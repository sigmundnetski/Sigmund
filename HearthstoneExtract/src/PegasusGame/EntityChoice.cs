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

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class EntityChoice : GeneratedMessageLite<EntityChoice, Builder>
    {
        private static readonly string[] _entityChoiceFieldNames = new string[] { "cancelable", "choice_type", "count_max", "count_min", "entities", "id", "source" };
        private static readonly uint[] _entityChoiceFieldTags = new uint[] { 0x18, 0x10, 40, 0x20, 50, 8, 0x38 };
        private bool cancelable_;
        public const int CancelableFieldNumber = 3;
        private int choiceType_;
        public const int ChoiceTypeFieldNumber = 2;
        private int countMax_;
        public const int CountMaxFieldNumber = 5;
        private int countMin_;
        public const int CountMinFieldNumber = 4;
        private static readonly EntityChoice defaultInstance = new EntityChoice().MakeReadOnly();
        private PopsicleList<int> entities_ = new PopsicleList<int>();
        public const int EntitiesFieldNumber = 6;
        private int entitiesMemoizedSerializedSize;
        private bool hasCancelable;
        private bool hasChoiceType;
        private bool hasCountMax;
        private bool hasCountMin;
        private bool hasId;
        private bool hasSource;
        private int id_;
        public const int IdFieldNumber = 1;
        private int memoizedSerializedSize = -1;
        private int source_;
        public const int SourceFieldNumber = 7;

        static EntityChoice()
        {
            object.ReferenceEquals(PegasusGamelite.Descriptor, null);
        }

        private EntityChoice()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(EntityChoice prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            EntityChoice choice = obj as EntityChoice;
            if (choice == null)
            {
                return false;
            }
            if ((this.hasId != choice.hasId) || (this.hasId && !this.id_.Equals(choice.id_)))
            {
                return false;
            }
            if ((this.hasChoiceType != choice.hasChoiceType) || (this.hasChoiceType && !this.choiceType_.Equals(choice.choiceType_)))
            {
                return false;
            }
            if ((this.hasCancelable != choice.hasCancelable) || (this.hasCancelable && !this.cancelable_.Equals(choice.cancelable_)))
            {
                return false;
            }
            if ((this.hasCountMin != choice.hasCountMin) || (this.hasCountMin && !this.countMin_.Equals(choice.countMin_)))
            {
                return false;
            }
            if ((this.hasCountMax != choice.hasCountMax) || (this.hasCountMax && !this.countMax_.Equals(choice.countMax_)))
            {
                return false;
            }
            if (this.entities_.Count != choice.entities_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.entities_.Count; i++)
            {
                int num2 = this.entities_[i];
                if (!num2.Equals(choice.entities_[i]))
                {
                    return false;
                }
            }
            return ((this.hasSource == choice.hasSource) && (!this.hasSource || this.source_.Equals(choice.source_)));
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
            if (this.hasChoiceType)
            {
                hashCode ^= this.choiceType_.GetHashCode();
            }
            if (this.hasCancelable)
            {
                hashCode ^= this.cancelable_.GetHashCode();
            }
            if (this.hasCountMin)
            {
                hashCode ^= this.countMin_.GetHashCode();
            }
            if (this.hasCountMax)
            {
                hashCode ^= this.countMax_.GetHashCode();
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
            if (this.hasSource)
            {
                hashCode ^= this.source_.GetHashCode();
            }
            return hashCode;
        }

        private EntityChoice MakeReadOnly()
        {
            this.entities_.MakeReadOnly();
            return this;
        }

        public static EntityChoice ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static EntityChoice ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static EntityChoice ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static EntityChoice ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static EntityChoice ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static EntityChoice ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static EntityChoice ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static EntityChoice ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static EntityChoice ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static EntityChoice ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<EntityChoice, Builder>.PrintField("id", this.hasId, this.id_, writer);
            GeneratedMessageLite<EntityChoice, Builder>.PrintField("choice_type", this.hasChoiceType, this.choiceType_, writer);
            GeneratedMessageLite<EntityChoice, Builder>.PrintField("cancelable", this.hasCancelable, this.cancelable_, writer);
            GeneratedMessageLite<EntityChoice, Builder>.PrintField("count_min", this.hasCountMin, this.countMin_, writer);
            GeneratedMessageLite<EntityChoice, Builder>.PrintField("count_max", this.hasCountMax, this.countMax_, writer);
            GeneratedMessageLite<EntityChoice, Builder>.PrintField<int>("entities", this.entities_, writer);
            GeneratedMessageLite<EntityChoice, Builder>.PrintField("source", this.hasSource, this.source_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _entityChoiceFieldNames;
            if (this.hasId)
            {
                output.WriteInt32(1, strArray[5], this.Id);
            }
            if (this.hasChoiceType)
            {
                output.WriteInt32(2, strArray[1], this.ChoiceType);
            }
            if (this.hasCancelable)
            {
                output.WriteBool(3, strArray[0], this.Cancelable);
            }
            if (this.hasCountMin)
            {
                output.WriteInt32(4, strArray[3], this.CountMin);
            }
            if (this.hasCountMax)
            {
                output.WriteInt32(5, strArray[2], this.CountMax);
            }
            if (this.entities_.Count > 0)
            {
                output.WritePackedInt32Array(6, strArray[4], this.entitiesMemoizedSerializedSize, this.entities_);
            }
            if (this.hasSource)
            {
                output.WriteInt32(7, strArray[6], this.Source);
            }
        }

        public bool Cancelable
        {
            get
            {
                return this.cancelable_;
            }
        }

        public int ChoiceType
        {
            get
            {
                return this.choiceType_;
            }
        }

        public int CountMax
        {
            get
            {
                return this.countMax_;
            }
        }

        public int CountMin
        {
            get
            {
                return this.countMin_;
            }
        }

        public static EntityChoice DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override EntityChoice DefaultInstanceForType
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

        public bool HasCancelable
        {
            get
            {
                return this.hasCancelable;
            }
        }

        public bool HasChoiceType
        {
            get
            {
                return this.hasChoiceType;
            }
        }

        public bool HasCountMax
        {
            get
            {
                return this.hasCountMax;
            }
        }

        public bool HasCountMin
        {
            get
            {
                return this.hasCountMin;
            }
        }

        public bool HasId
        {
            get
            {
                return this.hasId;
            }
        }

        public bool HasSource
        {
            get
            {
                return this.hasSource;
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
                if (!this.hasChoiceType)
                {
                    return false;
                }
                if (!this.hasCancelable)
                {
                    return false;
                }
                if (!this.hasCountMin)
                {
                    return false;
                }
                if (!this.hasCountMax)
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
                    if (this.hasChoiceType)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.ChoiceType);
                    }
                    if (this.hasCancelable)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(3, this.Cancelable);
                    }
                    if (this.hasCountMin)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(4, this.CountMin);
                    }
                    if (this.hasCountMax)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(5, this.CountMax);
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
                    if (this.hasSource)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(7, this.Source);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        public int Source
        {
            get
            {
                return this.source_;
            }
        }

        protected override EntityChoice ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<EntityChoice, EntityChoice.Builder>
        {
            private EntityChoice result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = EntityChoice.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(EntityChoice cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public EntityChoice.Builder AddEntities(int value)
            {
                this.PrepareBuilder();
                this.result.entities_.Add(value);
                return this;
            }

            public EntityChoice.Builder AddRangeEntities(IEnumerable<int> values)
            {
                this.PrepareBuilder();
                this.result.entities_.Add(values);
                return this;
            }

            public override EntityChoice BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override EntityChoice.Builder Clear()
            {
                this.result = EntityChoice.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public EntityChoice.Builder ClearCancelable()
            {
                this.PrepareBuilder();
                this.result.hasCancelable = false;
                this.result.cancelable_ = false;
                return this;
            }

            public EntityChoice.Builder ClearChoiceType()
            {
                this.PrepareBuilder();
                this.result.hasChoiceType = false;
                this.result.choiceType_ = 0;
                return this;
            }

            public EntityChoice.Builder ClearCountMax()
            {
                this.PrepareBuilder();
                this.result.hasCountMax = false;
                this.result.countMax_ = 0;
                return this;
            }

            public EntityChoice.Builder ClearCountMin()
            {
                this.PrepareBuilder();
                this.result.hasCountMin = false;
                this.result.countMin_ = 0;
                return this;
            }

            public EntityChoice.Builder ClearEntities()
            {
                this.PrepareBuilder();
                this.result.entities_.Clear();
                return this;
            }

            public EntityChoice.Builder ClearId()
            {
                this.PrepareBuilder();
                this.result.hasId = false;
                this.result.id_ = 0;
                return this;
            }

            public EntityChoice.Builder ClearSource()
            {
                this.PrepareBuilder();
                this.result.hasSource = false;
                this.result.source_ = 0;
                return this;
            }

            public override EntityChoice.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new EntityChoice.Builder(this.result);
                }
                return new EntityChoice.Builder().MergeFrom(this.result);
            }

            public int GetEntities(int index)
            {
                return this.result.GetEntities(index);
            }

            public override EntityChoice.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override EntityChoice.Builder MergeFrom(IMessageLite other)
            {
                if (other is EntityChoice)
                {
                    return this.MergeFrom((EntityChoice) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override EntityChoice.Builder MergeFrom(EntityChoice other)
            {
                if (other != EntityChoice.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasId)
                    {
                        this.Id = other.Id;
                    }
                    if (other.HasChoiceType)
                    {
                        this.ChoiceType = other.ChoiceType;
                    }
                    if (other.HasCancelable)
                    {
                        this.Cancelable = other.Cancelable;
                    }
                    if (other.HasCountMin)
                    {
                        this.CountMin = other.CountMin;
                    }
                    if (other.HasCountMax)
                    {
                        this.CountMax = other.CountMax;
                    }
                    if (other.entities_.Count != 0)
                    {
                        this.result.entities_.Add(other.entities_);
                    }
                    if (other.HasSource)
                    {
                        this.Source = other.Source;
                    }
                }
                return this;
            }

            public override EntityChoice.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(EntityChoice._entityChoiceFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = EntityChoice._entityChoiceFieldTags[index];
                        }
                        else
                        {
                            this.ParseUnknownField(input, extensionRegistry, num, str);
                            continue;
                        }
                    }
                    switch (num)
                    {
                        case 0x30:
                        case 50:
                        {
                            input.ReadInt32Array(num, str, this.result.entities_);
                            continue;
                        }
                        case 0:
                            throw InvalidProtocolBufferException.InvalidTag();

                        case 8:
                            goto Label_00C2;

                        case 0x10:
                            goto Label_00E3;

                        case 0x18:
                            goto Label_0104;

                        case 0x20:
                            goto Label_0125;

                        case 40:
                            goto Label_0146;

                        case 0x38:
                            goto Label_017F;

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
                Label_00C2:
                    this.result.hasId = input.ReadInt32(ref this.result.id_);
                    continue;
                Label_00E3:
                    this.result.hasChoiceType = input.ReadInt32(ref this.result.choiceType_);
                    continue;
                Label_0104:
                    this.result.hasCancelable = input.ReadBool(ref this.result.cancelable_);
                    continue;
                Label_0125:
                    this.result.hasCountMin = input.ReadInt32(ref this.result.countMin_);
                    continue;
                Label_0146:
                    this.result.hasCountMax = input.ReadInt32(ref this.result.countMax_);
                    continue;
                Label_017F:
                    this.result.hasSource = input.ReadInt32(ref this.result.source_);
                }
                return this;
            }

            private EntityChoice PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    EntityChoice result = this.result;
                    this.result = new EntityChoice();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public EntityChoice.Builder SetCancelable(bool value)
            {
                this.PrepareBuilder();
                this.result.hasCancelable = true;
                this.result.cancelable_ = value;
                return this;
            }

            public EntityChoice.Builder SetChoiceType(int value)
            {
                this.PrepareBuilder();
                this.result.hasChoiceType = true;
                this.result.choiceType_ = value;
                return this;
            }

            public EntityChoice.Builder SetCountMax(int value)
            {
                this.PrepareBuilder();
                this.result.hasCountMax = true;
                this.result.countMax_ = value;
                return this;
            }

            public EntityChoice.Builder SetCountMin(int value)
            {
                this.PrepareBuilder();
                this.result.hasCountMin = true;
                this.result.countMin_ = value;
                return this;
            }

            public EntityChoice.Builder SetEntities(int index, int value)
            {
                this.PrepareBuilder();
                this.result.entities_[index] = value;
                return this;
            }

            public EntityChoice.Builder SetId(int value)
            {
                this.PrepareBuilder();
                this.result.hasId = true;
                this.result.id_ = value;
                return this;
            }

            public EntityChoice.Builder SetSource(int value)
            {
                this.PrepareBuilder();
                this.result.hasSource = true;
                this.result.source_ = value;
                return this;
            }

            public bool Cancelable
            {
                get
                {
                    return this.result.Cancelable;
                }
                set
                {
                    this.SetCancelable(value);
                }
            }

            public int ChoiceType
            {
                get
                {
                    return this.result.ChoiceType;
                }
                set
                {
                    this.SetChoiceType(value);
                }
            }

            public int CountMax
            {
                get
                {
                    return this.result.CountMax;
                }
                set
                {
                    this.SetCountMax(value);
                }
            }

            public int CountMin
            {
                get
                {
                    return this.result.CountMin;
                }
                set
                {
                    this.SetCountMin(value);
                }
            }

            public override EntityChoice DefaultInstanceForType
            {
                get
                {
                    return EntityChoice.DefaultInstance;
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

            public bool HasCancelable
            {
                get
                {
                    return this.result.hasCancelable;
                }
            }

            public bool HasChoiceType
            {
                get
                {
                    return this.result.hasChoiceType;
                }
            }

            public bool HasCountMax
            {
                get
                {
                    return this.result.hasCountMax;
                }
            }

            public bool HasCountMin
            {
                get
                {
                    return this.result.hasCountMin;
                }
            }

            public bool HasId
            {
                get
                {
                    return this.result.hasId;
                }
            }

            public bool HasSource
            {
                get
                {
                    return this.result.hasSource;
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

            protected override EntityChoice MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int Source
            {
                get
                {
                    return this.result.Source;
                }
                set
                {
                    this.SetSource(value);
                }
            }

            protected override EntityChoice.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0x11
            }
        }
    }
}

