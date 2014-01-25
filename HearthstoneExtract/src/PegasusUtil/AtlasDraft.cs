namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class AtlasDraft : GeneratedMessageLite<AtlasDraft, Builder>
    {
        private static readonly string[] _atlasDraftFieldNames = new string[] { "history", "license", "ticket_id", "was_used" };
        private static readonly uint[] _atlasDraftFieldTags = new uint[] { 0x22, 0x1a, 8, 0x10 };
        private static readonly AtlasDraft defaultInstance = new AtlasDraft().MakeReadOnly();
        private bool hasLicense;
        private bool hasTicketId;
        private bool hasWasUsed;
        private PopsicleList<AtlasDraftHistory> history_ = new PopsicleList<AtlasDraftHistory>();
        public const int HistoryFieldNumber = 4;
        private string license_ = string.Empty;
        public const int LicenseFieldNumber = 3;
        private int memoizedSerializedSize = -1;
        private ulong ticketId_;
        public const int TicketIdFieldNumber = 1;
        private bool wasUsed_;
        public const int WasUsedFieldNumber = 2;

        static AtlasDraft()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AtlasDraft()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AtlasDraft prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AtlasDraft draft = obj as AtlasDraft;
            if (draft == null)
            {
                return false;
            }
            if ((this.hasTicketId != draft.hasTicketId) || (this.hasTicketId && !this.ticketId_.Equals(draft.ticketId_)))
            {
                return false;
            }
            if ((this.hasWasUsed != draft.hasWasUsed) || (this.hasWasUsed && !this.wasUsed_.Equals(draft.wasUsed_)))
            {
                return false;
            }
            if ((this.hasLicense != draft.hasLicense) || (this.hasLicense && !this.license_.Equals(draft.license_)))
            {
                return false;
            }
            if (this.history_.Count != draft.history_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.history_.Count; i++)
            {
                if (!this.history_[i].Equals(draft.history_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasTicketId)
            {
                hashCode ^= this.ticketId_.GetHashCode();
            }
            if (this.hasWasUsed)
            {
                hashCode ^= this.wasUsed_.GetHashCode();
            }
            if (this.hasLicense)
            {
                hashCode ^= this.license_.GetHashCode();
            }
            IEnumerator<AtlasDraftHistory> enumerator = this.history_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    AtlasDraftHistory current = enumerator.Current;
                    hashCode ^= current.GetHashCode();
                }
            }
            finally
            {
                if (enumerator == null)
                {
                }
                enumerator.Dispose();
            }
            return hashCode;
        }

        public AtlasDraftHistory GetHistory(int index)
        {
            return this.history_[index];
        }

        private AtlasDraft MakeReadOnly()
        {
            this.history_.MakeReadOnly();
            return this;
        }

        public static AtlasDraft ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AtlasDraft ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasDraft ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasDraft ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasDraft ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasDraft ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasDraft ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AtlasDraft ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasDraft ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasDraft ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AtlasDraft, Builder>.PrintField("ticket_id", this.hasTicketId, this.ticketId_, writer);
            GeneratedMessageLite<AtlasDraft, Builder>.PrintField("was_used", this.hasWasUsed, this.wasUsed_, writer);
            GeneratedMessageLite<AtlasDraft, Builder>.PrintField("license", this.hasLicense, this.license_, writer);
            GeneratedMessageLite<AtlasDraft, Builder>.PrintField<AtlasDraftHistory>("history", this.history_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _atlasDraftFieldNames;
            if (this.hasTicketId)
            {
                output.WriteUInt64(1, strArray[2], this.TicketId);
            }
            if (this.hasWasUsed)
            {
                output.WriteBool(2, strArray[3], this.WasUsed);
            }
            if (this.hasLicense)
            {
                output.WriteString(3, strArray[1], this.License);
            }
            if (this.history_.Count > 0)
            {
                output.WriteMessageArray<AtlasDraftHistory>(4, strArray[0], this.history_);
            }
        }

        public static AtlasDraft DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AtlasDraft DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasLicense
        {
            get
            {
                return this.hasLicense;
            }
        }

        public bool HasTicketId
        {
            get
            {
                return this.hasTicketId;
            }
        }

        public bool HasWasUsed
        {
            get
            {
                return this.hasWasUsed;
            }
        }

        public int HistoryCount
        {
            get
            {
                return this.history_.Count;
            }
        }

        public IList<AtlasDraftHistory> HistoryList
        {
            get
            {
                return this.history_;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasTicketId)
                {
                    return false;
                }
                if (!this.hasWasUsed)
                {
                    return false;
                }
                if (!this.hasLicense)
                {
                    return false;
                }
                IEnumerator<AtlasDraftHistory> enumerator = this.HistoryList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        AtlasDraftHistory current = enumerator.Current;
                        if (!current.IsInitialized)
                        {
                            return false;
                        }
                    }
                }
                finally
                {
                    if (enumerator == null)
                    {
                    }
                    enumerator.Dispose();
                }
                return true;
            }
        }

        public string License
        {
            get
            {
                return this.license_;
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
                    if (this.hasTicketId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(1, this.TicketId);
                    }
                    if (this.hasWasUsed)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(2, this.WasUsed);
                    }
                    if (this.hasLicense)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(3, this.License);
                    }
                    IEnumerator<AtlasDraftHistory> enumerator = this.HistoryList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            AtlasDraftHistory current = enumerator.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(4, current);
                        }
                    }
                    finally
                    {
                        if (enumerator == null)
                        {
                        }
                        enumerator.Dispose();
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override AtlasDraft ThisMessage
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

        public bool WasUsed
        {
            get
            {
                return this.wasUsed_;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<AtlasDraft, AtlasDraft.Builder>
        {
            private AtlasDraft result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AtlasDraft.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AtlasDraft cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public AtlasDraft.Builder AddHistory(AtlasDraftHistory value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.history_.Add(value);
                return this;
            }

            public AtlasDraft.Builder AddHistory(AtlasDraftHistory.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.history_.Add(builderForValue.Build());
                return this;
            }

            public AtlasDraft.Builder AddRangeHistory(IEnumerable<AtlasDraftHistory> values)
            {
                this.PrepareBuilder();
                this.result.history_.Add(values);
                return this;
            }

            public override AtlasDraft BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AtlasDraft.Builder Clear()
            {
                this.result = AtlasDraft.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AtlasDraft.Builder ClearHistory()
            {
                this.PrepareBuilder();
                this.result.history_.Clear();
                return this;
            }

            public AtlasDraft.Builder ClearLicense()
            {
                this.PrepareBuilder();
                this.result.hasLicense = false;
                this.result.license_ = string.Empty;
                return this;
            }

            public AtlasDraft.Builder ClearTicketId()
            {
                this.PrepareBuilder();
                this.result.hasTicketId = false;
                this.result.ticketId_ = 0L;
                return this;
            }

            public AtlasDraft.Builder ClearWasUsed()
            {
                this.PrepareBuilder();
                this.result.hasWasUsed = false;
                this.result.wasUsed_ = false;
                return this;
            }

            public override AtlasDraft.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AtlasDraft.Builder(this.result);
                }
                return new AtlasDraft.Builder().MergeFrom(this.result);
            }

            public AtlasDraftHistory GetHistory(int index)
            {
                return this.result.GetHistory(index);
            }

            public override AtlasDraft.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AtlasDraft.Builder MergeFrom(IMessageLite other)
            {
                if (other is AtlasDraft)
                {
                    return this.MergeFrom((AtlasDraft) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AtlasDraft.Builder MergeFrom(AtlasDraft other)
            {
                if (other != AtlasDraft.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasTicketId)
                    {
                        this.TicketId = other.TicketId;
                    }
                    if (other.HasWasUsed)
                    {
                        this.WasUsed = other.WasUsed;
                    }
                    if (other.HasLicense)
                    {
                        this.License = other.License;
                    }
                    if (other.history_.Count != 0)
                    {
                        this.result.history_.Add(other.history_);
                    }
                }
                return this;
            }

            public override AtlasDraft.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AtlasDraft._atlasDraftFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AtlasDraft._atlasDraftFieldTags[index];
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
                            this.result.hasTicketId = input.ReadUInt64(ref this.result.ticketId_);
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasWasUsed = input.ReadBool(ref this.result.wasUsed_);
                            continue;
                        }
                        case 0x1a:
                        {
                            this.result.hasLicense = input.ReadString(ref this.result.license_);
                            continue;
                        }
                        case 0x22:
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
                    input.ReadMessageArray<AtlasDraftHistory>(num, str, this.result.history_, AtlasDraftHistory.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private AtlasDraft PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AtlasDraft result = this.result;
                    this.result = new AtlasDraft();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public AtlasDraft.Builder SetHistory(int index, AtlasDraftHistory value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.history_[index] = value;
                return this;
            }

            public AtlasDraft.Builder SetHistory(int index, AtlasDraftHistory.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.history_[index] = builderForValue.Build();
                return this;
            }

            public AtlasDraft.Builder SetLicense(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasLicense = true;
                this.result.license_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public AtlasDraft.Builder SetTicketId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasTicketId = true;
                this.result.ticketId_ = value;
                return this;
            }

            public AtlasDraft.Builder SetWasUsed(bool value)
            {
                this.PrepareBuilder();
                this.result.hasWasUsed = true;
                this.result.wasUsed_ = value;
                return this;
            }

            public override AtlasDraft DefaultInstanceForType
            {
                get
                {
                    return AtlasDraft.DefaultInstance;
                }
            }

            public bool HasLicense
            {
                get
                {
                    return this.result.hasLicense;
                }
            }

            public bool HasTicketId
            {
                get
                {
                    return this.result.hasTicketId;
                }
            }

            public bool HasWasUsed
            {
                get
                {
                    return this.result.hasWasUsed;
                }
            }

            public int HistoryCount
            {
                get
                {
                    return this.result.HistoryCount;
                }
            }

            public IPopsicleList<AtlasDraftHistory> HistoryList
            {
                get
                {
                    return this.PrepareBuilder().history_;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public string License
            {
                get
                {
                    return this.result.License;
                }
                set
                {
                    this.SetLicense(value);
                }
            }

            protected override AtlasDraft MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override AtlasDraft.Builder ThisBuilder
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

            public bool WasUsed
            {
                get
                {
                    return this.result.WasUsed;
                }
                set
                {
                    this.SetWasUsed(value);
                }
            }
        }
    }
}

