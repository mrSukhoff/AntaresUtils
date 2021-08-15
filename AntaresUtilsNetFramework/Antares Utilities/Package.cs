using System;

namespace AntaresUtilities
{
    public struct Package
    {
        private string _gtin;
        private string _serial;
        private string _cryptoKey;
        private string _cryptoCode;
        public string GTIN
        {
            get
            {
                return _gtin;
            }
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
            get
            {
                return _serial;
            }
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
            get
            {
                return _cryptoKey;
            }
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
            get
            {
                return _cryptoCode;
            }
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
    }
}
