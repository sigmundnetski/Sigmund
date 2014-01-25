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

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class ChannelState : GeneratedMessageLite<ChannelState, Builder>
    {
        private static readonly string[] _channelStateFieldNames = new string[] { "entity_id", "field_operation", "healing" };
        private static readonly uint[] _channelStateFieldTags = new uint[] { 10, 0x12, 0x18 };
        private static readonly ChannelState defaultInstance = new ChannelState().MakeReadOnly();
        private bnet.protocol.EntityId entityId_;
        public const int EntityIdFieldNumber = 1;
        private PopsicleList<FieldOperation> fieldOperation_ = new PopsicleList<FieldOperation>();
        public const int FieldOperationFieldNumber = 2;
        private bool hasEntityId;
        private bool hasHealing;
        private bool healing_;
        public const int HealingFieldNumber = 3;
        private int memoizedSerializedSize = -1;
        public static GeneratedExtensionLite<ChannelState, ChannelState> Presence;
        public const int PresenceFieldNumber = 0x65;

        static ChannelState()
        {
            object.ReferenceEquals(PresenceService.Descriptor, null);
        }

        private ChannelState()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ChannelState prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ChannelState state = obj as ChannelState;
            if (state == null)
            {
                return false;
            }
            if ((this.hasEntityId != state.hasEntityId) || (this.hasEntityId && !this.entityId_.Equals(state.entityId_)))
            {
                return false;
            }
            if (this.fieldOperation_.Count != state.fieldOperation_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.fieldOperation_.Count; i++)
            {
                if (!this.fieldOperation_[i].Equals(state.fieldOperation_[i]))
                {
                    return false;
                }
            }
            return ((this.hasHealing == state.hasHealing) && (!this.hasHealing || this.healing_.Equals(state.healing_)));
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
            if (this.hasHealing)
            {
                hashCode ^= this.healing_.GetHashCode();
            }
            return hashCode;
        }

        private ChannelState MakeReadOnly()
        {
            this.fieldOperation_.MakeReadOnly();
            return this;
        }

        public static ChannelState ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ChannelState ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ChannelState ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ChannelState ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ChannelState ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ChannelState ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ChannelState ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ChannelState ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ChannelState ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ChannelState ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ChannelState, Builder>.PrintField("entity_id", this.hasEntityId, this.entityId_, writer);
            GeneratedMessageLite<ChannelState, Builder>.PrintField<FieldOperation>("field_operation", this.fieldOperation_, writer);
            GeneratedMessageLite<ChannelState, Builder>.PrintField("healing", this.hasHealing, this.healing_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _channelStateFieldNames;
            if (this.hasEntityId)
            {
                output.WriteMessage(1, strArray[0], this.EntityId);
            }
            if (this.fieldOperation_.Count > 0)
            {
                output.WriteMessageArray<FieldOperation>(2, strArray[1], this.fieldOperation_);
            }
            if (this.hasHealing)
            {
                output.WriteBool(3, strArray[2], this.Healing);
            }
        }

        public static ChannelState DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ChannelState DefaultInstanceForType
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

        public bool HasHealing
        {
            get
            {
                return this.hasHealing;
            }
        }

        public bool Healing
        {
            get
            {
                return this.healing_;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (this.HasEntityId && !this.EntityId.IsInitialized)
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
                    if (this.hasHealing)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(3, this.Healing);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ChannelState ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<ChannelState, ChannelState.Builder>
        {
            private ChannelState result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ChannelState.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ChannelState cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public ChannelState.Builder AddFieldOperation(FieldOperation value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.fieldOperation_.Add(value);
                return this;
            }

            public ChannelState.Builder AddFieldOperation(FieldOperation.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.fieldOperation_.Add(builderForValue.Build());
                return this;
            }

            public ChannelState.Builder AddRangeFieldOperation(IEnumerable<FieldOperation> values)
            {
                this.PrepareBuilder();
                this.result.fieldOperation_.Add(values);
                return this;
            }

            public override ChannelState BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ChannelState.Builder Clear()
            {
                this.result = ChannelState.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ChannelState.Builder ClearEntityId()
            {
                this.PrepareBuilder();
                this.result.hasEntityId = false;
                this.result.entityId_ = null;
                return this;
            }

            public ChannelState.Builder ClearFieldOperation()
            {
                this.PrepareBuilder();
                this.result.fieldOperation_.Clear();
                return this;
            }

            public ChannelState.Builder ClearHealing()
            {
                this.PrepareBuilder();
                this.result.hasHealing = false;
                this.result.healing_ = false;
                return this;
            }

            public override ChannelState.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ChannelState.Builder(this.result);
                }
                return new ChannelState.Builder().MergeFrom(this.result);
            }

            public FieldOperation GetFieldOperation(int index)
            {
                return this.result.GetFieldOperation(index);
            }

            public ChannelState.Builder MergeEntityId(bnet.protocol.EntityId value)
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

            public override ChannelState.Builder MergeFrom(ChannelState other)
            {
                if (other != ChannelState.DefaultInstance)
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
                    if (other.HasHealing)
                    {
                        this.Healing = other.Healing;
                    }
                }
                return this;
            }

            public override ChannelState.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ChannelState.Builder MergeFrom(IMessageLite other)
            {
                if (other is ChannelState)
                {
                    return this.MergeFrom((ChannelState) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ChannelState.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ChannelState._channelStateFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ChannelState._channelStateFieldTags[index];
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
                        {
                            input.ReadMessageArray<FieldOperation>(num, str, this.result.fieldOperation_, FieldOperation.DefaultInstance, extensionRegistry);
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
                    this.result.hasHealing = input.ReadBool(ref this.result.healing_);
                }
                return this;
            }

            private ChannelState PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ChannelState result = this.result;
                    this.result = new ChannelState();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ChannelState.Builder SetEntityId(bnet.protocol.EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasEntityId = true;
                this.result.entityId_ = value;
                return this;
            }

            public ChannelState.Builder SetEntityId(bnet.protocol.EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasEntityId = true;
                this.result.entityId_ = builderForValue.Build();
                return this;
            }

            public ChannelState.Builder SetFieldOperation(int index, FieldOperation value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.fieldOperation_[index] = value;
                return this;
            }

            public ChannelState.Builder SetFieldOperation(int index, FieldOperation.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.fieldOperation_[index] = builderForValue.Build();
                return this;
            }

            public ChannelState.Builder SetHealing(bool value)
            {
                this.PrepareBuilder();
                this.result.hasHealing = true;
                this.result.healing_ = value;
                return this;
            }

            public override ChannelState DefaultInstanceForType
            {
                get
                {
                    return ChannelState.DefaultInstance;
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

            public bool HasHealing
            {
                get
                {
                    return this.result.hasHealing;
                }
            }

            public bool Healing
            {
                get
                {
                    return this.result.Healing;
                }
                set
                {
                    this.SetHealing(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override ChannelState MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override ChannelState.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

