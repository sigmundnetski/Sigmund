namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class DatabaseCardChange : GeneratedMessageLite<DatabaseCardChange, Builder>
    {
        private static readonly string[] _databaseCardChangeFieldNames = new string[] { "added", "card" };
        private static readonly uint[] _databaseCardChangeFieldTags = new uint[] { 0x10, 8 };
        private bool added_;
        public const int AddedFieldNumber = 2;
        private int card_;
        public const int CardFieldNumber = 1;
        private static readonly DatabaseCardChange defaultInstance = new DatabaseCardChange().MakeReadOnly();
        private bool hasAdded;
        private bool hasCard;
        private int memoizedSerializedSize = -1;

        static DatabaseCardChange()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private DatabaseCardChange()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DatabaseCardChange prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DatabaseCardChange change = obj as DatabaseCardChange;
            if (change == null)
            {
                return false;
            }
            if ((this.hasCard != change.hasCard) || (this.hasCard && !this.card_.Equals(change.card_)))
            {
                return false;
            }
            return ((this.hasAdded == change.hasAdded) && (!this.hasAdded || this.added_.Equals(change.added_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasCard)
            {
                hashCode ^= this.card_.GetHashCode();
            }
            if (this.hasAdded)
            {
                hashCode ^= this.added_.GetHashCode();
            }
            return hashCode;
        }

        private DatabaseCardChange MakeReadOnly()
        {
            return this;
        }

        public static DatabaseCardChange ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DatabaseCardChange ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DatabaseCardChange ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DatabaseCardChange ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DatabaseCardChange ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DatabaseCardChange ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DatabaseCardChange ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DatabaseCardChange ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DatabaseCardChange ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DatabaseCardChange ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DatabaseCardChange, Builder>.PrintField("card", this.hasCard, this.card_, writer);
            GeneratedMessageLite<DatabaseCardChange, Builder>.PrintField("added", this.hasAdded, this.added_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _databaseCardChangeFieldNames;
            if (this.hasCard)
            {
                output.WriteInt32(1, strArray[1], this.Card);
            }
            if (this.hasAdded)
            {
                output.WriteBool(2, strArray[0], this.Added);
            }
        }

        public bool Added
        {
            get
            {
                return this.added_;
            }
        }

        public int Card
        {
            get
            {
                return this.card_;
            }
        }

        public static DatabaseCardChange DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DatabaseCardChange DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasAdded
        {
            get
            {
                return this.hasAdded;
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
                if (!this.hasAdded)
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
                    if (this.hasAdded)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(2, this.Added);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override DatabaseCardChange ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<DatabaseCardChange, DatabaseCardChange.Builder>
        {
            private DatabaseCardChange result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DatabaseCardChange.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DatabaseCardChange cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override DatabaseCardChange BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DatabaseCardChange.Builder Clear()
            {
                this.result = DatabaseCardChange.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DatabaseCardChange.Builder ClearAdded()
            {
                this.PrepareBuilder();
                this.result.hasAdded = false;
                this.result.added_ = false;
                return this;
            }

            public DatabaseCardChange.Builder ClearCard()
            {
                this.PrepareBuilder();
                this.result.hasCard = false;
                this.result.card_ = 0;
                return this;
            }

            public override DatabaseCardChange.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DatabaseCardChange.Builder(this.result);
                }
                return new DatabaseCardChange.Builder().MergeFrom(this.result);
            }

            public override DatabaseCardChange.Builder MergeFrom(DatabaseCardChange other)
            {
                if (other != DatabaseCardChange.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasCard)
                    {
                        this.Card = other.Card;
                    }
                    if (other.HasAdded)
                    {
                        this.Added = other.Added;
                    }
                }
                return this;
            }

            public override DatabaseCardChange.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DatabaseCardChange.Builder MergeFrom(IMessageLite other)
            {
                if (other is DatabaseCardChange)
                {
                    return this.MergeFrom((DatabaseCardChange) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DatabaseCardChange.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DatabaseCardChange._databaseCardChangeFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DatabaseCardChange._databaseCardChangeFieldTags[index];
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
                            this.result.hasCard = input.ReadInt32(ref this.result.card_);
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
                    this.result.hasAdded = input.ReadBool(ref this.result.added_);
                }
                return this;
            }

            private DatabaseCardChange PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DatabaseCardChange result = this.result;
                    this.result = new DatabaseCardChange();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DatabaseCardChange.Builder SetAdded(bool value)
            {
                this.PrepareBuilder();
                this.result.hasAdded = true;
                this.result.added_ = value;
                return this;
            }

            public DatabaseCardChange.Builder SetCard(int value)
            {
                this.PrepareBuilder();
                this.result.hasCard = true;
                this.result.card_ = value;
                return this;
            }

            public bool Added
            {
                get
                {
                    return this.result.Added;
                }
                set
                {
                    this.SetAdded(value);
                }
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

            public override DatabaseCardChange DefaultInstanceForType
            {
                get
                {
                    return DatabaseCardChange.DefaultInstance;
                }
            }

            public bool HasAdded
            {
                get
                {
                    return this.result.hasAdded;
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

            protected override DatabaseCardChange MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override DatabaseCardChange.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0x84
            }
        }
    }
}

