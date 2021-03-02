using System.Threading.Tasks;

namespace BirdWatcherMobileApp.Services.Routing
{
    interface IRoutingService
    {
        Task GoBack();
        Task GoBackModal();
        Task NavigateTo(string route);
    }
}
