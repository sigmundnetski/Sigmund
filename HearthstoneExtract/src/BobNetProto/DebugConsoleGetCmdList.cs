namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class DebugConsoleGetCmdList : GeneratedMessageLite<DebugConsoleGetCmdList, Builder>
    {
        private static readonly string[] _debugConsoleGetCmdListFieldNames = new string[0];
        private static readonly uint[] _debugConsoleGetCmdListFieldTags = new uint[0];
        private static readonly DebugConsoleGetCmdList defaultInstance = new DebugConsoleGetCmdList().MakeReadOnly();
        private int memoizedSerializedSize = -1;

        static DebugConsoleGetCmdList()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private DebugConsoleGetCmdList()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DebugConsoleGetCmdList prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            return (obj is DebugConsoleGetCmdList);
        }

        public override int GetHashCode()
        {
            return base.GetType().GetHashCode();
        }

        private DebugConsoleGetCmdList MakeReadOnly()
        {
            return this;
        }

        public static DebugConsoleGetCmdList ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DebugConsoleGetCmdList ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DebugConsoleGetCmdList ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DebugConsoleGetCmdList ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DebugConsoleGetCmdList ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DebugConsoleGetCmdList ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DebugConsoleGetCmdList ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DebugConsoleGetCmdList ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DebugConsoleGetCmdList ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DebugConsoleGetCmdList ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
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
            string[] strArray = _debugConsoleGetCmdListFieldNames;
        }

        public static DebugConsoleGetCmdList DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DebugConsoleGetCmdList DefaultInstanceForType
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

        protected override DebugConsoleGetCmdList ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<DebugConsoleGetCmdList, DebugConsoleGetCmdList.Builder>
        {
            private DebugConsoleGetCmdList result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DebugConsoleGetCmdList.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DebugConsoleGetCmdList cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override DebugConsoleGetCmdList BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DebugConsoleGetCmdList.Builder Clear()
            {
                this.result = DebugConsoleGetCmdList.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public override DebugConsoleGetCmdList.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DebugConsoleGetCmdList.Builder(this.result);
                }
                return new DebugConsoleGetCmdList.Builder().MergeFrom(this.result);
            }

            public override DebugConsoleGetCmdList.Builder MergeFrom(DebugConsoleGetCmdList other)
            {
                if (other != DebugConsoleGetCmdList.DefaultInstance)
                {
                    this.PrepareBuilder();
                }
                return this;
            }

            public override DebugConsoleGetCmdList.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DebugConsoleGetCmdList.Builder MergeFrom(IMessageLite other)
            {
                if (other is DebugConsoleGetCmdList)
                {
                    return this.MergeFrom((DebugConsoleGetCmdList) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DebugConsoleGetCmdList.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DebugConsoleGetCmdList._debugConsoleGetCmdListFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DebugConsoleGetCmdList._debugConsoleGetCmdListFieldTags[index];
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

            private DebugConsoleGetCmdList PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DebugConsoleGetCmdList result = this.result;
                    this.result = new DebugConsoleGetCmdList();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public override DebugConsoleGetCmdList DefaultInstanceForType
            {
                get
                {
                    return DebugConsoleGetCmdList.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override DebugConsoleGetCmdList MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override DebugConsoleGetCmdList.Builder ThisBuilder
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
                ID = 0x7d
            }
        }
    }
}

