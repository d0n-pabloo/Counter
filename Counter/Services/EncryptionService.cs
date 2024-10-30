using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Counter.Services
{
    public class EncryptionService : IEncryptionService
    {
        private readonly byte[] _key = Encoding.UTF8.GetBytes("JCBIXYXDnc4cIF8j"); // 16-byte klucz
        private readonly byte[] _iv = Encoding.UTF8.GetBytes("1emfeXKevmStDiH4");   // 16-byte wektor inicjalizacji

        public string Encrypt(string plainText)
        {
            using var aes = Aes.Create();
            aes.Key = _key;
            aes.IV = _iv;

            using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            using var ms = new MemoryStream();
            using var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
            using var writer = new StreamWriter(cs);
            writer.Write(plainText);
            writer.Close();

            return Convert.ToBase64String(ms.ToArray());
        }

        public string Decrypt(string cipherText)
        {
            using var aes = Aes.Create();
            aes.Key = _key;
            aes.IV = _iv;

            using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using var ms = new MemoryStream(Convert.FromBase64String(cipherText));
            using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var reader = new StreamReader(cs);
            return reader.ReadToEnd();
        }
    }

}
