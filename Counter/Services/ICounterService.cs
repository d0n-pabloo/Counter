using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter.Services
{
    internal interface ICounterService
    {
        List<Models.Counter> LoadCounters();        // Ładuje zapisane liczniki
        void SaveCounters(List<Models.Counter> counters); // Zapisuje aktualne liczniki
        void ResetCounters(List<Models.Counter> counters); // Resetuje wszystkie liczniki do wartości początkowych
    }
}
