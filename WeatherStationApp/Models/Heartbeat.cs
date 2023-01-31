namespace WeatherStationApp.Models
{
    public class Heartbeat
    {
        public string applicationName { get; set; }
        public DateTime requestDateTime { get; set; }
        public string welcomeMessage { get; set; }
        public string appVersion { get; set; }
    }
}
