using System.Threading.Tasks;

namespace RemoteCarDiagz.Server.Mqtt
{
    public interface IInitialConfigurationPublisherMqttClient
    {
        Task Start();
    }
}