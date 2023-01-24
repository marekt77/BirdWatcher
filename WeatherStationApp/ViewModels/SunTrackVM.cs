using WeatherStationApp.Services.Interface;

namespace WeatherStationApp.ViewModels
{
    public class SunTrackVM : BaseVM
    {
        private readonly IWeatherStationService _weatherStationService;

        public SunTrackVM(IWeatherStationService weatherStationService)
        {
            _weatherStationService = weatherStationService;

            GetWeatherData();
        }

        private async void GetWeatherData()
        {
            var blah = await _weatherStationService.GetSunTrackInfo();

            string x = "Marek";
        }
    }
}
