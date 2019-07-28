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
    public partial class KnownBirdDetailPage : ContentPage
    {
        KnownBirdDetailPageViewModel knowBirdVM;

        public KnownBirdDetailPage(KnownBirdDetailPageViewModel tmpKnownBirdVM)
        {
            InitializeComponent();

            BindingContext = this.knowBirdVM = tmpKnownBirdVM;
        }
    }
}