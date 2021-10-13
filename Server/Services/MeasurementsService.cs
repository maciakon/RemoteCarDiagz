using Prometheus;
using RemoteCarDiagz.Shared.Requests;
using RemoteCarDiagz.Shared.Domain;

namespace RemoteCarDiagz.Server.Services
{
    public interface IMeasurementService
    {
        void SetMeasurement(byte value);
    }

    public class MeasurementService : IMeasurementService
    {
        private static readonly Gauge Rpm = Metrics.CreateGauge("RPM", "Number of jobs waiting for processing in the queue.");
        public void SetMeasurement(byte value)
        {
            Rpm.Set(value);
        }

        public void ProcessMeasurement(SendMeaurementsRequest request)
        {
            
        }
    }
}
