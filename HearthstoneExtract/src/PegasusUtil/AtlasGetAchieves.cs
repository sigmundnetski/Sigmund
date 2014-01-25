namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class AtlasGetAchieves : GeneratedMessageLite<AtlasGetAchieves, Builder>
    {
        private static readonly string[] _atlasGetAchievesFieldNames = new string[] { "account_id" };
        private static readonly uint[] _atlasGetAchievesFieldTags = new uint[] { 8 };
        private ulong accountId_;
        public const int AccountIdFieldNumber = 1;
        private static readonly AtlasGetAchieves defaultInstance = new AtlasGetAchieves().MakeReadOnly();
        private bool hasAccountId;
        private int memoizedSerializedSize = -1;

        static AtlasGetAchieves()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AtlasGetAchieves()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AtlasGetAchieves prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AtlasGetAchieves achieves = obj as AtlasGetAchieves;
            if (achieves == null)
            {
                return false;
            }
            return ((this.hasAccountId == achieves.hasAccountId) && (!this.hasAccountId || this.accountId_.Equals(achieves.accountId_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasAccountId)
            {
                hashCode ^= this.accountId_.GetHashCode();
            }
            return hashCode;
        }

        private AtlasGetAchieves MakeReadOnly()
        {
            return this;
        }

        public static AtlasGetAchieves ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AtlasGetAchieves ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasGetAchieves ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasGetAchieves ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasGetAchieves ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasGetAchieves ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasGetAchieves ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AtlasGetAchieves ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasGetAchieves ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasGetAchieves ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AtlasGetAchieves, Builder>.PrintField("account_id", this.hasAccountId, this.accountId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _atlasGetAchievesFieldNames;
            if (this.hasAccountId)
            {
                output.WriteUInt64(1, strArray[0], this.AccountId);
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

        public static AtlasGetAchieves DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AtlasGetAchieves DefaultInstanceForType
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

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasAccountId)
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
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override AtlasGetAchieves ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<AtlasGetAchieves, AtlasGetAchieves.Builder>
        {
            private AtlasGetAchieves result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AtlasGetAchieves.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AtlasGetAchieves cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override AtlasGetAchieves BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AtlasGetAchieves.Builder Clear()
            {
                this.result = AtlasGetAchieves.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AtlasGetAchieves.Builder ClearAccountId()
            {
                this.PrepareBuilder();
                this.result.hasAccountId = false;
                this.result.accountId_ = 0L;
                return this;
            }

            public override AtlasGetAchieves.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AtlasGetAchieves.Builder(this.result);
                }
                return new AtlasGetAchieves.Builder().MergeFrom(this.result);
            }

            public override AtlasGetAchieves.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AtlasGetAchieves.Builder MergeFrom(IMessageLite other)
            {
                if (other is AtlasGetAchieves)
                {
                    return this.MergeFrom((AtlasGetAchieves) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AtlasGetAchieves.Builder MergeFrom(AtlasGetAchieves other)
            {
                if (other != AtlasGetAchieves.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAccountId)
                    {
                        this.AccountId = other.AccountId;
                    }
                }
                return this;
            }

            public override AtlasGetAchieves.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AtlasGetAchieves._atlasGetAchievesFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AtlasGetAchieves._atlasGetAchievesFieldTags[index];
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
                    this.result.hasAccountId = input.ReadUInt64(ref this.result.accountId_);
                }
                return this;
            }

            private AtlasGetAchieves PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AtlasGetAchieves result = this.result;
                    this.result = new AtlasGetAchieves();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public AtlasGetAchieves.Builder SetAccountId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasAccountId = true;
                this.result.accountId_ = value;
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

            public override AtlasGetAchieves DefaultInstanceForType
            {
                get
                {
                    return AtlasGetAchieves.DefaultInstance;
                }
            }

            public bool HasAccountId
            {
                get
                {
                    return this.result.hasAccountId;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override AtlasGetAchieves MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override AtlasGetAchieves.Builder ThisBuilder
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
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 410
            }
        }
    }
}

