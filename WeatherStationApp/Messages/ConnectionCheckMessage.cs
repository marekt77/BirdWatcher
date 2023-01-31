namespace WeatherStationApp.Messages
{
    public class ConnectionCheckMessage
    {
        public string ServerIPAddress { get; set; }
        public bool IsSuccessful { get; set; }  
    }
}
