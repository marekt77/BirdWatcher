using BirdWatcherMobileApp.Models;
using BirdWatcherMobileApp.Views;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BirdWatcherMobileApp.ViewModels
{
    public class KnownBirdsViewModel : BaseViewModel
    {
        private BindingList<KnownBird> _knownBirds { get; set; }
        public BindingList<KnownBird> KnownBirds
        {
            get
            {
                return _knownBirds;
            }
            set
            {
                _knownBirds = value;
                OnPropertyChanged("KnownBirds");
            }
        }
        public Command LoadKnownBirdsCommand { get; set; }

        public INavigation Navigation { get; set; }

        public async void OnItemTapped(object sender, ItemTappedEventArgs args, INavigation myNav)
        {
            KnownBird selectedBird = args.Item as KnownBird;

            await myNav.PushAsync(new KnownBirdDetailPage(new KnownBirdDetailPageViewModel(selectedBird)));
        }

        public KnownBirdsViewModel()
        {
            Title = "Known Birds";
            KnownBirds = new BindingList<KnownBird>();

            LoadKnownBirdsCommand = new Command(async () => await ExecuteLoadBirdsCommand());
        }

        async Task ExecuteLoadBirdsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                KnownBirds.Clear();
                var _birds = await BirdService.GetKnownBirdsAsync();

                foreach (var tmpBird in _birds)
                {
                    KnownBird tmpKB = new KnownBird();

                    tmpKB.BirdID = tmpBird.BirdID;
                    tmpKB.Name = tmpBird.Name;
                    tmpKB.examplePicture = tmpBird.examplePicture;

                    //Change this to URL when setting this from the REST API and not the local data.
                    //tmpKB.BirdImage = ImageSource.FromResource("BirdWatcherMobileApp.SampleData.images." + tmpBird.examplePicture);

                    tmpKB.BirdImage = ImageSource.FromUri(new Uri("http://" + Settings.ServerAddress + "/images/bird_examples/" + tmpBird.examplePicture));

                    KnownBirds.Add(tmpKB);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }

    public class KnownBird : Bird
    {
        private ImageSource _birdImage { get; set; }
        public ImageSource BirdImage
        {
            get
            {
                return _birdImage;
            }
            set
            {
                _birdImage = value;
                OnPropertyChanged("BirdImage");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
