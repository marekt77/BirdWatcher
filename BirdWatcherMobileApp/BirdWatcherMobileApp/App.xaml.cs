using Xamarin.Forms;
using BirdWatcherMobileApp.Models;

namespace BirdWatcherMobileApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //Get rid of this later....
            //DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            //Check if Server Address has been set.  If not, show modal window to ask user to set the Server Address
            if (!Settings.IsServerAddressSet)
            {

                //Show Modal

            }
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
