namespace bnet.protocol.game_utilities
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
    public sealed class ServerRequest : GeneratedMessageLite<ServerRequest, Builder>
    {
        private static readonly string[] _serverRequestFieldNames = new string[] { "attribute", "host", "program" };
        private static readonly uint[] _serverRequestFieldTags = new uint[] { 10, 0x1a, 0x15 };
        private PopsicleList<bnet.protocol.game_utilities.Attribute> attribute_ = new PopsicleList<bnet.protocol.game_utilities.Attribute>();
        public const int AttributeFieldNumber = 1;
        private static readonly ServerRequest defaultInstance = new ServerRequest().MakeReadOnly();
        private bool hasHost;
        private bool hasProgram;
        private ProcessId host_;
        public const int HostFieldNumber = 3;
        private int memoizedSerializedSize = -1;
        private uint program_;
        public const int ProgramFieldNumber = 2;

        static ServerRequest()
        {
            object.ReferenceEquals(GameUtils.Descriptor, null);
        }

        private ServerRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ServerRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ServerRequest request = obj as ServerRequest;
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
            if ((this.hasProgram != request.hasProgram) || (this.hasProgram && !this.program_.Equals(request.program_)))
            {
                return false;
            }
            return ((this.hasHost == request.hasHost) && (!this.hasHost || this.host_.Equals(request.host_)));
        }

        public bnet.protocol.game_utilities.Attribute GetAttribute(int index)
        {
            return this.attribute_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<bnet.protocol.game_utilities.Attribute> enumerator = this.attribute_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    bnet.protocol.game_utilities.Attribute current = enumerator.Current;
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
            if (this.hasProgram)
            {
                hashCode ^= this.program_.GetHashCode();
            }
            if (this.hasHost)
            {
                hashCode ^= this.host_.GetHashCode();
            }
            return hashCode;
        }

        private ServerRequest MakeReadOnly()
        {
            this.attribute_.MakeReadOnly();
            return this;
        }

        public static ServerRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ServerRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ServerRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ServerRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ServerRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ServerRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ServerRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ServerRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ServerRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ServerRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ServerRequest, Builder>.PrintField<bnet.protocol.game_utilities.Attribute>("attribute", this.attribute_, writer);
            GeneratedMessageLite<ServerRequest, Builder>.PrintField("program", this.hasProgram, this.program_, writer);
            GeneratedMessageLite<ServerRequest, Builder>.PrintField("host", this.hasHost, this.host_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _serverRequestFieldNames;
            if (this.attribute_.Count > 0)
            {
                output.WriteMessageArray<bnet.protocol.game_utilities.Attribute>(1, strArray[0], this.attribute_);
            }
            if (this.hasProgram)
            {
                output.WriteFixed32(2, strArray[2], this.Program);
            }
            if (this.hasHost)
            {
                output.WriteMessage(3, strArray[1], this.Host);
            }
        }

        public int AttributeCount
        {
            get
            {
                return this.attribute_.Count;
            }
        }

        public IList<bnet.protocol.game_utilities.Attribute> AttributeList
        {
            get
            {
                return this.attribute_;
            }
        }

        public static ServerRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ServerRequest DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasHost
        {
            get
            {
                return this.hasHost;
            }
        }

        public bool HasProgram
        {
            get
            {
                return this.hasProgram;
            }
        }

        public ProcessId Host
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.host_ != null)
                {
                    goto Label_0012;
                }
                return ProcessId.DefaultInstance;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasProgram)
                {
                    return false;
                }
                IEnumerator<bnet.protocol.game_utilities.Attribute> enumerator = this.AttributeList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        bnet.protocol.game_utilities.Attribute current = enumerator.Current;
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
                if (this.HasHost && !this.Host.IsInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        [CLSCompliant(false)]
        public uint Program
        {
            get
            {
                return this.program_;
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
                    IEnumerator<bnet.protocol.game_utilities.Attribute> enumerator = this.AttributeList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            bnet.protocol.game_utilities.Attribute current = enumerator.Current;
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
                    if (this.hasProgram)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed32Size(2, this.Program);
                    }
                    if (this.hasHost)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(3, this.Host);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ServerRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<ServerRequest, ServerRequest.Builder>
        {
            private ServerRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ServerRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ServerRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public ServerRequest.Builder AddAttribute(bnet.protocol.game_utilities.Attribute value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.attribute_.Add(value);
                return this;
            }

            public ServerRequest.Builder AddAttribute(bnet.protocol.game_utilities.Attribute.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.attribute_.Add(builderForValue.Build());
                return this;
            }

            public ServerRequest.Builder AddRangeAttribute(IEnumerable<bnet.protocol.game_utilities.Attribute> values)
            {
                this.PrepareBuilder();
                this.result.attribute_.Add(values);
                return this;
            }

            public override ServerRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ServerRequest.Builder Clear()
            {
                this.result = ServerRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ServerRequest.Builder ClearAttribute()
            {
                this.PrepareBuilder();
                this.result.attribute_.Clear();
                return this;
            }

            public ServerRequest.Builder ClearHost()
            {
                this.PrepareBuilder();
                this.result.hasHost = false;
                this.result.host_ = null;
                return this;
            }

            public ServerRequest.Builder ClearProgram()
            {
                this.PrepareBuilder();
                this.result.hasProgram = false;
                this.result.program_ = 0;
                return this;
            }

            public override ServerRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ServerRequest.Builder(this.result);
                }
                return new ServerRequest.Builder().MergeFrom(this.result);
            }

            public bnet.protocol.game_utilities.Attribute GetAttribute(int index)
            {
                return this.result.GetAttribute(index);
            }

            public override ServerRequest.Builder MergeFrom(ServerRequest other)
            {
                if (other != ServerRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.attribute_.Count != 0)
                    {
                        this.result.attribute_.Add(other.attribute_);
                    }
                    if (other.HasProgram)
                    {
                        this.Program = other.Program;
                    }
                    if (other.HasHost)
                    {
                        this.MergeHost(other.Host);
                    }
                }
                return this;
            }

            public override ServerRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ServerRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is ServerRequest)
                {
                    return this.MergeFrom((ServerRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ServerRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ServerRequest._serverRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ServerRequest._serverRequestFieldTags[index];
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
                            input.ReadMessageArray<bnet.protocol.game_utilities.Attribute>(num, str, this.result.attribute_, bnet.protocol.game_utilities.Attribute.DefaultInstance, extensionRegistry);
                            continue;
                        }
                        case 0x15:
                        {
                            this.result.hasProgram = input.ReadFixed32(ref this.result.program_);
                            continue;
                        }
                        case 0x1a:
                        {
                            ProcessId.Builder builder = ProcessId.CreateBuilder();
                            if (this.result.hasHost)
                            {
                                builder.MergeFrom(this.Host);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.Host = builder.BuildPartial();
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

            public ServerRequest.Builder MergeHost(ProcessId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasHost && (this.result.host_ != ProcessId.DefaultInstance))
                {
                    this.result.host_ = ProcessId.CreateBuilder(this.result.host_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.host_ = value;
                }
                this.result.hasHost = true;
                return this;
            }

            private ServerRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ServerRequest result = this.result;
                    this.result = new ServerRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ServerRequest.Builder SetAttribute(int index, bnet.protocol.game_utilities.Attribute value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.attribute_[index] = value;
                return this;
            }

            public ServerRequest.Builder SetAttribute(int index, bnet.protocol.game_utilities.Attribute.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.attribute_[index] = builderForValue.Build();
                return this;
            }

            public ServerRequest.Builder SetHost(ProcessId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasHost = true;
                this.result.host_ = value;
                return this;
            }

            public ServerRequest.Builder SetHost(ProcessId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasHost = true;
                this.result.host_ = builderForValue.Build();
                return this;
            }

            [CLSCompliant(false)]
            public ServerRequest.Builder SetProgram(uint value)
            {
                this.PrepareBuilder();
                this.result.hasProgram = true;
                this.result.program_ = value;
                return this;
            }

            public int AttributeCount
            {
                get
                {
                    return this.result.AttributeCount;
                }
            }

            public IPopsicleList<bnet.protocol.game_utilities.Attribute> AttributeList
            {
                get
                {
                    return this.PrepareBuilder().attribute_;
                }
            }

            public override ServerRequest DefaultInstanceForType
            {
                get
                {
                    return ServerRequest.DefaultInstance;
                }
            }

            public bool HasHost
            {
                get
                {
                    return this.result.hasHost;
                }
            }

            public bool HasProgram
            {
                get
                {
                    return this.result.hasProgram;
                }
            }

            public ProcessId Host
            {
                get
                {
                    return this.result.Host;
                }
                set
                {
                    this.SetHost(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override ServerRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            [CLSCompliant(false)]
            public uint Program
            {
                get
                {
                    return this.result.Program;
                }
                set
                {
                    this.SetProgram(value);
                }
            }

            protected override ServerRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

