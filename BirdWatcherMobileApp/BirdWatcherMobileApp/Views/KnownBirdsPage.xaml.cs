using BirdWatcherMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            BindingContext = knownBirdsVM = new KnownBirdsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (knownBirdsVM.KnownBirds.Count == 0)
                knownBirdsVM.LoadKnownBirdsCommand.Execute(null);
        }
    }
}