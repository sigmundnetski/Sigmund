namespace bnet.protocol.game_master
{
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class JoinGameResponse : GeneratedMessageLite<JoinGameResponse, Builder>
    {
        private static readonly string[] _joinGameResponseFieldNames = new string[] { "connect_info", "queued", "request_id" };
        private static readonly uint[] _joinGameResponseFieldTags = new uint[] { 0x1a, 0x10, 9 };
        private PopsicleList<ConnectInfo> connectInfo_ = new PopsicleList<ConnectInfo>();
        public const int ConnectInfoFieldNumber = 3;
        private static readonly JoinGameResponse defaultInstance = new JoinGameResponse().MakeReadOnly();
        private bool hasQueued;
        private bool hasRequestId;
        private int memoizedSerializedSize = -1;
        private bool queued_;
        public const int QueuedFieldNumber = 2;
        private ulong requestId_;
        public const int RequestIdFieldNumber = 1;

        static JoinGameResponse()
        {
            object.ReferenceEquals(GameMaster.Descriptor, null);
        }

        private JoinGameResponse()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(JoinGameResponse prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            JoinGameResponse response = obj as JoinGameResponse;
            if (response == null)
            {
                return false;
            }
            if ((this.hasRequestId != response.hasRequestId) || (this.hasRequestId && !this.requestId_.Equals(response.requestId_)))
            {
                return false;
            }
            if ((this.hasQueued != response.hasQueued) || (this.hasQueued && !this.queued_.Equals(response.queued_)))
            {
                return false;
            }
            if (this.connectInfo_.Count != response.connectInfo_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.connectInfo_.Count; i++)
            {
                if (!this.connectInfo_[i].Equals(response.connectInfo_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public ConnectInfo GetConnectInfo(int index)
        {
            return this.connectInfo_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasRequestId)
            {
                hashCode ^= this.requestId_.GetHashCode();
            }
            if (this.hasQueued)
            {
                hashCode ^= this.queued_.GetHashCode();
            }
            IEnumerator<ConnectInfo> enumerator = this.connectInfo_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    ConnectInfo current = enumerator.Current;
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

        private JoinGameResponse MakeReadOnly()
        {
            this.connectInfo_.MakeReadOnly();
            return this;
        }

        public static JoinGameResponse ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static JoinGameResponse ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static JoinGameResponse ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static JoinGameResponse ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static JoinGameResponse ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static JoinGameResponse ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static JoinGameResponse ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static JoinGameResponse ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static JoinGameResponse ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static JoinGameResponse ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<JoinGameResponse, Builder>.PrintField("request_id", this.hasRequestId, this.requestId_, writer);
            GeneratedMessageLite<JoinGameResponse, Builder>.PrintField("queued", this.hasQueued, this.queued_, writer);
            GeneratedMessageLite<JoinGameResponse, Builder>.PrintField<ConnectInfo>("connect_info", this.connectInfo_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _joinGameResponseFieldNames;
            if (this.hasRequestId)
            {
                output.WriteFixed64(1, strArray[2], this.RequestId);
            }
            if (this.hasQueued)
            {
                output.WriteBool(2, strArray[1], this.Queued);
            }
            if (this.connectInfo_.Count > 0)
            {
                output.WriteMessageArray<ConnectInfo>(3, strArray[0], this.connectInfo_);
            }
        }

        public int ConnectInfoCount
        {
            get
            {
                return this.connectInfo_.Count;
            }
        }

        public IList<ConnectInfo> ConnectInfoList
        {
            get
            {
                return this.connectInfo_;
            }
        }

        public static JoinGameResponse DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override JoinGameResponse DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasQueued
        {
            get
            {
                return this.hasQueued;
            }
        }

        public bool HasRequestId
        {
            get
            {
                return this.hasRequestId;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                IEnumerator<ConnectInfo> enumerator = this.ConnectInfoList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        ConnectInfo current = enumerator.Current;
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

        public bool Queued
        {
            get
            {
                return this.queued_;
            }
        }

        [CLSCompliant(false)]
        public ulong RequestId
        {
            get
            {
                return this.requestId_;
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
                    if (this.hasRequestId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed64Size(1, this.RequestId);
                    }
                    if (this.hasQueued)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(2, this.Queued);
                    }
                    IEnumerator<ConnectInfo> enumerator = this.ConnectInfoList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            ConnectInfo current = enumerator.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(3, current);
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

        protected override JoinGameResponse ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<JoinGameResponse, JoinGameResponse.Builder>
        {
            private JoinGameResponse result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = JoinGameResponse.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(JoinGameResponse cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public JoinGameResponse.Builder AddConnectInfo(ConnectInfo value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.connectInfo_.Add(value);
                return this;
            }

            public JoinGameResponse.Builder AddConnectInfo(ConnectInfo.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.connectInfo_.Add(builderForValue.Build());
                return this;
            }

            public JoinGameResponse.Builder AddRangeConnectInfo(IEnumerable<ConnectInfo> values)
            {
                this.PrepareBuilder();
                this.result.connectInfo_.Add(values);
                return this;
            }

            public override JoinGameResponse BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override JoinGameResponse.Builder Clear()
            {
                this.result = JoinGameResponse.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public JoinGameResponse.Builder ClearConnectInfo()
            {
                this.PrepareBuilder();
                this.result.connectInfo_.Clear();
                return this;
            }

            public JoinGameResponse.Builder ClearQueued()
            {
                this.PrepareBuilder();
                this.result.hasQueued = false;
                this.result.queued_ = false;
                return this;
            }

            public JoinGameResponse.Builder ClearRequestId()
            {
                this.PrepareBuilder();
                this.result.hasRequestId = false;
                this.result.requestId_ = 0L;
                return this;
            }

            public override JoinGameResponse.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new JoinGameResponse.Builder(this.result);
                }
                return new JoinGameResponse.Builder().MergeFrom(this.result);
            }

            public ConnectInfo GetConnectInfo(int index)
            {
                return this.result.GetConnectInfo(index);
            }

            public override JoinGameResponse.Builder MergeFrom(JoinGameResponse other)
            {
                if (other != JoinGameResponse.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasRequestId)
                    {
                        this.RequestId = other.RequestId;
                    }
                    if (other.HasQueued)
                    {
                        this.Queued = other.Queued;
                    }
                    if (other.connectInfo_.Count != 0)
                    {
                        this.result.connectInfo_.Add(other.connectInfo_);
                    }
                }
                return this;
            }

            public override JoinGameResponse.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override JoinGameResponse.Builder MergeFrom(IMessageLite other)
            {
                if (other is JoinGameResponse)
                {
                    return this.MergeFrom((JoinGameResponse) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override JoinGameResponse.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(JoinGameResponse._joinGameResponseFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = JoinGameResponse._joinGameResponseFieldTags[index];
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

                        case 9:
                        {
                            this.result.hasRequestId = input.ReadFixed64(ref this.result.requestId_);
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasQueued = input.ReadBool(ref this.result.queued_);
                            continue;
                        }
                        case 0x1a:
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
                    input.ReadMessageArray<ConnectInfo>(num, str, this.result.connectInfo_, ConnectInfo.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private JoinGameResponse PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    JoinGameResponse result = this.result;
                    this.result = new JoinGameResponse();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public JoinGameResponse.Builder SetConnectInfo(int index, ConnectInfo value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.connectInfo_[index] = value;
                return this;
            }

            public JoinGameResponse.Builder SetConnectInfo(int index, ConnectInfo.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.connectInfo_[index] = builderForValue.Build();
                return this;
            }

            public JoinGameResponse.Builder SetQueued(bool value)
            {
                this.PrepareBuilder();
                this.result.hasQueued = true;
                this.result.queued_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public JoinGameResponse.Builder SetRequestId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasRequestId = true;
                this.result.requestId_ = value;
                return this;
            }

            public int ConnectInfoCount
            {
                get
                {
                    return this.result.ConnectInfoCount;
                }
            }

            public IPopsicleList<ConnectInfo> ConnectInfoList
            {
                get
                {
                    return this.PrepareBuilder().connectInfo_;
                }
            }

            public override JoinGameResponse DefaultInstanceForType
            {
                get
                {
                    return JoinGameResponse.DefaultInstance;
                }
            }

            public bool HasQueued
            {
                get
                {
                    return this.result.hasQueued;
                }
            }

            public bool HasRequestId
            {
                get
                {
                    return this.result.hasRequestId;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override JoinGameResponse MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public bool Queued
            {
                get
                {
                    return this.result.Queued;
                }
                set
                {
                    this.SetQueued(value);
                }
            }

            [CLSCompliant(false)]
            public ulong RequestId
            {
                get
                {
                    return this.result.RequestId;
                }
                set
                {
                    this.SetRequestId(value);
                }
            }

            protected override JoinGameResponse.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

