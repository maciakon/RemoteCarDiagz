using Prometheus;
using RemoteCarDiagz.Shared.Domain;
using RemoteCarDiagz.Shared.Requests;

namespace RemoteCarDiagz.Server.Services.PidServices
{
    public class IntakeAirTemperatureHandler : MeasurementHandler
    {
        private static readonly Gauge IntakeAirTemp = Metrics.CreateGauge(nameof(PidIds.PID_INTAKE_TEMP), "Intake air temperature [C]");
        
        public override void Handle(SendMeaurementsRequest request)
        {
            if (request.PIDCode == PidIds.PID_INTAKE_TEMP)
            {
                var intakeAirTemp = request.A - 40;
                IntakeAirTemp.Set(intakeAirTemp);
                return;
            }
            base.Handle(request);
        }
    }
}
