namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using PegasusShared;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class AtlasCardHistory : GeneratedMessageLite<AtlasCardHistory, Builder>
    {
        private static readonly string[] _atlasCardHistoryFieldNames = new string[] { "action", "action_date", "data" };
        private static readonly uint[] _atlasCardHistoryFieldTags = new uint[] { 8, 0x12, 0x18 };
        private uint action_;
        private Date actionDate_;
        public const int ActionDateFieldNumber = 2;
        public const int ActionFieldNumber = 1;
        private ulong data_;
        public const int DataFieldNumber = 3;
        private static readonly AtlasCardHistory defaultInstance = new AtlasCardHistory().MakeReadOnly();
        private bool hasAction;
        private bool hasActionDate;
        private bool hasData;
        private int memoizedSerializedSize = -1;

        static AtlasCardHistory()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AtlasCardHistory()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AtlasCardHistory prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AtlasCardHistory history = obj as AtlasCardHistory;
            if (history == null)
            {
                return false;
            }
            if ((this.hasAction != history.hasAction) || (this.hasAction && !this.action_.Equals(history.action_)))
            {
                return false;
            }
            if ((this.hasActionDate != history.hasActionDate) || (this.hasActionDate && !this.actionDate_.Equals(history.actionDate_)))
            {
                return false;
            }
            return ((this.hasData == history.hasData) && (!this.hasData || this.data_.Equals(history.data_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasAction)
            {
                hashCode ^= this.action_.GetHashCode();
            }
            if (this.hasActionDate)
            {
                hashCode ^= this.actionDate_.GetHashCode();
            }
            if (this.hasData)
            {
                hashCode ^= this.data_.GetHashCode();
            }
            return hashCode;
        }

        private AtlasCardHistory MakeReadOnly()
        {
            return this;
        }

        public static AtlasCardHistory ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AtlasCardHistory ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasCardHistory ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasCardHistory ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasCardHistory ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasCardHistory ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasCardHistory ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AtlasCardHistory ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasCardHistory ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasCardHistory ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AtlasCardHistory, Builder>.PrintField("action", this.hasAction, this.action_, writer);
            GeneratedMessageLite<AtlasCardHistory, Builder>.PrintField("action_date", this.hasActionDate, this.actionDate_, writer);
            GeneratedMessageLite<AtlasCardHistory, Builder>.PrintField("data", this.hasData, this.data_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _atlasCardHistoryFieldNames;
            if (this.hasAction)
            {
                output.WriteUInt32(1, strArray[0], this.Action);
            }
            if (this.hasActionDate)
            {
                output.WriteMessage(2, strArray[1], this.ActionDate);
            }
            if (this.hasData)
            {
                output.WriteUInt64(3, strArray[2], this.Data);
            }
        }

        [CLSCompliant(false)]
        public uint Action
        {
            get
            {
                return this.action_;
            }
        }

        public Date ActionDate
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.actionDate_ != null)
                {
                    goto Label_0012;
                }
                return Date.DefaultInstance;
            }
        }

        [CLSCompliant(false)]
        public ulong Data
        {
            get
            {
                return this.data_;
            }
        }

        public static AtlasCardHistory DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AtlasCardHistory DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasAction
        {
            get
            {
                return this.hasAction;
            }
        }

        public bool HasActionDate
        {
            get
            {
                return this.hasActionDate;
            }
        }

        public bool HasData
        {
            get
            {
                return this.hasData;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasAction)
                {
                    return false;
                }
                if (!this.hasActionDate)
                {
                    return false;
                }
                if (!this.hasData)
                {
                    return false;
                }
                if (!this.ActionDate.IsInitialized)
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
                    if (this.hasAction)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(1, this.Action);
                    }
                    if (this.hasActionDate)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, this.ActionDate);
                    }
                    if (this.hasData)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(3, this.Data);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override AtlasCardHistory ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<AtlasCardHistory, AtlasCardHistory.Builder>
        {
            private AtlasCardHistory result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AtlasCardHistory.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AtlasCardHistory cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override AtlasCardHistory BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AtlasCardHistory.Builder Clear()
            {
                this.result = AtlasCardHistory.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AtlasCardHistory.Builder ClearAction()
            {
                this.PrepareBuilder();
                this.result.hasAction = false;
                this.result.action_ = 0;
                return this;
            }

            public AtlasCardHistory.Builder ClearActionDate()
            {
                this.PrepareBuilder();
                this.result.hasActionDate = false;
                this.result.actionDate_ = null;
                return this;
            }

            public AtlasCardHistory.Builder ClearData()
            {
                this.PrepareBuilder();
                this.result.hasData = false;
                this.result.data_ = 0L;
                return this;
            }

            public override AtlasCardHistory.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AtlasCardHistory.Builder(this.result);
                }
                return new AtlasCardHistory.Builder().MergeFrom(this.result);
            }

            public AtlasCardHistory.Builder MergeActionDate(Date value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasActionDate && (this.result.actionDate_ != Date.DefaultInstance))
                {
                    this.result.actionDate_ = Date.CreateBuilder(this.result.actionDate_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.actionDate_ = value;
                }
                this.result.hasActionDate = true;
                return this;
            }

            public override AtlasCardHistory.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AtlasCardHistory.Builder MergeFrom(IMessageLite other)
            {
                if (other is AtlasCardHistory)
                {
                    return this.MergeFrom((AtlasCardHistory) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AtlasCardHistory.Builder MergeFrom(AtlasCardHistory other)
            {
                if (other != AtlasCardHistory.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAction)
                    {
                        this.Action = other.Action;
                    }
                    if (other.HasActionDate)
                    {
                        this.MergeActionDate(other.ActionDate);
                    }
                    if (other.HasData)
                    {
                        this.Data = other.Data;
                    }
                }
                return this;
            }

            public override AtlasCardHistory.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AtlasCardHistory._atlasCardHistoryFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AtlasCardHistory._atlasCardHistoryFieldTags[index];
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
                            this.result.hasAction = input.ReadUInt32(ref this.result.action_);
                            continue;
                        }
                        case 0x12:
                        {
                            Date.Builder builder = Date.CreateBuilder();
                            if (this.result.hasActionDate)
                            {
                                builder.MergeFrom(this.ActionDate);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.ActionDate = builder.BuildPartial();
                            continue;
                        }
                        case 0x18:
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
                    this.result.hasData = input.ReadUInt64(ref this.result.data_);
                }
                return this;
            }

            private AtlasCardHistory PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AtlasCardHistory result = this.result;
                    this.result = new AtlasCardHistory();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public AtlasCardHistory.Builder SetAction(uint value)
            {
                this.PrepareBuilder();
                this.result.hasAction = true;
                this.result.action_ = value;
                return this;
            }

            public AtlasCardHistory.Builder SetActionDate(Date value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasActionDate = true;
                this.result.actionDate_ = value;
                return this;
            }

            public AtlasCardHistory.Builder SetActionDate(Date.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasActionDate = true;
                this.result.actionDate_ = builderForValue.Build();
                return this;
            }

            [CLSCompliant(false)]
            public AtlasCardHistory.Builder SetData(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasData = true;
                this.result.data_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public uint Action
            {
                get
                {
                    return this.result.Action;
                }
                set
                {
                    this.SetAction(value);
                }
            }

            public Date ActionDate
            {
                get
                {
                    return this.result.ActionDate;
                }
                set
                {
                    this.SetActionDate(value);
                }
            }

            [CLSCompliant(false)]
            public ulong Data
            {
                get
                {
                    return this.result.Data;
                }
                set
                {
                    this.SetData(value);
                }
            }

            public override AtlasCardHistory DefaultInstanceForType
            {
                get
                {
                    return AtlasCardHistory.DefaultInstance;
                }
            }

            public bool HasAction
            {
                get
                {
                    return this.result.hasAction;
                }
            }

            public bool HasActionDate
            {
                get
                {
                    return this.result.hasActionDate;
                }
            }

            public bool HasData
            {
                get
                {
                    return this.result.hasData;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override AtlasCardHistory MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override AtlasCardHistory.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

