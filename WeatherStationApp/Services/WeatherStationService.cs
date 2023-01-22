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
        private readonly HttpClient _client;
        private readonly Uri _uri = new Uri("http://" + +  "/api/");

        public async Task<SunTrack> GetSunTrackInfo()
        {
            try
            {
                var response = await _client.GetAsync(_uri);
            }
        }
    }
}
