namespace RemoteCarDiagz.Shared.Requests
{
    public class SendMeaurementsRequest
    {
        public byte PIDCode { get; set; } 
        public byte A {get; set; }
        public byte B { get; set; }
        public byte C { get; set;}
        public byte D { get; set; }
    }
}