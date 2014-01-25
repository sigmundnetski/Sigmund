namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class PurchaseMethod : GeneratedMessageLite<PurchaseMethod, Builder>
    {
        private static readonly string[] _purchaseMethodFieldNames = new string[] { "currency", "error", "product", "quantity", "use_ebalance", "wallet_name" };
        private static readonly uint[] _purchaseMethodFieldTags = new uint[] { 0x18, 50, 8, 0x10, 40, 0x22 };
        private int currency_;
        public const int CurrencyFieldNumber = 3;
        private static readonly PurchaseMethod defaultInstance = new PurchaseMethod().MakeReadOnly();
        private PurchaseError error_;
        public const int ErrorFieldNumber = 6;
        private bool hasCurrency;
        private bool hasError;
        private bool hasProduct;
        private bool hasQuantity;
        private bool hasUseEbalance;
        private bool hasWalletName;
        private int memoizedSerializedSize = -1;
        private int product_;
        public const int ProductFieldNumber = 1;
        private int quantity_;
        public const int QuantityFieldNumber = 2;
        private bool useEbalance_;
        public const int UseEbalanceFieldNumber = 5;
        private string walletName_ = string.Empty;
        public const int WalletNameFieldNumber = 4;

        static PurchaseMethod()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private PurchaseMethod()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(PurchaseMethod prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            PurchaseMethod method = obj as PurchaseMethod;
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
            if ((this.hasCurrency != method.hasCurrency) || (this.hasCurrency && !this.currency_.Equals(method.currency_)))
            {
                return false;
            }
            if ((this.hasWalletName != method.hasWalletName) || (this.hasWalletName && !this.walletName_.Equals(method.walletName_)))
            {
                return false;
            }
            if ((this.hasUseEbalance != method.hasUseEbalance) || (this.hasUseEbalance && !this.useEbalance_.Equals(method.useEbalance_)))
            {
                return false;
            }
            return ((this.hasError == method.hasError) && (!this.hasError || this.error_.Equals(method.error_)));
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
            if (this.hasWalletName)
            {
                hashCode ^= this.walletName_.GetHashCode();
            }
            if (this.hasUseEbalance)
            {
                hashCode ^= this.useEbalance_.GetHashCode();
            }
            if (this.hasError)
            {
                hashCode ^= this.error_.GetHashCode();
            }
            return hashCode;
        }

        private PurchaseMethod MakeReadOnly()
        {
            return this;
        }

        public static PurchaseMethod ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static PurchaseMethod ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static PurchaseMethod ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PurchaseMethod ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PurchaseMethod ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PurchaseMethod ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PurchaseMethod ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static PurchaseMethod ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PurchaseMethod ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PurchaseMethod ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<PurchaseMethod, Builder>.PrintField("product", this.hasProduct, this.product_, writer);
            GeneratedMessageLite<PurchaseMethod, Builder>.PrintField("quantity", this.hasQuantity, this.quantity_, writer);
            GeneratedMessageLite<PurchaseMethod, Builder>.PrintField("currency", this.hasCurrency, this.currency_, writer);
            GeneratedMessageLite<PurchaseMethod, Builder>.PrintField("wallet_name", this.hasWalletName, this.walletName_, writer);
            GeneratedMessageLite<PurchaseMethod, Builder>.PrintField("use_ebalance", this.hasUseEbalance, this.useEbalance_, writer);
            GeneratedMessageLite<PurchaseMethod, Builder>.PrintField("error", this.hasError, this.error_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _purchaseMethodFieldNames;
            if (this.hasProduct)
            {
                output.WriteInt32(1, strArray[2], this.Product);
            }
            if (this.hasQuantity)
            {
                output.WriteInt32(2, strArray[3], this.Quantity);
            }
            if (this.hasCurrency)
            {
                output.WriteInt32(3, strArray[0], this.Currency);
            }
            if (this.hasWalletName)
            {
                output.WriteString(4, strArray[5], this.WalletName);
            }
            if (this.hasUseEbalance)
            {
                output.WriteBool(5, strArray[4], this.UseEbalance);
            }
            if (this.hasError)
            {
                output.WriteMessage(6, strArray[1], this.Error);
            }
        }

        public int Currency
        {
            get
            {
                return this.currency_;
            }
        }

        public static PurchaseMethod DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override PurchaseMethod DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public PurchaseError Error
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.error_ != null)
                {
                    goto Label_0012;
                }
                return PurchaseError.DefaultInstance;
            }
        }

        public bool HasCurrency
        {
            get
            {
                return this.hasCurrency;
            }
        }

        public bool HasError
        {
            get
            {
                return this.hasError;
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

        public bool HasUseEbalance
        {
            get
            {
                return this.hasUseEbalance;
            }
        }

        public bool HasWalletName
        {
            get
            {
                return this.hasWalletName;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (this.HasError && !this.Error.IsInitialized)
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
                    if (this.hasWalletName)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(4, this.WalletName);
                    }
                    if (this.hasUseEbalance)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(5, this.UseEbalance);
                    }
                    if (this.hasError)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(6, this.Error);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override PurchaseMethod ThisMessage
        {
            get
            {
                return this;
            }
        }

        public bool UseEbalance
        {
            get
            {
                return this.useEbalance_;
            }
        }

        public string WalletName
        {
            get
            {
                return this.walletName_;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<PurchaseMethod, PurchaseMethod.Builder>
        {
            private PurchaseMethod result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = PurchaseMethod.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(PurchaseMethod cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override PurchaseMethod BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override PurchaseMethod.Builder Clear()
            {
                this.result = PurchaseMethod.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public PurchaseMethod.Builder ClearCurrency()
            {
                this.PrepareBuilder();
                this.result.hasCurrency = false;
                this.result.currency_ = 0;
                return this;
            }

            public PurchaseMethod.Builder ClearError()
            {
                this.PrepareBuilder();
                this.result.hasError = false;
                this.result.error_ = null;
                return this;
            }

            public PurchaseMethod.Builder ClearProduct()
            {
                this.PrepareBuilder();
                this.result.hasProduct = false;
                this.result.product_ = 0;
                return this;
            }

            public PurchaseMethod.Builder ClearQuantity()
            {
                this.PrepareBuilder();
                this.result.hasQuantity = false;
                this.result.quantity_ = 0;
                return this;
            }

            public PurchaseMethod.Builder ClearUseEbalance()
            {
                this.PrepareBuilder();
                this.result.hasUseEbalance = false;
                this.result.useEbalance_ = false;
                return this;
            }

            public PurchaseMethod.Builder ClearWalletName()
            {
                this.PrepareBuilder();
                this.result.hasWalletName = false;
                this.result.walletName_ = string.Empty;
                return this;
            }

            public override PurchaseMethod.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new PurchaseMethod.Builder(this.result);
                }
                return new PurchaseMethod.Builder().MergeFrom(this.result);
            }

            public PurchaseMethod.Builder MergeError(PurchaseError value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasError && (this.result.error_ != PurchaseError.DefaultInstance))
                {
                    this.result.error_ = PurchaseError.CreateBuilder(this.result.error_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.error_ = value;
                }
                this.result.hasError = true;
                return this;
            }

            public override PurchaseMethod.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override PurchaseMethod.Builder MergeFrom(IMessageLite other)
            {
                if (other is PurchaseMethod)
                {
                    return this.MergeFrom((PurchaseMethod) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override PurchaseMethod.Builder MergeFrom(PurchaseMethod other)
            {
                if (other != PurchaseMethod.DefaultInstance)
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
                    if (other.HasWalletName)
                    {
                        this.WalletName = other.WalletName;
                    }
                    if (other.HasUseEbalance)
                    {
                        this.UseEbalance = other.UseEbalance;
                    }
                    if (other.HasError)
                    {
                        this.MergeError(other.Error);
                    }
                }
                return this;
            }

            public override PurchaseMethod.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(PurchaseMethod._purchaseMethodFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = PurchaseMethod._purchaseMethodFieldTags[index];
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
                        {
                            this.result.hasCurrency = input.ReadInt32(ref this.result.currency_);
                            continue;
                        }
                        case 0x22:
                        {
                            this.result.hasWalletName = input.ReadString(ref this.result.walletName_);
                            continue;
                        }
                        case 40:
                        {
                            this.result.hasUseEbalance = input.ReadBool(ref this.result.useEbalance_);
                            continue;
                        }
                        case 50:
                        {
                            PurchaseError.Builder builder = PurchaseError.CreateBuilder();
                            if (this.result.hasError)
                            {
                                builder.MergeFrom(this.Error);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.Error = builder.BuildPartial();
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

            private PurchaseMethod PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    PurchaseMethod result = this.result;
                    this.result = new PurchaseMethod();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public PurchaseMethod.Builder SetCurrency(int value)
            {
                this.PrepareBuilder();
                this.result.hasCurrency = true;
                this.result.currency_ = value;
                return this;
            }

            public PurchaseMethod.Builder SetError(PurchaseError value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasError = true;
                this.result.error_ = value;
                return this;
            }

            public PurchaseMethod.Builder SetError(PurchaseError.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasError = true;
                this.result.error_ = builderForValue.Build();
                return this;
            }

            public PurchaseMethod.Builder SetProduct(int value)
            {
                this.PrepareBuilder();
                this.result.hasProduct = true;
                this.result.product_ = value;
                return this;
            }

            public PurchaseMethod.Builder SetQuantity(int value)
            {
                this.PrepareBuilder();
                this.result.hasQuantity = true;
                this.result.quantity_ = value;
                return this;
            }

            public PurchaseMethod.Builder SetUseEbalance(bool value)
            {
                this.PrepareBuilder();
                this.result.hasUseEbalance = true;
                this.result.useEbalance_ = value;
                return this;
            }

            public PurchaseMethod.Builder SetWalletName(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasWalletName = true;
                this.result.walletName_ = value;
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

            public override PurchaseMethod DefaultInstanceForType
            {
                get
                {
                    return PurchaseMethod.DefaultInstance;
                }
            }

            public PurchaseError Error
            {
                get
                {
                    return this.result.Error;
                }
                set
                {
                    this.SetError(value);
                }
            }

            public bool HasCurrency
            {
                get
                {
                    return this.result.hasCurrency;
                }
            }

            public bool HasError
            {
                get
                {
                    return this.result.hasError;
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

            public bool HasUseEbalance
            {
                get
                {
                    return this.result.hasUseEbalance;
                }
            }

            public bool HasWalletName
            {
                get
                {
                    return this.result.hasWalletName;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override PurchaseMethod MessageBeingBuilt
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

            protected override PurchaseMethod.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public bool UseEbalance
            {
                get
                {
                    return this.result.UseEbalance;
                }
                set
                {
                    this.SetUseEbalance(value);
                }
            }

            public string WalletName
            {
                get
                {
                    return this.result.WalletName;
                }
                set
                {
                    this.SetWalletName(value);
                }
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0x110
            }
        }
    }
}

