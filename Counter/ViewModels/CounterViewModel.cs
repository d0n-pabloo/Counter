using Counter.Helpers;
using Counter.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;


namespace Counter.ViewModels
{
    public class CounterViewModel : INotifyPropertyChanged
    {
        private Models.Counter _counter;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name => _counter.Settings.Name;
        public string Color => _counter.Settings.Color;

        public Models.Counter Counter => _counter;

        public int Value
        {
            get => _counter.Value;
            private set
            {
                if (_counter.Value != value)
                {
                    _counter = new Models.Counter(new CounterSettings(_counter.Settings.Name, _counter.Settings.InitialValue, _counter.Settings.Color)) { Value = value };
                    OnPropertyChanged();
                }
            }
        }

        public ICommand IncrementCommand { get; }
        public ICommand DecrementCommand { get; }
        public ICommand ResetCommand { get; }

        public CounterViewModel(Models.Counter counter)
        {
            _counter = counter;
            IncrementCommand = new RelayCommand(Increment);
            DecrementCommand = new RelayCommand(Decrement);
            ResetCommand = new RelayCommand(Reset);
        }

        private void Increment()
        {
            _counter.Increment();
            OnPropertyChanged(nameof(Value));
        }

        private void Decrement()
        {
            _counter.Decrement();
            OnPropertyChanged(nameof(Value));
        }

        private void Reset()
        {
            _counter.Reset();
            OnPropertyChanged(nameof(Value));
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
