namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class AtlasChangeCredits : GeneratedMessageLite<AtlasChangeCredits, Builder>
    {
        private static readonly string[] _atlasChangeCreditsFieldNames = new string[] { "account_id", "amount" };
        private static readonly uint[] _atlasChangeCreditsFieldTags = new uint[] { 8, 0x10 };
        private ulong accountId_;
        public const int AccountIdFieldNumber = 1;
        private long amount_;
        public const int AmountFieldNumber = 2;
        private static readonly AtlasChangeCredits defaultInstance = new AtlasChangeCredits().MakeReadOnly();
        private bool hasAccountId;
        private bool hasAmount;
        private int memoizedSerializedSize = -1;

        static AtlasChangeCredits()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AtlasChangeCredits()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AtlasChangeCredits prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AtlasChangeCredits credits = obj as AtlasChangeCredits;
            if (credits == null)
            {
                return false;
            }
            if ((this.hasAccountId != credits.hasAccountId) || (this.hasAccountId && !this.accountId_.Equals(credits.accountId_)))
            {
                return false;
            }
            return ((this.hasAmount == credits.hasAmount) && (!this.hasAmount || this.amount_.Equals(credits.amount_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasAccountId)
            {
                hashCode ^= this.accountId_.GetHashCode();
            }
            if (this.hasAmount)
            {
                hashCode ^= this.amount_.GetHashCode();
            }
            return hashCode;
        }

        private AtlasChangeCredits MakeReadOnly()
        {
            return this;
        }

        public static AtlasChangeCredits ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AtlasChangeCredits ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasChangeCredits ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasChangeCredits ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasChangeCredits ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasChangeCredits ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasChangeCredits ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AtlasChangeCredits ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasChangeCredits ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasChangeCredits ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AtlasChangeCredits, Builder>.PrintField("account_id", this.hasAccountId, this.accountId_, writer);
            GeneratedMessageLite<AtlasChangeCredits, Builder>.PrintField("amount", this.hasAmount, this.amount_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _atlasChangeCreditsFieldNames;
            if (this.hasAccountId)
            {
                output.WriteUInt64(1, strArray[0], this.AccountId);
            }
            if (this.hasAmount)
            {
                output.WriteInt64(2, strArray[1], this.Amount);
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

        public long Amount
        {
            get
            {
                return this.amount_;
            }
        }

        public static AtlasChangeCredits DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AtlasChangeCredits DefaultInstanceForType
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

        public bool HasAmount
        {
            get
            {
                return this.hasAmount;
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
                if (!this.hasAmount)
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
                    if (this.hasAmount)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(2, this.Amount);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override AtlasChangeCredits ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<AtlasChangeCredits, AtlasChangeCredits.Builder>
        {
            private AtlasChangeCredits result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AtlasChangeCredits.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AtlasChangeCredits cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override AtlasChangeCredits BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AtlasChangeCredits.Builder Clear()
            {
                this.result = AtlasChangeCredits.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AtlasChangeCredits.Builder ClearAccountId()
            {
                this.PrepareBuilder();
                this.result.hasAccountId = false;
                this.result.accountId_ = 0L;
                return this;
            }

            public AtlasChangeCredits.Builder ClearAmount()
            {
                this.PrepareBuilder();
                this.result.hasAmount = false;
                this.result.amount_ = 0L;
                return this;
            }

            public override AtlasChangeCredits.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AtlasChangeCredits.Builder(this.result);
                }
                return new AtlasChangeCredits.Builder().MergeFrom(this.result);
            }

            public override AtlasChangeCredits.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AtlasChangeCredits.Builder MergeFrom(IMessageLite other)
            {
                if (other is AtlasChangeCredits)
                {
                    return this.MergeFrom((AtlasChangeCredits) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AtlasChangeCredits.Builder MergeFrom(AtlasChangeCredits other)
            {
                if (other != AtlasChangeCredits.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAccountId)
                    {
                        this.AccountId = other.AccountId;
                    }
                    if (other.HasAmount)
                    {
                        this.Amount = other.Amount;
                    }
                }
                return this;
            }

            public override AtlasChangeCredits.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AtlasChangeCredits._atlasChangeCreditsFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AtlasChangeCredits._atlasChangeCreditsFieldTags[index];
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
                    this.result.hasAmount = input.ReadInt64(ref this.result.amount_);
                }
                return this;
            }

            private AtlasChangeCredits PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AtlasChangeCredits result = this.result;
                    this.result = new AtlasChangeCredits();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public AtlasChangeCredits.Builder SetAccountId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasAccountId = true;
                this.result.accountId_ = value;
                return this;
            }

            public AtlasChangeCredits.Builder SetAmount(long value)
            {
                this.PrepareBuilder();
                this.result.hasAmount = true;
                this.result.amount_ = value;
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

            public long Amount
            {
                get
                {
                    return this.result.Amount;
                }
                set
                {
                    this.SetAmount(value);
                }
            }

            public override AtlasChangeCredits DefaultInstanceForType
            {
                get
                {
                    return AtlasChangeCredits.DefaultInstance;
                }
            }

            public bool HasAccountId
            {
                get
                {
                    return this.result.hasAccountId;
                }
            }

            public bool HasAmount
            {
                get
                {
                    return this.result.hasAmount;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override AtlasChangeCredits MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override AtlasChangeCredits.Builder ThisBuilder
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
                ID = 0x197
            }
        }
    }
}

