namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class MedalHistory : GeneratedMessageLite<MedalHistory, Builder>
    {
        private static readonly string[] _medalHistoryFieldNames = new string[] { "medals" };
        private static readonly uint[] _medalHistoryFieldTags = new uint[] { 10 };
        private static readonly MedalHistory defaultInstance = new MedalHistory().MakeReadOnly();
        private PopsicleList<MedalHistoryInfo> medals_ = new PopsicleList<MedalHistoryInfo>();
        public const int MedalsFieldNumber = 1;
        private int memoizedSerializedSize = -1;

        static MedalHistory()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private MedalHistory()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(MedalHistory prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            MedalHistory history = obj as MedalHistory;
            if (history == null)
            {
                return false;
            }
            if (this.medals_.Count != history.medals_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.medals_.Count; i++)
            {
                if (!this.medals_[i].Equals(history.medals_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<MedalHistoryInfo> enumerator = this.medals_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    MedalHistoryInfo current = enumerator.Current;
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

        public MedalHistoryInfo GetMedals(int index)
        {
            return this.medals_[index];
        }

        private MedalHistory MakeReadOnly()
        {
            this.medals_.MakeReadOnly();
            return this;
        }

        public static MedalHistory ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static MedalHistory ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static MedalHistory ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static MedalHistory ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static MedalHistory ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static MedalHistory ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static MedalHistory ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static MedalHistory ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static MedalHistory ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static MedalHistory ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<MedalHistory, Builder>.PrintField<MedalHistoryInfo>("medals", this.medals_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _medalHistoryFieldNames;
            if (this.medals_.Count > 0)
            {
                output.WriteMessageArray<MedalHistoryInfo>(1, strArray[0], this.medals_);
            }
        }

        public static MedalHistory DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override MedalHistory DefaultInstanceForType
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
                IEnumerator<MedalHistoryInfo> enumerator = this.MedalsList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        MedalHistoryInfo current = enumerator.Current;
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

        public int MedalsCount
        {
            get
            {
                return this.medals_.Count;
            }
        }

        public IList<MedalHistoryInfo> MedalsList
        {
            get
            {
                return this.medals_;
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
                    IEnumerator<MedalHistoryInfo> enumerator = this.MedalsList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            MedalHistoryInfo current = enumerator.Current;
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

        protected override MedalHistory ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<MedalHistory, MedalHistory.Builder>
        {
            private MedalHistory result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = MedalHistory.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(MedalHistory cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public MedalHistory.Builder AddMedals(MedalHistoryInfo value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.medals_.Add(value);
                return this;
            }

            public MedalHistory.Builder AddMedals(MedalHistoryInfo.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.medals_.Add(builderForValue.Build());
                return this;
            }

            public MedalHistory.Builder AddRangeMedals(IEnumerable<MedalHistoryInfo> values)
            {
                this.PrepareBuilder();
                this.result.medals_.Add(values);
                return this;
            }

            public override MedalHistory BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override MedalHistory.Builder Clear()
            {
                this.result = MedalHistory.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public MedalHistory.Builder ClearMedals()
            {
                this.PrepareBuilder();
                this.result.medals_.Clear();
                return this;
            }

            public override MedalHistory.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new MedalHistory.Builder(this.result);
                }
                return new MedalHistory.Builder().MergeFrom(this.result);
            }

            public MedalHistoryInfo GetMedals(int index)
            {
                return this.result.GetMedals(index);
            }

            public override MedalHistory.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override MedalHistory.Builder MergeFrom(IMessageLite other)
            {
                if (other is MedalHistory)
                {
                    return this.MergeFrom((MedalHistory) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override MedalHistory.Builder MergeFrom(MedalHistory other)
            {
                if (other != MedalHistory.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.medals_.Count != 0)
                    {
                        this.result.medals_.Add(other.medals_);
                    }
                }
                return this;
            }

            public override MedalHistory.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(MedalHistory._medalHistoryFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = MedalHistory._medalHistoryFieldTags[index];
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
                    input.ReadMessageArray<MedalHistoryInfo>(num, str, this.result.medals_, MedalHistoryInfo.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private MedalHistory PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    MedalHistory result = this.result;
                    this.result = new MedalHistory();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public MedalHistory.Builder SetMedals(int index, MedalHistoryInfo value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.medals_[index] = value;
                return this;
            }

            public MedalHistory.Builder SetMedals(int index, MedalHistoryInfo.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.medals_[index] = builderForValue.Build();
                return this;
            }

            public override MedalHistory DefaultInstanceForType
            {
                get
                {
                    return MedalHistory.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public int MedalsCount
            {
                get
                {
                    return this.result.MedalsCount;
                }
            }

            public IPopsicleList<MedalHistoryInfo> MedalsList
            {
                get
                {
                    return this.PrepareBuilder().medals_;
                }
            }

            protected override MedalHistory MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override MedalHistory.Builder ThisBuilder
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
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0xea
            }
        }
    }
}

