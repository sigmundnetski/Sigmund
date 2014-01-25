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

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class RegisterServerRequest : GeneratedMessageLite<RegisterServerRequest, Builder>
    {
        private static readonly string[] _registerServerRequestFieldNames = new string[] { "attribute", "program_id", "state" };
        private static readonly uint[] _registerServerRequestFieldTags = new uint[] { 10, 0x1d, 0x12 };
        private PopsicleList<bnet.protocol.game_master.Attribute> attribute_ = new PopsicleList<bnet.protocol.game_master.Attribute>();
        public const int AttributeFieldNumber = 1;
        private static readonly RegisterServerRequest defaultInstance = new RegisterServerRequest().MakeReadOnly();
        private bool hasProgramId;
        private bool hasState;
        private int memoizedSerializedSize = -1;
        private uint programId_;
        public const int ProgramIdFieldNumber = 3;
        private ServerState state_;
        public const int StateFieldNumber = 2;

        static RegisterServerRequest()
        {
            object.ReferenceEquals(GameMaster.Descriptor, null);
        }

        private RegisterServerRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(RegisterServerRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            RegisterServerRequest request = obj as RegisterServerRequest;
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

        private RegisterServerRequest MakeReadOnly()
        {
            this.attribute_.MakeReadOnly();
            return this;
        }

        public static RegisterServerRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static RegisterServerRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static RegisterServerRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static RegisterServerRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static RegisterServerRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static RegisterServerRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static RegisterServerRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static RegisterServerRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static RegisterServerRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static RegisterServerRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<RegisterServerRequest, Builder>.PrintField<bnet.protocol.game_master.Attribute>("attribute", this.attribute_, writer);
            GeneratedMessageLite<RegisterServerRequest, Builder>.PrintField("state", this.hasState, this.state_, writer);
            GeneratedMessageLite<RegisterServerRequest, Builder>.PrintField("program_id", this.hasProgramId, this.programId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _registerServerRequestFieldNames;
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

        public static RegisterServerRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override RegisterServerRequest DefaultInstanceForType
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

        protected override RegisterServerRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<RegisterServerRequest, RegisterServerRequest.Builder>
        {
            private RegisterServerRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = RegisterServerRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(RegisterServerRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public RegisterServerRequest.Builder AddAttribute(bnet.protocol.game_master.Attribute value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.attribute_.Add(value);
                return this;
            }

            public RegisterServerRequest.Builder AddAttribute(bnet.protocol.game_master.Attribute.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.attribute_.Add(builderForValue.Build());
                return this;
            }

            public RegisterServerRequest.Builder AddRangeAttribute(IEnumerable<bnet.protocol.game_master.Attribute> values)
            {
                this.PrepareBuilder();
                this.result.attribute_.Add(values);
                return this;
            }

            public override RegisterServerRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override RegisterServerRequest.Builder Clear()
            {
                this.result = RegisterServerRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public RegisterServerRequest.Builder ClearAttribute()
            {
                this.PrepareBuilder();
                this.result.attribute_.Clear();
                return this;
            }

            public RegisterServerRequest.Builder ClearProgramId()
            {
                this.PrepareBuilder();
                this.result.hasProgramId = false;
                this.result.programId_ = 0;
                return this;
            }

            public RegisterServerRequest.Builder ClearState()
            {
                this.PrepareBuilder();
                this.result.hasState = false;
                this.result.state_ = null;
                return this;
            }

            public override RegisterServerRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new RegisterServerRequest.Builder(this.result);
                }
                return new RegisterServerRequest.Builder().MergeFrom(this.result);
            }

            public bnet.protocol.game_master.Attribute GetAttribute(int index)
            {
                return this.result.GetAttribute(index);
            }

            public override RegisterServerRequest.Builder MergeFrom(RegisterServerRequest other)
            {
                if (other != RegisterServerRequest.DefaultInstance)
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

            public override RegisterServerRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override RegisterServerRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is RegisterServerRequest)
                {
                    return this.MergeFrom((RegisterServerRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override RegisterServerRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(RegisterServerRequest._registerServerRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = RegisterServerRequest._registerServerRequestFieldTags[index];
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

            public RegisterServerRequest.Builder MergeState(ServerState value)
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

            private RegisterServerRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    RegisterServerRequest result = this.result;
                    this.result = new RegisterServerRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public RegisterServerRequest.Builder SetAttribute(int index, bnet.protocol.game_master.Attribute value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.attribute_[index] = value;
                return this;
            }

            public RegisterServerRequest.Builder SetAttribute(int index, bnet.protocol.game_master.Attribute.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.attribute_[index] = builderForValue.Build();
                return this;
            }

            [CLSCompliant(false)]
            public RegisterServerRequest.Builder SetProgramId(uint value)
            {
                this.PrepareBuilder();
                this.result.hasProgramId = true;
                this.result.programId_ = value;
                return this;
            }

            public RegisterServerRequest.Builder SetState(ServerState value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasState = true;
                this.result.state_ = value;
                return this;
            }

            public RegisterServerRequest.Builder SetState(ServerState.Builder builderForValue)
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

            public override RegisterServerRequest DefaultInstanceForType
            {
                get
                {
                    return RegisterServerRequest.DefaultInstance;
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

            protected override RegisterServerRequest MessageBeingBuilt
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

            protected override RegisterServerRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

