namespace bnet.protocol.game_master
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class ListFactoriesRequest : GeneratedMessageLite<ListFactoriesRequest, Builder>
    {
        private static readonly string[] _listFactoriesRequestFieldNames = new string[] { "filter", "max_results", "start_index" };
        private static readonly uint[] _listFactoriesRequestFieldTags = new uint[] { 10, 0x18, 0x10 };
        private static readonly ListFactoriesRequest defaultInstance = new ListFactoriesRequest().MakeReadOnly();
        private AttributeFilter filter_;
        public const int FilterFieldNumber = 1;
        private bool hasFilter;
        private bool hasMaxResults;
        private bool hasStartIndex;
        private uint maxResults_ = 100;
        public const int MaxResultsFieldNumber = 3;
        private int memoizedSerializedSize = -1;
        private uint startIndex_;
        public const int StartIndexFieldNumber = 2;

        static ListFactoriesRequest()
        {
            object.ReferenceEquals(GameMaster.Descriptor, null);
        }

        private ListFactoriesRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ListFactoriesRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ListFactoriesRequest request = obj as ListFactoriesRequest;
            if (request == null)
            {
                return false;
            }
            if ((this.hasFilter != request.hasFilter) || (this.hasFilter && !this.filter_.Equals(request.filter_)))
            {
                return false;
            }
            if ((this.hasStartIndex != request.hasStartIndex) || (this.hasStartIndex && !this.startIndex_.Equals(request.startIndex_)))
            {
                return false;
            }
            return ((this.hasMaxResults == request.hasMaxResults) && (!this.hasMaxResults || this.maxResults_.Equals(request.maxResults_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasFilter)
            {
                hashCode ^= this.filter_.GetHashCode();
            }
            if (this.hasStartIndex)
            {
                hashCode ^= this.startIndex_.GetHashCode();
            }
            if (this.hasMaxResults)
            {
                hashCode ^= this.maxResults_.GetHashCode();
            }
            return hashCode;
        }

        private ListFactoriesRequest MakeReadOnly()
        {
            return this;
        }

        public static ListFactoriesRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ListFactoriesRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ListFactoriesRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ListFactoriesRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ListFactoriesRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ListFactoriesRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ListFactoriesRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ListFactoriesRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ListFactoriesRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ListFactoriesRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ListFactoriesRequest, Builder>.PrintField("filter", this.hasFilter, this.filter_, writer);
            GeneratedMessageLite<ListFactoriesRequest, Builder>.PrintField("start_index", this.hasStartIndex, this.startIndex_, writer);
            GeneratedMessageLite<ListFactoriesRequest, Builder>.PrintField("max_results", this.hasMaxResults, this.maxResults_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _listFactoriesRequestFieldNames;
            if (this.hasFilter)
            {
                output.WriteMessage(1, strArray[0], this.Filter);
            }
            if (this.hasStartIndex)
            {
                output.WriteUInt32(2, strArray[2], this.StartIndex);
            }
            if (this.hasMaxResults)
            {
                output.WriteUInt32(3, strArray[1], this.MaxResults);
            }
        }

        public static ListFactoriesRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ListFactoriesRequest DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public AttributeFilter Filter
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.filter_ != null)
                {
                    goto Label_0012;
                }
                return AttributeFilter.DefaultInstance;
            }
        }

        public bool HasFilter
        {
            get
            {
                return this.hasFilter;
            }
        }

        public bool HasMaxResults
        {
            get
            {
                return this.hasMaxResults;
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
                if (!this.hasFilter)
                {
                    return false;
                }
                if (!this.Filter.IsInitialized)
                {
                    return false;
                }
                return true;
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

        public override int SerializedSize
        {
            get
            {
                int memoizedSerializedSize = this.memoizedSerializedSize;
                if (memoizedSerializedSize == -1)
                {
                    memoizedSerializedSize = 0;
                    if (this.hasFilter)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.Filter);
                    }
                    if (this.hasStartIndex)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(2, this.StartIndex);
                    }
                    if (this.hasMaxResults)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(3, this.MaxResults);
                    }
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

        protected override ListFactoriesRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<ListFactoriesRequest, ListFactoriesRequest.Builder>
        {
            private ListFactoriesRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ListFactoriesRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ListFactoriesRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override ListFactoriesRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ListFactoriesRequest.Builder Clear()
            {
                this.result = ListFactoriesRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ListFactoriesRequest.Builder ClearFilter()
            {
                this.PrepareBuilder();
                this.result.hasFilter = false;
                this.result.filter_ = null;
                return this;
            }

            public ListFactoriesRequest.Builder ClearMaxResults()
            {
                this.PrepareBuilder();
                this.result.hasMaxResults = false;
                this.result.maxResults_ = 100;
                return this;
            }

            public ListFactoriesRequest.Builder ClearStartIndex()
            {
                this.PrepareBuilder();
                this.result.hasStartIndex = false;
                this.result.startIndex_ = 0;
                return this;
            }

            public override ListFactoriesRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ListFactoriesRequest.Builder(this.result);
                }
                return new ListFactoriesRequest.Builder().MergeFrom(this.result);
            }

            public ListFactoriesRequest.Builder MergeFilter(AttributeFilter value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasFilter && (this.result.filter_ != AttributeFilter.DefaultInstance))
                {
                    this.result.filter_ = AttributeFilter.CreateBuilder(this.result.filter_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.filter_ = value;
                }
                this.result.hasFilter = true;
                return this;
            }

            public override ListFactoriesRequest.Builder MergeFrom(ListFactoriesRequest other)
            {
                if (other != ListFactoriesRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasFilter)
                    {
                        this.MergeFilter(other.Filter);
                    }
                    if (other.HasStartIndex)
                    {
                        this.StartIndex = other.StartIndex;
                    }
                    if (other.HasMaxResults)
                    {
                        this.MaxResults = other.MaxResults;
                    }
                }
                return this;
            }

            public override ListFactoriesRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ListFactoriesRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is ListFactoriesRequest)
                {
                    return this.MergeFrom((ListFactoriesRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ListFactoriesRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ListFactoriesRequest._listFactoriesRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ListFactoriesRequest._listFactoriesRequestFieldTags[index];
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

                        case 10:
                        {
                            AttributeFilter.Builder builder = AttributeFilter.CreateBuilder();
                            if (this.result.hasFilter)
                            {
                                builder.MergeFrom(this.Filter);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.Filter = builder.BuildPartial();
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasStartIndex = input.ReadUInt32(ref this.result.startIndex_);
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
                    this.result.hasMaxResults = input.ReadUInt32(ref this.result.maxResults_);
                }
                return this;
            }

            private ListFactoriesRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ListFactoriesRequest result = this.result;
                    this.result = new ListFactoriesRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ListFactoriesRequest.Builder SetFilter(AttributeFilter value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasFilter = true;
                this.result.filter_ = value;
                return this;
            }

            public ListFactoriesRequest.Builder SetFilter(AttributeFilter.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasFilter = true;
                this.result.filter_ = builderForValue.Build();
                return this;
            }

            [CLSCompliant(false)]
            public ListFactoriesRequest.Builder SetMaxResults(uint value)
            {
                this.PrepareBuilder();
                this.result.hasMaxResults = true;
                this.result.maxResults_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public ListFactoriesRequest.Builder SetStartIndex(uint value)
            {
                this.PrepareBuilder();
                this.result.hasStartIndex = true;
                this.result.startIndex_ = value;
                return this;
            }

            public override ListFactoriesRequest DefaultInstanceForType
            {
                get
                {
                    return ListFactoriesRequest.DefaultInstance;
                }
            }

            public AttributeFilter Filter
            {
                get
                {
                    return this.result.Filter;
                }
                set
                {
                    this.SetFilter(value);
                }
            }

            public bool HasFilter
            {
                get
                {
                    return this.result.hasFilter;
                }
            }

            public bool HasMaxResults
            {
                get
                {
                    return this.result.hasMaxResults;
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

            protected override ListFactoriesRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
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

            protected override ListFactoriesRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

