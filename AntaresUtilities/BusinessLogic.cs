using System;
using System.Collections.Generic;

namespace AntaresUtilities
{
    public class BusinessLogic
    {
        public List<string> ServerNames { get; private set; }
        public string CurrentGMID => _currentGMID;

        private readonly DataMiner _dm;
        private readonly ServerList _listOfServers;
        private List<RecipeGeometry> _currentGMIDRecipesGeometry;
        private string _currentGMID;

        public BusinessLogic()
        {
            _listOfServers = new ServerList();
            ServerNames = _listOfServers.ServerNameList;
            _dm = new DataMiner();
        }

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

        public Package GetCrypto(Package package)
        {
            _dm.Connect(_listOfServers.SelectedServerFQN, _listOfServers.SelectedServerDBName);

            //Получаем по GTIN его идентификатор.
            string GTINid = _dm.GetGtinId(package.GTIN);

            //Проверяем найден ли GTIN
            if (GTINid.Length != 4)
            {
                throw new Exception("GTIN не найден!");
            }

            // По идентификатору GTIN и серийному номеру пачки получаем крипто-данные.
            return _dm.GetCryptoData(package, GTINid);
        }

        public void SelectServer(string serverName)
        {
            _listOfServers.SelectServer(serverName);
        }
        public void Clear()
        {
            _currentGMID = "";
            _currentGMIDRecipesGeometry = null;
        }
    }
}
