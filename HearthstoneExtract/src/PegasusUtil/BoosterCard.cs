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
    public sealed class BoosterCard : GeneratedMessageLite<BoosterCard, Builder>
    {
        private static readonly string[] _boosterCardFieldNames = new string[] { "card_def", "insert_date" };
        private static readonly uint[] _boosterCardFieldTags = new uint[] { 10, 0x12 };
        private PegasusShared.CardDef cardDef_;
        public const int CardDefFieldNumber = 1;
        private static readonly BoosterCard defaultInstance = new BoosterCard().MakeReadOnly();
        private bool hasCardDef;
        private bool hasInsertDate;
        private Date insertDate_;
        public const int InsertDateFieldNumber = 2;
        private int memoizedSerializedSize = -1;

        static BoosterCard()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private BoosterCard()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(BoosterCard prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            BoosterCard card = obj as BoosterCard;
            if (card == null)
            {
                return false;
            }
            if ((this.hasCardDef != card.hasCardDef) || (this.hasCardDef && !this.cardDef_.Equals(card.cardDef_)))
            {
                return false;
            }
            return ((this.hasInsertDate == card.hasInsertDate) && (!this.hasInsertDate || this.insertDate_.Equals(card.insertDate_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasCardDef)
            {
                hashCode ^= this.cardDef_.GetHashCode();
            }
            if (this.hasInsertDate)
            {
                hashCode ^= this.insertDate_.GetHashCode();
            }
            return hashCode;
        }

        private BoosterCard MakeReadOnly()
        {
            return this;
        }

        public static BoosterCard ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static BoosterCard ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static BoosterCard ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static BoosterCard ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static BoosterCard ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static BoosterCard ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static BoosterCard ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static BoosterCard ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static BoosterCard ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static BoosterCard ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<BoosterCard, Builder>.PrintField("card_def", this.hasCardDef, this.cardDef_, writer);
            GeneratedMessageLite<BoosterCard, Builder>.PrintField("insert_date", this.hasInsertDate, this.insertDate_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _boosterCardFieldNames;
            if (this.hasCardDef)
            {
                output.WriteMessage(1, strArray[0], this.CardDef);
            }
            if (this.hasInsertDate)
            {
                output.WriteMessage(2, strArray[1], this.InsertDate);
            }
        }

        public PegasusShared.CardDef CardDef
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.cardDef_ != null)
                {
                    goto Label_0012;
                }
                return PegasusShared.CardDef.DefaultInstance;
            }
        }

        public static BoosterCard DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override BoosterCard DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasCardDef
        {
            get
            {
                return this.hasCardDef;
            }
        }

        public bool HasInsertDate
        {
            get
            {
                return this.hasInsertDate;
            }
        }

        public Date InsertDate
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.insertDate_ != null)
                {
                    goto Label_0012;
                }
                return Date.DefaultInstance;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasCardDef)
                {
                    return false;
                }
                if (!this.hasInsertDate)
                {
                    return false;
                }
                if (!this.CardDef.IsInitialized)
                {
                    return false;
                }
                if (!this.InsertDate.IsInitialized)
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
                    if (this.hasCardDef)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.CardDef);
                    }
                    if (this.hasInsertDate)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, this.InsertDate);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override BoosterCard ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<BoosterCard, BoosterCard.Builder>
        {
            private BoosterCard result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = BoosterCard.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(BoosterCard cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override BoosterCard BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override BoosterCard.Builder Clear()
            {
                this.result = BoosterCard.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public BoosterCard.Builder ClearCardDef()
            {
                this.PrepareBuilder();
                this.result.hasCardDef = false;
                this.result.cardDef_ = null;
                return this;
            }

            public BoosterCard.Builder ClearInsertDate()
            {
                this.PrepareBuilder();
                this.result.hasInsertDate = false;
                this.result.insertDate_ = null;
                return this;
            }

            public override BoosterCard.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new BoosterCard.Builder(this.result);
                }
                return new BoosterCard.Builder().MergeFrom(this.result);
            }

            public BoosterCard.Builder MergeCardDef(PegasusShared.CardDef value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasCardDef && (this.result.cardDef_ != PegasusShared.CardDef.DefaultInstance))
                {
                    this.result.cardDef_ = PegasusShared.CardDef.CreateBuilder(this.result.cardDef_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.cardDef_ = value;
                }
                this.result.hasCardDef = true;
                return this;
            }

            public override BoosterCard.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override BoosterCard.Builder MergeFrom(IMessageLite other)
            {
                if (other is BoosterCard)
                {
                    return this.MergeFrom((BoosterCard) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override BoosterCard.Builder MergeFrom(BoosterCard other)
            {
                if (other != BoosterCard.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasCardDef)
                    {
                        this.MergeCardDef(other.CardDef);
                    }
                    if (other.HasInsertDate)
                    {
                        this.MergeInsertDate(other.InsertDate);
                    }
                }
                return this;
            }

            public override BoosterCard.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(BoosterCard._boosterCardFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = BoosterCard._boosterCardFieldTags[index];
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
                            PegasusShared.CardDef.Builder builder = PegasusShared.CardDef.CreateBuilder();
                            if (this.result.hasCardDef)
                            {
                                builder.MergeFrom(this.CardDef);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.CardDef = builder.BuildPartial();
                            continue;
                        }
                        case 0x12:
                        {
                            Date.Builder builder2 = Date.CreateBuilder();
                            if (this.result.hasInsertDate)
                            {
                                builder2.MergeFrom(this.InsertDate);
                            }
                            input.ReadMessage(builder2, extensionRegistry);
                            this.InsertDate = builder2.BuildPartial();
                            continue;
                        }
                    }
                    if (WireFormat.IsEndGroupTag(num))
                    {
                        return this;
                    }
                    this.ParseUnknownField(input, extensionRegistry, num, str);
                }
                return this;
            }

            public BoosterCard.Builder MergeInsertDate(Date value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasInsertDate && (this.result.insertDate_ != Date.DefaultInstance))
                {
                    this.result.insertDate_ = Date.CreateBuilder(this.result.insertDate_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.insertDate_ = value;
                }
                this.result.hasInsertDate = true;
                return this;
            }

            private BoosterCard PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    BoosterCard result = this.result;
                    this.result = new BoosterCard();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public BoosterCard.Builder SetCardDef(PegasusShared.CardDef value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasCardDef = true;
                this.result.cardDef_ = value;
                return this;
            }

            public BoosterCard.Builder SetCardDef(PegasusShared.CardDef.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasCardDef = true;
                this.result.cardDef_ = builderForValue.Build();
                return this;
            }

            public BoosterCard.Builder SetInsertDate(Date value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasInsertDate = true;
                this.result.insertDate_ = value;
                return this;
            }

            public BoosterCard.Builder SetInsertDate(Date.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasInsertDate = true;
                this.result.insertDate_ = builderForValue.Build();
                return this;
            }

            public PegasusShared.CardDef CardDef
            {
                get
                {
                    return this.result.CardDef;
                }
                set
                {
                    this.SetCardDef(value);
                }
            }

            public override BoosterCard DefaultInstanceForType
            {
                get
                {
                    return BoosterCard.DefaultInstance;
                }
            }

            public bool HasCardDef
            {
                get
                {
                    return this.result.hasCardDef;
                }
            }

            public bool HasInsertDate
            {
                get
                {
                    return this.result.hasInsertDate;
                }
            }

            public Date InsertDate
            {
                get
                {
                    return this.result.InsertDate;
                }
                set
                {
                    this.SetInsertDate(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override BoosterCard MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override BoosterCard.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

