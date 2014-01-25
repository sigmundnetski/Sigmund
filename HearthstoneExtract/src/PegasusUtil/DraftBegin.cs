namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class DraftBegin : GeneratedMessageLite<DraftBegin, Builder>
    {
        private static readonly string[] _draftBeginFieldNames = new string[0];
        private static readonly uint[] _draftBeginFieldTags = new uint[0];
        private static readonly DraftBegin defaultInstance = new DraftBegin().MakeReadOnly();
        private int memoizedSerializedSize = -1;

        static DraftBegin()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private DraftBegin()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DraftBegin prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            return (obj is DraftBegin);
        }

        public override int GetHashCode()
        {
            return base.GetType().GetHashCode();
        }

        private DraftBegin MakeReadOnly()
        {
            return this;
        }

        public static DraftBegin ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DraftBegin ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DraftBegin ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DraftBegin ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DraftBegin ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DraftBegin ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DraftBegin ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DraftBegin ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DraftBegin ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DraftBegin ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
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
            string[] strArray = _draftBeginFieldNames;
        }

        public static DraftBegin DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DraftBegin DefaultInstanceForType
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

        protected override DraftBegin ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<DraftBegin, DraftBegin.Builder>
        {
            private DraftBegin result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DraftBegin.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DraftBegin cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override DraftBegin BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DraftBegin.Builder Clear()
            {
                this.result = DraftBegin.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public override DraftBegin.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DraftBegin.Builder(this.result);
                }
                return new DraftBegin.Builder().MergeFrom(this.result);
            }

            public override DraftBegin.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DraftBegin.Builder MergeFrom(IMessageLite other)
            {
                if (other is DraftBegin)
                {
                    return this.MergeFrom((DraftBegin) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DraftBegin.Builder MergeFrom(DraftBegin other)
            {
                if (other != DraftBegin.DefaultInstance)
                {
                    this.PrepareBuilder();
                }
                return this;
            }

            public override DraftBegin.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DraftBegin._draftBeginFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DraftBegin._draftBeginFieldTags[index];
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

            private DraftBegin PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DraftBegin result = this.result;
                    this.result = new DraftBegin();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public override DraftBegin DefaultInstanceForType
            {
                get
                {
                    return DraftBegin.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override DraftBegin MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override DraftBegin.Builder ThisBuilder
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
                ID = 0xeb,
                System = 0
            }
        }
    }
}

