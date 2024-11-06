using CommunityToolkit.Maui;
using CounterApp2.Services;
using CounterApp2.ViewModels;
using CounterApp2.Views;

namespace CounterApp2
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Rejestracja serwisu
            builder.Services.AddSingleton<ICounterService, CounterService>();
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddTransient<CounterViewModel>();
            builder.Services.AddTransient<MainViewPage>();
            builder.Services.AddTransient<CounterView>();

            return builder.Build();
        }
    }
}
