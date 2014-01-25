namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class DebugConsoleResponse : GeneratedMessageLite<DebugConsoleResponse, Builder>
    {
        private static readonly string[] _debugConsoleResponseFieldNames = new string[] { "response", "response_type" };
        private static readonly uint[] _debugConsoleResponseFieldTags = new uint[] { 10, 0x10 };
        private static readonly DebugConsoleResponse defaultInstance = new DebugConsoleResponse().MakeReadOnly();
        private bool hasResponse;
        private bool hasResponseType;
        private int memoizedSerializedSize = -1;
        private string response_ = string.Empty;
        public const int ResponseFieldNumber = 1;
        private BobNetProto.DebugConsoleResponse.Types.ResponseType responseType_;
        public const int ResponseTypeFieldNumber = 2;

        static DebugConsoleResponse()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private DebugConsoleResponse()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DebugConsoleResponse prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DebugConsoleResponse response = obj as DebugConsoleResponse;
            if (response == null)
            {
                return false;
            }
            if ((this.hasResponse != response.hasResponse) || (this.hasResponse && !this.response_.Equals(response.response_)))
            {
                return false;
            }
            return ((this.hasResponseType == response.hasResponseType) && (!this.hasResponseType || this.responseType_.Equals(response.responseType_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasResponse)
            {
                hashCode ^= this.response_.GetHashCode();
            }
            if (this.hasResponseType)
            {
                hashCode ^= this.responseType_.GetHashCode();
            }
            return hashCode;
        }

        private DebugConsoleResponse MakeReadOnly()
        {
            return this;
        }

        public static DebugConsoleResponse ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DebugConsoleResponse ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DebugConsoleResponse ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DebugConsoleResponse ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DebugConsoleResponse ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DebugConsoleResponse ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DebugConsoleResponse ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DebugConsoleResponse ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DebugConsoleResponse ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DebugConsoleResponse ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DebugConsoleResponse, Builder>.PrintField("response", this.hasResponse, this.response_, writer);
            GeneratedMessageLite<DebugConsoleResponse, Builder>.PrintField("response_type", this.hasResponseType, this.responseType_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _debugConsoleResponseFieldNames;
            if (this.hasResponse)
            {
                output.WriteString(1, strArray[0], this.Response);
            }
            if (this.hasResponseType)
            {
                output.WriteEnum(2, strArray[1], (int) this.ResponseType, this.ResponseType);
            }
        }

        public static DebugConsoleResponse DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DebugConsoleResponse DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasResponse
        {
            get
            {
                return this.hasResponse;
            }
        }

        public bool HasResponseType
        {
            get
            {
                return this.hasResponseType;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasResponse)
                {
                    return false;
                }
                if (!this.hasResponseType)
                {
                    return false;
                }
                return true;
            }
        }

        public string Response
        {
            get
            {
                return this.response_;
            }
        }

        public BobNetProto.DebugConsoleResponse.Types.ResponseType ResponseType
        {
            get
            {
                return this.responseType_;
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
                    if (this.hasResponse)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(1, this.Response);
                    }
                    if (this.hasResponseType)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeEnumSize(2, (int) this.ResponseType);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override DebugConsoleResponse ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<DebugConsoleResponse, DebugConsoleResponse.Builder>
        {
            private DebugConsoleResponse result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DebugConsoleResponse.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DebugConsoleResponse cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override DebugConsoleResponse BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DebugConsoleResponse.Builder Clear()
            {
                this.result = DebugConsoleResponse.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DebugConsoleResponse.Builder ClearResponse()
            {
                this.PrepareBuilder();
                this.result.hasResponse = false;
                this.result.response_ = string.Empty;
                return this;
            }

            public DebugConsoleResponse.Builder ClearResponseType()
            {
                this.PrepareBuilder();
                this.result.hasResponseType = false;
                this.result.responseType_ = BobNetProto.DebugConsoleResponse.Types.ResponseType.CONSOLE_OUTPUT;
                return this;
            }

            public override DebugConsoleResponse.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DebugConsoleResponse.Builder(this.result);
                }
                return new DebugConsoleResponse.Builder().MergeFrom(this.result);
            }

            public override DebugConsoleResponse.Builder MergeFrom(DebugConsoleResponse other)
            {
                if (other != DebugConsoleResponse.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasResponse)
                    {
                        this.Response = other.Response;
                    }
                    if (other.HasResponseType)
                    {
                        this.ResponseType = other.ResponseType;
                    }
                }
                return this;
            }

            public override DebugConsoleResponse.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DebugConsoleResponse.Builder MergeFrom(IMessageLite other)
            {
                if (other is DebugConsoleResponse)
                {
                    return this.MergeFrom((DebugConsoleResponse) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DebugConsoleResponse.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    object obj2;
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DebugConsoleResponse._debugConsoleResponseFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DebugConsoleResponse._debugConsoleResponseFieldTags[index];
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
                            this.result.hasResponse = input.ReadString(ref this.result.response_);
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
                    if (input.ReadEnum<BobNetProto.DebugConsoleResponse.Types.ResponseType>(ref this.result.responseType_, out obj2))
                    {
                        this.result.hasResponseType = true;
                    }
                    else if (!(obj2 is int))
                    {
                        continue;
                    }
                }
                return this;
            }

            private DebugConsoleResponse PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DebugConsoleResponse result = this.result;
                    this.result = new DebugConsoleResponse();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DebugConsoleResponse.Builder SetResponse(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasResponse = true;
                this.result.response_ = value;
                return this;
            }

            public DebugConsoleResponse.Builder SetResponseType(BobNetProto.DebugConsoleResponse.Types.ResponseType value)
            {
                this.PrepareBuilder();
                this.result.hasResponseType = true;
                this.result.responseType_ = value;
                return this;
            }

            public override DebugConsoleResponse DefaultInstanceForType
            {
                get
                {
                    return DebugConsoleResponse.DefaultInstance;
                }
            }

            public bool HasResponse
            {
                get
                {
                    return this.result.hasResponse;
                }
            }

            public bool HasResponseType
            {
                get
                {
                    return this.result.hasResponseType;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override DebugConsoleResponse MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public string Response
            {
                get
                {
                    return this.result.Response;
                }
                set
                {
                    this.SetResponse(value);
                }
            }

            public BobNetProto.DebugConsoleResponse.Types.ResponseType ResponseType
            {
                get
                {
                    return this.result.ResponseType;
                }
                set
                {
                    this.SetResponseType(value);
                }
            }

            protected override DebugConsoleResponse.Builder ThisBuilder
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
            public enum PacketID
            {
                ID = 0x7c
            }

            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum ResponseType
            {
                CONSOLE_OUTPUT,
                LOG_MESSAGE
            }
        }
    }
}

