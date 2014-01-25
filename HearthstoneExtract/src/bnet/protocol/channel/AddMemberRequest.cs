namespace bnet.protocol.channel
{
    using bnet.protocol;
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class AddMemberRequest : GeneratedMessageLite<AddMemberRequest, Builder>
    {
        private static readonly string[] _addMemberRequestFieldNames = new string[] { "agent_id", "member_identity", "member_state", "object_id" };
        private static readonly uint[] _addMemberRequestFieldTags = new uint[] { 10, 0x12, 0x1a, 0x20 };
        private EntityId agentId_;
        public const int AgentIdFieldNumber = 1;
        private static readonly AddMemberRequest defaultInstance = new AddMemberRequest().MakeReadOnly();
        private bool hasAgentId;
        private bool hasMemberIdentity;
        private bool hasMemberState;
        private bool hasObjectId;
        private Identity memberIdentity_;
        public const int MemberIdentityFieldNumber = 2;
        private bnet.protocol.channel.MemberState memberState_;
        public const int MemberStateFieldNumber = 3;
        private int memoizedSerializedSize = -1;
        private ulong objectId_;
        public const int ObjectIdFieldNumber = 4;

        static AddMemberRequest()
        {
            object.ReferenceEquals(ChannelService.Descriptor, null);
        }

        private AddMemberRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AddMemberRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AddMemberRequest request = obj as AddMemberRequest;
            if (request == null)
            {
                return false;
            }
            if ((this.hasAgentId != request.hasAgentId) || (this.hasAgentId && !this.agentId_.Equals(request.agentId_)))
            {
                return false;
            }
            if ((this.hasMemberIdentity != request.hasMemberIdentity) || (this.hasMemberIdentity && !this.memberIdentity_.Equals(request.memberIdentity_)))
            {
                return false;
            }
            if ((this.hasMemberState != request.hasMemberState) || (this.hasMemberState && !this.memberState_.Equals(request.memberState_)))
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
            if (this.hasMemberIdentity)
            {
                hashCode ^= this.memberIdentity_.GetHashCode();
            }
            if (this.hasMemberState)
            {
                hashCode ^= this.memberState_.GetHashCode();
            }
            if (this.hasObjectId)
            {
                hashCode ^= this.objectId_.GetHashCode();
            }
            return hashCode;
        }

        private AddMemberRequest MakeReadOnly()
        {
            return this;
        }

        public static AddMemberRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AddMemberRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AddMemberRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AddMemberRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AddMemberRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AddMemberRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AddMemberRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AddMemberRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AddMemberRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AddMemberRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AddMemberRequest, Builder>.PrintField("agent_id", this.hasAgentId, this.agentId_, writer);
            GeneratedMessageLite<AddMemberRequest, Builder>.PrintField("member_identity", this.hasMemberIdentity, this.memberIdentity_, writer);
            GeneratedMessageLite<AddMemberRequest, Builder>.PrintField("member_state", this.hasMemberState, this.memberState_, writer);
            GeneratedMessageLite<AddMemberRequest, Builder>.PrintField("object_id", this.hasObjectId, this.objectId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _addMemberRequestFieldNames;
            if (this.hasAgentId)
            {
                output.WriteMessage(1, strArray[0], this.AgentId);
            }
            if (this.hasMemberIdentity)
            {
                output.WriteMessage(2, strArray[1], this.MemberIdentity);
            }
            if (this.hasMemberState)
            {
                output.WriteMessage(3, strArray[2], this.MemberState);
            }
            if (this.hasObjectId)
            {
                output.WriteUInt64(4, strArray[3], this.ObjectId);
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

        public static AddMemberRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AddMemberRequest DefaultInstanceForType
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

        public bool HasMemberIdentity
        {
            get
            {
                return this.hasMemberIdentity;
            }
        }

        public bool HasMemberState
        {
            get
            {
                return this.hasMemberState;
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
                if (!this.hasMemberIdentity)
                {
                    return false;
                }
                if (!this.hasMemberState)
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
                if (!this.MemberIdentity.IsInitialized)
                {
                    return false;
                }
                if (!this.MemberState.IsInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        public Identity MemberIdentity
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.memberIdentity_ != null)
                {
                    goto Label_0012;
                }
                return Identity.DefaultInstance;
            }
        }

        public bnet.protocol.channel.MemberState MemberState
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.memberState_ != null)
                {
                    goto Label_0012;
                }
                return bnet.protocol.channel.MemberState.DefaultInstance;
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
                    if (this.hasMemberIdentity)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, this.MemberIdentity);
                    }
                    if (this.hasMemberState)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(3, this.MemberState);
                    }
                    if (this.hasObjectId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(4, this.ObjectId);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override AddMemberRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<AddMemberRequest, AddMemberRequest.Builder>
        {
            private AddMemberRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AddMemberRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AddMemberRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override AddMemberRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AddMemberRequest.Builder Clear()
            {
                this.result = AddMemberRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AddMemberRequest.Builder ClearAgentId()
            {
                this.PrepareBuilder();
                this.result.hasAgentId = false;
                this.result.agentId_ = null;
                return this;
            }

            public AddMemberRequest.Builder ClearMemberIdentity()
            {
                this.PrepareBuilder();
                this.result.hasMemberIdentity = false;
                this.result.memberIdentity_ = null;
                return this;
            }

            public AddMemberRequest.Builder ClearMemberState()
            {
                this.PrepareBuilder();
                this.result.hasMemberState = false;
                this.result.memberState_ = null;
                return this;
            }

            public AddMemberRequest.Builder ClearObjectId()
            {
                this.PrepareBuilder();
                this.result.hasObjectId = false;
                this.result.objectId_ = 0L;
                return this;
            }

            public override AddMemberRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AddMemberRequest.Builder(this.result);
                }
                return new AddMemberRequest.Builder().MergeFrom(this.result);
            }

            public AddMemberRequest.Builder MergeAgentId(EntityId value)
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

            public override AddMemberRequest.Builder MergeFrom(AddMemberRequest other)
            {
                if (other != AddMemberRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAgentId)
                    {
                        this.MergeAgentId(other.AgentId);
                    }
                    if (other.HasMemberIdentity)
                    {
                        this.MergeMemberIdentity(other.MemberIdentity);
                    }
                    if (other.HasMemberState)
                    {
                        this.MergeMemberState(other.MemberState);
                    }
                    if (other.HasObjectId)
                    {
                        this.ObjectId = other.ObjectId;
                    }
                }
                return this;
            }

            public override AddMemberRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AddMemberRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is AddMemberRequest)
                {
                    return this.MergeFrom((AddMemberRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AddMemberRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AddMemberRequest._addMemberRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AddMemberRequest._addMemberRequestFieldTags[index];
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
                            Identity.Builder builder2 = Identity.CreateBuilder();
                            if (this.result.hasMemberIdentity)
                            {
                                builder2.MergeFrom(this.MemberIdentity);
                            }
                            input.ReadMessage(builder2, extensionRegistry);
                            this.MemberIdentity = builder2.BuildPartial();
                            continue;
                        }
                        case 0x1a:
                        {
                            bnet.protocol.channel.MemberState.Builder builder3 = bnet.protocol.channel.MemberState.CreateBuilder();
                            if (this.result.hasMemberState)
                            {
                                builder3.MergeFrom(this.MemberState);
                            }
                            input.ReadMessage(builder3, extensionRegistry);
                            this.MemberState = builder3.BuildPartial();
                            continue;
                        }
                        case 0x20:
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

            public AddMemberRequest.Builder MergeMemberIdentity(Identity value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasMemberIdentity && (this.result.memberIdentity_ != Identity.DefaultInstance))
                {
                    this.result.memberIdentity_ = Identity.CreateBuilder(this.result.memberIdentity_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.memberIdentity_ = value;
                }
                this.result.hasMemberIdentity = true;
                return this;
            }

            public AddMemberRequest.Builder MergeMemberState(bnet.protocol.channel.MemberState value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasMemberState && (this.result.memberState_ != bnet.protocol.channel.MemberState.DefaultInstance))
                {
                    this.result.memberState_ = bnet.protocol.channel.MemberState.CreateBuilder(this.result.memberState_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.memberState_ = value;
                }
                this.result.hasMemberState = true;
                return this;
            }

            private AddMemberRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AddMemberRequest result = this.result;
                    this.result = new AddMemberRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public AddMemberRequest.Builder SetAgentId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasAgentId = true;
                this.result.agentId_ = value;
                return this;
            }

            public AddMemberRequest.Builder SetAgentId(EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasAgentId = true;
                this.result.agentId_ = builderForValue.Build();
                return this;
            }

            public AddMemberRequest.Builder SetMemberIdentity(Identity value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasMemberIdentity = true;
                this.result.memberIdentity_ = value;
                return this;
            }

            public AddMemberRequest.Builder SetMemberIdentity(Identity.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasMemberIdentity = true;
                this.result.memberIdentity_ = builderForValue.Build();
                return this;
            }

            public AddMemberRequest.Builder SetMemberState(bnet.protocol.channel.MemberState value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasMemberState = true;
                this.result.memberState_ = value;
                return this;
            }

            public AddMemberRequest.Builder SetMemberState(bnet.protocol.channel.MemberState.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasMemberState = true;
                this.result.memberState_ = builderForValue.Build();
                return this;
            }

            [CLSCompliant(false)]
            public AddMemberRequest.Builder SetObjectId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasObjectId = true;
                this.result.objectId_ = value;
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

            public override AddMemberRequest DefaultInstanceForType
            {
                get
                {
                    return AddMemberRequest.DefaultInstance;
                }
            }

            public bool HasAgentId
            {
                get
                {
                    return this.result.hasAgentId;
                }
            }

            public bool HasMemberIdentity
            {
                get
                {
                    return this.result.hasMemberIdentity;
                }
            }

            public bool HasMemberState
            {
                get
                {
                    return this.result.hasMemberState;
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

            public Identity MemberIdentity
            {
                get
                {
                    return this.result.MemberIdentity;
                }
                set
                {
                    this.SetMemberIdentity(value);
                }
            }

            public bnet.protocol.channel.MemberState MemberState
            {
                get
                {
                    return this.result.MemberState;
                }
                set
                {
                    this.SetMemberState(value);
                }
            }

            protected override AddMemberRequest MessageBeingBuilt
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

            protected override AddMemberRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

