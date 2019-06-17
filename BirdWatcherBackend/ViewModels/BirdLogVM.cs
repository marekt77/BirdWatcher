﻿using BirdWatcherBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirdWatcherBackend.ViewModels
{
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