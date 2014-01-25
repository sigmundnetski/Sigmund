namespace bnet.protocol
{
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class Header : GeneratedMessageLite<Header, Builder>
    {
        private static readonly string[] _headerFieldNames = new string[] { "error", "method_id", "object_id", "service_id", "size", "status", "token" };
        private static readonly uint[] _headerFieldTags = new uint[] { 0x3a, 0x10, 0x20, 8, 40, 0x30, 0x18 };
        private static readonly Header defaultInstance = new Header().MakeReadOnly();
        private PopsicleList<ErrorInfo> error_ = new PopsicleList<ErrorInfo>();
        public const int ErrorFieldNumber = 7;
        private bool hasMethodId;
        private bool hasObjectId;
        private bool hasServiceId;
        private bool hasSize;
        private bool hasStatus;
        private bool hasToken;
        private int memoizedSerializedSize = -1;
        private uint methodId_;
        public const int MethodIdFieldNumber = 2;
        private ulong objectId_;
        public const int ObjectIdFieldNumber = 4;
        private uint serviceId_;
        public const int ServiceIdFieldNumber = 1;
        private uint size_;
        public const int SizeFieldNumber = 5;
        private uint status_;
        public const int StatusFieldNumber = 6;
        private uint token_;
        public const int TokenFieldNumber = 3;

        static Header()
        {
            object.ReferenceEquals(Rpc.Descriptor, null);
        }

        private Header()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(Header prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            Header header = obj as Header;
            if (header == null)
            {
                return false;
            }
            if ((this.hasServiceId != header.hasServiceId) || (this.hasServiceId && !this.serviceId_.Equals(header.serviceId_)))
            {
                return false;
            }
            if ((this.hasMethodId != header.hasMethodId) || (this.hasMethodId && !this.methodId_.Equals(header.methodId_)))
            {
                return false;
            }
            if ((this.hasToken != header.hasToken) || (this.hasToken && !this.token_.Equals(header.token_)))
            {
                return false;
            }
            if ((this.hasObjectId != header.hasObjectId) || (this.hasObjectId && !this.objectId_.Equals(header.objectId_)))
            {
                return false;
            }
            if ((this.hasSize != header.hasSize) || (this.hasSize && !this.size_.Equals(header.size_)))
            {
                return false;
            }
            if ((this.hasStatus != header.hasStatus) || (this.hasStatus && !this.status_.Equals(header.status_)))
            {
                return false;
            }
            if (this.error_.Count != header.error_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.error_.Count; i++)
            {
                if (!this.error_[i].Equals(header.error_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public ErrorInfo GetError(int index)
        {
            return this.error_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasServiceId)
            {
                hashCode ^= this.serviceId_.GetHashCode();
            }
            if (this.hasMethodId)
            {
                hashCode ^= this.methodId_.GetHashCode();
            }
            if (this.hasToken)
            {
                hashCode ^= this.token_.GetHashCode();
            }
            if (this.hasObjectId)
            {
                hashCode ^= this.objectId_.GetHashCode();
            }
            if (this.hasSize)
            {
                hashCode ^= this.size_.GetHashCode();
            }
            if (this.hasStatus)
            {
                hashCode ^= this.status_.GetHashCode();
            }
            IEnumerator<ErrorInfo> enumerator = this.error_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    ErrorInfo current = enumerator.Current;
                    hashCode ^= current.GetHashCode();
                }
            }
            finally
            {
                if (enumerator == null)
                {
                }
                enumerator.Dispose();
            }
            return hashCode;
        }

        private Header MakeReadOnly()
        {
            this.error_.MakeReadOnly();
            return this;
        }

        public static Header ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static Header ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static Header ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Header ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Header ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Header ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Header ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static Header ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Header ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Header ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<Header, Builder>.PrintField("service_id", this.hasServiceId, this.serviceId_, writer);
            GeneratedMessageLite<Header, Builder>.PrintField("method_id", this.hasMethodId, this.methodId_, writer);
            GeneratedMessageLite<Header, Builder>.PrintField("token", this.hasToken, this.token_, writer);
            GeneratedMessageLite<Header, Builder>.PrintField("object_id", this.hasObjectId, this.objectId_, writer);
            GeneratedMessageLite<Header, Builder>.PrintField("size", this.hasSize, this.size_, writer);
            GeneratedMessageLite<Header, Builder>.PrintField("status", this.hasStatus, this.status_, writer);
            GeneratedMessageLite<Header, Builder>.PrintField<ErrorInfo>("error", this.error_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _headerFieldNames;
            if (this.hasServiceId)
            {
                output.WriteUInt32(1, strArray[3], this.ServiceId);
            }
            if (this.hasMethodId)
            {
                output.WriteUInt32(2, strArray[1], this.MethodId);
            }
            if (this.hasToken)
            {
                output.WriteUInt32(3, strArray[6], this.Token);
            }
            if (this.hasObjectId)
            {
                output.WriteUInt64(4, strArray[2], this.ObjectId);
            }
            if (this.hasSize)
            {
                output.WriteUInt32(5, strArray[4], this.Size);
            }
            if (this.hasStatus)
            {
                output.WriteUInt32(6, strArray[5], this.Status);
            }
            if (this.error_.Count > 0)
            {
                output.WriteMessageArray<ErrorInfo>(7, strArray[0], this.error_);
            }
        }

        public static Header DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override Header DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public int ErrorCount
        {
            get
            {
                return this.error_.Count;
            }
        }

        public IList<ErrorInfo> ErrorList
        {
            get
            {
                return this.error_;
            }
        }

        public bool HasMethodId
        {
            get
            {
                return this.hasMethodId;
            }
        }

        public bool HasObjectId
        {
            get
            {
                return this.hasObjectId;
            }
        }

        public bool HasServiceId
        {
            get
            {
                return this.hasServiceId;
            }
        }

        public bool HasSize
        {
            get
            {
                return this.hasSize;
            }
        }

        public bool HasStatus
        {
            get
            {
                return this.hasStatus;
            }
        }

        public bool HasToken
        {
            get
            {
                return this.hasToken;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasServiceId)
                {
                    return false;
                }
                if (!this.hasToken)
                {
                    return false;
                }
                IEnumerator<ErrorInfo> enumerator = this.ErrorList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        ErrorInfo current = enumerator.Current;
                        if (!current.IsInitialized)
                        {
                            return false;
                        }
                    }
                }
                finally
                {
                    if (enumerator == null)
                    {
                    }
                    enumerator.Dispose();
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

        [CLSCompliant(false)]
        public ulong ObjectId
        {
            get
            {
                return this.objectId_;
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
                    if (this.hasServiceId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(1, this.ServiceId);
                    }
                    if (this.hasMethodId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(2, this.MethodId);
                    }
                    if (this.hasToken)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(3, this.Token);
                    }
                    if (this.hasObjectId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(4, this.ObjectId);
                    }
                    if (this.hasSize)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(5, this.Size);
                    }
                    if (this.hasStatus)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(6, this.Status);
                    }
                    IEnumerator<ErrorInfo> enumerator = this.ErrorList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            ErrorInfo current = enumerator.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(7, current);
                        }
                    }
                    finally
                    {
                        if (enumerator == null)
                        {
                        }
                        enumerator.Dispose();
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        [CLSCompliant(false)]
        public uint ServiceId
        {
            get
            {
                return this.serviceId_;
            }
        }

        [CLSCompliant(false)]
        public uint Size
        {
            get
            {
                return this.size_;
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

        protected override Header ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CLSCompliant(false)]
        public uint Token
        {
            get
            {
                return this.token_;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<Header, Header.Builder>
        {
            private Header result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = Header.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(Header cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public Header.Builder AddError(ErrorInfo value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.error_.Add(value);
                return this;
            }

            public Header.Builder AddError(ErrorInfo.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.error_.Add(builderForValue.Build());
                return this;
            }

            public Header.Builder AddRangeError(IEnumerable<ErrorInfo> values)
            {
                this.PrepareBuilder();
                this.result.error_.Add(values);
                return this;
            }

            public override Header BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override Header.Builder Clear()
            {
                this.result = Header.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public Header.Builder ClearError()
            {
                this.PrepareBuilder();
                this.result.error_.Clear();
                return this;
            }

            public Header.Builder ClearMethodId()
            {
                this.PrepareBuilder();
                this.result.hasMethodId = false;
                this.result.methodId_ = 0;
                return this;
            }

            public Header.Builder ClearObjectId()
            {
                this.PrepareBuilder();
                this.result.hasObjectId = false;
                this.result.objectId_ = 0L;
                return this;
            }

            public Header.Builder ClearServiceId()
            {
                this.PrepareBuilder();
                this.result.hasServiceId = false;
                this.result.serviceId_ = 0;
                return this;
            }

            public Header.Builder ClearSize()
            {
                this.PrepareBuilder();
                this.result.hasSize = false;
                this.result.size_ = 0;
                return this;
            }

            public Header.Builder ClearStatus()
            {
                this.PrepareBuilder();
                this.result.hasStatus = false;
                this.result.status_ = 0;
                return this;
            }

            public Header.Builder ClearToken()
            {
                this.PrepareBuilder();
                this.result.hasToken = false;
                this.result.token_ = 0;
                return this;
            }

            public override Header.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new Header.Builder(this.result);
                }
                return new Header.Builder().MergeFrom(this.result);
            }

            public ErrorInfo GetError(int index)
            {
                return this.result.GetError(index);
            }

            public override Header.Builder MergeFrom(Header other)
            {
                if (other != Header.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasServiceId)
                    {
                        this.ServiceId = other.ServiceId;
                    }
                    if (other.HasMethodId)
                    {
                        this.MethodId = other.MethodId;
                    }
                    if (other.HasToken)
                    {
                        this.Token = other.Token;
                    }
                    if (other.HasObjectId)
                    {
                        this.ObjectId = other.ObjectId;
                    }
                    if (other.HasSize)
                    {
                        this.Size = other.Size;
                    }
                    if (other.HasStatus)
                    {
                        this.Status = other.Status;
                    }
                    if (other.error_.Count != 0)
                    {
                        this.result.error_.Add(other.error_);
                    }
                }
                return this;
            }

            public override Header.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override Header.Builder MergeFrom(IMessageLite other)
            {
                if (other is Header)
                {
                    return this.MergeFrom((Header) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override Header.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(Header._headerFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = Header._headerFieldTags[index];
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
                            this.result.hasServiceId = input.ReadUInt32(ref this.result.serviceId_);
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasMethodId = input.ReadUInt32(ref this.result.methodId_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasToken = input.ReadUInt32(ref this.result.token_);
                            continue;
                        }
                        case 0x20:
                        {
                            this.result.hasObjectId = input.ReadUInt64(ref this.result.objectId_);
                            continue;
                        }
                        case 40:
                        {
                            this.result.hasSize = input.ReadUInt32(ref this.result.size_);
                            continue;
                        }
                        case 0x30:
                        {
                            this.result.hasStatus = input.ReadUInt32(ref this.result.status_);
                            continue;
                        }
                        case 0x3a:
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
                    input.ReadMessageArray<ErrorInfo>(num, str, this.result.error_, ErrorInfo.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private Header PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    Header result = this.result;
                    this.result = new Header();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public Header.Builder SetError(int index, ErrorInfo value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.error_[index] = value;
                return this;
            }

            public Header.Builder SetError(int index, ErrorInfo.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.error_[index] = builderForValue.Build();
                return this;
            }

            [CLSCompliant(false)]
            public Header.Builder SetMethodId(uint value)
            {
                this.PrepareBuilder();
                this.result.hasMethodId = true;
                this.result.methodId_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public Header.Builder SetObjectId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasObjectId = true;
                this.result.objectId_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public Header.Builder SetServiceId(uint value)
            {
                this.PrepareBuilder();
                this.result.hasServiceId = true;
                this.result.serviceId_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public Header.Builder SetSize(uint value)
            {
                this.PrepareBuilder();
                this.result.hasSize = true;
                this.result.size_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public Header.Builder SetStatus(uint value)
            {
                this.PrepareBuilder();
                this.result.hasStatus = true;
                this.result.status_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public Header.Builder SetToken(uint value)
            {
                this.PrepareBuilder();
                this.result.hasToken = true;
                this.result.token_ = value;
                return this;
            }

            public override Header DefaultInstanceForType
            {
                get
                {
                    return Header.DefaultInstance;
                }
            }

            public int ErrorCount
            {
                get
                {
                    return this.result.ErrorCount;
                }
            }

            public IPopsicleList<ErrorInfo> ErrorList
            {
                get
                {
                    return this.PrepareBuilder().error_;
                }
            }

            public bool HasMethodId
            {
                get
                {
                    return this.result.hasMethodId;
                }
            }

            public bool HasObjectId
            {
                get
                {
                    return this.result.hasObjectId;
                }
            }

            public bool HasServiceId
            {
                get
                {
                    return this.result.hasServiceId;
                }
            }

            public bool HasSize
            {
                get
                {
                    return this.result.hasSize;
                }
            }

            public bool HasStatus
            {
                get
                {
                    return this.result.hasStatus;
                }
            }

            public bool HasToken
            {
                get
                {
                    return this.result.hasToken;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override Header MessageBeingBuilt
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

            [CLSCompliant(false)]
            public ulong ObjectId
            {
                get
                {
                    return this.result.ObjectId;
                }
                set
                {
                    this.SetObjectId(value);
                }
            }

            [CLSCompliant(false)]
            public uint ServiceId
            {
                get
                {
                    return this.result.ServiceId;
                }
                set
                {
                    this.SetServiceId(value);
                }
            }

            [CLSCompliant(false)]
            public uint Size
            {
                get
                {
                    return this.result.Size;
                }
                set
                {
                    this.SetSize(value);
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

            protected override Header.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            [CLSCompliant(false)]
            public uint Token
            {
                get
                {
                    return this.result.Token;
                }
                set
                {
                    this.SetToken(value);
                }
            }
        }
    }
}

