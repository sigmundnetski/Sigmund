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
    public sealed class BuySellCard : GeneratedMessageLite<BuySellCard, Builder>
    {
        private static readonly string[] _buySellCardFieldNames = new string[] { "buying", "def" };
        private static readonly uint[] _buySellCardFieldTags = new uint[] { 0x18, 10 };
        private bool buying_;
        public const int BuyingFieldNumber = 3;
        private CardDef def_;
        private static readonly BuySellCard defaultInstance = new BuySellCard().MakeReadOnly();
        public const int DefFieldNumber = 1;
        private bool hasBuying;
        private bool hasDef;
        private int memoizedSerializedSize = -1;

        static BuySellCard()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private BuySellCard()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(BuySellCard prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            BuySellCard card = obj as BuySellCard;
            if (card == null)
            {
                return false;
            }
            if ((this.hasDef != card.hasDef) || (this.hasDef && !this.def_.Equals(card.def_)))
            {
                return false;
            }
            return ((this.hasBuying == card.hasBuying) && (!this.hasBuying || this.buying_.Equals(card.buying_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasDef)
            {
                hashCode ^= this.def_.GetHashCode();
            }
            if (this.hasBuying)
            {
                hashCode ^= this.buying_.GetHashCode();
            }
            return hashCode;
        }

        private BuySellCard MakeReadOnly()
        {
            return this;
        }

        public static BuySellCard ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static BuySellCard ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static BuySellCard ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static BuySellCard ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static BuySellCard ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static BuySellCard ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static BuySellCard ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static BuySellCard ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static BuySellCard ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static BuySellCard ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<BuySellCard, Builder>.PrintField("def", this.hasDef, this.def_, writer);
            GeneratedMessageLite<BuySellCard, Builder>.PrintField("buying", this.hasBuying, this.buying_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _buySellCardFieldNames;
            if (this.hasDef)
            {
                output.WriteMessage(1, strArray[1], this.Def);
            }
            if (this.hasBuying)
            {
                output.WriteBool(3, strArray[0], this.Buying);
            }
        }

        public bool Buying
        {
            get
            {
                return this.buying_;
            }
        }

        public CardDef Def
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.def_ != null)
                {
                    goto Label_0012;
                }
                return CardDef.DefaultInstance;
            }
        }

        public static BuySellCard DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override BuySellCard DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasBuying
        {
            get
            {
                return this.hasBuying;
            }
        }

        public bool HasDef
        {
            get
            {
                return this.hasDef;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasDef)
                {
                    return false;
                }
                if (!this.hasBuying)
                {
                    return false;
                }
                if (!this.Def.IsInitialized)
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
                    if (this.hasDef)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.Def);
                    }
                    if (this.hasBuying)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(3, this.Buying);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override BuySellCard ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<BuySellCard, BuySellCard.Builder>
        {
            private BuySellCard result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = BuySellCard.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(BuySellCard cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override BuySellCard BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override BuySellCard.Builder Clear()
            {
                this.result = BuySellCard.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public BuySellCard.Builder ClearBuying()
            {
                this.PrepareBuilder();
                this.result.hasBuying = false;
                this.result.buying_ = false;
                return this;
            }

            public BuySellCard.Builder ClearDef()
            {
                this.PrepareBuilder();
                this.result.hasDef = false;
                this.result.def_ = null;
                return this;
            }

            public override BuySellCard.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new BuySellCard.Builder(this.result);
                }
                return new BuySellCard.Builder().MergeFrom(this.result);
            }

            public BuySellCard.Builder MergeDef(CardDef value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasDef && (this.result.def_ != CardDef.DefaultInstance))
                {
                    this.result.def_ = CardDef.CreateBuilder(this.result.def_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.def_ = value;
                }
                this.result.hasDef = true;
                return this;
            }

            public override BuySellCard.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override BuySellCard.Builder MergeFrom(IMessageLite other)
            {
                if (other is BuySellCard)
                {
                    return this.MergeFrom((BuySellCard) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override BuySellCard.Builder MergeFrom(BuySellCard other)
            {
                if (other != BuySellCard.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasDef)
                    {
                        this.MergeDef(other.Def);
                    }
                    if (other.HasBuying)
                    {
                        this.Buying = other.Buying;
                    }
                }
                return this;
            }

            public override BuySellCard.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(BuySellCard._buySellCardFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = BuySellCard._buySellCardFieldTags[index];
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
                            if (this.result.hasDef)
                            {
                                builder.MergeFrom(this.Def);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.Def = builder.BuildPartial();
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
                    this.result.hasBuying = input.ReadBool(ref this.result.buying_);
                }
                return this;
            }

            private BuySellCard PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    BuySellCard result = this.result;
                    this.result = new BuySellCard();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public BuySellCard.Builder SetBuying(bool value)
            {
                this.PrepareBuilder();
                this.result.hasBuying = true;
                this.result.buying_ = value;
                return this;
            }

            public BuySellCard.Builder SetDef(CardDef value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasDef = true;
                this.result.def_ = value;
                return this;
            }

            public BuySellCard.Builder SetDef(CardDef.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasDef = true;
                this.result.def_ = builderForValue.Build();
                return this;
            }

            public bool Buying
            {
                get
                {
                    return this.result.Buying;
                }
                set
                {
                    this.SetBuying(value);
                }
            }

            public CardDef Def
            {
                get
                {
                    return this.result.Def;
                }
                set
                {
                    this.SetDef(value);
                }
            }

            public override BuySellCard DefaultInstanceForType
            {
                get
                {
                    return BuySellCard.DefaultInstance;
                }
            }

            public bool HasBuying
            {
                get
                {
                    return this.result.hasBuying;
                }
            }

            public bool HasDef
            {
                get
                {
                    return this.result.hasDef;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override BuySellCard MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override BuySellCard.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0x101,
                System = 0
            }
        }
    }
}

