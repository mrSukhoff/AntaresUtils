using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace AntaresUtilsNetFramework
{
    public partial class MainForm : Form
    {
        List<Server> Servers;
        readonly AntaresUtils au = new AntaresUtils();
        List<RecipeGeometry> _recipeGeometries;
        public MainForm()
        {
            InitializeComponent();
            //Создаем список объектов городов
            LoadServerList();
            //заполняем список серверов
            foreach (var s in Servers)
            {
                GeometryServerBox.Items.Add(s.Name);
                RecipesServerBox.Items.Add(s.Name);
            }
            GeometryServerBox.SelectedIndex = 0;
            RecipesServerBox.SelectedIndex = 0;
        }

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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (GeometryGridView.Rows.Count == 0) return;
            List<RecipeGeometry> list = new List<RecipeGeometry>();
            DialogResult result = MessageBox.Show("Are you sure?", "Save geometry to DB", MessageBoxButtons.YesNo);
            if (result != DialogResult.OK) return;
            for (int i=0; i<GeometryGridView.Rows.Count; i++)
            {
                var cells = GeometryGridView.Rows[i].Cells;
                RecipeGeometry r = new RecipeGeometry
                {
                    LineId = int.Parse(cells[0].Value.ToString()),
                    ItemType = int.Parse(cells[1].Value.ToString()),
                    X = int.Parse(cells[2].Value.ToString()),
                    Y = int.Parse(cells[3].Value.ToString()),
                    Z = int.Parse(cells[4].Value.ToString())
                };
                list.Add(r);
            }
            string recipeId = RecipesBox.SelectedItem.ToString();
            au.SetRecipeGeometry(list, recipeId);
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

        private void GetRecipeListButton_Click(object sender, EventArgs e)
        {
            RecipesGridView.Rows.Clear();
            if (GMIDBox.SelectedItem is null) return;
            string gmid = GMIDBox.SelectedItem.ToString();
            try
            {

                List<RecipeGeometry> recipeGeometryList = au.GetRecipesListByGMID(GMIDBox.SelectedItem.ToString());
                foreach (RecipeGeometry r in recipeGeometryList)
                {
                    RecipesGridView.Rows.Add(r.RecipeId, r.LineId, r.ItemType, r.Total);
                }
                _recipeGeometries = recipeGeometryList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

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

            RecepiesForSerialization r = new RecepiesForSerialization();
            r.GMID = GMIDBox.SelectedItem.ToString();
            r.ListOfrecipeGeometries = _recipeGeometries;
            XmlSerializer formatter = new XmlSerializer(typeof(RecepiesForSerialization));
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, r);
            }
        }

        private void LoadFromFileButton_Click(object sender, EventArgs e)
        {
            if (GMIDBox.Items.Count == 0 || RecipesGridView.Rows.Count == 0) return;
            OpenFileDialog dialog = new OpenFileDialog
            {
                DefaultExt = "xml",
                InitialDirectory = Application.StartupPath
            };
            if (dialog.ShowDialog(this) == DialogResult.Cancel) return;
            string filename = dialog.FileName;

            RecipesGridView.Rows.Clear();

            XmlSerializer deserializer = new XmlSerializer(typeof(RecepiesForSerialization));
            RecepiesForSerialization r = new RecepiesForSerialization();
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                r=(RecepiesForSerialization)deserializer.Deserialize(fs);
            }

            _recipeGeometries = r.ListOfrecipeGeometries;
            GMIDBox.SelectedItem = r.GMID;
            if (GMIDBox.SelectedItem.ToString() != r.GMID) 
            {
                MessageBox.Show("Не тот город!");
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
            RecipesBox.Items.Clear();
            RecipesBox.Text = "";
            GeometryGridView.Rows.Clear();
            GMIDBox.Items.Clear();
            GMIDBox.Text = "";
            RecipesGridView.Rows.Clear();
            au.Disconnect();
        }
    }
    class Server
    {
        public string Name { get; set; }
        public string FQN { get; set; }
        public string DBName { get; set; }
    }

    public class RecepiesForSerialization
    {
        public string GMID;
        public List<RecipeGeometry> ListOfrecipeGeometries;
    }

    public class RecipeGeometry : IComparable<RecipeGeometry>
    {
        public string RecipeId;
        public int LineId;
        public int ItemType;
        public int X;
        public int Y;
        public int Z;
        public int Total;

        public int CompareTo(RecipeGeometry other)
        {
            if (this.LineId > other.LineId) return 1;
            else if (this.LineId > other.LineId) return -1;

            if (this.ItemType > other.ItemType) return 1;
            else if (this.ItemType > other.ItemType) return -1;
            return 0;
        }
    }
}
