using RssJobParserApi.Models;

namespace RssJobParserApi.Services
{
    public interface IRssService
    {
        Task<List<JobModel>> getJobs();
    }
}
