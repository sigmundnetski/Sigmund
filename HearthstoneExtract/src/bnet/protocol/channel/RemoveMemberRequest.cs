namespace bnet.protocol.channel
{
    using bnet.protocol;
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class RemoveMemberRequest : GeneratedMessageLite<RemoveMemberRequest, Builder>
    {
        private static readonly string[] _removeMemberRequestFieldNames = new string[] { "agent_id", "member_id", "reason" };
        private static readonly uint[] _removeMemberRequestFieldTags = new uint[] { 10, 0x12, 0x18 };
        private EntityId agentId_;
        public const int AgentIdFieldNumber = 1;
        private static readonly RemoveMemberRequest defaultInstance = new RemoveMemberRequest().MakeReadOnly();
        private bool hasAgentId;
        private bool hasMemberId;
        private bool hasReason;
        private EntityId memberId_;
        public const int MemberIdFieldNumber = 2;
        private int memoizedSerializedSize = -1;
        private uint reason_;
        public const int ReasonFieldNumber = 3;

        static RemoveMemberRequest()
        {
            object.ReferenceEquals(ChannelService.Descriptor, null);
        }

        private RemoveMemberRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(RemoveMemberRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            RemoveMemberRequest request = obj as RemoveMemberRequest;
            if (request == null)
            {
                return false;
            }
            if ((this.hasAgentId != request.hasAgentId) || (this.hasAgentId && !this.agentId_.Equals(request.agentId_)))
            {
                return false;
            }
            if ((this.hasMemberId != request.hasMemberId) || (this.hasMemberId && !this.memberId_.Equals(request.memberId_)))
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
            if (this.hasMemberId)
            {
                hashCode ^= this.memberId_.GetHashCode();
            }
            if (this.hasReason)
            {
                hashCode ^= this.reason_.GetHashCode();
            }
            return hashCode;
        }

        private RemoveMemberRequest MakeReadOnly()
        {
            return this;
        }

        public static RemoveMemberRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static RemoveMemberRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static RemoveMemberRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static RemoveMemberRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static RemoveMemberRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static RemoveMemberRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static RemoveMemberRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static RemoveMemberRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static RemoveMemberRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static RemoveMemberRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<RemoveMemberRequest, Builder>.PrintField("agent_id", this.hasAgentId, this.agentId_, writer);
            GeneratedMessageLite<RemoveMemberRequest, Builder>.PrintField("member_id", this.hasMemberId, this.memberId_, writer);
            GeneratedMessageLite<RemoveMemberRequest, Builder>.PrintField("reason", this.hasReason, this.reason_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _removeMemberRequestFieldNames;
            if (this.hasAgentId)
            {
                output.WriteMessage(1, strArray[0], this.AgentId);
            }
            if (this.hasMemberId)
            {
                output.WriteMessage(2, strArray[1], this.MemberId);
            }
            if (this.hasReason)
            {
                output.WriteUInt32(3, strArray[2], this.Reason);
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

        public static RemoveMemberRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override RemoveMemberRequest DefaultInstanceForType
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

        public bool HasMemberId
        {
            get
            {
                return this.hasMemberId;
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
                if (!this.hasMemberId)
                {
                    return false;
                }
                if (this.HasAgentId && !this.AgentId.IsInitialized)
                {
                    return false;
                }
                if (!this.MemberId.IsInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        public EntityId MemberId
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.memberId_ != null)
                {
                    goto Label_0012;
                }
                return EntityId.DefaultInstance;
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
                    if (this.hasMemberId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, this.MemberId);
                    }
                    if (this.hasReason)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(3, this.Reason);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override RemoveMemberRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<RemoveMemberRequest, RemoveMemberRequest.Builder>
        {
            private RemoveMemberRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = RemoveMemberRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(RemoveMemberRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override RemoveMemberRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override RemoveMemberRequest.Builder Clear()
            {
                this.result = RemoveMemberRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public RemoveMemberRequest.Builder ClearAgentId()
            {
                this.PrepareBuilder();
                this.result.hasAgentId = false;
                this.result.agentId_ = null;
                return this;
            }

            public RemoveMemberRequest.Builder ClearMemberId()
            {
                this.PrepareBuilder();
                this.result.hasMemberId = false;
                this.result.memberId_ = null;
                return this;
            }

            public RemoveMemberRequest.Builder ClearReason()
            {
                this.PrepareBuilder();
                this.result.hasReason = false;
                this.result.reason_ = 0;
                return this;
            }

            public override RemoveMemberRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new RemoveMemberRequest.Builder(this.result);
                }
                return new RemoveMemberRequest.Builder().MergeFrom(this.result);
            }

            public RemoveMemberRequest.Builder MergeAgentId(EntityId value)
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

            public override RemoveMemberRequest.Builder MergeFrom(RemoveMemberRequest other)
            {
                if (other != RemoveMemberRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAgentId)
                    {
                        this.MergeAgentId(other.AgentId);
                    }
                    if (other.HasMemberId)
                    {
                        this.MergeMemberId(other.MemberId);
                    }
                    if (other.HasReason)
                    {
                        this.Reason = other.Reason;
                    }
                }
                return this;
            }

            public override RemoveMemberRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override RemoveMemberRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is RemoveMemberRequest)
                {
                    return this.MergeFrom((RemoveMemberRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override RemoveMemberRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(RemoveMemberRequest._removeMemberRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = RemoveMemberRequest._removeMemberRequestFieldTags[index];
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
                            EntityId.Builder builder2 = EntityId.CreateBuilder();
                            if (this.result.hasMemberId)
                            {
                                builder2.MergeFrom(this.MemberId);
                            }
                            input.ReadMessage(builder2, extensionRegistry);
                            this.MemberId = builder2.BuildPartial();
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
                    this.result.hasReason = input.ReadUInt32(ref this.result.reason_);
                }
                return this;
            }

            public RemoveMemberRequest.Builder MergeMemberId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasMemberId && (this.result.memberId_ != EntityId.DefaultInstance))
                {
                    this.result.memberId_ = EntityId.CreateBuilder(this.result.memberId_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.memberId_ = value;
                }
                this.result.hasMemberId = true;
                return this;
            }

            private RemoveMemberRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    RemoveMemberRequest result = this.result;
                    this.result = new RemoveMemberRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public RemoveMemberRequest.Builder SetAgentId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasAgentId = true;
                this.result.agentId_ = value;
                return this;
            }

            public RemoveMemberRequest.Builder SetAgentId(EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasAgentId = true;
                this.result.agentId_ = builderForValue.Build();
                return this;
            }

            public RemoveMemberRequest.Builder SetMemberId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasMemberId = true;
                this.result.memberId_ = value;
                return this;
            }

            public RemoveMemberRequest.Builder SetMemberId(EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasMemberId = true;
                this.result.memberId_ = builderForValue.Build();
                return this;
            }

            [CLSCompliant(false)]
            public RemoveMemberRequest.Builder SetReason(uint value)
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

            public override RemoveMemberRequest DefaultInstanceForType
            {
                get
                {
                    return RemoveMemberRequest.DefaultInstance;
                }
            }

            public bool HasAgentId
            {
                get
                {
                    return this.result.hasAgentId;
                }
            }

            public bool HasMemberId
            {
                get
                {
                    return this.result.hasMemberId;
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

            public EntityId MemberId
            {
                get
                {
                    return this.result.MemberId;
                }
                set
                {
                    this.SetMemberId(value);
                }
            }

            protected override RemoveMemberRequest MessageBeingBuilt
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

            protected override RemoveMemberRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

