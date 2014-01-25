namespace bnet.protocol.authentication
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class MemModuleLoadResponse : GeneratedMessageLite<MemModuleLoadResponse, Builder>
    {
        private static readonly string[] _memModuleLoadResponseFieldNames = new string[] { "data" };
        private static readonly uint[] _memModuleLoadResponseFieldTags = new uint[] { 10 };
        private ByteString data_ = ByteString.Empty;
        public const int DataFieldNumber = 1;
        private static readonly MemModuleLoadResponse defaultInstance = new MemModuleLoadResponse().MakeReadOnly();
        private bool hasData;
        private int memoizedSerializedSize = -1;

        static MemModuleLoadResponse()
        {
            object.ReferenceEquals(AuthenticationService.Descriptor, null);
        }

        private MemModuleLoadResponse()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(MemModuleLoadResponse prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            MemModuleLoadResponse response = obj as MemModuleLoadResponse;
            if (response == null)
            {
                return false;
            }
            return ((this.hasData == response.hasData) && (!this.hasData || this.data_.Equals(response.data_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasData)
            {
                hashCode ^= this.data_.GetHashCode();
            }
            return hashCode;
        }

        private MemModuleLoadResponse MakeReadOnly()
        {
            return this;
        }

        public static MemModuleLoadResponse ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static MemModuleLoadResponse ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static MemModuleLoadResponse ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static MemModuleLoadResponse ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static MemModuleLoadResponse ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static MemModuleLoadResponse ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static MemModuleLoadResponse ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static MemModuleLoadResponse ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static MemModuleLoadResponse ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static MemModuleLoadResponse ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<MemModuleLoadResponse, Builder>.PrintField("data", this.hasData, this.data_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _memModuleLoadResponseFieldNames;
            if (this.hasData)
            {
                output.WriteBytes(1, strArray[0], this.Data);
            }
        }

        public ByteString Data
        {
            get
            {
                return this.data_;
            }
        }

        public static MemModuleLoadResponse DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override MemModuleLoadResponse DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasData
        {
            get
            {
                return this.hasData;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasData)
                {
                    return false;
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
                    if (this.hasData)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBytesSize(1, this.Data);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override MemModuleLoadResponse ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<MemModuleLoadResponse, MemModuleLoadResponse.Builder>
        {
            private MemModuleLoadResponse result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = MemModuleLoadResponse.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(MemModuleLoadResponse cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override MemModuleLoadResponse BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override MemModuleLoadResponse.Builder Clear()
            {
                this.result = MemModuleLoadResponse.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public MemModuleLoadResponse.Builder ClearData()
            {
                this.PrepareBuilder();
                this.result.hasData = false;
                this.result.data_ = ByteString.Empty;
                return this;
            }

            public override MemModuleLoadResponse.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new MemModuleLoadResponse.Builder(this.result);
                }
                return new MemModuleLoadResponse.Builder().MergeFrom(this.result);
            }

            public override MemModuleLoadResponse.Builder MergeFrom(MemModuleLoadResponse other)
            {
                if (other != MemModuleLoadResponse.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasData)
                    {
                        this.Data = other.Data;
                    }
                }
                return this;
            }

            public override MemModuleLoadResponse.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override MemModuleLoadResponse.Builder MergeFrom(IMessageLite other)
            {
                if (other is MemModuleLoadResponse)
                {
                    return this.MergeFrom((MemModuleLoadResponse) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override MemModuleLoadResponse.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(MemModuleLoadResponse._memModuleLoadResponseFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = MemModuleLoadResponse._memModuleLoadResponseFieldTags[index];
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
                    this.result.hasData = input.ReadBytes(ref this.result.data_);
                }
                return this;
            }

            private MemModuleLoadResponse PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    MemModuleLoadResponse result = this.result;
                    this.result = new MemModuleLoadResponse();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public MemModuleLoadResponse.Builder SetData(ByteString value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasData = true;
                this.result.data_ = value;
                return this;
            }

            public ByteString Data
            {
                get
                {
                    return this.result.Data;
                }
                set
                {
                    this.SetData(value);
                }
            }

            public override MemModuleLoadResponse DefaultInstanceForType
            {
                get
                {
                    return MemModuleLoadResponse.DefaultInstance;
                }
            }

            public bool HasData
            {
                get
                {
                    return this.result.hasData;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override MemModuleLoadResponse MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override MemModuleLoadResponse.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

