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
        private readonly IMeasurementHandler _firstHandler = new EngineRpmHandler();

        public MeasurementService()
        {
            var coolantTemperatureHandler = new CoolantTemperatureHandler();
            _firstHandler.SetNext(coolantTemperatureHandler);
        }

        public void ProcessMeasurement(SendMeaurementsRequest request)
        {
            _firstHandler.Handle(request);
        }
    }
}
