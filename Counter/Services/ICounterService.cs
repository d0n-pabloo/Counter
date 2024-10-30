namespace Counter.Services
{
    public interface ICounterService
    {
        List<Models.Counter> LoadCounters();        // Ładuje zapisane liczniki
        void SaveCounters(List<Models.Counter> counters); // Zapisuje aktualne liczniki
        void ResetCounters(List<Models.Counter> counters); // Resetuje wszystkie liczniki do wartości początkowych
    }
}
