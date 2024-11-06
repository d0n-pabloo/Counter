using CounterApp2.ViewModels;

namespace CounterApp2.Views;

public partial class CounterView : ContentPage
{
    public CounterView(CounterViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}