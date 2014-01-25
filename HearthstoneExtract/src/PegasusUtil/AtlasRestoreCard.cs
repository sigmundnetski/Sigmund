namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class AtlasRestoreCard : GeneratedMessageLite<AtlasRestoreCard, Builder>
    {
        private static readonly string[] _atlasRestoreCardFieldNames = new string[] { "account_id", "card_id" };
        private static readonly uint[] _atlasRestoreCardFieldTags = new uint[] { 8, 0x10 };
        private ulong accountId_;
        public const int AccountIdFieldNumber = 1;
        private ulong cardId_;
        public const int CardIdFieldNumber = 2;
        private static readonly AtlasRestoreCard defaultInstance = new AtlasRestoreCard().MakeReadOnly();
        private bool hasAccountId;
        private bool hasCardId;
        private int memoizedSerializedSize = -1;

        static AtlasRestoreCard()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AtlasRestoreCard()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AtlasRestoreCard prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AtlasRestoreCard card = obj as AtlasRestoreCard;
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

        private AtlasRestoreCard MakeReadOnly()
        {
            return this;
        }

        public static AtlasRestoreCard ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AtlasRestoreCard ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasRestoreCard ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasRestoreCard ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasRestoreCard ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasRestoreCard ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasRestoreCard ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AtlasRestoreCard ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasRestoreCard ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasRestoreCard ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AtlasRestoreCard, Builder>.PrintField("account_id", this.hasAccountId, this.accountId_, writer);
            GeneratedMessageLite<AtlasRestoreCard, Builder>.PrintField("card_id", this.hasCardId, this.cardId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _atlasRestoreCardFieldNames;
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

        public static AtlasRestoreCard DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AtlasRestoreCard DefaultInstanceForType
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

        protected override AtlasRestoreCard ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<AtlasRestoreCard, AtlasRestoreCard.Builder>
        {
            private AtlasRestoreCard result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AtlasRestoreCard.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AtlasRestoreCard cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override AtlasRestoreCard BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AtlasRestoreCard.Builder Clear()
            {
                this.result = AtlasRestoreCard.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AtlasRestoreCard.Builder ClearAccountId()
            {
                this.PrepareBuilder();
                this.result.hasAccountId = false;
                this.result.accountId_ = 0L;
                return this;
            }

            public AtlasRestoreCard.Builder ClearCardId()
            {
                this.PrepareBuilder();
                this.result.hasCardId = false;
                this.result.cardId_ = 0L;
                return this;
            }

            public override AtlasRestoreCard.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AtlasRestoreCard.Builder(this.result);
                }
                return new AtlasRestoreCard.Builder().MergeFrom(this.result);
            }

            public override AtlasRestoreCard.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AtlasRestoreCard.Builder MergeFrom(IMessageLite other)
            {
                if (other is AtlasRestoreCard)
                {
                    return this.MergeFrom((AtlasRestoreCard) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AtlasRestoreCard.Builder MergeFrom(AtlasRestoreCard other)
            {
                if (other != AtlasRestoreCard.DefaultInstance)
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

            public override AtlasRestoreCard.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AtlasRestoreCard._atlasRestoreCardFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AtlasRestoreCard._atlasRestoreCardFieldTags[index];
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

            private AtlasRestoreCard PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AtlasRestoreCard result = this.result;
                    this.result = new AtlasRestoreCard();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public AtlasRestoreCard.Builder SetAccountId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasAccountId = true;
                this.result.accountId_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public AtlasRestoreCard.Builder SetCardId(ulong value)
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

            public override AtlasRestoreCard DefaultInstanceForType
            {
                get
                {
                    return AtlasRestoreCard.DefaultInstance;
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

            protected override AtlasRestoreCard MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override AtlasRestoreCard.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0x198
            }
        }
    }
}

