using BirdWatcherMobileApp.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BirdWatcherMobileApp.ViewModels
{
    public class KnownBirdsViewModel : BaseViewModel
    {
        public ObservableCollection<KnownBirds> KnownBirds { get; set; }
        public Command LoadKnownBirdsCommand { get; set; }

        public KnownBirdsViewModel()
        {
            Title = "Known Birds";
            KnownBirds = new ObservableCollection<KnownBirds>();

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
                    KnownBirds tmpKB = new KnownBirds();

                    tmpKB.BirdID = tmpBird.BirdID;
                    tmpKB.Name = tmpBird.Name;
                    tmpKB.Image = tmpBird.Image;

                    //Change this to URL when setting this from the REST API and not the local data.
                    tmpKB.BirdImage = ImageSource.FromResource("BirdWatcherMobileApp.SampleData.images." + tmpBird.Image);

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

    public class KnownBirds : Bird
    {
        public ImageSource BirdImage { get; set; }
    }
}
