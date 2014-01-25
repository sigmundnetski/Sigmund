namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using PegasusShared;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class AtlasAddCard : GeneratedMessageLite<AtlasAddCard, Builder>
    {
        private static readonly string[] _atlasAddCardFieldNames = new string[] { "account_id", "card_def", "is_seen" };
        private static readonly uint[] _atlasAddCardFieldTags = new uint[] { 8, 0x12, 0x18 };
        private ulong accountId_;
        public const int AccountIdFieldNumber = 1;
        private PegasusShared.CardDef cardDef_;
        public const int CardDefFieldNumber = 2;
        private static readonly AtlasAddCard defaultInstance = new AtlasAddCard().MakeReadOnly();
        private bool hasAccountId;
        private bool hasCardDef;
        private bool hasIsSeen;
        private bool isSeen_;
        public const int IsSeenFieldNumber = 3;
        private int memoizedSerializedSize = -1;

        static AtlasAddCard()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AtlasAddCard()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AtlasAddCard prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AtlasAddCard card = obj as AtlasAddCard;
            if (card == null)
            {
                return false;
            }
            if ((this.hasAccountId != card.hasAccountId) || (this.hasAccountId && !this.accountId_.Equals(card.accountId_)))
            {
                return false;
            }
            if ((this.hasCardDef != card.hasCardDef) || (this.hasCardDef && !this.cardDef_.Equals(card.cardDef_)))
            {
                return false;
            }
            return ((this.hasIsSeen == card.hasIsSeen) && (!this.hasIsSeen || this.isSeen_.Equals(card.isSeen_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasAccountId)
            {
                hashCode ^= this.accountId_.GetHashCode();
            }
            if (this.hasCardDef)
            {
                hashCode ^= this.cardDef_.GetHashCode();
            }
            if (this.hasIsSeen)
            {
                hashCode ^= this.isSeen_.GetHashCode();
            }
            return hashCode;
        }

        private AtlasAddCard MakeReadOnly()
        {
            return this;
        }

        public static AtlasAddCard ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AtlasAddCard ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasAddCard ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasAddCard ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasAddCard ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasAddCard ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasAddCard ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AtlasAddCard ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasAddCard ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasAddCard ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AtlasAddCard, Builder>.PrintField("account_id", this.hasAccountId, this.accountId_, writer);
            GeneratedMessageLite<AtlasAddCard, Builder>.PrintField("card_def", this.hasCardDef, this.cardDef_, writer);
            GeneratedMessageLite<AtlasAddCard, Builder>.PrintField("is_seen", this.hasIsSeen, this.isSeen_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _atlasAddCardFieldNames;
            if (this.hasAccountId)
            {
                output.WriteUInt64(1, strArray[0], this.AccountId);
            }
            if (this.hasCardDef)
            {
                output.WriteMessage(2, strArray[1], this.CardDef);
            }
            if (this.hasIsSeen)
            {
                output.WriteBool(3, strArray[2], this.IsSeen);
            }
        }

        [CLSCompliant(false)]
        public ulong AccountId
        {
            get
            {
                return this.accountId_;
            }
        }

        public PegasusShared.CardDef CardDef
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.cardDef_ != null)
                {
                    goto Label_0012;
                }
                return PegasusShared.CardDef.DefaultInstance;
            }
        }

        public static AtlasAddCard DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AtlasAddCard DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasAccountId
        {
            get
            {
                return this.hasAccountId;
            }
        }

        public bool HasCardDef
        {
            get
            {
                return this.hasCardDef;
            }
        }

        public bool HasIsSeen
        {
            get
            {
                return this.hasIsSeen;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasAccountId)
                {
                    return false;
                }
                if (!this.hasCardDef)
                {
                    return false;
                }
                if (!this.CardDef.IsInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        public bool IsSeen
        {
            get
            {
                return this.isSeen_;
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
                    if (this.hasAccountId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(1, this.AccountId);
                    }
                    if (this.hasCardDef)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, this.CardDef);
                    }
                    if (this.hasIsSeen)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(3, this.IsSeen);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override AtlasAddCard ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<AtlasAddCard, AtlasAddCard.Builder>
        {
            private AtlasAddCard result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AtlasAddCard.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AtlasAddCard cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override AtlasAddCard BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AtlasAddCard.Builder Clear()
            {
                this.result = AtlasAddCard.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AtlasAddCard.Builder ClearAccountId()
            {
                this.PrepareBuilder();
                this.result.hasAccountId = false;
                this.result.accountId_ = 0L;
                return this;
            }

            public AtlasAddCard.Builder ClearCardDef()
            {
                this.PrepareBuilder();
                this.result.hasCardDef = false;
                this.result.cardDef_ = null;
                return this;
            }

            public AtlasAddCard.Builder ClearIsSeen()
            {
                this.PrepareBuilder();
                this.result.hasIsSeen = false;
                this.result.isSeen_ = false;
                return this;
            }

            public override AtlasAddCard.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AtlasAddCard.Builder(this.result);
                }
                return new AtlasAddCard.Builder().MergeFrom(this.result);
            }

            public AtlasAddCard.Builder MergeCardDef(PegasusShared.CardDef value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasCardDef && (this.result.cardDef_ != PegasusShared.CardDef.DefaultInstance))
                {
                    this.result.cardDef_ = PegasusShared.CardDef.CreateBuilder(this.result.cardDef_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.cardDef_ = value;
                }
                this.result.hasCardDef = true;
                return this;
            }

            public override AtlasAddCard.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AtlasAddCard.Builder MergeFrom(IMessageLite other)
            {
                if (other is AtlasAddCard)
                {
                    return this.MergeFrom((AtlasAddCard) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AtlasAddCard.Builder MergeFrom(AtlasAddCard other)
            {
                if (other != AtlasAddCard.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAccountId)
                    {
                        this.AccountId = other.AccountId;
                    }
                    if (other.HasCardDef)
                    {
                        this.MergeCardDef(other.CardDef);
                    }
                    if (other.HasIsSeen)
                    {
                        this.IsSeen = other.IsSeen;
                    }
                }
                return this;
            }

            public override AtlasAddCard.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AtlasAddCard._atlasAddCardFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AtlasAddCard._atlasAddCardFieldTags[index];
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
                            this.result.hasAccountId = input.ReadUInt64(ref this.result.accountId_);
                            continue;
                        }
                        case 0x12:
                        {
                            PegasusShared.CardDef.Builder builder = PegasusShared.CardDef.CreateBuilder();
                            if (this.result.hasCardDef)
                            {
                                builder.MergeFrom(this.CardDef);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.CardDef = builder.BuildPartial();
                            continue;
                        }
                        case 0x18:
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
                    this.result.hasIsSeen = input.ReadBool(ref this.result.isSeen_);
                }
                return this;
            }

            private AtlasAddCard PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AtlasAddCard result = this.result;
                    this.result = new AtlasAddCard();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public AtlasAddCard.Builder SetAccountId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasAccountId = true;
                this.result.accountId_ = value;
                return this;
            }

            public AtlasAddCard.Builder SetCardDef(PegasusShared.CardDef value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasCardDef = true;
                this.result.cardDef_ = value;
                return this;
            }

            public AtlasAddCard.Builder SetCardDef(PegasusShared.CardDef.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasCardDef = true;
                this.result.cardDef_ = builderForValue.Build();
                return this;
            }

            public AtlasAddCard.Builder SetIsSeen(bool value)
            {
                this.PrepareBuilder();
                this.result.hasIsSeen = true;
                this.result.isSeen_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public ulong AccountId
            {
                get
                {
                    return this.result.AccountId;
                }
                set
                {
                    this.SetAccountId(value);
                }
            }

            public PegasusShared.CardDef CardDef
            {
                get
                {
                    return this.result.CardDef;
                }
                set
                {
                    this.SetCardDef(value);
                }
            }

            public override AtlasAddCard DefaultInstanceForType
            {
                get
                {
                    return AtlasAddCard.DefaultInstance;
                }
            }

            public bool HasAccountId
            {
                get
                {
                    return this.result.hasAccountId;
                }
            }

            public bool HasCardDef
            {
                get
                {
                    return this.result.hasCardDef;
                }
            }

            public bool HasIsSeen
            {
                get
                {
                    return this.result.hasIsSeen;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public bool IsSeen
            {
                get
                {
                    return this.result.IsSeen;
                }
                set
                {
                    this.SetIsSeen(value);
                }
            }

            protected override AtlasAddCard MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override AtlasAddCard.Builder ThisBuilder
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
                ID = 0x195
            }
        }
    }
}

