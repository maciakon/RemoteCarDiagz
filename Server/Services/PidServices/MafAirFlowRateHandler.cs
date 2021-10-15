using Prometheus;
using RemoteCarDiagz.Shared.Domain;
using RemoteCarDiagz.Shared.Requests;

namespace RemoteCarDiagz.Server.Services.PidServices
{
    public class MafAirFlowRateHandler : MeasurementHandler
    {
        private static readonly Gauge MafAirFlowRate = Metrics.CreateGauge(nameof(PidIds.PID_MAF_FLOW), "Mass air flow sensor air flow rate [grams/sec]");
        
        public override void Handle(SendMeaurementsRequest request)
        {
            if (request.PIDCode == PidIds.PID_MAF_FLOW)
            {
                var mafAirFlowRate = (256 * request.A + request.B) / 100;
                MafAirFlowRate.Set(mafAirFlowRate);
                return;
            }
            base.Handle(request);
        }
    }
}
