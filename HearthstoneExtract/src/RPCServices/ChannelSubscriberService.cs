namespace RPCServices
{
    using System;

    public class ChannelSubscriberService : ServiceDescriptor
    {
        public const uint CHANNEL_SUBSCRIBER_SERVICE_ID = 6;
        public const uint NOTIFY_ADD_ID = 1;
        public const uint NOTIFY_JOIN_ID = 2;
        public const uint NOTIFY_LEAVE_ID = 4;
        public const uint NOTIFY_REMOVE_ID = 3;
        public const uint NOTIFY_SEND_MESSAGE_ID = 5;
        public const uint NOTIFY_UPDATE_CHANNEL_STATE_ID = 6;
        public const uint NOTIFY_UPDATE_MEMBER_STATE_ID = 7;

        public ChannelSubscriberService() : base("bnet.protocol.channel.ChannelSubscriber")
        {
            base.Methods = new MethodDescriptor[] { new MethodDescriptor("bnet.protocol.channel.ChannelSubscriber.NotifyAdd", 1, false), new MethodDescriptor("bnet.protocol.channel.ChannelSubscriber.NotifyJoin", 2, false), new MethodDescriptor("bnet.protocol.channel.ChannelSubscriber.NotifyRemove", 3, false), new MethodDescriptor("bnet.protocol.channel.ChannelSubscriber.NotifyLeave", 4, false), new MethodDescriptor("bnet.protocol.channel.ChannelSubscriber.NotifySendMessage", 5, false), new MethodDescriptor("bnet.protocol.channel.ChannelSubscriber.NotifyUpdateChannelState", 6, false), new MethodDescriptor("bnet.protocol.channel.ChannelSubscriber.NotifyUpdateMemberState", 7, false) };
        }
    }
}

