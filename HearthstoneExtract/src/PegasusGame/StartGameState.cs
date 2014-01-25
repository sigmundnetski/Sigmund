namespace PegasusGame
{
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class StartGameState : GeneratedMessageLite<StartGameState, Builder>
    {
        private static readonly string[] _startGameStateFieldNames = new string[] { "game_entity", "players" };
        private static readonly uint[] _startGameStateFieldTags = new uint[] { 10, 0x12 };
        private static readonly StartGameState defaultInstance = new StartGameState().MakeReadOnly();
        private Entity gameEntity_;
        public const int GameEntityFieldNumber = 1;
        private bool hasGameEntity;
        private int memoizedSerializedSize = -1;
        private PopsicleList<Player> players_ = new PopsicleList<Player>();
        public const int PlayersFieldNumber = 2;

        static StartGameState()
        {
            object.ReferenceEquals(PegasusGamelite.Descriptor, null);
        }

        private StartGameState()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(StartGameState prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            StartGameState state = obj as StartGameState;
            if (state == null)
            {
                return false;
            }
            if ((this.hasGameEntity != state.hasGameEntity) || (this.hasGameEntity && !this.gameEntity_.Equals(state.gameEntity_)))
            {
                return false;
            }
            if (this.players_.Count != state.players_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.players_.Count; i++)
            {
                if (!this.players_[i].Equals(state.players_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasGameEntity)
            {
                hashCode ^= this.gameEntity_.GetHashCode();
            }
            IEnumerator<Player> enumerator = this.players_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    Player current = enumerator.Current;
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

        public Player GetPlayers(int index)
        {
            return this.players_[index];
        }

        private StartGameState MakeReadOnly()
        {
            this.players_.MakeReadOnly();
            return this;
        }

        public static StartGameState ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static StartGameState ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static StartGameState ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static StartGameState ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static StartGameState ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static StartGameState ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static StartGameState ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static StartGameState ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static StartGameState ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static StartGameState ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<StartGameState, Builder>.PrintField("game_entity", this.hasGameEntity, this.gameEntity_, writer);
            GeneratedMessageLite<StartGameState, Builder>.PrintField<Player>("players", this.players_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _startGameStateFieldNames;
            if (this.hasGameEntity)
            {
                output.WriteMessage(1, strArray[0], this.GameEntity);
            }
            if (this.players_.Count > 0)
            {
                output.WriteMessageArray<Player>(2, strArray[1], this.players_);
            }
        }

        public static StartGameState DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override StartGameState DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public Entity GameEntity
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.gameEntity_ != null)
                {
                    goto Label_0012;
                }
                return Entity.DefaultInstance;
            }
        }

        public bool HasGameEntity
        {
            get
            {
                return this.hasGameEntity;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasGameEntity)
                {
                    return false;
                }
                if (!this.GameEntity.IsInitialized)
                {
                    return false;
                }
                IEnumerator<Player> enumerator = this.PlayersList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        Player current = enumerator.Current;
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

        public int PlayersCount
        {
            get
            {
                return this.players_.Count;
            }
        }

        public IList<Player> PlayersList
        {
            get
            {
                return this.players_;
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
                    if (this.hasGameEntity)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.GameEntity);
                    }
                    IEnumerator<Player> enumerator = this.PlayersList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            Player current = enumerator.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, current);
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

        protected override StartGameState ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<StartGameState, StartGameState.Builder>
        {
            private StartGameState result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = StartGameState.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(StartGameState cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public StartGameState.Builder AddPlayers(Player value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.players_.Add(value);
                return this;
            }

            public StartGameState.Builder AddPlayers(Player.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.players_.Add(builderForValue.Build());
                return this;
            }

            public StartGameState.Builder AddRangePlayers(IEnumerable<Player> values)
            {
                this.PrepareBuilder();
                this.result.players_.Add(values);
                return this;
            }

            public override StartGameState BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override StartGameState.Builder Clear()
            {
                this.result = StartGameState.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public StartGameState.Builder ClearGameEntity()
            {
                this.PrepareBuilder();
                this.result.hasGameEntity = false;
                this.result.gameEntity_ = null;
                return this;
            }

            public StartGameState.Builder ClearPlayers()
            {
                this.PrepareBuilder();
                this.result.players_.Clear();
                return this;
            }

            public override StartGameState.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new StartGameState.Builder(this.result);
                }
                return new StartGameState.Builder().MergeFrom(this.result);
            }

            public Player GetPlayers(int index)
            {
                return this.result.GetPlayers(index);
            }

            public override StartGameState.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override StartGameState.Builder MergeFrom(IMessageLite other)
            {
                if (other is StartGameState)
                {
                    return this.MergeFrom((StartGameState) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override StartGameState.Builder MergeFrom(StartGameState other)
            {
                if (other != StartGameState.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasGameEntity)
                    {
                        this.MergeGameEntity(other.GameEntity);
                    }
                    if (other.players_.Count != 0)
                    {
                        this.result.players_.Add(other.players_);
                    }
                }
                return this;
            }

            public override StartGameState.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(StartGameState._startGameStateFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = StartGameState._startGameStateFieldTags[index];
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
                            Entity.Builder builder = Entity.CreateBuilder();
                            if (this.result.hasGameEntity)
                            {
                                builder.MergeFrom(this.GameEntity);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.GameEntity = builder.BuildPartial();
                            continue;
                        }
                        case 0x12:
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
                    input.ReadMessageArray<Player>(num, str, this.result.players_, Player.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            public StartGameState.Builder MergeGameEntity(Entity value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasGameEntity && (this.result.gameEntity_ != Entity.DefaultInstance))
                {
                    this.result.gameEntity_ = Entity.CreateBuilder(this.result.gameEntity_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.gameEntity_ = value;
                }
                this.result.hasGameEntity = true;
                return this;
            }

            private StartGameState PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    StartGameState result = this.result;
                    this.result = new StartGameState();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public StartGameState.Builder SetGameEntity(Entity value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasGameEntity = true;
                this.result.gameEntity_ = value;
                return this;
            }

            public StartGameState.Builder SetGameEntity(Entity.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasGameEntity = true;
                this.result.gameEntity_ = builderForValue.Build();
                return this;
            }

            public StartGameState.Builder SetPlayers(int index, Player value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.players_[index] = value;
                return this;
            }

            public StartGameState.Builder SetPlayers(int index, Player.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.players_[index] = builderForValue.Build();
                return this;
            }

            public override StartGameState DefaultInstanceForType
            {
                get
                {
                    return StartGameState.DefaultInstance;
                }
            }

            public Entity GameEntity
            {
                get
                {
                    return this.result.GameEntity;
                }
                set
                {
                    this.SetGameEntity(value);
                }
            }

            public bool HasGameEntity
            {
                get
                {
                    return this.result.hasGameEntity;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override StartGameState MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int PlayersCount
            {
                get
                {
                    return this.result.PlayersCount;
                }
            }

            public IPopsicleList<Player> PlayersList
            {
                get
                {
                    return this.PrepareBuilder().players_;
                }
            }

            protected override StartGameState.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 7
            }
        }
    }
}

