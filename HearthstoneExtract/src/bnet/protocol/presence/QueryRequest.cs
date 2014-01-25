namespace bnet.protocol.presence
{
    using bnet.protocol;
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class QueryRequest : GeneratedMessageLite<QueryRequest, Builder>
    {
        private static readonly string[] _queryRequestFieldNames = new string[] { "entity_id", "key" };
        private static readonly uint[] _queryRequestFieldTags = new uint[] { 10, 0x12 };
        private static readonly QueryRequest defaultInstance = new QueryRequest().MakeReadOnly();
        private bnet.protocol.EntityId entityId_;
        public const int EntityIdFieldNumber = 1;
        private bool hasEntityId;
        private PopsicleList<FieldKey> key_ = new PopsicleList<FieldKey>();
        public const int KeyFieldNumber = 2;
        private int memoizedSerializedSize = -1;

        static QueryRequest()
        {
            object.ReferenceEquals(PresenceService.Descriptor, null);
        }

        private QueryRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(QueryRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            QueryRequest request = obj as QueryRequest;
            if (request == null)
            {
                return false;
            }
            if ((this.hasEntityId != request.hasEntityId) || (this.hasEntityId && !this.entityId_.Equals(request.entityId_)))
            {
                return false;
            }
            if (this.key_.Count != request.key_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.key_.Count; i++)
            {
                if (!this.key_[i].Equals(request.key_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasEntityId)
            {
                hashCode ^= this.entityId_.GetHashCode();
            }
            IEnumerator<FieldKey> enumerator = this.key_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    FieldKey current = enumerator.Current;
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

        public FieldKey GetKey(int index)
        {
            return this.key_[index];
        }

        private QueryRequest MakeReadOnly()
        {
            this.key_.MakeReadOnly();
            return this;
        }

        public static QueryRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static QueryRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static QueryRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static QueryRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static QueryRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static QueryRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static QueryRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static QueryRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static QueryRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static QueryRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<QueryRequest, Builder>.PrintField("entity_id", this.hasEntityId, this.entityId_, writer);
            GeneratedMessageLite<QueryRequest, Builder>.PrintField<FieldKey>("key", this.key_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _queryRequestFieldNames;
            if (this.hasEntityId)
            {
                output.WriteMessage(1, strArray[0], this.EntityId);
            }
            if (this.key_.Count > 0)
            {
                output.WriteMessageArray<FieldKey>(2, strArray[1], this.key_);
            }
        }

        public static QueryRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override QueryRequest DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bnet.protocol.EntityId EntityId
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.entityId_ != null)
                {
                    goto Label_0012;
                }
                return bnet.protocol.EntityId.DefaultInstance;
            }
        }

        public bool HasEntityId
        {
            get
            {
                return this.hasEntityId;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasEntityId)
                {
                    return false;
                }
                if (!this.EntityId.IsInitialized)
                {
                    return false;
                }
                IEnumerator<FieldKey> enumerator = this.KeyList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        FieldKey current = enumerator.Current;
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

        public int KeyCount
        {
            get
            {
                return this.key_.Count;
            }
        }

        public IList<FieldKey> KeyList
        {
            get
            {
                return this.key_;
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
                    if (this.hasEntityId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.EntityId);
                    }
                    IEnumerator<FieldKey> enumerator = this.KeyList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            FieldKey current = enumerator.Current;
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

        protected override QueryRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<QueryRequest, QueryRequest.Builder>
        {
            private QueryRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = QueryRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(QueryRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public QueryRequest.Builder AddKey(FieldKey value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.key_.Add(value);
                return this;
            }

            public QueryRequest.Builder AddKey(FieldKey.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.key_.Add(builderForValue.Build());
                return this;
            }

            public QueryRequest.Builder AddRangeKey(IEnumerable<FieldKey> values)
            {
                this.PrepareBuilder();
                this.result.key_.Add(values);
                return this;
            }

            public override QueryRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override QueryRequest.Builder Clear()
            {
                this.result = QueryRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public QueryRequest.Builder ClearEntityId()
            {
                this.PrepareBuilder();
                this.result.hasEntityId = false;
                this.result.entityId_ = null;
                return this;
            }

            public QueryRequest.Builder ClearKey()
            {
                this.PrepareBuilder();
                this.result.key_.Clear();
                return this;
            }

            public override QueryRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new QueryRequest.Builder(this.result);
                }
                return new QueryRequest.Builder().MergeFrom(this.result);
            }

            public FieldKey GetKey(int index)
            {
                return this.result.GetKey(index);
            }

            public QueryRequest.Builder MergeEntityId(bnet.protocol.EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasEntityId && (this.result.entityId_ != bnet.protocol.EntityId.DefaultInstance))
                {
                    this.result.entityId_ = bnet.protocol.EntityId.CreateBuilder(this.result.entityId_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.entityId_ = value;
                }
                this.result.hasEntityId = true;
                return this;
            }

            public override QueryRequest.Builder MergeFrom(QueryRequest other)
            {
                if (other != QueryRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasEntityId)
                    {
                        this.MergeEntityId(other.EntityId);
                    }
                    if (other.key_.Count != 0)
                    {
                        this.result.key_.Add(other.key_);
                    }
                }
                return this;
            }

            public override QueryRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override QueryRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is QueryRequest)
                {
                    return this.MergeFrom((QueryRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override QueryRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(QueryRequest._queryRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = QueryRequest._queryRequestFieldTags[index];
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
                            bnet.protocol.EntityId.Builder builder = bnet.protocol.EntityId.CreateBuilder();
                            if (this.result.hasEntityId)
                            {
                                builder.MergeFrom(this.EntityId);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.EntityId = builder.BuildPartial();
                            continue;
                        }
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
                    input.ReadMessageArray<FieldKey>(num, str, this.result.key_, FieldKey.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private QueryRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    QueryRequest result = this.result;
                    this.result = new QueryRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public QueryRequest.Builder SetEntityId(bnet.protocol.EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasEntityId = true;
                this.result.entityId_ = value;
                return this;
            }

            public QueryRequest.Builder SetEntityId(bnet.protocol.EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasEntityId = true;
                this.result.entityId_ = builderForValue.Build();
                return this;
            }

            public QueryRequest.Builder SetKey(int index, FieldKey value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.key_[index] = value;
                return this;
            }

            public QueryRequest.Builder SetKey(int index, FieldKey.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.key_[index] = builderForValue.Build();
                return this;
            }

            public override QueryRequest DefaultInstanceForType
            {
                get
                {
                    return QueryRequest.DefaultInstance;
                }
            }

            public bnet.protocol.EntityId EntityId
            {
                get
                {
                    return this.result.EntityId;
                }
                set
                {
                    this.SetEntityId(value);
                }
            }

            public bool HasEntityId
            {
                get
                {
                    return this.result.hasEntityId;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public int KeyCount
            {
                get
                {
                    return this.result.KeyCount;
                }
            }

            public IPopsicleList<FieldKey> KeyList
            {
                get
                {
                    return this.PrepareBuilder().key_;
                }
            }

            protected override QueryRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override QueryRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

