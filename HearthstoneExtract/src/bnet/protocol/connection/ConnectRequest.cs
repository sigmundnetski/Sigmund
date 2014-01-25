namespace bnet.protocol.connection
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class ConnectRequest : GeneratedMessageLite<ConnectRequest, Builder>
    {
        private static readonly string[] _connectRequestFieldNames = new string[] { "bind_request", "client_id" };
        private static readonly uint[] _connectRequestFieldTags = new uint[] { 0x12, 10 };
        private bnet.protocol.connection.BindRequest bindRequest_;
        public const int BindRequestFieldNumber = 2;
        private ProcessId clientId_;
        public const int ClientIdFieldNumber = 1;
        private static readonly ConnectRequest defaultInstance = new ConnectRequest().MakeReadOnly();
        private bool hasBindRequest;
        private bool hasClientId;
        private int memoizedSerializedSize = -1;

        static ConnectRequest()
        {
            object.ReferenceEquals(Connect.Descriptor, null);
        }

        private ConnectRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ConnectRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ConnectRequest request = obj as ConnectRequest;
            if (request == null)
            {
                return false;
            }
            if ((this.hasClientId != request.hasClientId) || (this.hasClientId && !this.clientId_.Equals(request.clientId_)))
            {
                return false;
            }
            return ((this.hasBindRequest == request.hasBindRequest) && (!this.hasBindRequest || this.bindRequest_.Equals(request.bindRequest_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasClientId)
            {
                hashCode ^= this.clientId_.GetHashCode();
            }
            if (this.hasBindRequest)
            {
                hashCode ^= this.bindRequest_.GetHashCode();
            }
            return hashCode;
        }

        private ConnectRequest MakeReadOnly()
        {
            return this;
        }

        public static ConnectRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ConnectRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ConnectRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ConnectRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ConnectRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ConnectRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ConnectRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ConnectRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ConnectRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ConnectRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ConnectRequest, Builder>.PrintField("client_id", this.hasClientId, this.clientId_, writer);
            GeneratedMessageLite<ConnectRequest, Builder>.PrintField("bind_request", this.hasBindRequest, this.bindRequest_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _connectRequestFieldNames;
            if (this.hasClientId)
            {
                output.WriteMessage(1, strArray[1], this.ClientId);
            }
            if (this.hasBindRequest)
            {
                output.WriteMessage(2, strArray[0], this.BindRequest);
            }
        }

        public bnet.protocol.connection.BindRequest BindRequest
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.bindRequest_ != null)
                {
                    goto Label_0012;
                }
                return bnet.protocol.connection.BindRequest.DefaultInstance;
            }
        }

        public ProcessId ClientId
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.clientId_ != null)
                {
                    goto Label_0012;
                }
                return ProcessId.DefaultInstance;
            }
        }

        public static ConnectRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ConnectRequest DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasBindRequest
        {
            get
            {
                return this.hasBindRequest;
            }
        }

        public bool HasClientId
        {
            get
            {
                return this.hasClientId;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (this.HasClientId && !this.ClientId.IsInitialized)
                {
                    return false;
                }
                if (this.HasBindRequest && !this.BindRequest.IsInitialized)
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
                    if (this.hasClientId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.ClientId);
                    }
                    if (this.hasBindRequest)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, this.BindRequest);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ConnectRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<ConnectRequest, ConnectRequest.Builder>
        {
            private ConnectRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ConnectRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ConnectRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override ConnectRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ConnectRequest.Builder Clear()
            {
                this.result = ConnectRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ConnectRequest.Builder ClearBindRequest()
            {
                this.PrepareBuilder();
                this.result.hasBindRequest = false;
                this.result.bindRequest_ = null;
                return this;
            }

            public ConnectRequest.Builder ClearClientId()
            {
                this.PrepareBuilder();
                this.result.hasClientId = false;
                this.result.clientId_ = null;
                return this;
            }

            public override ConnectRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ConnectRequest.Builder(this.result);
                }
                return new ConnectRequest.Builder().MergeFrom(this.result);
            }

            public ConnectRequest.Builder MergeBindRequest(bnet.protocol.connection.BindRequest value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasBindRequest && (this.result.bindRequest_ != bnet.protocol.connection.BindRequest.DefaultInstance))
                {
                    this.result.bindRequest_ = bnet.protocol.connection.BindRequest.CreateBuilder(this.result.bindRequest_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.bindRequest_ = value;
                }
                this.result.hasBindRequest = true;
                return this;
            }

            public ConnectRequest.Builder MergeClientId(ProcessId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasClientId && (this.result.clientId_ != ProcessId.DefaultInstance))
                {
                    this.result.clientId_ = ProcessId.CreateBuilder(this.result.clientId_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.clientId_ = value;
                }
                this.result.hasClientId = true;
                return this;
            }

            public override ConnectRequest.Builder MergeFrom(ConnectRequest other)
            {
                if (other != ConnectRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasClientId)
                    {
                        this.MergeClientId(other.ClientId);
                    }
                    if (other.HasBindRequest)
                    {
                        this.MergeBindRequest(other.BindRequest);
                    }
                }
                return this;
            }

            public override ConnectRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ConnectRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is ConnectRequest)
                {
                    return this.MergeFrom((ConnectRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ConnectRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ConnectRequest._connectRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ConnectRequest._connectRequestFieldTags[index];
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
                            ProcessId.Builder builder = ProcessId.CreateBuilder();
                            if (this.result.hasClientId)
                            {
                                builder.MergeFrom(this.ClientId);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.ClientId = builder.BuildPartial();
                            continue;
                        }
                        case 0x12:
                        {
                            bnet.protocol.connection.BindRequest.Builder builder2 = bnet.protocol.connection.BindRequest.CreateBuilder();
                            if (this.result.hasBindRequest)
                            {
                                builder2.MergeFrom(this.BindRequest);
                            }
                            input.ReadMessage(builder2, extensionRegistry);
                            this.BindRequest = builder2.BuildPartial();
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

            private ConnectRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ConnectRequest result = this.result;
                    this.result = new ConnectRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ConnectRequest.Builder SetBindRequest(bnet.protocol.connection.BindRequest value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasBindRequest = true;
                this.result.bindRequest_ = value;
                return this;
            }

            public ConnectRequest.Builder SetBindRequest(bnet.protocol.connection.BindRequest.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasBindRequest = true;
                this.result.bindRequest_ = builderForValue.Build();
                return this;
            }

            public ConnectRequest.Builder SetClientId(ProcessId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasClientId = true;
                this.result.clientId_ = value;
                return this;
            }

            public ConnectRequest.Builder SetClientId(ProcessId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasClientId = true;
                this.result.clientId_ = builderForValue.Build();
                return this;
            }

            public bnet.protocol.connection.BindRequest BindRequest
            {
                get
                {
                    return this.result.BindRequest;
                }
                set
                {
                    this.SetBindRequest(value);
                }
            }

            public ProcessId ClientId
            {
                get
                {
                    return this.result.ClientId;
                }
                set
                {
                    this.SetClientId(value);
                }
            }

            public override ConnectRequest DefaultInstanceForType
            {
                get
                {
                    return ConnectRequest.DefaultInstance;
                }
            }

            public bool HasBindRequest
            {
                get
                {
                    return this.result.hasBindRequest;
                }
            }

            public bool HasClientId
            {
                get
                {
                    return this.result.hasClientId;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override ConnectRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override ConnectRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

