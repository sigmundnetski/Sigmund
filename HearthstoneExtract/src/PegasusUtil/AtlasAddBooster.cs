namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class AtlasAddBooster : GeneratedMessageLite<AtlasAddBooster, Builder>
    {
        private static readonly string[] _atlasAddBoosterFieldNames = new string[] { "account_id", "type" };
        private static readonly uint[] _atlasAddBoosterFieldTags = new uint[] { 8, 0x10 };
        private ulong accountId_;
        public const int AccountIdFieldNumber = 1;
        private static readonly AtlasAddBooster defaultInstance = new AtlasAddBooster().MakeReadOnly();
        private bool hasAccountId;
        private bool hasType;
        private int memoizedSerializedSize = -1;
        private int type_;
        public const int TypeFieldNumber = 2;

        static AtlasAddBooster()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AtlasAddBooster()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AtlasAddBooster prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AtlasAddBooster booster = obj as AtlasAddBooster;
            if (booster == null)
            {
                return false;
            }
            if ((this.hasAccountId != booster.hasAccountId) || (this.hasAccountId && !this.accountId_.Equals(booster.accountId_)))
            {
                return false;
            }
            return ((this.hasType == booster.hasType) && (!this.hasType || this.type_.Equals(booster.type_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasAccountId)
            {
                hashCode ^= this.accountId_.GetHashCode();
            }
            if (this.hasType)
            {
                hashCode ^= this.type_.GetHashCode();
            }
            return hashCode;
        }

        private AtlasAddBooster MakeReadOnly()
        {
            return this;
        }

        public static AtlasAddBooster ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AtlasAddBooster ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasAddBooster ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasAddBooster ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasAddBooster ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasAddBooster ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasAddBooster ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AtlasAddBooster ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasAddBooster ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasAddBooster ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AtlasAddBooster, Builder>.PrintField("account_id", this.hasAccountId, this.accountId_, writer);
            GeneratedMessageLite<AtlasAddBooster, Builder>.PrintField("type", this.hasType, this.type_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _atlasAddBoosterFieldNames;
            if (this.hasAccountId)
            {
                output.WriteUInt64(1, strArray[0], this.AccountId);
            }
            if (this.hasType)
            {
                output.WriteInt32(2, strArray[1], this.Type);
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

        public static AtlasAddBooster DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AtlasAddBooster DefaultInstanceForType
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

        public bool HasType
        {
            get
            {
                return this.hasType;
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
                if (!this.hasType)
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
                    if (this.hasType)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.Type);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override AtlasAddBooster ThisMessage
        {
            get
            {
                return this;
            }
        }

        public int Type
        {
            get
            {
                return this.type_;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<AtlasAddBooster, AtlasAddBooster.Builder>
        {
            private AtlasAddBooster result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AtlasAddBooster.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AtlasAddBooster cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override AtlasAddBooster BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AtlasAddBooster.Builder Clear()
            {
                this.result = AtlasAddBooster.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AtlasAddBooster.Builder ClearAccountId()
            {
                this.PrepareBuilder();
                this.result.hasAccountId = false;
                this.result.accountId_ = 0L;
                return this;
            }

            public AtlasAddBooster.Builder ClearType()
            {
                this.PrepareBuilder();
                this.result.hasType = false;
                this.result.type_ = 0;
                return this;
            }

            public override AtlasAddBooster.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AtlasAddBooster.Builder(this.result);
                }
                return new AtlasAddBooster.Builder().MergeFrom(this.result);
            }

            public override AtlasAddBooster.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AtlasAddBooster.Builder MergeFrom(IMessageLite other)
            {
                if (other is AtlasAddBooster)
                {
                    return this.MergeFrom((AtlasAddBooster) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AtlasAddBooster.Builder MergeFrom(AtlasAddBooster other)
            {
                if (other != AtlasAddBooster.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAccountId)
                    {
                        this.AccountId = other.AccountId;
                    }
                    if (other.HasType)
                    {
                        this.Type = other.Type;
                    }
                }
                return this;
            }

            public override AtlasAddBooster.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AtlasAddBooster._atlasAddBoosterFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AtlasAddBooster._atlasAddBoosterFieldTags[index];
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
                    this.result.hasType = input.ReadInt32(ref this.result.type_);
                }
                return this;
            }

            private AtlasAddBooster PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AtlasAddBooster result = this.result;
                    this.result = new AtlasAddBooster();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public AtlasAddBooster.Builder SetAccountId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasAccountId = true;
                this.result.accountId_ = value;
                return this;
            }

            public AtlasAddBooster.Builder SetType(int value)
            {
                this.PrepareBuilder();
                this.result.hasType = true;
                this.result.type_ = value;
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

            public override AtlasAddBooster DefaultInstanceForType
            {
                get
                {
                    return AtlasAddBooster.DefaultInstance;
                }
            }

            public bool HasAccountId
            {
                get
                {
                    return this.result.hasAccountId;
                }
            }

            public bool HasType
            {
                get
                {
                    return this.result.hasType;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override AtlasAddBooster MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override AtlasAddBooster.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public int Type
            {
                get
                {
                    return this.result.Type;
                }
                set
                {
                    this.SetType(value);
                }
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0x19d
            }
        }
    }
}

