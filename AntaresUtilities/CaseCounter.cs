using System.Collections.Generic;
using System.Windows.Forms; // Terrible dependency

namespace AntaresUtilities
{
    public partial class BusinessLogic
    {
        public List<string> GetClosedWorkorderList()
        {
            _dm.Connect(_listOfServers.SelectedServerFQN, _listOfServers.SelectedServerDBName);
            return _dm.GetClosedWorkorderList();
        }

        public TreeNode GetLotTree(string _workorder)
        {
            string lot = _dm.GetLotFromWO(_workorder);
            TreeNode root = new TreeNode { Text = $"Lot: {lot}", Tag = lot };

            TreeNode tempNode;

            //Add Workorders
            List<string> workorders = _dm.GetWorkOrdersByLot(lot, _workorder);
            foreach (string workorder in workorders)
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
            foreach (TreeNode wo in root.Nodes)
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

        internal List<string> GetWorkOrdersByLot(string lot, string wo)
        {
            string cmdString = $"SELECT [Id] FROM [{_DBname}].[dbo].[Workorder] where Lot = '{lot}' and Id like('{wo}%')";
            return SelectListFromDb(cmdString);
        }

        internal string GetLotFromWO(string workorder)
        {
            string cmdString = $"SELECT [lot] FROM [{_DBname}].[dbo].[Workorder] where Id = '{workorder}'";
            return SelectValueFromDb(cmdString);
        }

        internal List<string> GetPalletsByWorkorder(string _wo)
        {
            string cmdString = $"SELECT [Serial] FROM [{_DBname}].[dbo].[Item] where WorkOrderID = '{_wo}' and Type = 400";
            return SelectListFromDb(cmdString);
        }

        internal List<string> GetCasesbyPallets(string _ser)
        {
            string cmdString = $"SELECT [Serial] FROM [{_DBname}].[dbo].[Item] where Type = 300 and ParentSerial = '{_ser}'";
            return SelectListFromDb(cmdString);
        }

        internal int CalculetaPackagesInCase(string _caseSerial)
        {
            string cmdString = $"SELECT count(*) FROM [{_DBname}].[dbo].[Item] where Type = 100 and ParentSerial = '{_caseSerial}'";
            return int.Parse(SelectValueFromDb(cmdString));
        }
    }
}
