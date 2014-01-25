namespace bnet.protocol.invitation
{
    using bnet.protocol;
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class SendInvitationRequest : GeneratedMessageLite<SendInvitationRequest, Builder>
    {
        private static readonly string[] _sendInvitationRequestFieldNames = new string[] { "agent_identity", "agent_info", "params", "target", "target_id" };
        private static readonly uint[] _sendInvitationRequestFieldTags = new uint[] { 10, 0x22, 0x1a, 0x2a, 0x12 };
        private Identity agentIdentity_;
        public const int AgentIdentityFieldNumber = 1;
        private AccountInfo agentInfo_;
        public const int AgentInfoFieldNumber = 4;
        private static readonly SendInvitationRequest defaultInstance = new SendInvitationRequest().MakeReadOnly();
        private bool hasAgentIdentity;
        private bool hasAgentInfo;
        private bool hasParams;
        private bool hasTarget;
        private bool hasTargetId;
        private int memoizedSerializedSize = -1;
        private InvitationParams params_;
        public const int ParamsFieldNumber = 3;
        private InvitationTarget target_;
        public const int TargetFieldNumber = 5;
        private EntityId targetId_;
        public const int TargetIdFieldNumber = 2;

        static SendInvitationRequest()
        {
            object.ReferenceEquals(InvitationTypes.Descriptor, null);
        }

        private SendInvitationRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(SendInvitationRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            SendInvitationRequest request = obj as SendInvitationRequest;
            if (request == null)
            {
                return false;
            }
            if ((this.hasAgentIdentity != request.hasAgentIdentity) || (this.hasAgentIdentity && !this.agentIdentity_.Equals(request.agentIdentity_)))
            {
                return false;
            }
            if ((this.hasTargetId != request.hasTargetId) || (this.hasTargetId && !this.targetId_.Equals(request.targetId_)))
            {
                return false;
            }
            if ((this.hasParams != request.hasParams) || (this.hasParams && !this.params_.Equals(request.params_)))
            {
                return false;
            }
            if ((this.hasAgentInfo != request.hasAgentInfo) || (this.hasAgentInfo && !this.agentInfo_.Equals(request.agentInfo_)))
            {
                return false;
            }
            return ((this.hasTarget == request.hasTarget) && (!this.hasTarget || this.target_.Equals(request.target_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasAgentIdentity)
            {
                hashCode ^= this.agentIdentity_.GetHashCode();
            }
            if (this.hasTargetId)
            {
                hashCode ^= this.targetId_.GetHashCode();
            }
            if (this.hasParams)
            {
                hashCode ^= this.params_.GetHashCode();
            }
            if (this.hasAgentInfo)
            {
                hashCode ^= this.agentInfo_.GetHashCode();
            }
            if (this.hasTarget)
            {
                hashCode ^= this.target_.GetHashCode();
            }
            return hashCode;
        }

        private SendInvitationRequest MakeReadOnly()
        {
            return this;
        }

        public static SendInvitationRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static SendInvitationRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static SendInvitationRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static SendInvitationRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static SendInvitationRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static SendInvitationRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static SendInvitationRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static SendInvitationRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static SendInvitationRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static SendInvitationRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<SendInvitationRequest, Builder>.PrintField("agent_identity", this.hasAgentIdentity, this.agentIdentity_, writer);
            GeneratedMessageLite<SendInvitationRequest, Builder>.PrintField("target_id", this.hasTargetId, this.targetId_, writer);
            GeneratedMessageLite<SendInvitationRequest, Builder>.PrintField("params", this.hasParams, this.params_, writer);
            GeneratedMessageLite<SendInvitationRequest, Builder>.PrintField("agent_info", this.hasAgentInfo, this.agentInfo_, writer);
            GeneratedMessageLite<SendInvitationRequest, Builder>.PrintField("target", this.hasTarget, this.target_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _sendInvitationRequestFieldNames;
            if (this.hasAgentIdentity)
            {
                output.WriteMessage(1, strArray[0], this.AgentIdentity);
            }
            if (this.hasTargetId)
            {
                output.WriteMessage(2, strArray[4], this.TargetId);
            }
            if (this.hasParams)
            {
                output.WriteMessage(3, strArray[2], this.Params);
            }
            if (this.hasAgentInfo)
            {
                output.WriteMessage(4, strArray[1], this.AgentInfo);
            }
            if (this.hasTarget)
            {
                output.WriteMessage(5, strArray[3], this.Target);
            }
        }

        public Identity AgentIdentity
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.agentIdentity_ != null)
                {
                    goto Label_0012;
                }
                return Identity.DefaultInstance;
            }
        }

        public AccountInfo AgentInfo
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.agentInfo_ != null)
                {
                    goto Label_0012;
                }
                return AccountInfo.DefaultInstance;
            }
        }

        public static SendInvitationRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override SendInvitationRequest DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasAgentIdentity
        {
            get
            {
                return this.hasAgentIdentity;
            }
        }

        public bool HasAgentInfo
        {
            get
            {
                return this.hasAgentInfo;
            }
        }

        public bool HasParams
        {
            get
            {
                return this.hasParams;
            }
        }

        public bool HasTarget
        {
            get
            {
                return this.hasTarget;
            }
        }

        public bool HasTargetId
        {
            get
            {
                return this.hasTargetId;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasTargetId)
                {
                    return false;
                }
                if (!this.hasParams)
                {
                    return false;
                }
                if (this.HasAgentIdentity && !this.AgentIdentity.IsInitialized)
                {
                    return false;
                }
                if (!this.TargetId.IsInitialized)
                {
                    return false;
                }
                if (this.HasTarget && !this.Target.IsInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        public InvitationParams Params
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.params_ != null)
                {
                    goto Label_0012;
                }
                return InvitationParams.DefaultInstance;
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
                    if (this.hasAgentIdentity)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.AgentIdentity);
                    }
                    if (this.hasTargetId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, this.TargetId);
                    }
                    if (this.hasParams)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(3, this.Params);
                    }
                    if (this.hasAgentInfo)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(4, this.AgentInfo);
                    }
                    if (this.hasTarget)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(5, this.Target);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        public InvitationTarget Target
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.target_ != null)
                {
                    goto Label_0012;
                }
                return InvitationTarget.DefaultInstance;
            }
        }

        public EntityId TargetId
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.targetId_ != null)
                {
                    goto Label_0012;
                }
                return EntityId.DefaultInstance;
            }
        }

        protected override SendInvitationRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<SendInvitationRequest, SendInvitationRequest.Builder>
        {
            private SendInvitationRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = SendInvitationRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(SendInvitationRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override SendInvitationRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override SendInvitationRequest.Builder Clear()
            {
                this.result = SendInvitationRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public SendInvitationRequest.Builder ClearAgentIdentity()
            {
                this.PrepareBuilder();
                this.result.hasAgentIdentity = false;
                this.result.agentIdentity_ = null;
                return this;
            }

            public SendInvitationRequest.Builder ClearAgentInfo()
            {
                this.PrepareBuilder();
                this.result.hasAgentInfo = false;
                this.result.agentInfo_ = null;
                return this;
            }

            public SendInvitationRequest.Builder ClearParams()
            {
                this.PrepareBuilder();
                this.result.hasParams = false;
                this.result.params_ = null;
                return this;
            }

            public SendInvitationRequest.Builder ClearTarget()
            {
                this.PrepareBuilder();
                this.result.hasTarget = false;
                this.result.target_ = null;
                return this;
            }

            public SendInvitationRequest.Builder ClearTargetId()
            {
                this.PrepareBuilder();
                this.result.hasTargetId = false;
                this.result.targetId_ = null;
                return this;
            }

            public override SendInvitationRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new SendInvitationRequest.Builder(this.result);
                }
                return new SendInvitationRequest.Builder().MergeFrom(this.result);
            }

            public SendInvitationRequest.Builder MergeAgentIdentity(Identity value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasAgentIdentity && (this.result.agentIdentity_ != Identity.DefaultInstance))
                {
                    this.result.agentIdentity_ = Identity.CreateBuilder(this.result.agentIdentity_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.agentIdentity_ = value;
                }
                this.result.hasAgentIdentity = true;
                return this;
            }

            public SendInvitationRequest.Builder MergeAgentInfo(AccountInfo value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasAgentInfo && (this.result.agentInfo_ != AccountInfo.DefaultInstance))
                {
                    this.result.agentInfo_ = AccountInfo.CreateBuilder(this.result.agentInfo_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.agentInfo_ = value;
                }
                this.result.hasAgentInfo = true;
                return this;
            }

            public override SendInvitationRequest.Builder MergeFrom(SendInvitationRequest other)
            {
                if (other != SendInvitationRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAgentIdentity)
                    {
                        this.MergeAgentIdentity(other.AgentIdentity);
                    }
                    if (other.HasTargetId)
                    {
                        this.MergeTargetId(other.TargetId);
                    }
                    if (other.HasParams)
                    {
                        this.MergeParams(other.Params);
                    }
                    if (other.HasAgentInfo)
                    {
                        this.MergeAgentInfo(other.AgentInfo);
                    }
                    if (other.HasTarget)
                    {
                        this.MergeTarget(other.Target);
                    }
                }
                return this;
            }

            public override SendInvitationRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override SendInvitationRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is SendInvitationRequest)
                {
                    return this.MergeFrom((SendInvitationRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override SendInvitationRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(SendInvitationRequest._sendInvitationRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = SendInvitationRequest._sendInvitationRequestFieldTags[index];
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
                            Identity.Builder builder = Identity.CreateBuilder();
                            if (this.result.hasAgentIdentity)
                            {
                                builder.MergeFrom(this.AgentIdentity);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.AgentIdentity = builder.BuildPartial();
                            continue;
                        }
                        case 0x12:
                        {
                            EntityId.Builder builder2 = EntityId.CreateBuilder();
                            if (this.result.hasTargetId)
                            {
                                builder2.MergeFrom(this.TargetId);
                            }
                            input.ReadMessage(builder2, extensionRegistry);
                            this.TargetId = builder2.BuildPartial();
                            continue;
                        }
                        case 0x1a:
                        {
                            InvitationParams.Builder builder3 = InvitationParams.CreateBuilder();
                            if (this.result.hasParams)
                            {
                                builder3.MergeFrom(this.Params);
                            }
                            input.ReadMessage(builder3, extensionRegistry);
                            this.Params = builder3.BuildPartial();
                            continue;
                        }
                        case 0x22:
                        {
                            AccountInfo.Builder builder4 = AccountInfo.CreateBuilder();
                            if (this.result.hasAgentInfo)
                            {
                                builder4.MergeFrom(this.AgentInfo);
                            }
                            input.ReadMessage(builder4, extensionRegistry);
                            this.AgentInfo = builder4.BuildPartial();
                            continue;
                        }
                        case 0x2a:
                        {
                            InvitationTarget.Builder builder5 = InvitationTarget.CreateBuilder();
                            if (this.result.hasTarget)
                            {
                                builder5.MergeFrom(this.Target);
                            }
                            input.ReadMessage(builder5, extensionRegistry);
                            this.Target = builder5.BuildPartial();
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

            public SendInvitationRequest.Builder MergeParams(InvitationParams value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasParams && (this.result.params_ != InvitationParams.DefaultInstance))
                {
                    this.result.params_ = InvitationParams.CreateBuilder(this.result.params_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.params_ = value;
                }
                this.result.hasParams = true;
                return this;
            }

            public SendInvitationRequest.Builder MergeTarget(InvitationTarget value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasTarget && (this.result.target_ != InvitationTarget.DefaultInstance))
                {
                    this.result.target_ = InvitationTarget.CreateBuilder(this.result.target_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.target_ = value;
                }
                this.result.hasTarget = true;
                return this;
            }

            public SendInvitationRequest.Builder MergeTargetId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasTargetId && (this.result.targetId_ != EntityId.DefaultInstance))
                {
                    this.result.targetId_ = EntityId.CreateBuilder(this.result.targetId_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.targetId_ = value;
                }
                this.result.hasTargetId = true;
                return this;
            }

            private SendInvitationRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    SendInvitationRequest result = this.result;
                    this.result = new SendInvitationRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public SendInvitationRequest.Builder SetAgentIdentity(Identity value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasAgentIdentity = true;
                this.result.agentIdentity_ = value;
                return this;
            }

            public SendInvitationRequest.Builder SetAgentIdentity(Identity.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasAgentIdentity = true;
                this.result.agentIdentity_ = builderForValue.Build();
                return this;
            }

            public SendInvitationRequest.Builder SetAgentInfo(AccountInfo value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasAgentInfo = true;
                this.result.agentInfo_ = value;
                return this;
            }

            public SendInvitationRequest.Builder SetAgentInfo(AccountInfo.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasAgentInfo = true;
                this.result.agentInfo_ = builderForValue.Build();
                return this;
            }

            public SendInvitationRequest.Builder SetParams(InvitationParams value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasParams = true;
                this.result.params_ = value;
                return this;
            }

            public SendInvitationRequest.Builder SetParams(InvitationParams.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasParams = true;
                this.result.params_ = builderForValue.Build();
                return this;
            }

            public SendInvitationRequest.Builder SetTarget(InvitationTarget value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasTarget = true;
                this.result.target_ = value;
                return this;
            }

            public SendInvitationRequest.Builder SetTarget(InvitationTarget.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasTarget = true;
                this.result.target_ = builderForValue.Build();
                return this;
            }

            public SendInvitationRequest.Builder SetTargetId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasTargetId = true;
                this.result.targetId_ = value;
                return this;
            }

            public SendInvitationRequest.Builder SetTargetId(EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasTargetId = true;
                this.result.targetId_ = builderForValue.Build();
                return this;
            }

            public Identity AgentIdentity
            {
                get
                {
                    return this.result.AgentIdentity;
                }
                set
                {
                    this.SetAgentIdentity(value);
                }
            }

            public AccountInfo AgentInfo
            {
                get
                {
                    return this.result.AgentInfo;
                }
                set
                {
                    this.SetAgentInfo(value);
                }
            }

            public override SendInvitationRequest DefaultInstanceForType
            {
                get
                {
                    return SendInvitationRequest.DefaultInstance;
                }
            }

            public bool HasAgentIdentity
            {
                get
                {
                    return this.result.hasAgentIdentity;
                }
            }

            public bool HasAgentInfo
            {
                get
                {
                    return this.result.hasAgentInfo;
                }
            }

            public bool HasParams
            {
                get
                {
                    return this.result.hasParams;
                }
            }

            public bool HasTarget
            {
                get
                {
                    return this.result.hasTarget;
                }
            }

            public bool HasTargetId
            {
                get
                {
                    return this.result.hasTargetId;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override SendInvitationRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public InvitationParams Params
            {
                get
                {
                    return this.result.Params;
                }
                set
                {
                    this.SetParams(value);
                }
            }

            public InvitationTarget Target
            {
                get
                {
                    return this.result.Target;
                }
                set
                {
                    this.SetTarget(value);
                }
            }

            public EntityId TargetId
            {
                get
                {
                    return this.result.TargetId;
                }
                set
                {
                    this.SetTargetId(value);
                }
            }

            protected override SendInvitationRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

