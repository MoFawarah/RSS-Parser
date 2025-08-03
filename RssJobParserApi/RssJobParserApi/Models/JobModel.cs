namespace RssJobParserApi.Models
{
    public class JobModel
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Location { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
