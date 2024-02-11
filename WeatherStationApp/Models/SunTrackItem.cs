namespace WeatherStationApp.Models
{
    public class SunTrackItem
    {
        private string _temperature;
        public string Temperature
        {
            get => _temperature;
            set => _temperature = value;
        }

        private string _type;
        public string Type
        {
            get => _type;
            set => _type = value;
        }

        private string _time;
        public string Time
        {
            get => _time;
            set => _time = value;
        }
    }
}
