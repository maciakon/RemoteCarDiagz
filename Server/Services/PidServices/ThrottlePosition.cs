using Prometheus;
using RemoteCarDiagz.Shared.Domain;
using RemoteCarDiagz.Shared.Requests;

namespace RemoteCarDiagz.Server.Services.PidServices
{
    public class ThrottlePosition : MeasurementHandler
    {
        private static readonly Gauge Metric = Metrics.CreateGauge(nameof(PidIds.PID_THROTTLE), "Throttle position [%]");
        
        public override void Handle(SendMeaurementsRequest request)
        {
            if (request.PIDCode == PidIds.PID_THROTTLE)
            {
                var value = (100 * request.A) / 255;
                Metric.Set(value);
                return;
            }
            base.Handle(request);
        }
    }
}
