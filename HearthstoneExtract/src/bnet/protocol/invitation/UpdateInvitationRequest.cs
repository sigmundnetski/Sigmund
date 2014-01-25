namespace bnet.protocol.invitation
{
    using bnet.protocol;
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class UpdateInvitationRequest : GeneratedMessageLite<UpdateInvitationRequest, Builder>
    {
        private static readonly string[] _updateInvitationRequestFieldNames = new string[] { "agent_identity", "invitation_id", "params" };
        private static readonly uint[] _updateInvitationRequestFieldTags = new uint[] { 10, 0x11, 0x1a };
        private Identity agentIdentity_;
        public const int AgentIdentityFieldNumber = 1;
        private static readonly UpdateInvitationRequest defaultInstance = new UpdateInvitationRequest().MakeReadOnly();
        private bool hasAgentIdentity;
        private bool hasInvitationId;
        private bool hasParams;
        private ulong invitationId_;
        public const int InvitationIdFieldNumber = 2;
        private int memoizedSerializedSize = -1;
        private InvitationParams params_;
        public const int ParamsFieldNumber = 3;

        static UpdateInvitationRequest()
        {
            object.ReferenceEquals(InvitationTypes.Descriptor, null);
        }

        private UpdateInvitationRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(UpdateInvitationRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            UpdateInvitationRequest request = obj as UpdateInvitationRequest;
            if (request == null)
            {
                return false;
            }
            if ((this.hasAgentIdentity != request.hasAgentIdentity) || (this.hasAgentIdentity && !this.agentIdentity_.Equals(request.agentIdentity_)))
            {
                return false;
            }
            if ((this.hasInvitationId != request.hasInvitationId) || (this.hasInvitationId && !this.invitationId_.Equals(request.invitationId_)))
            {
                return false;
            }
            return ((this.hasParams == request.hasParams) && (!this.hasParams || this.params_.Equals(request.params_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasAgentIdentity)
            {
                hashCode ^= this.agentIdentity_.GetHashCode();
            }
            if (this.hasInvitationId)
            {
                hashCode ^= this.invitationId_.GetHashCode();
            }
            if (this.hasParams)
            {
                hashCode ^= this.params_.GetHashCode();
            }
            return hashCode;
        }

        private UpdateInvitationRequest MakeReadOnly()
        {
            return this;
        }

        public static UpdateInvitationRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static UpdateInvitationRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static UpdateInvitationRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static UpdateInvitationRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static UpdateInvitationRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static UpdateInvitationRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static UpdateInvitationRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static UpdateInvitationRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static UpdateInvitationRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static UpdateInvitationRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<UpdateInvitationRequest, Builder>.PrintField("agent_identity", this.hasAgentIdentity, this.agentIdentity_, writer);
            GeneratedMessageLite<UpdateInvitationRequest, Builder>.PrintField("invitation_id", this.hasInvitationId, this.invitationId_, writer);
            GeneratedMessageLite<UpdateInvitationRequest, Builder>.PrintField("params", this.hasParams, this.params_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _updateInvitationRequestFieldNames;
            if (this.hasAgentIdentity)
            {
                output.WriteMessage(1, strArray[0], this.AgentIdentity);
            }
            if (this.hasInvitationId)
            {
                output.WriteFixed64(2, strArray[1], this.InvitationId);
            }
            if (this.hasParams)
            {
                output.WriteMessage(3, strArray[2], this.Params);
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

        public static UpdateInvitationRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override UpdateInvitationRequest DefaultInstanceForType
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

        public bool HasInvitationId
        {
            get
            {
                return this.hasInvitationId;
            }
        }

        public bool HasParams
        {
            get
            {
                return this.hasParams;
            }
        }

        [CLSCompliant(false)]
        public ulong InvitationId
        {
            get
            {
                return this.invitationId_;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasInvitationId)
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
                    if (this.hasInvitationId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed64Size(2, this.InvitationId);
                    }
                    if (this.hasParams)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(3, this.Params);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override UpdateInvitationRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<UpdateInvitationRequest, UpdateInvitationRequest.Builder>
        {
            private UpdateInvitationRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = UpdateInvitationRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(UpdateInvitationRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override UpdateInvitationRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override UpdateInvitationRequest.Builder Clear()
            {
                this.result = UpdateInvitationRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public UpdateInvitationRequest.Builder ClearAgentIdentity()
            {
                this.PrepareBuilder();
                this.result.hasAgentIdentity = false;
                this.result.agentIdentity_ = null;
                return this;
            }

            public UpdateInvitationRequest.Builder ClearInvitationId()
            {
                this.PrepareBuilder();
                this.result.hasInvitationId = false;
                this.result.invitationId_ = 0L;
                return this;
            }

            public UpdateInvitationRequest.Builder ClearParams()
            {
                this.PrepareBuilder();
                this.result.hasParams = false;
                this.result.params_ = null;
                return this;
            }

            public override UpdateInvitationRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new UpdateInvitationRequest.Builder(this.result);
                }
                return new UpdateInvitationRequest.Builder().MergeFrom(this.result);
            }

            public UpdateInvitationRequest.Builder MergeAgentIdentity(Identity value)
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

            public override UpdateInvitationRequest.Builder MergeFrom(UpdateInvitationRequest other)
            {
                if (other != UpdateInvitationRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAgentIdentity)
                    {
                        this.MergeAgentIdentity(other.AgentIdentity);
                    }
                    if (other.HasInvitationId)
                    {
                        this.InvitationId = other.InvitationId;
                    }
                    if (other.HasParams)
                    {
                        this.MergeParams(other.Params);
                    }
                }
                return this;
            }

            public override UpdateInvitationRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override UpdateInvitationRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is UpdateInvitationRequest)
                {
                    return this.MergeFrom((UpdateInvitationRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override UpdateInvitationRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(UpdateInvitationRequest._updateInvitationRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = UpdateInvitationRequest._updateInvitationRequestFieldTags[index];
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
                        case 0x11:
                        {
                            this.result.hasInvitationId = input.ReadFixed64(ref this.result.invitationId_);
                            continue;
                        }
                        case 0x1a:
                        {
                            InvitationParams.Builder builder2 = InvitationParams.CreateBuilder();
                            if (this.result.hasParams)
                            {
                                builder2.MergeFrom(this.Params);
                            }
                            input.ReadMessage(builder2, extensionRegistry);
                            this.Params = builder2.BuildPartial();
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

            public UpdateInvitationRequest.Builder MergeParams(InvitationParams value)
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

            private UpdateInvitationRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    UpdateInvitationRequest result = this.result;
                    this.result = new UpdateInvitationRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public UpdateInvitationRequest.Builder SetAgentIdentity(Identity value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasAgentIdentity = true;
                this.result.agentIdentity_ = value;
                return this;
            }

            public UpdateInvitationRequest.Builder SetAgentIdentity(Identity.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasAgentIdentity = true;
                this.result.agentIdentity_ = builderForValue.Build();
                return this;
            }

            [CLSCompliant(false)]
            public UpdateInvitationRequest.Builder SetInvitationId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasInvitationId = true;
                this.result.invitationId_ = value;
                return this;
            }

            public UpdateInvitationRequest.Builder SetParams(InvitationParams value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasParams = true;
                this.result.params_ = value;
                return this;
            }

            public UpdateInvitationRequest.Builder SetParams(InvitationParams.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasParams = true;
                this.result.params_ = builderForValue.Build();
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

            public override UpdateInvitationRequest DefaultInstanceForType
            {
                get
                {
                    return UpdateInvitationRequest.DefaultInstance;
                }
            }

            public bool HasAgentIdentity
            {
                get
                {
                    return this.result.hasAgentIdentity;
                }
            }

            public bool HasInvitationId
            {
                get
                {
                    return this.result.hasInvitationId;
                }
            }

            public bool HasParams
            {
                get
                {
                    return this.result.hasParams;
                }
            }

            [CLSCompliant(false)]
            public ulong InvitationId
            {
                get
                {
                    return this.result.InvitationId;
                }
                set
                {
                    this.SetInvitationId(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override UpdateInvitationRequest MessageBeingBuilt
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

            protected override UpdateInvitationRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

