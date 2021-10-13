using RemoteCarDiagz.Shared.Requests;

namespace RemoteCarDiagz.Server.Services.PidServices
{
    public abstract class MeasurementHandler : IMeasurementHandler
    {
        private IMeasurementHandler _nextHandler;

        public virtual void Handle(SendMeaurementsRequest request)
        {
            if(_nextHandler != null)
            {
                _nextHandler.Handle(request);
                return;
            }
        }

        public IMeasurementHandler SetNext(IMeasurementHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }
    }
}
