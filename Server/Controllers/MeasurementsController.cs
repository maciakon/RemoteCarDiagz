using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using RemoteCarDiagz.Server.Services;
using RemoteCarDiagz.Shared.Requests;

namespace RemoteCarDiagz.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeasurementsController : ControllerBase
    {
        private readonly IMeasurementService _measurementsService;

        public MeasurementsController(IMeasurementService measurementsService)
        {
            _measurementsService = measurementsService;
        }

        [HttpPost]
        public IActionResult Upload([FromBody] SendMeaurementsRequest request)
        {
            var locationUri = HttpContext.Request.GetDisplayUrl();
            _measurementsService.ProcessMeasurement(request);
            return Created(locationUri, Ok());
        }
    }
}
