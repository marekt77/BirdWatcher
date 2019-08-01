using System;
using System.Collections.Generic;
using System.Text;

namespace BirdWatcherMobileApp.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public SettingsViewModel()
        {
            Title = "Settings";

            _serverIP = "192.168.1.2";
            _connStatus = "Connected";
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
            }
        }
    }
}
