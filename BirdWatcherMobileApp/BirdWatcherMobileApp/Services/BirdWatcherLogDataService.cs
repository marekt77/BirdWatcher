using BirdWatcherMobileApp.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BirdWatcherMobileApp.Services
{
    public class BirdWatcherLogDataService : IBirdWatcherLogService<BirdLogRootObject, BirdLog>
    {

        public async Task<BirdLog> GetBirdLogAsync(long id)
        {
            BirdLog _birdLog = null;

            HttpClient _client = new HttpClient();

            var uri = new Uri("http://" + Settings.ServerAddress + "/api/BirdLogs/" + id.ToString());

            try
            {
                var response = await _client.GetAsync(uri);

                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    _birdLog = JsonConvert.DeserializeObject<BirdLog>(content);
                }
            }
            catch(Exception ex)
            {
                //Add Logging...
            }

            return _birdLog;
        }

        public async Task<BirdLogRootObject> GetBirdLogsAsync()
        {
            BirdLogRootObject _rootObject = null;

            HttpClient _client = new HttpClient();

            var uri = new Uri("http://" + Settings.ServerAddress + "/api/BirdLogs/");

            try
            {
                var response = await _client.GetAsync(uri);

                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    _rootObject = JsonConvert.DeserializeObject<BirdLogRootObject>(content);
                }
            }
            catch(Exception ex)
            {

            }

            return _rootObject;
        }

        public async Task<BirdLogRootObject> GetBirdLogsAsync(int page)
        {
            BirdLogRootObject _rootObject = null;

            HttpClient _client = new HttpClient();

            var uri = new Uri("http://" + Settings.ServerAddress + "/api/BirdLogs/?page=" + page.ToString());

            try
            {
                var response = await _client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    _rootObject = JsonConvert.DeserializeObject<BirdLogRootObject>(content);
                }
            }
            catch (Exception ex)
            {

            }

            return _rootObject;
        }
    }
}
