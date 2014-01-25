namespace bnet.protocol.presence
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class FieldKey : GeneratedMessageLite<FieldKey, Builder>
    {
        private static readonly string[] _fieldKeyFieldNames = new string[] { "field", "group", "index", "program" };
        private static readonly uint[] _fieldKeyFieldTags = new uint[] { 0x18, 0x10, 0x20, 8 };
        private static readonly FieldKey defaultInstance = new FieldKey().MakeReadOnly();
        private uint field_;
        public const int FieldFieldNumber = 3;
        private uint group_;
        public const int GroupFieldNumber = 2;
        private bool hasField;
        private bool hasGroup;
        private bool hasIndex;
        private bool hasProgram;
        private ulong index_;
        public const int IndexFieldNumber = 4;
        private int memoizedSerializedSize = -1;
        private uint program_;
        public const int ProgramFieldNumber = 1;

        static FieldKey()
        {
            object.ReferenceEquals(PresenceTypes.Descriptor, null);
        }

        private FieldKey()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(FieldKey prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            FieldKey key = obj as FieldKey;
            if (key == null)
            {
                return false;
            }
            if ((this.hasProgram != key.hasProgram) || (this.hasProgram && !this.program_.Equals(key.program_)))
            {
                return false;
            }
            if ((this.hasGroup != key.hasGroup) || (this.hasGroup && !this.group_.Equals(key.group_)))
            {
                return false;
            }
            if ((this.hasField != key.hasField) || (this.hasField && !this.field_.Equals(key.field_)))
            {
                return false;
            }
            return ((this.hasIndex == key.hasIndex) && (!this.hasIndex || this.index_.Equals(key.index_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasProgram)
            {
                hashCode ^= this.program_.GetHashCode();
            }
            if (this.hasGroup)
            {
                hashCode ^= this.group_.GetHashCode();
            }
            if (this.hasField)
            {
                hashCode ^= this.field_.GetHashCode();
            }
            if (this.hasIndex)
            {
                hashCode ^= this.index_.GetHashCode();
            }
            return hashCode;
        }

        private FieldKey MakeReadOnly()
        {
            return this;
        }

        public static FieldKey ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static FieldKey ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static FieldKey ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static FieldKey ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static FieldKey ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static FieldKey ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static FieldKey ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static FieldKey ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static FieldKey ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static FieldKey ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<FieldKey, Builder>.PrintField("program", this.hasProgram, this.program_, writer);
            GeneratedMessageLite<FieldKey, Builder>.PrintField("group", this.hasGroup, this.group_, writer);
            GeneratedMessageLite<FieldKey, Builder>.PrintField("field", this.hasField, this.field_, writer);
            GeneratedMessageLite<FieldKey, Builder>.PrintField("index", this.hasIndex, this.index_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _fieldKeyFieldNames;
            if (this.hasProgram)
            {
                output.WriteUInt32(1, strArray[3], this.Program);
            }
            if (this.hasGroup)
            {
                output.WriteUInt32(2, strArray[1], this.Group);
            }
            if (this.hasField)
            {
                output.WriteUInt32(3, strArray[0], this.Field);
            }
            if (this.hasIndex)
            {
                output.WriteUInt64(4, strArray[2], this.Index);
            }
        }

        public static FieldKey DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override FieldKey DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        [CLSCompliant(false)]
        public uint Field
        {
            get
            {
                return this.field_;
            }
        }

        [CLSCompliant(false)]
        public uint Group
        {
            get
            {
                return this.group_;
            }
        }

        public bool HasField
        {
            get
            {
                return this.hasField;
            }
        }

        public bool HasGroup
        {
            get
            {
                return this.hasGroup;
            }
        }

        public bool HasIndex
        {
            get
            {
                return this.hasIndex;
            }
        }

        public bool HasProgram
        {
            get
            {
                return this.hasProgram;
            }
        }

        [CLSCompliant(false)]
        public ulong Index
        {
            get
            {
                return this.index_;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasProgram)
                {
                    return false;
                }
                if (!this.hasGroup)
                {
                    return false;
                }
                if (!this.hasField)
                {
                    return false;
                }
                return true;
            }
        }

        [CLSCompliant(false)]
        public uint Program
        {
            get
            {
                return this.program_;
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
                    if (this.hasProgram)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(1, this.Program);
                    }
                    if (this.hasGroup)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(2, this.Group);
                    }
                    if (this.hasField)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(3, this.Field);
                    }
                    if (this.hasIndex)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(4, this.Index);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override FieldKey ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<FieldKey, FieldKey.Builder>
        {
            private FieldKey result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = FieldKey.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(FieldKey cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override FieldKey BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override FieldKey.Builder Clear()
            {
                this.result = FieldKey.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public FieldKey.Builder ClearField()
            {
                this.PrepareBuilder();
                this.result.hasField = false;
                this.result.field_ = 0;
                return this;
            }

            public FieldKey.Builder ClearGroup()
            {
                this.PrepareBuilder();
                this.result.hasGroup = false;
                this.result.group_ = 0;
                return this;
            }

            public FieldKey.Builder ClearIndex()
            {
                this.PrepareBuilder();
                this.result.hasIndex = false;
                this.result.index_ = 0L;
                return this;
            }

            public FieldKey.Builder ClearProgram()
            {
                this.PrepareBuilder();
                this.result.hasProgram = false;
                this.result.program_ = 0;
                return this;
            }

            public override FieldKey.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new FieldKey.Builder(this.result);
                }
                return new FieldKey.Builder().MergeFrom(this.result);
            }

            public override FieldKey.Builder MergeFrom(FieldKey other)
            {
                if (other != FieldKey.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasProgram)
                    {
                        this.Program = other.Program;
                    }
                    if (other.HasGroup)
                    {
                        this.Group = other.Group;
                    }
                    if (other.HasField)
                    {
                        this.Field = other.Field;
                    }
                    if (other.HasIndex)
                    {
                        this.Index = other.Index;
                    }
                }
                return this;
            }

            public override FieldKey.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override FieldKey.Builder MergeFrom(IMessageLite other)
            {
                if (other is FieldKey)
                {
                    return this.MergeFrom((FieldKey) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override FieldKey.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(FieldKey._fieldKeyFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = FieldKey._fieldKeyFieldTags[index];
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
                            this.result.hasProgram = input.ReadUInt32(ref this.result.program_);
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasGroup = input.ReadUInt32(ref this.result.group_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasField = input.ReadUInt32(ref this.result.field_);
                            continue;
                        }
                        case 0x20:
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
                    this.result.hasIndex = input.ReadUInt64(ref this.result.index_);
                }
                return this;
            }

            private FieldKey PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    FieldKey result = this.result;
                    this.result = new FieldKey();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public FieldKey.Builder SetField(uint value)
            {
                this.PrepareBuilder();
                this.result.hasField = true;
                this.result.field_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public FieldKey.Builder SetGroup(uint value)
            {
                this.PrepareBuilder();
                this.result.hasGroup = true;
                this.result.group_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public FieldKey.Builder SetIndex(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasIndex = true;
                this.result.index_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public FieldKey.Builder SetProgram(uint value)
            {
                this.PrepareBuilder();
                this.result.hasProgram = true;
                this.result.program_ = value;
                return this;
            }

            public override FieldKey DefaultInstanceForType
            {
                get
                {
                    return FieldKey.DefaultInstance;
                }
            }

            [CLSCompliant(false)]
            public uint Field
            {
                get
                {
                    return this.result.Field;
                }
                set
                {
                    this.SetField(value);
                }
            }

            [CLSCompliant(false)]
            public uint Group
            {
                get
                {
                    return this.result.Group;
                }
                set
                {
                    this.SetGroup(value);
                }
            }

            public bool HasField
            {
                get
                {
                    return this.result.hasField;
                }
            }

            public bool HasGroup
            {
                get
                {
                    return this.result.hasGroup;
                }
            }

            public bool HasIndex
            {
                get
                {
                    return this.result.hasIndex;
                }
            }

            public bool HasProgram
            {
                get
                {
                    return this.result.hasProgram;
                }
            }

            [CLSCompliant(false)]
            public ulong Index
            {
                get
                {
                    return this.result.Index;
                }
                set
                {
                    this.SetIndex(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override FieldKey MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            [CLSCompliant(false)]
            public uint Program
            {
                get
                {
                    return this.result.Program;
                }
                set
                {
                    this.SetProgram(value);
                }
            }

            protected override FieldKey.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

