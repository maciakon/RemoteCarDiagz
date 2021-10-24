using Microsoft.Extensions.Logging;
using Prometheus;
using RemoteCarDiagz.Shared.Domain;
using RemoteCarDiagz.Shared.Requests;

namespace RemoteCarDiagz.Server.Services.PidServices
{
    public class CoolantTemperatureHandler : MeasurementHandler
    {
        private static readonly Gauge _coolantTemp = Metrics.CreateGauge(nameof(PidIds.PID_COOLANT_TEMP), "Coolant temperature [C]");
        private ILogger<CoolantTemperatureHandler> _logger;

        public CoolantTemperatureHandler(ILogger<CoolantTemperatureHandler> logger)
        {
            _logger = logger;
        }

        public override void Handle(SendMeaurementsRequest request)
        {
            if(request.PIDCode == PidIds.PID_COOLANT_TEMP)
            {
                _logger.LogInformation("CoolantTemperature handler");
                var coolantTemp = request.A - 40;
                _coolantTemp.Set(coolantTemp);
                return;
            }
            
            base.Handle(request);
        }
    }
}
