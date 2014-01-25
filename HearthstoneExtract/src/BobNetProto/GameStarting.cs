namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class GameStarting : GeneratedMessageLite<GameStarting, Builder>
    {
        private static readonly string[] _gameStartingFieldNames = new string[] { "game_handle" };
        private static readonly uint[] _gameStartingFieldTags = new uint[] { 8 };
        private static readonly GameStarting defaultInstance = new GameStarting().MakeReadOnly();
        private int gameHandle_;
        public const int GameHandleFieldNumber = 1;
        private bool hasGameHandle;
        private int memoizedSerializedSize = -1;

        static GameStarting()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private GameStarting()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GameStarting prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GameStarting starting = obj as GameStarting;
            if (starting == null)
            {
                return false;
            }
            return ((this.hasGameHandle == starting.hasGameHandle) && (!this.hasGameHandle || this.gameHandle_.Equals(starting.gameHandle_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasGameHandle)
            {
                hashCode ^= this.gameHandle_.GetHashCode();
            }
            return hashCode;
        }

        private GameStarting MakeReadOnly()
        {
            return this;
        }

        public static GameStarting ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GameStarting ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameStarting ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GameStarting ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GameStarting ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GameStarting ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GameStarting ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GameStarting ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameStarting ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameStarting ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GameStarting, Builder>.PrintField("game_handle", this.hasGameHandle, this.gameHandle_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _gameStartingFieldNames;
            if (this.hasGameHandle)
            {
                output.WriteInt32(1, strArray[0], this.GameHandle);
            }
        }

        public static GameStarting DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GameStarting DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public int GameHandle
        {
            get
            {
                return this.gameHandle_;
            }
        }

        public bool HasGameHandle
        {
            get
            {
                return this.hasGameHandle;
            }
        }

        public override bool IsInitialized
        {
            get
            {
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
                    if (this.hasGameHandle)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.GameHandle);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override GameStarting ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<GameStarting, GameStarting.Builder>
        {
            private GameStarting result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GameStarting.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GameStarting cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override GameStarting BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GameStarting.Builder Clear()
            {
                this.result = GameStarting.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GameStarting.Builder ClearGameHandle()
            {
                this.PrepareBuilder();
                this.result.hasGameHandle = false;
                this.result.gameHandle_ = 0;
                return this;
            }

            public override GameStarting.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GameStarting.Builder(this.result);
                }
                return new GameStarting.Builder().MergeFrom(this.result);
            }

            public override GameStarting.Builder MergeFrom(GameStarting other)
            {
                if (other != GameStarting.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasGameHandle)
                    {
                        this.GameHandle = other.GameHandle;
                    }
                }
                return this;
            }

            public override GameStarting.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GameStarting.Builder MergeFrom(IMessageLite other)
            {
                if (other is GameStarting)
                {
                    return this.MergeFrom((GameStarting) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GameStarting.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GameStarting._gameStartingFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GameStarting._gameStartingFieldTags[index];
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
                    this.result.hasGameHandle = input.ReadInt32(ref this.result.gameHandle_);
                }
                return this;
            }

            private GameStarting PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GameStarting result = this.result;
                    this.result = new GameStarting();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public GameStarting.Builder SetGameHandle(int value)
            {
                this.PrepareBuilder();
                this.result.hasGameHandle = true;
                this.result.gameHandle_ = value;
                return this;
            }

            public override GameStarting DefaultInstanceForType
            {
                get
                {
                    return GameStarting.DefaultInstance;
                }
            }

            public int GameHandle
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

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override GameStarting MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override GameStarting.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0x72
            }
        }
    }
}

