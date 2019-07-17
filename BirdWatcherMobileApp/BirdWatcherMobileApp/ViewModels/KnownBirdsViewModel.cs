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
        public ObservableCollection<Bird> KnownBirds { get; set; }
        public Command LoadKnownBirdsCommand { get; set; }

        public KnownBirdsViewModel()
        {
            Title = "Known Birds";
            KnownBirds = new ObservableCollection<Bird>();

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
                    KnownBirds.Add(tmpBird);
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
}
