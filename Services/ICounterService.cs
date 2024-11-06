using CounterApp2.Models;

namespace CounterApp2.Services
{
    public interface ICounterService
    {
        List<CounterModel> LoadCounters();
        void SaveCounters(IEnumerable<CounterModel> counters);
    }
}
