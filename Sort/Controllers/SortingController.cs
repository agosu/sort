using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SortAPI.Services;
using System.Collections;

namespace Sort.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SortingController : ControllerBase
    {
        private readonly ILogger<SortingController> _logger;
        private readonly ISortService _sortService;
        private readonly IStorageService _storageService;

        public SortingController(ILogger<SortingController> logger, ISortService sortService, IStorageService storageService)
        {
            _logger = logger;
            _sortService = sortService;
            _storageService = storageService;
        }

        [HttpPost]
        public IActionResult DoSort([FromBody] long[] sortRequest)
        {
            _logger.LogInformation("A new set of numbers posted for sorting.");
            ArrayList sortedNumbers = _sortService.Sort(new ArrayList(sortRequest));
            _storageService.StoreNewResult(sortedNumbers);
            return Ok();
        }

        [HttpGet]
        public ArrayList GetLatestResult()
        {
            return _storageService.GetLatestResult();
        }
    }
}
