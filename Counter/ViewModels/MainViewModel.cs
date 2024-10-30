using Counter.Helpers;
using Counter.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Counter.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ICounterService _counterService;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<CounterViewModel> Counters { get; private set; }

        public ICommand AddCounterCommand { get; }
        public ICommand ResetAllCommand { get; }
        public ICommand SaveCommand { get; }

        public MainViewModel(ICounterService counterService)
        {
            _counterService = counterService;
            Counters = new ObservableCollection<CounterViewModel>(_counterService.LoadCounters().Select(c => new CounterViewModel(c)));

            AddCounterCommand = new RelayCommand(AddCounter);
            ResetAllCommand = new RelayCommand(ResetAllCounters);
            SaveCommand = new RelayCommand(SaveAllCounters);
        }

        private void AddCounter()
        {
            // Przykładowa logika do dodawania nowego licznika (parametry można modyfikować)
            var newCounterSettings = new CounterSettings("New Counter", 0, "#000000");  // Przykładowe wartości
            var newCounter = new Models.Counter(newCounterSettings);
            var newCounterViewModel = new CounterViewModel(newCounter);

            Counters.Add(newCounterViewModel);
            _counterService.SaveCounters(Counters.Select(vm => vm.Counter).ToList());
        }

        private void ResetAllCounters()
        {
            foreach (var counterViewModel in Counters)
            {
                counterViewModel.ResetCommand.Execute(null);
            }
            SaveAllCounters();
        }

        private void SaveAllCounters()
        {
            _counterService.SaveCounters(Counters.Select(vm => vm.Counter).ToList());
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
