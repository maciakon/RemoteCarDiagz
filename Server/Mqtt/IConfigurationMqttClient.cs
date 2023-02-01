using RemoteCarDiagz.Shared.Domain;
using System.Threading.Tasks;

namespace RemoteCarDiagz.Server.Mqtt
{
    public interface IConfigurationMqttClient
    {
        Task PublishMeasurementMessage(Measurement measurement);
    }
}