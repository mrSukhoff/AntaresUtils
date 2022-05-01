using System;
using DataMatrix.net;
using System.Drawing;

namespace AntaresUtilities
{
    public class KIZ
    {
        private string _gtin;
        private string _serial;
        private string _cryptoKey;
        private string _cryptoCode;
        private ServerList _serverList;

        public string GTIN
        {
            get => _gtin;
            set
            {
                if (value.Length == 14)
                {
                    _gtin = value;
                }
                else
                {
                    throw new ArgumentException("Неверная длина GTIN!");
                }
            }
        }
        public string Serial
        {
            get => _serial;
            set
            {
                if (value.Length == 13)
                {
                    _serial = value;
                }
                else
                {
                    throw new ArgumentException("Неверная длина серийного номера!");
                }
            }
        }
        public string CryptoKey
        {
            get => _cryptoKey;
            set
            {
                if (value.Length == 4)
                {
                    _cryptoKey = value;
                }
                else
                {
                    throw new ArgumentException("Неверная длина криптоключа");
                }
            }
        }
        public string CryptoCode
        {
            get => _cryptoCode;
            set
            {
                if (value.Length == 44)
                {
                    _cryptoCode = value;
                }
                else
                {
                    throw new ArgumentException("Неверная длина криптокода!");
                }
            }
        }

        public KIZ() { }

        internal KIZ (string gtin, string serial, ServerList serverList)
        {
            _gtin = gtin;
            _serial = serial;
            _serverList = serverList;
        }

        public bool GetCrypto()
        {
            bool result = false;
            DataMiner dm = new DataMiner();

            string db = _serverList.SelectedServerDBName;
            dm.Connect(_serverList.SelectedServerFQN, db);

            //Получаем по GTIN его идентификатор.
            var cmdString = $"SELECT [Id] FROM [{db}].[dbo].[NtinDefinition] WHERE Ntin = '{_gtin}'";
            string gTINid = dm.SelectValuesFromDb(cmdString)[0];

            //Проверяем найден ли GTIN
            if (gTINid.Length != 4)
            {
                throw new Exception("GTIN не найден!");
            }

            cmdString = $"SELECT [VariableValue] FROM [{db}].[dbo].[ItemDetails] " +
                $"where Serial='{_serial}' and NtinId={gTINid} and VariableName='cryptocode'";
            string cryptoCode = dm.SelectValuesFromDb(cmdString)[0]; ;

            cmdString = $"SELECT [VariableValue] FROM [{db}].[dbo].[ItemDetails] " +
                $"where Serial='{_serial}'and NtinId={gTINid} and VariableName='cryptokey'";
            string cryptoKey = dm.SelectValuesFromDb(cmdString)[0]; ;

            if (!string.IsNullOrEmpty(cryptoKey) & !string.IsNullOrEmpty(cryptoCode))
            {
                _cryptoCode = cryptoCode; 
                _cryptoKey = cryptoKey ;
                result = true;
            }
            else
            {
                throw new Exception("Криптоданные не найдены");
            }
            return result;
        }

        public Bitmap GetDataMatrix()
        {
            DmtxImageEncoder encoder = new DmtxImageEncoder();
            DmtxImageEncoderOptions options = new DmtxImageEncoderOptions
            {
                ModuleSize = 5,
                MarginSize = 4
            };
            var separator = char.ConvertFromUtf32(29);
            var dataMatrixString =$"01{_gtin}21{_serial}{separator}91{_cryptoKey}{separator}92{_cryptoCode}";
            return encoder.EncodeImage(dataMatrixString, options);
        }
    }
}
