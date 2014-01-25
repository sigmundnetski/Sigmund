namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class AchieveInfo : GeneratedMessageLite<AchieveInfo, Builder>
    {
        private static readonly string[] _achieveInfoFieldNames = new string[] { "data", "desc", "has_notice", "quota" };
        private static readonly uint[] _achieveInfoFieldTags = new uint[] { 0x18, 10, 0x20, 0x10 };
        private int data_;
        public const int DataFieldNumber = 3;
        private static readonly AchieveInfo defaultInstance = new AchieveInfo().MakeReadOnly();
        private string desc_ = string.Empty;
        public const int DescFieldNumber = 1;
        private bool hasData;
        private bool hasDesc;
        private bool hasHasNotice;
        private bool hasNotice_;
        public const int HasNoticeFieldNumber = 4;
        private bool hasQuota;
        private int memoizedSerializedSize = -1;
        private int quota_;
        public const int QuotaFieldNumber = 2;

        static AchieveInfo()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AchieveInfo()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AchieveInfo prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AchieveInfo info = obj as AchieveInfo;
            if (info == null)
            {
                return false;
            }
            if ((this.hasDesc != info.hasDesc) || (this.hasDesc && !this.desc_.Equals(info.desc_)))
            {
                return false;
            }
            if ((this.hasQuota != info.hasQuota) || (this.hasQuota && !this.quota_.Equals(info.quota_)))
            {
                return false;
            }
            if ((this.hasData != info.hasData) || (this.hasData && !this.data_.Equals(info.data_)))
            {
                return false;
            }
            return ((this.hasHasNotice == info.hasHasNotice) && (!this.hasHasNotice || this.hasNotice_.Equals(info.hasNotice_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasDesc)
            {
                hashCode ^= this.desc_.GetHashCode();
            }
            if (this.hasQuota)
            {
                hashCode ^= this.quota_.GetHashCode();
            }
            if (this.hasData)
            {
                hashCode ^= this.data_.GetHashCode();
            }
            if (this.hasHasNotice)
            {
                hashCode ^= this.hasNotice_.GetHashCode();
            }
            return hashCode;
        }

        private AchieveInfo MakeReadOnly()
        {
            return this;
        }

        public static AchieveInfo ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AchieveInfo ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AchieveInfo ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AchieveInfo ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AchieveInfo ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AchieveInfo ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AchieveInfo ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AchieveInfo ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AchieveInfo ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AchieveInfo ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AchieveInfo, Builder>.PrintField("desc", this.hasDesc, this.desc_, writer);
            GeneratedMessageLite<AchieveInfo, Builder>.PrintField("quota", this.hasQuota, this.quota_, writer);
            GeneratedMessageLite<AchieveInfo, Builder>.PrintField("data", this.hasData, this.data_, writer);
            GeneratedMessageLite<AchieveInfo, Builder>.PrintField("has_notice", this.hasHasNotice, this.hasNotice_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _achieveInfoFieldNames;
            if (this.hasDesc)
            {
                output.WriteString(1, strArray[1], this.Desc);
            }
            if (this.hasQuota)
            {
                output.WriteInt32(2, strArray[3], this.Quota);
            }
            if (this.hasData)
            {
                output.WriteInt32(3, strArray[0], this.Data);
            }
            if (this.hasHasNotice)
            {
                output.WriteBool(4, strArray[2], this.HasNotice);
            }
        }

        public int Data
        {
            get
            {
                return this.data_;
            }
        }

        public static AchieveInfo DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AchieveInfo DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public string Desc
        {
            get
            {
                return this.desc_;
            }
        }

        public bool HasData
        {
            get
            {
                return this.hasData;
            }
        }

        public bool HasDesc
        {
            get
            {
                return this.hasDesc;
            }
        }

        public bool HasHasNotice
        {
            get
            {
                return this.hasHasNotice;
            }
        }

        public bool HasNotice
        {
            get
            {
                return this.hasNotice_;
            }
        }

        public bool HasQuota
        {
            get
            {
                return this.hasQuota;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasDesc)
                {
                    return false;
                }
                if (!this.hasQuota)
                {
                    return false;
                }
                if (!this.hasData)
                {
                    return false;
                }
                if (!this.hasHasNotice)
                {
                    return false;
                }
                return true;
            }
        }

        public int Quota
        {
            get
            {
                return this.quota_;
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
                    if (this.hasDesc)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(1, this.Desc);
                    }
                    if (this.hasQuota)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.Quota);
                    }
                    if (this.hasData)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(3, this.Data);
                    }
                    if (this.hasHasNotice)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(4, this.HasNotice);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override AchieveInfo ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<AchieveInfo, AchieveInfo.Builder>
        {
            private AchieveInfo result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AchieveInfo.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AchieveInfo cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override AchieveInfo BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AchieveInfo.Builder Clear()
            {
                this.result = AchieveInfo.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AchieveInfo.Builder ClearData()
            {
                this.PrepareBuilder();
                this.result.hasData = false;
                this.result.data_ = 0;
                return this;
            }

            public AchieveInfo.Builder ClearDesc()
            {
                this.PrepareBuilder();
                this.result.hasDesc = false;
                this.result.desc_ = string.Empty;
                return this;
            }

            public AchieveInfo.Builder ClearHasNotice()
            {
                this.PrepareBuilder();
                this.result.hasHasNotice = false;
                this.result.hasNotice_ = false;
                return this;
            }

            public AchieveInfo.Builder ClearQuota()
            {
                this.PrepareBuilder();
                this.result.hasQuota = false;
                this.result.quota_ = 0;
                return this;
            }

            public override AchieveInfo.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AchieveInfo.Builder(this.result);
                }
                return new AchieveInfo.Builder().MergeFrom(this.result);
            }

            public override AchieveInfo.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AchieveInfo.Builder MergeFrom(IMessageLite other)
            {
                if (other is AchieveInfo)
                {
                    return this.MergeFrom((AchieveInfo) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AchieveInfo.Builder MergeFrom(AchieveInfo other)
            {
                if (other != AchieveInfo.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasDesc)
                    {
                        this.Desc = other.Desc;
                    }
                    if (other.HasQuota)
                    {
                        this.Quota = other.Quota;
                    }
                    if (other.HasData)
                    {
                        this.Data = other.Data;
                    }
                    if (other.HasHasNotice)
                    {
                        this.HasNotice = other.HasNotice;
                    }
                }
                return this;
            }

            public override AchieveInfo.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AchieveInfo._achieveInfoFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AchieveInfo._achieveInfoFieldTags[index];
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
                            this.result.hasDesc = input.ReadString(ref this.result.desc_);
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasQuota = input.ReadInt32(ref this.result.quota_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasData = input.ReadInt32(ref this.result.data_);
                            continue;
                        }
                        case 0x20:
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
                    this.result.hasHasNotice = input.ReadBool(ref this.result.hasNotice_);
                }
                return this;
            }

            private AchieveInfo PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AchieveInfo result = this.result;
                    this.result = new AchieveInfo();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public AchieveInfo.Builder SetData(int value)
            {
                this.PrepareBuilder();
                this.result.hasData = true;
                this.result.data_ = value;
                return this;
            }

            public AchieveInfo.Builder SetDesc(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasDesc = true;
                this.result.desc_ = value;
                return this;
            }

            public AchieveInfo.Builder SetHasNotice(bool value)
            {
                this.PrepareBuilder();
                this.result.hasHasNotice = true;
                this.result.hasNotice_ = value;
                return this;
            }

            public AchieveInfo.Builder SetQuota(int value)
            {
                this.PrepareBuilder();
                this.result.hasQuota = true;
                this.result.quota_ = value;
                return this;
            }

            public int Data
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

            public override AchieveInfo DefaultInstanceForType
            {
                get
                {
                    return AchieveInfo.DefaultInstance;
                }
            }

            public string Desc
            {
                get
                {
                    return this.result.Desc;
                }
                set
                {
                    this.SetDesc(value);
                }
            }

            public bool HasData
            {
                get
                {
                    return this.result.hasData;
                }
            }

            public bool HasDesc
            {
                get
                {
                    return this.result.hasDesc;
                }
            }

            public bool HasHasNotice
            {
                get
                {
                    return this.result.hasHasNotice;
                }
            }

            public bool HasNotice
            {
                get
                {
                    return this.result.HasNotice;
                }
                set
                {
                    this.SetHasNotice(value);
                }
            }

            public bool HasQuota
            {
                get
                {
                    return this.result.hasQuota;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override AchieveInfo MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int Quota
            {
                get
                {
                    return this.result.Quota;
                }
                set
                {
                    this.SetQuota(value);
                }
            }

            protected override AchieveInfo.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

