using Prometheus;
using RemoteCarDiagz.Shared.Domain;
using RemoteCarDiagz.Shared.Requests;

namespace RemoteCarDiagz.Server.Services.PidServices
{
    public class VehicleSpeedHandler : MeasurementHandler
    {
        private static readonly Gauge VehicleSpeed = Metrics.CreateGauge(nameof(PidIds.PID_VEHICLE_SPEED), "Vehicle speed [km/h]");
        
        public override void Handle(SendMeaurementsRequest request)
        {
            if (request.PIDCode == PidIds.PID_VEHICLE_SPEED)
            {
                var speed = request.A;
                VehicleSpeed.Set(speed);
                return;
            }
            base.Handle(request);
        }
    }
}
