namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class PurchaseResponse : GeneratedMessageLite<PurchaseResponse, Builder>
    {
        private static readonly string[] _purchaseResponseFieldNames = new string[] { "error" };
        private static readonly uint[] _purchaseResponseFieldTags = new uint[] { 10 };
        private static readonly PurchaseResponse defaultInstance = new PurchaseResponse().MakeReadOnly();
        private PurchaseError error_;
        public const int ErrorFieldNumber = 1;
        private bool hasError;
        private int memoizedSerializedSize = -1;

        static PurchaseResponse()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private PurchaseResponse()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(PurchaseResponse prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            PurchaseResponse response = obj as PurchaseResponse;
            if (response == null)
            {
                return false;
            }
            return ((this.hasError == response.hasError) && (!this.hasError || this.error_.Equals(response.error_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasError)
            {
                hashCode ^= this.error_.GetHashCode();
            }
            return hashCode;
        }

        private PurchaseResponse MakeReadOnly()
        {
            return this;
        }

        public static PurchaseResponse ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static PurchaseResponse ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static PurchaseResponse ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PurchaseResponse ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PurchaseResponse ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PurchaseResponse ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PurchaseResponse ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static PurchaseResponse ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PurchaseResponse ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PurchaseResponse ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<PurchaseResponse, Builder>.PrintField("error", this.hasError, this.error_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _purchaseResponseFieldNames;
            if (this.hasError)
            {
                output.WriteMessage(1, strArray[0], this.Error);
            }
        }

        public static PurchaseResponse DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override PurchaseResponse DefaultInstanceForType
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

        public bool HasError
        {
            get
            {
                return this.hasError;
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
                if (!this.Error.IsInitialized)
                {
                    return false;
                }
                return true;
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
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.Error);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override PurchaseResponse ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<PurchaseResponse, PurchaseResponse.Builder>
        {
            private PurchaseResponse result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = PurchaseResponse.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(PurchaseResponse cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override PurchaseResponse BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override PurchaseResponse.Builder Clear()
            {
                this.result = PurchaseResponse.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public PurchaseResponse.Builder ClearError()
            {
                this.PrepareBuilder();
                this.result.hasError = false;
                this.result.error_ = null;
                return this;
            }

            public override PurchaseResponse.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new PurchaseResponse.Builder(this.result);
                }
                return new PurchaseResponse.Builder().MergeFrom(this.result);
            }

            public PurchaseResponse.Builder MergeError(PurchaseError value)
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

            public override PurchaseResponse.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override PurchaseResponse.Builder MergeFrom(IMessageLite other)
            {
                if (other is PurchaseResponse)
                {
                    return this.MergeFrom((PurchaseResponse) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override PurchaseResponse.Builder MergeFrom(PurchaseResponse other)
            {
                if (other != PurchaseResponse.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasError)
                    {
                        this.MergeError(other.Error);
                    }
                }
                return this;
            }

            public override PurchaseResponse.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(PurchaseResponse._purchaseResponseFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = PurchaseResponse._purchaseResponseFieldTags[index];
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

                        case 10:
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

            private PurchaseResponse PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    PurchaseResponse result = this.result;
                    this.result = new PurchaseResponse();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public PurchaseResponse.Builder SetError(PurchaseError value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasError = true;
                this.result.error_ = value;
                return this;
            }

            public PurchaseResponse.Builder SetError(PurchaseError.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasError = true;
                this.result.error_ = builderForValue.Build();
                return this;
            }

            public override PurchaseResponse DefaultInstanceForType
            {
                get
                {
                    return PurchaseResponse.DefaultInstance;
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

            public bool HasError
            {
                get
                {
                    return this.result.hasError;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override PurchaseResponse MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override PurchaseResponse.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0x100
            }
        }
    }
}

