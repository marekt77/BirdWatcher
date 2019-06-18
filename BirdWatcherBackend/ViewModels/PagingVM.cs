using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BirdWatcherBackend.ViewModels
{ 
    public class PageLink
    {
        public string Href { get; set; }
        public string Relation { get; set; }
        public string Method { get; set; }
    }

    public class PagingHeader
    {
        public PagingHeader(
            int totalItems,
            int pageNumber,
            int pageSize,
            int totalPages)
        {
            this.TotalItems = totalItems;
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.TotalPages = totalPages;
        }

        public int TotalItems { get; }
        public int PageNumber { get; }
        public int PageSize { get; }
        public int TotalPages { get; }

        public string ToJson() => JsonConvert.SerializeObject(this, new JsonSerializerSettings {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        });
    }
}
