using MQTTnet.Server;

namespace RemoteCarDiagz.MqttBroker.Mqtt
{
    public interface IMqttController
    {
        Task InterceptPublishAsync(InterceptingPublishEventArgs arg);
        Task OnClientConnected(ClientConnectedEventArgs eventArgs);
        Task ValidateConnection(ValidatingConnectionEventArgs eventArgs);
    }
}