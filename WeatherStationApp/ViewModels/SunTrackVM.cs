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
        private readonly ISettingsService _settingService;

        public SunTrackVM(IWeatherStationService weatherStationService, ISettingsService settingsService)
        {
            _weatherStationService = weatherStationService;
            _settingService = settingsService;
        }

        #region Variables

        private ObservableCollection<SunTrackDay> _sunTrack;
        public ObservableCollection<SunTrackDay> SunTrack
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

                SunTrack = new ObservableCollection<SunTrackDay>();

                foreach (var item in data.data.Select(x => x.timestamp.Date).ToList())
                {

                    List<SunTrackItem> events = new List<SunTrackItem>();

                    foreach (var stItem in data.data.Where(x => x.timestamp.Date == item))
                    {
                        string temp;
                        if (_settingService.UseImperial)
                        {
                            temp = ((int)((stItem.temperature * 9) / 5 + 32)).ToString() + "F";
                        }
                        else
                        {
                            temp = ((int)stItem.temperature).ToString() + "C";
                        }

                        SunTrackItem sunTrackItem = new SunTrackItem
                        {
                            Temperature = temp,
                            Type = stItem.type,
                            Time = stItem.timestamp.ToShortTimeString()
                        };

                        events.Add(sunTrackItem);

                    }

                    SunTrack.Add(new SunTrackDay(item.ToShortDateString(), events));
                }

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
