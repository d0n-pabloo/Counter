using CounterApp2.Views;

namespace CounterApp2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainViewPage(new ViewModels.MainViewModel());
        }
    }
}
