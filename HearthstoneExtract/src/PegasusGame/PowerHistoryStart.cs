namespace PegasusGame
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class PowerHistoryStart : GeneratedMessageLite<PowerHistoryStart, Builder>
    {
        private static readonly string[] _powerHistoryStartFieldNames = new string[] { "index", "source", "target", "type" };
        private static readonly uint[] _powerHistoryStartFieldTags = new uint[] { 0x10, 0x18, 0x20, 8 };
        private static readonly PowerHistoryStart defaultInstance = new PowerHistoryStart().MakeReadOnly();
        private bool hasIndex;
        private bool hasSource;
        private bool hasTarget;
        private bool hasType;
        private int index_;
        public const int IndexFieldNumber = 2;
        private int memoizedSerializedSize = -1;
        private int source_;
        public const int SourceFieldNumber = 3;
        private int target_;
        public const int TargetFieldNumber = 4;
        private PegasusGame.PowerHistoryStart.Types.Type type_ = PegasusGame.PowerHistoryStart.Types.Type.ATTACK;
        public const int TypeFieldNumber = 1;

        static PowerHistoryStart()
        {
            object.ReferenceEquals(PegasusGamelite.Descriptor, null);
        }

        private PowerHistoryStart()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(PowerHistoryStart prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            PowerHistoryStart start = obj as PowerHistoryStart;
            if (start == null)
            {
                return false;
            }
            if ((this.hasType != start.hasType) || (this.hasType && !this.type_.Equals(start.type_)))
            {
                return false;
            }
            if ((this.hasIndex != start.hasIndex) || (this.hasIndex && !this.index_.Equals(start.index_)))
            {
                return false;
            }
            if ((this.hasSource != start.hasSource) || (this.hasSource && !this.source_.Equals(start.source_)))
            {
                return false;
            }
            return ((this.hasTarget == start.hasTarget) && (!this.hasTarget || this.target_.Equals(start.target_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasType)
            {
                hashCode ^= this.type_.GetHashCode();
            }
            if (this.hasIndex)
            {
                hashCode ^= this.index_.GetHashCode();
            }
            if (this.hasSource)
            {
                hashCode ^= this.source_.GetHashCode();
            }
            if (this.hasTarget)
            {
                hashCode ^= this.target_.GetHashCode();
            }
            return hashCode;
        }

        private PowerHistoryStart MakeReadOnly()
        {
            return this;
        }

        public static PowerHistoryStart ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static PowerHistoryStart ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static PowerHistoryStart ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PowerHistoryStart ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PowerHistoryStart ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PowerHistoryStart ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PowerHistoryStart ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static PowerHistoryStart ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PowerHistoryStart ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PowerHistoryStart ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<PowerHistoryStart, Builder>.PrintField("type", this.hasType, this.type_, writer);
            GeneratedMessageLite<PowerHistoryStart, Builder>.PrintField("index", this.hasIndex, this.index_, writer);
            GeneratedMessageLite<PowerHistoryStart, Builder>.PrintField("source", this.hasSource, this.source_, writer);
            GeneratedMessageLite<PowerHistoryStart, Builder>.PrintField("target", this.hasTarget, this.target_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _powerHistoryStartFieldNames;
            if (this.hasType)
            {
                output.WriteEnum(1, strArray[3], (int) this.Type, this.Type);
            }
            if (this.hasIndex)
            {
                output.WriteInt32(2, strArray[0], this.Index);
            }
            if (this.hasSource)
            {
                output.WriteInt32(3, strArray[1], this.Source);
            }
            if (this.hasTarget)
            {
                output.WriteInt32(4, strArray[2], this.Target);
            }
        }

        public static PowerHistoryStart DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override PowerHistoryStart DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasIndex
        {
            get
            {
                return this.hasIndex;
            }
        }

        public bool HasSource
        {
            get
            {
                return this.hasSource;
            }
        }

        public bool HasTarget
        {
            get
            {
                return this.hasTarget;
            }
        }

        public bool HasType
        {
            get
            {
                return this.hasType;
            }
        }

        public int Index
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
                if (!this.hasType)
                {
                    return false;
                }
                if (!this.hasIndex)
                {
                    return false;
                }
                if (!this.hasSource)
                {
                    return false;
                }
                if (!this.hasTarget)
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
                    if (this.hasType)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeEnumSize(1, (int) this.Type);
                    }
                    if (this.hasIndex)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.Index);
                    }
                    if (this.hasSource)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(3, this.Source);
                    }
                    if (this.hasTarget)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(4, this.Target);
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

        public int Target
        {
            get
            {
                return this.target_;
            }
        }

        protected override PowerHistoryStart ThisMessage
        {
            get
            {
                return this;
            }
        }

        public PegasusGame.PowerHistoryStart.Types.Type Type
        {
            get
            {
                return this.type_;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<PowerHistoryStart, PowerHistoryStart.Builder>
        {
            private PowerHistoryStart result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = PowerHistoryStart.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(PowerHistoryStart cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override PowerHistoryStart BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override PowerHistoryStart.Builder Clear()
            {
                this.result = PowerHistoryStart.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public PowerHistoryStart.Builder ClearIndex()
            {
                this.PrepareBuilder();
                this.result.hasIndex = false;
                this.result.index_ = 0;
                return this;
            }

            public PowerHistoryStart.Builder ClearSource()
            {
                this.PrepareBuilder();
                this.result.hasSource = false;
                this.result.source_ = 0;
                return this;
            }

            public PowerHistoryStart.Builder ClearTarget()
            {
                this.PrepareBuilder();
                this.result.hasTarget = false;
                this.result.target_ = 0;
                return this;
            }

            public PowerHistoryStart.Builder ClearType()
            {
                this.PrepareBuilder();
                this.result.hasType = false;
                this.result.type_ = PegasusGame.PowerHistoryStart.Types.Type.ATTACK;
                return this;
            }

            public override PowerHistoryStart.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new PowerHistoryStart.Builder(this.result);
                }
                return new PowerHistoryStart.Builder().MergeFrom(this.result);
            }

            public override PowerHistoryStart.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override PowerHistoryStart.Builder MergeFrom(IMessageLite other)
            {
                if (other is PowerHistoryStart)
                {
                    return this.MergeFrom((PowerHistoryStart) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override PowerHistoryStart.Builder MergeFrom(PowerHistoryStart other)
            {
                if (other != PowerHistoryStart.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasType)
                    {
                        this.Type = other.Type;
                    }
                    if (other.HasIndex)
                    {
                        this.Index = other.Index;
                    }
                    if (other.HasSource)
                    {
                        this.Source = other.Source;
                    }
                    if (other.HasTarget)
                    {
                        this.Target = other.Target;
                    }
                }
                return this;
            }

            public override PowerHistoryStart.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(PowerHistoryStart._powerHistoryStartFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = PowerHistoryStart._powerHistoryStartFieldTags[index];
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
                            object obj2;
                            if (input.ReadEnum<PegasusGame.PowerHistoryStart.Types.Type>(ref this.result.type_, out obj2))
                            {
                                this.result.hasType = true;
                            }
                            else if (obj2 is int)
                            {
                            }
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasIndex = input.ReadInt32(ref this.result.index_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasSource = input.ReadInt32(ref this.result.source_);
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
                    this.result.hasTarget = input.ReadInt32(ref this.result.target_);
                }
                return this;
            }

            private PowerHistoryStart PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    PowerHistoryStart result = this.result;
                    this.result = new PowerHistoryStart();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public PowerHistoryStart.Builder SetIndex(int value)
            {
                this.PrepareBuilder();
                this.result.hasIndex = true;
                this.result.index_ = value;
                return this;
            }

            public PowerHistoryStart.Builder SetSource(int value)
            {
                this.PrepareBuilder();
                this.result.hasSource = true;
                this.result.source_ = value;
                return this;
            }

            public PowerHistoryStart.Builder SetTarget(int value)
            {
                this.PrepareBuilder();
                this.result.hasTarget = true;
                this.result.target_ = value;
                return this;
            }

            public PowerHistoryStart.Builder SetType(PegasusGame.PowerHistoryStart.Types.Type value)
            {
                this.PrepareBuilder();
                this.result.hasType = true;
                this.result.type_ = value;
                return this;
            }

            public override PowerHistoryStart DefaultInstanceForType
            {
                get
                {
                    return PowerHistoryStart.DefaultInstance;
                }
            }

            public bool HasIndex
            {
                get
                {
                    return this.result.hasIndex;
                }
            }

            public bool HasSource
            {
                get
                {
                    return this.result.hasSource;
                }
            }

            public bool HasTarget
            {
                get
                {
                    return this.result.hasTarget;
                }
            }

            public bool HasType
            {
                get
                {
                    return this.result.hasType;
                }
            }

            public int Index
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

            protected override PowerHistoryStart MessageBeingBuilt
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

            public int Target
            {
                get
                {
                    return this.result.Target;
                }
                set
                {
                    this.SetTarget(value);
                }
            }

            protected override PowerHistoryStart.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public PegasusGame.PowerHistoryStart.Types.Type Type
            {
                get
                {
                    return this.result.Type;
                }
                set
                {
                    this.SetType(value);
                }
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum Type
            {
                ATTACK = 1,
                CONTINUOUS = 2,
                DEATHS = 6,
                FATIGUE = 8,
                PLAY = 7,
                POWER = 3,
                SCRIPT = 4,
                TRIGGER = 5
            }
        }
    }
}

