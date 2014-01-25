namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class PingPong : GeneratedMessageLite<PingPong, Builder>
    {
        private static readonly string[] _pingPongFieldNames = new string[0];
        private static readonly uint[] _pingPongFieldTags = new uint[0];
        private static readonly PingPong defaultInstance = new PingPong().MakeReadOnly();
        private int memoizedSerializedSize = -1;

        static PingPong()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private PingPong()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(PingPong prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            return (obj is PingPong);
        }

        public override int GetHashCode()
        {
            return base.GetType().GetHashCode();
        }

        private PingPong MakeReadOnly()
        {
            return this;
        }

        public static PingPong ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static PingPong ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static PingPong ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PingPong ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PingPong ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PingPong ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PingPong ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static PingPong ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PingPong ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PingPong ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
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
            string[] strArray = _pingPongFieldNames;
        }

        public static PingPong DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override PingPong DefaultInstanceForType
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

        protected override PingPong ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<PingPong, PingPong.Builder>
        {
            private PingPong result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = PingPong.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(PingPong cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override PingPong BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override PingPong.Builder Clear()
            {
                this.result = PingPong.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public override PingPong.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new PingPong.Builder(this.result);
                }
                return new PingPong.Builder().MergeFrom(this.result);
            }

            public override PingPong.Builder MergeFrom(PingPong other)
            {
                if (other != PingPong.DefaultInstance)
                {
                    this.PrepareBuilder();
                }
                return this;
            }

            public override PingPong.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override PingPong.Builder MergeFrom(IMessageLite other)
            {
                if (other is PingPong)
                {
                    return this.MergeFrom((PingPong) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override PingPong.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(PingPong._pingPongFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = PingPong._pingPongFieldTags[index];
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

            private PingPong PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    PingPong result = this.result;
                    this.result = new PingPong();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public override PingPong DefaultInstanceForType
            {
                get
                {
                    return PingPong.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override PingPong MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override PingPong.Builder ThisBuilder
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
                ID = 0xa4
            }
        }
    }
}

