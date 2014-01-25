namespace bnet.protocol.connection
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class ContentHandle : GeneratedMessageLite<ContentHandle, Builder>
    {
        private static readonly string[] _contentHandleFieldNames = new string[] { "hash", "proto_url", "region", "usage" };
        private static readonly uint[] _contentHandleFieldTags = new uint[] { 0x1a, 0x22, 13, 0x15 };
        private static readonly ContentHandle defaultInstance = new ContentHandle().MakeReadOnly();
        private ByteString hash_ = ByteString.Empty;
        private bool hasHash;
        public const int HashFieldNumber = 3;
        private bool hasProtoUrl;
        private bool hasRegion;
        private bool hasUsage;
        private int memoizedSerializedSize = -1;
        private string protoUrl_ = string.Empty;
        public const int ProtoUrlFieldNumber = 4;
        private uint region_;
        public const int RegionFieldNumber = 1;
        private uint usage_;
        public const int UsageFieldNumber = 2;

        static ContentHandle()
        {
            object.ReferenceEquals(Connect.Descriptor, null);
        }

        private ContentHandle()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ContentHandle prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ContentHandle handle = obj as ContentHandle;
            if (handle == null)
            {
                return false;
            }
            if ((this.hasRegion != handle.hasRegion) || (this.hasRegion && !this.region_.Equals(handle.region_)))
            {
                return false;
            }
            if ((this.hasUsage != handle.hasUsage) || (this.hasUsage && !this.usage_.Equals(handle.usage_)))
            {
                return false;
            }
            if ((this.hasHash != handle.hasHash) || (this.hasHash && !this.hash_.Equals(handle.hash_)))
            {
                return false;
            }
            return ((this.hasProtoUrl == handle.hasProtoUrl) && (!this.hasProtoUrl || this.protoUrl_.Equals(handle.protoUrl_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasRegion)
            {
                hashCode ^= this.region_.GetHashCode();
            }
            if (this.hasUsage)
            {
                hashCode ^= this.usage_.GetHashCode();
            }
            if (this.hasHash)
            {
                hashCode ^= this.hash_.GetHashCode();
            }
            if (this.hasProtoUrl)
            {
                hashCode ^= this.protoUrl_.GetHashCode();
            }
            return hashCode;
        }

        private ContentHandle MakeReadOnly()
        {
            return this;
        }

        public static ContentHandle ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ContentHandle ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ContentHandle ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ContentHandle ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ContentHandle ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ContentHandle ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ContentHandle ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ContentHandle ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ContentHandle ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ContentHandle ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ContentHandle, Builder>.PrintField("region", this.hasRegion, this.region_, writer);
            GeneratedMessageLite<ContentHandle, Builder>.PrintField("usage", this.hasUsage, this.usage_, writer);
            GeneratedMessageLite<ContentHandle, Builder>.PrintField("hash", this.hasHash, this.hash_, writer);
            GeneratedMessageLite<ContentHandle, Builder>.PrintField("proto_url", this.hasProtoUrl, this.protoUrl_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _contentHandleFieldNames;
            if (this.hasRegion)
            {
                output.WriteFixed32(1, strArray[2], this.Region);
            }
            if (this.hasUsage)
            {
                output.WriteFixed32(2, strArray[3], this.Usage);
            }
            if (this.hasHash)
            {
                output.WriteBytes(3, strArray[0], this.Hash);
            }
            if (this.hasProtoUrl)
            {
                output.WriteString(4, strArray[1], this.ProtoUrl);
            }
        }

        public static ContentHandle DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ContentHandle DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public ByteString Hash
        {
            get
            {
                return this.hash_;
            }
        }

        public bool HasHash
        {
            get
            {
                return this.hasHash;
            }
        }

        public bool HasProtoUrl
        {
            get
            {
                return this.hasProtoUrl;
            }
        }

        public bool HasRegion
        {
            get
            {
                return this.hasRegion;
            }
        }

        public bool HasUsage
        {
            get
            {
                return this.hasUsage;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasRegion)
                {
                    return false;
                }
                if (!this.hasUsage)
                {
                    return false;
                }
                if (!this.hasHash)
                {
                    return false;
                }
                return true;
            }
        }

        public string ProtoUrl
        {
            get
            {
                return this.protoUrl_;
            }
        }

        [CLSCompliant(false)]
        public uint Region
        {
            get
            {
                return this.region_;
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
                    if (this.hasRegion)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed32Size(1, this.Region);
                    }
                    if (this.hasUsage)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed32Size(2, this.Usage);
                    }
                    if (this.hasHash)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBytesSize(3, this.Hash);
                    }
                    if (this.hasProtoUrl)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(4, this.ProtoUrl);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ContentHandle ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CLSCompliant(false)]
        public uint Usage
        {
            get
            {
                return this.usage_;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<ContentHandle, ContentHandle.Builder>
        {
            private ContentHandle result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ContentHandle.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ContentHandle cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override ContentHandle BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ContentHandle.Builder Clear()
            {
                this.result = ContentHandle.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ContentHandle.Builder ClearHash()
            {
                this.PrepareBuilder();
                this.result.hasHash = false;
                this.result.hash_ = ByteString.Empty;
                return this;
            }

            public ContentHandle.Builder ClearProtoUrl()
            {
                this.PrepareBuilder();
                this.result.hasProtoUrl = false;
                this.result.protoUrl_ = string.Empty;
                return this;
            }

            public ContentHandle.Builder ClearRegion()
            {
                this.PrepareBuilder();
                this.result.hasRegion = false;
                this.result.region_ = 0;
                return this;
            }

            public ContentHandle.Builder ClearUsage()
            {
                this.PrepareBuilder();
                this.result.hasUsage = false;
                this.result.usage_ = 0;
                return this;
            }

            public override ContentHandle.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ContentHandle.Builder(this.result);
                }
                return new ContentHandle.Builder().MergeFrom(this.result);
            }

            public override ContentHandle.Builder MergeFrom(ContentHandle other)
            {
                if (other != ContentHandle.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasRegion)
                    {
                        this.Region = other.Region;
                    }
                    if (other.HasUsage)
                    {
                        this.Usage = other.Usage;
                    }
                    if (other.HasHash)
                    {
                        this.Hash = other.Hash;
                    }
                    if (other.HasProtoUrl)
                    {
                        this.ProtoUrl = other.ProtoUrl;
                    }
                }
                return this;
            }

            public override ContentHandle.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ContentHandle.Builder MergeFrom(IMessageLite other)
            {
                if (other is ContentHandle)
                {
                    return this.MergeFrom((ContentHandle) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ContentHandle.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ContentHandle._contentHandleFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ContentHandle._contentHandleFieldTags[index];
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

                        case 13:
                        {
                            this.result.hasRegion = input.ReadFixed32(ref this.result.region_);
                            continue;
                        }
                        case 0x15:
                        {
                            this.result.hasUsage = input.ReadFixed32(ref this.result.usage_);
                            continue;
                        }
                        case 0x1a:
                        {
                            this.result.hasHash = input.ReadBytes(ref this.result.hash_);
                            continue;
                        }
                        case 0x22:
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
                    this.result.hasProtoUrl = input.ReadString(ref this.result.protoUrl_);
                }
                return this;
            }

            private ContentHandle PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ContentHandle result = this.result;
                    this.result = new ContentHandle();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ContentHandle.Builder SetHash(ByteString value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasHash = true;
                this.result.hash_ = value;
                return this;
            }

            public ContentHandle.Builder SetProtoUrl(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasProtoUrl = true;
                this.result.protoUrl_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public ContentHandle.Builder SetRegion(uint value)
            {
                this.PrepareBuilder();
                this.result.hasRegion = true;
                this.result.region_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public ContentHandle.Builder SetUsage(uint value)
            {
                this.PrepareBuilder();
                this.result.hasUsage = true;
                this.result.usage_ = value;
                return this;
            }

            public override ContentHandle DefaultInstanceForType
            {
                get
                {
                    return ContentHandle.DefaultInstance;
                }
            }

            public ByteString Hash
            {
                get
                {
                    return this.result.Hash;
                }
                set
                {
                    this.SetHash(value);
                }
            }

            public bool HasHash
            {
                get
                {
                    return this.result.hasHash;
                }
            }

            public bool HasProtoUrl
            {
                get
                {
                    return this.result.hasProtoUrl;
                }
            }

            public bool HasRegion
            {
                get
                {
                    return this.result.hasRegion;
                }
            }

            public bool HasUsage
            {
                get
                {
                    return this.result.hasUsage;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override ContentHandle MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public string ProtoUrl
            {
                get
                {
                    return this.result.ProtoUrl;
                }
                set
                {
                    this.SetProtoUrl(value);
                }
            }

            [CLSCompliant(false)]
            public uint Region
            {
                get
                {
                    return this.result.Region;
                }
                set
                {
                    this.SetRegion(value);
                }
            }

            protected override ContentHandle.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            [CLSCompliant(false)]
            public uint Usage
            {
                get
                {
                    return this.result.Usage;
                }
                set
                {
                    this.SetUsage(value);
                }
            }
        }
    }
}

