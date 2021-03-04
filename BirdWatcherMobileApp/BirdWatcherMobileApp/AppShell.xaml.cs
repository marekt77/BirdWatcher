using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BirdWatcherMobileApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}
