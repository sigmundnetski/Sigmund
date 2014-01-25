namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class GoldPrice : GeneratedMessageLite<GoldPrice, Builder>
    {
        private static readonly string[] _goldPriceFieldNames = new string[] { "cost", "data", "product" };
        private static readonly uint[] _goldPriceFieldTags = new uint[] { 8, 0x18, 0x10 };
        private long cost_;
        public const int CostFieldNumber = 1;
        private int data_;
        public const int DataFieldNumber = 3;
        private static readonly GoldPrice defaultInstance = new GoldPrice().MakeReadOnly();
        private bool hasCost;
        private bool hasData;
        private bool hasProduct;
        private int memoizedSerializedSize = -1;
        private int product_;
        public const int ProductFieldNumber = 2;

        static GoldPrice()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private GoldPrice()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GoldPrice prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GoldPrice price = obj as GoldPrice;
            if (price == null)
            {
                return false;
            }
            if ((this.hasCost != price.hasCost) || (this.hasCost && !this.cost_.Equals(price.cost_)))
            {
                return false;
            }
            if ((this.hasProduct != price.hasProduct) || (this.hasProduct && !this.product_.Equals(price.product_)))
            {
                return false;
            }
            return ((this.hasData == price.hasData) && (!this.hasData || this.data_.Equals(price.data_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasCost)
            {
                hashCode ^= this.cost_.GetHashCode();
            }
            if (this.hasProduct)
            {
                hashCode ^= this.product_.GetHashCode();
            }
            if (this.hasData)
            {
                hashCode ^= this.data_.GetHashCode();
            }
            return hashCode;
        }

        private GoldPrice MakeReadOnly()
        {
            return this;
        }

        public static GoldPrice ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GoldPrice ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GoldPrice ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GoldPrice ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GoldPrice ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GoldPrice ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GoldPrice ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GoldPrice ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GoldPrice ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GoldPrice ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GoldPrice, Builder>.PrintField("cost", this.hasCost, this.cost_, writer);
            GeneratedMessageLite<GoldPrice, Builder>.PrintField("product", this.hasProduct, this.product_, writer);
            GeneratedMessageLite<GoldPrice, Builder>.PrintField("data", this.hasData, this.data_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _goldPriceFieldNames;
            if (this.hasCost)
            {
                output.WriteInt64(1, strArray[0], this.Cost);
            }
            if (this.hasProduct)
            {
                output.WriteInt32(2, strArray[2], this.Product);
            }
            if (this.hasData)
            {
                output.WriteInt32(3, strArray[1], this.Data);
            }
        }

        public long Cost
        {
            get
            {
                return this.cost_;
            }
        }

        public int Data
        {
            get
            {
                return this.data_;
            }
        }

        public static GoldPrice DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GoldPrice DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasCost
        {
            get
            {
                return this.hasCost;
            }
        }

        public bool HasData
        {
            get
            {
                return this.hasData;
            }
        }

        public bool HasProduct
        {
            get
            {
                return this.hasProduct;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasCost)
                {
                    return false;
                }
                if (!this.hasProduct)
                {
                    return false;
                }
                return true;
            }
        }

        public int Product
        {
            get
            {
                return this.product_;
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
                    if (this.hasCost)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(1, this.Cost);
                    }
                    if (this.hasProduct)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.Product);
                    }
                    if (this.hasData)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(3, this.Data);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override GoldPrice ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<GoldPrice, GoldPrice.Builder>
        {
            private GoldPrice result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GoldPrice.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GoldPrice cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override GoldPrice BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GoldPrice.Builder Clear()
            {
                this.result = GoldPrice.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GoldPrice.Builder ClearCost()
            {
                this.PrepareBuilder();
                this.result.hasCost = false;
                this.result.cost_ = 0L;
                return this;
            }

            public GoldPrice.Builder ClearData()
            {
                this.PrepareBuilder();
                this.result.hasData = false;
                this.result.data_ = 0;
                return this;
            }

            public GoldPrice.Builder ClearProduct()
            {
                this.PrepareBuilder();
                this.result.hasProduct = false;
                this.result.product_ = 0;
                return this;
            }

            public override GoldPrice.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GoldPrice.Builder(this.result);
                }
                return new GoldPrice.Builder().MergeFrom(this.result);
            }

            public override GoldPrice.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GoldPrice.Builder MergeFrom(IMessageLite other)
            {
                if (other is GoldPrice)
                {
                    return this.MergeFrom((GoldPrice) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GoldPrice.Builder MergeFrom(GoldPrice other)
            {
                if (other != GoldPrice.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasCost)
                    {
                        this.Cost = other.Cost;
                    }
                    if (other.HasProduct)
                    {
                        this.Product = other.Product;
                    }
                    if (other.HasData)
                    {
                        this.Data = other.Data;
                    }
                }
                return this;
            }

            public override GoldPrice.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GoldPrice._goldPriceFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GoldPrice._goldPriceFieldTags[index];
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
                            this.result.hasCost = input.ReadInt64(ref this.result.cost_);
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasProduct = input.ReadInt32(ref this.result.product_);
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
                    this.result.hasData = input.ReadInt32(ref this.result.data_);
                }
                return this;
            }

            private GoldPrice PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GoldPrice result = this.result;
                    this.result = new GoldPrice();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public GoldPrice.Builder SetCost(long value)
            {
                this.PrepareBuilder();
                this.result.hasCost = true;
                this.result.cost_ = value;
                return this;
            }

            public GoldPrice.Builder SetData(int value)
            {
                this.PrepareBuilder();
                this.result.hasData = true;
                this.result.data_ = value;
                return this;
            }

            public GoldPrice.Builder SetProduct(int value)
            {
                this.PrepareBuilder();
                this.result.hasProduct = true;
                this.result.product_ = value;
                return this;
            }

            public long Cost
            {
                get
                {
                    return this.result.Cost;
                }
                set
                {
                    this.SetCost(value);
                }
            }

            public int Data
            {
                get
                {
                    return this.result.Data;
                }
                set
                {
                    this.SetData(value);
                }
            }

            public override GoldPrice DefaultInstanceForType
            {
                get
                {
                    return GoldPrice.DefaultInstance;
                }
            }

            public bool HasCost
            {
                get
                {
                    return this.result.hasCost;
                }
            }

            public bool HasData
            {
                get
                {
                    return this.result.hasData;
                }
            }

            public bool HasProduct
            {
                get
                {
                    return this.result.hasProduct;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override GoldPrice MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int Product
            {
                get
                {
                    return this.result.Product;
                }
                set
                {
                    this.SetProduct(value);
                }
            }

            protected override GoldPrice.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

