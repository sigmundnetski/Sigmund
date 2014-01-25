namespace PegasusGame
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class ChooseOption : GeneratedMessageLite<ChooseOption, Builder>
    {
        private static readonly string[] _chooseOptionFieldNames = new string[] { "id", "index", "position", "subOption", "target" };
        private static readonly uint[] _chooseOptionFieldTags = new uint[] { 8, 0x10, 40, 0x20, 0x18 };
        private static readonly ChooseOption defaultInstance = new ChooseOption().MakeReadOnly();
        private bool hasId;
        private bool hasIndex;
        private bool hasPosition;
        private bool hasSubOption;
        private bool hasTarget;
        private int id_;
        public const int IdFieldNumber = 1;
        private int index_;
        public const int IndexFieldNumber = 2;
        private int memoizedSerializedSize = -1;
        private int position_;
        public const int PositionFieldNumber = 5;
        private int subOption_;
        public const int SubOptionFieldNumber = 4;
        private int target_;
        public const int TargetFieldNumber = 3;

        static ChooseOption()
        {
            object.ReferenceEquals(PegasusGamelite.Descriptor, null);
        }

        private ChooseOption()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ChooseOption prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ChooseOption option = obj as ChooseOption;
            if (option == null)
            {
                return false;
            }
            if ((this.hasId != option.hasId) || (this.hasId && !this.id_.Equals(option.id_)))
            {
                return false;
            }
            if ((this.hasIndex != option.hasIndex) || (this.hasIndex && !this.index_.Equals(option.index_)))
            {
                return false;
            }
            if ((this.hasTarget != option.hasTarget) || (this.hasTarget && !this.target_.Equals(option.target_)))
            {
                return false;
            }
            if ((this.hasSubOption != option.hasSubOption) || (this.hasSubOption && !this.subOption_.Equals(option.subOption_)))
            {
                return false;
            }
            return ((this.hasPosition == option.hasPosition) && (!this.hasPosition || this.position_.Equals(option.position_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasId)
            {
                hashCode ^= this.id_.GetHashCode();
            }
            if (this.hasIndex)
            {
                hashCode ^= this.index_.GetHashCode();
            }
            if (this.hasTarget)
            {
                hashCode ^= this.target_.GetHashCode();
            }
            if (this.hasSubOption)
            {
                hashCode ^= this.subOption_.GetHashCode();
            }
            if (this.hasPosition)
            {
                hashCode ^= this.position_.GetHashCode();
            }
            return hashCode;
        }

        private ChooseOption MakeReadOnly()
        {
            return this;
        }

        public static ChooseOption ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ChooseOption ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ChooseOption ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ChooseOption ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ChooseOption ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ChooseOption ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ChooseOption ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ChooseOption ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ChooseOption ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ChooseOption ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ChooseOption, Builder>.PrintField("id", this.hasId, this.id_, writer);
            GeneratedMessageLite<ChooseOption, Builder>.PrintField("index", this.hasIndex, this.index_, writer);
            GeneratedMessageLite<ChooseOption, Builder>.PrintField("target", this.hasTarget, this.target_, writer);
            GeneratedMessageLite<ChooseOption, Builder>.PrintField("subOption", this.hasSubOption, this.subOption_, writer);
            GeneratedMessageLite<ChooseOption, Builder>.PrintField("position", this.hasPosition, this.position_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _chooseOptionFieldNames;
            if (this.hasId)
            {
                output.WriteInt32(1, strArray[0], this.Id);
            }
            if (this.hasIndex)
            {
                output.WriteInt32(2, strArray[1], this.Index);
            }
            if (this.hasTarget)
            {
                output.WriteInt32(3, strArray[4], this.Target);
            }
            if (this.hasSubOption)
            {
                output.WriteInt32(4, strArray[3], this.SubOption);
            }
            if (this.hasPosition)
            {
                output.WriteInt32(5, strArray[2], this.Position);
            }
        }

        public static ChooseOption DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ChooseOption DefaultInstanceForType
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

        public bool HasIndex
        {
            get
            {
                return this.hasIndex;
            }
        }

        public bool HasPosition
        {
            get
            {
                return this.hasPosition;
            }
        }

        public bool HasSubOption
        {
            get
            {
                return this.hasSubOption;
            }
        }

        public bool HasTarget
        {
            get
            {
                return this.hasTarget;
            }
        }

        public int Id
        {
            get
            {
                return this.id_;
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
                if (!this.hasId)
                {
                    return false;
                }
                if (!this.hasIndex)
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

        public int Position
        {
            get
            {
                return this.position_;
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
                    if (this.hasIndex)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.Index);
                    }
                    if (this.hasTarget)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(3, this.Target);
                    }
                    if (this.hasSubOption)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(4, this.SubOption);
                    }
                    if (this.hasPosition)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(5, this.Position);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        public int SubOption
        {
            get
            {
                return this.subOption_;
            }
        }

        public int Target
        {
            get
            {
                return this.target_;
            }
        }

        protected override ChooseOption ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<ChooseOption, ChooseOption.Builder>
        {
            private ChooseOption result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ChooseOption.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ChooseOption cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override ChooseOption BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ChooseOption.Builder Clear()
            {
                this.result = ChooseOption.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ChooseOption.Builder ClearId()
            {
                this.PrepareBuilder();
                this.result.hasId = false;
                this.result.id_ = 0;
                return this;
            }

            public ChooseOption.Builder ClearIndex()
            {
                this.PrepareBuilder();
                this.result.hasIndex = false;
                this.result.index_ = 0;
                return this;
            }

            public ChooseOption.Builder ClearPosition()
            {
                this.PrepareBuilder();
                this.result.hasPosition = false;
                this.result.position_ = 0;
                return this;
            }

            public ChooseOption.Builder ClearSubOption()
            {
                this.PrepareBuilder();
                this.result.hasSubOption = false;
                this.result.subOption_ = 0;
                return this;
            }

            public ChooseOption.Builder ClearTarget()
            {
                this.PrepareBuilder();
                this.result.hasTarget = false;
                this.result.target_ = 0;
                return this;
            }

            public override ChooseOption.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ChooseOption.Builder(this.result);
                }
                return new ChooseOption.Builder().MergeFrom(this.result);
            }

            public override ChooseOption.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ChooseOption.Builder MergeFrom(IMessageLite other)
            {
                if (other is ChooseOption)
                {
                    return this.MergeFrom((ChooseOption) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ChooseOption.Builder MergeFrom(ChooseOption other)
            {
                if (other != ChooseOption.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasId)
                    {
                        this.Id = other.Id;
                    }
                    if (other.HasIndex)
                    {
                        this.Index = other.Index;
                    }
                    if (other.HasTarget)
                    {
                        this.Target = other.Target;
                    }
                    if (other.HasSubOption)
                    {
                        this.SubOption = other.SubOption;
                    }
                    if (other.HasPosition)
                    {
                        this.Position = other.Position;
                    }
                }
                return this;
            }

            public override ChooseOption.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ChooseOption._chooseOptionFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ChooseOption._chooseOptionFieldTags[index];
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
                        case 0x10:
                        {
                            this.result.hasIndex = input.ReadInt32(ref this.result.index_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasTarget = input.ReadInt32(ref this.result.target_);
                            continue;
                        }
                        case 0x20:
                        {
                            this.result.hasSubOption = input.ReadInt32(ref this.result.subOption_);
                            continue;
                        }
                        case 40:
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
                    this.result.hasPosition = input.ReadInt32(ref this.result.position_);
                }
                return this;
            }

            private ChooseOption PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ChooseOption result = this.result;
                    this.result = new ChooseOption();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ChooseOption.Builder SetId(int value)
            {
                this.PrepareBuilder();
                this.result.hasId = true;
                this.result.id_ = value;
                return this;
            }

            public ChooseOption.Builder SetIndex(int value)
            {
                this.PrepareBuilder();
                this.result.hasIndex = true;
                this.result.index_ = value;
                return this;
            }

            public ChooseOption.Builder SetPosition(int value)
            {
                this.PrepareBuilder();
                this.result.hasPosition = true;
                this.result.position_ = value;
                return this;
            }

            public ChooseOption.Builder SetSubOption(int value)
            {
                this.PrepareBuilder();
                this.result.hasSubOption = true;
                this.result.subOption_ = value;
                return this;
            }

            public ChooseOption.Builder SetTarget(int value)
            {
                this.PrepareBuilder();
                this.result.hasTarget = true;
                this.result.target_ = value;
                return this;
            }

            public override ChooseOption DefaultInstanceForType
            {
                get
                {
                    return ChooseOption.DefaultInstance;
                }
            }

            public bool HasId
            {
                get
                {
                    return this.result.hasId;
                }
            }

            public bool HasIndex
            {
                get
                {
                    return this.result.hasIndex;
                }
            }

            public bool HasPosition
            {
                get
                {
                    return this.result.hasPosition;
                }
            }

            public bool HasSubOption
            {
                get
                {
                    return this.result.hasSubOption;
                }
            }

            public bool HasTarget
            {
                get
                {
                    return this.result.hasTarget;
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

            protected override ChooseOption MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int Position
            {
                get
                {
                    return this.result.Position;
                }
                set
                {
                    this.SetPosition(value);
                }
            }

            public int SubOption
            {
                get
                {
                    return this.result.SubOption;
                }
                set
                {
                    this.SetSubOption(value);
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

            protected override ChooseOption.Builder ThisBuilder
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
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 2
            }
        }
    }
}

