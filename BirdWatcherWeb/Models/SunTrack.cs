using System;

namespace BirdWatcherWeb.Models
{
    public class SunTrack
    {
        public long Id { get; set; }
        public float Temperature { get; set; }
        public float PhotoresistorValue { get; set; }
        public DateTime Timestamp { get; set; }
        public string Type { get; set; }
    }
}
