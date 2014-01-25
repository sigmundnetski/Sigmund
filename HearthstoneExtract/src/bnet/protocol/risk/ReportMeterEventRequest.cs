namespace bnet.protocol.risk
{
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class ReportMeterEventRequest : GeneratedMessageLite<ReportMeterEventRequest, Builder>
    {
        private static readonly string[] _reportMeterEventRequestFieldNames = new string[] { "additional_penalty_secs", "attribute", "event_type", "meter_type", "object" };
        private static readonly uint[] _reportMeterEventRequestFieldTags = new uint[] { 0x20, 0x2a, 0x12, 13, 0x1a };
        private ulong additionalPenaltySecs_;
        public const int AdditionalPenaltySecsFieldNumber = 4;
        private PopsicleList<bnet.protocol.risk.Attribute> attribute_ = new PopsicleList<bnet.protocol.risk.Attribute>();
        public const int AttributeFieldNumber = 5;
        private static readonly ReportMeterEventRequest defaultInstance = new ReportMeterEventRequest().MakeReadOnly();
        private string eventType_ = string.Empty;
        public const int EventTypeFieldNumber = 2;
        private bool hasAdditionalPenaltySecs;
        private bool hasEventType;
        private bool hasMeterType;
        private bool hasObject;
        private int memoizedSerializedSize = -1;
        private uint meterType_;
        public const int MeterTypeFieldNumber = 1;
        private string object_ = string.Empty;
        public const int ObjectFieldNumber = 3;

        static ReportMeterEventRequest()
        {
            object.ReferenceEquals(Throttle.Descriptor, null);
        }

        private ReportMeterEventRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ReportMeterEventRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ReportMeterEventRequest request = obj as ReportMeterEventRequest;
            if (request == null)
            {
                return false;
            }
            if ((this.hasMeterType != request.hasMeterType) || (this.hasMeterType && !this.meterType_.Equals(request.meterType_)))
            {
                return false;
            }
            if ((this.hasEventType != request.hasEventType) || (this.hasEventType && !this.eventType_.Equals(request.eventType_)))
            {
                return false;
            }
            if ((this.hasObject != request.hasObject) || (this.hasObject && !this.object_.Equals(request.object_)))
            {
                return false;
            }
            if ((this.hasAdditionalPenaltySecs != request.hasAdditionalPenaltySecs) || (this.hasAdditionalPenaltySecs && !this.additionalPenaltySecs_.Equals(request.additionalPenaltySecs_)))
            {
                return false;
            }
            if (this.attribute_.Count != request.attribute_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.attribute_.Count; i++)
            {
                if (!this.attribute_[i].Equals(request.attribute_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public bnet.protocol.risk.Attribute GetAttribute(int index)
        {
            return this.attribute_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasMeterType)
            {
                hashCode ^= this.meterType_.GetHashCode();
            }
            if (this.hasEventType)
            {
                hashCode ^= this.eventType_.GetHashCode();
            }
            if (this.hasObject)
            {
                hashCode ^= this.object_.GetHashCode();
            }
            if (this.hasAdditionalPenaltySecs)
            {
                hashCode ^= this.additionalPenaltySecs_.GetHashCode();
            }
            IEnumerator<bnet.protocol.risk.Attribute> enumerator = this.attribute_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    bnet.protocol.risk.Attribute current = enumerator.Current;
                    hashCode ^= current.GetHashCode();
                }
            }
            finally
            {
                if (enumerator == null)
                {
                }
                enumerator.Dispose();
            }
            return hashCode;
        }

        private ReportMeterEventRequest MakeReadOnly()
        {
            this.attribute_.MakeReadOnly();
            return this;
        }

        public static ReportMeterEventRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ReportMeterEventRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ReportMeterEventRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ReportMeterEventRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ReportMeterEventRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ReportMeterEventRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ReportMeterEventRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ReportMeterEventRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ReportMeterEventRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ReportMeterEventRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ReportMeterEventRequest, Builder>.PrintField("meter_type", this.hasMeterType, this.meterType_, writer);
            GeneratedMessageLite<ReportMeterEventRequest, Builder>.PrintField("event_type", this.hasEventType, this.eventType_, writer);
            GeneratedMessageLite<ReportMeterEventRequest, Builder>.PrintField("object", this.hasObject, this.object_, writer);
            GeneratedMessageLite<ReportMeterEventRequest, Builder>.PrintField("additional_penalty_secs", this.hasAdditionalPenaltySecs, this.additionalPenaltySecs_, writer);
            GeneratedMessageLite<ReportMeterEventRequest, Builder>.PrintField<bnet.protocol.risk.Attribute>("attribute", this.attribute_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _reportMeterEventRequestFieldNames;
            if (this.hasMeterType)
            {
                output.WriteFixed32(1, strArray[3], this.MeterType);
            }
            if (this.hasEventType)
            {
                output.WriteString(2, strArray[2], this.EventType);
            }
            if (this.hasObject)
            {
                output.WriteString(3, strArray[4], this.Object);
            }
            if (this.hasAdditionalPenaltySecs)
            {
                output.WriteUInt64(4, strArray[0], this.AdditionalPenaltySecs);
            }
            if (this.attribute_.Count > 0)
            {
                output.WriteMessageArray<bnet.protocol.risk.Attribute>(5, strArray[1], this.attribute_);
            }
        }

        [CLSCompliant(false)]
        public ulong AdditionalPenaltySecs
        {
            get
            {
                return this.additionalPenaltySecs_;
            }
        }

        public int AttributeCount
        {
            get
            {
                return this.attribute_.Count;
            }
        }

        public IList<bnet.protocol.risk.Attribute> AttributeList
        {
            get
            {
                return this.attribute_;
            }
        }

        public static ReportMeterEventRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ReportMeterEventRequest DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public string EventType
        {
            get
            {
                return this.eventType_;
            }
        }

        public bool HasAdditionalPenaltySecs
        {
            get
            {
                return this.hasAdditionalPenaltySecs;
            }
        }

        public bool HasEventType
        {
            get
            {
                return this.hasEventType;
            }
        }

        public bool HasMeterType
        {
            get
            {
                return this.hasMeterType;
            }
        }

        public bool HasObject
        {
            get
            {
                return this.hasObject;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasMeterType)
                {
                    return false;
                }
                if (!this.hasEventType)
                {
                    return false;
                }
                if (!this.hasObject)
                {
                    return false;
                }
                IEnumerator<bnet.protocol.risk.Attribute> enumerator = this.AttributeList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        bnet.protocol.risk.Attribute current = enumerator.Current;
                        if (!current.IsInitialized)
                        {
                            return false;
                        }
                    }
                }
                finally
                {
                    if (enumerator == null)
                    {
                    }
                    enumerator.Dispose();
                }
                return true;
            }
        }

        [CLSCompliant(false)]
        public uint MeterType
        {
            get
            {
                return this.meterType_;
            }
        }

        public string Object
        {
            get
            {
                return this.object_;
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
                    if (this.hasMeterType)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed32Size(1, this.MeterType);
                    }
                    if (this.hasEventType)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(2, this.EventType);
                    }
                    if (this.hasObject)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(3, this.Object);
                    }
                    if (this.hasAdditionalPenaltySecs)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(4, this.AdditionalPenaltySecs);
                    }
                    IEnumerator<bnet.protocol.risk.Attribute> enumerator = this.AttributeList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            bnet.protocol.risk.Attribute current = enumerator.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(5, current);
                        }
                    }
                    finally
                    {
                        if (enumerator == null)
                        {
                        }
                        enumerator.Dispose();
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ReportMeterEventRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<ReportMeterEventRequest, ReportMeterEventRequest.Builder>
        {
            private ReportMeterEventRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ReportMeterEventRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ReportMeterEventRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public ReportMeterEventRequest.Builder AddAttribute(bnet.protocol.risk.Attribute value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.attribute_.Add(value);
                return this;
            }

            public ReportMeterEventRequest.Builder AddAttribute(bnet.protocol.risk.Attribute.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.attribute_.Add(builderForValue.Build());
                return this;
            }

            public ReportMeterEventRequest.Builder AddRangeAttribute(IEnumerable<bnet.protocol.risk.Attribute> values)
            {
                this.PrepareBuilder();
                this.result.attribute_.Add(values);
                return this;
            }

            public override ReportMeterEventRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ReportMeterEventRequest.Builder Clear()
            {
                this.result = ReportMeterEventRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ReportMeterEventRequest.Builder ClearAdditionalPenaltySecs()
            {
                this.PrepareBuilder();
                this.result.hasAdditionalPenaltySecs = false;
                this.result.additionalPenaltySecs_ = 0L;
                return this;
            }

            public ReportMeterEventRequest.Builder ClearAttribute()
            {
                this.PrepareBuilder();
                this.result.attribute_.Clear();
                return this;
            }

            public ReportMeterEventRequest.Builder ClearEventType()
            {
                this.PrepareBuilder();
                this.result.hasEventType = false;
                this.result.eventType_ = string.Empty;
                return this;
            }

            public ReportMeterEventRequest.Builder ClearMeterType()
            {
                this.PrepareBuilder();
                this.result.hasMeterType = false;
                this.result.meterType_ = 0;
                return this;
            }

            public ReportMeterEventRequest.Builder ClearObject()
            {
                this.PrepareBuilder();
                this.result.hasObject = false;
                this.result.object_ = string.Empty;
                return this;
            }

            public override ReportMeterEventRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ReportMeterEventRequest.Builder(this.result);
                }
                return new ReportMeterEventRequest.Builder().MergeFrom(this.result);
            }

            public bnet.protocol.risk.Attribute GetAttribute(int index)
            {
                return this.result.GetAttribute(index);
            }

            public override ReportMeterEventRequest.Builder MergeFrom(ReportMeterEventRequest other)
            {
                if (other != ReportMeterEventRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasMeterType)
                    {
                        this.MeterType = other.MeterType;
                    }
                    if (other.HasEventType)
                    {
                        this.EventType = other.EventType;
                    }
                    if (other.HasObject)
                    {
                        this.Object = other.Object;
                    }
                    if (other.HasAdditionalPenaltySecs)
                    {
                        this.AdditionalPenaltySecs = other.AdditionalPenaltySecs;
                    }
                    if (other.attribute_.Count != 0)
                    {
                        this.result.attribute_.Add(other.attribute_);
                    }
                }
                return this;
            }

            public override ReportMeterEventRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ReportMeterEventRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is ReportMeterEventRequest)
                {
                    return this.MergeFrom((ReportMeterEventRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ReportMeterEventRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ReportMeterEventRequest._reportMeterEventRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ReportMeterEventRequest._reportMeterEventRequestFieldTags[index];
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

                        case 13:
                        {
                            this.result.hasMeterType = input.ReadFixed32(ref this.result.meterType_);
                            continue;
                        }
                        case 0x12:
                        {
                            this.result.hasEventType = input.ReadString(ref this.result.eventType_);
                            continue;
                        }
                        case 0x1a:
                        {
                            this.result.hasObject = input.ReadString(ref this.result.object_);
                            continue;
                        }
                        case 0x20:
                        {
                            this.result.hasAdditionalPenaltySecs = input.ReadUInt64(ref this.result.additionalPenaltySecs_);
                            continue;
                        }
                        case 0x2a:
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
                    input.ReadMessageArray<bnet.protocol.risk.Attribute>(num, str, this.result.attribute_, bnet.protocol.risk.Attribute.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private ReportMeterEventRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ReportMeterEventRequest result = this.result;
                    this.result = new ReportMeterEventRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public ReportMeterEventRequest.Builder SetAdditionalPenaltySecs(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasAdditionalPenaltySecs = true;
                this.result.additionalPenaltySecs_ = value;
                return this;
            }

            public ReportMeterEventRequest.Builder SetAttribute(int index, bnet.protocol.risk.Attribute value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.attribute_[index] = value;
                return this;
            }

            public ReportMeterEventRequest.Builder SetAttribute(int index, bnet.protocol.risk.Attribute.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.attribute_[index] = builderForValue.Build();
                return this;
            }

            public ReportMeterEventRequest.Builder SetEventType(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasEventType = true;
                this.result.eventType_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public ReportMeterEventRequest.Builder SetMeterType(uint value)
            {
                this.PrepareBuilder();
                this.result.hasMeterType = true;
                this.result.meterType_ = value;
                return this;
            }

            public ReportMeterEventRequest.Builder SetObject(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasObject = true;
                this.result.object_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public ulong AdditionalPenaltySecs
            {
                get
                {
                    return this.result.AdditionalPenaltySecs;
                }
                set
                {
                    this.SetAdditionalPenaltySecs(value);
                }
            }

            public int AttributeCount
            {
                get
                {
                    return this.result.AttributeCount;
                }
            }

            public IPopsicleList<bnet.protocol.risk.Attribute> AttributeList
            {
                get
                {
                    return this.PrepareBuilder().attribute_;
                }
            }

            public override ReportMeterEventRequest DefaultInstanceForType
            {
                get
                {
                    return ReportMeterEventRequest.DefaultInstance;
                }
            }

            public string EventType
            {
                get
                {
                    return this.result.EventType;
                }
                set
                {
                    this.SetEventType(value);
                }
            }

            public bool HasAdditionalPenaltySecs
            {
                get
                {
                    return this.result.hasAdditionalPenaltySecs;
                }
            }

            public bool HasEventType
            {
                get
                {
                    return this.result.hasEventType;
                }
            }

            public bool HasMeterType
            {
                get
                {
                    return this.result.hasMeterType;
                }
            }

            public bool HasObject
            {
                get
                {
                    return this.result.hasObject;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override ReportMeterEventRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            [CLSCompliant(false)]
            public uint MeterType
            {
                get
                {
                    return this.result.MeterType;
                }
                set
                {
                    this.SetMeterType(value);
                }
            }

            public string Object
            {
                get
                {
                    return this.result.Object;
                }
                set
                {
                    this.SetObject(value);
                }
            }

            protected override ReportMeterEventRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

