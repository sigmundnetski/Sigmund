namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using PegasusShared;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class NextHeroLevelReward : GeneratedMessageLite<NextHeroLevelReward, Builder>
    {
        private static readonly string[] _nextHeroLevelRewardFieldNames = new string[] { "level", "reward_booster", "reward_card", "reward_dust", "reward_forge", "reward_gold", "reward_mount" };
        private static readonly uint[] _nextHeroLevelRewardFieldTags = new uint[] { 8, 0x12, 0x1a, 0x22, 0x3a, 0x2a, 50 };
        private static readonly NextHeroLevelReward defaultInstance = new NextHeroLevelReward().MakeReadOnly();
        private bool hasLevel;
        private bool hasRewardBooster;
        private bool hasRewardCard;
        private bool hasRewardDust;
        private bool hasRewardForge;
        private bool hasRewardGold;
        private bool hasRewardMount;
        private int level_;
        public const int LevelFieldNumber = 1;
        private int memoizedSerializedSize = -1;
        private ProfileNoticeRewardBooster rewardBooster_;
        public const int RewardBoosterFieldNumber = 2;
        private ProfileNoticeRewardCard rewardCard_;
        public const int RewardCardFieldNumber = 3;
        private ProfileNoticeRewardDust rewardDust_;
        public const int RewardDustFieldNumber = 4;
        private ProfileNoticeRewardForge rewardForge_;
        public const int RewardForgeFieldNumber = 7;
        private ProfileNoticeRewardGold rewardGold_;
        public const int RewardGoldFieldNumber = 5;
        private ProfileNoticeRewardMount rewardMount_;
        public const int RewardMountFieldNumber = 6;

        static NextHeroLevelReward()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private NextHeroLevelReward()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(NextHeroLevelReward prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            NextHeroLevelReward reward = obj as NextHeroLevelReward;
            if (reward == null)
            {
                return false;
            }
            if ((this.hasLevel != reward.hasLevel) || (this.hasLevel && !this.level_.Equals(reward.level_)))
            {
                return false;
            }
            if ((this.hasRewardBooster != reward.hasRewardBooster) || (this.hasRewardBooster && !this.rewardBooster_.Equals(reward.rewardBooster_)))
            {
                return false;
            }
            if ((this.hasRewardCard != reward.hasRewardCard) || (this.hasRewardCard && !this.rewardCard_.Equals(reward.rewardCard_)))
            {
                return false;
            }
            if ((this.hasRewardDust != reward.hasRewardDust) || (this.hasRewardDust && !this.rewardDust_.Equals(reward.rewardDust_)))
            {
                return false;
            }
            if ((this.hasRewardGold != reward.hasRewardGold) || (this.hasRewardGold && !this.rewardGold_.Equals(reward.rewardGold_)))
            {
                return false;
            }
            if ((this.hasRewardMount != reward.hasRewardMount) || (this.hasRewardMount && !this.rewardMount_.Equals(reward.rewardMount_)))
            {
                return false;
            }
            return ((this.hasRewardForge == reward.hasRewardForge) && (!this.hasRewardForge || this.rewardForge_.Equals(reward.rewardForge_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasLevel)
            {
                hashCode ^= this.level_.GetHashCode();
            }
            if (this.hasRewardBooster)
            {
                hashCode ^= this.rewardBooster_.GetHashCode();
            }
            if (this.hasRewardCard)
            {
                hashCode ^= this.rewardCard_.GetHashCode();
            }
            if (this.hasRewardDust)
            {
                hashCode ^= this.rewardDust_.GetHashCode();
            }
            if (this.hasRewardGold)
            {
                hashCode ^= this.rewardGold_.GetHashCode();
            }
            if (this.hasRewardMount)
            {
                hashCode ^= this.rewardMount_.GetHashCode();
            }
            if (this.hasRewardForge)
            {
                hashCode ^= this.rewardForge_.GetHashCode();
            }
            return hashCode;
        }

        private NextHeroLevelReward MakeReadOnly()
        {
            return this;
        }

        public static NextHeroLevelReward ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static NextHeroLevelReward ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static NextHeroLevelReward ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static NextHeroLevelReward ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static NextHeroLevelReward ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static NextHeroLevelReward ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static NextHeroLevelReward ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static NextHeroLevelReward ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static NextHeroLevelReward ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static NextHeroLevelReward ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<NextHeroLevelReward, Builder>.PrintField("level", this.hasLevel, this.level_, writer);
            GeneratedMessageLite<NextHeroLevelReward, Builder>.PrintField("reward_booster", this.hasRewardBooster, this.rewardBooster_, writer);
            GeneratedMessageLite<NextHeroLevelReward, Builder>.PrintField("reward_card", this.hasRewardCard, this.rewardCard_, writer);
            GeneratedMessageLite<NextHeroLevelReward, Builder>.PrintField("reward_dust", this.hasRewardDust, this.rewardDust_, writer);
            GeneratedMessageLite<NextHeroLevelReward, Builder>.PrintField("reward_gold", this.hasRewardGold, this.rewardGold_, writer);
            GeneratedMessageLite<NextHeroLevelReward, Builder>.PrintField("reward_mount", this.hasRewardMount, this.rewardMount_, writer);
            GeneratedMessageLite<NextHeroLevelReward, Builder>.PrintField("reward_forge", this.hasRewardForge, this.rewardForge_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _nextHeroLevelRewardFieldNames;
            if (this.hasLevel)
            {
                output.WriteInt32(1, strArray[0], this.Level);
            }
            if (this.hasRewardBooster)
            {
                output.WriteMessage(2, strArray[1], this.RewardBooster);
            }
            if (this.hasRewardCard)
            {
                output.WriteMessage(3, strArray[2], this.RewardCard);
            }
            if (this.hasRewardDust)
            {
                output.WriteMessage(4, strArray[3], this.RewardDust);
            }
            if (this.hasRewardGold)
            {
                output.WriteMessage(5, strArray[5], this.RewardGold);
            }
            if (this.hasRewardMount)
            {
                output.WriteMessage(6, strArray[6], this.RewardMount);
            }
            if (this.hasRewardForge)
            {
                output.WriteMessage(7, strArray[4], this.RewardForge);
            }
        }

        public static NextHeroLevelReward DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override NextHeroLevelReward DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasLevel
        {
            get
            {
                return this.hasLevel;
            }
        }

        public bool HasRewardBooster
        {
            get
            {
                return this.hasRewardBooster;
            }
        }

        public bool HasRewardCard
        {
            get
            {
                return this.hasRewardCard;
            }
        }

        public bool HasRewardDust
        {
            get
            {
                return this.hasRewardDust;
            }
        }

        public bool HasRewardForge
        {
            get
            {
                return this.hasRewardForge;
            }
        }

        public bool HasRewardGold
        {
            get
            {
                return this.hasRewardGold;
            }
        }

        public bool HasRewardMount
        {
            get
            {
                return this.hasRewardMount;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasLevel)
                {
                    return false;
                }
                if (this.HasRewardBooster && !this.RewardBooster.IsInitialized)
                {
                    return false;
                }
                if (this.HasRewardCard && !this.RewardCard.IsInitialized)
                {
                    return false;
                }
                if (this.HasRewardDust && !this.RewardDust.IsInitialized)
                {
                    return false;
                }
                if (this.HasRewardGold && !this.RewardGold.IsInitialized)
                {
                    return false;
                }
                if (this.HasRewardMount && !this.RewardMount.IsInitialized)
                {
                    return false;
                }
                if (this.HasRewardForge && !this.RewardForge.IsInitialized)
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

        public ProfileNoticeRewardBooster RewardBooster
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.rewardBooster_ != null)
                {
                    goto Label_0012;
                }
                return ProfileNoticeRewardBooster.DefaultInstance;
            }
        }

        public ProfileNoticeRewardCard RewardCard
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.rewardCard_ != null)
                {
                    goto Label_0012;
                }
                return ProfileNoticeRewardCard.DefaultInstance;
            }
        }

        public ProfileNoticeRewardDust RewardDust
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.rewardDust_ != null)
                {
                    goto Label_0012;
                }
                return ProfileNoticeRewardDust.DefaultInstance;
            }
        }

        public ProfileNoticeRewardForge RewardForge
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.rewardForge_ != null)
                {
                    goto Label_0012;
                }
                return ProfileNoticeRewardForge.DefaultInstance;
            }
        }

        public ProfileNoticeRewardGold RewardGold
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.rewardGold_ != null)
                {
                    goto Label_0012;
                }
                return ProfileNoticeRewardGold.DefaultInstance;
            }
        }

        public ProfileNoticeRewardMount RewardMount
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.rewardMount_ != null)
                {
                    goto Label_0012;
                }
                return ProfileNoticeRewardMount.DefaultInstance;
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
                    if (this.hasLevel)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.Level);
                    }
                    if (this.hasRewardBooster)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, this.RewardBooster);
                    }
                    if (this.hasRewardCard)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(3, this.RewardCard);
                    }
                    if (this.hasRewardDust)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(4, this.RewardDust);
                    }
                    if (this.hasRewardGold)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(5, this.RewardGold);
                    }
                    if (this.hasRewardMount)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(6, this.RewardMount);
                    }
                    if (this.hasRewardForge)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(7, this.RewardForge);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override NextHeroLevelReward ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<NextHeroLevelReward, NextHeroLevelReward.Builder>
        {
            private NextHeroLevelReward result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = NextHeroLevelReward.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(NextHeroLevelReward cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override NextHeroLevelReward BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override NextHeroLevelReward.Builder Clear()
            {
                this.result = NextHeroLevelReward.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public NextHeroLevelReward.Builder ClearLevel()
            {
                this.PrepareBuilder();
                this.result.hasLevel = false;
                this.result.level_ = 0;
                return this;
            }

            public NextHeroLevelReward.Builder ClearRewardBooster()
            {
                this.PrepareBuilder();
                this.result.hasRewardBooster = false;
                this.result.rewardBooster_ = null;
                return this;
            }

            public NextHeroLevelReward.Builder ClearRewardCard()
            {
                this.PrepareBuilder();
                this.result.hasRewardCard = false;
                this.result.rewardCard_ = null;
                return this;
            }

            public NextHeroLevelReward.Builder ClearRewardDust()
            {
                this.PrepareBuilder();
                this.result.hasRewardDust = false;
                this.result.rewardDust_ = null;
                return this;
            }

            public NextHeroLevelReward.Builder ClearRewardForge()
            {
                this.PrepareBuilder();
                this.result.hasRewardForge = false;
                this.result.rewardForge_ = null;
                return this;
            }

            public NextHeroLevelReward.Builder ClearRewardGold()
            {
                this.PrepareBuilder();
                this.result.hasRewardGold = false;
                this.result.rewardGold_ = null;
                return this;
            }

            public NextHeroLevelReward.Builder ClearRewardMount()
            {
                this.PrepareBuilder();
                this.result.hasRewardMount = false;
                this.result.rewardMount_ = null;
                return this;
            }

            public override NextHeroLevelReward.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new NextHeroLevelReward.Builder(this.result);
                }
                return new NextHeroLevelReward.Builder().MergeFrom(this.result);
            }

            public override NextHeroLevelReward.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override NextHeroLevelReward.Builder MergeFrom(IMessageLite other)
            {
                if (other is NextHeroLevelReward)
                {
                    return this.MergeFrom((NextHeroLevelReward) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override NextHeroLevelReward.Builder MergeFrom(NextHeroLevelReward other)
            {
                if (other != NextHeroLevelReward.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasLevel)
                    {
                        this.Level = other.Level;
                    }
                    if (other.HasRewardBooster)
                    {
                        this.MergeRewardBooster(other.RewardBooster);
                    }
                    if (other.HasRewardCard)
                    {
                        this.MergeRewardCard(other.RewardCard);
                    }
                    if (other.HasRewardDust)
                    {
                        this.MergeRewardDust(other.RewardDust);
                    }
                    if (other.HasRewardGold)
                    {
                        this.MergeRewardGold(other.RewardGold);
                    }
                    if (other.HasRewardMount)
                    {
                        this.MergeRewardMount(other.RewardMount);
                    }
                    if (other.HasRewardForge)
                    {
                        this.MergeRewardForge(other.RewardForge);
                    }
                }
                return this;
            }

            public override NextHeroLevelReward.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(NextHeroLevelReward._nextHeroLevelRewardFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = NextHeroLevelReward._nextHeroLevelRewardFieldTags[index];
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
                            this.result.hasLevel = input.ReadInt32(ref this.result.level_);
                            continue;
                        }
                        case 0x12:
                        {
                            ProfileNoticeRewardBooster.Builder builder = ProfileNoticeRewardBooster.CreateBuilder();
                            if (this.result.hasRewardBooster)
                            {
                                builder.MergeFrom(this.RewardBooster);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.RewardBooster = builder.BuildPartial();
                            continue;
                        }
                        case 0x1a:
                        {
                            ProfileNoticeRewardCard.Builder builder2 = ProfileNoticeRewardCard.CreateBuilder();
                            if (this.result.hasRewardCard)
                            {
                                builder2.MergeFrom(this.RewardCard);
                            }
                            input.ReadMessage(builder2, extensionRegistry);
                            this.RewardCard = builder2.BuildPartial();
                            continue;
                        }
                        case 0x22:
                        {
                            ProfileNoticeRewardDust.Builder builder3 = ProfileNoticeRewardDust.CreateBuilder();
                            if (this.result.hasRewardDust)
                            {
                                builder3.MergeFrom(this.RewardDust);
                            }
                            input.ReadMessage(builder3, extensionRegistry);
                            this.RewardDust = builder3.BuildPartial();
                            continue;
                        }
                        case 0x2a:
                        {
                            ProfileNoticeRewardGold.Builder builder4 = ProfileNoticeRewardGold.CreateBuilder();
                            if (this.result.hasRewardGold)
                            {
                                builder4.MergeFrom(this.RewardGold);
                            }
                            input.ReadMessage(builder4, extensionRegistry);
                            this.RewardGold = builder4.BuildPartial();
                            continue;
                        }
                        case 50:
                        {
                            ProfileNoticeRewardMount.Builder builder5 = ProfileNoticeRewardMount.CreateBuilder();
                            if (this.result.hasRewardMount)
                            {
                                builder5.MergeFrom(this.RewardMount);
                            }
                            input.ReadMessage(builder5, extensionRegistry);
                            this.RewardMount = builder5.BuildPartial();
                            continue;
                        }
                        case 0x3a:
                        {
                            ProfileNoticeRewardForge.Builder builder6 = ProfileNoticeRewardForge.CreateBuilder();
                            if (this.result.hasRewardForge)
                            {
                                builder6.MergeFrom(this.RewardForge);
                            }
                            input.ReadMessage(builder6, extensionRegistry);
                            this.RewardForge = builder6.BuildPartial();
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

            public NextHeroLevelReward.Builder MergeRewardBooster(ProfileNoticeRewardBooster value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasRewardBooster && (this.result.rewardBooster_ != ProfileNoticeRewardBooster.DefaultInstance))
                {
                    this.result.rewardBooster_ = ProfileNoticeRewardBooster.CreateBuilder(this.result.rewardBooster_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.rewardBooster_ = value;
                }
                this.result.hasRewardBooster = true;
                return this;
            }

            public NextHeroLevelReward.Builder MergeRewardCard(ProfileNoticeRewardCard value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasRewardCard && (this.result.rewardCard_ != ProfileNoticeRewardCard.DefaultInstance))
                {
                    this.result.rewardCard_ = ProfileNoticeRewardCard.CreateBuilder(this.result.rewardCard_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.rewardCard_ = value;
                }
                this.result.hasRewardCard = true;
                return this;
            }

            public NextHeroLevelReward.Builder MergeRewardDust(ProfileNoticeRewardDust value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasRewardDust && (this.result.rewardDust_ != ProfileNoticeRewardDust.DefaultInstance))
                {
                    this.result.rewardDust_ = ProfileNoticeRewardDust.CreateBuilder(this.result.rewardDust_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.rewardDust_ = value;
                }
                this.result.hasRewardDust = true;
                return this;
            }

            public NextHeroLevelReward.Builder MergeRewardForge(ProfileNoticeRewardForge value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasRewardForge && (this.result.rewardForge_ != ProfileNoticeRewardForge.DefaultInstance))
                {
                    this.result.rewardForge_ = ProfileNoticeRewardForge.CreateBuilder(this.result.rewardForge_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.rewardForge_ = value;
                }
                this.result.hasRewardForge = true;
                return this;
            }

            public NextHeroLevelReward.Builder MergeRewardGold(ProfileNoticeRewardGold value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasRewardGold && (this.result.rewardGold_ != ProfileNoticeRewardGold.DefaultInstance))
                {
                    this.result.rewardGold_ = ProfileNoticeRewardGold.CreateBuilder(this.result.rewardGold_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.rewardGold_ = value;
                }
                this.result.hasRewardGold = true;
                return this;
            }

            public NextHeroLevelReward.Builder MergeRewardMount(ProfileNoticeRewardMount value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasRewardMount && (this.result.rewardMount_ != ProfileNoticeRewardMount.DefaultInstance))
                {
                    this.result.rewardMount_ = ProfileNoticeRewardMount.CreateBuilder(this.result.rewardMount_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.rewardMount_ = value;
                }
                this.result.hasRewardMount = true;
                return this;
            }

            private NextHeroLevelReward PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    NextHeroLevelReward result = this.result;
                    this.result = new NextHeroLevelReward();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public NextHeroLevelReward.Builder SetLevel(int value)
            {
                this.PrepareBuilder();
                this.result.hasLevel = true;
                this.result.level_ = value;
                return this;
            }

            public NextHeroLevelReward.Builder SetRewardBooster(ProfileNoticeRewardBooster value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasRewardBooster = true;
                this.result.rewardBooster_ = value;
                return this;
            }

            public NextHeroLevelReward.Builder SetRewardBooster(ProfileNoticeRewardBooster.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasRewardBooster = true;
                this.result.rewardBooster_ = builderForValue.Build();
                return this;
            }

            public NextHeroLevelReward.Builder SetRewardCard(ProfileNoticeRewardCard value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasRewardCard = true;
                this.result.rewardCard_ = value;
                return this;
            }

            public NextHeroLevelReward.Builder SetRewardCard(ProfileNoticeRewardCard.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasRewardCard = true;
                this.result.rewardCard_ = builderForValue.Build();
                return this;
            }

            public NextHeroLevelReward.Builder SetRewardDust(ProfileNoticeRewardDust value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasRewardDust = true;
                this.result.rewardDust_ = value;
                return this;
            }

            public NextHeroLevelReward.Builder SetRewardDust(ProfileNoticeRewardDust.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasRewardDust = true;
                this.result.rewardDust_ = builderForValue.Build();
                return this;
            }

            public NextHeroLevelReward.Builder SetRewardForge(ProfileNoticeRewardForge value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasRewardForge = true;
                this.result.rewardForge_ = value;
                return this;
            }

            public NextHeroLevelReward.Builder SetRewardForge(ProfileNoticeRewardForge.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasRewardForge = true;
                this.result.rewardForge_ = builderForValue.Build();
                return this;
            }

            public NextHeroLevelReward.Builder SetRewardGold(ProfileNoticeRewardGold value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasRewardGold = true;
                this.result.rewardGold_ = value;
                return this;
            }

            public NextHeroLevelReward.Builder SetRewardGold(ProfileNoticeRewardGold.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasRewardGold = true;
                this.result.rewardGold_ = builderForValue.Build();
                return this;
            }

            public NextHeroLevelReward.Builder SetRewardMount(ProfileNoticeRewardMount value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasRewardMount = true;
                this.result.rewardMount_ = value;
                return this;
            }

            public NextHeroLevelReward.Builder SetRewardMount(ProfileNoticeRewardMount.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasRewardMount = true;
                this.result.rewardMount_ = builderForValue.Build();
                return this;
            }

            public override NextHeroLevelReward DefaultInstanceForType
            {
                get
                {
                    return NextHeroLevelReward.DefaultInstance;
                }
            }

            public bool HasLevel
            {
                get
                {
                    return this.result.hasLevel;
                }
            }

            public bool HasRewardBooster
            {
                get
                {
                    return this.result.hasRewardBooster;
                }
            }

            public bool HasRewardCard
            {
                get
                {
                    return this.result.hasRewardCard;
                }
            }

            public bool HasRewardDust
            {
                get
                {
                    return this.result.hasRewardDust;
                }
            }

            public bool HasRewardForge
            {
                get
                {
                    return this.result.hasRewardForge;
                }
            }

            public bool HasRewardGold
            {
                get
                {
                    return this.result.hasRewardGold;
                }
            }

            public bool HasRewardMount
            {
                get
                {
                    return this.result.hasRewardMount;
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

            protected override NextHeroLevelReward MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public ProfileNoticeRewardBooster RewardBooster
            {
                get
                {
                    return this.result.RewardBooster;
                }
                set
                {
                    this.SetRewardBooster(value);
                }
            }

            public ProfileNoticeRewardCard RewardCard
            {
                get
                {
                    return this.result.RewardCard;
                }
                set
                {
                    this.SetRewardCard(value);
                }
            }

            public ProfileNoticeRewardDust RewardDust
            {
                get
                {
                    return this.result.RewardDust;
                }
                set
                {
                    this.SetRewardDust(value);
                }
            }

            public ProfileNoticeRewardForge RewardForge
            {
                get
                {
                    return this.result.RewardForge;
                }
                set
                {
                    this.SetRewardForge(value);
                }
            }

            public ProfileNoticeRewardGold RewardGold
            {
                get
                {
                    return this.result.RewardGold;
                }
                set
                {
                    this.SetRewardGold(value);
                }
            }

            public ProfileNoticeRewardMount RewardMount
            {
                get
                {
                    return this.result.RewardMount;
                }
                set
                {
                    this.SetRewardMount(value);
                }
            }

            protected override NextHeroLevelReward.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

