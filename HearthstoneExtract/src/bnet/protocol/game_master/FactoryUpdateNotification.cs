namespace bnet.protocol.game_master
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class FactoryUpdateNotification : GeneratedMessageLite<FactoryUpdateNotification, Builder>
    {
        private static readonly string[] _factoryUpdateNotificationFieldNames = new string[] { "description", "op", "program_id" };
        private static readonly uint[] _factoryUpdateNotificationFieldTags = new uint[] { 0x12, 8, 0x1d };
        private static readonly FactoryUpdateNotification defaultInstance = new FactoryUpdateNotification().MakeReadOnly();
        private GameFactoryDescription description_;
        public const int DescriptionFieldNumber = 2;
        private bool hasDescription;
        private bool hasOp;
        private bool hasProgramId;
        private int memoizedSerializedSize = -1;
        private Types.Operation op_ = Types.Operation.ADD;
        public const int OpFieldNumber = 1;
        private uint programId_;
        public const int ProgramIdFieldNumber = 3;

        static FactoryUpdateNotification()
        {
            object.ReferenceEquals(GameMaster.Descriptor, null);
        }

        private FactoryUpdateNotification()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(FactoryUpdateNotification prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            FactoryUpdateNotification notification = obj as FactoryUpdateNotification;
            if (notification == null)
            {
                return false;
            }
            if ((this.hasOp != notification.hasOp) || (this.hasOp && !this.op_.Equals(notification.op_)))
            {
                return false;
            }
            if ((this.hasDescription != notification.hasDescription) || (this.hasDescription && !this.description_.Equals(notification.description_)))
            {
                return false;
            }
            return ((this.hasProgramId == notification.hasProgramId) && (!this.hasProgramId || this.programId_.Equals(notification.programId_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasOp)
            {
                hashCode ^= this.op_.GetHashCode();
            }
            if (this.hasDescription)
            {
                hashCode ^= this.description_.GetHashCode();
            }
            if (this.hasProgramId)
            {
                hashCode ^= this.programId_.GetHashCode();
            }
            return hashCode;
        }

        private FactoryUpdateNotification MakeReadOnly()
        {
            return this;
        }

        public static FactoryUpdateNotification ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static FactoryUpdateNotification ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static FactoryUpdateNotification ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static FactoryUpdateNotification ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static FactoryUpdateNotification ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static FactoryUpdateNotification ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static FactoryUpdateNotification ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static FactoryUpdateNotification ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static FactoryUpdateNotification ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static FactoryUpdateNotification ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<FactoryUpdateNotification, Builder>.PrintField("op", this.hasOp, this.op_, writer);
            GeneratedMessageLite<FactoryUpdateNotification, Builder>.PrintField("description", this.hasDescription, this.description_, writer);
            GeneratedMessageLite<FactoryUpdateNotification, Builder>.PrintField("program_id", this.hasProgramId, this.programId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _factoryUpdateNotificationFieldNames;
            if (this.hasOp)
            {
                output.WriteEnum(1, strArray[1], (int) this.Op, this.Op);
            }
            if (this.hasDescription)
            {
                output.WriteMessage(2, strArray[0], this.Description);
            }
            if (this.hasProgramId)
            {
                output.WriteFixed32(3, strArray[2], this.ProgramId);
            }
        }

        public static FactoryUpdateNotification DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override FactoryUpdateNotification DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public GameFactoryDescription Description
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.description_ != null)
                {
                    goto Label_0012;
                }
                return GameFactoryDescription.DefaultInstance;
            }
        }

        public bool HasDescription
        {
            get
            {
                return this.hasDescription;
            }
        }

        public bool HasOp
        {
            get
            {
                return this.hasOp;
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
                if (!this.hasOp)
                {
                    return false;
                }
                if (!this.hasDescription)
                {
                    return false;
                }
                if (!this.Description.IsInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        public Types.Operation Op
        {
            get
            {
                return this.op_;
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
                    if (this.hasOp)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeEnumSize(1, (int) this.Op);
                    }
                    if (this.hasDescription)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, this.Description);
                    }
                    if (this.hasProgramId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed32Size(3, this.ProgramId);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override FactoryUpdateNotification ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<FactoryUpdateNotification, FactoryUpdateNotification.Builder>
        {
            private FactoryUpdateNotification result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = FactoryUpdateNotification.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(FactoryUpdateNotification cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override FactoryUpdateNotification BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override FactoryUpdateNotification.Builder Clear()
            {
                this.result = FactoryUpdateNotification.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public FactoryUpdateNotification.Builder ClearDescription()
            {
                this.PrepareBuilder();
                this.result.hasDescription = false;
                this.result.description_ = null;
                return this;
            }

            public FactoryUpdateNotification.Builder ClearOp()
            {
                this.PrepareBuilder();
                this.result.hasOp = false;
                this.result.op_ = FactoryUpdateNotification.Types.Operation.ADD;
                return this;
            }

            public FactoryUpdateNotification.Builder ClearProgramId()
            {
                this.PrepareBuilder();
                this.result.hasProgramId = false;
                this.result.programId_ = 0;
                return this;
            }

            public override FactoryUpdateNotification.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new FactoryUpdateNotification.Builder(this.result);
                }
                return new FactoryUpdateNotification.Builder().MergeFrom(this.result);
            }

            public FactoryUpdateNotification.Builder MergeDescription(GameFactoryDescription value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasDescription && (this.result.description_ != GameFactoryDescription.DefaultInstance))
                {
                    this.result.description_ = GameFactoryDescription.CreateBuilder(this.result.description_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.description_ = value;
                }
                this.result.hasDescription = true;
                return this;
            }

            public override FactoryUpdateNotification.Builder MergeFrom(FactoryUpdateNotification other)
            {
                if (other != FactoryUpdateNotification.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasOp)
                    {
                        this.Op = other.Op;
                    }
                    if (other.HasDescription)
                    {
                        this.MergeDescription(other.Description);
                    }
                    if (other.HasProgramId)
                    {
                        this.ProgramId = other.ProgramId;
                    }
                }
                return this;
            }

            public override FactoryUpdateNotification.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override FactoryUpdateNotification.Builder MergeFrom(IMessageLite other)
            {
                if (other is FactoryUpdateNotification)
                {
                    return this.MergeFrom((FactoryUpdateNotification) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override FactoryUpdateNotification.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(FactoryUpdateNotification._factoryUpdateNotificationFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = FactoryUpdateNotification._factoryUpdateNotificationFieldTags[index];
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
                            if (input.ReadEnum<FactoryUpdateNotification.Types.Operation>(ref this.result.op_, out obj2))
                            {
                                this.result.hasOp = true;
                            }
                            else if (obj2 is int)
                            {
                            }
                            continue;
                        }
                        case 0x12:
                        {
                            GameFactoryDescription.Builder builder = GameFactoryDescription.CreateBuilder();
                            if (this.result.hasDescription)
                            {
                                builder.MergeFrom(this.Description);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.Description = builder.BuildPartial();
                            continue;
                        }
                        case 0x1d:
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

            private FactoryUpdateNotification PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    FactoryUpdateNotification result = this.result;
                    this.result = new FactoryUpdateNotification();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public FactoryUpdateNotification.Builder SetDescription(GameFactoryDescription value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasDescription = true;
                this.result.description_ = value;
                return this;
            }

            public FactoryUpdateNotification.Builder SetDescription(GameFactoryDescription.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasDescription = true;
                this.result.description_ = builderForValue.Build();
                return this;
            }

            public FactoryUpdateNotification.Builder SetOp(FactoryUpdateNotification.Types.Operation value)
            {
                this.PrepareBuilder();
                this.result.hasOp = true;
                this.result.op_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public FactoryUpdateNotification.Builder SetProgramId(uint value)
            {
                this.PrepareBuilder();
                this.result.hasProgramId = true;
                this.result.programId_ = value;
                return this;
            }

            public override FactoryUpdateNotification DefaultInstanceForType
            {
                get
                {
                    return FactoryUpdateNotification.DefaultInstance;
                }
            }

            public GameFactoryDescription Description
            {
                get
                {
                    return this.result.Description;
                }
                set
                {
                    this.SetDescription(value);
                }
            }

            public bool HasDescription
            {
                get
                {
                    return this.result.hasDescription;
                }
            }

            public bool HasOp
            {
                get
                {
                    return this.result.hasOp;
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

            protected override FactoryUpdateNotification MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public FactoryUpdateNotification.Types.Operation Op
            {
                get
                {
                    return this.result.Op;
                }
                set
                {
                    this.SetOp(value);
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

            protected override FactoryUpdateNotification.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum Operation
            {
                ADD = 1,
                CHANGE = 3,
                REMOVE = 2
            }
        }
    }
}

