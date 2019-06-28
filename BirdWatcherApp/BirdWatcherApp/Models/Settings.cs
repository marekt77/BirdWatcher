using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace BirdWatcherApp.Models
{
    static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        public static bool IsServerAddressSet => AppSettings.Contains(nameof(ServerAddress));

        public static string ServerAddress
        {
            get => AppSettings.GetValueOrDefault(nameof(ServerAddress), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(ServerAddress), value);
        }
    }
}
