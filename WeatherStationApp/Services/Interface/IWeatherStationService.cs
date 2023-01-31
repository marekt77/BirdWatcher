using WeatherStationApp.Models;

namespace WeatherStationApp.Services.Interface
{
    public interface IWeatherStationService
    {
        Task<RootModel<SunTrack>> GetSunTrackInfo();
        Task<Heartbeat> GetHeartbeat(string testIP);
    }
}
