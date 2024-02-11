using WeatherStationApp.Services.Interface;

namespace WeatherStationApp.Services
{
    public sealed class SettingsService : ISettingsService
    {
        private const string serverIP = "server_ip";
        private const string serverIPDefault = "0.0.0.0";

        private const string useImperial = "use_imperial";

        public string ServerIP
        {
            get => Preferences.Get(serverIP, serverIPDefault);
            set => Preferences.Set(serverIP, value);
        }

        public bool UseImperial
        {
            get => Preferences.Get(useImperial, false);
            set => Preferences.Set(useImperial, value);
        }
    }
}
