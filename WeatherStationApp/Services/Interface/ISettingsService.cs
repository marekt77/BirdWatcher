namespace WeatherStationApp.Services.Interface
{
    public interface ISettingsService
    {
        string ServerIP { get; set; }
        bool UseImperial { get; set; }
    }
}
