namespace bnet.protocol.invitation
{
    using bnet.protocol;
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class GenericRequest : GeneratedMessageLite<GenericRequest, Builder>
    {
        private static readonly string[] _genericRequestFieldNames = new string[] { "agent_id", "desired_role", "invitation_id", "invitee_name", "inviter_name", "previous_role", "reason", "target_id" };
        private static readonly uint[] _genericRequestFieldTags = new uint[] { 10, 0x3a, 0x19, 0x22, 0x2a, 50, 0x40, 0x12 };
        private EntityId agentId_;
        public const int AgentIdFieldNumber = 1;
        private static readonly GenericRequest defaultInstance = new GenericRequest().MakeReadOnly();
        private PopsicleList<uint> desiredRole_ = new PopsicleList<uint>();
        public const int DesiredRoleFieldNumber = 7;
        private int desiredRoleMemoizedSerializedSize;
        private bool hasAgentId;
        private bool hasInvitationId;
        private bool hasInviteeName;
        private bool hasInviterName;
        private bool hasReason;
        private bool hasTargetId;
        private ulong invitationId_;
        public const int InvitationIdFieldNumber = 3;
        private string inviteeName_ = string.Empty;
        public const int InviteeNameFieldNumber = 4;
        private string inviterName_ = string.Empty;
        public const int InviterNameFieldNumber = 5;
        private int memoizedSerializedSize = -1;
        private PopsicleList<uint> previousRole_ = new PopsicleList<uint>();
        public const int PreviousRoleFieldNumber = 6;
        private int previousRoleMemoizedSerializedSize;
        private uint reason_;
        public const int ReasonFieldNumber = 8;
        private EntityId targetId_;
        public const int TargetIdFieldNumber = 2;

        static GenericRequest()
        {
            object.ReferenceEquals(InvitationTypes.Descriptor, null);
        }

        private GenericRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GenericRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GenericRequest request = obj as GenericRequest;
            if (request == null)
            {
                return false;
            }
            if ((this.hasAgentId != request.hasAgentId) || (this.hasAgentId && !this.agentId_.Equals(request.agentId_)))
            {
                return false;
            }
            if ((this.hasTargetId != request.hasTargetId) || (this.hasTargetId && !this.targetId_.Equals(request.targetId_)))
            {
                return false;
            }
            if ((this.hasInvitationId != request.hasInvitationId) || (this.hasInvitationId && !this.invitationId_.Equals(request.invitationId_)))
            {
                return false;
            }
            if ((this.hasInviteeName != request.hasInviteeName) || (this.hasInviteeName && !this.inviteeName_.Equals(request.inviteeName_)))
            {
                return false;
            }
            if ((this.hasInviterName != request.hasInviterName) || (this.hasInviterName && !this.inviterName_.Equals(request.inviterName_)))
            {
                return false;
            }
            if (this.previousRole_.Count != request.previousRole_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.previousRole_.Count; i++)
            {
                uint num3 = this.previousRole_[i];
                if (!num3.Equals(request.previousRole_[i]))
                {
                    return false;
                }
            }
            if (this.desiredRole_.Count != request.desiredRole_.Count)
            {
                return false;
            }
            for (int j = 0; j < this.desiredRole_.Count; j++)
            {
                uint num4 = this.desiredRole_[j];
                if (!num4.Equals(request.desiredRole_[j]))
                {
                    return false;
                }
            }
            return ((this.hasReason == request.hasReason) && (!this.hasReason || this.reason_.Equals(request.reason_)));
        }

        [CLSCompliant(false)]
        public uint GetDesiredRole(int index)
        {
            return this.desiredRole_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasAgentId)
            {
                hashCode ^= this.agentId_.GetHashCode();
            }
            if (this.hasTargetId)
            {
                hashCode ^= this.targetId_.GetHashCode();
            }
            if (this.hasInvitationId)
            {
                hashCode ^= this.invitationId_.GetHashCode();
            }
            if (this.hasInviteeName)
            {
                hashCode ^= this.inviteeName_.GetHashCode();
            }
            if (this.hasInviterName)
            {
                hashCode ^= this.inviterName_.GetHashCode();
            }
            IEnumerator<uint> enumerator = this.previousRole_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    uint current = enumerator.Current;
                    hashCode ^= current.GetHashCode();
                }
            }
            finally
            {
                if (enumerator == null)
                {
                }
                enumerator.Dispose();
            }
            IEnumerator<uint> enumerator2 = this.desiredRole_.GetEnumerator();
            try
            {
                while (enumerator2.MoveNext())
                {
                    uint num3 = enumerator2.Current;
                    hashCode ^= num3.GetHashCode();
                }
            }
            finally
            {
                if (enumerator2 == null)
                {
                }
                enumerator2.Dispose();
            }
            if (this.hasReason)
            {
                hashCode ^= this.reason_.GetHashCode();
            }
            return hashCode;
        }

        [CLSCompliant(false)]
        public uint GetPreviousRole(int index)
        {
            return this.previousRole_[index];
        }

        private GenericRequest MakeReadOnly()
        {
            this.previousRole_.MakeReadOnly();
            this.desiredRole_.MakeReadOnly();
            return this;
        }

        public static GenericRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GenericRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GenericRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GenericRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GenericRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GenericRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GenericRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GenericRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GenericRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GenericRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GenericRequest, Builder>.PrintField("agent_id", this.hasAgentId, this.agentId_, writer);
            GeneratedMessageLite<GenericRequest, Builder>.PrintField("target_id", this.hasTargetId, this.targetId_, writer);
            GeneratedMessageLite<GenericRequest, Builder>.PrintField("invitation_id", this.hasInvitationId, this.invitationId_, writer);
            GeneratedMessageLite<GenericRequest, Builder>.PrintField("invitee_name", this.hasInviteeName, this.inviteeName_, writer);
            GeneratedMessageLite<GenericRequest, Builder>.PrintField("inviter_name", this.hasInviterName, this.inviterName_, writer);
            GeneratedMessageLite<GenericRequest, Builder>.PrintField<uint>("previous_role", this.previousRole_, writer);
            GeneratedMessageLite<GenericRequest, Builder>.PrintField<uint>("desired_role", this.desiredRole_, writer);
            GeneratedMessageLite<GenericRequest, Builder>.PrintField("reason", this.hasReason, this.reason_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _genericRequestFieldNames;
            if (this.hasAgentId)
            {
                output.WriteMessage(1, strArray[0], this.AgentId);
            }
            if (this.hasTargetId)
            {
                output.WriteMessage(2, strArray[7], this.TargetId);
            }
            if (this.hasInvitationId)
            {
                output.WriteFixed64(3, strArray[2], this.InvitationId);
            }
            if (this.hasInviteeName)
            {
                output.WriteString(4, strArray[3], this.InviteeName);
            }
            if (this.hasInviterName)
            {
                output.WriteString(5, strArray[4], this.InviterName);
            }
            if (this.previousRole_.Count > 0)
            {
                output.WritePackedUInt32Array(6, strArray[5], this.previousRoleMemoizedSerializedSize, this.previousRole_);
            }
            if (this.desiredRole_.Count > 0)
            {
                output.WritePackedUInt32Array(7, strArray[1], this.desiredRoleMemoizedSerializedSize, this.desiredRole_);
            }
            if (this.hasReason)
            {
                output.WriteUInt32(8, strArray[6], this.Reason);
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

        public static GenericRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GenericRequest DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public int DesiredRoleCount
        {
            get
            {
                return this.desiredRole_.Count;
            }
        }

        [CLSCompliant(false)]
        public IList<uint> DesiredRoleList
        {
            get
            {
                return Lists.AsReadOnly<uint>(this.desiredRole_);
            }
        }

        public bool HasAgentId
        {
            get
            {
                return this.hasAgentId;
            }
        }

        public bool HasInvitationId
        {
            get
            {
                return this.hasInvitationId;
            }
        }

        public bool HasInviteeName
        {
            get
            {
                return this.hasInviteeName;
            }
        }

        public bool HasInviterName
        {
            get
            {
                return this.hasInviterName;
            }
        }

        public bool HasReason
        {
            get
            {
                return this.hasReason;
            }
        }

        public bool HasTargetId
        {
            get
            {
                return this.hasTargetId;
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

        public string InviteeName
        {
            get
            {
                return this.inviteeName_;
            }
        }

        public string InviterName
        {
            get
            {
                return this.inviterName_;
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
                if (this.HasAgentId && !this.AgentId.IsInitialized)
                {
                    return false;
                }
                if (this.HasTargetId && !this.TargetId.IsInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        public int PreviousRoleCount
        {
            get
            {
                return this.previousRole_.Count;
            }
        }

        [CLSCompliant(false)]
        public IList<uint> PreviousRoleList
        {
            get
            {
                return Lists.AsReadOnly<uint>(this.previousRole_);
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
                    if (this.hasTargetId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, this.TargetId);
                    }
                    if (this.hasInvitationId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed64Size(3, this.InvitationId);
                    }
                    if (this.hasInviteeName)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(4, this.InviteeName);
                    }
                    if (this.hasInviterName)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(5, this.InviterName);
                    }
                    int num2 = 0;
                    IEnumerator<uint> enumerator = this.PreviousRoleList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            uint current = enumerator.Current;
                            num2 += CodedOutputStream.ComputeUInt32SizeNoTag(current);
                        }
                    }
                    finally
                    {
                        if (enumerator == null)
                        {
                        }
                        enumerator.Dispose();
                    }
                    memoizedSerializedSize += num2;
                    if (this.previousRole_.Count != 0)
                    {
                        memoizedSerializedSize += 1 + CodedOutputStream.ComputeInt32SizeNoTag(num2);
                    }
                    this.previousRoleMemoizedSerializedSize = num2;
                    int num4 = 0;
                    IEnumerator<uint> enumerator2 = this.DesiredRoleList.GetEnumerator();
                    try
                    {
                        while (enumerator2.MoveNext())
                        {
                            uint num5 = enumerator2.Current;
                            num4 += CodedOutputStream.ComputeUInt32SizeNoTag(num5);
                        }
                    }
                    finally
                    {
                        if (enumerator2 == null)
                        {
                        }
                        enumerator2.Dispose();
                    }
                    memoizedSerializedSize += num4;
                    if (this.desiredRole_.Count != 0)
                    {
                        memoizedSerializedSize += 1 + CodedOutputStream.ComputeInt32SizeNoTag(num4);
                    }
                    this.desiredRoleMemoizedSerializedSize = num4;
                    if (this.hasReason)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(8, this.Reason);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
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

        protected override GenericRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<GenericRequest, GenericRequest.Builder>
        {
            private GenericRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GenericRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GenericRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            [CLSCompliant(false)]
            public GenericRequest.Builder AddDesiredRole(uint value)
            {
                this.PrepareBuilder();
                this.result.desiredRole_.Add(value);
                return this;
            }

            [CLSCompliant(false)]
            public GenericRequest.Builder AddPreviousRole(uint value)
            {
                this.PrepareBuilder();
                this.result.previousRole_.Add(value);
                return this;
            }

            [CLSCompliant(false)]
            public GenericRequest.Builder AddRangeDesiredRole(IEnumerable<uint> values)
            {
                this.PrepareBuilder();
                this.result.desiredRole_.Add(values);
                return this;
            }

            [CLSCompliant(false)]
            public GenericRequest.Builder AddRangePreviousRole(IEnumerable<uint> values)
            {
                this.PrepareBuilder();
                this.result.previousRole_.Add(values);
                return this;
            }

            public override GenericRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GenericRequest.Builder Clear()
            {
                this.result = GenericRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GenericRequest.Builder ClearAgentId()
            {
                this.PrepareBuilder();
                this.result.hasAgentId = false;
                this.result.agentId_ = null;
                return this;
            }

            public GenericRequest.Builder ClearDesiredRole()
            {
                this.PrepareBuilder();
                this.result.desiredRole_.Clear();
                return this;
            }

            public GenericRequest.Builder ClearInvitationId()
            {
                this.PrepareBuilder();
                this.result.hasInvitationId = false;
                this.result.invitationId_ = 0L;
                return this;
            }

            public GenericRequest.Builder ClearInviteeName()
            {
                this.PrepareBuilder();
                this.result.hasInviteeName = false;
                this.result.inviteeName_ = string.Empty;
                return this;
            }

            public GenericRequest.Builder ClearInviterName()
            {
                this.PrepareBuilder();
                this.result.hasInviterName = false;
                this.result.inviterName_ = string.Empty;
                return this;
            }

            public GenericRequest.Builder ClearPreviousRole()
            {
                this.PrepareBuilder();
                this.result.previousRole_.Clear();
                return this;
            }

            public GenericRequest.Builder ClearReason()
            {
                this.PrepareBuilder();
                this.result.hasReason = false;
                this.result.reason_ = 0;
                return this;
            }

            public GenericRequest.Builder ClearTargetId()
            {
                this.PrepareBuilder();
                this.result.hasTargetId = false;
                this.result.targetId_ = null;
                return this;
            }

            public override GenericRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GenericRequest.Builder(this.result);
                }
                return new GenericRequest.Builder().MergeFrom(this.result);
            }

            [CLSCompliant(false)]
            public uint GetDesiredRole(int index)
            {
                return this.result.GetDesiredRole(index);
            }

            [CLSCompliant(false)]
            public uint GetPreviousRole(int index)
            {
                return this.result.GetPreviousRole(index);
            }

            public GenericRequest.Builder MergeAgentId(EntityId value)
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

            public override GenericRequest.Builder MergeFrom(GenericRequest other)
            {
                if (other != GenericRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAgentId)
                    {
                        this.MergeAgentId(other.AgentId);
                    }
                    if (other.HasTargetId)
                    {
                        this.MergeTargetId(other.TargetId);
                    }
                    if (other.HasInvitationId)
                    {
                        this.InvitationId = other.InvitationId;
                    }
                    if (other.HasInviteeName)
                    {
                        this.InviteeName = other.InviteeName;
                    }
                    if (other.HasInviterName)
                    {
                        this.InviterName = other.InviterName;
                    }
                    if (other.previousRole_.Count != 0)
                    {
                        this.result.previousRole_.Add(other.previousRole_);
                    }
                    if (other.desiredRole_.Count != 0)
                    {
                        this.result.desiredRole_.Add(other.desiredRole_);
                    }
                    if (other.HasReason)
                    {
                        this.Reason = other.Reason;
                    }
                }
                return this;
            }

            public override GenericRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GenericRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is GenericRequest)
                {
                    return this.MergeFrom((GenericRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GenericRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    EntityId.Builder builder;
                    EntityId.Builder builder2;
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GenericRequest._genericRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GenericRequest._genericRequestFieldTags[index];
                        }
                        else
                        {
                            this.ParseUnknownField(input, extensionRegistry, num, str);
                            continue;
                        }
                    }
                    switch (num)
                    {
                        case 0x30:
                        case 50:
                        {
                            input.ReadUInt32Array(num, str, this.result.previousRole_);
                            continue;
                        }
                        case 0x38:
                        case 0x3a:
                        {
                            input.ReadUInt32Array(num, str, this.result.desiredRole_);
                            continue;
                        }
                        case 0:
                            throw InvalidProtocolBufferException.InvalidTag();

                        case 10:
                            goto Label_00E2;

                        case 0x12:
                            goto Label_011E;

                        case 0x19:
                            goto Label_015E;

                        case 0x22:
                            goto Label_017F;

                        case 0x2a:
                            goto Label_01A0;

                        case 0x40:
                            goto Label_01F1;

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
                Label_00E2:
                    builder = EntityId.CreateBuilder();
                    if (this.result.hasAgentId)
                    {
                        builder.MergeFrom(this.AgentId);
                    }
                    input.ReadMessage(builder, extensionRegistry);
                    this.AgentId = builder.BuildPartial();
                    continue;
                Label_011E:
                    builder2 = EntityId.CreateBuilder();
                    if (this.result.hasTargetId)
                    {
                        builder2.MergeFrom(this.TargetId);
                    }
                    input.ReadMessage(builder2, extensionRegistry);
                    this.TargetId = builder2.BuildPartial();
                    continue;
                Label_015E:
                    this.result.hasInvitationId = input.ReadFixed64(ref this.result.invitationId_);
                    continue;
                Label_017F:
                    this.result.hasInviteeName = input.ReadString(ref this.result.inviteeName_);
                    continue;
                Label_01A0:
                    this.result.hasInviterName = input.ReadString(ref this.result.inviterName_);
                    continue;
                Label_01F1:
                    this.result.hasReason = input.ReadUInt32(ref this.result.reason_);
                }
                return this;
            }

            public GenericRequest.Builder MergeTargetId(EntityId value)
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

            private GenericRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GenericRequest result = this.result;
                    this.result = new GenericRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public GenericRequest.Builder SetAgentId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasAgentId = true;
                this.result.agentId_ = value;
                return this;
            }

            public GenericRequest.Builder SetAgentId(EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasAgentId = true;
                this.result.agentId_ = builderForValue.Build();
                return this;
            }

            [CLSCompliant(false)]
            public GenericRequest.Builder SetDesiredRole(int index, uint value)
            {
                this.PrepareBuilder();
                this.result.desiredRole_[index] = value;
                return this;
            }

            [CLSCompliant(false)]
            public GenericRequest.Builder SetInvitationId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasInvitationId = true;
                this.result.invitationId_ = value;
                return this;
            }

            public GenericRequest.Builder SetInviteeName(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasInviteeName = true;
                this.result.inviteeName_ = value;
                return this;
            }

            public GenericRequest.Builder SetInviterName(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasInviterName = true;
                this.result.inviterName_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public GenericRequest.Builder SetPreviousRole(int index, uint value)
            {
                this.PrepareBuilder();
                this.result.previousRole_[index] = value;
                return this;
            }

            [CLSCompliant(false)]
            public GenericRequest.Builder SetReason(uint value)
            {
                this.PrepareBuilder();
                this.result.hasReason = true;
                this.result.reason_ = value;
                return this;
            }

            public GenericRequest.Builder SetTargetId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasTargetId = true;
                this.result.targetId_ = value;
                return this;
            }

            public GenericRequest.Builder SetTargetId(EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasTargetId = true;
                this.result.targetId_ = builderForValue.Build();
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

            public override GenericRequest DefaultInstanceForType
            {
                get
                {
                    return GenericRequest.DefaultInstance;
                }
            }

            public int DesiredRoleCount
            {
                get
                {
                    return this.result.DesiredRoleCount;
                }
            }

            [CLSCompliant(false)]
            public IPopsicleList<uint> DesiredRoleList
            {
                get
                {
                    return this.PrepareBuilder().desiredRole_;
                }
            }

            public bool HasAgentId
            {
                get
                {
                    return this.result.hasAgentId;
                }
            }

            public bool HasInvitationId
            {
                get
                {
                    return this.result.hasInvitationId;
                }
            }

            public bool HasInviteeName
            {
                get
                {
                    return this.result.hasInviteeName;
                }
            }

            public bool HasInviterName
            {
                get
                {
                    return this.result.hasInviterName;
                }
            }

            public bool HasReason
            {
                get
                {
                    return this.result.hasReason;
                }
            }

            public bool HasTargetId
            {
                get
                {
                    return this.result.hasTargetId;
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

            public string InviteeName
            {
                get
                {
                    return this.result.InviteeName;
                }
                set
                {
                    this.SetInviteeName(value);
                }
            }

            public string InviterName
            {
                get
                {
                    return this.result.InviterName;
                }
                set
                {
                    this.SetInviterName(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override GenericRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int PreviousRoleCount
            {
                get
                {
                    return this.result.PreviousRoleCount;
                }
            }

            [CLSCompliant(false)]
            public IPopsicleList<uint> PreviousRoleList
            {
                get
                {
                    return this.PrepareBuilder().previousRole_;
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

            protected override GenericRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

