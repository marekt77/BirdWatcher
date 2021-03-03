using BirdWatcherMobileApp.Models;
using BirdWatcherMobileApp.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BirdWatcherMobileApp.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public SettingsViewModel(INavigation _nav)
        {
            Title = "Settings";

            UpdatePageData();

            Navigation = _nav;

            ServerAddressPage _serverAddressPage = new ServerAddressPage();

            OpenSetServerAddressCommand = new Command(async () => await Navigation.PushModalAsync(_serverAddressPage));

            MessagingCenter.Subscribe<ServerAddressViewModel>(this, "update", (sender) =>
            {
                UpdatePageData();
            });
        }

        private async void UpdatePageData()
        {
            ServerIP = Settings.ServerAddress;
            ConnErrorVisible = false;
            ServerDetailsVisible = false;
            ConnStatus = null;

            TryingConnectionVisible = true;
            if(await IsConnected())
            {
                TryingConnectionVisible = false;
                ConnStatus = "Connected";
            }
            else
            {
                TryingConnectionVisible = false;
                ConnStatus = "Not Connected";
                ConnErrorVisible = true;
            }
        }

        private async Task<bool> IsConnected()
        {
            bool isConnected = false;
            
            BirdWatcher serverInfo = await BirdWatcherService.GetServerInfo();

            if (serverInfo.welcomeMessage != null)
            {
                isConnected = true;
                ServerVersion = serverInfo.appVersion;
                WelcomeMessage = serverInfo.welcomeMessage;
                ServerDetailsVisible = true;
            }
            else
            {
                //ConnErrorMessage = serverInfo.errorMessage;
            }

            return isConnected;
        }

        private string _connStatus;
        public string ConnStatus
        {
            get
            {
                return _connStatus;
            }
            set
            {
                _connStatus = value;
                OnPropertyChanged("ConnStatus");
            }
        }

        private string _serverIP;
        public string ServerIP
        {
            get
            {
                return _serverIP;
            }
            set
            {
                _serverIP = value;
                OnPropertyChanged("ServerIP");
            }
        }

        public bool UseMetric
        {
            get
            {
                return Settings.UseMetric;
            }
            set
            {
                Settings.UseMetric = value;
                OnPropertyChanged("UseMetric");
            }
        }

        public bool Use24Hour
        {
            get
            {
                return Settings.Use24Hour;
            }
            set
            {
                Settings.Use24Hour = value;
                OnPropertyChanged("Use24Hour");
            }
        }

        private string _connErrorMessage;
        public string ConnErrorMessage
        {
            get
            {
                return _connErrorMessage;
            }
            set
            {
                _connErrorMessage = value;
                OnPropertyChanged("ConnErrorMessage");
            }
        }

        private bool _connErrorVisible = false;
        public bool ConnErrorVisible
        {
            get
            {
                return _connErrorVisible;
            }
            set
            {
                _connErrorVisible = value;
                OnPropertyChanged("ConnErrorVisible");
            }
        }

        private bool _serverDetailsVisible = false;
        public bool ServerDetailsVisible
        {
            get
            {
                return _serverDetailsVisible;
            }
            set
            {
                _serverDetailsVisible = value;
                OnPropertyChanged("ServerDetailsVisible");
            }
        }

        private string _serverVersion;

        public string ServerVersion
        {
            get
            {
                return _serverVersion;
            }
            set
            {
                _serverVersion = value;
                OnPropertyChanged("ServerVersion");
            }
        }

        private string _serverOS;

        public string ServerOS
        {
            get
            {
                return _serverOS;
            }
            set
            {
                _serverOS = value;
                OnPropertyChanged("ServerOS");
            }
        }

        private string _welcomeMessage;

        public string WelcomeMessage
        {
            get
            {
                return _welcomeMessage;
            }
            set
            {
                _welcomeMessage = value;
                OnPropertyChanged("WelcomeMessage");
            }
        }

        private bool _tryingConnectionVisible;
        public bool TryingConnectionVisible
        {
            get
            {
                return _tryingConnectionVisible;
            }
            set
            {
                _tryingConnectionVisible = value;
                OnPropertyChanged("TryingConnectionVisible");
            }
        }

        public ICommand OpenSetServerAddressCommand { get; }

        private INavigation Navigation { get; set; }

    }
}
