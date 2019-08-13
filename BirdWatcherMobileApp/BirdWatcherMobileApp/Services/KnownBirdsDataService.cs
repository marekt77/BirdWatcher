using BirdWatcherMobileApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BirdWatcherMobileApp.Services
{
    public class KnownBirdsDataService : IKnownBirdsService<Bird>
    {
        public async Task<Bird> GetKnownBirdAsync(long id)
        {
            Bird _bird = null;

            HttpClient _client = new HttpClient();

            var uri = new Uri("http://" + Settings.ServerAddress + "/api/Birds/" + id.ToString());

            try
            {
                var response = await _client.GetAsync(uri);

                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    _bird = JsonConvert.DeserializeObject<Bird>(content);
                }
            }
            catch(Exception ex)
            {

            }

            return _bird;
        }

        public async Task<IEnumerable<Bird>> GetKnownBirdsAsync()
        {
            List<Bird> _knownBirds = null;

            HttpClient _client = new HttpClient();

            var uri = new Uri("http://" + Settings.ServerAddress + "/api/Birds/");

            try
            {
                var response = await _client.GetAsync(uri);

                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    _knownBirds = JsonConvert.DeserializeObject<List<Bird>>(content);
                }
            }
            catch(Exception ex)
            {

            }

            return _knownBirds;
        }
    }
}
