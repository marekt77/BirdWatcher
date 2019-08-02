using BirdWatcherMobileApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BirdWatcherMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BirdLogPage : ContentPage
    {
        BirdLogViewModel BirdLogVM;
        public BirdLogPage()
        {
            InitializeComponent();

            BindingContext = BirdLogVM = new BirdLogViewModel();
        }

        /*
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
        }*/
    }
}
