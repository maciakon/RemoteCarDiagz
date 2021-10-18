using System.Collections.Generic;
using RemoteCarDiagz.Shared.Domain;

namespace RemoteCarDiagz.Shared.Requests
{
    public class SetActiveMeasurementsRequest
    {
        public List<PidIdsEnum> PidIds { get; set; }
    }
}