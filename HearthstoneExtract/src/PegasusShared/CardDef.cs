namespace PegasusShared
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class CardDef : GeneratedMessageLite<CardDef, Builder>
    {
        private static readonly string[] _cardDefFieldNames = new string[] { "asset", "premium" };
        private static readonly uint[] _cardDefFieldTags = new uint[] { 8, 0x10 };
        private int asset_;
        public const int AssetFieldNumber = 1;
        private static readonly CardDef defaultInstance = new CardDef().MakeReadOnly();
        private bool hasAsset;
        private bool hasPremium;
        private int memoizedSerializedSize = -1;
        private int premium_;
        public const int PremiumFieldNumber = 2;

        static CardDef()
        {
            object.ReferenceEquals(PegasusSharedlite.Descriptor, null);
        }

        private CardDef()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(CardDef prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            CardDef def = obj as CardDef;
            if (def == null)
            {
                return false;
            }
            if ((this.hasAsset != def.hasAsset) || (this.hasAsset && !this.asset_.Equals(def.asset_)))
            {
                return false;
            }
            return ((this.hasPremium == def.hasPremium) && (!this.hasPremium || this.premium_.Equals(def.premium_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasAsset)
            {
                hashCode ^= this.asset_.GetHashCode();
            }
            if (this.hasPremium)
            {
                hashCode ^= this.premium_.GetHashCode();
            }
            return hashCode;
        }

        private CardDef MakeReadOnly()
        {
            return this;
        }

        public static CardDef ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static CardDef ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static CardDef ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static CardDef ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static CardDef ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static CardDef ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static CardDef ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static CardDef ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static CardDef ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static CardDef ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<CardDef, Builder>.PrintField("asset", this.hasAsset, this.asset_, writer);
            GeneratedMessageLite<CardDef, Builder>.PrintField("premium", this.hasPremium, this.premium_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _cardDefFieldNames;
            if (this.hasAsset)
            {
                output.WriteInt32(1, strArray[0], this.Asset);
            }
            if (this.hasPremium)
            {
                output.WriteInt32(2, strArray[1], this.Premium);
            }
        }

        public int Asset
        {
            get
            {
                return this.asset_;
            }
        }

        public static CardDef DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override CardDef DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasAsset
        {
            get
            {
                return this.hasAsset;
            }
        }

        public bool HasPremium
        {
            get
            {
                return this.hasPremium;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasAsset)
                {
                    return false;
                }
                return true;
            }
        }

        public int Premium
        {
            get
            {
                return this.premium_;
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
                    if (this.hasAsset)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.Asset);
                    }
                    if (this.hasPremium)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.Premium);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override CardDef ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<CardDef, CardDef.Builder>
        {
            private CardDef result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = CardDef.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(CardDef cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override CardDef BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override CardDef.Builder Clear()
            {
                this.result = CardDef.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public CardDef.Builder ClearAsset()
            {
                this.PrepareBuilder();
                this.result.hasAsset = false;
                this.result.asset_ = 0;
                return this;
            }

            public CardDef.Builder ClearPremium()
            {
                this.PrepareBuilder();
                this.result.hasPremium = false;
                this.result.premium_ = 0;
                return this;
            }

            public override CardDef.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new CardDef.Builder(this.result);
                }
                return new CardDef.Builder().MergeFrom(this.result);
            }

            public override CardDef.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override CardDef.Builder MergeFrom(IMessageLite other)
            {
                if (other is CardDef)
                {
                    return this.MergeFrom((CardDef) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override CardDef.Builder MergeFrom(CardDef other)
            {
                if (other != CardDef.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAsset)
                    {
                        this.Asset = other.Asset;
                    }
                    if (other.HasPremium)
                    {
                        this.Premium = other.Premium;
                    }
                }
                return this;
            }

            public override CardDef.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(CardDef._cardDefFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = CardDef._cardDefFieldTags[index];
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
                            this.result.hasAsset = input.ReadInt32(ref this.result.asset_);
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
                    this.result.hasPremium = input.ReadInt32(ref this.result.premium_);
                }
                return this;
            }

            private CardDef PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    CardDef result = this.result;
                    this.result = new CardDef();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public CardDef.Builder SetAsset(int value)
            {
                this.PrepareBuilder();
                this.result.hasAsset = true;
                this.result.asset_ = value;
                return this;
            }

            public CardDef.Builder SetPremium(int value)
            {
                this.PrepareBuilder();
                this.result.hasPremium = true;
                this.result.premium_ = value;
                return this;
            }

            public int Asset
            {
                get
                {
                    return this.result.Asset;
                }
                set
                {
                    this.SetAsset(value);
                }
            }

            public override CardDef DefaultInstanceForType
            {
                get
                {
                    return CardDef.DefaultInstance;
                }
            }

            public bool HasAsset
            {
                get
                {
                    return this.result.hasAsset;
                }
            }

            public bool HasPremium
            {
                get
                {
                    return this.result.hasPremium;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override CardDef MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int Premium
            {
                get
                {
                    return this.result.Premium;
                }
                set
                {
                    this.SetPremium(value);
                }
            }

            protected override CardDef.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

