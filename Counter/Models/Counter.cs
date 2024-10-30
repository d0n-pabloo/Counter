using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter.Models
{
    internal class Counter

    {
        public CounterSettings Settings { get; private set; }  // Ustawienia licznika, np. początkowa wartość, kolor
        public int Value { get; private set; }                 // Aktualna wartość licznika

        public Counter(CounterSettings settings)
        {
            Settings = settings;
            Value = settings.InitialValue;    // Inicjujemy wartość licznika wartością początkową
        }

        // Metoda do zwiększania wartości licznika
        public void Increment()
        {
            Value++;
        }

        // Metoda do zmniejszania wartości licznika
        public void Decrement()
        {
            Value--;
        }

        // Resetowanie wartości licznika do wartości początkowej
        public void Reset()
        {
            Value = Settings.InitialValue;
        }
    }
}
