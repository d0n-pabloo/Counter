using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter.Services
{
        public interface IEncryptionService
        {
            string Encrypt(string plainText);   // Szyfruje dane
            string Decrypt(string cipherText);  // Deszyfruje dane
        }
}
