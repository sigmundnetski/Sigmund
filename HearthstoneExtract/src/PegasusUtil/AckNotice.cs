namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class AckNotice : GeneratedMessageLite<AckNotice, Builder>
    {
        private static readonly string[] _ackNoticeFieldNames = new string[] { "entry" };
        private static readonly uint[] _ackNoticeFieldTags = new uint[] { 8 };
        private static readonly AckNotice defaultInstance = new AckNotice().MakeReadOnly();
        private long entry_;
        public const int EntryFieldNumber = 1;
        private bool hasEntry;
        private int memoizedSerializedSize = -1;

        static AckNotice()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AckNotice()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AckNotice prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AckNotice notice = obj as AckNotice;
            if (notice == null)
            {
                return false;
            }
            return ((this.hasEntry == notice.hasEntry) && (!this.hasEntry || this.entry_.Equals(notice.entry_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasEntry)
            {
                hashCode ^= this.entry_.GetHashCode();
            }
            return hashCode;
        }

        private AckNotice MakeReadOnly()
        {
            return this;
        }

        public static AckNotice ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AckNotice ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AckNotice ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AckNotice ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AckNotice ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AckNotice ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AckNotice ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AckNotice ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AckNotice ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AckNotice ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AckNotice, Builder>.PrintField("entry", this.hasEntry, this.entry_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _ackNoticeFieldNames;
            if (this.hasEntry)
            {
                output.WriteInt64(1, strArray[0], this.Entry);
            }
        }

        public static AckNotice DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AckNotice DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public long Entry
        {
            get
            {
                return this.entry_;
            }
        }

        public bool HasEntry
        {
            get
            {
                return this.hasEntry;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasEntry)
                {
                    return false;
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
                    if (this.hasEntry)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(1, this.Entry);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override AckNotice ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<AckNotice, AckNotice.Builder>
        {
            private AckNotice result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AckNotice.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AckNotice cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override AckNotice BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AckNotice.Builder Clear()
            {
                this.result = AckNotice.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AckNotice.Builder ClearEntry()
            {
                this.PrepareBuilder();
                this.result.hasEntry = false;
                this.result.entry_ = 0L;
                return this;
            }

            public override AckNotice.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AckNotice.Builder(this.result);
                }
                return new AckNotice.Builder().MergeFrom(this.result);
            }

            public override AckNotice.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AckNotice.Builder MergeFrom(IMessageLite other)
            {
                if (other is AckNotice)
                {
                    return this.MergeFrom((AckNotice) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AckNotice.Builder MergeFrom(AckNotice other)
            {
                if (other != AckNotice.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasEntry)
                    {
                        this.Entry = other.Entry;
                    }
                }
                return this;
            }

            public override AckNotice.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AckNotice._ackNoticeFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AckNotice._ackNoticeFieldTags[index];
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

                        case 8:
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
                    this.result.hasEntry = input.ReadInt64(ref this.result.entry_);
                }
                return this;
            }

            private AckNotice PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AckNotice result = this.result;
                    this.result = new AckNotice();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public AckNotice.Builder SetEntry(long value)
            {
                this.PrepareBuilder();
                this.result.hasEntry = true;
                this.result.entry_ = value;
                return this;
            }

            public override AckNotice DefaultInstanceForType
            {
                get
                {
                    return AckNotice.DefaultInstance;
                }
            }

            public long Entry
            {
                get
                {
                    return this.result.Entry;
                }
                set
                {
                    this.SetEntry(value);
                }
            }

            public bool HasEntry
            {
                get
                {
                    return this.result.hasEntry;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override AckNotice MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override AckNotice.Builder ThisBuilder
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
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0xd5,
                System = 0
            }
        }
    }
}

