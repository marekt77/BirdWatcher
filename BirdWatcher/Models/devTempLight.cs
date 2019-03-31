using System;

namespace BirdWatcherBackend.Models
{
    public class devTempLight
    {
        public long Id { get; set; }
        public int Temperature { get; set; }
        public int PhotoresistorValue { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
