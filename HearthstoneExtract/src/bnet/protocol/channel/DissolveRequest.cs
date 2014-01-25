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
    public sealed class DissolveRequest : GeneratedMessageLite<DissolveRequest, Builder>
    {
        private static readonly string[] _dissolveRequestFieldNames = new string[] { "agent_id", "reason" };
        private static readonly uint[] _dissolveRequestFieldTags = new uint[] { 10, 0x10 };
        private EntityId agentId_;
        public const int AgentIdFieldNumber = 1;
        private static readonly DissolveRequest defaultInstance = new DissolveRequest().MakeReadOnly();
        private bool hasAgentId;
        private bool hasReason;
        private int memoizedSerializedSize = -1;
        private uint reason_;
        public const int ReasonFieldNumber = 2;

        static DissolveRequest()
        {
            object.ReferenceEquals(ChannelService.Descriptor, null);
        }

        private DissolveRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DissolveRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DissolveRequest request = obj as DissolveRequest;
            if (request == null)
            {
                return false;
            }
            if ((this.hasAgentId != request.hasAgentId) || (this.hasAgentId && !this.agentId_.Equals(request.agentId_)))
            {
                return false;
            }
            return ((this.hasReason == request.hasReason) && (!this.hasReason || this.reason_.Equals(request.reason_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasAgentId)
            {
                hashCode ^= this.agentId_.GetHashCode();
            }
            if (this.hasReason)
            {
                hashCode ^= this.reason_.GetHashCode();
            }
            return hashCode;
        }

        private DissolveRequest MakeReadOnly()
        {
            return this;
        }

        public static DissolveRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DissolveRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DissolveRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DissolveRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DissolveRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DissolveRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DissolveRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DissolveRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DissolveRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DissolveRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DissolveRequest, Builder>.PrintField("agent_id", this.hasAgentId, this.agentId_, writer);
            GeneratedMessageLite<DissolveRequest, Builder>.PrintField("reason", this.hasReason, this.reason_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _dissolveRequestFieldNames;
            if (this.hasAgentId)
            {
                output.WriteMessage(1, strArray[0], this.AgentId);
            }
            if (this.hasReason)
            {
                output.WriteUInt32(2, strArray[1], this.Reason);
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

        public static DissolveRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DissolveRequest DefaultInstanceForType
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

        public bool HasReason
        {
            get
            {
                return this.hasReason;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (this.HasAgentId && !this.AgentId.IsInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        [CLSCompliant(false)]
        public uint Reason
        {
            get
            {
                return this.reason_;
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
                    if (this.hasReason)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(2, this.Reason);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override DissolveRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<DissolveRequest, DissolveRequest.Builder>
        {
            private DissolveRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DissolveRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DissolveRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override DissolveRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DissolveRequest.Builder Clear()
            {
                this.result = DissolveRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DissolveRequest.Builder ClearAgentId()
            {
                this.PrepareBuilder();
                this.result.hasAgentId = false;
                this.result.agentId_ = null;
                return this;
            }

            public DissolveRequest.Builder ClearReason()
            {
                this.PrepareBuilder();
                this.result.hasReason = false;
                this.result.reason_ = 0;
                return this;
            }

            public override DissolveRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DissolveRequest.Builder(this.result);
                }
                return new DissolveRequest.Builder().MergeFrom(this.result);
            }

            public DissolveRequest.Builder MergeAgentId(EntityId value)
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

            public override DissolveRequest.Builder MergeFrom(DissolveRequest other)
            {
                if (other != DissolveRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAgentId)
                    {
                        this.MergeAgentId(other.AgentId);
                    }
                    if (other.HasReason)
                    {
                        this.Reason = other.Reason;
                    }
                }
                return this;
            }

            public override DissolveRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DissolveRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is DissolveRequest)
                {
                    return this.MergeFrom((DissolveRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DissolveRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DissolveRequest._dissolveRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DissolveRequest._dissolveRequestFieldTags[index];
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
                        case 0x10:
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
                    this.result.hasReason = input.ReadUInt32(ref this.result.reason_);
                }
                return this;
            }

            private DissolveRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DissolveRequest result = this.result;
                    this.result = new DissolveRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DissolveRequest.Builder SetAgentId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasAgentId = true;
                this.result.agentId_ = value;
                return this;
            }

            public DissolveRequest.Builder SetAgentId(EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasAgentId = true;
                this.result.agentId_ = builderForValue.Build();
                return this;
            }

            [CLSCompliant(false)]
            public DissolveRequest.Builder SetReason(uint value)
            {
                this.PrepareBuilder();
                this.result.hasReason = true;
                this.result.reason_ = value;
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

            public override DissolveRequest DefaultInstanceForType
            {
                get
                {
                    return DissolveRequest.DefaultInstance;
                }
            }

            public bool HasAgentId
            {
                get
                {
                    return this.result.hasAgentId;
                }
            }

            public bool HasReason
            {
                get
                {
                    return this.result.hasReason;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override DissolveRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            [CLSCompliant(false)]
            public uint Reason
            {
                get
                {
                    return this.result.Reason;
                }
                set
                {
                    this.SetReason(value);
                }
            }

            protected override DissolveRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

