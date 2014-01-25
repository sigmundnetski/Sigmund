namespace bnet.protocol.presence
{
    using bnet.protocol.channel;
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Descriptors;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public static class PresenceService
    {
        internal static readonly object Descriptor = null;

        static PresenceService()
        {
            bnet.protocol.presence.ChannelState.Presence = new GeneratedExtensionLite<bnet.protocol.channel.ChannelState, bnet.protocol.presence.ChannelState>("bnet.protocol.presence.ChannelState.presence", bnet.protocol.channel.ChannelState.DefaultInstance, null, bnet.protocol.presence.ChannelState.DefaultInstance, null, 0x65, FieldType.Message);
        }

        public static void RegisterAllExtensions(ExtensionRegistry registry)
        {
            registry.Add(bnet.protocol.presence.ChannelState.Presence);
        }
    }
}

