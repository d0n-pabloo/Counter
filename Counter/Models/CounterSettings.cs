using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter.Models
{
    internal class CounterSettings
    {
        public Guid Id { get; set; }             // Unikalny identyfikator licznika
        public string Name { get; set; }         // Nazwa licznika
        public int InitialValue { get; set; }    // Wartość początkowa
        public string Color { get; set; }        // Kolor licznika, np. w formacie HEX

        public CounterSettings(string name, int initialValue, string color)
        {
            Id = Guid.NewGuid();   // Generujemy unikalny ID dla licznika
            Name = name;
            InitialValue = initialValue;
            Color = color;
        }
    }
}
