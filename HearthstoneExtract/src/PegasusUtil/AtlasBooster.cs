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
    public sealed class AtlasBooster : GeneratedMessageLite<AtlasBooster, Builder>
    {
        private static readonly string[] _atlasBoosterFieldNames = new string[] { "booster_id", "history", "is_open", "license", "type" };
        private static readonly uint[] _atlasBoosterFieldTags = new uint[] { 8, 0x2a, 0x10, 0x20, 0x18 };
        private ulong boosterId_;
        public const int BoosterIdFieldNumber = 1;
        private static readonly AtlasBooster defaultInstance = new AtlasBooster().MakeReadOnly();
        private bool hasBoosterId;
        private bool hasIsOpen;
        private bool hasLicense;
        private bool hasType;
        private PopsicleList<AtlasBoosterHistory> history_ = new PopsicleList<AtlasBoosterHistory>();
        public const int HistoryFieldNumber = 5;
        private bool isOpen_;
        public const int IsOpenFieldNumber = 2;
        private ulong license_;
        public const int LicenseFieldNumber = 4;
        private int memoizedSerializedSize = -1;
        private int type_;
        public const int TypeFieldNumber = 3;

        static AtlasBooster()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AtlasBooster()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AtlasBooster prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AtlasBooster booster = obj as AtlasBooster;
            if (booster == null)
            {
                return false;
            }
            if ((this.hasBoosterId != booster.hasBoosterId) || (this.hasBoosterId && !this.boosterId_.Equals(booster.boosterId_)))
            {
                return false;
            }
            if ((this.hasIsOpen != booster.hasIsOpen) || (this.hasIsOpen && !this.isOpen_.Equals(booster.isOpen_)))
            {
                return false;
            }
            if ((this.hasType != booster.hasType) || (this.hasType && !this.type_.Equals(booster.type_)))
            {
                return false;
            }
            if ((this.hasLicense != booster.hasLicense) || (this.hasLicense && !this.license_.Equals(booster.license_)))
            {
                return false;
            }
            if (this.history_.Count != booster.history_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.history_.Count; i++)
            {
                if (!this.history_[i].Equals(booster.history_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasBoosterId)
            {
                hashCode ^= this.boosterId_.GetHashCode();
            }
            if (this.hasIsOpen)
            {
                hashCode ^= this.isOpen_.GetHashCode();
            }
            if (this.hasType)
            {
                hashCode ^= this.type_.GetHashCode();
            }
            if (this.hasLicense)
            {
                hashCode ^= this.license_.GetHashCode();
            }
            IEnumerator<AtlasBoosterHistory> enumerator = this.history_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    AtlasBoosterHistory current = enumerator.Current;
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

        public AtlasBoosterHistory GetHistory(int index)
        {
            return this.history_[index];
        }

        private AtlasBooster MakeReadOnly()
        {
            this.history_.MakeReadOnly();
            return this;
        }

        public static AtlasBooster ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AtlasBooster ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasBooster ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasBooster ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasBooster ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasBooster ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasBooster ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AtlasBooster ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasBooster ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasBooster ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AtlasBooster, Builder>.PrintField("booster_id", this.hasBoosterId, this.boosterId_, writer);
            GeneratedMessageLite<AtlasBooster, Builder>.PrintField("is_open", this.hasIsOpen, this.isOpen_, writer);
            GeneratedMessageLite<AtlasBooster, Builder>.PrintField("type", this.hasType, this.type_, writer);
            GeneratedMessageLite<AtlasBooster, Builder>.PrintField("license", this.hasLicense, this.license_, writer);
            GeneratedMessageLite<AtlasBooster, Builder>.PrintField<AtlasBoosterHistory>("history", this.history_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _atlasBoosterFieldNames;
            if (this.hasBoosterId)
            {
                output.WriteUInt64(1, strArray[0], this.BoosterId);
            }
            if (this.hasIsOpen)
            {
                output.WriteBool(2, strArray[2], this.IsOpen);
            }
            if (this.hasType)
            {
                output.WriteInt32(3, strArray[4], this.Type);
            }
            if (this.hasLicense)
            {
                output.WriteUInt64(4, strArray[3], this.License);
            }
            if (this.history_.Count > 0)
            {
                output.WriteMessageArray<AtlasBoosterHistory>(5, strArray[1], this.history_);
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

        public static AtlasBooster DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AtlasBooster DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasBoosterId
        {
            get
            {
                return this.hasBoosterId;
            }
        }

        public bool HasIsOpen
        {
            get
            {
                return this.hasIsOpen;
            }
        }

        public bool HasLicense
        {
            get
            {
                return this.hasLicense;
            }
        }

        public bool HasType
        {
            get
            {
                return this.hasType;
            }
        }

        public int HistoryCount
        {
            get
            {
                return this.history_.Count;
            }
        }

        public IList<AtlasBoosterHistory> HistoryList
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
                if (!this.hasBoosterId)
                {
                    return false;
                }
                if (!this.hasIsOpen)
                {
                    return false;
                }
                if (!this.hasType)
                {
                    return false;
                }
                if (!this.hasLicense)
                {
                    return false;
                }
                IEnumerator<AtlasBoosterHistory> enumerator = this.HistoryList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        AtlasBoosterHistory current = enumerator.Current;
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

        public bool IsOpen
        {
            get
            {
                return this.isOpen_;
            }
        }

        [CLSCompliant(false)]
        public ulong License
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
                    if (this.hasBoosterId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(1, this.BoosterId);
                    }
                    if (this.hasIsOpen)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(2, this.IsOpen);
                    }
                    if (this.hasType)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(3, this.Type);
                    }
                    if (this.hasLicense)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(4, this.License);
                    }
                    IEnumerator<AtlasBoosterHistory> enumerator = this.HistoryList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            AtlasBoosterHistory current = enumerator.Current;
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

        protected override AtlasBooster ThisMessage
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

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<AtlasBooster, AtlasBooster.Builder>
        {
            private AtlasBooster result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AtlasBooster.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AtlasBooster cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public AtlasBooster.Builder AddHistory(AtlasBoosterHistory value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.history_.Add(value);
                return this;
            }

            public AtlasBooster.Builder AddHistory(AtlasBoosterHistory.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.history_.Add(builderForValue.Build());
                return this;
            }

            public AtlasBooster.Builder AddRangeHistory(IEnumerable<AtlasBoosterHistory> values)
            {
                this.PrepareBuilder();
                this.result.history_.Add(values);
                return this;
            }

            public override AtlasBooster BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AtlasBooster.Builder Clear()
            {
                this.result = AtlasBooster.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AtlasBooster.Builder ClearBoosterId()
            {
                this.PrepareBuilder();
                this.result.hasBoosterId = false;
                this.result.boosterId_ = 0L;
                return this;
            }

            public AtlasBooster.Builder ClearHistory()
            {
                this.PrepareBuilder();
                this.result.history_.Clear();
                return this;
            }

            public AtlasBooster.Builder ClearIsOpen()
            {
                this.PrepareBuilder();
                this.result.hasIsOpen = false;
                this.result.isOpen_ = false;
                return this;
            }

            public AtlasBooster.Builder ClearLicense()
            {
                this.PrepareBuilder();
                this.result.hasLicense = false;
                this.result.license_ = 0L;
                return this;
            }

            public AtlasBooster.Builder ClearType()
            {
                this.PrepareBuilder();
                this.result.hasType = false;
                this.result.type_ = 0;
                return this;
            }

            public override AtlasBooster.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AtlasBooster.Builder(this.result);
                }
                return new AtlasBooster.Builder().MergeFrom(this.result);
            }

            public AtlasBoosterHistory GetHistory(int index)
            {
                return this.result.GetHistory(index);
            }

            public override AtlasBooster.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AtlasBooster.Builder MergeFrom(IMessageLite other)
            {
                if (other is AtlasBooster)
                {
                    return this.MergeFrom((AtlasBooster) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AtlasBooster.Builder MergeFrom(AtlasBooster other)
            {
                if (other != AtlasBooster.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasBoosterId)
                    {
                        this.BoosterId = other.BoosterId;
                    }
                    if (other.HasIsOpen)
                    {
                        this.IsOpen = other.IsOpen;
                    }
                    if (other.HasType)
                    {
                        this.Type = other.Type;
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

            public override AtlasBooster.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AtlasBooster._atlasBoosterFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AtlasBooster._atlasBoosterFieldTags[index];
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
                            this.result.hasBoosterId = input.ReadUInt64(ref this.result.boosterId_);
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasIsOpen = input.ReadBool(ref this.result.isOpen_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasType = input.ReadInt32(ref this.result.type_);
                            continue;
                        }
                        case 0x20:
                        {
                            this.result.hasLicense = input.ReadUInt64(ref this.result.license_);
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
                    input.ReadMessageArray<AtlasBoosterHistory>(num, str, this.result.history_, AtlasBoosterHistory.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private AtlasBooster PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AtlasBooster result = this.result;
                    this.result = new AtlasBooster();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public AtlasBooster.Builder SetBoosterId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasBoosterId = true;
                this.result.boosterId_ = value;
                return this;
            }

            public AtlasBooster.Builder SetHistory(int index, AtlasBoosterHistory value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.history_[index] = value;
                return this;
            }

            public AtlasBooster.Builder SetHistory(int index, AtlasBoosterHistory.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.history_[index] = builderForValue.Build();
                return this;
            }

            public AtlasBooster.Builder SetIsOpen(bool value)
            {
                this.PrepareBuilder();
                this.result.hasIsOpen = true;
                this.result.isOpen_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public AtlasBooster.Builder SetLicense(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasLicense = true;
                this.result.license_ = value;
                return this;
            }

            public AtlasBooster.Builder SetType(int value)
            {
                this.PrepareBuilder();
                this.result.hasType = true;
                this.result.type_ = value;
                return this;
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

            public override AtlasBooster DefaultInstanceForType
            {
                get
                {
                    return AtlasBooster.DefaultInstance;
                }
            }

            public bool HasBoosterId
            {
                get
                {
                    return this.result.hasBoosterId;
                }
            }

            public bool HasIsOpen
            {
                get
                {
                    return this.result.hasIsOpen;
                }
            }

            public bool HasLicense
            {
                get
                {
                    return this.result.hasLicense;
                }
            }

            public bool HasType
            {
                get
                {
                    return this.result.hasType;
                }
            }

            public int HistoryCount
            {
                get
                {
                    return this.result.HistoryCount;
                }
            }

            public IPopsicleList<AtlasBoosterHistory> HistoryList
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

            public bool IsOpen
            {
                get
                {
                    return this.result.IsOpen;
                }
                set
                {
                    this.SetIsOpen(value);
                }
            }

            [CLSCompliant(false)]
            public ulong License
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

            protected override AtlasBooster MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override AtlasBooster.Builder ThisBuilder
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
    }
}

