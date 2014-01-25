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

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class AtlasCardDetails : GeneratedMessageLite<AtlasCardDetails, Builder>
    {
        private static readonly string[] _atlasCardDetailsFieldNames = new string[] { "details" };
        private static readonly uint[] _atlasCardDetailsFieldTags = new uint[] { 10 };
        private static readonly AtlasCardDetails defaultInstance = new AtlasCardDetails().MakeReadOnly();
        private PopsicleList<AtlasCardDetail> details_ = new PopsicleList<AtlasCardDetail>();
        public const int DetailsFieldNumber = 1;
        private int memoizedSerializedSize = -1;

        static AtlasCardDetails()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AtlasCardDetails()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AtlasCardDetails prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AtlasCardDetails details = obj as AtlasCardDetails;
            if (details == null)
            {
                return false;
            }
            if (this.details_.Count != details.details_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.details_.Count; i++)
            {
                if (!this.details_[i].Equals(details.details_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public AtlasCardDetail GetDetails(int index)
        {
            return this.details_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<AtlasCardDetail> enumerator = this.details_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    AtlasCardDetail current = enumerator.Current;
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

        private AtlasCardDetails MakeReadOnly()
        {
            this.details_.MakeReadOnly();
            return this;
        }

        public static AtlasCardDetails ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AtlasCardDetails ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasCardDetails ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasCardDetails ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasCardDetails ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasCardDetails ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasCardDetails ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AtlasCardDetails ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasCardDetails ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasCardDetails ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AtlasCardDetails, Builder>.PrintField<AtlasCardDetail>("details", this.details_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _atlasCardDetailsFieldNames;
            if (this.details_.Count > 0)
            {
                output.WriteMessageArray<AtlasCardDetail>(1, strArray[0], this.details_);
            }
        }

        public static AtlasCardDetails DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AtlasCardDetails DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public int DetailsCount
        {
            get
            {
                return this.details_.Count;
            }
        }

        public IList<AtlasCardDetail> DetailsList
        {
            get
            {
                return this.details_;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                IEnumerator<AtlasCardDetail> enumerator = this.DetailsList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        AtlasCardDetail current = enumerator.Current;
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
                    IEnumerator<AtlasCardDetail> enumerator = this.DetailsList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            AtlasCardDetail current = enumerator.Current;
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

        protected override AtlasCardDetails ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<AtlasCardDetails, AtlasCardDetails.Builder>
        {
            private AtlasCardDetails result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AtlasCardDetails.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AtlasCardDetails cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public AtlasCardDetails.Builder AddDetails(AtlasCardDetail value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.details_.Add(value);
                return this;
            }

            public AtlasCardDetails.Builder AddDetails(AtlasCardDetail.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.details_.Add(builderForValue.Build());
                return this;
            }

            public AtlasCardDetails.Builder AddRangeDetails(IEnumerable<AtlasCardDetail> values)
            {
                this.PrepareBuilder();
                this.result.details_.Add(values);
                return this;
            }

            public override AtlasCardDetails BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AtlasCardDetails.Builder Clear()
            {
                this.result = AtlasCardDetails.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AtlasCardDetails.Builder ClearDetails()
            {
                this.PrepareBuilder();
                this.result.details_.Clear();
                return this;
            }

            public override AtlasCardDetails.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AtlasCardDetails.Builder(this.result);
                }
                return new AtlasCardDetails.Builder().MergeFrom(this.result);
            }

            public AtlasCardDetail GetDetails(int index)
            {
                return this.result.GetDetails(index);
            }

            public override AtlasCardDetails.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AtlasCardDetails.Builder MergeFrom(IMessageLite other)
            {
                if (other is AtlasCardDetails)
                {
                    return this.MergeFrom((AtlasCardDetails) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AtlasCardDetails.Builder MergeFrom(AtlasCardDetails other)
            {
                if (other != AtlasCardDetails.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.details_.Count != 0)
                    {
                        this.result.details_.Add(other.details_);
                    }
                }
                return this;
            }

            public override AtlasCardDetails.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AtlasCardDetails._atlasCardDetailsFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AtlasCardDetails._atlasCardDetailsFieldTags[index];
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
                    input.ReadMessageArray<AtlasCardDetail>(num, str, this.result.details_, AtlasCardDetail.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private AtlasCardDetails PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AtlasCardDetails result = this.result;
                    this.result = new AtlasCardDetails();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public AtlasCardDetails.Builder SetDetails(int index, AtlasCardDetail value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.details_[index] = value;
                return this;
            }

            public AtlasCardDetails.Builder SetDetails(int index, AtlasCardDetail.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.details_[index] = builderForValue.Build();
                return this;
            }

            public override AtlasCardDetails DefaultInstanceForType
            {
                get
                {
                    return AtlasCardDetails.DefaultInstance;
                }
            }

            public int DetailsCount
            {
                get
                {
                    return this.result.DetailsCount;
                }
            }

            public IPopsicleList<AtlasCardDetail> DetailsList
            {
                get
                {
                    return this.PrepareBuilder().details_;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override AtlasCardDetails MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override AtlasCardDetails.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0x67
            }
        }
    }
}

