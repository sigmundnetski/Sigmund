namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class BoosterInfo : GeneratedMessageLite<BoosterInfo, Builder>
    {
        private static readonly string[] _boosterInfoFieldNames = new string[] { "count", "type" };
        private static readonly uint[] _boosterInfoFieldTags = new uint[] { 0x18, 0x10 };
        private int count_;
        public const int CountFieldNumber = 3;
        private static readonly BoosterInfo defaultInstance = new BoosterInfo().MakeReadOnly();
        private bool hasCount;
        private bool hasType;
        private int memoizedSerializedSize = -1;
        private int type_;
        public const int TypeFieldNumber = 2;

        static BoosterInfo()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private BoosterInfo()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(BoosterInfo prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            BoosterInfo info = obj as BoosterInfo;
            if (info == null)
            {
                return false;
            }
            if ((this.hasType != info.hasType) || (this.hasType && !this.type_.Equals(info.type_)))
            {
                return false;
            }
            return ((this.hasCount == info.hasCount) && (!this.hasCount || this.count_.Equals(info.count_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasType)
            {
                hashCode ^= this.type_.GetHashCode();
            }
            if (this.hasCount)
            {
                hashCode ^= this.count_.GetHashCode();
            }
            return hashCode;
        }

        private BoosterInfo MakeReadOnly()
        {
            return this;
        }

        public static BoosterInfo ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static BoosterInfo ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static BoosterInfo ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static BoosterInfo ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static BoosterInfo ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static BoosterInfo ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static BoosterInfo ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static BoosterInfo ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static BoosterInfo ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static BoosterInfo ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<BoosterInfo, Builder>.PrintField("type", this.hasType, this.type_, writer);
            GeneratedMessageLite<BoosterInfo, Builder>.PrintField("count", this.hasCount, this.count_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _boosterInfoFieldNames;
            if (this.hasType)
            {
                output.WriteInt32(2, strArray[1], this.Type);
            }
            if (this.hasCount)
            {
                output.WriteInt32(3, strArray[0], this.Count);
            }
        }

        public int Count
        {
            get
            {
                return this.count_;
            }
        }

        public static BoosterInfo DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override BoosterInfo DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasCount
        {
            get
            {
                return this.hasCount;
            }
        }

        public bool HasType
        {
            get
            {
                return this.hasType;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasType)
                {
                    return false;
                }
                if (!this.hasCount)
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
                    if (this.hasType)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.Type);
                    }
                    if (this.hasCount)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(3, this.Count);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override BoosterInfo ThisMessage
        {
            get
            {
                return this;
            }
        }

        public int Type
        {
            get
            {
                return this.type_;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<BoosterInfo, BoosterInfo.Builder>
        {
            private BoosterInfo result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = BoosterInfo.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(BoosterInfo cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override BoosterInfo BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override BoosterInfo.Builder Clear()
            {
                this.result = BoosterInfo.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public BoosterInfo.Builder ClearCount()
            {
                this.PrepareBuilder();
                this.result.hasCount = false;
                this.result.count_ = 0;
                return this;
            }

            public BoosterInfo.Builder ClearType()
            {
                this.PrepareBuilder();
                this.result.hasType = false;
                this.result.type_ = 0;
                return this;
            }

            public override BoosterInfo.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new BoosterInfo.Builder(this.result);
                }
                return new BoosterInfo.Builder().MergeFrom(this.result);
            }

            public override BoosterInfo.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override BoosterInfo.Builder MergeFrom(IMessageLite other)
            {
                if (other is BoosterInfo)
                {
                    return this.MergeFrom((BoosterInfo) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override BoosterInfo.Builder MergeFrom(BoosterInfo other)
            {
                if (other != BoosterInfo.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasType)
                    {
                        this.Type = other.Type;
                    }
                    if (other.HasCount)
                    {
                        this.Count = other.Count;
                    }
                }
                return this;
            }

            public override BoosterInfo.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(BoosterInfo._boosterInfoFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = BoosterInfo._boosterInfoFieldTags[index];
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

                        case 0x10:
                        {
                            this.result.hasType = input.ReadInt32(ref this.result.type_);
                            continue;
                        }
                        case 0x18:
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
                    this.result.hasCount = input.ReadInt32(ref this.result.count_);
                }
                return this;
            }

            private BoosterInfo PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    BoosterInfo result = this.result;
                    this.result = new BoosterInfo();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public BoosterInfo.Builder SetCount(int value)
            {
                this.PrepareBuilder();
                this.result.hasCount = true;
                this.result.count_ = value;
                return this;
            }

            public BoosterInfo.Builder SetType(int value)
            {
                this.PrepareBuilder();
                this.result.hasType = true;
                this.result.type_ = value;
                return this;
            }

            public int Count
            {
                get
                {
                    return this.result.Count;
                }
                set
                {
                    this.SetCount(value);
                }
            }

            public override BoosterInfo DefaultInstanceForType
            {
                get
                {
                    return BoosterInfo.DefaultInstance;
                }
            }

            public bool HasCount
            {
                get
                {
                    return this.result.hasCount;
                }
            }

            public bool HasType
            {
                get
                {
                    return this.result.hasType;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override BoosterInfo MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override BoosterInfo.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public int Type
            {
                get
                {
                    return this.result.Type;
                }
                set
                {
                    this.SetType(value);
                }
            }
        }
    }
}

