using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace BirdWatcherMobileApp.Models
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

        public static bool UseMetric
        {
            get => AppSettings.GetValueOrDefault(nameof(UseMetric), false);
            set => AppSettings.AddOrUpdateValue(nameof(UseMetric), value);
        }

        public static bool Use24Hour
        {
            get => AppSettings.GetValueOrDefault(nameof(Use24Hour), false);
            set => AppSettings.AddOrUpdateValue(nameof(Use24Hour), value);
        }
    }
}
