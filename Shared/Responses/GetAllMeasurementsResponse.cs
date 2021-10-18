using System.Collections.Generic;
using RemoteCarDiagz.Shared.Domain;

namespace RemoteCarDiagz.Shared.Responses
{
    public class GetAllMeasurementsResponse
    {
        public List<PidIdsEnum> ActiveMeasurements { get; set; }
    }
}