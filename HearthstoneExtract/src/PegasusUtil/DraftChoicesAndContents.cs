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

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class DraftChoicesAndContents : GeneratedMessageLite<DraftChoicesAndContents, Builder>
    {
        private static readonly string[] _draftChoicesAndContentsFieldNames = new string[] { "cards", "choices", "deck_id", "hero", "losses", "slot", "wins" };
        private static readonly uint[] _draftChoicesAndContentsFieldTags = new uint[] { 0x2a, 0x1a, 8, 0x20, 0x38, 0x10, 0x30 };
        private PopsicleList<DeckCardData> cards_ = new PopsicleList<DeckCardData>();
        public const int CardsFieldNumber = 5;
        private PopsicleList<int> choices_ = new PopsicleList<int>();
        public const int ChoicesFieldNumber = 3;
        private int choicesMemoizedSerializedSize;
        private long deckId_;
        public const int DeckIdFieldNumber = 1;
        private static readonly DraftChoicesAndContents defaultInstance = new DraftChoicesAndContents().MakeReadOnly();
        private bool hasDeckId;
        private bool hasHero;
        private bool hasLosses;
        private bool hasSlot;
        private bool hasWins;
        private int hero_;
        public const int HeroFieldNumber = 4;
        private int losses_;
        public const int LossesFieldNumber = 7;
        private int memoizedSerializedSize = -1;
        private int slot_;
        public const int SlotFieldNumber = 2;
        private int wins_;
        public const int WinsFieldNumber = 6;

        static DraftChoicesAndContents()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private DraftChoicesAndContents()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DraftChoicesAndContents prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DraftChoicesAndContents contents = obj as DraftChoicesAndContents;
            if (contents == null)
            {
                return false;
            }
            if ((this.hasDeckId != contents.hasDeckId) || (this.hasDeckId && !this.deckId_.Equals(contents.deckId_)))
            {
                return false;
            }
            if ((this.hasSlot != contents.hasSlot) || (this.hasSlot && !this.slot_.Equals(contents.slot_)))
            {
                return false;
            }
            if (this.choices_.Count != contents.choices_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.choices_.Count; i++)
            {
                int num3 = this.choices_[i];
                if (!num3.Equals(contents.choices_[i]))
                {
                    return false;
                }
            }
            if ((this.hasHero != contents.hasHero) || (this.hasHero && !this.hero_.Equals(contents.hero_)))
            {
                return false;
            }
            if (this.cards_.Count != contents.cards_.Count)
            {
                return false;
            }
            for (int j = 0; j < this.cards_.Count; j++)
            {
                if (!this.cards_[j].Equals(contents.cards_[j]))
                {
                    return false;
                }
            }
            if ((this.hasWins != contents.hasWins) || (this.hasWins && !this.wins_.Equals(contents.wins_)))
            {
                return false;
            }
            return ((this.hasLosses == contents.hasLosses) && (!this.hasLosses || this.losses_.Equals(contents.losses_)));
        }

        public DeckCardData GetCards(int index)
        {
            return this.cards_[index];
        }

        public int GetChoices(int index)
        {
            return this.choices_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasDeckId)
            {
                hashCode ^= this.deckId_.GetHashCode();
            }
            if (this.hasSlot)
            {
                hashCode ^= this.slot_.GetHashCode();
            }
            IEnumerator<int> enumerator = this.choices_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    int current = enumerator.Current;
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
            if (this.hasHero)
            {
                hashCode ^= this.hero_.GetHashCode();
            }
            IEnumerator<DeckCardData> enumerator2 = this.cards_.GetEnumerator();
            try
            {
                while (enumerator2.MoveNext())
                {
                    DeckCardData data = enumerator2.Current;
                    hashCode ^= data.GetHashCode();
                }
            }
            finally
            {
                if (enumerator2 == null)
                {
                }
                enumerator2.Dispose();
            }
            if (this.hasWins)
            {
                hashCode ^= this.wins_.GetHashCode();
            }
            if (this.hasLosses)
            {
                hashCode ^= this.losses_.GetHashCode();
            }
            return hashCode;
        }

        private DraftChoicesAndContents MakeReadOnly()
        {
            this.choices_.MakeReadOnly();
            this.cards_.MakeReadOnly();
            return this;
        }

        public static DraftChoicesAndContents ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DraftChoicesAndContents ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DraftChoicesAndContents ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DraftChoicesAndContents ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DraftChoicesAndContents ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DraftChoicesAndContents ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DraftChoicesAndContents ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DraftChoicesAndContents ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DraftChoicesAndContents ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DraftChoicesAndContents ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DraftChoicesAndContents, Builder>.PrintField("deck_id", this.hasDeckId, this.deckId_, writer);
            GeneratedMessageLite<DraftChoicesAndContents, Builder>.PrintField("slot", this.hasSlot, this.slot_, writer);
            GeneratedMessageLite<DraftChoicesAndContents, Builder>.PrintField<int>("choices", this.choices_, writer);
            GeneratedMessageLite<DraftChoicesAndContents, Builder>.PrintField("hero", this.hasHero, this.hero_, writer);
            GeneratedMessageLite<DraftChoicesAndContents, Builder>.PrintField<DeckCardData>("cards", this.cards_, writer);
            GeneratedMessageLite<DraftChoicesAndContents, Builder>.PrintField("wins", this.hasWins, this.wins_, writer);
            GeneratedMessageLite<DraftChoicesAndContents, Builder>.PrintField("losses", this.hasLosses, this.losses_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _draftChoicesAndContentsFieldNames;
            if (this.hasDeckId)
            {
                output.WriteInt64(1, strArray[2], this.DeckId);
            }
            if (this.hasSlot)
            {
                output.WriteInt32(2, strArray[5], this.Slot);
            }
            if (this.choices_.Count > 0)
            {
                output.WritePackedInt32Array(3, strArray[1], this.choicesMemoizedSerializedSize, this.choices_);
            }
            if (this.hasHero)
            {
                output.WriteInt32(4, strArray[3], this.Hero);
            }
            if (this.cards_.Count > 0)
            {
                output.WriteMessageArray<DeckCardData>(5, strArray[0], this.cards_);
            }
            if (this.hasWins)
            {
                output.WriteInt32(6, strArray[6], this.Wins);
            }
            if (this.hasLosses)
            {
                output.WriteInt32(7, strArray[4], this.Losses);
            }
        }

        public int CardsCount
        {
            get
            {
                return this.cards_.Count;
            }
        }

        public IList<DeckCardData> CardsList
        {
            get
            {
                return this.cards_;
            }
        }

        public int ChoicesCount
        {
            get
            {
                return this.choices_.Count;
            }
        }

        public IList<int> ChoicesList
        {
            get
            {
                return Lists.AsReadOnly<int>(this.choices_);
            }
        }

        public long DeckId
        {
            get
            {
                return this.deckId_;
            }
        }

        public static DraftChoicesAndContents DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DraftChoicesAndContents DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasDeckId
        {
            get
            {
                return this.hasDeckId;
            }
        }

        public bool HasHero
        {
            get
            {
                return this.hasHero;
            }
        }

        public bool HasLosses
        {
            get
            {
                return this.hasLosses;
            }
        }

        public bool HasSlot
        {
            get
            {
                return this.hasSlot;
            }
        }

        public bool HasWins
        {
            get
            {
                return this.hasWins;
            }
        }

        public int Hero
        {
            get
            {
                return this.hero_;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasDeckId)
                {
                    return false;
                }
                if (!this.hasSlot)
                {
                    return false;
                }
                if (!this.hasHero)
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
                IEnumerator<DeckCardData> enumerator = this.CardsList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        DeckCardData current = enumerator.Current;
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
                    if (this.hasDeckId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(1, this.DeckId);
                    }
                    if (this.hasSlot)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.Slot);
                    }
                    int num2 = 0;
                    IEnumerator<int> enumerator = this.ChoicesList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            int current = enumerator.Current;
                            num2 += CodedOutputStream.ComputeInt32SizeNoTag(current);
                        }
                    }
                    finally
                    {
                        if (enumerator == null)
                        {
                        }
                        enumerator.Dispose();
                    }
                    memoizedSerializedSize += num2;
                    if (this.choices_.Count != 0)
                    {
                        memoizedSerializedSize += 1 + CodedOutputStream.ComputeInt32SizeNoTag(num2);
                    }
                    this.choicesMemoizedSerializedSize = num2;
                    if (this.hasHero)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(4, this.Hero);
                    }
                    IEnumerator<DeckCardData> enumerator2 = this.CardsList.GetEnumerator();
                    try
                    {
                        while (enumerator2.MoveNext())
                        {
                            DeckCardData data = enumerator2.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(5, data);
                        }
                    }
                    finally
                    {
                        if (enumerator2 == null)
                        {
                        }
                        enumerator2.Dispose();
                    }
                    if (this.hasWins)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(6, this.Wins);
                    }
                    if (this.hasLosses)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(7, this.Losses);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        public int Slot
        {
            get
            {
                return this.slot_;
            }
        }

        protected override DraftChoicesAndContents ThisMessage
        {
            get
            {
                return this;
            }
        }

        public int Wins
        {
            get
            {
                return this.wins_;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<DraftChoicesAndContents, DraftChoicesAndContents.Builder>
        {
            private DraftChoicesAndContents result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DraftChoicesAndContents.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DraftChoicesAndContents cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public DraftChoicesAndContents.Builder AddCards(DeckCardData value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.cards_.Add(value);
                return this;
            }

            public DraftChoicesAndContents.Builder AddCards(DeckCardData.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.cards_.Add(builderForValue.Build());
                return this;
            }

            public DraftChoicesAndContents.Builder AddChoices(int value)
            {
                this.PrepareBuilder();
                this.result.choices_.Add(value);
                return this;
            }

            public DraftChoicesAndContents.Builder AddRangeCards(IEnumerable<DeckCardData> values)
            {
                this.PrepareBuilder();
                this.result.cards_.Add(values);
                return this;
            }

            public DraftChoicesAndContents.Builder AddRangeChoices(IEnumerable<int> values)
            {
                this.PrepareBuilder();
                this.result.choices_.Add(values);
                return this;
            }

            public override DraftChoicesAndContents BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DraftChoicesAndContents.Builder Clear()
            {
                this.result = DraftChoicesAndContents.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DraftChoicesAndContents.Builder ClearCards()
            {
                this.PrepareBuilder();
                this.result.cards_.Clear();
                return this;
            }

            public DraftChoicesAndContents.Builder ClearChoices()
            {
                this.PrepareBuilder();
                this.result.choices_.Clear();
                return this;
            }

            public DraftChoicesAndContents.Builder ClearDeckId()
            {
                this.PrepareBuilder();
                this.result.hasDeckId = false;
                this.result.deckId_ = 0L;
                return this;
            }

            public DraftChoicesAndContents.Builder ClearHero()
            {
                this.PrepareBuilder();
                this.result.hasHero = false;
                this.result.hero_ = 0;
                return this;
            }

            public DraftChoicesAndContents.Builder ClearLosses()
            {
                this.PrepareBuilder();
                this.result.hasLosses = false;
                this.result.losses_ = 0;
                return this;
            }

            public DraftChoicesAndContents.Builder ClearSlot()
            {
                this.PrepareBuilder();
                this.result.hasSlot = false;
                this.result.slot_ = 0;
                return this;
            }

            public DraftChoicesAndContents.Builder ClearWins()
            {
                this.PrepareBuilder();
                this.result.hasWins = false;
                this.result.wins_ = 0;
                return this;
            }

            public override DraftChoicesAndContents.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DraftChoicesAndContents.Builder(this.result);
                }
                return new DraftChoicesAndContents.Builder().MergeFrom(this.result);
            }

            public DeckCardData GetCards(int index)
            {
                return this.result.GetCards(index);
            }

            public int GetChoices(int index)
            {
                return this.result.GetChoices(index);
            }

            public override DraftChoicesAndContents.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DraftChoicesAndContents.Builder MergeFrom(IMessageLite other)
            {
                if (other is DraftChoicesAndContents)
                {
                    return this.MergeFrom((DraftChoicesAndContents) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DraftChoicesAndContents.Builder MergeFrom(DraftChoicesAndContents other)
            {
                if (other != DraftChoicesAndContents.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasDeckId)
                    {
                        this.DeckId = other.DeckId;
                    }
                    if (other.HasSlot)
                    {
                        this.Slot = other.Slot;
                    }
                    if (other.choices_.Count != 0)
                    {
                        this.result.choices_.Add(other.choices_);
                    }
                    if (other.HasHero)
                    {
                        this.Hero = other.Hero;
                    }
                    if (other.cards_.Count != 0)
                    {
                        this.result.cards_.Add(other.cards_);
                    }
                    if (other.HasWins)
                    {
                        this.Wins = other.Wins;
                    }
                    if (other.HasLosses)
                    {
                        this.Losses = other.Losses;
                    }
                }
                return this;
            }

            public override DraftChoicesAndContents.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DraftChoicesAndContents._draftChoicesAndContentsFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DraftChoicesAndContents._draftChoicesAndContentsFieldTags[index];
                        }
                        else
                        {
                            this.ParseUnknownField(input, extensionRegistry, num, str);
                            continue;
                        }
                    }
                    switch (num)
                    {
                        case 0x18:
                        case 0x1a:
                        {
                            input.ReadInt32Array(num, str, this.result.choices_);
                            continue;
                        }
                        case 0:
                            throw InvalidProtocolBufferException.InvalidTag();

                        case 8:
                            goto Label_00C2;

                        case 0x10:
                            goto Label_00E3;

                        case 0x20:
                            goto Label_011C;

                        case 0x2a:
                            goto Label_013D;

                        case 0x30:
                            goto Label_015B;

                        case 0x38:
                            goto Label_017C;

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
                Label_00C2:
                    this.result.hasDeckId = input.ReadInt64(ref this.result.deckId_);
                    continue;
                Label_00E3:
                    this.result.hasSlot = input.ReadInt32(ref this.result.slot_);
                    continue;
                Label_011C:
                    this.result.hasHero = input.ReadInt32(ref this.result.hero_);
                    continue;
                Label_013D:
                    input.ReadMessageArray<DeckCardData>(num, str, this.result.cards_, DeckCardData.DefaultInstance, extensionRegistry);
                    continue;
                Label_015B:
                    this.result.hasWins = input.ReadInt32(ref this.result.wins_);
                    continue;
                Label_017C:
                    this.result.hasLosses = input.ReadInt32(ref this.result.losses_);
                }
                return this;
            }

            private DraftChoicesAndContents PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DraftChoicesAndContents result = this.result;
                    this.result = new DraftChoicesAndContents();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DraftChoicesAndContents.Builder SetCards(int index, DeckCardData value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.cards_[index] = value;
                return this;
            }

            public DraftChoicesAndContents.Builder SetCards(int index, DeckCardData.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.cards_[index] = builderForValue.Build();
                return this;
            }

            public DraftChoicesAndContents.Builder SetChoices(int index, int value)
            {
                this.PrepareBuilder();
                this.result.choices_[index] = value;
                return this;
            }

            public DraftChoicesAndContents.Builder SetDeckId(long value)
            {
                this.PrepareBuilder();
                this.result.hasDeckId = true;
                this.result.deckId_ = value;
                return this;
            }

            public DraftChoicesAndContents.Builder SetHero(int value)
            {
                this.PrepareBuilder();
                this.result.hasHero = true;
                this.result.hero_ = value;
                return this;
            }

            public DraftChoicesAndContents.Builder SetLosses(int value)
            {
                this.PrepareBuilder();
                this.result.hasLosses = true;
                this.result.losses_ = value;
                return this;
            }

            public DraftChoicesAndContents.Builder SetSlot(int value)
            {
                this.PrepareBuilder();
                this.result.hasSlot = true;
                this.result.slot_ = value;
                return this;
            }

            public DraftChoicesAndContents.Builder SetWins(int value)
            {
                this.PrepareBuilder();
                this.result.hasWins = true;
                this.result.wins_ = value;
                return this;
            }

            public int CardsCount
            {
                get
                {
                    return this.result.CardsCount;
                }
            }

            public IPopsicleList<DeckCardData> CardsList
            {
                get
                {
                    return this.PrepareBuilder().cards_;
                }
            }

            public int ChoicesCount
            {
                get
                {
                    return this.result.ChoicesCount;
                }
            }

            public IPopsicleList<int> ChoicesList
            {
                get
                {
                    return this.PrepareBuilder().choices_;
                }
            }

            public long DeckId
            {
                get
                {
                    return this.result.DeckId;
                }
                set
                {
                    this.SetDeckId(value);
                }
            }

            public override DraftChoicesAndContents DefaultInstanceForType
            {
                get
                {
                    return DraftChoicesAndContents.DefaultInstance;
                }
            }

            public bool HasDeckId
            {
                get
                {
                    return this.result.hasDeckId;
                }
            }

            public bool HasHero
            {
                get
                {
                    return this.result.hasHero;
                }
            }

            public bool HasLosses
            {
                get
                {
                    return this.result.hasLosses;
                }
            }

            public bool HasSlot
            {
                get
                {
                    return this.result.hasSlot;
                }
            }

            public bool HasWins
            {
                get
                {
                    return this.result.hasWins;
                }
            }

            public int Hero
            {
                get
                {
                    return this.result.Hero;
                }
                set
                {
                    this.SetHero(value);
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

            protected override DraftChoicesAndContents MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int Slot
            {
                get
                {
                    return this.result.Slot;
                }
                set
                {
                    this.SetSlot(value);
                }
            }

            protected override DraftChoicesAndContents.Builder ThisBuilder
            {
                get
                {
                    return this;
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

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0xf8
            }
        }
    }
}

