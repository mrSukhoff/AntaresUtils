using System;
using System.Collections.Generic;
using System.Windows.Forms;

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

        public Dictionary<int, string> WOStatuses = new Dictionary<int, string>()
        {
            { 1, "Assigned" },
            { 3, "Production" },
            { 9, "Suspended" },
            { 11, "Aborted" },
            { 31, "Completed" }
        };

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
        
        public List<string> GetWorkordersList()
        {
            _dm.Connect(_listOfServers.SelectedServerFQN, _listOfServers.SelectedServerDBName);
            return _dm.GetWOList();
        }

        public WorkOrder GetWorOrderDetails(string woName)
        {
            WorkOrder wo = _dm.GetWODetail(woName);
            //if (int.TryParse(wo.Status,out int t)) wo.Status = WOStatus[t];
            return wo;
        }

        public void UpdateWoInDb (WorkOrder wo)
        {
            _dm.UpdateWoInDb(wo);
        }
    
        public List<string> GetClosedWorkorderList()
        {
            _dm.Connect(_listOfServers.SelectedServerFQN, _listOfServers.SelectedServerDBName);
            return _dm.GetClosedWorkorderList();
        }

        public TreeNode GetLotTree(string _workorder)
        {
            string lot = _dm.GetLotFromWO(_workorder);
            TreeNode root = new TreeNode{Text = $"Lot: {lot}", Tag = lot};

            TreeNode tempNode;
            
            //Add Workorders
            List<string> workorders = _dm.GetWorkOrdersByLot(lot, _workorder);
            foreach(string workorder in workorders)
            {
                tempNode = new TreeNode { Text = $"Workorder:{workorder}", Tag = workorder };
                root.Nodes.Add(tempNode);
            }

            //Add Pallets
            foreach (TreeNode node in root.Nodes)
            {
                List<string> pallets = _dm.GetPalletsByWorkorder(node.Tag.ToString());
                foreach (var p in pallets)
                {
                    tempNode = new TreeNode { Text = $"Pallet: {p}", Tag = p };
                    node.Nodes.Add(tempNode);
                }
            }

            //Add Caseses
            foreach(TreeNode wo in root.Nodes)
                {
                    foreach (TreeNode pallet in wo.Nodes)
                    {
                        List<string> cases = _dm.GetCasesbyPallets(pallet.Tag.ToString());
                        foreach (var c in cases)
                        {
                            int amount = _dm.CalculetaPackagesInCase(c);

                            tempNode = new TreeNode { Text = $"Case: {c} - {amount}", Tag = c };
                            pallet.Nodes.Add(tempNode);
                        }
                    }
                }
            return root;
        }
    }
}
