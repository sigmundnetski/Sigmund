namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class MatchMaker : GeneratedMessageLite<MatchMaker, Builder>
    {
        private static readonly string[] _matchMakerFieldNames = new string[] { "debug_name", "deck" };
        private static readonly uint[] _matchMakerFieldTags = new uint[] { 0x12, 8 };
        private string debugName_ = string.Empty;
        public const int DebugNameFieldNumber = 2;
        private long deck_;
        public const int DeckFieldNumber = 1;
        private static readonly MatchMaker defaultInstance = new MatchMaker().MakeReadOnly();
        private bool hasDebugName;
        private bool hasDeck;
        private int memoizedSerializedSize = -1;

        static MatchMaker()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private MatchMaker()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(MatchMaker prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            MatchMaker maker = obj as MatchMaker;
            if (maker == null)
            {
                return false;
            }
            if ((this.hasDeck != maker.hasDeck) || (this.hasDeck && !this.deck_.Equals(maker.deck_)))
            {
                return false;
            }
            return ((this.hasDebugName == maker.hasDebugName) && (!this.hasDebugName || this.debugName_.Equals(maker.debugName_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasDeck)
            {
                hashCode ^= this.deck_.GetHashCode();
            }
            if (this.hasDebugName)
            {
                hashCode ^= this.debugName_.GetHashCode();
            }
            return hashCode;
        }

        private MatchMaker MakeReadOnly()
        {
            return this;
        }

        public static MatchMaker ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static MatchMaker ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static MatchMaker ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static MatchMaker ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static MatchMaker ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static MatchMaker ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static MatchMaker ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static MatchMaker ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static MatchMaker ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static MatchMaker ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<MatchMaker, Builder>.PrintField("deck", this.hasDeck, this.deck_, writer);
            GeneratedMessageLite<MatchMaker, Builder>.PrintField("debug_name", this.hasDebugName, this.debugName_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _matchMakerFieldNames;
            if (this.hasDeck)
            {
                output.WriteInt64(1, strArray[1], this.Deck);
            }
            if (this.hasDebugName)
            {
                output.WriteString(2, strArray[0], this.DebugName);
            }
        }

        public string DebugName
        {
            get
            {
                return this.debugName_;
            }
        }

        public long Deck
        {
            get
            {
                return this.deck_;
            }
        }

        public static MatchMaker DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override MatchMaker DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasDebugName
        {
            get
            {
                return this.hasDebugName;
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
                if (!this.hasDebugName)
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
                    if (this.hasDebugName)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(2, this.DebugName);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override MatchMaker ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<MatchMaker, MatchMaker.Builder>
        {
            private MatchMaker result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = MatchMaker.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(MatchMaker cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override MatchMaker BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override MatchMaker.Builder Clear()
            {
                this.result = MatchMaker.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public MatchMaker.Builder ClearDebugName()
            {
                this.PrepareBuilder();
                this.result.hasDebugName = false;
                this.result.debugName_ = string.Empty;
                return this;
            }

            public MatchMaker.Builder ClearDeck()
            {
                this.PrepareBuilder();
                this.result.hasDeck = false;
                this.result.deck_ = 0L;
                return this;
            }

            public override MatchMaker.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new MatchMaker.Builder(this.result);
                }
                return new MatchMaker.Builder().MergeFrom(this.result);
            }

            public override MatchMaker.Builder MergeFrom(MatchMaker other)
            {
                if (other != MatchMaker.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasDeck)
                    {
                        this.Deck = other.Deck;
                    }
                    if (other.HasDebugName)
                    {
                        this.DebugName = other.DebugName;
                    }
                }
                return this;
            }

            public override MatchMaker.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override MatchMaker.Builder MergeFrom(IMessageLite other)
            {
                if (other is MatchMaker)
                {
                    return this.MergeFrom((MatchMaker) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override MatchMaker.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(MatchMaker._matchMakerFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = MatchMaker._matchMakerFieldTags[index];
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
                    this.result.hasDebugName = input.ReadString(ref this.result.debugName_);
                }
                return this;
            }

            private MatchMaker PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    MatchMaker result = this.result;
                    this.result = new MatchMaker();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public MatchMaker.Builder SetDebugName(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasDebugName = true;
                this.result.debugName_ = value;
                return this;
            }

            public MatchMaker.Builder SetDeck(long value)
            {
                this.PrepareBuilder();
                this.result.hasDeck = true;
                this.result.deck_ = value;
                return this;
            }

            public string DebugName
            {
                get
                {
                    return this.result.DebugName;
                }
                set
                {
                    this.SetDebugName(value);
                }
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

            public override MatchMaker DefaultInstanceForType
            {
                get
                {
                    return MatchMaker.DefaultInstance;
                }
            }

            public bool HasDebugName
            {
                get
                {
                    return this.result.hasDebugName;
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

            protected override MatchMaker MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override MatchMaker.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0x9c
            }
        }
    }
}

