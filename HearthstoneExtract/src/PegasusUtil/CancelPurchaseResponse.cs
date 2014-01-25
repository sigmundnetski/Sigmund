namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class CancelPurchaseResponse : GeneratedMessageLite<CancelPurchaseResponse, Builder>
    {
        private static readonly string[] _cancelPurchaseResponseFieldNames = new string[] { "result" };
        private static readonly uint[] _cancelPurchaseResponseFieldTags = new uint[] { 8 };
        private static readonly CancelPurchaseResponse defaultInstance = new CancelPurchaseResponse().MakeReadOnly();
        private bool hasResult;
        private int memoizedSerializedSize = -1;
        private Types.CancelResult result_ = Types.CancelResult.CR_SUCCESS;
        public const int ResultFieldNumber = 1;

        static CancelPurchaseResponse()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private CancelPurchaseResponse()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(CancelPurchaseResponse prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            CancelPurchaseResponse response = obj as CancelPurchaseResponse;
            if (response == null)
            {
                return false;
            }
            return ((this.hasResult == response.hasResult) && (!this.hasResult || this.result_.Equals(response.result_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasResult)
            {
                hashCode ^= this.result_.GetHashCode();
            }
            return hashCode;
        }

        private CancelPurchaseResponse MakeReadOnly()
        {
            return this;
        }

        public static CancelPurchaseResponse ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static CancelPurchaseResponse ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static CancelPurchaseResponse ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static CancelPurchaseResponse ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static CancelPurchaseResponse ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static CancelPurchaseResponse ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static CancelPurchaseResponse ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static CancelPurchaseResponse ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static CancelPurchaseResponse ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static CancelPurchaseResponse ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<CancelPurchaseResponse, Builder>.PrintField("result", this.hasResult, this.result_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _cancelPurchaseResponseFieldNames;
            if (this.hasResult)
            {
                output.WriteEnum(1, strArray[0], (int) this.Result, this.Result);
            }
        }

        public static CancelPurchaseResponse DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override CancelPurchaseResponse DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
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

        public Types.CancelResult Result
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
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override CancelPurchaseResponse ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<CancelPurchaseResponse, CancelPurchaseResponse.Builder>
        {
            private CancelPurchaseResponse result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = CancelPurchaseResponse.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(CancelPurchaseResponse cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override CancelPurchaseResponse BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override CancelPurchaseResponse.Builder Clear()
            {
                this.result = CancelPurchaseResponse.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public CancelPurchaseResponse.Builder ClearResult()
            {
                this.PrepareBuilder();
                this.result.hasResult = false;
                this.result.result_ = CancelPurchaseResponse.Types.CancelResult.CR_SUCCESS;
                return this;
            }

            public override CancelPurchaseResponse.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new CancelPurchaseResponse.Builder(this.result);
                }
                return new CancelPurchaseResponse.Builder().MergeFrom(this.result);
            }

            public override CancelPurchaseResponse.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override CancelPurchaseResponse.Builder MergeFrom(IMessageLite other)
            {
                if (other is CancelPurchaseResponse)
                {
                    return this.MergeFrom((CancelPurchaseResponse) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override CancelPurchaseResponse.Builder MergeFrom(CancelPurchaseResponse other)
            {
                if (other != CancelPurchaseResponse.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasResult)
                    {
                        this.Result = other.Result;
                    }
                }
                return this;
            }

            public override CancelPurchaseResponse.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    object obj2;
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(CancelPurchaseResponse._cancelPurchaseResponseFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = CancelPurchaseResponse._cancelPurchaseResponseFieldTags[index];
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
                    if (input.ReadEnum<CancelPurchaseResponse.Types.CancelResult>(ref this.result.result_, out obj2))
                    {
                        this.result.hasResult = true;
                    }
                    else if (!(obj2 is int))
                    {
                        continue;
                    }
                }
                return this;
            }

            private CancelPurchaseResponse PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    CancelPurchaseResponse result = this.result;
                    this.result = new CancelPurchaseResponse();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public CancelPurchaseResponse.Builder SetResult(CancelPurchaseResponse.Types.CancelResult value)
            {
                this.PrepareBuilder();
                this.result.hasResult = true;
                this.result.result_ = value;
                return this;
            }

            public override CancelPurchaseResponse DefaultInstanceForType
            {
                get
                {
                    return CancelPurchaseResponse.DefaultInstance;
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

            protected override CancelPurchaseResponse MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public CancelPurchaseResponse.Types.CancelResult Result
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

            protected override CancelPurchaseResponse.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum CancelResult
            {
                CR_NOT_ALLOWED = 2,
                CR_NOTHING_TO_CANCEL = 3,
                CR_SUCCESS = 1
            }

            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0x113
            }
        }
    }
}

