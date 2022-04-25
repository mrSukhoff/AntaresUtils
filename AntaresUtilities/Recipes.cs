using System.Collections.Generic;

namespace AntaresUtilities
{
    public partial class BusinessLogic
    {
        public string CurrentGMID => _currentGMID;

        public void Clear()
        {
            _currentGMID = "";
            _currentGMIDRecipesGeometry = null;
        }

        public List<string> GetMaterialsList()
        {
            _dm.Connect(_listOfServers.SelectedServerFQN, _listOfServers.SelectedServerDBName);
            return _dm.GetGMIDList();
        }

        public string GetMaterialDescription(string materialName)
        {
            return _dm.GetMaterialDescription(materialName);
        }

        /// <summary>
        /// Возвращает описание материала по его имени
        /// </summary>
        /// <param name="recipeName"></param>
        /// <returns></returns>
        internal string GetMaterialDescription(string materialName)
        {
            string str = string.Format("SELECT [Description] FROM [{0}].[dbo].[Material] Where Id='{1}'", _DBname, materialName);
            return SelectValueFromDb(str);
        }

        public List<RecipeGeometry> GetRecipesListAssociatedWithGMID(string gMID)
        {
            _currentGMIDRecipesGeometry = _dm.GetRecipesListAssociatedWithGMID(gMID);
            _currentGMID = gMID;
            return _currentGMIDRecipesGeometry;
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

        public void SaveMaterialGeometriesToFile(string path)
        {
            GMIDGeometry g = new GMIDGeometry
            {
                GMID = _currentGMID,
                ListOfrecipeGeometries = _currentGMIDRecipesGeometry
            };
            g.Save(path);
        }

        public List<RecipeGeometry> LoadMaterialGeometriesfromFile(string path)
        {
            GMIDGeometry gg = GMIDGeometry.Load(path);
            _currentGMID = gg.GMID;
            _currentGMIDRecipesGeometry = gg.ListOfrecipeGeometries;
            return _currentGMIDRecipesGeometry;
        }

        public void SaveMaterialGeometriesToDb()
        {
            UpdateRecipeGeometryInDb(_currentGMIDRecipesGeometry);
        }


        /// <summary>
        /// Возвращает список материалов из БД
        /// </summary>
        /// <returns></returns>
        internal List<string> GetGMIDList()
        {
            string cmdString = "SELECT [Id] FROM [" + _DBname + "].[dbo].[Material]";
            return SelectListFromDb(cmdString);
        }
    }
}
