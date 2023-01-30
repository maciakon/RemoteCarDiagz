using MQTTnet.Server;
using System;
using System.Text.Json;

namespace RemoteCarDiagz.MqttBroker.Mqtt
{
    public class MqttController : IMqttController
    {
        public Task InterceptPublishAsync(InterceptingPublishEventArgs arg)
        {
            var json = JsonSerializer.Deserialize<dynamic>(arg.ApplicationMessage.Payload);
            Console.WriteLine($"Client {json} intercepting publish.");
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
