namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class DeckLostCard : GeneratedMessageLite<DeckLostCard, Builder>
    {
        private static readonly string[] _deckLostCardFieldNames = new string[] { "card", "deck" };
        private static readonly uint[] _deckLostCardFieldTags = new uint[] { 0x10, 8 };
        private long card_;
        public const int CardFieldNumber = 2;
        private long deck_;
        public const int DeckFieldNumber = 1;
        private static readonly DeckLostCard defaultInstance = new DeckLostCard().MakeReadOnly();
        private bool hasCard;
        private bool hasDeck;
        private int memoizedSerializedSize = -1;

        static DeckLostCard()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private DeckLostCard()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DeckLostCard prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DeckLostCard card = obj as DeckLostCard;
            if (card == null)
            {
                return false;
            }
            if ((this.hasDeck != card.hasDeck) || (this.hasDeck && !this.deck_.Equals(card.deck_)))
            {
                return false;
            }
            return ((this.hasCard == card.hasCard) && (!this.hasCard || this.card_.Equals(card.card_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasDeck)
            {
                hashCode ^= this.deck_.GetHashCode();
            }
            if (this.hasCard)
            {
                hashCode ^= this.card_.GetHashCode();
            }
            return hashCode;
        }

        private DeckLostCard MakeReadOnly()
        {
            return this;
        }

        public static DeckLostCard ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DeckLostCard ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DeckLostCard ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DeckLostCard ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DeckLostCard ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DeckLostCard ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DeckLostCard ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DeckLostCard ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DeckLostCard ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DeckLostCard ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DeckLostCard, Builder>.PrintField("deck", this.hasDeck, this.deck_, writer);
            GeneratedMessageLite<DeckLostCard, Builder>.PrintField("card", this.hasCard, this.card_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _deckLostCardFieldNames;
            if (this.hasDeck)
            {
                output.WriteInt64(1, strArray[1], this.Deck);
            }
            if (this.hasCard)
            {
                output.WriteInt64(2, strArray[0], this.Card);
            }
        }

        public long Card
        {
            get
            {
                return this.card_;
            }
        }

        public long Deck
        {
            get
            {
                return this.deck_;
            }
        }

        public static DeckLostCard DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DeckLostCard DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasCard
        {
            get
            {
                return this.hasCard;
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
                if (!this.hasCard)
                {
                    return false;
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
                    if (this.hasCard)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(2, this.Card);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override DeckLostCard ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<DeckLostCard, DeckLostCard.Builder>
        {
            private DeckLostCard result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DeckLostCard.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DeckLostCard cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override DeckLostCard BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DeckLostCard.Builder Clear()
            {
                this.result = DeckLostCard.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DeckLostCard.Builder ClearCard()
            {
                this.PrepareBuilder();
                this.result.hasCard = false;
                this.result.card_ = 0L;
                return this;
            }

            public DeckLostCard.Builder ClearDeck()
            {
                this.PrepareBuilder();
                this.result.hasDeck = false;
                this.result.deck_ = 0L;
                return this;
            }

            public override DeckLostCard.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DeckLostCard.Builder(this.result);
                }
                return new DeckLostCard.Builder().MergeFrom(this.result);
            }

            public override DeckLostCard.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DeckLostCard.Builder MergeFrom(IMessageLite other)
            {
                if (other is DeckLostCard)
                {
                    return this.MergeFrom((DeckLostCard) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DeckLostCard.Builder MergeFrom(DeckLostCard other)
            {
                if (other != DeckLostCard.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasDeck)
                    {
                        this.Deck = other.Deck;
                    }
                    if (other.HasCard)
                    {
                        this.Card = other.Card;
                    }
                }
                return this;
            }

            public override DeckLostCard.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DeckLostCard._deckLostCardFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DeckLostCard._deckLostCardFieldTags[index];
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
                        case 0x10:
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
                    this.result.hasCard = input.ReadInt64(ref this.result.card_);
                }
                return this;
            }

            private DeckLostCard PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DeckLostCard result = this.result;
                    this.result = new DeckLostCard();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DeckLostCard.Builder SetCard(long value)
            {
                this.PrepareBuilder();
                this.result.hasCard = true;
                this.result.card_ = value;
                return this;
            }

            public DeckLostCard.Builder SetDeck(long value)
            {
                this.PrepareBuilder();
                this.result.hasDeck = true;
                this.result.deck_ = value;
                return this;
            }

            public long Card
            {
                get
                {
                    return this.result.Card;
                }
                set
                {
                    this.SetCard(value);
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

            public override DeckLostCard DefaultInstanceForType
            {
                get
                {
                    return DeckLostCard.DefaultInstance;
                }
            }

            public bool HasCard
            {
                get
                {
                    return this.result.hasCard;
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

            protected override DeckLostCard MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override DeckLostCard.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0xdd
            }
        }
    }
}

