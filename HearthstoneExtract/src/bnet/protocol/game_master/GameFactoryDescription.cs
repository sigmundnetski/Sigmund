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
    public sealed class GameFactoryDescription : GeneratedMessageLite<GameFactoryDescription, Builder>
    {
        private static readonly string[] _gameFactoryDescriptionFieldNames = new string[] { "allow_queueing", "attribute", "id", "name", "stats_bucket", "unseeded_id" };
        private static readonly uint[] _gameFactoryDescriptionFieldTags = new uint[] { 0x30, 0x1a, 9, 0x12, 0x22, 0x29 };
        private bool allowQueueing_ = true;
        public const int AllowQueueingFieldNumber = 6;
        private PopsicleList<bnet.protocol.game_master.Attribute> attribute_ = new PopsicleList<bnet.protocol.game_master.Attribute>();
        public const int AttributeFieldNumber = 3;
        private static readonly GameFactoryDescription defaultInstance = new GameFactoryDescription().MakeReadOnly();
        private bool hasAllowQueueing;
        private bool hasId;
        private bool hasName;
        private bool hasUnseededId;
        private ulong id_;
        public const int IdFieldNumber = 1;
        private int memoizedSerializedSize = -1;
        private string name_ = string.Empty;
        public const int NameFieldNumber = 2;
        private PopsicleList<GameStatsBucket> statsBucket_ = new PopsicleList<GameStatsBucket>();
        public const int StatsBucketFieldNumber = 4;
        private ulong unseededId_;
        public const int UnseededIdFieldNumber = 5;

        static GameFactoryDescription()
        {
            object.ReferenceEquals(GameMaster.Descriptor, null);
        }

        private GameFactoryDescription()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GameFactoryDescription prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GameFactoryDescription description = obj as GameFactoryDescription;
            if (description == null)
            {
                return false;
            }
            if ((this.hasId != description.hasId) || (this.hasId && !this.id_.Equals(description.id_)))
            {
                return false;
            }
            if ((this.hasName != description.hasName) || (this.hasName && !this.name_.Equals(description.name_)))
            {
                return false;
            }
            if (this.attribute_.Count != description.attribute_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.attribute_.Count; i++)
            {
                if (!this.attribute_[i].Equals(description.attribute_[i]))
                {
                    return false;
                }
            }
            if (this.statsBucket_.Count != description.statsBucket_.Count)
            {
                return false;
            }
            for (int j = 0; j < this.statsBucket_.Count; j++)
            {
                if (!this.statsBucket_[j].Equals(description.statsBucket_[j]))
                {
                    return false;
                }
            }
            if ((this.hasUnseededId != description.hasUnseededId) || (this.hasUnseededId && !this.unseededId_.Equals(description.unseededId_)))
            {
                return false;
            }
            return ((this.hasAllowQueueing == description.hasAllowQueueing) && (!this.hasAllowQueueing || this.allowQueueing_.Equals(description.allowQueueing_)));
        }

        public bnet.protocol.game_master.Attribute GetAttribute(int index)
        {
            return this.attribute_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasId)
            {
                hashCode ^= this.id_.GetHashCode();
            }
            if (this.hasName)
            {
                hashCode ^= this.name_.GetHashCode();
            }
            IEnumerator<bnet.protocol.game_master.Attribute> enumerator = this.attribute_.GetEnumerator();
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
            IEnumerator<GameStatsBucket> enumerator2 = this.statsBucket_.GetEnumerator();
            try
            {
                while (enumerator2.MoveNext())
                {
                    GameStatsBucket bucket = enumerator2.Current;
                    hashCode ^= bucket.GetHashCode();
                }
            }
            finally
            {
                if (enumerator2 == null)
                {
                }
                enumerator2.Dispose();
            }
            if (this.hasUnseededId)
            {
                hashCode ^= this.unseededId_.GetHashCode();
            }
            if (this.hasAllowQueueing)
            {
                hashCode ^= this.allowQueueing_.GetHashCode();
            }
            return hashCode;
        }

        public GameStatsBucket GetStatsBucket(int index)
        {
            return this.statsBucket_[index];
        }

        private GameFactoryDescription MakeReadOnly()
        {
            this.attribute_.MakeReadOnly();
            this.statsBucket_.MakeReadOnly();
            return this;
        }

        public static GameFactoryDescription ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GameFactoryDescription ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameFactoryDescription ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GameFactoryDescription ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GameFactoryDescription ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GameFactoryDescription ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GameFactoryDescription ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GameFactoryDescription ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameFactoryDescription ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameFactoryDescription ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GameFactoryDescription, Builder>.PrintField("id", this.hasId, this.id_, writer);
            GeneratedMessageLite<GameFactoryDescription, Builder>.PrintField("name", this.hasName, this.name_, writer);
            GeneratedMessageLite<GameFactoryDescription, Builder>.PrintField<bnet.protocol.game_master.Attribute>("attribute", this.attribute_, writer);
            GeneratedMessageLite<GameFactoryDescription, Builder>.PrintField<GameStatsBucket>("stats_bucket", this.statsBucket_, writer);
            GeneratedMessageLite<GameFactoryDescription, Builder>.PrintField("unseeded_id", this.hasUnseededId, this.unseededId_, writer);
            GeneratedMessageLite<GameFactoryDescription, Builder>.PrintField("allow_queueing", this.hasAllowQueueing, this.allowQueueing_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _gameFactoryDescriptionFieldNames;
            if (this.hasId)
            {
                output.WriteFixed64(1, strArray[2], this.Id);
            }
            if (this.hasName)
            {
                output.WriteString(2, strArray[3], this.Name);
            }
            if (this.attribute_.Count > 0)
            {
                output.WriteMessageArray<bnet.protocol.game_master.Attribute>(3, strArray[1], this.attribute_);
            }
            if (this.statsBucket_.Count > 0)
            {
                output.WriteMessageArray<GameStatsBucket>(4, strArray[4], this.statsBucket_);
            }
            if (this.hasUnseededId)
            {
                output.WriteFixed64(5, strArray[5], this.UnseededId);
            }
            if (this.hasAllowQueueing)
            {
                output.WriteBool(6, strArray[0], this.AllowQueueing);
            }
        }

        public bool AllowQueueing
        {
            get
            {
                return this.allowQueueing_;
            }
        }

        public int AttributeCount
        {
            get
            {
                return this.attribute_.Count;
            }
        }

        public IList<bnet.protocol.game_master.Attribute> AttributeList
        {
            get
            {
                return this.attribute_;
            }
        }

        public static GameFactoryDescription DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GameFactoryDescription DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasAllowQueueing
        {
            get
            {
                return this.hasAllowQueueing;
            }
        }

        public bool HasId
        {
            get
            {
                return this.hasId;
            }
        }

        public bool HasName
        {
            get
            {
                return this.hasName;
            }
        }

        public bool HasUnseededId
        {
            get
            {
                return this.hasUnseededId;
            }
        }

        [CLSCompliant(false)]
        public ulong Id
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
                IEnumerator<bnet.protocol.game_master.Attribute> enumerator = this.AttributeList.GetEnumerator();
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
                    if (this.hasId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed64Size(1, this.Id);
                    }
                    if (this.hasName)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(2, this.Name);
                    }
                    IEnumerator<bnet.protocol.game_master.Attribute> enumerator = this.AttributeList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            bnet.protocol.game_master.Attribute current = enumerator.Current;
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
                    IEnumerator<GameStatsBucket> enumerator2 = this.StatsBucketList.GetEnumerator();
                    try
                    {
                        while (enumerator2.MoveNext())
                        {
                            GameStatsBucket bucket = enumerator2.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(4, bucket);
                        }
                    }
                    finally
                    {
                        if (enumerator2 == null)
                        {
                        }
                        enumerator2.Dispose();
                    }
                    if (this.hasUnseededId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed64Size(5, this.UnseededId);
                    }
                    if (this.hasAllowQueueing)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(6, this.AllowQueueing);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        public int StatsBucketCount
        {
            get
            {
                return this.statsBucket_.Count;
            }
        }

        public IList<GameStatsBucket> StatsBucketList
        {
            get
            {
                return this.statsBucket_;
            }
        }

        protected override GameFactoryDescription ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CLSCompliant(false)]
        public ulong UnseededId
        {
            get
            {
                return this.unseededId_;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<GameFactoryDescription, GameFactoryDescription.Builder>
        {
            private GameFactoryDescription result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GameFactoryDescription.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GameFactoryDescription cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public GameFactoryDescription.Builder AddAttribute(bnet.protocol.game_master.Attribute value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.attribute_.Add(value);
                return this;
            }

            public GameFactoryDescription.Builder AddAttribute(bnet.protocol.game_master.Attribute.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.attribute_.Add(builderForValue.Build());
                return this;
            }

            public GameFactoryDescription.Builder AddRangeAttribute(IEnumerable<bnet.protocol.game_master.Attribute> values)
            {
                this.PrepareBuilder();
                this.result.attribute_.Add(values);
                return this;
            }

            public GameFactoryDescription.Builder AddRangeStatsBucket(IEnumerable<GameStatsBucket> values)
            {
                this.PrepareBuilder();
                this.result.statsBucket_.Add(values);
                return this;
            }

            public GameFactoryDescription.Builder AddStatsBucket(GameStatsBucket value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.statsBucket_.Add(value);
                return this;
            }

            public GameFactoryDescription.Builder AddStatsBucket(GameStatsBucket.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.statsBucket_.Add(builderForValue.Build());
                return this;
            }

            public override GameFactoryDescription BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GameFactoryDescription.Builder Clear()
            {
                this.result = GameFactoryDescription.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GameFactoryDescription.Builder ClearAllowQueueing()
            {
                this.PrepareBuilder();
                this.result.hasAllowQueueing = false;
                this.result.allowQueueing_ = true;
                return this;
            }

            public GameFactoryDescription.Builder ClearAttribute()
            {
                this.PrepareBuilder();
                this.result.attribute_.Clear();
                return this;
            }

            public GameFactoryDescription.Builder ClearId()
            {
                this.PrepareBuilder();
                this.result.hasId = false;
                this.result.id_ = 0L;
                return this;
            }

            public GameFactoryDescription.Builder ClearName()
            {
                this.PrepareBuilder();
                this.result.hasName = false;
                this.result.name_ = string.Empty;
                return this;
            }

            public GameFactoryDescription.Builder ClearStatsBucket()
            {
                this.PrepareBuilder();
                this.result.statsBucket_.Clear();
                return this;
            }

            public GameFactoryDescription.Builder ClearUnseededId()
            {
                this.PrepareBuilder();
                this.result.hasUnseededId = false;
                this.result.unseededId_ = 0L;
                return this;
            }

            public override GameFactoryDescription.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GameFactoryDescription.Builder(this.result);
                }
                return new GameFactoryDescription.Builder().MergeFrom(this.result);
            }

            public bnet.protocol.game_master.Attribute GetAttribute(int index)
            {
                return this.result.GetAttribute(index);
            }

            public GameStatsBucket GetStatsBucket(int index)
            {
                return this.result.GetStatsBucket(index);
            }

            public override GameFactoryDescription.Builder MergeFrom(GameFactoryDescription other)
            {
                if (other != GameFactoryDescription.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasId)
                    {
                        this.Id = other.Id;
                    }
                    if (other.HasName)
                    {
                        this.Name = other.Name;
                    }
                    if (other.attribute_.Count != 0)
                    {
                        this.result.attribute_.Add(other.attribute_);
                    }
                    if (other.statsBucket_.Count != 0)
                    {
                        this.result.statsBucket_.Add(other.statsBucket_);
                    }
                    if (other.HasUnseededId)
                    {
                        this.UnseededId = other.UnseededId;
                    }
                    if (other.HasAllowQueueing)
                    {
                        this.AllowQueueing = other.AllowQueueing;
                    }
                }
                return this;
            }

            public override GameFactoryDescription.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GameFactoryDescription.Builder MergeFrom(IMessageLite other)
            {
                if (other is GameFactoryDescription)
                {
                    return this.MergeFrom((GameFactoryDescription) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GameFactoryDescription.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GameFactoryDescription._gameFactoryDescriptionFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GameFactoryDescription._gameFactoryDescriptionFieldTags[index];
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
                            this.result.hasId = input.ReadFixed64(ref this.result.id_);
                            continue;
                        }
                        case 0x12:
                        {
                            this.result.hasName = input.ReadString(ref this.result.name_);
                            continue;
                        }
                        case 0x1a:
                        {
                            input.ReadMessageArray<bnet.protocol.game_master.Attribute>(num, str, this.result.attribute_, bnet.protocol.game_master.Attribute.DefaultInstance, extensionRegistry);
                            continue;
                        }
                        case 0x22:
                        {
                            input.ReadMessageArray<GameStatsBucket>(num, str, this.result.statsBucket_, GameStatsBucket.DefaultInstance, extensionRegistry);
                            continue;
                        }
                        case 0x29:
                        {
                            this.result.hasUnseededId = input.ReadFixed64(ref this.result.unseededId_);
                            continue;
                        }
                        case 0x30:
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
                    this.result.hasAllowQueueing = input.ReadBool(ref this.result.allowQueueing_);
                }
                return this;
            }

            private GameFactoryDescription PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GameFactoryDescription result = this.result;
                    this.result = new GameFactoryDescription();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public GameFactoryDescription.Builder SetAllowQueueing(bool value)
            {
                this.PrepareBuilder();
                this.result.hasAllowQueueing = true;
                this.result.allowQueueing_ = value;
                return this;
            }

            public GameFactoryDescription.Builder SetAttribute(int index, bnet.protocol.game_master.Attribute value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.attribute_[index] = value;
                return this;
            }

            public GameFactoryDescription.Builder SetAttribute(int index, bnet.protocol.game_master.Attribute.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.attribute_[index] = builderForValue.Build();
                return this;
            }

            [CLSCompliant(false)]
            public GameFactoryDescription.Builder SetId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasId = true;
                this.result.id_ = value;
                return this;
            }

            public GameFactoryDescription.Builder SetName(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasName = true;
                this.result.name_ = value;
                return this;
            }

            public GameFactoryDescription.Builder SetStatsBucket(int index, GameStatsBucket value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.statsBucket_[index] = value;
                return this;
            }

            public GameFactoryDescription.Builder SetStatsBucket(int index, GameStatsBucket.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.statsBucket_[index] = builderForValue.Build();
                return this;
            }

            [CLSCompliant(false)]
            public GameFactoryDescription.Builder SetUnseededId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasUnseededId = true;
                this.result.unseededId_ = value;
                return this;
            }

            public bool AllowQueueing
            {
                get
                {
                    return this.result.AllowQueueing;
                }
                set
                {
                    this.SetAllowQueueing(value);
                }
            }

            public int AttributeCount
            {
                get
                {
                    return this.result.AttributeCount;
                }
            }

            public IPopsicleList<bnet.protocol.game_master.Attribute> AttributeList
            {
                get
                {
                    return this.PrepareBuilder().attribute_;
                }
            }

            public override GameFactoryDescription DefaultInstanceForType
            {
                get
                {
                    return GameFactoryDescription.DefaultInstance;
                }
            }

            public bool HasAllowQueueing
            {
                get
                {
                    return this.result.hasAllowQueueing;
                }
            }

            public bool HasId
            {
                get
                {
                    return this.result.hasId;
                }
            }

            public bool HasName
            {
                get
                {
                    return this.result.hasName;
                }
            }

            public bool HasUnseededId
            {
                get
                {
                    return this.result.hasUnseededId;
                }
            }

            [CLSCompliant(false)]
            public ulong Id
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

            protected override GameFactoryDescription MessageBeingBuilt
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

            public int StatsBucketCount
            {
                get
                {
                    return this.result.StatsBucketCount;
                }
            }

            public IPopsicleList<GameStatsBucket> StatsBucketList
            {
                get
                {
                    return this.PrepareBuilder().statsBucket_;
                }
            }

            protected override GameFactoryDescription.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            [CLSCompliant(false)]
            public ulong UnseededId
            {
                get
                {
                    return this.result.UnseededId;
                }
                set
                {
                    this.SetUnseededId(value);
                }
            }
        }
    }
}

