using Counter.Services;

namespace Counter;

public partial class App : Application
{
    private readonly ICounterService _counterService;
    private List<Models.Counter> _currentCounters;

    public App(ICounterService counterService)
    {
        InitializeComponent();

        // Inicjalizacja usługi liczników
        _counterService = counterService;

        // Wczytanie liczników przy starcie
        _currentCounters = _counterService.LoadCounters();

        // Ustawienie strony głównej aplikacji
        MainPage = new NavigationPage(new MainPage());
    }

    protected override void OnStart()
    {
        // Wczytanie stanu liczników przy pierwszym uruchomieniu aplikacji (jeśli to potrzebne)
        _currentCounters = _counterService.LoadCounters();

        // Możemy również zainicjalizować inne usługi, jeśli aplikacja tego wymaga
    }

    protected override void OnSleep()
    {
        // Automatyczny zapis stanu liczników przed uśpieniem aplikacji
        _counterService.SaveCounters(_currentCounters);
    }

    protected override void OnResume()
    {
        // Opcjonalnie wczytanie danych po wznowieniu, aby odświeżyć stan liczników
        _currentCounters = _counterService.LoadCounters();
    }
}