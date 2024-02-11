using Microsoft.Extensions.Logging;
using WeatherStationApp.Pages;
using WeatherStationApp.Services;
using WeatherStationApp.Services.Interface;
using WeatherStationApp.ViewModels;

namespace WeatherStationApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<IWeatherStationService, WeatherStationService>();
            mauiAppBuilder.Services.AddSingleton<ISettingsService, SettingsService>();

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<SunTrackVM>();
            mauiAppBuilder.Services.AddTransient<SettingsVM>();
            mauiAppBuilder.Services.AddTransient<MainPageVM>();
            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<SunTrackPage>();
            mauiAppBuilder.Services.AddTransient<SettingsPage>();
            mauiAppBuilder.Services.AddTransient<MainPage>();

            return mauiAppBuilder;
        }
    }
}
