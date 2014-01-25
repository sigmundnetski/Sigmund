namespace bnet.protocol.risk
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class ReportMeterEventResponse : GeneratedMessageLite<ReportMeterEventResponse, Builder>
    {
        private static readonly string[] _reportMeterEventResponseFieldNames = new string[] { "penalty_secs", "threshold" };
        private static readonly uint[] _reportMeterEventResponseFieldTags = new uint[] { 8, 0x10 };
        private static readonly ReportMeterEventResponse defaultInstance = new ReportMeterEventResponse().MakeReadOnly();
        private bool hasPenaltySecs;
        private bool hasThreshold;
        private int memoizedSerializedSize = -1;
        private ulong penaltySecs_;
        public const int PenaltySecsFieldNumber = 1;
        private ulong threshold_;
        public const int ThresholdFieldNumber = 2;

        static ReportMeterEventResponse()
        {
            object.ReferenceEquals(Throttle.Descriptor, null);
        }

        private ReportMeterEventResponse()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ReportMeterEventResponse prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ReportMeterEventResponse response = obj as ReportMeterEventResponse;
            if (response == null)
            {
                return false;
            }
            if ((this.hasPenaltySecs != response.hasPenaltySecs) || (this.hasPenaltySecs && !this.penaltySecs_.Equals(response.penaltySecs_)))
            {
                return false;
            }
            return ((this.hasThreshold == response.hasThreshold) && (!this.hasThreshold || this.threshold_.Equals(response.threshold_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasPenaltySecs)
            {
                hashCode ^= this.penaltySecs_.GetHashCode();
            }
            if (this.hasThreshold)
            {
                hashCode ^= this.threshold_.GetHashCode();
            }
            return hashCode;
        }

        private ReportMeterEventResponse MakeReadOnly()
        {
            return this;
        }

        public static ReportMeterEventResponse ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ReportMeterEventResponse ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ReportMeterEventResponse ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ReportMeterEventResponse ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ReportMeterEventResponse ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ReportMeterEventResponse ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ReportMeterEventResponse ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ReportMeterEventResponse ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ReportMeterEventResponse ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ReportMeterEventResponse ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ReportMeterEventResponse, Builder>.PrintField("penalty_secs", this.hasPenaltySecs, this.penaltySecs_, writer);
            GeneratedMessageLite<ReportMeterEventResponse, Builder>.PrintField("threshold", this.hasThreshold, this.threshold_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _reportMeterEventResponseFieldNames;
            if (this.hasPenaltySecs)
            {
                output.WriteUInt64(1, strArray[0], this.PenaltySecs);
            }
            if (this.hasThreshold)
            {
                output.WriteUInt64(2, strArray[1], this.Threshold);
            }
        }

        public static ReportMeterEventResponse DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ReportMeterEventResponse DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasPenaltySecs
        {
            get
            {
                return this.hasPenaltySecs;
            }
        }

        public bool HasThreshold
        {
            get
            {
                return this.hasThreshold;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasPenaltySecs)
                {
                    return false;
                }
                if (!this.hasThreshold)
                {
                    return false;
                }
                return true;
            }
        }

        [CLSCompliant(false)]
        public ulong PenaltySecs
        {
            get
            {
                return this.penaltySecs_;
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
                    if (this.hasPenaltySecs)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(1, this.PenaltySecs);
                    }
                    if (this.hasThreshold)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(2, this.Threshold);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ReportMeterEventResponse ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CLSCompliant(false)]
        public ulong Threshold
        {
            get
            {
                return this.threshold_;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<ReportMeterEventResponse, ReportMeterEventResponse.Builder>
        {
            private ReportMeterEventResponse result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ReportMeterEventResponse.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ReportMeterEventResponse cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override ReportMeterEventResponse BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ReportMeterEventResponse.Builder Clear()
            {
                this.result = ReportMeterEventResponse.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ReportMeterEventResponse.Builder ClearPenaltySecs()
            {
                this.PrepareBuilder();
                this.result.hasPenaltySecs = false;
                this.result.penaltySecs_ = 0L;
                return this;
            }

            public ReportMeterEventResponse.Builder ClearThreshold()
            {
                this.PrepareBuilder();
                this.result.hasThreshold = false;
                this.result.threshold_ = 0L;
                return this;
            }

            public override ReportMeterEventResponse.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ReportMeterEventResponse.Builder(this.result);
                }
                return new ReportMeterEventResponse.Builder().MergeFrom(this.result);
            }

            public override ReportMeterEventResponse.Builder MergeFrom(ReportMeterEventResponse other)
            {
                if (other != ReportMeterEventResponse.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasPenaltySecs)
                    {
                        this.PenaltySecs = other.PenaltySecs;
                    }
                    if (other.HasThreshold)
                    {
                        this.Threshold = other.Threshold;
                    }
                }
                return this;
            }

            public override ReportMeterEventResponse.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ReportMeterEventResponse.Builder MergeFrom(IMessageLite other)
            {
                if (other is ReportMeterEventResponse)
                {
                    return this.MergeFrom((ReportMeterEventResponse) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ReportMeterEventResponse.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ReportMeterEventResponse._reportMeterEventResponseFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ReportMeterEventResponse._reportMeterEventResponseFieldTags[index];
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
                            this.result.hasPenaltySecs = input.ReadUInt64(ref this.result.penaltySecs_);
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
                    this.result.hasThreshold = input.ReadUInt64(ref this.result.threshold_);
                }
                return this;
            }

            private ReportMeterEventResponse PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ReportMeterEventResponse result = this.result;
                    this.result = new ReportMeterEventResponse();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public ReportMeterEventResponse.Builder SetPenaltySecs(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasPenaltySecs = true;
                this.result.penaltySecs_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public ReportMeterEventResponse.Builder SetThreshold(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasThreshold = true;
                this.result.threshold_ = value;
                return this;
            }

            public override ReportMeterEventResponse DefaultInstanceForType
            {
                get
                {
                    return ReportMeterEventResponse.DefaultInstance;
                }
            }

            public bool HasPenaltySecs
            {
                get
                {
                    return this.result.hasPenaltySecs;
                }
            }

            public bool HasThreshold
            {
                get
                {
                    return this.result.hasThreshold;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override ReportMeterEventResponse MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            [CLSCompliant(false)]
            public ulong PenaltySecs
            {
                get
                {
                    return this.result.PenaltySecs;
                }
                set
                {
                    this.SetPenaltySecs(value);
                }
            }

            protected override ReportMeterEventResponse.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            [CLSCompliant(false)]
            public ulong Threshold
            {
                get
                {
                    return this.result.Threshold;
                }
                set
                {
                    this.SetThreshold(value);
                }
            }
        }
    }
}

