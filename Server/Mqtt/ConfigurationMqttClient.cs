using Microsoft.Extensions.Logging;
using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using RemoteCarDiagz.Shared.Domain;
using RemoteCarDiagz.Shared.Mqtt;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace RemoteCarDiagz.Server.Mqtt
{
    public class ConfigurationMqttClient : IConfigurationMqttClient
    {
        private readonly IManagedMqttClient _mqttClient;
        private readonly ILogger<ConfigurationMqttClient> _logger;
        private const string _clientName = nameof(ConfigurationMqttClient);
        private const string _serverTcpAddress = "mqttbroker";

        public ConfigurationMqttClient(IManagedMqttClient mqttClient, ILogger<ConfigurationMqttClient> logger)
        {
            _mqttClient = mqttClient;
            _logger = logger;

            var builder = new MqttClientOptionsBuilder()
                                        .WithClientId(_clientName)
                                        .WithTcpServer(_serverTcpAddress);

            var options = new ManagedMqttClientOptionsBuilder()
                                    .WithAutoReconnectDelay(TimeSpan.FromSeconds(60))
                                    .WithClientOptions(builder.Build())
                                    .Build();

            _mqttClient.ConnectedAsync += OnConnectedAsync;
            _mqttClient.DisconnectedAsync += OnDisconnectedAsync;
            _mqttClient.ConnectingFailedAsync += ConnectingFailedAsync;
            _mqttClient.StartAsync(options);
        }

        public async Task PublishMeasurementMessage(Measurement measurement)
        {
            string serializedMeasurement = JsonSerializer.Serialize(measurement);
            await _mqttClient.EnqueueAsync(MqttTopic.ActiveMeasurementsTopic, serializedMeasurement);
        }

        private Task OnConnectedAsync(MqttClientConnectedEventArgs args)
        {
            _logger.LogInformation("Client {name} connected", _clientName);
            return Task.CompletedTask;
        }

        private Task OnDisconnectedAsync(MqttClientDisconnectedEventArgs args)
        {
            _logger.LogInformation("Client {name} disconnected", _clientName);
            return Task.CompletedTask;
        }

        private Task ConnectingFailedAsync(ConnectingFailedEventArgs args)
        {
            _logger.LogError("Client {name} connection failure because of {reasonString}", _clientName, args.ConnectResult.ReasonString);
            return Task.CompletedTask;
        }
    }
}
