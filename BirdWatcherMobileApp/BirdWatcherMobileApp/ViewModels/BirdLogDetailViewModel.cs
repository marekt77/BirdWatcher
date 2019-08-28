using BirdWatcherMobileApp.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BirdWatcherMobileApp.ViewModels
{
    public class BirdLogDetailViewModel : BaseViewModel
    {
        public BirdLogDetailViewModel(long tmpBirdLogID)
        {
            BirdsFound = new List<string>();
            LoadBirdLog(tmpBirdLogID);
        }

        private async void LoadBirdLog(long birdLogID)
        {
            var birdLog = await BirdWatcherLogService.GetBirdLogAsync(birdLogID);

            if(Settings.UseMetric)
            {

                LogTemp = birdLog.temperature.ToString() + "C";
            }
            else
            {
                LogTemp = ConvertCelsiusToFahrenheit(birdLog.temperature).ToString() + "F";
            }

            LogDate = birdLog.timestamp.ToString("MM/dd/yyyy");

            if (Settings.Use24Hour)
            {
                LogTime = birdLog.timestamp.ToString("HH:mm");
            }
            else
            {
                LogTime = birdLog.timestamp.ToString("hh:mm tt");
            }

            if (!String.IsNullOrEmpty(birdLog.picture))
            {
                LogImage = new UriImageSource { CachingEnabled = false, Uri = new Uri("http://" + Settings.ServerAddress + "/images/captured/" + birdLog.picture) };
            }

            foreach(int x in birdLog.birds)
            {
                var knownBird = await BirdService.GetKnownBirdAsync(x);
                BirdsFound.Add(knownBird.Name);
            }

        }

        private ImageSource _logImage;
        public ImageSource LogImage
        {
            get
            {
                return _logImage;
            }
            set
            {
                _logImage = value;
                OnPropertyChanged("LogImage");
            }
        }

        private string _logDate;
        public string LogDate
        {
            get
            {
                return _logDate;
            }
            set
            {
                _logDate = value;
                OnPropertyChanged("LogDate");
            }
        }

        private string _logTime;
        public string LogTime
        {
            get
            {
                return _logTime;
            }
            set
            {
                _logTime = value;
                OnPropertyChanged("LogTime");
            }
        }

        private string _logTemp;
        public string LogTemp
        {
            get
            {
                return _logTemp;
            }
            set
            {
                _logTemp = value;
                OnPropertyChanged("LogTemp");
            }
        }

        private List<string> _birdsFound { get; set; }
        public List<string> BirdsFound
        {
            get
            {
                return _birdsFound;
            }
            set
            {
                _birdsFound = value;
                OnPropertyChanged("BirdsFound");
            }
        }

        private double ConvertCelsiusToFahrenheit(double c)
        {
            return ((9.0 / 5.0) * c) + 32;
        }
    }
}
