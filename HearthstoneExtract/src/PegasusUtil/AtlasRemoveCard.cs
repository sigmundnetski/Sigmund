namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class AtlasRemoveCard : GeneratedMessageLite<AtlasRemoveCard, Builder>
    {
        private static readonly string[] _atlasRemoveCardFieldNames = new string[] { "account_id", "card_id" };
        private static readonly uint[] _atlasRemoveCardFieldTags = new uint[] { 8, 0x10 };
        private ulong accountId_;
        public const int AccountIdFieldNumber = 1;
        private ulong cardId_;
        public const int CardIdFieldNumber = 2;
        private static readonly AtlasRemoveCard defaultInstance = new AtlasRemoveCard().MakeReadOnly();
        private bool hasAccountId;
        private bool hasCardId;
        private int memoizedSerializedSize = -1;

        static AtlasRemoveCard()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AtlasRemoveCard()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AtlasRemoveCard prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AtlasRemoveCard card = obj as AtlasRemoveCard;
            if (card == null)
            {
                return false;
            }
            if ((this.hasAccountId != card.hasAccountId) || (this.hasAccountId && !this.accountId_.Equals(card.accountId_)))
            {
                return false;
            }
            return ((this.hasCardId == card.hasCardId) && (!this.hasCardId || this.cardId_.Equals(card.cardId_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasAccountId)
            {
                hashCode ^= this.accountId_.GetHashCode();
            }
            if (this.hasCardId)
            {
                hashCode ^= this.cardId_.GetHashCode();
            }
            return hashCode;
        }

        private AtlasRemoveCard MakeReadOnly()
        {
            return this;
        }

        public static AtlasRemoveCard ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AtlasRemoveCard ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasRemoveCard ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasRemoveCard ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasRemoveCard ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasRemoveCard ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasRemoveCard ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AtlasRemoveCard ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasRemoveCard ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasRemoveCard ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AtlasRemoveCard, Builder>.PrintField("account_id", this.hasAccountId, this.accountId_, writer);
            GeneratedMessageLite<AtlasRemoveCard, Builder>.PrintField("card_id", this.hasCardId, this.cardId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _atlasRemoveCardFieldNames;
            if (this.hasAccountId)
            {
                output.WriteUInt64(1, strArray[0], this.AccountId);
            }
            if (this.hasCardId)
            {
                output.WriteUInt64(2, strArray[1], this.CardId);
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

        [CLSCompliant(false)]
        public ulong CardId
        {
            get
            {
                return this.cardId_;
            }
        }

        public static AtlasRemoveCard DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AtlasRemoveCard DefaultInstanceForType
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

        public bool HasCardId
        {
            get
            {
                return this.hasCardId;
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
                if (!this.hasCardId)
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
                    if (this.hasAccountId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(1, this.AccountId);
                    }
                    if (this.hasCardId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(2, this.CardId);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override AtlasRemoveCard ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<AtlasRemoveCard, AtlasRemoveCard.Builder>
        {
            private AtlasRemoveCard result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AtlasRemoveCard.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AtlasRemoveCard cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override AtlasRemoveCard BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AtlasRemoveCard.Builder Clear()
            {
                this.result = AtlasRemoveCard.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AtlasRemoveCard.Builder ClearAccountId()
            {
                this.PrepareBuilder();
                this.result.hasAccountId = false;
                this.result.accountId_ = 0L;
                return this;
            }

            public AtlasRemoveCard.Builder ClearCardId()
            {
                this.PrepareBuilder();
                this.result.hasCardId = false;
                this.result.cardId_ = 0L;
                return this;
            }

            public override AtlasRemoveCard.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AtlasRemoveCard.Builder(this.result);
                }
                return new AtlasRemoveCard.Builder().MergeFrom(this.result);
            }

            public override AtlasRemoveCard.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AtlasRemoveCard.Builder MergeFrom(IMessageLite other)
            {
                if (other is AtlasRemoveCard)
                {
                    return this.MergeFrom((AtlasRemoveCard) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AtlasRemoveCard.Builder MergeFrom(AtlasRemoveCard other)
            {
                if (other != AtlasRemoveCard.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAccountId)
                    {
                        this.AccountId = other.AccountId;
                    }
                    if (other.HasCardId)
                    {
                        this.CardId = other.CardId;
                    }
                }
                return this;
            }

            public override AtlasRemoveCard.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AtlasRemoveCard._atlasRemoveCardFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AtlasRemoveCard._atlasRemoveCardFieldTags[index];
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
                    this.result.hasCardId = input.ReadUInt64(ref this.result.cardId_);
                }
                return this;
            }

            private AtlasRemoveCard PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AtlasRemoveCard result = this.result;
                    this.result = new AtlasRemoveCard();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public AtlasRemoveCard.Builder SetAccountId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasAccountId = true;
                this.result.accountId_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public AtlasRemoveCard.Builder SetCardId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasCardId = true;
                this.result.cardId_ = value;
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

            [CLSCompliant(false)]
            public ulong CardId
            {
                get
                {
                    return this.result.CardId;
                }
                set
                {
                    this.SetCardId(value);
                }
            }

            public override AtlasRemoveCard DefaultInstanceForType
            {
                get
                {
                    return AtlasRemoveCard.DefaultInstance;
                }
            }

            public bool HasAccountId
            {
                get
                {
                    return this.result.hasAccountId;
                }
            }

            public bool HasCardId
            {
                get
                {
                    return this.result.hasCardId;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override AtlasRemoveCard MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override AtlasRemoveCard.Builder ThisBuilder
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
                ID = 0x196
            }
        }
    }
}

