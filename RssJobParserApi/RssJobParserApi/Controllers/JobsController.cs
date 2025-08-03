using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RssJobParserApi.Models;
using RssJobParserApi.Services;

namespace RssJobParserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IRssService _rssService;

        public JobsController(IRssService rssService)
        {
            this._rssService = rssService;
        }

        [HttpGet]
        public async Task<IActionResult> getAllJobs()
        {
            var jobs = await _rssService.getJobs();

            return Ok(jobs);    
        }
    }
}
