namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using PegasusShared;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class AtlasCardDetail : GeneratedMessageLite<AtlasCardDetail, Builder>
    {
        private static readonly string[] _atlasCardDetailFieldNames = new string[] { "card_id", "deleted", "history", "insert_date", "is_seen" };
        private static readonly uint[] _atlasCardDetailFieldTags = new uint[] { 8, 0x10, 0x2a, 0x22, 0x18 };
        private ulong cardId_;
        public const int CardIdFieldNumber = 1;
        private static readonly AtlasCardDetail defaultInstance = new AtlasCardDetail().MakeReadOnly();
        private uint deleted_;
        public const int DeletedFieldNumber = 2;
        private bool hasCardId;
        private bool hasDeleted;
        private bool hasInsertDate;
        private bool hasIsSeen;
        private PopsicleList<AtlasCardHistory> history_ = new PopsicleList<AtlasCardHistory>();
        public const int HistoryFieldNumber = 5;
        private Date insertDate_;
        public const int InsertDateFieldNumber = 4;
        private bool isSeen_;
        public const int IsSeenFieldNumber = 3;
        private int memoizedSerializedSize = -1;

        static AtlasCardDetail()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AtlasCardDetail()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AtlasCardDetail prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AtlasCardDetail detail = obj as AtlasCardDetail;
            if (detail == null)
            {
                return false;
            }
            if ((this.hasCardId != detail.hasCardId) || (this.hasCardId && !this.cardId_.Equals(detail.cardId_)))
            {
                return false;
            }
            if ((this.hasDeleted != detail.hasDeleted) || (this.hasDeleted && !this.deleted_.Equals(detail.deleted_)))
            {
                return false;
            }
            if ((this.hasIsSeen != detail.hasIsSeen) || (this.hasIsSeen && !this.isSeen_.Equals(detail.isSeen_)))
            {
                return false;
            }
            if ((this.hasInsertDate != detail.hasInsertDate) || (this.hasInsertDate && !this.insertDate_.Equals(detail.insertDate_)))
            {
                return false;
            }
            if (this.history_.Count != detail.history_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.history_.Count; i++)
            {
                if (!this.history_[i].Equals(detail.history_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasCardId)
            {
                hashCode ^= this.cardId_.GetHashCode();
            }
            if (this.hasDeleted)
            {
                hashCode ^= this.deleted_.GetHashCode();
            }
            if (this.hasIsSeen)
            {
                hashCode ^= this.isSeen_.GetHashCode();
            }
            if (this.hasInsertDate)
            {
                hashCode ^= this.insertDate_.GetHashCode();
            }
            IEnumerator<AtlasCardHistory> enumerator = this.history_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    AtlasCardHistory current = enumerator.Current;
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

        public AtlasCardHistory GetHistory(int index)
        {
            return this.history_[index];
        }

        private AtlasCardDetail MakeReadOnly()
        {
            this.history_.MakeReadOnly();
            return this;
        }

        public static AtlasCardDetail ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AtlasCardDetail ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasCardDetail ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasCardDetail ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasCardDetail ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasCardDetail ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasCardDetail ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AtlasCardDetail ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasCardDetail ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasCardDetail ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AtlasCardDetail, Builder>.PrintField("card_id", this.hasCardId, this.cardId_, writer);
            GeneratedMessageLite<AtlasCardDetail, Builder>.PrintField("deleted", this.hasDeleted, this.deleted_, writer);
            GeneratedMessageLite<AtlasCardDetail, Builder>.PrintField("is_seen", this.hasIsSeen, this.isSeen_, writer);
            GeneratedMessageLite<AtlasCardDetail, Builder>.PrintField("insert_date", this.hasInsertDate, this.insertDate_, writer);
            GeneratedMessageLite<AtlasCardDetail, Builder>.PrintField<AtlasCardHistory>("history", this.history_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _atlasCardDetailFieldNames;
            if (this.hasCardId)
            {
                output.WriteUInt64(1, strArray[0], this.CardId);
            }
            if (this.hasDeleted)
            {
                output.WriteUInt32(2, strArray[1], this.Deleted);
            }
            if (this.hasIsSeen)
            {
                output.WriteBool(3, strArray[4], this.IsSeen);
            }
            if (this.hasInsertDate)
            {
                output.WriteMessage(4, strArray[3], this.InsertDate);
            }
            if (this.history_.Count > 0)
            {
                output.WriteMessageArray<AtlasCardHistory>(5, strArray[2], this.history_);
            }
        }

        [CLSCompliant(false)]
        public ulong CardId
        {
            get
            {
                return this.cardId_;
            }
        }

        public static AtlasCardDetail DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AtlasCardDetail DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        [CLSCompliant(false)]
        public uint Deleted
        {
            get
            {
                return this.deleted_;
            }
        }

        public bool HasCardId
        {
            get
            {
                return this.hasCardId;
            }
        }

        public bool HasDeleted
        {
            get
            {
                return this.hasDeleted;
            }
        }

        public bool HasInsertDate
        {
            get
            {
                return this.hasInsertDate;
            }
        }

        public bool HasIsSeen
        {
            get
            {
                return this.hasIsSeen;
            }
        }

        public int HistoryCount
        {
            get
            {
                return this.history_.Count;
            }
        }

        public IList<AtlasCardHistory> HistoryList
        {
            get
            {
                return this.history_;
            }
        }

        public Date InsertDate
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.insertDate_ != null)
                {
                    goto Label_0012;
                }
                return Date.DefaultInstance;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasCardId)
                {
                    return false;
                }
                if (!this.hasDeleted)
                {
                    return false;
                }
                if (!this.hasIsSeen)
                {
                    return false;
                }
                if (!this.hasInsertDate)
                {
                    return false;
                }
                if (!this.InsertDate.IsInitialized)
                {
                    return false;
                }
                IEnumerator<AtlasCardHistory> enumerator = this.HistoryList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        AtlasCardHistory current = enumerator.Current;
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

        public bool IsSeen
        {
            get
            {
                return this.isSeen_;
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
                    if (this.hasCardId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(1, this.CardId);
                    }
                    if (this.hasDeleted)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(2, this.Deleted);
                    }
                    if (this.hasIsSeen)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(3, this.IsSeen);
                    }
                    if (this.hasInsertDate)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(4, this.InsertDate);
                    }
                    IEnumerator<AtlasCardHistory> enumerator = this.HistoryList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            AtlasCardHistory current = enumerator.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(5, current);
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

        protected override AtlasCardDetail ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<AtlasCardDetail, AtlasCardDetail.Builder>
        {
            private AtlasCardDetail result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AtlasCardDetail.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AtlasCardDetail cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public AtlasCardDetail.Builder AddHistory(AtlasCardHistory value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.history_.Add(value);
                return this;
            }

            public AtlasCardDetail.Builder AddHistory(AtlasCardHistory.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.history_.Add(builderForValue.Build());
                return this;
            }

            public AtlasCardDetail.Builder AddRangeHistory(IEnumerable<AtlasCardHistory> values)
            {
                this.PrepareBuilder();
                this.result.history_.Add(values);
                return this;
            }

            public override AtlasCardDetail BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AtlasCardDetail.Builder Clear()
            {
                this.result = AtlasCardDetail.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AtlasCardDetail.Builder ClearCardId()
            {
                this.PrepareBuilder();
                this.result.hasCardId = false;
                this.result.cardId_ = 0L;
                return this;
            }

            public AtlasCardDetail.Builder ClearDeleted()
            {
                this.PrepareBuilder();
                this.result.hasDeleted = false;
                this.result.deleted_ = 0;
                return this;
            }

            public AtlasCardDetail.Builder ClearHistory()
            {
                this.PrepareBuilder();
                this.result.history_.Clear();
                return this;
            }

            public AtlasCardDetail.Builder ClearInsertDate()
            {
                this.PrepareBuilder();
                this.result.hasInsertDate = false;
                this.result.insertDate_ = null;
                return this;
            }

            public AtlasCardDetail.Builder ClearIsSeen()
            {
                this.PrepareBuilder();
                this.result.hasIsSeen = false;
                this.result.isSeen_ = false;
                return this;
            }

            public override AtlasCardDetail.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AtlasCardDetail.Builder(this.result);
                }
                return new AtlasCardDetail.Builder().MergeFrom(this.result);
            }

            public AtlasCardHistory GetHistory(int index)
            {
                return this.result.GetHistory(index);
            }

            public override AtlasCardDetail.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AtlasCardDetail.Builder MergeFrom(IMessageLite other)
            {
                if (other is AtlasCardDetail)
                {
                    return this.MergeFrom((AtlasCardDetail) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AtlasCardDetail.Builder MergeFrom(AtlasCardDetail other)
            {
                if (other != AtlasCardDetail.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasCardId)
                    {
                        this.CardId = other.CardId;
                    }
                    if (other.HasDeleted)
                    {
                        this.Deleted = other.Deleted;
                    }
                    if (other.HasIsSeen)
                    {
                        this.IsSeen = other.IsSeen;
                    }
                    if (other.HasInsertDate)
                    {
                        this.MergeInsertDate(other.InsertDate);
                    }
                    if (other.history_.Count != 0)
                    {
                        this.result.history_.Add(other.history_);
                    }
                }
                return this;
            }

            public override AtlasCardDetail.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AtlasCardDetail._atlasCardDetailFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AtlasCardDetail._atlasCardDetailFieldTags[index];
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
                            this.result.hasCardId = input.ReadUInt64(ref this.result.cardId_);
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasDeleted = input.ReadUInt32(ref this.result.deleted_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasIsSeen = input.ReadBool(ref this.result.isSeen_);
                            continue;
                        }
                        case 0x22:
                        {
                            Date.Builder builder = Date.CreateBuilder();
                            if (this.result.hasInsertDate)
                            {
                                builder.MergeFrom(this.InsertDate);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.InsertDate = builder.BuildPartial();
                            continue;
                        }
                        case 0x2a:
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
                    input.ReadMessageArray<AtlasCardHistory>(num, str, this.result.history_, AtlasCardHistory.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            public AtlasCardDetail.Builder MergeInsertDate(Date value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasInsertDate && (this.result.insertDate_ != Date.DefaultInstance))
                {
                    this.result.insertDate_ = Date.CreateBuilder(this.result.insertDate_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.insertDate_ = value;
                }
                this.result.hasInsertDate = true;
                return this;
            }

            private AtlasCardDetail PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AtlasCardDetail result = this.result;
                    this.result = new AtlasCardDetail();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public AtlasCardDetail.Builder SetCardId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasCardId = true;
                this.result.cardId_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public AtlasCardDetail.Builder SetDeleted(uint value)
            {
                this.PrepareBuilder();
                this.result.hasDeleted = true;
                this.result.deleted_ = value;
                return this;
            }

            public AtlasCardDetail.Builder SetHistory(int index, AtlasCardHistory value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.history_[index] = value;
                return this;
            }

            public AtlasCardDetail.Builder SetHistory(int index, AtlasCardHistory.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.history_[index] = builderForValue.Build();
                return this;
            }

            public AtlasCardDetail.Builder SetInsertDate(Date value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasInsertDate = true;
                this.result.insertDate_ = value;
                return this;
            }

            public AtlasCardDetail.Builder SetInsertDate(Date.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasInsertDate = true;
                this.result.insertDate_ = builderForValue.Build();
                return this;
            }

            public AtlasCardDetail.Builder SetIsSeen(bool value)
            {
                this.PrepareBuilder();
                this.result.hasIsSeen = true;
                this.result.isSeen_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public ulong CardId
            {
                get
                {
                    return this.result.CardId;
                }
                set
                {
                    this.SetCardId(value);
                }
            }

            public override AtlasCardDetail DefaultInstanceForType
            {
                get
                {
                    return AtlasCardDetail.DefaultInstance;
                }
            }

            [CLSCompliant(false)]
            public uint Deleted
            {
                get
                {
                    return this.result.Deleted;
                }
                set
                {
                    this.SetDeleted(value);
                }
            }

            public bool HasCardId
            {
                get
                {
                    return this.result.hasCardId;
                }
            }

            public bool HasDeleted
            {
                get
                {
                    return this.result.hasDeleted;
                }
            }

            public bool HasInsertDate
            {
                get
                {
                    return this.result.hasInsertDate;
                }
            }

            public bool HasIsSeen
            {
                get
                {
                    return this.result.hasIsSeen;
                }
            }

            public int HistoryCount
            {
                get
                {
                    return this.result.HistoryCount;
                }
            }

            public IPopsicleList<AtlasCardHistory> HistoryList
            {
                get
                {
                    return this.PrepareBuilder().history_;
                }
            }

            public Date InsertDate
            {
                get
                {
                    return this.result.InsertDate;
                }
                set
                {
                    this.SetInsertDate(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public bool IsSeen
            {
                get
                {
                    return this.result.IsSeen;
                }
                set
                {
                    this.SetIsSeen(value);
                }
            }

            protected override AtlasCardDetail MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override AtlasCardDetail.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

