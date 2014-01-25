namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class CardUseCount : GeneratedMessageLite<CardUseCount, Builder>
    {
        private static readonly string[] _cardUseCountFieldNames = new string[] { "asset", "count" };
        private static readonly uint[] _cardUseCountFieldTags = new uint[] { 8, 0x10 };
        private int asset_;
        public const int AssetFieldNumber = 1;
        private int count_;
        public const int CountFieldNumber = 2;
        private static readonly CardUseCount defaultInstance = new CardUseCount().MakeReadOnly();
        private bool hasAsset;
        private bool hasCount;
        private int memoizedSerializedSize = -1;

        static CardUseCount()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private CardUseCount()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(CardUseCount prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            CardUseCount count = obj as CardUseCount;
            if (count == null)
            {
                return false;
            }
            if ((this.hasAsset != count.hasAsset) || (this.hasAsset && !this.asset_.Equals(count.asset_)))
            {
                return false;
            }
            return ((this.hasCount == count.hasCount) && (!this.hasCount || this.count_.Equals(count.count_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasAsset)
            {
                hashCode ^= this.asset_.GetHashCode();
            }
            if (this.hasCount)
            {
                hashCode ^= this.count_.GetHashCode();
            }
            return hashCode;
        }

        private CardUseCount MakeReadOnly()
        {
            return this;
        }

        public static CardUseCount ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static CardUseCount ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static CardUseCount ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static CardUseCount ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static CardUseCount ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static CardUseCount ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static CardUseCount ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static CardUseCount ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static CardUseCount ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static CardUseCount ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<CardUseCount, Builder>.PrintField("asset", this.hasAsset, this.asset_, writer);
            GeneratedMessageLite<CardUseCount, Builder>.PrintField("count", this.hasCount, this.count_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _cardUseCountFieldNames;
            if (this.hasAsset)
            {
                output.WriteInt32(1, strArray[0], this.Asset);
            }
            if (this.hasCount)
            {
                output.WriteInt32(2, strArray[1], this.Count);
            }
        }

        public int Asset
        {
            get
            {
                return this.asset_;
            }
        }

        public int Count
        {
            get
            {
                return this.count_;
            }
        }

        public static CardUseCount DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override CardUseCount DefaultInstanceForType
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

        public bool HasCount
        {
            get
            {
                return this.hasCount;
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
                if (!this.hasCount)
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
                    if (this.hasAsset)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.Asset);
                    }
                    if (this.hasCount)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.Count);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override CardUseCount ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<CardUseCount, CardUseCount.Builder>
        {
            private CardUseCount result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = CardUseCount.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(CardUseCount cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override CardUseCount BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override CardUseCount.Builder Clear()
            {
                this.result = CardUseCount.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public CardUseCount.Builder ClearAsset()
            {
                this.PrepareBuilder();
                this.result.hasAsset = false;
                this.result.asset_ = 0;
                return this;
            }

            public CardUseCount.Builder ClearCount()
            {
                this.PrepareBuilder();
                this.result.hasCount = false;
                this.result.count_ = 0;
                return this;
            }

            public override CardUseCount.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new CardUseCount.Builder(this.result);
                }
                return new CardUseCount.Builder().MergeFrom(this.result);
            }

            public override CardUseCount.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override CardUseCount.Builder MergeFrom(IMessageLite other)
            {
                if (other is CardUseCount)
                {
                    return this.MergeFrom((CardUseCount) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override CardUseCount.Builder MergeFrom(CardUseCount other)
            {
                if (other != CardUseCount.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAsset)
                    {
                        this.Asset = other.Asset;
                    }
                    if (other.HasCount)
                    {
                        this.Count = other.Count;
                    }
                }
                return this;
            }

            public override CardUseCount.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(CardUseCount._cardUseCountFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = CardUseCount._cardUseCountFieldTags[index];
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
                    this.result.hasCount = input.ReadInt32(ref this.result.count_);
                }
                return this;
            }

            private CardUseCount PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    CardUseCount result = this.result;
                    this.result = new CardUseCount();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public CardUseCount.Builder SetAsset(int value)
            {
                this.PrepareBuilder();
                this.result.hasAsset = true;
                this.result.asset_ = value;
                return this;
            }

            public CardUseCount.Builder SetCount(int value)
            {
                this.PrepareBuilder();
                this.result.hasCount = true;
                this.result.count_ = value;
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

            public override CardUseCount DefaultInstanceForType
            {
                get
                {
                    return CardUseCount.DefaultInstance;
                }
            }

            public bool HasAsset
            {
                get
                {
                    return this.result.hasAsset;
                }
            }

            public bool HasCount
            {
                get
                {
                    return this.result.hasCount;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override CardUseCount MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override CardUseCount.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

