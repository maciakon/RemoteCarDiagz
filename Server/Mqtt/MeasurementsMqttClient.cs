using Microsoft.Extensions.Logging;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using Prometheus;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace RemoteCarDiagz.Server.Mqtt
{
    public class MeasurementsMqttClient : IMeasurementsMqttClient
    {
        private readonly IManagedMqttClient _mqttClient;
        private readonly ILogger<MeasurementsMqttClient> _logger;
        
#if DEBUG
        private const string _serverTcpAddress = "18.185.185.121";
        private const string _clientName = "MeasurementsClient";
#else
        private const string _serverTcpAddress = "mqttbroker";
        private const string _clientName = nameof(MeasurementsMqttClient);
#endif

        public MeasurementsMqttClient(IManagedMqttClient mqttClient, ILogger<MeasurementsMqttClient> logger)
        {
            _mqttClient = mqttClient;
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

        private async Task ApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs arg)
        {
            var metricName = arg.ApplicationMessage.Topic.Substring(arg.ApplicationMessage.Topic.LastIndexOf('/') + 1);
            var metric = Metrics.CreateGauge(metricName, arg.ApplicationMessage.Topic);
            using MemoryStream stream = new(arg.ApplicationMessage.Payload);
            var json = await JsonSerializer.DeserializeAsync<UInt16>(stream);
            metric.Set(json);
            _logger.LogInformation("Message received: {0}, value: {1}, with metric {2}", arg.ApplicationMessage.Topic, json, metricName);
        }

        private Task ConnectingFailedAsync(ConnectingFailedEventArgs arg)
        {
            _logger.LogError("Client {name} connection failure because of {reasonString}", _clientName, arg.ConnectResult.ReasonString);
            return Task.CompletedTask;
        }

        private Task OnDisconnectedAsync(MqttClientDisconnectedEventArgs arg)
        {
            _logger.LogInformation("Client {name} disconnected", _clientName);
            return Task.CompletedTask;
        }

        private Task OnConnectedAsync(MqttClientConnectedEventArgs arg)
        {
            _logger.LogInformation("Client {name} connected", _clientName);
            var mqttSubscribeOptions = new MqttFactory().CreateSubscribeOptionsBuilder()
               .WithTopicFilter(
                   f =>
                   {
                       f.WithTopic("remotecardiagz/pids/#");
                   })
               .Build();

            return _mqttClient.SubscribeAsync(mqttSubscribeOptions.TopicFilters);
        }
    }
}
