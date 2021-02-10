using BirdWatcherWeb.Models;
using System.Collections.Generic;

namespace BirdWatcherWeb.ViewModels
{
    public class SunTrackVM
    {
        public PagingHeader PagingHeader { get; set; }
        public List<SunTrack> Items { get; set; }
    }
}
