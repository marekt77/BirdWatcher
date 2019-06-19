using BirdWatcherBackend.Models;
using System.Collections.Generic;

namespace BirdWatcherBackend.ViewModels
{
    public class devTempLightVM
    {
        public PagingHeader PagingHeader { get; set; }
        public List<devTempLight> Items { get; set; }
    }
}
