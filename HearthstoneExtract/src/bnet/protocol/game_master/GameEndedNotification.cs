namespace bnet.protocol.game_master
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class GameEndedNotification : GeneratedMessageLite<GameEndedNotification, Builder>
    {
        private static readonly string[] _gameEndedNotificationFieldNames = new string[] { "game_handle", "reason" };
        private static readonly uint[] _gameEndedNotificationFieldTags = new uint[] { 10, 0x10 };
        private static readonly GameEndedNotification defaultInstance = new GameEndedNotification().MakeReadOnly();
        private bnet.protocol.game_master.GameHandle gameHandle_;
        public const int GameHandleFieldNumber = 1;
        private bool hasGameHandle;
        private bool hasReason;
        private int memoizedSerializedSize = -1;
        private uint reason_;
        public const int ReasonFieldNumber = 2;

        static GameEndedNotification()
        {
            object.ReferenceEquals(GameMaster.Descriptor, null);
        }

        private GameEndedNotification()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GameEndedNotification prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GameEndedNotification notification = obj as GameEndedNotification;
            if (notification == null)
            {
                return false;
            }
            if ((this.hasGameHandle != notification.hasGameHandle) || (this.hasGameHandle && !this.gameHandle_.Equals(notification.gameHandle_)))
            {
                return false;
            }
            return ((this.hasReason == notification.hasReason) && (!this.hasReason || this.reason_.Equals(notification.reason_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasGameHandle)
            {
                hashCode ^= this.gameHandle_.GetHashCode();
            }
            if (this.hasReason)
            {
                hashCode ^= this.reason_.GetHashCode();
            }
            return hashCode;
        }

        private GameEndedNotification MakeReadOnly()
        {
            return this;
        }

        public static GameEndedNotification ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GameEndedNotification ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameEndedNotification ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GameEndedNotification ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GameEndedNotification ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GameEndedNotification ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GameEndedNotification ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GameEndedNotification ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameEndedNotification ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameEndedNotification ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GameEndedNotification, Builder>.PrintField("game_handle", this.hasGameHandle, this.gameHandle_, writer);
            GeneratedMessageLite<GameEndedNotification, Builder>.PrintField("reason", this.hasReason, this.reason_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _gameEndedNotificationFieldNames;
            if (this.hasGameHandle)
            {
                output.WriteMessage(1, strArray[0], this.GameHandle);
            }
            if (this.hasReason)
            {
                output.WriteUInt32(2, strArray[1], this.Reason);
            }
        }

        public static GameEndedNotification DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GameEndedNotification DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
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

        public bool HasGameHandle
        {
            get
            {
                return this.hasGameHandle;
            }
        }

        public bool HasReason
        {
            get
            {
                return this.hasReason;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasGameHandle)
                {
                    return false;
                }
                if (!this.GameHandle.IsInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        [CLSCompliant(false)]
        public uint Reason
        {
            get
            {
                return this.reason_;
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
                    if (this.hasGameHandle)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.GameHandle);
                    }
                    if (this.hasReason)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(2, this.Reason);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override GameEndedNotification ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<GameEndedNotification, GameEndedNotification.Builder>
        {
            private GameEndedNotification result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GameEndedNotification.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GameEndedNotification cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override GameEndedNotification BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GameEndedNotification.Builder Clear()
            {
                this.result = GameEndedNotification.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GameEndedNotification.Builder ClearGameHandle()
            {
                this.PrepareBuilder();
                this.result.hasGameHandle = false;
                this.result.gameHandle_ = null;
                return this;
            }

            public GameEndedNotification.Builder ClearReason()
            {
                this.PrepareBuilder();
                this.result.hasReason = false;
                this.result.reason_ = 0;
                return this;
            }

            public override GameEndedNotification.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GameEndedNotification.Builder(this.result);
                }
                return new GameEndedNotification.Builder().MergeFrom(this.result);
            }

            public override GameEndedNotification.Builder MergeFrom(GameEndedNotification other)
            {
                if (other != GameEndedNotification.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasGameHandle)
                    {
                        this.MergeGameHandle(other.GameHandle);
                    }
                    if (other.HasReason)
                    {
                        this.Reason = other.Reason;
                    }
                }
                return this;
            }

            public override GameEndedNotification.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GameEndedNotification.Builder MergeFrom(IMessageLite other)
            {
                if (other is GameEndedNotification)
                {
                    return this.MergeFrom((GameEndedNotification) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GameEndedNotification.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GameEndedNotification._gameEndedNotificationFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GameEndedNotification._gameEndedNotificationFieldTags[index];
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
                            bnet.protocol.game_master.GameHandle.Builder builder = bnet.protocol.game_master.GameHandle.CreateBuilder();
                            if (this.result.hasGameHandle)
                            {
                                builder.MergeFrom(this.GameHandle);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.GameHandle = builder.BuildPartial();
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
                    this.result.hasReason = input.ReadUInt32(ref this.result.reason_);
                }
                return this;
            }

            public GameEndedNotification.Builder MergeGameHandle(bnet.protocol.game_master.GameHandle value)
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

            private GameEndedNotification PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GameEndedNotification result = this.result;
                    this.result = new GameEndedNotification();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public GameEndedNotification.Builder SetGameHandle(bnet.protocol.game_master.GameHandle value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasGameHandle = true;
                this.result.gameHandle_ = value;
                return this;
            }

            public GameEndedNotification.Builder SetGameHandle(bnet.protocol.game_master.GameHandle.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasGameHandle = true;
                this.result.gameHandle_ = builderForValue.Build();
                return this;
            }

            [CLSCompliant(false)]
            public GameEndedNotification.Builder SetReason(uint value)
            {
                this.PrepareBuilder();
                this.result.hasReason = true;
                this.result.reason_ = value;
                return this;
            }

            public override GameEndedNotification DefaultInstanceForType
            {
                get
                {
                    return GameEndedNotification.DefaultInstance;
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

            public bool HasGameHandle
            {
                get
                {
                    return this.result.hasGameHandle;
                }
            }

            public bool HasReason
            {
                get
                {
                    return this.result.hasReason;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override GameEndedNotification MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            [CLSCompliant(false)]
            public uint Reason
            {
                get
                {
                    return this.result.Reason;
                }
                set
                {
                    this.SetReason(value);
                }
            }

            protected override GameEndedNotification.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

