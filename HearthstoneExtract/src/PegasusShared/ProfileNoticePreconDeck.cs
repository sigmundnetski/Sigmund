namespace PegasusShared
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class ProfileNoticePreconDeck : GeneratedMessageLite<ProfileNoticePreconDeck, Builder>
    {
        private static readonly string[] _profileNoticePreconDeckFieldNames = new string[] { "deck", "hero" };
        private static readonly uint[] _profileNoticePreconDeckFieldTags = new uint[] { 8, 0x10 };
        private long deck_;
        public const int DeckFieldNumber = 1;
        private static readonly ProfileNoticePreconDeck defaultInstance = new ProfileNoticePreconDeck().MakeReadOnly();
        private bool hasDeck;
        private bool hasHero;
        private int hero_;
        public const int HeroFieldNumber = 2;
        private int memoizedSerializedSize = -1;

        static ProfileNoticePreconDeck()
        {
            object.ReferenceEquals(PegasusSharedlite.Descriptor, null);
        }

        private ProfileNoticePreconDeck()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ProfileNoticePreconDeck prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ProfileNoticePreconDeck deck = obj as ProfileNoticePreconDeck;
            if (deck == null)
            {
                return false;
            }
            if ((this.hasDeck != deck.hasDeck) || (this.hasDeck && !this.deck_.Equals(deck.deck_)))
            {
                return false;
            }
            return ((this.hasHero == deck.hasHero) && (!this.hasHero || this.hero_.Equals(deck.hero_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasDeck)
            {
                hashCode ^= this.deck_.GetHashCode();
            }
            if (this.hasHero)
            {
                hashCode ^= this.hero_.GetHashCode();
            }
            return hashCode;
        }

        private ProfileNoticePreconDeck MakeReadOnly()
        {
            return this;
        }

        public static ProfileNoticePreconDeck ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ProfileNoticePreconDeck ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileNoticePreconDeck ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ProfileNoticePreconDeck ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ProfileNoticePreconDeck ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ProfileNoticePreconDeck ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ProfileNoticePreconDeck ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ProfileNoticePreconDeck ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileNoticePreconDeck ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileNoticePreconDeck ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ProfileNoticePreconDeck, Builder>.PrintField("deck", this.hasDeck, this.deck_, writer);
            GeneratedMessageLite<ProfileNoticePreconDeck, Builder>.PrintField("hero", this.hasHero, this.hero_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _profileNoticePreconDeckFieldNames;
            if (this.hasDeck)
            {
                output.WriteInt64(1, strArray[0], this.Deck);
            }
            if (this.hasHero)
            {
                output.WriteInt32(2, strArray[1], this.Hero);
            }
        }

        public long Deck
        {
            get
            {
                return this.deck_;
            }
        }

        public static ProfileNoticePreconDeck DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ProfileNoticePreconDeck DefaultInstanceForType
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

        public bool HasHero
        {
            get
            {
                return this.hasHero;
            }
        }

        public int Hero
        {
            get
            {
                return this.hero_;
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
                if (!this.hasHero)
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
                    if (this.hasHero)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.Hero);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ProfileNoticePreconDeck ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<ProfileNoticePreconDeck, ProfileNoticePreconDeck.Builder>
        {
            private ProfileNoticePreconDeck result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ProfileNoticePreconDeck.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ProfileNoticePreconDeck cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override ProfileNoticePreconDeck BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ProfileNoticePreconDeck.Builder Clear()
            {
                this.result = ProfileNoticePreconDeck.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ProfileNoticePreconDeck.Builder ClearDeck()
            {
                this.PrepareBuilder();
                this.result.hasDeck = false;
                this.result.deck_ = 0L;
                return this;
            }

            public ProfileNoticePreconDeck.Builder ClearHero()
            {
                this.PrepareBuilder();
                this.result.hasHero = false;
                this.result.hero_ = 0;
                return this;
            }

            public override ProfileNoticePreconDeck.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ProfileNoticePreconDeck.Builder(this.result);
                }
                return new ProfileNoticePreconDeck.Builder().MergeFrom(this.result);
            }

            public override ProfileNoticePreconDeck.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ProfileNoticePreconDeck.Builder MergeFrom(IMessageLite other)
            {
                if (other is ProfileNoticePreconDeck)
                {
                    return this.MergeFrom((ProfileNoticePreconDeck) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ProfileNoticePreconDeck.Builder MergeFrom(ProfileNoticePreconDeck other)
            {
                if (other != ProfileNoticePreconDeck.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasDeck)
                    {
                        this.Deck = other.Deck;
                    }
                    if (other.HasHero)
                    {
                        this.Hero = other.Hero;
                    }
                }
                return this;
            }

            public override ProfileNoticePreconDeck.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ProfileNoticePreconDeck._profileNoticePreconDeckFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ProfileNoticePreconDeck._profileNoticePreconDeckFieldTags[index];
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
                    this.result.hasHero = input.ReadInt32(ref this.result.hero_);
                }
                return this;
            }

            private ProfileNoticePreconDeck PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ProfileNoticePreconDeck result = this.result;
                    this.result = new ProfileNoticePreconDeck();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ProfileNoticePreconDeck.Builder SetDeck(long value)
            {
                this.PrepareBuilder();
                this.result.hasDeck = true;
                this.result.deck_ = value;
                return this;
            }

            public ProfileNoticePreconDeck.Builder SetHero(int value)
            {
                this.PrepareBuilder();
                this.result.hasHero = true;
                this.result.hero_ = value;
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

            public override ProfileNoticePreconDeck DefaultInstanceForType
            {
                get
                {
                    return ProfileNoticePreconDeck.DefaultInstance;
                }
            }

            public bool HasDeck
            {
                get
                {
                    return this.result.hasDeck;
                }
            }

            public bool HasHero
            {
                get
                {
                    return this.result.hasHero;
                }
            }

            public int Hero
            {
                get
                {
                    return this.result.Hero;
                }
                set
                {
                    this.SetHero(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override ProfileNoticePreconDeck MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override ProfileNoticePreconDeck.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum NoticeID
            {
                ID = 5
            }
        }
    }
}

