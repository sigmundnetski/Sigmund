namespace bnet.protocol.presence
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
    public sealed class QueryResponse : GeneratedMessageLite<QueryResponse, Builder>
    {
        private static readonly string[] _queryResponseFieldNames = new string[] { "field" };
        private static readonly uint[] _queryResponseFieldTags = new uint[] { 0x12 };
        private static readonly QueryResponse defaultInstance = new QueryResponse().MakeReadOnly();
        private PopsicleList<Field> field_ = new PopsicleList<Field>();
        public const int FieldFieldNumber = 2;
        private int memoizedSerializedSize = -1;

        static QueryResponse()
        {
            object.ReferenceEquals(PresenceService.Descriptor, null);
        }

        private QueryResponse()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(QueryResponse prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            QueryResponse response = obj as QueryResponse;
            if (response == null)
            {
                return false;
            }
            if (this.field_.Count != response.field_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.field_.Count; i++)
            {
                if (!this.field_[i].Equals(response.field_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public Field GetField(int index)
        {
            return this.field_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<Field> enumerator = this.field_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    Field current = enumerator.Current;
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

        private QueryResponse MakeReadOnly()
        {
            this.field_.MakeReadOnly();
            return this;
        }

        public static QueryResponse ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static QueryResponse ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static QueryResponse ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static QueryResponse ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static QueryResponse ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static QueryResponse ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static QueryResponse ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static QueryResponse ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static QueryResponse ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static QueryResponse ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<QueryResponse, Builder>.PrintField<Field>("field", this.field_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _queryResponseFieldNames;
            if (this.field_.Count > 0)
            {
                output.WriteMessageArray<Field>(2, strArray[0], this.field_);
            }
        }

        public static QueryResponse DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override QueryResponse DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public int FieldCount
        {
            get
            {
                return this.field_.Count;
            }
        }

        public IList<Field> FieldList
        {
            get
            {
                return this.field_;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                IEnumerator<Field> enumerator = this.FieldList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        Field current = enumerator.Current;
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
                    IEnumerator<Field> enumerator = this.FieldList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            Field current = enumerator.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, current);
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

        protected override QueryResponse ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<QueryResponse, QueryResponse.Builder>
        {
            private QueryResponse result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = QueryResponse.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(QueryResponse cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public QueryResponse.Builder AddField(Field value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.field_.Add(value);
                return this;
            }

            public QueryResponse.Builder AddField(Field.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.field_.Add(builderForValue.Build());
                return this;
            }

            public QueryResponse.Builder AddRangeField(IEnumerable<Field> values)
            {
                this.PrepareBuilder();
                this.result.field_.Add(values);
                return this;
            }

            public override QueryResponse BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override QueryResponse.Builder Clear()
            {
                this.result = QueryResponse.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public QueryResponse.Builder ClearField()
            {
                this.PrepareBuilder();
                this.result.field_.Clear();
                return this;
            }

            public override QueryResponse.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new QueryResponse.Builder(this.result);
                }
                return new QueryResponse.Builder().MergeFrom(this.result);
            }

            public Field GetField(int index)
            {
                return this.result.GetField(index);
            }

            public override QueryResponse.Builder MergeFrom(QueryResponse other)
            {
                if (other != QueryResponse.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.field_.Count != 0)
                    {
                        this.result.field_.Add(other.field_);
                    }
                }
                return this;
            }

            public override QueryResponse.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override QueryResponse.Builder MergeFrom(IMessageLite other)
            {
                if (other is QueryResponse)
                {
                    return this.MergeFrom((QueryResponse) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override QueryResponse.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(QueryResponse._queryResponseFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = QueryResponse._queryResponseFieldTags[index];
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

                        case 0x12:
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
                    input.ReadMessageArray<Field>(num, str, this.result.field_, Field.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private QueryResponse PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    QueryResponse result = this.result;
                    this.result = new QueryResponse();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public QueryResponse.Builder SetField(int index, Field value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.field_[index] = value;
                return this;
            }

            public QueryResponse.Builder SetField(int index, Field.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.field_[index] = builderForValue.Build();
                return this;
            }

            public override QueryResponse DefaultInstanceForType
            {
                get
                {
                    return QueryResponse.DefaultInstance;
                }
            }

            public int FieldCount
            {
                get
                {
                    return this.result.FieldCount;
                }
            }

            public IPopsicleList<Field> FieldList
            {
                get
                {
                    return this.PrepareBuilder().field_;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override QueryResponse MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override QueryResponse.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

