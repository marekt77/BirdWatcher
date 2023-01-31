using System.Windows.Input;
using WeatherStationApp.Services.Interface;

namespace WeatherStationApp.ViewModels
{
    public class SettingsVM : BaseVM
    {
        private readonly ISettingsService _settingService;

        public SettingsVM(ISettingsService settingsService) 
        { 
            _settingService = settingsService;
            CheckConnectionCommand = new Command(CheckConnection);
            SaveSettingsCommand = new Command(SaveSettings);
            LoadValues();
        }

        #region Variables
        private string _serverAddress;
        public string ServerAddress
        {
            get => _serverAddress;
            set
            {
                if(!string.IsNullOrWhiteSpace(value))
                {
                    _settingService.ServerIP = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _useImperial;
        public bool UseImperial
        {
            get => _useImperial;
            set
            {
                _settingService.UseImperial = value;
                OnPropertyChanged();
            }
        }

        public ICommand CheckConnectionCommand
        {
            get;
        }

        public ICommand SaveSettingsCommand
        { 
            get; 
        }
        #endregion

        private void LoadValues()
        {
            _serverAddress = _settingService.ServerIP;
            _useImperial = _settingService.UseImperial;
        }

        private void CheckConnection()
        {

        }

        private void SaveSettings()
        {

        }
    }
}
