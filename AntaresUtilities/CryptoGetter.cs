using System;

namespace AntaresUtilities
{
    public partial class BusinessLogic
    {

        public Package GetCrypto(Package package)
        {
            var db = _listOfServers.SelectedServerDBName;
            _dm.Connect(_listOfServers.SelectedServerFQN, db);

            //Получаем по GTIN его идентификатор.
            var cmdString = $"SELECT [Id] FROM [{db}].[dbo].[NtinDefinition] WHERE Ntin = '{package.GTIN}'";
            var gTINid = _dm.SelectValuesFromDb(cmdString)[0];

            //Проверяем найден ли GTIN
            if (gTINid.Length != 4)
            {
                throw new Exception("GTIN не найден!");
            }

            cmdString = $"SELECT [VariableValue] FROM [{db}].[dbo].[ItemDetails] " +
                $"where Serial='{package.Serial}' and NtinId={gTINid} and VariableName='cryptocode'";
            var cryptoCode = _dm.SelectValuesFromDb(cmdString)[0]; ;

            cmdString = $"SELECT [VariableValue] FROM [{db}].[dbo].[ItemDetails] " +
                $"where Serial='{package.Serial}'and NtinId={gTINid} and VariableName='cryptokey'";
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
