namespace PegasusGame
{
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class PowerHistoryEntity : GeneratedMessageLite<PowerHistoryEntity, Builder>
    {
        private static readonly string[] _powerHistoryEntityFieldNames = new string[] { "entity", "name", "tags" };
        private static readonly uint[] _powerHistoryEntityFieldTags = new uint[] { 8, 0x12, 0x1a };
        private static readonly PowerHistoryEntity defaultInstance = new PowerHistoryEntity().MakeReadOnly();
        private int entity_;
        public const int EntityFieldNumber = 1;
        private bool hasEntity;
        private bool hasName;
        private int memoizedSerializedSize = -1;
        private string name_ = string.Empty;
        public const int NameFieldNumber = 2;
        private PopsicleList<Tag> tags_ = new PopsicleList<Tag>();
        public const int TagsFieldNumber = 3;

        static PowerHistoryEntity()
        {
            object.ReferenceEquals(PegasusGamelite.Descriptor, null);
        }

        private PowerHistoryEntity()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(PowerHistoryEntity prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            PowerHistoryEntity entity = obj as PowerHistoryEntity;
            if (entity == null)
            {
                return false;
            }
            if ((this.hasEntity != entity.hasEntity) || (this.hasEntity && !this.entity_.Equals(entity.entity_)))
            {
                return false;
            }
            if ((this.hasName != entity.hasName) || (this.hasName && !this.name_.Equals(entity.name_)))
            {
                return false;
            }
            if (this.tags_.Count != entity.tags_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.tags_.Count; i++)
            {
                if (!this.tags_[i].Equals(entity.tags_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasEntity)
            {
                hashCode ^= this.entity_.GetHashCode();
            }
            if (this.hasName)
            {
                hashCode ^= this.name_.GetHashCode();
            }
            IEnumerator<Tag> enumerator = this.tags_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    Tag current = enumerator.Current;
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

        public Tag GetTags(int index)
        {
            return this.tags_[index];
        }

        private PowerHistoryEntity MakeReadOnly()
        {
            this.tags_.MakeReadOnly();
            return this;
        }

        public static PowerHistoryEntity ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static PowerHistoryEntity ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static PowerHistoryEntity ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PowerHistoryEntity ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PowerHistoryEntity ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PowerHistoryEntity ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PowerHistoryEntity ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static PowerHistoryEntity ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PowerHistoryEntity ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PowerHistoryEntity ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<PowerHistoryEntity, Builder>.PrintField("entity", this.hasEntity, this.entity_, writer);
            GeneratedMessageLite<PowerHistoryEntity, Builder>.PrintField("name", this.hasName, this.name_, writer);
            GeneratedMessageLite<PowerHistoryEntity, Builder>.PrintField<Tag>("tags", this.tags_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _powerHistoryEntityFieldNames;
            if (this.hasEntity)
            {
                output.WriteInt32(1, strArray[0], this.Entity);
            }
            if (this.hasName)
            {
                output.WriteString(2, strArray[1], this.Name);
            }
            if (this.tags_.Count > 0)
            {
                output.WriteMessageArray<Tag>(3, strArray[2], this.tags_);
            }
        }

        public static PowerHistoryEntity DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override PowerHistoryEntity DefaultInstanceForType
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

        public bool HasName
        {
            get
            {
                return this.hasName;
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
                if (!this.hasName)
                {
                    return false;
                }
                IEnumerator<Tag> enumerator = this.TagsList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        Tag current = enumerator.Current;
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

        public string Name
        {
            get
            {
                return this.name_;
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
                    if (this.hasName)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(2, this.Name);
                    }
                    IEnumerator<Tag> enumerator = this.TagsList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            Tag current = enumerator.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(3, current);
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

        public int TagsCount
        {
            get
            {
                return this.tags_.Count;
            }
        }

        public IList<Tag> TagsList
        {
            get
            {
                return this.tags_;
            }
        }

        protected override PowerHistoryEntity ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<PowerHistoryEntity, PowerHistoryEntity.Builder>
        {
            private PowerHistoryEntity result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = PowerHistoryEntity.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(PowerHistoryEntity cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public PowerHistoryEntity.Builder AddRangeTags(IEnumerable<Tag> values)
            {
                this.PrepareBuilder();
                this.result.tags_.Add(values);
                return this;
            }

            public PowerHistoryEntity.Builder AddTags(Tag value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.tags_.Add(value);
                return this;
            }

            public PowerHistoryEntity.Builder AddTags(Tag.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.tags_.Add(builderForValue.Build());
                return this;
            }

            public override PowerHistoryEntity BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override PowerHistoryEntity.Builder Clear()
            {
                this.result = PowerHistoryEntity.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public PowerHistoryEntity.Builder ClearEntity()
            {
                this.PrepareBuilder();
                this.result.hasEntity = false;
                this.result.entity_ = 0;
                return this;
            }

            public PowerHistoryEntity.Builder ClearName()
            {
                this.PrepareBuilder();
                this.result.hasName = false;
                this.result.name_ = string.Empty;
                return this;
            }

            public PowerHistoryEntity.Builder ClearTags()
            {
                this.PrepareBuilder();
                this.result.tags_.Clear();
                return this;
            }

            public override PowerHistoryEntity.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new PowerHistoryEntity.Builder(this.result);
                }
                return new PowerHistoryEntity.Builder().MergeFrom(this.result);
            }

            public Tag GetTags(int index)
            {
                return this.result.GetTags(index);
            }

            public override PowerHistoryEntity.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override PowerHistoryEntity.Builder MergeFrom(IMessageLite other)
            {
                if (other is PowerHistoryEntity)
                {
                    return this.MergeFrom((PowerHistoryEntity) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override PowerHistoryEntity.Builder MergeFrom(PowerHistoryEntity other)
            {
                if (other != PowerHistoryEntity.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasEntity)
                    {
                        this.Entity = other.Entity;
                    }
                    if (other.HasName)
                    {
                        this.Name = other.Name;
                    }
                    if (other.tags_.Count != 0)
                    {
                        this.result.tags_.Add(other.tags_);
                    }
                }
                return this;
            }

            public override PowerHistoryEntity.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(PowerHistoryEntity._powerHistoryEntityFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = PowerHistoryEntity._powerHistoryEntityFieldTags[index];
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
                        case 0x12:
                        {
                            this.result.hasName = input.ReadString(ref this.result.name_);
                            continue;
                        }
                        case 0x1a:
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
                    input.ReadMessageArray<Tag>(num, str, this.result.tags_, Tag.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private PowerHistoryEntity PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    PowerHistoryEntity result = this.result;
                    this.result = new PowerHistoryEntity();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public PowerHistoryEntity.Builder SetEntity(int value)
            {
                this.PrepareBuilder();
                this.result.hasEntity = true;
                this.result.entity_ = value;
                return this;
            }

            public PowerHistoryEntity.Builder SetName(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasName = true;
                this.result.name_ = value;
                return this;
            }

            public PowerHistoryEntity.Builder SetTags(int index, Tag value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.tags_[index] = value;
                return this;
            }

            public PowerHistoryEntity.Builder SetTags(int index, Tag.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.tags_[index] = builderForValue.Build();
                return this;
            }

            public override PowerHistoryEntity DefaultInstanceForType
            {
                get
                {
                    return PowerHistoryEntity.DefaultInstance;
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

            public bool HasName
            {
                get
                {
                    return this.result.hasName;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override PowerHistoryEntity MessageBeingBuilt
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

            public int TagsCount
            {
                get
                {
                    return this.result.TagsCount;
                }
            }

            public IPopsicleList<Tag> TagsList
            {
                get
                {
                    return this.PrepareBuilder().tags_;
                }
            }

            protected override PowerHistoryEntity.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

