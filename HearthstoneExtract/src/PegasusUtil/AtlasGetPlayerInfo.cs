namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class AtlasGetPlayerInfo : GeneratedMessageLite<AtlasGetPlayerInfo, Builder>
    {
        private static readonly string[] _atlasGetPlayerInfoFieldNames = new string[] { "account_id" };
        private static readonly uint[] _atlasGetPlayerInfoFieldTags = new uint[] { 8 };
        private ulong accountId_;
        public const int AccountIdFieldNumber = 1;
        private static readonly AtlasGetPlayerInfo defaultInstance = new AtlasGetPlayerInfo().MakeReadOnly();
        private bool hasAccountId;
        private int memoizedSerializedSize = -1;

        static AtlasGetPlayerInfo()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AtlasGetPlayerInfo()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AtlasGetPlayerInfo prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AtlasGetPlayerInfo info = obj as AtlasGetPlayerInfo;
            if (info == null)
            {
                return false;
            }
            return ((this.hasAccountId == info.hasAccountId) && (!this.hasAccountId || this.accountId_.Equals(info.accountId_)));
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

        private AtlasGetPlayerInfo MakeReadOnly()
        {
            return this;
        }

        public static AtlasGetPlayerInfo ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AtlasGetPlayerInfo ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasGetPlayerInfo ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasGetPlayerInfo ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasGetPlayerInfo ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasGetPlayerInfo ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasGetPlayerInfo ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AtlasGetPlayerInfo ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasGetPlayerInfo ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasGetPlayerInfo ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AtlasGetPlayerInfo, Builder>.PrintField("account_id", this.hasAccountId, this.accountId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _atlasGetPlayerInfoFieldNames;
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

        public static AtlasGetPlayerInfo DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AtlasGetPlayerInfo DefaultInstanceForType
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

        protected override AtlasGetPlayerInfo ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<AtlasGetPlayerInfo, AtlasGetPlayerInfo.Builder>
        {
            private AtlasGetPlayerInfo result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AtlasGetPlayerInfo.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AtlasGetPlayerInfo cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override AtlasGetPlayerInfo BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AtlasGetPlayerInfo.Builder Clear()
            {
                this.result = AtlasGetPlayerInfo.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AtlasGetPlayerInfo.Builder ClearAccountId()
            {
                this.PrepareBuilder();
                this.result.hasAccountId = false;
                this.result.accountId_ = 0L;
                return this;
            }

            public override AtlasGetPlayerInfo.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AtlasGetPlayerInfo.Builder(this.result);
                }
                return new AtlasGetPlayerInfo.Builder().MergeFrom(this.result);
            }

            public override AtlasGetPlayerInfo.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AtlasGetPlayerInfo.Builder MergeFrom(IMessageLite other)
            {
                if (other is AtlasGetPlayerInfo)
                {
                    return this.MergeFrom((AtlasGetPlayerInfo) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AtlasGetPlayerInfo.Builder MergeFrom(AtlasGetPlayerInfo other)
            {
                if (other != AtlasGetPlayerInfo.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAccountId)
                    {
                        this.AccountId = other.AccountId;
                    }
                }
                return this;
            }

            public override AtlasGetPlayerInfo.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AtlasGetPlayerInfo._atlasGetPlayerInfoFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AtlasGetPlayerInfo._atlasGetPlayerInfoFieldTags[index];
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

            private AtlasGetPlayerInfo PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AtlasGetPlayerInfo result = this.result;
                    this.result = new AtlasGetPlayerInfo();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public AtlasGetPlayerInfo.Builder SetAccountId(ulong value)
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

            public override AtlasGetPlayerInfo DefaultInstanceForType
            {
                get
                {
                    return AtlasGetPlayerInfo.DefaultInstance;
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

            protected override AtlasGetPlayerInfo MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override AtlasGetPlayerInfo.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0x191
            }
        }
    }
}

