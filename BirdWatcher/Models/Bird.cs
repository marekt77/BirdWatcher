using System;

namespace BirdWatcherBackend.Models
{
    public class Bird
    {
        public long Id { get; set; }
        public string BirdType { get; set; }
        public string ImageFile { get; set; }
    }
}
