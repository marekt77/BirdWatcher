using WeatherStationApp.Pages;

namespace WeatherStationApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("SunTrackPage", typeof(SunTrackPage));
        }
    }
}
