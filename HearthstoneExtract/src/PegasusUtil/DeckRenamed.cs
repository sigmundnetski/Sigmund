namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class DeckRenamed : GeneratedMessageLite<DeckRenamed, Builder>
    {
        private static readonly string[] _deckRenamedFieldNames = new string[] { "deck", "name" };
        private static readonly uint[] _deckRenamedFieldTags = new uint[] { 8, 0x12 };
        private long deck_;
        public const int DeckFieldNumber = 1;
        private static readonly DeckRenamed defaultInstance = new DeckRenamed().MakeReadOnly();
        private bool hasDeck;
        private bool hasName;
        private int memoizedSerializedSize = -1;
        private string name_ = string.Empty;
        public const int NameFieldNumber = 2;

        static DeckRenamed()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private DeckRenamed()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DeckRenamed prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DeckRenamed renamed = obj as DeckRenamed;
            if (renamed == null)
            {
                return false;
            }
            if ((this.hasDeck != renamed.hasDeck) || (this.hasDeck && !this.deck_.Equals(renamed.deck_)))
            {
                return false;
            }
            return ((this.hasName == renamed.hasName) && (!this.hasName || this.name_.Equals(renamed.name_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasDeck)
            {
                hashCode ^= this.deck_.GetHashCode();
            }
            if (this.hasName)
            {
                hashCode ^= this.name_.GetHashCode();
            }
            return hashCode;
        }

        private DeckRenamed MakeReadOnly()
        {
            return this;
        }

        public static DeckRenamed ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DeckRenamed ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DeckRenamed ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DeckRenamed ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DeckRenamed ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DeckRenamed ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DeckRenamed ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DeckRenamed ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DeckRenamed ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DeckRenamed ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DeckRenamed, Builder>.PrintField("deck", this.hasDeck, this.deck_, writer);
            GeneratedMessageLite<DeckRenamed, Builder>.PrintField("name", this.hasName, this.name_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _deckRenamedFieldNames;
            if (this.hasDeck)
            {
                output.WriteInt64(1, strArray[0], this.Deck);
            }
            if (this.hasName)
            {
                output.WriteString(2, strArray[1], this.Name);
            }
        }

        public long Deck
        {
            get
            {
                return this.deck_;
            }
        }

        public static DeckRenamed DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DeckRenamed DefaultInstanceForType
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
                if (!this.hasDeck)
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
                    if (this.hasDeck)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(1, this.Deck);
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

        protected override DeckRenamed ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<DeckRenamed, DeckRenamed.Builder>
        {
            private DeckRenamed result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DeckRenamed.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DeckRenamed cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override DeckRenamed BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DeckRenamed.Builder Clear()
            {
                this.result = DeckRenamed.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DeckRenamed.Builder ClearDeck()
            {
                this.PrepareBuilder();
                this.result.hasDeck = false;
                this.result.deck_ = 0L;
                return this;
            }

            public DeckRenamed.Builder ClearName()
            {
                this.PrepareBuilder();
                this.result.hasName = false;
                this.result.name_ = string.Empty;
                return this;
            }

            public override DeckRenamed.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DeckRenamed.Builder(this.result);
                }
                return new DeckRenamed.Builder().MergeFrom(this.result);
            }

            public override DeckRenamed.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DeckRenamed.Builder MergeFrom(IMessageLite other)
            {
                if (other is DeckRenamed)
                {
                    return this.MergeFrom((DeckRenamed) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DeckRenamed.Builder MergeFrom(DeckRenamed other)
            {
                if (other != DeckRenamed.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasDeck)
                    {
                        this.Deck = other.Deck;
                    }
                    if (other.HasName)
                    {
                        this.Name = other.Name;
                    }
                }
                return this;
            }

            public override DeckRenamed.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DeckRenamed._deckRenamedFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DeckRenamed._deckRenamedFieldTags[index];
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
                            this.result.hasDeck = input.ReadInt64(ref this.result.deck_);
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

            private DeckRenamed PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DeckRenamed result = this.result;
                    this.result = new DeckRenamed();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DeckRenamed.Builder SetDeck(long value)
            {
                this.PrepareBuilder();
                this.result.hasDeck = true;
                this.result.deck_ = value;
                return this;
            }

            public DeckRenamed.Builder SetName(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasName = true;
                this.result.name_ = value;
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

            public override DeckRenamed DefaultInstanceForType
            {
                get
                {
                    return DeckRenamed.DefaultInstance;
                }
            }

            public bool HasDeck
            {
                get
                {
                    return this.result.hasDeck;
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

            protected override DeckRenamed MessageBeingBuilt
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

            protected override DeckRenamed.Builder ThisBuilder
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
                ID = 0xdb
            }
        }
    }
}

