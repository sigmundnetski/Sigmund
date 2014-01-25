namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class DebugConsoleGetZones : GeneratedMessageLite<DebugConsoleGetZones, Builder>
    {
        private static readonly string[] _debugConsoleGetZonesFieldNames = new string[0];
        private static readonly uint[] _debugConsoleGetZonesFieldTags = new uint[0];
        private static readonly DebugConsoleGetZones defaultInstance = new DebugConsoleGetZones().MakeReadOnly();
        private int memoizedSerializedSize = -1;

        static DebugConsoleGetZones()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private DebugConsoleGetZones()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DebugConsoleGetZones prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            return (obj is DebugConsoleGetZones);
        }

        public override int GetHashCode()
        {
            return base.GetType().GetHashCode();
        }

        private DebugConsoleGetZones MakeReadOnly()
        {
            return this;
        }

        public static DebugConsoleGetZones ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DebugConsoleGetZones ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DebugConsoleGetZones ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DebugConsoleGetZones ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DebugConsoleGetZones ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DebugConsoleGetZones ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DebugConsoleGetZones ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DebugConsoleGetZones ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DebugConsoleGetZones ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DebugConsoleGetZones ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
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
            string[] strArray = _debugConsoleGetZonesFieldNames;
        }

        public static DebugConsoleGetZones DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DebugConsoleGetZones DefaultInstanceForType
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

        protected override DebugConsoleGetZones ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<DebugConsoleGetZones, DebugConsoleGetZones.Builder>
        {
            private DebugConsoleGetZones result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DebugConsoleGetZones.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DebugConsoleGetZones cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override DebugConsoleGetZones BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DebugConsoleGetZones.Builder Clear()
            {
                this.result = DebugConsoleGetZones.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public override DebugConsoleGetZones.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DebugConsoleGetZones.Builder(this.result);
                }
                return new DebugConsoleGetZones.Builder().MergeFrom(this.result);
            }

            public override DebugConsoleGetZones.Builder MergeFrom(DebugConsoleGetZones other)
            {
                if (other != DebugConsoleGetZones.DefaultInstance)
                {
                    this.PrepareBuilder();
                }
                return this;
            }

            public override DebugConsoleGetZones.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DebugConsoleGetZones.Builder MergeFrom(IMessageLite other)
            {
                if (other is DebugConsoleGetZones)
                {
                    return this.MergeFrom((DebugConsoleGetZones) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DebugConsoleGetZones.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DebugConsoleGetZones._debugConsoleGetZonesFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DebugConsoleGetZones._debugConsoleGetZonesFieldTags[index];
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

            private DebugConsoleGetZones PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DebugConsoleGetZones result = this.result;
                    this.result = new DebugConsoleGetZones();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public override DebugConsoleGetZones DefaultInstanceForType
            {
                get
                {
                    return DebugConsoleGetZones.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override DebugConsoleGetZones MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override DebugConsoleGetZones.Builder ThisBuilder
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
                ID = 0x93
            }
        }
    }
}

