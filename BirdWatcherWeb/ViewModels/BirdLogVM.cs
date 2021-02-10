using System;
using System.Collections.Generic;

namespace BirdWatcherWeb.ViewModels
{
    public class PagedBirdLogVM
    {
        public PagingHeader PagingHeader { get; set; }
        public List<BirdLogVM> Items { get; set; }
    }
    public class BirdLogVM
    {
        public long BirdLogID { get; set; }
        public DateTime Timestamp { get; set; }
        public float Temperature { get; set; }
        public float Location_latitude { get; set; }
        public float location_longitude { get; set; }
        public string UserGUID { get; set; }
        public string Picture { get; set; }
        public List<long> Birds { get; set; }
    }
}
