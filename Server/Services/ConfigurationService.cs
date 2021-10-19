using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RemoteCarDiagz.Server.Data;
using RemoteCarDiagz.Shared.Domain;
using RemoteCarDiagz.Shared.Requests;

namespace RemoteCarDiagz.Server.Services
{
    public interface IConfigurationService
    {
        Task<List<Measurement>> GetAvailableMeasurements();
        Task<bool> ToggleMeasurementActive(ToggleActivateMeasurementRequest requestPid);
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

        public async Task<List<Measurement>> GetAvailableMeasurements()
        {
            try
            {
                return await _dbContext.Measurements.Where(x => x.IsAvailable).ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError($"GetActiveMeasurements: {e.Message}");
                throw;
            }
        }

        public async Task<bool> ToggleMeasurementActive(ToggleActivateMeasurementRequest toggleActivationRequest)
        {
            _logger.LogInformation($"Toggle measurement: {toggleActivationRequest.Pid}, active: {toggleActivationRequest.IsActive}");

            var entry = await _dbContext.Measurements.FirstOrDefaultAsync(x => x.Value == toggleActivationRequest.Pid);
            if(entry != null)
            {
                entry.IsActive = toggleActivationRequest.IsActive;
            }
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}