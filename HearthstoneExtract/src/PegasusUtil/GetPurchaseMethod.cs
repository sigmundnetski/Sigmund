namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class GetPurchaseMethod : GeneratedMessageLite<GetPurchaseMethod, Builder>
    {
        private static readonly string[] _getPurchaseMethodFieldNames = new string[] { "currency", "product", "quantity" };
        private static readonly uint[] _getPurchaseMethodFieldTags = new uint[] { 0x18, 8, 0x10 };
        private int currency_;
        public const int CurrencyFieldNumber = 3;
        private static readonly GetPurchaseMethod defaultInstance = new GetPurchaseMethod().MakeReadOnly();
        private bool hasCurrency;
        private bool hasProduct;
        private bool hasQuantity;
        private int memoizedSerializedSize = -1;
        private int product_;
        public const int ProductFieldNumber = 1;
        private int quantity_;
        public const int QuantityFieldNumber = 2;

        static GetPurchaseMethod()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private GetPurchaseMethod()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GetPurchaseMethod prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GetPurchaseMethod method = obj as GetPurchaseMethod;
            if (method == null)
            {
                return false;
            }
            if ((this.hasProduct != method.hasProduct) || (this.hasProduct && !this.product_.Equals(method.product_)))
            {
                return false;
            }
            if ((this.hasQuantity != method.hasQuantity) || (this.hasQuantity && !this.quantity_.Equals(method.quantity_)))
            {
                return false;
            }
            return ((this.hasCurrency == method.hasCurrency) && (!this.hasCurrency || this.currency_.Equals(method.currency_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasProduct)
            {
                hashCode ^= this.product_.GetHashCode();
            }
            if (this.hasQuantity)
            {
                hashCode ^= this.quantity_.GetHashCode();
            }
            if (this.hasCurrency)
            {
                hashCode ^= this.currency_.GetHashCode();
            }
            return hashCode;
        }

        private GetPurchaseMethod MakeReadOnly()
        {
            return this;
        }

        public static GetPurchaseMethod ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GetPurchaseMethod ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetPurchaseMethod ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GetPurchaseMethod ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GetPurchaseMethod ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GetPurchaseMethod ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GetPurchaseMethod ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GetPurchaseMethod ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetPurchaseMethod ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetPurchaseMethod ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GetPurchaseMethod, Builder>.PrintField("product", this.hasProduct, this.product_, writer);
            GeneratedMessageLite<GetPurchaseMethod, Builder>.PrintField("quantity", this.hasQuantity, this.quantity_, writer);
            GeneratedMessageLite<GetPurchaseMethod, Builder>.PrintField("currency", this.hasCurrency, this.currency_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _getPurchaseMethodFieldNames;
            if (this.hasProduct)
            {
                output.WriteInt32(1, strArray[1], this.Product);
            }
            if (this.hasQuantity)
            {
                output.WriteInt32(2, strArray[2], this.Quantity);
            }
            if (this.hasCurrency)
            {
                output.WriteInt32(3, strArray[0], this.Currency);
            }
        }

        public int Currency
        {
            get
            {
                return this.currency_;
            }
        }

        public static GetPurchaseMethod DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GetPurchaseMethod DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasCurrency
        {
            get
            {
                return this.hasCurrency;
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
                if (!this.hasProduct)
                {
                    return false;
                }
                if (!this.hasQuantity)
                {
                    return false;
                }
                if (!this.hasCurrency)
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
                    if (this.hasProduct)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.Product);
                    }
                    if (this.hasQuantity)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.Quantity);
                    }
                    if (this.hasCurrency)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(3, this.Currency);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override GetPurchaseMethod ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<GetPurchaseMethod, GetPurchaseMethod.Builder>
        {
            private GetPurchaseMethod result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GetPurchaseMethod.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GetPurchaseMethod cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override GetPurchaseMethod BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GetPurchaseMethod.Builder Clear()
            {
                this.result = GetPurchaseMethod.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GetPurchaseMethod.Builder ClearCurrency()
            {
                this.PrepareBuilder();
                this.result.hasCurrency = false;
                this.result.currency_ = 0;
                return this;
            }

            public GetPurchaseMethod.Builder ClearProduct()
            {
                this.PrepareBuilder();
                this.result.hasProduct = false;
                this.result.product_ = 0;
                return this;
            }

            public GetPurchaseMethod.Builder ClearQuantity()
            {
                this.PrepareBuilder();
                this.result.hasQuantity = false;
                this.result.quantity_ = 0;
                return this;
            }

            public override GetPurchaseMethod.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GetPurchaseMethod.Builder(this.result);
                }
                return new GetPurchaseMethod.Builder().MergeFrom(this.result);
            }

            public override GetPurchaseMethod.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GetPurchaseMethod.Builder MergeFrom(IMessageLite other)
            {
                if (other is GetPurchaseMethod)
                {
                    return this.MergeFrom((GetPurchaseMethod) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GetPurchaseMethod.Builder MergeFrom(GetPurchaseMethod other)
            {
                if (other != GetPurchaseMethod.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasProduct)
                    {
                        this.Product = other.Product;
                    }
                    if (other.HasQuantity)
                    {
                        this.Quantity = other.Quantity;
                    }
                    if (other.HasCurrency)
                    {
                        this.Currency = other.Currency;
                    }
                }
                return this;
            }

            public override GetPurchaseMethod.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GetPurchaseMethod._getPurchaseMethodFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GetPurchaseMethod._getPurchaseMethodFieldTags[index];
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
                            this.result.hasProduct = input.ReadInt32(ref this.result.product_);
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasQuantity = input.ReadInt32(ref this.result.quantity_);
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
                    this.result.hasCurrency = input.ReadInt32(ref this.result.currency_);
                }
                return this;
            }

            private GetPurchaseMethod PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GetPurchaseMethod result = this.result;
                    this.result = new GetPurchaseMethod();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public GetPurchaseMethod.Builder SetCurrency(int value)
            {
                this.PrepareBuilder();
                this.result.hasCurrency = true;
                this.result.currency_ = value;
                return this;
            }

            public GetPurchaseMethod.Builder SetProduct(int value)
            {
                this.PrepareBuilder();
                this.result.hasProduct = true;
                this.result.product_ = value;
                return this;
            }

            public GetPurchaseMethod.Builder SetQuantity(int value)
            {
                this.PrepareBuilder();
                this.result.hasQuantity = true;
                this.result.quantity_ = value;
                return this;
            }

            public int Currency
            {
                get
                {
                    return this.result.Currency;
                }
                set
                {
                    this.SetCurrency(value);
                }
            }

            public override GetPurchaseMethod DefaultInstanceForType
            {
                get
                {
                    return GetPurchaseMethod.DefaultInstance;
                }
            }

            public bool HasCurrency
            {
                get
                {
                    return this.result.hasCurrency;
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

            protected override GetPurchaseMethod MessageBeingBuilt
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

            protected override GetPurchaseMethod.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 250,
                System = 1
            }
        }
    }
}

