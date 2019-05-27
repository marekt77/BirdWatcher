using System;
using System.Collections.Generic;

namespace BirdWatcherBackend.Models
{
    public class BirdLog
    {
        public long BirdLogID { get; set; }
        public DateTime Timestamp { get; set; }
        public float Temperature { get; set; }
        public string Picture { get; set; }
        public List<Bird> Birds { get; set; }
    }
}
