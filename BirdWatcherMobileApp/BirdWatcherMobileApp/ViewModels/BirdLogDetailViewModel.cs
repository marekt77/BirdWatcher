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


            LogTemp = birdLog.temperature.ToString();
            LogDate = birdLog.timestamp.ToString("MM/dd/yyyy");
            LogTime = birdLog.timestamp.ToString("hh:mm tt");

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

        public ImageSource LogImage { get; set; }

        public string LogDate { get; set; }

        public string LogTime { get; set; }

        public string LogTemp { get; set; }

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
    }
}
