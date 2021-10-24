using Microsoft.Extensions.Logging;
using Prometheus;
using RemoteCarDiagz.Shared.Domain;
using RemoteCarDiagz.Shared.Requests;

namespace RemoteCarDiagz.Server.Services.PidServices
{
    public class FuelPressureHandler : MeasurementHandler
    {
        private static readonly Gauge FuelPressure = Metrics.CreateGauge(nameof(PidIds.PID_FUEL_PRESSURE), "Fuel pressure [kPa]");
        private ILogger<FuelPressureHandler> _logger;

        public FuelPressureHandler(ILogger<FuelPressureHandler> logger)
        {
            _logger = logger;
        }

        public override void Handle(SendMeaurementsRequest request)
        {
            if(request.PIDCode == PidIds.PID_FUEL_PRESSURE)
            {
                _logger.LogInformation("Handling fuel pressure handler");
                var engineLoad = 3 * request.A;
                FuelPressure.Set(engineLoad);
                return;
            }
            base.Handle(request);
        }
    }
}
