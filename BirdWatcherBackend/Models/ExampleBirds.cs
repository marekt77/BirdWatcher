using System.Collections.Generic;

namespace BirdWatcherBackend.Models
{
    public class ExampleBird
    {
        public string name { get; set; }
        public string image { get; set; }
    }

    public class ExampleBirds
    {
        public List<ExampleBird> birds { get; set; }
    }
}
