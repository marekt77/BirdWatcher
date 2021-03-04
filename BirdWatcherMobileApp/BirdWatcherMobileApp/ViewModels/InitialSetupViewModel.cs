using BirdWatcherMobileApp.Models;
using BirdWatcherMobileApp.Services.Routing;
using Splat;
using System.Windows.Input;
using Xamarin.Forms;

namespace BirdWatcherMobileApp.ViewModels
{
    class InitialSetupViewModel : BaseViewModel
    {
        private readonly IRoutingService routingService;
        public InitialSetupViewModel(IRoutingService routingService = null)
        {
            this.routingService = routingService ?? Locator.Current.GetService<IRoutingService>();
            TestConnectionCommand = new Command(() => TestConnection());
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
                OnPropertyChanged("ServerAddress");
            }
        }

        public ICommand TestConnectionCommand { get; }

        private async void TestConnection()
        {
            if (!string.IsNullOrEmpty(ServerAddress))
            {
                //Check if Server Address if valid
                BirdWatcher serverInfo = await BirdWatcherService.GetServerInfo(ServerAddress);

                if (serverInfo.welcomeMessage != null)
                {
                    Settings.ServerAddress = ServerAddress;
                    await App.Current.MainPage.DisplayAlert("Yay", "Connection successful!", "Ok");

                    await this.routingService.NavigateTo("///main");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Opps!", "Could not connect to server.  Please check if address is correct", "OK");
                }
            }
            else
            {
               await App.Current.MainPage.DisplayAlert("Opps!", "Server address cannot be blank.", "Ok");
            }
        }

    }
}
