using System.Collections.Generic;

namespace BirdWatcherMobileApp.Models
{
    public class Bird
    {
        public long BirdID { get; set; }
        public string Name { get; set; }
        public string examplePicture { get; set; }
    }

    public class RootObject
    {
        public List<Bird> Birds { get; set; }
    }
}
