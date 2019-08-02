using BirdWatcherMobileApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BirdWatcherMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ServerAddressPage : ContentPage
    {
        SetServerAddressViewModel SetServerAddressVM;
        public ServerAddressPage()
        {
            InitializeComponent();

            BindingContext = SetServerAddressVM = new SetServerAddressViewModel(Navigation);

        }
    }
}