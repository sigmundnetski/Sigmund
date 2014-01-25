namespace bnet.protocol.connection
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class DisconnectRequest : GeneratedMessageLite<DisconnectRequest, Builder>
    {
        private static readonly string[] _disconnectRequestFieldNames = new string[] { "error_code" };
        private static readonly uint[] _disconnectRequestFieldTags = new uint[] { 8 };
        private static readonly DisconnectRequest defaultInstance = new DisconnectRequest().MakeReadOnly();
        private uint errorCode_;
        public const int ErrorCodeFieldNumber = 1;
        private bool hasErrorCode;
        private int memoizedSerializedSize = -1;

        static DisconnectRequest()
        {
            object.ReferenceEquals(Connect.Descriptor, null);
        }

        private DisconnectRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DisconnectRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DisconnectRequest request = obj as DisconnectRequest;
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

        private DisconnectRequest MakeReadOnly()
        {
            return this;
        }

        public static DisconnectRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DisconnectRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DisconnectRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DisconnectRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DisconnectRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DisconnectRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DisconnectRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DisconnectRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DisconnectRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DisconnectRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DisconnectRequest, Builder>.PrintField("error_code", this.hasErrorCode, this.errorCode_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _disconnectRequestFieldNames;
            if (this.hasErrorCode)
            {
                output.WriteUInt32(1, strArray[0], this.ErrorCode);
            }
        }

        public static DisconnectRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DisconnectRequest DefaultInstanceForType
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

        protected override DisconnectRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<DisconnectRequest, DisconnectRequest.Builder>
        {
            private DisconnectRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DisconnectRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DisconnectRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override DisconnectRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DisconnectRequest.Builder Clear()
            {
                this.result = DisconnectRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DisconnectRequest.Builder ClearErrorCode()
            {
                this.PrepareBuilder();
                this.result.hasErrorCode = false;
                this.result.errorCode_ = 0;
                return this;
            }

            public override DisconnectRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DisconnectRequest.Builder(this.result);
                }
                return new DisconnectRequest.Builder().MergeFrom(this.result);
            }

            public override DisconnectRequest.Builder MergeFrom(DisconnectRequest other)
            {
                if (other != DisconnectRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasErrorCode)
                    {
                        this.ErrorCode = other.ErrorCode;
                    }
                }
                return this;
            }

            public override DisconnectRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DisconnectRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is DisconnectRequest)
                {
                    return this.MergeFrom((DisconnectRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DisconnectRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DisconnectRequest._disconnectRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DisconnectRequest._disconnectRequestFieldTags[index];
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

            private DisconnectRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DisconnectRequest result = this.result;
                    this.result = new DisconnectRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public DisconnectRequest.Builder SetErrorCode(uint value)
            {
                this.PrepareBuilder();
                this.result.hasErrorCode = true;
                this.result.errorCode_ = value;
                return this;
            }

            public override DisconnectRequest DefaultInstanceForType
            {
                get
                {
                    return DisconnectRequest.DefaultInstance;
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

            protected override DisconnectRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override DisconnectRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

