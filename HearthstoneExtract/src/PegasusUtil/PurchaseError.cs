namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class PurchaseError : GeneratedMessageLite<PurchaseError, Builder>
    {
        private static readonly string[] _purchaseErrorFieldNames = new string[] { "error", "error_code", "purchase_in_progress" };
        private static readonly uint[] _purchaseErrorFieldTags = new uint[] { 8, 0x1a, 0x10 };
        private static readonly PurchaseError defaultInstance = new PurchaseError().MakeReadOnly();
        private PegasusUtil.PurchaseError.Types.Error error_ = PegasusUtil.PurchaseError.Types.Error.E_UNKNOWN;
        private string errorCode_ = string.Empty;
        public const int ErrorCodeFieldNumber = 3;
        public const int ErrorFieldNumber = 1;
        private bool hasError;
        private bool hasErrorCode;
        private bool hasPurchaseInProgress;
        private int memoizedSerializedSize = -1;
        private int purchaseInProgress_;
        public const int PurchaseInProgressFieldNumber = 2;

        static PurchaseError()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private PurchaseError()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(PurchaseError prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            PurchaseError error = obj as PurchaseError;
            if (error == null)
            {
                return false;
            }
            if ((this.hasError != error.hasError) || (this.hasError && !this.error_.Equals(error.error_)))
            {
                return false;
            }
            if ((this.hasPurchaseInProgress != error.hasPurchaseInProgress) || (this.hasPurchaseInProgress && !this.purchaseInProgress_.Equals(error.purchaseInProgress_)))
            {
                return false;
            }
            return ((this.hasErrorCode == error.hasErrorCode) && (!this.hasErrorCode || this.errorCode_.Equals(error.errorCode_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasError)
            {
                hashCode ^= this.error_.GetHashCode();
            }
            if (this.hasPurchaseInProgress)
            {
                hashCode ^= this.purchaseInProgress_.GetHashCode();
            }
            if (this.hasErrorCode)
            {
                hashCode ^= this.errorCode_.GetHashCode();
            }
            return hashCode;
        }

        private PurchaseError MakeReadOnly()
        {
            return this;
        }

        public static PurchaseError ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static PurchaseError ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static PurchaseError ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PurchaseError ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PurchaseError ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PurchaseError ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PurchaseError ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static PurchaseError ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PurchaseError ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PurchaseError ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<PurchaseError, Builder>.PrintField("error", this.hasError, this.error_, writer);
            GeneratedMessageLite<PurchaseError, Builder>.PrintField("purchase_in_progress", this.hasPurchaseInProgress, this.purchaseInProgress_, writer);
            GeneratedMessageLite<PurchaseError, Builder>.PrintField("error_code", this.hasErrorCode, this.errorCode_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _purchaseErrorFieldNames;
            if (this.hasError)
            {
                output.WriteEnum(1, strArray[0], (int) this.Error, this.Error);
            }
            if (this.hasPurchaseInProgress)
            {
                output.WriteInt32(2, strArray[2], this.PurchaseInProgress);
            }
            if (this.hasErrorCode)
            {
                output.WriteString(3, strArray[1], this.ErrorCode);
            }
        }

        public static PurchaseError DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override PurchaseError DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public PegasusUtil.PurchaseError.Types.Error Error
        {
            get
            {
                return this.error_;
            }
        }

        public string ErrorCode
        {
            get
            {
                return this.errorCode_;
            }
        }

        public bool HasError
        {
            get
            {
                return this.hasError;
            }
        }

        public bool HasErrorCode
        {
            get
            {
                return this.hasErrorCode;
            }
        }

        public bool HasPurchaseInProgress
        {
            get
            {
                return this.hasPurchaseInProgress;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasError)
                {
                    return false;
                }
                return true;
            }
        }

        public int PurchaseInProgress
        {
            get
            {
                return this.purchaseInProgress_;
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
                    if (this.hasError)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeEnumSize(1, (int) this.Error);
                    }
                    if (this.hasPurchaseInProgress)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.PurchaseInProgress);
                    }
                    if (this.hasErrorCode)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(3, this.ErrorCode);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override PurchaseError ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<PurchaseError, PurchaseError.Builder>
        {
            private PurchaseError result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = PurchaseError.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(PurchaseError cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override PurchaseError BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override PurchaseError.Builder Clear()
            {
                this.result = PurchaseError.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public PurchaseError.Builder ClearError()
            {
                this.PrepareBuilder();
                this.result.hasError = false;
                this.result.error_ = PegasusUtil.PurchaseError.Types.Error.E_UNKNOWN;
                return this;
            }

            public PurchaseError.Builder ClearErrorCode()
            {
                this.PrepareBuilder();
                this.result.hasErrorCode = false;
                this.result.errorCode_ = string.Empty;
                return this;
            }

            public PurchaseError.Builder ClearPurchaseInProgress()
            {
                this.PrepareBuilder();
                this.result.hasPurchaseInProgress = false;
                this.result.purchaseInProgress_ = 0;
                return this;
            }

            public override PurchaseError.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new PurchaseError.Builder(this.result);
                }
                return new PurchaseError.Builder().MergeFrom(this.result);
            }

            public override PurchaseError.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override PurchaseError.Builder MergeFrom(IMessageLite other)
            {
                if (other is PurchaseError)
                {
                    return this.MergeFrom((PurchaseError) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override PurchaseError.Builder MergeFrom(PurchaseError other)
            {
                if (other != PurchaseError.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasError)
                    {
                        this.Error = other.Error;
                    }
                    if (other.HasPurchaseInProgress)
                    {
                        this.PurchaseInProgress = other.PurchaseInProgress;
                    }
                    if (other.HasErrorCode)
                    {
                        this.ErrorCode = other.ErrorCode;
                    }
                }
                return this;
            }

            public override PurchaseError.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(PurchaseError._purchaseErrorFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = PurchaseError._purchaseErrorFieldTags[index];
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
                            if (input.ReadEnum<PegasusUtil.PurchaseError.Types.Error>(ref this.result.error_, out obj2))
                            {
                                this.result.hasError = true;
                            }
                            else if (obj2 is int)
                            {
                            }
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasPurchaseInProgress = input.ReadInt32(ref this.result.purchaseInProgress_);
                            continue;
                        }
                        case 0x1a:
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
                    this.result.hasErrorCode = input.ReadString(ref this.result.errorCode_);
                }
                return this;
            }

            private PurchaseError PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    PurchaseError result = this.result;
                    this.result = new PurchaseError();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public PurchaseError.Builder SetError(PegasusUtil.PurchaseError.Types.Error value)
            {
                this.PrepareBuilder();
                this.result.hasError = true;
                this.result.error_ = value;
                return this;
            }

            public PurchaseError.Builder SetErrorCode(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasErrorCode = true;
                this.result.errorCode_ = value;
                return this;
            }

            public PurchaseError.Builder SetPurchaseInProgress(int value)
            {
                this.PrepareBuilder();
                this.result.hasPurchaseInProgress = true;
                this.result.purchaseInProgress_ = value;
                return this;
            }

            public override PurchaseError DefaultInstanceForType
            {
                get
                {
                    return PurchaseError.DefaultInstance;
                }
            }

            public PegasusUtil.PurchaseError.Types.Error Error
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

            public string ErrorCode
            {
                get
                {
                    return this.result.ErrorCode;
                }
                set
                {
                    this.SetErrorCode(value);
                }
            }

            public bool HasError
            {
                get
                {
                    return this.result.hasError;
                }
            }

            public bool HasErrorCode
            {
                get
                {
                    return this.result.hasErrorCode;
                }
            }

            public bool HasPurchaseInProgress
            {
                get
                {
                    return this.result.hasPurchaseInProgress;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override PurchaseError MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int PurchaseInProgress
            {
                get
                {
                    return this.result.PurchaseInProgress;
                }
                set
                {
                    this.SetPurchaseInProgress(value);
                }
            }

            protected override PurchaseError.Builder ThisBuilder
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
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum Error
            {
                E_BP_GENERIC_FAIL = 100,
                E_BP_INVALID_CC_EXPIRY = 0x65,
                E_BP_NO_VALID_PAYMENT = 0x67,
                E_BP_PAYMENT_AUTH = 0x68,
                E_BP_PROVIDER_DENIED = 0x69,
                E_BP_RISK_ERROR = 0x66,
                E_CANCELED = 11,
                E_DATABASE = 5,
                E_DUPLICATE_LICENSE = 7,
                E_FAILED_RISK = 10,
                E_INVALID_BNET = 2,
                E_INVALID_QUANTITY = 6,
                E_NO_ACTIVE_BPAY = 9,
                E_PRODUCT_NA = 15,
                E_PURCHASE_IN_PROGRESS = 4,
                E_REQUEST_NOT_SENT = 8,
                E_RISK_TIMEOUT = 0x10,
                E_SERVICE_NA = 3,
                E_STILL_IN_PROGRESS = 1,
                E_SUCCESS = 0,
                E_UNKNOWN = -1,
                E_WAIT_CLIENT_CONFIRM = 13,
                E_WAIT_CLIENT_RISK = 14,
                E_WAIT_MOP = 12
            }
        }
    }
}

