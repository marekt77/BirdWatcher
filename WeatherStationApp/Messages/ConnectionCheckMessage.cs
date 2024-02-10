namespace WeatherStationApp.Messages
{
    public class ConnectionCheckMessage
    {
        public string ServerIPAddress { get; set; } = string.Empty;
        public bool IsSuccessful { get; set; }
    }
}
