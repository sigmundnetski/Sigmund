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
    public sealed class AtlasDeckCard : GeneratedMessageLite<AtlasDeckCard, Builder>
    {
        private static readonly string[] _atlasDeckCardFieldNames = new string[] { "def", "qty" };
        private static readonly uint[] _atlasDeckCardFieldTags = new uint[] { 10, 0x10 };
        private CardDef def_;
        private static readonly AtlasDeckCard defaultInstance = new AtlasDeckCard().MakeReadOnly();
        public const int DefFieldNumber = 1;
        private bool hasDef;
        private bool hasQty;
        private int memoizedSerializedSize = -1;
        private int qty_;
        public const int QtyFieldNumber = 2;

        static AtlasDeckCard()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AtlasDeckCard()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AtlasDeckCard prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AtlasDeckCard card = obj as AtlasDeckCard;
            if (card == null)
            {
                return false;
            }
            if ((this.hasDef != card.hasDef) || (this.hasDef && !this.def_.Equals(card.def_)))
            {
                return false;
            }
            return ((this.hasQty == card.hasQty) && (!this.hasQty || this.qty_.Equals(card.qty_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasDef)
            {
                hashCode ^= this.def_.GetHashCode();
            }
            if (this.hasQty)
            {
                hashCode ^= this.qty_.GetHashCode();
            }
            return hashCode;
        }

        private AtlasDeckCard MakeReadOnly()
        {
            return this;
        }

        public static AtlasDeckCard ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AtlasDeckCard ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasDeckCard ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasDeckCard ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasDeckCard ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasDeckCard ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasDeckCard ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AtlasDeckCard ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasDeckCard ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasDeckCard ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AtlasDeckCard, Builder>.PrintField("def", this.hasDef, this.def_, writer);
            GeneratedMessageLite<AtlasDeckCard, Builder>.PrintField("qty", this.hasQty, this.qty_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _atlasDeckCardFieldNames;
            if (this.hasDef)
            {
                output.WriteMessage(1, strArray[0], this.Def);
            }
            if (this.hasQty)
            {
                output.WriteInt32(2, strArray[1], this.Qty);
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

        public static AtlasDeckCard DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AtlasDeckCard DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasDef
        {
            get
            {
                return this.hasDef;
            }
        }

        public bool HasQty
        {
            get
            {
                return this.hasQty;
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
                if (!this.Def.IsInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        public int Qty
        {
            get
            {
                return this.qty_;
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
                    if (this.hasQty)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.Qty);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override AtlasDeckCard ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<AtlasDeckCard, AtlasDeckCard.Builder>
        {
            private AtlasDeckCard result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AtlasDeckCard.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AtlasDeckCard cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override AtlasDeckCard BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AtlasDeckCard.Builder Clear()
            {
                this.result = AtlasDeckCard.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AtlasDeckCard.Builder ClearDef()
            {
                this.PrepareBuilder();
                this.result.hasDef = false;
                this.result.def_ = null;
                return this;
            }

            public AtlasDeckCard.Builder ClearQty()
            {
                this.PrepareBuilder();
                this.result.hasQty = false;
                this.result.qty_ = 0;
                return this;
            }

            public override AtlasDeckCard.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AtlasDeckCard.Builder(this.result);
                }
                return new AtlasDeckCard.Builder().MergeFrom(this.result);
            }

            public AtlasDeckCard.Builder MergeDef(CardDef value)
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

            public override AtlasDeckCard.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AtlasDeckCard.Builder MergeFrom(IMessageLite other)
            {
                if (other is AtlasDeckCard)
                {
                    return this.MergeFrom((AtlasDeckCard) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AtlasDeckCard.Builder MergeFrom(AtlasDeckCard other)
            {
                if (other != AtlasDeckCard.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasDef)
                    {
                        this.MergeDef(other.Def);
                    }
                    if (other.HasQty)
                    {
                        this.Qty = other.Qty;
                    }
                }
                return this;
            }

            public override AtlasDeckCard.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AtlasDeckCard._atlasDeckCardFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AtlasDeckCard._atlasDeckCardFieldTags[index];
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
                    this.result.hasQty = input.ReadInt32(ref this.result.qty_);
                }
                return this;
            }

            private AtlasDeckCard PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AtlasDeckCard result = this.result;
                    this.result = new AtlasDeckCard();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public AtlasDeckCard.Builder SetDef(CardDef value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasDef = true;
                this.result.def_ = value;
                return this;
            }

            public AtlasDeckCard.Builder SetDef(CardDef.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasDef = true;
                this.result.def_ = builderForValue.Build();
                return this;
            }

            public AtlasDeckCard.Builder SetQty(int value)
            {
                this.PrepareBuilder();
                this.result.hasQty = true;
                this.result.qty_ = value;
                return this;
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

            public override AtlasDeckCard DefaultInstanceForType
            {
                get
                {
                    return AtlasDeckCard.DefaultInstance;
                }
            }

            public bool HasDef
            {
                get
                {
                    return this.result.hasDef;
                }
            }

            public bool HasQty
            {
                get
                {
                    return this.result.hasQty;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override AtlasDeckCard MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int Qty
            {
                get
                {
                    return this.result.Qty;
                }
                set
                {
                    this.SetQty(value);
                }
            }

            protected override AtlasDeckCard.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

