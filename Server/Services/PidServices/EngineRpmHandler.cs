using Microsoft.Extensions.Logging;
using Prometheus;
using RemoteCarDiagz.Shared.Domain;
using RemoteCarDiagz.Shared.Requests;

namespace RemoteCarDiagz.Server.Services.PidServices
{
    public class EngineRpmHandler : MeasurementHandler
    {
        private static readonly Gauge Rpm = Metrics.CreateGauge(nameof(PidIds.PID_ENGINE_RPM), "RPM");
        private ILogger<EngineRpmHandler> _logger;

        public EngineRpmHandler(ILogger<EngineRpmHandler> logger)
        {
            _logger = logger;
        }

        public override void Handle(SendMeaurementsRequest request)
        {
            
            if (request.PIDCode == PidIds.PID_ENGINE_RPM)
            {
                _logger.LogInformation("EngineRpm handler");
                var rpm = (256 * request.A + request.B) / 4;
                Rpm.Set(rpm);
                return;
            }
            base.Handle(request);
        }
    }
}
