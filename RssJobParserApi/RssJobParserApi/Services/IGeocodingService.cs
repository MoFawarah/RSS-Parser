namespace RssJobParserApi.Services
{
    public interface IGeocodingService
    {
        Task<(double? lat, double? lng)> getCoordinates(string location);
    }
}
