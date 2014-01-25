namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class MedalInfo : GeneratedMessageLite<MedalInfo, Builder>
    {
        private static readonly string[] _medalInfoFieldNames = new string[] { "curr_medal", "curr_xp", "prev_medal", "prev_xp", "season_wins" };
        private static readonly uint[] _medalInfoFieldTags = new uint[] { 8, 0x10, 0x20, 40, 0x18 };
        private int currMedal_;
        public const int CurrMedalFieldNumber = 1;
        private int currXp_;
        public const int CurrXpFieldNumber = 2;
        private static readonly MedalInfo defaultInstance = new MedalInfo().MakeReadOnly();
        private bool hasCurrMedal;
        private bool hasCurrXp;
        private bool hasPrevMedal;
        private bool hasPrevXp;
        private bool hasSeasonWins;
        private int memoizedSerializedSize = -1;
        private int prevMedal_;
        public const int PrevMedalFieldNumber = 4;
        private int prevXp_;
        public const int PrevXpFieldNumber = 5;
        private int seasonWins_;
        public const int SeasonWinsFieldNumber = 3;

        static MedalInfo()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private MedalInfo()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(MedalInfo prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            MedalInfo info = obj as MedalInfo;
            if (info == null)
            {
                return false;
            }
            if ((this.hasCurrMedal != info.hasCurrMedal) || (this.hasCurrMedal && !this.currMedal_.Equals(info.currMedal_)))
            {
                return false;
            }
            if ((this.hasCurrXp != info.hasCurrXp) || (this.hasCurrXp && !this.currXp_.Equals(info.currXp_)))
            {
                return false;
            }
            if ((this.hasSeasonWins != info.hasSeasonWins) || (this.hasSeasonWins && !this.seasonWins_.Equals(info.seasonWins_)))
            {
                return false;
            }
            if ((this.hasPrevMedal != info.hasPrevMedal) || (this.hasPrevMedal && !this.prevMedal_.Equals(info.prevMedal_)))
            {
                return false;
            }
            return ((this.hasPrevXp == info.hasPrevXp) && (!this.hasPrevXp || this.prevXp_.Equals(info.prevXp_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasCurrMedal)
            {
                hashCode ^= this.currMedal_.GetHashCode();
            }
            if (this.hasCurrXp)
            {
                hashCode ^= this.currXp_.GetHashCode();
            }
            if (this.hasSeasonWins)
            {
                hashCode ^= this.seasonWins_.GetHashCode();
            }
            if (this.hasPrevMedal)
            {
                hashCode ^= this.prevMedal_.GetHashCode();
            }
            if (this.hasPrevXp)
            {
                hashCode ^= this.prevXp_.GetHashCode();
            }
            return hashCode;
        }

        private MedalInfo MakeReadOnly()
        {
            return this;
        }

        public static MedalInfo ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static MedalInfo ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static MedalInfo ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static MedalInfo ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static MedalInfo ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static MedalInfo ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static MedalInfo ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static MedalInfo ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static MedalInfo ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static MedalInfo ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<MedalInfo, Builder>.PrintField("curr_medal", this.hasCurrMedal, this.currMedal_, writer);
            GeneratedMessageLite<MedalInfo, Builder>.PrintField("curr_xp", this.hasCurrXp, this.currXp_, writer);
            GeneratedMessageLite<MedalInfo, Builder>.PrintField("season_wins", this.hasSeasonWins, this.seasonWins_, writer);
            GeneratedMessageLite<MedalInfo, Builder>.PrintField("prev_medal", this.hasPrevMedal, this.prevMedal_, writer);
            GeneratedMessageLite<MedalInfo, Builder>.PrintField("prev_xp", this.hasPrevXp, this.prevXp_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _medalInfoFieldNames;
            if (this.hasCurrMedal)
            {
                output.WriteInt32(1, strArray[0], this.CurrMedal);
            }
            if (this.hasCurrXp)
            {
                output.WriteInt32(2, strArray[1], this.CurrXp);
            }
            if (this.hasSeasonWins)
            {
                output.WriteInt32(3, strArray[4], this.SeasonWins);
            }
            if (this.hasPrevMedal)
            {
                output.WriteInt32(4, strArray[2], this.PrevMedal);
            }
            if (this.hasPrevXp)
            {
                output.WriteInt32(5, strArray[3], this.PrevXp);
            }
        }

        public int CurrMedal
        {
            get
            {
                return this.currMedal_;
            }
        }

        public int CurrXp
        {
            get
            {
                return this.currXp_;
            }
        }

        public static MedalInfo DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override MedalInfo DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasCurrMedal
        {
            get
            {
                return this.hasCurrMedal;
            }
        }

        public bool HasCurrXp
        {
            get
            {
                return this.hasCurrXp;
            }
        }

        public bool HasPrevMedal
        {
            get
            {
                return this.hasPrevMedal;
            }
        }

        public bool HasPrevXp
        {
            get
            {
                return this.hasPrevXp;
            }
        }

        public bool HasSeasonWins
        {
            get
            {
                return this.hasSeasonWins;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasCurrMedal)
                {
                    return false;
                }
                if (!this.hasCurrXp)
                {
                    return false;
                }
                if (!this.hasSeasonWins)
                {
                    return false;
                }
                if (!this.hasPrevMedal)
                {
                    return false;
                }
                if (!this.hasPrevXp)
                {
                    return false;
                }
                return true;
            }
        }

        public int PrevMedal
        {
            get
            {
                return this.prevMedal_;
            }
        }

        public int PrevXp
        {
            get
            {
                return this.prevXp_;
            }
        }

        public int SeasonWins
        {
            get
            {
                return this.seasonWins_;
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
                    if (this.hasCurrMedal)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.CurrMedal);
                    }
                    if (this.hasCurrXp)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.CurrXp);
                    }
                    if (this.hasSeasonWins)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(3, this.SeasonWins);
                    }
                    if (this.hasPrevMedal)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(4, this.PrevMedal);
                    }
                    if (this.hasPrevXp)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(5, this.PrevXp);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override MedalInfo ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<MedalInfo, MedalInfo.Builder>
        {
            private MedalInfo result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = MedalInfo.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(MedalInfo cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override MedalInfo BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override MedalInfo.Builder Clear()
            {
                this.result = MedalInfo.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public MedalInfo.Builder ClearCurrMedal()
            {
                this.PrepareBuilder();
                this.result.hasCurrMedal = false;
                this.result.currMedal_ = 0;
                return this;
            }

            public MedalInfo.Builder ClearCurrXp()
            {
                this.PrepareBuilder();
                this.result.hasCurrXp = false;
                this.result.currXp_ = 0;
                return this;
            }

            public MedalInfo.Builder ClearPrevMedal()
            {
                this.PrepareBuilder();
                this.result.hasPrevMedal = false;
                this.result.prevMedal_ = 0;
                return this;
            }

            public MedalInfo.Builder ClearPrevXp()
            {
                this.PrepareBuilder();
                this.result.hasPrevXp = false;
                this.result.prevXp_ = 0;
                return this;
            }

            public MedalInfo.Builder ClearSeasonWins()
            {
                this.PrepareBuilder();
                this.result.hasSeasonWins = false;
                this.result.seasonWins_ = 0;
                return this;
            }

            public override MedalInfo.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new MedalInfo.Builder(this.result);
                }
                return new MedalInfo.Builder().MergeFrom(this.result);
            }

            public override MedalInfo.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override MedalInfo.Builder MergeFrom(IMessageLite other)
            {
                if (other is MedalInfo)
                {
                    return this.MergeFrom((MedalInfo) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override MedalInfo.Builder MergeFrom(MedalInfo other)
            {
                if (other != MedalInfo.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasCurrMedal)
                    {
                        this.CurrMedal = other.CurrMedal;
                    }
                    if (other.HasCurrXp)
                    {
                        this.CurrXp = other.CurrXp;
                    }
                    if (other.HasSeasonWins)
                    {
                        this.SeasonWins = other.SeasonWins;
                    }
                    if (other.HasPrevMedal)
                    {
                        this.PrevMedal = other.PrevMedal;
                    }
                    if (other.HasPrevXp)
                    {
                        this.PrevXp = other.PrevXp;
                    }
                }
                return this;
            }

            public override MedalInfo.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(MedalInfo._medalInfoFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = MedalInfo._medalInfoFieldTags[index];
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
                            this.result.hasCurrMedal = input.ReadInt32(ref this.result.currMedal_);
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasCurrXp = input.ReadInt32(ref this.result.currXp_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasSeasonWins = input.ReadInt32(ref this.result.seasonWins_);
                            continue;
                        }
                        case 0x20:
                        {
                            this.result.hasPrevMedal = input.ReadInt32(ref this.result.prevMedal_);
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
                    this.result.hasPrevXp = input.ReadInt32(ref this.result.prevXp_);
                }
                return this;
            }

            private MedalInfo PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    MedalInfo result = this.result;
                    this.result = new MedalInfo();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public MedalInfo.Builder SetCurrMedal(int value)
            {
                this.PrepareBuilder();
                this.result.hasCurrMedal = true;
                this.result.currMedal_ = value;
                return this;
            }

            public MedalInfo.Builder SetCurrXp(int value)
            {
                this.PrepareBuilder();
                this.result.hasCurrXp = true;
                this.result.currXp_ = value;
                return this;
            }

            public MedalInfo.Builder SetPrevMedal(int value)
            {
                this.PrepareBuilder();
                this.result.hasPrevMedal = true;
                this.result.prevMedal_ = value;
                return this;
            }

            public MedalInfo.Builder SetPrevXp(int value)
            {
                this.PrepareBuilder();
                this.result.hasPrevXp = true;
                this.result.prevXp_ = value;
                return this;
            }

            public MedalInfo.Builder SetSeasonWins(int value)
            {
                this.PrepareBuilder();
                this.result.hasSeasonWins = true;
                this.result.seasonWins_ = value;
                return this;
            }

            public int CurrMedal
            {
                get
                {
                    return this.result.CurrMedal;
                }
                set
                {
                    this.SetCurrMedal(value);
                }
            }

            public int CurrXp
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

            public override MedalInfo DefaultInstanceForType
            {
                get
                {
                    return MedalInfo.DefaultInstance;
                }
            }

            public bool HasCurrMedal
            {
                get
                {
                    return this.result.hasCurrMedal;
                }
            }

            public bool HasCurrXp
            {
                get
                {
                    return this.result.hasCurrXp;
                }
            }

            public bool HasPrevMedal
            {
                get
                {
                    return this.result.hasPrevMedal;
                }
            }

            public bool HasPrevXp
            {
                get
                {
                    return this.result.hasPrevXp;
                }
            }

            public bool HasSeasonWins
            {
                get
                {
                    return this.result.hasSeasonWins;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override MedalInfo MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int PrevMedal
            {
                get
                {
                    return this.result.PrevMedal;
                }
                set
                {
                    this.SetPrevMedal(value);
                }
            }

            public int PrevXp
            {
                get
                {
                    return this.result.PrevXp;
                }
                set
                {
                    this.SetPrevXp(value);
                }
            }

            public int SeasonWins
            {
                get
                {
                    return this.result.SeasonWins;
                }
                set
                {
                    this.SetSeasonWins(value);
                }
            }

            protected override MedalInfo.Builder ThisBuilder
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
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0xe8
            }
        }
    }
}

