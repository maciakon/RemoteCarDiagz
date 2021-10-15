using Prometheus;
using RemoteCarDiagz.Shared.Domain;
using RemoteCarDiagz.Shared.Requests;

namespace RemoteCarDiagz.Server.Services.PidServices
{
    public class CoolantTemperatureHandler : MeasurementHandler
    {
        private static readonly Gauge _coolantTemp = Metrics.CreateGauge(nameof(PidIds.PID_COOLANT_TEMP), "Coolant temperature [C]");

        public override void Handle(SendMeaurementsRequest request)
        {
            if(request.A == PidIds.PID_COOLANT_TEMP)
            {
                var coolantTemp = request.A - 40;
                _coolantTemp.Set(coolantTemp);
                return;
            }
            base.Handle(request);
        }
    }
}
