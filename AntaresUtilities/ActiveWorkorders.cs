using System.Collections.Generic;

namespace AntaresUtilities
{
    public partial class BusinessLogic
    {

        public Dictionary<int, string> WOStatuses = new Dictionary<int, string>()
        {
            { 1, "Assigned" },
            { 3, "Production" },
            { 9, "Suspended" },
            { 11, "Aborted" },
            { 31, "Completed" }
        };

        public List<string> GetWorkordersList()
        {
            _dm.Connect(_listOfServers.SelectedServerFQN, _listOfServers.SelectedServerDBName);
            
            var cmdString = string.Format("SELECT [Id] FROM [{0}].[dbo].[WorkOrder] where Status in (1,3,9,11)", 
                _listOfServers.SelectedServerDBName);
            return _dm.SelectValuesFromDb(cmdString);
        }

        public WorkOrder GetWorOrderDetails(string woName)
        {
            var cmdString = string.Format("SELECT [Id],[LineId],[RecipeId],[QuantityToProduce],[Lot],[Expiry]," +
                "[Manufactured],[ProductDescription],[UserName],[Status],[OpenTime],[CloseTime] " +
                "FROM [{0}].[dbo].[WorkOrder] where Id = '{1}'", _listOfServers.SelectedServerDBName, woName);
            
            WorkOrder wo = new WorkOrder();

            var details = _dm.SelectTableFromDb(cmdString, 11)[0];

            wo.Id =             details[0];
            wo.Line =           details[1];
            wo.RecipeId =       details[2];
            wo.Quantity =       details[3];
            wo.Lot =            details[4];
            wo.Expiry =         details[5];
            wo.Manufactured =   details[6];
            wo.Descrition =     details[7];
            wo.UserName =       details[8];
            wo.Status = int.Parse(details[9]);
            wo.OpenTime =       details[10];
            wo.Closetime =      details[10];

            return wo;
        }

        public void UpdateWoInDb(WorkOrder wo)
        {
            var cmdString = string.Format("Update [{0}].[dbo].[WorkOrder] set Expiry={1}, Manufactured={2} where Id='{3}'",
                _listOfServers.SelectedServerDBName, wo.Expiry, wo.Manufactured, wo.Id);
            /* требуется проверка
            var cmdString = string.Format("Update [{0}].[dbo].[WorkOrder] set Expiry={1}, Manufactured={2}, Staus = {3} where Id='{4}'",
                _listOfServers.SelectedServerDBName, wo.Expiry, wo.Manufactured,wo.Status, wo.Id);
            */
            _dm.UpdateValueInDb(cmdString);
        }
    }
}
