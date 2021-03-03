using BirdWatcherMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BirdWatcherMobileApp.ViewModels
{
    public class InitialSetupViewModel : BaseViewModel
    {
        public InitialSetupViewModel()
        {
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
                }
            }
            else
            {

            }
        }

    }
}
