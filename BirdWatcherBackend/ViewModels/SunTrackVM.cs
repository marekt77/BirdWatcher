using BirdWatcherBackend.Models;
using System.Collections.Generic;

namespace BirdWatcherBackend.ViewModels
{
    public class SunTrackVM
    {
        public PagingHeader PagingHeader { get; set; }
        public List<SunTrack> Items { get; set; }
    }
}
