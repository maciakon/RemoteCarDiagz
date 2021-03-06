using Microsoft.Extensions.Logging;
using Prometheus;
using RemoteCarDiagz.Shared.Domain;
using RemoteCarDiagz.Shared.Requests;

namespace RemoteCarDiagz.Server.Services.PidServices
{
    public class IntakeManifoldAbsolutePressureHandler : MeasurementHandler
    {
        private static readonly Gauge IntakeManifoldPressure = Metrics.CreateGauge(nameof(PidIds.PID_INTAKE_MAP), "Intake manifold pressure handler [kPa]");
        private ILogger<IntakeManifoldAbsolutePressureHandler> _logger;

        public IntakeManifoldAbsolutePressureHandler(ILogger<IntakeManifoldAbsolutePressureHandler> logger)
        {
            _logger = logger;
        }

        public override void Handle(SendMeaurementsRequest request)
        {
            if(request.PIDCode == PidIds.PID_INTAKE_MAP)
            {
                _logger.LogInformation("IntakeManifoldAbsolutePressure handler");
                var intakeManifoldAbsolutePressure = request.A;
                IntakeManifoldPressure.Set(intakeManifoldAbsolutePressure);
                return;
            }
            base.Handle(request);
        }
    }
}
