namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class AtlasAddDraft : GeneratedMessageLite<AtlasAddDraft, Builder>
    {
        private static readonly string[] _atlasAddDraftFieldNames = new string[] { "account_id" };
        private static readonly uint[] _atlasAddDraftFieldTags = new uint[] { 8 };
        private ulong accountId_;
        public const int AccountIdFieldNumber = 1;
        private static readonly AtlasAddDraft defaultInstance = new AtlasAddDraft().MakeReadOnly();
        private bool hasAccountId;
        private int memoizedSerializedSize = -1;

        static AtlasAddDraft()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AtlasAddDraft()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AtlasAddDraft prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AtlasAddDraft draft = obj as AtlasAddDraft;
            if (draft == null)
            {
                return false;
            }
            return ((this.hasAccountId == draft.hasAccountId) && (!this.hasAccountId || this.accountId_.Equals(draft.accountId_)));
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

        private AtlasAddDraft MakeReadOnly()
        {
            return this;
        }

        public static AtlasAddDraft ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AtlasAddDraft ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasAddDraft ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasAddDraft ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasAddDraft ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasAddDraft ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasAddDraft ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AtlasAddDraft ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasAddDraft ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasAddDraft ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AtlasAddDraft, Builder>.PrintField("account_id", this.hasAccountId, this.accountId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _atlasAddDraftFieldNames;
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

        public static AtlasAddDraft DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AtlasAddDraft DefaultInstanceForType
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

        protected override AtlasAddDraft ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<AtlasAddDraft, AtlasAddDraft.Builder>
        {
            private AtlasAddDraft result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AtlasAddDraft.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AtlasAddDraft cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override AtlasAddDraft BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AtlasAddDraft.Builder Clear()
            {
                this.result = AtlasAddDraft.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AtlasAddDraft.Builder ClearAccountId()
            {
                this.PrepareBuilder();
                this.result.hasAccountId = false;
                this.result.accountId_ = 0L;
                return this;
            }

            public override AtlasAddDraft.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AtlasAddDraft.Builder(this.result);
                }
                return new AtlasAddDraft.Builder().MergeFrom(this.result);
            }

            public override AtlasAddDraft.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AtlasAddDraft.Builder MergeFrom(IMessageLite other)
            {
                if (other is AtlasAddDraft)
                {
                    return this.MergeFrom((AtlasAddDraft) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AtlasAddDraft.Builder MergeFrom(AtlasAddDraft other)
            {
                if (other != AtlasAddDraft.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAccountId)
                    {
                        this.AccountId = other.AccountId;
                    }
                }
                return this;
            }

            public override AtlasAddDraft.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AtlasAddDraft._atlasAddDraftFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AtlasAddDraft._atlasAddDraftFieldTags[index];
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

            private AtlasAddDraft PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AtlasAddDraft result = this.result;
                    this.result = new AtlasAddDraft();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public AtlasAddDraft.Builder SetAccountId(ulong value)
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

            public override AtlasAddDraft DefaultInstanceForType
            {
                get
                {
                    return AtlasAddDraft.DefaultInstance;
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

            protected override AtlasAddDraft MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override AtlasAddDraft.Builder ThisBuilder
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
                ID = 0x1a0
            }
        }
    }
}

