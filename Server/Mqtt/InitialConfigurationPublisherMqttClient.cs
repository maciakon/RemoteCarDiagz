using Microsoft.Extensions.Logging;
using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using System.Threading.Tasks;
using System;
using MQTTnet;
using System.Text.Json;
using RemoteCarDiagz.Server.Services;
using RemoteCarDiagz.Shared.Mqtt;

namespace RemoteCarDiagz.Server.Mqtt
{
    public class InitialConfigurationPublisherMqttClient : IInitialConfigurationPublisherMqttClient
    {
        private readonly IManagedMqttClient _mqttClient;
        private readonly IConfigurationService _configurationService;
        private readonly ILogger<MeasurementsMqttClient> _logger;

#if DEBUG
        private const string _serverTcpAddress = "18.185.185.121";
        private const string _clientName = "InitialConfigClient";
#else
        private const string _serverTcpAddress = "mqttbroker";
        private const string _clientName = "nameof(InitialConfigurationPublisherMqttClient)";
#endif
        public InitialConfigurationPublisherMqttClient(IManagedMqttClient mqttClient, IConfigurationService configurationService, ILogger<MeasurementsMqttClient> logger)
        {
            _mqttClient = mqttClient;
            _configurationService = configurationService;
            _logger = logger;
        }

        public Task Start()
        {
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
            _mqttClient.ApplicationMessageReceivedAsync += ApplicationMessageReceivedAsync;
            return _mqttClient.StartAsync(options);
        }

        private async Task ApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs args)
        {
           var configuration = await _configurationService.GetAvailableMeasurements();
            var serializedMeasurements = JsonSerializer.Serialize(configuration);
            await _mqttClient.EnqueueAsync(MqttTopic.InitialConfigurationTopic, serializedMeasurements);
        }

        private Task ConnectingFailedAsync(ConnectingFailedEventArgs args)
        {
            _logger.LogError("Client {name} connection failure because of {reasonString}", _clientName, args.ConnectResult.ReasonString);
            return Task.CompletedTask;
        }

        private Task OnDisconnectedAsync(MqttClientDisconnectedEventArgs args)
        {
            _logger.LogInformation("Client {name} disconnected", _clientName);
            return Task.CompletedTask;
        }

        private Task OnConnectedAsync(MqttClientConnectedEventArgs args)
        {
            _logger.LogInformation("Client {name} connected", _clientName);
            var mqttSubscribeOptions = new MqttFactory().CreateSubscribeOptionsBuilder()
               .WithTopicFilter(
                   f =>
                   {
                       f.WithTopic(MqttTopic.DeviceReadyTopic);
                   })
               .Build();

            return _mqttClient.SubscribeAsync("remotecardiagz/deviceready");
        }
    }
}
