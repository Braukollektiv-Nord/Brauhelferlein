using System;
using System.Security.Cryptography;
using System.Text;

namespace BKNBrauhelferKonverter.Utils
{
    public static class Cryptograph
    {

        public static string Encrypt(string value)
        {
            if (value == null)
                return null;

            var cryptoService = GetCryptoService();

            var toEncryptArray = Encoding.UTF8.GetBytes(value);
            var encryptor = cryptoService.CreateEncryptor();
            var resultArray = encryptor.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            cryptoService.Clear();

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string Decrypt(string value)
        {
            if (value == null)
                return null;

            var cryptoService = GetCryptoService();

            var toDecryptArray = Convert.FromBase64String(value);
            var decryptor = cryptoService.CreateDecryptor();
            var resultArray = decryptor.TransformFinalBlock(toDecryptArray, 0, toDecryptArray.Length);
            cryptoService.Clear();

            return Encoding.UTF8.GetString(resultArray);
        }

        private static TripleDESCryptoServiceProvider GetCryptoService()
        {
            // Kleine Hexerei, um den Key in die passende Größe zu bekommen...
            var hash = new SHA512CryptoServiceProvider();
            var keyArray = hash.ComputeHash(Encoding.UTF8.GetBytes("ugHDs*Wd<ZzvEl0"));
            var trimmedBytes = new byte[24];
            Buffer.BlockCopy(keyArray, 0, trimmedBytes, 0, 24);
            keyArray = trimmedBytes;

            return new TripleDESCryptoServiceProvider
            {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
        }
    }
}
