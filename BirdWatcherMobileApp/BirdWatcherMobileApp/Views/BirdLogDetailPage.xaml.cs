using BirdWatcherMobileApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BirdWatcherMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BirdLogDetailPage : ContentPage
    {
        BirdLogDetailViewModel BirdLogDetailVM;
        public BirdLogDetailPage( BirdLogDetailViewModel tmpBirdLogDetailVM)
        {
            InitializeComponent();

            BindingContext = this.BirdLogDetailVM = tmpBirdLogDetailVM;

        }
    }
}