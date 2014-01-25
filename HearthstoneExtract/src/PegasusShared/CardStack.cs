namespace PegasusShared
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class CardStack : GeneratedMessageLite<CardStack, Builder>
    {
        private static readonly string[] _cardStackFieldNames = new string[] { "card_def", "count", "latest_insert_date", "num_seen" };
        private static readonly uint[] _cardStackFieldTags = new uint[] { 10, 0x18, 0x12, 0x20 };
        private PegasusShared.CardDef cardDef_;
        public const int CardDefFieldNumber = 1;
        private int count_;
        public const int CountFieldNumber = 3;
        private static readonly CardStack defaultInstance = new CardStack().MakeReadOnly();
        private bool hasCardDef;
        private bool hasCount;
        private bool hasLatestInsertDate;
        private bool hasNumSeen;
        private Date latestInsertDate_;
        public const int LatestInsertDateFieldNumber = 2;
        private int memoizedSerializedSize = -1;
        private int numSeen_;
        public const int NumSeenFieldNumber = 4;

        static CardStack()
        {
            object.ReferenceEquals(PegasusSharedlite.Descriptor, null);
        }

        private CardStack()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(CardStack prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            CardStack stack = obj as CardStack;
            if (stack == null)
            {
                return false;
            }
            if ((this.hasCardDef != stack.hasCardDef) || (this.hasCardDef && !this.cardDef_.Equals(stack.cardDef_)))
            {
                return false;
            }
            if ((this.hasLatestInsertDate != stack.hasLatestInsertDate) || (this.hasLatestInsertDate && !this.latestInsertDate_.Equals(stack.latestInsertDate_)))
            {
                return false;
            }
            if ((this.hasCount != stack.hasCount) || (this.hasCount && !this.count_.Equals(stack.count_)))
            {
                return false;
            }
            return ((this.hasNumSeen == stack.hasNumSeen) && (!this.hasNumSeen || this.numSeen_.Equals(stack.numSeen_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasCardDef)
            {
                hashCode ^= this.cardDef_.GetHashCode();
            }
            if (this.hasLatestInsertDate)
            {
                hashCode ^= this.latestInsertDate_.GetHashCode();
            }
            if (this.hasCount)
            {
                hashCode ^= this.count_.GetHashCode();
            }
            if (this.hasNumSeen)
            {
                hashCode ^= this.numSeen_.GetHashCode();
            }
            return hashCode;
        }

        private CardStack MakeReadOnly()
        {
            return this;
        }

        public static CardStack ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static CardStack ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static CardStack ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static CardStack ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static CardStack ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static CardStack ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static CardStack ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static CardStack ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static CardStack ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static CardStack ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<CardStack, Builder>.PrintField("card_def", this.hasCardDef, this.cardDef_, writer);
            GeneratedMessageLite<CardStack, Builder>.PrintField("latest_insert_date", this.hasLatestInsertDate, this.latestInsertDate_, writer);
            GeneratedMessageLite<CardStack, Builder>.PrintField("count", this.hasCount, this.count_, writer);
            GeneratedMessageLite<CardStack, Builder>.PrintField("num_seen", this.hasNumSeen, this.numSeen_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _cardStackFieldNames;
            if (this.hasCardDef)
            {
                output.WriteMessage(1, strArray[0], this.CardDef);
            }
            if (this.hasLatestInsertDate)
            {
                output.WriteMessage(2, strArray[2], this.LatestInsertDate);
            }
            if (this.hasCount)
            {
                output.WriteInt32(3, strArray[1], this.Count);
            }
            if (this.hasNumSeen)
            {
                output.WriteInt32(4, strArray[3], this.NumSeen);
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

        public int Count
        {
            get
            {
                return this.count_;
            }
        }

        public static CardStack DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override CardStack DefaultInstanceForType
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

        public bool HasCount
        {
            get
            {
                return this.hasCount;
            }
        }

        public bool HasLatestInsertDate
        {
            get
            {
                return this.hasLatestInsertDate;
            }
        }

        public bool HasNumSeen
        {
            get
            {
                return this.hasNumSeen;
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
                if (!this.hasLatestInsertDate)
                {
                    return false;
                }
                if (!this.hasCount)
                {
                    return false;
                }
                if (!this.hasNumSeen)
                {
                    return false;
                }
                if (!this.CardDef.IsInitialized)
                {
                    return false;
                }
                if (!this.LatestInsertDate.IsInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        public Date LatestInsertDate
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.latestInsertDate_ != null)
                {
                    goto Label_0012;
                }
                return Date.DefaultInstance;
            }
        }

        public int NumSeen
        {
            get
            {
                return this.numSeen_;
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
                    if (this.hasLatestInsertDate)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, this.LatestInsertDate);
                    }
                    if (this.hasCount)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(3, this.Count);
                    }
                    if (this.hasNumSeen)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(4, this.NumSeen);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override CardStack ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<CardStack, CardStack.Builder>
        {
            private CardStack result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = CardStack.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(CardStack cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override CardStack BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override CardStack.Builder Clear()
            {
                this.result = CardStack.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public CardStack.Builder ClearCardDef()
            {
                this.PrepareBuilder();
                this.result.hasCardDef = false;
                this.result.cardDef_ = null;
                return this;
            }

            public CardStack.Builder ClearCount()
            {
                this.PrepareBuilder();
                this.result.hasCount = false;
                this.result.count_ = 0;
                return this;
            }

            public CardStack.Builder ClearLatestInsertDate()
            {
                this.PrepareBuilder();
                this.result.hasLatestInsertDate = false;
                this.result.latestInsertDate_ = null;
                return this;
            }

            public CardStack.Builder ClearNumSeen()
            {
                this.PrepareBuilder();
                this.result.hasNumSeen = false;
                this.result.numSeen_ = 0;
                return this;
            }

            public override CardStack.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new CardStack.Builder(this.result);
                }
                return new CardStack.Builder().MergeFrom(this.result);
            }

            public CardStack.Builder MergeCardDef(PegasusShared.CardDef value)
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

            public override CardStack.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override CardStack.Builder MergeFrom(IMessageLite other)
            {
                if (other is CardStack)
                {
                    return this.MergeFrom((CardStack) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override CardStack.Builder MergeFrom(CardStack other)
            {
                if (other != CardStack.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasCardDef)
                    {
                        this.MergeCardDef(other.CardDef);
                    }
                    if (other.HasLatestInsertDate)
                    {
                        this.MergeLatestInsertDate(other.LatestInsertDate);
                    }
                    if (other.HasCount)
                    {
                        this.Count = other.Count;
                    }
                    if (other.HasNumSeen)
                    {
                        this.NumSeen = other.NumSeen;
                    }
                }
                return this;
            }

            public override CardStack.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(CardStack._cardStackFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = CardStack._cardStackFieldTags[index];
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
                            if (this.result.hasLatestInsertDate)
                            {
                                builder2.MergeFrom(this.LatestInsertDate);
                            }
                            input.ReadMessage(builder2, extensionRegistry);
                            this.LatestInsertDate = builder2.BuildPartial();
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasCount = input.ReadInt32(ref this.result.count_);
                            continue;
                        }
                        case 0x20:
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
                    this.result.hasNumSeen = input.ReadInt32(ref this.result.numSeen_);
                }
                return this;
            }

            public CardStack.Builder MergeLatestInsertDate(Date value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasLatestInsertDate && (this.result.latestInsertDate_ != Date.DefaultInstance))
                {
                    this.result.latestInsertDate_ = Date.CreateBuilder(this.result.latestInsertDate_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.latestInsertDate_ = value;
                }
                this.result.hasLatestInsertDate = true;
                return this;
            }

            private CardStack PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    CardStack result = this.result;
                    this.result = new CardStack();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public CardStack.Builder SetCardDef(PegasusShared.CardDef value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasCardDef = true;
                this.result.cardDef_ = value;
                return this;
            }

            public CardStack.Builder SetCardDef(PegasusShared.CardDef.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasCardDef = true;
                this.result.cardDef_ = builderForValue.Build();
                return this;
            }

            public CardStack.Builder SetCount(int value)
            {
                this.PrepareBuilder();
                this.result.hasCount = true;
                this.result.count_ = value;
                return this;
            }

            public CardStack.Builder SetLatestInsertDate(Date value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasLatestInsertDate = true;
                this.result.latestInsertDate_ = value;
                return this;
            }

            public CardStack.Builder SetLatestInsertDate(Date.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasLatestInsertDate = true;
                this.result.latestInsertDate_ = builderForValue.Build();
                return this;
            }

            public CardStack.Builder SetNumSeen(int value)
            {
                this.PrepareBuilder();
                this.result.hasNumSeen = true;
                this.result.numSeen_ = value;
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

            public int Count
            {
                get
                {
                    return this.result.Count;
                }
                set
                {
                    this.SetCount(value);
                }
            }

            public override CardStack DefaultInstanceForType
            {
                get
                {
                    return CardStack.DefaultInstance;
                }
            }

            public bool HasCardDef
            {
                get
                {
                    return this.result.hasCardDef;
                }
            }

            public bool HasCount
            {
                get
                {
                    return this.result.hasCount;
                }
            }

            public bool HasLatestInsertDate
            {
                get
                {
                    return this.result.hasLatestInsertDate;
                }
            }

            public bool HasNumSeen
            {
                get
                {
                    return this.result.hasNumSeen;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public Date LatestInsertDate
            {
                get
                {
                    return this.result.LatestInsertDate;
                }
                set
                {
                    this.SetLatestInsertDate(value);
                }
            }

            protected override CardStack MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int NumSeen
            {
                get
                {
                    return this.result.NumSeen;
                }
                set
                {
                    this.SetNumSeen(value);
                }
            }

            protected override CardStack.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

