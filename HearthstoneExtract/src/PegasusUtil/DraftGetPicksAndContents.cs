namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class DraftGetPicksAndContents : GeneratedMessageLite<DraftGetPicksAndContents, Builder>
    {
        private static readonly string[] _draftGetPicksAndContentsFieldNames = new string[0];
        private static readonly uint[] _draftGetPicksAndContentsFieldTags = new uint[0];
        private static readonly DraftGetPicksAndContents defaultInstance = new DraftGetPicksAndContents().MakeReadOnly();
        private int memoizedSerializedSize = -1;

        static DraftGetPicksAndContents()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private DraftGetPicksAndContents()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DraftGetPicksAndContents prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            return (obj is DraftGetPicksAndContents);
        }

        public override int GetHashCode()
        {
            return base.GetType().GetHashCode();
        }

        private DraftGetPicksAndContents MakeReadOnly()
        {
            return this;
        }

        public static DraftGetPicksAndContents ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DraftGetPicksAndContents ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DraftGetPicksAndContents ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DraftGetPicksAndContents ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DraftGetPicksAndContents ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DraftGetPicksAndContents ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DraftGetPicksAndContents ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DraftGetPicksAndContents ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DraftGetPicksAndContents ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DraftGetPicksAndContents ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
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
            string[] strArray = _draftGetPicksAndContentsFieldNames;
        }

        public static DraftGetPicksAndContents DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DraftGetPicksAndContents DefaultInstanceForType
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

        protected override DraftGetPicksAndContents ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<DraftGetPicksAndContents, DraftGetPicksAndContents.Builder>
        {
            private DraftGetPicksAndContents result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DraftGetPicksAndContents.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DraftGetPicksAndContents cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override DraftGetPicksAndContents BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DraftGetPicksAndContents.Builder Clear()
            {
                this.result = DraftGetPicksAndContents.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public override DraftGetPicksAndContents.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DraftGetPicksAndContents.Builder(this.result);
                }
                return new DraftGetPicksAndContents.Builder().MergeFrom(this.result);
            }

            public override DraftGetPicksAndContents.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DraftGetPicksAndContents.Builder MergeFrom(IMessageLite other)
            {
                if (other is DraftGetPicksAndContents)
                {
                    return this.MergeFrom((DraftGetPicksAndContents) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DraftGetPicksAndContents.Builder MergeFrom(DraftGetPicksAndContents other)
            {
                if (other != DraftGetPicksAndContents.DefaultInstance)
                {
                    this.PrepareBuilder();
                }
                return this;
            }

            public override DraftGetPicksAndContents.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DraftGetPicksAndContents._draftGetPicksAndContentsFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DraftGetPicksAndContents._draftGetPicksAndContentsFieldTags[index];
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

            private DraftGetPicksAndContents PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DraftGetPicksAndContents result = this.result;
                    this.result = new DraftGetPicksAndContents();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public override DraftGetPicksAndContents DefaultInstanceForType
            {
                get
                {
                    return DraftGetPicksAndContents.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override DraftGetPicksAndContents MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override DraftGetPicksAndContents.Builder ThisBuilder
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
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0xf4,
                System = 0
            }
        }
    }
}

