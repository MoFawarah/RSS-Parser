using System.Net.Http;
using System.Text.Json;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using RssJobParserApi.Services;

public class GeocodingService : IGeocodingService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly IMemoryCache _cache;

    public GeocodingService(HttpClient httpClient, IConfiguration config, IMemoryCache cache)
    {
        _httpClient = httpClient;
        _apiKey = config["GoogleMaps:ApiKey"];
        _cache = cache;

    }

    public async Task<(double? lat, double? lng)> getCoordinates(string location)
    {
        if (string.IsNullOrWhiteSpace(location)) return (null, null);

        var url = $"https://maps.googleapis.com/maps/api/geocode/json?address={Uri.EscapeDataString(location)}&key={_apiKey}";
        var response = await _httpClient.GetStringAsync(url);

        var json = JsonDocument.Parse(response);
        var results = json.RootElement.GetProperty("results");

        if (results.GetArrayLength() == 0)
            return (null, null);

        var loc = results[0].GetProperty("geometry").GetProperty("location");
        var coordinates = (lat: loc.GetProperty("lat").GetDouble(), lng: loc.GetProperty("lng").GetDouble());

        // Cache for 1 hour (adjust as needed)
        var cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromHours(1));

        _cache.Set(location, coordinates, cacheEntryOptions);

        return coordinates;
    }
}
