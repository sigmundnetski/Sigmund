namespace PegasusShared
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class ProfileNoticeRewardCard : GeneratedMessageLite<ProfileNoticeRewardCard, Builder>
    {
        private static readonly string[] _profileNoticeRewardCardFieldNames = new string[] { "card" };
        private static readonly uint[] _profileNoticeRewardCardFieldTags = new uint[] { 10 };
        private CardDef card_;
        public const int CardFieldNumber = 1;
        private static readonly ProfileNoticeRewardCard defaultInstance = new ProfileNoticeRewardCard().MakeReadOnly();
        private bool hasCard;
        private int memoizedSerializedSize = -1;

        static ProfileNoticeRewardCard()
        {
            object.ReferenceEquals(PegasusSharedlite.Descriptor, null);
        }

        private ProfileNoticeRewardCard()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ProfileNoticeRewardCard prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ProfileNoticeRewardCard card = obj as ProfileNoticeRewardCard;
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

        private ProfileNoticeRewardCard MakeReadOnly()
        {
            return this;
        }

        public static ProfileNoticeRewardCard ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ProfileNoticeRewardCard ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileNoticeRewardCard ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ProfileNoticeRewardCard ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ProfileNoticeRewardCard ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ProfileNoticeRewardCard ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ProfileNoticeRewardCard ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ProfileNoticeRewardCard ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileNoticeRewardCard ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileNoticeRewardCard ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ProfileNoticeRewardCard, Builder>.PrintField("card", this.hasCard, this.card_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _profileNoticeRewardCardFieldNames;
            if (this.hasCard)
            {
                output.WriteMessage(1, strArray[0], this.Card);
            }
        }

        public CardDef Card
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.card_ != null)
                {
                    goto Label_0012;
                }
                return CardDef.DefaultInstance;
            }
        }

        public static ProfileNoticeRewardCard DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ProfileNoticeRewardCard DefaultInstanceForType
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
                if (!this.Card.IsInitialized)
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
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.Card);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ProfileNoticeRewardCard ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<ProfileNoticeRewardCard, ProfileNoticeRewardCard.Builder>
        {
            private ProfileNoticeRewardCard result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ProfileNoticeRewardCard.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ProfileNoticeRewardCard cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override ProfileNoticeRewardCard BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ProfileNoticeRewardCard.Builder Clear()
            {
                this.result = ProfileNoticeRewardCard.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ProfileNoticeRewardCard.Builder ClearCard()
            {
                this.PrepareBuilder();
                this.result.hasCard = false;
                this.result.card_ = null;
                return this;
            }

            public override ProfileNoticeRewardCard.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ProfileNoticeRewardCard.Builder(this.result);
                }
                return new ProfileNoticeRewardCard.Builder().MergeFrom(this.result);
            }

            public ProfileNoticeRewardCard.Builder MergeCard(CardDef value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasCard && (this.result.card_ != CardDef.DefaultInstance))
                {
                    this.result.card_ = CardDef.CreateBuilder(this.result.card_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.card_ = value;
                }
                this.result.hasCard = true;
                return this;
            }

            public override ProfileNoticeRewardCard.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ProfileNoticeRewardCard.Builder MergeFrom(IMessageLite other)
            {
                if (other is ProfileNoticeRewardCard)
                {
                    return this.MergeFrom((ProfileNoticeRewardCard) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ProfileNoticeRewardCard.Builder MergeFrom(ProfileNoticeRewardCard other)
            {
                if (other != ProfileNoticeRewardCard.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasCard)
                    {
                        this.MergeCard(other.Card);
                    }
                }
                return this;
            }

            public override ProfileNoticeRewardCard.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ProfileNoticeRewardCard._profileNoticeRewardCardFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ProfileNoticeRewardCard._profileNoticeRewardCardFieldTags[index];
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
                            CardDef.Builder builder = CardDef.CreateBuilder();
                            if (this.result.hasCard)
                            {
                                builder.MergeFrom(this.Card);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.Card = builder.BuildPartial();
                            continue;
                        }
                    }
                    if (WireFormat.IsEndGroupTag(num))
                    {
                        return this;
                    }
                    this.ParseUnknownField(input, extensionRegistry, num, str);
                }
                return this;
            }

            private ProfileNoticeRewardCard PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ProfileNoticeRewardCard result = this.result;
                    this.result = new ProfileNoticeRewardCard();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ProfileNoticeRewardCard.Builder SetCard(CardDef value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasCard = true;
                this.result.card_ = value;
                return this;
            }

            public ProfileNoticeRewardCard.Builder SetCard(CardDef.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasCard = true;
                this.result.card_ = builderForValue.Build();
                return this;
            }

            public CardDef Card
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

            public override ProfileNoticeRewardCard DefaultInstanceForType
            {
                get
                {
                    return ProfileNoticeRewardCard.DefaultInstance;
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

            protected override ProfileNoticeRewardCard MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override ProfileNoticeRewardCard.Builder ThisBuilder
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
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum NoticeID
            {
                ID = 3
            }
        }
    }
}

