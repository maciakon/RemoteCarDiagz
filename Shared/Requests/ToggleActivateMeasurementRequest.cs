using RemoteCarDiagz.Shared.Domain;

namespace RemoteCarDiagz.Shared.Requests
{
    public class ToggleActivateMeasurementRequest
    {
        public PidIdsEnum Pid { get; set; }
        public bool IsActive {get; set;}
    }
}