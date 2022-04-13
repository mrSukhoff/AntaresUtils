using System;

namespace AntaresUtilities
{
    public partial class BusinessLogic
    {

        public Package GetCrypto(Package package)
        {
            _dm.Connect(_listOfServers.SelectedServerFQN, _listOfServers.SelectedServerDBName);

            //Получаем по GTIN его идентификатор.
            string GTINid = _dm.GetGtinId(package.GTIN);

            //Проверяем найден ли GTIN
            if (GTINid.Length != 4)
            {
                throw new Exception("GTIN не найден!");
            }

            // По идентификатору GTIN и серийному номеру пачки получаем крипто-данные.
            return _dm.GetCryptoData(package, GTINid);
        }





    }
}
