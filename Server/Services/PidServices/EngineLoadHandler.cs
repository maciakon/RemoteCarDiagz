using Prometheus;
using RemoteCarDiagz.Shared.Domain;
using RemoteCarDiagz.Shared.Requests;

namespace RemoteCarDiagz.Server.Services.PidServices
{
    public class EngineLoadHandler : MeasurementHandler
    {
        private static readonly Gauge EngineLoad = Metrics.CreateGauge(nameof(PidIds.PID_ABSOLUTE_ENGINE_LOAD), "Engine load [%]");
        public override void Handle(SendMeaurementsRequest request)
        {
            if(request.PIDCode == PidIds.PID_ABSOLUTE_ENGINE_LOAD)
            {
                var engineLoad = (100 * request.A) / 255;
                EngineLoad.Set(engineLoad);
                return;
            }
            base.Handle(request);
        }
    }
}
