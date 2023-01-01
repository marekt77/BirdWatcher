using BirdWatcherWeb.Filter;
using System;

namespace BirdWatcherWeb.Services.Interface
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
