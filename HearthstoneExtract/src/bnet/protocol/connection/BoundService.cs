namespace bnet.protocol.connection
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class BoundService : GeneratedMessageLite<BoundService, Builder>
    {
        private static readonly string[] _boundServiceFieldNames = new string[] { "hash", "id" };
        private static readonly uint[] _boundServiceFieldTags = new uint[] { 13, 0x10 };
        private static readonly BoundService defaultInstance = new BoundService().MakeReadOnly();
        private uint hash_;
        private bool hasHash;
        public const int HashFieldNumber = 1;
        private bool hasId;
        private uint id_;
        public const int IdFieldNumber = 2;
        private int memoizedSerializedSize = -1;

        static BoundService()
        {
            object.ReferenceEquals(Connect.Descriptor, null);
        }

        private BoundService()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(BoundService prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            BoundService service = obj as BoundService;
            if (service == null)
            {
                return false;
            }
            if ((this.hasHash != service.hasHash) || (this.hasHash && !this.hash_.Equals(service.hash_)))
            {
                return false;
            }
            return ((this.hasId == service.hasId) && (!this.hasId || this.id_.Equals(service.id_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasHash)
            {
                hashCode ^= this.hash_.GetHashCode();
            }
            if (this.hasId)
            {
                hashCode ^= this.id_.GetHashCode();
            }
            return hashCode;
        }

        private BoundService MakeReadOnly()
        {
            return this;
        }

        public static BoundService ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static BoundService ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static BoundService ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static BoundService ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static BoundService ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static BoundService ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static BoundService ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static BoundService ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static BoundService ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static BoundService ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<BoundService, Builder>.PrintField("hash", this.hasHash, this.hash_, writer);
            GeneratedMessageLite<BoundService, Builder>.PrintField("id", this.hasId, this.id_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _boundServiceFieldNames;
            if (this.hasHash)
            {
                output.WriteFixed32(1, strArray[0], this.Hash);
            }
            if (this.hasId)
            {
                output.WriteUInt32(2, strArray[1], this.Id);
            }
        }

        public static BoundService DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override BoundService DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        [CLSCompliant(false)]
        public uint Hash
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

        public bool HasId
        {
            get
            {
                return this.hasId;
            }
        }

        [CLSCompliant(false)]
        public uint Id
        {
            get
            {
                return this.id_;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasHash)
                {
                    return false;
                }
                if (!this.hasId)
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
                    if (this.hasHash)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed32Size(1, this.Hash);
                    }
                    if (this.hasId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(2, this.Id);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override BoundService ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<BoundService, BoundService.Builder>
        {
            private BoundService result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = BoundService.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(BoundService cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override BoundService BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override BoundService.Builder Clear()
            {
                this.result = BoundService.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public BoundService.Builder ClearHash()
            {
                this.PrepareBuilder();
                this.result.hasHash = false;
                this.result.hash_ = 0;
                return this;
            }

            public BoundService.Builder ClearId()
            {
                this.PrepareBuilder();
                this.result.hasId = false;
                this.result.id_ = 0;
                return this;
            }

            public override BoundService.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new BoundService.Builder(this.result);
                }
                return new BoundService.Builder().MergeFrom(this.result);
            }

            public override BoundService.Builder MergeFrom(BoundService other)
            {
                if (other != BoundService.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasHash)
                    {
                        this.Hash = other.Hash;
                    }
                    if (other.HasId)
                    {
                        this.Id = other.Id;
                    }
                }
                return this;
            }

            public override BoundService.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override BoundService.Builder MergeFrom(IMessageLite other)
            {
                if (other is BoundService)
                {
                    return this.MergeFrom((BoundService) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override BoundService.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(BoundService._boundServiceFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = BoundService._boundServiceFieldTags[index];
                        }
                        else
                        {
                            this.ParseUnknownField(input, extensionRegistry, num, str);
                            continue;
                        }
                    }
                    switch (num)
                    {
                        case 13:
                        {
                            this.result.hasHash = input.ReadFixed32(ref this.result.hash_);
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasId = input.ReadUInt32(ref this.result.id_);
                            continue;
                        }
                        case 0:
                            throw InvalidProtocolBufferException.InvalidTag();
                    }
                    if (WireFormat.IsEndGroupTag(num))
                    {
                        return this;
                    }
                    this.ParseUnknownField(input, extensionRegistry, num, str);
                }
                return this;
            }

            private BoundService PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    BoundService result = this.result;
                    this.result = new BoundService();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public BoundService.Builder SetHash(uint value)
            {
                this.PrepareBuilder();
                this.result.hasHash = true;
                this.result.hash_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public BoundService.Builder SetId(uint value)
            {
                this.PrepareBuilder();
                this.result.hasId = true;
                this.result.id_ = value;
                return this;
            }

            public override BoundService DefaultInstanceForType
            {
                get
                {
                    return BoundService.DefaultInstance;
                }
            }

            [CLSCompliant(false)]
            public uint Hash
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

            public bool HasId
            {
                get
                {
                    return this.result.hasId;
                }
            }

            [CLSCompliant(false)]
            public uint Id
            {
                get
                {
                    return this.result.Id;
                }
                set
                {
                    this.SetId(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override BoundService MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override BoundService.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

