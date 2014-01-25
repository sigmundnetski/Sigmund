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
    public sealed class RewardProgress : GeneratedMessageLite<RewardProgress, Builder>
    {
        private static readonly string[] _rewardProgressFieldNames = new string[] { "dust_per_reward", "max_dust_rewards", "max_hero_level", "max_pack_rewards", "pack_id", "packs_per_reward", "season_end", "wins_per_dust", "wins_per_pack", "xp_solo_limit" };
        private static readonly uint[] _rewardProgressFieldTags = new uint[] { 0x38, 40, 80, 0x20, 0x40, 0x30, 10, 0x18, 0x10, 0x48 };
        private static readonly RewardProgress defaultInstance = new RewardProgress().MakeReadOnly();
        private int dustPerReward_;
        public const int DustPerRewardFieldNumber = 7;
        private bool hasDustPerReward;
        private bool hasMaxDustRewards;
        private bool hasMaxHeroLevel;
        private bool hasMaxPackRewards;
        private bool hasPackId;
        private bool hasPacksPerReward;
        private bool hasSeasonEnd;
        private bool hasWinsPerDust;
        private bool hasWinsPerPack;
        private bool hasXpSoloLimit;
        private int maxDustRewards_;
        public const int MaxDustRewardsFieldNumber = 5;
        private int maxHeroLevel_;
        public const int MaxHeroLevelFieldNumber = 10;
        private int maxPackRewards_;
        public const int MaxPackRewardsFieldNumber = 4;
        private int memoizedSerializedSize = -1;
        private int packId_;
        public const int PackIdFieldNumber = 8;
        private int packsPerReward_;
        public const int PacksPerRewardFieldNumber = 6;
        private Date seasonEnd_;
        public const int SeasonEndFieldNumber = 1;
        private int winsPerDust_;
        public const int WinsPerDustFieldNumber = 3;
        private int winsPerPack_;
        public const int WinsPerPackFieldNumber = 2;
        private int xpSoloLimit_;
        public const int XpSoloLimitFieldNumber = 9;

        static RewardProgress()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private RewardProgress()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(RewardProgress prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            RewardProgress progress = obj as RewardProgress;
            if (progress == null)
            {
                return false;
            }
            if ((this.hasSeasonEnd != progress.hasSeasonEnd) || (this.hasSeasonEnd && !this.seasonEnd_.Equals(progress.seasonEnd_)))
            {
                return false;
            }
            if ((this.hasWinsPerPack != progress.hasWinsPerPack) || (this.hasWinsPerPack && !this.winsPerPack_.Equals(progress.winsPerPack_)))
            {
                return false;
            }
            if ((this.hasWinsPerDust != progress.hasWinsPerDust) || (this.hasWinsPerDust && !this.winsPerDust_.Equals(progress.winsPerDust_)))
            {
                return false;
            }
            if ((this.hasMaxPackRewards != progress.hasMaxPackRewards) || (this.hasMaxPackRewards && !this.maxPackRewards_.Equals(progress.maxPackRewards_)))
            {
                return false;
            }
            if ((this.hasMaxDustRewards != progress.hasMaxDustRewards) || (this.hasMaxDustRewards && !this.maxDustRewards_.Equals(progress.maxDustRewards_)))
            {
                return false;
            }
            if ((this.hasPacksPerReward != progress.hasPacksPerReward) || (this.hasPacksPerReward && !this.packsPerReward_.Equals(progress.packsPerReward_)))
            {
                return false;
            }
            if ((this.hasDustPerReward != progress.hasDustPerReward) || (this.hasDustPerReward && !this.dustPerReward_.Equals(progress.dustPerReward_)))
            {
                return false;
            }
            if ((this.hasPackId != progress.hasPackId) || (this.hasPackId && !this.packId_.Equals(progress.packId_)))
            {
                return false;
            }
            if ((this.hasXpSoloLimit != progress.hasXpSoloLimit) || (this.hasXpSoloLimit && !this.xpSoloLimit_.Equals(progress.xpSoloLimit_)))
            {
                return false;
            }
            return ((this.hasMaxHeroLevel == progress.hasMaxHeroLevel) && (!this.hasMaxHeroLevel || this.maxHeroLevel_.Equals(progress.maxHeroLevel_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasSeasonEnd)
            {
                hashCode ^= this.seasonEnd_.GetHashCode();
            }
            if (this.hasWinsPerPack)
            {
                hashCode ^= this.winsPerPack_.GetHashCode();
            }
            if (this.hasWinsPerDust)
            {
                hashCode ^= this.winsPerDust_.GetHashCode();
            }
            if (this.hasMaxPackRewards)
            {
                hashCode ^= this.maxPackRewards_.GetHashCode();
            }
            if (this.hasMaxDustRewards)
            {
                hashCode ^= this.maxDustRewards_.GetHashCode();
            }
            if (this.hasPacksPerReward)
            {
                hashCode ^= this.packsPerReward_.GetHashCode();
            }
            if (this.hasDustPerReward)
            {
                hashCode ^= this.dustPerReward_.GetHashCode();
            }
            if (this.hasPackId)
            {
                hashCode ^= this.packId_.GetHashCode();
            }
            if (this.hasXpSoloLimit)
            {
                hashCode ^= this.xpSoloLimit_.GetHashCode();
            }
            if (this.hasMaxHeroLevel)
            {
                hashCode ^= this.maxHeroLevel_.GetHashCode();
            }
            return hashCode;
        }

        private RewardProgress MakeReadOnly()
        {
            return this;
        }

        public static RewardProgress ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static RewardProgress ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static RewardProgress ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static RewardProgress ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static RewardProgress ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static RewardProgress ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static RewardProgress ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static RewardProgress ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static RewardProgress ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static RewardProgress ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<RewardProgress, Builder>.PrintField("season_end", this.hasSeasonEnd, this.seasonEnd_, writer);
            GeneratedMessageLite<RewardProgress, Builder>.PrintField("wins_per_pack", this.hasWinsPerPack, this.winsPerPack_, writer);
            GeneratedMessageLite<RewardProgress, Builder>.PrintField("wins_per_dust", this.hasWinsPerDust, this.winsPerDust_, writer);
            GeneratedMessageLite<RewardProgress, Builder>.PrintField("max_pack_rewards", this.hasMaxPackRewards, this.maxPackRewards_, writer);
            GeneratedMessageLite<RewardProgress, Builder>.PrintField("max_dust_rewards", this.hasMaxDustRewards, this.maxDustRewards_, writer);
            GeneratedMessageLite<RewardProgress, Builder>.PrintField("packs_per_reward", this.hasPacksPerReward, this.packsPerReward_, writer);
            GeneratedMessageLite<RewardProgress, Builder>.PrintField("dust_per_reward", this.hasDustPerReward, this.dustPerReward_, writer);
            GeneratedMessageLite<RewardProgress, Builder>.PrintField("pack_id", this.hasPackId, this.packId_, writer);
            GeneratedMessageLite<RewardProgress, Builder>.PrintField("xp_solo_limit", this.hasXpSoloLimit, this.xpSoloLimit_, writer);
            GeneratedMessageLite<RewardProgress, Builder>.PrintField("max_hero_level", this.hasMaxHeroLevel, this.maxHeroLevel_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _rewardProgressFieldNames;
            if (this.hasSeasonEnd)
            {
                output.WriteMessage(1, strArray[6], this.SeasonEnd);
            }
            if (this.hasWinsPerPack)
            {
                output.WriteInt32(2, strArray[8], this.WinsPerPack);
            }
            if (this.hasWinsPerDust)
            {
                output.WriteInt32(3, strArray[7], this.WinsPerDust);
            }
            if (this.hasMaxPackRewards)
            {
                output.WriteInt32(4, strArray[3], this.MaxPackRewards);
            }
            if (this.hasMaxDustRewards)
            {
                output.WriteInt32(5, strArray[1], this.MaxDustRewards);
            }
            if (this.hasPacksPerReward)
            {
                output.WriteInt32(6, strArray[5], this.PacksPerReward);
            }
            if (this.hasDustPerReward)
            {
                output.WriteInt32(7, strArray[0], this.DustPerReward);
            }
            if (this.hasPackId)
            {
                output.WriteInt32(8, strArray[4], this.PackId);
            }
            if (this.hasXpSoloLimit)
            {
                output.WriteInt32(9, strArray[9], this.XpSoloLimit);
            }
            if (this.hasMaxHeroLevel)
            {
                output.WriteInt32(10, strArray[2], this.MaxHeroLevel);
            }
        }

        public static RewardProgress DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override RewardProgress DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public int DustPerReward
        {
            get
            {
                return this.dustPerReward_;
            }
        }

        public bool HasDustPerReward
        {
            get
            {
                return this.hasDustPerReward;
            }
        }

        public bool HasMaxDustRewards
        {
            get
            {
                return this.hasMaxDustRewards;
            }
        }

        public bool HasMaxHeroLevel
        {
            get
            {
                return this.hasMaxHeroLevel;
            }
        }

        public bool HasMaxPackRewards
        {
            get
            {
                return this.hasMaxPackRewards;
            }
        }

        public bool HasPackId
        {
            get
            {
                return this.hasPackId;
            }
        }

        public bool HasPacksPerReward
        {
            get
            {
                return this.hasPacksPerReward;
            }
        }

        public bool HasSeasonEnd
        {
            get
            {
                return this.hasSeasonEnd;
            }
        }

        public bool HasWinsPerDust
        {
            get
            {
                return this.hasWinsPerDust;
            }
        }

        public bool HasWinsPerPack
        {
            get
            {
                return this.hasWinsPerPack;
            }
        }

        public bool HasXpSoloLimit
        {
            get
            {
                return this.hasXpSoloLimit;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasSeasonEnd)
                {
                    return false;
                }
                if (!this.hasWinsPerPack)
                {
                    return false;
                }
                if (!this.hasMaxPackRewards)
                {
                    return false;
                }
                if (!this.hasDustPerReward)
                {
                    return false;
                }
                if (!this.hasXpSoloLimit)
                {
                    return false;
                }
                if (!this.hasMaxHeroLevel)
                {
                    return false;
                }
                if (!this.SeasonEnd.IsInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        public int MaxDustRewards
        {
            get
            {
                return this.maxDustRewards_;
            }
        }

        public int MaxHeroLevel
        {
            get
            {
                return this.maxHeroLevel_;
            }
        }

        public int MaxPackRewards
        {
            get
            {
                return this.maxPackRewards_;
            }
        }

        public int PackId
        {
            get
            {
                return this.packId_;
            }
        }

        public int PacksPerReward
        {
            get
            {
                return this.packsPerReward_;
            }
        }

        public Date SeasonEnd
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.seasonEnd_ != null)
                {
                    goto Label_0012;
                }
                return Date.DefaultInstance;
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
                    if (this.hasSeasonEnd)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.SeasonEnd);
                    }
                    if (this.hasWinsPerPack)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.WinsPerPack);
                    }
                    if (this.hasWinsPerDust)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(3, this.WinsPerDust);
                    }
                    if (this.hasMaxPackRewards)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(4, this.MaxPackRewards);
                    }
                    if (this.hasMaxDustRewards)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(5, this.MaxDustRewards);
                    }
                    if (this.hasPacksPerReward)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(6, this.PacksPerReward);
                    }
                    if (this.hasDustPerReward)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(7, this.DustPerReward);
                    }
                    if (this.hasPackId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(8, this.PackId);
                    }
                    if (this.hasXpSoloLimit)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(9, this.XpSoloLimit);
                    }
                    if (this.hasMaxHeroLevel)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(10, this.MaxHeroLevel);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override RewardProgress ThisMessage
        {
            get
            {
                return this;
            }
        }

        public int WinsPerDust
        {
            get
            {
                return this.winsPerDust_;
            }
        }

        public int WinsPerPack
        {
            get
            {
                return this.winsPerPack_;
            }
        }

        public int XpSoloLimit
        {
            get
            {
                return this.xpSoloLimit_;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<RewardProgress, RewardProgress.Builder>
        {
            private RewardProgress result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = RewardProgress.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(RewardProgress cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override RewardProgress BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override RewardProgress.Builder Clear()
            {
                this.result = RewardProgress.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public RewardProgress.Builder ClearDustPerReward()
            {
                this.PrepareBuilder();
                this.result.hasDustPerReward = false;
                this.result.dustPerReward_ = 0;
                return this;
            }

            public RewardProgress.Builder ClearMaxDustRewards()
            {
                this.PrepareBuilder();
                this.result.hasMaxDustRewards = false;
                this.result.maxDustRewards_ = 0;
                return this;
            }

            public RewardProgress.Builder ClearMaxHeroLevel()
            {
                this.PrepareBuilder();
                this.result.hasMaxHeroLevel = false;
                this.result.maxHeroLevel_ = 0;
                return this;
            }

            public RewardProgress.Builder ClearMaxPackRewards()
            {
                this.PrepareBuilder();
                this.result.hasMaxPackRewards = false;
                this.result.maxPackRewards_ = 0;
                return this;
            }

            public RewardProgress.Builder ClearPackId()
            {
                this.PrepareBuilder();
                this.result.hasPackId = false;
                this.result.packId_ = 0;
                return this;
            }

            public RewardProgress.Builder ClearPacksPerReward()
            {
                this.PrepareBuilder();
                this.result.hasPacksPerReward = false;
                this.result.packsPerReward_ = 0;
                return this;
            }

            public RewardProgress.Builder ClearSeasonEnd()
            {
                this.PrepareBuilder();
                this.result.hasSeasonEnd = false;
                this.result.seasonEnd_ = null;
                return this;
            }

            public RewardProgress.Builder ClearWinsPerDust()
            {
                this.PrepareBuilder();
                this.result.hasWinsPerDust = false;
                this.result.winsPerDust_ = 0;
                return this;
            }

            public RewardProgress.Builder ClearWinsPerPack()
            {
                this.PrepareBuilder();
                this.result.hasWinsPerPack = false;
                this.result.winsPerPack_ = 0;
                return this;
            }

            public RewardProgress.Builder ClearXpSoloLimit()
            {
                this.PrepareBuilder();
                this.result.hasXpSoloLimit = false;
                this.result.xpSoloLimit_ = 0;
                return this;
            }

            public override RewardProgress.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new RewardProgress.Builder(this.result);
                }
                return new RewardProgress.Builder().MergeFrom(this.result);
            }

            public override RewardProgress.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override RewardProgress.Builder MergeFrom(IMessageLite other)
            {
                if (other is RewardProgress)
                {
                    return this.MergeFrom((RewardProgress) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override RewardProgress.Builder MergeFrom(RewardProgress other)
            {
                if (other != RewardProgress.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasSeasonEnd)
                    {
                        this.MergeSeasonEnd(other.SeasonEnd);
                    }
                    if (other.HasWinsPerPack)
                    {
                        this.WinsPerPack = other.WinsPerPack;
                    }
                    if (other.HasWinsPerDust)
                    {
                        this.WinsPerDust = other.WinsPerDust;
                    }
                    if (other.HasMaxPackRewards)
                    {
                        this.MaxPackRewards = other.MaxPackRewards;
                    }
                    if (other.HasMaxDustRewards)
                    {
                        this.MaxDustRewards = other.MaxDustRewards;
                    }
                    if (other.HasPacksPerReward)
                    {
                        this.PacksPerReward = other.PacksPerReward;
                    }
                    if (other.HasDustPerReward)
                    {
                        this.DustPerReward = other.DustPerReward;
                    }
                    if (other.HasPackId)
                    {
                        this.PackId = other.PackId;
                    }
                    if (other.HasXpSoloLimit)
                    {
                        this.XpSoloLimit = other.XpSoloLimit;
                    }
                    if (other.HasMaxHeroLevel)
                    {
                        this.MaxHeroLevel = other.MaxHeroLevel;
                    }
                }
                return this;
            }

            public override RewardProgress.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(RewardProgress._rewardProgressFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = RewardProgress._rewardProgressFieldTags[index];
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
                            Date.Builder builder = Date.CreateBuilder();
                            if (this.result.hasSeasonEnd)
                            {
                                builder.MergeFrom(this.SeasonEnd);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.SeasonEnd = builder.BuildPartial();
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasWinsPerPack = input.ReadInt32(ref this.result.winsPerPack_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasWinsPerDust = input.ReadInt32(ref this.result.winsPerDust_);
                            continue;
                        }
                        case 0x20:
                        {
                            this.result.hasMaxPackRewards = input.ReadInt32(ref this.result.maxPackRewards_);
                            continue;
                        }
                        case 40:
                        {
                            this.result.hasMaxDustRewards = input.ReadInt32(ref this.result.maxDustRewards_);
                            continue;
                        }
                        case 0x30:
                        {
                            this.result.hasPacksPerReward = input.ReadInt32(ref this.result.packsPerReward_);
                            continue;
                        }
                        case 0x38:
                        {
                            this.result.hasDustPerReward = input.ReadInt32(ref this.result.dustPerReward_);
                            continue;
                        }
                        case 0x40:
                        {
                            this.result.hasPackId = input.ReadInt32(ref this.result.packId_);
                            continue;
                        }
                        case 0x48:
                        {
                            this.result.hasXpSoloLimit = input.ReadInt32(ref this.result.xpSoloLimit_);
                            continue;
                        }
                        case 80:
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
                    this.result.hasMaxHeroLevel = input.ReadInt32(ref this.result.maxHeroLevel_);
                }
                return this;
            }

            public RewardProgress.Builder MergeSeasonEnd(Date value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasSeasonEnd && (this.result.seasonEnd_ != Date.DefaultInstance))
                {
                    this.result.seasonEnd_ = Date.CreateBuilder(this.result.seasonEnd_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.seasonEnd_ = value;
                }
                this.result.hasSeasonEnd = true;
                return this;
            }

            private RewardProgress PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    RewardProgress result = this.result;
                    this.result = new RewardProgress();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public RewardProgress.Builder SetDustPerReward(int value)
            {
                this.PrepareBuilder();
                this.result.hasDustPerReward = true;
                this.result.dustPerReward_ = value;
                return this;
            }

            public RewardProgress.Builder SetMaxDustRewards(int value)
            {
                this.PrepareBuilder();
                this.result.hasMaxDustRewards = true;
                this.result.maxDustRewards_ = value;
                return this;
            }

            public RewardProgress.Builder SetMaxHeroLevel(int value)
            {
                this.PrepareBuilder();
                this.result.hasMaxHeroLevel = true;
                this.result.maxHeroLevel_ = value;
                return this;
            }

            public RewardProgress.Builder SetMaxPackRewards(int value)
            {
                this.PrepareBuilder();
                this.result.hasMaxPackRewards = true;
                this.result.maxPackRewards_ = value;
                return this;
            }

            public RewardProgress.Builder SetPackId(int value)
            {
                this.PrepareBuilder();
                this.result.hasPackId = true;
                this.result.packId_ = value;
                return this;
            }

            public RewardProgress.Builder SetPacksPerReward(int value)
            {
                this.PrepareBuilder();
                this.result.hasPacksPerReward = true;
                this.result.packsPerReward_ = value;
                return this;
            }

            public RewardProgress.Builder SetSeasonEnd(Date value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasSeasonEnd = true;
                this.result.seasonEnd_ = value;
                return this;
            }

            public RewardProgress.Builder SetSeasonEnd(Date.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasSeasonEnd = true;
                this.result.seasonEnd_ = builderForValue.Build();
                return this;
            }

            public RewardProgress.Builder SetWinsPerDust(int value)
            {
                this.PrepareBuilder();
                this.result.hasWinsPerDust = true;
                this.result.winsPerDust_ = value;
                return this;
            }

            public RewardProgress.Builder SetWinsPerPack(int value)
            {
                this.PrepareBuilder();
                this.result.hasWinsPerPack = true;
                this.result.winsPerPack_ = value;
                return this;
            }

            public RewardProgress.Builder SetXpSoloLimit(int value)
            {
                this.PrepareBuilder();
                this.result.hasXpSoloLimit = true;
                this.result.xpSoloLimit_ = value;
                return this;
            }

            public override RewardProgress DefaultInstanceForType
            {
                get
                {
                    return RewardProgress.DefaultInstance;
                }
            }

            public int DustPerReward
            {
                get
                {
                    return this.result.DustPerReward;
                }
                set
                {
                    this.SetDustPerReward(value);
                }
            }

            public bool HasDustPerReward
            {
                get
                {
                    return this.result.hasDustPerReward;
                }
            }

            public bool HasMaxDustRewards
            {
                get
                {
                    return this.result.hasMaxDustRewards;
                }
            }

            public bool HasMaxHeroLevel
            {
                get
                {
                    return this.result.hasMaxHeroLevel;
                }
            }

            public bool HasMaxPackRewards
            {
                get
                {
                    return this.result.hasMaxPackRewards;
                }
            }

            public bool HasPackId
            {
                get
                {
                    return this.result.hasPackId;
                }
            }

            public bool HasPacksPerReward
            {
                get
                {
                    return this.result.hasPacksPerReward;
                }
            }

            public bool HasSeasonEnd
            {
                get
                {
                    return this.result.hasSeasonEnd;
                }
            }

            public bool HasWinsPerDust
            {
                get
                {
                    return this.result.hasWinsPerDust;
                }
            }

            public bool HasWinsPerPack
            {
                get
                {
                    return this.result.hasWinsPerPack;
                }
            }

            public bool HasXpSoloLimit
            {
                get
                {
                    return this.result.hasXpSoloLimit;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public int MaxDustRewards
            {
                get
                {
                    return this.result.MaxDustRewards;
                }
                set
                {
                    this.SetMaxDustRewards(value);
                }
            }

            public int MaxHeroLevel
            {
                get
                {
                    return this.result.MaxHeroLevel;
                }
                set
                {
                    this.SetMaxHeroLevel(value);
                }
            }

            public int MaxPackRewards
            {
                get
                {
                    return this.result.MaxPackRewards;
                }
                set
                {
                    this.SetMaxPackRewards(value);
                }
            }

            protected override RewardProgress MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int PackId
            {
                get
                {
                    return this.result.PackId;
                }
                set
                {
                    this.SetPackId(value);
                }
            }

            public int PacksPerReward
            {
                get
                {
                    return this.result.PacksPerReward;
                }
                set
                {
                    this.SetPacksPerReward(value);
                }
            }

            public Date SeasonEnd
            {
                get
                {
                    return this.result.SeasonEnd;
                }
                set
                {
                    this.SetSeasonEnd(value);
                }
            }

            protected override RewardProgress.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public int WinsPerDust
            {
                get
                {
                    return this.result.WinsPerDust;
                }
                set
                {
                    this.SetWinsPerDust(value);
                }
            }

            public int WinsPerPack
            {
                get
                {
                    return this.result.WinsPerPack;
                }
                set
                {
                    this.SetWinsPerPack(value);
                }
            }

            public int XpSoloLimit
            {
                get
                {
                    return this.result.XpSoloLimit;
                }
                set
                {
                    this.SetXpSoloLimit(value);
                }
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0x10f
            }
        }
    }
}

