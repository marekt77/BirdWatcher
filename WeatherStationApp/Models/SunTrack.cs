namespace WeatherStationApp.Models
{
    public class SunTrack : RootModel<SunTrack>
    {
        public int id { get; set; }
        public double temperature { get; set; }
        public double photoresistorValue { get; set; }
        public DateTime timestamp { get; set; }
        public string type { get; set; }
    }
}
