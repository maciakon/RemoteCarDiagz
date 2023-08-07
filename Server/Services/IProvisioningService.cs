using RemoteCarDiagz.Shared.Domain;
using System.Threading.Tasks;

namespace RemoteCarDiagz.Server.Services
{
    public interface IProvisioningService
    {
        Task<ProvisioningConfiguration> GetGrafanaConfiguration();
        Task SetGrafanaConfiguration(string grafanaPublicDashboardUid);
    }
}