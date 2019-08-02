using BirdWatcherMobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BirdWatcherMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        SettingsViewModel settingsVM;

        public SettingsPage()
        {
            InitializeComponent();

            BindingContext = settingsVM = new SettingsViewModel(Navigation);
        }
    }
}