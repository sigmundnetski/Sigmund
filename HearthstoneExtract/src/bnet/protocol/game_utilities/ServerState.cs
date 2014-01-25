namespace bnet.protocol.game_utilities
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class ServerState : GeneratedMessageLite<ServerState, Builder>
    {
        private static readonly string[] _serverStateFieldNames = new string[] { "current_load", "game_count", "player_count" };
        private static readonly uint[] _serverStateFieldTags = new uint[] { 13, 0x10, 0x18 };
        private float currentLoad_ = 1f;
        public const int CurrentLoadFieldNumber = 1;
        private static readonly ServerState defaultInstance = new ServerState().MakeReadOnly();
        private uint gameCount_;
        public const int GameCountFieldNumber = 2;
        private bool hasCurrentLoad;
        private bool hasGameCount;
        private bool hasPlayerCount;
        private int memoizedSerializedSize = -1;
        private uint playerCount_;
        public const int PlayerCountFieldNumber = 3;

        static ServerState()
        {
            object.ReferenceEquals(GameUtils.Descriptor, null);
        }

        private ServerState()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ServerState prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ServerState state = obj as ServerState;
            if (state == null)
            {
                return false;
            }
            if ((this.hasCurrentLoad != state.hasCurrentLoad) || (this.hasCurrentLoad && !this.currentLoad_.Equals(state.currentLoad_)))
            {
                return false;
            }
            if ((this.hasGameCount != state.hasGameCount) || (this.hasGameCount && !this.gameCount_.Equals(state.gameCount_)))
            {
                return false;
            }
            return ((this.hasPlayerCount == state.hasPlayerCount) && (!this.hasPlayerCount || this.playerCount_.Equals(state.playerCount_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasCurrentLoad)
            {
                hashCode ^= this.currentLoad_.GetHashCode();
            }
            if (this.hasGameCount)
            {
                hashCode ^= this.gameCount_.GetHashCode();
            }
            if (this.hasPlayerCount)
            {
                hashCode ^= this.playerCount_.GetHashCode();
            }
            return hashCode;
        }

        private ServerState MakeReadOnly()
        {
            return this;
        }

        public static ServerState ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ServerState ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ServerState ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ServerState ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ServerState ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ServerState ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ServerState ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ServerState ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ServerState ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ServerState ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ServerState, Builder>.PrintField("current_load", this.hasCurrentLoad, this.currentLoad_, writer);
            GeneratedMessageLite<ServerState, Builder>.PrintField("game_count", this.hasGameCount, this.gameCount_, writer);
            GeneratedMessageLite<ServerState, Builder>.PrintField("player_count", this.hasPlayerCount, this.playerCount_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _serverStateFieldNames;
            if (this.hasCurrentLoad)
            {
                output.WriteFloat(1, strArray[0], this.CurrentLoad);
            }
            if (this.hasGameCount)
            {
                output.WriteUInt32(2, strArray[1], this.GameCount);
            }
            if (this.hasPlayerCount)
            {
                output.WriteUInt32(3, strArray[2], this.PlayerCount);
            }
        }

        public float CurrentLoad
        {
            get
            {
                return this.currentLoad_;
            }
        }

        public static ServerState DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ServerState DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        [CLSCompliant(false)]
        public uint GameCount
        {
            get
            {
                return this.gameCount_;
            }
        }

        public bool HasCurrentLoad
        {
            get
            {
                return this.hasCurrentLoad;
            }
        }

        public bool HasGameCount
        {
            get
            {
                return this.hasGameCount;
            }
        }

        public bool HasPlayerCount
        {
            get
            {
                return this.hasPlayerCount;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                return true;
            }
        }

        [CLSCompliant(false)]
        public uint PlayerCount
        {
            get
            {
                return this.playerCount_;
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
                    if (this.hasCurrentLoad)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFloatSize(1, this.CurrentLoad);
                    }
                    if (this.hasGameCount)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(2, this.GameCount);
                    }
                    if (this.hasPlayerCount)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(3, this.PlayerCount);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ServerState ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<ServerState, ServerState.Builder>
        {
            private ServerState result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ServerState.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ServerState cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override ServerState BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ServerState.Builder Clear()
            {
                this.result = ServerState.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ServerState.Builder ClearCurrentLoad()
            {
                this.PrepareBuilder();
                this.result.hasCurrentLoad = false;
                this.result.currentLoad_ = 1f;
                return this;
            }

            public ServerState.Builder ClearGameCount()
            {
                this.PrepareBuilder();
                this.result.hasGameCount = false;
                this.result.gameCount_ = 0;
                return this;
            }

            public ServerState.Builder ClearPlayerCount()
            {
                this.PrepareBuilder();
                this.result.hasPlayerCount = false;
                this.result.playerCount_ = 0;
                return this;
            }

            public override ServerState.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ServerState.Builder(this.result);
                }
                return new ServerState.Builder().MergeFrom(this.result);
            }

            public override ServerState.Builder MergeFrom(ServerState other)
            {
                if (other != ServerState.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasCurrentLoad)
                    {
                        this.CurrentLoad = other.CurrentLoad;
                    }
                    if (other.HasGameCount)
                    {
                        this.GameCount = other.GameCount;
                    }
                    if (other.HasPlayerCount)
                    {
                        this.PlayerCount = other.PlayerCount;
                    }
                }
                return this;
            }

            public override ServerState.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ServerState.Builder MergeFrom(IMessageLite other)
            {
                if (other is ServerState)
                {
                    return this.MergeFrom((ServerState) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ServerState.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ServerState._serverStateFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ServerState._serverStateFieldTags[index];
                        }
                        else
                        {
                            this.ParseUnknownField(input, extensionRegistry, num, str);
                            continue;
                        }
                    }
                    switch (num)
                    {
                        case 13:
                        {
                            this.result.hasCurrentLoad = input.ReadFloat(ref this.result.currentLoad_);
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasGameCount = input.ReadUInt32(ref this.result.gameCount_);
                            continue;
                        }
                        case 0:
                            throw InvalidProtocolBufferException.InvalidTag();

                        case 0x18:
                            goto Label_00E1;

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
                Label_00E1:
                    this.result.hasPlayerCount = input.ReadUInt32(ref this.result.playerCount_);
                }
                return this;
            }

            private ServerState PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ServerState result = this.result;
                    this.result = new ServerState();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ServerState.Builder SetCurrentLoad(float value)
            {
                this.PrepareBuilder();
                this.result.hasCurrentLoad = true;
                this.result.currentLoad_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public ServerState.Builder SetGameCount(uint value)
            {
                this.PrepareBuilder();
                this.result.hasGameCount = true;
                this.result.gameCount_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public ServerState.Builder SetPlayerCount(uint value)
            {
                this.PrepareBuilder();
                this.result.hasPlayerCount = true;
                this.result.playerCount_ = value;
                return this;
            }

            public float CurrentLoad
            {
                get
                {
                    return this.result.CurrentLoad;
                }
                set
                {
                    this.SetCurrentLoad(value);
                }
            }

            public override ServerState DefaultInstanceForType
            {
                get
                {
                    return ServerState.DefaultInstance;
                }
            }

            [CLSCompliant(false)]
            public uint GameCount
            {
                get
                {
                    return this.result.GameCount;
                }
                set
                {
                    this.SetGameCount(value);
                }
            }

            public bool HasCurrentLoad
            {
                get
                {
                    return this.result.hasCurrentLoad;
                }
            }

            public bool HasGameCount
            {
                get
                {
                    return this.result.hasGameCount;
                }
            }

            public bool HasPlayerCount
            {
                get
                {
                    return this.result.hasPlayerCount;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override ServerState MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            [CLSCompliant(false)]
            public uint PlayerCount
            {
                get
                {
                    return this.result.PlayerCount;
                }
                set
                {
                    this.SetPlayerCount(value);
                }
            }

            protected override ServerState.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

