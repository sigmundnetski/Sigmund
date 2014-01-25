namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class AtlasDeck : GeneratedMessageLite<AtlasDeck, Builder>
    {
        private static readonly string[] _atlasDeckFieldNames = new string[] { "cards", "header" };
        private static readonly uint[] _atlasDeckFieldTags = new uint[] { 0x12, 10 };
        private PopsicleList<AtlasDeckCard> cards_ = new PopsicleList<AtlasDeckCard>();
        public const int CardsFieldNumber = 2;
        private static readonly AtlasDeck defaultInstance = new AtlasDeck().MakeReadOnly();
        private bool hasHeader;
        private DeckInfo header_;
        public const int HeaderFieldNumber = 1;
        private int memoizedSerializedSize = -1;

        static AtlasDeck()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AtlasDeck()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AtlasDeck prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AtlasDeck deck = obj as AtlasDeck;
            if (deck == null)
            {
                return false;
            }
            if ((this.hasHeader != deck.hasHeader) || (this.hasHeader && !this.header_.Equals(deck.header_)))
            {
                return false;
            }
            if (this.cards_.Count != deck.cards_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.cards_.Count; i++)
            {
                if (!this.cards_[i].Equals(deck.cards_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public AtlasDeckCard GetCards(int index)
        {
            return this.cards_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasHeader)
            {
                hashCode ^= this.header_.GetHashCode();
            }
            IEnumerator<AtlasDeckCard> enumerator = this.cards_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    AtlasDeckCard current = enumerator.Current;
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

        private AtlasDeck MakeReadOnly()
        {
            this.cards_.MakeReadOnly();
            return this;
        }

        public static AtlasDeck ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AtlasDeck ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasDeck ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasDeck ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasDeck ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasDeck ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasDeck ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AtlasDeck ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasDeck ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasDeck ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AtlasDeck, Builder>.PrintField("header", this.hasHeader, this.header_, writer);
            GeneratedMessageLite<AtlasDeck, Builder>.PrintField<AtlasDeckCard>("cards", this.cards_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _atlasDeckFieldNames;
            if (this.hasHeader)
            {
                output.WriteMessage(1, strArray[1], this.Header);
            }
            if (this.cards_.Count > 0)
            {
                output.WriteMessageArray<AtlasDeckCard>(2, strArray[0], this.cards_);
            }
        }

        public int CardsCount
        {
            get
            {
                return this.cards_.Count;
            }
        }

        public IList<AtlasDeckCard> CardsList
        {
            get
            {
                return this.cards_;
            }
        }

        public static AtlasDeck DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AtlasDeck DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasHeader
        {
            get
            {
                return this.hasHeader;
            }
        }

        public DeckInfo Header
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.header_ != null)
                {
                    goto Label_0012;
                }
                return DeckInfo.DefaultInstance;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasHeader)
                {
                    return false;
                }
                if (!this.Header.IsInitialized)
                {
                    return false;
                }
                IEnumerator<AtlasDeckCard> enumerator = this.CardsList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        AtlasDeckCard current = enumerator.Current;
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
                    if (this.hasHeader)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.Header);
                    }
                    IEnumerator<AtlasDeckCard> enumerator = this.CardsList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            AtlasDeckCard current = enumerator.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, current);
                        }
                    }
                    finally
                    {
                        if (enumerator == null)
                        {
                        }
                        enumerator.Dispose();
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override AtlasDeck ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<AtlasDeck, AtlasDeck.Builder>
        {
            private AtlasDeck result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AtlasDeck.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AtlasDeck cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public AtlasDeck.Builder AddCards(AtlasDeckCard value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.cards_.Add(value);
                return this;
            }

            public AtlasDeck.Builder AddCards(AtlasDeckCard.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.cards_.Add(builderForValue.Build());
                return this;
            }

            public AtlasDeck.Builder AddRangeCards(IEnumerable<AtlasDeckCard> values)
            {
                this.PrepareBuilder();
                this.result.cards_.Add(values);
                return this;
            }

            public override AtlasDeck BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AtlasDeck.Builder Clear()
            {
                this.result = AtlasDeck.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AtlasDeck.Builder ClearCards()
            {
                this.PrepareBuilder();
                this.result.cards_.Clear();
                return this;
            }

            public AtlasDeck.Builder ClearHeader()
            {
                this.PrepareBuilder();
                this.result.hasHeader = false;
                this.result.header_ = null;
                return this;
            }

            public override AtlasDeck.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AtlasDeck.Builder(this.result);
                }
                return new AtlasDeck.Builder().MergeFrom(this.result);
            }

            public AtlasDeckCard GetCards(int index)
            {
                return this.result.GetCards(index);
            }

            public override AtlasDeck.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AtlasDeck.Builder MergeFrom(IMessageLite other)
            {
                if (other is AtlasDeck)
                {
                    return this.MergeFrom((AtlasDeck) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AtlasDeck.Builder MergeFrom(AtlasDeck other)
            {
                if (other != AtlasDeck.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasHeader)
                    {
                        this.MergeHeader(other.Header);
                    }
                    if (other.cards_.Count != 0)
                    {
                        this.result.cards_.Add(other.cards_);
                    }
                }
                return this;
            }

            public override AtlasDeck.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AtlasDeck._atlasDeckFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AtlasDeck._atlasDeckFieldTags[index];
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
                            DeckInfo.Builder builder = DeckInfo.CreateBuilder();
                            if (this.result.hasHeader)
                            {
                                builder.MergeFrom(this.Header);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.Header = builder.BuildPartial();
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
                    input.ReadMessageArray<AtlasDeckCard>(num, str, this.result.cards_, AtlasDeckCard.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            public AtlasDeck.Builder MergeHeader(DeckInfo value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasHeader && (this.result.header_ != DeckInfo.DefaultInstance))
                {
                    this.result.header_ = DeckInfo.CreateBuilder(this.result.header_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.header_ = value;
                }
                this.result.hasHeader = true;
                return this;
            }

            private AtlasDeck PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AtlasDeck result = this.result;
                    this.result = new AtlasDeck();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public AtlasDeck.Builder SetCards(int index, AtlasDeckCard value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.cards_[index] = value;
                return this;
            }

            public AtlasDeck.Builder SetCards(int index, AtlasDeckCard.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.cards_[index] = builderForValue.Build();
                return this;
            }

            public AtlasDeck.Builder SetHeader(DeckInfo value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasHeader = true;
                this.result.header_ = value;
                return this;
            }

            public AtlasDeck.Builder SetHeader(DeckInfo.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasHeader = true;
                this.result.header_ = builderForValue.Build();
                return this;
            }

            public int CardsCount
            {
                get
                {
                    return this.result.CardsCount;
                }
            }

            public IPopsicleList<AtlasDeckCard> CardsList
            {
                get
                {
                    return this.PrepareBuilder().cards_;
                }
            }

            public override AtlasDeck DefaultInstanceForType
            {
                get
                {
                    return AtlasDeck.DefaultInstance;
                }
            }

            public bool HasHeader
            {
                get
                {
                    return this.result.hasHeader;
                }
            }

            public DeckInfo Header
            {
                get
                {
                    return this.result.Header;
                }
                set
                {
                    this.SetHeader(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override AtlasDeck MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override AtlasDeck.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

