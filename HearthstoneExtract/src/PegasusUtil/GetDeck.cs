namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class GetDeck : GeneratedMessageLite<GetDeck, Builder>
    {
        private static readonly string[] _getDeckFieldNames = new string[] { "deck" };
        private static readonly uint[] _getDeckFieldTags = new uint[] { 8 };
        private long deck_;
        public const int DeckFieldNumber = 1;
        private static readonly GetDeck defaultInstance = new GetDeck().MakeReadOnly();
        private bool hasDeck;
        private int memoizedSerializedSize = -1;

        static GetDeck()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private GetDeck()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GetDeck prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GetDeck deck = obj as GetDeck;
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

        private GetDeck MakeReadOnly()
        {
            return this;
        }

        public static GetDeck ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GetDeck ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetDeck ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GetDeck ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GetDeck ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GetDeck ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GetDeck ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GetDeck ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetDeck ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetDeck ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GetDeck, Builder>.PrintField("deck", this.hasDeck, this.deck_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _getDeckFieldNames;
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

        public static GetDeck DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GetDeck DefaultInstanceForType
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

        protected override GetDeck ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<GetDeck, GetDeck.Builder>
        {
            private GetDeck result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GetDeck.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GetDeck cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override GetDeck BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GetDeck.Builder Clear()
            {
                this.result = GetDeck.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GetDeck.Builder ClearDeck()
            {
                this.PrepareBuilder();
                this.result.hasDeck = false;
                this.result.deck_ = 0L;
                return this;
            }

            public override GetDeck.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GetDeck.Builder(this.result);
                }
                return new GetDeck.Builder().MergeFrom(this.result);
            }

            public override GetDeck.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GetDeck.Builder MergeFrom(IMessageLite other)
            {
                if (other is GetDeck)
                {
                    return this.MergeFrom((GetDeck) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GetDeck.Builder MergeFrom(GetDeck other)
            {
                if (other != GetDeck.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasDeck)
                    {
                        this.Deck = other.Deck;
                    }
                }
                return this;
            }

            public override GetDeck.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GetDeck._getDeckFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GetDeck._getDeckFieldTags[index];
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

            private GetDeck PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GetDeck result = this.result;
                    this.result = new GetDeck();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public GetDeck.Builder SetDeck(long value)
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

            public override GetDeck DefaultInstanceForType
            {
                get
                {
                    return GetDeck.DefaultInstance;
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

            protected override GetDeck MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override GetDeck.Builder ThisBuilder
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
                ID = 0xd6,
                System = 0
            }
        }
    }
}

