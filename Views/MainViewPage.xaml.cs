using CommunityToolkit.Maui.Views;
using CounterApp2.Models;
using CounterApp2.ViewModels;
using System.Diagnostics;

namespace CounterApp2.Views;

public partial class MainViewPage : ContentPage
{
    private readonly MainViewModel viewModel;
    public MainViewPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        this.viewModel = viewModel;
        LoadCounters();
    }
    private void LoadCounters()
    {
        CounterListView.ItemsSource = new List<CounterViewModel>();
        CounterListView.ItemsSource = viewModel.Counters;
    }

    private async void AddCounterCommand(object sender, EventArgs e)
    {
        var popup = new AddCounterPopup();
        popup.CounterCreated += (name, initialValue, color) =>
        {
            var newCounter = new CounterModel(name, initialValue, color);
            viewModel.AddCounterCommand.Execute(newCounter);
            LoadCounters();
        };

        await Application.Current.MainPage.ShowPopupAsync(popup);
    }


    private async void RefreshCommand(object sender, EventArgs e)
    {
        LoadCounters();
    }
}