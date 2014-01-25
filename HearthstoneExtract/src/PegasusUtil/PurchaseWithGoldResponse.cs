namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class PurchaseWithGoldResponse : GeneratedMessageLite<PurchaseWithGoldResponse, Builder>
    {
        private static readonly string[] _purchaseWithGoldResponseFieldNames = new string[] { "gold_used", "result" };
        private static readonly uint[] _purchaseWithGoldResponseFieldTags = new uint[] { 0x10, 8 };
        private static readonly PurchaseWithGoldResponse defaultInstance = new PurchaseWithGoldResponse().MakeReadOnly();
        private long goldUsed_;
        public const int GoldUsedFieldNumber = 2;
        private bool hasGoldUsed;
        private bool hasResult;
        private int memoizedSerializedSize = -1;
        private Types.PurchaseResult result_ = Types.PurchaseResult.PR_SUCCESS;
        public const int ResultFieldNumber = 1;

        static PurchaseWithGoldResponse()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private PurchaseWithGoldResponse()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(PurchaseWithGoldResponse prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            PurchaseWithGoldResponse response = obj as PurchaseWithGoldResponse;
            if (response == null)
            {
                return false;
            }
            if ((this.hasResult != response.hasResult) || (this.hasResult && !this.result_.Equals(response.result_)))
            {
                return false;
            }
            return ((this.hasGoldUsed == response.hasGoldUsed) && (!this.hasGoldUsed || this.goldUsed_.Equals(response.goldUsed_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasResult)
            {
                hashCode ^= this.result_.GetHashCode();
            }
            if (this.hasGoldUsed)
            {
                hashCode ^= this.goldUsed_.GetHashCode();
            }
            return hashCode;
        }

        private PurchaseWithGoldResponse MakeReadOnly()
        {
            return this;
        }

        public static PurchaseWithGoldResponse ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static PurchaseWithGoldResponse ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static PurchaseWithGoldResponse ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PurchaseWithGoldResponse ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PurchaseWithGoldResponse ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PurchaseWithGoldResponse ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PurchaseWithGoldResponse ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static PurchaseWithGoldResponse ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PurchaseWithGoldResponse ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PurchaseWithGoldResponse ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<PurchaseWithGoldResponse, Builder>.PrintField("result", this.hasResult, this.result_, writer);
            GeneratedMessageLite<PurchaseWithGoldResponse, Builder>.PrintField("gold_used", this.hasGoldUsed, this.goldUsed_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _purchaseWithGoldResponseFieldNames;
            if (this.hasResult)
            {
                output.WriteEnum(1, strArray[1], (int) this.Result, this.Result);
            }
            if (this.hasGoldUsed)
            {
                output.WriteInt64(2, strArray[0], this.GoldUsed);
            }
        }

        public static PurchaseWithGoldResponse DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override PurchaseWithGoldResponse DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public long GoldUsed
        {
            get
            {
                return this.goldUsed_;
            }
        }

        public bool HasGoldUsed
        {
            get
            {
                return this.hasGoldUsed;
            }
        }

        public bool HasResult
        {
            get
            {
                return this.hasResult;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasResult)
                {
                    return false;
                }
                return true;
            }
        }

        public Types.PurchaseResult Result
        {
            get
            {
                return this.result_;
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
                    if (this.hasResult)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeEnumSize(1, (int) this.Result);
                    }
                    if (this.hasGoldUsed)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(2, this.GoldUsed);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override PurchaseWithGoldResponse ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<PurchaseWithGoldResponse, PurchaseWithGoldResponse.Builder>
        {
            private PurchaseWithGoldResponse result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = PurchaseWithGoldResponse.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(PurchaseWithGoldResponse cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override PurchaseWithGoldResponse BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override PurchaseWithGoldResponse.Builder Clear()
            {
                this.result = PurchaseWithGoldResponse.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public PurchaseWithGoldResponse.Builder ClearGoldUsed()
            {
                this.PrepareBuilder();
                this.result.hasGoldUsed = false;
                this.result.goldUsed_ = 0L;
                return this;
            }

            public PurchaseWithGoldResponse.Builder ClearResult()
            {
                this.PrepareBuilder();
                this.result.hasResult = false;
                this.result.result_ = PurchaseWithGoldResponse.Types.PurchaseResult.PR_SUCCESS;
                return this;
            }

            public override PurchaseWithGoldResponse.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new PurchaseWithGoldResponse.Builder(this.result);
                }
                return new PurchaseWithGoldResponse.Builder().MergeFrom(this.result);
            }

            public override PurchaseWithGoldResponse.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override PurchaseWithGoldResponse.Builder MergeFrom(IMessageLite other)
            {
                if (other is PurchaseWithGoldResponse)
                {
                    return this.MergeFrom((PurchaseWithGoldResponse) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override PurchaseWithGoldResponse.Builder MergeFrom(PurchaseWithGoldResponse other)
            {
                if (other != PurchaseWithGoldResponse.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasResult)
                    {
                        this.Result = other.Result;
                    }
                    if (other.HasGoldUsed)
                    {
                        this.GoldUsed = other.GoldUsed;
                    }
                }
                return this;
            }

            public override PurchaseWithGoldResponse.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(PurchaseWithGoldResponse._purchaseWithGoldResponseFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = PurchaseWithGoldResponse._purchaseWithGoldResponseFieldTags[index];
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
                            if (input.ReadEnum<PurchaseWithGoldResponse.Types.PurchaseResult>(ref this.result.result_, out obj2))
                            {
                                this.result.hasResult = true;
                            }
                            else if (obj2 is int)
                            {
                            }
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
                    this.result.hasGoldUsed = input.ReadInt64(ref this.result.goldUsed_);
                }
                return this;
            }

            private PurchaseWithGoldResponse PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    PurchaseWithGoldResponse result = this.result;
                    this.result = new PurchaseWithGoldResponse();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public PurchaseWithGoldResponse.Builder SetGoldUsed(long value)
            {
                this.PrepareBuilder();
                this.result.hasGoldUsed = true;
                this.result.goldUsed_ = value;
                return this;
            }

            public PurchaseWithGoldResponse.Builder SetResult(PurchaseWithGoldResponse.Types.PurchaseResult value)
            {
                this.PrepareBuilder();
                this.result.hasResult = true;
                this.result.result_ = value;
                return this;
            }

            public override PurchaseWithGoldResponse DefaultInstanceForType
            {
                get
                {
                    return PurchaseWithGoldResponse.DefaultInstance;
                }
            }

            public long GoldUsed
            {
                get
                {
                    return this.result.GoldUsed;
                }
                set
                {
                    this.SetGoldUsed(value);
                }
            }

            public bool HasGoldUsed
            {
                get
                {
                    return this.result.hasGoldUsed;
                }
            }

            public bool HasResult
            {
                get
                {
                    return this.result.hasResult;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override PurchaseWithGoldResponse MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public PurchaseWithGoldResponse.Types.PurchaseResult Result
            {
                get
                {
                    return this.result.Result;
                }
                set
                {
                    this.SetResult(value);
                }
            }

            protected override PurchaseWithGoldResponse.Builder ThisBuilder
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
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 280
            }

            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PurchaseResult
            {
                PR_FEATURE_NA = 4,
                PR_INSUFFICIENT_FUNDS = 2,
                PR_INVALID_QUANTITY = 5,
                PR_PRODUCT_NA = 3,
                PR_SUCCESS = 1
            }
        }
    }
}

