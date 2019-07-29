using BirdWatcherMobileApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BirdWatcherMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KnownBirdDetailPage : ContentPage
    {
        KnownBirdDetailPageViewModel knowBirdVM;

        public KnownBirdDetailPage(KnownBirdDetailPageViewModel tmpKnownBirdVM)
        {
            InitializeComponent();

            BindingContext = this.knowBirdVM = tmpKnownBirdVM;
        }
    }
}