namespace bnet.protocol.presence
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class RichPresence : GeneratedMessageLite<RichPresence, Builder>
    {
        private static readonly string[] _richPresenceFieldNames = new string[] { "index", "program_id", "stream_id" };
        private static readonly uint[] _richPresenceFieldTags = new uint[] { 0x18, 13, 0x15 };
        private static readonly RichPresence defaultInstance = new RichPresence().MakeReadOnly();
        private bool hasIndex;
        private bool hasProgramId;
        private bool hasStreamId;
        private uint index_;
        public const int IndexFieldNumber = 3;
        private int memoizedSerializedSize = -1;
        private uint programId_;
        public const int ProgramIdFieldNumber = 1;
        private uint streamId_;
        public const int StreamIdFieldNumber = 2;

        static RichPresence()
        {
            object.ReferenceEquals(PresenceTypes.Descriptor, null);
        }

        private RichPresence()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(RichPresence prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            RichPresence presence = obj as RichPresence;
            if (presence == null)
            {
                return false;
            }
            if ((this.hasProgramId != presence.hasProgramId) || (this.hasProgramId && !this.programId_.Equals(presence.programId_)))
            {
                return false;
            }
            if ((this.hasStreamId != presence.hasStreamId) || (this.hasStreamId && !this.streamId_.Equals(presence.streamId_)))
            {
                return false;
            }
            return ((this.hasIndex == presence.hasIndex) && (!this.hasIndex || this.index_.Equals(presence.index_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasProgramId)
            {
                hashCode ^= this.programId_.GetHashCode();
            }
            if (this.hasStreamId)
            {
                hashCode ^= this.streamId_.GetHashCode();
            }
            if (this.hasIndex)
            {
                hashCode ^= this.index_.GetHashCode();
            }
            return hashCode;
        }

        private RichPresence MakeReadOnly()
        {
            return this;
        }

        public static RichPresence ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static RichPresence ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static RichPresence ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static RichPresence ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static RichPresence ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static RichPresence ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static RichPresence ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static RichPresence ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static RichPresence ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static RichPresence ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<RichPresence, Builder>.PrintField("program_id", this.hasProgramId, this.programId_, writer);
            GeneratedMessageLite<RichPresence, Builder>.PrintField("stream_id", this.hasStreamId, this.streamId_, writer);
            GeneratedMessageLite<RichPresence, Builder>.PrintField("index", this.hasIndex, this.index_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _richPresenceFieldNames;
            if (this.hasProgramId)
            {
                output.WriteFixed32(1, strArray[1], this.ProgramId);
            }
            if (this.hasStreamId)
            {
                output.WriteFixed32(2, strArray[2], this.StreamId);
            }
            if (this.hasIndex)
            {
                output.WriteUInt32(3, strArray[0], this.Index);
            }
        }

        public static RichPresence DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override RichPresence DefaultInstanceForType
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

        public bool HasProgramId
        {
            get
            {
                return this.hasProgramId;
            }
        }

        public bool HasStreamId
        {
            get
            {
                return this.hasStreamId;
            }
        }

        [CLSCompliant(false)]
        public uint Index
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
                if (!this.hasProgramId)
                {
                    return false;
                }
                if (!this.hasStreamId)
                {
                    return false;
                }
                if (!this.hasIndex)
                {
                    return false;
                }
                return true;
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
                    if (this.hasProgramId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed32Size(1, this.ProgramId);
                    }
                    if (this.hasStreamId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed32Size(2, this.StreamId);
                    }
                    if (this.hasIndex)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(3, this.Index);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        [CLSCompliant(false)]
        public uint StreamId
        {
            get
            {
                return this.streamId_;
            }
        }

        protected override RichPresence ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<RichPresence, RichPresence.Builder>
        {
            private RichPresence result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = RichPresence.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(RichPresence cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override RichPresence BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override RichPresence.Builder Clear()
            {
                this.result = RichPresence.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public RichPresence.Builder ClearIndex()
            {
                this.PrepareBuilder();
                this.result.hasIndex = false;
                this.result.index_ = 0;
                return this;
            }

            public RichPresence.Builder ClearProgramId()
            {
                this.PrepareBuilder();
                this.result.hasProgramId = false;
                this.result.programId_ = 0;
                return this;
            }

            public RichPresence.Builder ClearStreamId()
            {
                this.PrepareBuilder();
                this.result.hasStreamId = false;
                this.result.streamId_ = 0;
                return this;
            }

            public override RichPresence.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new RichPresence.Builder(this.result);
                }
                return new RichPresence.Builder().MergeFrom(this.result);
            }

            public override RichPresence.Builder MergeFrom(RichPresence other)
            {
                if (other != RichPresence.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasProgramId)
                    {
                        this.ProgramId = other.ProgramId;
                    }
                    if (other.HasStreamId)
                    {
                        this.StreamId = other.StreamId;
                    }
                    if (other.HasIndex)
                    {
                        this.Index = other.Index;
                    }
                }
                return this;
            }

            public override RichPresence.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override RichPresence.Builder MergeFrom(IMessageLite other)
            {
                if (other is RichPresence)
                {
                    return this.MergeFrom((RichPresence) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override RichPresence.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(RichPresence._richPresenceFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = RichPresence._richPresenceFieldTags[index];
                        }
                        else
                        {
                            this.ParseUnknownField(input, extensionRegistry, num, str);
                            continue;
                        }
                    }
                    switch (num)
                    {
                        case 0x15:
                        {
                            this.result.hasStreamId = input.ReadFixed32(ref this.result.streamId_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasIndex = input.ReadUInt32(ref this.result.index_);
                            continue;
                        }
                        case 0:
                            throw InvalidProtocolBufferException.InvalidTag();

                        case 13:
                            goto Label_009F;

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
                Label_009F:
                    this.result.hasProgramId = input.ReadFixed32(ref this.result.programId_);
                }
                return this;
            }

            private RichPresence PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    RichPresence result = this.result;
                    this.result = new RichPresence();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public RichPresence.Builder SetIndex(uint value)
            {
                this.PrepareBuilder();
                this.result.hasIndex = true;
                this.result.index_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public RichPresence.Builder SetProgramId(uint value)
            {
                this.PrepareBuilder();
                this.result.hasProgramId = true;
                this.result.programId_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public RichPresence.Builder SetStreamId(uint value)
            {
                this.PrepareBuilder();
                this.result.hasStreamId = true;
                this.result.streamId_ = value;
                return this;
            }

            public override RichPresence DefaultInstanceForType
            {
                get
                {
                    return RichPresence.DefaultInstance;
                }
            }

            public bool HasIndex
            {
                get
                {
                    return this.result.hasIndex;
                }
            }

            public bool HasProgramId
            {
                get
                {
                    return this.result.hasProgramId;
                }
            }

            public bool HasStreamId
            {
                get
                {
                    return this.result.hasStreamId;
                }
            }

            [CLSCompliant(false)]
            public uint Index
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

            protected override RichPresence MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
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

            [CLSCompliant(false)]
            public uint StreamId
            {
                get
                {
                    return this.result.StreamId;
                }
                set
                {
                    this.SetStreamId(value);
                }
            }

            protected override RichPresence.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

