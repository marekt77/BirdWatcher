using BirdWatcherMobileApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BirdWatcherMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ServerAddressPage : ContentPage
    {
        ServerAddressViewModel SetServerAddressVM;
        public ServerAddressPage()
        {
            InitializeComponent();

            BindingContext = SetServerAddressVM = new ServerAddressViewModel(Navigation);

        }
    }
}