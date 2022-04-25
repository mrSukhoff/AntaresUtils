using System.Collections.Generic;
using System.Data.SqlClient;

namespace AntaresUtilities
{
    internal class DataMiner
    {
        private SqlConnection connection;
        private string _DBname;

        /// <summary>
        /// Соединение с БД 
        /// </summary>
        /// <param name="serverAdress"></param>
        /// <param name="dBname"></param>
        internal void Connect(string serverAdress, string dBname)
        {
            Disconnect();
            string connectionString = "Data Source=" + serverAdress + ";Initial Catalog=" + dBname + ";Persist Security Info=True;User ID=tav;Password=tav";
            connection = new SqlConnection(connectionString);
            connection.Open();
            _DBname = dBname;
        }

        // Отключеие от БД
        private void Disconnect()
        {
            if (connection != null)
            {
                connection.Close();
                _DBname = null;
            }
        }

        //выполняет команду и возвращает результат
        internal string SelectValueFromDb(string cmdString)
        {
            return SelectValuesFromDb(cmdString)[0];
        }

        
        internal List<string> SelectValuesFromDb(string cmdString)
        {
            List<string> results = new List<string>();
            SqlCommand cmd = new SqlCommand(cmdString, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                results.Add(reader.GetValue(0).ToString());
            }
            reader.Close();
            cmd.Dispose();

            results.Sort();
            return results;
        }
    
        internal List<string[]> SelectTableFromDb (string cmdString, int numberOfColumn)
        {
            List<string[]> results = new List<string[]>();

            SqlCommand cmd = new SqlCommand(cmdString, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string[] row = new string[numberOfColumn];
                for (int i = 0; i < numberOfColumn; i++)
                {
                    row[i] = reader.GetValue(i).ToString();
                }
                results.Add(row);           
            }
            reader.Close();
            cmd.Dispose();
            return results;
        }
    
        internal void UpdateValueInDb(string cmdString)
        {
            SqlCommand cmd = new SqlCommand(cmdString, connection);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

    }
}
