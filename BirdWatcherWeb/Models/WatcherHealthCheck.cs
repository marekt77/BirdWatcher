using System;

namespace BirdWatcherWeb.Models
{
    public class WatcherHealthCheck
    {
        public long Id { get; set; }
        public string Hostname { get; set; }
        public string IP { get; set; }
        public float CPU_Temp { get; set; }
        public float GPU_Temp { get; set; }
        public long Disk_Total { get; set; }
        public long Disk_Used { get; set; }
        public long Disk_Free { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
