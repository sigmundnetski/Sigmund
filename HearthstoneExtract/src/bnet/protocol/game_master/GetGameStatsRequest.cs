namespace bnet.protocol.game_master
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class GetGameStatsRequest : GeneratedMessageLite<GetGameStatsRequest, Builder>
    {
        private static readonly string[] _getGameStatsRequestFieldNames = new string[] { "factory_id", "filter" };
        private static readonly uint[] _getGameStatsRequestFieldTags = new uint[] { 9, 0x12 };
        private static readonly GetGameStatsRequest defaultInstance = new GetGameStatsRequest().MakeReadOnly();
        private ulong factoryId_;
        public const int FactoryIdFieldNumber = 1;
        private AttributeFilter filter_;
        public const int FilterFieldNumber = 2;
        private bool hasFactoryId;
        private bool hasFilter;
        private int memoizedSerializedSize = -1;

        static GetGameStatsRequest()
        {
            object.ReferenceEquals(GameMaster.Descriptor, null);
        }

        private GetGameStatsRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GetGameStatsRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GetGameStatsRequest request = obj as GetGameStatsRequest;
            if (request == null)
            {
                return false;
            }
            if ((this.hasFactoryId != request.hasFactoryId) || (this.hasFactoryId && !this.factoryId_.Equals(request.factoryId_)))
            {
                return false;
            }
            return ((this.hasFilter == request.hasFilter) && (!this.hasFilter || this.filter_.Equals(request.filter_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasFactoryId)
            {
                hashCode ^= this.factoryId_.GetHashCode();
            }
            if (this.hasFilter)
            {
                hashCode ^= this.filter_.GetHashCode();
            }
            return hashCode;
        }

        private GetGameStatsRequest MakeReadOnly()
        {
            return this;
        }

        public static GetGameStatsRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GetGameStatsRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetGameStatsRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GetGameStatsRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GetGameStatsRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GetGameStatsRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GetGameStatsRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GetGameStatsRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetGameStatsRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetGameStatsRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GetGameStatsRequest, Builder>.PrintField("factory_id", this.hasFactoryId, this.factoryId_, writer);
            GeneratedMessageLite<GetGameStatsRequest, Builder>.PrintField("filter", this.hasFilter, this.filter_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _getGameStatsRequestFieldNames;
            if (this.hasFactoryId)
            {
                output.WriteFixed64(1, strArray[0], this.FactoryId);
            }
            if (this.hasFilter)
            {
                output.WriteMessage(2, strArray[1], this.Filter);
            }
        }

        public static GetGameStatsRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GetGameStatsRequest DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        [CLSCompliant(false)]
        public ulong FactoryId
        {
            get
            {
                return this.factoryId_;
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

        public bool HasFactoryId
        {
            get
            {
                return this.hasFactoryId;
            }
        }

        public bool HasFilter
        {
            get
            {
                return this.hasFilter;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasFactoryId)
                {
                    return false;
                }
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

        public override int SerializedSize
        {
            get
            {
                int memoizedSerializedSize = this.memoizedSerializedSize;
                if (memoizedSerializedSize == -1)
                {
                    memoizedSerializedSize = 0;
                    if (this.hasFactoryId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed64Size(1, this.FactoryId);
                    }
                    if (this.hasFilter)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, this.Filter);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override GetGameStatsRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<GetGameStatsRequest, GetGameStatsRequest.Builder>
        {
            private GetGameStatsRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GetGameStatsRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GetGameStatsRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override GetGameStatsRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GetGameStatsRequest.Builder Clear()
            {
                this.result = GetGameStatsRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GetGameStatsRequest.Builder ClearFactoryId()
            {
                this.PrepareBuilder();
                this.result.hasFactoryId = false;
                this.result.factoryId_ = 0L;
                return this;
            }

            public GetGameStatsRequest.Builder ClearFilter()
            {
                this.PrepareBuilder();
                this.result.hasFilter = false;
                this.result.filter_ = null;
                return this;
            }

            public override GetGameStatsRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GetGameStatsRequest.Builder(this.result);
                }
                return new GetGameStatsRequest.Builder().MergeFrom(this.result);
            }

            public GetGameStatsRequest.Builder MergeFilter(AttributeFilter value)
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

            public override GetGameStatsRequest.Builder MergeFrom(GetGameStatsRequest other)
            {
                if (other != GetGameStatsRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasFactoryId)
                    {
                        this.FactoryId = other.FactoryId;
                    }
                    if (other.HasFilter)
                    {
                        this.MergeFilter(other.Filter);
                    }
                }
                return this;
            }

            public override GetGameStatsRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GetGameStatsRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is GetGameStatsRequest)
                {
                    return this.MergeFrom((GetGameStatsRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GetGameStatsRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GetGameStatsRequest._getGameStatsRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GetGameStatsRequest._getGameStatsRequestFieldTags[index];
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

                        case 9:
                        {
                            this.result.hasFactoryId = input.ReadFixed64(ref this.result.factoryId_);
                            continue;
                        }
                        case 0x12:
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
                    }
                    if (WireFormat.IsEndGroupTag(num))
                    {
                        return this;
                    }
                    this.ParseUnknownField(input, extensionRegistry, num, str);
                }
                return this;
            }

            private GetGameStatsRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GetGameStatsRequest result = this.result;
                    this.result = new GetGameStatsRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public GetGameStatsRequest.Builder SetFactoryId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasFactoryId = true;
                this.result.factoryId_ = value;
                return this;
            }

            public GetGameStatsRequest.Builder SetFilter(AttributeFilter value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasFilter = true;
                this.result.filter_ = value;
                return this;
            }

            public GetGameStatsRequest.Builder SetFilter(AttributeFilter.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasFilter = true;
                this.result.filter_ = builderForValue.Build();
                return this;
            }

            public override GetGameStatsRequest DefaultInstanceForType
            {
                get
                {
                    return GetGameStatsRequest.DefaultInstance;
                }
            }

            [CLSCompliant(false)]
            public ulong FactoryId
            {
                get
                {
                    return this.result.FactoryId;
                }
                set
                {
                    this.SetFactoryId(value);
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

            public bool HasFactoryId
            {
                get
                {
                    return this.result.hasFactoryId;
                }
            }

            public bool HasFilter
            {
                get
                {
                    return this.result.hasFilter;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override GetGameStatsRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override GetGameStatsRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

