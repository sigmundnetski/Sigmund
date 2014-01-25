namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class JoinGame : GeneratedMessageLite<JoinGame, Builder>
    {
        private static readonly string[] _joinGameFieldNames = new string[] { "bn_game_handle", "deck" };
        private static readonly uint[] _joinGameFieldTags = new uint[] { 8, 0x10 };
        private int bnGameHandle_;
        public const int BnGameHandleFieldNumber = 1;
        private long deck_;
        public const int DeckFieldNumber = 2;
        private static readonly JoinGame defaultInstance = new JoinGame().MakeReadOnly();
        private bool hasBnGameHandle;
        private bool hasDeck;
        private int memoizedSerializedSize = -1;

        static JoinGame()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private JoinGame()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(JoinGame prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            JoinGame game = obj as JoinGame;
            if (game == null)
            {
                return false;
            }
            if ((this.hasBnGameHandle != game.hasBnGameHandle) || (this.hasBnGameHandle && !this.bnGameHandle_.Equals(game.bnGameHandle_)))
            {
                return false;
            }
            return ((this.hasDeck == game.hasDeck) && (!this.hasDeck || this.deck_.Equals(game.deck_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasBnGameHandle)
            {
                hashCode ^= this.bnGameHandle_.GetHashCode();
            }
            if (this.hasDeck)
            {
                hashCode ^= this.deck_.GetHashCode();
            }
            return hashCode;
        }

        private JoinGame MakeReadOnly()
        {
            return this;
        }

        public static JoinGame ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static JoinGame ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static JoinGame ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static JoinGame ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static JoinGame ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static JoinGame ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static JoinGame ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static JoinGame ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static JoinGame ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static JoinGame ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<JoinGame, Builder>.PrintField("bn_game_handle", this.hasBnGameHandle, this.bnGameHandle_, writer);
            GeneratedMessageLite<JoinGame, Builder>.PrintField("deck", this.hasDeck, this.deck_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _joinGameFieldNames;
            if (this.hasBnGameHandle)
            {
                output.WriteInt32(1, strArray[0], this.BnGameHandle);
            }
            if (this.hasDeck)
            {
                output.WriteInt64(2, strArray[1], this.Deck);
            }
        }

        public int BnGameHandle
        {
            get
            {
                return this.bnGameHandle_;
            }
        }

        public long Deck
        {
            get
            {
                return this.deck_;
            }
        }

        public static JoinGame DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override JoinGame DefaultInstanceForType
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

        public bool HasDeck
        {
            get
            {
                return this.hasDeck;
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
                if (!this.hasDeck)
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
                    if (this.hasDeck)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(2, this.Deck);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override JoinGame ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<JoinGame, JoinGame.Builder>
        {
            private JoinGame result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = JoinGame.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(JoinGame cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override JoinGame BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override JoinGame.Builder Clear()
            {
                this.result = JoinGame.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public JoinGame.Builder ClearBnGameHandle()
            {
                this.PrepareBuilder();
                this.result.hasBnGameHandle = false;
                this.result.bnGameHandle_ = 0;
                return this;
            }

            public JoinGame.Builder ClearDeck()
            {
                this.PrepareBuilder();
                this.result.hasDeck = false;
                this.result.deck_ = 0L;
                return this;
            }

            public override JoinGame.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new JoinGame.Builder(this.result);
                }
                return new JoinGame.Builder().MergeFrom(this.result);
            }

            public override JoinGame.Builder MergeFrom(JoinGame other)
            {
                if (other != JoinGame.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasBnGameHandle)
                    {
                        this.BnGameHandle = other.BnGameHandle;
                    }
                    if (other.HasDeck)
                    {
                        this.Deck = other.Deck;
                    }
                }
                return this;
            }

            public override JoinGame.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override JoinGame.Builder MergeFrom(IMessageLite other)
            {
                if (other is JoinGame)
                {
                    return this.MergeFrom((JoinGame) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override JoinGame.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(JoinGame._joinGameFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = JoinGame._joinGameFieldTags[index];
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
                            this.result.hasBnGameHandle = input.ReadInt32(ref this.result.bnGameHandle_);
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
                    this.result.hasDeck = input.ReadInt64(ref this.result.deck_);
                }
                return this;
            }

            private JoinGame PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    JoinGame result = this.result;
                    this.result = new JoinGame();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public JoinGame.Builder SetBnGameHandle(int value)
            {
                this.PrepareBuilder();
                this.result.hasBnGameHandle = true;
                this.result.bnGameHandle_ = value;
                return this;
            }

            public JoinGame.Builder SetDeck(long value)
            {
                this.PrepareBuilder();
                this.result.hasDeck = true;
                this.result.deck_ = value;
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

            public long Deck
            {
                get
                {
                    return this.result.Deck;
                }
                set
                {
                    this.SetDeck(value);
                }
            }

            public override JoinGame DefaultInstanceForType
            {
                get
                {
                    return JoinGame.DefaultInstance;
                }
            }

            public bool HasBnGameHandle
            {
                get
                {
                    return this.result.hasBnGameHandle;
                }
            }

            public bool HasDeck
            {
                get
                {
                    return this.result.hasDeck;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override JoinGame MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override JoinGame.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0x69
            }
        }
    }
}

