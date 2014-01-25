namespace bnet.protocol.game_master
{
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class RegisterUtilitiesRequest : GeneratedMessageLite<RegisterUtilitiesRequest, Builder>
    {
        private static readonly string[] _registerUtilitiesRequestFieldNames = new string[] { "attribute", "program_id", "state" };
        private static readonly uint[] _registerUtilitiesRequestFieldTags = new uint[] { 10, 0x1d, 0x12 };
        private PopsicleList<bnet.protocol.game_master.Attribute> attribute_ = new PopsicleList<bnet.protocol.game_master.Attribute>();
        public const int AttributeFieldNumber = 1;
        private static readonly RegisterUtilitiesRequest defaultInstance = new RegisterUtilitiesRequest().MakeReadOnly();
        private bool hasProgramId;
        private bool hasState;
        private int memoizedSerializedSize = -1;
        private uint programId_;
        public const int ProgramIdFieldNumber = 3;
        private ServerState state_;
        public const int StateFieldNumber = 2;

        static RegisterUtilitiesRequest()
        {
            object.ReferenceEquals(GameMaster.Descriptor, null);
        }

        private RegisterUtilitiesRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(RegisterUtilitiesRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            RegisterUtilitiesRequest request = obj as RegisterUtilitiesRequest;
            if (request == null)
            {
                return false;
            }
            if (this.attribute_.Count != request.attribute_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.attribute_.Count; i++)
            {
                if (!this.attribute_[i].Equals(request.attribute_[i]))
                {
                    return false;
                }
            }
            if ((this.hasState != request.hasState) || (this.hasState && !this.state_.Equals(request.state_)))
            {
                return false;
            }
            return ((this.hasProgramId == request.hasProgramId) && (!this.hasProgramId || this.programId_.Equals(request.programId_)));
        }

        public bnet.protocol.game_master.Attribute GetAttribute(int index)
        {
            return this.attribute_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<bnet.protocol.game_master.Attribute> enumerator = this.attribute_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    bnet.protocol.game_master.Attribute current = enumerator.Current;
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
            if (this.hasState)
            {
                hashCode ^= this.state_.GetHashCode();
            }
            if (this.hasProgramId)
            {
                hashCode ^= this.programId_.GetHashCode();
            }
            return hashCode;
        }

        private RegisterUtilitiesRequest MakeReadOnly()
        {
            this.attribute_.MakeReadOnly();
            return this;
        }

        public static RegisterUtilitiesRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static RegisterUtilitiesRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static RegisterUtilitiesRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static RegisterUtilitiesRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static RegisterUtilitiesRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static RegisterUtilitiesRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static RegisterUtilitiesRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static RegisterUtilitiesRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static RegisterUtilitiesRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static RegisterUtilitiesRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<RegisterUtilitiesRequest, Builder>.PrintField<bnet.protocol.game_master.Attribute>("attribute", this.attribute_, writer);
            GeneratedMessageLite<RegisterUtilitiesRequest, Builder>.PrintField("state", this.hasState, this.state_, writer);
            GeneratedMessageLite<RegisterUtilitiesRequest, Builder>.PrintField("program_id", this.hasProgramId, this.programId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _registerUtilitiesRequestFieldNames;
            if (this.attribute_.Count > 0)
            {
                output.WriteMessageArray<bnet.protocol.game_master.Attribute>(1, strArray[0], this.attribute_);
            }
            if (this.hasState)
            {
                output.WriteMessage(2, strArray[2], this.State);
            }
            if (this.hasProgramId)
            {
                output.WriteFixed32(3, strArray[1], this.ProgramId);
            }
        }

        public int AttributeCount
        {
            get
            {
                return this.attribute_.Count;
            }
        }

        public IList<bnet.protocol.game_master.Attribute> AttributeList
        {
            get
            {
                return this.attribute_;
            }
        }

        public static RegisterUtilitiesRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override RegisterUtilitiesRequest DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasProgramId
        {
            get
            {
                return this.hasProgramId;
            }
        }

        public bool HasState
        {
            get
            {
                return this.hasState;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasProgramId)
                {
                    return false;
                }
                IEnumerator<bnet.protocol.game_master.Attribute> enumerator = this.AttributeList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        bnet.protocol.game_master.Attribute current = enumerator.Current;
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

        [CLSCompliant(false)]
        public uint ProgramId
        {
            get
            {
                return this.programId_;
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
                    IEnumerator<bnet.protocol.game_master.Attribute> enumerator = this.AttributeList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            bnet.protocol.game_master.Attribute current = enumerator.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, current);
                        }
                    }
                    finally
                    {
                        if (enumerator == null)
                        {
                        }
                        enumerator.Dispose();
                    }
                    if (this.hasState)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, this.State);
                    }
                    if (this.hasProgramId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed32Size(3, this.ProgramId);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        public ServerState State
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.state_ != null)
                {
                    goto Label_0012;
                }
                return ServerState.DefaultInstance;
            }
        }

        protected override RegisterUtilitiesRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<RegisterUtilitiesRequest, RegisterUtilitiesRequest.Builder>
        {
            private RegisterUtilitiesRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = RegisterUtilitiesRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(RegisterUtilitiesRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public RegisterUtilitiesRequest.Builder AddAttribute(bnet.protocol.game_master.Attribute value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.attribute_.Add(value);
                return this;
            }

            public RegisterUtilitiesRequest.Builder AddAttribute(bnet.protocol.game_master.Attribute.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.attribute_.Add(builderForValue.Build());
                return this;
            }

            public RegisterUtilitiesRequest.Builder AddRangeAttribute(IEnumerable<bnet.protocol.game_master.Attribute> values)
            {
                this.PrepareBuilder();
                this.result.attribute_.Add(values);
                return this;
            }

            public override RegisterUtilitiesRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override RegisterUtilitiesRequest.Builder Clear()
            {
                this.result = RegisterUtilitiesRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public RegisterUtilitiesRequest.Builder ClearAttribute()
            {
                this.PrepareBuilder();
                this.result.attribute_.Clear();
                return this;
            }

            public RegisterUtilitiesRequest.Builder ClearProgramId()
            {
                this.PrepareBuilder();
                this.result.hasProgramId = false;
                this.result.programId_ = 0;
                return this;
            }

            public RegisterUtilitiesRequest.Builder ClearState()
            {
                this.PrepareBuilder();
                this.result.hasState = false;
                this.result.state_ = null;
                return this;
            }

            public override RegisterUtilitiesRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new RegisterUtilitiesRequest.Builder(this.result);
                }
                return new RegisterUtilitiesRequest.Builder().MergeFrom(this.result);
            }

            public bnet.protocol.game_master.Attribute GetAttribute(int index)
            {
                return this.result.GetAttribute(index);
            }

            public override RegisterUtilitiesRequest.Builder MergeFrom(RegisterUtilitiesRequest other)
            {
                if (other != RegisterUtilitiesRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.attribute_.Count != 0)
                    {
                        this.result.attribute_.Add(other.attribute_);
                    }
                    if (other.HasState)
                    {
                        this.MergeState(other.State);
                    }
                    if (other.HasProgramId)
                    {
                        this.ProgramId = other.ProgramId;
                    }
                }
                return this;
            }

            public override RegisterUtilitiesRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override RegisterUtilitiesRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is RegisterUtilitiesRequest)
                {
                    return this.MergeFrom((RegisterUtilitiesRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override RegisterUtilitiesRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(RegisterUtilitiesRequest._registerUtilitiesRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = RegisterUtilitiesRequest._registerUtilitiesRequestFieldTags[index];
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
                            input.ReadMessageArray<bnet.protocol.game_master.Attribute>(num, str, this.result.attribute_, bnet.protocol.game_master.Attribute.DefaultInstance, extensionRegistry);
                            continue;
                        }
                        case 0x12:
                        {
                            ServerState.Builder builder = ServerState.CreateBuilder();
                            if (this.result.hasState)
                            {
                                builder.MergeFrom(this.State);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.State = builder.BuildPartial();
                            continue;
                        }
                        case 0x1d:
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
                    this.result.hasProgramId = input.ReadFixed32(ref this.result.programId_);
                }
                return this;
            }

            public RegisterUtilitiesRequest.Builder MergeState(ServerState value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasState && (this.result.state_ != ServerState.DefaultInstance))
                {
                    this.result.state_ = ServerState.CreateBuilder(this.result.state_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.state_ = value;
                }
                this.result.hasState = true;
                return this;
            }

            private RegisterUtilitiesRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    RegisterUtilitiesRequest result = this.result;
                    this.result = new RegisterUtilitiesRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public RegisterUtilitiesRequest.Builder SetAttribute(int index, bnet.protocol.game_master.Attribute value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.attribute_[index] = value;
                return this;
            }

            public RegisterUtilitiesRequest.Builder SetAttribute(int index, bnet.protocol.game_master.Attribute.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.attribute_[index] = builderForValue.Build();
                return this;
            }

            [CLSCompliant(false)]
            public RegisterUtilitiesRequest.Builder SetProgramId(uint value)
            {
                this.PrepareBuilder();
                this.result.hasProgramId = true;
                this.result.programId_ = value;
                return this;
            }

            public RegisterUtilitiesRequest.Builder SetState(ServerState value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasState = true;
                this.result.state_ = value;
                return this;
            }

            public RegisterUtilitiesRequest.Builder SetState(ServerState.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasState = true;
                this.result.state_ = builderForValue.Build();
                return this;
            }

            public int AttributeCount
            {
                get
                {
                    return this.result.AttributeCount;
                }
            }

            public IPopsicleList<bnet.protocol.game_master.Attribute> AttributeList
            {
                get
                {
                    return this.PrepareBuilder().attribute_;
                }
            }

            public override RegisterUtilitiesRequest DefaultInstanceForType
            {
                get
                {
                    return RegisterUtilitiesRequest.DefaultInstance;
                }
            }

            public bool HasProgramId
            {
                get
                {
                    return this.result.hasProgramId;
                }
            }

            public bool HasState
            {
                get
                {
                    return this.result.hasState;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override RegisterUtilitiesRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            [CLSCompliant(false)]
            public uint ProgramId
            {
                get
                {
                    return this.result.ProgramId;
                }
                set
                {
                    this.SetProgramId(value);
                }
            }

            public ServerState State
            {
                get
                {
                    return this.result.State;
                }
                set
                {
                    this.SetState(value);
                }
            }

            protected override RegisterUtilitiesRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

