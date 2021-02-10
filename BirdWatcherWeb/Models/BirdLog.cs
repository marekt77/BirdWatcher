using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BirdWatcherWeb.Models
{
    public class BirdLog
    {
        [Key]
        public long BirdLogID { get; set; }
        public DateTime Timestamp { get; set; }
        public float Temperature { get; set; }
        public float Location_latitude { get; set; }
        public float location_longitude { get; set; }
        public string UserGUID { get; set; }
        public string Picture { get; set; }
        public ICollection<BirdLogBird> BirdLogBird { get; set; }
    }
}
