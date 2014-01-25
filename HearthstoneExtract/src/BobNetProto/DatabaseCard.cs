namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class DatabaseCard : GeneratedMessageLite<DatabaseCard, Builder>
    {
        private static readonly string[] _databaseCardFieldNames = new string[] { "card_id", "name" };
        private static readonly uint[] _databaseCardFieldTags = new uint[] { 8, 0x10 };
        private int cardId_;
        public const int CardIdFieldNumber = 1;
        private static readonly DatabaseCard defaultInstance = new DatabaseCard().MakeReadOnly();
        private bool hasCardId;
        private bool hasName;
        private int memoizedSerializedSize = -1;
        private int name_;
        public const int NameFieldNumber = 2;

        static DatabaseCard()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private DatabaseCard()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DatabaseCard prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DatabaseCard card = obj as DatabaseCard;
            if (card == null)
            {
                return false;
            }
            if ((this.hasCardId != card.hasCardId) || (this.hasCardId && !this.cardId_.Equals(card.cardId_)))
            {
                return false;
            }
            return ((this.hasName == card.hasName) && (!this.hasName || this.name_.Equals(card.name_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasCardId)
            {
                hashCode ^= this.cardId_.GetHashCode();
            }
            if (this.hasName)
            {
                hashCode ^= this.name_.GetHashCode();
            }
            return hashCode;
        }

        private DatabaseCard MakeReadOnly()
        {
            return this;
        }

        public static DatabaseCard ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DatabaseCard ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DatabaseCard ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DatabaseCard ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DatabaseCard ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DatabaseCard ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DatabaseCard ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DatabaseCard ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DatabaseCard ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DatabaseCard ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DatabaseCard, Builder>.PrintField("card_id", this.hasCardId, this.cardId_, writer);
            GeneratedMessageLite<DatabaseCard, Builder>.PrintField("name", this.hasName, this.name_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _databaseCardFieldNames;
            if (this.hasCardId)
            {
                output.WriteInt32(1, strArray[0], this.CardId);
            }
            if (this.hasName)
            {
                output.WriteInt32(2, strArray[1], this.Name);
            }
        }

        public int CardId
        {
            get
            {
                return this.cardId_;
            }
        }

        public static DatabaseCard DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DatabaseCard DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasCardId
        {
            get
            {
                return this.hasCardId;
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
                if (!this.hasCardId)
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

        public int Name
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
                    if (this.hasCardId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.CardId);
                    }
                    if (this.hasName)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.Name);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override DatabaseCard ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<DatabaseCard, DatabaseCard.Builder>
        {
            private DatabaseCard result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DatabaseCard.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DatabaseCard cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override DatabaseCard BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DatabaseCard.Builder Clear()
            {
                this.result = DatabaseCard.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DatabaseCard.Builder ClearCardId()
            {
                this.PrepareBuilder();
                this.result.hasCardId = false;
                this.result.cardId_ = 0;
                return this;
            }

            public DatabaseCard.Builder ClearName()
            {
                this.PrepareBuilder();
                this.result.hasName = false;
                this.result.name_ = 0;
                return this;
            }

            public override DatabaseCard.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DatabaseCard.Builder(this.result);
                }
                return new DatabaseCard.Builder().MergeFrom(this.result);
            }

            public override DatabaseCard.Builder MergeFrom(DatabaseCard other)
            {
                if (other != DatabaseCard.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasCardId)
                    {
                        this.CardId = other.CardId;
                    }
                    if (other.HasName)
                    {
                        this.Name = other.Name;
                    }
                }
                return this;
            }

            public override DatabaseCard.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DatabaseCard.Builder MergeFrom(IMessageLite other)
            {
                if (other is DatabaseCard)
                {
                    return this.MergeFrom((DatabaseCard) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DatabaseCard.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DatabaseCard._databaseCardFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DatabaseCard._databaseCardFieldTags[index];
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
                            this.result.hasCardId = input.ReadInt32(ref this.result.cardId_);
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
                    this.result.hasName = input.ReadInt32(ref this.result.name_);
                }
                return this;
            }

            private DatabaseCard PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DatabaseCard result = this.result;
                    this.result = new DatabaseCard();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DatabaseCard.Builder SetCardId(int value)
            {
                this.PrepareBuilder();
                this.result.hasCardId = true;
                this.result.cardId_ = value;
                return this;
            }

            public DatabaseCard.Builder SetName(int value)
            {
                this.PrepareBuilder();
                this.result.hasName = true;
                this.result.name_ = value;
                return this;
            }

            public int CardId
            {
                get
                {
                    return this.result.CardId;
                }
                set
                {
                    this.SetCardId(value);
                }
            }

            public override DatabaseCard DefaultInstanceForType
            {
                get
                {
                    return DatabaseCard.DefaultInstance;
                }
            }

            public bool HasCardId
            {
                get
                {
                    return this.result.hasCardId;
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

            protected override DatabaseCard MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int Name
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

            protected override DatabaseCard.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

