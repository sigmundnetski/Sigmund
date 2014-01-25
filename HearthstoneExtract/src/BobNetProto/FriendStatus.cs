namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class FriendStatus : GeneratedMessageLite<FriendStatus, Builder>
    {
        private static readonly string[] _friendStatusFieldNames = new string[] { "status" };
        private static readonly uint[] _friendStatusFieldTags = new uint[] { 8 };
        private static readonly FriendStatus defaultInstance = new FriendStatus().MakeReadOnly();
        private bool hasStatus;
        private int memoizedSerializedSize = -1;
        private BobNetProto.FriendStatus.Types.Status status_ = BobNetProto.FriendStatus.Types.Status.NEED_LIST;
        public const int StatusFieldNumber = 1;

        static FriendStatus()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private FriendStatus()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(FriendStatus prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            FriendStatus status = obj as FriendStatus;
            if (status == null)
            {
                return false;
            }
            return ((this.hasStatus == status.hasStatus) && (!this.hasStatus || this.status_.Equals(status.status_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasStatus)
            {
                hashCode ^= this.status_.GetHashCode();
            }
            return hashCode;
        }

        private FriendStatus MakeReadOnly()
        {
            return this;
        }

        public static FriendStatus ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static FriendStatus ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static FriendStatus ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static FriendStatus ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static FriendStatus ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static FriendStatus ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static FriendStatus ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static FriendStatus ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static FriendStatus ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static FriendStatus ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<FriendStatus, Builder>.PrintField("status", this.hasStatus, this.status_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _friendStatusFieldNames;
            if (this.hasStatus)
            {
                output.WriteEnum(1, strArray[0], (int) this.Status, this.Status);
            }
        }

        public static FriendStatus DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override FriendStatus DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasStatus
        {
            get
            {
                return this.hasStatus;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasStatus)
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
                    if (this.hasStatus)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeEnumSize(1, (int) this.Status);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        public BobNetProto.FriendStatus.Types.Status Status
        {
            get
            {
                return this.status_;
            }
        }

        protected override FriendStatus ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<FriendStatus, FriendStatus.Builder>
        {
            private FriendStatus result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = FriendStatus.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(FriendStatus cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override FriendStatus BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override FriendStatus.Builder Clear()
            {
                this.result = FriendStatus.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public FriendStatus.Builder ClearStatus()
            {
                this.PrepareBuilder();
                this.result.hasStatus = false;
                this.result.status_ = BobNetProto.FriendStatus.Types.Status.NEED_LIST;
                return this;
            }

            public override FriendStatus.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new FriendStatus.Builder(this.result);
                }
                return new FriendStatus.Builder().MergeFrom(this.result);
            }

            public override FriendStatus.Builder MergeFrom(FriendStatus other)
            {
                if (other != FriendStatus.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasStatus)
                    {
                        this.Status = other.Status;
                    }
                }
                return this;
            }

            public override FriendStatus.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override FriendStatus.Builder MergeFrom(IMessageLite other)
            {
                if (other is FriendStatus)
                {
                    return this.MergeFrom((FriendStatus) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override FriendStatus.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    object obj2;
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(FriendStatus._friendStatusFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = FriendStatus._friendStatusFieldTags[index];
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
                    if (input.ReadEnum<BobNetProto.FriendStatus.Types.Status>(ref this.result.status_, out obj2))
                    {
                        this.result.hasStatus = true;
                    }
                    else if (!(obj2 is int))
                    {
                        continue;
                    }
                }
                return this;
            }

            private FriendStatus PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    FriendStatus result = this.result;
                    this.result = new FriendStatus();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public FriendStatus.Builder SetStatus(BobNetProto.FriendStatus.Types.Status value)
            {
                this.PrepareBuilder();
                this.result.hasStatus = true;
                this.result.status_ = value;
                return this;
            }

            public override FriendStatus DefaultInstanceForType
            {
                get
                {
                    return FriendStatus.DefaultInstance;
                }
            }

            public bool HasStatus
            {
                get
                {
                    return this.result.hasStatus;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override FriendStatus MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public BobNetProto.FriendStatus.Types.Status Status
            {
                get
                {
                    return this.result.Status;
                }
                set
                {
                    this.SetStatus(value);
                }
            }

            protected override FriendStatus.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 160
            }

            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum Status
            {
                NEED_LIST = 1,
                SET_AVAILABLE = 2,
                SET_UNAVAILABLE = 3
            }
        }
    }
}

