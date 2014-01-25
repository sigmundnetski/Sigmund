namespace bnet.protocol.game_master
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class GameStatsBucket : GeneratedMessageLite<GameStatsBucket, Builder>
    {
        private static readonly string[] _gameStatsBucketFieldNames = new string[] { "active_games", "active_players", "bucket_max", "bucket_min", "forming_games", "games_per_hour", "wait_milliseconds", "waiting_players" };
        private static readonly uint[] _gameStatsBucketFieldTags = new uint[] { 40, 0x30, 0x15, 13, 0x38, 0x20, 0x18, 0x40 };
        private uint activeGames_;
        public const int ActiveGamesFieldNumber = 5;
        private uint activePlayers_;
        public const int ActivePlayersFieldNumber = 6;
        private float bucketMax_ = 4.294967E+09f;
        public const int BucketMaxFieldNumber = 2;
        private float bucketMin_;
        public const int BucketMinFieldNumber = 1;
        private static readonly GameStatsBucket defaultInstance = new GameStatsBucket().MakeReadOnly();
        private uint formingGames_;
        public const int FormingGamesFieldNumber = 7;
        private uint gamesPerHour_;
        public const int GamesPerHourFieldNumber = 4;
        private bool hasActiveGames;
        private bool hasActivePlayers;
        private bool hasBucketMax;
        private bool hasBucketMin;
        private bool hasFormingGames;
        private bool hasGamesPerHour;
        private bool hasWaitingPlayers;
        private bool hasWaitMilliseconds;
        private int memoizedSerializedSize = -1;
        private uint waitingPlayers_;
        public const int WaitingPlayersFieldNumber = 8;
        private uint waitMilliseconds_;
        public const int WaitMillisecondsFieldNumber = 3;

        static GameStatsBucket()
        {
            object.ReferenceEquals(GameMaster.Descriptor, null);
        }

        private GameStatsBucket()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GameStatsBucket prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GameStatsBucket bucket = obj as GameStatsBucket;
            if (bucket == null)
            {
                return false;
            }
            if ((this.hasBucketMin != bucket.hasBucketMin) || (this.hasBucketMin && !this.bucketMin_.Equals(bucket.bucketMin_)))
            {
                return false;
            }
            if ((this.hasBucketMax != bucket.hasBucketMax) || (this.hasBucketMax && !this.bucketMax_.Equals(bucket.bucketMax_)))
            {
                return false;
            }
            if ((this.hasWaitMilliseconds != bucket.hasWaitMilliseconds) || (this.hasWaitMilliseconds && !this.waitMilliseconds_.Equals(bucket.waitMilliseconds_)))
            {
                return false;
            }
            if ((this.hasGamesPerHour != bucket.hasGamesPerHour) || (this.hasGamesPerHour && !this.gamesPerHour_.Equals(bucket.gamesPerHour_)))
            {
                return false;
            }
            if ((this.hasActiveGames != bucket.hasActiveGames) || (this.hasActiveGames && !this.activeGames_.Equals(bucket.activeGames_)))
            {
                return false;
            }
            if ((this.hasActivePlayers != bucket.hasActivePlayers) || (this.hasActivePlayers && !this.activePlayers_.Equals(bucket.activePlayers_)))
            {
                return false;
            }
            if ((this.hasFormingGames != bucket.hasFormingGames) || (this.hasFormingGames && !this.formingGames_.Equals(bucket.formingGames_)))
            {
                return false;
            }
            return ((this.hasWaitingPlayers == bucket.hasWaitingPlayers) && (!this.hasWaitingPlayers || this.waitingPlayers_.Equals(bucket.waitingPlayers_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasBucketMin)
            {
                hashCode ^= this.bucketMin_.GetHashCode();
            }
            if (this.hasBucketMax)
            {
                hashCode ^= this.bucketMax_.GetHashCode();
            }
            if (this.hasWaitMilliseconds)
            {
                hashCode ^= this.waitMilliseconds_.GetHashCode();
            }
            if (this.hasGamesPerHour)
            {
                hashCode ^= this.gamesPerHour_.GetHashCode();
            }
            if (this.hasActiveGames)
            {
                hashCode ^= this.activeGames_.GetHashCode();
            }
            if (this.hasActivePlayers)
            {
                hashCode ^= this.activePlayers_.GetHashCode();
            }
            if (this.hasFormingGames)
            {
                hashCode ^= this.formingGames_.GetHashCode();
            }
            if (this.hasWaitingPlayers)
            {
                hashCode ^= this.waitingPlayers_.GetHashCode();
            }
            return hashCode;
        }

        private GameStatsBucket MakeReadOnly()
        {
            return this;
        }

        public static GameStatsBucket ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GameStatsBucket ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameStatsBucket ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GameStatsBucket ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GameStatsBucket ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GameStatsBucket ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GameStatsBucket ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GameStatsBucket ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameStatsBucket ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameStatsBucket ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GameStatsBucket, Builder>.PrintField("bucket_min", this.hasBucketMin, this.bucketMin_, writer);
            GeneratedMessageLite<GameStatsBucket, Builder>.PrintField("bucket_max", this.hasBucketMax, this.bucketMax_, writer);
            GeneratedMessageLite<GameStatsBucket, Builder>.PrintField("wait_milliseconds", this.hasWaitMilliseconds, this.waitMilliseconds_, writer);
            GeneratedMessageLite<GameStatsBucket, Builder>.PrintField("games_per_hour", this.hasGamesPerHour, this.gamesPerHour_, writer);
            GeneratedMessageLite<GameStatsBucket, Builder>.PrintField("active_games", this.hasActiveGames, this.activeGames_, writer);
            GeneratedMessageLite<GameStatsBucket, Builder>.PrintField("active_players", this.hasActivePlayers, this.activePlayers_, writer);
            GeneratedMessageLite<GameStatsBucket, Builder>.PrintField("forming_games", this.hasFormingGames, this.formingGames_, writer);
            GeneratedMessageLite<GameStatsBucket, Builder>.PrintField("waiting_players", this.hasWaitingPlayers, this.waitingPlayers_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _gameStatsBucketFieldNames;
            if (this.hasBucketMin)
            {
                output.WriteFloat(1, strArray[3], this.BucketMin);
            }
            if (this.hasBucketMax)
            {
                output.WriteFloat(2, strArray[2], this.BucketMax);
            }
            if (this.hasWaitMilliseconds)
            {
                output.WriteUInt32(3, strArray[6], this.WaitMilliseconds);
            }
            if (this.hasGamesPerHour)
            {
                output.WriteUInt32(4, strArray[5], this.GamesPerHour);
            }
            if (this.hasActiveGames)
            {
                output.WriteUInt32(5, strArray[0], this.ActiveGames);
            }
            if (this.hasActivePlayers)
            {
                output.WriteUInt32(6, strArray[1], this.ActivePlayers);
            }
            if (this.hasFormingGames)
            {
                output.WriteUInt32(7, strArray[4], this.FormingGames);
            }
            if (this.hasWaitingPlayers)
            {
                output.WriteUInt32(8, strArray[7], this.WaitingPlayers);
            }
        }

        [CLSCompliant(false)]
        public uint ActiveGames
        {
            get
            {
                return this.activeGames_;
            }
        }

        [CLSCompliant(false)]
        public uint ActivePlayers
        {
            get
            {
                return this.activePlayers_;
            }
        }

        public float BucketMax
        {
            get
            {
                return this.bucketMax_;
            }
        }

        public float BucketMin
        {
            get
            {
                return this.bucketMin_;
            }
        }

        public static GameStatsBucket DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GameStatsBucket DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        [CLSCompliant(false)]
        public uint FormingGames
        {
            get
            {
                return this.formingGames_;
            }
        }

        [CLSCompliant(false)]
        public uint GamesPerHour
        {
            get
            {
                return this.gamesPerHour_;
            }
        }

        public bool HasActiveGames
        {
            get
            {
                return this.hasActiveGames;
            }
        }

        public bool HasActivePlayers
        {
            get
            {
                return this.hasActivePlayers;
            }
        }

        public bool HasBucketMax
        {
            get
            {
                return this.hasBucketMax;
            }
        }

        public bool HasBucketMin
        {
            get
            {
                return this.hasBucketMin;
            }
        }

        public bool HasFormingGames
        {
            get
            {
                return this.hasFormingGames;
            }
        }

        public bool HasGamesPerHour
        {
            get
            {
                return this.hasGamesPerHour;
            }
        }

        public bool HasWaitingPlayers
        {
            get
            {
                return this.hasWaitingPlayers;
            }
        }

        public bool HasWaitMilliseconds
        {
            get
            {
                return this.hasWaitMilliseconds;
            }
        }

        public override bool IsInitialized
        {
            get
            {
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
                    if (this.hasBucketMin)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFloatSize(1, this.BucketMin);
                    }
                    if (this.hasBucketMax)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFloatSize(2, this.BucketMax);
                    }
                    if (this.hasWaitMilliseconds)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(3, this.WaitMilliseconds);
                    }
                    if (this.hasGamesPerHour)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(4, this.GamesPerHour);
                    }
                    if (this.hasActiveGames)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(5, this.ActiveGames);
                    }
                    if (this.hasActivePlayers)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(6, this.ActivePlayers);
                    }
                    if (this.hasFormingGames)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(7, this.FormingGames);
                    }
                    if (this.hasWaitingPlayers)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(8, this.WaitingPlayers);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override GameStatsBucket ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CLSCompliant(false)]
        public uint WaitingPlayers
        {
            get
            {
                return this.waitingPlayers_;
            }
        }

        [CLSCompliant(false)]
        public uint WaitMilliseconds
        {
            get
            {
                return this.waitMilliseconds_;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<GameStatsBucket, GameStatsBucket.Builder>
        {
            private GameStatsBucket result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GameStatsBucket.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GameStatsBucket cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override GameStatsBucket BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GameStatsBucket.Builder Clear()
            {
                this.result = GameStatsBucket.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GameStatsBucket.Builder ClearActiveGames()
            {
                this.PrepareBuilder();
                this.result.hasActiveGames = false;
                this.result.activeGames_ = 0;
                return this;
            }

            public GameStatsBucket.Builder ClearActivePlayers()
            {
                this.PrepareBuilder();
                this.result.hasActivePlayers = false;
                this.result.activePlayers_ = 0;
                return this;
            }

            public GameStatsBucket.Builder ClearBucketMax()
            {
                this.PrepareBuilder();
                this.result.hasBucketMax = false;
                this.result.bucketMax_ = 4.294967E+09f;
                return this;
            }

            public GameStatsBucket.Builder ClearBucketMin()
            {
                this.PrepareBuilder();
                this.result.hasBucketMin = false;
                this.result.bucketMin_ = 0f;
                return this;
            }

            public GameStatsBucket.Builder ClearFormingGames()
            {
                this.PrepareBuilder();
                this.result.hasFormingGames = false;
                this.result.formingGames_ = 0;
                return this;
            }

            public GameStatsBucket.Builder ClearGamesPerHour()
            {
                this.PrepareBuilder();
                this.result.hasGamesPerHour = false;
                this.result.gamesPerHour_ = 0;
                return this;
            }

            public GameStatsBucket.Builder ClearWaitingPlayers()
            {
                this.PrepareBuilder();
                this.result.hasWaitingPlayers = false;
                this.result.waitingPlayers_ = 0;
                return this;
            }

            public GameStatsBucket.Builder ClearWaitMilliseconds()
            {
                this.PrepareBuilder();
                this.result.hasWaitMilliseconds = false;
                this.result.waitMilliseconds_ = 0;
                return this;
            }

            public override GameStatsBucket.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GameStatsBucket.Builder(this.result);
                }
                return new GameStatsBucket.Builder().MergeFrom(this.result);
            }

            public override GameStatsBucket.Builder MergeFrom(GameStatsBucket other)
            {
                if (other != GameStatsBucket.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasBucketMin)
                    {
                        this.BucketMin = other.BucketMin;
                    }
                    if (other.HasBucketMax)
                    {
                        this.BucketMax = other.BucketMax;
                    }
                    if (other.HasWaitMilliseconds)
                    {
                        this.WaitMilliseconds = other.WaitMilliseconds;
                    }
                    if (other.HasGamesPerHour)
                    {
                        this.GamesPerHour = other.GamesPerHour;
                    }
                    if (other.HasActiveGames)
                    {
                        this.ActiveGames = other.ActiveGames;
                    }
                    if (other.HasActivePlayers)
                    {
                        this.ActivePlayers = other.ActivePlayers;
                    }
                    if (other.HasFormingGames)
                    {
                        this.FormingGames = other.FormingGames;
                    }
                    if (other.HasWaitingPlayers)
                    {
                        this.WaitingPlayers = other.WaitingPlayers;
                    }
                }
                return this;
            }

            public override GameStatsBucket.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GameStatsBucket.Builder MergeFrom(IMessageLite other)
            {
                if (other is GameStatsBucket)
                {
                    return this.MergeFrom((GameStatsBucket) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GameStatsBucket.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GameStatsBucket._gameStatsBucketFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GameStatsBucket._gameStatsBucketFieldTags[index];
                        }
                        else
                        {
                            this.ParseUnknownField(input, extensionRegistry, num, str);
                            continue;
                        }
                    }
                    switch (num)
                    {
                        case 0x15:
                        {
                            this.result.hasBucketMax = input.ReadFloat(ref this.result.bucketMax_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasWaitMilliseconds = input.ReadUInt32(ref this.result.waitMilliseconds_);
                            continue;
                        }
                        case 0:
                            throw InvalidProtocolBufferException.InvalidTag();

                        case 13:
                            goto Label_00C7;

                        case 0x20:
                            goto Label_012A;

                        case 40:
                            goto Label_014B;

                        case 0x30:
                            goto Label_016C;

                        case 0x38:
                            goto Label_018D;

                        case 0x40:
                            goto Label_01AE;

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
                Label_00C7:
                    this.result.hasBucketMin = input.ReadFloat(ref this.result.bucketMin_);
                    continue;
                Label_012A:
                    this.result.hasGamesPerHour = input.ReadUInt32(ref this.result.gamesPerHour_);
                    continue;
                Label_014B:
                    this.result.hasActiveGames = input.ReadUInt32(ref this.result.activeGames_);
                    continue;
                Label_016C:
                    this.result.hasActivePlayers = input.ReadUInt32(ref this.result.activePlayers_);
                    continue;
                Label_018D:
                    this.result.hasFormingGames = input.ReadUInt32(ref this.result.formingGames_);
                    continue;
                Label_01AE:
                    this.result.hasWaitingPlayers = input.ReadUInt32(ref this.result.waitingPlayers_);
                }
                return this;
            }

            private GameStatsBucket PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GameStatsBucket result = this.result;
                    this.result = new GameStatsBucket();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public GameStatsBucket.Builder SetActiveGames(uint value)
            {
                this.PrepareBuilder();
                this.result.hasActiveGames = true;
                this.result.activeGames_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public GameStatsBucket.Builder SetActivePlayers(uint value)
            {
                this.PrepareBuilder();
                this.result.hasActivePlayers = true;
                this.result.activePlayers_ = value;
                return this;
            }

            public GameStatsBucket.Builder SetBucketMax(float value)
            {
                this.PrepareBuilder();
                this.result.hasBucketMax = true;
                this.result.bucketMax_ = value;
                return this;
            }

            public GameStatsBucket.Builder SetBucketMin(float value)
            {
                this.PrepareBuilder();
                this.result.hasBucketMin = true;
                this.result.bucketMin_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public GameStatsBucket.Builder SetFormingGames(uint value)
            {
                this.PrepareBuilder();
                this.result.hasFormingGames = true;
                this.result.formingGames_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public GameStatsBucket.Builder SetGamesPerHour(uint value)
            {
                this.PrepareBuilder();
                this.result.hasGamesPerHour = true;
                this.result.gamesPerHour_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public GameStatsBucket.Builder SetWaitingPlayers(uint value)
            {
                this.PrepareBuilder();
                this.result.hasWaitingPlayers = true;
                this.result.waitingPlayers_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public GameStatsBucket.Builder SetWaitMilliseconds(uint value)
            {
                this.PrepareBuilder();
                this.result.hasWaitMilliseconds = true;
                this.result.waitMilliseconds_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public uint ActiveGames
            {
                get
                {
                    return this.result.ActiveGames;
                }
                set
                {
                    this.SetActiveGames(value);
                }
            }

            [CLSCompliant(false)]
            public uint ActivePlayers
            {
                get
                {
                    return this.result.ActivePlayers;
                }
                set
                {
                    this.SetActivePlayers(value);
                }
            }

            public float BucketMax
            {
                get
                {
                    return this.result.BucketMax;
                }
                set
                {
                    this.SetBucketMax(value);
                }
            }

            public float BucketMin
            {
                get
                {
                    return this.result.BucketMin;
                }
                set
                {
                    this.SetBucketMin(value);
                }
            }

            public override GameStatsBucket DefaultInstanceForType
            {
                get
                {
                    return GameStatsBucket.DefaultInstance;
                }
            }

            [CLSCompliant(false)]
            public uint FormingGames
            {
                get
                {
                    return this.result.FormingGames;
                }
                set
                {
                    this.SetFormingGames(value);
                }
            }

            [CLSCompliant(false)]
            public uint GamesPerHour
            {
                get
                {
                    return this.result.GamesPerHour;
                }
                set
                {
                    this.SetGamesPerHour(value);
                }
            }

            public bool HasActiveGames
            {
                get
                {
                    return this.result.hasActiveGames;
                }
            }

            public bool HasActivePlayers
            {
                get
                {
                    return this.result.hasActivePlayers;
                }
            }

            public bool HasBucketMax
            {
                get
                {
                    return this.result.hasBucketMax;
                }
            }

            public bool HasBucketMin
            {
                get
                {
                    return this.result.hasBucketMin;
                }
            }

            public bool HasFormingGames
            {
                get
                {
                    return this.result.hasFormingGames;
                }
            }

            public bool HasGamesPerHour
            {
                get
                {
                    return this.result.hasGamesPerHour;
                }
            }

            public bool HasWaitingPlayers
            {
                get
                {
                    return this.result.hasWaitingPlayers;
                }
            }

            public bool HasWaitMilliseconds
            {
                get
                {
                    return this.result.hasWaitMilliseconds;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override GameStatsBucket MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override GameStatsBucket.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            [CLSCompliant(false)]
            public uint WaitingPlayers
            {
                get
                {
                    return this.result.WaitingPlayers;
                }
                set
                {
                    this.SetWaitingPlayers(value);
                }
            }

            [CLSCompliant(false)]
            public uint WaitMilliseconds
            {
                get
                {
                    return this.result.WaitMilliseconds;
                }
                set
                {
                    this.SetWaitMilliseconds(value);
                }
            }
        }
    }
}

