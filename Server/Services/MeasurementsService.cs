using RemoteCarDiagz.Server.Services.PidServices;
using RemoteCarDiagz.Shared.Requests;

namespace RemoteCarDiagz.Server.Services
{
    public interface IMeasurementService
    {
        void ProcessMeasurement(SendMeaurementsRequest request);
    }

    public class MeasurementService : IMeasurementService
    {
        private readonly IMeasurementHandler _engineRpmHandler = new EngineRpmHandler();
        public MeasurementService()
        {
            _engineRpmHandler
                .SetNext(new CoolantTemperatureHandler())
                .SetNext(new EngineLoadHandler())
                .SetNext(new EngineRpmHandler())
                .SetNext(new FuelPressureHandler())
                .SetNext(new IntakeAirTemperatureHandler())
                .SetNext(new IntakeManifoldAbsolutePressureHandler())
                .SetNext(new MafAirFlowRateHandler())
                .SetNext(new ThrottlePosition())
                .SetNext(new VehicleSpeedHandler());
        }

        public void ProcessMeasurement(SendMeaurementsRequest request)
        {
            _engineRpmHandler.Handle(request);
        }
    }
}
