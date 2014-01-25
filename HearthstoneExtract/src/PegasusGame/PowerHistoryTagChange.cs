namespace PegasusGame
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class PowerHistoryTagChange : GeneratedMessageLite<PowerHistoryTagChange, Builder>
    {
        private static readonly string[] _powerHistoryTagChangeFieldNames = new string[] { "entity", "tag", "value" };
        private static readonly uint[] _powerHistoryTagChangeFieldTags = new uint[] { 8, 0x10, 0x18 };
        private static readonly PowerHistoryTagChange defaultInstance = new PowerHistoryTagChange().MakeReadOnly();
        private int entity_;
        public const int EntityFieldNumber = 1;
        private bool hasEntity;
        private bool hasTag;
        private bool hasValue;
        private int memoizedSerializedSize = -1;
        private int tag_;
        public const int TagFieldNumber = 2;
        private int value_;
        public const int ValueFieldNumber = 3;

        static PowerHistoryTagChange()
        {
            object.ReferenceEquals(PegasusGamelite.Descriptor, null);
        }

        private PowerHistoryTagChange()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(PowerHistoryTagChange prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            PowerHistoryTagChange change = obj as PowerHistoryTagChange;
            if (change == null)
            {
                return false;
            }
            if ((this.hasEntity != change.hasEntity) || (this.hasEntity && !this.entity_.Equals(change.entity_)))
            {
                return false;
            }
            if ((this.hasTag != change.hasTag) || (this.hasTag && !this.tag_.Equals(change.tag_)))
            {
                return false;
            }
            return ((this.hasValue == change.hasValue) && (!this.hasValue || this.value_.Equals(change.value_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasEntity)
            {
                hashCode ^= this.entity_.GetHashCode();
            }
            if (this.hasTag)
            {
                hashCode ^= this.tag_.GetHashCode();
            }
            if (this.hasValue)
            {
                hashCode ^= this.value_.GetHashCode();
            }
            return hashCode;
        }

        private PowerHistoryTagChange MakeReadOnly()
        {
            return this;
        }

        public static PowerHistoryTagChange ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static PowerHistoryTagChange ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static PowerHistoryTagChange ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PowerHistoryTagChange ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PowerHistoryTagChange ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PowerHistoryTagChange ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PowerHistoryTagChange ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static PowerHistoryTagChange ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PowerHistoryTagChange ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PowerHistoryTagChange ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<PowerHistoryTagChange, Builder>.PrintField("entity", this.hasEntity, this.entity_, writer);
            GeneratedMessageLite<PowerHistoryTagChange, Builder>.PrintField("tag", this.hasTag, this.tag_, writer);
            GeneratedMessageLite<PowerHistoryTagChange, Builder>.PrintField("value", this.hasValue, this.value_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _powerHistoryTagChangeFieldNames;
            if (this.hasEntity)
            {
                output.WriteInt32(1, strArray[0], this.Entity);
            }
            if (this.hasTag)
            {
                output.WriteInt32(2, strArray[1], this.Tag);
            }
            if (this.hasValue)
            {
                output.WriteInt32(3, strArray[2], this.Value);
            }
        }

        public static PowerHistoryTagChange DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override PowerHistoryTagChange DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public int Entity
        {
            get
            {
                return this.entity_;
            }
        }

        public bool HasEntity
        {
            get
            {
                return this.hasEntity;
            }
        }

        public bool HasTag
        {
            get
            {
                return this.hasTag;
            }
        }

        public bool HasValue
        {
            get
            {
                return this.hasValue;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasEntity)
                {
                    return false;
                }
                if (!this.hasTag)
                {
                    return false;
                }
                if (!this.hasValue)
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
                    if (this.hasEntity)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.Entity);
                    }
                    if (this.hasTag)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.Tag);
                    }
                    if (this.hasValue)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(3, this.Value);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        public int Tag
        {
            get
            {
                return this.tag_;
            }
        }

        protected override PowerHistoryTagChange ThisMessage
        {
            get
            {
                return this;
            }
        }

        public int Value
        {
            get
            {
                return this.value_;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<PowerHistoryTagChange, PowerHistoryTagChange.Builder>
        {
            private PowerHistoryTagChange result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = PowerHistoryTagChange.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(PowerHistoryTagChange cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override PowerHistoryTagChange BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override PowerHistoryTagChange.Builder Clear()
            {
                this.result = PowerHistoryTagChange.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public PowerHistoryTagChange.Builder ClearEntity()
            {
                this.PrepareBuilder();
                this.result.hasEntity = false;
                this.result.entity_ = 0;
                return this;
            }

            public PowerHistoryTagChange.Builder ClearTag()
            {
                this.PrepareBuilder();
                this.result.hasTag = false;
                this.result.tag_ = 0;
                return this;
            }

            public PowerHistoryTagChange.Builder ClearValue()
            {
                this.PrepareBuilder();
                this.result.hasValue = false;
                this.result.value_ = 0;
                return this;
            }

            public override PowerHistoryTagChange.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new PowerHistoryTagChange.Builder(this.result);
                }
                return new PowerHistoryTagChange.Builder().MergeFrom(this.result);
            }

            public override PowerHistoryTagChange.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override PowerHistoryTagChange.Builder MergeFrom(IMessageLite other)
            {
                if (other is PowerHistoryTagChange)
                {
                    return this.MergeFrom((PowerHistoryTagChange) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override PowerHistoryTagChange.Builder MergeFrom(PowerHistoryTagChange other)
            {
                if (other != PowerHistoryTagChange.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasEntity)
                    {
                        this.Entity = other.Entity;
                    }
                    if (other.HasTag)
                    {
                        this.Tag = other.Tag;
                    }
                    if (other.HasValue)
                    {
                        this.Value = other.Value;
                    }
                }
                return this;
            }

            public override PowerHistoryTagChange.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(PowerHistoryTagChange._powerHistoryTagChangeFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = PowerHistoryTagChange._powerHistoryTagChangeFieldTags[index];
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
                            this.result.hasEntity = input.ReadInt32(ref this.result.entity_);
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasTag = input.ReadInt32(ref this.result.tag_);
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
                    this.result.hasValue = input.ReadInt32(ref this.result.value_);
                }
                return this;
            }

            private PowerHistoryTagChange PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    PowerHistoryTagChange result = this.result;
                    this.result = new PowerHistoryTagChange();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public PowerHistoryTagChange.Builder SetEntity(int value)
            {
                this.PrepareBuilder();
                this.result.hasEntity = true;
                this.result.entity_ = value;
                return this;
            }

            public PowerHistoryTagChange.Builder SetTag(int value)
            {
                this.PrepareBuilder();
                this.result.hasTag = true;
                this.result.tag_ = value;
                return this;
            }

            public PowerHistoryTagChange.Builder SetValue(int value)
            {
                this.PrepareBuilder();
                this.result.hasValue = true;
                this.result.value_ = value;
                return this;
            }

            public override PowerHistoryTagChange DefaultInstanceForType
            {
                get
                {
                    return PowerHistoryTagChange.DefaultInstance;
                }
            }

            public int Entity
            {
                get
                {
                    return this.result.Entity;
                }
                set
                {
                    this.SetEntity(value);
                }
            }

            public bool HasEntity
            {
                get
                {
                    return this.result.hasEntity;
                }
            }

            public bool HasTag
            {
                get
                {
                    return this.result.hasTag;
                }
            }

            public bool HasValue
            {
                get
                {
                    return this.result.hasValue;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override PowerHistoryTagChange MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int Tag
            {
                get
                {
                    return this.result.Tag;
                }
                set
                {
                    this.SetTag(value);
                }
            }

            protected override PowerHistoryTagChange.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public int Value
            {
                get
                {
                    return this.result.Value;
                }
                set
                {
                    this.SetValue(value);
                }
            }
        }
    }
}

