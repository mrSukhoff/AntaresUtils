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
            return _dm.GetWOList();
        }

        public WorkOrder GetWorOrderDetails(string woName)
        {
            WorkOrder wo = _dm.GetWODetail(woName);
            //if (int.TryParse(wo.Status,out int t)) wo.Status = WOStatus[t];
            return wo;
        }

        public void UpdateWoInDb(WorkOrder wo)
        {
            _dm.UpdateWoInDb(wo);
        }

    }
}
