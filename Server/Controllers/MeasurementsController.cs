using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RemoteCarDiagz.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeasurementsController : ControllerBase
    {
        private readonly ILogger<MeasurementsController> _logger;

        public MeasurementsController(ILogger<MeasurementsController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Upload([FromBody] byte value)
        {
            var locationUri = HttpContext.Request.GetDisplayUrl();
            return Created(locationUri, Ok());
        }
    }
}
