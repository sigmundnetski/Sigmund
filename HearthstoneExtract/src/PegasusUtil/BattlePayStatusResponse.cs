namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class BattlePayStatusResponse : GeneratedMessageLite<BattlePayStatusResponse, Builder>
    {
        private static readonly string[] _battlePayStatusResponseFieldNames = new string[] { "battle_pay_available", "product_type", "purchase_error", "status" };
        private static readonly uint[] _battlePayStatusResponseFieldTags = new uint[] { 0x20, 0x10, 0x1a, 8 };
        private bool battlePayAvailable_;
        public const int BattlePayAvailableFieldNumber = 4;
        private static readonly BattlePayStatusResponse defaultInstance = new BattlePayStatusResponse().MakeReadOnly();
        private bool hasBattlePayAvailable;
        private bool hasProductType;
        private bool hasPurchaseError;
        private bool hasStatus;
        private int memoizedSerializedSize = -1;
        private int productType_;
        public const int ProductTypeFieldNumber = 2;
        private PegasusUtil.PurchaseError purchaseError_;
        public const int PurchaseErrorFieldNumber = 3;
        private Types.PurchaseState status_;
        public const int StatusFieldNumber = 1;

        static BattlePayStatusResponse()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private BattlePayStatusResponse()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(BattlePayStatusResponse prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            BattlePayStatusResponse response = obj as BattlePayStatusResponse;
            if (response == null)
            {
                return false;
            }
            if ((this.hasStatus != response.hasStatus) || (this.hasStatus && !this.status_.Equals(response.status_)))
            {
                return false;
            }
            if ((this.hasProductType != response.hasProductType) || (this.hasProductType && !this.productType_.Equals(response.productType_)))
            {
                return false;
            }
            if ((this.hasPurchaseError != response.hasPurchaseError) || (this.hasPurchaseError && !this.purchaseError_.Equals(response.purchaseError_)))
            {
                return false;
            }
            return ((this.hasBattlePayAvailable == response.hasBattlePayAvailable) && (!this.hasBattlePayAvailable || this.battlePayAvailable_.Equals(response.battlePayAvailable_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasStatus)
            {
                hashCode ^= this.status_.GetHashCode();
            }
            if (this.hasProductType)
            {
                hashCode ^= this.productType_.GetHashCode();
            }
            if (this.hasPurchaseError)
            {
                hashCode ^= this.purchaseError_.GetHashCode();
            }
            if (this.hasBattlePayAvailable)
            {
                hashCode ^= this.battlePayAvailable_.GetHashCode();
            }
            return hashCode;
        }

        private BattlePayStatusResponse MakeReadOnly()
        {
            return this;
        }

        public static BattlePayStatusResponse ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static BattlePayStatusResponse ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static BattlePayStatusResponse ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static BattlePayStatusResponse ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static BattlePayStatusResponse ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static BattlePayStatusResponse ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static BattlePayStatusResponse ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static BattlePayStatusResponse ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static BattlePayStatusResponse ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static BattlePayStatusResponse ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<BattlePayStatusResponse, Builder>.PrintField("status", this.hasStatus, this.status_, writer);
            GeneratedMessageLite<BattlePayStatusResponse, Builder>.PrintField("product_type", this.hasProductType, this.productType_, writer);
            GeneratedMessageLite<BattlePayStatusResponse, Builder>.PrintField("purchase_error", this.hasPurchaseError, this.purchaseError_, writer);
            GeneratedMessageLite<BattlePayStatusResponse, Builder>.PrintField("battle_pay_available", this.hasBattlePayAvailable, this.battlePayAvailable_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _battlePayStatusResponseFieldNames;
            if (this.hasStatus)
            {
                output.WriteEnum(1, strArray[3], (int) this.Status, this.Status);
            }
            if (this.hasProductType)
            {
                output.WriteInt32(2, strArray[1], this.ProductType);
            }
            if (this.hasPurchaseError)
            {
                output.WriteMessage(3, strArray[2], this.PurchaseError);
            }
            if (this.hasBattlePayAvailable)
            {
                output.WriteBool(4, strArray[0], this.BattlePayAvailable);
            }
        }

        public bool BattlePayAvailable
        {
            get
            {
                return this.battlePayAvailable_;
            }
        }

        public static BattlePayStatusResponse DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override BattlePayStatusResponse DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasBattlePayAvailable
        {
            get
            {
                return this.hasBattlePayAvailable;
            }
        }

        public bool HasProductType
        {
            get
            {
                return this.hasProductType;
            }
        }

        public bool HasPurchaseError
        {
            get
            {
                return this.hasPurchaseError;
            }
        }

        public bool HasStatus
        {
            get
            {
                return this.hasStatus;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasStatus)
                {
                    return false;
                }
                if (!this.hasBattlePayAvailable)
                {
                    return false;
                }
                if (this.HasPurchaseError && !this.PurchaseError.IsInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        public int ProductType
        {
            get
            {
                return this.productType_;
            }
        }

        public PegasusUtil.PurchaseError PurchaseError
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.purchaseError_ != null)
                {
                    goto Label_0012;
                }
                return PegasusUtil.PurchaseError.DefaultInstance;
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
                    if (this.hasStatus)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeEnumSize(1, (int) this.Status);
                    }
                    if (this.hasProductType)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.ProductType);
                    }
                    if (this.hasPurchaseError)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(3, this.PurchaseError);
                    }
                    if (this.hasBattlePayAvailable)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(4, this.BattlePayAvailable);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        public Types.PurchaseState Status
        {
            get
            {
                return this.status_;
            }
        }

        protected override BattlePayStatusResponse ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<BattlePayStatusResponse, BattlePayStatusResponse.Builder>
        {
            private BattlePayStatusResponse result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = BattlePayStatusResponse.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(BattlePayStatusResponse cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override BattlePayStatusResponse BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override BattlePayStatusResponse.Builder Clear()
            {
                this.result = BattlePayStatusResponse.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public BattlePayStatusResponse.Builder ClearBattlePayAvailable()
            {
                this.PrepareBuilder();
                this.result.hasBattlePayAvailable = false;
                this.result.battlePayAvailable_ = false;
                return this;
            }

            public BattlePayStatusResponse.Builder ClearProductType()
            {
                this.PrepareBuilder();
                this.result.hasProductType = false;
                this.result.productType_ = 0;
                return this;
            }

            public BattlePayStatusResponse.Builder ClearPurchaseError()
            {
                this.PrepareBuilder();
                this.result.hasPurchaseError = false;
                this.result.purchaseError_ = null;
                return this;
            }

            public BattlePayStatusResponse.Builder ClearStatus()
            {
                this.PrepareBuilder();
                this.result.hasStatus = false;
                this.result.status_ = BattlePayStatusResponse.Types.PurchaseState.PS_READY;
                return this;
            }

            public override BattlePayStatusResponse.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new BattlePayStatusResponse.Builder(this.result);
                }
                return new BattlePayStatusResponse.Builder().MergeFrom(this.result);
            }

            public override BattlePayStatusResponse.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override BattlePayStatusResponse.Builder MergeFrom(IMessageLite other)
            {
                if (other is BattlePayStatusResponse)
                {
                    return this.MergeFrom((BattlePayStatusResponse) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override BattlePayStatusResponse.Builder MergeFrom(BattlePayStatusResponse other)
            {
                if (other != BattlePayStatusResponse.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasStatus)
                    {
                        this.Status = other.Status;
                    }
                    if (other.HasProductType)
                    {
                        this.ProductType = other.ProductType;
                    }
                    if (other.HasPurchaseError)
                    {
                        this.MergePurchaseError(other.PurchaseError);
                    }
                    if (other.HasBattlePayAvailable)
                    {
                        this.BattlePayAvailable = other.BattlePayAvailable;
                    }
                }
                return this;
            }

            public override BattlePayStatusResponse.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(BattlePayStatusResponse._battlePayStatusResponseFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = BattlePayStatusResponse._battlePayStatusResponseFieldTags[index];
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
                            object obj2;
                            if (input.ReadEnum<BattlePayStatusResponse.Types.PurchaseState>(ref this.result.status_, out obj2))
                            {
                                this.result.hasStatus = true;
                            }
                            else if (obj2 is int)
                            {
                            }
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasProductType = input.ReadInt32(ref this.result.productType_);
                            continue;
                        }
                        case 0x1a:
                        {
                            PegasusUtil.PurchaseError.Builder builder = PegasusUtil.PurchaseError.CreateBuilder();
                            if (this.result.hasPurchaseError)
                            {
                                builder.MergeFrom(this.PurchaseError);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.PurchaseError = builder.BuildPartial();
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
                    this.result.hasBattlePayAvailable = input.ReadBool(ref this.result.battlePayAvailable_);
                }
                return this;
            }

            public BattlePayStatusResponse.Builder MergePurchaseError(PegasusUtil.PurchaseError value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasPurchaseError && (this.result.purchaseError_ != PegasusUtil.PurchaseError.DefaultInstance))
                {
                    this.result.purchaseError_ = PegasusUtil.PurchaseError.CreateBuilder(this.result.purchaseError_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.purchaseError_ = value;
                }
                this.result.hasPurchaseError = true;
                return this;
            }

            private BattlePayStatusResponse PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    BattlePayStatusResponse result = this.result;
                    this.result = new BattlePayStatusResponse();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public BattlePayStatusResponse.Builder SetBattlePayAvailable(bool value)
            {
                this.PrepareBuilder();
                this.result.hasBattlePayAvailable = true;
                this.result.battlePayAvailable_ = value;
                return this;
            }

            public BattlePayStatusResponse.Builder SetProductType(int value)
            {
                this.PrepareBuilder();
                this.result.hasProductType = true;
                this.result.productType_ = value;
                return this;
            }

            public BattlePayStatusResponse.Builder SetPurchaseError(PegasusUtil.PurchaseError value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasPurchaseError = true;
                this.result.purchaseError_ = value;
                return this;
            }

            public BattlePayStatusResponse.Builder SetPurchaseError(PegasusUtil.PurchaseError.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasPurchaseError = true;
                this.result.purchaseError_ = builderForValue.Build();
                return this;
            }

            public BattlePayStatusResponse.Builder SetStatus(BattlePayStatusResponse.Types.PurchaseState value)
            {
                this.PrepareBuilder();
                this.result.hasStatus = true;
                this.result.status_ = value;
                return this;
            }

            public bool BattlePayAvailable
            {
                get
                {
                    return this.result.BattlePayAvailable;
                }
                set
                {
                    this.SetBattlePayAvailable(value);
                }
            }

            public override BattlePayStatusResponse DefaultInstanceForType
            {
                get
                {
                    return BattlePayStatusResponse.DefaultInstance;
                }
            }

            public bool HasBattlePayAvailable
            {
                get
                {
                    return this.result.hasBattlePayAvailable;
                }
            }

            public bool HasProductType
            {
                get
                {
                    return this.result.hasProductType;
                }
            }

            public bool HasPurchaseError
            {
                get
                {
                    return this.result.hasPurchaseError;
                }
            }

            public bool HasStatus
            {
                get
                {
                    return this.result.hasStatus;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override BattlePayStatusResponse MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int ProductType
            {
                get
                {
                    return this.result.ProductType;
                }
                set
                {
                    this.SetProductType(value);
                }
            }

            public PegasusUtil.PurchaseError PurchaseError
            {
                get
                {
                    return this.result.PurchaseError;
                }
                set
                {
                    this.SetPurchaseError(value);
                }
            }

            public BattlePayStatusResponse.Types.PurchaseState Status
            {
                get
                {
                    return this.result.Status;
                }
                set
                {
                    this.SetStatus(value);
                }
            }

            protected override BattlePayStatusResponse.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0x109
            }

            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PurchaseState
            {
                PS_READY,
                PS_CHECK_RESULTS,
                PS_ERROR
            }
        }
    }
}

