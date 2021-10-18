using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RemoteCarDiagz.Server.Data;
using RemoteCarDiagz.Server.Services.PidServices;
using RemoteCarDiagz.Shared.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteCarDiagz.Server.Services
{
    public interface IMeasurementService
    {
        void ProcessMeasurement(SendMeaurementsRequest request);
        Task<List<Measurement>> GetActiveMeasurements();
        Task SetActiveMeasurements(SetActiveMeasurementsRequest request);
    }

    public class MeasurementService : IMeasurementService
    {
        private readonly IMeasurementHandler _engineRpmHandler = new EngineRpmHandler();
        private readonly RemoteCarDiagzContext _dbContext;
        private readonly ILogger<MeasurementService> _logger;

        public MeasurementService(RemoteCarDiagzContext dbContext, ILogger<MeasurementService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;

            _engineRpmHandler
                .SetNext(new CoolantTemperatureHandler())
                .SetNext(new EngineLoadHandler())
                .SetNext(new EngineRpmHandler())
                .SetNext(new FuelPressureHandler())
                .SetNext(new IntakeAirTemperatureHandler())
                .SetNext(new IntakeManifoldAbsolutePressureHandler())
                .SetNext(new MafAirFlowRateHandler())
                .SetNext(new ThrottlePosition())
                .SetNext(new VehicleSpeedHandler());
        }

        public async Task<List<Measurement>> GetActiveMeasurements()
        {
            try
            {
                return await _dbContext.Measurements.Where(x => x.IsActive == true).ToListAsync();
            }
            catch(Exception e)
            {
                _logger.LogError($"GetActiveMeasurements: {e.Message}");
                throw;
            }
        }

        public async Task SetActiveMeasurements(SetActiveMeasurementsRequest request)
        {
            _logger.LogInformation($"Setting active measurements: {request.PidIds.ToString()}");
            _dbContext.Database.ExecuteSqlRaw("UPDATE [Measurements] SET [Active] = false");
            foreach(var pid in request.PidIds)
            {
                var entry = await _dbContext.Measurements.FirstOrDefaultAsync(x => x.Value == pid);
                entry.IsActive = true;
            }

            await _dbContext.SaveChangesAsync();
        }

        public void ProcessMeasurement(SendMeaurementsRequest request)
        {
            _engineRpmHandler.Handle(request);
        }
    }
}
