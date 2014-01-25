namespace RPCServices
{
    using System;

    public class PresenceService : ServiceDescriptor
    {
        public const uint PRESENCE_SERVICE_ID = 4;
        public const uint QUERY_ID = 4;
        public const uint SUBSCRIBE_ID = 1;
        public const uint UNSUBSCRIBE_ID = 2;
        public const uint UPDATE_ID = 3;

        public PresenceService() : base("bnet.protocol.presence.PresenceService")
        {
            base.Methods = new MethodDescriptor[] { new MethodDescriptor("bnet.protocol.presence.PresenceService.Subscribe", 1, false), new MethodDescriptor("bnet.protocol.presence.PresenceService.Unsubscribe", 2, false), new MethodDescriptor("bnet.protocol.presence.PresenceService.Update", 3, false), new MethodDescriptor("bnet.protocol.presence.PresenceService.Query", 4, true) };
        }
    }
}

