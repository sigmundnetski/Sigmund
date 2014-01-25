namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class DebugProfilingFrame : GeneratedMessageLite<DebugProfilingFrame, Builder>
    {
        private static readonly string[] _debugProfilingFrameFieldNames = new string[] { "samples" };
        private static readonly uint[] _debugProfilingFrameFieldTags = new uint[] { 10 };
        private static readonly DebugProfilingFrame defaultInstance = new DebugProfilingFrame().MakeReadOnly();
        private int memoizedSerializedSize = -1;
        private PopsicleList<Types.DebugProfilingSample> samples_ = new PopsicleList<Types.DebugProfilingSample>();
        public const int SamplesFieldNumber = 1;

        static DebugProfilingFrame()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private DebugProfilingFrame()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DebugProfilingFrame prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DebugProfilingFrame frame = obj as DebugProfilingFrame;
            if (frame == null)
            {
                return false;
            }
            if (this.samples_.Count != frame.samples_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.samples_.Count; i++)
            {
                if (!this.samples_[i].Equals(frame.samples_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<Types.DebugProfilingSample> enumerator = this.samples_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    Types.DebugProfilingSample current = enumerator.Current;
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

        public Types.DebugProfilingSample GetSamples(int index)
        {
            return this.samples_[index];
        }

        private DebugProfilingFrame MakeReadOnly()
        {
            this.samples_.MakeReadOnly();
            return this;
        }

        public static DebugProfilingFrame ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DebugProfilingFrame ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DebugProfilingFrame ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DebugProfilingFrame ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DebugProfilingFrame ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DebugProfilingFrame ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DebugProfilingFrame ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DebugProfilingFrame ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DebugProfilingFrame ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DebugProfilingFrame ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DebugProfilingFrame, Builder>.PrintField<Types.DebugProfilingSample>("samples", this.samples_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _debugProfilingFrameFieldNames;
            if (this.samples_.Count > 0)
            {
                output.WriteMessageArray<Types.DebugProfilingSample>(1, strArray[0], this.samples_);
            }
        }

        public static DebugProfilingFrame DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DebugProfilingFrame DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                IEnumerator<Types.DebugProfilingSample> enumerator = this.SamplesList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        Types.DebugProfilingSample current = enumerator.Current;
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

        public int SamplesCount
        {
            get
            {
                return this.samples_.Count;
            }
        }

        public IList<Types.DebugProfilingSample> SamplesList
        {
            get
            {
                return this.samples_;
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
                    IEnumerator<Types.DebugProfilingSample> enumerator = this.SamplesList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            Types.DebugProfilingSample current = enumerator.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, current);
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

        protected override DebugProfilingFrame ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<DebugProfilingFrame, DebugProfilingFrame.Builder>
        {
            private DebugProfilingFrame result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DebugProfilingFrame.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DebugProfilingFrame cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public DebugProfilingFrame.Builder AddRangeSamples(IEnumerable<DebugProfilingFrame.Types.DebugProfilingSample> values)
            {
                this.PrepareBuilder();
                this.result.samples_.Add(values);
                return this;
            }

            public DebugProfilingFrame.Builder AddSamples(DebugProfilingFrame.Types.DebugProfilingSample value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.samples_.Add(value);
                return this;
            }

            public DebugProfilingFrame.Builder AddSamples(DebugProfilingFrame.Types.DebugProfilingSample.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.samples_.Add(builderForValue.Build());
                return this;
            }

            public override DebugProfilingFrame BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DebugProfilingFrame.Builder Clear()
            {
                this.result = DebugProfilingFrame.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DebugProfilingFrame.Builder ClearSamples()
            {
                this.PrepareBuilder();
                this.result.samples_.Clear();
                return this;
            }

            public override DebugProfilingFrame.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DebugProfilingFrame.Builder(this.result);
                }
                return new DebugProfilingFrame.Builder().MergeFrom(this.result);
            }

            public DebugProfilingFrame.Types.DebugProfilingSample GetSamples(int index)
            {
                return this.result.GetSamples(index);
            }

            public override DebugProfilingFrame.Builder MergeFrom(DebugProfilingFrame other)
            {
                if (other != DebugProfilingFrame.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.samples_.Count != 0)
                    {
                        this.result.samples_.Add(other.samples_);
                    }
                }
                return this;
            }

            public override DebugProfilingFrame.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DebugProfilingFrame.Builder MergeFrom(IMessageLite other)
            {
                if (other is DebugProfilingFrame)
                {
                    return this.MergeFrom((DebugProfilingFrame) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DebugProfilingFrame.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DebugProfilingFrame._debugProfilingFrameFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DebugProfilingFrame._debugProfilingFrameFieldTags[index];
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

                        case 10:
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
                    input.ReadMessageArray<DebugProfilingFrame.Types.DebugProfilingSample>(num, str, this.result.samples_, DebugProfilingFrame.Types.DebugProfilingSample.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private DebugProfilingFrame PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DebugProfilingFrame result = this.result;
                    this.result = new DebugProfilingFrame();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DebugProfilingFrame.Builder SetSamples(int index, DebugProfilingFrame.Types.DebugProfilingSample value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.samples_[index] = value;
                return this;
            }

            public DebugProfilingFrame.Builder SetSamples(int index, DebugProfilingFrame.Types.DebugProfilingSample.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.samples_[index] = builderForValue.Build();
                return this;
            }

            public override DebugProfilingFrame DefaultInstanceForType
            {
                get
                {
                    return DebugProfilingFrame.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override DebugProfilingFrame MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int SamplesCount
            {
                get
                {
                    return this.result.SamplesCount;
                }
            }

            public IPopsicleList<DebugProfilingFrame.Types.DebugProfilingSample> SamplesList
            {
                get
                {
                    return this.PrepareBuilder().samples_;
                }
            }

            protected override DebugProfilingFrame.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
            public sealed class DebugProfilingSample : GeneratedMessageLite<DebugProfilingFrame.Types.DebugProfilingSample, Builder>
            {
                private static readonly string[] _debugProfilingSampleFieldNames = new string[] { "active", "endstamp", "level", "sectionid", "sectionname", "startofframe", "startstamp", "threadid" };
                private static readonly uint[] _debugProfilingSampleFieldTags = new uint[] { 0x38, 0x18, 0x30, 40, 10, 0x40, 0x10, 0x20 };
                private bool active_;
                public const int ActiveFieldNumber = 7;
                private static readonly DebugProfilingFrame.Types.DebugProfilingSample defaultInstance = new DebugProfilingFrame.Types.DebugProfilingSample().MakeReadOnly();
                private ulong endstamp_;
                public const int EndstampFieldNumber = 3;
                private bool hasActive;
                private bool hasEndstamp;
                private bool hasLevel;
                private bool hasSectionid;
                private bool hasSectionname;
                private bool hasStartofframe;
                private bool hasStartstamp;
                private bool hasThreadid;
                private uint level_;
                public const int LevelFieldNumber = 6;
                private int memoizedSerializedSize = -1;
                private uint sectionid_;
                public const int SectionidFieldNumber = 5;
                private string sectionname_ = string.Empty;
                public const int SectionnameFieldNumber = 1;
                private bool startofframe_;
                public const int StartofframeFieldNumber = 8;
                private ulong startstamp_;
                public const int StartstampFieldNumber = 2;
                private uint threadid_;
                public const int ThreadidFieldNumber = 4;

                static DebugProfilingSample()
                {
                    object.ReferenceEquals(BobNetlite.Descriptor, null);
                }

                private DebugProfilingSample()
                {
                }

                public static Builder CreateBuilder()
                {
                    return new Builder();
                }

                public static Builder CreateBuilder(DebugProfilingFrame.Types.DebugProfilingSample prototype)
                {
                    return new Builder(prototype);
                }

                public override Builder CreateBuilderForType()
                {
                    return new Builder();
                }

                public override bool Equals(object obj)
                {
                    DebugProfilingFrame.Types.DebugProfilingSample sample = obj as DebugProfilingFrame.Types.DebugProfilingSample;
                    if (sample == null)
                    {
                        return false;
                    }
                    if ((this.hasSectionname != sample.hasSectionname) || (this.hasSectionname && !this.sectionname_.Equals(sample.sectionname_)))
                    {
                        return false;
                    }
                    if ((this.hasStartstamp != sample.hasStartstamp) || (this.hasStartstamp && !this.startstamp_.Equals(sample.startstamp_)))
                    {
                        return false;
                    }
                    if ((this.hasEndstamp != sample.hasEndstamp) || (this.hasEndstamp && !this.endstamp_.Equals(sample.endstamp_)))
                    {
                        return false;
                    }
                    if ((this.hasThreadid != sample.hasThreadid) || (this.hasThreadid && !this.threadid_.Equals(sample.threadid_)))
                    {
                        return false;
                    }
                    if ((this.hasSectionid != sample.hasSectionid) || (this.hasSectionid && !this.sectionid_.Equals(sample.sectionid_)))
                    {
                        return false;
                    }
                    if ((this.hasLevel != sample.hasLevel) || (this.hasLevel && !this.level_.Equals(sample.level_)))
                    {
                        return false;
                    }
                    if ((this.hasActive != sample.hasActive) || (this.hasActive && !this.active_.Equals(sample.active_)))
                    {
                        return false;
                    }
                    return ((this.hasStartofframe == sample.hasStartofframe) && (!this.hasStartofframe || this.startofframe_.Equals(sample.startofframe_)));
                }

                public override int GetHashCode()
                {
                    int hashCode = base.GetType().GetHashCode();
                    if (this.hasSectionname)
                    {
                        hashCode ^= this.sectionname_.GetHashCode();
                    }
                    if (this.hasStartstamp)
                    {
                        hashCode ^= this.startstamp_.GetHashCode();
                    }
                    if (this.hasEndstamp)
                    {
                        hashCode ^= this.endstamp_.GetHashCode();
                    }
                    if (this.hasThreadid)
                    {
                        hashCode ^= this.threadid_.GetHashCode();
                    }
                    if (this.hasSectionid)
                    {
                        hashCode ^= this.sectionid_.GetHashCode();
                    }
                    if (this.hasLevel)
                    {
                        hashCode ^= this.level_.GetHashCode();
                    }
                    if (this.hasActive)
                    {
                        hashCode ^= this.active_.GetHashCode();
                    }
                    if (this.hasStartofframe)
                    {
                        hashCode ^= this.startofframe_.GetHashCode();
                    }
                    return hashCode;
                }

                private DebugProfilingFrame.Types.DebugProfilingSample MakeReadOnly()
                {
                    return this;
                }

                public static DebugProfilingFrame.Types.DebugProfilingSample ParseDelimitedFrom(Stream input)
                {
                    return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
                }

                public static DebugProfilingFrame.Types.DebugProfilingSample ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
                {
                    return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
                }

                public static DebugProfilingFrame.Types.DebugProfilingSample ParseFrom(byte[] data)
                {
                    return CreateBuilder().MergeFrom(data).BuildParsed();
                }

                public static DebugProfilingFrame.Types.DebugProfilingSample ParseFrom(ByteString data)
                {
                    return CreateBuilder().MergeFrom(data).BuildParsed();
                }

                public static DebugProfilingFrame.Types.DebugProfilingSample ParseFrom(ICodedInputStream input)
                {
                    return CreateBuilder().MergeFrom(input).BuildParsed();
                }

                public static DebugProfilingFrame.Types.DebugProfilingSample ParseFrom(Stream input)
                {
                    return CreateBuilder().MergeFrom(input).BuildParsed();
                }

                public static DebugProfilingFrame.Types.DebugProfilingSample ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
                {
                    return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
                }

                public static DebugProfilingFrame.Types.DebugProfilingSample ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
                {
                    return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
                }

                public static DebugProfilingFrame.Types.DebugProfilingSample ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
                {
                    return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
                }

                public static DebugProfilingFrame.Types.DebugProfilingSample ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
                {
                    return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
                }

                public override void PrintTo(TextWriter writer)
                {
                    GeneratedMessageLite<DebugProfilingFrame.Types.DebugProfilingSample, Builder>.PrintField("sectionname", this.hasSectionname, this.sectionname_, writer);
                    GeneratedMessageLite<DebugProfilingFrame.Types.DebugProfilingSample, Builder>.PrintField("startstamp", this.hasStartstamp, this.startstamp_, writer);
                    GeneratedMessageLite<DebugProfilingFrame.Types.DebugProfilingSample, Builder>.PrintField("endstamp", this.hasEndstamp, this.endstamp_, writer);
                    GeneratedMessageLite<DebugProfilingFrame.Types.DebugProfilingSample, Builder>.PrintField("threadid", this.hasThreadid, this.threadid_, writer);
                    GeneratedMessageLite<DebugProfilingFrame.Types.DebugProfilingSample, Builder>.PrintField("sectionid", this.hasSectionid, this.sectionid_, writer);
                    GeneratedMessageLite<DebugProfilingFrame.Types.DebugProfilingSample, Builder>.PrintField("level", this.hasLevel, this.level_, writer);
                    GeneratedMessageLite<DebugProfilingFrame.Types.DebugProfilingSample, Builder>.PrintField("active", this.hasActive, this.active_, writer);
                    GeneratedMessageLite<DebugProfilingFrame.Types.DebugProfilingSample, Builder>.PrintField("startofframe", this.hasStartofframe, this.startofframe_, writer);
                }

                public override Builder ToBuilder()
                {
                    return CreateBuilder(this);
                }

                public override void WriteTo(ICodedOutputStream output)
                {
                    int serializedSize = this.SerializedSize;
                    string[] strArray = _debugProfilingSampleFieldNames;
                    if (this.hasSectionname)
                    {
                        output.WriteString(1, strArray[4], this.Sectionname);
                    }
                    if (this.hasStartstamp)
                    {
                        output.WriteUInt64(2, strArray[6], this.Startstamp);
                    }
                    if (this.hasEndstamp)
                    {
                        output.WriteUInt64(3, strArray[1], this.Endstamp);
                    }
                    if (this.hasThreadid)
                    {
                        output.WriteUInt32(4, strArray[7], this.Threadid);
                    }
                    if (this.hasSectionid)
                    {
                        output.WriteUInt32(5, strArray[3], this.Sectionid);
                    }
                    if (this.hasLevel)
                    {
                        output.WriteUInt32(6, strArray[2], this.Level);
                    }
                    if (this.hasActive)
                    {
                        output.WriteBool(7, strArray[0], this.Active);
                    }
                    if (this.hasStartofframe)
                    {
                        output.WriteBool(8, strArray[5], this.Startofframe);
                    }
                }

                public bool Active
                {
                    get
                    {
                        return this.active_;
                    }
                }

                public static DebugProfilingFrame.Types.DebugProfilingSample DefaultInstance
                {
                    get
                    {
                        return defaultInstance;
                    }
                }

                public override DebugProfilingFrame.Types.DebugProfilingSample DefaultInstanceForType
                {
                    get
                    {
                        return DefaultInstance;
                    }
                }

                [CLSCompliant(false)]
                public ulong Endstamp
                {
                    get
                    {
                        return this.endstamp_;
                    }
                }

                public bool HasActive
                {
                    get
                    {
                        return this.hasActive;
                    }
                }

                public bool HasEndstamp
                {
                    get
                    {
                        return this.hasEndstamp;
                    }
                }

                public bool HasLevel
                {
                    get
                    {
                        return this.hasLevel;
                    }
                }

                public bool HasSectionid
                {
                    get
                    {
                        return this.hasSectionid;
                    }
                }

                public bool HasSectionname
                {
                    get
                    {
                        return this.hasSectionname;
                    }
                }

                public bool HasStartofframe
                {
                    get
                    {
                        return this.hasStartofframe;
                    }
                }

                public bool HasStartstamp
                {
                    get
                    {
                        return this.hasStartstamp;
                    }
                }

                public bool HasThreadid
                {
                    get
                    {
                        return this.hasThreadid;
                    }
                }

                public override bool IsInitialized
                {
                    get
                    {
                        if (!this.hasSectionname)
                        {
                            return false;
                        }
                        if (!this.hasStartstamp)
                        {
                            return false;
                        }
                        if (!this.hasEndstamp)
                        {
                            return false;
                        }
                        if (!this.hasThreadid)
                        {
                            return false;
                        }
                        if (!this.hasSectionid)
                        {
                            return false;
                        }
                        if (!this.hasLevel)
                        {
                            return false;
                        }
                        if (!this.hasActive)
                        {
                            return false;
                        }
                        if (!this.hasStartofframe)
                        {
                            return false;
                        }
                        return true;
                    }
                }

                [CLSCompliant(false)]
                public uint Level
                {
                    get
                    {
                        return this.level_;
                    }
                }

                [CLSCompliant(false)]
                public uint Sectionid
                {
                    get
                    {
                        return this.sectionid_;
                    }
                }

                public string Sectionname
                {
                    get
                    {
                        return this.sectionname_;
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
                            if (this.hasSectionname)
                            {
                                memoizedSerializedSize += CodedOutputStream.ComputeStringSize(1, this.Sectionname);
                            }
                            if (this.hasStartstamp)
                            {
                                memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(2, this.Startstamp);
                            }
                            if (this.hasEndstamp)
                            {
                                memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(3, this.Endstamp);
                            }
                            if (this.hasThreadid)
                            {
                                memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(4, this.Threadid);
                            }
                            if (this.hasSectionid)
                            {
                                memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(5, this.Sectionid);
                            }
                            if (this.hasLevel)
                            {
                                memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(6, this.Level);
                            }
                            if (this.hasActive)
                            {
                                memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(7, this.Active);
                            }
                            if (this.hasStartofframe)
                            {
                                memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(8, this.Startofframe);
                            }
                            this.memoizedSerializedSize = memoizedSerializedSize;
                        }
                        return memoizedSerializedSize;
                    }
                }

                public bool Startofframe
                {
                    get
                    {
                        return this.startofframe_;
                    }
                }

                [CLSCompliant(false)]
                public ulong Startstamp
                {
                    get
                    {
                        return this.startstamp_;
                    }
                }

                protected override DebugProfilingFrame.Types.DebugProfilingSample ThisMessage
                {
                    get
                    {
                        return this;
                    }
                }

                [CLSCompliant(false)]
                public uint Threadid
                {
                    get
                    {
                        return this.threadid_;
                    }
                }

                [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
                public sealed class Builder : GeneratedBuilderLite<DebugProfilingFrame.Types.DebugProfilingSample, DebugProfilingFrame.Types.DebugProfilingSample.Builder>
                {
                    private DebugProfilingFrame.Types.DebugProfilingSample result;
                    private bool resultIsReadOnly;

                    public Builder()
                    {
                        this.result = DebugProfilingFrame.Types.DebugProfilingSample.DefaultInstance;
                        this.resultIsReadOnly = true;
                    }

                    internal Builder(DebugProfilingFrame.Types.DebugProfilingSample cloneFrom)
                    {
                        this.result = cloneFrom;
                        this.resultIsReadOnly = true;
                    }

                    public override DebugProfilingFrame.Types.DebugProfilingSample BuildPartial()
                    {
                        if (this.resultIsReadOnly)
                        {
                            return this.result;
                        }
                        this.resultIsReadOnly = true;
                        return this.result.MakeReadOnly();
                    }

                    public override DebugProfilingFrame.Types.DebugProfilingSample.Builder Clear()
                    {
                        this.result = DebugProfilingFrame.Types.DebugProfilingSample.DefaultInstance;
                        this.resultIsReadOnly = true;
                        return this;
                    }

                    public DebugProfilingFrame.Types.DebugProfilingSample.Builder ClearActive()
                    {
                        this.PrepareBuilder();
                        this.result.hasActive = false;
                        this.result.active_ = false;
                        return this;
                    }

                    public DebugProfilingFrame.Types.DebugProfilingSample.Builder ClearEndstamp()
                    {
                        this.PrepareBuilder();
                        this.result.hasEndstamp = false;
                        this.result.endstamp_ = 0L;
                        return this;
                    }

                    public DebugProfilingFrame.Types.DebugProfilingSample.Builder ClearLevel()
                    {
                        this.PrepareBuilder();
                        this.result.hasLevel = false;
                        this.result.level_ = 0;
                        return this;
                    }

                    public DebugProfilingFrame.Types.DebugProfilingSample.Builder ClearSectionid()
                    {
                        this.PrepareBuilder();
                        this.result.hasSectionid = false;
                        this.result.sectionid_ = 0;
                        return this;
                    }

                    public DebugProfilingFrame.Types.DebugProfilingSample.Builder ClearSectionname()
                    {
                        this.PrepareBuilder();
                        this.result.hasSectionname = false;
                        this.result.sectionname_ = string.Empty;
                        return this;
                    }

                    public DebugProfilingFrame.Types.DebugProfilingSample.Builder ClearStartofframe()
                    {
                        this.PrepareBuilder();
                        this.result.hasStartofframe = false;
                        this.result.startofframe_ = false;
                        return this;
                    }

                    public DebugProfilingFrame.Types.DebugProfilingSample.Builder ClearStartstamp()
                    {
                        this.PrepareBuilder();
                        this.result.hasStartstamp = false;
                        this.result.startstamp_ = 0L;
                        return this;
                    }

                    public DebugProfilingFrame.Types.DebugProfilingSample.Builder ClearThreadid()
                    {
                        this.PrepareBuilder();
                        this.result.hasThreadid = false;
                        this.result.threadid_ = 0;
                        return this;
                    }

                    public override DebugProfilingFrame.Types.DebugProfilingSample.Builder Clone()
                    {
                        if (this.resultIsReadOnly)
                        {
                            return new DebugProfilingFrame.Types.DebugProfilingSample.Builder(this.result);
                        }
                        return new DebugProfilingFrame.Types.DebugProfilingSample.Builder().MergeFrom(this.result);
                    }

                    public override DebugProfilingFrame.Types.DebugProfilingSample.Builder MergeFrom(DebugProfilingFrame.Types.DebugProfilingSample other)
                    {
                        if (other != DebugProfilingFrame.Types.DebugProfilingSample.DefaultInstance)
                        {
                            this.PrepareBuilder();
                            if (other.HasSectionname)
                            {
                                this.Sectionname = other.Sectionname;
                            }
                            if (other.HasStartstamp)
                            {
                                this.Startstamp = other.Startstamp;
                            }
                            if (other.HasEndstamp)
                            {
                                this.Endstamp = other.Endstamp;
                            }
                            if (other.HasThreadid)
                            {
                                this.Threadid = other.Threadid;
                            }
                            if (other.HasSectionid)
                            {
                                this.Sectionid = other.Sectionid;
                            }
                            if (other.HasLevel)
                            {
                                this.Level = other.Level;
                            }
                            if (other.HasActive)
                            {
                                this.Active = other.Active;
                            }
                            if (other.HasStartofframe)
                            {
                                this.Startofframe = other.Startofframe;
                            }
                        }
                        return this;
                    }

                    public override DebugProfilingFrame.Types.DebugProfilingSample.Builder MergeFrom(ICodedInputStream input)
                    {
                        return this.MergeFrom(input, ExtensionRegistry.Empty);
                    }

                    public override DebugProfilingFrame.Types.DebugProfilingSample.Builder MergeFrom(IMessageLite other)
                    {
                        if (other is DebugProfilingFrame.Types.DebugProfilingSample)
                        {
                            return this.MergeFrom((DebugProfilingFrame.Types.DebugProfilingSample) other);
                        }
                        base.MergeFrom(other);
                        return this;
                    }

                    public override DebugProfilingFrame.Types.DebugProfilingSample.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
                    {
                        uint num;
                        string str;
                        this.PrepareBuilder();
                        while (input.ReadTag(out num, out str))
                        {
                            if ((num == 0) && (str != null))
                            {
                                int index = Array.BinarySearch<string>(DebugProfilingFrame.Types.DebugProfilingSample._debugProfilingSampleFieldNames, str, StringComparer.Ordinal);
                                if (index >= 0)
                                {
                                    num = DebugProfilingFrame.Types.DebugProfilingSample._debugProfilingSampleFieldTags[index];
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

                                case 10:
                                {
                                    this.result.hasSectionname = input.ReadString(ref this.result.sectionname_);
                                    continue;
                                }
                                case 0x10:
                                {
                                    this.result.hasStartstamp = input.ReadUInt64(ref this.result.startstamp_);
                                    continue;
                                }
                                case 0x18:
                                {
                                    this.result.hasEndstamp = input.ReadUInt64(ref this.result.endstamp_);
                                    continue;
                                }
                                case 0x20:
                                {
                                    this.result.hasThreadid = input.ReadUInt32(ref this.result.threadid_);
                                    continue;
                                }
                                case 40:
                                {
                                    this.result.hasSectionid = input.ReadUInt32(ref this.result.sectionid_);
                                    continue;
                                }
                                case 0x30:
                                {
                                    this.result.hasLevel = input.ReadUInt32(ref this.result.level_);
                                    continue;
                                }
                                case 0x38:
                                {
                                    this.result.hasActive = input.ReadBool(ref this.result.active_);
                                    continue;
                                }
                                case 0x40:
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
                            this.result.hasStartofframe = input.ReadBool(ref this.result.startofframe_);
                        }
                        return this;
                    }

                    private DebugProfilingFrame.Types.DebugProfilingSample PrepareBuilder()
                    {
                        if (this.resultIsReadOnly)
                        {
                            DebugProfilingFrame.Types.DebugProfilingSample result = this.result;
                            this.result = new DebugProfilingFrame.Types.DebugProfilingSample();
                            this.resultIsReadOnly = false;
                            this.MergeFrom(result);
                        }
                        return this.result;
                    }

                    public DebugProfilingFrame.Types.DebugProfilingSample.Builder SetActive(bool value)
                    {
                        this.PrepareBuilder();
                        this.result.hasActive = true;
                        this.result.active_ = value;
                        return this;
                    }

                    [CLSCompliant(false)]
                    public DebugProfilingFrame.Types.DebugProfilingSample.Builder SetEndstamp(ulong value)
                    {
                        this.PrepareBuilder();
                        this.result.hasEndstamp = true;
                        this.result.endstamp_ = value;
                        return this;
                    }

                    [CLSCompliant(false)]
                    public DebugProfilingFrame.Types.DebugProfilingSample.Builder SetLevel(uint value)
                    {
                        this.PrepareBuilder();
                        this.result.hasLevel = true;
                        this.result.level_ = value;
                        return this;
                    }

                    [CLSCompliant(false)]
                    public DebugProfilingFrame.Types.DebugProfilingSample.Builder SetSectionid(uint value)
                    {
                        this.PrepareBuilder();
                        this.result.hasSectionid = true;
                        this.result.sectionid_ = value;
                        return this;
                    }

                    public DebugProfilingFrame.Types.DebugProfilingSample.Builder SetSectionname(string value)
                    {
                        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                        this.PrepareBuilder();
                        this.result.hasSectionname = true;
                        this.result.sectionname_ = value;
                        return this;
                    }

                    public DebugProfilingFrame.Types.DebugProfilingSample.Builder SetStartofframe(bool value)
                    {
                        this.PrepareBuilder();
                        this.result.hasStartofframe = true;
                        this.result.startofframe_ = value;
                        return this;
                    }

                    [CLSCompliant(false)]
                    public DebugProfilingFrame.Types.DebugProfilingSample.Builder SetStartstamp(ulong value)
                    {
                        this.PrepareBuilder();
                        this.result.hasStartstamp = true;
                        this.result.startstamp_ = value;
                        return this;
                    }

                    [CLSCompliant(false)]
                    public DebugProfilingFrame.Types.DebugProfilingSample.Builder SetThreadid(uint value)
                    {
                        this.PrepareBuilder();
                        this.result.hasThreadid = true;
                        this.result.threadid_ = value;
                        return this;
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

                    public override DebugProfilingFrame.Types.DebugProfilingSample DefaultInstanceForType
                    {
                        get
                        {
                            return DebugProfilingFrame.Types.DebugProfilingSample.DefaultInstance;
                        }
                    }

                    [CLSCompliant(false)]
                    public ulong Endstamp
                    {
                        get
                        {
                            return this.result.Endstamp;
                        }
                        set
                        {
                            this.SetEndstamp(value);
                        }
                    }

                    public bool HasActive
                    {
                        get
                        {
                            return this.result.hasActive;
                        }
                    }

                    public bool HasEndstamp
                    {
                        get
                        {
                            return this.result.hasEndstamp;
                        }
                    }

                    public bool HasLevel
                    {
                        get
                        {
                            return this.result.hasLevel;
                        }
                    }

                    public bool HasSectionid
                    {
                        get
                        {
                            return this.result.hasSectionid;
                        }
                    }

                    public bool HasSectionname
                    {
                        get
                        {
                            return this.result.hasSectionname;
                        }
                    }

                    public bool HasStartofframe
                    {
                        get
                        {
                            return this.result.hasStartofframe;
                        }
                    }

                    public bool HasStartstamp
                    {
                        get
                        {
                            return this.result.hasStartstamp;
                        }
                    }

                    public bool HasThreadid
                    {
                        get
                        {
                            return this.result.hasThreadid;
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
                    public uint Level
                    {
                        get
                        {
                            return this.result.Level;
                        }
                        set
                        {
                            this.SetLevel(value);
                        }
                    }

                    protected override DebugProfilingFrame.Types.DebugProfilingSample MessageBeingBuilt
                    {
                        get
                        {
                            return this.PrepareBuilder();
                        }
                    }

                    [CLSCompliant(false)]
                    public uint Sectionid
                    {
                        get
                        {
                            return this.result.Sectionid;
                        }
                        set
                        {
                            this.SetSectionid(value);
                        }
                    }

                    public string Sectionname
                    {
                        get
                        {
                            return this.result.Sectionname;
                        }
                        set
                        {
                            this.SetSectionname(value);
                        }
                    }

                    public bool Startofframe
                    {
                        get
                        {
                            return this.result.Startofframe;
                        }
                        set
                        {
                            this.SetStartofframe(value);
                        }
                    }

                    [CLSCompliant(false)]
                    public ulong Startstamp
                    {
                        get
                        {
                            return this.result.Startstamp;
                        }
                        set
                        {
                            this.SetStartstamp(value);
                        }
                    }

                    protected override DebugProfilingFrame.Types.DebugProfilingSample.Builder ThisBuilder
                    {
                        get
                        {
                            return this;
                        }
                    }

                    [CLSCompliant(false)]
                    public uint Threadid
                    {
                        get
                        {
                            return this.result.Threadid;
                        }
                        set
                        {
                            this.SetThreadid(value);
                        }
                    }
                }
            }

            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0x90
            }
        }
    }
}

