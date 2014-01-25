namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class QueueStatus : GeneratedMessageLite<QueueStatus, Builder>
    {
        private static readonly string[] _queueStatusFieldNames = new string[] { "bnet_error", "max_seconds", "min_seconds", "queue_event" };
        private static readonly uint[] _queueStatusFieldTags = new uint[] { 0x20, 0x18, 0x10, 8 };
        private int bnetError_;
        public const int BnetErrorFieldNumber = 4;
        private static readonly QueueStatus defaultInstance = new QueueStatus().MakeReadOnly();
        private bool hasBnetError;
        private bool hasMaxSeconds;
        private bool hasMinSeconds;
        private bool hasQueueEvent;
        private int maxSeconds_;
        public const int MaxSecondsFieldNumber = 3;
        private int memoizedSerializedSize = -1;
        private int minSeconds_;
        public const int MinSecondsFieldNumber = 2;
        private BobNetProto.QueueStatus.Types.QueueEvent queueEvent_ = BobNetProto.QueueStatus.Types.QueueEvent.QUEUE_ENTER;
        public const int QueueEventFieldNumber = 1;

        static QueueStatus()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private QueueStatus()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(QueueStatus prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            QueueStatus status = obj as QueueStatus;
            if (status == null)
            {
                return false;
            }
            if ((this.hasQueueEvent != status.hasQueueEvent) || (this.hasQueueEvent && !this.queueEvent_.Equals(status.queueEvent_)))
            {
                return false;
            }
            if ((this.hasMinSeconds != status.hasMinSeconds) || (this.hasMinSeconds && !this.minSeconds_.Equals(status.minSeconds_)))
            {
                return false;
            }
            if ((this.hasMaxSeconds != status.hasMaxSeconds) || (this.hasMaxSeconds && !this.maxSeconds_.Equals(status.maxSeconds_)))
            {
                return false;
            }
            return ((this.hasBnetError == status.hasBnetError) && (!this.hasBnetError || this.bnetError_.Equals(status.bnetError_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasQueueEvent)
            {
                hashCode ^= this.queueEvent_.GetHashCode();
            }
            if (this.hasMinSeconds)
            {
                hashCode ^= this.minSeconds_.GetHashCode();
            }
            if (this.hasMaxSeconds)
            {
                hashCode ^= this.maxSeconds_.GetHashCode();
            }
            if (this.hasBnetError)
            {
                hashCode ^= this.bnetError_.GetHashCode();
            }
            return hashCode;
        }

        private QueueStatus MakeReadOnly()
        {
            return this;
        }

        public static QueueStatus ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static QueueStatus ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static QueueStatus ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static QueueStatus ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static QueueStatus ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static QueueStatus ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static QueueStatus ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static QueueStatus ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static QueueStatus ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static QueueStatus ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<QueueStatus, Builder>.PrintField("queue_event", this.hasQueueEvent, this.queueEvent_, writer);
            GeneratedMessageLite<QueueStatus, Builder>.PrintField("min_seconds", this.hasMinSeconds, this.minSeconds_, writer);
            GeneratedMessageLite<QueueStatus, Builder>.PrintField("max_seconds", this.hasMaxSeconds, this.maxSeconds_, writer);
            GeneratedMessageLite<QueueStatus, Builder>.PrintField("bnet_error", this.hasBnetError, this.bnetError_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _queueStatusFieldNames;
            if (this.hasQueueEvent)
            {
                output.WriteEnum(1, strArray[3], (int) this.QueueEvent, this.QueueEvent);
            }
            if (this.hasMinSeconds)
            {
                output.WriteInt32(2, strArray[2], this.MinSeconds);
            }
            if (this.hasMaxSeconds)
            {
                output.WriteInt32(3, strArray[1], this.MaxSeconds);
            }
            if (this.hasBnetError)
            {
                output.WriteInt32(4, strArray[0], this.BnetError);
            }
        }

        public int BnetError
        {
            get
            {
                return this.bnetError_;
            }
        }

        public static QueueStatus DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override QueueStatus DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasBnetError
        {
            get
            {
                return this.hasBnetError;
            }
        }

        public bool HasMaxSeconds
        {
            get
            {
                return this.hasMaxSeconds;
            }
        }

        public bool HasMinSeconds
        {
            get
            {
                return this.hasMinSeconds;
            }
        }

        public bool HasQueueEvent
        {
            get
            {
                return this.hasQueueEvent;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasQueueEvent)
                {
                    return false;
                }
                return true;
            }
        }

        public int MaxSeconds
        {
            get
            {
                return this.maxSeconds_;
            }
        }

        public int MinSeconds
        {
            get
            {
                return this.minSeconds_;
            }
        }

        public BobNetProto.QueueStatus.Types.QueueEvent QueueEvent
        {
            get
            {
                return this.queueEvent_;
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
                    if (this.hasQueueEvent)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeEnumSize(1, (int) this.QueueEvent);
                    }
                    if (this.hasMinSeconds)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.MinSeconds);
                    }
                    if (this.hasMaxSeconds)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(3, this.MaxSeconds);
                    }
                    if (this.hasBnetError)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(4, this.BnetError);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override QueueStatus ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<QueueStatus, QueueStatus.Builder>
        {
            private QueueStatus result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = QueueStatus.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(QueueStatus cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override QueueStatus BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override QueueStatus.Builder Clear()
            {
                this.result = QueueStatus.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public QueueStatus.Builder ClearBnetError()
            {
                this.PrepareBuilder();
                this.result.hasBnetError = false;
                this.result.bnetError_ = 0;
                return this;
            }

            public QueueStatus.Builder ClearMaxSeconds()
            {
                this.PrepareBuilder();
                this.result.hasMaxSeconds = false;
                this.result.maxSeconds_ = 0;
                return this;
            }

            public QueueStatus.Builder ClearMinSeconds()
            {
                this.PrepareBuilder();
                this.result.hasMinSeconds = false;
                this.result.minSeconds_ = 0;
                return this;
            }

            public QueueStatus.Builder ClearQueueEvent()
            {
                this.PrepareBuilder();
                this.result.hasQueueEvent = false;
                this.result.queueEvent_ = BobNetProto.QueueStatus.Types.QueueEvent.QUEUE_ENTER;
                return this;
            }

            public override QueueStatus.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new QueueStatus.Builder(this.result);
                }
                return new QueueStatus.Builder().MergeFrom(this.result);
            }

            public override QueueStatus.Builder MergeFrom(QueueStatus other)
            {
                if (other != QueueStatus.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasQueueEvent)
                    {
                        this.QueueEvent = other.QueueEvent;
                    }
                    if (other.HasMinSeconds)
                    {
                        this.MinSeconds = other.MinSeconds;
                    }
                    if (other.HasMaxSeconds)
                    {
                        this.MaxSeconds = other.MaxSeconds;
                    }
                    if (other.HasBnetError)
                    {
                        this.BnetError = other.BnetError;
                    }
                }
                return this;
            }

            public override QueueStatus.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override QueueStatus.Builder MergeFrom(IMessageLite other)
            {
                if (other is QueueStatus)
                {
                    return this.MergeFrom((QueueStatus) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override QueueStatus.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(QueueStatus._queueStatusFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = QueueStatus._queueStatusFieldTags[index];
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
                            if (input.ReadEnum<BobNetProto.QueueStatus.Types.QueueEvent>(ref this.result.queueEvent_, out obj2))
                            {
                                this.result.hasQueueEvent = true;
                            }
                            else if (obj2 is int)
                            {
                            }
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasMinSeconds = input.ReadInt32(ref this.result.minSeconds_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasMaxSeconds = input.ReadInt32(ref this.result.maxSeconds_);
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
                    this.result.hasBnetError = input.ReadInt32(ref this.result.bnetError_);
                }
                return this;
            }

            private QueueStatus PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    QueueStatus result = this.result;
                    this.result = new QueueStatus();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public QueueStatus.Builder SetBnetError(int value)
            {
                this.PrepareBuilder();
                this.result.hasBnetError = true;
                this.result.bnetError_ = value;
                return this;
            }

            public QueueStatus.Builder SetMaxSeconds(int value)
            {
                this.PrepareBuilder();
                this.result.hasMaxSeconds = true;
                this.result.maxSeconds_ = value;
                return this;
            }

            public QueueStatus.Builder SetMinSeconds(int value)
            {
                this.PrepareBuilder();
                this.result.hasMinSeconds = true;
                this.result.minSeconds_ = value;
                return this;
            }

            public QueueStatus.Builder SetQueueEvent(BobNetProto.QueueStatus.Types.QueueEvent value)
            {
                this.PrepareBuilder();
                this.result.hasQueueEvent = true;
                this.result.queueEvent_ = value;
                return this;
            }

            public int BnetError
            {
                get
                {
                    return this.result.BnetError;
                }
                set
                {
                    this.SetBnetError(value);
                }
            }

            public override QueueStatus DefaultInstanceForType
            {
                get
                {
                    return QueueStatus.DefaultInstance;
                }
            }

            public bool HasBnetError
            {
                get
                {
                    return this.result.hasBnetError;
                }
            }

            public bool HasMaxSeconds
            {
                get
                {
                    return this.result.hasMaxSeconds;
                }
            }

            public bool HasMinSeconds
            {
                get
                {
                    return this.result.hasMinSeconds;
                }
            }

            public bool HasQueueEvent
            {
                get
                {
                    return this.result.hasQueueEvent;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public int MaxSeconds
            {
                get
                {
                    return this.result.MaxSeconds;
                }
                set
                {
                    this.SetMaxSeconds(value);
                }
            }

            protected override QueueStatus MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int MinSeconds
            {
                get
                {
                    return this.result.MinSeconds;
                }
                set
                {
                    this.SetMinSeconds(value);
                }
            }

            public BobNetProto.QueueStatus.Types.QueueEvent QueueEvent
            {
                get
                {
                    return this.result.QueueEvent;
                }
                set
                {
                    this.SetQueueEvent(value);
                }
            }

            protected override QueueStatus.Builder ThisBuilder
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
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0xa1
            }

            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum QueueEvent
            {
                QUEUE_AMM_ERROR = 6,
                QUEUE_CANCEL = 8,
                QUEUE_DELAY = 3,
                QUEUE_DELAY_ERROR = 5,
                QUEUE_ENTER = 1,
                QUEUE_LEAVE = 2,
                QUEUE_UPDATE = 4,
                QUEUE_WAIT_END = 7
            }
        }
    }
}

