using BirdWatcherMobileApp.Models;
using System.Windows.Input;
using Xamarin.Forms;

namespace BirdWatcherMobileApp.ViewModels
{
    public class SetServerAddressViewModel : BaseViewModel
    {
        public SetServerAddressViewModel(INavigation _nav)
        {
            Navigation = _nav;

            SaveServerAddressCommand = new Command(() => SetServerAddress());

            if(!string.IsNullOrEmpty(Settings.ServerAddress))
            {
                _serverAddress = Settings.ServerAddress;
            }
        }

        private string _serverAddress;
        public string ServerAddress
        {
            get
            {
                return _serverAddress;
            }
            set
            {
                _serverAddress = value;
            }
        }

        private INavigation Navigation { get; set; }

        public ICommand SaveServerAddressCommand { get; }

        private async void SetServerAddress()
        {
            if(!string.IsNullOrEmpty(_serverAddress))
            {
                Settings.ServerAddress = _serverAddress;
                await Navigation.PopModalAsync();
            }
        }
    }
}
