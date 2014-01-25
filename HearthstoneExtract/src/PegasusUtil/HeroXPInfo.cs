namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class HeroXPInfo : GeneratedMessageLite<HeroXPInfo, Builder>
    {
        private static readonly string[] _heroXPInfoFieldNames = new string[] { "class_id", "curr_xp", "level", "max_xp", "next_reward" };
        private static readonly uint[] _heroXPInfoFieldTags = new uint[] { 8, 0x18, 0x10, 0x20, 0x2a };
        private int classId_;
        public const int ClassIdFieldNumber = 1;
        private long currXp_;
        public const int CurrXpFieldNumber = 3;
        private static readonly HeroXPInfo defaultInstance = new HeroXPInfo().MakeReadOnly();
        private bool hasClassId;
        private bool hasCurrXp;
        private bool hasLevel;
        private bool hasMaxXp;
        private bool hasNextReward;
        private int level_;
        public const int LevelFieldNumber = 2;
        private long maxXp_;
        public const int MaxXpFieldNumber = 4;
        private int memoizedSerializedSize = -1;
        private NextHeroLevelReward nextReward_;
        public const int NextRewardFieldNumber = 5;

        static HeroXPInfo()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private HeroXPInfo()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(HeroXPInfo prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            HeroXPInfo info = obj as HeroXPInfo;
            if (info == null)
            {
                return false;
            }
            if ((this.hasClassId != info.hasClassId) || (this.hasClassId && !this.classId_.Equals(info.classId_)))
            {
                return false;
            }
            if ((this.hasLevel != info.hasLevel) || (this.hasLevel && !this.level_.Equals(info.level_)))
            {
                return false;
            }
            if ((this.hasCurrXp != info.hasCurrXp) || (this.hasCurrXp && !this.currXp_.Equals(info.currXp_)))
            {
                return false;
            }
            if ((this.hasMaxXp != info.hasMaxXp) || (this.hasMaxXp && !this.maxXp_.Equals(info.maxXp_)))
            {
                return false;
            }
            return ((this.hasNextReward == info.hasNextReward) && (!this.hasNextReward || this.nextReward_.Equals(info.nextReward_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasClassId)
            {
                hashCode ^= this.classId_.GetHashCode();
            }
            if (this.hasLevel)
            {
                hashCode ^= this.level_.GetHashCode();
            }
            if (this.hasCurrXp)
            {
                hashCode ^= this.currXp_.GetHashCode();
            }
            if (this.hasMaxXp)
            {
                hashCode ^= this.maxXp_.GetHashCode();
            }
            if (this.hasNextReward)
            {
                hashCode ^= this.nextReward_.GetHashCode();
            }
            return hashCode;
        }

        private HeroXPInfo MakeReadOnly()
        {
            return this;
        }

        public static HeroXPInfo ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static HeroXPInfo ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static HeroXPInfo ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static HeroXPInfo ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static HeroXPInfo ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static HeroXPInfo ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static HeroXPInfo ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static HeroXPInfo ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static HeroXPInfo ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static HeroXPInfo ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<HeroXPInfo, Builder>.PrintField("class_id", this.hasClassId, this.classId_, writer);
            GeneratedMessageLite<HeroXPInfo, Builder>.PrintField("level", this.hasLevel, this.level_, writer);
            GeneratedMessageLite<HeroXPInfo, Builder>.PrintField("curr_xp", this.hasCurrXp, this.currXp_, writer);
            GeneratedMessageLite<HeroXPInfo, Builder>.PrintField("max_xp", this.hasMaxXp, this.maxXp_, writer);
            GeneratedMessageLite<HeroXPInfo, Builder>.PrintField("next_reward", this.hasNextReward, this.nextReward_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _heroXPInfoFieldNames;
            if (this.hasClassId)
            {
                output.WriteInt32(1, strArray[0], this.ClassId);
            }
            if (this.hasLevel)
            {
                output.WriteInt32(2, strArray[2], this.Level);
            }
            if (this.hasCurrXp)
            {
                output.WriteInt64(3, strArray[1], this.CurrXp);
            }
            if (this.hasMaxXp)
            {
                output.WriteInt64(4, strArray[3], this.MaxXp);
            }
            if (this.hasNextReward)
            {
                output.WriteMessage(5, strArray[4], this.NextReward);
            }
        }

        public int ClassId
        {
            get
            {
                return this.classId_;
            }
        }

        public long CurrXp
        {
            get
            {
                return this.currXp_;
            }
        }

        public static HeroXPInfo DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override HeroXPInfo DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasClassId
        {
            get
            {
                return this.hasClassId;
            }
        }

        public bool HasCurrXp
        {
            get
            {
                return this.hasCurrXp;
            }
        }

        public bool HasLevel
        {
            get
            {
                return this.hasLevel;
            }
        }

        public bool HasMaxXp
        {
            get
            {
                return this.hasMaxXp;
            }
        }

        public bool HasNextReward
        {
            get
            {
                return this.hasNextReward;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasClassId)
                {
                    return false;
                }
                if (!this.hasLevel)
                {
                    return false;
                }
                if (!this.hasCurrXp)
                {
                    return false;
                }
                if (!this.hasMaxXp)
                {
                    return false;
                }
                if (this.HasNextReward && !this.NextReward.IsInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        public int Level
        {
            get
            {
                return this.level_;
            }
        }

        public long MaxXp
        {
            get
            {
                return this.maxXp_;
            }
        }

        public NextHeroLevelReward NextReward
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.nextReward_ != null)
                {
                    goto Label_0012;
                }
                return NextHeroLevelReward.DefaultInstance;
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
                    if (this.hasClassId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.ClassId);
                    }
                    if (this.hasLevel)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.Level);
                    }
                    if (this.hasCurrXp)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(3, this.CurrXp);
                    }
                    if (this.hasMaxXp)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(4, this.MaxXp);
                    }
                    if (this.hasNextReward)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(5, this.NextReward);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override HeroXPInfo ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<HeroXPInfo, HeroXPInfo.Builder>
        {
            private HeroXPInfo result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = HeroXPInfo.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(HeroXPInfo cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override HeroXPInfo BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override HeroXPInfo.Builder Clear()
            {
                this.result = HeroXPInfo.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public HeroXPInfo.Builder ClearClassId()
            {
                this.PrepareBuilder();
                this.result.hasClassId = false;
                this.result.classId_ = 0;
                return this;
            }

            public HeroXPInfo.Builder ClearCurrXp()
            {
                this.PrepareBuilder();
                this.result.hasCurrXp = false;
                this.result.currXp_ = 0L;
                return this;
            }

            public HeroXPInfo.Builder ClearLevel()
            {
                this.PrepareBuilder();
                this.result.hasLevel = false;
                this.result.level_ = 0;
                return this;
            }

            public HeroXPInfo.Builder ClearMaxXp()
            {
                this.PrepareBuilder();
                this.result.hasMaxXp = false;
                this.result.maxXp_ = 0L;
                return this;
            }

            public HeroXPInfo.Builder ClearNextReward()
            {
                this.PrepareBuilder();
                this.result.hasNextReward = false;
                this.result.nextReward_ = null;
                return this;
            }

            public override HeroXPInfo.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new HeroXPInfo.Builder(this.result);
                }
                return new HeroXPInfo.Builder().MergeFrom(this.result);
            }

            public override HeroXPInfo.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override HeroXPInfo.Builder MergeFrom(IMessageLite other)
            {
                if (other is HeroXPInfo)
                {
                    return this.MergeFrom((HeroXPInfo) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override HeroXPInfo.Builder MergeFrom(HeroXPInfo other)
            {
                if (other != HeroXPInfo.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasClassId)
                    {
                        this.ClassId = other.ClassId;
                    }
                    if (other.HasLevel)
                    {
                        this.Level = other.Level;
                    }
                    if (other.HasCurrXp)
                    {
                        this.CurrXp = other.CurrXp;
                    }
                    if (other.HasMaxXp)
                    {
                        this.MaxXp = other.MaxXp;
                    }
                    if (other.HasNextReward)
                    {
                        this.MergeNextReward(other.NextReward);
                    }
                }
                return this;
            }

            public override HeroXPInfo.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(HeroXPInfo._heroXPInfoFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = HeroXPInfo._heroXPInfoFieldTags[index];
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
                            this.result.hasClassId = input.ReadInt32(ref this.result.classId_);
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasLevel = input.ReadInt32(ref this.result.level_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasCurrXp = input.ReadInt64(ref this.result.currXp_);
                            continue;
                        }
                        case 0x20:
                        {
                            this.result.hasMaxXp = input.ReadInt64(ref this.result.maxXp_);
                            continue;
                        }
                        case 0x2a:
                        {
                            NextHeroLevelReward.Builder builder = NextHeroLevelReward.CreateBuilder();
                            if (this.result.hasNextReward)
                            {
                                builder.MergeFrom(this.NextReward);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.NextReward = builder.BuildPartial();
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

            public HeroXPInfo.Builder MergeNextReward(NextHeroLevelReward value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasNextReward && (this.result.nextReward_ != NextHeroLevelReward.DefaultInstance))
                {
                    this.result.nextReward_ = NextHeroLevelReward.CreateBuilder(this.result.nextReward_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.nextReward_ = value;
                }
                this.result.hasNextReward = true;
                return this;
            }

            private HeroXPInfo PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    HeroXPInfo result = this.result;
                    this.result = new HeroXPInfo();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public HeroXPInfo.Builder SetClassId(int value)
            {
                this.PrepareBuilder();
                this.result.hasClassId = true;
                this.result.classId_ = value;
                return this;
            }

            public HeroXPInfo.Builder SetCurrXp(long value)
            {
                this.PrepareBuilder();
                this.result.hasCurrXp = true;
                this.result.currXp_ = value;
                return this;
            }

            public HeroXPInfo.Builder SetLevel(int value)
            {
                this.PrepareBuilder();
                this.result.hasLevel = true;
                this.result.level_ = value;
                return this;
            }

            public HeroXPInfo.Builder SetMaxXp(long value)
            {
                this.PrepareBuilder();
                this.result.hasMaxXp = true;
                this.result.maxXp_ = value;
                return this;
            }

            public HeroXPInfo.Builder SetNextReward(NextHeroLevelReward value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasNextReward = true;
                this.result.nextReward_ = value;
                return this;
            }

            public HeroXPInfo.Builder SetNextReward(NextHeroLevelReward.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasNextReward = true;
                this.result.nextReward_ = builderForValue.Build();
                return this;
            }

            public int ClassId
            {
                get
                {
                    return this.result.ClassId;
                }
                set
                {
                    this.SetClassId(value);
                }
            }

            public long CurrXp
            {
                get
                {
                    return this.result.CurrXp;
                }
                set
                {
                    this.SetCurrXp(value);
                }
            }

            public override HeroXPInfo DefaultInstanceForType
            {
                get
                {
                    return HeroXPInfo.DefaultInstance;
                }
            }

            public bool HasClassId
            {
                get
                {
                    return this.result.hasClassId;
                }
            }

            public bool HasCurrXp
            {
                get
                {
                    return this.result.hasCurrXp;
                }
            }

            public bool HasLevel
            {
                get
                {
                    return this.result.hasLevel;
                }
            }

            public bool HasMaxXp
            {
                get
                {
                    return this.result.hasMaxXp;
                }
            }

            public bool HasNextReward
            {
                get
                {
                    return this.result.hasNextReward;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public int Level
            {
                get
                {
                    return this.result.Level;
                }
                set
                {
                    this.SetLevel(value);
                }
            }

            public long MaxXp
            {
                get
                {
                    return this.result.MaxXp;
                }
                set
                {
                    this.SetMaxXp(value);
                }
            }

            protected override HeroXPInfo MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public NextHeroLevelReward NextReward
            {
                get
                {
                    return this.result.NextReward;
                }
                set
                {
                    this.SetNextReward(value);
                }
            }

            protected override HeroXPInfo.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

