using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCarDiagz.Server.Mqtt
{
    public class MqttClientHostedService : BackgroundService
    {
        private readonly IMeasurementsMqttClient _measurementsMqttClient;

        public MqttClientHostedService(IMeasurementsMqttClient measurementsMqttClient)
        {
            _measurementsMqttClient = measurementsMqttClient;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return _measurementsMqttClient.Start();
        }
    }
}
