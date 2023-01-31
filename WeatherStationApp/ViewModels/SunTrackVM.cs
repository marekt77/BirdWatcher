using System.Collections.ObjectModel;
using WeatherStationApp.Models;
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

        #region Variables

        private ObservableCollection<SunTrack> _sunTrack;
        public ObservableCollection<SunTrack> SunTrack
        {
            get => _sunTrack;
            set
            {
                _sunTrack = value;
                OnPropertyChanged();
            }
        }

        #endregion

        //public ObservableCollection<TodoItem> Items { get; set; } = new();

        private async void GetWeatherData()
        {
            var data = await _weatherStationService.GetSunTrackInfo();

            SunTrack = new ObservableCollection<SunTrack>(data.data);

        }
    }
}
