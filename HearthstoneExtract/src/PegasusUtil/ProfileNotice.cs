namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using PegasusShared;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class ProfileNotice : GeneratedMessageLite<ProfileNotice, Builder>
    {
        private static readonly string[] _profileNoticeFieldNames = new string[] { "entry", "medal", "origin", "origin_data", "precon_deck", "reward_booster", "reward_card", "reward_dust", "reward_forge", "reward_gold", "reward_mount" };
        private static readonly uint[] _profileNoticeFieldTags = new uint[] { 8, 0x12, 0x58, 0x60, 50, 0x1a, 0x22, 0x3a, 0x52, 0x42, 0x4a };
        private static readonly ProfileNotice defaultInstance = new ProfileNotice().MakeReadOnly();
        private long entry_;
        public const int EntryFieldNumber = 1;
        private bool hasEntry;
        private bool hasMedal;
        private bool hasOrigin;
        private bool hasOriginData;
        private bool hasPreconDeck;
        private bool hasRewardBooster;
        private bool hasRewardCard;
        private bool hasRewardDust;
        private bool hasRewardForge;
        private bool hasRewardGold;
        private bool hasRewardMount;
        private ProfileNoticeMedal medal_;
        public const int MedalFieldNumber = 2;
        private int memoizedSerializedSize = -1;
        private int origin_;
        private long originData_;
        public const int OriginDataFieldNumber = 12;
        public const int OriginFieldNumber = 11;
        private ProfileNoticePreconDeck preconDeck_;
        public const int PreconDeckFieldNumber = 6;
        private ProfileNoticeRewardBooster rewardBooster_;
        public const int RewardBoosterFieldNumber = 3;
        private ProfileNoticeRewardCard rewardCard_;
        public const int RewardCardFieldNumber = 4;
        private ProfileNoticeRewardDust rewardDust_;
        public const int RewardDustFieldNumber = 7;
        private ProfileNoticeRewardForge rewardForge_;
        public const int RewardForgeFieldNumber = 10;
        private ProfileNoticeRewardGold rewardGold_;
        public const int RewardGoldFieldNumber = 8;
        private ProfileNoticeRewardMount rewardMount_;
        public const int RewardMountFieldNumber = 9;

        static ProfileNotice()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private ProfileNotice()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ProfileNotice prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ProfileNotice notice = obj as ProfileNotice;
            if (notice == null)
            {
                return false;
            }
            if ((this.hasEntry != notice.hasEntry) || (this.hasEntry && !this.entry_.Equals(notice.entry_)))
            {
                return false;
            }
            if ((this.hasMedal != notice.hasMedal) || (this.hasMedal && !this.medal_.Equals(notice.medal_)))
            {
                return false;
            }
            if ((this.hasRewardBooster != notice.hasRewardBooster) || (this.hasRewardBooster && !this.rewardBooster_.Equals(notice.rewardBooster_)))
            {
                return false;
            }
            if ((this.hasRewardCard != notice.hasRewardCard) || (this.hasRewardCard && !this.rewardCard_.Equals(notice.rewardCard_)))
            {
                return false;
            }
            if ((this.hasPreconDeck != notice.hasPreconDeck) || (this.hasPreconDeck && !this.preconDeck_.Equals(notice.preconDeck_)))
            {
                return false;
            }
            if ((this.hasRewardDust != notice.hasRewardDust) || (this.hasRewardDust && !this.rewardDust_.Equals(notice.rewardDust_)))
            {
                return false;
            }
            if ((this.hasRewardGold != notice.hasRewardGold) || (this.hasRewardGold && !this.rewardGold_.Equals(notice.rewardGold_)))
            {
                return false;
            }
            if ((this.hasRewardMount != notice.hasRewardMount) || (this.hasRewardMount && !this.rewardMount_.Equals(notice.rewardMount_)))
            {
                return false;
            }
            if ((this.hasRewardForge != notice.hasRewardForge) || (this.hasRewardForge && !this.rewardForge_.Equals(notice.rewardForge_)))
            {
                return false;
            }
            if ((this.hasOrigin != notice.hasOrigin) || (this.hasOrigin && !this.origin_.Equals(notice.origin_)))
            {
                return false;
            }
            return ((this.hasOriginData == notice.hasOriginData) && (!this.hasOriginData || this.originData_.Equals(notice.originData_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasEntry)
            {
                hashCode ^= this.entry_.GetHashCode();
            }
            if (this.hasMedal)
            {
                hashCode ^= this.medal_.GetHashCode();
            }
            if (this.hasRewardBooster)
            {
                hashCode ^= this.rewardBooster_.GetHashCode();
            }
            if (this.hasRewardCard)
            {
                hashCode ^= this.rewardCard_.GetHashCode();
            }
            if (this.hasPreconDeck)
            {
                hashCode ^= this.preconDeck_.GetHashCode();
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
            if (this.hasOrigin)
            {
                hashCode ^= this.origin_.GetHashCode();
            }
            if (this.hasOriginData)
            {
                hashCode ^= this.originData_.GetHashCode();
            }
            return hashCode;
        }

        private ProfileNotice MakeReadOnly()
        {
            return this;
        }

        public static ProfileNotice ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ProfileNotice ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileNotice ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ProfileNotice ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ProfileNotice ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ProfileNotice ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ProfileNotice ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ProfileNotice ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileNotice ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileNotice ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ProfileNotice, Builder>.PrintField("entry", this.hasEntry, this.entry_, writer);
            GeneratedMessageLite<ProfileNotice, Builder>.PrintField("medal", this.hasMedal, this.medal_, writer);
            GeneratedMessageLite<ProfileNotice, Builder>.PrintField("reward_booster", this.hasRewardBooster, this.rewardBooster_, writer);
            GeneratedMessageLite<ProfileNotice, Builder>.PrintField("reward_card", this.hasRewardCard, this.rewardCard_, writer);
            GeneratedMessageLite<ProfileNotice, Builder>.PrintField("precon_deck", this.hasPreconDeck, this.preconDeck_, writer);
            GeneratedMessageLite<ProfileNotice, Builder>.PrintField("reward_dust", this.hasRewardDust, this.rewardDust_, writer);
            GeneratedMessageLite<ProfileNotice, Builder>.PrintField("reward_gold", this.hasRewardGold, this.rewardGold_, writer);
            GeneratedMessageLite<ProfileNotice, Builder>.PrintField("reward_mount", this.hasRewardMount, this.rewardMount_, writer);
            GeneratedMessageLite<ProfileNotice, Builder>.PrintField("reward_forge", this.hasRewardForge, this.rewardForge_, writer);
            GeneratedMessageLite<ProfileNotice, Builder>.PrintField("origin", this.hasOrigin, this.origin_, writer);
            GeneratedMessageLite<ProfileNotice, Builder>.PrintField("origin_data", this.hasOriginData, this.originData_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _profileNoticeFieldNames;
            if (this.hasEntry)
            {
                output.WriteInt64(1, strArray[0], this.Entry);
            }
            if (this.hasMedal)
            {
                output.WriteMessage(2, strArray[1], this.Medal);
            }
            if (this.hasRewardBooster)
            {
                output.WriteMessage(3, strArray[5], this.RewardBooster);
            }
            if (this.hasRewardCard)
            {
                output.WriteMessage(4, strArray[6], this.RewardCard);
            }
            if (this.hasPreconDeck)
            {
                output.WriteMessage(6, strArray[4], this.PreconDeck);
            }
            if (this.hasRewardDust)
            {
                output.WriteMessage(7, strArray[7], this.RewardDust);
            }
            if (this.hasRewardGold)
            {
                output.WriteMessage(8, strArray[9], this.RewardGold);
            }
            if (this.hasRewardMount)
            {
                output.WriteMessage(9, strArray[10], this.RewardMount);
            }
            if (this.hasRewardForge)
            {
                output.WriteMessage(10, strArray[8], this.RewardForge);
            }
            if (this.hasOrigin)
            {
                output.WriteInt32(11, strArray[2], this.Origin);
            }
            if (this.hasOriginData)
            {
                output.WriteInt64(12, strArray[3], this.OriginData);
            }
        }

        public static ProfileNotice DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ProfileNotice DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public long Entry
        {
            get
            {
                return this.entry_;
            }
        }

        public bool HasEntry
        {
            get
            {
                return this.hasEntry;
            }
        }

        public bool HasMedal
        {
            get
            {
                return this.hasMedal;
            }
        }

        public bool HasOrigin
        {
            get
            {
                return this.hasOrigin;
            }
        }

        public bool HasOriginData
        {
            get
            {
                return this.hasOriginData;
            }
        }

        public bool HasPreconDeck
        {
            get
            {
                return this.hasPreconDeck;
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
                if (!this.hasEntry)
                {
                    return false;
                }
                if (!this.hasOrigin)
                {
                    return false;
                }
                if (this.HasMedal && !this.Medal.IsInitialized)
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
                if (this.HasPreconDeck && !this.PreconDeck.IsInitialized)
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

        public ProfileNoticeMedal Medal
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.medal_ != null)
                {
                    goto Label_0012;
                }
                return ProfileNoticeMedal.DefaultInstance;
            }
        }

        public int Origin
        {
            get
            {
                return this.origin_;
            }
        }

        public long OriginData
        {
            get
            {
                return this.originData_;
            }
        }

        public ProfileNoticePreconDeck PreconDeck
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.preconDeck_ != null)
                {
                    goto Label_0012;
                }
                return ProfileNoticePreconDeck.DefaultInstance;
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
                    if (this.hasEntry)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(1, this.Entry);
                    }
                    if (this.hasMedal)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, this.Medal);
                    }
                    if (this.hasRewardBooster)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(3, this.RewardBooster);
                    }
                    if (this.hasRewardCard)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(4, this.RewardCard);
                    }
                    if (this.hasPreconDeck)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(6, this.PreconDeck);
                    }
                    if (this.hasRewardDust)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(7, this.RewardDust);
                    }
                    if (this.hasRewardGold)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(8, this.RewardGold);
                    }
                    if (this.hasRewardMount)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(9, this.RewardMount);
                    }
                    if (this.hasRewardForge)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(10, this.RewardForge);
                    }
                    if (this.hasOrigin)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(11, this.Origin);
                    }
                    if (this.hasOriginData)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(12, this.OriginData);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ProfileNotice ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<ProfileNotice, ProfileNotice.Builder>
        {
            private ProfileNotice result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ProfileNotice.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ProfileNotice cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override ProfileNotice BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ProfileNotice.Builder Clear()
            {
                this.result = ProfileNotice.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ProfileNotice.Builder ClearEntry()
            {
                this.PrepareBuilder();
                this.result.hasEntry = false;
                this.result.entry_ = 0L;
                return this;
            }

            public ProfileNotice.Builder ClearMedal()
            {
                this.PrepareBuilder();
                this.result.hasMedal = false;
                this.result.medal_ = null;
                return this;
            }

            public ProfileNotice.Builder ClearOrigin()
            {
                this.PrepareBuilder();
                this.result.hasOrigin = false;
                this.result.origin_ = 0;
                return this;
            }

            public ProfileNotice.Builder ClearOriginData()
            {
                this.PrepareBuilder();
                this.result.hasOriginData = false;
                this.result.originData_ = 0L;
                return this;
            }

            public ProfileNotice.Builder ClearPreconDeck()
            {
                this.PrepareBuilder();
                this.result.hasPreconDeck = false;
                this.result.preconDeck_ = null;
                return this;
            }

            public ProfileNotice.Builder ClearRewardBooster()
            {
                this.PrepareBuilder();
                this.result.hasRewardBooster = false;
                this.result.rewardBooster_ = null;
                return this;
            }

            public ProfileNotice.Builder ClearRewardCard()
            {
                this.PrepareBuilder();
                this.result.hasRewardCard = false;
                this.result.rewardCard_ = null;
                return this;
            }

            public ProfileNotice.Builder ClearRewardDust()
            {
                this.PrepareBuilder();
                this.result.hasRewardDust = false;
                this.result.rewardDust_ = null;
                return this;
            }

            public ProfileNotice.Builder ClearRewardForge()
            {
                this.PrepareBuilder();
                this.result.hasRewardForge = false;
                this.result.rewardForge_ = null;
                return this;
            }

            public ProfileNotice.Builder ClearRewardGold()
            {
                this.PrepareBuilder();
                this.result.hasRewardGold = false;
                this.result.rewardGold_ = null;
                return this;
            }

            public ProfileNotice.Builder ClearRewardMount()
            {
                this.PrepareBuilder();
                this.result.hasRewardMount = false;
                this.result.rewardMount_ = null;
                return this;
            }

            public override ProfileNotice.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ProfileNotice.Builder(this.result);
                }
                return new ProfileNotice.Builder().MergeFrom(this.result);
            }

            public override ProfileNotice.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ProfileNotice.Builder MergeFrom(IMessageLite other)
            {
                if (other is ProfileNotice)
                {
                    return this.MergeFrom((ProfileNotice) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ProfileNotice.Builder MergeFrom(ProfileNotice other)
            {
                if (other != ProfileNotice.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasEntry)
                    {
                        this.Entry = other.Entry;
                    }
                    if (other.HasMedal)
                    {
                        this.MergeMedal(other.Medal);
                    }
                    if (other.HasRewardBooster)
                    {
                        this.MergeRewardBooster(other.RewardBooster);
                    }
                    if (other.HasRewardCard)
                    {
                        this.MergeRewardCard(other.RewardCard);
                    }
                    if (other.HasPreconDeck)
                    {
                        this.MergePreconDeck(other.PreconDeck);
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
                    if (other.HasOrigin)
                    {
                        this.Origin = other.Origin;
                    }
                    if (other.HasOriginData)
                    {
                        this.OriginData = other.OriginData;
                    }
                }
                return this;
            }

            public override ProfileNotice.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ProfileNotice._profileNoticeFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ProfileNotice._profileNoticeFieldTags[index];
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
                            this.result.hasEntry = input.ReadInt64(ref this.result.entry_);
                            continue;
                        }
                        case 0x12:
                        {
                            ProfileNoticeMedal.Builder builder = ProfileNoticeMedal.CreateBuilder();
                            if (this.result.hasMedal)
                            {
                                builder.MergeFrom(this.Medal);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.Medal = builder.BuildPartial();
                            continue;
                        }
                        case 0x1a:
                        {
                            ProfileNoticeRewardBooster.Builder builder2 = ProfileNoticeRewardBooster.CreateBuilder();
                            if (this.result.hasRewardBooster)
                            {
                                builder2.MergeFrom(this.RewardBooster);
                            }
                            input.ReadMessage(builder2, extensionRegistry);
                            this.RewardBooster = builder2.BuildPartial();
                            continue;
                        }
                        case 0x22:
                        {
                            ProfileNoticeRewardCard.Builder builder3 = ProfileNoticeRewardCard.CreateBuilder();
                            if (this.result.hasRewardCard)
                            {
                                builder3.MergeFrom(this.RewardCard);
                            }
                            input.ReadMessage(builder3, extensionRegistry);
                            this.RewardCard = builder3.BuildPartial();
                            continue;
                        }
                        case 50:
                        {
                            ProfileNoticePreconDeck.Builder builder4 = ProfileNoticePreconDeck.CreateBuilder();
                            if (this.result.hasPreconDeck)
                            {
                                builder4.MergeFrom(this.PreconDeck);
                            }
                            input.ReadMessage(builder4, extensionRegistry);
                            this.PreconDeck = builder4.BuildPartial();
                            continue;
                        }
                        case 0x3a:
                        {
                            ProfileNoticeRewardDust.Builder builder5 = ProfileNoticeRewardDust.CreateBuilder();
                            if (this.result.hasRewardDust)
                            {
                                builder5.MergeFrom(this.RewardDust);
                            }
                            input.ReadMessage(builder5, extensionRegistry);
                            this.RewardDust = builder5.BuildPartial();
                            continue;
                        }
                        case 0x42:
                        {
                            ProfileNoticeRewardGold.Builder builder6 = ProfileNoticeRewardGold.CreateBuilder();
                            if (this.result.hasRewardGold)
                            {
                                builder6.MergeFrom(this.RewardGold);
                            }
                            input.ReadMessage(builder6, extensionRegistry);
                            this.RewardGold = builder6.BuildPartial();
                            continue;
                        }
                        case 0x4a:
                        {
                            ProfileNoticeRewardMount.Builder builder7 = ProfileNoticeRewardMount.CreateBuilder();
                            if (this.result.hasRewardMount)
                            {
                                builder7.MergeFrom(this.RewardMount);
                            }
                            input.ReadMessage(builder7, extensionRegistry);
                            this.RewardMount = builder7.BuildPartial();
                            continue;
                        }
                        case 0x52:
                        {
                            ProfileNoticeRewardForge.Builder builder8 = ProfileNoticeRewardForge.CreateBuilder();
                            if (this.result.hasRewardForge)
                            {
                                builder8.MergeFrom(this.RewardForge);
                            }
                            input.ReadMessage(builder8, extensionRegistry);
                            this.RewardForge = builder8.BuildPartial();
                            continue;
                        }
                        case 0x58:
                        {
                            this.result.hasOrigin = input.ReadInt32(ref this.result.origin_);
                            continue;
                        }
                        case 0x60:
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
                    this.result.hasOriginData = input.ReadInt64(ref this.result.originData_);
                }
                return this;
            }

            public ProfileNotice.Builder MergeMedal(ProfileNoticeMedal value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasMedal && (this.result.medal_ != ProfileNoticeMedal.DefaultInstance))
                {
                    this.result.medal_ = ProfileNoticeMedal.CreateBuilder(this.result.medal_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.medal_ = value;
                }
                this.result.hasMedal = true;
                return this;
            }

            public ProfileNotice.Builder MergePreconDeck(ProfileNoticePreconDeck value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasPreconDeck && (this.result.preconDeck_ != ProfileNoticePreconDeck.DefaultInstance))
                {
                    this.result.preconDeck_ = ProfileNoticePreconDeck.CreateBuilder(this.result.preconDeck_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.preconDeck_ = value;
                }
                this.result.hasPreconDeck = true;
                return this;
            }

            public ProfileNotice.Builder MergeRewardBooster(ProfileNoticeRewardBooster value)
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

            public ProfileNotice.Builder MergeRewardCard(ProfileNoticeRewardCard value)
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

            public ProfileNotice.Builder MergeRewardDust(ProfileNoticeRewardDust value)
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

            public ProfileNotice.Builder MergeRewardForge(ProfileNoticeRewardForge value)
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

            public ProfileNotice.Builder MergeRewardGold(ProfileNoticeRewardGold value)
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

            public ProfileNotice.Builder MergeRewardMount(ProfileNoticeRewardMount value)
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

            private ProfileNotice PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ProfileNotice result = this.result;
                    this.result = new ProfileNotice();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ProfileNotice.Builder SetEntry(long value)
            {
                this.PrepareBuilder();
                this.result.hasEntry = true;
                this.result.entry_ = value;
                return this;
            }

            public ProfileNotice.Builder SetMedal(ProfileNoticeMedal value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasMedal = true;
                this.result.medal_ = value;
                return this;
            }

            public ProfileNotice.Builder SetMedal(ProfileNoticeMedal.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasMedal = true;
                this.result.medal_ = builderForValue.Build();
                return this;
            }

            public ProfileNotice.Builder SetOrigin(int value)
            {
                this.PrepareBuilder();
                this.result.hasOrigin = true;
                this.result.origin_ = value;
                return this;
            }

            public ProfileNotice.Builder SetOriginData(long value)
            {
                this.PrepareBuilder();
                this.result.hasOriginData = true;
                this.result.originData_ = value;
                return this;
            }

            public ProfileNotice.Builder SetPreconDeck(ProfileNoticePreconDeck value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasPreconDeck = true;
                this.result.preconDeck_ = value;
                return this;
            }

            public ProfileNotice.Builder SetPreconDeck(ProfileNoticePreconDeck.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasPreconDeck = true;
                this.result.preconDeck_ = builderForValue.Build();
                return this;
            }

            public ProfileNotice.Builder SetRewardBooster(ProfileNoticeRewardBooster value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasRewardBooster = true;
                this.result.rewardBooster_ = value;
                return this;
            }

            public ProfileNotice.Builder SetRewardBooster(ProfileNoticeRewardBooster.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasRewardBooster = true;
                this.result.rewardBooster_ = builderForValue.Build();
                return this;
            }

            public ProfileNotice.Builder SetRewardCard(ProfileNoticeRewardCard value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasRewardCard = true;
                this.result.rewardCard_ = value;
                return this;
            }

            public ProfileNotice.Builder SetRewardCard(ProfileNoticeRewardCard.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasRewardCard = true;
                this.result.rewardCard_ = builderForValue.Build();
                return this;
            }

            public ProfileNotice.Builder SetRewardDust(ProfileNoticeRewardDust value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasRewardDust = true;
                this.result.rewardDust_ = value;
                return this;
            }

            public ProfileNotice.Builder SetRewardDust(ProfileNoticeRewardDust.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasRewardDust = true;
                this.result.rewardDust_ = builderForValue.Build();
                return this;
            }

            public ProfileNotice.Builder SetRewardForge(ProfileNoticeRewardForge value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasRewardForge = true;
                this.result.rewardForge_ = value;
                return this;
            }

            public ProfileNotice.Builder SetRewardForge(ProfileNoticeRewardForge.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasRewardForge = true;
                this.result.rewardForge_ = builderForValue.Build();
                return this;
            }

            public ProfileNotice.Builder SetRewardGold(ProfileNoticeRewardGold value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasRewardGold = true;
                this.result.rewardGold_ = value;
                return this;
            }

            public ProfileNotice.Builder SetRewardGold(ProfileNoticeRewardGold.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasRewardGold = true;
                this.result.rewardGold_ = builderForValue.Build();
                return this;
            }

            public ProfileNotice.Builder SetRewardMount(ProfileNoticeRewardMount value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasRewardMount = true;
                this.result.rewardMount_ = value;
                return this;
            }

            public ProfileNotice.Builder SetRewardMount(ProfileNoticeRewardMount.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasRewardMount = true;
                this.result.rewardMount_ = builderForValue.Build();
                return this;
            }

            public override ProfileNotice DefaultInstanceForType
            {
                get
                {
                    return ProfileNotice.DefaultInstance;
                }
            }

            public long Entry
            {
                get
                {
                    return this.result.Entry;
                }
                set
                {
                    this.SetEntry(value);
                }
            }

            public bool HasEntry
            {
                get
                {
                    return this.result.hasEntry;
                }
            }

            public bool HasMedal
            {
                get
                {
                    return this.result.hasMedal;
                }
            }

            public bool HasOrigin
            {
                get
                {
                    return this.result.hasOrigin;
                }
            }

            public bool HasOriginData
            {
                get
                {
                    return this.result.hasOriginData;
                }
            }

            public bool HasPreconDeck
            {
                get
                {
                    return this.result.hasPreconDeck;
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

            public ProfileNoticeMedal Medal
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

            protected override ProfileNotice MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int Origin
            {
                get
                {
                    return this.result.Origin;
                }
                set
                {
                    this.SetOrigin(value);
                }
            }

            public long OriginData
            {
                get
                {
                    return this.result.OriginData;
                }
                set
                {
                    this.SetOriginData(value);
                }
            }

            public ProfileNoticePreconDeck PreconDeck
            {
                get
                {
                    return this.result.PreconDeck;
                }
                set
                {
                    this.SetPreconDeck(value);
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

            protected override ProfileNotice.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

