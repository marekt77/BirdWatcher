using System;

namespace BirdWatcherBackend.Models
{
    public class BirdLog
    {
        public long BirdLogId { get; set; }
        public DateTime Timestamp { get; set; }
        public float Temperature { get; set; }
        public Bird Bird { get; set; }
    }
}
