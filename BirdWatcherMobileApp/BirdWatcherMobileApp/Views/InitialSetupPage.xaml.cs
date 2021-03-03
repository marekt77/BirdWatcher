using BirdWatcherMobileApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BirdWatcherMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InitialSetupPage : ContentPage
    {
        InitialSetupViewModel initialSetupVM;
        public InitialSetupPage()
        {
            InitializeComponent();

            BindingContext = initialSetupVM = new InitialSetupViewModel();
        }
    }
}