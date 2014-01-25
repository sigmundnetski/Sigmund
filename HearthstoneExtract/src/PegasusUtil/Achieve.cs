namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using PegasusShared;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class Achieve : GeneratedMessageLite<Achieve, Builder>
    {
        private static readonly string[] _achieveFieldNames = new string[] { "ack_progress", "active", "completion_count", "date_completed", "date_given", "do_not_ack", "id", "progress", "started_count" };
        private static readonly uint[] _achieveFieldTags = new uint[] { 0x18, 40, 0x20, 0x42, 0x3a, 0x48, 8, 0x10, 0x30 };
        private int ackProgress_;
        public const int AckProgressFieldNumber = 3;
        private bool active_;
        public const int ActiveFieldNumber = 5;
        private int completionCount_;
        public const int CompletionCountFieldNumber = 4;
        private Date dateCompleted_;
        public const int DateCompletedFieldNumber = 8;
        private Date dateGiven_;
        public const int DateGivenFieldNumber = 7;
        private static readonly Achieve defaultInstance = new Achieve().MakeReadOnly();
        private bool doNotAck_;
        public const int DoNotAckFieldNumber = 9;
        private bool hasAckProgress;
        private bool hasActive;
        private bool hasCompletionCount;
        private bool hasDateCompleted;
        private bool hasDateGiven;
        private bool hasDoNotAck;
        private bool hasId;
        private bool hasProgress;
        private bool hasStartedCount;
        private int id_;
        public const int IdFieldNumber = 1;
        private int memoizedSerializedSize = -1;
        private int progress_;
        public const int ProgressFieldNumber = 2;
        private int startedCount_;
        public const int StartedCountFieldNumber = 6;

        static Achieve()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private Achieve()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(Achieve prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            Achieve achieve = obj as Achieve;
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
            if ((this.hasAckProgress != achieve.hasAckProgress) || (this.hasAckProgress && !this.ackProgress_.Equals(achieve.ackProgress_)))
            {
                return false;
            }
            if ((this.hasCompletionCount != achieve.hasCompletionCount) || (this.hasCompletionCount && !this.completionCount_.Equals(achieve.completionCount_)))
            {
                return false;
            }
            if ((this.hasActive != achieve.hasActive) || (this.hasActive && !this.active_.Equals(achieve.active_)))
            {
                return false;
            }
            if ((this.hasStartedCount != achieve.hasStartedCount) || (this.hasStartedCount && !this.startedCount_.Equals(achieve.startedCount_)))
            {
                return false;
            }
            if ((this.hasDateGiven != achieve.hasDateGiven) || (this.hasDateGiven && !this.dateGiven_.Equals(achieve.dateGiven_)))
            {
                return false;
            }
            if ((this.hasDateCompleted != achieve.hasDateCompleted) || (this.hasDateCompleted && !this.dateCompleted_.Equals(achieve.dateCompleted_)))
            {
                return false;
            }
            return ((this.hasDoNotAck == achieve.hasDoNotAck) && (!this.hasDoNotAck || this.doNotAck_.Equals(achieve.doNotAck_)));
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
            if (this.hasAckProgress)
            {
                hashCode ^= this.ackProgress_.GetHashCode();
            }
            if (this.hasCompletionCount)
            {
                hashCode ^= this.completionCount_.GetHashCode();
            }
            if (this.hasActive)
            {
                hashCode ^= this.active_.GetHashCode();
            }
            if (this.hasStartedCount)
            {
                hashCode ^= this.startedCount_.GetHashCode();
            }
            if (this.hasDateGiven)
            {
                hashCode ^= this.dateGiven_.GetHashCode();
            }
            if (this.hasDateCompleted)
            {
                hashCode ^= this.dateCompleted_.GetHashCode();
            }
            if (this.hasDoNotAck)
            {
                hashCode ^= this.doNotAck_.GetHashCode();
            }
            return hashCode;
        }

        private Achieve MakeReadOnly()
        {
            return this;
        }

        public static Achieve ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static Achieve ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static Achieve ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Achieve ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Achieve ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Achieve ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Achieve ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static Achieve ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Achieve ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Achieve ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<Achieve, Builder>.PrintField("id", this.hasId, this.id_, writer);
            GeneratedMessageLite<Achieve, Builder>.PrintField("progress", this.hasProgress, this.progress_, writer);
            GeneratedMessageLite<Achieve, Builder>.PrintField("ack_progress", this.hasAckProgress, this.ackProgress_, writer);
            GeneratedMessageLite<Achieve, Builder>.PrintField("completion_count", this.hasCompletionCount, this.completionCount_, writer);
            GeneratedMessageLite<Achieve, Builder>.PrintField("active", this.hasActive, this.active_, writer);
            GeneratedMessageLite<Achieve, Builder>.PrintField("started_count", this.hasStartedCount, this.startedCount_, writer);
            GeneratedMessageLite<Achieve, Builder>.PrintField("date_given", this.hasDateGiven, this.dateGiven_, writer);
            GeneratedMessageLite<Achieve, Builder>.PrintField("date_completed", this.hasDateCompleted, this.dateCompleted_, writer);
            GeneratedMessageLite<Achieve, Builder>.PrintField("do_not_ack", this.hasDoNotAck, this.doNotAck_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _achieveFieldNames;
            if (this.hasId)
            {
                output.WriteInt32(1, strArray[6], this.Id);
            }
            if (this.hasProgress)
            {
                output.WriteInt32(2, strArray[7], this.Progress);
            }
            if (this.hasAckProgress)
            {
                output.WriteInt32(3, strArray[0], this.AckProgress);
            }
            if (this.hasCompletionCount)
            {
                output.WriteInt32(4, strArray[2], this.CompletionCount);
            }
            if (this.hasActive)
            {
                output.WriteBool(5, strArray[1], this.Active);
            }
            if (this.hasStartedCount)
            {
                output.WriteInt32(6, strArray[8], this.StartedCount);
            }
            if (this.hasDateGiven)
            {
                output.WriteMessage(7, strArray[4], this.DateGiven);
            }
            if (this.hasDateCompleted)
            {
                output.WriteMessage(8, strArray[3], this.DateCompleted);
            }
            if (this.hasDoNotAck)
            {
                output.WriteBool(9, strArray[5], this.DoNotAck);
            }
        }

        public int AckProgress
        {
            get
            {
                return this.ackProgress_;
            }
        }

        public bool Active
        {
            get
            {
                return this.active_;
            }
        }

        public int CompletionCount
        {
            get
            {
                return this.completionCount_;
            }
        }

        public Date DateCompleted
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.dateCompleted_ != null)
                {
                    goto Label_0012;
                }
                return Date.DefaultInstance;
            }
        }

        public Date DateGiven
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.dateGiven_ != null)
                {
                    goto Label_0012;
                }
                return Date.DefaultInstance;
            }
        }

        public static Achieve DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override Achieve DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool DoNotAck
        {
            get
            {
                return this.doNotAck_;
            }
        }

        public bool HasAckProgress
        {
            get
            {
                return this.hasAckProgress;
            }
        }

        public bool HasActive
        {
            get
            {
                return this.hasActive;
            }
        }

        public bool HasCompletionCount
        {
            get
            {
                return this.hasCompletionCount;
            }
        }

        public bool HasDateCompleted
        {
            get
            {
                return this.hasDateCompleted;
            }
        }

        public bool HasDateGiven
        {
            get
            {
                return this.hasDateGiven;
            }
        }

        public bool HasDoNotAck
        {
            get
            {
                return this.hasDoNotAck;
            }
        }

        public bool HasId
        {
            get
            {
                return this.hasId;
            }
        }

        public bool HasProgress
        {
            get
            {
                return this.hasProgress;
            }
        }

        public bool HasStartedCount
        {
            get
            {
                return this.hasStartedCount;
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
                if (!this.hasProgress)
                {
                    return false;
                }
                if (!this.hasAckProgress)
                {
                    return false;
                }
                if (this.HasDateGiven && !this.DateGiven.IsInitialized)
                {
                    return false;
                }
                if (this.HasDateCompleted && !this.DateCompleted.IsInitialized)
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
                    if (this.hasAckProgress)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(3, this.AckProgress);
                    }
                    if (this.hasCompletionCount)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(4, this.CompletionCount);
                    }
                    if (this.hasActive)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(5, this.Active);
                    }
                    if (this.hasStartedCount)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(6, this.StartedCount);
                    }
                    if (this.hasDateGiven)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(7, this.DateGiven);
                    }
                    if (this.hasDateCompleted)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(8, this.DateCompleted);
                    }
                    if (this.hasDoNotAck)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(9, this.DoNotAck);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        public int StartedCount
        {
            get
            {
                return this.startedCount_;
            }
        }

        protected override Achieve ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<Achieve, Achieve.Builder>
        {
            private Achieve result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = Achieve.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(Achieve cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override Achieve BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override Achieve.Builder Clear()
            {
                this.result = Achieve.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public Achieve.Builder ClearAckProgress()
            {
                this.PrepareBuilder();
                this.result.hasAckProgress = false;
                this.result.ackProgress_ = 0;
                return this;
            }

            public Achieve.Builder ClearActive()
            {
                this.PrepareBuilder();
                this.result.hasActive = false;
                this.result.active_ = false;
                return this;
            }

            public Achieve.Builder ClearCompletionCount()
            {
                this.PrepareBuilder();
                this.result.hasCompletionCount = false;
                this.result.completionCount_ = 0;
                return this;
            }

            public Achieve.Builder ClearDateCompleted()
            {
                this.PrepareBuilder();
                this.result.hasDateCompleted = false;
                this.result.dateCompleted_ = null;
                return this;
            }

            public Achieve.Builder ClearDateGiven()
            {
                this.PrepareBuilder();
                this.result.hasDateGiven = false;
                this.result.dateGiven_ = null;
                return this;
            }

            public Achieve.Builder ClearDoNotAck()
            {
                this.PrepareBuilder();
                this.result.hasDoNotAck = false;
                this.result.doNotAck_ = false;
                return this;
            }

            public Achieve.Builder ClearId()
            {
                this.PrepareBuilder();
                this.result.hasId = false;
                this.result.id_ = 0;
                return this;
            }

            public Achieve.Builder ClearProgress()
            {
                this.PrepareBuilder();
                this.result.hasProgress = false;
                this.result.progress_ = 0;
                return this;
            }

            public Achieve.Builder ClearStartedCount()
            {
                this.PrepareBuilder();
                this.result.hasStartedCount = false;
                this.result.startedCount_ = 0;
                return this;
            }

            public override Achieve.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new Achieve.Builder(this.result);
                }
                return new Achieve.Builder().MergeFrom(this.result);
            }

            public Achieve.Builder MergeDateCompleted(Date value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasDateCompleted && (this.result.dateCompleted_ != Date.DefaultInstance))
                {
                    this.result.dateCompleted_ = Date.CreateBuilder(this.result.dateCompleted_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.dateCompleted_ = value;
                }
                this.result.hasDateCompleted = true;
                return this;
            }

            public Achieve.Builder MergeDateGiven(Date value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasDateGiven && (this.result.dateGiven_ != Date.DefaultInstance))
                {
                    this.result.dateGiven_ = Date.CreateBuilder(this.result.dateGiven_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.dateGiven_ = value;
                }
                this.result.hasDateGiven = true;
                return this;
            }

            public override Achieve.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override Achieve.Builder MergeFrom(IMessageLite other)
            {
                if (other is Achieve)
                {
                    return this.MergeFrom((Achieve) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override Achieve.Builder MergeFrom(Achieve other)
            {
                if (other != Achieve.DefaultInstance)
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
                    if (other.HasAckProgress)
                    {
                        this.AckProgress = other.AckProgress;
                    }
                    if (other.HasCompletionCount)
                    {
                        this.CompletionCount = other.CompletionCount;
                    }
                    if (other.HasActive)
                    {
                        this.Active = other.Active;
                    }
                    if (other.HasStartedCount)
                    {
                        this.StartedCount = other.StartedCount;
                    }
                    if (other.HasDateGiven)
                    {
                        this.MergeDateGiven(other.DateGiven);
                    }
                    if (other.HasDateCompleted)
                    {
                        this.MergeDateCompleted(other.DateCompleted);
                    }
                    if (other.HasDoNotAck)
                    {
                        this.DoNotAck = other.DoNotAck;
                    }
                }
                return this;
            }

            public override Achieve.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(Achieve._achieveFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = Achieve._achieveFieldTags[index];
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
                            this.result.hasAckProgress = input.ReadInt32(ref this.result.ackProgress_);
                            continue;
                        }
                        case 0x20:
                        {
                            this.result.hasCompletionCount = input.ReadInt32(ref this.result.completionCount_);
                            continue;
                        }
                        case 40:
                        {
                            this.result.hasActive = input.ReadBool(ref this.result.active_);
                            continue;
                        }
                        case 0x30:
                        {
                            this.result.hasStartedCount = input.ReadInt32(ref this.result.startedCount_);
                            continue;
                        }
                        case 0x3a:
                        {
                            Date.Builder builder = Date.CreateBuilder();
                            if (this.result.hasDateGiven)
                            {
                                builder.MergeFrom(this.DateGiven);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.DateGiven = builder.BuildPartial();
                            continue;
                        }
                        case 0x42:
                        {
                            Date.Builder builder2 = Date.CreateBuilder();
                            if (this.result.hasDateCompleted)
                            {
                                builder2.MergeFrom(this.DateCompleted);
                            }
                            input.ReadMessage(builder2, extensionRegistry);
                            this.DateCompleted = builder2.BuildPartial();
                            continue;
                        }
                        case 0x48:
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
                    this.result.hasDoNotAck = input.ReadBool(ref this.result.doNotAck_);
                }
                return this;
            }

            private Achieve PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    Achieve result = this.result;
                    this.result = new Achieve();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public Achieve.Builder SetAckProgress(int value)
            {
                this.PrepareBuilder();
                this.result.hasAckProgress = true;
                this.result.ackProgress_ = value;
                return this;
            }

            public Achieve.Builder SetActive(bool value)
            {
                this.PrepareBuilder();
                this.result.hasActive = true;
                this.result.active_ = value;
                return this;
            }

            public Achieve.Builder SetCompletionCount(int value)
            {
                this.PrepareBuilder();
                this.result.hasCompletionCount = true;
                this.result.completionCount_ = value;
                return this;
            }

            public Achieve.Builder SetDateCompleted(Date value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasDateCompleted = true;
                this.result.dateCompleted_ = value;
                return this;
            }

            public Achieve.Builder SetDateCompleted(Date.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasDateCompleted = true;
                this.result.dateCompleted_ = builderForValue.Build();
                return this;
            }

            public Achieve.Builder SetDateGiven(Date value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasDateGiven = true;
                this.result.dateGiven_ = value;
                return this;
            }

            public Achieve.Builder SetDateGiven(Date.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasDateGiven = true;
                this.result.dateGiven_ = builderForValue.Build();
                return this;
            }

            public Achieve.Builder SetDoNotAck(bool value)
            {
                this.PrepareBuilder();
                this.result.hasDoNotAck = true;
                this.result.doNotAck_ = value;
                return this;
            }

            public Achieve.Builder SetId(int value)
            {
                this.PrepareBuilder();
                this.result.hasId = true;
                this.result.id_ = value;
                return this;
            }

            public Achieve.Builder SetProgress(int value)
            {
                this.PrepareBuilder();
                this.result.hasProgress = true;
                this.result.progress_ = value;
                return this;
            }

            public Achieve.Builder SetStartedCount(int value)
            {
                this.PrepareBuilder();
                this.result.hasStartedCount = true;
                this.result.startedCount_ = value;
                return this;
            }

            public int AckProgress
            {
                get
                {
                    return this.result.AckProgress;
                }
                set
                {
                    this.SetAckProgress(value);
                }
            }

            public bool Active
            {
                get
                {
                    return this.result.Active;
                }
                set
                {
                    this.SetActive(value);
                }
            }

            public int CompletionCount
            {
                get
                {
                    return this.result.CompletionCount;
                }
                set
                {
                    this.SetCompletionCount(value);
                }
            }

            public Date DateCompleted
            {
                get
                {
                    return this.result.DateCompleted;
                }
                set
                {
                    this.SetDateCompleted(value);
                }
            }

            public Date DateGiven
            {
                get
                {
                    return this.result.DateGiven;
                }
                set
                {
                    this.SetDateGiven(value);
                }
            }

            public override Achieve DefaultInstanceForType
            {
                get
                {
                    return Achieve.DefaultInstance;
                }
            }

            public bool DoNotAck
            {
                get
                {
                    return this.result.DoNotAck;
                }
                set
                {
                    this.SetDoNotAck(value);
                }
            }

            public bool HasAckProgress
            {
                get
                {
                    return this.result.hasAckProgress;
                }
            }

            public bool HasActive
            {
                get
                {
                    return this.result.hasActive;
                }
            }

            public bool HasCompletionCount
            {
                get
                {
                    return this.result.hasCompletionCount;
                }
            }

            public bool HasDateCompleted
            {
                get
                {
                    return this.result.hasDateCompleted;
                }
            }

            public bool HasDateGiven
            {
                get
                {
                    return this.result.hasDateGiven;
                }
            }

            public bool HasDoNotAck
            {
                get
                {
                    return this.result.hasDoNotAck;
                }
            }

            public bool HasId
            {
                get
                {
                    return this.result.hasId;
                }
            }

            public bool HasProgress
            {
                get
                {
                    return this.result.hasProgress;
                }
            }

            public bool HasStartedCount
            {
                get
                {
                    return this.result.hasStartedCount;
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

            protected override Achieve MessageBeingBuilt
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

            public int StartedCount
            {
                get
                {
                    return this.result.StartedCount;
                }
                set
                {
                    this.SetStartedCount(value);
                }
            }

            protected override Achieve.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

