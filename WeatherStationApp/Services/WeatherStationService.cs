using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherStationApp.Models;
using WeatherStationApp.Services.Interface;

namespace WeatherStationApp.Services
{
    public interface WeatherStationService : IWeatherStationService
    {
        private Uri _uri = new Uri("http://" + "192.168.1.20" + "/api/suntrack");

        public async Task<SunTrack> GetSunTrackInfo()
        {
            HttpClient _client = new HttpClient();
            SunTrack sunTrack = new SunTrack();

            try
            {
                var response = await _client.GetAsync(_uri);

                HttpResponseMessage httpResponse = new HttpResponseMessage();


            }
            catch (Exception ex)
            {
                _client.Dispose();
                throw new Exception("ERROR! Cannot retrive Movie Data");
            }

            return sunTrack;
        }
    }
}
