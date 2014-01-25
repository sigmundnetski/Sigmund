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

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class HeroXP : GeneratedMessageLite<HeroXP, Builder>
    {
        private static readonly string[] _heroXPFieldNames = new string[] { "xp_infos" };
        private static readonly uint[] _heroXPFieldTags = new uint[] { 10 };
        private static readonly HeroXP defaultInstance = new HeroXP().MakeReadOnly();
        private int memoizedSerializedSize = -1;
        private PopsicleList<HeroXPInfo> xpInfos_ = new PopsicleList<HeroXPInfo>();
        public const int XpInfosFieldNumber = 1;

        static HeroXP()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private HeroXP()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(HeroXP prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            HeroXP oxp = obj as HeroXP;
            if (oxp == null)
            {
                return false;
            }
            if (this.xpInfos_.Count != oxp.xpInfos_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.xpInfos_.Count; i++)
            {
                if (!this.xpInfos_[i].Equals(oxp.xpInfos_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<HeroXPInfo> enumerator = this.xpInfos_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    HeroXPInfo current = enumerator.Current;
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

        public HeroXPInfo GetXpInfos(int index)
        {
            return this.xpInfos_[index];
        }

        private HeroXP MakeReadOnly()
        {
            this.xpInfos_.MakeReadOnly();
            return this;
        }

        public static HeroXP ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static HeroXP ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static HeroXP ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static HeroXP ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static HeroXP ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static HeroXP ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static HeroXP ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static HeroXP ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static HeroXP ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static HeroXP ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<HeroXP, Builder>.PrintField<HeroXPInfo>("xp_infos", this.xpInfos_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _heroXPFieldNames;
            if (this.xpInfos_.Count > 0)
            {
                output.WriteMessageArray<HeroXPInfo>(1, strArray[0], this.xpInfos_);
            }
        }

        public static HeroXP DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override HeroXP DefaultInstanceForType
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
                IEnumerator<HeroXPInfo> enumerator = this.XpInfosList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        HeroXPInfo current = enumerator.Current;
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
                    IEnumerator<HeroXPInfo> enumerator = this.XpInfosList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            HeroXPInfo current = enumerator.Current;
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

        protected override HeroXP ThisMessage
        {
            get
            {
                return this;
            }
        }

        public int XpInfosCount
        {
            get
            {
                return this.xpInfos_.Count;
            }
        }

        public IList<HeroXPInfo> XpInfosList
        {
            get
            {
                return this.xpInfos_;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<HeroXP, HeroXP.Builder>
        {
            private HeroXP result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = HeroXP.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(HeroXP cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public HeroXP.Builder AddRangeXpInfos(IEnumerable<HeroXPInfo> values)
            {
                this.PrepareBuilder();
                this.result.xpInfos_.Add(values);
                return this;
            }

            public HeroXP.Builder AddXpInfos(HeroXPInfo value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.xpInfos_.Add(value);
                return this;
            }

            public HeroXP.Builder AddXpInfos(HeroXPInfo.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.xpInfos_.Add(builderForValue.Build());
                return this;
            }

            public override HeroXP BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override HeroXP.Builder Clear()
            {
                this.result = HeroXP.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public HeroXP.Builder ClearXpInfos()
            {
                this.PrepareBuilder();
                this.result.xpInfos_.Clear();
                return this;
            }

            public override HeroXP.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new HeroXP.Builder(this.result);
                }
                return new HeroXP.Builder().MergeFrom(this.result);
            }

            public HeroXPInfo GetXpInfos(int index)
            {
                return this.result.GetXpInfos(index);
            }

            public override HeroXP.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override HeroXP.Builder MergeFrom(IMessageLite other)
            {
                if (other is HeroXP)
                {
                    return this.MergeFrom((HeroXP) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override HeroXP.Builder MergeFrom(HeroXP other)
            {
                if (other != HeroXP.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.xpInfos_.Count != 0)
                    {
                        this.result.xpInfos_.Add(other.xpInfos_);
                    }
                }
                return this;
            }

            public override HeroXP.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(HeroXP._heroXPFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = HeroXP._heroXPFieldTags[index];
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
                    input.ReadMessageArray<HeroXPInfo>(num, str, this.result.xpInfos_, HeroXPInfo.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private HeroXP PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    HeroXP result = this.result;
                    this.result = new HeroXP();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public HeroXP.Builder SetXpInfos(int index, HeroXPInfo value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.xpInfos_[index] = value;
                return this;
            }

            public HeroXP.Builder SetXpInfos(int index, HeroXPInfo.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.xpInfos_[index] = builderForValue.Build();
                return this;
            }

            public override HeroXP DefaultInstanceForType
            {
                get
                {
                    return HeroXP.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override HeroXP MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override HeroXP.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public int XpInfosCount
            {
                get
                {
                    return this.result.XpInfosCount;
                }
            }

            public IPopsicleList<HeroXPInfo> XpInfosList
            {
                get
                {
                    return this.PrepareBuilder().xpInfos_;
                }
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0x11b
            }
        }
    }
}

