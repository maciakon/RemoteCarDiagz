using Prometheus;
using RemoteCarDiagz.Shared.Domain;
using RemoteCarDiagz.Shared.Requests;

namespace RemoteCarDiagz.Server.Services.PidServices
{
    public class FuelPressureHandler : MeasurementHandler
    {
        private static readonly Gauge FuelPressure = Metrics.CreateGauge(nameof(PidIds.PID_FUEL_PRESSURE), "Fuel pressure [kPa]");
        public override void Handle(SendMeaurementsRequest request)
        {
            if(request.PIDCode == PidIds.PID_FUEL_PRESSURE)
            {
                var engineLoad = 3 * request.A;
                FuelPressure.Set(engineLoad);
                return;
            }
            base.Handle(request);
        }
    }
}
