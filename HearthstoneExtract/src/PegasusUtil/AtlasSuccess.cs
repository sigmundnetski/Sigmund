namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class AtlasSuccess : GeneratedMessageLite<AtlasSuccess, Builder>
    {
        private static readonly string[] _atlasSuccessFieldNames = new string[0];
        private static readonly uint[] _atlasSuccessFieldTags = new uint[0];
        private static readonly AtlasSuccess defaultInstance = new AtlasSuccess().MakeReadOnly();
        private int memoizedSerializedSize = -1;

        static AtlasSuccess()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AtlasSuccess()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AtlasSuccess prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            return (obj is AtlasSuccess);
        }

        public override int GetHashCode()
        {
            return base.GetType().GetHashCode();
        }

        private AtlasSuccess MakeReadOnly()
        {
            return this;
        }

        public static AtlasSuccess ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AtlasSuccess ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasSuccess ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasSuccess ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasSuccess ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasSuccess ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasSuccess ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AtlasSuccess ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasSuccess ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasSuccess ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
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
            string[] strArray = _atlasSuccessFieldNames;
        }

        public static AtlasSuccess DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AtlasSuccess DefaultInstanceForType
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

        protected override AtlasSuccess ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<AtlasSuccess, AtlasSuccess.Builder>
        {
            private AtlasSuccess result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AtlasSuccess.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AtlasSuccess cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override AtlasSuccess BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AtlasSuccess.Builder Clear()
            {
                this.result = AtlasSuccess.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public override AtlasSuccess.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AtlasSuccess.Builder(this.result);
                }
                return new AtlasSuccess.Builder().MergeFrom(this.result);
            }

            public override AtlasSuccess.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AtlasSuccess.Builder MergeFrom(IMessageLite other)
            {
                if (other is AtlasSuccess)
                {
                    return this.MergeFrom((AtlasSuccess) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AtlasSuccess.Builder MergeFrom(AtlasSuccess other)
            {
                if (other != AtlasSuccess.DefaultInstance)
                {
                    this.PrepareBuilder();
                }
                return this;
            }

            public override AtlasSuccess.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AtlasSuccess._atlasSuccessFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AtlasSuccess._atlasSuccessFieldTags[index];
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

            private AtlasSuccess PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AtlasSuccess result = this.result;
                    this.result = new AtlasSuccess();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public override AtlasSuccess DefaultInstanceForType
            {
                get
                {
                    return AtlasSuccess.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override AtlasSuccess MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override AtlasSuccess.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0x69
            }
        }
    }
}

