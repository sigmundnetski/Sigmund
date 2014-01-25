namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class DeckDeleted : GeneratedMessageLite<DeckDeleted, Builder>
    {
        private static readonly string[] _deckDeletedFieldNames = new string[] { "deck" };
        private static readonly uint[] _deckDeletedFieldTags = new uint[] { 8 };
        private long deck_;
        public const int DeckFieldNumber = 1;
        private static readonly DeckDeleted defaultInstance = new DeckDeleted().MakeReadOnly();
        private bool hasDeck;
        private int memoizedSerializedSize = -1;

        static DeckDeleted()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private DeckDeleted()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DeckDeleted prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DeckDeleted deleted = obj as DeckDeleted;
            if (deleted == null)
            {
                return false;
            }
            return ((this.hasDeck == deleted.hasDeck) && (!this.hasDeck || this.deck_.Equals(deleted.deck_)));
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

        private DeckDeleted MakeReadOnly()
        {
            return this;
        }

        public static DeckDeleted ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DeckDeleted ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DeckDeleted ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DeckDeleted ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DeckDeleted ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DeckDeleted ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DeckDeleted ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DeckDeleted ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DeckDeleted ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DeckDeleted ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DeckDeleted, Builder>.PrintField("deck", this.hasDeck, this.deck_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _deckDeletedFieldNames;
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

        public static DeckDeleted DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DeckDeleted DefaultInstanceForType
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

        protected override DeckDeleted ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<DeckDeleted, DeckDeleted.Builder>
        {
            private DeckDeleted result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DeckDeleted.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DeckDeleted cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override DeckDeleted BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DeckDeleted.Builder Clear()
            {
                this.result = DeckDeleted.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DeckDeleted.Builder ClearDeck()
            {
                this.PrepareBuilder();
                this.result.hasDeck = false;
                this.result.deck_ = 0L;
                return this;
            }

            public override DeckDeleted.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DeckDeleted.Builder(this.result);
                }
                return new DeckDeleted.Builder().MergeFrom(this.result);
            }

            public override DeckDeleted.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DeckDeleted.Builder MergeFrom(IMessageLite other)
            {
                if (other is DeckDeleted)
                {
                    return this.MergeFrom((DeckDeleted) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DeckDeleted.Builder MergeFrom(DeckDeleted other)
            {
                if (other != DeckDeleted.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasDeck)
                    {
                        this.Deck = other.Deck;
                    }
                }
                return this;
            }

            public override DeckDeleted.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DeckDeleted._deckDeletedFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DeckDeleted._deckDeletedFieldTags[index];
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

            private DeckDeleted PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DeckDeleted result = this.result;
                    this.result = new DeckDeleted();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DeckDeleted.Builder SetDeck(long value)
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

            public override DeckDeleted DefaultInstanceForType
            {
                get
                {
                    return DeckDeleted.DefaultInstance;
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

            protected override DeckDeleted MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override DeckDeleted.Builder ThisBuilder
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
                ID = 0xda
            }
        }
    }
}

