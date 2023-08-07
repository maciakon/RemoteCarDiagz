using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RemoteCarDiagz.Server.Data;
using RemoteCarDiagz.Shared.Domain;
using System.Threading.Tasks;

namespace RemoteCarDiagz.Server.Services
{
    public class ProvisioningService : IProvisioningService
    {
        private readonly IDbContextFactory<RemoteCarDiagzContext> _dbContextFactory;
        private readonly ILogger<ProvisioningService> _logger;

        public ProvisioningService(IDbContextFactory<RemoteCarDiagzContext> dbContextFactory, ILogger<ProvisioningService> logger)
        {
            _dbContextFactory = dbContextFactory;
            _logger = logger;
        }

        public async Task<ProvisioningConfiguration> GetGrafanaConfiguration()
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            return await dbContext.GrafanaConfig.FirstOrDefaultAsync();
        }

        public async Task SetGrafanaConfiguration(string grafanaPublicDashboardUid)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            var configuration = await dbContext.GrafanaConfig.FirstOrDefaultAsync();
            if (configuration == null)
            {
                dbContext.GrafanaConfig.Add(new ProvisioningConfiguration { PublicDashboardUid = grafanaPublicDashboardUid });
            }
            else
            {
                configuration.PublicDashboardUid = grafanaPublicDashboardUid;
            }
            await dbContext.SaveChangesAsync();
        }
    }
}
