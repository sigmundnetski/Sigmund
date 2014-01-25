namespace bnet.protocol.presence
{
    using bnet.protocol;
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class UnsubscribeRequest : GeneratedMessageLite<UnsubscribeRequest, Builder>
    {
        private static readonly string[] _unsubscribeRequestFieldNames = new string[] { "agent_id", "entity_id" };
        private static readonly uint[] _unsubscribeRequestFieldTags = new uint[] { 10, 0x12 };
        private bnet.protocol.EntityId agentId_;
        public const int AgentIdFieldNumber = 1;
        private static readonly UnsubscribeRequest defaultInstance = new UnsubscribeRequest().MakeReadOnly();
        private bnet.protocol.EntityId entityId_;
        public const int EntityIdFieldNumber = 2;
        private bool hasAgentId;
        private bool hasEntityId;
        private int memoizedSerializedSize = -1;

        static UnsubscribeRequest()
        {
            object.ReferenceEquals(PresenceService.Descriptor, null);
        }

        private UnsubscribeRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(UnsubscribeRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            UnsubscribeRequest request = obj as UnsubscribeRequest;
            if (request == null)
            {
                return false;
            }
            if ((this.hasAgentId != request.hasAgentId) || (this.hasAgentId && !this.agentId_.Equals(request.agentId_)))
            {
                return false;
            }
            return ((this.hasEntityId == request.hasEntityId) && (!this.hasEntityId || this.entityId_.Equals(request.entityId_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasAgentId)
            {
                hashCode ^= this.agentId_.GetHashCode();
            }
            if (this.hasEntityId)
            {
                hashCode ^= this.entityId_.GetHashCode();
            }
            return hashCode;
        }

        private UnsubscribeRequest MakeReadOnly()
        {
            return this;
        }

        public static UnsubscribeRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static UnsubscribeRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static UnsubscribeRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static UnsubscribeRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static UnsubscribeRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static UnsubscribeRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static UnsubscribeRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static UnsubscribeRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static UnsubscribeRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static UnsubscribeRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<UnsubscribeRequest, Builder>.PrintField("agent_id", this.hasAgentId, this.agentId_, writer);
            GeneratedMessageLite<UnsubscribeRequest, Builder>.PrintField("entity_id", this.hasEntityId, this.entityId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _unsubscribeRequestFieldNames;
            if (this.hasAgentId)
            {
                output.WriteMessage(1, strArray[0], this.AgentId);
            }
            if (this.hasEntityId)
            {
                output.WriteMessage(2, strArray[1], this.EntityId);
            }
        }

        public bnet.protocol.EntityId AgentId
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.agentId_ != null)
                {
                    goto Label_0012;
                }
                return bnet.protocol.EntityId.DefaultInstance;
            }
        }

        public static UnsubscribeRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override UnsubscribeRequest DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bnet.protocol.EntityId EntityId
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.entityId_ != null)
                {
                    goto Label_0012;
                }
                return bnet.protocol.EntityId.DefaultInstance;
            }
        }

        public bool HasAgentId
        {
            get
            {
                return this.hasAgentId;
            }
        }

        public bool HasEntityId
        {
            get
            {
                return this.hasEntityId;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasEntityId)
                {
                    return false;
                }
                if (this.HasAgentId && !this.AgentId.IsInitialized)
                {
                    return false;
                }
                if (!this.EntityId.IsInitialized)
                {
                    return false;
                }
                return true;
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
                    if (this.hasEntityId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, this.EntityId);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override UnsubscribeRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<UnsubscribeRequest, UnsubscribeRequest.Builder>
        {
            private UnsubscribeRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = UnsubscribeRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(UnsubscribeRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override UnsubscribeRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override UnsubscribeRequest.Builder Clear()
            {
                this.result = UnsubscribeRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public UnsubscribeRequest.Builder ClearAgentId()
            {
                this.PrepareBuilder();
                this.result.hasAgentId = false;
                this.result.agentId_ = null;
                return this;
            }

            public UnsubscribeRequest.Builder ClearEntityId()
            {
                this.PrepareBuilder();
                this.result.hasEntityId = false;
                this.result.entityId_ = null;
                return this;
            }

            public override UnsubscribeRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new UnsubscribeRequest.Builder(this.result);
                }
                return new UnsubscribeRequest.Builder().MergeFrom(this.result);
            }

            public UnsubscribeRequest.Builder MergeAgentId(bnet.protocol.EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasAgentId && (this.result.agentId_ != bnet.protocol.EntityId.DefaultInstance))
                {
                    this.result.agentId_ = bnet.protocol.EntityId.CreateBuilder(this.result.agentId_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.agentId_ = value;
                }
                this.result.hasAgentId = true;
                return this;
            }

            public UnsubscribeRequest.Builder MergeEntityId(bnet.protocol.EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasEntityId && (this.result.entityId_ != bnet.protocol.EntityId.DefaultInstance))
                {
                    this.result.entityId_ = bnet.protocol.EntityId.CreateBuilder(this.result.entityId_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.entityId_ = value;
                }
                this.result.hasEntityId = true;
                return this;
            }

            public override UnsubscribeRequest.Builder MergeFrom(UnsubscribeRequest other)
            {
                if (other != UnsubscribeRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAgentId)
                    {
                        this.MergeAgentId(other.AgentId);
                    }
                    if (other.HasEntityId)
                    {
                        this.MergeEntityId(other.EntityId);
                    }
                }
                return this;
            }

            public override UnsubscribeRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override UnsubscribeRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is UnsubscribeRequest)
                {
                    return this.MergeFrom((UnsubscribeRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override UnsubscribeRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(UnsubscribeRequest._unsubscribeRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = UnsubscribeRequest._unsubscribeRequestFieldTags[index];
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
                            bnet.protocol.EntityId.Builder builder = bnet.protocol.EntityId.CreateBuilder();
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
                            bnet.protocol.EntityId.Builder builder2 = bnet.protocol.EntityId.CreateBuilder();
                            if (this.result.hasEntityId)
                            {
                                builder2.MergeFrom(this.EntityId);
                            }
                            input.ReadMessage(builder2, extensionRegistry);
                            this.EntityId = builder2.BuildPartial();
                            continue;
                        }
                    }
                    if (WireFormat.IsEndGroupTag(num))
                    {
                        return this;
                    }
                    this.ParseUnknownField(input, extensionRegistry, num, str);
                }
                return this;
            }

            private UnsubscribeRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    UnsubscribeRequest result = this.result;
                    this.result = new UnsubscribeRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public UnsubscribeRequest.Builder SetAgentId(bnet.protocol.EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasAgentId = true;
                this.result.agentId_ = value;
                return this;
            }

            public UnsubscribeRequest.Builder SetAgentId(bnet.protocol.EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasAgentId = true;
                this.result.agentId_ = builderForValue.Build();
                return this;
            }

            public UnsubscribeRequest.Builder SetEntityId(bnet.protocol.EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasEntityId = true;
                this.result.entityId_ = value;
                return this;
            }

            public UnsubscribeRequest.Builder SetEntityId(bnet.protocol.EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasEntityId = true;
                this.result.entityId_ = builderForValue.Build();
                return this;
            }

            public bnet.protocol.EntityId AgentId
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

            public override UnsubscribeRequest DefaultInstanceForType
            {
                get
                {
                    return UnsubscribeRequest.DefaultInstance;
                }
            }

            public bnet.protocol.EntityId EntityId
            {
                get
                {
                    return this.result.EntityId;
                }
                set
                {
                    this.SetEntityId(value);
                }
            }

            public bool HasAgentId
            {
                get
                {
                    return this.result.hasAgentId;
                }
            }

            public bool HasEntityId
            {
                get
                {
                    return this.result.hasEntityId;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override UnsubscribeRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override UnsubscribeRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

