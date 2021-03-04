using Xamarin.Forms;
using Splat;
using BirdWatcherMobileApp.Services.Routing;
using BirdWatcherMobileApp.ViewModels;

namespace BirdWatcherMobileApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeDi();
            InitializeComponent();

            MainPage = new AppShell();
        }

        private void InitializeDi()
        {
            Locator.CurrentMutable.RegisterLazySingleton<IRoutingService>(() => new ShellRoutingService());

            //ViewModels
            Locator.CurrentMutable.Register(() => new LoadingViewModel());
            Locator.CurrentMutable.Register(() => new InitialSetupViewModel());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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
