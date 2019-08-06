using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirdWatcherBackend.Models
{
    public class BirdWatcher
    {
        public string ApplicationName { get; set; }
        public DateTime RequestDateTime { get; set; }
        public string WelcomeMessage { get; set; }
        public string AppVersion { get; set; }
        public string ServerOS { get; set; }


    }
}
