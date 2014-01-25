namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class Bundle : GeneratedMessageLite<Bundle, Builder>
    {
        private static readonly string[] _bundleFieldNames = new string[] { "cost", "data", "product", "quantity", "type" };
        private static readonly uint[] _bundleFieldTags = new uint[] { 0x29, 0x18, 0x10, 0x20, 8 };
        private double cost_;
        public const int CostFieldNumber = 5;
        private int data_;
        public const int DataFieldNumber = 3;
        private static readonly Bundle defaultInstance = new Bundle().MakeReadOnly();
        private bool hasCost;
        private bool hasData;
        private bool hasProduct;
        private bool hasQuantity;
        private bool hasType;
        private int memoizedSerializedSize = -1;
        private int product_;
        public const int ProductFieldNumber = 2;
        private int quantity_;
        public const int QuantityFieldNumber = 4;
        private int type_;
        public const int TypeFieldNumber = 1;

        static Bundle()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private Bundle()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(Bundle prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            Bundle bundle = obj as Bundle;
            if (bundle == null)
            {
                return false;
            }
            if ((this.hasType != bundle.hasType) || (this.hasType && !this.type_.Equals(bundle.type_)))
            {
                return false;
            }
            if ((this.hasProduct != bundle.hasProduct) || (this.hasProduct && !this.product_.Equals(bundle.product_)))
            {
                return false;
            }
            if ((this.hasData != bundle.hasData) || (this.hasData && !this.data_.Equals(bundle.data_)))
            {
                return false;
            }
            if ((this.hasQuantity != bundle.hasQuantity) || (this.hasQuantity && !this.quantity_.Equals(bundle.quantity_)))
            {
                return false;
            }
            return ((this.hasCost == bundle.hasCost) && (!this.hasCost || this.cost_.Equals(bundle.cost_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasType)
            {
                hashCode ^= this.type_.GetHashCode();
            }
            if (this.hasProduct)
            {
                hashCode ^= this.product_.GetHashCode();
            }
            if (this.hasData)
            {
                hashCode ^= this.data_.GetHashCode();
            }
            if (this.hasQuantity)
            {
                hashCode ^= this.quantity_.GetHashCode();
            }
            if (this.hasCost)
            {
                hashCode ^= this.cost_.GetHashCode();
            }
            return hashCode;
        }

        private Bundle MakeReadOnly()
        {
            return this;
        }

        public static Bundle ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static Bundle ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static Bundle ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Bundle ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Bundle ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Bundle ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Bundle ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static Bundle ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Bundle ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Bundle ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<Bundle, Builder>.PrintField("type", this.hasType, this.type_, writer);
            GeneratedMessageLite<Bundle, Builder>.PrintField("product", this.hasProduct, this.product_, writer);
            GeneratedMessageLite<Bundle, Builder>.PrintField("data", this.hasData, this.data_, writer);
            GeneratedMessageLite<Bundle, Builder>.PrintField("quantity", this.hasQuantity, this.quantity_, writer);
            GeneratedMessageLite<Bundle, Builder>.PrintField("cost", this.hasCost, this.cost_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _bundleFieldNames;
            if (this.hasType)
            {
                output.WriteInt32(1, strArray[4], this.Type);
            }
            if (this.hasProduct)
            {
                output.WriteInt32(2, strArray[2], this.Product);
            }
            if (this.hasData)
            {
                output.WriteInt32(3, strArray[1], this.Data);
            }
            if (this.hasQuantity)
            {
                output.WriteInt32(4, strArray[3], this.Quantity);
            }
            if (this.hasCost)
            {
                output.WriteDouble(5, strArray[0], this.Cost);
            }
        }

        public double Cost
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

        public static Bundle DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override Bundle DefaultInstanceForType
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

        public bool HasQuantity
        {
            get
            {
                return this.hasQuantity;
            }
        }

        public bool HasType
        {
            get
            {
                return this.hasType;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasType)
                {
                    return false;
                }
                if (!this.hasProduct)
                {
                    return false;
                }
                if (!this.hasData)
                {
                    return false;
                }
                if (!this.hasQuantity)
                {
                    return false;
                }
                if (!this.hasCost)
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

        public int Quantity
        {
            get
            {
                return this.quantity_;
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
                    if (this.hasType)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.Type);
                    }
                    if (this.hasProduct)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.Product);
                    }
                    if (this.hasData)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(3, this.Data);
                    }
                    if (this.hasQuantity)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(4, this.Quantity);
                    }
                    if (this.hasCost)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeDoubleSize(5, this.Cost);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override Bundle ThisMessage
        {
            get
            {
                return this;
            }
        }

        public int Type
        {
            get
            {
                return this.type_;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<Bundle, Bundle.Builder>
        {
            private Bundle result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = Bundle.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(Bundle cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override Bundle BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override Bundle.Builder Clear()
            {
                this.result = Bundle.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public Bundle.Builder ClearCost()
            {
                this.PrepareBuilder();
                this.result.hasCost = false;
                this.result.cost_ = 0.0;
                return this;
            }

            public Bundle.Builder ClearData()
            {
                this.PrepareBuilder();
                this.result.hasData = false;
                this.result.data_ = 0;
                return this;
            }

            public Bundle.Builder ClearProduct()
            {
                this.PrepareBuilder();
                this.result.hasProduct = false;
                this.result.product_ = 0;
                return this;
            }

            public Bundle.Builder ClearQuantity()
            {
                this.PrepareBuilder();
                this.result.hasQuantity = false;
                this.result.quantity_ = 0;
                return this;
            }

            public Bundle.Builder ClearType()
            {
                this.PrepareBuilder();
                this.result.hasType = false;
                this.result.type_ = 0;
                return this;
            }

            public override Bundle.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new Bundle.Builder(this.result);
                }
                return new Bundle.Builder().MergeFrom(this.result);
            }

            public override Bundle.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override Bundle.Builder MergeFrom(IMessageLite other)
            {
                if (other is Bundle)
                {
                    return this.MergeFrom((Bundle) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override Bundle.Builder MergeFrom(Bundle other)
            {
                if (other != Bundle.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasType)
                    {
                        this.Type = other.Type;
                    }
                    if (other.HasProduct)
                    {
                        this.Product = other.Product;
                    }
                    if (other.HasData)
                    {
                        this.Data = other.Data;
                    }
                    if (other.HasQuantity)
                    {
                        this.Quantity = other.Quantity;
                    }
                    if (other.HasCost)
                    {
                        this.Cost = other.Cost;
                    }
                }
                return this;
            }

            public override Bundle.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(Bundle._bundleFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = Bundle._bundleFieldTags[index];
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
                            this.result.hasType = input.ReadInt32(ref this.result.type_);
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasProduct = input.ReadInt32(ref this.result.product_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasData = input.ReadInt32(ref this.result.data_);
                            continue;
                        }
                        case 0x20:
                        {
                            this.result.hasQuantity = input.ReadInt32(ref this.result.quantity_);
                            continue;
                        }
                        case 0x29:
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
                    this.result.hasCost = input.ReadDouble(ref this.result.cost_);
                }
                return this;
            }

            private Bundle PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    Bundle result = this.result;
                    this.result = new Bundle();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public Bundle.Builder SetCost(double value)
            {
                this.PrepareBuilder();
                this.result.hasCost = true;
                this.result.cost_ = value;
                return this;
            }

            public Bundle.Builder SetData(int value)
            {
                this.PrepareBuilder();
                this.result.hasData = true;
                this.result.data_ = value;
                return this;
            }

            public Bundle.Builder SetProduct(int value)
            {
                this.PrepareBuilder();
                this.result.hasProduct = true;
                this.result.product_ = value;
                return this;
            }

            public Bundle.Builder SetQuantity(int value)
            {
                this.PrepareBuilder();
                this.result.hasQuantity = true;
                this.result.quantity_ = value;
                return this;
            }

            public Bundle.Builder SetType(int value)
            {
                this.PrepareBuilder();
                this.result.hasType = true;
                this.result.type_ = value;
                return this;
            }

            public double Cost
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

            public override Bundle DefaultInstanceForType
            {
                get
                {
                    return Bundle.DefaultInstance;
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

            public bool HasQuantity
            {
                get
                {
                    return this.result.hasQuantity;
                }
            }

            public bool HasType
            {
                get
                {
                    return this.result.hasType;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override Bundle MessageBeingBuilt
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

            public int Quantity
            {
                get
                {
                    return this.result.Quantity;
                }
                set
                {
                    this.SetQuantity(value);
                }
            }

            protected override Bundle.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public int Type
            {
                get
                {
                    return this.result.Type;
                }
                set
                {
                    this.SetType(value);
                }
            }
        }
    }
}

