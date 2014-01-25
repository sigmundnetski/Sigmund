namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class RemoveGame : GeneratedMessageLite<RemoveGame, Builder>
    {
        private static readonly string[] _removeGameFieldNames = new string[] { "game_handle" };
        private static readonly uint[] _removeGameFieldTags = new uint[] { 8 };
        private static readonly RemoveGame defaultInstance = new RemoveGame().MakeReadOnly();
        private int gameHandle_;
        public const int GameHandleFieldNumber = 1;
        private bool hasGameHandle;
        private int memoizedSerializedSize = -1;

        static RemoveGame()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private RemoveGame()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(RemoveGame prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            RemoveGame game = obj as RemoveGame;
            if (game == null)
            {
                return false;
            }
            return ((this.hasGameHandle == game.hasGameHandle) && (!this.hasGameHandle || this.gameHandle_.Equals(game.gameHandle_)));
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

        private RemoveGame MakeReadOnly()
        {
            return this;
        }

        public static RemoveGame ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static RemoveGame ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static RemoveGame ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static RemoveGame ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static RemoveGame ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static RemoveGame ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static RemoveGame ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static RemoveGame ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static RemoveGame ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static RemoveGame ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<RemoveGame, Builder>.PrintField("game_handle", this.hasGameHandle, this.gameHandle_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _removeGameFieldNames;
            if (this.hasGameHandle)
            {
                output.WriteInt32(1, strArray[0], this.GameHandle);
            }
        }

        public static RemoveGame DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override RemoveGame DefaultInstanceForType
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

        protected override RemoveGame ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<RemoveGame, RemoveGame.Builder>
        {
            private RemoveGame result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = RemoveGame.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(RemoveGame cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override RemoveGame BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override RemoveGame.Builder Clear()
            {
                this.result = RemoveGame.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public RemoveGame.Builder ClearGameHandle()
            {
                this.PrepareBuilder();
                this.result.hasGameHandle = false;
                this.result.gameHandle_ = 0;
                return this;
            }

            public override RemoveGame.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new RemoveGame.Builder(this.result);
                }
                return new RemoveGame.Builder().MergeFrom(this.result);
            }

            public override RemoveGame.Builder MergeFrom(RemoveGame other)
            {
                if (other != RemoveGame.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasGameHandle)
                    {
                        this.GameHandle = other.GameHandle;
                    }
                }
                return this;
            }

            public override RemoveGame.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override RemoveGame.Builder MergeFrom(IMessageLite other)
            {
                if (other is RemoveGame)
                {
                    return this.MergeFrom((RemoveGame) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override RemoveGame.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(RemoveGame._removeGameFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = RemoveGame._removeGameFieldTags[index];
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

            private RemoveGame PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    RemoveGame result = this.result;
                    this.result = new RemoveGame();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public RemoveGame.Builder SetGameHandle(int value)
            {
                this.PrepareBuilder();
                this.result.hasGameHandle = true;
                this.result.gameHandle_ = value;
                return this;
            }

            public override RemoveGame DefaultInstanceForType
            {
                get
                {
                    return RemoveGame.DefaultInstance;
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

            protected override RemoveGame MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override RemoveGame.Builder ThisBuilder
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
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0x77
            }
        }
    }
}

