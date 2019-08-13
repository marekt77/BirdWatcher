using System.Collections.Generic;

namespace BirdWatcherMobileApp.Models
{
    public class BirdLogRootObject
    {
        public PagingHeader pagingHeader { get; set; }
        public List<BirdLog> items { get; set; }
    }
}
