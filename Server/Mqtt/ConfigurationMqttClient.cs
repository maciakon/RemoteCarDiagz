using Microsoft.Extensions.Logging;
using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using RemoteCarDiagz.Shared.Domain;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace RemoteCarDiagz.Server.Mqtt
{
    public class ConfigurationMqttClient : IConfigurationMqttClient
    {
        private readonly IManagedMqttClient _mqttClient;
        private readonly ILogger<ConfigurationMqttClient> _logger;

        public ConfigurationMqttClient(IManagedMqttClient mqttClient, ILogger<ConfigurationMqttClient> logger)
        {
            _mqttClient = mqttClient;
            _logger = logger;

            MqttClientOptionsBuilder builder = new MqttClientOptionsBuilder()
                                        .WithClientId("behroozbc")
                                        .WithTcpServer("mqttbroker");
            ManagedMqttClientOptions options = new ManagedMqttClientOptionsBuilder()
                                    .WithAutoReconnectDelay(TimeSpan.FromSeconds(60))
                                    .WithClientOptions(builder.Build())
                                    .Build();
            // Set up handlers
            _mqttClient.ConnectedAsync += new Func<MqttClientConnectedEventArgs, Task>((e) => { logger.LogInformation("Connected"); return Task.CompletedTask; });
            _mqttClient.DisconnectedAsync += new Func<MqttClientDisconnectedEventArgs, Task>((e) => { logger.LogInformation("Disconnected"); return Task.CompletedTask; });
            _mqttClient.ConnectingFailedAsync += new Func<ConnectingFailedEventArgs, Task>((e) =>
            {
                logger.LogError("Connection failed check network or broker!");
                return Task.CompletedTask;
            });
            _mqttClient.StartAsync(options);

        }

        public async Task PublishMeasurementMessage(Measurement measurement)
        {
            _logger.LogInformation("Enqueueing message");
            string serializedMeasurement = JsonSerializer.Serialize(measurement);
            await _mqttClient.EnqueueAsync("behroozbc.ir/topic/json", serializedMeasurement);
        }
    }
}
