namespace BirdWatcherMobileApp.ViewModels
{
    public class KnownBirdDetailPageViewModel : BaseViewModel
    {
        public KnownBird knownBird { get; set; }
        public KnownBirdDetailPageViewModel(KnownBird tmpKnownBird)
        {
            knownBird = tmpKnownBird;

            Title = knownBird.Name + " Details";
        }
    }
}
