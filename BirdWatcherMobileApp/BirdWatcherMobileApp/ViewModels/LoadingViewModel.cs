using BirdWatcherMobileApp.Models;
using BirdWatcherMobileApp.Services.Routing;
using Splat;

namespace BirdWatcherMobileApp.ViewModels
{
    class LoadingViewModel : BaseViewModel
    {
        private readonly IRoutingService routingService;

        public LoadingViewModel(IRoutingService routingService = null)
        {
            this.routingService = routingService ?? Locator.Current.GetService<IRoutingService>();
        }


        //Called by the views OnAppearing method
        public void Init()
        {
            //Check if Server Address has been set.  If not, show modal window to ask user to set the Server Address
            if (!Settings.IsServerAddressSet)
            {
                this.routingService.NavigateTo("///setup");
            }
            else
            {
                this.routingService.NavigateTo("///main");
            }
        }
    }
}
