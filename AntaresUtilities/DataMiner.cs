using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AntaresUtilities
{
    internal class DataMiner
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

        /// <summary>
        /// Возвращает список рецептов из БД
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Возвращает геометрию для всех линий конкретного рецепта
        /// </summary>
        /// <param name="recipeId">Идентификатора рецепта</param>
        /// <returns></returns>
        public List<RecipeGeometry> GetRecipeGeometry(string recipeId)
        {
            List<RecipeGeometry> results = new List<RecipeGeometry>();

            //Создаем запрос к БД
            string cmdString = string.Format("SELECT [LineId],[ItemType],[X],[Y],[Z] FROM [{0}].[dbo].[ItemTypeGeometry] where RecipeId = '{1}' and LineId <> -1", _DBname, recipeId);
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

        /// <summary>
        /// Записывает в БД геометрию из каждого рецепта из списка
        /// </summary>
        /// <param name="recipeGeometries">Список рецептов</param>
        public void SetRecipeGeometry(List<RecipeGeometry> recipeGeometries)
        {
            foreach (RecipeGeometry r in recipeGeometries)
            {
                //Создаем запрос к БД
                string cmdString = string.Format("update [{0}].[dbo].[ItemTypeGeometry] set X = {1}, Y = {2}, Z = {3} where RecipeId = '{4}' and LineID = {5} and ItemType = {6}",
                    _DBname, r.X, r.Y, r.Z, r.RecipeId, r.LineId, r.ItemType);
                SqlCommand cmd = new SqlCommand(cmdString, connection);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        /// <summary>
        /// Возвращает список материалов из БД
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Возвращает геометрию всех рецептов привязанных к конкретному материалу
        /// </summary>
        /// <param name="material"></param>
        /// <returns></returns>
        public List<RecipeGeometry> GetRecipesListByGMID(string material)
        {
            List<RecipeGeometry> results = new List<RecipeGeometry>();
            //Создаем запрос к БД
            string cmdString = string.Format("use [{0}]; SELECT r.Id,g.LineId,g.ItemType,g.X,g.Y,g.Z,g.X*g.Y*g.Z FROM [Material] as m join [Recipe] as r on r.GMID = m.Id join [ItemTypeGeometry] as g on g.RecipeId = r.Id where r.GMID = '{1}' and g.LineId <> -1 order by r.Id, g.LineId",
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
        
        /// <summary>
        /// Возвращает пакет со всеми заполнеными полями.
        /// </summary>
        /// <param name="package">В пакете должны быть заполнены GTIN и серийный номер</param>
        /// <returns></returns>
        public Package GetCrypto(Package package)
        {
            //Получаем по GTIN его идентификатор.
            string GTINid = GetGtinId(package.GTIN);

            //Проверяем найден ли GTIN
            if (GTINid.Length != 4)
            {
                throw new Exception("GTIN не найден!");
            }

            // По идентификатору GTIN и серийному номеру пачки получаем крипто-данные.
            return GetCryptoData(package, GTINid);
        }


        /// <summary>
        /// Метод запрашивает в БД идентификатор GTINа
        /// </summary>
        /// <param name="GTIN">GTIN, для которого ищем идентификатор</param>
        /// <returns></returns>
        private string GetGtinId(string gtin)
        {
            //Результат по умолчанию
            string result = "";

            //Создаем запрос к БД
            string cmdString = String.Format("SELECT [Id] FROM [{0}].[dbo].[NtinDefinition] WHERE Ntin = '{1}'", _DBname, gtin);
            SqlCommand cmd = new SqlCommand(cmdString, connection);
            // И выполняем его
            SqlDataReader reader = cmd.ExecuteReader();

            //Читаем все результаты
            while (reader.Read())
            {
                //но запоминаем последний :)
                result = reader.GetValue(0).ToString();
            }

            //Всё закрываем
            reader.Close();
            cmd.Dispose();

            return result;
        }

        /// <summary>
        /// Метод по идентификатору GTIN и серийному номеру находит криптоданные и возвращает пакет со всеми даннфми
        /// </summary>
        /// <param name="package">пакет с заполненым GTIN и серийным номером</param>
        /// <param name="gtinId">Идентификатор GTIN</param>
        /// <returns></returns>
        private Package GetCryptoData(Package package, string gtinId)
        {
            Package result = new Package() { GTIN = package.GTIN, Serial = package.Serial };
            Dictionary<string, string> results = new Dictionary<string, string>();

            //Формируем запрос
            string cmdString = String.Format("SELECT [VariableName] ,[VariableValue] FROM [{0}].[dbo].[ItemDetails] where Serial='{1}' and NtinId={2}", _DBname, package.Serial, gtinId);
            SqlCommand cmd = new SqlCommand(cmdString, connection);
            cmd.CommandTimeout = 300;
            //И выполняем его
            SqlDataReader reader = cmd.ExecuteReader();

            //Читаем по порядку все ответы
            while (reader.Read())
            {
                string key = reader.GetValue(0).ToString();
                string value = reader.GetValue(1).ToString();
                results.Add(key, value);
            }
            reader.Close();
            cmd.Dispose();

            if (results.Count >= 2)
            {
                result.CryptoCode = results["cryptocode"];
                result.CryptoKey = results["cryptokey"];
            }
            else
            {
                throw new Exception("Криптоданные не найдены");
            }
            return result;
        }
    
        /// <summary>
        /// Возвращает описание рецепта по его имени
        /// </summary>
        /// <param name="recipeName"></param>
        /// <returns></returns>
        public string GetRecipeName(string recipeName)
        {
            //Формируем запрос
            string cmdString = String.Format("SELECT [RecipeDescription] FROM [{0}].[dbo].[Recipe] Where Id='{1}'", _DBname, recipeName);
            SqlCommand cmd = new SqlCommand(cmdString, connection);
            cmd.CommandTimeout = 300;
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
            if (result == "") throw new Exception("Recipe description doesn't found!");
            return result;
        }


        /// <summary>
        /// Возвращает описание материала по его имени
        /// </summary>
        /// <param name="recipeName"></param>
        /// <returns></returns>
        public string GetMaterialName(string materialName)
        {
            //Формируем запрос
            string cmdString = String.Format("SELECT [Description] FROM [{0}].[dbo].[Material] Where Id='{1}'", _DBname, materialName);
            SqlCommand cmd = new SqlCommand(cmdString, connection);
            cmd.CommandTimeout = 300;
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
            if (result == "") throw new Exception("Material description doesn't found!");
            return result;
        }

    }
}
