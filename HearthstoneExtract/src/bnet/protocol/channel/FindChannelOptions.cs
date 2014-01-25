namespace bnet.protocol.channel
{
    using bnet.protocol.attribute;
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class FindChannelOptions : ExtendableMessageLite<FindChannelOptions, Builder>
    {
        private static readonly string[] _findChannelOptionsFieldNames = new string[] { "attribute_filter", "capacity_full", "locale", "max_results", "name", "program", "start_index" };
        private static readonly uint[] _findChannelOptionsFieldTags = new uint[] { 0x3a, 0x30, 0x2d, 0x10, 0x1a, 0x25, 8 };
        private bnet.protocol.attribute.AttributeFilter attributeFilter_;
        public const int AttributeFilterFieldNumber = 7;
        private uint capacityFull_;
        public const int CapacityFullFieldNumber = 6;
        private static readonly FindChannelOptions defaultInstance = new FindChannelOptions().MakeReadOnly();
        private bool hasAttributeFilter;
        private bool hasCapacityFull;
        private bool hasLocale;
        private bool hasMaxResults;
        private bool hasName;
        private bool hasProgram;
        private bool hasStartIndex;
        private uint locale_;
        public const int LocaleFieldNumber = 5;
        private uint maxResults_ = 0x10;
        public const int MaxResultsFieldNumber = 2;
        private int memoizedSerializedSize = -1;
        private string name_ = string.Empty;
        public const int NameFieldNumber = 3;
        private uint program_;
        public const int ProgramFieldNumber = 4;
        private uint startIndex_;
        public const int StartIndexFieldNumber = 1;

        static FindChannelOptions()
        {
            object.ReferenceEquals(ChannelTypes.Descriptor, null);
        }

        private FindChannelOptions()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(FindChannelOptions prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            FindChannelOptions options = obj as FindChannelOptions;
            if (options == null)
            {
                return false;
            }
            if ((this.hasStartIndex != options.hasStartIndex) || (this.hasStartIndex && !this.startIndex_.Equals(options.startIndex_)))
            {
                return false;
            }
            if ((this.hasMaxResults != options.hasMaxResults) || (this.hasMaxResults && !this.maxResults_.Equals(options.maxResults_)))
            {
                return false;
            }
            if ((this.hasName != options.hasName) || (this.hasName && !this.name_.Equals(options.name_)))
            {
                return false;
            }
            if ((this.hasProgram != options.hasProgram) || (this.hasProgram && !this.program_.Equals(options.program_)))
            {
                return false;
            }
            if ((this.hasLocale != options.hasLocale) || (this.hasLocale && !this.locale_.Equals(options.locale_)))
            {
                return false;
            }
            if ((this.hasCapacityFull != options.hasCapacityFull) || (this.hasCapacityFull && !this.capacityFull_.Equals(options.capacityFull_)))
            {
                return false;
            }
            if ((this.hasAttributeFilter != options.hasAttributeFilter) || (this.hasAttributeFilter && !this.attributeFilter_.Equals(options.attributeFilter_)))
            {
                return false;
            }
            if (!base.Equals(options))
            {
                return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasStartIndex)
            {
                hashCode ^= this.startIndex_.GetHashCode();
            }
            if (this.hasMaxResults)
            {
                hashCode ^= this.maxResults_.GetHashCode();
            }
            if (this.hasName)
            {
                hashCode ^= this.name_.GetHashCode();
            }
            if (this.hasProgram)
            {
                hashCode ^= this.program_.GetHashCode();
            }
            if (this.hasLocale)
            {
                hashCode ^= this.locale_.GetHashCode();
            }
            if (this.hasCapacityFull)
            {
                hashCode ^= this.capacityFull_.GetHashCode();
            }
            if (this.hasAttributeFilter)
            {
                hashCode ^= this.attributeFilter_.GetHashCode();
            }
            return (hashCode ^ base.GetHashCode());
        }

        private FindChannelOptions MakeReadOnly()
        {
            return this;
        }

        public static FindChannelOptions ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static FindChannelOptions ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static FindChannelOptions ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static FindChannelOptions ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static FindChannelOptions ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static FindChannelOptions ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static FindChannelOptions ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static FindChannelOptions ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static FindChannelOptions ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static FindChannelOptions ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<FindChannelOptions, Builder>.PrintField("start_index", this.hasStartIndex, this.startIndex_, writer);
            GeneratedMessageLite<FindChannelOptions, Builder>.PrintField("max_results", this.hasMaxResults, this.maxResults_, writer);
            GeneratedMessageLite<FindChannelOptions, Builder>.PrintField("name", this.hasName, this.name_, writer);
            GeneratedMessageLite<FindChannelOptions, Builder>.PrintField("program", this.hasProgram, this.program_, writer);
            GeneratedMessageLite<FindChannelOptions, Builder>.PrintField("locale", this.hasLocale, this.locale_, writer);
            GeneratedMessageLite<FindChannelOptions, Builder>.PrintField("capacity_full", this.hasCapacityFull, this.capacityFull_, writer);
            GeneratedMessageLite<FindChannelOptions, Builder>.PrintField("attribute_filter", this.hasAttributeFilter, this.attributeFilter_, writer);
            base.PrintTo(writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _findChannelOptionsFieldNames;
            ExtendableMessageLite<FindChannelOptions, Builder>.ExtensionWriter writer = base.CreateExtensionWriter(this);
            if (this.hasStartIndex)
            {
                output.WriteUInt32(1, strArray[6], this.StartIndex);
            }
            if (this.hasMaxResults)
            {
                output.WriteUInt32(2, strArray[3], this.MaxResults);
            }
            if (this.hasName)
            {
                output.WriteString(3, strArray[4], this.Name);
            }
            if (this.hasProgram)
            {
                output.WriteFixed32(4, strArray[5], this.Program);
            }
            if (this.hasLocale)
            {
                output.WriteFixed32(5, strArray[2], this.Locale);
            }
            if (this.hasCapacityFull)
            {
                output.WriteUInt32(6, strArray[1], this.CapacityFull);
            }
            if (this.hasAttributeFilter)
            {
                output.WriteMessage(7, strArray[0], this.AttributeFilter);
            }
            writer.WriteUntil(0x2710, output);
        }

        public bnet.protocol.attribute.AttributeFilter AttributeFilter
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.attributeFilter_ != null)
                {
                    goto Label_0012;
                }
                return bnet.protocol.attribute.AttributeFilter.DefaultInstance;
            }
        }

        [CLSCompliant(false)]
        public uint CapacityFull
        {
            get
            {
                return this.capacityFull_;
            }
        }

        public static FindChannelOptions DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override FindChannelOptions DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasAttributeFilter
        {
            get
            {
                return this.hasAttributeFilter;
            }
        }

        public bool HasCapacityFull
        {
            get
            {
                return this.hasCapacityFull;
            }
        }

        public bool HasLocale
        {
            get
            {
                return this.hasLocale;
            }
        }

        public bool HasMaxResults
        {
            get
            {
                return this.hasMaxResults;
            }
        }

        public bool HasName
        {
            get
            {
                return this.hasName;
            }
        }

        public bool HasProgram
        {
            get
            {
                return this.hasProgram;
            }
        }

        public bool HasStartIndex
        {
            get
            {
                return this.hasStartIndex;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasAttributeFilter)
                {
                    return false;
                }
                if (!this.AttributeFilter.IsInitialized)
                {
                    return false;
                }
                if (!base.ExtensionsAreInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        [CLSCompliant(false)]
        public uint Locale
        {
            get
            {
                return this.locale_;
            }
        }

        [CLSCompliant(false)]
        public uint MaxResults
        {
            get
            {
                return this.maxResults_;
            }
        }

        public string Name
        {
            get
            {
                return this.name_;
            }
        }

        [CLSCompliant(false)]
        public uint Program
        {
            get
            {
                return this.program_;
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
                    if (this.hasStartIndex)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(1, this.StartIndex);
                    }
                    if (this.hasMaxResults)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(2, this.MaxResults);
                    }
                    if (this.hasName)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(3, this.Name);
                    }
                    if (this.hasProgram)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed32Size(4, this.Program);
                    }
                    if (this.hasLocale)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed32Size(5, this.Locale);
                    }
                    if (this.hasCapacityFull)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(6, this.CapacityFull);
                    }
                    if (this.hasAttributeFilter)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(7, this.AttributeFilter);
                    }
                    memoizedSerializedSize += base.ExtensionsSerializedSize;
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        [CLSCompliant(false)]
        public uint StartIndex
        {
            get
            {
                return this.startIndex_;
            }
        }

        protected override FindChannelOptions ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : ExtendableBuilderLite<FindChannelOptions, FindChannelOptions.Builder>
        {
            private FindChannelOptions result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = FindChannelOptions.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(FindChannelOptions cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override FindChannelOptions BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override FindChannelOptions.Builder Clear()
            {
                this.result = FindChannelOptions.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public FindChannelOptions.Builder ClearAttributeFilter()
            {
                this.PrepareBuilder();
                this.result.hasAttributeFilter = false;
                this.result.attributeFilter_ = null;
                return this;
            }

            public FindChannelOptions.Builder ClearCapacityFull()
            {
                this.PrepareBuilder();
                this.result.hasCapacityFull = false;
                this.result.capacityFull_ = 0;
                return this;
            }

            public FindChannelOptions.Builder ClearLocale()
            {
                this.PrepareBuilder();
                this.result.hasLocale = false;
                this.result.locale_ = 0;
                return this;
            }

            public FindChannelOptions.Builder ClearMaxResults()
            {
                this.PrepareBuilder();
                this.result.hasMaxResults = false;
                this.result.maxResults_ = 0x10;
                return this;
            }

            public FindChannelOptions.Builder ClearName()
            {
                this.PrepareBuilder();
                this.result.hasName = false;
                this.result.name_ = string.Empty;
                return this;
            }

            public FindChannelOptions.Builder ClearProgram()
            {
                this.PrepareBuilder();
                this.result.hasProgram = false;
                this.result.program_ = 0;
                return this;
            }

            public FindChannelOptions.Builder ClearStartIndex()
            {
                this.PrepareBuilder();
                this.result.hasStartIndex = false;
                this.result.startIndex_ = 0;
                return this;
            }

            public override FindChannelOptions.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new FindChannelOptions.Builder(this.result);
                }
                return new FindChannelOptions.Builder().MergeFrom(this.result);
            }

            public FindChannelOptions.Builder MergeAttributeFilter(bnet.protocol.attribute.AttributeFilter value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasAttributeFilter && (this.result.attributeFilter_ != bnet.protocol.attribute.AttributeFilter.DefaultInstance))
                {
                    this.result.attributeFilter_ = bnet.protocol.attribute.AttributeFilter.CreateBuilder(this.result.attributeFilter_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.attributeFilter_ = value;
                }
                this.result.hasAttributeFilter = true;
                return this;
            }

            public override FindChannelOptions.Builder MergeFrom(FindChannelOptions other)
            {
                if (other != FindChannelOptions.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasStartIndex)
                    {
                        this.StartIndex = other.StartIndex;
                    }
                    if (other.HasMaxResults)
                    {
                        this.MaxResults = other.MaxResults;
                    }
                    if (other.HasName)
                    {
                        this.Name = other.Name;
                    }
                    if (other.HasProgram)
                    {
                        this.Program = other.Program;
                    }
                    if (other.HasLocale)
                    {
                        this.Locale = other.Locale;
                    }
                    if (other.HasCapacityFull)
                    {
                        this.CapacityFull = other.CapacityFull;
                    }
                    if (other.HasAttributeFilter)
                    {
                        this.MergeAttributeFilter(other.AttributeFilter);
                    }
                    base.MergeExtensionFields(other);
                }
                return this;
            }

            public override FindChannelOptions.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override FindChannelOptions.Builder MergeFrom(IMessageLite other)
            {
                if (other is FindChannelOptions)
                {
                    return this.MergeFrom((FindChannelOptions) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override FindChannelOptions.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    bnet.protocol.attribute.AttributeFilter.Builder builder;
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(FindChannelOptions._findChannelOptionsFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = FindChannelOptions._findChannelOptionsFieldTags[index];
                        }
                        else
                        {
                            this.ParseUnknownField(input, extensionRegistry, num, str);
                            continue;
                        }
                    }
                    switch (num)
                    {
                        case 0x2d:
                        {
                            this.result.hasLocale = input.ReadFixed32(ref this.result.locale_);
                            continue;
                        }
                        case 0x30:
                        {
                            this.result.hasCapacityFull = input.ReadUInt32(ref this.result.capacityFull_);
                            continue;
                        }
                        case 0:
                            throw InvalidProtocolBufferException.InvalidTag();

                        case 8:
                            goto Label_00C6;

                        case 0x10:
                            goto Label_00E7;

                        case 0x1a:
                            goto Label_0108;

                        case 0x25:
                            goto Label_0129;

                        case 0x3a:
                            goto Label_018C;

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
                Label_00C6:
                    this.result.hasStartIndex = input.ReadUInt32(ref this.result.startIndex_);
                    continue;
                Label_00E7:
                    this.result.hasMaxResults = input.ReadUInt32(ref this.result.maxResults_);
                    continue;
                Label_0108:
                    this.result.hasName = input.ReadString(ref this.result.name_);
                    continue;
                Label_0129:
                    this.result.hasProgram = input.ReadFixed32(ref this.result.program_);
                    continue;
                Label_018C:
                    builder = bnet.protocol.attribute.AttributeFilter.CreateBuilder();
                    if (this.result.hasAttributeFilter)
                    {
                        builder.MergeFrom(this.AttributeFilter);
                    }
                    input.ReadMessage(builder, extensionRegistry);
                    this.AttributeFilter = builder.BuildPartial();
                }
                return this;
            }

            private FindChannelOptions PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    FindChannelOptions result = this.result;
                    this.result = new FindChannelOptions();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public FindChannelOptions.Builder SetAttributeFilter(bnet.protocol.attribute.AttributeFilter value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasAttributeFilter = true;
                this.result.attributeFilter_ = value;
                return this;
            }

            public FindChannelOptions.Builder SetAttributeFilter(bnet.protocol.attribute.AttributeFilter.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasAttributeFilter = true;
                this.result.attributeFilter_ = builderForValue.Build();
                return this;
            }

            [CLSCompliant(false)]
            public FindChannelOptions.Builder SetCapacityFull(uint value)
            {
                this.PrepareBuilder();
                this.result.hasCapacityFull = true;
                this.result.capacityFull_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public FindChannelOptions.Builder SetLocale(uint value)
            {
                this.PrepareBuilder();
                this.result.hasLocale = true;
                this.result.locale_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public FindChannelOptions.Builder SetMaxResults(uint value)
            {
                this.PrepareBuilder();
                this.result.hasMaxResults = true;
                this.result.maxResults_ = value;
                return this;
            }

            public FindChannelOptions.Builder SetName(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasName = true;
                this.result.name_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public FindChannelOptions.Builder SetProgram(uint value)
            {
                this.PrepareBuilder();
                this.result.hasProgram = true;
                this.result.program_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public FindChannelOptions.Builder SetStartIndex(uint value)
            {
                this.PrepareBuilder();
                this.result.hasStartIndex = true;
                this.result.startIndex_ = value;
                return this;
            }

            public bnet.protocol.attribute.AttributeFilter AttributeFilter
            {
                get
                {
                    return this.result.AttributeFilter;
                }
                set
                {
                    this.SetAttributeFilter(value);
                }
            }

            [CLSCompliant(false)]
            public uint CapacityFull
            {
                get
                {
                    return this.result.CapacityFull;
                }
                set
                {
                    this.SetCapacityFull(value);
                }
            }

            public override FindChannelOptions DefaultInstanceForType
            {
                get
                {
                    return FindChannelOptions.DefaultInstance;
                }
            }

            public bool HasAttributeFilter
            {
                get
                {
                    return this.result.hasAttributeFilter;
                }
            }

            public bool HasCapacityFull
            {
                get
                {
                    return this.result.hasCapacityFull;
                }
            }

            public bool HasLocale
            {
                get
                {
                    return this.result.hasLocale;
                }
            }

            public bool HasMaxResults
            {
                get
                {
                    return this.result.hasMaxResults;
                }
            }

            public bool HasName
            {
                get
                {
                    return this.result.hasName;
                }
            }

            public bool HasProgram
            {
                get
                {
                    return this.result.hasProgram;
                }
            }

            public bool HasStartIndex
            {
                get
                {
                    return this.result.hasStartIndex;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            [CLSCompliant(false)]
            public uint Locale
            {
                get
                {
                    return this.result.Locale;
                }
                set
                {
                    this.SetLocale(value);
                }
            }

            [CLSCompliant(false)]
            public uint MaxResults
            {
                get
                {
                    return this.result.MaxResults;
                }
                set
                {
                    this.SetMaxResults(value);
                }
            }

            protected override FindChannelOptions MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public string Name
            {
                get
                {
                    return this.result.Name;
                }
                set
                {
                    this.SetName(value);
                }
            }

            [CLSCompliant(false)]
            public uint Program
            {
                get
                {
                    return this.result.Program;
                }
                set
                {
                    this.SetProgram(value);
                }
            }

            [CLSCompliant(false)]
            public uint StartIndex
            {
                get
                {
                    return this.result.StartIndex;
                }
                set
                {
                    this.SetStartIndex(value);
                }
            }

            protected override FindChannelOptions.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

