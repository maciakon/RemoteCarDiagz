using RemoteCarDiagz.Shared.Requests;

namespace RemoteCarDiagz.Server.Services.PidServices
{
    public interface IMeasurementHandler
    {
        IMeasurementHandler SetNext(IMeasurementHandler handler);
        void Handle(SendMeaurementsRequest request);
    }
}
