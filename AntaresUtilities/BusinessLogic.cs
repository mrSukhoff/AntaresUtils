using System.Collections.Generic;

namespace AntaresUtilities
{
    public class BusinessLogic
    {
        
        private readonly DataMiner dm;
        private readonly ServerList _listOfServers;
        public List<string> ServerNames;

        private List<RecipeGeometry> _currentGMIDRecipesGeometry;
        private string _currentGMID;

        public BusinessLogic()
        {
            _listOfServers = new ServerList();
            ServerNames = _listOfServers.ServerNameList;
            dm = new DataMiner();
        }

        
        //Получаем список рецептов с выбраного сервера
        public List<string> GetRecipeList()
        {
            dm.Connect(_listOfServers.SelectedServerFQN, _listOfServers.SelectedServerDBName);

            List<string> result = new List<string>();
            foreach (string recipe in dm.GetRecipeList())
            {
                result.Add(recipe);
            }
            return result;
        }

        //Получаем с сервера геометрию выбраного рецепта
        public List<RecipeGeometry> GetSelectedRecipeGeometriesList(string recipeID)
        {
            return dm.GetRecipeGeometry(recipeID);
        }

        public string GetRecipeDescription(string recipeName)
        {
            return dm.GetRecipeDescription(recipeName);
        }

        public void SaveRecipeGeometryToDb(List<RecipeGeometry> list)
        {
            dm.SetRecipeGeometry(list);
        }

        
        public List<string> GetMaterialsList()
        {
            dm.Connect(_listOfServers.SelectedServerFQN, _listOfServers.SelectedServerDBName);
            return dm.GetGMIDList();
        }
        
        public string GetMaterialDescription(string materialName)
        {
            return dm.GetMaterialDescription(materialName);
        }

        public List<RecipeGeometry> GetRecipesListAssociatedWithGMID(string gMID)
        {
            _currentGMIDRecipesGeometry = dm.GetRecipesListAssociatedWithGMID(gMID);
            _currentGMID = gMID;
            return _currentGMIDRecipesGeometry;
        }

        public void SaveMaterialGeometriesToFile(string path)
        {
            GMIDGeometry r = new GMIDGeometry
            {
                GMID = _currentGMID,
                ListOfrecipeGeometries = _currentGMIDRecipesGeometry
            };
            r.Save(path);
        }

        public GMIDGeometry LoadMaterialGeometriesfromFile(string path)
        {
            GMIDGeometry gg = GMIDGeometry.Load(path);
            _currentGMID = gg.GMID;
            _currentGMIDRecipesGeometry = gg.ListOfrecipeGeometries;
            return gg;
        }
        public void SaveMaterialGeometriesToDb()
        {
            dm.SaveMaterialGeometriesToDb(_currentGMIDRecipesGeometry);
        }
        
        public void Clear()
        {
            _currentGMID = "";
            _currentGMIDRecipesGeometry = null;
        }
        

        public Package GetCrypto(Package package)
        {
            dm.Connect(_listOfServers.SelectedServerFQN, _listOfServers.SelectedServerDBName);
            return dm.GetCrypto(package);
        }
    
        public void SelectServer(string serverName)
        {
            _listOfServers.SelectServer(serverName);
        }
    }
}
