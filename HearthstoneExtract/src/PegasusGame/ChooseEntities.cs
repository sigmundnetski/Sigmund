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
    public sealed class ChooseEntities : GeneratedMessageLite<ChooseEntities, Builder>
    {
        private static readonly string[] _chooseEntitiesFieldNames = new string[] { "entities", "id" };
        private static readonly uint[] _chooseEntitiesFieldTags = new uint[] { 0x12, 8 };
        private static readonly ChooseEntities defaultInstance = new ChooseEntities().MakeReadOnly();
        private PopsicleList<int> entities_ = new PopsicleList<int>();
        public const int EntitiesFieldNumber = 2;
        private int entitiesMemoizedSerializedSize;
        private bool hasId;
        private int id_;
        public const int IdFieldNumber = 1;
        private int memoizedSerializedSize = -1;

        static ChooseEntities()
        {
            object.ReferenceEquals(PegasusGamelite.Descriptor, null);
        }

        private ChooseEntities()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ChooseEntities prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ChooseEntities entities = obj as ChooseEntities;
            if (entities == null)
            {
                return false;
            }
            if ((this.hasId != entities.hasId) || (this.hasId && !this.id_.Equals(entities.id_)))
            {
                return false;
            }
            if (this.entities_.Count != entities.entities_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.entities_.Count; i++)
            {
                int num2 = this.entities_[i];
                if (!num2.Equals(entities.entities_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public int GetEntities(int index)
        {
            return this.entities_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasId)
            {
                hashCode ^= this.id_.GetHashCode();
            }
            IEnumerator<int> enumerator = this.entities_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    int current = enumerator.Current;
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

        private ChooseEntities MakeReadOnly()
        {
            this.entities_.MakeReadOnly();
            return this;
        }

        public static ChooseEntities ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ChooseEntities ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ChooseEntities ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ChooseEntities ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ChooseEntities ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ChooseEntities ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ChooseEntities ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ChooseEntities ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ChooseEntities ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ChooseEntities ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ChooseEntities, Builder>.PrintField("id", this.hasId, this.id_, writer);
            GeneratedMessageLite<ChooseEntities, Builder>.PrintField<int>("entities", this.entities_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _chooseEntitiesFieldNames;
            if (this.hasId)
            {
                output.WriteInt32(1, strArray[1], this.Id);
            }
            if (this.entities_.Count > 0)
            {
                output.WritePackedInt32Array(2, strArray[0], this.entitiesMemoizedSerializedSize, this.entities_);
            }
        }

        public static ChooseEntities DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ChooseEntities DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public int EntitiesCount
        {
            get
            {
                return this.entities_.Count;
            }
        }

        public IList<int> EntitiesList
        {
            get
            {
                return Lists.AsReadOnly<int>(this.entities_);
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
                    int num2 = 0;
                    IEnumerator<int> enumerator = this.EntitiesList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            int current = enumerator.Current;
                            num2 += CodedOutputStream.ComputeInt32SizeNoTag(current);
                        }
                    }
                    finally
                    {
                        if (enumerator == null)
                        {
                        }
                        enumerator.Dispose();
                    }
                    memoizedSerializedSize += num2;
                    if (this.entities_.Count != 0)
                    {
                        memoizedSerializedSize += 1 + CodedOutputStream.ComputeInt32SizeNoTag(num2);
                    }
                    this.entitiesMemoizedSerializedSize = num2;
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ChooseEntities ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<ChooseEntities, ChooseEntities.Builder>
        {
            private ChooseEntities result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ChooseEntities.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ChooseEntities cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public ChooseEntities.Builder AddEntities(int value)
            {
                this.PrepareBuilder();
                this.result.entities_.Add(value);
                return this;
            }

            public ChooseEntities.Builder AddRangeEntities(IEnumerable<int> values)
            {
                this.PrepareBuilder();
                this.result.entities_.Add(values);
                return this;
            }

            public override ChooseEntities BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ChooseEntities.Builder Clear()
            {
                this.result = ChooseEntities.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ChooseEntities.Builder ClearEntities()
            {
                this.PrepareBuilder();
                this.result.entities_.Clear();
                return this;
            }

            public ChooseEntities.Builder ClearId()
            {
                this.PrepareBuilder();
                this.result.hasId = false;
                this.result.id_ = 0;
                return this;
            }

            public override ChooseEntities.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ChooseEntities.Builder(this.result);
                }
                return new ChooseEntities.Builder().MergeFrom(this.result);
            }

            public int GetEntities(int index)
            {
                return this.result.GetEntities(index);
            }

            public override ChooseEntities.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ChooseEntities.Builder MergeFrom(IMessageLite other)
            {
                if (other is ChooseEntities)
                {
                    return this.MergeFrom((ChooseEntities) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ChooseEntities.Builder MergeFrom(ChooseEntities other)
            {
                if (other != ChooseEntities.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasId)
                    {
                        this.Id = other.Id;
                    }
                    if (other.entities_.Count != 0)
                    {
                        this.result.entities_.Add(other.entities_);
                    }
                }
                return this;
            }

            public override ChooseEntities.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ChooseEntities._chooseEntitiesFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ChooseEntities._chooseEntitiesFieldTags[index];
                        }
                        else
                        {
                            this.ParseUnknownField(input, extensionRegistry, num, str);
                            continue;
                        }
                    }
                    switch (num)
                    {
                        case 0x10:
                        case 0x12:
                            goto Label_00BB;

                        case 0:
                            throw InvalidProtocolBufferException.InvalidTag();

                        case 8:
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
                    this.result.hasId = input.ReadInt32(ref this.result.id_);
                    continue;
                Label_00BB:
                    input.ReadInt32Array(num, str, this.result.entities_);
                }
                return this;
            }

            private ChooseEntities PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ChooseEntities result = this.result;
                    this.result = new ChooseEntities();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ChooseEntities.Builder SetEntities(int index, int value)
            {
                this.PrepareBuilder();
                this.result.entities_[index] = value;
                return this;
            }

            public ChooseEntities.Builder SetId(int value)
            {
                this.PrepareBuilder();
                this.result.hasId = true;
                this.result.id_ = value;
                return this;
            }

            public override ChooseEntities DefaultInstanceForType
            {
                get
                {
                    return ChooseEntities.DefaultInstance;
                }
            }

            public int EntitiesCount
            {
                get
                {
                    return this.result.EntitiesCount;
                }
            }

            public IPopsicleList<int> EntitiesList
            {
                get
                {
                    return this.PrepareBuilder().entities_;
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

            protected override ChooseEntities MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override ChooseEntities.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 3
            }
        }
    }
}

