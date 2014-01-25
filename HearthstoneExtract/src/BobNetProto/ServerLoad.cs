namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class ServerLoad : GeneratedMessageLite<ServerLoad, Builder>
    {
        private static readonly string[] _serverLoadFieldNames = new string[] { "game_space", "games_started" };
        private static readonly uint[] _serverLoadFieldTags = new uint[] { 8, 0x10 };
        private static readonly ServerLoad defaultInstance = new ServerLoad().MakeReadOnly();
        private int gameSpace_;
        public const int GameSpaceFieldNumber = 1;
        private int gamesStarted_;
        public const int GamesStartedFieldNumber = 2;
        private bool hasGameSpace;
        private bool hasGamesStarted;
        private int memoizedSerializedSize = -1;

        static ServerLoad()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private ServerLoad()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ServerLoad prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ServerLoad load = obj as ServerLoad;
            if (load == null)
            {
                return false;
            }
            if ((this.hasGameSpace != load.hasGameSpace) || (this.hasGameSpace && !this.gameSpace_.Equals(load.gameSpace_)))
            {
                return false;
            }
            return ((this.hasGamesStarted == load.hasGamesStarted) && (!this.hasGamesStarted || this.gamesStarted_.Equals(load.gamesStarted_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasGameSpace)
            {
                hashCode ^= this.gameSpace_.GetHashCode();
            }
            if (this.hasGamesStarted)
            {
                hashCode ^= this.gamesStarted_.GetHashCode();
            }
            return hashCode;
        }

        private ServerLoad MakeReadOnly()
        {
            return this;
        }

        public static ServerLoad ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ServerLoad ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ServerLoad ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ServerLoad ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ServerLoad ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ServerLoad ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ServerLoad ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ServerLoad ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ServerLoad ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ServerLoad ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ServerLoad, Builder>.PrintField("game_space", this.hasGameSpace, this.gameSpace_, writer);
            GeneratedMessageLite<ServerLoad, Builder>.PrintField("games_started", this.hasGamesStarted, this.gamesStarted_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _serverLoadFieldNames;
            if (this.hasGameSpace)
            {
                output.WriteInt32(1, strArray[0], this.GameSpace);
            }
            if (this.hasGamesStarted)
            {
                output.WriteInt32(2, strArray[1], this.GamesStarted);
            }
        }

        public static ServerLoad DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ServerLoad DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public int GameSpace
        {
            get
            {
                return this.gameSpace_;
            }
        }

        public int GamesStarted
        {
            get
            {
                return this.gamesStarted_;
            }
        }

        public bool HasGameSpace
        {
            get
            {
                return this.hasGameSpace;
            }
        }

        public bool HasGamesStarted
        {
            get
            {
                return this.hasGamesStarted;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasGameSpace)
                {
                    return false;
                }
                if (!this.hasGamesStarted)
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
                    if (this.hasGameSpace)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.GameSpace);
                    }
                    if (this.hasGamesStarted)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.GamesStarted);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ServerLoad ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<ServerLoad, ServerLoad.Builder>
        {
            private ServerLoad result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ServerLoad.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ServerLoad cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override ServerLoad BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ServerLoad.Builder Clear()
            {
                this.result = ServerLoad.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ServerLoad.Builder ClearGameSpace()
            {
                this.PrepareBuilder();
                this.result.hasGameSpace = false;
                this.result.gameSpace_ = 0;
                return this;
            }

            public ServerLoad.Builder ClearGamesStarted()
            {
                this.PrepareBuilder();
                this.result.hasGamesStarted = false;
                this.result.gamesStarted_ = 0;
                return this;
            }

            public override ServerLoad.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ServerLoad.Builder(this.result);
                }
                return new ServerLoad.Builder().MergeFrom(this.result);
            }

            public override ServerLoad.Builder MergeFrom(ServerLoad other)
            {
                if (other != ServerLoad.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasGameSpace)
                    {
                        this.GameSpace = other.GameSpace;
                    }
                    if (other.HasGamesStarted)
                    {
                        this.GamesStarted = other.GamesStarted;
                    }
                }
                return this;
            }

            public override ServerLoad.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ServerLoad.Builder MergeFrom(IMessageLite other)
            {
                if (other is ServerLoad)
                {
                    return this.MergeFrom((ServerLoad) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ServerLoad.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ServerLoad._serverLoadFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ServerLoad._serverLoadFieldTags[index];
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
                            this.result.hasGameSpace = input.ReadInt32(ref this.result.gameSpace_);
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
                    this.result.hasGamesStarted = input.ReadInt32(ref this.result.gamesStarted_);
                }
                return this;
            }

            private ServerLoad PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ServerLoad result = this.result;
                    this.result = new ServerLoad();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ServerLoad.Builder SetGameSpace(int value)
            {
                this.PrepareBuilder();
                this.result.hasGameSpace = true;
                this.result.gameSpace_ = value;
                return this;
            }

            public ServerLoad.Builder SetGamesStarted(int value)
            {
                this.PrepareBuilder();
                this.result.hasGamesStarted = true;
                this.result.gamesStarted_ = value;
                return this;
            }

            public override ServerLoad DefaultInstanceForType
            {
                get
                {
                    return ServerLoad.DefaultInstance;
                }
            }

            public int GameSpace
            {
                get
                {
                    return this.result.GameSpace;
                }
                set
                {
                    this.SetGameSpace(value);
                }
            }

            public int GamesStarted
            {
                get
                {
                    return this.result.GamesStarted;
                }
                set
                {
                    this.SetGamesStarted(value);
                }
            }

            public bool HasGameSpace
            {
                get
                {
                    return this.result.hasGameSpace;
                }
            }

            public bool HasGamesStarted
            {
                get
                {
                    return this.result.hasGamesStarted;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override ServerLoad MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override ServerLoad.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0xa5
            }
        }
    }
}

