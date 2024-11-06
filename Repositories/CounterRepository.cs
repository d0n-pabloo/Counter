using CounterApp2.Models;
using CounterApp2.Services;

namespace CounterApp2.Repositories
{
    public class CounterRepository : ICounterRepository
    {
        private readonly ICounterService _counterService;
        private List<CounterModel> _counters;

        public CounterRepository(ICounterService counterService)
        {
            _counterService = counterService;
            _counters = new List<CounterModel>();
        }

        public List<CounterModel> GetAllCounters()
        {
            return _counters;
        }

        public void AddCounter(CounterModel counter)
        {
            _counters.Add(counter);
            _counterService.SaveCounters(_counters);
        }

        public void UpdateCounter(CounterModel counter)
        {
            _counterService.SaveCounters(_counters);
        }

        public void RemoveCounter(CounterModel counter)
        {
            _counters.Remove(counter);
            _counterService.SaveCounters(_counters);
        }
    }
}
