namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using PegasusShared;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class AtlasGetCardDetails : GeneratedMessageLite<AtlasGetCardDetails, Builder>
    {
        private static readonly string[] _atlasGetCardDetailsFieldNames = new string[] { "account_id", "card_def" };
        private static readonly uint[] _atlasGetCardDetailsFieldTags = new uint[] { 8, 0x12 };
        private ulong accountId_;
        public const int AccountIdFieldNumber = 1;
        private PegasusShared.CardDef cardDef_;
        public const int CardDefFieldNumber = 2;
        private static readonly AtlasGetCardDetails defaultInstance = new AtlasGetCardDetails().MakeReadOnly();
        private bool hasAccountId;
        private bool hasCardDef;
        private int memoizedSerializedSize = -1;

        static AtlasGetCardDetails()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AtlasGetCardDetails()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AtlasGetCardDetails prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AtlasGetCardDetails details = obj as AtlasGetCardDetails;
            if (details == null)
            {
                return false;
            }
            if ((this.hasAccountId != details.hasAccountId) || (this.hasAccountId && !this.accountId_.Equals(details.accountId_)))
            {
                return false;
            }
            return ((this.hasCardDef == details.hasCardDef) && (!this.hasCardDef || this.cardDef_.Equals(details.cardDef_)));
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
            return hashCode;
        }

        private AtlasGetCardDetails MakeReadOnly()
        {
            return this;
        }

        public static AtlasGetCardDetails ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AtlasGetCardDetails ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasGetCardDetails ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasGetCardDetails ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasGetCardDetails ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasGetCardDetails ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasGetCardDetails ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AtlasGetCardDetails ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasGetCardDetails ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasGetCardDetails ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AtlasGetCardDetails, Builder>.PrintField("account_id", this.hasAccountId, this.accountId_, writer);
            GeneratedMessageLite<AtlasGetCardDetails, Builder>.PrintField("card_def", this.hasCardDef, this.cardDef_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _atlasGetCardDetailsFieldNames;
            if (this.hasAccountId)
            {
                output.WriteUInt64(1, strArray[0], this.AccountId);
            }
            if (this.hasCardDef)
            {
                output.WriteMessage(2, strArray[1], this.CardDef);
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

        public static AtlasGetCardDetails DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AtlasGetCardDetails DefaultInstanceForType
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
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override AtlasGetCardDetails ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<AtlasGetCardDetails, AtlasGetCardDetails.Builder>
        {
            private AtlasGetCardDetails result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AtlasGetCardDetails.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AtlasGetCardDetails cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override AtlasGetCardDetails BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AtlasGetCardDetails.Builder Clear()
            {
                this.result = AtlasGetCardDetails.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AtlasGetCardDetails.Builder ClearAccountId()
            {
                this.PrepareBuilder();
                this.result.hasAccountId = false;
                this.result.accountId_ = 0L;
                return this;
            }

            public AtlasGetCardDetails.Builder ClearCardDef()
            {
                this.PrepareBuilder();
                this.result.hasCardDef = false;
                this.result.cardDef_ = null;
                return this;
            }

            public override AtlasGetCardDetails.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AtlasGetCardDetails.Builder(this.result);
                }
                return new AtlasGetCardDetails.Builder().MergeFrom(this.result);
            }

            public AtlasGetCardDetails.Builder MergeCardDef(PegasusShared.CardDef value)
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

            public override AtlasGetCardDetails.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AtlasGetCardDetails.Builder MergeFrom(IMessageLite other)
            {
                if (other is AtlasGetCardDetails)
                {
                    return this.MergeFrom((AtlasGetCardDetails) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AtlasGetCardDetails.Builder MergeFrom(AtlasGetCardDetails other)
            {
                if (other != AtlasGetCardDetails.DefaultInstance)
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
                }
                return this;
            }

            public override AtlasGetCardDetails.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AtlasGetCardDetails._atlasGetCardDetailsFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AtlasGetCardDetails._atlasGetCardDetailsFieldTags[index];
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
                    }
                    if (WireFormat.IsEndGroupTag(num))
                    {
                        return this;
                    }
                    this.ParseUnknownField(input, extensionRegistry, num, str);
                }
                return this;
            }

            private AtlasGetCardDetails PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AtlasGetCardDetails result = this.result;
                    this.result = new AtlasGetCardDetails();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public AtlasGetCardDetails.Builder SetAccountId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasAccountId = true;
                this.result.accountId_ = value;
                return this;
            }

            public AtlasGetCardDetails.Builder SetCardDef(PegasusShared.CardDef value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasCardDef = true;
                this.result.cardDef_ = value;
                return this;
            }

            public AtlasGetCardDetails.Builder SetCardDef(PegasusShared.CardDef.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasCardDef = true;
                this.result.cardDef_ = builderForValue.Build();
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

            public override AtlasGetCardDetails DefaultInstanceForType
            {
                get
                {
                    return AtlasGetCardDetails.DefaultInstance;
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

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override AtlasGetCardDetails MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override AtlasGetCardDetails.Builder ThisBuilder
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
                ID = 0x193
            }
        }
    }
}

