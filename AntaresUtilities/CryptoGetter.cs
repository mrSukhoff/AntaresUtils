using System;

namespace AntaresUtilities
{
    public partial class BusinessLogic
    {

        public Package GetCrypto(Package package)
        {
            _dm.Connect(_listOfServers.SelectedServerFQN, _listOfServers.SelectedServerDBName);

            //Получаем по GTIN его идентификатор.
            var cmdString = String.Format("SELECT [Id] FROM [{0}].[dbo].[NtinDefinition] WHERE Ntin = '{1}'", 
                _listOfServers.SelectedServerDBName, package.GTIN);
            var gTINid = _dm.SelectValuesFromDb(cmdString)[0];

            //Проверяем найден ли GTIN
            if (gTINid.Length != 4)
            {
                throw new Exception("GTIN не найден!");
            }

            cmdString = String.Format("SELECT [VariableValue] FROM [{0}].[dbo].[ItemDetails] where Serial='{1}' " +
                "and NtinId={2} and VariableName='cryptocode'", _listOfServers.SelectedServerDBName, package.Serial, gTINid);
            var cryptoCode = _dm.SelectValuesFromDb(cmdString)[0]; ;

            cmdString = String.Format("SELECT [VariableValue] FROM [{0}].[dbo].[ItemDetails] where Serial='{1}' " +
                "and NtinId={2} and VariableName='cryptokey'", _listOfServers.SelectedServerDBName, package.Serial, gTINid);
            var cryptoKey = _dm.SelectValuesFromDb(cmdString)[0]; ;

            Package result;

            if (!string.IsNullOrEmpty(cryptoKey) & !string.IsNullOrEmpty(cryptoCode))
            {
                result = new Package() { GTIN = package.GTIN, Serial = package.Serial, CryptoCode = cryptoCode, CryptoKey = cryptoKey };
            }
            else
            {
                throw new Exception("Криптоданные не найдены");
            }
            return result;
        }

    }
}
