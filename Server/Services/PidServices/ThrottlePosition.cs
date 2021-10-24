using Microsoft.Extensions.Logging;
using Prometheus;
using RemoteCarDiagz.Shared.Domain;
using RemoteCarDiagz.Shared.Requests;

namespace RemoteCarDiagz.Server.Services.PidServices
{
    public class ThrottlePosition : MeasurementHandler
    {
        private static readonly Gauge Metric = Metrics.CreateGauge(nameof(PidIds.PID_THROTTLE), "Throttle position [%]");
        private ILogger<ThrottlePosition> _logger;

        public ThrottlePosition(ILogger<ThrottlePosition> logger)
        {
            _logger = logger;
        }

        public override void Handle(SendMeaurementsRequest request)
        {
            if (request.PIDCode == PidIds.PID_THROTTLE)
            {
                _logger.LogInformation("Throttle position handler");
                var value = (100 * request.A) / 255;
                Metric.Set(value);
                return;
            }
            base.Handle(request);
        }
    }
}
