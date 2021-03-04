using System;

namespace BirdWatcherMobileApp.Models
{
    public class BirdWatcher
    {
        public string applicationName { get; set; }
        public DateTime requestDateTime { get; set; }
        public string welcomeMessage { get; set; }
        public string appVersion { get; set; }
        public string errorMessage { get; set; }
    }
}
