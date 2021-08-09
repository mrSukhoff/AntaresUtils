using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AntaresUtilsNetFramework
{
    public class AntaresUtils
    {
        private SqlConnection connection;
        public bool IsConnected { get; private set; }

        /// <summary>
        ////Соединение с БД 
        /// </summary>
        /// <param name="servername"></param>
        public void Connect(string servername)
        {
            Disconnect();
            string connectionString = "Data Source=" + servername + ";Initial Catalog=AntaresTracking_QA;Persist Security Info=True;User ID=tav;Password=tav";
            connection = new SqlConnection(connectionString);
            connection.Open();
            IsConnected = true;
        }

        /// <summary>
        /// Отключеие от БД
        /// </summary>
        public void Disconnect()
        {
            if (IsConnected)
            {
                if (connection != null)
                {
                    connection.Close();
                    IsConnected = false;
                }
            }
        }

        public List<string> GetRecipeList() 
        {
            List<string> results = new List<string>();
            
            //Создаем запрос к БД
            string cmdString = "SELECT [Id] FROM [AntaresTracking_QA].[dbo].[Recipe]";
            SqlCommand cmd = new SqlCommand(cmdString, connection);
            // И выполняем его
            SqlDataReader reader = cmd.ExecuteReader();
            //Читаем все результаты
            while (reader.Read())
            {
                results.Add(reader.GetValue(0).ToString());
            }

            //Всё закрываем
            reader.Close();
            cmd.Dispose();

            results.Sort();
            return results;
        }

        public List<RecipeGeometry> GetRecipeGeometry(string recipeId)
        {
            List<RecipeGeometry> results = new List<RecipeGeometry>();

            //Создаем запрос к БД
            string cmdString = string.Format("SELECT [LineId],[ItemType],[X],[Y],[Z] FROM [AntaresTracking_QA].[dbo].[ItemTypeGeometry] where RecipeId = '{0}'",recipeId);
            SqlCommand cmd = new SqlCommand(cmdString, connection);
            // И выполняем его
            SqlDataReader reader = cmd.ExecuteReader();
            //Читаем все результаты
            while (reader.Read())
            {
                RecipeGeometry r = new RecipeGeometry();
                int.TryParse(reader.GetValue(0).ToString(), out r.LineId);
                int.TryParse(reader.GetValue(1).ToString(), out r.ItemType);
                int.TryParse(reader.GetValue(2).ToString(), out r.X);
                int.TryParse(reader.GetValue(3).ToString(), out r.Y);
                int.TryParse(reader.GetValue(4).ToString(), out r.Z);
                if (r.ItemType == 300 || r.ItemType == 400) results.Add(r);
            }

            //Всё закрываем
            reader.Close();
            cmd.Dispose();

            results.Sort();
            return results;
        }

        public void SetRecipeGeometry(List<RecipeGeometry> recipeGeometries, string recipeId)
        {
            foreach (RecipeGeometry r in recipeGeometries)
            {
                //Создаем запрос к БД
                string cmdString = string.Format("update [AntaresTracking_QA].[dbo].[ItemTypeGeometry] set X = {0}, Y = {1}, Z = {2} where RecipeId = '{3}' and LineID = {4} and ItemType = {5}",
                    r.X,r.Y,r.Z,recipeId,r.LineId,r.ItemType);
                SqlCommand cmd = new SqlCommand(cmdString, connection);
                //cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
    
    
    }

    public class RecipeGeometry : IComparable<RecipeGeometry>
    {
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
