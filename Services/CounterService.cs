using CounterApp2.Models;
using System.Text.Json;

namespace CounterApp2.Services
{
    public class CounterService : ICounterService
    {
        private const string FileName = "counters.json";

        public List<CounterModel> LoadCounters()
        {
            try
            {
                var filePath = Path.Combine(FileSystem.AppDataDirectory, FileName);
                if (!File.Exists(filePath))
                {
                    return new List<CounterModel>();
                }

                var json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<CounterModel>>(json) ?? new List<CounterModel>();
            }
            catch
            {
                return new List<CounterModel>();
            }
        }

        public void SaveCounters(IEnumerable<CounterModel> counters)
        {
            var filePath = Path.Combine(FileSystem.AppDataDirectory, FileName);
            var json = JsonSerializer.Serialize(counters);
            File.WriteAllText(filePath, json);
        }
    }
}
