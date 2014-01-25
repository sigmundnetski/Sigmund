namespace bnet.protocol.channel
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

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class SetRolesRequest : GeneratedMessageLite<SetRolesRequest, Builder>
    {
        private static readonly string[] _setRolesRequestFieldNames = new string[] { "agent_id", "member_id", "role" };
        private static readonly uint[] _setRolesRequestFieldTags = new uint[] { 10, 0x1a, 0x12 };
        private EntityId agentId_;
        public const int AgentIdFieldNumber = 1;
        private static readonly SetRolesRequest defaultInstance = new SetRolesRequest().MakeReadOnly();
        private bool hasAgentId;
        private PopsicleList<EntityId> memberId_ = new PopsicleList<EntityId>();
        public const int MemberIdFieldNumber = 3;
        private int memoizedSerializedSize = -1;
        private PopsicleList<uint> role_ = new PopsicleList<uint>();
        public const int RoleFieldNumber = 2;
        private int roleMemoizedSerializedSize;

        static SetRolesRequest()
        {
            object.ReferenceEquals(ChannelService.Descriptor, null);
        }

        private SetRolesRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(SetRolesRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            SetRolesRequest request = obj as SetRolesRequest;
            if (request == null)
            {
                return false;
            }
            if ((this.hasAgentId != request.hasAgentId) || (this.hasAgentId && !this.agentId_.Equals(request.agentId_)))
            {
                return false;
            }
            if (this.role_.Count != request.role_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.role_.Count; i++)
            {
                uint num3 = this.role_[i];
                if (!num3.Equals(request.role_[i]))
                {
                    return false;
                }
            }
            if (this.memberId_.Count != request.memberId_.Count)
            {
                return false;
            }
            for (int j = 0; j < this.memberId_.Count; j++)
            {
                if (!this.memberId_[j].Equals(request.memberId_[j]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasAgentId)
            {
                hashCode ^= this.agentId_.GetHashCode();
            }
            IEnumerator<uint> enumerator = this.role_.GetEnumerator();
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
            IEnumerator<EntityId> enumerator2 = this.memberId_.GetEnumerator();
            try
            {
                while (enumerator2.MoveNext())
                {
                    EntityId id = enumerator2.Current;
                    hashCode ^= id.GetHashCode();
                }
            }
            finally
            {
                if (enumerator2 == null)
                {
                }
                enumerator2.Dispose();
            }
            return hashCode;
        }

        public EntityId GetMemberId(int index)
        {
            return this.memberId_[index];
        }

        [CLSCompliant(false)]
        public uint GetRole(int index)
        {
            return this.role_[index];
        }

        private SetRolesRequest MakeReadOnly()
        {
            this.role_.MakeReadOnly();
            this.memberId_.MakeReadOnly();
            return this;
        }

        public static SetRolesRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static SetRolesRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static SetRolesRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static SetRolesRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static SetRolesRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static SetRolesRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static SetRolesRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static SetRolesRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static SetRolesRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static SetRolesRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<SetRolesRequest, Builder>.PrintField("agent_id", this.hasAgentId, this.agentId_, writer);
            GeneratedMessageLite<SetRolesRequest, Builder>.PrintField<uint>("role", this.role_, writer);
            GeneratedMessageLite<SetRolesRequest, Builder>.PrintField<EntityId>("member_id", this.memberId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _setRolesRequestFieldNames;
            if (this.hasAgentId)
            {
                output.WriteMessage(1, strArray[0], this.AgentId);
            }
            if (this.role_.Count > 0)
            {
                output.WritePackedUInt32Array(2, strArray[2], this.roleMemoizedSerializedSize, this.role_);
            }
            if (this.memberId_.Count > 0)
            {
                output.WriteMessageArray<EntityId>(3, strArray[1], this.memberId_);
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

        public static SetRolesRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override SetRolesRequest DefaultInstanceForType
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

        public override bool IsInitialized
        {
            get
            {
                if (this.HasAgentId && !this.AgentId.IsInitialized)
                {
                    return false;
                }
                IEnumerator<EntityId> enumerator = this.MemberIdList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        EntityId current = enumerator.Current;
                        if (!current.IsInitialized)
                        {
                            return false;
                        }
                    }
                }
                finally
                {
                    if (enumerator == null)
                    {
                    }
                    enumerator.Dispose();
                }
                return true;
            }
        }

        public int MemberIdCount
        {
            get
            {
                return this.memberId_.Count;
            }
        }

        public IList<EntityId> MemberIdList
        {
            get
            {
                return this.memberId_;
            }
        }

        public int RoleCount
        {
            get
            {
                return this.role_.Count;
            }
        }

        [CLSCompliant(false)]
        public IList<uint> RoleList
        {
            get
            {
                return Lists.AsReadOnly<uint>(this.role_);
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
                    int num2 = 0;
                    IEnumerator<uint> enumerator = this.RoleList.GetEnumerator();
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
                    if (this.role_.Count != 0)
                    {
                        memoizedSerializedSize += 1 + CodedOutputStream.ComputeInt32SizeNoTag(num2);
                    }
                    this.roleMemoizedSerializedSize = num2;
                    IEnumerator<EntityId> enumerator2 = this.MemberIdList.GetEnumerator();
                    try
                    {
                        while (enumerator2.MoveNext())
                        {
                            EntityId id = enumerator2.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(3, id);
                        }
                    }
                    finally
                    {
                        if (enumerator2 == null)
                        {
                        }
                        enumerator2.Dispose();
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override SetRolesRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<SetRolesRequest, SetRolesRequest.Builder>
        {
            private SetRolesRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = SetRolesRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(SetRolesRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public SetRolesRequest.Builder AddMemberId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.memberId_.Add(value);
                return this;
            }

            public SetRolesRequest.Builder AddMemberId(EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.memberId_.Add(builderForValue.Build());
                return this;
            }

            public SetRolesRequest.Builder AddRangeMemberId(IEnumerable<EntityId> values)
            {
                this.PrepareBuilder();
                this.result.memberId_.Add(values);
                return this;
            }

            [CLSCompliant(false)]
            public SetRolesRequest.Builder AddRangeRole(IEnumerable<uint> values)
            {
                this.PrepareBuilder();
                this.result.role_.Add(values);
                return this;
            }

            [CLSCompliant(false)]
            public SetRolesRequest.Builder AddRole(uint value)
            {
                this.PrepareBuilder();
                this.result.role_.Add(value);
                return this;
            }

            public override SetRolesRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override SetRolesRequest.Builder Clear()
            {
                this.result = SetRolesRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public SetRolesRequest.Builder ClearAgentId()
            {
                this.PrepareBuilder();
                this.result.hasAgentId = false;
                this.result.agentId_ = null;
                return this;
            }

            public SetRolesRequest.Builder ClearMemberId()
            {
                this.PrepareBuilder();
                this.result.memberId_.Clear();
                return this;
            }

            public SetRolesRequest.Builder ClearRole()
            {
                this.PrepareBuilder();
                this.result.role_.Clear();
                return this;
            }

            public override SetRolesRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new SetRolesRequest.Builder(this.result);
                }
                return new SetRolesRequest.Builder().MergeFrom(this.result);
            }

            public EntityId GetMemberId(int index)
            {
                return this.result.GetMemberId(index);
            }

            [CLSCompliant(false)]
            public uint GetRole(int index)
            {
                return this.result.GetRole(index);
            }

            public SetRolesRequest.Builder MergeAgentId(EntityId value)
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

            public override SetRolesRequest.Builder MergeFrom(SetRolesRequest other)
            {
                if (other != SetRolesRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAgentId)
                    {
                        this.MergeAgentId(other.AgentId);
                    }
                    if (other.role_.Count != 0)
                    {
                        this.result.role_.Add(other.role_);
                    }
                    if (other.memberId_.Count != 0)
                    {
                        this.result.memberId_.Add(other.memberId_);
                    }
                }
                return this;
            }

            public override SetRolesRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override SetRolesRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is SetRolesRequest)
                {
                    return this.MergeFrom((SetRolesRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override SetRolesRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    EntityId.Builder builder;
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(SetRolesRequest._setRolesRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = SetRolesRequest._setRolesRequestFieldTags[index];
                        }
                        else
                        {
                            this.ParseUnknownField(input, extensionRegistry, num, str);
                            continue;
                        }
                    }
                    switch (num)
                    {
                        case 0x10:
                        case 0x12:
                        {
                            input.ReadUInt32Array(num, str, this.result.role_);
                            continue;
                        }
                        case 0:
                            throw InvalidProtocolBufferException.InvalidTag();

                        case 10:
                            goto Label_00A8;

                        case 0x1a:
                            goto Label_00FC;

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
                Label_00A8:
                    builder = EntityId.CreateBuilder();
                    if (this.result.hasAgentId)
                    {
                        builder.MergeFrom(this.AgentId);
                    }
                    input.ReadMessage(builder, extensionRegistry);
                    this.AgentId = builder.BuildPartial();
                    continue;
                Label_00FC:
                    input.ReadMessageArray<EntityId>(num, str, this.result.memberId_, EntityId.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private SetRolesRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    SetRolesRequest result = this.result;
                    this.result = new SetRolesRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public SetRolesRequest.Builder SetAgentId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasAgentId = true;
                this.result.agentId_ = value;
                return this;
            }

            public SetRolesRequest.Builder SetAgentId(EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasAgentId = true;
                this.result.agentId_ = builderForValue.Build();
                return this;
            }

            public SetRolesRequest.Builder SetMemberId(int index, EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.memberId_[index] = value;
                return this;
            }

            public SetRolesRequest.Builder SetMemberId(int index, EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.memberId_[index] = builderForValue.Build();
                return this;
            }

            [CLSCompliant(false)]
            public SetRolesRequest.Builder SetRole(int index, uint value)
            {
                this.PrepareBuilder();
                this.result.role_[index] = value;
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

            public override SetRolesRequest DefaultInstanceForType
            {
                get
                {
                    return SetRolesRequest.DefaultInstance;
                }
            }

            public bool HasAgentId
            {
                get
                {
                    return this.result.hasAgentId;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public int MemberIdCount
            {
                get
                {
                    return this.result.MemberIdCount;
                }
            }

            public IPopsicleList<EntityId> MemberIdList
            {
                get
                {
                    return this.PrepareBuilder().memberId_;
                }
            }

            protected override SetRolesRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int RoleCount
            {
                get
                {
                    return this.result.RoleCount;
                }
            }

            [CLSCompliant(false)]
            public IPopsicleList<uint> RoleList
            {
                get
                {
                    return this.PrepareBuilder().role_;
                }
            }

            protected override SetRolesRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

