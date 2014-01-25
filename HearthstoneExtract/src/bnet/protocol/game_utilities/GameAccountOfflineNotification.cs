namespace bnet.protocol.game_utilities
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class GameAccountOfflineNotification : GeneratedMessageLite<GameAccountOfflineNotification, Builder>
    {
        private static readonly string[] _gameAccountOfflineNotificationFieldNames = new string[] { "game_account_id", "host" };
        private static readonly uint[] _gameAccountOfflineNotificationFieldTags = new uint[] { 10, 0x12 };
        private static readonly GameAccountOfflineNotification defaultInstance = new GameAccountOfflineNotification().MakeReadOnly();
        private EntityId gameAccountId_;
        public const int GameAccountIdFieldNumber = 1;
        private bool hasGameAccountId;
        private bool hasHost;
        private ProcessId host_;
        public const int HostFieldNumber = 2;
        private int memoizedSerializedSize = -1;

        static GameAccountOfflineNotification()
        {
            object.ReferenceEquals(GameUtils.Descriptor, null);
        }

        private GameAccountOfflineNotification()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GameAccountOfflineNotification prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GameAccountOfflineNotification notification = obj as GameAccountOfflineNotification;
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

        private GameAccountOfflineNotification MakeReadOnly()
        {
            return this;
        }

        public static GameAccountOfflineNotification ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GameAccountOfflineNotification ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameAccountOfflineNotification ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GameAccountOfflineNotification ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GameAccountOfflineNotification ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GameAccountOfflineNotification ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GameAccountOfflineNotification ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GameAccountOfflineNotification ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameAccountOfflineNotification ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameAccountOfflineNotification ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GameAccountOfflineNotification, Builder>.PrintField("game_account_id", this.hasGameAccountId, this.gameAccountId_, writer);
            GeneratedMessageLite<GameAccountOfflineNotification, Builder>.PrintField("host", this.hasHost, this.host_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _gameAccountOfflineNotificationFieldNames;
            if (this.hasGameAccountId)
            {
                output.WriteMessage(1, strArray[0], this.GameAccountId);
            }
            if (this.hasHost)
            {
                output.WriteMessage(2, strArray[1], this.Host);
            }
        }

        public static GameAccountOfflineNotification DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GameAccountOfflineNotification DefaultInstanceForType
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

        protected override GameAccountOfflineNotification ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<GameAccountOfflineNotification, GameAccountOfflineNotification.Builder>
        {
            private GameAccountOfflineNotification result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GameAccountOfflineNotification.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GameAccountOfflineNotification cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override GameAccountOfflineNotification BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GameAccountOfflineNotification.Builder Clear()
            {
                this.result = GameAccountOfflineNotification.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GameAccountOfflineNotification.Builder ClearGameAccountId()
            {
                this.PrepareBuilder();
                this.result.hasGameAccountId = false;
                this.result.gameAccountId_ = null;
                return this;
            }

            public GameAccountOfflineNotification.Builder ClearHost()
            {
                this.PrepareBuilder();
                this.result.hasHost = false;
                this.result.host_ = null;
                return this;
            }

            public override GameAccountOfflineNotification.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GameAccountOfflineNotification.Builder(this.result);
                }
                return new GameAccountOfflineNotification.Builder().MergeFrom(this.result);
            }

            public override GameAccountOfflineNotification.Builder MergeFrom(GameAccountOfflineNotification other)
            {
                if (other != GameAccountOfflineNotification.DefaultInstance)
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

            public override GameAccountOfflineNotification.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GameAccountOfflineNotification.Builder MergeFrom(IMessageLite other)
            {
                if (other is GameAccountOfflineNotification)
                {
                    return this.MergeFrom((GameAccountOfflineNotification) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GameAccountOfflineNotification.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GameAccountOfflineNotification._gameAccountOfflineNotificationFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GameAccountOfflineNotification._gameAccountOfflineNotificationFieldTags[index];
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

            public GameAccountOfflineNotification.Builder MergeGameAccountId(EntityId value)
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

            public GameAccountOfflineNotification.Builder MergeHost(ProcessId value)
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

            private GameAccountOfflineNotification PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GameAccountOfflineNotification result = this.result;
                    this.result = new GameAccountOfflineNotification();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public GameAccountOfflineNotification.Builder SetGameAccountId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasGameAccountId = true;
                this.result.gameAccountId_ = value;
                return this;
            }

            public GameAccountOfflineNotification.Builder SetGameAccountId(EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasGameAccountId = true;
                this.result.gameAccountId_ = builderForValue.Build();
                return this;
            }

            public GameAccountOfflineNotification.Builder SetHost(ProcessId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasHost = true;
                this.result.host_ = value;
                return this;
            }

            public GameAccountOfflineNotification.Builder SetHost(ProcessId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasHost = true;
                this.result.host_ = builderForValue.Build();
                return this;
            }

            public override GameAccountOfflineNotification DefaultInstanceForType
            {
                get
                {
                    return GameAccountOfflineNotification.DefaultInstance;
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

            protected override GameAccountOfflineNotification MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override GameAccountOfflineNotification.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

