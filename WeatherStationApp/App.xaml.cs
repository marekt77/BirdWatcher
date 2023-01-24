using Microsoft.Maui.Controls;
using WeatherStationApp.Pages;

namespace WeatherStationApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}