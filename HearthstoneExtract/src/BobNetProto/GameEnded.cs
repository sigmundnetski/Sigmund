namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class GameEnded : GeneratedMessageLite<GameEnded, Builder>
    {
        private static readonly string[] _gameEndedFieldNames = new string[] { "game_handle" };
        private static readonly uint[] _gameEndedFieldTags = new uint[] { 8 };
        private static readonly GameEnded defaultInstance = new GameEnded().MakeReadOnly();
        private int gameHandle_;
        public const int GameHandleFieldNumber = 1;
        private bool hasGameHandle;
        private int memoizedSerializedSize = -1;

        static GameEnded()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private GameEnded()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GameEnded prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GameEnded ended = obj as GameEnded;
            if (ended == null)
            {
                return false;
            }
            return ((this.hasGameHandle == ended.hasGameHandle) && (!this.hasGameHandle || this.gameHandle_.Equals(ended.gameHandle_)));
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

        private GameEnded MakeReadOnly()
        {
            return this;
        }

        public static GameEnded ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GameEnded ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameEnded ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GameEnded ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GameEnded ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GameEnded ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GameEnded ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GameEnded ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameEnded ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameEnded ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GameEnded, Builder>.PrintField("game_handle", this.hasGameHandle, this.gameHandle_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _gameEndedFieldNames;
            if (this.hasGameHandle)
            {
                output.WriteInt32(1, strArray[0], this.GameHandle);
            }
        }

        public static GameEnded DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GameEnded DefaultInstanceForType
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
                if (!this.hasGameHandle)
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
                    if (this.hasGameHandle)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.GameHandle);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override GameEnded ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<GameEnded, GameEnded.Builder>
        {
            private GameEnded result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GameEnded.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GameEnded cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override GameEnded BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GameEnded.Builder Clear()
            {
                this.result = GameEnded.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GameEnded.Builder ClearGameHandle()
            {
                this.PrepareBuilder();
                this.result.hasGameHandle = false;
                this.result.gameHandle_ = 0;
                return this;
            }

            public override GameEnded.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GameEnded.Builder(this.result);
                }
                return new GameEnded.Builder().MergeFrom(this.result);
            }

            public override GameEnded.Builder MergeFrom(GameEnded other)
            {
                if (other != GameEnded.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasGameHandle)
                    {
                        this.GameHandle = other.GameHandle;
                    }
                }
                return this;
            }

            public override GameEnded.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GameEnded.Builder MergeFrom(IMessageLite other)
            {
                if (other is GameEnded)
                {
                    return this.MergeFrom((GameEnded) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GameEnded.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GameEnded._gameEndedFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GameEnded._gameEndedFieldTags[index];
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

            private GameEnded PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GameEnded result = this.result;
                    this.result = new GameEnded();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public GameEnded.Builder SetGameHandle(int value)
            {
                this.PrepareBuilder();
                this.result.hasGameHandle = true;
                this.result.gameHandle_ = value;
                return this;
            }

            public override GameEnded DefaultInstanceForType
            {
                get
                {
                    return GameEnded.DefaultInstance;
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

            protected override GameEnded MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override GameEnded.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0x75
            }
        }
    }
}

