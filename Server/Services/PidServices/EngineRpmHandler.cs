using Prometheus;
using RemoteCarDiagz.Shared.Domain;
using RemoteCarDiagz.Shared.Requests;

namespace RemoteCarDiagz.Server.Services.PidServices
{
    public class EngineRpmHandler : MeasurementHandler
    {
        private static readonly Gauge Rpm = Metrics.CreateGauge(nameof(PidIds.PID_ENGINE_RPM), "RPM");
        
        public override void Handle(SendMeaurementsRequest request)
        {
            if (request.PIDCode == PidIds.PID_ENGINE_RPM)
            {
                var rpm = (256 * request.A + request.B) / 4;
                Rpm.Set(rpm);
                return;
            }
            base.Handle(request);
        }
    }
}
