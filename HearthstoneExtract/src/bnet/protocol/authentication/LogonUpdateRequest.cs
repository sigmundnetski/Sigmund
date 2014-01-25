namespace bnet.protocol.authentication
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class LogonUpdateRequest : GeneratedMessageLite<LogonUpdateRequest, Builder>
    {
        private static readonly string[] _logonUpdateRequestFieldNames = new string[] { "error_code" };
        private static readonly uint[] _logonUpdateRequestFieldTags = new uint[] { 8 };
        private static readonly LogonUpdateRequest defaultInstance = new LogonUpdateRequest().MakeReadOnly();
        private uint errorCode_;
        public const int ErrorCodeFieldNumber = 1;
        private bool hasErrorCode;
        private int memoizedSerializedSize = -1;

        static LogonUpdateRequest()
        {
            object.ReferenceEquals(AuthenticationService.Descriptor, null);
        }

        private LogonUpdateRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(LogonUpdateRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            LogonUpdateRequest request = obj as LogonUpdateRequest;
            if (request == null)
            {
                return false;
            }
            return ((this.hasErrorCode == request.hasErrorCode) && (!this.hasErrorCode || this.errorCode_.Equals(request.errorCode_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasErrorCode)
            {
                hashCode ^= this.errorCode_.GetHashCode();
            }
            return hashCode;
        }

        private LogonUpdateRequest MakeReadOnly()
        {
            return this;
        }

        public static LogonUpdateRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static LogonUpdateRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static LogonUpdateRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static LogonUpdateRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static LogonUpdateRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static LogonUpdateRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static LogonUpdateRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static LogonUpdateRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static LogonUpdateRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static LogonUpdateRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<LogonUpdateRequest, Builder>.PrintField("error_code", this.hasErrorCode, this.errorCode_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _logonUpdateRequestFieldNames;
            if (this.hasErrorCode)
            {
                output.WriteUInt32(1, strArray[0], this.ErrorCode);
            }
        }

        public static LogonUpdateRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override LogonUpdateRequest DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        [CLSCompliant(false)]
        public uint ErrorCode
        {
            get
            {
                return this.errorCode_;
            }
        }

        public bool HasErrorCode
        {
            get
            {
                return this.hasErrorCode;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasErrorCode)
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
                    if (this.hasErrorCode)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(1, this.ErrorCode);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override LogonUpdateRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<LogonUpdateRequest, LogonUpdateRequest.Builder>
        {
            private LogonUpdateRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = LogonUpdateRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(LogonUpdateRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override LogonUpdateRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override LogonUpdateRequest.Builder Clear()
            {
                this.result = LogonUpdateRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public LogonUpdateRequest.Builder ClearErrorCode()
            {
                this.PrepareBuilder();
                this.result.hasErrorCode = false;
                this.result.errorCode_ = 0;
                return this;
            }

            public override LogonUpdateRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new LogonUpdateRequest.Builder(this.result);
                }
                return new LogonUpdateRequest.Builder().MergeFrom(this.result);
            }

            public override LogonUpdateRequest.Builder MergeFrom(LogonUpdateRequest other)
            {
                if (other != LogonUpdateRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasErrorCode)
                    {
                        this.ErrorCode = other.ErrorCode;
                    }
                }
                return this;
            }

            public override LogonUpdateRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override LogonUpdateRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is LogonUpdateRequest)
                {
                    return this.MergeFrom((LogonUpdateRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override LogonUpdateRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(LogonUpdateRequest._logonUpdateRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = LogonUpdateRequest._logonUpdateRequestFieldTags[index];
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
                    this.result.hasErrorCode = input.ReadUInt32(ref this.result.errorCode_);
                }
                return this;
            }

            private LogonUpdateRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    LogonUpdateRequest result = this.result;
                    this.result = new LogonUpdateRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public LogonUpdateRequest.Builder SetErrorCode(uint value)
            {
                this.PrepareBuilder();
                this.result.hasErrorCode = true;
                this.result.errorCode_ = value;
                return this;
            }

            public override LogonUpdateRequest DefaultInstanceForType
            {
                get
                {
                    return LogonUpdateRequest.DefaultInstance;
                }
            }

            [CLSCompliant(false)]
            public uint ErrorCode
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

            public bool HasErrorCode
            {
                get
                {
                    return this.result.hasErrorCode;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override LogonUpdateRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override LogonUpdateRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

