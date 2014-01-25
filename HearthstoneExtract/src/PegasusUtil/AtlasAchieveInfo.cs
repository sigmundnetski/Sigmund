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
    public sealed class AtlasAchieveInfo : GeneratedMessageLite<AtlasAchieveInfo, Builder>
    {
        private static readonly string[] _atlasAchieveInfoFieldNames = new string[] { "info" };
        private static readonly uint[] _atlasAchieveInfoFieldTags = new uint[] { 10 };
        private static readonly AtlasAchieveInfo defaultInstance = new AtlasAchieveInfo().MakeReadOnly();
        private PopsicleList<AchieveInfo> info_ = new PopsicleList<AchieveInfo>();
        public const int InfoFieldNumber = 1;
        private int memoizedSerializedSize = -1;

        static AtlasAchieveInfo()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AtlasAchieveInfo()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AtlasAchieveInfo prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AtlasAchieveInfo info = obj as AtlasAchieveInfo;
            if (info == null)
            {
                return false;
            }
            if (this.info_.Count != info.info_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.info_.Count; i++)
            {
                if (!this.info_[i].Equals(info.info_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<AchieveInfo> enumerator = this.info_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    AchieveInfo current = enumerator.Current;
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

        public AchieveInfo GetInfo(int index)
        {
            return this.info_[index];
        }

        private AtlasAchieveInfo MakeReadOnly()
        {
            this.info_.MakeReadOnly();
            return this;
        }

        public static AtlasAchieveInfo ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AtlasAchieveInfo ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasAchieveInfo ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasAchieveInfo ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasAchieveInfo ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasAchieveInfo ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasAchieveInfo ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AtlasAchieveInfo ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasAchieveInfo ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasAchieveInfo ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AtlasAchieveInfo, Builder>.PrintField<AchieveInfo>("info", this.info_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _atlasAchieveInfoFieldNames;
            if (this.info_.Count > 0)
            {
                output.WriteMessageArray<AchieveInfo>(1, strArray[0], this.info_);
            }
        }

        public static AtlasAchieveInfo DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AtlasAchieveInfo DefaultInstanceForType
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

        public IList<AchieveInfo> InfoList
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
                IEnumerator<AchieveInfo> enumerator = this.InfoList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        AchieveInfo current = enumerator.Current;
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
                    IEnumerator<AchieveInfo> enumerator = this.InfoList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            AchieveInfo current = enumerator.Current;
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

        protected override AtlasAchieveInfo ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<AtlasAchieveInfo, AtlasAchieveInfo.Builder>
        {
            private AtlasAchieveInfo result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AtlasAchieveInfo.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AtlasAchieveInfo cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public AtlasAchieveInfo.Builder AddInfo(AchieveInfo value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.info_.Add(value);
                return this;
            }

            public AtlasAchieveInfo.Builder AddInfo(AchieveInfo.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.info_.Add(builderForValue.Build());
                return this;
            }

            public AtlasAchieveInfo.Builder AddRangeInfo(IEnumerable<AchieveInfo> values)
            {
                this.PrepareBuilder();
                this.result.info_.Add(values);
                return this;
            }

            public override AtlasAchieveInfo BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AtlasAchieveInfo.Builder Clear()
            {
                this.result = AtlasAchieveInfo.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AtlasAchieveInfo.Builder ClearInfo()
            {
                this.PrepareBuilder();
                this.result.info_.Clear();
                return this;
            }

            public override AtlasAchieveInfo.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AtlasAchieveInfo.Builder(this.result);
                }
                return new AtlasAchieveInfo.Builder().MergeFrom(this.result);
            }

            public AchieveInfo GetInfo(int index)
            {
                return this.result.GetInfo(index);
            }

            public override AtlasAchieveInfo.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AtlasAchieveInfo.Builder MergeFrom(IMessageLite other)
            {
                if (other is AtlasAchieveInfo)
                {
                    return this.MergeFrom((AtlasAchieveInfo) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AtlasAchieveInfo.Builder MergeFrom(AtlasAchieveInfo other)
            {
                if (other != AtlasAchieveInfo.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.info_.Count != 0)
                    {
                        this.result.info_.Add(other.info_);
                    }
                }
                return this;
            }

            public override AtlasAchieveInfo.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AtlasAchieveInfo._atlasAchieveInfoFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AtlasAchieveInfo._atlasAchieveInfoFieldTags[index];
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
                    input.ReadMessageArray<AchieveInfo>(num, str, this.result.info_, AchieveInfo.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private AtlasAchieveInfo PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AtlasAchieveInfo result = this.result;
                    this.result = new AtlasAchieveInfo();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public AtlasAchieveInfo.Builder SetInfo(int index, AchieveInfo value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.info_[index] = value;
                return this;
            }

            public AtlasAchieveInfo.Builder SetInfo(int index, AchieveInfo.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.info_[index] = builderForValue.Build();
                return this;
            }

            public override AtlasAchieveInfo DefaultInstanceForType
            {
                get
                {
                    return AtlasAchieveInfo.DefaultInstance;
                }
            }

            public int InfoCount
            {
                get
                {
                    return this.result.InfoCount;
                }
            }

            public IPopsicleList<AchieveInfo> InfoList
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

            protected override AtlasAchieveInfo MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override AtlasAchieveInfo.Builder ThisBuilder
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
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0x6c
            }
        }
    }
}

