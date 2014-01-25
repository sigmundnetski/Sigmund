namespace bnet.protocol.connection
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class ProcessId : GeneratedMessageLite<ProcessId, Builder>
    {
        private static readonly string[] _processIdFieldNames = new string[] { "epoch", "label" };
        private static readonly uint[] _processIdFieldTags = new uint[] { 0x10, 8 };
        private static readonly ProcessId defaultInstance = new ProcessId().MakeReadOnly();
        private uint epoch_;
        public const int EpochFieldNumber = 2;
        private bool hasEpoch;
        private bool hasLabel;
        private uint label_;
        public const int LabelFieldNumber = 1;
        private int memoizedSerializedSize = -1;

        static ProcessId()
        {
            object.ReferenceEquals(Connect.Descriptor, null);
        }

        private ProcessId()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ProcessId prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ProcessId id = obj as ProcessId;
            if (id == null)
            {
                return false;
            }
            if ((this.hasLabel != id.hasLabel) || (this.hasLabel && !this.label_.Equals(id.label_)))
            {
                return false;
            }
            return ((this.hasEpoch == id.hasEpoch) && (!this.hasEpoch || this.epoch_.Equals(id.epoch_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasLabel)
            {
                hashCode ^= this.label_.GetHashCode();
            }
            if (this.hasEpoch)
            {
                hashCode ^= this.epoch_.GetHashCode();
            }
            return hashCode;
        }

        private ProcessId MakeReadOnly()
        {
            return this;
        }

        public static ProcessId ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ProcessId ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProcessId ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ProcessId ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ProcessId ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ProcessId ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ProcessId ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ProcessId ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProcessId ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProcessId ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ProcessId, Builder>.PrintField("label", this.hasLabel, this.label_, writer);
            GeneratedMessageLite<ProcessId, Builder>.PrintField("epoch", this.hasEpoch, this.epoch_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _processIdFieldNames;
            if (this.hasLabel)
            {
                output.WriteUInt32(1, strArray[1], this.Label);
            }
            if (this.hasEpoch)
            {
                output.WriteUInt32(2, strArray[0], this.Epoch);
            }
        }

        public static ProcessId DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ProcessId DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        [CLSCompliant(false)]
        public uint Epoch
        {
            get
            {
                return this.epoch_;
            }
        }

        public bool HasEpoch
        {
            get
            {
                return this.hasEpoch;
            }
        }

        public bool HasLabel
        {
            get
            {
                return this.hasLabel;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasLabel)
                {
                    return false;
                }
                if (!this.hasEpoch)
                {
                    return false;
                }
                return true;
            }
        }

        [CLSCompliant(false)]
        public uint Label
        {
            get
            {
                return this.label_;
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
                    if (this.hasLabel)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(1, this.Label);
                    }
                    if (this.hasEpoch)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(2, this.Epoch);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ProcessId ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<ProcessId, ProcessId.Builder>
        {
            private ProcessId result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ProcessId.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ProcessId cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override ProcessId BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ProcessId.Builder Clear()
            {
                this.result = ProcessId.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ProcessId.Builder ClearEpoch()
            {
                this.PrepareBuilder();
                this.result.hasEpoch = false;
                this.result.epoch_ = 0;
                return this;
            }

            public ProcessId.Builder ClearLabel()
            {
                this.PrepareBuilder();
                this.result.hasLabel = false;
                this.result.label_ = 0;
                return this;
            }

            public override ProcessId.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ProcessId.Builder(this.result);
                }
                return new ProcessId.Builder().MergeFrom(this.result);
            }

            public override ProcessId.Builder MergeFrom(ProcessId other)
            {
                if (other != ProcessId.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasLabel)
                    {
                        this.Label = other.Label;
                    }
                    if (other.HasEpoch)
                    {
                        this.Epoch = other.Epoch;
                    }
                }
                return this;
            }

            public override ProcessId.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ProcessId.Builder MergeFrom(IMessageLite other)
            {
                if (other is ProcessId)
                {
                    return this.MergeFrom((ProcessId) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ProcessId.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ProcessId._processIdFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ProcessId._processIdFieldTags[index];
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
                            this.result.hasLabel = input.ReadUInt32(ref this.result.label_);
                            continue;
                        }
                        case 0x10:
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
                    this.result.hasEpoch = input.ReadUInt32(ref this.result.epoch_);
                }
                return this;
            }

            private ProcessId PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ProcessId result = this.result;
                    this.result = new ProcessId();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public ProcessId.Builder SetEpoch(uint value)
            {
                this.PrepareBuilder();
                this.result.hasEpoch = true;
                this.result.epoch_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public ProcessId.Builder SetLabel(uint value)
            {
                this.PrepareBuilder();
                this.result.hasLabel = true;
                this.result.label_ = value;
                return this;
            }

            public override ProcessId DefaultInstanceForType
            {
                get
                {
                    return ProcessId.DefaultInstance;
                }
            }

            [CLSCompliant(false)]
            public uint Epoch
            {
                get
                {
                    return this.result.Epoch;
                }
                set
                {
                    this.SetEpoch(value);
                }
            }

            public bool HasEpoch
            {
                get
                {
                    return this.result.hasEpoch;
                }
            }

            public bool HasLabel
            {
                get
                {
                    return this.result.hasLabel;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            [CLSCompliant(false)]
            public uint Label
            {
                get
                {
                    return this.result.Label;
                }
                set
                {
                    this.SetLabel(value);
                }
            }

            protected override ProcessId MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override ProcessId.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

