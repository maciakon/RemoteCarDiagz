using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RemoteCarDiagz.Server.Services;
using RemoteCarDiagz.Shared.Requests;

namespace RemoteCarDiagz.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProvisioningController : ControllerBase
    {
        private readonly IProvisioningService _provisioningService;

        public ProvisioningController(IProvisioningService provisioningService)
        {
            _provisioningService = provisioningService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProvisioning()
        {
            var grafanaConfiguration = await _provisioningService.GetGrafanaConfiguration();
            return Ok(grafanaConfiguration);
        }

        [HttpPost]
        public async Task<IActionResult> SetActiveMeasurement([FromBody] ProvisioningRequest request)
        {
            await _provisioningService.SetGrafanaConfiguration(request.GrafanaPublicDashBoardUid);
            return Ok();
        }
    }
}