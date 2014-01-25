namespace bnet.protocol.game_utilities
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class GameAccountOnlineNotification : GeneratedMessageLite<GameAccountOnlineNotification, Builder>
    {
        private static readonly string[] _gameAccountOnlineNotificationFieldNames = new string[] { "game_account_id", "host" };
        private static readonly uint[] _gameAccountOnlineNotificationFieldTags = new uint[] { 10, 0x12 };
        private static readonly GameAccountOnlineNotification defaultInstance = new GameAccountOnlineNotification().MakeReadOnly();
        private EntityId gameAccountId_;
        public const int GameAccountIdFieldNumber = 1;
        private bool hasGameAccountId;
        private bool hasHost;
        private ProcessId host_;
        public const int HostFieldNumber = 2;
        private int memoizedSerializedSize = -1;

        static GameAccountOnlineNotification()
        {
            object.ReferenceEquals(GameUtils.Descriptor, null);
        }

        private GameAccountOnlineNotification()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GameAccountOnlineNotification prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GameAccountOnlineNotification notification = obj as GameAccountOnlineNotification;
            if (notification == null)
            {
                return false;
            }
            if ((this.hasGameAccountId != notification.hasGameAccountId) || (this.hasGameAccountId && !this.gameAccountId_.Equals(notification.gameAccountId_)))
            {
                return false;
            }
            return ((this.hasHost == notification.hasHost) && (!this.hasHost || this.host_.Equals(notification.host_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasGameAccountId)
            {
                hashCode ^= this.gameAccountId_.GetHashCode();
            }
            if (this.hasHost)
            {
                hashCode ^= this.host_.GetHashCode();
            }
            return hashCode;
        }

        private GameAccountOnlineNotification MakeReadOnly()
        {
            return this;
        }

        public static GameAccountOnlineNotification ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GameAccountOnlineNotification ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameAccountOnlineNotification ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GameAccountOnlineNotification ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GameAccountOnlineNotification ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GameAccountOnlineNotification ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GameAccountOnlineNotification ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GameAccountOnlineNotification ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameAccountOnlineNotification ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameAccountOnlineNotification ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GameAccountOnlineNotification, Builder>.PrintField("game_account_id", this.hasGameAccountId, this.gameAccountId_, writer);
            GeneratedMessageLite<GameAccountOnlineNotification, Builder>.PrintField("host", this.hasHost, this.host_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _gameAccountOnlineNotificationFieldNames;
            if (this.hasGameAccountId)
            {
                output.WriteMessage(1, strArray[0], this.GameAccountId);
            }
            if (this.hasHost)
            {
                output.WriteMessage(2, strArray[1], this.Host);
            }
        }

        public static GameAccountOnlineNotification DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GameAccountOnlineNotification DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public EntityId GameAccountId
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.gameAccountId_ != null)
                {
                    goto Label_0012;
                }
                return EntityId.DefaultInstance;
            }
        }

        public bool HasGameAccountId
        {
            get
            {
                return this.hasGameAccountId;
            }
        }

        public bool HasHost
        {
            get
            {
                return this.hasHost;
            }
        }

        public ProcessId Host
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.host_ != null)
                {
                    goto Label_0012;
                }
                return ProcessId.DefaultInstance;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasGameAccountId)
                {
                    return false;
                }
                if (!this.GameAccountId.IsInitialized)
                {
                    return false;
                }
                if (this.HasHost && !this.Host.IsInitialized)
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
                    if (this.hasGameAccountId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.GameAccountId);
                    }
                    if (this.hasHost)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, this.Host);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override GameAccountOnlineNotification ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<GameAccountOnlineNotification, GameAccountOnlineNotification.Builder>
        {
            private GameAccountOnlineNotification result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GameAccountOnlineNotification.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GameAccountOnlineNotification cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override GameAccountOnlineNotification BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GameAccountOnlineNotification.Builder Clear()
            {
                this.result = GameAccountOnlineNotification.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GameAccountOnlineNotification.Builder ClearGameAccountId()
            {
                this.PrepareBuilder();
                this.result.hasGameAccountId = false;
                this.result.gameAccountId_ = null;
                return this;
            }

            public GameAccountOnlineNotification.Builder ClearHost()
            {
                this.PrepareBuilder();
                this.result.hasHost = false;
                this.result.host_ = null;
                return this;
            }

            public override GameAccountOnlineNotification.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GameAccountOnlineNotification.Builder(this.result);
                }
                return new GameAccountOnlineNotification.Builder().MergeFrom(this.result);
            }

            public override GameAccountOnlineNotification.Builder MergeFrom(GameAccountOnlineNotification other)
            {
                if (other != GameAccountOnlineNotification.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasGameAccountId)
                    {
                        this.MergeGameAccountId(other.GameAccountId);
                    }
                    if (other.HasHost)
                    {
                        this.MergeHost(other.Host);
                    }
                }
                return this;
            }

            public override GameAccountOnlineNotification.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GameAccountOnlineNotification.Builder MergeFrom(IMessageLite other)
            {
                if (other is GameAccountOnlineNotification)
                {
                    return this.MergeFrom((GameAccountOnlineNotification) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GameAccountOnlineNotification.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GameAccountOnlineNotification._gameAccountOnlineNotificationFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GameAccountOnlineNotification._gameAccountOnlineNotificationFieldTags[index];
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
                            EntityId.Builder builder = EntityId.CreateBuilder();
                            if (this.result.hasGameAccountId)
                            {
                                builder.MergeFrom(this.GameAccountId);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.GameAccountId = builder.BuildPartial();
                            continue;
                        }
                        case 0x12:
                        {
                            ProcessId.Builder builder2 = ProcessId.CreateBuilder();
                            if (this.result.hasHost)
                            {
                                builder2.MergeFrom(this.Host);
                            }
                            input.ReadMessage(builder2, extensionRegistry);
                            this.Host = builder2.BuildPartial();
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

            public GameAccountOnlineNotification.Builder MergeGameAccountId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasGameAccountId && (this.result.gameAccountId_ != EntityId.DefaultInstance))
                {
                    this.result.gameAccountId_ = EntityId.CreateBuilder(this.result.gameAccountId_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.gameAccountId_ = value;
                }
                this.result.hasGameAccountId = true;
                return this;
            }

            public GameAccountOnlineNotification.Builder MergeHost(ProcessId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasHost && (this.result.host_ != ProcessId.DefaultInstance))
                {
                    this.result.host_ = ProcessId.CreateBuilder(this.result.host_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.host_ = value;
                }
                this.result.hasHost = true;
                return this;
            }

            private GameAccountOnlineNotification PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GameAccountOnlineNotification result = this.result;
                    this.result = new GameAccountOnlineNotification();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public GameAccountOnlineNotification.Builder SetGameAccountId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasGameAccountId = true;
                this.result.gameAccountId_ = value;
                return this;
            }

            public GameAccountOnlineNotification.Builder SetGameAccountId(EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasGameAccountId = true;
                this.result.gameAccountId_ = builderForValue.Build();
                return this;
            }

            public GameAccountOnlineNotification.Builder SetHost(ProcessId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasHost = true;
                this.result.host_ = value;
                return this;
            }

            public GameAccountOnlineNotification.Builder SetHost(ProcessId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasHost = true;
                this.result.host_ = builderForValue.Build();
                return this;
            }

            public override GameAccountOnlineNotification DefaultInstanceForType
            {
                get
                {
                    return GameAccountOnlineNotification.DefaultInstance;
                }
            }

            public EntityId GameAccountId
            {
                get
                {
                    return this.result.GameAccountId;
                }
                set
                {
                    this.SetGameAccountId(value);
                }
            }

            public bool HasGameAccountId
            {
                get
                {
                    return this.result.hasGameAccountId;
                }
            }

            public bool HasHost
            {
                get
                {
                    return this.result.hasHost;
                }
            }

            public ProcessId Host
            {
                get
                {
                    return this.result.Host;
                }
                set
                {
                    this.SetHost(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override GameAccountOnlineNotification MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override GameAccountOnlineNotification.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

