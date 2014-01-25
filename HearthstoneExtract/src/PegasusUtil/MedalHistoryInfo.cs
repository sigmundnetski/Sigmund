namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using PegasusShared;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class MedalHistoryInfo : GeneratedMessageLite<MedalHistoryInfo, Builder>
    {
        private static readonly string[] _medalHistoryInfoFieldNames = new string[] { "medal", "rank", "when" };
        private static readonly uint[] _medalHistoryInfoFieldTags = new uint[] { 8, 0x18, 0x12 };
        private static readonly MedalHistoryInfo defaultInstance = new MedalHistoryInfo().MakeReadOnly();
        private bool hasMedal;
        private bool hasRank;
        private bool hasWhen;
        private int medal_;
        public const int MedalFieldNumber = 1;
        private int memoizedSerializedSize = -1;
        private int rank_;
        public const int RankFieldNumber = 3;
        private Date when_;
        public const int WhenFieldNumber = 2;

        static MedalHistoryInfo()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private MedalHistoryInfo()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(MedalHistoryInfo prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            MedalHistoryInfo info = obj as MedalHistoryInfo;
            if (info == null)
            {
                return false;
            }
            if ((this.hasMedal != info.hasMedal) || (this.hasMedal && !this.medal_.Equals(info.medal_)))
            {
                return false;
            }
            if ((this.hasWhen != info.hasWhen) || (this.hasWhen && !this.when_.Equals(info.when_)))
            {
                return false;
            }
            return ((this.hasRank == info.hasRank) && (!this.hasRank || this.rank_.Equals(info.rank_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasMedal)
            {
                hashCode ^= this.medal_.GetHashCode();
            }
            if (this.hasWhen)
            {
                hashCode ^= this.when_.GetHashCode();
            }
            if (this.hasRank)
            {
                hashCode ^= this.rank_.GetHashCode();
            }
            return hashCode;
        }

        private MedalHistoryInfo MakeReadOnly()
        {
            return this;
        }

        public static MedalHistoryInfo ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static MedalHistoryInfo ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static MedalHistoryInfo ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static MedalHistoryInfo ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static MedalHistoryInfo ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static MedalHistoryInfo ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static MedalHistoryInfo ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static MedalHistoryInfo ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static MedalHistoryInfo ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static MedalHistoryInfo ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<MedalHistoryInfo, Builder>.PrintField("medal", this.hasMedal, this.medal_, writer);
            GeneratedMessageLite<MedalHistoryInfo, Builder>.PrintField("when", this.hasWhen, this.when_, writer);
            GeneratedMessageLite<MedalHistoryInfo, Builder>.PrintField("rank", this.hasRank, this.rank_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _medalHistoryInfoFieldNames;
            if (this.hasMedal)
            {
                output.WriteInt32(1, strArray[0], this.Medal);
            }
            if (this.hasWhen)
            {
                output.WriteMessage(2, strArray[2], this.When);
            }
            if (this.hasRank)
            {
                output.WriteInt32(3, strArray[1], this.Rank);
            }
        }

        public static MedalHistoryInfo DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override MedalHistoryInfo DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasMedal
        {
            get
            {
                return this.hasMedal;
            }
        }

        public bool HasRank
        {
            get
            {
                return this.hasRank;
            }
        }

        public bool HasWhen
        {
            get
            {
                return this.hasWhen;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasMedal)
                {
                    return false;
                }
                if (!this.hasWhen)
                {
                    return false;
                }
                if (!this.When.IsInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        public int Medal
        {
            get
            {
                return this.medal_;
            }
        }

        public int Rank
        {
            get
            {
                return this.rank_;
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
                    if (this.hasMedal)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.Medal);
                    }
                    if (this.hasWhen)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, this.When);
                    }
                    if (this.hasRank)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(3, this.Rank);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override MedalHistoryInfo ThisMessage
        {
            get
            {
                return this;
            }
        }

        public Date When
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.when_ != null)
                {
                    goto Label_0012;
                }
                return Date.DefaultInstance;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<MedalHistoryInfo, MedalHistoryInfo.Builder>
        {
            private MedalHistoryInfo result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = MedalHistoryInfo.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(MedalHistoryInfo cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override MedalHistoryInfo BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override MedalHistoryInfo.Builder Clear()
            {
                this.result = MedalHistoryInfo.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public MedalHistoryInfo.Builder ClearMedal()
            {
                this.PrepareBuilder();
                this.result.hasMedal = false;
                this.result.medal_ = 0;
                return this;
            }

            public MedalHistoryInfo.Builder ClearRank()
            {
                this.PrepareBuilder();
                this.result.hasRank = false;
                this.result.rank_ = 0;
                return this;
            }

            public MedalHistoryInfo.Builder ClearWhen()
            {
                this.PrepareBuilder();
                this.result.hasWhen = false;
                this.result.when_ = null;
                return this;
            }

            public override MedalHistoryInfo.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new MedalHistoryInfo.Builder(this.result);
                }
                return new MedalHistoryInfo.Builder().MergeFrom(this.result);
            }

            public override MedalHistoryInfo.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override MedalHistoryInfo.Builder MergeFrom(IMessageLite other)
            {
                if (other is MedalHistoryInfo)
                {
                    return this.MergeFrom((MedalHistoryInfo) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override MedalHistoryInfo.Builder MergeFrom(MedalHistoryInfo other)
            {
                if (other != MedalHistoryInfo.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasMedal)
                    {
                        this.Medal = other.Medal;
                    }
                    if (other.HasWhen)
                    {
                        this.MergeWhen(other.When);
                    }
                    if (other.HasRank)
                    {
                        this.Rank = other.Rank;
                    }
                }
                return this;
            }

            public override MedalHistoryInfo.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(MedalHistoryInfo._medalHistoryInfoFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = MedalHistoryInfo._medalHistoryInfoFieldTags[index];
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
                            this.result.hasMedal = input.ReadInt32(ref this.result.medal_);
                            continue;
                        }
                        case 0x12:
                        {
                            Date.Builder builder = Date.CreateBuilder();
                            if (this.result.hasWhen)
                            {
                                builder.MergeFrom(this.When);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.When = builder.BuildPartial();
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
                    this.result.hasRank = input.ReadInt32(ref this.result.rank_);
                }
                return this;
            }

            public MedalHistoryInfo.Builder MergeWhen(Date value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasWhen && (this.result.when_ != Date.DefaultInstance))
                {
                    this.result.when_ = Date.CreateBuilder(this.result.when_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.when_ = value;
                }
                this.result.hasWhen = true;
                return this;
            }

            private MedalHistoryInfo PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    MedalHistoryInfo result = this.result;
                    this.result = new MedalHistoryInfo();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public MedalHistoryInfo.Builder SetMedal(int value)
            {
                this.PrepareBuilder();
                this.result.hasMedal = true;
                this.result.medal_ = value;
                return this;
            }

            public MedalHistoryInfo.Builder SetRank(int value)
            {
                this.PrepareBuilder();
                this.result.hasRank = true;
                this.result.rank_ = value;
                return this;
            }

            public MedalHistoryInfo.Builder SetWhen(Date value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasWhen = true;
                this.result.when_ = value;
                return this;
            }

            public MedalHistoryInfo.Builder SetWhen(Date.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasWhen = true;
                this.result.when_ = builderForValue.Build();
                return this;
            }

            public override MedalHistoryInfo DefaultInstanceForType
            {
                get
                {
                    return MedalHistoryInfo.DefaultInstance;
                }
            }

            public bool HasMedal
            {
                get
                {
                    return this.result.hasMedal;
                }
            }

            public bool HasRank
            {
                get
                {
                    return this.result.hasRank;
                }
            }

            public bool HasWhen
            {
                get
                {
                    return this.result.hasWhen;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public int Medal
            {
                get
                {
                    return this.result.Medal;
                }
                set
                {
                    this.SetMedal(value);
                }
            }

            protected override MedalHistoryInfo MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int Rank
            {
                get
                {
                    return this.result.Rank;
                }
                set
                {
                    this.SetRank(value);
                }
            }

            protected override MedalHistoryInfo.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public Date When
            {
                get
                {
                    return this.result.When;
                }
                set
                {
                    this.SetWhen(value);
                }
            }
        }
    }
}

