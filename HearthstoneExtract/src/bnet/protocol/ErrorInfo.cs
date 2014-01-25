namespace bnet.protocol
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class ErrorInfo : GeneratedMessageLite<ErrorInfo, Builder>
    {
        private static readonly string[] _errorInfoFieldNames = new string[] { "method_id", "object_address", "service_hash", "status" };
        private static readonly uint[] _errorInfoFieldTags = new uint[] { 0x20, 10, 0x18, 0x10 };
        private static readonly ErrorInfo defaultInstance = new ErrorInfo().MakeReadOnly();
        private bool hasMethodId;
        private bool hasObjectAddress;
        private bool hasServiceHash;
        private bool hasStatus;
        private int memoizedSerializedSize = -1;
        private uint methodId_;
        public const int MethodIdFieldNumber = 4;
        private bnet.protocol.ObjectAddress objectAddress_;
        public const int ObjectAddressFieldNumber = 1;
        private uint serviceHash_;
        public const int ServiceHashFieldNumber = 3;
        private uint status_;
        public const int StatusFieldNumber = 2;

        static ErrorInfo()
        {
            object.ReferenceEquals(Rpc.Descriptor, null);
        }

        private ErrorInfo()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ErrorInfo prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ErrorInfo info = obj as ErrorInfo;
            if (info == null)
            {
                return false;
            }
            if ((this.hasObjectAddress != info.hasObjectAddress) || (this.hasObjectAddress && !this.objectAddress_.Equals(info.objectAddress_)))
            {
                return false;
            }
            if ((this.hasStatus != info.hasStatus) || (this.hasStatus && !this.status_.Equals(info.status_)))
            {
                return false;
            }
            if ((this.hasServiceHash != info.hasServiceHash) || (this.hasServiceHash && !this.serviceHash_.Equals(info.serviceHash_)))
            {
                return false;
            }
            return ((this.hasMethodId == info.hasMethodId) && (!this.hasMethodId || this.methodId_.Equals(info.methodId_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasObjectAddress)
            {
                hashCode ^= this.objectAddress_.GetHashCode();
            }
            if (this.hasStatus)
            {
                hashCode ^= this.status_.GetHashCode();
            }
            if (this.hasServiceHash)
            {
                hashCode ^= this.serviceHash_.GetHashCode();
            }
            if (this.hasMethodId)
            {
                hashCode ^= this.methodId_.GetHashCode();
            }
            return hashCode;
        }

        private ErrorInfo MakeReadOnly()
        {
            return this;
        }

        public static ErrorInfo ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ErrorInfo ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ErrorInfo ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ErrorInfo ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ErrorInfo ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ErrorInfo ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ErrorInfo ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ErrorInfo ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ErrorInfo ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ErrorInfo ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ErrorInfo, Builder>.PrintField("object_address", this.hasObjectAddress, this.objectAddress_, writer);
            GeneratedMessageLite<ErrorInfo, Builder>.PrintField("status", this.hasStatus, this.status_, writer);
            GeneratedMessageLite<ErrorInfo, Builder>.PrintField("service_hash", this.hasServiceHash, this.serviceHash_, writer);
            GeneratedMessageLite<ErrorInfo, Builder>.PrintField("method_id", this.hasMethodId, this.methodId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _errorInfoFieldNames;
            if (this.hasObjectAddress)
            {
                output.WriteMessage(1, strArray[1], this.ObjectAddress);
            }
            if (this.hasStatus)
            {
                output.WriteUInt32(2, strArray[3], this.Status);
            }
            if (this.hasServiceHash)
            {
                output.WriteUInt32(3, strArray[2], this.ServiceHash);
            }
            if (this.hasMethodId)
            {
                output.WriteUInt32(4, strArray[0], this.MethodId);
            }
        }

        public static ErrorInfo DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ErrorInfo DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasMethodId
        {
            get
            {
                return this.hasMethodId;
            }
        }

        public bool HasObjectAddress
        {
            get
            {
                return this.hasObjectAddress;
            }
        }

        public bool HasServiceHash
        {
            get
            {
                return this.hasServiceHash;
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
                if (!this.hasObjectAddress)
                {
                    return false;
                }
                if (!this.hasStatus)
                {
                    return false;
                }
                if (!this.hasServiceHash)
                {
                    return false;
                }
                if (!this.hasMethodId)
                {
                    return false;
                }
                if (!this.ObjectAddress.IsInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        [CLSCompliant(false)]
        public uint MethodId
        {
            get
            {
                return this.methodId_;
            }
        }

        public bnet.protocol.ObjectAddress ObjectAddress
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.objectAddress_ != null)
                {
                    goto Label_0012;
                }
                return bnet.protocol.ObjectAddress.DefaultInstance;
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
                    if (this.hasObjectAddress)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.ObjectAddress);
                    }
                    if (this.hasStatus)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(2, this.Status);
                    }
                    if (this.hasServiceHash)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(3, this.ServiceHash);
                    }
                    if (this.hasMethodId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(4, this.MethodId);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        [CLSCompliant(false)]
        public uint ServiceHash
        {
            get
            {
                return this.serviceHash_;
            }
        }

        [CLSCompliant(false)]
        public uint Status
        {
            get
            {
                return this.status_;
            }
        }

        protected override ErrorInfo ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<ErrorInfo, ErrorInfo.Builder>
        {
            private ErrorInfo result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ErrorInfo.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ErrorInfo cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override ErrorInfo BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ErrorInfo.Builder Clear()
            {
                this.result = ErrorInfo.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ErrorInfo.Builder ClearMethodId()
            {
                this.PrepareBuilder();
                this.result.hasMethodId = false;
                this.result.methodId_ = 0;
                return this;
            }

            public ErrorInfo.Builder ClearObjectAddress()
            {
                this.PrepareBuilder();
                this.result.hasObjectAddress = false;
                this.result.objectAddress_ = null;
                return this;
            }

            public ErrorInfo.Builder ClearServiceHash()
            {
                this.PrepareBuilder();
                this.result.hasServiceHash = false;
                this.result.serviceHash_ = 0;
                return this;
            }

            public ErrorInfo.Builder ClearStatus()
            {
                this.PrepareBuilder();
                this.result.hasStatus = false;
                this.result.status_ = 0;
                return this;
            }

            public override ErrorInfo.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ErrorInfo.Builder(this.result);
                }
                return new ErrorInfo.Builder().MergeFrom(this.result);
            }

            public override ErrorInfo.Builder MergeFrom(ErrorInfo other)
            {
                if (other != ErrorInfo.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasObjectAddress)
                    {
                        this.MergeObjectAddress(other.ObjectAddress);
                    }
                    if (other.HasStatus)
                    {
                        this.Status = other.Status;
                    }
                    if (other.HasServiceHash)
                    {
                        this.ServiceHash = other.ServiceHash;
                    }
                    if (other.HasMethodId)
                    {
                        this.MethodId = other.MethodId;
                    }
                }
                return this;
            }

            public override ErrorInfo.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ErrorInfo.Builder MergeFrom(IMessageLite other)
            {
                if (other is ErrorInfo)
                {
                    return this.MergeFrom((ErrorInfo) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ErrorInfo.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ErrorInfo._errorInfoFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ErrorInfo._errorInfoFieldTags[index];
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
                            bnet.protocol.ObjectAddress.Builder builder = bnet.protocol.ObjectAddress.CreateBuilder();
                            if (this.result.hasObjectAddress)
                            {
                                builder.MergeFrom(this.ObjectAddress);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.ObjectAddress = builder.BuildPartial();
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasStatus = input.ReadUInt32(ref this.result.status_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasServiceHash = input.ReadUInt32(ref this.result.serviceHash_);
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
                    this.result.hasMethodId = input.ReadUInt32(ref this.result.methodId_);
                }
                return this;
            }

            public ErrorInfo.Builder MergeObjectAddress(bnet.protocol.ObjectAddress value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasObjectAddress && (this.result.objectAddress_ != bnet.protocol.ObjectAddress.DefaultInstance))
                {
                    this.result.objectAddress_ = bnet.protocol.ObjectAddress.CreateBuilder(this.result.objectAddress_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.objectAddress_ = value;
                }
                this.result.hasObjectAddress = true;
                return this;
            }

            private ErrorInfo PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ErrorInfo result = this.result;
                    this.result = new ErrorInfo();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public ErrorInfo.Builder SetMethodId(uint value)
            {
                this.PrepareBuilder();
                this.result.hasMethodId = true;
                this.result.methodId_ = value;
                return this;
            }

            public ErrorInfo.Builder SetObjectAddress(bnet.protocol.ObjectAddress value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasObjectAddress = true;
                this.result.objectAddress_ = value;
                return this;
            }

            public ErrorInfo.Builder SetObjectAddress(bnet.protocol.ObjectAddress.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasObjectAddress = true;
                this.result.objectAddress_ = builderForValue.Build();
                return this;
            }

            [CLSCompliant(false)]
            public ErrorInfo.Builder SetServiceHash(uint value)
            {
                this.PrepareBuilder();
                this.result.hasServiceHash = true;
                this.result.serviceHash_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public ErrorInfo.Builder SetStatus(uint value)
            {
                this.PrepareBuilder();
                this.result.hasStatus = true;
                this.result.status_ = value;
                return this;
            }

            public override ErrorInfo DefaultInstanceForType
            {
                get
                {
                    return ErrorInfo.DefaultInstance;
                }
            }

            public bool HasMethodId
            {
                get
                {
                    return this.result.hasMethodId;
                }
            }

            public bool HasObjectAddress
            {
                get
                {
                    return this.result.hasObjectAddress;
                }
            }

            public bool HasServiceHash
            {
                get
                {
                    return this.result.hasServiceHash;
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

            protected override ErrorInfo MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            [CLSCompliant(false)]
            public uint MethodId
            {
                get
                {
                    return this.result.MethodId;
                }
                set
                {
                    this.SetMethodId(value);
                }
            }

            public bnet.protocol.ObjectAddress ObjectAddress
            {
                get
                {
                    return this.result.ObjectAddress;
                }
                set
                {
                    this.SetObjectAddress(value);
                }
            }

            [CLSCompliant(false)]
            public uint ServiceHash
            {
                get
                {
                    return this.result.ServiceHash;
                }
                set
                {
                    this.SetServiceHash(value);
                }
            }

            [CLSCompliant(false)]
            public uint Status
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

            protected override ErrorInfo.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

