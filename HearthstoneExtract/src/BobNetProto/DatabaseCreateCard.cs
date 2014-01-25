namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class DatabaseCreateCard : GeneratedMessageLite<DatabaseCreateCard, Builder>
    {
        private static readonly string[] _databaseCreateCardFieldNames = new string[] { "card" };
        private static readonly uint[] _databaseCreateCardFieldTags = new uint[] { 8 };
        private int card_;
        public const int CardFieldNumber = 1;
        private static readonly DatabaseCreateCard defaultInstance = new DatabaseCreateCard().MakeReadOnly();
        private bool hasCard;
        private int memoizedSerializedSize = -1;

        static DatabaseCreateCard()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private DatabaseCreateCard()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DatabaseCreateCard prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DatabaseCreateCard card = obj as DatabaseCreateCard;
            if (card == null)
            {
                return false;
            }
            return ((this.hasCard == card.hasCard) && (!this.hasCard || this.card_.Equals(card.card_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasCard)
            {
                hashCode ^= this.card_.GetHashCode();
            }
            return hashCode;
        }

        private DatabaseCreateCard MakeReadOnly()
        {
            return this;
        }

        public static DatabaseCreateCard ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DatabaseCreateCard ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DatabaseCreateCard ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DatabaseCreateCard ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DatabaseCreateCard ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DatabaseCreateCard ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DatabaseCreateCard ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DatabaseCreateCard ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DatabaseCreateCard ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DatabaseCreateCard ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DatabaseCreateCard, Builder>.PrintField("card", this.hasCard, this.card_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _databaseCreateCardFieldNames;
            if (this.hasCard)
            {
                output.WriteInt32(1, strArray[0], this.Card);
            }
        }

        public int Card
        {
            get
            {
                return this.card_;
            }
        }

        public static DatabaseCreateCard DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DatabaseCreateCard DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasCard
        {
            get
            {
                return this.hasCard;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasCard)
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
                    if (this.hasCard)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.Card);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override DatabaseCreateCard ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<DatabaseCreateCard, DatabaseCreateCard.Builder>
        {
            private DatabaseCreateCard result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DatabaseCreateCard.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DatabaseCreateCard cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override DatabaseCreateCard BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DatabaseCreateCard.Builder Clear()
            {
                this.result = DatabaseCreateCard.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DatabaseCreateCard.Builder ClearCard()
            {
                this.PrepareBuilder();
                this.result.hasCard = false;
                this.result.card_ = 0;
                return this;
            }

            public override DatabaseCreateCard.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DatabaseCreateCard.Builder(this.result);
                }
                return new DatabaseCreateCard.Builder().MergeFrom(this.result);
            }

            public override DatabaseCreateCard.Builder MergeFrom(DatabaseCreateCard other)
            {
                if (other != DatabaseCreateCard.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasCard)
                    {
                        this.Card = other.Card;
                    }
                }
                return this;
            }

            public override DatabaseCreateCard.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DatabaseCreateCard.Builder MergeFrom(IMessageLite other)
            {
                if (other is DatabaseCreateCard)
                {
                    return this.MergeFrom((DatabaseCreateCard) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DatabaseCreateCard.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DatabaseCreateCard._databaseCreateCardFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DatabaseCreateCard._databaseCreateCardFieldTags[index];
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
                    this.result.hasCard = input.ReadInt32(ref this.result.card_);
                }
                return this;
            }

            private DatabaseCreateCard PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DatabaseCreateCard result = this.result;
                    this.result = new DatabaseCreateCard();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DatabaseCreateCard.Builder SetCard(int value)
            {
                this.PrepareBuilder();
                this.result.hasCard = true;
                this.result.card_ = value;
                return this;
            }

            public int Card
            {
                get
                {
                    return this.result.Card;
                }
                set
                {
                    this.SetCard(value);
                }
            }

            public override DatabaseCreateCard DefaultInstanceForType
            {
                get
                {
                    return DatabaseCreateCard.DefaultInstance;
                }
            }

            public bool HasCard
            {
                get
                {
                    return this.result.hasCard;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override DatabaseCreateCard MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override DatabaseCreateCard.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0x81
            }
        }
    }
}

