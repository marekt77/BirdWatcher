using Newtonsoft.Json;
using WeatherStationApp.Models;
using WeatherStationApp.Services.Interface;

namespace WeatherStationApp.Services
{
    public sealed class WeatherStationService : IWeatherStationService
    {
        private Uri _uri = new Uri("http://" + "192.168.1.20" + "/api/suntrack");

        public async Task<RootModel<SunTrack>> GetSunTrackInfo()
        {
            HttpClient _client = new HttpClient();
            RootModel<SunTrack> sunTrack = new RootModel<SunTrack>();

            HttpResponseMessage httpResponse = new HttpResponseMessage();
            
            try
            {
                httpResponse = await _client.GetAsync(_uri);

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
    }
}
