namespace RPCServices
{
    using System;

    public class ThrottleService : ServiceDescriptor
    {
        public const uint REPORT_METER_EVENT_ID = 1;
        public const uint THROTTLE_SERVICE_ID = 3;

        public ThrottleService() : base("bnet.protocol.risk.ThrottleService")
        {
            base.Methods = new MethodDescriptor[] { new MethodDescriptor("bnet.protocol.risk.ThrottleService.ReportMeterEvent", 1, true) };
        }
    }
}

