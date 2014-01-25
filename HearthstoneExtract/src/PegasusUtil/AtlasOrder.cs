namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class AtlasOrder : GeneratedMessageLite<AtlasOrder, Builder>
    {
        private static readonly string[] _atlasOrderFieldNames = new string[] { "data", "err_str", "first_data", "id", "order", "status", "type", "wallet" };
        private static readonly uint[] _atlasOrderFieldTags = new uint[] { 0x20, 0x42, 40, 8, 50, 0x18, 0x10, 0x38 };
        private long data_;
        public const int DataFieldNumber = 4;
        private static readonly AtlasOrder defaultInstance = new AtlasOrder().MakeReadOnly();
        private string errStr_ = string.Empty;
        public const int ErrStrFieldNumber = 8;
        private long firstData_;
        public const int FirstDataFieldNumber = 5;
        private bool hasData;
        private bool hasErrStr;
        private bool hasFirstData;
        private bool hasId;
        private bool hasOrder;
        private bool hasStatus;
        private bool hasType;
        private bool hasWallet;
        private long id_;
        public const int IdFieldNumber = 1;
        private int memoizedSerializedSize = -1;
        private string order_ = string.Empty;
        public const int OrderFieldNumber = 6;
        private int status_;
        public const int StatusFieldNumber = 3;
        private int type_;
        public const int TypeFieldNumber = 2;
        private long wallet_;
        public const int WalletFieldNumber = 7;

        static AtlasOrder()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AtlasOrder()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AtlasOrder prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AtlasOrder order = obj as AtlasOrder;
            if (order == null)
            {
                return false;
            }
            if ((this.hasId != order.hasId) || (this.hasId && !this.id_.Equals(order.id_)))
            {
                return false;
            }
            if ((this.hasType != order.hasType) || (this.hasType && !this.type_.Equals(order.type_)))
            {
                return false;
            }
            if ((this.hasStatus != order.hasStatus) || (this.hasStatus && !this.status_.Equals(order.status_)))
            {
                return false;
            }
            if ((this.hasData != order.hasData) || (this.hasData && !this.data_.Equals(order.data_)))
            {
                return false;
            }
            if ((this.hasFirstData != order.hasFirstData) || (this.hasFirstData && !this.firstData_.Equals(order.firstData_)))
            {
                return false;
            }
            if ((this.hasOrder != order.hasOrder) || (this.hasOrder && !this.order_.Equals(order.order_)))
            {
                return false;
            }
            if ((this.hasWallet != order.hasWallet) || (this.hasWallet && !this.wallet_.Equals(order.wallet_)))
            {
                return false;
            }
            return ((this.hasErrStr == order.hasErrStr) && (!this.hasErrStr || this.errStr_.Equals(order.errStr_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasId)
            {
                hashCode ^= this.id_.GetHashCode();
            }
            if (this.hasType)
            {
                hashCode ^= this.type_.GetHashCode();
            }
            if (this.hasStatus)
            {
                hashCode ^= this.status_.GetHashCode();
            }
            if (this.hasData)
            {
                hashCode ^= this.data_.GetHashCode();
            }
            if (this.hasFirstData)
            {
                hashCode ^= this.firstData_.GetHashCode();
            }
            if (this.hasOrder)
            {
                hashCode ^= this.order_.GetHashCode();
            }
            if (this.hasWallet)
            {
                hashCode ^= this.wallet_.GetHashCode();
            }
            if (this.hasErrStr)
            {
                hashCode ^= this.errStr_.GetHashCode();
            }
            return hashCode;
        }

        private AtlasOrder MakeReadOnly()
        {
            return this;
        }

        public static AtlasOrder ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AtlasOrder ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasOrder ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasOrder ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasOrder ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasOrder ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasOrder ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AtlasOrder ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasOrder ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasOrder ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AtlasOrder, Builder>.PrintField("id", this.hasId, this.id_, writer);
            GeneratedMessageLite<AtlasOrder, Builder>.PrintField("type", this.hasType, this.type_, writer);
            GeneratedMessageLite<AtlasOrder, Builder>.PrintField("status", this.hasStatus, this.status_, writer);
            GeneratedMessageLite<AtlasOrder, Builder>.PrintField("data", this.hasData, this.data_, writer);
            GeneratedMessageLite<AtlasOrder, Builder>.PrintField("first_data", this.hasFirstData, this.firstData_, writer);
            GeneratedMessageLite<AtlasOrder, Builder>.PrintField("order", this.hasOrder, this.order_, writer);
            GeneratedMessageLite<AtlasOrder, Builder>.PrintField("wallet", this.hasWallet, this.wallet_, writer);
            GeneratedMessageLite<AtlasOrder, Builder>.PrintField("err_str", this.hasErrStr, this.errStr_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _atlasOrderFieldNames;
            if (this.hasId)
            {
                output.WriteInt64(1, strArray[3], this.Id);
            }
            if (this.hasType)
            {
                output.WriteInt32(2, strArray[6], this.Type);
            }
            if (this.hasStatus)
            {
                output.WriteInt32(3, strArray[5], this.Status);
            }
            if (this.hasData)
            {
                output.WriteInt64(4, strArray[0], this.Data);
            }
            if (this.hasFirstData)
            {
                output.WriteInt64(5, strArray[2], this.FirstData);
            }
            if (this.hasOrder)
            {
                output.WriteString(6, strArray[4], this.Order);
            }
            if (this.hasWallet)
            {
                output.WriteInt64(7, strArray[7], this.Wallet);
            }
            if (this.hasErrStr)
            {
                output.WriteString(8, strArray[1], this.ErrStr);
            }
        }

        public long Data
        {
            get
            {
                return this.data_;
            }
        }

        public static AtlasOrder DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AtlasOrder DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public string ErrStr
        {
            get
            {
                return this.errStr_;
            }
        }

        public long FirstData
        {
            get
            {
                return this.firstData_;
            }
        }

        public bool HasData
        {
            get
            {
                return this.hasData;
            }
        }

        public bool HasErrStr
        {
            get
            {
                return this.hasErrStr;
            }
        }

        public bool HasFirstData
        {
            get
            {
                return this.hasFirstData;
            }
        }

        public bool HasId
        {
            get
            {
                return this.hasId;
            }
        }

        public bool HasOrder
        {
            get
            {
                return this.hasOrder;
            }
        }

        public bool HasStatus
        {
            get
            {
                return this.hasStatus;
            }
        }

        public bool HasType
        {
            get
            {
                return this.hasType;
            }
        }

        public bool HasWallet
        {
            get
            {
                return this.hasWallet;
            }
        }

        public long Id
        {
            get
            {
                return this.id_;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasId)
                {
                    return false;
                }
                if (!this.hasType)
                {
                    return false;
                }
                if (!this.hasStatus)
                {
                    return false;
                }
                if (!this.hasData)
                {
                    return false;
                }
                if (!this.hasFirstData)
                {
                    return false;
                }
                if (!this.hasOrder)
                {
                    return false;
                }
                if (!this.hasWallet)
                {
                    return false;
                }
                if (!this.hasErrStr)
                {
                    return false;
                }
                return true;
            }
        }

        public string Order
        {
            get
            {
                return this.order_;
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
                    if (this.hasId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(1, this.Id);
                    }
                    if (this.hasType)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.Type);
                    }
                    if (this.hasStatus)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(3, this.Status);
                    }
                    if (this.hasData)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(4, this.Data);
                    }
                    if (this.hasFirstData)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(5, this.FirstData);
                    }
                    if (this.hasOrder)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(6, this.Order);
                    }
                    if (this.hasWallet)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(7, this.Wallet);
                    }
                    if (this.hasErrStr)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(8, this.ErrStr);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        public int Status
        {
            get
            {
                return this.status_;
            }
        }

        protected override AtlasOrder ThisMessage
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

        public long Wallet
        {
            get
            {
                return this.wallet_;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<AtlasOrder, AtlasOrder.Builder>
        {
            private AtlasOrder result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AtlasOrder.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AtlasOrder cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override AtlasOrder BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AtlasOrder.Builder Clear()
            {
                this.result = AtlasOrder.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AtlasOrder.Builder ClearData()
            {
                this.PrepareBuilder();
                this.result.hasData = false;
                this.result.data_ = 0L;
                return this;
            }

            public AtlasOrder.Builder ClearErrStr()
            {
                this.PrepareBuilder();
                this.result.hasErrStr = false;
                this.result.errStr_ = string.Empty;
                return this;
            }

            public AtlasOrder.Builder ClearFirstData()
            {
                this.PrepareBuilder();
                this.result.hasFirstData = false;
                this.result.firstData_ = 0L;
                return this;
            }

            public AtlasOrder.Builder ClearId()
            {
                this.PrepareBuilder();
                this.result.hasId = false;
                this.result.id_ = 0L;
                return this;
            }

            public AtlasOrder.Builder ClearOrder()
            {
                this.PrepareBuilder();
                this.result.hasOrder = false;
                this.result.order_ = string.Empty;
                return this;
            }

            public AtlasOrder.Builder ClearStatus()
            {
                this.PrepareBuilder();
                this.result.hasStatus = false;
                this.result.status_ = 0;
                return this;
            }

            public AtlasOrder.Builder ClearType()
            {
                this.PrepareBuilder();
                this.result.hasType = false;
                this.result.type_ = 0;
                return this;
            }

            public AtlasOrder.Builder ClearWallet()
            {
                this.PrepareBuilder();
                this.result.hasWallet = false;
                this.result.wallet_ = 0L;
                return this;
            }

            public override AtlasOrder.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AtlasOrder.Builder(this.result);
                }
                return new AtlasOrder.Builder().MergeFrom(this.result);
            }

            public override AtlasOrder.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AtlasOrder.Builder MergeFrom(IMessageLite other)
            {
                if (other is AtlasOrder)
                {
                    return this.MergeFrom((AtlasOrder) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AtlasOrder.Builder MergeFrom(AtlasOrder other)
            {
                if (other != AtlasOrder.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasId)
                    {
                        this.Id = other.Id;
                    }
                    if (other.HasType)
                    {
                        this.Type = other.Type;
                    }
                    if (other.HasStatus)
                    {
                        this.Status = other.Status;
                    }
                    if (other.HasData)
                    {
                        this.Data = other.Data;
                    }
                    if (other.HasFirstData)
                    {
                        this.FirstData = other.FirstData;
                    }
                    if (other.HasOrder)
                    {
                        this.Order = other.Order;
                    }
                    if (other.HasWallet)
                    {
                        this.Wallet = other.Wallet;
                    }
                    if (other.HasErrStr)
                    {
                        this.ErrStr = other.ErrStr;
                    }
                }
                return this;
            }

            public override AtlasOrder.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AtlasOrder._atlasOrderFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AtlasOrder._atlasOrderFieldTags[index];
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
                            this.result.hasId = input.ReadInt64(ref this.result.id_);
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasType = input.ReadInt32(ref this.result.type_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasStatus = input.ReadInt32(ref this.result.status_);
                            continue;
                        }
                        case 0x20:
                        {
                            this.result.hasData = input.ReadInt64(ref this.result.data_);
                            continue;
                        }
                        case 40:
                        {
                            this.result.hasFirstData = input.ReadInt64(ref this.result.firstData_);
                            continue;
                        }
                        case 50:
                        {
                            this.result.hasOrder = input.ReadString(ref this.result.order_);
                            continue;
                        }
                        case 0x38:
                        {
                            this.result.hasWallet = input.ReadInt64(ref this.result.wallet_);
                            continue;
                        }
                        case 0x42:
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
                    this.result.hasErrStr = input.ReadString(ref this.result.errStr_);
                }
                return this;
            }

            private AtlasOrder PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AtlasOrder result = this.result;
                    this.result = new AtlasOrder();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public AtlasOrder.Builder SetData(long value)
            {
                this.PrepareBuilder();
                this.result.hasData = true;
                this.result.data_ = value;
                return this;
            }

            public AtlasOrder.Builder SetErrStr(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasErrStr = true;
                this.result.errStr_ = value;
                return this;
            }

            public AtlasOrder.Builder SetFirstData(long value)
            {
                this.PrepareBuilder();
                this.result.hasFirstData = true;
                this.result.firstData_ = value;
                return this;
            }

            public AtlasOrder.Builder SetId(long value)
            {
                this.PrepareBuilder();
                this.result.hasId = true;
                this.result.id_ = value;
                return this;
            }

            public AtlasOrder.Builder SetOrder(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasOrder = true;
                this.result.order_ = value;
                return this;
            }

            public AtlasOrder.Builder SetStatus(int value)
            {
                this.PrepareBuilder();
                this.result.hasStatus = true;
                this.result.status_ = value;
                return this;
            }

            public AtlasOrder.Builder SetType(int value)
            {
                this.PrepareBuilder();
                this.result.hasType = true;
                this.result.type_ = value;
                return this;
            }

            public AtlasOrder.Builder SetWallet(long value)
            {
                this.PrepareBuilder();
                this.result.hasWallet = true;
                this.result.wallet_ = value;
                return this;
            }

            public long Data
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

            public override AtlasOrder DefaultInstanceForType
            {
                get
                {
                    return AtlasOrder.DefaultInstance;
                }
            }

            public string ErrStr
            {
                get
                {
                    return this.result.ErrStr;
                }
                set
                {
                    this.SetErrStr(value);
                }
            }

            public long FirstData
            {
                get
                {
                    return this.result.FirstData;
                }
                set
                {
                    this.SetFirstData(value);
                }
            }

            public bool HasData
            {
                get
                {
                    return this.result.hasData;
                }
            }

            public bool HasErrStr
            {
                get
                {
                    return this.result.hasErrStr;
                }
            }

            public bool HasFirstData
            {
                get
                {
                    return this.result.hasFirstData;
                }
            }

            public bool HasId
            {
                get
                {
                    return this.result.hasId;
                }
            }

            public bool HasOrder
            {
                get
                {
                    return this.result.hasOrder;
                }
            }

            public bool HasStatus
            {
                get
                {
                    return this.result.hasStatus;
                }
            }

            public bool HasType
            {
                get
                {
                    return this.result.hasType;
                }
            }

            public bool HasWallet
            {
                get
                {
                    return this.result.hasWallet;
                }
            }

            public long Id
            {
                get
                {
                    return this.result.Id;
                }
                set
                {
                    this.SetId(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override AtlasOrder MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public string Order
            {
                get
                {
                    return this.result.Order;
                }
                set
                {
                    this.SetOrder(value);
                }
            }

            public int Status
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

            protected override AtlasOrder.Builder ThisBuilder
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

            public long Wallet
            {
                get
                {
                    return this.result.Wallet;
                }
                set
                {
                    this.SetWallet(value);
                }
            }
        }
    }
}

