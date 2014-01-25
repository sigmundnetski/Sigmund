namespace bnet.protocol.connection
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class EchoResponse : GeneratedMessageLite<EchoResponse, Builder>
    {
        private static readonly string[] _echoResponseFieldNames = new string[] { "payload", "time" };
        private static readonly uint[] _echoResponseFieldTags = new uint[] { 0x12, 9 };
        private static readonly EchoResponse defaultInstance = new EchoResponse().MakeReadOnly();
        private bool hasPayload;
        private bool hasTime;
        private int memoizedSerializedSize = -1;
        private ByteString payload_ = ByteString.Empty;
        public const int PayloadFieldNumber = 2;
        private ulong time_;
        public const int TimeFieldNumber = 1;

        static EchoResponse()
        {
            object.ReferenceEquals(Connect.Descriptor, null);
        }

        private EchoResponse()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(EchoResponse prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            EchoResponse response = obj as EchoResponse;
            if (response == null)
            {
                return false;
            }
            if ((this.hasTime != response.hasTime) || (this.hasTime && !this.time_.Equals(response.time_)))
            {
                return false;
            }
            return ((this.hasPayload == response.hasPayload) && (!this.hasPayload || this.payload_.Equals(response.payload_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasTime)
            {
                hashCode ^= this.time_.GetHashCode();
            }
            if (this.hasPayload)
            {
                hashCode ^= this.payload_.GetHashCode();
            }
            return hashCode;
        }

        private EchoResponse MakeReadOnly()
        {
            return this;
        }

        public static EchoResponse ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static EchoResponse ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static EchoResponse ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static EchoResponse ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static EchoResponse ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static EchoResponse ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static EchoResponse ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static EchoResponse ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static EchoResponse ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static EchoResponse ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<EchoResponse, Builder>.PrintField("time", this.hasTime, this.time_, writer);
            GeneratedMessageLite<EchoResponse, Builder>.PrintField("payload", this.hasPayload, this.payload_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _echoResponseFieldNames;
            if (this.hasTime)
            {
                output.WriteFixed64(1, strArray[1], this.Time);
            }
            if (this.hasPayload)
            {
                output.WriteBytes(2, strArray[0], this.Payload);
            }
        }

        public static EchoResponse DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override EchoResponse DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasPayload
        {
            get
            {
                return this.hasPayload;
            }
        }

        public bool HasTime
        {
            get
            {
                return this.hasTime;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                return true;
            }
        }

        public ByteString Payload
        {
            get
            {
                return this.payload_;
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
                    if (this.hasTime)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed64Size(1, this.Time);
                    }
                    if (this.hasPayload)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBytesSize(2, this.Payload);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override EchoResponse ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CLSCompliant(false)]
        public ulong Time
        {
            get
            {
                return this.time_;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<EchoResponse, EchoResponse.Builder>
        {
            private EchoResponse result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = EchoResponse.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(EchoResponse cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override EchoResponse BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override EchoResponse.Builder Clear()
            {
                this.result = EchoResponse.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public EchoResponse.Builder ClearPayload()
            {
                this.PrepareBuilder();
                this.result.hasPayload = false;
                this.result.payload_ = ByteString.Empty;
                return this;
            }

            public EchoResponse.Builder ClearTime()
            {
                this.PrepareBuilder();
                this.result.hasTime = false;
                this.result.time_ = 0L;
                return this;
            }

            public override EchoResponse.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new EchoResponse.Builder(this.result);
                }
                return new EchoResponse.Builder().MergeFrom(this.result);
            }

            public override EchoResponse.Builder MergeFrom(EchoResponse other)
            {
                if (other != EchoResponse.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasTime)
                    {
                        this.Time = other.Time;
                    }
                    if (other.HasPayload)
                    {
                        this.Payload = other.Payload;
                    }
                }
                return this;
            }

            public override EchoResponse.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override EchoResponse.Builder MergeFrom(IMessageLite other)
            {
                if (other is EchoResponse)
                {
                    return this.MergeFrom((EchoResponse) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override EchoResponse.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(EchoResponse._echoResponseFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = EchoResponse._echoResponseFieldTags[index];
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

                        case 9:
                        {
                            this.result.hasTime = input.ReadFixed64(ref this.result.time_);
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
                    this.result.hasPayload = input.ReadBytes(ref this.result.payload_);
                }
                return this;
            }

            private EchoResponse PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    EchoResponse result = this.result;
                    this.result = new EchoResponse();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public EchoResponse.Builder SetPayload(ByteString value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasPayload = true;
                this.result.payload_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public EchoResponse.Builder SetTime(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasTime = true;
                this.result.time_ = value;
                return this;
            }

            public override EchoResponse DefaultInstanceForType
            {
                get
                {
                    return EchoResponse.DefaultInstance;
                }
            }

            public bool HasPayload
            {
                get
                {
                    return this.result.hasPayload;
                }
            }

            public bool HasTime
            {
                get
                {
                    return this.result.hasTime;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override EchoResponse MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public ByteString Payload
            {
                get
                {
                    return this.result.Payload;
                }
                set
                {
                    this.SetPayload(value);
                }
            }

            protected override EchoResponse.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            [CLSCompliant(false)]
            public ulong Time
            {
                get
                {
                    return this.result.Time;
                }
                set
                {
                    this.SetTime(value);
                }
            }
        }
    }
}

