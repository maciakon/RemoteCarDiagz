using Microsoft.Extensions.Logging;
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
        private readonly IMeasurementHandler _engineRpmHandler;
        private readonly ILoggerFactory _loggerFactory;

        public MeasurementService(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
            _engineRpmHandler = new EngineRpmHandler(_loggerFactory.CreateLogger<EngineRpmHandler>());
            _engineRpmHandler
                .SetNext(new CoolantTemperatureHandler(_loggerFactory.CreateLogger<CoolantTemperatureHandler>()))
                .SetNext(new EngineLoadHandler(_loggerFactory.CreateLogger<EngineLoadHandler>()))
                .SetNext(new FuelPressureHandler(_loggerFactory.CreateLogger<FuelPressureHandler>()))
                .SetNext(new IntakeAirTemperatureHandler(_loggerFactory.CreateLogger<IntakeAirTemperatureHandler>()))
                .SetNext(new IntakeManifoldAbsolutePressureHandler(_loggerFactory.CreateLogger<IntakeManifoldAbsolutePressureHandler>()))
                .SetNext(new MafAirFlowRateHandler(_loggerFactory.CreateLogger<MafAirFlowRateHandler>()))
                .SetNext(new ThrottlePosition(_loggerFactory.CreateLogger<ThrottlePosition>()))
                .SetNext(new VehicleSpeedHandler(_loggerFactory.CreateLogger<VehicleSpeedHandler>()));
        }

        public void ProcessMeasurement(SendMeaurementsRequest request)
        {
            _engineRpmHandler.Handle(request);
        }
    }
}
