namespace PegasusGame
{
    using Google.ProtocolBuffers;
    using PegasusShared;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class Player : GeneratedMessageLite<Player, Builder>
    {
        private static readonly string[] _playerFieldNames = new string[] { "entity", "gameAccountId", "id" };
        private static readonly uint[] _playerFieldTags = new uint[] { 0x22, 0x12, 8 };
        private static readonly Player defaultInstance = new Player().MakeReadOnly();
        private PegasusGame.Entity entity_;
        public const int EntityFieldNumber = 4;
        private BnetId gameAccountId_;
        public const int GameAccountIdFieldNumber = 2;
        private bool hasEntity;
        private bool hasGameAccountId;
        private bool hasId;
        private int id_;
        public const int IdFieldNumber = 1;
        private int memoizedSerializedSize = -1;

        static Player()
        {
            object.ReferenceEquals(PegasusGamelite.Descriptor, null);
        }

        private Player()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(Player prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            Player player = obj as Player;
            if (player == null)
            {
                return false;
            }
            if ((this.hasId != player.hasId) || (this.hasId && !this.id_.Equals(player.id_)))
            {
                return false;
            }
            if ((this.hasGameAccountId != player.hasGameAccountId) || (this.hasGameAccountId && !this.gameAccountId_.Equals(player.gameAccountId_)))
            {
                return false;
            }
            return ((this.hasEntity == player.hasEntity) && (!this.hasEntity || this.entity_.Equals(player.entity_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasId)
            {
                hashCode ^= this.id_.GetHashCode();
            }
            if (this.hasGameAccountId)
            {
                hashCode ^= this.gameAccountId_.GetHashCode();
            }
            if (this.hasEntity)
            {
                hashCode ^= this.entity_.GetHashCode();
            }
            return hashCode;
        }

        private Player MakeReadOnly()
        {
            return this;
        }

        public static Player ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static Player ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static Player ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Player ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Player ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Player ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Player ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static Player ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Player ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Player ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<Player, Builder>.PrintField("id", this.hasId, this.id_, writer);
            GeneratedMessageLite<Player, Builder>.PrintField("gameAccountId", this.hasGameAccountId, this.gameAccountId_, writer);
            GeneratedMessageLite<Player, Builder>.PrintField("entity", this.hasEntity, this.entity_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _playerFieldNames;
            if (this.hasId)
            {
                output.WriteInt32(1, strArray[2], this.Id);
            }
            if (this.hasGameAccountId)
            {
                output.WriteMessage(2, strArray[1], this.GameAccountId);
            }
            if (this.hasEntity)
            {
                output.WriteMessage(4, strArray[0], this.Entity);
            }
        }

        public static Player DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override Player DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public PegasusGame.Entity Entity
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.entity_ != null)
                {
                    goto Label_0012;
                }
                return PegasusGame.Entity.DefaultInstance;
            }
        }

        public BnetId GameAccountId
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.gameAccountId_ != null)
                {
                    goto Label_0012;
                }
                return BnetId.DefaultInstance;
            }
        }

        public bool HasEntity
        {
            get
            {
                return this.hasEntity;
            }
        }

        public bool HasGameAccountId
        {
            get
            {
                return this.hasGameAccountId;
            }
        }

        public bool HasId
        {
            get
            {
                return this.hasId;
            }
        }

        public int Id
        {
            get
            {
                return this.id_;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasId)
                {
                    return false;
                }
                if (!this.hasGameAccountId)
                {
                    return false;
                }
                if (!this.hasEntity)
                {
                    return false;
                }
                if (!this.GameAccountId.IsInitialized)
                {
                    return false;
                }
                if (!this.Entity.IsInitialized)
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
                    if (this.hasId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.Id);
                    }
                    if (this.hasGameAccountId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, this.GameAccountId);
                    }
                    if (this.hasEntity)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(4, this.Entity);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override Player ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<Player, Player.Builder>
        {
            private Player result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = Player.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(Player cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override Player BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override Player.Builder Clear()
            {
                this.result = Player.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public Player.Builder ClearEntity()
            {
                this.PrepareBuilder();
                this.result.hasEntity = false;
                this.result.entity_ = null;
                return this;
            }

            public Player.Builder ClearGameAccountId()
            {
                this.PrepareBuilder();
                this.result.hasGameAccountId = false;
                this.result.gameAccountId_ = null;
                return this;
            }

            public Player.Builder ClearId()
            {
                this.PrepareBuilder();
                this.result.hasId = false;
                this.result.id_ = 0;
                return this;
            }

            public override Player.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new Player.Builder(this.result);
                }
                return new Player.Builder().MergeFrom(this.result);
            }

            public Player.Builder MergeEntity(PegasusGame.Entity value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasEntity && (this.result.entity_ != PegasusGame.Entity.DefaultInstance))
                {
                    this.result.entity_ = PegasusGame.Entity.CreateBuilder(this.result.entity_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.entity_ = value;
                }
                this.result.hasEntity = true;
                return this;
            }

            public override Player.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override Player.Builder MergeFrom(IMessageLite other)
            {
                if (other is Player)
                {
                    return this.MergeFrom((Player) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override Player.Builder MergeFrom(Player other)
            {
                if (other != Player.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasId)
                    {
                        this.Id = other.Id;
                    }
                    if (other.HasGameAccountId)
                    {
                        this.MergeGameAccountId(other.GameAccountId);
                    }
                    if (other.HasEntity)
                    {
                        this.MergeEntity(other.Entity);
                    }
                }
                return this;
            }

            public override Player.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(Player._playerFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = Player._playerFieldTags[index];
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
                        {
                            this.result.hasId = input.ReadInt32(ref this.result.id_);
                            continue;
                        }
                        case 0x12:
                        {
                            BnetId.Builder builder = BnetId.CreateBuilder();
                            if (this.result.hasGameAccountId)
                            {
                                builder.MergeFrom(this.GameAccountId);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.GameAccountId = builder.BuildPartial();
                            continue;
                        }
                        case 0x22:
                        {
                            PegasusGame.Entity.Builder builder2 = PegasusGame.Entity.CreateBuilder();
                            if (this.result.hasEntity)
                            {
                                builder2.MergeFrom(this.Entity);
                            }
                            input.ReadMessage(builder2, extensionRegistry);
                            this.Entity = builder2.BuildPartial();
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

            public Player.Builder MergeGameAccountId(BnetId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasGameAccountId && (this.result.gameAccountId_ != BnetId.DefaultInstance))
                {
                    this.result.gameAccountId_ = BnetId.CreateBuilder(this.result.gameAccountId_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.gameAccountId_ = value;
                }
                this.result.hasGameAccountId = true;
                return this;
            }

            private Player PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    Player result = this.result;
                    this.result = new Player();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public Player.Builder SetEntity(PegasusGame.Entity value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasEntity = true;
                this.result.entity_ = value;
                return this;
            }

            public Player.Builder SetEntity(PegasusGame.Entity.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasEntity = true;
                this.result.entity_ = builderForValue.Build();
                return this;
            }

            public Player.Builder SetGameAccountId(BnetId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasGameAccountId = true;
                this.result.gameAccountId_ = value;
                return this;
            }

            public Player.Builder SetGameAccountId(BnetId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasGameAccountId = true;
                this.result.gameAccountId_ = builderForValue.Build();
                return this;
            }

            public Player.Builder SetId(int value)
            {
                this.PrepareBuilder();
                this.result.hasId = true;
                this.result.id_ = value;
                return this;
            }

            public override Player DefaultInstanceForType
            {
                get
                {
                    return Player.DefaultInstance;
                }
            }

            public PegasusGame.Entity Entity
            {
                get
                {
                    return this.result.Entity;
                }
                set
                {
                    this.SetEntity(value);
                }
            }

            public BnetId GameAccountId
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

            public bool HasEntity
            {
                get
                {
                    return this.result.hasEntity;
                }
            }

            public bool HasGameAccountId
            {
                get
                {
                    return this.result.hasGameAccountId;
                }
            }

            public bool HasId
            {
                get
                {
                    return this.result.hasId;
                }
            }

            public int Id
            {
                get
                {
                    return this.result.Id;
                }
                set
                {
                    this.SetId(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override Player MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override Player.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

