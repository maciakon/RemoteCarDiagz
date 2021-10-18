using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RemoteCarDiagz.Server.Data;
using RemoteCarDiagz.Shared.Requests;

namespace RemoteCarDiagz.Server.Services
{
    public interface IConfigurationService
    {
        Task<List<Measurement>> GetActiveMeasurements();
        Task<bool> SetActiveMeasurements(SetActiveMeasurementsRequest request);
    }

    public class ConfigurationService : IConfigurationService
    {
        private readonly ILogger<ConfigurationService> _logger;
        private readonly RemoteCarDiagzContext _dbContext;

        public ConfigurationService(RemoteCarDiagzContext dbContext, ILogger<ConfigurationService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<List<Measurement>> GetActiveMeasurements()
        {
            try
            {
                return await _dbContext.Measurements.Where(x => x.IsActive == true).ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError($"GetActiveMeasurements: {e.Message}");
                throw;
            }
        }

        public async Task<bool> SetActiveMeasurements(SetActiveMeasurementsRequest request)
        {
            _logger.LogInformation($"Setting active measurements: {request.PidIds.ToString()}");
            _dbContext.Database.ExecuteSqlRaw("UPDATE [Measurements] SET [IsActive] = false");
            foreach (var pid in request.PidIds)
            {
                var entry = await _dbContext.Measurements.FirstOrDefaultAsync(x => x.Value == pid);
                if(entry != null)
                {
                    entry.IsActive = true;
                }
                else return false;

            }

            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}