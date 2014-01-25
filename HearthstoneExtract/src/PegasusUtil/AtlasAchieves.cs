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
    public sealed class AtlasAchieves : GeneratedMessageLite<AtlasAchieves, Builder>
    {
        private static readonly string[] _atlasAchievesFieldNames = new string[] { "info" };
        private static readonly uint[] _atlasAchievesFieldTags = new uint[] { 10 };
        private static readonly AtlasAchieves defaultInstance = new AtlasAchieves().MakeReadOnly();
        private PopsicleList<AtlasAchieve> info_ = new PopsicleList<AtlasAchieve>();
        public const int InfoFieldNumber = 1;
        private int memoizedSerializedSize = -1;

        static AtlasAchieves()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AtlasAchieves()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AtlasAchieves prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AtlasAchieves achieves = obj as AtlasAchieves;
            if (achieves == null)
            {
                return false;
            }
            if (this.info_.Count != achieves.info_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.info_.Count; i++)
            {
                if (!this.info_[i].Equals(achieves.info_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<AtlasAchieve> enumerator = this.info_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    AtlasAchieve current = enumerator.Current;
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

        public AtlasAchieve GetInfo(int index)
        {
            return this.info_[index];
        }

        private AtlasAchieves MakeReadOnly()
        {
            this.info_.MakeReadOnly();
            return this;
        }

        public static AtlasAchieves ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AtlasAchieves ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasAchieves ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasAchieves ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasAchieves ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasAchieves ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasAchieves ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AtlasAchieves ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasAchieves ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasAchieves ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AtlasAchieves, Builder>.PrintField<AtlasAchieve>("info", this.info_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _atlasAchievesFieldNames;
            if (this.info_.Count > 0)
            {
                output.WriteMessageArray<AtlasAchieve>(1, strArray[0], this.info_);
            }
        }

        public static AtlasAchieves DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AtlasAchieves DefaultInstanceForType
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

        public IList<AtlasAchieve> InfoList
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
                IEnumerator<AtlasAchieve> enumerator = this.InfoList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        AtlasAchieve current = enumerator.Current;
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
                    IEnumerator<AtlasAchieve> enumerator = this.InfoList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            AtlasAchieve current = enumerator.Current;
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

        protected override AtlasAchieves ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<AtlasAchieves, AtlasAchieves.Builder>
        {
            private AtlasAchieves result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AtlasAchieves.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AtlasAchieves cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public AtlasAchieves.Builder AddInfo(AtlasAchieve value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.info_.Add(value);
                return this;
            }

            public AtlasAchieves.Builder AddInfo(AtlasAchieve.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.info_.Add(builderForValue.Build());
                return this;
            }

            public AtlasAchieves.Builder AddRangeInfo(IEnumerable<AtlasAchieve> values)
            {
                this.PrepareBuilder();
                this.result.info_.Add(values);
                return this;
            }

            public override AtlasAchieves BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AtlasAchieves.Builder Clear()
            {
                this.result = AtlasAchieves.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AtlasAchieves.Builder ClearInfo()
            {
                this.PrepareBuilder();
                this.result.info_.Clear();
                return this;
            }

            public override AtlasAchieves.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AtlasAchieves.Builder(this.result);
                }
                return new AtlasAchieves.Builder().MergeFrom(this.result);
            }

            public AtlasAchieve GetInfo(int index)
            {
                return this.result.GetInfo(index);
            }

            public override AtlasAchieves.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AtlasAchieves.Builder MergeFrom(IMessageLite other)
            {
                if (other is AtlasAchieves)
                {
                    return this.MergeFrom((AtlasAchieves) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AtlasAchieves.Builder MergeFrom(AtlasAchieves other)
            {
                if (other != AtlasAchieves.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.info_.Count != 0)
                    {
                        this.result.info_.Add(other.info_);
                    }
                }
                return this;
            }

            public override AtlasAchieves.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AtlasAchieves._atlasAchievesFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AtlasAchieves._atlasAchievesFieldTags[index];
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
                    input.ReadMessageArray<AtlasAchieve>(num, str, this.result.info_, AtlasAchieve.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private AtlasAchieves PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AtlasAchieves result = this.result;
                    this.result = new AtlasAchieves();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public AtlasAchieves.Builder SetInfo(int index, AtlasAchieve value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.info_[index] = value;
                return this;
            }

            public AtlasAchieves.Builder SetInfo(int index, AtlasAchieve.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.info_[index] = builderForValue.Build();
                return this;
            }

            public override AtlasAchieves DefaultInstanceForType
            {
                get
                {
                    return AtlasAchieves.DefaultInstance;
                }
            }

            public int InfoCount
            {
                get
                {
                    return this.result.InfoCount;
                }
            }

            public IPopsicleList<AtlasAchieve> InfoList
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

            protected override AtlasAchieves MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override AtlasAchieves.Builder ThisBuilder
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
                ID = 0x6b
            }
        }
    }
}

