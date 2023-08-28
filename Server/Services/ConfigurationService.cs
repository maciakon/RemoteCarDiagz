using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Prometheus;
using RemoteCarDiagz.Server.Data;
using RemoteCarDiagz.Server.Mqtt;
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
        private readonly IDbContextFactory<RemoteCarDiagzContext> _dbContextFactory;
        private readonly IConfigurationMqttClient _configurationMqttClient;

        public ConfigurationService(IDbContextFactory<RemoteCarDiagzContext> dbContextFactory, IConfigurationMqttClient configurationMqttClient, ILogger<ConfigurationService> logger)
        {
            _dbContextFactory = dbContextFactory;
            _configurationMqttClient = configurationMqttClient;
            _logger = logger;
        }

        public async Task<List<Measurement>> GetAvailableMeasurements()
        {
            try
            {
                using var dbContext = _dbContextFactory.CreateDbContext();
                return await dbContext.Measurements.Where(x => x.IsAvailable).ToListAsync();
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
            ResetMetricWhenDeactivated(toggleActivationRequest);
            await _configurationMqttClient.PublishMeasurementMessage(new Measurement { IsActive = toggleActivationRequest.IsActive, Value = toggleActivationRequest.Pid });
            return await SaveMeasurement(toggleActivationRequest);
        }

        private async Task<bool> SaveMeasurement(ToggleActivateMeasurementRequest toggleActivationRequest)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            var entry = await dbContext.Measurements.FirstOrDefaultAsync(x => x.Value == toggleActivationRequest.Pid);
            if (entry != null)
            {
                entry.IsActive = toggleActivationRequest.IsActive;
            }
            return await dbContext.SaveChangesAsync() > 0;
        }

        private void ResetMetricWhenDeactivated(ToggleActivateMeasurementRequest toggleActivationRequest)
        {
            if(!toggleActivationRequest.IsActive)
            {
                var metricName = toggleActivationRequest.Pid.ToString()["PID_".Length..];
                var metric = Metrics.CreateGauge(metricName, string.Empty);
                metric.Set(0);
            }
        }
    }
}