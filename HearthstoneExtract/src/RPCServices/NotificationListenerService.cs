namespace RPCServices
{
    using System;

    public class NotificationListenerService : ServiceDescriptor
    {
        public const uint NOTIFICATION_LISTENER_SERVICE_ID = 5;
        public const uint ON_NOTIFICATION_REC_ID = 1;

        public NotificationListenerService() : base("bnet.protocol.notification.NotificationListener")
        {
            base.Methods = new MethodDescriptor[] { new MethodDescriptor("bnet.protocol.notification.NotificationListener.OnNotificationReceived", 1, false) };
        }
    }
}

