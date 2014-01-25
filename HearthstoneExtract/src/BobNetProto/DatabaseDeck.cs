namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class DatabaseDeck : GeneratedMessageLite<DatabaseDeck, Builder>
    {
        private static readonly string[] _databaseDeckFieldNames = new string[] { "cards", "deck_id", "name" };
        private static readonly uint[] _databaseDeckFieldTags = new uint[] { 0x1a, 8, 0x12 };
        private PopsicleList<int> cards_ = new PopsicleList<int>();
        public const int CardsFieldNumber = 3;
        private int cardsMemoizedSerializedSize;
        private long deckId_;
        public const int DeckIdFieldNumber = 1;
        private static readonly DatabaseDeck defaultInstance = new DatabaseDeck().MakeReadOnly();
        private bool hasDeckId;
        private bool hasName;
        private int memoizedSerializedSize = -1;
        private string name_ = string.Empty;
        public const int NameFieldNumber = 2;

        static DatabaseDeck()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private DatabaseDeck()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DatabaseDeck prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DatabaseDeck deck = obj as DatabaseDeck;
            if (deck == null)
            {
                return false;
            }
            if ((this.hasDeckId != deck.hasDeckId) || (this.hasDeckId && !this.deckId_.Equals(deck.deckId_)))
            {
                return false;
            }
            if ((this.hasName != deck.hasName) || (this.hasName && !this.name_.Equals(deck.name_)))
            {
                return false;
            }
            if (this.cards_.Count != deck.cards_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.cards_.Count; i++)
            {
                int num2 = this.cards_[i];
                if (!num2.Equals(deck.cards_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public int GetCards(int index)
        {
            return this.cards_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasDeckId)
            {
                hashCode ^= this.deckId_.GetHashCode();
            }
            if (this.hasName)
            {
                hashCode ^= this.name_.GetHashCode();
            }
            IEnumerator<int> enumerator = this.cards_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    int current = enumerator.Current;
                    hashCode ^= current.GetHashCode();
                }
            }
            finally
            {
                if (enumerator == null)
                {
                }
                enumerator.Dispose();
            }
            return hashCode;
        }

        private DatabaseDeck MakeReadOnly()
        {
            this.cards_.MakeReadOnly();
            return this;
        }

        public static DatabaseDeck ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DatabaseDeck ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DatabaseDeck ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DatabaseDeck ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DatabaseDeck ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DatabaseDeck ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DatabaseDeck ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DatabaseDeck ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DatabaseDeck ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DatabaseDeck ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DatabaseDeck, Builder>.PrintField("deck_id", this.hasDeckId, this.deckId_, writer);
            GeneratedMessageLite<DatabaseDeck, Builder>.PrintField("name", this.hasName, this.name_, writer);
            GeneratedMessageLite<DatabaseDeck, Builder>.PrintField<int>("cards", this.cards_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _databaseDeckFieldNames;
            if (this.hasDeckId)
            {
                output.WriteInt64(1, strArray[1], this.DeckId);
            }
            if (this.hasName)
            {
                output.WriteString(2, strArray[2], this.Name);
            }
            if (this.cards_.Count > 0)
            {
                output.WritePackedInt32Array(3, strArray[0], this.cardsMemoizedSerializedSize, this.cards_);
            }
        }

        public int CardsCount
        {
            get
            {
                return this.cards_.Count;
            }
        }

        public IList<int> CardsList
        {
            get
            {
                return Lists.AsReadOnly<int>(this.cards_);
            }
        }

        public long DeckId
        {
            get
            {
                return this.deckId_;
            }
        }

        public static DatabaseDeck DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DatabaseDeck DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasDeckId
        {
            get
            {
                return this.hasDeckId;
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
                if (!this.hasDeckId)
                {
                    return false;
                }
                if (!this.hasName)
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
                    if (this.hasDeckId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(1, this.DeckId);
                    }
                    if (this.hasName)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(2, this.Name);
                    }
                    int num2 = 0;
                    IEnumerator<int> enumerator = this.CardsList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            int current = enumerator.Current;
                            num2 += CodedOutputStream.ComputeInt32SizeNoTag(current);
                        }
                    }
                    finally
                    {
                        if (enumerator == null)
                        {
                        }
                        enumerator.Dispose();
                    }
                    memoizedSerializedSize += num2;
                    if (this.cards_.Count != 0)
                    {
                        memoizedSerializedSize += 1 + CodedOutputStream.ComputeInt32SizeNoTag(num2);
                    }
                    this.cardsMemoizedSerializedSize = num2;
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override DatabaseDeck ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<DatabaseDeck, DatabaseDeck.Builder>
        {
            private DatabaseDeck result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DatabaseDeck.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DatabaseDeck cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public DatabaseDeck.Builder AddCards(int value)
            {
                this.PrepareBuilder();
                this.result.cards_.Add(value);
                return this;
            }

            public DatabaseDeck.Builder AddRangeCards(IEnumerable<int> values)
            {
                this.PrepareBuilder();
                this.result.cards_.Add(values);
                return this;
            }

            public override DatabaseDeck BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DatabaseDeck.Builder Clear()
            {
                this.result = DatabaseDeck.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DatabaseDeck.Builder ClearCards()
            {
                this.PrepareBuilder();
                this.result.cards_.Clear();
                return this;
            }

            public DatabaseDeck.Builder ClearDeckId()
            {
                this.PrepareBuilder();
                this.result.hasDeckId = false;
                this.result.deckId_ = 0L;
                return this;
            }

            public DatabaseDeck.Builder ClearName()
            {
                this.PrepareBuilder();
                this.result.hasName = false;
                this.result.name_ = string.Empty;
                return this;
            }

            public override DatabaseDeck.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DatabaseDeck.Builder(this.result);
                }
                return new DatabaseDeck.Builder().MergeFrom(this.result);
            }

            public int GetCards(int index)
            {
                return this.result.GetCards(index);
            }

            public override DatabaseDeck.Builder MergeFrom(DatabaseDeck other)
            {
                if (other != DatabaseDeck.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasDeckId)
                    {
                        this.DeckId = other.DeckId;
                    }
                    if (other.HasName)
                    {
                        this.Name = other.Name;
                    }
                    if (other.cards_.Count != 0)
                    {
                        this.result.cards_.Add(other.cards_);
                    }
                }
                return this;
            }

            public override DatabaseDeck.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DatabaseDeck.Builder MergeFrom(IMessageLite other)
            {
                if (other is DatabaseDeck)
                {
                    return this.MergeFrom((DatabaseDeck) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DatabaseDeck.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DatabaseDeck._databaseDeckFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DatabaseDeck._databaseDeckFieldTags[index];
                        }
                        else
                        {
                            this.ParseUnknownField(input, extensionRegistry, num, str);
                            continue;
                        }
                    }
                    switch (num)
                    {
                        case 0x18:
                        case 0x1a:
                            goto Label_00E4;

                        case 0:
                            throw InvalidProtocolBufferException.InvalidTag();

                        case 8:
                            break;

                        case 0x12:
                            goto Label_00C3;

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
                    this.result.hasDeckId = input.ReadInt64(ref this.result.deckId_);
                    continue;
                Label_00C3:
                    this.result.hasName = input.ReadString(ref this.result.name_);
                    continue;
                Label_00E4:
                    input.ReadInt32Array(num, str, this.result.cards_);
                }
                return this;
            }

            private DatabaseDeck PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DatabaseDeck result = this.result;
                    this.result = new DatabaseDeck();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DatabaseDeck.Builder SetCards(int index, int value)
            {
                this.PrepareBuilder();
                this.result.cards_[index] = value;
                return this;
            }

            public DatabaseDeck.Builder SetDeckId(long value)
            {
                this.PrepareBuilder();
                this.result.hasDeckId = true;
                this.result.deckId_ = value;
                return this;
            }

            public DatabaseDeck.Builder SetName(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasName = true;
                this.result.name_ = value;
                return this;
            }

            public int CardsCount
            {
                get
                {
                    return this.result.CardsCount;
                }
            }

            public IPopsicleList<int> CardsList
            {
                get
                {
                    return this.PrepareBuilder().cards_;
                }
            }

            public long DeckId
            {
                get
                {
                    return this.result.DeckId;
                }
                set
                {
                    this.SetDeckId(value);
                }
            }

            public override DatabaseDeck DefaultInstanceForType
            {
                get
                {
                    return DatabaseDeck.DefaultInstance;
                }
            }

            public bool HasDeckId
            {
                get
                {
                    return this.result.hasDeckId;
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

            protected override DatabaseDeck MessageBeingBuilt
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

            protected override DatabaseDeck.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

