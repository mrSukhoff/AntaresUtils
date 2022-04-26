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
            var cmdString = string.Format("SELECT [Id] FROM [{0}].[dbo].[Material]", _listOfServers.SelectedServerDBName);
            return _dm.SelectValuesFromDb(cmdString);
        }

        public string GetMaterialDescription(string materialName)
        {
            var str = string.Format($"SELECT [Description] FROM [{0}].[dbo].[Material] Where Id='{1}'",
                _listOfServers.SelectedServerDBName, materialName);
            return _dm.SelectValuesFromDb(str)[0];
        }

        public List<RecipeGeometry> GetRecipesListAssociatedWithGMID(string gMID)
        {
            List<RecipeGeometry> results = new List<RecipeGeometry>();

            string cmdString = string.Format("use [{0}]; SELECT r.Id,g.LineId,g.ItemType,g.X,g.Y,g.Z,g.X*g.Y*g.Z " +
                "FROM [Material] as m join [Recipe] as r on r.GMID = m.Id join [ItemTypeGeometry] as g on g.RecipeId = r.Id " +
                "where r.GMID = '{1}' and g.LineId <> -1 order by r.Id, g.LineId", _listOfServers.SelectedServerDBName, gMID);
            
            var values = _dm.SelectTableFromDb(cmdString, 7);
            
            foreach (var row in values)
            {
                RecipeGeometry r = new RecipeGeometry();
                r.RecipeId = row[0];
                int.TryParse(row[1], out r.LineId);
                int.TryParse(row[2], out r.ItemType);
                int.TryParse(row[3], out r.X);
                int.TryParse(row[4], out r.Y);
                int.TryParse(row[5], out r.Z);
                int.TryParse(row[6], out r.Total);
                results.Add(r);
            }

            _currentGMIDRecipesGeometry = results;
            _currentGMID = gMID;
            return _currentGMIDRecipesGeometry;
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

    }
}
