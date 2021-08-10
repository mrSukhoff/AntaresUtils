using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntaresUtilsNetFramework
{
    public partial class MainForm : Form
    {
        List<Server> Servers;
        readonly AntaresUtils au = new AntaresUtils();

        public MainForm()
        {
            InitializeComponent();
            //Создаем список объектов городов
            LoadServerList();
            //заполняем список серверов
            foreach (var s in Servers)
            {
                CitiesBox.Items.Add(s.Name);
            }
            CitiesBox.SelectedIndex = 0;
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
                string servername = CitiesBox.SelectedItem.ToString();
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
    }
    class Server
    {
        public string Name { get; set; }
        public string FQN { get; set; }
        public string DBName { get; set; }
    }

}
