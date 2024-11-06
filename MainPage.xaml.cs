using CommunityToolkit.Maui.Views;
using CounterApp2.Models;
using CounterApp2.Services;
using CounterApp2.ViewModels;
using CounterApp2.Views;
using System.Diagnostics;

namespace CounterApp2
{
    public partial class MainPage : ContentPage
    {
        private readonly MainViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            BindingContext = _viewModel;

            // Inicjalizacja widoku
            LoadCounters();
        }

        private void LoadCounters()
        {
            CounterListView.ItemsSource = _viewModel.Counters;
        }

        private async void OnCounterTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                var counter = e.Item as CounterViewModel;
                // Przejdź do widoku szczegółów licznika lub edycji
                await Navigation.PushAsync(new CounterView(counter));
            }
        }

        private async void OnAddCounterClicked(object sender, EventArgs e)
        {
            var popup = new AddCounterPopup();
            popup.CounterCreated += (name, initialValue, color) =>
            {
                var newCounter = new CounterModel(name, initialValue, color);
                _viewModel.AddCounterCommand.Execute(newCounter);
                LoadCounters();
            };

            await Application.Current.MainPage.ShowPopupAsync(popup);
        }
    }

}
