using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntaresUtilsNetFramework
{
    public partial class Form1 : Form
    {
        List<Server> Servers;
        AntaresUtils au = new AntaresUtils();

        public Form1()
        {
            InitializeComponent();
            //Создаем список объектов городов
            LoadServerList();
            //Привязываем его к combobox
            foreach (var s in Servers)
            {
                CitiesBox.Items.Add(s.Name);
            }
            CitiesBox.SelectedIndex = 0;
        }

        private void LoadServerList() 
        {
            Servers = new List<Server>
            {
                new Server {Name = "Иркутск", FQN = "irk-sql-tst", DBName = "AntaresTracking_QA" }/*,
                new Server {Name = "Иркутск", Server = "irk-m1-sql", DBName = "AntaresTracking_PRD" },
                new Server {Name = "Тюмень", Server = "tmn-m1-sql", DBName = "AntaresTracking_PRD"  },
                new Server {Name = "Уссурийск", Server = "uss-m1-sql" , DBName = "AntaresTracking_PRD" },
                new City {Name = "Санкт-Петербург", Server = "spb-m1-sql" , DBName = "AntaresTracking_PRD" }
            */};
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

                RecipesBox.Items.Clear();
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
            try
            {
                if (RecipesBox.SelectedItem == null) return;
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

        private void GeometryGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string message = "Должно быть целое положительное число!";
            int x, y, z;
            for (int i = 0; i < GeometryGridView.Rows.Count; i++)
            {
                if  (!int.TryParse(GeometryGridView[2,i].Value.ToString(),out x) || x<1)
                {
                    MessageBox.Show(message);
                    GeometryGridView[2, i].Value = 1;
                    x = 1;
                }
                if (!int.TryParse(GeometryGridView[3, i].Value.ToString(), out y) || y < 1)
                {
                    MessageBox.Show(message);
                    GeometryGridView[3, i].Value = 1;
                    y = 1;
                }
                if (!int.TryParse(GeometryGridView[4, i].Value.ToString(), out z) || z < 1)
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
