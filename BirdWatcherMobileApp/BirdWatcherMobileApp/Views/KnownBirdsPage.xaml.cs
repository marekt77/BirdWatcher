using BirdWatcherMobileApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BirdWatcherMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KnownBirdsPage : ContentPage
    {
        KnownBirdsViewModel knownBirdsVM;

         public KnownBirdsPage()
        {
            InitializeComponent();

            Title = "Known Birds";

            BindingContext = knownBirdsVM = new KnownBirdsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (knownBirdsVM.KnownBirds.Count == 0)
                knownBirdsVM.LoadKnownBirdsCommand.Execute(null);
        }

        private void FlowListView_FlowItemTapped(object sender, ItemTappedEventArgs args)
        {
            knownBirdsVM.OnItemTapped(sender, args, Navigation);
        }
    }
}