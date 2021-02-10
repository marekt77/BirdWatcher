using System.ComponentModel.DataAnnotations;

namespace BirdWatcherWeb.Models
{
    public class BirdLogBird
    {
        [Key]
        public long BirdID { get; set; }
        public Bird Bird { get; set; }

        [Key]
        public long BirdLogID { get; set; }
        public BirdLog BirdLog { get; set; }
    }
}
