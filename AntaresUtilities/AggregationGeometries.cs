using System.Collections.Generic;

namespace AntaresUtilities
{
    public partial class BusinessLogic
    {
        public List<string> GetRecipeList()
        {
            _dm.Connect(_listOfServers.SelectedServerFQN, _listOfServers.SelectedServerDBName);
            return _dm.GetRecipeList();
        }

        public List<RecipeGeometry> GetRecipeGeometriesList(string recipeID)
        {
            return _dm.GetRecipeGeometry(recipeID);
        }

        public string GetRecipeDescription(string recipeName)
        {
            return _dm.GetRecipeDescription(recipeName);
        }

        public void UpdateRecipeGeometryInDb(List<RecipeGeometry> list)
        {
            foreach (RecipeGeometry r in list)
            {
                _dm.UpdateGeometryInDb(r);
            }
        }

        /// <summary>
        /// Возвращает список рецептов из БД
        /// </summary>
        /// <returns></returns>
        internal List<string> GetRecipeList()
        {
            string cmdString = "SELECT [Id] FROM [" + _DBname + "].[dbo].[Recipe]";
            return SelectListFromDb(cmdString);
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
        internal void UpdateGeometryInDb(RecipeGeometry r)
        {
            string cmdString = string.Format("Update [{0}].[dbo].[ItemTypeGeometry] set x={1},y={2},z={3} where RecipeId='{4}' and LineId={5} and ItemType={6}",
                _DBname, r.X, r.Y, r.Z, r.RecipeId, r.LineId, r.ItemType);
            SqlCommand cmd = new SqlCommand(cmdString, connection);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        /// <summary>
        /// Возвращает описание рецепта по его имени
        /// </summary>
        /// <param name="recipeName"></param>
        /// <returns></returns>
        internal string GetRecipeDescription(string recipeName)
        {
            string cmdString = String.Format("SELECT [RecipeDescription] FROM [{0}].[dbo].[Recipe] Where Id='{1}'", _DBname, recipeName);
            return SelectValueFromDb(cmdString);
        }

    }
}
