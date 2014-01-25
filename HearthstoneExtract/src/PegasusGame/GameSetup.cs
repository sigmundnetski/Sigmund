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

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class GameSetup : GeneratedMessageLite<GameSetup, Builder>
    {
        private static readonly string[] _gameSetupFieldNames = new string[] { "board", "clients", "max_friendly_minions_per_player", "max_secrets_per_player" };
        private static readonly uint[] _gameSetupFieldTags = new uint[] { 10, 0x12, 0x20, 0x18 };
        private string board_ = string.Empty;
        public const int BoardFieldNumber = 1;
        private PopsicleList<ClientInfo> clients_ = new PopsicleList<ClientInfo>();
        public const int ClientsFieldNumber = 2;
        private static readonly GameSetup defaultInstance = new GameSetup().MakeReadOnly();
        private bool hasBoard;
        private bool hasMaxFriendlyMinionsPerPlayer;
        private bool hasMaxSecretsPerPlayer;
        private int maxFriendlyMinionsPerPlayer_;
        public const int MaxFriendlyMinionsPerPlayerFieldNumber = 4;
        private int maxSecretsPerPlayer_;
        public const int MaxSecretsPerPlayerFieldNumber = 3;
        private int memoizedSerializedSize = -1;

        static GameSetup()
        {
            object.ReferenceEquals(PegasusGamelite.Descriptor, null);
        }

        private GameSetup()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GameSetup prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GameSetup setup = obj as GameSetup;
            if (setup == null)
            {
                return false;
            }
            if ((this.hasBoard != setup.hasBoard) || (this.hasBoard && !this.board_.Equals(setup.board_)))
            {
                return false;
            }
            if (this.clients_.Count != setup.clients_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.clients_.Count; i++)
            {
                if (!this.clients_[i].Equals(setup.clients_[i]))
                {
                    return false;
                }
            }
            if ((this.hasMaxSecretsPerPlayer != setup.hasMaxSecretsPerPlayer) || (this.hasMaxSecretsPerPlayer && !this.maxSecretsPerPlayer_.Equals(setup.maxSecretsPerPlayer_)))
            {
                return false;
            }
            return ((this.hasMaxFriendlyMinionsPerPlayer == setup.hasMaxFriendlyMinionsPerPlayer) && (!this.hasMaxFriendlyMinionsPerPlayer || this.maxFriendlyMinionsPerPlayer_.Equals(setup.maxFriendlyMinionsPerPlayer_)));
        }

        public ClientInfo GetClients(int index)
        {
            return this.clients_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasBoard)
            {
                hashCode ^= this.board_.GetHashCode();
            }
            IEnumerator<ClientInfo> enumerator = this.clients_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    ClientInfo current = enumerator.Current;
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
            if (this.hasMaxSecretsPerPlayer)
            {
                hashCode ^= this.maxSecretsPerPlayer_.GetHashCode();
            }
            if (this.hasMaxFriendlyMinionsPerPlayer)
            {
                hashCode ^= this.maxFriendlyMinionsPerPlayer_.GetHashCode();
            }
            return hashCode;
        }

        private GameSetup MakeReadOnly()
        {
            this.clients_.MakeReadOnly();
            return this;
        }

        public static GameSetup ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GameSetup ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameSetup ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GameSetup ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GameSetup ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GameSetup ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GameSetup ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GameSetup ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameSetup ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameSetup ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GameSetup, Builder>.PrintField("board", this.hasBoard, this.board_, writer);
            GeneratedMessageLite<GameSetup, Builder>.PrintField<ClientInfo>("clients", this.clients_, writer);
            GeneratedMessageLite<GameSetup, Builder>.PrintField("max_secrets_per_player", this.hasMaxSecretsPerPlayer, this.maxSecretsPerPlayer_, writer);
            GeneratedMessageLite<GameSetup, Builder>.PrintField("max_friendly_minions_per_player", this.hasMaxFriendlyMinionsPerPlayer, this.maxFriendlyMinionsPerPlayer_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _gameSetupFieldNames;
            if (this.hasBoard)
            {
                output.WriteString(1, strArray[0], this.Board);
            }
            if (this.clients_.Count > 0)
            {
                output.WriteMessageArray<ClientInfo>(2, strArray[1], this.clients_);
            }
            if (this.hasMaxSecretsPerPlayer)
            {
                output.WriteInt32(3, strArray[3], this.MaxSecretsPerPlayer);
            }
            if (this.hasMaxFriendlyMinionsPerPlayer)
            {
                output.WriteInt32(4, strArray[2], this.MaxFriendlyMinionsPerPlayer);
            }
        }

        public string Board
        {
            get
            {
                return this.board_;
            }
        }

        public int ClientsCount
        {
            get
            {
                return this.clients_.Count;
            }
        }

        public IList<ClientInfo> ClientsList
        {
            get
            {
                return this.clients_;
            }
        }

        public static GameSetup DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GameSetup DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasBoard
        {
            get
            {
                return this.hasBoard;
            }
        }

        public bool HasMaxFriendlyMinionsPerPlayer
        {
            get
            {
                return this.hasMaxFriendlyMinionsPerPlayer;
            }
        }

        public bool HasMaxSecretsPerPlayer
        {
            get
            {
                return this.hasMaxSecretsPerPlayer;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasBoard)
                {
                    return false;
                }
                if (!this.hasMaxSecretsPerPlayer)
                {
                    return false;
                }
                if (!this.hasMaxFriendlyMinionsPerPlayer)
                {
                    return false;
                }
                IEnumerator<ClientInfo> enumerator = this.ClientsList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        ClientInfo current = enumerator.Current;
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

        public int MaxFriendlyMinionsPerPlayer
        {
            get
            {
                return this.maxFriendlyMinionsPerPlayer_;
            }
        }

        public int MaxSecretsPerPlayer
        {
            get
            {
                return this.maxSecretsPerPlayer_;
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
                    if (this.hasBoard)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(1, this.Board);
                    }
                    IEnumerator<ClientInfo> enumerator = this.ClientsList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            ClientInfo current = enumerator.Current;
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
                    if (this.hasMaxSecretsPerPlayer)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(3, this.MaxSecretsPerPlayer);
                    }
                    if (this.hasMaxFriendlyMinionsPerPlayer)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(4, this.MaxFriendlyMinionsPerPlayer);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override GameSetup ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<GameSetup, GameSetup.Builder>
        {
            private GameSetup result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GameSetup.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GameSetup cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public GameSetup.Builder AddClients(ClientInfo value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.clients_.Add(value);
                return this;
            }

            public GameSetup.Builder AddClients(ClientInfo.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.clients_.Add(builderForValue.Build());
                return this;
            }

            public GameSetup.Builder AddRangeClients(IEnumerable<ClientInfo> values)
            {
                this.PrepareBuilder();
                this.result.clients_.Add(values);
                return this;
            }

            public override GameSetup BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GameSetup.Builder Clear()
            {
                this.result = GameSetup.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GameSetup.Builder ClearBoard()
            {
                this.PrepareBuilder();
                this.result.hasBoard = false;
                this.result.board_ = string.Empty;
                return this;
            }

            public GameSetup.Builder ClearClients()
            {
                this.PrepareBuilder();
                this.result.clients_.Clear();
                return this;
            }

            public GameSetup.Builder ClearMaxFriendlyMinionsPerPlayer()
            {
                this.PrepareBuilder();
                this.result.hasMaxFriendlyMinionsPerPlayer = false;
                this.result.maxFriendlyMinionsPerPlayer_ = 0;
                return this;
            }

            public GameSetup.Builder ClearMaxSecretsPerPlayer()
            {
                this.PrepareBuilder();
                this.result.hasMaxSecretsPerPlayer = false;
                this.result.maxSecretsPerPlayer_ = 0;
                return this;
            }

            public override GameSetup.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GameSetup.Builder(this.result);
                }
                return new GameSetup.Builder().MergeFrom(this.result);
            }

            public ClientInfo GetClients(int index)
            {
                return this.result.GetClients(index);
            }

            public override GameSetup.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GameSetup.Builder MergeFrom(IMessageLite other)
            {
                if (other is GameSetup)
                {
                    return this.MergeFrom((GameSetup) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GameSetup.Builder MergeFrom(GameSetup other)
            {
                if (other != GameSetup.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasBoard)
                    {
                        this.Board = other.Board;
                    }
                    if (other.clients_.Count != 0)
                    {
                        this.result.clients_.Add(other.clients_);
                    }
                    if (other.HasMaxSecretsPerPlayer)
                    {
                        this.MaxSecretsPerPlayer = other.MaxSecretsPerPlayer;
                    }
                    if (other.HasMaxFriendlyMinionsPerPlayer)
                    {
                        this.MaxFriendlyMinionsPerPlayer = other.MaxFriendlyMinionsPerPlayer;
                    }
                }
                return this;
            }

            public override GameSetup.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GameSetup._gameSetupFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GameSetup._gameSetupFieldTags[index];
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
                            this.result.hasBoard = input.ReadString(ref this.result.board_);
                            continue;
                        }
                        case 0x12:
                        {
                            input.ReadMessageArray<ClientInfo>(num, str, this.result.clients_, ClientInfo.DefaultInstance, extensionRegistry);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasMaxSecretsPerPlayer = input.ReadInt32(ref this.result.maxSecretsPerPlayer_);
                            continue;
                        }
                        case 0x20:
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
                    this.result.hasMaxFriendlyMinionsPerPlayer = input.ReadInt32(ref this.result.maxFriendlyMinionsPerPlayer_);
                }
                return this;
            }

            private GameSetup PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GameSetup result = this.result;
                    this.result = new GameSetup();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public GameSetup.Builder SetBoard(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasBoard = true;
                this.result.board_ = value;
                return this;
            }

            public GameSetup.Builder SetClients(int index, ClientInfo value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.clients_[index] = value;
                return this;
            }

            public GameSetup.Builder SetClients(int index, ClientInfo.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.clients_[index] = builderForValue.Build();
                return this;
            }

            public GameSetup.Builder SetMaxFriendlyMinionsPerPlayer(int value)
            {
                this.PrepareBuilder();
                this.result.hasMaxFriendlyMinionsPerPlayer = true;
                this.result.maxFriendlyMinionsPerPlayer_ = value;
                return this;
            }

            public GameSetup.Builder SetMaxSecretsPerPlayer(int value)
            {
                this.PrepareBuilder();
                this.result.hasMaxSecretsPerPlayer = true;
                this.result.maxSecretsPerPlayer_ = value;
                return this;
            }

            public string Board
            {
                get
                {
                    return this.result.Board;
                }
                set
                {
                    this.SetBoard(value);
                }
            }

            public int ClientsCount
            {
                get
                {
                    return this.result.ClientsCount;
                }
            }

            public IPopsicleList<ClientInfo> ClientsList
            {
                get
                {
                    return this.PrepareBuilder().clients_;
                }
            }

            public override GameSetup DefaultInstanceForType
            {
                get
                {
                    return GameSetup.DefaultInstance;
                }
            }

            public bool HasBoard
            {
                get
                {
                    return this.result.hasBoard;
                }
            }

            public bool HasMaxFriendlyMinionsPerPlayer
            {
                get
                {
                    return this.result.hasMaxFriendlyMinionsPerPlayer;
                }
            }

            public bool HasMaxSecretsPerPlayer
            {
                get
                {
                    return this.result.hasMaxSecretsPerPlayer;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public int MaxFriendlyMinionsPerPlayer
            {
                get
                {
                    return this.result.MaxFriendlyMinionsPerPlayer;
                }
                set
                {
                    this.SetMaxFriendlyMinionsPerPlayer(value);
                }
            }

            public int MaxSecretsPerPlayer
            {
                get
                {
                    return this.result.MaxSecretsPerPlayer;
                }
                set
                {
                    this.SetMaxSecretsPerPlayer(value);
                }
            }

            protected override GameSetup MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override GameSetup.Builder ThisBuilder
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
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0x10
            }
        }
    }
}

