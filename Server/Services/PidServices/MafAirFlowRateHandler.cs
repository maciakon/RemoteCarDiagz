using Microsoft.Extensions.Logging;
using Prometheus;
using RemoteCarDiagz.Shared.Domain;
using RemoteCarDiagz.Shared.Requests;

namespace RemoteCarDiagz.Server.Services.PidServices
{
    public class MafAirFlowRateHandler : MeasurementHandler
    {
        private static readonly Gauge MafAirFlowRate = Metrics.CreateGauge(nameof(PidIds.PID_MAF_FLOW), "Mass air flow sensor air flow rate [grams/sec]");
        private ILogger<MafAirFlowRateHandler> _logger;

        public MafAirFlowRateHandler(ILogger<MafAirFlowRateHandler> logger)
        {
            _logger = logger;
        }

        public override void Handle(SendMeaurementsRequest request)
        {
            if (request.PIDCode == PidIds.PID_MAF_FLOW)
            {
                _logger.LogInformation("MafAirFlowRate hanlder");
                var mafAirFlowRate = (256 * request.A + request.B) / 100;
                MafAirFlowRate.Set(mafAirFlowRate);
                return;
            }
            base.Handle(request);
        }
    }
}
