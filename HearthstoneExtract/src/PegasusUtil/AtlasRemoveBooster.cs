namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class AtlasRemoveBooster : GeneratedMessageLite<AtlasRemoveBooster, Builder>
    {
        private static readonly string[] _atlasRemoveBoosterFieldNames = new string[] { "account_id", "booster_id" };
        private static readonly uint[] _atlasRemoveBoosterFieldTags = new uint[] { 8, 0x10 };
        private ulong accountId_;
        public const int AccountIdFieldNumber = 1;
        private ulong boosterId_;
        public const int BoosterIdFieldNumber = 2;
        private static readonly AtlasRemoveBooster defaultInstance = new AtlasRemoveBooster().MakeReadOnly();
        private bool hasAccountId;
        private bool hasBoosterId;
        private int memoizedSerializedSize = -1;

        static AtlasRemoveBooster()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AtlasRemoveBooster()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AtlasRemoveBooster prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AtlasRemoveBooster booster = obj as AtlasRemoveBooster;
            if (booster == null)
            {
                return false;
            }
            if ((this.hasAccountId != booster.hasAccountId) || (this.hasAccountId && !this.accountId_.Equals(booster.accountId_)))
            {
                return false;
            }
            return ((this.hasBoosterId == booster.hasBoosterId) && (!this.hasBoosterId || this.boosterId_.Equals(booster.boosterId_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasAccountId)
            {
                hashCode ^= this.accountId_.GetHashCode();
            }
            if (this.hasBoosterId)
            {
                hashCode ^= this.boosterId_.GetHashCode();
            }
            return hashCode;
        }

        private AtlasRemoveBooster MakeReadOnly()
        {
            return this;
        }

        public static AtlasRemoveBooster ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AtlasRemoveBooster ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasRemoveBooster ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasRemoveBooster ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasRemoveBooster ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasRemoveBooster ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasRemoveBooster ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AtlasRemoveBooster ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasRemoveBooster ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasRemoveBooster ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AtlasRemoveBooster, Builder>.PrintField("account_id", this.hasAccountId, this.accountId_, writer);
            GeneratedMessageLite<AtlasRemoveBooster, Builder>.PrintField("booster_id", this.hasBoosterId, this.boosterId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _atlasRemoveBoosterFieldNames;
            if (this.hasAccountId)
            {
                output.WriteUInt64(1, strArray[0], this.AccountId);
            }
            if (this.hasBoosterId)
            {
                output.WriteUInt64(2, strArray[1], this.BoosterId);
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
        public ulong BoosterId
        {
            get
            {
                return this.boosterId_;
            }
        }

        public static AtlasRemoveBooster DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AtlasRemoveBooster DefaultInstanceForType
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

        public bool HasBoosterId
        {
            get
            {
                return this.hasBoosterId;
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
                if (!this.hasBoosterId)
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
                    if (this.hasBoosterId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(2, this.BoosterId);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override AtlasRemoveBooster ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<AtlasRemoveBooster, AtlasRemoveBooster.Builder>
        {
            private AtlasRemoveBooster result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AtlasRemoveBooster.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AtlasRemoveBooster cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override AtlasRemoveBooster BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AtlasRemoveBooster.Builder Clear()
            {
                this.result = AtlasRemoveBooster.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AtlasRemoveBooster.Builder ClearAccountId()
            {
                this.PrepareBuilder();
                this.result.hasAccountId = false;
                this.result.accountId_ = 0L;
                return this;
            }

            public AtlasRemoveBooster.Builder ClearBoosterId()
            {
                this.PrepareBuilder();
                this.result.hasBoosterId = false;
                this.result.boosterId_ = 0L;
                return this;
            }

            public override AtlasRemoveBooster.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AtlasRemoveBooster.Builder(this.result);
                }
                return new AtlasRemoveBooster.Builder().MergeFrom(this.result);
            }

            public override AtlasRemoveBooster.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AtlasRemoveBooster.Builder MergeFrom(IMessageLite other)
            {
                if (other is AtlasRemoveBooster)
                {
                    return this.MergeFrom((AtlasRemoveBooster) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AtlasRemoveBooster.Builder MergeFrom(AtlasRemoveBooster other)
            {
                if (other != AtlasRemoveBooster.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAccountId)
                    {
                        this.AccountId = other.AccountId;
                    }
                    if (other.HasBoosterId)
                    {
                        this.BoosterId = other.BoosterId;
                    }
                }
                return this;
            }

            public override AtlasRemoveBooster.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AtlasRemoveBooster._atlasRemoveBoosterFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AtlasRemoveBooster._atlasRemoveBoosterFieldTags[index];
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
                    this.result.hasBoosterId = input.ReadUInt64(ref this.result.boosterId_);
                }
                return this;
            }

            private AtlasRemoveBooster PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AtlasRemoveBooster result = this.result;
                    this.result = new AtlasRemoveBooster();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public AtlasRemoveBooster.Builder SetAccountId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasAccountId = true;
                this.result.accountId_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public AtlasRemoveBooster.Builder SetBoosterId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasBoosterId = true;
                this.result.boosterId_ = value;
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
            public ulong BoosterId
            {
                get
                {
                    return this.result.BoosterId;
                }
                set
                {
                    this.SetBoosterId(value);
                }
            }

            public override AtlasRemoveBooster DefaultInstanceForType
            {
                get
                {
                    return AtlasRemoveBooster.DefaultInstance;
                }
            }

            public bool HasAccountId
            {
                get
                {
                    return this.result.hasAccountId;
                }
            }

            public bool HasBoosterId
            {
                get
                {
                    return this.result.hasBoosterId;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override AtlasRemoveBooster MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override AtlasRemoveBooster.Builder ThisBuilder
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
            public enum PacketID
            {
                ID = 0x19e
            }
        }
    }
}

