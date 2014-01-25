namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class GameListings : GeneratedMessageLite<GameListings, Builder>
    {
        private static readonly string[] _gameListingsFieldNames = new string[] { "enable" };
        private static readonly uint[] _gameListingsFieldTags = new uint[] { 8 };
        private static readonly GameListings defaultInstance = new GameListings().MakeReadOnly();
        private bool enable_;
        public const int EnableFieldNumber = 1;
        private bool hasEnable;
        private int memoizedSerializedSize = -1;

        static GameListings()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private GameListings()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GameListings prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GameListings listings = obj as GameListings;
            if (listings == null)
            {
                return false;
            }
            return ((this.hasEnable == listings.hasEnable) && (!this.hasEnable || this.enable_.Equals(listings.enable_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasEnable)
            {
                hashCode ^= this.enable_.GetHashCode();
            }
            return hashCode;
        }

        private GameListings MakeReadOnly()
        {
            return this;
        }

        public static GameListings ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GameListings ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameListings ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GameListings ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GameListings ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GameListings ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GameListings ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GameListings ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameListings ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameListings ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GameListings, Builder>.PrintField("enable", this.hasEnable, this.enable_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _gameListingsFieldNames;
            if (this.hasEnable)
            {
                output.WriteBool(1, strArray[0], this.Enable);
            }
        }

        public static GameListings DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GameListings DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool Enable
        {
            get
            {
                return this.enable_;
            }
        }

        public bool HasEnable
        {
            get
            {
                return this.hasEnable;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasEnable)
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
                    if (this.hasEnable)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(1, this.Enable);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override GameListings ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<GameListings, GameListings.Builder>
        {
            private GameListings result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GameListings.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GameListings cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override GameListings BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GameListings.Builder Clear()
            {
                this.result = GameListings.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GameListings.Builder ClearEnable()
            {
                this.PrepareBuilder();
                this.result.hasEnable = false;
                this.result.enable_ = false;
                return this;
            }

            public override GameListings.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GameListings.Builder(this.result);
                }
                return new GameListings.Builder().MergeFrom(this.result);
            }

            public override GameListings.Builder MergeFrom(GameListings other)
            {
                if (other != GameListings.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasEnable)
                    {
                        this.Enable = other.Enable;
                    }
                }
                return this;
            }

            public override GameListings.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GameListings.Builder MergeFrom(IMessageLite other)
            {
                if (other is GameListings)
                {
                    return this.MergeFrom((GameListings) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GameListings.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GameListings._gameListingsFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GameListings._gameListingsFieldTags[index];
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
                    this.result.hasEnable = input.ReadBool(ref this.result.enable_);
                }
                return this;
            }

            private GameListings PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GameListings result = this.result;
                    this.result = new GameListings();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public GameListings.Builder SetEnable(bool value)
            {
                this.PrepareBuilder();
                this.result.hasEnable = true;
                this.result.enable_ = value;
                return this;
            }

            public override GameListings DefaultInstanceForType
            {
                get
                {
                    return GameListings.DefaultInstance;
                }
            }

            public bool Enable
            {
                get
                {
                    return this.result.Enable;
                }
                set
                {
                    this.SetEnable(value);
                }
            }

            public bool HasEnable
            {
                get
                {
                    return this.result.hasEnable;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override GameListings MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override GameListings.Builder ThisBuilder
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
                ID = 0x66
            }
        }
    }
}

