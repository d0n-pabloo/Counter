using CounterApp2.Models;
using CounterApp2.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CounterApp2.ViewModels
{
    public class MainViewModel
    {
        private readonly ICounterService _counterService;
        public ObservableCollection<CounterViewModel> Counters { get; set; }
        
        public ICommand AddCounterCommand { get; }
        public ICommand RemoveCounterCommand { get; }

        public MainViewModel()
        {
            _counterService = new CounterService();
            Counters = new ObservableCollection<CounterViewModel>();
            AddCounterCommand = new Command<CounterModel>(OnAddCounter);
            RemoveCounterCommand = new Command<CounterViewModel>(OnRemoveCounter);

            LoadCounters();
        }

        private void LoadCounters()
        {
            var counters = _counterService.LoadCounters();
            foreach (var counter in counters) 
            {
                Counters.Add(new CounterViewModel(counter));
                counter.PropertyChanged += (sender, changed) =>
                {
                    _counterService.SaveCounters(Counters.Select(c => c.CounterModel));
                };
            }
        }

        private void OnAddCounter(CounterModel counterModel)
        {
            Counters.Add(new CounterViewModel(counterModel));
            _counterService.SaveCounters(Counters.Select(c => c.CounterModel));
        }

        private void OnRemoveCounter(CounterViewModel counterViewModel)
        {
            if (counterViewModel == null)
                return;
            Counters.Remove(counterViewModel);
            _counterService.SaveCounters(Counters.Select(c => c.CounterModel));
        }
    }
}
