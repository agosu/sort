using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SortAPI.Services;
using System.Collections;
using System.Diagnostics;

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
            //TODO: In a more complex solution it would be logical to
            //make sorting an async task and immediately return status
            //(that posting was successful or not). Sorting status storing
            //and retrieving also would be needed for user information.
            _logger.LogInformation("A new set of numbers posted for sorting.");
            if (sortRequest.Length != 0)
            {
                var watch = Stopwatch.StartNew();
                ArrayList sortedNumbers = _sortService.Sort(new ArrayList(sortRequest));
                watch.Stop();
                var performance = watch.ElapsedMilliseconds;
                _storageService.StoreNewResult(sortedNumbers);
                _storageService.StorePerformance(performance);
                return Ok("Array is sorted and saved, to retrieve it, call GET endpoint. Call GET /performance to see the latest sorting performance.");
            }

            return BadRequest("Array cannot be empty.");
        }

        [HttpGet]
        public ArrayList GetLatestResult()
        {
            _logger.LogInformation("Latest sorting result is being retrieved.");
            return _storageService.GetLatestResult();
        }

        [HttpGet("performance")]
        public long GetLatestPerformance()
        {
            _logger.LogInformation("Latest sorting performance is being retrieved.");
            return _storageService.GetLatestPerformance();
        }
    }
}
