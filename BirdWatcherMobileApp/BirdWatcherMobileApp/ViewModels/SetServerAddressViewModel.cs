using BirdWatcherMobileApp.Models;
using BirdWatcherMobileApp.Views;
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
                ServerAddress = Settings.ServerAddress;
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
            if(!string.IsNullOrEmpty(ServerAddress))
            {
                Settings.ServerAddress = ServerAddress;
                MessagingCenter.Send<SetServerAddressViewModel>(this, "update");
                await Navigation.PopModalAsync();
            }
        }
    }
}
