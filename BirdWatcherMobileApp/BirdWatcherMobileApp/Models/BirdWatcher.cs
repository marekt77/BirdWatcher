using Newtonsoft.Json;
using System;

namespace BirdWatcherMobileApp.Models
{
    public class BirdWatcher
    {
        public string applicationName { get; set; }
        public DateTime requestDateTime { get; set; }
        public string welcomeMessage { get; set; }
        public string appVersion { get; set; }

        /*
        [JsonProperty(Required = Newtonsoft.Json.Required.AllowNull)]
        public string errorMessage { get; set; }*/
    }
}
