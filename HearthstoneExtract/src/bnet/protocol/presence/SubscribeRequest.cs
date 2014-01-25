namespace bnet.protocol.presence
{
    using bnet.protocol;
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class SubscribeRequest : GeneratedMessageLite<SubscribeRequest, Builder>
    {
        private static readonly string[] _subscribeRequestFieldNames = new string[] { "agent_id", "entity_id", "object_id" };
        private static readonly uint[] _subscribeRequestFieldTags = new uint[] { 10, 0x12, 0x18 };
        private bnet.protocol.EntityId agentId_;
        public const int AgentIdFieldNumber = 1;
        private static readonly SubscribeRequest defaultInstance = new SubscribeRequest().MakeReadOnly();
        private bnet.protocol.EntityId entityId_;
        public const int EntityIdFieldNumber = 2;
        private bool hasAgentId;
        private bool hasEntityId;
        private bool hasObjectId;
        private int memoizedSerializedSize = -1;
        private ulong objectId_;
        public const int ObjectIdFieldNumber = 3;

        static SubscribeRequest()
        {
            object.ReferenceEquals(PresenceService.Descriptor, null);
        }

        private SubscribeRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(SubscribeRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            SubscribeRequest request = obj as SubscribeRequest;
            if (request == null)
            {
                return false;
            }
            if ((this.hasAgentId != request.hasAgentId) || (this.hasAgentId && !this.agentId_.Equals(request.agentId_)))
            {
                return false;
            }
            if ((this.hasEntityId != request.hasEntityId) || (this.hasEntityId && !this.entityId_.Equals(request.entityId_)))
            {
                return false;
            }
            return ((this.hasObjectId == request.hasObjectId) && (!this.hasObjectId || this.objectId_.Equals(request.objectId_)));
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
            if (this.hasObjectId)
            {
                hashCode ^= this.objectId_.GetHashCode();
            }
            return hashCode;
        }

        private SubscribeRequest MakeReadOnly()
        {
            return this;
        }

        public static SubscribeRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static SubscribeRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static SubscribeRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static SubscribeRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static SubscribeRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static SubscribeRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static SubscribeRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static SubscribeRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static SubscribeRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static SubscribeRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<SubscribeRequest, Builder>.PrintField("agent_id", this.hasAgentId, this.agentId_, writer);
            GeneratedMessageLite<SubscribeRequest, Builder>.PrintField("entity_id", this.hasEntityId, this.entityId_, writer);
            GeneratedMessageLite<SubscribeRequest, Builder>.PrintField("object_id", this.hasObjectId, this.objectId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _subscribeRequestFieldNames;
            if (this.hasAgentId)
            {
                output.WriteMessage(1, strArray[0], this.AgentId);
            }
            if (this.hasEntityId)
            {
                output.WriteMessage(2, strArray[1], this.EntityId);
            }
            if (this.hasObjectId)
            {
                output.WriteUInt64(3, strArray[2], this.ObjectId);
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

        public static SubscribeRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override SubscribeRequest DefaultInstanceForType
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

        public bool HasObjectId
        {
            get
            {
                return this.hasObjectId;
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
                if (!this.hasObjectId)
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

        [CLSCompliant(false)]
        public ulong ObjectId
        {
            get
            {
                return this.objectId_;
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
                    if (this.hasObjectId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(3, this.ObjectId);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override SubscribeRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<SubscribeRequest, SubscribeRequest.Builder>
        {
            private SubscribeRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = SubscribeRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(SubscribeRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override SubscribeRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override SubscribeRequest.Builder Clear()
            {
                this.result = SubscribeRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public SubscribeRequest.Builder ClearAgentId()
            {
                this.PrepareBuilder();
                this.result.hasAgentId = false;
                this.result.agentId_ = null;
                return this;
            }

            public SubscribeRequest.Builder ClearEntityId()
            {
                this.PrepareBuilder();
                this.result.hasEntityId = false;
                this.result.entityId_ = null;
                return this;
            }

            public SubscribeRequest.Builder ClearObjectId()
            {
                this.PrepareBuilder();
                this.result.hasObjectId = false;
                this.result.objectId_ = 0L;
                return this;
            }

            public override SubscribeRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new SubscribeRequest.Builder(this.result);
                }
                return new SubscribeRequest.Builder().MergeFrom(this.result);
            }

            public SubscribeRequest.Builder MergeAgentId(bnet.protocol.EntityId value)
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

            public SubscribeRequest.Builder MergeEntityId(bnet.protocol.EntityId value)
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

            public override SubscribeRequest.Builder MergeFrom(SubscribeRequest other)
            {
                if (other != SubscribeRequest.DefaultInstance)
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
                    if (other.HasObjectId)
                    {
                        this.ObjectId = other.ObjectId;
                    }
                }
                return this;
            }

            public override SubscribeRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override SubscribeRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is SubscribeRequest)
                {
                    return this.MergeFrom((SubscribeRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override SubscribeRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(SubscribeRequest._subscribeRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = SubscribeRequest._subscribeRequestFieldTags[index];
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
                    this.result.hasObjectId = input.ReadUInt64(ref this.result.objectId_);
                }
                return this;
            }

            private SubscribeRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    SubscribeRequest result = this.result;
                    this.result = new SubscribeRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public SubscribeRequest.Builder SetAgentId(bnet.protocol.EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasAgentId = true;
                this.result.agentId_ = value;
                return this;
            }

            public SubscribeRequest.Builder SetAgentId(bnet.protocol.EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasAgentId = true;
                this.result.agentId_ = builderForValue.Build();
                return this;
            }

            public SubscribeRequest.Builder SetEntityId(bnet.protocol.EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasEntityId = true;
                this.result.entityId_ = value;
                return this;
            }

            public SubscribeRequest.Builder SetEntityId(bnet.protocol.EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasEntityId = true;
                this.result.entityId_ = builderForValue.Build();
                return this;
            }

            [CLSCompliant(false)]
            public SubscribeRequest.Builder SetObjectId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasObjectId = true;
                this.result.objectId_ = value;
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

            public override SubscribeRequest DefaultInstanceForType
            {
                get
                {
                    return SubscribeRequest.DefaultInstance;
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

            public bool HasObjectId
            {
                get
                {
                    return this.result.hasObjectId;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override SubscribeRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            [CLSCompliant(false)]
            public ulong ObjectId
            {
                get
                {
                    return this.result.ObjectId;
                }
                set
                {
                    this.SetObjectId(value);
                }
            }

            protected override SubscribeRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

