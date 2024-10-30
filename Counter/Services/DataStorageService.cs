using Newtonsoft.Json;

namespace Counter.Services
{
    public class DataStorageService : IDataStorageService
    {
        private const string FilePath = "counters.json"; // Ścieżka do pliku danych

        public void SaveData(string encryptedData)
        {
            File.WriteAllText(FilePath, encryptedData);
        }

        public string LoadData()
        {
            return File.Exists(FilePath) ? File.ReadAllText(FilePath) : string.Empty;
        }

        public string SerializeData(List<Models.Counter> counters)
        {
            return JsonConvert.SerializeObject(counters);
        }

        public List<Models.Counter> DeserializeData(string jsonData)
        {
            return JsonConvert.DeserializeObject<List<Models.Counter>>(jsonData) ?? new List<Models.Counter>();
        }
    }
}
