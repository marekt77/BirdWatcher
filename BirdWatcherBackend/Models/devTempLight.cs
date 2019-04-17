using System;

namespace BirdWatcherBackend.Models
{
    public class devTempLight
    {
        public long Id { get; set; }
        public float Temperature { get; set; }
        public float PhotoresistorValue { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
