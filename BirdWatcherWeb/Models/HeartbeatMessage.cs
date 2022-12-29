using System;

namespace BirdWatcherWeb.Models
{
    public class HeartbeatMessage
    {
        public string ApplicationName { get; set; }
        public DateTime RequestDateTime { get; set; }
        public string WelcomeMessage { get; set; }
        public string AppVersion { get; set; }
    }
}
