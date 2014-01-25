namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class DatabaseDeleteDeck : GeneratedMessageLite<DatabaseDeleteDeck, Builder>
    {
        private static readonly string[] _databaseDeleteDeckFieldNames = new string[] { "deck" };
        private static readonly uint[] _databaseDeleteDeckFieldTags = new uint[] { 8 };
        private long deck_;
        public const int DeckFieldNumber = 1;
        private static readonly DatabaseDeleteDeck defaultInstance = new DatabaseDeleteDeck().MakeReadOnly();
        private bool hasDeck;
        private int memoizedSerializedSize = -1;

        static DatabaseDeleteDeck()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private DatabaseDeleteDeck()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DatabaseDeleteDeck prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DatabaseDeleteDeck deck = obj as DatabaseDeleteDeck;
            if (deck == null)
            {
                return false;
            }
            return ((this.hasDeck == deck.hasDeck) && (!this.hasDeck || this.deck_.Equals(deck.deck_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasDeck)
            {
                hashCode ^= this.deck_.GetHashCode();
            }
            return hashCode;
        }

        private DatabaseDeleteDeck MakeReadOnly()
        {
            return this;
        }

        public static DatabaseDeleteDeck ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DatabaseDeleteDeck ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DatabaseDeleteDeck ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DatabaseDeleteDeck ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DatabaseDeleteDeck ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DatabaseDeleteDeck ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DatabaseDeleteDeck ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DatabaseDeleteDeck ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DatabaseDeleteDeck ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DatabaseDeleteDeck ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DatabaseDeleteDeck, Builder>.PrintField("deck", this.hasDeck, this.deck_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _databaseDeleteDeckFieldNames;
            if (this.hasDeck)
            {
                output.WriteInt64(1, strArray[0], this.Deck);
            }
        }

        public long Deck
        {
            get
            {
                return this.deck_;
            }
        }

        public static DatabaseDeleteDeck DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DatabaseDeleteDeck DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
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
                    if (this.hasDeck)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(1, this.Deck);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override DatabaseDeleteDeck ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<DatabaseDeleteDeck, DatabaseDeleteDeck.Builder>
        {
            private DatabaseDeleteDeck result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DatabaseDeleteDeck.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DatabaseDeleteDeck cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override DatabaseDeleteDeck BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DatabaseDeleteDeck.Builder Clear()
            {
                this.result = DatabaseDeleteDeck.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DatabaseDeleteDeck.Builder ClearDeck()
            {
                this.PrepareBuilder();
                this.result.hasDeck = false;
                this.result.deck_ = 0L;
                return this;
            }

            public override DatabaseDeleteDeck.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DatabaseDeleteDeck.Builder(this.result);
                }
                return new DatabaseDeleteDeck.Builder().MergeFrom(this.result);
            }

            public override DatabaseDeleteDeck.Builder MergeFrom(DatabaseDeleteDeck other)
            {
                if (other != DatabaseDeleteDeck.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasDeck)
                    {
                        this.Deck = other.Deck;
                    }
                }
                return this;
            }

            public override DatabaseDeleteDeck.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DatabaseDeleteDeck.Builder MergeFrom(IMessageLite other)
            {
                if (other is DatabaseDeleteDeck)
                {
                    return this.MergeFrom((DatabaseDeleteDeck) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DatabaseDeleteDeck.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DatabaseDeleteDeck._databaseDeleteDeckFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DatabaseDeleteDeck._databaseDeleteDeckFieldTags[index];
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
                    this.result.hasDeck = input.ReadInt64(ref this.result.deck_);
                }
                return this;
            }

            private DatabaseDeleteDeck PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DatabaseDeleteDeck result = this.result;
                    this.result = new DatabaseDeleteDeck();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DatabaseDeleteDeck.Builder SetDeck(long value)
            {
                this.PrepareBuilder();
                this.result.hasDeck = true;
                this.result.deck_ = value;
                return this;
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

            public override DatabaseDeleteDeck DefaultInstanceForType
            {
                get
                {
                    return DatabaseDeleteDeck.DefaultInstance;
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

            protected override DatabaseDeleteDeck MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override DatabaseDeleteDeck.Builder ThisBuilder
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
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0x88
            }
        }
    }
}

