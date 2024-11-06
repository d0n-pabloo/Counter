using CounterApp2.Models;
using System.Diagnostics;
using System.Windows.Input;

namespace CounterApp2.ViewModels
{
    public class CounterViewModel
    {
        private readonly CounterModel _counterModel;
        public CounterModel CounterModel { get { return _counterModel; } }

        public string Name => _counterModel.Name;
        public string Color => _counterModel.Color;
        public int Value => _counterModel.Value;

        public ICommand IncrementCommand { get; }
        public ICommand DecrementCommand { get; }
        public ICommand ResetCommand {  get; }

        public CounterViewModel(CounterModel counterModel)
        {
            _counterModel = counterModel;

            IncrementCommand = new Command(OnIncrement);
            DecrementCommand = new Command(OnDecrement);
            ResetCommand = new Command(OnReset);
        }

        private void OnIncrement()
        {
            _counterModel.Value++;
        }

        private void OnDecrement()
        {
            _counterModel.Value--;
        }

        private void OnReset()
        {
            _counterModel.Reset();
        }
    }
}
