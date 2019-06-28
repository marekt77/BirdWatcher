using BirdWatcherApp.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BirdWatcherApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            //Check if Server Address has been set.  If not, show modal window to ask user to set the Server Address
            if(!Settings.IsServerAddressSet)
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
