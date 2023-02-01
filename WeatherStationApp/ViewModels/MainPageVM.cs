using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Maui.Dispatching;
using WeatherStationApp.Messages;
using WeatherStationApp.Services.Interface;

namespace WeatherStationApp.ViewModels
{
    public class MainPageVM : BaseVM
    {
        private readonly IWeatherStationService _weatherStationService;
        private readonly ISettingsService _settingService;
        private IDispatcherTimer viewRefresh;

        public MainPageVM(
            IWeatherStationService weatherStationService, 
            ISettingsService settingsService)
        {
            _weatherStationService = weatherStationService;
            _settingService = settingsService;

            var dispatcher = Application.Current.Dispatcher;

            viewRefresh = dispatcher.CreateTimer();

            viewRefresh.Tick += ViewRefresh_Tick;
            viewRefresh.Interval = new TimeSpan(0, 0, 1);

            LoadData();
        }

        private void ViewRefresh_Tick(object sender, EventArgs e)
        {
            Time = DateTime.Now.ToString("t");
        }

        #region Variables

        private string _temperature;
        public string Temperature
        {
            get => _temperature;
            set
            {
                _temperature = value;
                OnPropertyChanged();
            }
        }

        private string _date;
        public string Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        private string _time;
        public string Time
        {
            get => _time;
            set
            {
                _time = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public async void LoadData()
        {
            try
            {
                var tempData = await _weatherStationService.GetTempReading();

                if(_settingService.UseImperial)
                {
                    Temperature = ((int)((tempData.temperature * 9) / 5 + 32)).ToString() + "F";
                }
                else
                {
                    Temperature = ((int)tempData.temperature).ToString() + "C";
                }

            }
            catch(Exception ex)
            {
                WeakReferenceMessenger.Default.Send(new ErrorMessage 
                { 
                    Error = "Unable to get Temperature.  Please check connection and try again."
                });
            }

            Date = DateTime.Now.ToString("ddd, MMM dd");
            Time = DateTime.Now.ToString("t");
            viewRefresh.Start();
        }
    }
}
