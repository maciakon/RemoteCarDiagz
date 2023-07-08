using MQTTnet.Server;

namespace RemoteCarDiagz.MqttBroker.Mqtt
{
    public interface IMqttController
    {
        Task InterceptingInboundPacketAsync(InterceptingPacketEventArgs args);
        Task InterceptPublishAsync(InterceptingPublishEventArgs arg);
        Task InterceptSubscriptionAsync(InterceptingSubscriptionEventArgs args);
        Task OnClientConnected(ClientConnectedEventArgs eventArgs);
        Task ValidateConnection(ValidatingConnectionEventArgs eventArgs);
    }
}