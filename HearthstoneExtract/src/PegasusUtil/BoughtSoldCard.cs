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
    public sealed class BoughtSoldCard : GeneratedMessageLite<BoughtSoldCard, Builder>
    {
        private static readonly string[] _boughtSoldCardFieldNames = new string[] { "amount", "def", "result" };
        private static readonly uint[] _boughtSoldCardFieldTags = new uint[] { 0x10, 10, 0x18 };
        private int amount_;
        public const int AmountFieldNumber = 2;
        private CardDef def_;
        private static readonly BoughtSoldCard defaultInstance = new BoughtSoldCard().MakeReadOnly();
        public const int DefFieldNumber = 1;
        private bool hasAmount;
        private bool hasDef;
        private bool hasResult;
        private int memoizedSerializedSize = -1;
        private PegasusUtil.BoughtSoldCard.Types.Result result_ = PegasusUtil.BoughtSoldCard.Types.Result.FAILED;
        public const int ResultFieldNumber = 3;

        static BoughtSoldCard()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private BoughtSoldCard()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(BoughtSoldCard prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            BoughtSoldCard card = obj as BoughtSoldCard;
            if (card == null)
            {
                return false;
            }
            if ((this.hasDef != card.hasDef) || (this.hasDef && !this.def_.Equals(card.def_)))
            {
                return false;
            }
            if ((this.hasAmount != card.hasAmount) || (this.hasAmount && !this.amount_.Equals(card.amount_)))
            {
                return false;
            }
            return ((this.hasResult == card.hasResult) && (!this.hasResult || this.result_.Equals(card.result_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasDef)
            {
                hashCode ^= this.def_.GetHashCode();
            }
            if (this.hasAmount)
            {
                hashCode ^= this.amount_.GetHashCode();
            }
            if (this.hasResult)
            {
                hashCode ^= this.result_.GetHashCode();
            }
            return hashCode;
        }

        private BoughtSoldCard MakeReadOnly()
        {
            return this;
        }

        public static BoughtSoldCard ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static BoughtSoldCard ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static BoughtSoldCard ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static BoughtSoldCard ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static BoughtSoldCard ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static BoughtSoldCard ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static BoughtSoldCard ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static BoughtSoldCard ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static BoughtSoldCard ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static BoughtSoldCard ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<BoughtSoldCard, Builder>.PrintField("def", this.hasDef, this.def_, writer);
            GeneratedMessageLite<BoughtSoldCard, Builder>.PrintField("amount", this.hasAmount, this.amount_, writer);
            GeneratedMessageLite<BoughtSoldCard, Builder>.PrintField("result", this.hasResult, this.result_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _boughtSoldCardFieldNames;
            if (this.hasDef)
            {
                output.WriteMessage(1, strArray[1], this.Def);
            }
            if (this.hasAmount)
            {
                output.WriteInt32(2, strArray[0], this.Amount);
            }
            if (this.hasResult)
            {
                output.WriteEnum(3, strArray[2], (int) this.Result, this.Result);
            }
        }

        public int Amount
        {
            get
            {
                return this.amount_;
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

        public static BoughtSoldCard DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override BoughtSoldCard DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasAmount
        {
            get
            {
                return this.hasAmount;
            }
        }

        public bool HasDef
        {
            get
            {
                return this.hasDef;
            }
        }

        public bool HasResult
        {
            get
            {
                return this.hasResult;
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
                if (!this.hasAmount)
                {
                    return false;
                }
                if (!this.hasResult)
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

        public PegasusUtil.BoughtSoldCard.Types.Result Result
        {
            get
            {
                return this.result_;
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
                    if (this.hasAmount)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.Amount);
                    }
                    if (this.hasResult)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeEnumSize(3, (int) this.Result);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override BoughtSoldCard ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<BoughtSoldCard, BoughtSoldCard.Builder>
        {
            private BoughtSoldCard result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = BoughtSoldCard.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(BoughtSoldCard cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override BoughtSoldCard BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override BoughtSoldCard.Builder Clear()
            {
                this.result = BoughtSoldCard.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public BoughtSoldCard.Builder ClearAmount()
            {
                this.PrepareBuilder();
                this.result.hasAmount = false;
                this.result.amount_ = 0;
                return this;
            }

            public BoughtSoldCard.Builder ClearDef()
            {
                this.PrepareBuilder();
                this.result.hasDef = false;
                this.result.def_ = null;
                return this;
            }

            public BoughtSoldCard.Builder ClearResult()
            {
                this.PrepareBuilder();
                this.result.hasResult = false;
                this.result.result_ = PegasusUtil.BoughtSoldCard.Types.Result.FAILED;
                return this;
            }

            public override BoughtSoldCard.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new BoughtSoldCard.Builder(this.result);
                }
                return new BoughtSoldCard.Builder().MergeFrom(this.result);
            }

            public BoughtSoldCard.Builder MergeDef(CardDef value)
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

            public override BoughtSoldCard.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override BoughtSoldCard.Builder MergeFrom(IMessageLite other)
            {
                if (other is BoughtSoldCard)
                {
                    return this.MergeFrom((BoughtSoldCard) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override BoughtSoldCard.Builder MergeFrom(BoughtSoldCard other)
            {
                if (other != BoughtSoldCard.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasDef)
                    {
                        this.MergeDef(other.Def);
                    }
                    if (other.HasAmount)
                    {
                        this.Amount = other.Amount;
                    }
                    if (other.HasResult)
                    {
                        this.Result = other.Result;
                    }
                }
                return this;
            }

            public override BoughtSoldCard.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    object obj2;
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(BoughtSoldCard._boughtSoldCardFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = BoughtSoldCard._boughtSoldCardFieldTags[index];
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
                        {
                            this.result.hasAmount = input.ReadInt32(ref this.result.amount_);
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
                    if (input.ReadEnum<PegasusUtil.BoughtSoldCard.Types.Result>(ref this.result.result_, out obj2))
                    {
                        this.result.hasResult = true;
                    }
                    else if (!(obj2 is int))
                    {
                        continue;
                    }
                }
                return this;
            }

            private BoughtSoldCard PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    BoughtSoldCard result = this.result;
                    this.result = new BoughtSoldCard();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public BoughtSoldCard.Builder SetAmount(int value)
            {
                this.PrepareBuilder();
                this.result.hasAmount = true;
                this.result.amount_ = value;
                return this;
            }

            public BoughtSoldCard.Builder SetDef(CardDef value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasDef = true;
                this.result.def_ = value;
                return this;
            }

            public BoughtSoldCard.Builder SetDef(CardDef.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasDef = true;
                this.result.def_ = builderForValue.Build();
                return this;
            }

            public BoughtSoldCard.Builder SetResult(PegasusUtil.BoughtSoldCard.Types.Result value)
            {
                this.PrepareBuilder();
                this.result.hasResult = true;
                this.result.result_ = value;
                return this;
            }

            public int Amount
            {
                get
                {
                    return this.result.Amount;
                }
                set
                {
                    this.SetAmount(value);
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

            public override BoughtSoldCard DefaultInstanceForType
            {
                get
                {
                    return BoughtSoldCard.DefaultInstance;
                }
            }

            public bool HasAmount
            {
                get
                {
                    return this.result.hasAmount;
                }
            }

            public bool HasDef
            {
                get
                {
                    return this.result.hasDef;
                }
            }

            public bool HasResult
            {
                get
                {
                    return this.result.hasResult;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override BoughtSoldCard MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public PegasusUtil.BoughtSoldCard.Types.Result Result
            {
                get
                {
                    return this.result.Result;
                }
                set
                {
                    this.SetResult(value);
                }
            }

            protected override BoughtSoldCard.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0x102
            }

            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum Result
            {
                BOUGHT = 3,
                FAILED = 1,
                SOLD = 2,
                SOULBOUND = 4
            }
        }
    }
}

