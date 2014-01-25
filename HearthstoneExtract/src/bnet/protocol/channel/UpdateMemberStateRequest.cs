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
    public sealed class UpdateMemberStateRequest : GeneratedMessageLite<UpdateMemberStateRequest, Builder>
    {
        private static readonly string[] _updateMemberStateRequestFieldNames = new string[] { "agent_id", "state_change" };
        private static readonly uint[] _updateMemberStateRequestFieldTags = new uint[] { 10, 0x12 };
        private EntityId agentId_;
        public const int AgentIdFieldNumber = 1;
        private static readonly UpdateMemberStateRequest defaultInstance = new UpdateMemberStateRequest().MakeReadOnly();
        private bool hasAgentId;
        private int memoizedSerializedSize = -1;
        private PopsicleList<Member> stateChange_ = new PopsicleList<Member>();
        public const int StateChangeFieldNumber = 2;

        static UpdateMemberStateRequest()
        {
            object.ReferenceEquals(ChannelService.Descriptor, null);
        }

        private UpdateMemberStateRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(UpdateMemberStateRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            UpdateMemberStateRequest request = obj as UpdateMemberStateRequest;
            if (request == null)
            {
                return false;
            }
            if ((this.hasAgentId != request.hasAgentId) || (this.hasAgentId && !this.agentId_.Equals(request.agentId_)))
            {
                return false;
            }
            if (this.stateChange_.Count != request.stateChange_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.stateChange_.Count; i++)
            {
                if (!this.stateChange_[i].Equals(request.stateChange_[i]))
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
            IEnumerator<Member> enumerator = this.stateChange_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    Member current = enumerator.Current;
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
            return hashCode;
        }

        public Member GetStateChange(int index)
        {
            return this.stateChange_[index];
        }

        private UpdateMemberStateRequest MakeReadOnly()
        {
            this.stateChange_.MakeReadOnly();
            return this;
        }

        public static UpdateMemberStateRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static UpdateMemberStateRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static UpdateMemberStateRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static UpdateMemberStateRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static UpdateMemberStateRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static UpdateMemberStateRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static UpdateMemberStateRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static UpdateMemberStateRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static UpdateMemberStateRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static UpdateMemberStateRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<UpdateMemberStateRequest, Builder>.PrintField("agent_id", this.hasAgentId, this.agentId_, writer);
            GeneratedMessageLite<UpdateMemberStateRequest, Builder>.PrintField<Member>("state_change", this.stateChange_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _updateMemberStateRequestFieldNames;
            if (this.hasAgentId)
            {
                output.WriteMessage(1, strArray[0], this.AgentId);
            }
            if (this.stateChange_.Count > 0)
            {
                output.WriteMessageArray<Member>(2, strArray[1], this.stateChange_);
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

        public static UpdateMemberStateRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override UpdateMemberStateRequest DefaultInstanceForType
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
                IEnumerator<Member> enumerator = this.StateChangeList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        Member current = enumerator.Current;
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
                    IEnumerator<Member> enumerator = this.StateChangeList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            Member current = enumerator.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, current);
                        }
                    }
                    finally
                    {
                        if (enumerator == null)
                        {
                        }
                        enumerator.Dispose();
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        public int StateChangeCount
        {
            get
            {
                return this.stateChange_.Count;
            }
        }

        public IList<Member> StateChangeList
        {
            get
            {
                return this.stateChange_;
            }
        }

        protected override UpdateMemberStateRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<UpdateMemberStateRequest, UpdateMemberStateRequest.Builder>
        {
            private UpdateMemberStateRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = UpdateMemberStateRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(UpdateMemberStateRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public UpdateMemberStateRequest.Builder AddRangeStateChange(IEnumerable<Member> values)
            {
                this.PrepareBuilder();
                this.result.stateChange_.Add(values);
                return this;
            }

            public UpdateMemberStateRequest.Builder AddStateChange(Member value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.stateChange_.Add(value);
                return this;
            }

            public UpdateMemberStateRequest.Builder AddStateChange(Member.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.stateChange_.Add(builderForValue.Build());
                return this;
            }

            public override UpdateMemberStateRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override UpdateMemberStateRequest.Builder Clear()
            {
                this.result = UpdateMemberStateRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public UpdateMemberStateRequest.Builder ClearAgentId()
            {
                this.PrepareBuilder();
                this.result.hasAgentId = false;
                this.result.agentId_ = null;
                return this;
            }

            public UpdateMemberStateRequest.Builder ClearStateChange()
            {
                this.PrepareBuilder();
                this.result.stateChange_.Clear();
                return this;
            }

            public override UpdateMemberStateRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new UpdateMemberStateRequest.Builder(this.result);
                }
                return new UpdateMemberStateRequest.Builder().MergeFrom(this.result);
            }

            public Member GetStateChange(int index)
            {
                return this.result.GetStateChange(index);
            }

            public UpdateMemberStateRequest.Builder MergeAgentId(EntityId value)
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

            public override UpdateMemberStateRequest.Builder MergeFrom(UpdateMemberStateRequest other)
            {
                if (other != UpdateMemberStateRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAgentId)
                    {
                        this.MergeAgentId(other.AgentId);
                    }
                    if (other.stateChange_.Count != 0)
                    {
                        this.result.stateChange_.Add(other.stateChange_);
                    }
                }
                return this;
            }

            public override UpdateMemberStateRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override UpdateMemberStateRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is UpdateMemberStateRequest)
                {
                    return this.MergeFrom((UpdateMemberStateRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override UpdateMemberStateRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(UpdateMemberStateRequest._updateMemberStateRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = UpdateMemberStateRequest._updateMemberStateRequestFieldTags[index];
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
                    input.ReadMessageArray<Member>(num, str, this.result.stateChange_, Member.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private UpdateMemberStateRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    UpdateMemberStateRequest result = this.result;
                    this.result = new UpdateMemberStateRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public UpdateMemberStateRequest.Builder SetAgentId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasAgentId = true;
                this.result.agentId_ = value;
                return this;
            }

            public UpdateMemberStateRequest.Builder SetAgentId(EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasAgentId = true;
                this.result.agentId_ = builderForValue.Build();
                return this;
            }

            public UpdateMemberStateRequest.Builder SetStateChange(int index, Member value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.stateChange_[index] = value;
                return this;
            }

            public UpdateMemberStateRequest.Builder SetStateChange(int index, Member.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.stateChange_[index] = builderForValue.Build();
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

            public override UpdateMemberStateRequest DefaultInstanceForType
            {
                get
                {
                    return UpdateMemberStateRequest.DefaultInstance;
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

            protected override UpdateMemberStateRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int StateChangeCount
            {
                get
                {
                    return this.result.StateChangeCount;
                }
            }

            public IPopsicleList<Member> StateChangeList
            {
                get
                {
                    return this.PrepareBuilder().stateChange_;
                }
            }

            protected override UpdateMemberStateRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

