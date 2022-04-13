using AntaresUtilities;
using DataMatrix.net;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

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
                CGServerComboBox.Items.Add(s);
                AGServerComboBox.Items.Add(s);
                RecipesServerComboBox.Items.Add(s);
                AWOServerComboBox.Items.Add(s);
                CCServerComboBox.Items.Add(s);
            }
            CGServerComboBox.SelectedIndex = 0;
            AGServerComboBox.SelectedIndex = 0;
            RecipesServerComboBox.SelectedIndex = 0;
            AWOServerComboBox.SelectedIndex = 0;
            CCServerComboBox.SelectedIndex = 0;
        }

        //очистка при переключении вкладок
        private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Crypto
            ClearCryptoResultFields();
            CGSgtinTextBox.Text = "";
            CGGtinTextBox.Text = "";
            CGSerialTextBox.Text = "";

            //Geometry
            AGRecipesComboBox.Items.Clear();
            AGRecipesComboBox.Text = "";
            AGGridView.Rows.Clear();
            AGRecipeNameTextBox.Text = "";
            AGGetAgregationGeometryButton.Enabled = false;
            AGSendAgregationToDbButton.Enabled = false;

            //Recipes
            RecipesGMIDComboBox.Items.Clear();
            RecipesGMIDComboBox.Text = "";
            RecipesGridView.Rows.Clear();
            au.Clear();
            RecipesMaterialNameTextBox.Text = "";

            //workorders
            ClerarWOWindow();
            AWOWorkordersListComboBox.Items.Clear();
            AWOWorkordersListComboBox.Text = "";

            //Counters
            CCWorkordersListComboBox.Items.Clear();
            CCWorkordersListComboBox.Text = "";
            CountedAggregationTreeView.Nodes.Clear();
        }


        //****************************************************** CryptoGetter ************************************************

        private void GetCryptoСodeButton_Click(object sender, EventArgs e)
        {
            ClearCryptoResultFields();

            try
            {
                Package package = new Package()
                {
                    GTIN = CGGtinTextBox.Text,
                    Serial = CGSerialTextBox.Text
                };

                Package result = au.GetCrypto(package);
                CGCryptoKeyTextBox.Text = result.CryptoKey;
                CGCryptoCodeTextBox.Text = result.CryptoCode;
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
            CGDataMatrixPictureBox.Image = encodedBitmap;
        }

        //Очищает поля вывода криптоданный
        private void ClearCryptoResultFields()
        {
            CGCryptoKeyTextBox.Text = "";
            CGCryptoCodeTextBox.Text = "";
            if (CGDataMatrixPictureBox.Image != null) CGDataMatrixPictureBox.Image.Dispose();
            CGDataMatrixPictureBox.Image = null;
        }

        // Метод при изменении SGTIN меняет поля GTIN и серийного номера
        private void SgtinBox_TextChanged(object sender, EventArgs e)
        {
            if (CGSgtinTextBox.Text.Length == 27)
            {
                //странная переменная, но без неё не работает
                string text = CGSgtinTextBox.Text;
                CGGtinTextBox.Text = text.Substring(0, 14);
                CGSerialTextBox.Text = text.Substring(14, 13);
            }
        }

        // Метод при изменении поля GTIN меняет поле SGTIN
        private void GtinBox_TextChanged(object sender, EventArgs e)
        {
            if (CGGtinTextBox.Text.Length > 14) CGGtinTextBox.Text = CGGtinTextBox.Text.Substring(0, 13);
            if (CGGtinTextBox.Text.Length == 14)
            {
                CGSgtinTextBox.Text = CGGtinTextBox.Text + CGSerialTextBox.Text;
            }
        }

        // Метод при изменении поля cерийного номера меняет SGTIN
        private void SerialBox_TextChanged(object sender, EventArgs e)
        {
            if (CGSerialTextBox.Text.Length > 13) CGSerialTextBox.Text = CGSerialTextBox.Text.Substring(0, 13);
            if (CGSerialTextBox.Text.Length == 13)
            {
                CGSgtinTextBox.Text = CGGtinTextBox.Text + CGSerialTextBox.Text;
            }
        }

        //Метод сохраняет картинку в файл
        private void SaveImageButton_Click(object sender, EventArgs e)
        {
            if (CGDataMatrixPictureBox.Image == null) return;

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                DefaultExt = "bmp",
                FileName = CGSgtinTextBox.Text
            };
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;

            string path = saveFileDialog.FileName;
            CGDataMatrixPictureBox.Image.Save(path);
        }

        //При изменении выбранного сервера вызывает метод смены выбранного сервера
        private void CryptoServerBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            au.SelectServer(CGServerComboBox.SelectedItem.ToString());
        }


        //****************************************************** AggregationGeometries ***********************************************

        //Получаем список рецептов с выбраного сервера
        private void GetRecipesButton_Click(object sender, EventArgs e)
        {
            AGGridView.Rows.Clear();
            AGRecipesComboBox.Items.Clear();
            try
            {
                foreach (string recipe in au.GetRecipeList())
                {
                    AGRecipesComboBox.Items.Add(recipe);
                }
                AGRecipesComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            AGGetAgregationGeometryButton.Enabled = true;
            AGSendAgregationToDbButton.Enabled = true;
        }

        //Получаем с сервера геометрию выбраного рецепта
        private void GetGeometryButton_Click(object sender, EventArgs e)
        {
            AGGridView.Rows.Clear();
            if (AGRecipesComboBox.SelectedItem is null) return;
            try
            {

                List<RecipeGeometry> recipeGeometryList = au.GetRecipeGeometriesList(AGRecipesComboBox.SelectedItem.ToString());
                foreach (RecipeGeometry r in recipeGeometryList)
                {
                    AGGridView.Rows.Add(r.LineId, r.ItemType, r.X, r.Y, r.Z, r.X * r.Y * r.Z);
                }

                AGRecipeNameTextBox.Text = au.GetRecipeDescription(AGRecipesComboBox.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Записывает новую геометрию в БД из таблицы
        private void SendButton_Click(object sender, EventArgs e)
        {
            if (AGGridView.Rows.Count == 0) return;

            DialogResult result = MessageBox.Show("Are you sure?", "Save geometry to DB", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes) return;

            List<RecipeGeometry> list = new List<RecipeGeometry>();

            for (int i = 0; i < AGGridView.Rows.Count; i++)
            {
                var cells = AGGridView.Rows[i].Cells;
                RecipeGeometry r = new RecipeGeometry
                {
                    RecipeId = AGRecipesComboBox.SelectedItem.ToString(),
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
            for (int i = 0; i < AGGridView.Rows.Count; i++)
            {
                if (!int.TryParse(AGGridView[2, i].Value.ToString(), out int x) || x < 1)
                {
                    MessageBox.Show(message);
                    AGGridView[2, i].Value = 1;
                    x = 1;
                }
                if (!int.TryParse(AGGridView[3, i].Value.ToString(), out int y) || y < 1)
                {
                    MessageBox.Show(message);
                    AGGridView[3, i].Value = 1;
                    y = 1;
                }
                if (!int.TryParse(AGGridView[4, i].Value.ToString(), out int z) || z < 1)
                {
                    MessageBox.Show(message);
                    AGGridView[4, i].Value = 1;
                    y = 1;
                }
                AGGridView[5, i].Value = x * y * z;
            }
        }


        //****************************************************** Recipes *************************************************************

        //Получает список материалов с выбранного сервера
        private void GetGMIDsButton_Click(object sender, EventArgs e)
        {
            RecipesGridView.Rows.Clear();
            RecipesGMIDComboBox.Items.Clear();
            try
            {
                foreach (string material in au.GetMaterialsList())
                {
                    RecipesGMIDComboBox.Items.Add(material);
                }
                RecipesGMIDComboBox.SelectedIndex = 0;
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
            if (RecipesGMIDComboBox.SelectedItem is null) return;
            try
            {
                List<RecipeGeometry> recipeGeometryList = au.GetRecipesListAssociatedWithGMID(RecipesGMIDComboBox.SelectedItem.ToString());
                foreach (RecipeGeometry r in recipeGeometryList)
                {
                    RecipesGridView.Rows.Add(r.RecipeId, r.LineId, r.ItemType, r.Total);
                }

                RecipesMaterialNameTextBox.Text = au.GetMaterialDescription(RecipesGMIDComboBox.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Сохраняет список рецептов с геометрией в файл
        private void SaveToFileButton_Click(object sender, EventArgs e)
        {
            if (RecipesGMIDComboBox.Items.Count == 0 || RecipesGridView.Rows.Count == 0) return;
            SaveFileDialog dialog = new SaveFileDialog
            {
                FileName = RecipesGMIDComboBox.SelectedItem.ToString(),
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
            if (RecipesGMIDComboBox.Items.Count == 0) return;
            OpenFileDialog dialog = new OpenFileDialog
            {
                DefaultExt = "xml",
                InitialDirectory = Application.StartupPath
            };
            if (dialog.ShowDialog(this) == DialogResult.Cancel) return;
            string filename = dialog.FileName;

            RecipesGridView.Rows.Clear();

            List<RecipeGeometry> r = au.LoadMaterialGeometriesfromFile(filename);

            RecipesGMIDComboBox.SelectedItem = au.CurrentGMID;
            if (RecipesGMIDComboBox.SelectedItem.ToString() != au.CurrentGMID)
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

        //Сохраняет текущий список рецептов с геометрией в БД
        private void UpdateDbButton_Click(object sender, EventArgs e)
        {
            if (RecipesGMIDComboBox.SelectedItem is null || RecipesGridView.Rows.Count == 0) return;
            DialogResult result = MessageBox.Show("Are you sure?", "Save geometry to DB", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) au.SaveMaterialGeometriesToDb();
        }


        //при вставке текста выбирает рецепт с тем же именем
        private void RecipesBox_TextChanged(object sender, EventArgs e)
        {
            AGRecipesComboBox.SelectedItem = AGRecipesComboBox.Text;
        }

        //при вставке текста выбирает этот элемент
        private void GMIDBox_TextChanged(object sender, EventArgs e)
        {
            RecipesGMIDComboBox.SelectedItem = RecipesGMIDComboBox.Text;
        }

        //При изменении выбранного сервера вызывает метод смены выбранного сервера
        private void GeometryServerBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            au.SelectServer(AGServerComboBox.SelectedItem.ToString());
        }

        //При изменении выбранного сервера вызывает метод смены выбранного сервера
        private void RecipesServerBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            au.SelectServer(RecipesServerComboBox.SelectedItem.ToString());
        }


        //****************************************************** Active Workorders ***************************************************
        private void GetWOsButton_Click(object sender, EventArgs e)
        {
            ClerarWOWindow();

            try
            {
                foreach (string wo in au.GetWorkordersList())
                {
                    AWOWorkordersListComboBox.Items.Add(wo);
                }
                AWOWorkordersListComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClerarWOWindow()
        {
            AWOWorkordersListComboBox.Items.Clear();
            AWOWorkordersNameTextBox.Text = "";
            AWOLineInfoTextBox.Text = "";
            AWOLotTextBox.Text = "";
            AWOQuantityTextBox.Text = "";
            AWOExpiryTextBox.Text = "";
            AWOManufacturedTextBox.Text = "";
        }

        private void GetWODetailButton_Click(object sender, EventArgs e)
        {
            if (AWOWorkordersListComboBox.SelectedItem == null) return;
            WorkOrder w = au.GetWorOrderDetails(AWOWorkordersListComboBox.SelectedItem.ToString());
            AWOWorkordersNameTextBox.Text = w.Descrition;
            AWOLineInfoTextBox.Text = w.Line;
            AWOLotTextBox.Text = w.Lot;
            AWOQuantityTextBox.Text = w.Quantity;
            AWOExpiryTextBox.Text = w.Expiry;
            AWOManufacturedTextBox.Text = w.Manufactured;
            FillWoStatusComboBox();
            AWOStatusComboBox.SelectedIndex = AWOStatusComboBox.Items.IndexOf(au.WOStatuses[w.Status]);
        }

        private void FillWoStatusComboBox()
        {
            foreach (var p in au.WOStatuses)
            {
                AWOStatusComboBox.Items.Add(p.Value);
            }
        }

        private void WOUpdateDbButton_Click(object sender, EventArgs e)
        {
            if (AWOWorkordersListComboBox.SelectedItem == null) return;
            DialogResult result = MessageBox.Show("Are you sure?", "Save WorkOrder to DB", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes) return;

            WorkOrder wo = new WorkOrder()
            {
                Id = AWOWorkordersListComboBox.SelectedItem.ToString(),
                Expiry = AWOExpiryTextBox.Text,
                Manufactured = AWOManufacturedTextBox.Text,
                Status = au.WOStatuses.First(x => x.Value == AWOStatusComboBox.SelectedItem.ToString()).Key
            };
            AWOStatusComboBox.Items.Clear();
            au.UpdateWoInDb(wo);
        }

        private void WOListBox_TextChanged(object sender, EventArgs e)
        {
            AWOWorkordersListComboBox.SelectedItem = AWOWorkordersListComboBox.Text;
        }

        private void WOServerBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            au.SelectServer(AWOServerComboBox.SelectedItem.ToString());
        }


        //****************************************************** Case Counter *******************************************************

        private void CountedWorkorderListBox_TextChanged(object sender, EventArgs e)
        {
            CCWorkordersListComboBox.SelectedItem = CCWorkordersListComboBox.Text;
        }

        private void GetWorkorderListButton_Click(object sender, EventArgs e)
        {
            CCWorkordersListComboBox.Items.Clear();
            CCWorkordersListComboBox.Text = "";
            CountedAggregationTreeView.Nodes.Clear();

            try
            {
                foreach (string wo in au.GetClosedWorkorderList())
                {
                    CCWorkordersListComboBox.Items.Add(wo);
                }
                CCWorkordersListComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CounterServerBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            au.SelectServer(CCServerComboBox.SelectedItem.ToString());
        }

        private void CountButton_Click(object sender, EventArgs e)
        {
            CountedAggregationTreeView.Nodes.Clear();
            TreeNode root = au.GetLotTree(CCWorkordersListComboBox.SelectedItem.ToString());
            CountedAggregationTreeView.Nodes.Add(root);
        }

    }
}
