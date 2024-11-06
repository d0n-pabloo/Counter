using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace CounterApp2.Models
{
    public class CounterModel : INotifyPropertyChanged
    {
        private int _value;
        private int _initialValue;
        private string _name;
        private string _color;

        public int Value
        {
            get => _value;
            set
            {
                if (_value != value) {
                    _value = value;
                    OnPropertyChanged();
                }
            }
        }
        public int InitialValue
        {
            get => _initialValue;
            set
            {
                if (_initialValue != value)
                {
                    _initialValue = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Color
        {
            get => _color;
            set
            {
                if (_color != value)
                {
                    _color = value;
                    OnPropertyChanged();
                }
            }
        }

        public CounterModel(string name, int  initialValue, string color)
        {
            Name = name;
            InitialValue = initialValue;
            Value = initialValue;
            Color = color;
        }

        public void Reset()
        {
            Value = InitialValue;
            OnPropertyChanged();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
