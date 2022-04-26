using System.Collections.Generic;
using System.Windows.Forms; // Terrible dependency

namespace AntaresUtilities
{
    public partial class BusinessLogic
    {
        public List<string> GetClosedWorkorderList()
        {
            _dm.Connect(_listOfServers.SelectedServerFQN, _listOfServers.SelectedServerDBName);
            var cmdString = $"SELECT [Id] FROM [{_listOfServers.SelectedServerDBName}].[dbo].[Workorder] where Status = 31";

            return _dm.SelectValuesFromDb(cmdString);
        }
        

        public TreeNode GetLotTree(string workorder)
        {
            var db = _listOfServers.SelectedServerDBName;

            // Get Lot
            var cmdString = $"SELECT [lot] FROM [{db}].[dbo].[Workorder] where Id = '{workorder}'";

            string lot = _dm.SelectValuesFromDb(cmdString)[0];
                        
            TreeNode root = new TreeNode { Text = $"Lot: {lot}", Tag = lot };

            TreeNode tempNode;

            // Get Workorders by Lot
            cmdString = $"SELECT [Id] FROM [{db}].[dbo].[Workorder] where Lot = '{lot}' and Id like('{workorder}%')";
            List<string> workorders = _dm.SelectValuesFromDb(cmdString);
                         
            foreach (string wo in workorders)
            {
                tempNode = new TreeNode { Text = $"Workorder:{wo}", Tag = wo };
                root.Nodes.Add(tempNode);
            }

            // Get Pallets by Workorder
            foreach (TreeNode node in root.Nodes)
            {
                cmdString = $"SELECT [Serial] FROM [{db}].[dbo].[Item] where WorkOrderID = '{node.Tag}' and Type = 400";
                List<string> pallets = _dm.SelectValuesFromDb(cmdString);

                foreach (var p in pallets)
                {
                    tempNode = new TreeNode { Text = $"Pallet: {p}", Tag = p };
                    node.Nodes.Add(tempNode);
                }
            }

            // Get Caseses on Pallets
            foreach (TreeNode wo in root.Nodes)
            {
                foreach (TreeNode pallet in wo.Nodes)
                {
                    cmdString = $"SELECT [Serial] FROM [{db}].[dbo].[Item] where Type = 300 and ParentSerial = '{pallet.Tag}'";

                    List<string> cases = _dm.SelectValuesFromDb(cmdString);
                    
                    foreach (var c in cases)
                    {

                        cmdString = $"SELECT count(*) FROM [{db}].[dbo].[Item] where Type = 100 and ParentSerial = '{c}'";

                        int amount = int.Parse(_dm.SelectValuesFromDb(cmdString)[0]);

                        tempNode = new TreeNode { Text = $"Case: {c} - {amount}", Tag = c };
                        pallet.Nodes.Add(tempNode);
                    }
                }
            }
            return root;
        }
    }
}
