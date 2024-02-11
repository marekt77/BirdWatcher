using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Input;
using WeatherStationApp.Messages;
using WeatherStationApp.Services.Interface;

namespace WeatherStationApp.ViewModels
{
    public class SettingsVM : BaseVM
    {
        private readonly ISettingsService _settingService;
        private readonly IWeatherStationService _weatherStationService;

        public SettingsVM(
            ISettingsService settingsService,
            IWeatherStationService weatherStationService)
        {
            _settingService = settingsService;
            _weatherStationService = weatherStationService;
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
                _serverAddress = value;
                OnPropertyChanged();
                SaveEnabled = false;
            }
        }

        private bool _useImperial;

        private object _tempSelection;
        public object TempSelection
        {
            get => _tempSelection;
            set
            {
                _tempSelection = value;
                OnPropertyChanged(nameof(TempSelection));
            }
        }

        private object _saveEnabled;
        public object SaveEnabled
        {
            get => _saveEnabled;
            set
            {
                _saveEnabled = value;
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
            ServerAddress = _settingService.ServerIP;
            _useImperial = _settingService.UseImperial;

            if (ServerAddress == "0.0.0.0")
            {
                SaveEnabled = false;
            }
            else
            {
                SaveEnabled = true;
            }

            if (_useImperial)
            {
                TempSelection = "F";
            }
            else
            {
                TempSelection = "C";
            }
        }

        private async void CheckConnection()
        {
            if (!string.IsNullOrEmpty(ServerAddress) || ServerAddress != "0.0.0.0")
            {
                try
                {
                    var result = await _weatherStationService.GetHeartbeat(ServerAddress);

                    if (result != null)
                    {
                        WeakReferenceMessenger.Default.Send(new ConnectionCheckMessage
                        {
                            ServerIPAddress = ServerAddress,
                            IsSuccessful = true
                        });
                        SaveEnabled = true;
                    }
                    else
                    {
                        WeakReferenceMessenger.Default.Send(new ConnectionCheckMessage
                        {
                            ServerIPAddress = ServerAddress,
                            IsSuccessful = false
                        });
                        SaveEnabled = false;
                    }
                }
                catch (Exception ex)
                {
                    WeakReferenceMessenger.Default.Send(new ConnectionCheckMessage
                    {
                        ServerIPAddress = ServerAddress,
                        IsSuccessful = false
                    });
                }
            }
        }

        private void SaveSettings()
        {
            if ((string)TempSelection == "C")
            {
                _settingService.UseImperial = false;
            }
            else
            {
                _settingService.UseImperial = true;
            }

            _settingService.ServerIP = ServerAddress;

            WeakReferenceMessenger.Default.Send(new SettingsSavedMessage());
        }
    }
}
