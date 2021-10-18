using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RemoteCarDiagz.Server.Services;
using RemoteCarDiagz.Shared.Requests;

namespace RemoteCarDiagz.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfigurationService _configurationService;

        public ConfigurationController(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetActiveMeasurements()
        {
            var activeMeasurements = await _configurationService.GetActiveMeasurements();
            return Ok(activeMeasurements);
        }

        [HttpPost]
        public async Task<IActionResult> SetActiveMeasurements([FromBody] SetActiveMeasurementsRequest request)
        {
            if(await _configurationService.SetActiveMeasurements(request))
            {
                return Ok();
            }
            return NotFound(request.PidIds);
        }
    }
}