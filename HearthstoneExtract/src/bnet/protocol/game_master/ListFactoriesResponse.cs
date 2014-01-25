namespace bnet.protocol.game_master
{
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class ListFactoriesResponse : GeneratedMessageLite<ListFactoriesResponse, Builder>
    {
        private static readonly string[] _listFactoriesResponseFieldNames = new string[] { "description", "total_results" };
        private static readonly uint[] _listFactoriesResponseFieldTags = new uint[] { 10, 0x10 };
        private static readonly ListFactoriesResponse defaultInstance = new ListFactoriesResponse().MakeReadOnly();
        private PopsicleList<GameFactoryDescription> description_ = new PopsicleList<GameFactoryDescription>();
        public const int DescriptionFieldNumber = 1;
        private bool hasTotalResults;
        private int memoizedSerializedSize = -1;
        private uint totalResults_;
        public const int TotalResultsFieldNumber = 2;

        static ListFactoriesResponse()
        {
            object.ReferenceEquals(GameMaster.Descriptor, null);
        }

        private ListFactoriesResponse()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ListFactoriesResponse prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ListFactoriesResponse response = obj as ListFactoriesResponse;
            if (response == null)
            {
                return false;
            }
            if (this.description_.Count != response.description_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.description_.Count; i++)
            {
                if (!this.description_[i].Equals(response.description_[i]))
                {
                    return false;
                }
            }
            return ((this.hasTotalResults == response.hasTotalResults) && (!this.hasTotalResults || this.totalResults_.Equals(response.totalResults_)));
        }

        public GameFactoryDescription GetDescription(int index)
        {
            return this.description_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<GameFactoryDescription> enumerator = this.description_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    GameFactoryDescription current = enumerator.Current;
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
            if (this.hasTotalResults)
            {
                hashCode ^= this.totalResults_.GetHashCode();
            }
            return hashCode;
        }

        private ListFactoriesResponse MakeReadOnly()
        {
            this.description_.MakeReadOnly();
            return this;
        }

        public static ListFactoriesResponse ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ListFactoriesResponse ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ListFactoriesResponse ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ListFactoriesResponse ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ListFactoriesResponse ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ListFactoriesResponse ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ListFactoriesResponse ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ListFactoriesResponse ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ListFactoriesResponse ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ListFactoriesResponse ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ListFactoriesResponse, Builder>.PrintField<GameFactoryDescription>("description", this.description_, writer);
            GeneratedMessageLite<ListFactoriesResponse, Builder>.PrintField("total_results", this.hasTotalResults, this.totalResults_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _listFactoriesResponseFieldNames;
            if (this.description_.Count > 0)
            {
                output.WriteMessageArray<GameFactoryDescription>(1, strArray[0], this.description_);
            }
            if (this.hasTotalResults)
            {
                output.WriteUInt32(2, strArray[1], this.TotalResults);
            }
        }

        public static ListFactoriesResponse DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ListFactoriesResponse DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public int DescriptionCount
        {
            get
            {
                return this.description_.Count;
            }
        }

        public IList<GameFactoryDescription> DescriptionList
        {
            get
            {
                return this.description_;
            }
        }

        public bool HasTotalResults
        {
            get
            {
                return this.hasTotalResults;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                IEnumerator<GameFactoryDescription> enumerator = this.DescriptionList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        GameFactoryDescription current = enumerator.Current;
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

        public override int SerializedSize
        {
            get
            {
                int memoizedSerializedSize = this.memoizedSerializedSize;
                if (memoizedSerializedSize == -1)
                {
                    memoizedSerializedSize = 0;
                    IEnumerator<GameFactoryDescription> enumerator = this.DescriptionList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            GameFactoryDescription current = enumerator.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, current);
                        }
                    }
                    finally
                    {
                        if (enumerator == null)
                        {
                        }
                        enumerator.Dispose();
                    }
                    if (this.hasTotalResults)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(2, this.TotalResults);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ListFactoriesResponse ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CLSCompliant(false)]
        public uint TotalResults
        {
            get
            {
                return this.totalResults_;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<ListFactoriesResponse, ListFactoriesResponse.Builder>
        {
            private ListFactoriesResponse result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ListFactoriesResponse.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ListFactoriesResponse cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public ListFactoriesResponse.Builder AddDescription(GameFactoryDescription value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.description_.Add(value);
                return this;
            }

            public ListFactoriesResponse.Builder AddDescription(GameFactoryDescription.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.description_.Add(builderForValue.Build());
                return this;
            }

            public ListFactoriesResponse.Builder AddRangeDescription(IEnumerable<GameFactoryDescription> values)
            {
                this.PrepareBuilder();
                this.result.description_.Add(values);
                return this;
            }

            public override ListFactoriesResponse BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ListFactoriesResponse.Builder Clear()
            {
                this.result = ListFactoriesResponse.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ListFactoriesResponse.Builder ClearDescription()
            {
                this.PrepareBuilder();
                this.result.description_.Clear();
                return this;
            }

            public ListFactoriesResponse.Builder ClearTotalResults()
            {
                this.PrepareBuilder();
                this.result.hasTotalResults = false;
                this.result.totalResults_ = 0;
                return this;
            }

            public override ListFactoriesResponse.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ListFactoriesResponse.Builder(this.result);
                }
                return new ListFactoriesResponse.Builder().MergeFrom(this.result);
            }

            public GameFactoryDescription GetDescription(int index)
            {
                return this.result.GetDescription(index);
            }

            public override ListFactoriesResponse.Builder MergeFrom(ListFactoriesResponse other)
            {
                if (other != ListFactoriesResponse.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.description_.Count != 0)
                    {
                        this.result.description_.Add(other.description_);
                    }
                    if (other.HasTotalResults)
                    {
                        this.TotalResults = other.TotalResults;
                    }
                }
                return this;
            }

            public override ListFactoriesResponse.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ListFactoriesResponse.Builder MergeFrom(IMessageLite other)
            {
                if (other is ListFactoriesResponse)
                {
                    return this.MergeFrom((ListFactoriesResponse) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ListFactoriesResponse.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ListFactoriesResponse._listFactoriesResponseFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ListFactoriesResponse._listFactoriesResponseFieldTags[index];
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
                            input.ReadMessageArray<GameFactoryDescription>(num, str, this.result.description_, GameFactoryDescription.DefaultInstance, extensionRegistry);
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
                    this.result.hasTotalResults = input.ReadUInt32(ref this.result.totalResults_);
                }
                return this;
            }

            private ListFactoriesResponse PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ListFactoriesResponse result = this.result;
                    this.result = new ListFactoriesResponse();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ListFactoriesResponse.Builder SetDescription(int index, GameFactoryDescription value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.description_[index] = value;
                return this;
            }

            public ListFactoriesResponse.Builder SetDescription(int index, GameFactoryDescription.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.description_[index] = builderForValue.Build();
                return this;
            }

            [CLSCompliant(false)]
            public ListFactoriesResponse.Builder SetTotalResults(uint value)
            {
                this.PrepareBuilder();
                this.result.hasTotalResults = true;
                this.result.totalResults_ = value;
                return this;
            }

            public override ListFactoriesResponse DefaultInstanceForType
            {
                get
                {
                    return ListFactoriesResponse.DefaultInstance;
                }
            }

            public int DescriptionCount
            {
                get
                {
                    return this.result.DescriptionCount;
                }
            }

            public IPopsicleList<GameFactoryDescription> DescriptionList
            {
                get
                {
                    return this.PrepareBuilder().description_;
                }
            }

            public bool HasTotalResults
            {
                get
                {
                    return this.result.hasTotalResults;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override ListFactoriesResponse MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override ListFactoriesResponse.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            [CLSCompliant(false)]
            public uint TotalResults
            {
                get
                {
                    return this.result.TotalResults;
                }
                set
                {
                    this.SetTotalResults(value);
                }
            }
        }
    }
}

