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
    public sealed class CardValue : GeneratedMessageLite<CardValue, Builder>
    {
        private static readonly string[] _cardValueFieldNames = new string[] { "buy", "card", "sell" };
        private static readonly uint[] _cardValueFieldTags = new uint[] { 0x10, 10, 0x18 };
        private int buy_;
        public const int BuyFieldNumber = 2;
        private CardDef card_;
        public const int CardFieldNumber = 1;
        private static readonly CardValue defaultInstance = new CardValue().MakeReadOnly();
        private bool hasBuy;
        private bool hasCard;
        private bool hasSell;
        private int memoizedSerializedSize = -1;
        private int sell_;
        public const int SellFieldNumber = 3;

        static CardValue()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private CardValue()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(CardValue prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            CardValue value2 = obj as CardValue;
            if (value2 == null)
            {
                return false;
            }
            if ((this.hasCard != value2.hasCard) || (this.hasCard && !this.card_.Equals(value2.card_)))
            {
                return false;
            }
            if ((this.hasBuy != value2.hasBuy) || (this.hasBuy && !this.buy_.Equals(value2.buy_)))
            {
                return false;
            }
            return ((this.hasSell == value2.hasSell) && (!this.hasSell || this.sell_.Equals(value2.sell_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasCard)
            {
                hashCode ^= this.card_.GetHashCode();
            }
            if (this.hasBuy)
            {
                hashCode ^= this.buy_.GetHashCode();
            }
            if (this.hasSell)
            {
                hashCode ^= this.sell_.GetHashCode();
            }
            return hashCode;
        }

        private CardValue MakeReadOnly()
        {
            return this;
        }

        public static CardValue ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static CardValue ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static CardValue ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static CardValue ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static CardValue ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static CardValue ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static CardValue ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static CardValue ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static CardValue ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static CardValue ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<CardValue, Builder>.PrintField("card", this.hasCard, this.card_, writer);
            GeneratedMessageLite<CardValue, Builder>.PrintField("buy", this.hasBuy, this.buy_, writer);
            GeneratedMessageLite<CardValue, Builder>.PrintField("sell", this.hasSell, this.sell_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _cardValueFieldNames;
            if (this.hasCard)
            {
                output.WriteMessage(1, strArray[1], this.Card);
            }
            if (this.hasBuy)
            {
                output.WriteInt32(2, strArray[0], this.Buy);
            }
            if (this.hasSell)
            {
                output.WriteInt32(3, strArray[2], this.Sell);
            }
        }

        public int Buy
        {
            get
            {
                return this.buy_;
            }
        }

        public CardDef Card
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.card_ != null)
                {
                    goto Label_0012;
                }
                return CardDef.DefaultInstance;
            }
        }

        public static CardValue DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override CardValue DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasBuy
        {
            get
            {
                return this.hasBuy;
            }
        }

        public bool HasCard
        {
            get
            {
                return this.hasCard;
            }
        }

        public bool HasSell
        {
            get
            {
                return this.hasSell;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasCard)
                {
                    return false;
                }
                if (!this.hasBuy)
                {
                    return false;
                }
                if (!this.hasSell)
                {
                    return false;
                }
                if (!this.Card.IsInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        public int Sell
        {
            get
            {
                return this.sell_;
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
                    if (this.hasCard)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.Card);
                    }
                    if (this.hasBuy)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.Buy);
                    }
                    if (this.hasSell)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(3, this.Sell);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override CardValue ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<CardValue, CardValue.Builder>
        {
            private CardValue result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = CardValue.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(CardValue cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override CardValue BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override CardValue.Builder Clear()
            {
                this.result = CardValue.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public CardValue.Builder ClearBuy()
            {
                this.PrepareBuilder();
                this.result.hasBuy = false;
                this.result.buy_ = 0;
                return this;
            }

            public CardValue.Builder ClearCard()
            {
                this.PrepareBuilder();
                this.result.hasCard = false;
                this.result.card_ = null;
                return this;
            }

            public CardValue.Builder ClearSell()
            {
                this.PrepareBuilder();
                this.result.hasSell = false;
                this.result.sell_ = 0;
                return this;
            }

            public override CardValue.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new CardValue.Builder(this.result);
                }
                return new CardValue.Builder().MergeFrom(this.result);
            }

            public CardValue.Builder MergeCard(CardDef value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasCard && (this.result.card_ != CardDef.DefaultInstance))
                {
                    this.result.card_ = CardDef.CreateBuilder(this.result.card_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.card_ = value;
                }
                this.result.hasCard = true;
                return this;
            }

            public override CardValue.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override CardValue.Builder MergeFrom(IMessageLite other)
            {
                if (other is CardValue)
                {
                    return this.MergeFrom((CardValue) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override CardValue.Builder MergeFrom(CardValue other)
            {
                if (other != CardValue.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasCard)
                    {
                        this.MergeCard(other.Card);
                    }
                    if (other.HasBuy)
                    {
                        this.Buy = other.Buy;
                    }
                    if (other.HasSell)
                    {
                        this.Sell = other.Sell;
                    }
                }
                return this;
            }

            public override CardValue.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(CardValue._cardValueFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = CardValue._cardValueFieldTags[index];
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
                            CardDef.Builder builder = CardDef.CreateBuilder();
                            if (this.result.hasCard)
                            {
                                builder.MergeFrom(this.Card);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.Card = builder.BuildPartial();
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasBuy = input.ReadInt32(ref this.result.buy_);
                            continue;
                        }
                        case 0x18:
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
                    this.result.hasSell = input.ReadInt32(ref this.result.sell_);
                }
                return this;
            }

            private CardValue PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    CardValue result = this.result;
                    this.result = new CardValue();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public CardValue.Builder SetBuy(int value)
            {
                this.PrepareBuilder();
                this.result.hasBuy = true;
                this.result.buy_ = value;
                return this;
            }

            public CardValue.Builder SetCard(CardDef value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasCard = true;
                this.result.card_ = value;
                return this;
            }

            public CardValue.Builder SetCard(CardDef.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasCard = true;
                this.result.card_ = builderForValue.Build();
                return this;
            }

            public CardValue.Builder SetSell(int value)
            {
                this.PrepareBuilder();
                this.result.hasSell = true;
                this.result.sell_ = value;
                return this;
            }

            public int Buy
            {
                get
                {
                    return this.result.Buy;
                }
                set
                {
                    this.SetBuy(value);
                }
            }

            public CardDef Card
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

            public override CardValue DefaultInstanceForType
            {
                get
                {
                    return CardValue.DefaultInstance;
                }
            }

            public bool HasBuy
            {
                get
                {
                    return this.result.hasBuy;
                }
            }

            public bool HasCard
            {
                get
                {
                    return this.result.hasCard;
                }
            }

            public bool HasSell
            {
                get
                {
                    return this.result.hasSell;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override CardValue MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int Sell
            {
                get
                {
                    return this.result.Sell;
                }
                set
                {
                    this.SetSell(value);
                }
            }

            protected override CardValue.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

