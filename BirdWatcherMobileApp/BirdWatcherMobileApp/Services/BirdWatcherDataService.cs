using BirdWatcherMobileApp.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BirdWatcherMobileApp.Services
{
    public class BirdWatcherDataService : IBirdWatcherService<BirdWatcher>
    {
        public async Task<BirdWatcher> GetServerInfo()
        {
            BirdWatcher _birdWatcher = null;

            HttpClient _client = new HttpClient();

            var uri = new Uri("http://" + Settings.ServerAddress + "/api/heartbeat");

            try
            {
                var response = await _client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    _birdWatcher = JsonConvert.DeserializeObject<BirdWatcher>(content);
                }
            }
            catch(Exception ex)
            {
                _birdWatcher = new BirdWatcher();
                //_birdWatcher.errorMessage = ex.Message;
            }

            return _birdWatcher;
        }

        public async Task<BirdWatcher> GetServerInfo(string ServerAddress)
        {
            BirdWatcher _birdWatcher = null;

            HttpClient _client = new HttpClient();

            var uri = new Uri("http://" + ServerAddress + "/api/heartbeat");

            try
            {
                var response = await _client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    _birdWatcher = JsonConvert.DeserializeObject<BirdWatcher>(content);
                }
            }
            catch (Exception ex)
            {
                _birdWatcher = new BirdWatcher();
                //_birdWatcher.errorMessage = ex.Message;
            }

            return _birdWatcher;
        }
    }
}
