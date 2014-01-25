namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class AddPlayer : GeneratedMessageLite<AddPlayer, Builder>
    {
        private static readonly string[] _addPlayerFieldNames = new string[] { "ai_deck", "client_handle", "deck", "game_handle", "password" };
        private static readonly uint[] _addPlayerFieldTags = new uint[] { 40, 8, 0x10, 0x18, 0x20 };
        private long aiDeck_;
        public const int AiDeckFieldNumber = 5;
        private int clientHandle_;
        public const int ClientHandleFieldNumber = 1;
        private long deck_;
        public const int DeckFieldNumber = 2;
        private static readonly AddPlayer defaultInstance = new AddPlayer().MakeReadOnly();
        private int gameHandle_;
        public const int GameHandleFieldNumber = 3;
        private bool hasAiDeck;
        private bool hasClientHandle;
        private bool hasDeck;
        private bool hasGameHandle;
        private bool hasPassword;
        private int memoizedSerializedSize = -1;
        private int password_;
        public const int PasswordFieldNumber = 4;

        static AddPlayer()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private AddPlayer()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AddPlayer prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AddPlayer player = obj as AddPlayer;
            if (player == null)
            {
                return false;
            }
            if ((this.hasClientHandle != player.hasClientHandle) || (this.hasClientHandle && !this.clientHandle_.Equals(player.clientHandle_)))
            {
                return false;
            }
            if ((this.hasDeck != player.hasDeck) || (this.hasDeck && !this.deck_.Equals(player.deck_)))
            {
                return false;
            }
            if ((this.hasGameHandle != player.hasGameHandle) || (this.hasGameHandle && !this.gameHandle_.Equals(player.gameHandle_)))
            {
                return false;
            }
            if ((this.hasPassword != player.hasPassword) || (this.hasPassword && !this.password_.Equals(player.password_)))
            {
                return false;
            }
            return ((this.hasAiDeck == player.hasAiDeck) && (!this.hasAiDeck || this.aiDeck_.Equals(player.aiDeck_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasClientHandle)
            {
                hashCode ^= this.clientHandle_.GetHashCode();
            }
            if (this.hasDeck)
            {
                hashCode ^= this.deck_.GetHashCode();
            }
            if (this.hasGameHandle)
            {
                hashCode ^= this.gameHandle_.GetHashCode();
            }
            if (this.hasPassword)
            {
                hashCode ^= this.password_.GetHashCode();
            }
            if (this.hasAiDeck)
            {
                hashCode ^= this.aiDeck_.GetHashCode();
            }
            return hashCode;
        }

        private AddPlayer MakeReadOnly()
        {
            return this;
        }

        public static AddPlayer ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AddPlayer ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AddPlayer ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AddPlayer ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AddPlayer ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AddPlayer ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AddPlayer ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AddPlayer ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AddPlayer ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AddPlayer ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AddPlayer, Builder>.PrintField("client_handle", this.hasClientHandle, this.clientHandle_, writer);
            GeneratedMessageLite<AddPlayer, Builder>.PrintField("deck", this.hasDeck, this.deck_, writer);
            GeneratedMessageLite<AddPlayer, Builder>.PrintField("game_handle", this.hasGameHandle, this.gameHandle_, writer);
            GeneratedMessageLite<AddPlayer, Builder>.PrintField("password", this.hasPassword, this.password_, writer);
            GeneratedMessageLite<AddPlayer, Builder>.PrintField("ai_deck", this.hasAiDeck, this.aiDeck_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _addPlayerFieldNames;
            if (this.hasClientHandle)
            {
                output.WriteInt32(1, strArray[1], this.ClientHandle);
            }
            if (this.hasDeck)
            {
                output.WriteInt64(2, strArray[2], this.Deck);
            }
            if (this.hasGameHandle)
            {
                output.WriteInt32(3, strArray[3], this.GameHandle);
            }
            if (this.hasPassword)
            {
                output.WriteInt32(4, strArray[4], this.Password);
            }
            if (this.hasAiDeck)
            {
                output.WriteInt64(5, strArray[0], this.AiDeck);
            }
        }

        public long AiDeck
        {
            get
            {
                return this.aiDeck_;
            }
        }

        public int ClientHandle
        {
            get
            {
                return this.clientHandle_;
            }
        }

        public long Deck
        {
            get
            {
                return this.deck_;
            }
        }

        public static AddPlayer DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AddPlayer DefaultInstanceForType
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

        public bool HasAiDeck
        {
            get
            {
                return this.hasAiDeck;
            }
        }

        public bool HasClientHandle
        {
            get
            {
                return this.hasClientHandle;
            }
        }

        public bool HasDeck
        {
            get
            {
                return this.hasDeck;
            }
        }

        public bool HasGameHandle
        {
            get
            {
                return this.hasGameHandle;
            }
        }

        public bool HasPassword
        {
            get
            {
                return this.hasPassword;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasClientHandle)
                {
                    return false;
                }
                if (!this.hasDeck)
                {
                    return false;
                }
                if (!this.hasGameHandle)
                {
                    return false;
                }
                if (!this.hasPassword)
                {
                    return false;
                }
                return true;
            }
        }

        public int Password
        {
            get
            {
                return this.password_;
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
                    if (this.hasClientHandle)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.ClientHandle);
                    }
                    if (this.hasDeck)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(2, this.Deck);
                    }
                    if (this.hasGameHandle)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(3, this.GameHandle);
                    }
                    if (this.hasPassword)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(4, this.Password);
                    }
                    if (this.hasAiDeck)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(5, this.AiDeck);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override AddPlayer ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<AddPlayer, AddPlayer.Builder>
        {
            private AddPlayer result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AddPlayer.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AddPlayer cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override AddPlayer BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AddPlayer.Builder Clear()
            {
                this.result = AddPlayer.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AddPlayer.Builder ClearAiDeck()
            {
                this.PrepareBuilder();
                this.result.hasAiDeck = false;
                this.result.aiDeck_ = 0L;
                return this;
            }

            public AddPlayer.Builder ClearClientHandle()
            {
                this.PrepareBuilder();
                this.result.hasClientHandle = false;
                this.result.clientHandle_ = 0;
                return this;
            }

            public AddPlayer.Builder ClearDeck()
            {
                this.PrepareBuilder();
                this.result.hasDeck = false;
                this.result.deck_ = 0L;
                return this;
            }

            public AddPlayer.Builder ClearGameHandle()
            {
                this.PrepareBuilder();
                this.result.hasGameHandle = false;
                this.result.gameHandle_ = 0;
                return this;
            }

            public AddPlayer.Builder ClearPassword()
            {
                this.PrepareBuilder();
                this.result.hasPassword = false;
                this.result.password_ = 0;
                return this;
            }

            public override AddPlayer.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AddPlayer.Builder(this.result);
                }
                return new AddPlayer.Builder().MergeFrom(this.result);
            }

            public override AddPlayer.Builder MergeFrom(AddPlayer other)
            {
                if (other != AddPlayer.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasClientHandle)
                    {
                        this.ClientHandle = other.ClientHandle;
                    }
                    if (other.HasDeck)
                    {
                        this.Deck = other.Deck;
                    }
                    if (other.HasGameHandle)
                    {
                        this.GameHandle = other.GameHandle;
                    }
                    if (other.HasPassword)
                    {
                        this.Password = other.Password;
                    }
                    if (other.HasAiDeck)
                    {
                        this.AiDeck = other.AiDeck;
                    }
                }
                return this;
            }

            public override AddPlayer.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AddPlayer.Builder MergeFrom(IMessageLite other)
            {
                if (other is AddPlayer)
                {
                    return this.MergeFrom((AddPlayer) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AddPlayer.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AddPlayer._addPlayerFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AddPlayer._addPlayerFieldTags[index];
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
                            this.result.hasClientHandle = input.ReadInt32(ref this.result.clientHandle_);
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasDeck = input.ReadInt64(ref this.result.deck_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasGameHandle = input.ReadInt32(ref this.result.gameHandle_);
                            continue;
                        }
                        case 0x20:
                        {
                            this.result.hasPassword = input.ReadInt32(ref this.result.password_);
                            continue;
                        }
                        case 40:
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
                    this.result.hasAiDeck = input.ReadInt64(ref this.result.aiDeck_);
                }
                return this;
            }

            private AddPlayer PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AddPlayer result = this.result;
                    this.result = new AddPlayer();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public AddPlayer.Builder SetAiDeck(long value)
            {
                this.PrepareBuilder();
                this.result.hasAiDeck = true;
                this.result.aiDeck_ = value;
                return this;
            }

            public AddPlayer.Builder SetClientHandle(int value)
            {
                this.PrepareBuilder();
                this.result.hasClientHandle = true;
                this.result.clientHandle_ = value;
                return this;
            }

            public AddPlayer.Builder SetDeck(long value)
            {
                this.PrepareBuilder();
                this.result.hasDeck = true;
                this.result.deck_ = value;
                return this;
            }

            public AddPlayer.Builder SetGameHandle(int value)
            {
                this.PrepareBuilder();
                this.result.hasGameHandle = true;
                this.result.gameHandle_ = value;
                return this;
            }

            public AddPlayer.Builder SetPassword(int value)
            {
                this.PrepareBuilder();
                this.result.hasPassword = true;
                this.result.password_ = value;
                return this;
            }

            public long AiDeck
            {
                get
                {
                    return this.result.AiDeck;
                }
                set
                {
                    this.SetAiDeck(value);
                }
            }

            public int ClientHandle
            {
                get
                {
                    return this.result.ClientHandle;
                }
                set
                {
                    this.SetClientHandle(value);
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

            public override AddPlayer DefaultInstanceForType
            {
                get
                {
                    return AddPlayer.DefaultInstance;
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

            public bool HasAiDeck
            {
                get
                {
                    return this.result.hasAiDeck;
                }
            }

            public bool HasClientHandle
            {
                get
                {
                    return this.result.hasClientHandle;
                }
            }

            public bool HasDeck
            {
                get
                {
                    return this.result.hasDeck;
                }
            }

            public bool HasGameHandle
            {
                get
                {
                    return this.result.hasGameHandle;
                }
            }

            public bool HasPassword
            {
                get
                {
                    return this.result.hasPassword;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override AddPlayer MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int Password
            {
                get
                {
                    return this.result.Password;
                }
                set
                {
                    this.SetPassword(value);
                }
            }

            protected override AddPlayer.Builder ThisBuilder
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
                ID = 120
            }
        }
    }
}

