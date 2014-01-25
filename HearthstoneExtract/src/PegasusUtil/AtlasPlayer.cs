namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class AtlasPlayer : GeneratedMessageLite<AtlasPlayer, Builder>
    {
        private static readonly string[] _atlasPlayerFieldNames = new string[] { "battlepay_id", "booster_list", "campaign_progress", "craft_asset_id", "craft_count", "craft_premium", "credits", "deck_limit", "deleted_reason", "games_completed", "games_lost", "games_startd", "games_won", "last_game_id", "player_id", "random_deck_id" };
        private static readonly uint[] _atlasPlayerFieldTags = new uint[] { 120, 130, 0x40, 0x60, 0x70, 0x68, 80, 0x38, 0x30, 0x18, 40, 0x10, 0x20, 0x58, 8, 0x48 };
        private long battlepayId_;
        public const int BattlepayIdFieldNumber = 15;
        private PopsicleList<BoosterInfo> boosterList_ = new PopsicleList<BoosterInfo>();
        public const int BoosterListFieldNumber = 0x10;
        private long campaignProgress_;
        public const int CampaignProgressFieldNumber = 8;
        private int craftAssetId_;
        public const int CraftAssetIdFieldNumber = 12;
        private int craftCount_;
        public const int CraftCountFieldNumber = 14;
        private int craftPremium_;
        public const int CraftPremiumFieldNumber = 13;
        private long credits_;
        public const int CreditsFieldNumber = 10;
        private int deckLimit_;
        public const int DeckLimitFieldNumber = 7;
        private static readonly AtlasPlayer defaultInstance = new AtlasPlayer().MakeReadOnly();
        private int deletedReason_;
        public const int DeletedReasonFieldNumber = 6;
        private int gamesCompleted_;
        public const int GamesCompletedFieldNumber = 3;
        private int gamesLost_;
        public const int GamesLostFieldNumber = 5;
        private int gamesStartd_;
        public const int GamesStartdFieldNumber = 2;
        private int gamesWon_;
        public const int GamesWonFieldNumber = 4;
        private bool hasBattlepayId;
        private bool hasCampaignProgress;
        private bool hasCraftAssetId;
        private bool hasCraftCount;
        private bool hasCraftPremium;
        private bool hasCredits;
        private bool hasDeckLimit;
        private bool hasDeletedReason;
        private bool hasGamesCompleted;
        private bool hasGamesLost;
        private bool hasGamesStartd;
        private bool hasGamesWon;
        private bool hasLastGameId;
        private bool hasPlayerId;
        private bool hasRandomDeckId;
        private long lastGameId_;
        public const int LastGameIdFieldNumber = 11;
        private int memoizedSerializedSize = -1;
        private long playerId_;
        public const int PlayerIdFieldNumber = 1;
        private long randomDeckId_;
        public const int RandomDeckIdFieldNumber = 9;

        static AtlasPlayer()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AtlasPlayer()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AtlasPlayer prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AtlasPlayer player = obj as AtlasPlayer;
            if (player == null)
            {
                return false;
            }
            if ((this.hasPlayerId != player.hasPlayerId) || (this.hasPlayerId && !this.playerId_.Equals(player.playerId_)))
            {
                return false;
            }
            if ((this.hasGamesStartd != player.hasGamesStartd) || (this.hasGamesStartd && !this.gamesStartd_.Equals(player.gamesStartd_)))
            {
                return false;
            }
            if ((this.hasGamesCompleted != player.hasGamesCompleted) || (this.hasGamesCompleted && !this.gamesCompleted_.Equals(player.gamesCompleted_)))
            {
                return false;
            }
            if ((this.hasGamesWon != player.hasGamesWon) || (this.hasGamesWon && !this.gamesWon_.Equals(player.gamesWon_)))
            {
                return false;
            }
            if ((this.hasGamesLost != player.hasGamesLost) || (this.hasGamesLost && !this.gamesLost_.Equals(player.gamesLost_)))
            {
                return false;
            }
            if ((this.hasDeletedReason != player.hasDeletedReason) || (this.hasDeletedReason && !this.deletedReason_.Equals(player.deletedReason_)))
            {
                return false;
            }
            if ((this.hasDeckLimit != player.hasDeckLimit) || (this.hasDeckLimit && !this.deckLimit_.Equals(player.deckLimit_)))
            {
                return false;
            }
            if ((this.hasCampaignProgress != player.hasCampaignProgress) || (this.hasCampaignProgress && !this.campaignProgress_.Equals(player.campaignProgress_)))
            {
                return false;
            }
            if ((this.hasRandomDeckId != player.hasRandomDeckId) || (this.hasRandomDeckId && !this.randomDeckId_.Equals(player.randomDeckId_)))
            {
                return false;
            }
            if ((this.hasCredits != player.hasCredits) || (this.hasCredits && !this.credits_.Equals(player.credits_)))
            {
                return false;
            }
            if ((this.hasLastGameId != player.hasLastGameId) || (this.hasLastGameId && !this.lastGameId_.Equals(player.lastGameId_)))
            {
                return false;
            }
            if ((this.hasCraftAssetId != player.hasCraftAssetId) || (this.hasCraftAssetId && !this.craftAssetId_.Equals(player.craftAssetId_)))
            {
                return false;
            }
            if ((this.hasCraftPremium != player.hasCraftPremium) || (this.hasCraftPremium && !this.craftPremium_.Equals(player.craftPremium_)))
            {
                return false;
            }
            if ((this.hasCraftCount != player.hasCraftCount) || (this.hasCraftCount && !this.craftCount_.Equals(player.craftCount_)))
            {
                return false;
            }
            if ((this.hasBattlepayId != player.hasBattlepayId) || (this.hasBattlepayId && !this.battlepayId_.Equals(player.battlepayId_)))
            {
                return false;
            }
            if (this.boosterList_.Count != player.boosterList_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.boosterList_.Count; i++)
            {
                if (!this.boosterList_[i].Equals(player.boosterList_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public BoosterInfo GetBoosterList(int index)
        {
            return this.boosterList_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasPlayerId)
            {
                hashCode ^= this.playerId_.GetHashCode();
            }
            if (this.hasGamesStartd)
            {
                hashCode ^= this.gamesStartd_.GetHashCode();
            }
            if (this.hasGamesCompleted)
            {
                hashCode ^= this.gamesCompleted_.GetHashCode();
            }
            if (this.hasGamesWon)
            {
                hashCode ^= this.gamesWon_.GetHashCode();
            }
            if (this.hasGamesLost)
            {
                hashCode ^= this.gamesLost_.GetHashCode();
            }
            if (this.hasDeletedReason)
            {
                hashCode ^= this.deletedReason_.GetHashCode();
            }
            if (this.hasDeckLimit)
            {
                hashCode ^= this.deckLimit_.GetHashCode();
            }
            if (this.hasCampaignProgress)
            {
                hashCode ^= this.campaignProgress_.GetHashCode();
            }
            if (this.hasRandomDeckId)
            {
                hashCode ^= this.randomDeckId_.GetHashCode();
            }
            if (this.hasCredits)
            {
                hashCode ^= this.credits_.GetHashCode();
            }
            if (this.hasLastGameId)
            {
                hashCode ^= this.lastGameId_.GetHashCode();
            }
            if (this.hasCraftAssetId)
            {
                hashCode ^= this.craftAssetId_.GetHashCode();
            }
            if (this.hasCraftPremium)
            {
                hashCode ^= this.craftPremium_.GetHashCode();
            }
            if (this.hasCraftCount)
            {
                hashCode ^= this.craftCount_.GetHashCode();
            }
            if (this.hasBattlepayId)
            {
                hashCode ^= this.battlepayId_.GetHashCode();
            }
            IEnumerator<BoosterInfo> enumerator = this.boosterList_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    BoosterInfo current = enumerator.Current;
                    hashCode ^= current.GetHashCode();
                }
            }
            finally
            {
                if (enumerator == null)
                {
                }
                enumerator.Dispose();
            }
            return hashCode;
        }

        private AtlasPlayer MakeReadOnly()
        {
            this.boosterList_.MakeReadOnly();
            return this;
        }

        public static AtlasPlayer ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AtlasPlayer ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasPlayer ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasPlayer ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasPlayer ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasPlayer ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasPlayer ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AtlasPlayer ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasPlayer ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasPlayer ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AtlasPlayer, Builder>.PrintField("player_id", this.hasPlayerId, this.playerId_, writer);
            GeneratedMessageLite<AtlasPlayer, Builder>.PrintField("games_startd", this.hasGamesStartd, this.gamesStartd_, writer);
            GeneratedMessageLite<AtlasPlayer, Builder>.PrintField("games_completed", this.hasGamesCompleted, this.gamesCompleted_, writer);
            GeneratedMessageLite<AtlasPlayer, Builder>.PrintField("games_won", this.hasGamesWon, this.gamesWon_, writer);
            GeneratedMessageLite<AtlasPlayer, Builder>.PrintField("games_lost", this.hasGamesLost, this.gamesLost_, writer);
            GeneratedMessageLite<AtlasPlayer, Builder>.PrintField("deleted_reason", this.hasDeletedReason, this.deletedReason_, writer);
            GeneratedMessageLite<AtlasPlayer, Builder>.PrintField("deck_limit", this.hasDeckLimit, this.deckLimit_, writer);
            GeneratedMessageLite<AtlasPlayer, Builder>.PrintField("campaign_progress", this.hasCampaignProgress, this.campaignProgress_, writer);
            GeneratedMessageLite<AtlasPlayer, Builder>.PrintField("random_deck_id", this.hasRandomDeckId, this.randomDeckId_, writer);
            GeneratedMessageLite<AtlasPlayer, Builder>.PrintField("credits", this.hasCredits, this.credits_, writer);
            GeneratedMessageLite<AtlasPlayer, Builder>.PrintField("last_game_id", this.hasLastGameId, this.lastGameId_, writer);
            GeneratedMessageLite<AtlasPlayer, Builder>.PrintField("craft_asset_id", this.hasCraftAssetId, this.craftAssetId_, writer);
            GeneratedMessageLite<AtlasPlayer, Builder>.PrintField("craft_premium", this.hasCraftPremium, this.craftPremium_, writer);
            GeneratedMessageLite<AtlasPlayer, Builder>.PrintField("craft_count", this.hasCraftCount, this.craftCount_, writer);
            GeneratedMessageLite<AtlasPlayer, Builder>.PrintField("battlepay_id", this.hasBattlepayId, this.battlepayId_, writer);
            GeneratedMessageLite<AtlasPlayer, Builder>.PrintField<BoosterInfo>("booster_list", this.boosterList_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _atlasPlayerFieldNames;
            if (this.hasPlayerId)
            {
                output.WriteInt64(1, strArray[14], this.PlayerId);
            }
            if (this.hasGamesStartd)
            {
                output.WriteInt32(2, strArray[11], this.GamesStartd);
            }
            if (this.hasGamesCompleted)
            {
                output.WriteInt32(3, strArray[9], this.GamesCompleted);
            }
            if (this.hasGamesWon)
            {
                output.WriteInt32(4, strArray[12], this.GamesWon);
            }
            if (this.hasGamesLost)
            {
                output.WriteInt32(5, strArray[10], this.GamesLost);
            }
            if (this.hasDeletedReason)
            {
                output.WriteInt32(6, strArray[8], this.DeletedReason);
            }
            if (this.hasDeckLimit)
            {
                output.WriteInt32(7, strArray[7], this.DeckLimit);
            }
            if (this.hasCampaignProgress)
            {
                output.WriteInt64(8, strArray[2], this.CampaignProgress);
            }
            if (this.hasRandomDeckId)
            {
                output.WriteInt64(9, strArray[15], this.RandomDeckId);
            }
            if (this.hasCredits)
            {
                output.WriteInt64(10, strArray[6], this.Credits);
            }
            if (this.hasLastGameId)
            {
                output.WriteInt64(11, strArray[13], this.LastGameId);
            }
            if (this.hasCraftAssetId)
            {
                output.WriteInt32(12, strArray[3], this.CraftAssetId);
            }
            if (this.hasCraftPremium)
            {
                output.WriteInt32(13, strArray[5], this.CraftPremium);
            }
            if (this.hasCraftCount)
            {
                output.WriteInt32(14, strArray[4], this.CraftCount);
            }
            if (this.hasBattlepayId)
            {
                output.WriteInt64(15, strArray[0], this.BattlepayId);
            }
            if (this.boosterList_.Count > 0)
            {
                output.WriteMessageArray<BoosterInfo>(0x10, strArray[1], this.boosterList_);
            }
        }

        public long BattlepayId
        {
            get
            {
                return this.battlepayId_;
            }
        }

        public int BoosterListCount
        {
            get
            {
                return this.boosterList_.Count;
            }
        }

        public IList<BoosterInfo> BoosterListList
        {
            get
            {
                return this.boosterList_;
            }
        }

        public long CampaignProgress
        {
            get
            {
                return this.campaignProgress_;
            }
        }

        public int CraftAssetId
        {
            get
            {
                return this.craftAssetId_;
            }
        }

        public int CraftCount
        {
            get
            {
                return this.craftCount_;
            }
        }

        public int CraftPremium
        {
            get
            {
                return this.craftPremium_;
            }
        }

        public long Credits
        {
            get
            {
                return this.credits_;
            }
        }

        public int DeckLimit
        {
            get
            {
                return this.deckLimit_;
            }
        }

        public static AtlasPlayer DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AtlasPlayer DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public int DeletedReason
        {
            get
            {
                return this.deletedReason_;
            }
        }

        public int GamesCompleted
        {
            get
            {
                return this.gamesCompleted_;
            }
        }

        public int GamesLost
        {
            get
            {
                return this.gamesLost_;
            }
        }

        public int GamesStartd
        {
            get
            {
                return this.gamesStartd_;
            }
        }

        public int GamesWon
        {
            get
            {
                return this.gamesWon_;
            }
        }

        public bool HasBattlepayId
        {
            get
            {
                return this.hasBattlepayId;
            }
        }

        public bool HasCampaignProgress
        {
            get
            {
                return this.hasCampaignProgress;
            }
        }

        public bool HasCraftAssetId
        {
            get
            {
                return this.hasCraftAssetId;
            }
        }

        public bool HasCraftCount
        {
            get
            {
                return this.hasCraftCount;
            }
        }

        public bool HasCraftPremium
        {
            get
            {
                return this.hasCraftPremium;
            }
        }

        public bool HasCredits
        {
            get
            {
                return this.hasCredits;
            }
        }

        public bool HasDeckLimit
        {
            get
            {
                return this.hasDeckLimit;
            }
        }

        public bool HasDeletedReason
        {
            get
            {
                return this.hasDeletedReason;
            }
        }

        public bool HasGamesCompleted
        {
            get
            {
                return this.hasGamesCompleted;
            }
        }

        public bool HasGamesLost
        {
            get
            {
                return this.hasGamesLost;
            }
        }

        public bool HasGamesStartd
        {
            get
            {
                return this.hasGamesStartd;
            }
        }

        public bool HasGamesWon
        {
            get
            {
                return this.hasGamesWon;
            }
        }

        public bool HasLastGameId
        {
            get
            {
                return this.hasLastGameId;
            }
        }

        public bool HasPlayerId
        {
            get
            {
                return this.hasPlayerId;
            }
        }

        public bool HasRandomDeckId
        {
            get
            {
                return this.hasRandomDeckId;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasPlayerId)
                {
                    return false;
                }
                if (!this.hasGamesStartd)
                {
                    return false;
                }
                if (!this.hasGamesCompleted)
                {
                    return false;
                }
                if (!this.hasGamesWon)
                {
                    return false;
                }
                if (!this.hasGamesLost)
                {
                    return false;
                }
                if (!this.hasDeletedReason)
                {
                    return false;
                }
                if (!this.hasDeckLimit)
                {
                    return false;
                }
                if (!this.hasCampaignProgress)
                {
                    return false;
                }
                if (!this.hasRandomDeckId)
                {
                    return false;
                }
                if (!this.hasCredits)
                {
                    return false;
                }
                if (!this.hasLastGameId)
                {
                    return false;
                }
                if (!this.hasCraftAssetId)
                {
                    return false;
                }
                if (!this.hasCraftPremium)
                {
                    return false;
                }
                if (!this.hasCraftCount)
                {
                    return false;
                }
                if (!this.hasBattlepayId)
                {
                    return false;
                }
                IEnumerator<BoosterInfo> enumerator = this.BoosterListList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        BoosterInfo current = enumerator.Current;
                        if (!current.IsInitialized)
                        {
                            return false;
                        }
                    }
                }
                finally
                {
                    if (enumerator == null)
                    {
                    }
                    enumerator.Dispose();
                }
                return true;
            }
        }

        public long LastGameId
        {
            get
            {
                return this.lastGameId_;
            }
        }

        public long PlayerId
        {
            get
            {
                return this.playerId_;
            }
        }

        public long RandomDeckId
        {
            get
            {
                return this.randomDeckId_;
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
                    if (this.hasPlayerId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(1, this.PlayerId);
                    }
                    if (this.hasGamesStartd)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.GamesStartd);
                    }
                    if (this.hasGamesCompleted)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(3, this.GamesCompleted);
                    }
                    if (this.hasGamesWon)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(4, this.GamesWon);
                    }
                    if (this.hasGamesLost)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(5, this.GamesLost);
                    }
                    if (this.hasDeletedReason)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(6, this.DeletedReason);
                    }
                    if (this.hasDeckLimit)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(7, this.DeckLimit);
                    }
                    if (this.hasCampaignProgress)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(8, this.CampaignProgress);
                    }
                    if (this.hasRandomDeckId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(9, this.RandomDeckId);
                    }
                    if (this.hasCredits)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(10, this.Credits);
                    }
                    if (this.hasLastGameId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(11, this.LastGameId);
                    }
                    if (this.hasCraftAssetId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(12, this.CraftAssetId);
                    }
                    if (this.hasCraftPremium)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(13, this.CraftPremium);
                    }
                    if (this.hasCraftCount)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(14, this.CraftCount);
                    }
                    if (this.hasBattlepayId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(15, this.BattlepayId);
                    }
                    IEnumerator<BoosterInfo> enumerator = this.BoosterListList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            BoosterInfo current = enumerator.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(0x10, current);
                        }
                    }
                    finally
                    {
                        if (enumerator == null)
                        {
                        }
                        enumerator.Dispose();
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override AtlasPlayer ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<AtlasPlayer, AtlasPlayer.Builder>
        {
            private AtlasPlayer result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AtlasPlayer.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AtlasPlayer cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public AtlasPlayer.Builder AddBoosterList(BoosterInfo value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.boosterList_.Add(value);
                return this;
            }

            public AtlasPlayer.Builder AddBoosterList(BoosterInfo.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.boosterList_.Add(builderForValue.Build());
                return this;
            }

            public AtlasPlayer.Builder AddRangeBoosterList(IEnumerable<BoosterInfo> values)
            {
                this.PrepareBuilder();
                this.result.boosterList_.Add(values);
                return this;
            }

            public override AtlasPlayer BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AtlasPlayer.Builder Clear()
            {
                this.result = AtlasPlayer.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AtlasPlayer.Builder ClearBattlepayId()
            {
                this.PrepareBuilder();
                this.result.hasBattlepayId = false;
                this.result.battlepayId_ = 0L;
                return this;
            }

            public AtlasPlayer.Builder ClearBoosterList()
            {
                this.PrepareBuilder();
                this.result.boosterList_.Clear();
                return this;
            }

            public AtlasPlayer.Builder ClearCampaignProgress()
            {
                this.PrepareBuilder();
                this.result.hasCampaignProgress = false;
                this.result.campaignProgress_ = 0L;
                return this;
            }

            public AtlasPlayer.Builder ClearCraftAssetId()
            {
                this.PrepareBuilder();
                this.result.hasCraftAssetId = false;
                this.result.craftAssetId_ = 0;
                return this;
            }

            public AtlasPlayer.Builder ClearCraftCount()
            {
                this.PrepareBuilder();
                this.result.hasCraftCount = false;
                this.result.craftCount_ = 0;
                return this;
            }

            public AtlasPlayer.Builder ClearCraftPremium()
            {
                this.PrepareBuilder();
                this.result.hasCraftPremium = false;
                this.result.craftPremium_ = 0;
                return this;
            }

            public AtlasPlayer.Builder ClearCredits()
            {
                this.PrepareBuilder();
                this.result.hasCredits = false;
                this.result.credits_ = 0L;
                return this;
            }

            public AtlasPlayer.Builder ClearDeckLimit()
            {
                this.PrepareBuilder();
                this.result.hasDeckLimit = false;
                this.result.deckLimit_ = 0;
                return this;
            }

            public AtlasPlayer.Builder ClearDeletedReason()
            {
                this.PrepareBuilder();
                this.result.hasDeletedReason = false;
                this.result.deletedReason_ = 0;
                return this;
            }

            public AtlasPlayer.Builder ClearGamesCompleted()
            {
                this.PrepareBuilder();
                this.result.hasGamesCompleted = false;
                this.result.gamesCompleted_ = 0;
                return this;
            }

            public AtlasPlayer.Builder ClearGamesLost()
            {
                this.PrepareBuilder();
                this.result.hasGamesLost = false;
                this.result.gamesLost_ = 0;
                return this;
            }

            public AtlasPlayer.Builder ClearGamesStartd()
            {
                this.PrepareBuilder();
                this.result.hasGamesStartd = false;
                this.result.gamesStartd_ = 0;
                return this;
            }

            public AtlasPlayer.Builder ClearGamesWon()
            {
                this.PrepareBuilder();
                this.result.hasGamesWon = false;
                this.result.gamesWon_ = 0;
                return this;
            }

            public AtlasPlayer.Builder ClearLastGameId()
            {
                this.PrepareBuilder();
                this.result.hasLastGameId = false;
                this.result.lastGameId_ = 0L;
                return this;
            }

            public AtlasPlayer.Builder ClearPlayerId()
            {
                this.PrepareBuilder();
                this.result.hasPlayerId = false;
                this.result.playerId_ = 0L;
                return this;
            }

            public AtlasPlayer.Builder ClearRandomDeckId()
            {
                this.PrepareBuilder();
                this.result.hasRandomDeckId = false;
                this.result.randomDeckId_ = 0L;
                return this;
            }

            public override AtlasPlayer.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AtlasPlayer.Builder(this.result);
                }
                return new AtlasPlayer.Builder().MergeFrom(this.result);
            }

            public BoosterInfo GetBoosterList(int index)
            {
                return this.result.GetBoosterList(index);
            }

            public override AtlasPlayer.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AtlasPlayer.Builder MergeFrom(IMessageLite other)
            {
                if (other is AtlasPlayer)
                {
                    return this.MergeFrom((AtlasPlayer) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AtlasPlayer.Builder MergeFrom(AtlasPlayer other)
            {
                if (other != AtlasPlayer.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasPlayerId)
                    {
                        this.PlayerId = other.PlayerId;
                    }
                    if (other.HasGamesStartd)
                    {
                        this.GamesStartd = other.GamesStartd;
                    }
                    if (other.HasGamesCompleted)
                    {
                        this.GamesCompleted = other.GamesCompleted;
                    }
                    if (other.HasGamesWon)
                    {
                        this.GamesWon = other.GamesWon;
                    }
                    if (other.HasGamesLost)
                    {
                        this.GamesLost = other.GamesLost;
                    }
                    if (other.HasDeletedReason)
                    {
                        this.DeletedReason = other.DeletedReason;
                    }
                    if (other.HasDeckLimit)
                    {
                        this.DeckLimit = other.DeckLimit;
                    }
                    if (other.HasCampaignProgress)
                    {
                        this.CampaignProgress = other.CampaignProgress;
                    }
                    if (other.HasRandomDeckId)
                    {
                        this.RandomDeckId = other.RandomDeckId;
                    }
                    if (other.HasCredits)
                    {
                        this.Credits = other.Credits;
                    }
                    if (other.HasLastGameId)
                    {
                        this.LastGameId = other.LastGameId;
                    }
                    if (other.HasCraftAssetId)
                    {
                        this.CraftAssetId = other.CraftAssetId;
                    }
                    if (other.HasCraftPremium)
                    {
                        this.CraftPremium = other.CraftPremium;
                    }
                    if (other.HasCraftCount)
                    {
                        this.CraftCount = other.CraftCount;
                    }
                    if (other.HasBattlepayId)
                    {
                        this.BattlepayId = other.BattlepayId;
                    }
                    if (other.boosterList_.Count != 0)
                    {
                        this.result.boosterList_.Add(other.boosterList_);
                    }
                }
                return this;
            }

            public override AtlasPlayer.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AtlasPlayer._atlasPlayerFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AtlasPlayer._atlasPlayerFieldTags[index];
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
                            this.result.hasPlayerId = input.ReadInt64(ref this.result.playerId_);
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasGamesStartd = input.ReadInt32(ref this.result.gamesStartd_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasGamesCompleted = input.ReadInt32(ref this.result.gamesCompleted_);
                            continue;
                        }
                        case 0x20:
                        {
                            this.result.hasGamesWon = input.ReadInt32(ref this.result.gamesWon_);
                            continue;
                        }
                        case 40:
                        {
                            this.result.hasGamesLost = input.ReadInt32(ref this.result.gamesLost_);
                            continue;
                        }
                        case 0x30:
                        {
                            this.result.hasDeletedReason = input.ReadInt32(ref this.result.deletedReason_);
                            continue;
                        }
                        case 0x38:
                        {
                            this.result.hasDeckLimit = input.ReadInt32(ref this.result.deckLimit_);
                            continue;
                        }
                        case 0x40:
                        {
                            this.result.hasCampaignProgress = input.ReadInt64(ref this.result.campaignProgress_);
                            continue;
                        }
                        case 0x48:
                        {
                            this.result.hasRandomDeckId = input.ReadInt64(ref this.result.randomDeckId_);
                            continue;
                        }
                        case 80:
                        {
                            this.result.hasCredits = input.ReadInt64(ref this.result.credits_);
                            continue;
                        }
                        case 0x58:
                        {
                            this.result.hasLastGameId = input.ReadInt64(ref this.result.lastGameId_);
                            continue;
                        }
                        case 0x60:
                        {
                            this.result.hasCraftAssetId = input.ReadInt32(ref this.result.craftAssetId_);
                            continue;
                        }
                        case 0x68:
                        {
                            this.result.hasCraftPremium = input.ReadInt32(ref this.result.craftPremium_);
                            continue;
                        }
                        case 0x70:
                        {
                            this.result.hasCraftCount = input.ReadInt32(ref this.result.craftCount_);
                            continue;
                        }
                        case 120:
                        {
                            this.result.hasBattlepayId = input.ReadInt64(ref this.result.battlepayId_);
                            continue;
                        }
                        case 130:
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
                    input.ReadMessageArray<BoosterInfo>(num, str, this.result.boosterList_, BoosterInfo.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private AtlasPlayer PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AtlasPlayer result = this.result;
                    this.result = new AtlasPlayer();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public AtlasPlayer.Builder SetBattlepayId(long value)
            {
                this.PrepareBuilder();
                this.result.hasBattlepayId = true;
                this.result.battlepayId_ = value;
                return this;
            }

            public AtlasPlayer.Builder SetBoosterList(int index, BoosterInfo value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.boosterList_[index] = value;
                return this;
            }

            public AtlasPlayer.Builder SetBoosterList(int index, BoosterInfo.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.boosterList_[index] = builderForValue.Build();
                return this;
            }

            public AtlasPlayer.Builder SetCampaignProgress(long value)
            {
                this.PrepareBuilder();
                this.result.hasCampaignProgress = true;
                this.result.campaignProgress_ = value;
                return this;
            }

            public AtlasPlayer.Builder SetCraftAssetId(int value)
            {
                this.PrepareBuilder();
                this.result.hasCraftAssetId = true;
                this.result.craftAssetId_ = value;
                return this;
            }

            public AtlasPlayer.Builder SetCraftCount(int value)
            {
                this.PrepareBuilder();
                this.result.hasCraftCount = true;
                this.result.craftCount_ = value;
                return this;
            }

            public AtlasPlayer.Builder SetCraftPremium(int value)
            {
                this.PrepareBuilder();
                this.result.hasCraftPremium = true;
                this.result.craftPremium_ = value;
                return this;
            }

            public AtlasPlayer.Builder SetCredits(long value)
            {
                this.PrepareBuilder();
                this.result.hasCredits = true;
                this.result.credits_ = value;
                return this;
            }

            public AtlasPlayer.Builder SetDeckLimit(int value)
            {
                this.PrepareBuilder();
                this.result.hasDeckLimit = true;
                this.result.deckLimit_ = value;
                return this;
            }

            public AtlasPlayer.Builder SetDeletedReason(int value)
            {
                this.PrepareBuilder();
                this.result.hasDeletedReason = true;
                this.result.deletedReason_ = value;
                return this;
            }

            public AtlasPlayer.Builder SetGamesCompleted(int value)
            {
                this.PrepareBuilder();
                this.result.hasGamesCompleted = true;
                this.result.gamesCompleted_ = value;
                return this;
            }

            public AtlasPlayer.Builder SetGamesLost(int value)
            {
                this.PrepareBuilder();
                this.result.hasGamesLost = true;
                this.result.gamesLost_ = value;
                return this;
            }

            public AtlasPlayer.Builder SetGamesStartd(int value)
            {
                this.PrepareBuilder();
                this.result.hasGamesStartd = true;
                this.result.gamesStartd_ = value;
                return this;
            }

            public AtlasPlayer.Builder SetGamesWon(int value)
            {
                this.PrepareBuilder();
                this.result.hasGamesWon = true;
                this.result.gamesWon_ = value;
                return this;
            }

            public AtlasPlayer.Builder SetLastGameId(long value)
            {
                this.PrepareBuilder();
                this.result.hasLastGameId = true;
                this.result.lastGameId_ = value;
                return this;
            }

            public AtlasPlayer.Builder SetPlayerId(long value)
            {
                this.PrepareBuilder();
                this.result.hasPlayerId = true;
                this.result.playerId_ = value;
                return this;
            }

            public AtlasPlayer.Builder SetRandomDeckId(long value)
            {
                this.PrepareBuilder();
                this.result.hasRandomDeckId = true;
                this.result.randomDeckId_ = value;
                return this;
            }

            public long BattlepayId
            {
                get
                {
                    return this.result.BattlepayId;
                }
                set
                {
                    this.SetBattlepayId(value);
                }
            }

            public int BoosterListCount
            {
                get
                {
                    return this.result.BoosterListCount;
                }
            }

            public IPopsicleList<BoosterInfo> BoosterListList
            {
                get
                {
                    return this.PrepareBuilder().boosterList_;
                }
            }

            public long CampaignProgress
            {
                get
                {
                    return this.result.CampaignProgress;
                }
                set
                {
                    this.SetCampaignProgress(value);
                }
            }

            public int CraftAssetId
            {
                get
                {
                    return this.result.CraftAssetId;
                }
                set
                {
                    this.SetCraftAssetId(value);
                }
            }

            public int CraftCount
            {
                get
                {
                    return this.result.CraftCount;
                }
                set
                {
                    this.SetCraftCount(value);
                }
            }

            public int CraftPremium
            {
                get
                {
                    return this.result.CraftPremium;
                }
                set
                {
                    this.SetCraftPremium(value);
                }
            }

            public long Credits
            {
                get
                {
                    return this.result.Credits;
                }
                set
                {
                    this.SetCredits(value);
                }
            }

            public int DeckLimit
            {
                get
                {
                    return this.result.DeckLimit;
                }
                set
                {
                    this.SetDeckLimit(value);
                }
            }

            public override AtlasPlayer DefaultInstanceForType
            {
                get
                {
                    return AtlasPlayer.DefaultInstance;
                }
            }

            public int DeletedReason
            {
                get
                {
                    return this.result.DeletedReason;
                }
                set
                {
                    this.SetDeletedReason(value);
                }
            }

            public int GamesCompleted
            {
                get
                {
                    return this.result.GamesCompleted;
                }
                set
                {
                    this.SetGamesCompleted(value);
                }
            }

            public int GamesLost
            {
                get
                {
                    return this.result.GamesLost;
                }
                set
                {
                    this.SetGamesLost(value);
                }
            }

            public int GamesStartd
            {
                get
                {
                    return this.result.GamesStartd;
                }
                set
                {
                    this.SetGamesStartd(value);
                }
            }

            public int GamesWon
            {
                get
                {
                    return this.result.GamesWon;
                }
                set
                {
                    this.SetGamesWon(value);
                }
            }

            public bool HasBattlepayId
            {
                get
                {
                    return this.result.hasBattlepayId;
                }
            }

            public bool HasCampaignProgress
            {
                get
                {
                    return this.result.hasCampaignProgress;
                }
            }

            public bool HasCraftAssetId
            {
                get
                {
                    return this.result.hasCraftAssetId;
                }
            }

            public bool HasCraftCount
            {
                get
                {
                    return this.result.hasCraftCount;
                }
            }

            public bool HasCraftPremium
            {
                get
                {
                    return this.result.hasCraftPremium;
                }
            }

            public bool HasCredits
            {
                get
                {
                    return this.result.hasCredits;
                }
            }

            public bool HasDeckLimit
            {
                get
                {
                    return this.result.hasDeckLimit;
                }
            }

            public bool HasDeletedReason
            {
                get
                {
                    return this.result.hasDeletedReason;
                }
            }

            public bool HasGamesCompleted
            {
                get
                {
                    return this.result.hasGamesCompleted;
                }
            }

            public bool HasGamesLost
            {
                get
                {
                    return this.result.hasGamesLost;
                }
            }

            public bool HasGamesStartd
            {
                get
                {
                    return this.result.hasGamesStartd;
                }
            }

            public bool HasGamesWon
            {
                get
                {
                    return this.result.hasGamesWon;
                }
            }

            public bool HasLastGameId
            {
                get
                {
                    return this.result.hasLastGameId;
                }
            }

            public bool HasPlayerId
            {
                get
                {
                    return this.result.hasPlayerId;
                }
            }

            public bool HasRandomDeckId
            {
                get
                {
                    return this.result.hasRandomDeckId;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public long LastGameId
            {
                get
                {
                    return this.result.LastGameId;
                }
                set
                {
                    this.SetLastGameId(value);
                }
            }

            protected override AtlasPlayer MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public long PlayerId
            {
                get
                {
                    return this.result.PlayerId;
                }
                set
                {
                    this.SetPlayerId(value);
                }
            }

            public long RandomDeckId
            {
                get
                {
                    return this.result.RandomDeckId;
                }
                set
                {
                    this.SetRandomDeckId(value);
                }
            }

            protected override AtlasPlayer.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 100
            }
        }
    }
}

