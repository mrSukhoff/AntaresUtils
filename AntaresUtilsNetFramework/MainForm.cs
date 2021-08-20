using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AntaresUtilities;
using DataMatrix.net;

namespace AntaresUtilsNetFramework
{
    public partial class MainForm : Form
    {
        //Фасад утилит
        readonly BusinessLogic au = new BusinessLogic();

        public MainForm()
        {
            InitializeComponent();

            //заполняем список серверов
            foreach (string s in au.ServerNames)
            {
                CryptoServerBox.Items.Add(s);
                GeometryServerBox.Items.Add(s);
                RecipesServerBox.Items.Add(s);
                WOServerBox.Items.Add(s);
                CounterServerBox.Items.Add(s);
            }
            CryptoServerBox.SelectedIndex = 0;
            GeometryServerBox.SelectedIndex = 0;
            RecipesServerBox.SelectedIndex = 0;
            WOServerBox.SelectedIndex = 0;
            CounterServerBox.SelectedIndex = 0;
        }

        //Получаем список рецептов с выбраного сервера
        private void GetRecipesButton_Click(object sender, EventArgs e)
        {
            GeometryGridView.Rows.Clear();
            RecipesBox.Items.Clear();
            try
            {
                foreach (string recipe in au.GetRecipeList())
                {
                    RecipesBox.Items.Add(recipe);
                }
                RecipesBox.SelectedIndex = 0;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Получаем с сервера геометрию выбраного рецепта
        private void GetGeometryButton_Click(object sender, EventArgs e)
        {
            GeometryGridView.Rows.Clear();
            if (RecipesBox.SelectedItem is null) return;
            try
            {
                
                List<RecipeGeometry> recipeGeometryList = au.GetRecipeGeometriesList(RecipesBox.SelectedItem.ToString());
                foreach (RecipeGeometry r in recipeGeometryList)
                {
                    GeometryGridView.Rows.Add(r.LineId, r.ItemType, r.X, r.Y, r.Z, r.X * r.Y * r.Z);
                }

                RecipeNameTextBox.Text = au.GetRecipeDescription(RecipesBox.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Записывает новую геометрию в БД из таблицы
        private void SendButton_Click(object sender, EventArgs e)
        {
            if (GeometryGridView.Rows.Count == 0) return;

            DialogResult result = MessageBox.Show("Are you sure?", "Save geometry to DB", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes) return;

            List<RecipeGeometry> list = new List<RecipeGeometry>();
            
            for (int i=0; i<GeometryGridView.Rows.Count; i++)
            {
                var cells = GeometryGridView.Rows[i].Cells;
                RecipeGeometry r = new RecipeGeometry
                {
                    RecipeId = RecipesBox.SelectedItem.ToString(),
                    LineId = int.Parse(cells[0].Value.ToString()),
                    ItemType = int.Parse(cells[1].Value.ToString()),
                    X = int.Parse(cells[2].Value.ToString()),
                    Y = int.Parse(cells[3].Value.ToString()),
                    Z = int.Parse(cells[4].Value.ToString())
                };
                list.Add(r);
            }

            au.UpdateRecipeGeometryInDb(list);
        }

        //При изменении содержимого проверяет корректность и пересчитывает поля
        private void GeometryGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string message = "Must be a positive integer!";
            for (int i = 0; i < GeometryGridView.Rows.Count; i++)
            {
                if  (!int.TryParse(GeometryGridView[2,i].Value.ToString(),out int x) || x<1)
                {
                    MessageBox.Show(message);
                    GeometryGridView[2, i].Value = 1;
                    x = 1;
                }
                if (!int.TryParse(GeometryGridView[3, i].Value.ToString(), out int y) || y < 1)
                {
                    MessageBox.Show(message);
                    GeometryGridView[3, i].Value = 1;
                    y = 1;
                }
                if (!int.TryParse(GeometryGridView[4, i].Value.ToString(), out int z) || z < 1)
                {
                    MessageBox.Show(message);
                    GeometryGridView[4, i].Value = 1;
                    y = 1;
                }
                GeometryGridView[5, i].Value = x * y * z;
            }
        }

        //Получает список материалов с выбранного сервера
        private void GetGMIDsButton_Click(object sender, EventArgs e)
        {
            RecipesGridView.Rows.Clear();
            GMIDBox.Items.Clear();
            try
            {
                foreach (string material in au.GetMaterialsList())
                {
                    GMIDBox.Items.Add(material);
                }
                GMIDBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Получает список рецептов связанных с выбранным материалом
        private void GetRecipeListButton_Click(object sender, EventArgs e)
        {
            RecipesGridView.Rows.Clear();
            if (GMIDBox.SelectedItem is null) return;
            try
            {
                List<RecipeGeometry> recipeGeometryList = au.GetRecipesListAssociatedWithGMID(GMIDBox.SelectedItem.ToString());
                foreach (RecipeGeometry r in recipeGeometryList)
                {
                    RecipesGridView.Rows.Add(r.RecipeId, r.LineId, r.ItemType, r.Total);
                }

                MaterialNameTextBox.Text = au.GetMaterialDescription(GMIDBox.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Сохраняет список рецептов с геометрией в файл
        private void SaveToFileButton_Click(object sender, EventArgs e)
        {
            if (GMIDBox.Items.Count == 0 || RecipesGridView.Rows.Count == 0) return;
            SaveFileDialog dialog = new SaveFileDialog
            {
                FileName = GMIDBox.SelectedItem.ToString(),
                DefaultExt = "xml",
                InitialDirectory = Application.StartupPath
            };
            if (dialog.ShowDialog(this) == DialogResult.Cancel) return;
            string filename = dialog.FileName;
            au.SaveMaterialGeometriesToFile(filename);
        }
        
        //Загружает список рецептов с геометрией из файла
        private void LoadFromFileButton_Click(object sender, EventArgs e)
        {
            if (GMIDBox.Items.Count == 0) return;
            OpenFileDialog dialog = new OpenFileDialog
            {
                DefaultExt = "xml",
                InitialDirectory = Application.StartupPath
            };
            if (dialog.ShowDialog(this) == DialogResult.Cancel) return;
            string filename = dialog.FileName;

            RecipesGridView.Rows.Clear();

            List<RecipeGeometry> r = au.LoadMaterialGeometriesfromFile(filename);

            GMIDBox.SelectedItem = au.CurrentGMID;
            if (GMIDBox.SelectedItem.ToString() != au.CurrentGMID) 
            {
                MessageBox.Show("Check the Server!");
                MainTabControl_SelectedIndexChanged(null, null);
                return;
            }
            
            foreach (var rg in r)
            {
                RecipesGridView.Rows.Add(rg.RecipeId, rg.LineId, rg.ItemType, rg.X * rg.Y * rg.Z);
            }
        }
        
        //очистка при переключении вкладок
        private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Crypto
            ClearCryptoResultFields();
            SgtinBox.Text = "";
            GtinBox.Text = "";
            SerialBox.Text = "";
            
            //Geometry
            RecipesBox.Items.Clear();
            RecipesBox.Text = "";
            GeometryGridView.Rows.Clear();
            RecipeNameTextBox.Text = "";

            //Recipes
            GMIDBox.Items.Clear();
            GMIDBox.Text = "";
            RecipesGridView.Rows.Clear();
            au.Clear();
            MaterialNameTextBox.Text = "";

            //workorders
            ClerarWOWindow();
            WOListBox.Items.Clear();
            WOListBox.Text = "";

            //Counters
            CountedLotListBox.Items.Clear();
            CountedLotListBox.Text = "";
            CountedAggregationTreeView.Nodes.Clear();
        }

        //Сохраняет текущий список рецептов с геометрией в БД
        private void UpdateDbButton_Click(object sender, EventArgs e)
        {
            if (GMIDBox.SelectedItem is null || RecipesGridView.Rows.Count == 0) return;
            DialogResult result = MessageBox.Show("Are you sure?", "Save geometry to DB", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) au.SaveMaterialGeometriesToDb();
        }

        private void GetCryptoСodeButton_Click(object sender, EventArgs e)
        {
            ClearCryptoResultFields();

            try
            {
                Package package = new Package()
                {
                    GTIN = GtinBox.Text,
                    Serial = SerialBox.Text
                };
            
                Package result = au.GetCrypto(package);
                CryptoKeyBox.Text = result.CryptoKey;
                CryptoCodeBox.Text = result.CryptoCode;
                ShowDM("01" + result.GTIN + "21" + result.Serial + char.ConvertFromUtf32(29) + "91" + result.CryptoKey + 
                    char.ConvertFromUtf32(29) + "92" + result.CryptoCode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // По входной строке рисует DMC
        private void ShowDM(string dataMatrixString)
        {
            DmtxImageEncoder encoder = new DmtxImageEncoder();
            DmtxImageEncoderOptions options = new DmtxImageEncoderOptions
            {
                ModuleSize = 5,
                MarginSize = 4
            };
            Bitmap encodedBitmap = encoder.EncodeImage(dataMatrixString, options);
            DMPictureBox.Image = encodedBitmap;
        }

        //Очищает поля вывода криптоданный
        private void ClearCryptoResultFields()
        {
            CryptoKeyBox.Text = "";
            CryptoCodeBox.Text = "";
            if (DMPictureBox.Image != null) DMPictureBox.Image.Dispose();
            DMPictureBox.Image = null;
        }
        
        // Метод при изменении SGTIN меняет поля GTIN и серийного номера
        private void SgtinBox_TextChanged(object sender, EventArgs e)
        {
            if (SgtinBox.Text.Length == 27)
            {
                //странная переменная, но без неё не работает
                string text = SgtinBox.Text;
                GtinBox.Text = text.Substring(0, 14);
                SerialBox.Text = text.Substring(14, 13);
            }
        }

        // Метод при изменении поля GTIN меняет поле SGTIN
        private void GtinBox_TextChanged(object sender, EventArgs e)
        {
            if (GtinBox.Text.Length > 14) GtinBox.Text = GtinBox.Text.Substring(0, 13);
            if (GtinBox.Text.Length == 14)
            {
                SgtinBox.Text = GtinBox.Text + SerialBox.Text;
            }
        }

        // Метод при изменении поля cерийного номера меняет SGTIN
        private void SerialBox_TextChanged(object sender, EventArgs e)
        {
            if (SerialBox.Text.Length > 13) SerialBox.Text = SerialBox.Text.Substring(0, 13);
            if (SerialBox.Text.Length == 13)
            {
                SgtinBox.Text = GtinBox.Text + SerialBox.Text;
            }
        }

        //Метод сохраняет картинку в файл
        private void SaveImageButton_Click(object sender, EventArgs e)
        {
            if (DMPictureBox.Image == null) return;

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                DefaultExt = "bmp",
                FileName = SgtinBox.Text
            };
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;

            string path = saveFileDialog.FileName;
            DMPictureBox.Image.Save(path);
        }

        //при вставке текста выбирает рецепт с тем же именем
        private void RecipesBox_TextChanged(object sender, EventArgs e)
        {
            RecipesBox.SelectedItem = RecipesBox.Text;
        }

        //при вставке текста выбирает этот элемент
        private void GMIDBox_TextChanged(object sender, EventArgs e)
        {
            GMIDBox.SelectedItem = GMIDBox.Text;
        }

        //При изменении выбранного сервера вызывает метод смены выбранного сервера
        private void CryptoServerBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            au.SelectServer(CryptoServerBox.SelectedItem.ToString());
        }
        
        //При изменении выбранного сервера вызывает метод смены выбранного сервера
        private void GeometryServerBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            au.SelectServer(GeometryServerBox.SelectedItem.ToString());
        }

        //При изменении выбранного сервера вызывает метод смены выбранного сервера
        private void RecipesServerBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            au.SelectServer(RecipesServerBox.SelectedItem.ToString());
        }

        private void GetWOsButton_Click(object sender, EventArgs e)
        {
            ClerarWOWindow();

            try
            {
                foreach (string wo in au.GetWorkordersList())
                {
                    WOListBox.Items.Add(wo);
                }
                WOListBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void ClerarWOWindow()
        {
            WOListBox.Items.Clear();
            WODescriptionBox.Text = "";
            WOLineInfoBox.Text = "";
            WOLotBox.Text = "";
            WOStatusBox.Text = "";
            WOQuantityBox.Text = "";
            WOExpiryBox.Text = "";
            WOManufacturedBox.Text = "";
        }

        private void GetWODetailButton_Click(object sender, EventArgs e)
        {
            if (WOListBox.SelectedItem == null) return;
            WorkOrder w = au.GetWorOrderDetails(WOListBox.SelectedItem.ToString());
            WODescriptionBox.Text = w.Descrition;
            WOLineInfoBox.Text = w.Line;
            WOLotBox.Text = w.Lot;
            WOStatusBox.Text = w.Status;
            WOQuantityBox.Text = w.Quantity;
            WOExpiryBox.Text = w.Expiry;
            WOManufacturedBox.Text = w.Manufactured;
        }

        private void WOUpdateDbButton_Click(object sender, EventArgs e)
        {
            if (WOListBox.SelectedItem == null) return;
            DialogResult result = MessageBox.Show("Are you sure?", "Save WorkOrder to DB", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes) return;

            WorkOrder wo = new WorkOrder()
            {
                Id = WOListBox.SelectedItem.ToString(),
                Expiry = WOExpiryBox.Text,
                Manufactured = WOManufacturedBox.Text
            };
            au.UpdateWoInDb(wo);
        }

        private void WOListBox_TextChanged(object sender, EventArgs e)
        {
            WOListBox.SelectedItem = WOListBox.Text;
        }

        private void WOServerBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            au.SelectServer(WOServerBox.SelectedItem.ToString());
        }
    }
}
