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

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class UpdateRequest : GeneratedMessageLite<UpdateRequest, Builder>
    {
        private static readonly string[] _updateRequestFieldNames = new string[] { "entity_id", "field_operation" };
        private static readonly uint[] _updateRequestFieldTags = new uint[] { 10, 0x12 };
        private static readonly UpdateRequest defaultInstance = new UpdateRequest().MakeReadOnly();
        private bnet.protocol.EntityId entityId_;
        public const int EntityIdFieldNumber = 1;
        private PopsicleList<FieldOperation> fieldOperation_ = new PopsicleList<FieldOperation>();
        public const int FieldOperationFieldNumber = 2;
        private bool hasEntityId;
        private int memoizedSerializedSize = -1;

        static UpdateRequest()
        {
            object.ReferenceEquals(PresenceService.Descriptor, null);
        }

        private UpdateRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(UpdateRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            UpdateRequest request = obj as UpdateRequest;
            if (request == null)
            {
                return false;
            }
            if ((this.hasEntityId != request.hasEntityId) || (this.hasEntityId && !this.entityId_.Equals(request.entityId_)))
            {
                return false;
            }
            if (this.fieldOperation_.Count != request.fieldOperation_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.fieldOperation_.Count; i++)
            {
                if (!this.fieldOperation_[i].Equals(request.fieldOperation_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public FieldOperation GetFieldOperation(int index)
        {
            return this.fieldOperation_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasEntityId)
            {
                hashCode ^= this.entityId_.GetHashCode();
            }
            IEnumerator<FieldOperation> enumerator = this.fieldOperation_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    FieldOperation current = enumerator.Current;
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

        private UpdateRequest MakeReadOnly()
        {
            this.fieldOperation_.MakeReadOnly();
            return this;
        }

        public static UpdateRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static UpdateRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static UpdateRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static UpdateRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static UpdateRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static UpdateRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static UpdateRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static UpdateRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static UpdateRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static UpdateRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<UpdateRequest, Builder>.PrintField("entity_id", this.hasEntityId, this.entityId_, writer);
            GeneratedMessageLite<UpdateRequest, Builder>.PrintField<FieldOperation>("field_operation", this.fieldOperation_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _updateRequestFieldNames;
            if (this.hasEntityId)
            {
                output.WriteMessage(1, strArray[0], this.EntityId);
            }
            if (this.fieldOperation_.Count > 0)
            {
                output.WriteMessageArray<FieldOperation>(2, strArray[1], this.fieldOperation_);
            }
        }

        public static UpdateRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override UpdateRequest DefaultInstanceForType
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

        public int FieldOperationCount
        {
            get
            {
                return this.fieldOperation_.Count;
            }
        }

        public IList<FieldOperation> FieldOperationList
        {
            get
            {
                return this.fieldOperation_;
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
                IEnumerator<FieldOperation> enumerator = this.FieldOperationList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        FieldOperation current = enumerator.Current;
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
                    if (this.hasEntityId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.EntityId);
                    }
                    IEnumerator<FieldOperation> enumerator = this.FieldOperationList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            FieldOperation current = enumerator.Current;
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

        protected override UpdateRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<UpdateRequest, UpdateRequest.Builder>
        {
            private UpdateRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = UpdateRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(UpdateRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public UpdateRequest.Builder AddFieldOperation(FieldOperation value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.fieldOperation_.Add(value);
                return this;
            }

            public UpdateRequest.Builder AddFieldOperation(FieldOperation.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.fieldOperation_.Add(builderForValue.Build());
                return this;
            }

            public UpdateRequest.Builder AddRangeFieldOperation(IEnumerable<FieldOperation> values)
            {
                this.PrepareBuilder();
                this.result.fieldOperation_.Add(values);
                return this;
            }

            public override UpdateRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override UpdateRequest.Builder Clear()
            {
                this.result = UpdateRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public UpdateRequest.Builder ClearEntityId()
            {
                this.PrepareBuilder();
                this.result.hasEntityId = false;
                this.result.entityId_ = null;
                return this;
            }

            public UpdateRequest.Builder ClearFieldOperation()
            {
                this.PrepareBuilder();
                this.result.fieldOperation_.Clear();
                return this;
            }

            public override UpdateRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new UpdateRequest.Builder(this.result);
                }
                return new UpdateRequest.Builder().MergeFrom(this.result);
            }

            public FieldOperation GetFieldOperation(int index)
            {
                return this.result.GetFieldOperation(index);
            }

            public UpdateRequest.Builder MergeEntityId(bnet.protocol.EntityId value)
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

            public override UpdateRequest.Builder MergeFrom(UpdateRequest other)
            {
                if (other != UpdateRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasEntityId)
                    {
                        this.MergeEntityId(other.EntityId);
                    }
                    if (other.fieldOperation_.Count != 0)
                    {
                        this.result.fieldOperation_.Add(other.fieldOperation_);
                    }
                }
                return this;
            }

            public override UpdateRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override UpdateRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is UpdateRequest)
                {
                    return this.MergeFrom((UpdateRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override UpdateRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(UpdateRequest._updateRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = UpdateRequest._updateRequestFieldTags[index];
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
                    input.ReadMessageArray<FieldOperation>(num, str, this.result.fieldOperation_, FieldOperation.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private UpdateRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    UpdateRequest result = this.result;
                    this.result = new UpdateRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public UpdateRequest.Builder SetEntityId(bnet.protocol.EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasEntityId = true;
                this.result.entityId_ = value;
                return this;
            }

            public UpdateRequest.Builder SetEntityId(bnet.protocol.EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasEntityId = true;
                this.result.entityId_ = builderForValue.Build();
                return this;
            }

            public UpdateRequest.Builder SetFieldOperation(int index, FieldOperation value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.fieldOperation_[index] = value;
                return this;
            }

            public UpdateRequest.Builder SetFieldOperation(int index, FieldOperation.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.fieldOperation_[index] = builderForValue.Build();
                return this;
            }

            public override UpdateRequest DefaultInstanceForType
            {
                get
                {
                    return UpdateRequest.DefaultInstance;
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

            public int FieldOperationCount
            {
                get
                {
                    return this.result.FieldOperationCount;
                }
            }

            public IPopsicleList<FieldOperation> FieldOperationList
            {
                get
                {
                    return this.PrepareBuilder().fieldOperation_;
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

            protected override UpdateRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override UpdateRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

