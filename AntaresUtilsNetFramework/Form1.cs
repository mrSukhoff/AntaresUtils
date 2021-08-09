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
        readonly List<City> Cities;
        AntaresUtils au = new AntaresUtils();

        public Form1()
        {
            InitializeComponent();
            //Создаем список объектов городов
            Cities = new List<City>
            {
                new City {Name = "Иркутск", Server = "irk-sql-tst" }/*,
                new City {Name = "Иркутск", Server = "irk-m1-sql" },
                new City {Name = "Тюмень", Server = "tmn-m1-sql" },
                new City {Name = "Уссурийск", Server = "uss-m1-sql" },
                new City {Name = "Санкт-Петербург", Server = "spb-m1-sql" }
            */};

            //Привязываем его к combobox
            CitiesBox.DataSource = Cities;
            //И сообщаем что показывать, а что выдавать
            CitiesBox.DisplayMember = "Name";
            CitiesBox.ValueMember = "Server";
            //Устанавливаем выбранный элемент
            CitiesBox.SelectedItem = 0;
        }

        private void GetRecipesButton_Click(object sender, EventArgs e)
        {
            GeometryGridView.Rows.Clear();
            RecipesBox.Items.Clear();
            try
            {
                au.Connect(CitiesBox.SelectedValue.ToString());

                RecipesBox.Items.Clear();
                foreach (string recipe in au.GetRecipeList())
                {
                    RecipesBox.Items.Add(recipe);
                }
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
                RecipeGeometry r = new RecipeGeometry();
                r.LineId = (int)cells[0].Value;
                r.ItemType = (int)cells[1].Value;
                r.X = (int)cells[2].Value;
                r.Y = (int)cells[3].Value;
                r.Z = (int)cells[4].Value;
                list.Add(r);
            }
            string recipeId = RecipesBox.SelectedItem.ToString();
            au.SetRecipeGeometry(list, recipeId);
        }

    }
    class City
    {
        public string Name { get; set; }
        public string Server { get; set; }
    }

}
