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

    }
}
