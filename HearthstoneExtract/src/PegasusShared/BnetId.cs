namespace PegasusShared
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class BnetId : GeneratedMessageLite<BnetId, Builder>
    {
        private static readonly string[] _bnetIdFieldNames = new string[] { "hi", "lo" };
        private static readonly uint[] _bnetIdFieldTags = new uint[] { 8, 0x10 };
        private static readonly BnetId defaultInstance = new BnetId().MakeReadOnly();
        private bool hasHi;
        private bool hasLo;
        private ulong hi_;
        public const int HiFieldNumber = 1;
        private ulong lo_;
        public const int LoFieldNumber = 2;
        private int memoizedSerializedSize = -1;

        static BnetId()
        {
            object.ReferenceEquals(PegasusSharedlite.Descriptor, null);
        }

        private BnetId()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(BnetId prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            BnetId id = obj as BnetId;
            if (id == null)
            {
                return false;
            }
            if ((this.hasHi != id.hasHi) || (this.hasHi && !this.hi_.Equals(id.hi_)))
            {
                return false;
            }
            return ((this.hasLo == id.hasLo) && (!this.hasLo || this.lo_.Equals(id.lo_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasHi)
            {
                hashCode ^= this.hi_.GetHashCode();
            }
            if (this.hasLo)
            {
                hashCode ^= this.lo_.GetHashCode();
            }
            return hashCode;
        }

        private BnetId MakeReadOnly()
        {
            return this;
        }

        public static BnetId ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static BnetId ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static BnetId ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static BnetId ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static BnetId ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static BnetId ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static BnetId ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static BnetId ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static BnetId ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static BnetId ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<BnetId, Builder>.PrintField("hi", this.hasHi, this.hi_, writer);
            GeneratedMessageLite<BnetId, Builder>.PrintField("lo", this.hasLo, this.lo_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _bnetIdFieldNames;
            if (this.hasHi)
            {
                output.WriteUInt64(1, strArray[0], this.Hi);
            }
            if (this.hasLo)
            {
                output.WriteUInt64(2, strArray[1], this.Lo);
            }
        }

        public static BnetId DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override BnetId DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasHi
        {
            get
            {
                return this.hasHi;
            }
        }

        public bool HasLo
        {
            get
            {
                return this.hasLo;
            }
        }

        [CLSCompliant(false)]
        public ulong Hi
        {
            get
            {
                return this.hi_;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasHi)
                {
                    return false;
                }
                if (!this.hasLo)
                {
                    return false;
                }
                return true;
            }
        }

        [CLSCompliant(false)]
        public ulong Lo
        {
            get
            {
                return this.lo_;
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
                    if (this.hasHi)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(1, this.Hi);
                    }
                    if (this.hasLo)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(2, this.Lo);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override BnetId ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<BnetId, BnetId.Builder>
        {
            private BnetId result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = BnetId.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(BnetId cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override BnetId BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override BnetId.Builder Clear()
            {
                this.result = BnetId.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public BnetId.Builder ClearHi()
            {
                this.PrepareBuilder();
                this.result.hasHi = false;
                this.result.hi_ = 0L;
                return this;
            }

            public BnetId.Builder ClearLo()
            {
                this.PrepareBuilder();
                this.result.hasLo = false;
                this.result.lo_ = 0L;
                return this;
            }

            public override BnetId.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new BnetId.Builder(this.result);
                }
                return new BnetId.Builder().MergeFrom(this.result);
            }

            public override BnetId.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override BnetId.Builder MergeFrom(IMessageLite other)
            {
                if (other is BnetId)
                {
                    return this.MergeFrom((BnetId) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override BnetId.Builder MergeFrom(BnetId other)
            {
                if (other != BnetId.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasHi)
                    {
                        this.Hi = other.Hi;
                    }
                    if (other.HasLo)
                    {
                        this.Lo = other.Lo;
                    }
                }
                return this;
            }

            public override BnetId.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(BnetId._bnetIdFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = BnetId._bnetIdFieldTags[index];
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

                        case 8:
                        {
                            this.result.hasHi = input.ReadUInt64(ref this.result.hi_);
                            continue;
                        }
                        case 0x10:
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
                    this.result.hasLo = input.ReadUInt64(ref this.result.lo_);
                }
                return this;
            }

            private BnetId PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    BnetId result = this.result;
                    this.result = new BnetId();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public BnetId.Builder SetHi(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasHi = true;
                this.result.hi_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public BnetId.Builder SetLo(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasLo = true;
                this.result.lo_ = value;
                return this;
            }

            public override BnetId DefaultInstanceForType
            {
                get
                {
                    return BnetId.DefaultInstance;
                }
            }

            public bool HasHi
            {
                get
                {
                    return this.result.hasHi;
                }
            }

            public bool HasLo
            {
                get
                {
                    return this.result.hasLo;
                }
            }

            [CLSCompliant(false)]
            public ulong Hi
            {
                get
                {
                    return this.result.Hi;
                }
                set
                {
                    this.SetHi(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            [CLSCompliant(false)]
            public ulong Lo
            {
                get
                {
                    return this.result.Lo;
                }
                set
                {
                    this.SetLo(value);
                }
            }

            protected override BnetId MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override BnetId.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

