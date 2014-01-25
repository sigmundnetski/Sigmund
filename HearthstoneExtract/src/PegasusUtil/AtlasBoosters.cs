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

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class AtlasBoosters : GeneratedMessageLite<AtlasBoosters, Builder>
    {
        private static readonly string[] _atlasBoostersFieldNames = new string[] { "info" };
        private static readonly uint[] _atlasBoostersFieldTags = new uint[] { 10 };
        private static readonly AtlasBoosters defaultInstance = new AtlasBoosters().MakeReadOnly();
        private PopsicleList<AtlasBooster> info_ = new PopsicleList<AtlasBooster>();
        public const int InfoFieldNumber = 1;
        private int memoizedSerializedSize = -1;

        static AtlasBoosters()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AtlasBoosters()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AtlasBoosters prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AtlasBoosters boosters = obj as AtlasBoosters;
            if (boosters == null)
            {
                return false;
            }
            if (this.info_.Count != boosters.info_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.info_.Count; i++)
            {
                if (!this.info_[i].Equals(boosters.info_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<AtlasBooster> enumerator = this.info_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    AtlasBooster current = enumerator.Current;
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

        public AtlasBooster GetInfo(int index)
        {
            return this.info_[index];
        }

        private AtlasBoosters MakeReadOnly()
        {
            this.info_.MakeReadOnly();
            return this;
        }

        public static AtlasBoosters ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AtlasBoosters ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasBoosters ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasBoosters ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasBoosters ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasBoosters ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasBoosters ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AtlasBoosters ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasBoosters ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasBoosters ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AtlasBoosters, Builder>.PrintField<AtlasBooster>("info", this.info_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _atlasBoostersFieldNames;
            if (this.info_.Count > 0)
            {
                output.WriteMessageArray<AtlasBooster>(1, strArray[0], this.info_);
            }
        }

        public static AtlasBoosters DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AtlasBoosters DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public int InfoCount
        {
            get
            {
                return this.info_.Count;
            }
        }

        public IList<AtlasBooster> InfoList
        {
            get
            {
                return this.info_;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                IEnumerator<AtlasBooster> enumerator = this.InfoList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        AtlasBooster current = enumerator.Current;
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

        public override int SerializedSize
        {
            get
            {
                int memoizedSerializedSize = this.memoizedSerializedSize;
                if (memoizedSerializedSize == -1)
                {
                    memoizedSerializedSize = 0;
                    IEnumerator<AtlasBooster> enumerator = this.InfoList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            AtlasBooster current = enumerator.Current;
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

        protected override AtlasBoosters ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<AtlasBoosters, AtlasBoosters.Builder>
        {
            private AtlasBoosters result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AtlasBoosters.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AtlasBoosters cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public AtlasBoosters.Builder AddInfo(AtlasBooster value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.info_.Add(value);
                return this;
            }

            public AtlasBoosters.Builder AddInfo(AtlasBooster.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.info_.Add(builderForValue.Build());
                return this;
            }

            public AtlasBoosters.Builder AddRangeInfo(IEnumerable<AtlasBooster> values)
            {
                this.PrepareBuilder();
                this.result.info_.Add(values);
                return this;
            }

            public override AtlasBoosters BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AtlasBoosters.Builder Clear()
            {
                this.result = AtlasBoosters.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AtlasBoosters.Builder ClearInfo()
            {
                this.PrepareBuilder();
                this.result.info_.Clear();
                return this;
            }

            public override AtlasBoosters.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AtlasBoosters.Builder(this.result);
                }
                return new AtlasBoosters.Builder().MergeFrom(this.result);
            }

            public AtlasBooster GetInfo(int index)
            {
                return this.result.GetInfo(index);
            }

            public override AtlasBoosters.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AtlasBoosters.Builder MergeFrom(IMessageLite other)
            {
                if (other is AtlasBoosters)
                {
                    return this.MergeFrom((AtlasBoosters) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AtlasBoosters.Builder MergeFrom(AtlasBoosters other)
            {
                if (other != AtlasBoosters.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.info_.Count != 0)
                    {
                        this.result.info_.Add(other.info_);
                    }
                }
                return this;
            }

            public override AtlasBoosters.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AtlasBoosters._atlasBoostersFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AtlasBoosters._atlasBoostersFieldTags[index];
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
                    input.ReadMessageArray<AtlasBooster>(num, str, this.result.info_, AtlasBooster.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private AtlasBoosters PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AtlasBoosters result = this.result;
                    this.result = new AtlasBoosters();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public AtlasBoosters.Builder SetInfo(int index, AtlasBooster value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.info_[index] = value;
                return this;
            }

            public AtlasBoosters.Builder SetInfo(int index, AtlasBooster.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.info_[index] = builderForValue.Build();
                return this;
            }

            public override AtlasBoosters DefaultInstanceForType
            {
                get
                {
                    return AtlasBoosters.DefaultInstance;
                }
            }

            public int InfoCount
            {
                get
                {
                    return this.result.InfoCount;
                }
            }

            public IPopsicleList<AtlasBooster> InfoList
            {
                get
                {
                    return this.PrepareBuilder().info_;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override AtlasBoosters MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override AtlasBoosters.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0x6d
            }
        }
    }
}

