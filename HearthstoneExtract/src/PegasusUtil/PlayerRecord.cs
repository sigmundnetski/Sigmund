namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class PlayerRecord : GeneratedMessageLite<PlayerRecord, Builder>
    {
        private static readonly string[] _playerRecordFieldNames = new string[] { "data", "losses", "ties", "type", "wins" };
        private static readonly uint[] _playerRecordFieldTags = new uint[] { 0x10, 0x20, 40, 8, 0x18 };
        private int data_;
        public const int DataFieldNumber = 2;
        private static readonly PlayerRecord defaultInstance = new PlayerRecord().MakeReadOnly();
        private bool hasData;
        private bool hasLosses;
        private bool hasTies;
        private bool hasType;
        private bool hasWins;
        private int losses_;
        public const int LossesFieldNumber = 4;
        private int memoizedSerializedSize = -1;
        private int ties_;
        public const int TiesFieldNumber = 5;
        private int type_;
        public const int TypeFieldNumber = 1;
        private int wins_;
        public const int WinsFieldNumber = 3;

        static PlayerRecord()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private PlayerRecord()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(PlayerRecord prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            PlayerRecord record = obj as PlayerRecord;
            if (record == null)
            {
                return false;
            }
            if ((this.hasType != record.hasType) || (this.hasType && !this.type_.Equals(record.type_)))
            {
                return false;
            }
            if ((this.hasData != record.hasData) || (this.hasData && !this.data_.Equals(record.data_)))
            {
                return false;
            }
            if ((this.hasWins != record.hasWins) || (this.hasWins && !this.wins_.Equals(record.wins_)))
            {
                return false;
            }
            if ((this.hasLosses != record.hasLosses) || (this.hasLosses && !this.losses_.Equals(record.losses_)))
            {
                return false;
            }
            return ((this.hasTies == record.hasTies) && (!this.hasTies || this.ties_.Equals(record.ties_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasType)
            {
                hashCode ^= this.type_.GetHashCode();
            }
            if (this.hasData)
            {
                hashCode ^= this.data_.GetHashCode();
            }
            if (this.hasWins)
            {
                hashCode ^= this.wins_.GetHashCode();
            }
            if (this.hasLosses)
            {
                hashCode ^= this.losses_.GetHashCode();
            }
            if (this.hasTies)
            {
                hashCode ^= this.ties_.GetHashCode();
            }
            return hashCode;
        }

        private PlayerRecord MakeReadOnly()
        {
            return this;
        }

        public static PlayerRecord ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static PlayerRecord ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static PlayerRecord ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PlayerRecord ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PlayerRecord ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PlayerRecord ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PlayerRecord ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static PlayerRecord ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PlayerRecord ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PlayerRecord ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<PlayerRecord, Builder>.PrintField("type", this.hasType, this.type_, writer);
            GeneratedMessageLite<PlayerRecord, Builder>.PrintField("data", this.hasData, this.data_, writer);
            GeneratedMessageLite<PlayerRecord, Builder>.PrintField("wins", this.hasWins, this.wins_, writer);
            GeneratedMessageLite<PlayerRecord, Builder>.PrintField("losses", this.hasLosses, this.losses_, writer);
            GeneratedMessageLite<PlayerRecord, Builder>.PrintField("ties", this.hasTies, this.ties_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _playerRecordFieldNames;
            if (this.hasType)
            {
                output.WriteInt32(1, strArray[3], this.Type);
            }
            if (this.hasData)
            {
                output.WriteInt32(2, strArray[0], this.Data);
            }
            if (this.hasWins)
            {
                output.WriteInt32(3, strArray[4], this.Wins);
            }
            if (this.hasLosses)
            {
                output.WriteInt32(4, strArray[1], this.Losses);
            }
            if (this.hasTies)
            {
                output.WriteInt32(5, strArray[2], this.Ties);
            }
        }

        public int Data
        {
            get
            {
                return this.data_;
            }
        }

        public static PlayerRecord DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override PlayerRecord DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasData
        {
            get
            {
                return this.hasData;
            }
        }

        public bool HasLosses
        {
            get
            {
                return this.hasLosses;
            }
        }

        public bool HasTies
        {
            get
            {
                return this.hasTies;
            }
        }

        public bool HasType
        {
            get
            {
                return this.hasType;
            }
        }

        public bool HasWins
        {
            get
            {
                return this.hasWins;
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
                if (!this.hasWins)
                {
                    return false;
                }
                if (!this.hasLosses)
                {
                    return false;
                }
                return true;
            }
        }

        public int Losses
        {
            get
            {
                return this.losses_;
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
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.Type);
                    }
                    if (this.hasData)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.Data);
                    }
                    if (this.hasWins)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(3, this.Wins);
                    }
                    if (this.hasLosses)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(4, this.Losses);
                    }
                    if (this.hasTies)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(5, this.Ties);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override PlayerRecord ThisMessage
        {
            get
            {
                return this;
            }
        }

        public int Ties
        {
            get
            {
                return this.ties_;
            }
        }

        public int Type
        {
            get
            {
                return this.type_;
            }
        }

        public int Wins
        {
            get
            {
                return this.wins_;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<PlayerRecord, PlayerRecord.Builder>
        {
            private PlayerRecord result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = PlayerRecord.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(PlayerRecord cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override PlayerRecord BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override PlayerRecord.Builder Clear()
            {
                this.result = PlayerRecord.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public PlayerRecord.Builder ClearData()
            {
                this.PrepareBuilder();
                this.result.hasData = false;
                this.result.data_ = 0;
                return this;
            }

            public PlayerRecord.Builder ClearLosses()
            {
                this.PrepareBuilder();
                this.result.hasLosses = false;
                this.result.losses_ = 0;
                return this;
            }

            public PlayerRecord.Builder ClearTies()
            {
                this.PrepareBuilder();
                this.result.hasTies = false;
                this.result.ties_ = 0;
                return this;
            }

            public PlayerRecord.Builder ClearType()
            {
                this.PrepareBuilder();
                this.result.hasType = false;
                this.result.type_ = 0;
                return this;
            }

            public PlayerRecord.Builder ClearWins()
            {
                this.PrepareBuilder();
                this.result.hasWins = false;
                this.result.wins_ = 0;
                return this;
            }

            public override PlayerRecord.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new PlayerRecord.Builder(this.result);
                }
                return new PlayerRecord.Builder().MergeFrom(this.result);
            }

            public override PlayerRecord.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override PlayerRecord.Builder MergeFrom(IMessageLite other)
            {
                if (other is PlayerRecord)
                {
                    return this.MergeFrom((PlayerRecord) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override PlayerRecord.Builder MergeFrom(PlayerRecord other)
            {
                if (other != PlayerRecord.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasType)
                    {
                        this.Type = other.Type;
                    }
                    if (other.HasData)
                    {
                        this.Data = other.Data;
                    }
                    if (other.HasWins)
                    {
                        this.Wins = other.Wins;
                    }
                    if (other.HasLosses)
                    {
                        this.Losses = other.Losses;
                    }
                    if (other.HasTies)
                    {
                        this.Ties = other.Ties;
                    }
                }
                return this;
            }

            public override PlayerRecord.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(PlayerRecord._playerRecordFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = PlayerRecord._playerRecordFieldTags[index];
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
                            this.result.hasType = input.ReadInt32(ref this.result.type_);
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasData = input.ReadInt32(ref this.result.data_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasWins = input.ReadInt32(ref this.result.wins_);
                            continue;
                        }
                        case 0x20:
                        {
                            this.result.hasLosses = input.ReadInt32(ref this.result.losses_);
                            continue;
                        }
                        case 40:
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
                    this.result.hasTies = input.ReadInt32(ref this.result.ties_);
                }
                return this;
            }

            private PlayerRecord PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    PlayerRecord result = this.result;
                    this.result = new PlayerRecord();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public PlayerRecord.Builder SetData(int value)
            {
                this.PrepareBuilder();
                this.result.hasData = true;
                this.result.data_ = value;
                return this;
            }

            public PlayerRecord.Builder SetLosses(int value)
            {
                this.PrepareBuilder();
                this.result.hasLosses = true;
                this.result.losses_ = value;
                return this;
            }

            public PlayerRecord.Builder SetTies(int value)
            {
                this.PrepareBuilder();
                this.result.hasTies = true;
                this.result.ties_ = value;
                return this;
            }

            public PlayerRecord.Builder SetType(int value)
            {
                this.PrepareBuilder();
                this.result.hasType = true;
                this.result.type_ = value;
                return this;
            }

            public PlayerRecord.Builder SetWins(int value)
            {
                this.PrepareBuilder();
                this.result.hasWins = true;
                this.result.wins_ = value;
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

            public override PlayerRecord DefaultInstanceForType
            {
                get
                {
                    return PlayerRecord.DefaultInstance;
                }
            }

            public bool HasData
            {
                get
                {
                    return this.result.hasData;
                }
            }

            public bool HasLosses
            {
                get
                {
                    return this.result.hasLosses;
                }
            }

            public bool HasTies
            {
                get
                {
                    return this.result.hasTies;
                }
            }

            public bool HasType
            {
                get
                {
                    return this.result.hasType;
                }
            }

            public bool HasWins
            {
                get
                {
                    return this.result.hasWins;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public int Losses
            {
                get
                {
                    return this.result.Losses;
                }
                set
                {
                    this.SetLosses(value);
                }
            }

            protected override PlayerRecord MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override PlayerRecord.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public int Ties
            {
                get
                {
                    return this.result.Ties;
                }
                set
                {
                    this.SetTies(value);
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

            public int Wins
            {
                get
                {
                    return this.result.Wins;
                }
                set
                {
                    this.SetWins(value);
                }
            }
        }
    }
}

