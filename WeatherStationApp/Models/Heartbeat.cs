namespace WeatherStationApp.Models
{
    public class Heartbeat
    {
        public string applicationName { get; set; } = string.Empty;
        public DateTime requestDateTime { get; set; }
        public string welcomeMessage { get; set; } = string.Empty;
        public string appVersion { get; set; } = string.Empty;
    }
}
