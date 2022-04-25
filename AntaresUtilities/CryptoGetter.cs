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
            var gTINid = _dm.SelectValueFromDb(cmdString); ;

            //Проверяем найден ли GTIN
            if (gTINid.Length != 4)
            {
                throw new Exception("GTIN не найден!");
            }

            cmdString = String.Format("SELECT [VariableValue] FROM [{0}].[dbo].[ItemDetails] where Serial='{1}' " +
                "and NtinId={2} and VariableName='cryptocode'", _listOfServers.SelectedServerDBName, package.Serial, gTINid);
            var cryptoCode = _dm.SelectValueFromDb(cmdString); ;

            cmdString = String.Format("SELECT [VariableValue] FROM [{0}].[dbo].[ItemDetails] where Serial='{1}' " +
                "and NtinId={2} and VariableName='cryptokey'", _listOfServers.SelectedServerDBName, package.Serial, gTINid);
            var cryptoKey = _dm.SelectValueFromDb(cmdString); ;

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
