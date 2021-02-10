using System.Collections.Generic;

namespace BirdWatcherWeb.Models
{
    public class ExampleBird
    {
        public string name { get; set; }
        public string displayname { get; set; }
        public string image { get; set; }
    }

    public class ExampleBirds
    {
        public List<ExampleBird> birds { get; set; }
    }
}
