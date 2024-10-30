namespace Counter.Services
{
    public class CounterService : ICounterService
    {
        private readonly IDataStorageService _dataStorageService;
        private readonly IEncryptionService _encryptionService;

        public CounterService(IDataStorageService dataStorageService, IEncryptionService encryptionService)
        {
            _dataStorageService = dataStorageService;
            _encryptionService = encryptionService;
        }

        public List<Models.Counter> LoadCounters()
        {
            string encryptedData = _dataStorageService.LoadData();
            if (string.IsNullOrEmpty(encryptedData))
            {
                return new List<Models.Counter>(); // Jeśli brak danych, zwraca pustą listę liczników
            }

            string decryptedData = _encryptionService.Decrypt(encryptedData);
            return _dataStorageService.DeserializeData(decryptedData);
        }

        public void SaveCounters(List<Models.Counter> counters)
        {
            string jsonData = _dataStorageService.SerializeData(counters);
            string encryptedData = _encryptionService.Encrypt(jsonData);
            _dataStorageService.SaveData(encryptedData);
        }

        public void ResetCounters(List<Models.Counter> counters)
        {
            foreach (var counter in counters)
            {
                counter.Reset(); // Resetuje każdy licznik do wartości początkowej
            }
            SaveCounters(counters); // Zapisuje zresetowane liczniki
        }
    }
}
