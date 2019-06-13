using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BirdWatcherBackend.Models
{
    public class Bird
    {
        [Key]
        public long BirdID { get; set; }
        public string Name { get; set; }
        public string ExamplePicture { get; set; }
        public ICollection<BirdLogBird> BirdLogBird { get; set; }
    }
}
