using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCarDiagz.Server.Mqtt
{
    public class MqttClientHostedService : BackgroundService
    {
        private readonly IMeasurementsMqttClient _measurementsMqttClient;
        private readonly IInitialConfigurationPublisherMqttClient _initialConfigurationPublisherMqttClient;

        public MqttClientHostedService(IMeasurementsMqttClient measurementsMqttClient, IInitialConfigurationPublisherMqttClient initialConfigurationPublisherMqttClient)
        {
            _measurementsMqttClient = measurementsMqttClient;
            _initialConfigurationPublisherMqttClient = initialConfigurationPublisherMqttClient;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.WhenAll(_measurementsMqttClient.Start(), _initialConfigurationPublisherMqttClient.Start());
        }
    }
}
