namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class AtlasRemoveDraft : GeneratedMessageLite<AtlasRemoveDraft, Builder>
    {
        private static readonly string[] _atlasRemoveDraftFieldNames = new string[] { "account_id", "ticket_id" };
        private static readonly uint[] _atlasRemoveDraftFieldTags = new uint[] { 8, 0x10 };
        private ulong accountId_;
        public const int AccountIdFieldNumber = 1;
        private static readonly AtlasRemoveDraft defaultInstance = new AtlasRemoveDraft().MakeReadOnly();
        private bool hasAccountId;
        private bool hasTicketId;
        private int memoizedSerializedSize = -1;
        private ulong ticketId_;
        public const int TicketIdFieldNumber = 2;

        static AtlasRemoveDraft()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AtlasRemoveDraft()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AtlasRemoveDraft prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AtlasRemoveDraft draft = obj as AtlasRemoveDraft;
            if (draft == null)
            {
                return false;
            }
            if ((this.hasAccountId != draft.hasAccountId) || (this.hasAccountId && !this.accountId_.Equals(draft.accountId_)))
            {
                return false;
            }
            return ((this.hasTicketId == draft.hasTicketId) && (!this.hasTicketId || this.ticketId_.Equals(draft.ticketId_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasAccountId)
            {
                hashCode ^= this.accountId_.GetHashCode();
            }
            if (this.hasTicketId)
            {
                hashCode ^= this.ticketId_.GetHashCode();
            }
            return hashCode;
        }

        private AtlasRemoveDraft MakeReadOnly()
        {
            return this;
        }

        public static AtlasRemoveDraft ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AtlasRemoveDraft ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasRemoveDraft ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasRemoveDraft ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasRemoveDraft ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasRemoveDraft ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasRemoveDraft ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AtlasRemoveDraft ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasRemoveDraft ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasRemoveDraft ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AtlasRemoveDraft, Builder>.PrintField("account_id", this.hasAccountId, this.accountId_, writer);
            GeneratedMessageLite<AtlasRemoveDraft, Builder>.PrintField("ticket_id", this.hasTicketId, this.ticketId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _atlasRemoveDraftFieldNames;
            if (this.hasAccountId)
            {
                output.WriteUInt64(1, strArray[0], this.AccountId);
            }
            if (this.hasTicketId)
            {
                output.WriteUInt64(2, strArray[1], this.TicketId);
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

        public static AtlasRemoveDraft DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AtlasRemoveDraft DefaultInstanceForType
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

        public bool HasTicketId
        {
            get
            {
                return this.hasTicketId;
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
                if (!this.hasTicketId)
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
                    if (this.hasTicketId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(2, this.TicketId);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override AtlasRemoveDraft ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CLSCompliant(false)]
        public ulong TicketId
        {
            get
            {
                return this.ticketId_;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<AtlasRemoveDraft, AtlasRemoveDraft.Builder>
        {
            private AtlasRemoveDraft result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AtlasRemoveDraft.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AtlasRemoveDraft cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override AtlasRemoveDraft BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AtlasRemoveDraft.Builder Clear()
            {
                this.result = AtlasRemoveDraft.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AtlasRemoveDraft.Builder ClearAccountId()
            {
                this.PrepareBuilder();
                this.result.hasAccountId = false;
                this.result.accountId_ = 0L;
                return this;
            }

            public AtlasRemoveDraft.Builder ClearTicketId()
            {
                this.PrepareBuilder();
                this.result.hasTicketId = false;
                this.result.ticketId_ = 0L;
                return this;
            }

            public override AtlasRemoveDraft.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AtlasRemoveDraft.Builder(this.result);
                }
                return new AtlasRemoveDraft.Builder().MergeFrom(this.result);
            }

            public override AtlasRemoveDraft.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AtlasRemoveDraft.Builder MergeFrom(IMessageLite other)
            {
                if (other is AtlasRemoveDraft)
                {
                    return this.MergeFrom((AtlasRemoveDraft) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AtlasRemoveDraft.Builder MergeFrom(AtlasRemoveDraft other)
            {
                if (other != AtlasRemoveDraft.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAccountId)
                    {
                        this.AccountId = other.AccountId;
                    }
                    if (other.HasTicketId)
                    {
                        this.TicketId = other.TicketId;
                    }
                }
                return this;
            }

            public override AtlasRemoveDraft.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AtlasRemoveDraft._atlasRemoveDraftFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AtlasRemoveDraft._atlasRemoveDraftFieldTags[index];
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
                    this.result.hasTicketId = input.ReadUInt64(ref this.result.ticketId_);
                }
                return this;
            }

            private AtlasRemoveDraft PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AtlasRemoveDraft result = this.result;
                    this.result = new AtlasRemoveDraft();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public AtlasRemoveDraft.Builder SetAccountId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasAccountId = true;
                this.result.accountId_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public AtlasRemoveDraft.Builder SetTicketId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasTicketId = true;
                this.result.ticketId_ = value;
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

            public override AtlasRemoveDraft DefaultInstanceForType
            {
                get
                {
                    return AtlasRemoveDraft.DefaultInstance;
                }
            }

            public bool HasAccountId
            {
                get
                {
                    return this.result.hasAccountId;
                }
            }

            public bool HasTicketId
            {
                get
                {
                    return this.result.hasTicketId;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override AtlasRemoveDraft MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override AtlasRemoveDraft.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            [CLSCompliant(false)]
            public ulong TicketId
            {
                get
                {
                    return this.result.TicketId;
                }
                set
                {
                    this.SetTicketId(value);
                }
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0x1a1
            }
        }
    }
}

