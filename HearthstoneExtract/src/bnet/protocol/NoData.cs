namespace bnet.protocol
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class NoData : GeneratedMessageLite<NoData, Builder>
    {
        private static readonly string[] _noDataFieldNames = new string[0];
        private static readonly uint[] _noDataFieldTags = new uint[0];
        private static readonly NoData defaultInstance = new NoData().MakeReadOnly();
        private int memoizedSerializedSize = -1;

        static NoData()
        {
            object.ReferenceEquals(Rpc.Descriptor, null);
        }

        private NoData()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(NoData prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            return (obj is NoData);
        }

        public override int GetHashCode()
        {
            return base.GetType().GetHashCode();
        }

        private NoData MakeReadOnly()
        {
            return this;
        }

        public static NoData ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static NoData ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static NoData ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static NoData ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static NoData ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static NoData ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static NoData ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static NoData ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static NoData ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static NoData ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _noDataFieldNames;
        }

        public static NoData DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override NoData DefaultInstanceForType
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
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override NoData ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<NoData, NoData.Builder>
        {
            private NoData result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = NoData.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(NoData cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override NoData BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override NoData.Builder Clear()
            {
                this.result = NoData.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public override NoData.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new NoData.Builder(this.result);
                }
                return new NoData.Builder().MergeFrom(this.result);
            }

            public override NoData.Builder MergeFrom(NoData other)
            {
                if (other != NoData.DefaultInstance)
                {
                    this.PrepareBuilder();
                }
                return this;
            }

            public override NoData.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override NoData.Builder MergeFrom(IMessageLite other)
            {
                if (other is NoData)
                {
                    return this.MergeFrom((NoData) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override NoData.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(NoData._noDataFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = NoData._noDataFieldTags[index];
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
                    }
                    if (WireFormat.IsEndGroupTag(num))
                    {
                        return this;
                    }
                    this.ParseUnknownField(input, extensionRegistry, num, str);
                }
                return this;
            }

            private NoData PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    NoData result = this.result;
                    this.result = new NoData();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public override NoData DefaultInstanceForType
            {
                get
                {
                    return NoData.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override NoData MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override NoData.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

