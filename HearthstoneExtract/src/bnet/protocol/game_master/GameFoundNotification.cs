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

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class GameFoundNotification : GeneratedMessageLite<GameFoundNotification, Builder>
    {
        private static readonly string[] _gameFoundNotificationFieldNames = new string[] { "connect_info", "error_code", "game_handle", "request_id" };
        private static readonly uint[] _gameFoundNotificationFieldTags = new uint[] { 0x22, 0x10, 0x1a, 9 };
        private PopsicleList<ConnectInfo> connectInfo_ = new PopsicleList<ConnectInfo>();
        public const int ConnectInfoFieldNumber = 4;
        private static readonly GameFoundNotification defaultInstance = new GameFoundNotification().MakeReadOnly();
        private uint errorCode_;
        public const int ErrorCodeFieldNumber = 2;
        private bnet.protocol.game_master.GameHandle gameHandle_;
        public const int GameHandleFieldNumber = 3;
        private bool hasErrorCode;
        private bool hasGameHandle;
        private bool hasRequestId;
        private int memoizedSerializedSize = -1;
        private ulong requestId_;
        public const int RequestIdFieldNumber = 1;

        static GameFoundNotification()
        {
            object.ReferenceEquals(GameMaster.Descriptor, null);
        }

        private GameFoundNotification()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GameFoundNotification prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GameFoundNotification notification = obj as GameFoundNotification;
            if (notification == null)
            {
                return false;
            }
            if ((this.hasRequestId != notification.hasRequestId) || (this.hasRequestId && !this.requestId_.Equals(notification.requestId_)))
            {
                return false;
            }
            if ((this.hasErrorCode != notification.hasErrorCode) || (this.hasErrorCode && !this.errorCode_.Equals(notification.errorCode_)))
            {
                return false;
            }
            if ((this.hasGameHandle != notification.hasGameHandle) || (this.hasGameHandle && !this.gameHandle_.Equals(notification.gameHandle_)))
            {
                return false;
            }
            if (this.connectInfo_.Count != notification.connectInfo_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.connectInfo_.Count; i++)
            {
                if (!this.connectInfo_[i].Equals(notification.connectInfo_[i]))
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
            if (this.hasErrorCode)
            {
                hashCode ^= this.errorCode_.GetHashCode();
            }
            if (this.hasGameHandle)
            {
                hashCode ^= this.gameHandle_.GetHashCode();
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

        private GameFoundNotification MakeReadOnly()
        {
            this.connectInfo_.MakeReadOnly();
            return this;
        }

        public static GameFoundNotification ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GameFoundNotification ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameFoundNotification ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GameFoundNotification ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GameFoundNotification ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GameFoundNotification ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GameFoundNotification ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GameFoundNotification ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameFoundNotification ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameFoundNotification ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GameFoundNotification, Builder>.PrintField("request_id", this.hasRequestId, this.requestId_, writer);
            GeneratedMessageLite<GameFoundNotification, Builder>.PrintField("error_code", this.hasErrorCode, this.errorCode_, writer);
            GeneratedMessageLite<GameFoundNotification, Builder>.PrintField("game_handle", this.hasGameHandle, this.gameHandle_, writer);
            GeneratedMessageLite<GameFoundNotification, Builder>.PrintField<ConnectInfo>("connect_info", this.connectInfo_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _gameFoundNotificationFieldNames;
            if (this.hasRequestId)
            {
                output.WriteFixed64(1, strArray[3], this.RequestId);
            }
            if (this.hasErrorCode)
            {
                output.WriteUInt32(2, strArray[1], this.ErrorCode);
            }
            if (this.hasGameHandle)
            {
                output.WriteMessage(3, strArray[2], this.GameHandle);
            }
            if (this.connectInfo_.Count > 0)
            {
                output.WriteMessageArray<ConnectInfo>(4, strArray[0], this.connectInfo_);
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

        public static GameFoundNotification DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GameFoundNotification DefaultInstanceForType
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

        public bnet.protocol.game_master.GameHandle GameHandle
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.gameHandle_ != null)
                {
                    goto Label_0012;
                }
                return bnet.protocol.game_master.GameHandle.DefaultInstance;
            }
        }

        public bool HasErrorCode
        {
            get
            {
                return this.hasErrorCode;
            }
        }

        public bool HasGameHandle
        {
            get
            {
                return this.hasGameHandle;
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
                if (!this.hasRequestId)
                {
                    return false;
                }
                if (this.HasGameHandle && !this.GameHandle.IsInitialized)
                {
                    return false;
                }
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
                    if (this.hasErrorCode)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(2, this.ErrorCode);
                    }
                    if (this.hasGameHandle)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(3, this.GameHandle);
                    }
                    IEnumerator<ConnectInfo> enumerator = this.ConnectInfoList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            ConnectInfo current = enumerator.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(4, current);
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

        protected override GameFoundNotification ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<GameFoundNotification, GameFoundNotification.Builder>
        {
            private GameFoundNotification result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GameFoundNotification.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GameFoundNotification cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public GameFoundNotification.Builder AddConnectInfo(ConnectInfo value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.connectInfo_.Add(value);
                return this;
            }

            public GameFoundNotification.Builder AddConnectInfo(ConnectInfo.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.connectInfo_.Add(builderForValue.Build());
                return this;
            }

            public GameFoundNotification.Builder AddRangeConnectInfo(IEnumerable<ConnectInfo> values)
            {
                this.PrepareBuilder();
                this.result.connectInfo_.Add(values);
                return this;
            }

            public override GameFoundNotification BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GameFoundNotification.Builder Clear()
            {
                this.result = GameFoundNotification.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GameFoundNotification.Builder ClearConnectInfo()
            {
                this.PrepareBuilder();
                this.result.connectInfo_.Clear();
                return this;
            }

            public GameFoundNotification.Builder ClearErrorCode()
            {
                this.PrepareBuilder();
                this.result.hasErrorCode = false;
                this.result.errorCode_ = 0;
                return this;
            }

            public GameFoundNotification.Builder ClearGameHandle()
            {
                this.PrepareBuilder();
                this.result.hasGameHandle = false;
                this.result.gameHandle_ = null;
                return this;
            }

            public GameFoundNotification.Builder ClearRequestId()
            {
                this.PrepareBuilder();
                this.result.hasRequestId = false;
                this.result.requestId_ = 0L;
                return this;
            }

            public override GameFoundNotification.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GameFoundNotification.Builder(this.result);
                }
                return new GameFoundNotification.Builder().MergeFrom(this.result);
            }

            public ConnectInfo GetConnectInfo(int index)
            {
                return this.result.GetConnectInfo(index);
            }

            public override GameFoundNotification.Builder MergeFrom(GameFoundNotification other)
            {
                if (other != GameFoundNotification.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasRequestId)
                    {
                        this.RequestId = other.RequestId;
                    }
                    if (other.HasErrorCode)
                    {
                        this.ErrorCode = other.ErrorCode;
                    }
                    if (other.HasGameHandle)
                    {
                        this.MergeGameHandle(other.GameHandle);
                    }
                    if (other.connectInfo_.Count != 0)
                    {
                        this.result.connectInfo_.Add(other.connectInfo_);
                    }
                }
                return this;
            }

            public override GameFoundNotification.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GameFoundNotification.Builder MergeFrom(IMessageLite other)
            {
                if (other is GameFoundNotification)
                {
                    return this.MergeFrom((GameFoundNotification) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GameFoundNotification.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GameFoundNotification._gameFoundNotificationFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GameFoundNotification._gameFoundNotificationFieldTags[index];
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
                            this.result.hasErrorCode = input.ReadUInt32(ref this.result.errorCode_);
                            continue;
                        }
                        case 0x1a:
                        {
                            bnet.protocol.game_master.GameHandle.Builder builder = bnet.protocol.game_master.GameHandle.CreateBuilder();
                            if (this.result.hasGameHandle)
                            {
                                builder.MergeFrom(this.GameHandle);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.GameHandle = builder.BuildPartial();
                            continue;
                        }
                        case 0x22:
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

            public GameFoundNotification.Builder MergeGameHandle(bnet.protocol.game_master.GameHandle value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasGameHandle && (this.result.gameHandle_ != bnet.protocol.game_master.GameHandle.DefaultInstance))
                {
                    this.result.gameHandle_ = bnet.protocol.game_master.GameHandle.CreateBuilder(this.result.gameHandle_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.gameHandle_ = value;
                }
                this.result.hasGameHandle = true;
                return this;
            }

            private GameFoundNotification PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GameFoundNotification result = this.result;
                    this.result = new GameFoundNotification();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public GameFoundNotification.Builder SetConnectInfo(int index, ConnectInfo value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.connectInfo_[index] = value;
                return this;
            }

            public GameFoundNotification.Builder SetConnectInfo(int index, ConnectInfo.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.connectInfo_[index] = builderForValue.Build();
                return this;
            }

            [CLSCompliant(false)]
            public GameFoundNotification.Builder SetErrorCode(uint value)
            {
                this.PrepareBuilder();
                this.result.hasErrorCode = true;
                this.result.errorCode_ = value;
                return this;
            }

            public GameFoundNotification.Builder SetGameHandle(bnet.protocol.game_master.GameHandle value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasGameHandle = true;
                this.result.gameHandle_ = value;
                return this;
            }

            public GameFoundNotification.Builder SetGameHandle(bnet.protocol.game_master.GameHandle.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasGameHandle = true;
                this.result.gameHandle_ = builderForValue.Build();
                return this;
            }

            [CLSCompliant(false)]
            public GameFoundNotification.Builder SetRequestId(ulong value)
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

            public override GameFoundNotification DefaultInstanceForType
            {
                get
                {
                    return GameFoundNotification.DefaultInstance;
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

            public bnet.protocol.game_master.GameHandle GameHandle
            {
                get
                {
                    return this.result.GameHandle;
                }
                set
                {
                    this.SetGameHandle(value);
                }
            }

            public bool HasErrorCode
            {
                get
                {
                    return this.result.hasErrorCode;
                }
            }

            public bool HasGameHandle
            {
                get
                {
                    return this.result.hasGameHandle;
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

            protected override GameFoundNotification MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
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

            protected override GameFoundNotification.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

