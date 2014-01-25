namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class RemoveHostedGame : GeneratedMessageLite<RemoveHostedGame, Builder>
    {
        private static readonly string[] _removeHostedGameFieldNames = new string[] { "bn_game_handle" };
        private static readonly uint[] _removeHostedGameFieldTags = new uint[] { 8 };
        private int bnGameHandle_;
        public const int BnGameHandleFieldNumber = 1;
        private static readonly RemoveHostedGame defaultInstance = new RemoveHostedGame().MakeReadOnly();
        private bool hasBnGameHandle;
        private int memoizedSerializedSize = -1;

        static RemoveHostedGame()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private RemoveHostedGame()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(RemoveHostedGame prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            RemoveHostedGame game = obj as RemoveHostedGame;
            if (game == null)
            {
                return false;
            }
            return ((this.hasBnGameHandle == game.hasBnGameHandle) && (!this.hasBnGameHandle || this.bnGameHandle_.Equals(game.bnGameHandle_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasBnGameHandle)
            {
                hashCode ^= this.bnGameHandle_.GetHashCode();
            }
            return hashCode;
        }

        private RemoveHostedGame MakeReadOnly()
        {
            return this;
        }

        public static RemoveHostedGame ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static RemoveHostedGame ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static RemoveHostedGame ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static RemoveHostedGame ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static RemoveHostedGame ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static RemoveHostedGame ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static RemoveHostedGame ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static RemoveHostedGame ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static RemoveHostedGame ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static RemoveHostedGame ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<RemoveHostedGame, Builder>.PrintField("bn_game_handle", this.hasBnGameHandle, this.bnGameHandle_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _removeHostedGameFieldNames;
            if (this.hasBnGameHandle)
            {
                output.WriteInt32(1, strArray[0], this.BnGameHandle);
            }
        }

        public int BnGameHandle
        {
            get
            {
                return this.bnGameHandle_;
            }
        }

        public static RemoveHostedGame DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override RemoveHostedGame DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasBnGameHandle
        {
            get
            {
                return this.hasBnGameHandle;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasBnGameHandle)
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
                    if (this.hasBnGameHandle)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.BnGameHandle);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override RemoveHostedGame ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<RemoveHostedGame, RemoveHostedGame.Builder>
        {
            private RemoveHostedGame result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = RemoveHostedGame.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(RemoveHostedGame cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override RemoveHostedGame BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override RemoveHostedGame.Builder Clear()
            {
                this.result = RemoveHostedGame.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public RemoveHostedGame.Builder ClearBnGameHandle()
            {
                this.PrepareBuilder();
                this.result.hasBnGameHandle = false;
                this.result.bnGameHandle_ = 0;
                return this;
            }

            public override RemoveHostedGame.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new RemoveHostedGame.Builder(this.result);
                }
                return new RemoveHostedGame.Builder().MergeFrom(this.result);
            }

            public override RemoveHostedGame.Builder MergeFrom(RemoveHostedGame other)
            {
                if (other != RemoveHostedGame.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasBnGameHandle)
                    {
                        this.BnGameHandle = other.BnGameHandle;
                    }
                }
                return this;
            }

            public override RemoveHostedGame.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override RemoveHostedGame.Builder MergeFrom(IMessageLite other)
            {
                if (other is RemoveHostedGame)
                {
                    return this.MergeFrom((RemoveHostedGame) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override RemoveHostedGame.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(RemoveHostedGame._removeHostedGameFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = RemoveHostedGame._removeHostedGameFieldTags[index];
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
                    this.result.hasBnGameHandle = input.ReadInt32(ref this.result.bnGameHandle_);
                }
                return this;
            }

            private RemoveHostedGame PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    RemoveHostedGame result = this.result;
                    this.result = new RemoveHostedGame();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public RemoveHostedGame.Builder SetBnGameHandle(int value)
            {
                this.PrepareBuilder();
                this.result.hasBnGameHandle = true;
                this.result.bnGameHandle_ = value;
                return this;
            }

            public int BnGameHandle
            {
                get
                {
                    return this.result.BnGameHandle;
                }
                set
                {
                    this.SetBnGameHandle(value);
                }
            }

            public override RemoveHostedGame DefaultInstanceForType
            {
                get
                {
                    return RemoveHostedGame.DefaultInstance;
                }
            }

            public bool HasBnGameHandle
            {
                get
                {
                    return this.result.hasBnGameHandle;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override RemoveHostedGame MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override RemoveHostedGame.Builder ThisBuilder
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
                ID = 0x6c
            }
        }
    }
}

