using BirdWatcherMobileApp.Models;
using BirdWatcherMobileApp.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BirdWatcherMobileApp.ViewModels
{
    public class BirdLogViewModel : BaseViewModel
    {
        public BirdLogViewModel()
        {
            Title = "Bird Watcher Log";
            BirdLog = new ObservableCollection<BirdLogEntry>();

            LoadBirdLogCommand = new Command(async () => await ExecuteLoadBirdLogsCommand());
        }

        async Task ExecuteLoadBirdLogsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var _birdLog = await BirdWatcherLogService.GetBirdLogsAsync();

                foreach(var tmpBirdLog in _birdLog.items)
                {
                    BirdLogEntry tmpBLE = new BirdLogEntry();

                    tmpBLE.birdLogID = tmpBirdLog.birdLogID;
                    tmpBLE.LogDate = tmpBirdLog.timestamp.ToString("MM/dd/yyyy");
                    if(Settings.Use24Hour)
                    {
                        tmpBLE.LogTime = tmpBirdLog.timestamp.ToString("HH:mm");
                    }
                    else
                    {
                        tmpBLE.LogTime = tmpBirdLog.timestamp.ToString("hh:mm tt");
                    }
                    if(!String.IsNullOrEmpty(tmpBirdLog.picture))
                    {
                        //tmpBLE.LogImage = ImageSource.FromUri(new Uri("http://" + Settings.ServerAddress + "/images/captured/" + tmpBirdLog.picture));
                        tmpBLE.LogImage = new UriImageSource { CachingEnabled = false, Uri = new Uri("http://" + Settings.ServerAddress + "/images/captured/" + tmpBirdLog.picture) };
                    }

                    BirdLog.Add(tmpBLE);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }

        }

        public Command LoadBirdLogCommand { get; set; }

        public async void OnItemTapped(object sender, ItemTappedEventArgs args, INavigation myNav)
        {

            BirdLogEntry selectedBirdLog = args.Item as BirdLogEntry;

            await myNav.PushAsync(new BirdLogDetailPage(new BirdLogDetailViewModel(selectedBirdLog.birdLogID)));
        }

        private ObservableCollection<BirdLogEntry> _birdLog { get; set; }
        public ObservableCollection<BirdLogEntry> BirdLog {
            get
            {
                return _birdLog;
            }
            set
            {
                _birdLog = value;
                OnPropertyChanged("BirdLog");
            }
        }
        
    }

    public class BirdLogEntry
    {
        public long birdLogID { get; set; }

        public ImageSource LogImage { get;set; }

        public string LogDate { get; set; }

        public string LogTime { get; set; }

        public int BirdsFound { get; set; }
    }
}
