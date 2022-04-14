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

        internal WorkOrder GetWODetail(string woName)
        {
            string cmdString = string.Format("SELECT [Id],[LineId],[RecipeId],[QuantityToProduce],[Lot],[Expiry],[Manufactured],[ProductDescription],[UserName],[Status],[OpenTime],[CloseTime] FROM [{0}].[dbo].[WorkOrder] where Id = '{1}'",
              _DBname, woName);
            SqlCommand cmd = new SqlCommand(cmdString, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            WorkOrder wo = new WorkOrder();

            while (reader.Read())
            {
                wo.Id = reader.GetValue(0).ToString();
                wo.Line = reader.GetValue(1).ToString();
                wo.RecipeId = reader.GetValue(2).ToString();
                wo.Quantity = reader.GetValue(3).ToString();
                wo.Lot = reader.GetValue(4).ToString();
                wo.Expiry = reader.GetValue(5).ToString();
                wo.Manufactured = reader.GetValue(6).ToString();
                wo.Descrition = reader.GetValue(7).ToString();
                wo.UserName = reader.GetValue(8).ToString();
                wo.Status = int.Parse(reader.GetValue(9).ToString());
                wo.OpenTime = reader.GetValue(10).ToString();
                wo.Closetime = reader.GetValue(11).ToString();
            }
            //Всё закрываем
            reader.Close();
            cmd.Dispose();
            //меняем идентификатор на описание
            cmdString = String.Format("SELECT[Description] FROM[{0}].[dbo].[Line] where id = {1}", _DBname, wo.Line);
            wo.Line = SelectValueFromDb(cmdString);

            return wo;
        }

        internal void UpdateWoInDb(WorkOrder wo)
        {
            string cmdString = string.Format("Update [{0}].[dbo].[WorkOrder] set Expiry={1}, Manufactured={2} where Id='{3}'",
                _DBname, wo.Expiry, wo.Manufactured, wo.Id);
            SqlCommand cmd = new SqlCommand(cmdString, connection);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        internal List<string> GetWOList()
        {
            string cmdString = "SELECT [Id] FROM [" + _DBname + "].[dbo].[WorkOrder] where Status in (1,3,9,11)";
            return SelectListFromDb(cmdString);
        }


        internal List<string> GetClosedWorkorderList()
        {
            string cmdString = $"SELECT [Id] FROM [{_DBname}].[dbo].[Workorder] where Status = 31";
            return SelectListFromDb(cmdString);
        }
    }
}
