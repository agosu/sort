using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Sort.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SortingController : ControllerBase
    {
        private readonly ILogger<SortingController> _logger;

        public SortingController(ILogger<SortingController> logger)
        {
            _logger = logger;
        }
    }
}
