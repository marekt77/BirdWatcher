using System;
using System.Collections.Generic;
using System.Text;

namespace BirdWatcherMobileApp.Models
{
    public class PagingHeader
    {
        public int totalItems { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public int totalPages { get; set; }
    }
}
