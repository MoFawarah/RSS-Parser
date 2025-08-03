using System.Globalization;
using System.Xml.Linq;
using RssJobParserApi.Models;
using static System.Net.WebRequestMethods;

namespace RssJobParserApi.Services
{
    public class RssService : IRssService
    {
        private readonly HttpClient _httpClient;
        private readonly IGeocodingService _geo;

        public RssService(HttpClient httpClient, IGeocodingService geo)
        {
            _httpClient = httpClient;
            _geo = geo;
        }
        public async Task<List<JobModel>> getJobs()
        {

            var url = "https://careers.moveoneinc.com/rss/all-rss.xml/";
            var response = await _httpClient.GetStringAsync(url);

            var xml = XDocument.Parse(response);
            var items = xml.Descendants("item");

            var jobs = new List<JobModel>();

            foreach (var item in items)
            {
                var title = item.Element("title")?.Value;
                var link = item.Element("link")?.Value;
                var country = item.Element("country")?.Value;
                var posted = item.Element("posted_date")?.Value;

                DateTime.TryParseExact(posted, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var postedDate);

                var coords = await _geo.getCoordinates(country);

                jobs.Add(new JobModel
                {
                    Title = title,
                    Link = link,
                    Location = country,
                    PostedDate = postedDate,
                    Latitude = coords.lat,
                    Longitude = coords.lng
                });
            }

            return jobs;

        }
    }
}
