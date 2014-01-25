namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class PACKET_TYPES : GeneratedMessageLite<PACKET_TYPES, Builder>
    {
        private static readonly string[] _pACKETTYPESFieldNames = new string[0];
        private static readonly uint[] _pACKETTYPESFieldTags = new uint[0];
        private static readonly PACKET_TYPES defaultInstance = new PACKET_TYPES().MakeReadOnly();
        private int memoizedSerializedSize = -1;

        static PACKET_TYPES()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private PACKET_TYPES()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(PACKET_TYPES prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            return (obj is PACKET_TYPES);
        }

        public override int GetHashCode()
        {
            return base.GetType().GetHashCode();
        }

        private PACKET_TYPES MakeReadOnly()
        {
            return this;
        }

        public static PACKET_TYPES ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static PACKET_TYPES ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static PACKET_TYPES ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PACKET_TYPES ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PACKET_TYPES ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PACKET_TYPES ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PACKET_TYPES ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static PACKET_TYPES ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PACKET_TYPES ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PACKET_TYPES ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
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
            string[] strArray = _pACKETTYPESFieldNames;
        }

        public static PACKET_TYPES DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override PACKET_TYPES DefaultInstanceForType
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

        protected override PACKET_TYPES ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<PACKET_TYPES, PACKET_TYPES.Builder>
        {
            private PACKET_TYPES result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = PACKET_TYPES.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(PACKET_TYPES cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override PACKET_TYPES BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override PACKET_TYPES.Builder Clear()
            {
                this.result = PACKET_TYPES.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public override PACKET_TYPES.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new PACKET_TYPES.Builder(this.result);
                }
                return new PACKET_TYPES.Builder().MergeFrom(this.result);
            }

            public override PACKET_TYPES.Builder MergeFrom(PACKET_TYPES other)
            {
                if (other != PACKET_TYPES.DefaultInstance)
                {
                    this.PrepareBuilder();
                }
                return this;
            }

            public override PACKET_TYPES.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override PACKET_TYPES.Builder MergeFrom(IMessageLite other)
            {
                if (other is PACKET_TYPES)
                {
                    return this.MergeFrom((PACKET_TYPES) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override PACKET_TYPES.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(PACKET_TYPES._pACKETTYPESFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = PACKET_TYPES._pACKETTYPESFieldTags[index];
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

            private PACKET_TYPES PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    PACKET_TYPES result = this.result;
                    this.result = new PACKET_TYPES();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public override PACKET_TYPES DefaultInstanceForType
            {
                get
                {
                    return PACKET_TYPES.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override PACKET_TYPES MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override PACKET_TYPES.Builder ThisBuilder
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
            public enum BobNetCount
            {
                COUNT = 500
            }
        }
    }
}

