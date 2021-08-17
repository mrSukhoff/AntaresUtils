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

        /// <summary>
        /// Возвращает список рецептов из БД
        /// </summary>
        /// <returns></returns>
        internal List<string> GetRecipeList()
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
        internal List<RecipeGeometry> GetRecipeGeometry(string recipeId)
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

            return results;
        }

        /// <summary>
        /// Сохраняет геометрию списка рецептов
        /// </summary>
        /// <param name="recipes"></param>
        internal void SaveGeometryToDb(RecipeGeometry r)
        {
            string cmdString = string.Format("Update [{0}].[dbo].[ItemTypeGeometry] set x={1},y={2},z={3} where RecipeId='{4}' and LineId={5} and ItemType={6}",
                _DBname, r.X, r.Y, r.Z, r.RecipeId, r.LineId, r.ItemType);
            SqlCommand cmd = new SqlCommand(cmdString, connection);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        /// <summary>
        /// Возвращает список материалов из БД
        /// </summary>
        /// <returns></returns>
        internal List<string> GetGMIDList()
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
        internal List<RecipeGeometry> GetRecipesListAssociatedWithGMID(string material)
        {
            string cmdString = string.Format("use [{0}]; SELECT r.Id,g.LineId,g.ItemType,g.X,g.Y,g.Z,g.X*g.Y*g.Z FROM [Material] as m join [Recipe] as r on r.GMID = m.Id join [ItemTypeGeometry] as g on g.RecipeId = r.Id where r.GMID = '{1}' and g.LineId <> -1 order by r.Id, g.LineId",
                _DBname, material);
            SqlCommand cmd = new SqlCommand(cmdString, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            List<RecipeGeometry> results = new List<RecipeGeometry>();

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



        /// <summary>
        /// Метод запрашивает в БД идентификатор GTINа
        /// </summary>
        /// <param name="GTIN">GTIN, для которого ищем идентификатор</param>
        /// <returns></returns>
        internal string GetGtinId(string gtin)
        {
            string cmdString = String.Format("SELECT [Id] FROM [{0}].[dbo].[NtinDefinition] WHERE Ntin = '{1}'", _DBname, gtin);
            return ExecuteQuery(cmdString);
        }

        /// <summary>
        /// Метод по идентификатору GTIN и серийному номеру находит криптоданные и возвращает пакет со всеми даннфми
        /// </summary>
        /// <param name="package">пакет с заполненым GTIN и серийным номером</param>
        /// <param name="gtinId">Идентификатор GTIN</param>
        /// <returns></returns>
        internal Package GetCryptoData(Package package, string gtinId)
        {
            string cmdString = String.Format("SELECT [VariableName] ,[VariableValue] FROM [{0}].[dbo].[ItemDetails] where Serial='{1}' and NtinId={2}", _DBname, package.Serial, gtinId);
            SqlCommand cmd = new SqlCommand(cmdString, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            Dictionary<string, string> answers = new Dictionary<string, string>();
            //Читаем ответы и складываем в словарь
            while (reader.Read())
            {
                string key = reader.GetValue(0).ToString();
                string value = reader.GetValue(1).ToString();
                answers.Add(key, value);
            }
            reader.Close();
            cmd.Dispose();

            Package result = new Package() { GTIN = package.GTIN, Serial = package.Serial };
            if (answers.Count >= 2)
            {
                result.CryptoCode = answers["cryptocode"];
                result.CryptoKey = answers["cryptokey"];
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
        internal string GetRecipeDescription(string recipeName)
        {
            string cmdString = String.Format("SELECT [RecipeDescription] FROM [{0}].[dbo].[Recipe] Where Id='{1}'", _DBname, recipeName);
            return ExecuteQuery(cmdString);
        }

        /// <summary>
        /// Возвращает описание материала по его имени
        /// </summary>
        /// <param name="recipeName"></param>
        /// <returns></returns>
        internal string GetMaterialDescription(string materialName)
        {
            string str = string.Format("SELECT [Description] FROM [{0}].[dbo].[Material] Where Id='{1}'", _DBname, materialName);
            return ExecuteQuery(str);
        }

        //выполняет команду и возвращает результат
        private string ExecuteQuery(string cmdString)
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
    }
}
