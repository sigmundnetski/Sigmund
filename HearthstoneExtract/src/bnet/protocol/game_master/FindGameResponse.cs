namespace bnet.protocol.game_master
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class FindGameResponse : GeneratedMessageLite<FindGameResponse, Builder>
    {
        private static readonly string[] _findGameResponseFieldNames = new string[] { "factory_id", "queued", "request_id" };
        private static readonly uint[] _findGameResponseFieldTags = new uint[] { 0x11, 0x18, 9 };
        private static readonly FindGameResponse defaultInstance = new FindGameResponse().MakeReadOnly();
        private ulong factoryId_;
        public const int FactoryIdFieldNumber = 2;
        private bool hasFactoryId;
        private bool hasQueued;
        private bool hasRequestId;
        private int memoizedSerializedSize = -1;
        private bool queued_;
        public const int QueuedFieldNumber = 3;
        private ulong requestId_;
        public const int RequestIdFieldNumber = 1;

        static FindGameResponse()
        {
            object.ReferenceEquals(GameMaster.Descriptor, null);
        }

        private FindGameResponse()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(FindGameResponse prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            FindGameResponse response = obj as FindGameResponse;
            if (response == null)
            {
                return false;
            }
            if ((this.hasRequestId != response.hasRequestId) || (this.hasRequestId && !this.requestId_.Equals(response.requestId_)))
            {
                return false;
            }
            if ((this.hasFactoryId != response.hasFactoryId) || (this.hasFactoryId && !this.factoryId_.Equals(response.factoryId_)))
            {
                return false;
            }
            return ((this.hasQueued == response.hasQueued) && (!this.hasQueued || this.queued_.Equals(response.queued_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasRequestId)
            {
                hashCode ^= this.requestId_.GetHashCode();
            }
            if (this.hasFactoryId)
            {
                hashCode ^= this.factoryId_.GetHashCode();
            }
            if (this.hasQueued)
            {
                hashCode ^= this.queued_.GetHashCode();
            }
            return hashCode;
        }

        private FindGameResponse MakeReadOnly()
        {
            return this;
        }

        public static FindGameResponse ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static FindGameResponse ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static FindGameResponse ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static FindGameResponse ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static FindGameResponse ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static FindGameResponse ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static FindGameResponse ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static FindGameResponse ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static FindGameResponse ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static FindGameResponse ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<FindGameResponse, Builder>.PrintField("request_id", this.hasRequestId, this.requestId_, writer);
            GeneratedMessageLite<FindGameResponse, Builder>.PrintField("factory_id", this.hasFactoryId, this.factoryId_, writer);
            GeneratedMessageLite<FindGameResponse, Builder>.PrintField("queued", this.hasQueued, this.queued_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _findGameResponseFieldNames;
            if (this.hasRequestId)
            {
                output.WriteFixed64(1, strArray[2], this.RequestId);
            }
            if (this.hasFactoryId)
            {
                output.WriteFixed64(2, strArray[0], this.FactoryId);
            }
            if (this.hasQueued)
            {
                output.WriteBool(3, strArray[1], this.Queued);
            }
        }

        public static FindGameResponse DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override FindGameResponse DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        [CLSCompliant(false)]
        public ulong FactoryId
        {
            get
            {
                return this.factoryId_;
            }
        }

        public bool HasFactoryId
        {
            get
            {
                return this.hasFactoryId;
            }
        }

        public bool HasQueued
        {
            get
            {
                return this.hasQueued;
            }
        }

        public bool HasRequestId
        {
            get
            {
                return this.hasRequestId;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                return true;
            }
        }

        public bool Queued
        {
            get
            {
                return this.queued_;
            }
        }

        [CLSCompliant(false)]
        public ulong RequestId
        {
            get
            {
                return this.requestId_;
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
                    if (this.hasRequestId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed64Size(1, this.RequestId);
                    }
                    if (this.hasFactoryId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed64Size(2, this.FactoryId);
                    }
                    if (this.hasQueued)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(3, this.Queued);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override FindGameResponse ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<FindGameResponse, FindGameResponse.Builder>
        {
            private FindGameResponse result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = FindGameResponse.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(FindGameResponse cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override FindGameResponse BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override FindGameResponse.Builder Clear()
            {
                this.result = FindGameResponse.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public FindGameResponse.Builder ClearFactoryId()
            {
                this.PrepareBuilder();
                this.result.hasFactoryId = false;
                this.result.factoryId_ = 0L;
                return this;
            }

            public FindGameResponse.Builder ClearQueued()
            {
                this.PrepareBuilder();
                this.result.hasQueued = false;
                this.result.queued_ = false;
                return this;
            }

            public FindGameResponse.Builder ClearRequestId()
            {
                this.PrepareBuilder();
                this.result.hasRequestId = false;
                this.result.requestId_ = 0L;
                return this;
            }

            public override FindGameResponse.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new FindGameResponse.Builder(this.result);
                }
                return new FindGameResponse.Builder().MergeFrom(this.result);
            }

            public override FindGameResponse.Builder MergeFrom(FindGameResponse other)
            {
                if (other != FindGameResponse.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasRequestId)
                    {
                        this.RequestId = other.RequestId;
                    }
                    if (other.HasFactoryId)
                    {
                        this.FactoryId = other.FactoryId;
                    }
                    if (other.HasQueued)
                    {
                        this.Queued = other.Queued;
                    }
                }
                return this;
            }

            public override FindGameResponse.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override FindGameResponse.Builder MergeFrom(IMessageLite other)
            {
                if (other is FindGameResponse)
                {
                    return this.MergeFrom((FindGameResponse) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override FindGameResponse.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(FindGameResponse._findGameResponseFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = FindGameResponse._findGameResponseFieldTags[index];
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

                        case 9:
                        {
                            this.result.hasRequestId = input.ReadFixed64(ref this.result.requestId_);
                            continue;
                        }
                        case 0x11:
                        {
                            this.result.hasFactoryId = input.ReadFixed64(ref this.result.factoryId_);
                            continue;
                        }
                        case 0x18:
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
                    this.result.hasQueued = input.ReadBool(ref this.result.queued_);
                }
                return this;
            }

            private FindGameResponse PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    FindGameResponse result = this.result;
                    this.result = new FindGameResponse();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public FindGameResponse.Builder SetFactoryId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasFactoryId = true;
                this.result.factoryId_ = value;
                return this;
            }

            public FindGameResponse.Builder SetQueued(bool value)
            {
                this.PrepareBuilder();
                this.result.hasQueued = true;
                this.result.queued_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public FindGameResponse.Builder SetRequestId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasRequestId = true;
                this.result.requestId_ = value;
                return this;
            }

            public override FindGameResponse DefaultInstanceForType
            {
                get
                {
                    return FindGameResponse.DefaultInstance;
                }
            }

            [CLSCompliant(false)]
            public ulong FactoryId
            {
                get
                {
                    return this.result.FactoryId;
                }
                set
                {
                    this.SetFactoryId(value);
                }
            }

            public bool HasFactoryId
            {
                get
                {
                    return this.result.hasFactoryId;
                }
            }

            public bool HasQueued
            {
                get
                {
                    return this.result.hasQueued;
                }
            }

            public bool HasRequestId
            {
                get
                {
                    return this.result.hasRequestId;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override FindGameResponse MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public bool Queued
            {
                get
                {
                    return this.result.Queued;
                }
                set
                {
                    this.SetQueued(value);
                }
            }

            [CLSCompliant(false)]
            public ulong RequestId
            {
                get
                {
                    return this.result.RequestId;
                }
                set
                {
                    this.SetRequestId(value);
                }
            }

            protected override FindGameResponse.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

