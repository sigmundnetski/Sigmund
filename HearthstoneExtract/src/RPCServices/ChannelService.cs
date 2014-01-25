namespace RPCServices
{
    using System;

    public class ChannelService : ServiceDescriptor
    {
        public const uint ADD_MEMBER_ID = 1;
        public const uint CHANNEL_SERVICE_ID = 3;
        public const uint DISSOLVE_ID = 6;
        public const uint REMOVE_MEMBER_ID = 2;
        public const uint SEND_MESSAGE_ID = 3;
        public const uint SETROLES_ID = 7;
        public const uint UPDATE_CHANNEL_STATE_ID = 4;
        public const uint UPDATE_MEMBER_STATE_ID = 5;

        public ChannelService() : base("bnet.protocol.channel.Channel")
        {
            base.Methods = new MethodDescriptor[] { new MethodDescriptor("bnet.protocol.channel.Channel.AddMember", 1, false), new MethodDescriptor("bnet.protocol.channel.Channel.RemoveMember", 2, false), new MethodDescriptor("bnet.protocol.channel.Channel.SendMessage", 3, false), new MethodDescriptor("bnet.protocol.channel.Channel.UpdateChannelState", 4, false), new MethodDescriptor("bnet.protocol.channel.Channel.UpdateMemberState", 5, false), new MethodDescriptor("bnet.protocol.channel.Channel.Dissolve", 6, false), new MethodDescriptor("bnet.protocol.channel.Channel.AddMember", 7, false) };
        }
    }
}

