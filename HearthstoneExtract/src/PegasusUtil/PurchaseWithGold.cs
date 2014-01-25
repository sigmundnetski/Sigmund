namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class PurchaseWithGold : GeneratedMessageLite<PurchaseWithGold, Builder>
    {
        private static readonly string[] _purchaseWithGoldFieldNames = new string[] { "data", "product", "quantity" };
        private static readonly uint[] _purchaseWithGoldFieldTags = new uint[] { 0x18, 0x10, 8 };
        private int data_;
        public const int DataFieldNumber = 3;
        private static readonly PurchaseWithGold defaultInstance = new PurchaseWithGold().MakeReadOnly();
        private bool hasData;
        private bool hasProduct;
        private bool hasQuantity;
        private int memoizedSerializedSize = -1;
        private int product_;
        public const int ProductFieldNumber = 2;
        private int quantity_;
        public const int QuantityFieldNumber = 1;

        static PurchaseWithGold()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private PurchaseWithGold()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(PurchaseWithGold prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            PurchaseWithGold gold = obj as PurchaseWithGold;
            if (gold == null)
            {
                return false;
            }
            if ((this.hasQuantity != gold.hasQuantity) || (this.hasQuantity && !this.quantity_.Equals(gold.quantity_)))
            {
                return false;
            }
            if ((this.hasProduct != gold.hasProduct) || (this.hasProduct && !this.product_.Equals(gold.product_)))
            {
                return false;
            }
            return ((this.hasData == gold.hasData) && (!this.hasData || this.data_.Equals(gold.data_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasQuantity)
            {
                hashCode ^= this.quantity_.GetHashCode();
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

        private PurchaseWithGold MakeReadOnly()
        {
            return this;
        }

        public static PurchaseWithGold ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static PurchaseWithGold ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static PurchaseWithGold ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PurchaseWithGold ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PurchaseWithGold ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PurchaseWithGold ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PurchaseWithGold ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static PurchaseWithGold ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PurchaseWithGold ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PurchaseWithGold ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<PurchaseWithGold, Builder>.PrintField("quantity", this.hasQuantity, this.quantity_, writer);
            GeneratedMessageLite<PurchaseWithGold, Builder>.PrintField("product", this.hasProduct, this.product_, writer);
            GeneratedMessageLite<PurchaseWithGold, Builder>.PrintField("data", this.hasData, this.data_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _purchaseWithGoldFieldNames;
            if (this.hasQuantity)
            {
                output.WriteInt32(1, strArray[2], this.Quantity);
            }
            if (this.hasProduct)
            {
                output.WriteInt32(2, strArray[1], this.Product);
            }
            if (this.hasData)
            {
                output.WriteInt32(3, strArray[0], this.Data);
            }
        }

        public int Data
        {
            get
            {
                return this.data_;
            }
        }

        public static PurchaseWithGold DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override PurchaseWithGold DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
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

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasQuantity)
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
                    if (this.hasQuantity)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.Quantity);
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

        protected override PurchaseWithGold ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<PurchaseWithGold, PurchaseWithGold.Builder>
        {
            private PurchaseWithGold result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = PurchaseWithGold.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(PurchaseWithGold cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override PurchaseWithGold BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override PurchaseWithGold.Builder Clear()
            {
                this.result = PurchaseWithGold.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public PurchaseWithGold.Builder ClearData()
            {
                this.PrepareBuilder();
                this.result.hasData = false;
                this.result.data_ = 0;
                return this;
            }

            public PurchaseWithGold.Builder ClearProduct()
            {
                this.PrepareBuilder();
                this.result.hasProduct = false;
                this.result.product_ = 0;
                return this;
            }

            public PurchaseWithGold.Builder ClearQuantity()
            {
                this.PrepareBuilder();
                this.result.hasQuantity = false;
                this.result.quantity_ = 0;
                return this;
            }

            public override PurchaseWithGold.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new PurchaseWithGold.Builder(this.result);
                }
                return new PurchaseWithGold.Builder().MergeFrom(this.result);
            }

            public override PurchaseWithGold.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override PurchaseWithGold.Builder MergeFrom(IMessageLite other)
            {
                if (other is PurchaseWithGold)
                {
                    return this.MergeFrom((PurchaseWithGold) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override PurchaseWithGold.Builder MergeFrom(PurchaseWithGold other)
            {
                if (other != PurchaseWithGold.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasQuantity)
                    {
                        this.Quantity = other.Quantity;
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

            public override PurchaseWithGold.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(PurchaseWithGold._purchaseWithGoldFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = PurchaseWithGold._purchaseWithGoldFieldTags[index];
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
                            this.result.hasQuantity = input.ReadInt32(ref this.result.quantity_);
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

            private PurchaseWithGold PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    PurchaseWithGold result = this.result;
                    this.result = new PurchaseWithGold();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public PurchaseWithGold.Builder SetData(int value)
            {
                this.PrepareBuilder();
                this.result.hasData = true;
                this.result.data_ = value;
                return this;
            }

            public PurchaseWithGold.Builder SetProduct(int value)
            {
                this.PrepareBuilder();
                this.result.hasProduct = true;
                this.result.product_ = value;
                return this;
            }

            public PurchaseWithGold.Builder SetQuantity(int value)
            {
                this.PrepareBuilder();
                this.result.hasQuantity = true;
                this.result.quantity_ = value;
                return this;
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

            public override PurchaseWithGold DefaultInstanceForType
            {
                get
                {
                    return PurchaseWithGold.DefaultInstance;
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

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override PurchaseWithGold MessageBeingBuilt
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

            protected override PurchaseWithGold.Builder ThisBuilder
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
                ID = 0x117,
                System = 0
            }
        }
    }
}

