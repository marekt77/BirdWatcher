namespace WeatherStationApp.Models
{
    public class RootModel<T>
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public string firstPage { get; set; }
        public string lastPage { get; set; }
        public int totalPages { get; set; }
        public int totalRecords { get; set; }
        public string nextPage { get; set; }
        public string previousPage { get; set; }
        public List<T> data { get; set; }
        public bool succeeded { get; set; }
        public string errors { get; set; }
        public string message { get; set; }
    }
}
