using System.Threading.Tasks;

namespace RemoteCarDiagz.Server.Mqtt
{
    public interface IMeasurementsMqttClient
    {
        Task Start();
    }
}