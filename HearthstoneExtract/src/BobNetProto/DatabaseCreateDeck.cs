namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class DatabaseCreateDeck : GeneratedMessageLite<DatabaseCreateDeck, Builder>
    {
        private static readonly string[] _databaseCreateDeckFieldNames = new string[] { "name" };
        private static readonly uint[] _databaseCreateDeckFieldTags = new uint[] { 10 };
        private static readonly DatabaseCreateDeck defaultInstance = new DatabaseCreateDeck().MakeReadOnly();
        private bool hasName;
        private int memoizedSerializedSize = -1;
        private string name_ = string.Empty;
        public const int NameFieldNumber = 1;

        static DatabaseCreateDeck()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private DatabaseCreateDeck()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DatabaseCreateDeck prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DatabaseCreateDeck deck = obj as DatabaseCreateDeck;
            if (deck == null)
            {
                return false;
            }
            return ((this.hasName == deck.hasName) && (!this.hasName || this.name_.Equals(deck.name_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasName)
            {
                hashCode ^= this.name_.GetHashCode();
            }
            return hashCode;
        }

        private DatabaseCreateDeck MakeReadOnly()
        {
            return this;
        }

        public static DatabaseCreateDeck ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DatabaseCreateDeck ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DatabaseCreateDeck ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DatabaseCreateDeck ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DatabaseCreateDeck ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DatabaseCreateDeck ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DatabaseCreateDeck ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DatabaseCreateDeck ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DatabaseCreateDeck ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DatabaseCreateDeck ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DatabaseCreateDeck, Builder>.PrintField("name", this.hasName, this.name_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _databaseCreateDeckFieldNames;
            if (this.hasName)
            {
                output.WriteString(1, strArray[0], this.Name);
            }
        }

        public static DatabaseCreateDeck DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DatabaseCreateDeck DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
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
                    if (this.hasName)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(1, this.Name);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override DatabaseCreateDeck ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<DatabaseCreateDeck, DatabaseCreateDeck.Builder>
        {
            private DatabaseCreateDeck result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DatabaseCreateDeck.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DatabaseCreateDeck cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override DatabaseCreateDeck BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DatabaseCreateDeck.Builder Clear()
            {
                this.result = DatabaseCreateDeck.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DatabaseCreateDeck.Builder ClearName()
            {
                this.PrepareBuilder();
                this.result.hasName = false;
                this.result.name_ = string.Empty;
                return this;
            }

            public override DatabaseCreateDeck.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DatabaseCreateDeck.Builder(this.result);
                }
                return new DatabaseCreateDeck.Builder().MergeFrom(this.result);
            }

            public override DatabaseCreateDeck.Builder MergeFrom(DatabaseCreateDeck other)
            {
                if (other != DatabaseCreateDeck.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasName)
                    {
                        this.Name = other.Name;
                    }
                }
                return this;
            }

            public override DatabaseCreateDeck.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DatabaseCreateDeck.Builder MergeFrom(IMessageLite other)
            {
                if (other is DatabaseCreateDeck)
                {
                    return this.MergeFrom((DatabaseCreateDeck) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DatabaseCreateDeck.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DatabaseCreateDeck._databaseCreateDeckFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DatabaseCreateDeck._databaseCreateDeckFieldTags[index];
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

            private DatabaseCreateDeck PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DatabaseCreateDeck result = this.result;
                    this.result = new DatabaseCreateDeck();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DatabaseCreateDeck.Builder SetName(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasName = true;
                this.result.name_ = value;
                return this;
            }

            public override DatabaseCreateDeck DefaultInstanceForType
            {
                get
                {
                    return DatabaseCreateDeck.DefaultInstance;
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

            protected override DatabaseCreateDeck MessageBeingBuilt
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

            protected override DatabaseCreateDeck.Builder ThisBuilder
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
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 130
            }
        }
    }
}

