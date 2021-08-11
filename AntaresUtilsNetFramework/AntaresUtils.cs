using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AntaresUtilsNetFramework
{
    public class AntaresUtils
    {
        private SqlConnection connection;
        private string _DBname;
        public bool IsConnected { get; private set; }

        /// <summary>
        /// Соединение с БД 
        /// </summary>
        /// <param name="serverAdress"></param>
        /// <param name="dBname"></param>
        public void Connect(string serverAdress, string dBname)
        {
            Disconnect();
            string connectionString = "Data Source=" + serverAdress + ";Initial Catalog=" + dBname + ";Persist Security Info=True;User ID=tav;Password=tav";
            connection = new SqlConnection(connectionString);
            connection.Open();
            _DBname = dBname;
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
                    _DBname = null;
                    IsConnected = false;
                }
            }
        }

        public List<string> GetRecipeList()
        {
            List<string> results = new List<string>();

            //Создаем запрос к БД
            string cmdString = "SELECT [Id] FROM [" + _DBname + "].[dbo].[Recipe]";
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
            string cmdString = string.Format("SELECT [LineId],[ItemType],[X],[Y],[Z] FROM [{0}].[dbo].[ItemTypeGeometry] where RecipeId = '{1}'", _DBname, recipeId);
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
                string cmdString = string.Format("update [{0}].[dbo].[ItemTypeGeometry] set X = {1}, Y = {2}, Z = {3} where RecipeId = '{4}' and LineID = {5} and ItemType = {6}",
                    _DBname, r.X, r.Y, r.Z, recipeId, r.LineId, r.ItemType);
                SqlCommand cmd = new SqlCommand(cmdString, connection);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        public List<string> GetGMIDList()
        {
            List<string> results = new List<string>();

            //Создаем запрос к БД
            string cmdString = "SELECT [Id] FROM [" + _DBname + "].[dbo].[Material]";
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

        public List<RecipeGeometry> GetRecipesListByGMID(string material)
        {
            List<RecipeGeometry> results = new List<RecipeGeometry>();
            //Создаем запрос к БД
            string cmdString = string.Format("use [{0}]; SELECT r.Id,g.LineId,g.ItemType,g.X,g.Y,g.Z,g.X*g.Y*g.Z FROM [Material] as m join [Recipe] as r on r.GMID = m.Id join [ItemTypeGeometry] as g on g.RecipeId = r.Id where r.GMID = '{1}' order by r.Id, g.LineId",
                _DBname, material);
            SqlCommand cmd = new SqlCommand(cmdString, connection);
            // И выполняем его
            SqlDataReader reader = cmd.ExecuteReader();
            //Читаем все результаты
            while (reader.Read())
            {
                RecipeGeometry r = new RecipeGeometry();
                r.RecipeId = reader.GetValue(0).ToString();
                int.TryParse(reader.GetValue(1).ToString(), out r.LineId);
                int.TryParse(reader.GetValue(2).ToString(), out r.ItemType);
                int.TryParse(reader.GetValue(3).ToString(), out r.X);
                int.TryParse(reader.GetValue(4).ToString(), out r.Y);
                int.TryParse(reader.GetValue(5).ToString(), out r.Z);
                int.TryParse(reader.GetValue(6).ToString(), out r.Total);
                results.Add(r);
            }
            //Всё закрываем
            reader.Close();
            cmd.Dispose();
            return results;
        }
    
        public void SetRecipesGeometry(List<RecipeGeometry> recipes)
        {
            foreach (var r in recipes)
            {
                string cmdString = string.Format("Update [{0}].[dbo].[ItemTypeGeometry] set x={1},y={2},z={3} where RecipeId='{4}' and LineId={5} and ItemType={6}",
                    _DBname, r.X, r.Y, r.Z, r.RecipeId, r.LineId, r.ItemType);
                SqlCommand cmd = new SqlCommand(cmdString, connection);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }
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
