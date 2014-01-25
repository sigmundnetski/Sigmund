namespace RPCServices
{
    using System;

    public class NotificationService : ServiceDescriptor
    {
        public const uint FIND_CLIENT_ID = 4;
        public const uint NOTIFICATION_SERVICE_ID = 10;
        public const uint REGISTER_CLIENT_ID = 2;
        public const uint SEND_NOTIFICATION_ID = 1;
        public const uint UNREGISTER_CLIENT_ID = 3;

        public NotificationService() : base("bnet.protocol.notification.NotificationService")
        {
            base.Methods = new MethodDescriptor[] { new MethodDescriptor("bnet.protocol.notification.NotificationService.SendNotification", 1, true), new MethodDescriptor("bnet.protocol.notification.NotificationService.RegisterClient", 2, true), new MethodDescriptor("bnet.protocol.notification.NotificationService.UnregisterClient", 3, true), new MethodDescriptor("bnet.protocol.notification.NotificationService.FindClient", 4, true) };
        }
    }
}

