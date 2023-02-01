using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using WeatherStationApp.Messages;
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

        public async void GetWeatherData()
        {
            try
            {
                var data = await _weatherStationService.GetSunTrackInfo();
                SunTrack = new ObservableCollection<SunTrack>(data.data);
            }
            catch (Exception ex)
            {
                WeakReferenceMessenger.Default.Send(new ErrorMessage 
                { 
                    Error = "Cannot get Sun Tracking data.  Check connection and try again"
                });
            }
        }
    }
}
