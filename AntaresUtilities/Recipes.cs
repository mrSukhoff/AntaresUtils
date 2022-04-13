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

        public List<RecipeGeometry> GetRecipesListAssociatedWithGMID(string gMID)
        {
            _currentGMIDRecipesGeometry = _dm.GetRecipesListAssociatedWithGMID(gMID);
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
