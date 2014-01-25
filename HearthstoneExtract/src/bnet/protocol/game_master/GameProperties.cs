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

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class GameProperties : GeneratedMessageLite<GameProperties, Builder>
    {
        private static readonly string[] _gamePropertiesFieldNames = new string[] { "create", "creation_attributes", "filter", "open", "program_id" };
        private static readonly uint[] _gamePropertiesFieldTags = new uint[] { 0x18, 10, 0x12, 0x20, 0x2d };
        private bool create_;
        public const int CreateFieldNumber = 3;
        private PopsicleList<bnet.protocol.game_master.Attribute> creationAttributes_ = new PopsicleList<bnet.protocol.game_master.Attribute>();
        public const int CreationAttributesFieldNumber = 1;
        private static readonly GameProperties defaultInstance = new GameProperties().MakeReadOnly();
        private AttributeFilter filter_;
        public const int FilterFieldNumber = 2;
        private bool hasCreate;
        private bool hasFilter;
        private bool hasOpen;
        private bool hasProgramId;
        private int memoizedSerializedSize = -1;
        private bool open_ = true;
        public const int OpenFieldNumber = 4;
        private uint programId_;
        public const int ProgramIdFieldNumber = 5;

        static GameProperties()
        {
            object.ReferenceEquals(GameMaster.Descriptor, null);
        }

        private GameProperties()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GameProperties prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GameProperties properties = obj as GameProperties;
            if (properties == null)
            {
                return false;
            }
            if (this.creationAttributes_.Count != properties.creationAttributes_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.creationAttributes_.Count; i++)
            {
                if (!this.creationAttributes_[i].Equals(properties.creationAttributes_[i]))
                {
                    return false;
                }
            }
            if ((this.hasFilter != properties.hasFilter) || (this.hasFilter && !this.filter_.Equals(properties.filter_)))
            {
                return false;
            }
            if ((this.hasCreate != properties.hasCreate) || (this.hasCreate && !this.create_.Equals(properties.create_)))
            {
                return false;
            }
            if ((this.hasOpen != properties.hasOpen) || (this.hasOpen && !this.open_.Equals(properties.open_)))
            {
                return false;
            }
            return ((this.hasProgramId == properties.hasProgramId) && (!this.hasProgramId || this.programId_.Equals(properties.programId_)));
        }

        public bnet.protocol.game_master.Attribute GetCreationAttributes(int index)
        {
            return this.creationAttributes_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<bnet.protocol.game_master.Attribute> enumerator = this.creationAttributes_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    bnet.protocol.game_master.Attribute current = enumerator.Current;
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
            if (this.hasFilter)
            {
                hashCode ^= this.filter_.GetHashCode();
            }
            if (this.hasCreate)
            {
                hashCode ^= this.create_.GetHashCode();
            }
            if (this.hasOpen)
            {
                hashCode ^= this.open_.GetHashCode();
            }
            if (this.hasProgramId)
            {
                hashCode ^= this.programId_.GetHashCode();
            }
            return hashCode;
        }

        private GameProperties MakeReadOnly()
        {
            this.creationAttributes_.MakeReadOnly();
            return this;
        }

        public static GameProperties ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GameProperties ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameProperties ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GameProperties ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GameProperties ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GameProperties ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GameProperties ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GameProperties ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameProperties ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameProperties ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GameProperties, Builder>.PrintField<bnet.protocol.game_master.Attribute>("creation_attributes", this.creationAttributes_, writer);
            GeneratedMessageLite<GameProperties, Builder>.PrintField("filter", this.hasFilter, this.filter_, writer);
            GeneratedMessageLite<GameProperties, Builder>.PrintField("create", this.hasCreate, this.create_, writer);
            GeneratedMessageLite<GameProperties, Builder>.PrintField("open", this.hasOpen, this.open_, writer);
            GeneratedMessageLite<GameProperties, Builder>.PrintField("program_id", this.hasProgramId, this.programId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _gamePropertiesFieldNames;
            if (this.creationAttributes_.Count > 0)
            {
                output.WriteMessageArray<bnet.protocol.game_master.Attribute>(1, strArray[1], this.creationAttributes_);
            }
            if (this.hasFilter)
            {
                output.WriteMessage(2, strArray[2], this.Filter);
            }
            if (this.hasCreate)
            {
                output.WriteBool(3, strArray[0], this.Create);
            }
            if (this.hasOpen)
            {
                output.WriteBool(4, strArray[3], this.Open);
            }
            if (this.hasProgramId)
            {
                output.WriteFixed32(5, strArray[4], this.ProgramId);
            }
        }

        public bool Create
        {
            get
            {
                return this.create_;
            }
        }

        public int CreationAttributesCount
        {
            get
            {
                return this.creationAttributes_.Count;
            }
        }

        public IList<bnet.protocol.game_master.Attribute> CreationAttributesList
        {
            get
            {
                return this.creationAttributes_;
            }
        }

        public static GameProperties DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GameProperties DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
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

        public bool HasCreate
        {
            get
            {
                return this.hasCreate;
            }
        }

        public bool HasFilter
        {
            get
            {
                return this.hasFilter;
            }
        }

        public bool HasOpen
        {
            get
            {
                return this.hasOpen;
            }
        }

        public bool HasProgramId
        {
            get
            {
                return this.hasProgramId;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                IEnumerator<bnet.protocol.game_master.Attribute> enumerator = this.CreationAttributesList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        bnet.protocol.game_master.Attribute current = enumerator.Current;
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
                if (this.HasFilter && !this.Filter.IsInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        public bool Open
        {
            get
            {
                return this.open_;
            }
        }

        [CLSCompliant(false)]
        public uint ProgramId
        {
            get
            {
                return this.programId_;
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
                    IEnumerator<bnet.protocol.game_master.Attribute> enumerator = this.CreationAttributesList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            bnet.protocol.game_master.Attribute current = enumerator.Current;
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
                    if (this.hasFilter)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, this.Filter);
                    }
                    if (this.hasCreate)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(3, this.Create);
                    }
                    if (this.hasOpen)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(4, this.Open);
                    }
                    if (this.hasProgramId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed32Size(5, this.ProgramId);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override GameProperties ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<GameProperties, GameProperties.Builder>
        {
            private GameProperties result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GameProperties.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GameProperties cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public GameProperties.Builder AddCreationAttributes(bnet.protocol.game_master.Attribute value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.creationAttributes_.Add(value);
                return this;
            }

            public GameProperties.Builder AddCreationAttributes(bnet.protocol.game_master.Attribute.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.creationAttributes_.Add(builderForValue.Build());
                return this;
            }

            public GameProperties.Builder AddRangeCreationAttributes(IEnumerable<bnet.protocol.game_master.Attribute> values)
            {
                this.PrepareBuilder();
                this.result.creationAttributes_.Add(values);
                return this;
            }

            public override GameProperties BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GameProperties.Builder Clear()
            {
                this.result = GameProperties.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GameProperties.Builder ClearCreate()
            {
                this.PrepareBuilder();
                this.result.hasCreate = false;
                this.result.create_ = false;
                return this;
            }

            public GameProperties.Builder ClearCreationAttributes()
            {
                this.PrepareBuilder();
                this.result.creationAttributes_.Clear();
                return this;
            }

            public GameProperties.Builder ClearFilter()
            {
                this.PrepareBuilder();
                this.result.hasFilter = false;
                this.result.filter_ = null;
                return this;
            }

            public GameProperties.Builder ClearOpen()
            {
                this.PrepareBuilder();
                this.result.hasOpen = false;
                this.result.open_ = true;
                return this;
            }

            public GameProperties.Builder ClearProgramId()
            {
                this.PrepareBuilder();
                this.result.hasProgramId = false;
                this.result.programId_ = 0;
                return this;
            }

            public override GameProperties.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GameProperties.Builder(this.result);
                }
                return new GameProperties.Builder().MergeFrom(this.result);
            }

            public bnet.protocol.game_master.Attribute GetCreationAttributes(int index)
            {
                return this.result.GetCreationAttributes(index);
            }

            public GameProperties.Builder MergeFilter(AttributeFilter value)
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

            public override GameProperties.Builder MergeFrom(GameProperties other)
            {
                if (other != GameProperties.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.creationAttributes_.Count != 0)
                    {
                        this.result.creationAttributes_.Add(other.creationAttributes_);
                    }
                    if (other.HasFilter)
                    {
                        this.MergeFilter(other.Filter);
                    }
                    if (other.HasCreate)
                    {
                        this.Create = other.Create;
                    }
                    if (other.HasOpen)
                    {
                        this.Open = other.Open;
                    }
                    if (other.HasProgramId)
                    {
                        this.ProgramId = other.ProgramId;
                    }
                }
                return this;
            }

            public override GameProperties.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GameProperties.Builder MergeFrom(IMessageLite other)
            {
                if (other is GameProperties)
                {
                    return this.MergeFrom((GameProperties) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GameProperties.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GameProperties._gamePropertiesFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GameProperties._gamePropertiesFieldTags[index];
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
                            input.ReadMessageArray<bnet.protocol.game_master.Attribute>(num, str, this.result.creationAttributes_, bnet.protocol.game_master.Attribute.DefaultInstance, extensionRegistry);
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
                        case 0x18:
                        {
                            this.result.hasCreate = input.ReadBool(ref this.result.create_);
                            continue;
                        }
                        case 0x20:
                        {
                            this.result.hasOpen = input.ReadBool(ref this.result.open_);
                            continue;
                        }
                        case 0x2d:
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
                    this.result.hasProgramId = input.ReadFixed32(ref this.result.programId_);
                }
                return this;
            }

            private GameProperties PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GameProperties result = this.result;
                    this.result = new GameProperties();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public GameProperties.Builder SetCreate(bool value)
            {
                this.PrepareBuilder();
                this.result.hasCreate = true;
                this.result.create_ = value;
                return this;
            }

            public GameProperties.Builder SetCreationAttributes(int index, bnet.protocol.game_master.Attribute value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.creationAttributes_[index] = value;
                return this;
            }

            public GameProperties.Builder SetCreationAttributes(int index, bnet.protocol.game_master.Attribute.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.creationAttributes_[index] = builderForValue.Build();
                return this;
            }

            public GameProperties.Builder SetFilter(AttributeFilter value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasFilter = true;
                this.result.filter_ = value;
                return this;
            }

            public GameProperties.Builder SetFilter(AttributeFilter.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasFilter = true;
                this.result.filter_ = builderForValue.Build();
                return this;
            }

            public GameProperties.Builder SetOpen(bool value)
            {
                this.PrepareBuilder();
                this.result.hasOpen = true;
                this.result.open_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public GameProperties.Builder SetProgramId(uint value)
            {
                this.PrepareBuilder();
                this.result.hasProgramId = true;
                this.result.programId_ = value;
                return this;
            }

            public bool Create
            {
                get
                {
                    return this.result.Create;
                }
                set
                {
                    this.SetCreate(value);
                }
            }

            public int CreationAttributesCount
            {
                get
                {
                    return this.result.CreationAttributesCount;
                }
            }

            public IPopsicleList<bnet.protocol.game_master.Attribute> CreationAttributesList
            {
                get
                {
                    return this.PrepareBuilder().creationAttributes_;
                }
            }

            public override GameProperties DefaultInstanceForType
            {
                get
                {
                    return GameProperties.DefaultInstance;
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

            public bool HasCreate
            {
                get
                {
                    return this.result.hasCreate;
                }
            }

            public bool HasFilter
            {
                get
                {
                    return this.result.hasFilter;
                }
            }

            public bool HasOpen
            {
                get
                {
                    return this.result.hasOpen;
                }
            }

            public bool HasProgramId
            {
                get
                {
                    return this.result.hasProgramId;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override GameProperties MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public bool Open
            {
                get
                {
                    return this.result.Open;
                }
                set
                {
                    this.SetOpen(value);
                }
            }

            [CLSCompliant(false)]
            public uint ProgramId
            {
                get
                {
                    return this.result.ProgramId;
                }
                set
                {
                    this.SetProgramId(value);
                }
            }

            protected override GameProperties.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

