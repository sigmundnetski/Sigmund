namespace bnet.protocol.account
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class GameAccountLink : GeneratedMessageLite<GameAccountLink, Builder>
    {
        private static readonly string[] _gameAccountLinkFieldNames = new string[] { "game_account", "name" };
        private static readonly uint[] _gameAccountLinkFieldTags = new uint[] { 10, 0x12 };
        private static readonly GameAccountLink defaultInstance = new GameAccountLink().MakeReadOnly();
        private GameAccountHandle gameAccount_;
        public const int GameAccountFieldNumber = 1;
        private bool hasGameAccount;
        private bool hasName;
        private int memoizedSerializedSize = -1;
        private string name_ = string.Empty;
        public const int NameFieldNumber = 2;

        static GameAccountLink()
        {
            object.ReferenceEquals(AccountTypes.Descriptor, null);
        }

        private GameAccountLink()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GameAccountLink prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GameAccountLink link = obj as GameAccountLink;
            if (link == null)
            {
                return false;
            }
            if ((this.hasGameAccount != link.hasGameAccount) || (this.hasGameAccount && !this.gameAccount_.Equals(link.gameAccount_)))
            {
                return false;
            }
            return ((this.hasName == link.hasName) && (!this.hasName || this.name_.Equals(link.name_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasGameAccount)
            {
                hashCode ^= this.gameAccount_.GetHashCode();
            }
            if (this.hasName)
            {
                hashCode ^= this.name_.GetHashCode();
            }
            return hashCode;
        }

        private GameAccountLink MakeReadOnly()
        {
            return this;
        }

        public static GameAccountLink ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GameAccountLink ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameAccountLink ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GameAccountLink ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GameAccountLink ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GameAccountLink ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GameAccountLink ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GameAccountLink ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameAccountLink ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameAccountLink ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GameAccountLink, Builder>.PrintField("game_account", this.hasGameAccount, this.gameAccount_, writer);
            GeneratedMessageLite<GameAccountLink, Builder>.PrintField("name", this.hasName, this.name_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _gameAccountLinkFieldNames;
            if (this.hasGameAccount)
            {
                output.WriteMessage(1, strArray[0], this.GameAccount);
            }
            if (this.hasName)
            {
                output.WriteString(2, strArray[1], this.Name);
            }
        }

        public static GameAccountLink DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GameAccountLink DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public GameAccountHandle GameAccount
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.gameAccount_ != null)
                {
                    goto Label_0012;
                }
                return GameAccountHandle.DefaultInstance;
            }
        }

        public bool HasGameAccount
        {
            get
            {
                return this.hasGameAccount;
            }
        }

        public bool HasName
        {
            get
            {
                return this.hasName;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasGameAccount)
                {
                    return false;
                }
                if (!this.hasName)
                {
                    return false;
                }
                if (!this.GameAccount.IsInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        public string Name
        {
            get
            {
                return this.name_;
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
                    if (this.hasGameAccount)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.GameAccount);
                    }
                    if (this.hasName)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(2, this.Name);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override GameAccountLink ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<GameAccountLink, GameAccountLink.Builder>
        {
            private GameAccountLink result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GameAccountLink.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GameAccountLink cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override GameAccountLink BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GameAccountLink.Builder Clear()
            {
                this.result = GameAccountLink.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GameAccountLink.Builder ClearGameAccount()
            {
                this.PrepareBuilder();
                this.result.hasGameAccount = false;
                this.result.gameAccount_ = null;
                return this;
            }

            public GameAccountLink.Builder ClearName()
            {
                this.PrepareBuilder();
                this.result.hasName = false;
                this.result.name_ = string.Empty;
                return this;
            }

            public override GameAccountLink.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GameAccountLink.Builder(this.result);
                }
                return new GameAccountLink.Builder().MergeFrom(this.result);
            }

            public override GameAccountLink.Builder MergeFrom(GameAccountLink other)
            {
                if (other != GameAccountLink.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasGameAccount)
                    {
                        this.MergeGameAccount(other.GameAccount);
                    }
                    if (other.HasName)
                    {
                        this.Name = other.Name;
                    }
                }
                return this;
            }

            public override GameAccountLink.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GameAccountLink.Builder MergeFrom(IMessageLite other)
            {
                if (other is GameAccountLink)
                {
                    return this.MergeFrom((GameAccountLink) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GameAccountLink.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GameAccountLink._gameAccountLinkFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GameAccountLink._gameAccountLinkFieldTags[index];
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
                            GameAccountHandle.Builder builder = GameAccountHandle.CreateBuilder();
                            if (this.result.hasGameAccount)
                            {
                                builder.MergeFrom(this.GameAccount);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.GameAccount = builder.BuildPartial();
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
                    this.result.hasName = input.ReadString(ref this.result.name_);
                }
                return this;
            }

            public GameAccountLink.Builder MergeGameAccount(GameAccountHandle value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasGameAccount && (this.result.gameAccount_ != GameAccountHandle.DefaultInstance))
                {
                    this.result.gameAccount_ = GameAccountHandle.CreateBuilder(this.result.gameAccount_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.gameAccount_ = value;
                }
                this.result.hasGameAccount = true;
                return this;
            }

            private GameAccountLink PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GameAccountLink result = this.result;
                    this.result = new GameAccountLink();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public GameAccountLink.Builder SetGameAccount(GameAccountHandle value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasGameAccount = true;
                this.result.gameAccount_ = value;
                return this;
            }

            public GameAccountLink.Builder SetGameAccount(GameAccountHandle.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasGameAccount = true;
                this.result.gameAccount_ = builderForValue.Build();
                return this;
            }

            public GameAccountLink.Builder SetName(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasName = true;
                this.result.name_ = value;
                return this;
            }

            public override GameAccountLink DefaultInstanceForType
            {
                get
                {
                    return GameAccountLink.DefaultInstance;
                }
            }

            public GameAccountHandle GameAccount
            {
                get
                {
                    return this.result.GameAccount;
                }
                set
                {
                    this.SetGameAccount(value);
                }
            }

            public bool HasGameAccount
            {
                get
                {
                    return this.result.hasGameAccount;
                }
            }

            public bool HasName
            {
                get
                {
                    return this.result.hasName;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override GameAccountLink MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public string Name
            {
                get
                {
                    return this.result.Name;
                }
                set
                {
                    this.SetName(value);
                }
            }

            protected override GameAccountLink.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

