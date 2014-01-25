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

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class Entity : GeneratedMessageLite<Entity, Builder>
    {
        private static readonly string[] _entityFieldNames = new string[] { "id", "tags" };
        private static readonly uint[] _entityFieldTags = new uint[] { 8, 0x12 };
        private static readonly Entity defaultInstance = new Entity().MakeReadOnly();
        private bool hasId;
        private int id_;
        public const int IdFieldNumber = 1;
        private int memoizedSerializedSize = -1;
        private PopsicleList<Tag> tags_ = new PopsicleList<Tag>();
        public const int TagsFieldNumber = 2;

        static Entity()
        {
            object.ReferenceEquals(PegasusGamelite.Descriptor, null);
        }

        private Entity()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(Entity prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            Entity entity = obj as Entity;
            if (entity == null)
            {
                return false;
            }
            if ((this.hasId != entity.hasId) || (this.hasId && !this.id_.Equals(entity.id_)))
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
            if (this.hasId)
            {
                hashCode ^= this.id_.GetHashCode();
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

        private Entity MakeReadOnly()
        {
            this.tags_.MakeReadOnly();
            return this;
        }

        public static Entity ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static Entity ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static Entity ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Entity ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Entity ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Entity ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Entity ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static Entity ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Entity ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Entity ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<Entity, Builder>.PrintField("id", this.hasId, this.id_, writer);
            GeneratedMessageLite<Entity, Builder>.PrintField<Tag>("tags", this.tags_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _entityFieldNames;
            if (this.hasId)
            {
                output.WriteInt32(1, strArray[0], this.Id);
            }
            if (this.tags_.Count > 0)
            {
                output.WriteMessageArray<Tag>(2, strArray[1], this.tags_);
            }
        }

        public static Entity DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override Entity DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasId
        {
            get
            {
                return this.hasId;
            }
        }

        public int Id
        {
            get
            {
                return this.id_;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasId)
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

        public override int SerializedSize
        {
            get
            {
                int memoizedSerializedSize = this.memoizedSerializedSize;
                if (memoizedSerializedSize == -1)
                {
                    memoizedSerializedSize = 0;
                    if (this.hasId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.Id);
                    }
                    IEnumerator<Tag> enumerator = this.TagsList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            Tag current = enumerator.Current;
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

        protected override Entity ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<Entity, Entity.Builder>
        {
            private Entity result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = Entity.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(Entity cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public Entity.Builder AddRangeTags(IEnumerable<Tag> values)
            {
                this.PrepareBuilder();
                this.result.tags_.Add(values);
                return this;
            }

            public Entity.Builder AddTags(Tag value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.tags_.Add(value);
                return this;
            }

            public Entity.Builder AddTags(Tag.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.tags_.Add(builderForValue.Build());
                return this;
            }

            public override Entity BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override Entity.Builder Clear()
            {
                this.result = Entity.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public Entity.Builder ClearId()
            {
                this.PrepareBuilder();
                this.result.hasId = false;
                this.result.id_ = 0;
                return this;
            }

            public Entity.Builder ClearTags()
            {
                this.PrepareBuilder();
                this.result.tags_.Clear();
                return this;
            }

            public override Entity.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new Entity.Builder(this.result);
                }
                return new Entity.Builder().MergeFrom(this.result);
            }

            public Tag GetTags(int index)
            {
                return this.result.GetTags(index);
            }

            public override Entity.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override Entity.Builder MergeFrom(IMessageLite other)
            {
                if (other is Entity)
                {
                    return this.MergeFrom((Entity) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override Entity.Builder MergeFrom(Entity other)
            {
                if (other != Entity.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasId)
                    {
                        this.Id = other.Id;
                    }
                    if (other.tags_.Count != 0)
                    {
                        this.result.tags_.Add(other.tags_);
                    }
                }
                return this;
            }

            public override Entity.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(Entity._entityFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = Entity._entityFieldTags[index];
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
                            this.result.hasId = input.ReadInt32(ref this.result.id_);
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
                    input.ReadMessageArray<Tag>(num, str, this.result.tags_, Tag.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private Entity PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    Entity result = this.result;
                    this.result = new Entity();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public Entity.Builder SetId(int value)
            {
                this.PrepareBuilder();
                this.result.hasId = true;
                this.result.id_ = value;
                return this;
            }

            public Entity.Builder SetTags(int index, Tag value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.tags_[index] = value;
                return this;
            }

            public Entity.Builder SetTags(int index, Tag.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.tags_[index] = builderForValue.Build();
                return this;
            }

            public override Entity DefaultInstanceForType
            {
                get
                {
                    return Entity.DefaultInstance;
                }
            }

            public bool HasId
            {
                get
                {
                    return this.result.hasId;
                }
            }

            public int Id
            {
                get
                {
                    return this.result.Id;
                }
                set
                {
                    this.SetId(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override Entity MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
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

            protected override Entity.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

