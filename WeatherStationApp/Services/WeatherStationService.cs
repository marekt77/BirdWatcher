using Newtonsoft.Json;
using WeatherStationApp.Models;
using WeatherStationApp.Services.Interface;

namespace WeatherStationApp.Services
{
    public sealed class WeatherStationService : IWeatherStationService
    {
        private Uri _baseUri;
        private readonly ISettingsService _settingService;

        public WeatherStationService(ISettingsService settingsService)
        {
            _settingService = settingsService;
            _baseUri = new Uri("http://" + _settingService.ServerIP);
        }

        public async Task<RootModel<SunTrack>> GetSunTrackInfo()
        {
            HttpClient _client = new HttpClient();
            RootModel<SunTrack> sunTrack = new RootModel<SunTrack>();

            HttpResponseMessage httpResponse = new HttpResponseMessage();

            try
            {
                httpResponse = await _client.GetAsync(_baseUri + "api/suntrack");

                if (httpResponse.IsSuccessStatusCode)
                {
                    string rawResult = await httpResponse.Content.ReadAsStringAsync();

                    sunTrack = JsonConvert.DeserializeObject<RootModel<SunTrack>>(rawResult);
                }

            }
            catch (Exception ex)
            {
                _client.Dispose();
                throw new Exception("ERROR! Cannot retrive Sun Track Data");
            }

            return sunTrack;
        }

        public async Task<Heartbeat> GetHeartbeat(string testIP)
        {
            HttpClient _client = new HttpClient();

            HttpResponseMessage httpResponse = new HttpResponseMessage();

            Heartbeat heartBeat = new Heartbeat();

            if (!string.IsNullOrEmpty(testIP))
            {
                try
                {
                    httpResponse = await _client.GetAsync("http://" + testIP + "/api/heartbeat");

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        string rawResult = await httpResponse.Content.ReadAsStringAsync();

                        heartBeat = JsonConvert.DeserializeObject<List<Heartbeat>>(rawResult).FirstOrDefault();
                    }

                }
                catch (Exception ex)
                {
                    _client.Dispose();
                    throw new Exception("ERROR! Cannot retrive heartbeat");
                }
            }

            return heartBeat;
        }

        public async Task<TemperatureModel> GetTempReading()
        {
            HttpClient _client = new HttpClient();
            TemperatureModel temp = new TemperatureModel();

            HttpResponseMessage httpResponse = new HttpResponseMessage();

            try
            {
                httpResponse = await _client.GetAsync(_baseUri + "api/weather/temperature");

                if (httpResponse.IsSuccessStatusCode)
                {
                    string rawResult = await httpResponse.Content.ReadAsStringAsync();

                    temp = JsonConvert.DeserializeObject<TemperatureModel>(rawResult);
                }

            }
            catch (Exception ex)
            {
                _client.Dispose();
                throw new Exception("ERROR! Cannot retrive Temperature Data");
            }

            return temp;
        }
    }
}
