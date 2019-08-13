using System;
using System.Collections.Generic;
using System.Text;

namespace BirdWatcherMobileApp.Models
{
    public class BirdLog
    {
        public int birdLogID { get; set; }
        public DateTime timestamp { get; set; }
        public double temperature { get; set; }
        public double location_latitude { get; set; }
        public double location_longitude { get; set; }
        public string userGUID { get; set; }
        public string picture { get; set; }
        public List<int> birds { get; set; }
    }
}
