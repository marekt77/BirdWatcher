using BirdWatcherMobileApp.Models;
using BirdWatcherMobileApp.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace BirdWatcherMobileApp.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public SettingsViewModel(INavigation _nav)
        {
            Title = "Settings";

            _serverIP = Settings.ServerAddress;
            _connStatus = "Connected";

            Navigation = _nav;

            ServerAddressPage _serverAddressPage = new ServerAddressPage();

            OpenSetServerAddressCommand = new Command(async () => await Navigation.PushModalAsync(_serverAddressPage));

            MessagingCenter.Subscribe<SetServerAddressViewModel>(this, "update", (sender) =>
            {
                UpdatePageData();
            });
        }

        private void UpdatePageData()
        {
            ServerIP = Settings.ServerAddress;
            ConnStatus = "Connected";
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

        public ICommand OpenSetServerAddressCommand { get; }

        private INavigation Navigation { get; set; }

    }
}
