using System;

namespace AntaresUtilities
{
    public partial class BusinessLogic
    {

        public Package GetCrypto(Package package)
        {
            _dm.Connect(_listOfServers.SelectedServerFQN, _listOfServers.SelectedServerDBName);

            //Получаем по GTIN его идентификатор.
            string cmdString = String.Format("SELECT [Id] FROM [{0}].[dbo].[NtinDefinition] WHERE Ntin = '{1}'", _listOfServers.SelectedServerDBName, package.GTIN);
            string GTINid = _dm.SelectValueFromDb(cmdString); ;

            //Проверяем найден ли GTIN
            if (GTINid.Length != 4)
            {
                throw new Exception("GTIN не найден!");
            }

            // По идентификатору GTIN и серийному номеру пачки получаем крипто-данные.
            return GetCryptoData(package, GTINid);

            /// <summary>
            /// Метод по идентификатору GTIN и серийному номеру находит криптоданные и возвращает пакет со всеми даннфми
            /// </summary>
            /// <param name="package">пакет с заполненым GTIN и серийным номером</param>
            /// <param name="gtinId">Идентификатор GTIN</param>
            /// <returns></returns>
            Package GetCryptoData(Package package, string gtinId)
            {
                string cmdString = String.Format("SELECT [VariableName] ,[VariableValue] FROM [{0}].[dbo].[ItemDetails] where Serial='{1}' and NtinId={2}", _listOfServers.SelectedServerDBName, package.Serial, gtinId);
                SqlCommand cmd = new SqlCommand(cmdString, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                Dictionary<string, string> answers = new Dictionary<string, string>();
                //Читаем ответы и складываем в словарь
                while (reader.Read())
                {
                    string key = reader.GetValue(0).ToString();
                    string value = reader.GetValue(1).ToString();
                    answers.Add(key, value);
                }
                reader.Close();
                cmd.Dispose();

                Package result = new Package() { GTIN = package.GTIN, Serial = package.Serial };
                if (answers.Count >= 2)
                {
                    result.CryptoCode = answers["cryptocode"];
                    result.CryptoKey = answers["cryptokey"];
                }
                else
                {
                    throw new Exception("Криптоданные не найдены");
                }
                return result;
            }

        }

        
    }
}
