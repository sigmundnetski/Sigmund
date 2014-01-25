namespace bnet.protocol.connection
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class ConnectResponse : GeneratedMessageLite<ConnectResponse, Builder>
    {
        private static readonly string[] _connectResponseFieldNames = new string[] { "bind_response", "bind_result", "client_id", "content_handle_array", "server_id" };
        private static readonly uint[] _connectResponseFieldTags = new uint[] { 0x22, 0x18, 0x12, 0x2a, 10 };
        private bnet.protocol.connection.BindResponse bindResponse_;
        public const int BindResponseFieldNumber = 4;
        private uint bindResult_;
        public const int BindResultFieldNumber = 3;
        private ProcessId clientId_;
        public const int ClientIdFieldNumber = 2;
        private ConnectionMeteringContentHandles contentHandleArray_;
        public const int ContentHandleArrayFieldNumber = 5;
        private static readonly ConnectResponse defaultInstance = new ConnectResponse().MakeReadOnly();
        private bool hasBindResponse;
        private bool hasBindResult;
        private bool hasClientId;
        private bool hasContentHandleArray;
        private bool hasServerId;
        private int memoizedSerializedSize = -1;
        private ProcessId serverId_;
        public const int ServerIdFieldNumber = 1;

        static ConnectResponse()
        {
            object.ReferenceEquals(Connect.Descriptor, null);
        }

        private ConnectResponse()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ConnectResponse prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ConnectResponse response = obj as ConnectResponse;
            if (response == null)
            {
                return false;
            }
            if ((this.hasServerId != response.hasServerId) || (this.hasServerId && !this.serverId_.Equals(response.serverId_)))
            {
                return false;
            }
            if ((this.hasClientId != response.hasClientId) || (this.hasClientId && !this.clientId_.Equals(response.clientId_)))
            {
                return false;
            }
            if ((this.hasBindResult != response.hasBindResult) || (this.hasBindResult && !this.bindResult_.Equals(response.bindResult_)))
            {
                return false;
            }
            if ((this.hasBindResponse != response.hasBindResponse) || (this.hasBindResponse && !this.bindResponse_.Equals(response.bindResponse_)))
            {
                return false;
            }
            return ((this.hasContentHandleArray == response.hasContentHandleArray) && (!this.hasContentHandleArray || this.contentHandleArray_.Equals(response.contentHandleArray_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasServerId)
            {
                hashCode ^= this.serverId_.GetHashCode();
            }
            if (this.hasClientId)
            {
                hashCode ^= this.clientId_.GetHashCode();
            }
            if (this.hasBindResult)
            {
                hashCode ^= this.bindResult_.GetHashCode();
            }
            if (this.hasBindResponse)
            {
                hashCode ^= this.bindResponse_.GetHashCode();
            }
            if (this.hasContentHandleArray)
            {
                hashCode ^= this.contentHandleArray_.GetHashCode();
            }
            return hashCode;
        }

        private ConnectResponse MakeReadOnly()
        {
            return this;
        }

        public static ConnectResponse ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ConnectResponse ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ConnectResponse ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ConnectResponse ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ConnectResponse ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ConnectResponse ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ConnectResponse ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ConnectResponse ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ConnectResponse ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ConnectResponse ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ConnectResponse, Builder>.PrintField("server_id", this.hasServerId, this.serverId_, writer);
            GeneratedMessageLite<ConnectResponse, Builder>.PrintField("client_id", this.hasClientId, this.clientId_, writer);
            GeneratedMessageLite<ConnectResponse, Builder>.PrintField("bind_result", this.hasBindResult, this.bindResult_, writer);
            GeneratedMessageLite<ConnectResponse, Builder>.PrintField("bind_response", this.hasBindResponse, this.bindResponse_, writer);
            GeneratedMessageLite<ConnectResponse, Builder>.PrintField("content_handle_array", this.hasContentHandleArray, this.contentHandleArray_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _connectResponseFieldNames;
            if (this.hasServerId)
            {
                output.WriteMessage(1, strArray[4], this.ServerId);
            }
            if (this.hasClientId)
            {
                output.WriteMessage(2, strArray[2], this.ClientId);
            }
            if (this.hasBindResult)
            {
                output.WriteUInt32(3, strArray[1], this.BindResult);
            }
            if (this.hasBindResponse)
            {
                output.WriteMessage(4, strArray[0], this.BindResponse);
            }
            if (this.hasContentHandleArray)
            {
                output.WriteMessage(5, strArray[3], this.ContentHandleArray);
            }
        }

        public bnet.protocol.connection.BindResponse BindResponse
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.bindResponse_ != null)
                {
                    goto Label_0012;
                }
                return bnet.protocol.connection.BindResponse.DefaultInstance;
            }
        }

        [CLSCompliant(false)]
        public uint BindResult
        {
            get
            {
                return this.bindResult_;
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

        public ConnectionMeteringContentHandles ContentHandleArray
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.contentHandleArray_ != null)
                {
                    goto Label_0012;
                }
                return ConnectionMeteringContentHandles.DefaultInstance;
            }
        }

        public static ConnectResponse DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ConnectResponse DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasBindResponse
        {
            get
            {
                return this.hasBindResponse;
            }
        }

        public bool HasBindResult
        {
            get
            {
                return this.hasBindResult;
            }
        }

        public bool HasClientId
        {
            get
            {
                return this.hasClientId;
            }
        }

        public bool HasContentHandleArray
        {
            get
            {
                return this.hasContentHandleArray;
            }
        }

        public bool HasServerId
        {
            get
            {
                return this.hasServerId;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasServerId)
                {
                    return false;
                }
                if (!this.ServerId.IsInitialized)
                {
                    return false;
                }
                if (this.HasClientId && !this.ClientId.IsInitialized)
                {
                    return false;
                }
                if (this.HasContentHandleArray && !this.ContentHandleArray.IsInitialized)
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
                    if (this.hasServerId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.ServerId);
                    }
                    if (this.hasClientId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, this.ClientId);
                    }
                    if (this.hasBindResult)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(3, this.BindResult);
                    }
                    if (this.hasBindResponse)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(4, this.BindResponse);
                    }
                    if (this.hasContentHandleArray)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(5, this.ContentHandleArray);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        public ProcessId ServerId
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.serverId_ != null)
                {
                    goto Label_0012;
                }
                return ProcessId.DefaultInstance;
            }
        }

        protected override ConnectResponse ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<ConnectResponse, ConnectResponse.Builder>
        {
            private ConnectResponse result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ConnectResponse.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ConnectResponse cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override ConnectResponse BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ConnectResponse.Builder Clear()
            {
                this.result = ConnectResponse.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ConnectResponse.Builder ClearBindResponse()
            {
                this.PrepareBuilder();
                this.result.hasBindResponse = false;
                this.result.bindResponse_ = null;
                return this;
            }

            public ConnectResponse.Builder ClearBindResult()
            {
                this.PrepareBuilder();
                this.result.hasBindResult = false;
                this.result.bindResult_ = 0;
                return this;
            }

            public ConnectResponse.Builder ClearClientId()
            {
                this.PrepareBuilder();
                this.result.hasClientId = false;
                this.result.clientId_ = null;
                return this;
            }

            public ConnectResponse.Builder ClearContentHandleArray()
            {
                this.PrepareBuilder();
                this.result.hasContentHandleArray = false;
                this.result.contentHandleArray_ = null;
                return this;
            }

            public ConnectResponse.Builder ClearServerId()
            {
                this.PrepareBuilder();
                this.result.hasServerId = false;
                this.result.serverId_ = null;
                return this;
            }

            public override ConnectResponse.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ConnectResponse.Builder(this.result);
                }
                return new ConnectResponse.Builder().MergeFrom(this.result);
            }

            public ConnectResponse.Builder MergeBindResponse(bnet.protocol.connection.BindResponse value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasBindResponse && (this.result.bindResponse_ != bnet.protocol.connection.BindResponse.DefaultInstance))
                {
                    this.result.bindResponse_ = bnet.protocol.connection.BindResponse.CreateBuilder(this.result.bindResponse_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.bindResponse_ = value;
                }
                this.result.hasBindResponse = true;
                return this;
            }

            public ConnectResponse.Builder MergeClientId(ProcessId value)
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

            public ConnectResponse.Builder MergeContentHandleArray(ConnectionMeteringContentHandles value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasContentHandleArray && (this.result.contentHandleArray_ != ConnectionMeteringContentHandles.DefaultInstance))
                {
                    this.result.contentHandleArray_ = ConnectionMeteringContentHandles.CreateBuilder(this.result.contentHandleArray_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.contentHandleArray_ = value;
                }
                this.result.hasContentHandleArray = true;
                return this;
            }

            public override ConnectResponse.Builder MergeFrom(ConnectResponse other)
            {
                if (other != ConnectResponse.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasServerId)
                    {
                        this.MergeServerId(other.ServerId);
                    }
                    if (other.HasClientId)
                    {
                        this.MergeClientId(other.ClientId);
                    }
                    if (other.HasBindResult)
                    {
                        this.BindResult = other.BindResult;
                    }
                    if (other.HasBindResponse)
                    {
                        this.MergeBindResponse(other.BindResponse);
                    }
                    if (other.HasContentHandleArray)
                    {
                        this.MergeContentHandleArray(other.ContentHandleArray);
                    }
                }
                return this;
            }

            public override ConnectResponse.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ConnectResponse.Builder MergeFrom(IMessageLite other)
            {
                if (other is ConnectResponse)
                {
                    return this.MergeFrom((ConnectResponse) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ConnectResponse.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ConnectResponse._connectResponseFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ConnectResponse._connectResponseFieldTags[index];
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
                            if (this.result.hasServerId)
                            {
                                builder.MergeFrom(this.ServerId);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.ServerId = builder.BuildPartial();
                            continue;
                        }
                        case 0x12:
                        {
                            ProcessId.Builder builder2 = ProcessId.CreateBuilder();
                            if (this.result.hasClientId)
                            {
                                builder2.MergeFrom(this.ClientId);
                            }
                            input.ReadMessage(builder2, extensionRegistry);
                            this.ClientId = builder2.BuildPartial();
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasBindResult = input.ReadUInt32(ref this.result.bindResult_);
                            continue;
                        }
                        case 0x22:
                        {
                            bnet.protocol.connection.BindResponse.Builder builder3 = bnet.protocol.connection.BindResponse.CreateBuilder();
                            if (this.result.hasBindResponse)
                            {
                                builder3.MergeFrom(this.BindResponse);
                            }
                            input.ReadMessage(builder3, extensionRegistry);
                            this.BindResponse = builder3.BuildPartial();
                            continue;
                        }
                        case 0x2a:
                        {
                            ConnectionMeteringContentHandles.Builder builder4 = ConnectionMeteringContentHandles.CreateBuilder();
                            if (this.result.hasContentHandleArray)
                            {
                                builder4.MergeFrom(this.ContentHandleArray);
                            }
                            input.ReadMessage(builder4, extensionRegistry);
                            this.ContentHandleArray = builder4.BuildPartial();
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

            public ConnectResponse.Builder MergeServerId(ProcessId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasServerId && (this.result.serverId_ != ProcessId.DefaultInstance))
                {
                    this.result.serverId_ = ProcessId.CreateBuilder(this.result.serverId_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.serverId_ = value;
                }
                this.result.hasServerId = true;
                return this;
            }

            private ConnectResponse PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ConnectResponse result = this.result;
                    this.result = new ConnectResponse();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ConnectResponse.Builder SetBindResponse(bnet.protocol.connection.BindResponse value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasBindResponse = true;
                this.result.bindResponse_ = value;
                return this;
            }

            public ConnectResponse.Builder SetBindResponse(bnet.protocol.connection.BindResponse.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasBindResponse = true;
                this.result.bindResponse_ = builderForValue.Build();
                return this;
            }

            [CLSCompliant(false)]
            public ConnectResponse.Builder SetBindResult(uint value)
            {
                this.PrepareBuilder();
                this.result.hasBindResult = true;
                this.result.bindResult_ = value;
                return this;
            }

            public ConnectResponse.Builder SetClientId(ProcessId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasClientId = true;
                this.result.clientId_ = value;
                return this;
            }

            public ConnectResponse.Builder SetClientId(ProcessId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasClientId = true;
                this.result.clientId_ = builderForValue.Build();
                return this;
            }

            public ConnectResponse.Builder SetContentHandleArray(ConnectionMeteringContentHandles value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasContentHandleArray = true;
                this.result.contentHandleArray_ = value;
                return this;
            }

            public ConnectResponse.Builder SetContentHandleArray(ConnectionMeteringContentHandles.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasContentHandleArray = true;
                this.result.contentHandleArray_ = builderForValue.Build();
                return this;
            }

            public ConnectResponse.Builder SetServerId(ProcessId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasServerId = true;
                this.result.serverId_ = value;
                return this;
            }

            public ConnectResponse.Builder SetServerId(ProcessId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasServerId = true;
                this.result.serverId_ = builderForValue.Build();
                return this;
            }

            public bnet.protocol.connection.BindResponse BindResponse
            {
                get
                {
                    return this.result.BindResponse;
                }
                set
                {
                    this.SetBindResponse(value);
                }
            }

            [CLSCompliant(false)]
            public uint BindResult
            {
                get
                {
                    return this.result.BindResult;
                }
                set
                {
                    this.SetBindResult(value);
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

            public ConnectionMeteringContentHandles ContentHandleArray
            {
                get
                {
                    return this.result.ContentHandleArray;
                }
                set
                {
                    this.SetContentHandleArray(value);
                }
            }

            public override ConnectResponse DefaultInstanceForType
            {
                get
                {
                    return ConnectResponse.DefaultInstance;
                }
            }

            public bool HasBindResponse
            {
                get
                {
                    return this.result.hasBindResponse;
                }
            }

            public bool HasBindResult
            {
                get
                {
                    return this.result.hasBindResult;
                }
            }

            public bool HasClientId
            {
                get
                {
                    return this.result.hasClientId;
                }
            }

            public bool HasContentHandleArray
            {
                get
                {
                    return this.result.hasContentHandleArray;
                }
            }

            public bool HasServerId
            {
                get
                {
                    return this.result.hasServerId;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override ConnectResponse MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public ProcessId ServerId
            {
                get
                {
                    return this.result.ServerId;
                }
                set
                {
                    this.SetServerId(value);
                }
            }

            protected override ConnectResponse.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

