using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using DataMatrix.net;

namespace AntaresUtilsNetFramework
{
    public partial class MainForm : Form
    {
        //Список используемых серверов
        List<Server> Servers;
        
        readonly AntaresUtils au = new AntaresUtils();
        
        //текущая информаци о геометрии рецепта
        private List<RecipeGeometry> _recipeGeometries;
        public MainForm()
        {
            InitializeComponent();
            //Создаем список серверов
            LoadServerList();
            //заполняем список серверов
            foreach (var s in Servers)
            {
                CryptoServerBox.Items.Add(s.Name);
                GeometryServerBox.Items.Add(s.Name);
                RecipesServerBox.Items.Add(s.Name);
            }
            CryptoServerBox.SelectedIndex = 0;
            GeometryServerBox.SelectedIndex = 0;
            RecipesServerBox.SelectedIndex = 0;
        }

        //Загрузка списка серверов либо из файла либо, если файл не найден, только тестового
        private void LoadServerList()
        {
            string path = @"server.ini";
            if (File.Exists(path))
            {
                Servers = new List<Server>();
                try
                {
                    List<string> lines = new List<string>();
                    using (StreamReader sr = new StreamReader(path))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            lines.Add(line);
                        }
                    }

                    foreach (string l in lines)
                    {
                        string[] word = l.Split(' ');
                        string name = word[0];
                        string fqn = word[1];
                        string dbname = word[2];
                        Server server = new Server
                        {
                            Name = name,
                            FQN = fqn,
                            DBName = dbname
                        };
                        Servers.Add(server);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                Servers = new List<Server> { new Server { Name = "Иркутск", FQN = "irk-sql-tst", DBName = "AntaresTracking_QA" } };
            }
            
        }

        //Получаем список рецептов с выбраного сервера
        private void GetRecipesButton_Click(object sender, EventArgs e)
        {
            GeometryGridView.Rows.Clear();
            RecipesBox.Items.Clear();
            try
            {
                string servername = GeometryServerBox.SelectedItem.ToString();
                Server server = Servers.First(s => s.Name == servername);

                au.Connect(server.FQN, server.DBName);

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
                
                List<RecipeGeometry> recipeGeometryList = au.GetRecipeGeometry(RecipesBox.SelectedItem.ToString());
                foreach (RecipeGeometry r in recipeGeometryList)
                {
                    GeometryGridView.Rows.Add(r.LineId, r.ItemType, r.X, r.Y, r.Z, r.X * r.Y * r.Z);
                }

                RecipeNameTextBox.Text = au.GetRecipeName(RecipesBox.SelectedItem.ToString());
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

            au.SetRecipeGeometry(list);
        }

        //При изменении содержимого проверяет корректность и пересчитывает поля
        private void GeometryGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string message = "Должно быть целое положительное число!";
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
                string servername = RecipesServerBox.SelectedItem.ToString();
                Server server = Servers.First(s => s.Name == servername);

                au.Connect(server.FQN, server.DBName);

                foreach (string material in au.GetGMIDList())
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

                List<RecipeGeometry> recipeGeometryList = au.GetRecipesListByGMID(GMIDBox.SelectedItem.ToString());
                foreach (RecipeGeometry r in recipeGeometryList)
                {
                    RecipesGridView.Rows.Add(r.RecipeId, r.LineId, r.ItemType, r.Total);
                }
                _recipeGeometries = recipeGeometryList;

                MaterialNameTextBox.Text = au.GetMaterialName(GMIDBox.SelectedItem.ToString());
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

            GMIDGeometry r = new GMIDGeometry
            {
                GMID = GMIDBox.SelectedItem.ToString(),
                ListOfrecipeGeometries = _recipeGeometries
            };
            XmlSerializer formatter = new XmlSerializer(typeof(GMIDGeometry));
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, r);
            }
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

            XmlSerializer deserializer = new XmlSerializer(typeof(GMIDGeometry));
            GMIDGeometry r = new GMIDGeometry();
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                r=(GMIDGeometry)deserializer.Deserialize(fs);
            }

            _recipeGeometries = r.ListOfrecipeGeometries;
            GMIDBox.SelectedItem = r.GMID;
            if (GMIDBox.SelectedItem.ToString() != r.GMID) 
            {
                MessageBox.Show("Check the Server!");
                MainTabControl_SelectedIndexChanged(null, null);
                return;
            }
            
            foreach (var rg in _recipeGeometries)
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
            _recipeGeometries = null;
            MaterialNameTextBox.Text = "";

            au.Disconnect();
        }

        //Сохраняет текущий список рецептов с геометрией в БД
        private void UpdateDbButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?", "Save geometry to DB", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes) return;
            au.SetRecipesGeometry(_recipeGeometries);
        }

        private void GetCryptoСodeButton_Click(object sender, EventArgs e)
        {
            ClearCryptoResultFields();

            string servername = CryptoServerBox.SelectedItem.ToString();
            Server server = Servers.First(s => s.Name == servername);
            au.Connect(server.FQN, server.DBName);
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

        // Метод при изменении поля мерийного номера меняет SGTIN
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

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "bmp";
            saveFileDialog.FileName = SgtinBox.Text;
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;

            string path = saveFileDialog.FileName;
            DMPictureBox.Image.Save(path);
        }

        //при вставке текста выбирает этот элемент
        private void RecipesBox_TextChanged(object sender, EventArgs e)
        {
            RecipesBox.SelectedItem = RecipesBox.Text;
        }

        //при вставке текста выбирает этот элемент
        private void GMIDBox_TextChanged(object sender, EventArgs e)
        {
            GMIDBox.SelectedItem = GMIDBox.Text;
        }
    }

    //Формат списка серверов
    public class Server
    {
        public string Name { get; set; }
        public string FQN { get; set; }
        public string DBName { get; set; }
    }

    //Описывает структуру объектов для сериализации
    public class GMIDGeometry
    {
        public string GMID;
        public List<RecipeGeometry> ListOfrecipeGeometries;
    }
}
