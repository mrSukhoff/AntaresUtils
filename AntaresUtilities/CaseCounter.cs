using System.Collections.Generic;
using System.Windows.Forms; // Terrible dependency

namespace AntaresUtilities
{
    public partial class BusinessLogic
    {
        public List<string> GetClosedWorkorderList()
        {
            _dm.Connect(_listOfServers.SelectedServerFQN, _listOfServers.SelectedServerDBName);
            var cmdString = string.Format("SELECT [Id] FROM [{0}].[dbo].[Workorder] where Status = 31", _listOfServers.SelectedServerDBName);

            return _dm.SelectValuesFromDb(cmdString);
        }
        

        public TreeNode GetLotTree(string _workorder)
        {
            var db = _listOfServers.SelectedServerDBName;

            // Get Lot
            var cmdString = string.Format("SELECT [lot] FROM [{0}].[dbo].[Workorder] where Id = '{1}'", 
                db, _workorder);
            string lot = _dm.SelectValuesFromDb(cmdString)[0];
                        
            TreeNode root = new TreeNode { Text = $"Lot: {lot}", Tag = lot };

            TreeNode tempNode;

            // Get Workorders by Lot
            cmdString = string.Format("SELECT [Id] FROM [{0}].[dbo].[Workorder] where Lot = '{1}' and Id like('{2}%')", 
                db, lot, _workorder) ;
            List<string> workorders = _dm.SelectValuesFromDb(cmdString);
                         
            foreach (string workorder in workorders)
            {
                tempNode = new TreeNode { Text = $"Workorder:{workorder}", Tag = workorder };
                root.Nodes.Add(tempNode);
            }

            // Get Pallets by Workorder
            foreach (TreeNode node in root.Nodes)
            {
                cmdString = string.Format("SELECT [Serial] FROM [{0}].[dbo].[Item] where WorkOrderID = '{1}' and Type = 400",
                    db, node.Tag.ToString());
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
                    cmdString = string.Format("SELECT [Serial] FROM [{0}].[dbo].[Item] where Type = 300 and ParentSerial = '{1}'",
                       db, pallet.Tag.ToString());

                    List<string> cases = _dm.SelectValuesFromDb(cmdString);
                    
                    foreach (var c in cases)
                    {

                        cmdString = string.Format("SELECT count(*) FROM [{0}].[dbo].[Item] " +
                            "where Type = 100 and ParentSerial = '{_caseSerial}'", db, c);


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
