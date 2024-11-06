using CounterApp2.Models;

namespace CounterApp2.Repositories
{
    public interface ICounterRepository
    {
        List<CounterModel> GetAllCounters();
        void AddCounter(CounterModel counter);
        void UpdateCounter(CounterModel counter);
        void RemoveCounter(CounterModel counter);
    }
}
