namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class AtlasGetAchieveInfo : GeneratedMessageLite<AtlasGetAchieveInfo, Builder>
    {
        private static readonly string[] _atlasGetAchieveInfoFieldNames = new string[] { "account_id", "achieve_id" };
        private static readonly uint[] _atlasGetAchieveInfoFieldTags = new uint[] { 8, 0x10 };
        private ulong accountId_;
        public const int AccountIdFieldNumber = 1;
        private ulong achieveId_;
        public const int AchieveIdFieldNumber = 2;
        private static readonly AtlasGetAchieveInfo defaultInstance = new AtlasGetAchieveInfo().MakeReadOnly();
        private bool hasAccountId;
        private bool hasAchieveId;
        private int memoizedSerializedSize = -1;

        static AtlasGetAchieveInfo()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AtlasGetAchieveInfo()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AtlasGetAchieveInfo prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AtlasGetAchieveInfo info = obj as AtlasGetAchieveInfo;
            if (info == null)
            {
                return false;
            }
            if ((this.hasAccountId != info.hasAccountId) || (this.hasAccountId && !this.accountId_.Equals(info.accountId_)))
            {
                return false;
            }
            return ((this.hasAchieveId == info.hasAchieveId) && (!this.hasAchieveId || this.achieveId_.Equals(info.achieveId_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasAccountId)
            {
                hashCode ^= this.accountId_.GetHashCode();
            }
            if (this.hasAchieveId)
            {
                hashCode ^= this.achieveId_.GetHashCode();
            }
            return hashCode;
        }

        private AtlasGetAchieveInfo MakeReadOnly()
        {
            return this;
        }

        public static AtlasGetAchieveInfo ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AtlasGetAchieveInfo ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasGetAchieveInfo ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasGetAchieveInfo ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasGetAchieveInfo ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasGetAchieveInfo ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasGetAchieveInfo ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AtlasGetAchieveInfo ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasGetAchieveInfo ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasGetAchieveInfo ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AtlasGetAchieveInfo, Builder>.PrintField("account_id", this.hasAccountId, this.accountId_, writer);
            GeneratedMessageLite<AtlasGetAchieveInfo, Builder>.PrintField("achieve_id", this.hasAchieveId, this.achieveId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _atlasGetAchieveInfoFieldNames;
            if (this.hasAccountId)
            {
                output.WriteUInt64(1, strArray[0], this.AccountId);
            }
            if (this.hasAchieveId)
            {
                output.WriteUInt64(2, strArray[1], this.AchieveId);
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
        public ulong AchieveId
        {
            get
            {
                return this.achieveId_;
            }
        }

        public static AtlasGetAchieveInfo DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AtlasGetAchieveInfo DefaultInstanceForType
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

        public bool HasAchieveId
        {
            get
            {
                return this.hasAchieveId;
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
                if (!this.hasAchieveId)
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
                    if (this.hasAchieveId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(2, this.AchieveId);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override AtlasGetAchieveInfo ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<AtlasGetAchieveInfo, AtlasGetAchieveInfo.Builder>
        {
            private AtlasGetAchieveInfo result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AtlasGetAchieveInfo.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AtlasGetAchieveInfo cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override AtlasGetAchieveInfo BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AtlasGetAchieveInfo.Builder Clear()
            {
                this.result = AtlasGetAchieveInfo.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AtlasGetAchieveInfo.Builder ClearAccountId()
            {
                this.PrepareBuilder();
                this.result.hasAccountId = false;
                this.result.accountId_ = 0L;
                return this;
            }

            public AtlasGetAchieveInfo.Builder ClearAchieveId()
            {
                this.PrepareBuilder();
                this.result.hasAchieveId = false;
                this.result.achieveId_ = 0L;
                return this;
            }

            public override AtlasGetAchieveInfo.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AtlasGetAchieveInfo.Builder(this.result);
                }
                return new AtlasGetAchieveInfo.Builder().MergeFrom(this.result);
            }

            public override AtlasGetAchieveInfo.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AtlasGetAchieveInfo.Builder MergeFrom(IMessageLite other)
            {
                if (other is AtlasGetAchieveInfo)
                {
                    return this.MergeFrom((AtlasGetAchieveInfo) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AtlasGetAchieveInfo.Builder MergeFrom(AtlasGetAchieveInfo other)
            {
                if (other != AtlasGetAchieveInfo.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAccountId)
                    {
                        this.AccountId = other.AccountId;
                    }
                    if (other.HasAchieveId)
                    {
                        this.AchieveId = other.AchieveId;
                    }
                }
                return this;
            }

            public override AtlasGetAchieveInfo.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AtlasGetAchieveInfo._atlasGetAchieveInfoFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AtlasGetAchieveInfo._atlasGetAchieveInfoFieldTags[index];
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
                    this.result.hasAchieveId = input.ReadUInt64(ref this.result.achieveId_);
                }
                return this;
            }

            private AtlasGetAchieveInfo PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AtlasGetAchieveInfo result = this.result;
                    this.result = new AtlasGetAchieveInfo();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public AtlasGetAchieveInfo.Builder SetAccountId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasAccountId = true;
                this.result.accountId_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public AtlasGetAchieveInfo.Builder SetAchieveId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasAchieveId = true;
                this.result.achieveId_ = value;
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
            public ulong AchieveId
            {
                get
                {
                    return this.result.AchieveId;
                }
                set
                {
                    this.SetAchieveId(value);
                }
            }

            public override AtlasGetAchieveInfo DefaultInstanceForType
            {
                get
                {
                    return AtlasGetAchieveInfo.DefaultInstance;
                }
            }

            public bool HasAccountId
            {
                get
                {
                    return this.result.hasAccountId;
                }
            }

            public bool HasAchieveId
            {
                get
                {
                    return this.result.hasAchieveId;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override AtlasGetAchieveInfo MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override AtlasGetAchieveInfo.Builder ThisBuilder
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
                ID = 0x19b
            }
        }
    }
}

