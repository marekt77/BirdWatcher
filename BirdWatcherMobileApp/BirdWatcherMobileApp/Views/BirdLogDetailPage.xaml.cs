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
    public partial class BirdLogDetailPage : ContentPage
    {
        BirdLogDetailViewModel BirdLogDetailVM;
        public BirdLogDetailPage()
        {
            InitializeComponent();

            BindingContext = BirdLogDetailVM = new BirdLogDetailViewModel(Navigation);

        }
    }
}