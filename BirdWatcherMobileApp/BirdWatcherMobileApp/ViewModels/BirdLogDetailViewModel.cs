using Xamarin.Forms;

namespace BirdWatcherMobileApp.ViewModels
{
    public class BirdLogDetailViewModel : BaseViewModel
    {
        public BirdLogDetailViewModel(INavigation nav)
        {
            Navigation = nav;
        }

        private INavigation Navigation { get; set; }
    }
}
