using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirdWatcherWeb.Models
{
    public class SunTrack
    {
        public long Id { get; set; }
        public float Temperature { get; set; }
        public float PhotoresistorValue { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
