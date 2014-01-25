namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class DraftQueue : GeneratedMessageLite<DraftQueue, Builder>
    {
        private static readonly string[] _draftQueueFieldNames = new string[] { "join" };
        private static readonly uint[] _draftQueueFieldTags = new uint[] { 8 };
        private static readonly DraftQueue defaultInstance = new DraftQueue().MakeReadOnly();
        private bool hasJoin;
        private bool join_;
        public const int JoinFieldNumber = 1;
        private int memoizedSerializedSize = -1;

        static DraftQueue()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private DraftQueue()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DraftQueue prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DraftQueue queue = obj as DraftQueue;
            if (queue == null)
            {
                return false;
            }
            return ((this.hasJoin == queue.hasJoin) && (!this.hasJoin || this.join_.Equals(queue.join_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasJoin)
            {
                hashCode ^= this.join_.GetHashCode();
            }
            return hashCode;
        }

        private DraftQueue MakeReadOnly()
        {
            return this;
        }

        public static DraftQueue ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DraftQueue ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DraftQueue ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DraftQueue ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DraftQueue ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DraftQueue ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DraftQueue ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DraftQueue ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DraftQueue ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DraftQueue ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DraftQueue, Builder>.PrintField("join", this.hasJoin, this.join_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _draftQueueFieldNames;
            if (this.hasJoin)
            {
                output.WriteBool(1, strArray[0], this.Join);
            }
        }

        public static DraftQueue DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DraftQueue DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasJoin
        {
            get
            {
                return this.hasJoin;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasJoin)
                {
                    return false;
                }
                return true;
            }
        }

        public bool Join
        {
            get
            {
                return this.join_;
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
                    if (this.hasJoin)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(1, this.Join);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override DraftQueue ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<DraftQueue, DraftQueue.Builder>
        {
            private DraftQueue result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DraftQueue.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DraftQueue cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override DraftQueue BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DraftQueue.Builder Clear()
            {
                this.result = DraftQueue.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DraftQueue.Builder ClearJoin()
            {
                this.PrepareBuilder();
                this.result.hasJoin = false;
                this.result.join_ = false;
                return this;
            }

            public override DraftQueue.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DraftQueue.Builder(this.result);
                }
                return new DraftQueue.Builder().MergeFrom(this.result);
            }

            public override DraftQueue.Builder MergeFrom(DraftQueue other)
            {
                if (other != DraftQueue.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasJoin)
                    {
                        this.Join = other.Join;
                    }
                }
                return this;
            }

            public override DraftQueue.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DraftQueue.Builder MergeFrom(IMessageLite other)
            {
                if (other is DraftQueue)
                {
                    return this.MergeFrom((DraftQueue) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DraftQueue.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DraftQueue._draftQueueFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DraftQueue._draftQueueFieldTags[index];
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
                    this.result.hasJoin = input.ReadBool(ref this.result.join_);
                }
                return this;
            }

            private DraftQueue PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DraftQueue result = this.result;
                    this.result = new DraftQueue();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DraftQueue.Builder SetJoin(bool value)
            {
                this.PrepareBuilder();
                this.result.hasJoin = true;
                this.result.join_ = value;
                return this;
            }

            public override DraftQueue DefaultInstanceForType
            {
                get
                {
                    return DraftQueue.DefaultInstance;
                }
            }

            public bool HasJoin
            {
                get
                {
                    return this.result.hasJoin;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public bool Join
            {
                get
                {
                    return this.result.Join;
                }
                set
                {
                    this.SetJoin(value);
                }
            }

            protected override DraftQueue MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override DraftQueue.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0xa6
            }
        }
    }
}

