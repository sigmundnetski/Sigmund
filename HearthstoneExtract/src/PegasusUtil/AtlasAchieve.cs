namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class AtlasAchieve : GeneratedMessageLite<AtlasAchieve, Builder>
    {
        private static readonly string[] _atlasAchieveFieldNames = new string[] { "ack_value", "id", "is_complete", "progress" };
        private static readonly uint[] _atlasAchieveFieldTags = new uint[] { 0x20, 8, 0x18, 0x10 };
        private int ackValue_;
        public const int AckValueFieldNumber = 4;
        private static readonly AtlasAchieve defaultInstance = new AtlasAchieve().MakeReadOnly();
        private bool hasAckValue;
        private bool hasId;
        private bool hasIsComplete;
        private bool hasProgress;
        private int id_;
        public const int IdFieldNumber = 1;
        private bool isComplete_;
        public const int IsCompleteFieldNumber = 3;
        private int memoizedSerializedSize = -1;
        private int progress_;
        public const int ProgressFieldNumber = 2;

        static AtlasAchieve()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AtlasAchieve()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AtlasAchieve prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AtlasAchieve achieve = obj as AtlasAchieve;
            if (achieve == null)
            {
                return false;
            }
            if ((this.hasId != achieve.hasId) || (this.hasId && !this.id_.Equals(achieve.id_)))
            {
                return false;
            }
            if ((this.hasProgress != achieve.hasProgress) || (this.hasProgress && !this.progress_.Equals(achieve.progress_)))
            {
                return false;
            }
            if ((this.hasIsComplete != achieve.hasIsComplete) || (this.hasIsComplete && !this.isComplete_.Equals(achieve.isComplete_)))
            {
                return false;
            }
            return ((this.hasAckValue == achieve.hasAckValue) && (!this.hasAckValue || this.ackValue_.Equals(achieve.ackValue_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasId)
            {
                hashCode ^= this.id_.GetHashCode();
            }
            if (this.hasProgress)
            {
                hashCode ^= this.progress_.GetHashCode();
            }
            if (this.hasIsComplete)
            {
                hashCode ^= this.isComplete_.GetHashCode();
            }
            if (this.hasAckValue)
            {
                hashCode ^= this.ackValue_.GetHashCode();
            }
            return hashCode;
        }

        private AtlasAchieve MakeReadOnly()
        {
            return this;
        }

        public static AtlasAchieve ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AtlasAchieve ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasAchieve ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasAchieve ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasAchieve ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasAchieve ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasAchieve ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AtlasAchieve ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasAchieve ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasAchieve ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AtlasAchieve, Builder>.PrintField("id", this.hasId, this.id_, writer);
            GeneratedMessageLite<AtlasAchieve, Builder>.PrintField("progress", this.hasProgress, this.progress_, writer);
            GeneratedMessageLite<AtlasAchieve, Builder>.PrintField("is_complete", this.hasIsComplete, this.isComplete_, writer);
            GeneratedMessageLite<AtlasAchieve, Builder>.PrintField("ack_value", this.hasAckValue, this.ackValue_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _atlasAchieveFieldNames;
            if (this.hasId)
            {
                output.WriteInt32(1, strArray[1], this.Id);
            }
            if (this.hasProgress)
            {
                output.WriteInt32(2, strArray[3], this.Progress);
            }
            if (this.hasIsComplete)
            {
                output.WriteBool(3, strArray[2], this.IsComplete);
            }
            if (this.hasAckValue)
            {
                output.WriteInt32(4, strArray[0], this.AckValue);
            }
        }

        public int AckValue
        {
            get
            {
                return this.ackValue_;
            }
        }

        public static AtlasAchieve DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AtlasAchieve DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasAckValue
        {
            get
            {
                return this.hasAckValue;
            }
        }

        public bool HasId
        {
            get
            {
                return this.hasId;
            }
        }

        public bool HasIsComplete
        {
            get
            {
                return this.hasIsComplete;
            }
        }

        public bool HasProgress
        {
            get
            {
                return this.hasProgress;
            }
        }

        public int Id
        {
            get
            {
                return this.id_;
            }
        }

        public bool IsComplete
        {
            get
            {
                return this.isComplete_;
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
                if (!this.hasProgress)
                {
                    return false;
                }
                if (!this.hasIsComplete)
                {
                    return false;
                }
                if (!this.hasAckValue)
                {
                    return false;
                }
                return true;
            }
        }

        public int Progress
        {
            get
            {
                return this.progress_;
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
                    if (this.hasProgress)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.Progress);
                    }
                    if (this.hasIsComplete)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(3, this.IsComplete);
                    }
                    if (this.hasAckValue)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(4, this.AckValue);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override AtlasAchieve ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<AtlasAchieve, AtlasAchieve.Builder>
        {
            private AtlasAchieve result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AtlasAchieve.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AtlasAchieve cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override AtlasAchieve BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AtlasAchieve.Builder Clear()
            {
                this.result = AtlasAchieve.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AtlasAchieve.Builder ClearAckValue()
            {
                this.PrepareBuilder();
                this.result.hasAckValue = false;
                this.result.ackValue_ = 0;
                return this;
            }

            public AtlasAchieve.Builder ClearId()
            {
                this.PrepareBuilder();
                this.result.hasId = false;
                this.result.id_ = 0;
                return this;
            }

            public AtlasAchieve.Builder ClearIsComplete()
            {
                this.PrepareBuilder();
                this.result.hasIsComplete = false;
                this.result.isComplete_ = false;
                return this;
            }

            public AtlasAchieve.Builder ClearProgress()
            {
                this.PrepareBuilder();
                this.result.hasProgress = false;
                this.result.progress_ = 0;
                return this;
            }

            public override AtlasAchieve.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AtlasAchieve.Builder(this.result);
                }
                return new AtlasAchieve.Builder().MergeFrom(this.result);
            }

            public override AtlasAchieve.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AtlasAchieve.Builder MergeFrom(IMessageLite other)
            {
                if (other is AtlasAchieve)
                {
                    return this.MergeFrom((AtlasAchieve) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AtlasAchieve.Builder MergeFrom(AtlasAchieve other)
            {
                if (other != AtlasAchieve.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasId)
                    {
                        this.Id = other.Id;
                    }
                    if (other.HasProgress)
                    {
                        this.Progress = other.Progress;
                    }
                    if (other.HasIsComplete)
                    {
                        this.IsComplete = other.IsComplete;
                    }
                    if (other.HasAckValue)
                    {
                        this.AckValue = other.AckValue;
                    }
                }
                return this;
            }

            public override AtlasAchieve.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AtlasAchieve._atlasAchieveFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AtlasAchieve._atlasAchieveFieldTags[index];
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
                            this.result.hasProgress = input.ReadInt32(ref this.result.progress_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasIsComplete = input.ReadBool(ref this.result.isComplete_);
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
                    this.result.hasAckValue = input.ReadInt32(ref this.result.ackValue_);
                }
                return this;
            }

            private AtlasAchieve PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AtlasAchieve result = this.result;
                    this.result = new AtlasAchieve();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public AtlasAchieve.Builder SetAckValue(int value)
            {
                this.PrepareBuilder();
                this.result.hasAckValue = true;
                this.result.ackValue_ = value;
                return this;
            }

            public AtlasAchieve.Builder SetId(int value)
            {
                this.PrepareBuilder();
                this.result.hasId = true;
                this.result.id_ = value;
                return this;
            }

            public AtlasAchieve.Builder SetIsComplete(bool value)
            {
                this.PrepareBuilder();
                this.result.hasIsComplete = true;
                this.result.isComplete_ = value;
                return this;
            }

            public AtlasAchieve.Builder SetProgress(int value)
            {
                this.PrepareBuilder();
                this.result.hasProgress = true;
                this.result.progress_ = value;
                return this;
            }

            public int AckValue
            {
                get
                {
                    return this.result.AckValue;
                }
                set
                {
                    this.SetAckValue(value);
                }
            }

            public override AtlasAchieve DefaultInstanceForType
            {
                get
                {
                    return AtlasAchieve.DefaultInstance;
                }
            }

            public bool HasAckValue
            {
                get
                {
                    return this.result.hasAckValue;
                }
            }

            public bool HasId
            {
                get
                {
                    return this.result.hasId;
                }
            }

            public bool HasIsComplete
            {
                get
                {
                    return this.result.hasIsComplete;
                }
            }

            public bool HasProgress
            {
                get
                {
                    return this.result.hasProgress;
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

            public bool IsComplete
            {
                get
                {
                    return this.result.IsComplete;
                }
                set
                {
                    this.SetIsComplete(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override AtlasAchieve MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int Progress
            {
                get
                {
                    return this.result.Progress;
                }
                set
                {
                    this.SetProgress(value);
                }
            }

            protected override AtlasAchieve.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

