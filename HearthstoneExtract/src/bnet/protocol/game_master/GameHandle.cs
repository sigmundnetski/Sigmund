namespace bnet.protocol.game_master
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class GameHandle : GeneratedMessageLite<GameHandle, Builder>
    {
        private static readonly string[] _gameHandleFieldNames = new string[] { "factory_id", "game_id" };
        private static readonly uint[] _gameHandleFieldTags = new uint[] { 9, 0x12 };
        private static readonly GameHandle defaultInstance = new GameHandle().MakeReadOnly();
        private ulong factoryId_;
        public const int FactoryIdFieldNumber = 1;
        private EntityId gameId_;
        public const int GameIdFieldNumber = 2;
        private bool hasFactoryId;
        private bool hasGameId;
        private int memoizedSerializedSize = -1;

        static GameHandle()
        {
            object.ReferenceEquals(GameMaster.Descriptor, null);
        }

        private GameHandle()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GameHandle prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GameHandle handle = obj as GameHandle;
            if (handle == null)
            {
                return false;
            }
            if ((this.hasFactoryId != handle.hasFactoryId) || (this.hasFactoryId && !this.factoryId_.Equals(handle.factoryId_)))
            {
                return false;
            }
            return ((this.hasGameId == handle.hasGameId) && (!this.hasGameId || this.gameId_.Equals(handle.gameId_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasFactoryId)
            {
                hashCode ^= this.factoryId_.GetHashCode();
            }
            if (this.hasGameId)
            {
                hashCode ^= this.gameId_.GetHashCode();
            }
            return hashCode;
        }

        private GameHandle MakeReadOnly()
        {
            return this;
        }

        public static GameHandle ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GameHandle ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameHandle ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GameHandle ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GameHandle ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GameHandle ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GameHandle ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GameHandle ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameHandle ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameHandle ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GameHandle, Builder>.PrintField("factory_id", this.hasFactoryId, this.factoryId_, writer);
            GeneratedMessageLite<GameHandle, Builder>.PrintField("game_id", this.hasGameId, this.gameId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _gameHandleFieldNames;
            if (this.hasFactoryId)
            {
                output.WriteFixed64(1, strArray[0], this.FactoryId);
            }
            if (this.hasGameId)
            {
                output.WriteMessage(2, strArray[1], this.GameId);
            }
        }

        public static GameHandle DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GameHandle DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        [CLSCompliant(false)]
        public ulong FactoryId
        {
            get
            {
                return this.factoryId_;
            }
        }

        public EntityId GameId
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.gameId_ != null)
                {
                    goto Label_0012;
                }
                return EntityId.DefaultInstance;
            }
        }

        public bool HasFactoryId
        {
            get
            {
                return this.hasFactoryId;
            }
        }

        public bool HasGameId
        {
            get
            {
                return this.hasGameId;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasFactoryId)
                {
                    return false;
                }
                if (!this.hasGameId)
                {
                    return false;
                }
                if (!this.GameId.IsInitialized)
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
                    if (this.hasFactoryId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed64Size(1, this.FactoryId);
                    }
                    if (this.hasGameId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, this.GameId);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override GameHandle ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<GameHandle, GameHandle.Builder>
        {
            private GameHandle result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GameHandle.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GameHandle cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override GameHandle BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GameHandle.Builder Clear()
            {
                this.result = GameHandle.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GameHandle.Builder ClearFactoryId()
            {
                this.PrepareBuilder();
                this.result.hasFactoryId = false;
                this.result.factoryId_ = 0L;
                return this;
            }

            public GameHandle.Builder ClearGameId()
            {
                this.PrepareBuilder();
                this.result.hasGameId = false;
                this.result.gameId_ = null;
                return this;
            }

            public override GameHandle.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GameHandle.Builder(this.result);
                }
                return new GameHandle.Builder().MergeFrom(this.result);
            }

            public override GameHandle.Builder MergeFrom(GameHandle other)
            {
                if (other != GameHandle.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasFactoryId)
                    {
                        this.FactoryId = other.FactoryId;
                    }
                    if (other.HasGameId)
                    {
                        this.MergeGameId(other.GameId);
                    }
                }
                return this;
            }

            public override GameHandle.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GameHandle.Builder MergeFrom(IMessageLite other)
            {
                if (other is GameHandle)
                {
                    return this.MergeFrom((GameHandle) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GameHandle.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GameHandle._gameHandleFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GameHandle._gameHandleFieldTags[index];
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
                            this.result.hasFactoryId = input.ReadFixed64(ref this.result.factoryId_);
                            continue;
                        }
                        case 0x12:
                        {
                            EntityId.Builder builder = EntityId.CreateBuilder();
                            if (this.result.hasGameId)
                            {
                                builder.MergeFrom(this.GameId);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.GameId = builder.BuildPartial();
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

            public GameHandle.Builder MergeGameId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasGameId && (this.result.gameId_ != EntityId.DefaultInstance))
                {
                    this.result.gameId_ = EntityId.CreateBuilder(this.result.gameId_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.gameId_ = value;
                }
                this.result.hasGameId = true;
                return this;
            }

            private GameHandle PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GameHandle result = this.result;
                    this.result = new GameHandle();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public GameHandle.Builder SetFactoryId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasFactoryId = true;
                this.result.factoryId_ = value;
                return this;
            }

            public GameHandle.Builder SetGameId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasGameId = true;
                this.result.gameId_ = value;
                return this;
            }

            public GameHandle.Builder SetGameId(EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasGameId = true;
                this.result.gameId_ = builderForValue.Build();
                return this;
            }

            public override GameHandle DefaultInstanceForType
            {
                get
                {
                    return GameHandle.DefaultInstance;
                }
            }

            [CLSCompliant(false)]
            public ulong FactoryId
            {
                get
                {
                    return this.result.FactoryId;
                }
                set
                {
                    this.SetFactoryId(value);
                }
            }

            public EntityId GameId
            {
                get
                {
                    return this.result.GameId;
                }
                set
                {
                    this.SetGameId(value);
                }
            }

            public bool HasFactoryId
            {
                get
                {
                    return this.result.hasFactoryId;
                }
            }

            public bool HasGameId
            {
                get
                {
                    return this.result.hasGameId;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override GameHandle MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override GameHandle.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

