namespace WeatherStationApp.Models
{
    public class RootModel<T>
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public string firstPage { get; set; } = string.Empty;
        public string lastPage { get; set; } = string.Empty;
        public int totalPages { get; set; }
        public int totalRecords { get; set; }
        public string nextPage { get; set; } = string.Empty;
        public string previousPage { get; set; } = string.Empty;
        public List<T> data { get; set; }
        public bool succeeded { get; set; }
        public string errors { get; set; } = string.Empty;
        public string message { get; set; } = string.Empty;
    }
}
