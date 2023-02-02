namespace WeatherStationApp.Models
{
    public class SunTrackDay : List<SunTrackItem>
    {
        public string Date { get; private set; }

        public SunTrackDay(string date, List<SunTrackItem> events) : base(events) 
        { 
            Date = date;
        }
    }
}
