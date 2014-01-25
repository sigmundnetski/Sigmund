namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class GetUtilServer : GeneratedMessageLite<GetUtilServer, Builder>
    {
        private static readonly string[] _getUtilServerFieldNames = new string[0];
        private static readonly uint[] _getUtilServerFieldTags = new uint[0];
        private static readonly GetUtilServer defaultInstance = new GetUtilServer().MakeReadOnly();
        private int memoizedSerializedSize = -1;

        static GetUtilServer()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private GetUtilServer()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GetUtilServer prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            return (obj is GetUtilServer);
        }

        public override int GetHashCode()
        {
            return base.GetType().GetHashCode();
        }

        private GetUtilServer MakeReadOnly()
        {
            return this;
        }

        public static GetUtilServer ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GetUtilServer ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetUtilServer ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GetUtilServer ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GetUtilServer ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GetUtilServer ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GetUtilServer ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GetUtilServer ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetUtilServer ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetUtilServer ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
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
            string[] strArray = _getUtilServerFieldNames;
        }

        public static GetUtilServer DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GetUtilServer DefaultInstanceForType
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

        protected override GetUtilServer ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<GetUtilServer, GetUtilServer.Builder>
        {
            private GetUtilServer result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GetUtilServer.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GetUtilServer cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override GetUtilServer BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GetUtilServer.Builder Clear()
            {
                this.result = GetUtilServer.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public override GetUtilServer.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GetUtilServer.Builder(this.result);
                }
                return new GetUtilServer.Builder().MergeFrom(this.result);
            }

            public override GetUtilServer.Builder MergeFrom(GetUtilServer other)
            {
                if (other != GetUtilServer.DefaultInstance)
                {
                    this.PrepareBuilder();
                }
                return this;
            }

            public override GetUtilServer.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GetUtilServer.Builder MergeFrom(IMessageLite other)
            {
                if (other is GetUtilServer)
                {
                    return this.MergeFrom((GetUtilServer) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GetUtilServer.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GetUtilServer._getUtilServerFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GetUtilServer._getUtilServerFieldTags[index];
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

            private GetUtilServer PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GetUtilServer result = this.result;
                    this.result = new GetUtilServer();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public override GetUtilServer DefaultInstanceForType
            {
                get
                {
                    return GetUtilServer.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override GetUtilServer MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override GetUtilServer.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 150
            }
        }
    }
}

