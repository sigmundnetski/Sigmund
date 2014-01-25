namespace bnet.protocol.channel
{
    using bnet.protocol;
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class SendMessageNotification : GeneratedMessageLite<SendMessageNotification, Builder>
    {
        private static readonly string[] _sendMessageNotificationFieldNames = new string[] { "agent_id", "message", "required_privileges" };
        private static readonly uint[] _sendMessageNotificationFieldTags = new uint[] { 10, 0x12, 0x18 };
        private EntityId agentId_;
        public const int AgentIdFieldNumber = 1;
        private static readonly SendMessageNotification defaultInstance = new SendMessageNotification().MakeReadOnly();
        private bool hasAgentId;
        private bool hasMessage;
        private bool hasRequiredPrivileges;
        private int memoizedSerializedSize = -1;
        private bnet.protocol.channel.Message message_;
        public const int MessageFieldNumber = 2;
        private ulong requiredPrivileges_;
        public const int RequiredPrivilegesFieldNumber = 3;

        static SendMessageNotification()
        {
            object.ReferenceEquals(ChannelService.Descriptor, null);
        }

        private SendMessageNotification()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(SendMessageNotification prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            SendMessageNotification notification = obj as SendMessageNotification;
            if (notification == null)
            {
                return false;
            }
            if ((this.hasAgentId != notification.hasAgentId) || (this.hasAgentId && !this.agentId_.Equals(notification.agentId_)))
            {
                return false;
            }
            if ((this.hasMessage != notification.hasMessage) || (this.hasMessage && !this.message_.Equals(notification.message_)))
            {
                return false;
            }
            return ((this.hasRequiredPrivileges == notification.hasRequiredPrivileges) && (!this.hasRequiredPrivileges || this.requiredPrivileges_.Equals(notification.requiredPrivileges_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasAgentId)
            {
                hashCode ^= this.agentId_.GetHashCode();
            }
            if (this.hasMessage)
            {
                hashCode ^= this.message_.GetHashCode();
            }
            if (this.hasRequiredPrivileges)
            {
                hashCode ^= this.requiredPrivileges_.GetHashCode();
            }
            return hashCode;
        }

        private SendMessageNotification MakeReadOnly()
        {
            return this;
        }

        public static SendMessageNotification ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static SendMessageNotification ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static SendMessageNotification ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static SendMessageNotification ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static SendMessageNotification ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static SendMessageNotification ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static SendMessageNotification ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static SendMessageNotification ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static SendMessageNotification ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static SendMessageNotification ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<SendMessageNotification, Builder>.PrintField("agent_id", this.hasAgentId, this.agentId_, writer);
            GeneratedMessageLite<SendMessageNotification, Builder>.PrintField("message", this.hasMessage, this.message_, writer);
            GeneratedMessageLite<SendMessageNotification, Builder>.PrintField("required_privileges", this.hasRequiredPrivileges, this.requiredPrivileges_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _sendMessageNotificationFieldNames;
            if (this.hasAgentId)
            {
                output.WriteMessage(1, strArray[0], this.AgentId);
            }
            if (this.hasMessage)
            {
                output.WriteMessage(2, strArray[1], this.Message);
            }
            if (this.hasRequiredPrivileges)
            {
                output.WriteUInt64(3, strArray[2], this.RequiredPrivileges);
            }
        }

        public EntityId AgentId
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.agentId_ != null)
                {
                    goto Label_0012;
                }
                return EntityId.DefaultInstance;
            }
        }

        public static SendMessageNotification DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override SendMessageNotification DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasAgentId
        {
            get
            {
                return this.hasAgentId;
            }
        }

        public bool HasMessage
        {
            get
            {
                return this.hasMessage;
            }
        }

        public bool HasRequiredPrivileges
        {
            get
            {
                return this.hasRequiredPrivileges;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasMessage)
                {
                    return false;
                }
                if (this.HasAgentId && !this.AgentId.IsInitialized)
                {
                    return false;
                }
                if (!this.Message.IsInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        public bnet.protocol.channel.Message Message
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.message_ != null)
                {
                    goto Label_0012;
                }
                return bnet.protocol.channel.Message.DefaultInstance;
            }
        }

        [CLSCompliant(false)]
        public ulong RequiredPrivileges
        {
            get
            {
                return this.requiredPrivileges_;
            }
        }

        public override int SerializedSize
        {
            get
            {
                int memoizedSerializedSize = this.memoizedSerializedSize;
                if (memoizedSerializedSize == -1)
                {
                    memoizedSerializedSize = 0;
                    if (this.hasAgentId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.AgentId);
                    }
                    if (this.hasMessage)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, this.Message);
                    }
                    if (this.hasRequiredPrivileges)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(3, this.RequiredPrivileges);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override SendMessageNotification ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<SendMessageNotification, SendMessageNotification.Builder>
        {
            private SendMessageNotification result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = SendMessageNotification.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(SendMessageNotification cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override SendMessageNotification BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override SendMessageNotification.Builder Clear()
            {
                this.result = SendMessageNotification.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public SendMessageNotification.Builder ClearAgentId()
            {
                this.PrepareBuilder();
                this.result.hasAgentId = false;
                this.result.agentId_ = null;
                return this;
            }

            public SendMessageNotification.Builder ClearMessage()
            {
                this.PrepareBuilder();
                this.result.hasMessage = false;
                this.result.message_ = null;
                return this;
            }

            public SendMessageNotification.Builder ClearRequiredPrivileges()
            {
                this.PrepareBuilder();
                this.result.hasRequiredPrivileges = false;
                this.result.requiredPrivileges_ = 0L;
                return this;
            }

            public override SendMessageNotification.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new SendMessageNotification.Builder(this.result);
                }
                return new SendMessageNotification.Builder().MergeFrom(this.result);
            }

            public SendMessageNotification.Builder MergeAgentId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasAgentId && (this.result.agentId_ != EntityId.DefaultInstance))
                {
                    this.result.agentId_ = EntityId.CreateBuilder(this.result.agentId_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.agentId_ = value;
                }
                this.result.hasAgentId = true;
                return this;
            }

            public override SendMessageNotification.Builder MergeFrom(SendMessageNotification other)
            {
                if (other != SendMessageNotification.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAgentId)
                    {
                        this.MergeAgentId(other.AgentId);
                    }
                    if (other.HasMessage)
                    {
                        this.MergeMessage(other.Message);
                    }
                    if (other.HasRequiredPrivileges)
                    {
                        this.RequiredPrivileges = other.RequiredPrivileges;
                    }
                }
                return this;
            }

            public override SendMessageNotification.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override SendMessageNotification.Builder MergeFrom(IMessageLite other)
            {
                if (other is SendMessageNotification)
                {
                    return this.MergeFrom((SendMessageNotification) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override SendMessageNotification.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(SendMessageNotification._sendMessageNotificationFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = SendMessageNotification._sendMessageNotificationFieldTags[index];
                        }
                        else
                        {
                            this.ParseUnknownField(input, extensionRegistry, num, str);
                            continue;
                        }
                    }
                    switch (num)
                    {
                        case 0:
                            throw InvalidProtocolBufferException.InvalidTag();

                        case 10:
                        {
                            EntityId.Builder builder = EntityId.CreateBuilder();
                            if (this.result.hasAgentId)
                            {
                                builder.MergeFrom(this.AgentId);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.AgentId = builder.BuildPartial();
                            continue;
                        }
                        case 0x12:
                        {
                            bnet.protocol.channel.Message.Builder builder2 = bnet.protocol.channel.Message.CreateBuilder();
                            if (this.result.hasMessage)
                            {
                                builder2.MergeFrom(this.Message);
                            }
                            input.ReadMessage(builder2, extensionRegistry);
                            this.Message = builder2.BuildPartial();
                            continue;
                        }
                        case 0x18:
                            break;

                        default:
                        {
                            if (WireFormat.IsEndGroupTag(num))
                            {
                                return this;
                            }
                            this.ParseUnknownField(input, extensionRegistry, num, str);
                            continue;
                        }
                    }
                    this.result.hasRequiredPrivileges = input.ReadUInt64(ref this.result.requiredPrivileges_);
                }
                return this;
            }

            public SendMessageNotification.Builder MergeMessage(bnet.protocol.channel.Message value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasMessage && (this.result.message_ != bnet.protocol.channel.Message.DefaultInstance))
                {
                    this.result.message_ = bnet.protocol.channel.Message.CreateBuilder(this.result.message_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.message_ = value;
                }
                this.result.hasMessage = true;
                return this;
            }

            private SendMessageNotification PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    SendMessageNotification result = this.result;
                    this.result = new SendMessageNotification();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public SendMessageNotification.Builder SetAgentId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasAgentId = true;
                this.result.agentId_ = value;
                return this;
            }

            public SendMessageNotification.Builder SetAgentId(EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasAgentId = true;
                this.result.agentId_ = builderForValue.Build();
                return this;
            }

            public SendMessageNotification.Builder SetMessage(bnet.protocol.channel.Message value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasMessage = true;
                this.result.message_ = value;
                return this;
            }

            public SendMessageNotification.Builder SetMessage(bnet.protocol.channel.Message.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasMessage = true;
                this.result.message_ = builderForValue.Build();
                return this;
            }

            [CLSCompliant(false)]
            public SendMessageNotification.Builder SetRequiredPrivileges(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasRequiredPrivileges = true;
                this.result.requiredPrivileges_ = value;
                return this;
            }

            public EntityId AgentId
            {
                get
                {
                    return this.result.AgentId;
                }
                set
                {
                    this.SetAgentId(value);
                }
            }

            public override SendMessageNotification DefaultInstanceForType
            {
                get
                {
                    return SendMessageNotification.DefaultInstance;
                }
            }

            public bool HasAgentId
            {
                get
                {
                    return this.result.hasAgentId;
                }
            }

            public bool HasMessage
            {
                get
                {
                    return this.result.hasMessage;
                }
            }

            public bool HasRequiredPrivileges
            {
                get
                {
                    return this.result.hasRequiredPrivileges;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public bnet.protocol.channel.Message Message
            {
                get
                {
                    return this.result.Message;
                }
                set
                {
                    this.SetMessage(value);
                }
            }

            protected override SendMessageNotification MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            [CLSCompliant(false)]
            public ulong RequiredPrivileges
            {
                get
                {
                    return this.result.RequiredPrivileges;
                }
                set
                {
                    this.SetRequiredPrivileges(value);
                }
            }

            protected override SendMessageNotification.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

