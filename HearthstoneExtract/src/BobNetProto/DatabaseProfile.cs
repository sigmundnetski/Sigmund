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

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class DatabaseProfile : GeneratedMessageLite<DatabaseProfile, Builder>
    {
        private static readonly string[] _databaseProfileFieldNames = new string[] { "cards", "decks" };
        private static readonly uint[] _databaseProfileFieldTags = new uint[] { 10, 0x12 };
        private PopsicleList<DatabaseCard> cards_ = new PopsicleList<DatabaseCard>();
        public const int CardsFieldNumber = 1;
        private PopsicleList<DatabaseDeck> decks_ = new PopsicleList<DatabaseDeck>();
        public const int DecksFieldNumber = 2;
        private static readonly DatabaseProfile defaultInstance = new DatabaseProfile().MakeReadOnly();
        private int memoizedSerializedSize = -1;

        static DatabaseProfile()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private DatabaseProfile()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DatabaseProfile prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DatabaseProfile profile = obj as DatabaseProfile;
            if (profile == null)
            {
                return false;
            }
            if (this.cards_.Count != profile.cards_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.cards_.Count; i++)
            {
                if (!this.cards_[i].Equals(profile.cards_[i]))
                {
                    return false;
                }
            }
            if (this.decks_.Count != profile.decks_.Count)
            {
                return false;
            }
            for (int j = 0; j < this.decks_.Count; j++)
            {
                if (!this.decks_[j].Equals(profile.decks_[j]))
                {
                    return false;
                }
            }
            return true;
        }

        public DatabaseCard GetCards(int index)
        {
            return this.cards_[index];
        }

        public DatabaseDeck GetDecks(int index)
        {
            return this.decks_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<DatabaseCard> enumerator = this.cards_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    DatabaseCard current = enumerator.Current;
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
            IEnumerator<DatabaseDeck> enumerator2 = this.decks_.GetEnumerator();
            try
            {
                while (enumerator2.MoveNext())
                {
                    DatabaseDeck deck = enumerator2.Current;
                    hashCode ^= deck.GetHashCode();
                }
            }
            finally
            {
                if (enumerator2 == null)
                {
                }
                enumerator2.Dispose();
            }
            return hashCode;
        }

        private DatabaseProfile MakeReadOnly()
        {
            this.cards_.MakeReadOnly();
            this.decks_.MakeReadOnly();
            return this;
        }

        public static DatabaseProfile ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DatabaseProfile ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DatabaseProfile ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DatabaseProfile ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DatabaseProfile ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DatabaseProfile ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DatabaseProfile ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DatabaseProfile ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DatabaseProfile ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DatabaseProfile ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DatabaseProfile, Builder>.PrintField<DatabaseCard>("cards", this.cards_, writer);
            GeneratedMessageLite<DatabaseProfile, Builder>.PrintField<DatabaseDeck>("decks", this.decks_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _databaseProfileFieldNames;
            if (this.cards_.Count > 0)
            {
                output.WriteMessageArray<DatabaseCard>(1, strArray[0], this.cards_);
            }
            if (this.decks_.Count > 0)
            {
                output.WriteMessageArray<DatabaseDeck>(2, strArray[1], this.decks_);
            }
        }

        public int CardsCount
        {
            get
            {
                return this.cards_.Count;
            }
        }

        public IList<DatabaseCard> CardsList
        {
            get
            {
                return this.cards_;
            }
        }

        public int DecksCount
        {
            get
            {
                return this.decks_.Count;
            }
        }

        public IList<DatabaseDeck> DecksList
        {
            get
            {
                return this.decks_;
            }
        }

        public static DatabaseProfile DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DatabaseProfile DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                IEnumerator<DatabaseCard> enumerator = this.CardsList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        DatabaseCard current = enumerator.Current;
                        if (!current.IsInitialized)
                        {
                            return false;
                        }
                    }
                }
                finally
                {
                    if (enumerator == null)
                    {
                    }
                    enumerator.Dispose();
                }
                IEnumerator<DatabaseDeck> enumerator2 = this.DecksList.GetEnumerator();
                try
                {
                    while (enumerator2.MoveNext())
                    {
                        DatabaseDeck deck = enumerator2.Current;
                        if (!deck.IsInitialized)
                        {
                            return false;
                        }
                    }
                }
                finally
                {
                    if (enumerator2 == null)
                    {
                    }
                    enumerator2.Dispose();
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
                    IEnumerator<DatabaseCard> enumerator = this.CardsList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            DatabaseCard current = enumerator.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, current);
                        }
                    }
                    finally
                    {
                        if (enumerator == null)
                        {
                        }
                        enumerator.Dispose();
                    }
                    IEnumerator<DatabaseDeck> enumerator2 = this.DecksList.GetEnumerator();
                    try
                    {
                        while (enumerator2.MoveNext())
                        {
                            DatabaseDeck deck = enumerator2.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, deck);
                        }
                    }
                    finally
                    {
                        if (enumerator2 == null)
                        {
                        }
                        enumerator2.Dispose();
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override DatabaseProfile ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<DatabaseProfile, DatabaseProfile.Builder>
        {
            private DatabaseProfile result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DatabaseProfile.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DatabaseProfile cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public DatabaseProfile.Builder AddCards(DatabaseCard value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.cards_.Add(value);
                return this;
            }

            public DatabaseProfile.Builder AddCards(DatabaseCard.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.cards_.Add(builderForValue.Build());
                return this;
            }

            public DatabaseProfile.Builder AddDecks(DatabaseDeck value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.decks_.Add(value);
                return this;
            }

            public DatabaseProfile.Builder AddDecks(DatabaseDeck.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.decks_.Add(builderForValue.Build());
                return this;
            }

            public DatabaseProfile.Builder AddRangeCards(IEnumerable<DatabaseCard> values)
            {
                this.PrepareBuilder();
                this.result.cards_.Add(values);
                return this;
            }

            public DatabaseProfile.Builder AddRangeDecks(IEnumerable<DatabaseDeck> values)
            {
                this.PrepareBuilder();
                this.result.decks_.Add(values);
                return this;
            }

            public override DatabaseProfile BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DatabaseProfile.Builder Clear()
            {
                this.result = DatabaseProfile.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DatabaseProfile.Builder ClearCards()
            {
                this.PrepareBuilder();
                this.result.cards_.Clear();
                return this;
            }

            public DatabaseProfile.Builder ClearDecks()
            {
                this.PrepareBuilder();
                this.result.decks_.Clear();
                return this;
            }

            public override DatabaseProfile.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DatabaseProfile.Builder(this.result);
                }
                return new DatabaseProfile.Builder().MergeFrom(this.result);
            }

            public DatabaseCard GetCards(int index)
            {
                return this.result.GetCards(index);
            }

            public DatabaseDeck GetDecks(int index)
            {
                return this.result.GetDecks(index);
            }

            public override DatabaseProfile.Builder MergeFrom(DatabaseProfile other)
            {
                if (other != DatabaseProfile.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.cards_.Count != 0)
                    {
                        this.result.cards_.Add(other.cards_);
                    }
                    if (other.decks_.Count != 0)
                    {
                        this.result.decks_.Add(other.decks_);
                    }
                }
                return this;
            }

            public override DatabaseProfile.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DatabaseProfile.Builder MergeFrom(IMessageLite other)
            {
                if (other is DatabaseProfile)
                {
                    return this.MergeFrom((DatabaseProfile) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DatabaseProfile.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DatabaseProfile._databaseProfileFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DatabaseProfile._databaseProfileFieldTags[index];
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
                            input.ReadMessageArray<DatabaseCard>(num, str, this.result.cards_, DatabaseCard.DefaultInstance, extensionRegistry);
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
                    input.ReadMessageArray<DatabaseDeck>(num, str, this.result.decks_, DatabaseDeck.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private DatabaseProfile PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DatabaseProfile result = this.result;
                    this.result = new DatabaseProfile();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DatabaseProfile.Builder SetCards(int index, DatabaseCard value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.cards_[index] = value;
                return this;
            }

            public DatabaseProfile.Builder SetCards(int index, DatabaseCard.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.cards_[index] = builderForValue.Build();
                return this;
            }

            public DatabaseProfile.Builder SetDecks(int index, DatabaseDeck value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.decks_[index] = value;
                return this;
            }

            public DatabaseProfile.Builder SetDecks(int index, DatabaseDeck.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.decks_[index] = builderForValue.Build();
                return this;
            }

            public int CardsCount
            {
                get
                {
                    return this.result.CardsCount;
                }
            }

            public IPopsicleList<DatabaseCard> CardsList
            {
                get
                {
                    return this.PrepareBuilder().cards_;
                }
            }

            public int DecksCount
            {
                get
                {
                    return this.result.DecksCount;
                }
            }

            public IPopsicleList<DatabaseDeck> DecksList
            {
                get
                {
                    return this.PrepareBuilder().decks_;
                }
            }

            public override DatabaseProfile DefaultInstanceForType
            {
                get
                {
                    return DatabaseProfile.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override DatabaseProfile MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override DatabaseProfile.Builder ThisBuilder
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
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0x80
            }
        }
    }
}

