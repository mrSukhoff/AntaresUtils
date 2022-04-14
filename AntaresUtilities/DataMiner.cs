using System;
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
            //Формируем запрос
            SqlCommand cmd = new SqlCommand(cmdString, connection);

            //И выполняем его
            SqlDataReader reader = cmd.ExecuteReader();

            string result = "";
            //Читаем по порядку все ответы
            while (reader.Read())
            {
                result = reader.GetValue(0).ToString();
            }
            reader.Close();
            cmd.Dispose();

            return result;
        }

        //выполняет команду и возвращает список результатов
        internal List<string> SelectListFromDb(string cmdString)
        {
            List<string> results = new List<string>();
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
    }
}
