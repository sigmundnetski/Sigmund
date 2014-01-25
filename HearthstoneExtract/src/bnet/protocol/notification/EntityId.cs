namespace bnet.protocol.notification
{
    using bnet.protocol.notification.Proto;
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class EntityId : GeneratedMessageLite<EntityId, Builder>
    {
        private static readonly string[] _entityIdFieldNames = new string[] { "high", "low" };
        private static readonly uint[] _entityIdFieldTags = new uint[] { 9, 0x11 };
        private static readonly EntityId defaultInstance = new EntityId().MakeReadOnly();
        private bool hasHigh;
        private bool hasLow;
        private ulong high_;
        public const int HighFieldNumber = 1;
        private ulong low_;
        public const int LowFieldNumber = 2;
        private int memoizedSerializedSize = -1;

        static EntityId()
        {
            object.ReferenceEquals(bnet.protocol.notification.Proto.Notification.Descriptor, null);
        }

        private EntityId()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(EntityId prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            EntityId id = obj as EntityId;
            if (id == null)
            {
                return false;
            }
            if ((this.hasHigh != id.hasHigh) || (this.hasHigh && !this.high_.Equals(id.high_)))
            {
                return false;
            }
            return ((this.hasLow == id.hasLow) && (!this.hasLow || this.low_.Equals(id.low_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasHigh)
            {
                hashCode ^= this.high_.GetHashCode();
            }
            if (this.hasLow)
            {
                hashCode ^= this.low_.GetHashCode();
            }
            return hashCode;
        }

        private EntityId MakeReadOnly()
        {
            return this;
        }

        public static EntityId ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static EntityId ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static EntityId ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static EntityId ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static EntityId ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static EntityId ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static EntityId ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static EntityId ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static EntityId ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static EntityId ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<EntityId, Builder>.PrintField("high", this.hasHigh, this.high_, writer);
            GeneratedMessageLite<EntityId, Builder>.PrintField("low", this.hasLow, this.low_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _entityIdFieldNames;
            if (this.hasHigh)
            {
                output.WriteFixed64(1, strArray[0], this.High);
            }
            if (this.hasLow)
            {
                output.WriteFixed64(2, strArray[1], this.Low);
            }
        }

        public static EntityId DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override EntityId DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasHigh
        {
            get
            {
                return this.hasHigh;
            }
        }

        public bool HasLow
        {
            get
            {
                return this.hasLow;
            }
        }

        [CLSCompliant(false)]
        public ulong High
        {
            get
            {
                return this.high_;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasHigh)
                {
                    return false;
                }
                if (!this.hasLow)
                {
                    return false;
                }
                return true;
            }
        }

        [CLSCompliant(false)]
        public ulong Low
        {
            get
            {
                return this.low_;
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
                    if (this.hasHigh)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed64Size(1, this.High);
                    }
                    if (this.hasLow)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed64Size(2, this.Low);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override EntityId ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<EntityId, EntityId.Builder>
        {
            private EntityId result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = EntityId.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(EntityId cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override EntityId BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override EntityId.Builder Clear()
            {
                this.result = EntityId.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public EntityId.Builder ClearHigh()
            {
                this.PrepareBuilder();
                this.result.hasHigh = false;
                this.result.high_ = 0L;
                return this;
            }

            public EntityId.Builder ClearLow()
            {
                this.PrepareBuilder();
                this.result.hasLow = false;
                this.result.low_ = 0L;
                return this;
            }

            public override EntityId.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new EntityId.Builder(this.result);
                }
                return new EntityId.Builder().MergeFrom(this.result);
            }

            public override EntityId.Builder MergeFrom(EntityId other)
            {
                if (other != EntityId.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasHigh)
                    {
                        this.High = other.High;
                    }
                    if (other.HasLow)
                    {
                        this.Low = other.Low;
                    }
                }
                return this;
            }

            public override EntityId.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override EntityId.Builder MergeFrom(IMessageLite other)
            {
                if (other is EntityId)
                {
                    return this.MergeFrom((EntityId) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override EntityId.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(EntityId._entityIdFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = EntityId._entityIdFieldTags[index];
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
                            this.result.hasHigh = input.ReadFixed64(ref this.result.high_);
                            continue;
                        }
                        case 0x11:
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
                    this.result.hasLow = input.ReadFixed64(ref this.result.low_);
                }
                return this;
            }

            private EntityId PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    EntityId result = this.result;
                    this.result = new EntityId();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public EntityId.Builder SetHigh(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasHigh = true;
                this.result.high_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public EntityId.Builder SetLow(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasLow = true;
                this.result.low_ = value;
                return this;
            }

            public override EntityId DefaultInstanceForType
            {
                get
                {
                    return EntityId.DefaultInstance;
                }
            }

            public bool HasHigh
            {
                get
                {
                    return this.result.hasHigh;
                }
            }

            public bool HasLow
            {
                get
                {
                    return this.result.hasLow;
                }
            }

            [CLSCompliant(false)]
            public ulong High
            {
                get
                {
                    return this.result.High;
                }
                set
                {
                    this.SetHigh(value);
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
            public ulong Low
            {
                get
                {
                    return this.result.Low;
                }
                set
                {
                    this.SetLow(value);
                }
            }

            protected override EntityId MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override EntityId.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

