﻿using Microsoft.Extensions.DependencyInjection;
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
                .RegisterAppServices()
                .RegisterViewModels()
                .RegisterViews()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("fa_solid.ttf", "FontAwesome");
                });


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
            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<SunTrackPage>();
            mauiAppBuilder.Services.AddTransient<SettingsPage>();

            return mauiAppBuilder;
        }
    }
}