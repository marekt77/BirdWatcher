using System;
using System.Collections.Generic;
using System.Text;

namespace BirdWatcherApp.Models
{
    public class BirdLog
    {
        public long BirdLogID { get; set; }
        public DateTime Timestamp { get; set; }
        public float Temperature { get; set; }
        public float Location_latitude { get; set; }
        public float location_longitude { get; set; }
        public string UserGUID { get; set; }
        public string Picture { get; set; }
    }
}
