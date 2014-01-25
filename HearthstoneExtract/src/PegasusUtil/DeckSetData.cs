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

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class DeckSetData : GeneratedMessageLite<DeckSetData, Builder>
    {
        private static readonly string[] _deckSetDataFieldNames = new string[] { "cards", "deck" };
        private static readonly uint[] _deckSetDataFieldTags = new uint[] { 0x12, 8 };
        private PopsicleList<DeckCardData> cards_ = new PopsicleList<DeckCardData>();
        public const int CardsFieldNumber = 2;
        private long deck_;
        public const int DeckFieldNumber = 1;
        private static readonly DeckSetData defaultInstance = new DeckSetData().MakeReadOnly();
        private bool hasDeck;
        private int memoizedSerializedSize = -1;

        static DeckSetData()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private DeckSetData()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DeckSetData prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DeckSetData data = obj as DeckSetData;
            if (data == null)
            {
                return false;
            }
            if ((this.hasDeck != data.hasDeck) || (this.hasDeck && !this.deck_.Equals(data.deck_)))
            {
                return false;
            }
            if (this.cards_.Count != data.cards_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.cards_.Count; i++)
            {
                if (!this.cards_[i].Equals(data.cards_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public DeckCardData GetCards(int index)
        {
            return this.cards_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasDeck)
            {
                hashCode ^= this.deck_.GetHashCode();
            }
            IEnumerator<DeckCardData> enumerator = this.cards_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    DeckCardData current = enumerator.Current;
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

        private DeckSetData MakeReadOnly()
        {
            this.cards_.MakeReadOnly();
            return this;
        }

        public static DeckSetData ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DeckSetData ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DeckSetData ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DeckSetData ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DeckSetData ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DeckSetData ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DeckSetData ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DeckSetData ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DeckSetData ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DeckSetData ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DeckSetData, Builder>.PrintField("deck", this.hasDeck, this.deck_, writer);
            GeneratedMessageLite<DeckSetData, Builder>.PrintField<DeckCardData>("cards", this.cards_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _deckSetDataFieldNames;
            if (this.hasDeck)
            {
                output.WriteInt64(1, strArray[1], this.Deck);
            }
            if (this.cards_.Count > 0)
            {
                output.WriteMessageArray<DeckCardData>(2, strArray[0], this.cards_);
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

        public long Deck
        {
            get
            {
                return this.deck_;
            }
        }

        public static DeckSetData DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DeckSetData DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasDeck
        {
            get
            {
                return this.hasDeck;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasDeck)
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

        public override int SerializedSize
        {
            get
            {
                int memoizedSerializedSize = this.memoizedSerializedSize;
                if (memoizedSerializedSize == -1)
                {
                    memoizedSerializedSize = 0;
                    if (this.hasDeck)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(1, this.Deck);
                    }
                    IEnumerator<DeckCardData> enumerator = this.CardsList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            DeckCardData current = enumerator.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, current);
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

        protected override DeckSetData ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<DeckSetData, DeckSetData.Builder>
        {
            private DeckSetData result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DeckSetData.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DeckSetData cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public DeckSetData.Builder AddCards(DeckCardData value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.cards_.Add(value);
                return this;
            }

            public DeckSetData.Builder AddCards(DeckCardData.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.cards_.Add(builderForValue.Build());
                return this;
            }

            public DeckSetData.Builder AddRangeCards(IEnumerable<DeckCardData> values)
            {
                this.PrepareBuilder();
                this.result.cards_.Add(values);
                return this;
            }

            public override DeckSetData BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DeckSetData.Builder Clear()
            {
                this.result = DeckSetData.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DeckSetData.Builder ClearCards()
            {
                this.PrepareBuilder();
                this.result.cards_.Clear();
                return this;
            }

            public DeckSetData.Builder ClearDeck()
            {
                this.PrepareBuilder();
                this.result.hasDeck = false;
                this.result.deck_ = 0L;
                return this;
            }

            public override DeckSetData.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DeckSetData.Builder(this.result);
                }
                return new DeckSetData.Builder().MergeFrom(this.result);
            }

            public DeckCardData GetCards(int index)
            {
                return this.result.GetCards(index);
            }

            public override DeckSetData.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DeckSetData.Builder MergeFrom(IMessageLite other)
            {
                if (other is DeckSetData)
                {
                    return this.MergeFrom((DeckSetData) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DeckSetData.Builder MergeFrom(DeckSetData other)
            {
                if (other != DeckSetData.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasDeck)
                    {
                        this.Deck = other.Deck;
                    }
                    if (other.cards_.Count != 0)
                    {
                        this.result.cards_.Add(other.cards_);
                    }
                }
                return this;
            }

            public override DeckSetData.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DeckSetData._deckSetDataFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DeckSetData._deckSetDataFieldTags[index];
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
                            this.result.hasDeck = input.ReadInt64(ref this.result.deck_);
                            continue;
                        }
                        case 0x12:
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
                    input.ReadMessageArray<DeckCardData>(num, str, this.result.cards_, DeckCardData.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private DeckSetData PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DeckSetData result = this.result;
                    this.result = new DeckSetData();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DeckSetData.Builder SetCards(int index, DeckCardData value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.cards_[index] = value;
                return this;
            }

            public DeckSetData.Builder SetCards(int index, DeckCardData.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.cards_[index] = builderForValue.Build();
                return this;
            }

            public DeckSetData.Builder SetDeck(long value)
            {
                this.PrepareBuilder();
                this.result.hasDeck = true;
                this.result.deck_ = value;
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

            public long Deck
            {
                get
                {
                    return this.result.Deck;
                }
                set
                {
                    this.SetDeck(value);
                }
            }

            public override DeckSetData DefaultInstanceForType
            {
                get
                {
                    return DeckSetData.DefaultInstance;
                }
            }

            public bool HasDeck
            {
                get
                {
                    return this.result.hasDeck;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override DeckSetData MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override DeckSetData.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0xde,
                System = 0
            }
        }
    }
}

