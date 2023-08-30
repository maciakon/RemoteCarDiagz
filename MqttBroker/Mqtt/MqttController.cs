using MQTTnet.Server;

namespace RemoteCarDiagz.MqttBroker.Mqtt
{
    public class MqttController : IMqttController
    {
        private readonly ILogger<MqttController> _logger;

        public MqttController(ILogger<MqttController> logger)
        {
            _logger = logger;
        }

        public Task InterceptingInboundPacketAsync(InterceptingPacketEventArgs args)
        {
            Console.WriteLine($"InterceptingInboundPacket with client id: {args.ClientId} ");
            return Task.CompletedTask;
        }

        public Task InterceptPublishAsync(InterceptingPublishEventArgs arg)
        {
            // var topic = arg.ApplicationMessage.Topic;
            //var json = JsonSerializer.Deserialize<dynamic>(arg.ApplicationMessage.Payload);
            _logger.LogInformation($"Intercepting publish on topic: {arg.ApplicationMessage.Topic}.");
            // Console.WriteLine($"Client {json} intercepting publish.");
            return Task.CompletedTask;
        }

        public Task InterceptSubscriptionAsync(InterceptingSubscriptionEventArgs args)
        {
            Console.WriteLine($"InterceptSubscriptionAsync with topic: {args.TopicFilter.ToString()}");
            return Task.CompletedTask;
        }

        public Task OnClientConnected(ClientConnectedEventArgs eventArgs)
        {
            Console.WriteLine($"Client '{eventArgs.ClientId}' connected.");
            return Task.CompletedTask;
        }


        public Task ValidateConnection(ValidatingConnectionEventArgs eventArgs)
        {
            Console.WriteLine($"Client '{eventArgs.ClientId}' wants to connect. Accepting!");
            return Task.CompletedTask;
        }
    }
}
