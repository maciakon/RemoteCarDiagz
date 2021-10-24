using Microsoft.Extensions.Logging;
using Prometheus;
using RemoteCarDiagz.Shared.Domain;
using RemoteCarDiagz.Shared.Requests;

namespace RemoteCarDiagz.Server.Services.PidServices
{
    public class VehicleSpeedHandler : MeasurementHandler
    {
        private static readonly Gauge VehicleSpeed = Metrics.CreateGauge(nameof(PidIds.PID_VEHICLE_SPEED), "Vehicle speed [km/h]");
        private ILogger<VehicleSpeedHandler> _logger;

        public VehicleSpeedHandler(ILogger<VehicleSpeedHandler> logger)
        {
            _logger = logger;
        }

        public override void Handle(SendMeaurementsRequest request)
        {
            if (request.PIDCode == PidIds.PID_VEHICLE_SPEED)
            {
                _logger.LogInformation("Vehicle speed handler");
                var speed = request.A;
                VehicleSpeed.Set(speed);
                return;
            }
            base.Handle(request);
        }
    }
}
