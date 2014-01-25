namespace bnet.protocol.connection
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class EchoRequest : GeneratedMessageLite<EchoRequest, Builder>
    {
        private static readonly string[] _echoRequestFieldNames = new string[] { "network_only", "payload", "time" };
        private static readonly uint[] _echoRequestFieldTags = new uint[] { 0x10, 0x1a, 9 };
        private static readonly EchoRequest defaultInstance = new EchoRequest().MakeReadOnly();
        private bool hasNetworkOnly;
        private bool hasPayload;
        private bool hasTime;
        private int memoizedSerializedSize = -1;
        private bool networkOnly_;
        public const int NetworkOnlyFieldNumber = 2;
        private ByteString payload_ = ByteString.Empty;
        public const int PayloadFieldNumber = 3;
        private ulong time_;
        public const int TimeFieldNumber = 1;

        static EchoRequest()
        {
            object.ReferenceEquals(Connect.Descriptor, null);
        }

        private EchoRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(EchoRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            EchoRequest request = obj as EchoRequest;
            if (request == null)
            {
                return false;
            }
            if ((this.hasTime != request.hasTime) || (this.hasTime && !this.time_.Equals(request.time_)))
            {
                return false;
            }
            if ((this.hasNetworkOnly != request.hasNetworkOnly) || (this.hasNetworkOnly && !this.networkOnly_.Equals(request.networkOnly_)))
            {
                return false;
            }
            return ((this.hasPayload == request.hasPayload) && (!this.hasPayload || this.payload_.Equals(request.payload_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasTime)
            {
                hashCode ^= this.time_.GetHashCode();
            }
            if (this.hasNetworkOnly)
            {
                hashCode ^= this.networkOnly_.GetHashCode();
            }
            if (this.hasPayload)
            {
                hashCode ^= this.payload_.GetHashCode();
            }
            return hashCode;
        }

        private EchoRequest MakeReadOnly()
        {
            return this;
        }

        public static EchoRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static EchoRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static EchoRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static EchoRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static EchoRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static EchoRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static EchoRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static EchoRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static EchoRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static EchoRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<EchoRequest, Builder>.PrintField("time", this.hasTime, this.time_, writer);
            GeneratedMessageLite<EchoRequest, Builder>.PrintField("network_only", this.hasNetworkOnly, this.networkOnly_, writer);
            GeneratedMessageLite<EchoRequest, Builder>.PrintField("payload", this.hasPayload, this.payload_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _echoRequestFieldNames;
            if (this.hasTime)
            {
                output.WriteFixed64(1, strArray[2], this.Time);
            }
            if (this.hasNetworkOnly)
            {
                output.WriteBool(2, strArray[0], this.NetworkOnly);
            }
            if (this.hasPayload)
            {
                output.WriteBytes(3, strArray[1], this.Payload);
            }
        }

        public static EchoRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override EchoRequest DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasNetworkOnly
        {
            get
            {
                return this.hasNetworkOnly;
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

        public bool NetworkOnly
        {
            get
            {
                return this.networkOnly_;
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
                    if (this.hasNetworkOnly)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(2, this.NetworkOnly);
                    }
                    if (this.hasPayload)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBytesSize(3, this.Payload);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override EchoRequest ThisMessage
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

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<EchoRequest, EchoRequest.Builder>
        {
            private EchoRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = EchoRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(EchoRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override EchoRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override EchoRequest.Builder Clear()
            {
                this.result = EchoRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public EchoRequest.Builder ClearNetworkOnly()
            {
                this.PrepareBuilder();
                this.result.hasNetworkOnly = false;
                this.result.networkOnly_ = false;
                return this;
            }

            public EchoRequest.Builder ClearPayload()
            {
                this.PrepareBuilder();
                this.result.hasPayload = false;
                this.result.payload_ = ByteString.Empty;
                return this;
            }

            public EchoRequest.Builder ClearTime()
            {
                this.PrepareBuilder();
                this.result.hasTime = false;
                this.result.time_ = 0L;
                return this;
            }

            public override EchoRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new EchoRequest.Builder(this.result);
                }
                return new EchoRequest.Builder().MergeFrom(this.result);
            }

            public override EchoRequest.Builder MergeFrom(EchoRequest other)
            {
                if (other != EchoRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasTime)
                    {
                        this.Time = other.Time;
                    }
                    if (other.HasNetworkOnly)
                    {
                        this.NetworkOnly = other.NetworkOnly;
                    }
                    if (other.HasPayload)
                    {
                        this.Payload = other.Payload;
                    }
                }
                return this;
            }

            public override EchoRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override EchoRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is EchoRequest)
                {
                    return this.MergeFrom((EchoRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override EchoRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(EchoRequest._echoRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = EchoRequest._echoRequestFieldTags[index];
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
                        case 0x10:
                        {
                            this.result.hasNetworkOnly = input.ReadBool(ref this.result.networkOnly_);
                            continue;
                        }
                        case 0x1a:
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

            private EchoRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    EchoRequest result = this.result;
                    this.result = new EchoRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public EchoRequest.Builder SetNetworkOnly(bool value)
            {
                this.PrepareBuilder();
                this.result.hasNetworkOnly = true;
                this.result.networkOnly_ = value;
                return this;
            }

            public EchoRequest.Builder SetPayload(ByteString value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasPayload = true;
                this.result.payload_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public EchoRequest.Builder SetTime(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasTime = true;
                this.result.time_ = value;
                return this;
            }

            public override EchoRequest DefaultInstanceForType
            {
                get
                {
                    return EchoRequest.DefaultInstance;
                }
            }

            public bool HasNetworkOnly
            {
                get
                {
                    return this.result.hasNetworkOnly;
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

            protected override EchoRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public bool NetworkOnly
            {
                get
                {
                    return this.result.NetworkOnly;
                }
                set
                {
                    this.SetNetworkOnly(value);
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

            protected override EchoRequest.Builder ThisBuilder
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

