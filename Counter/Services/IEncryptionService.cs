namespace Counter.Services
{
        public interface IEncryptionService
        {
            string Encrypt(string plainText);   // Szyfruje dane
            string Decrypt(string cipherText);  // Deszyfruje dane
        }
}
