namespace bnet.protocol.game_master
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class SubscribeRequest : GeneratedMessageLite<SubscribeRequest, Builder>
    {
        private static readonly string[] _subscribeRequestFieldNames = new string[] { "object_id" };
        private static readonly uint[] _subscribeRequestFieldTags = new uint[] { 8 };
        private static readonly SubscribeRequest defaultInstance = new SubscribeRequest().MakeReadOnly();
        private bool hasObjectId;
        private int memoizedSerializedSize = -1;
        private ulong objectId_;
        public const int ObjectIdFieldNumber = 1;

        static SubscribeRequest()
        {
            object.ReferenceEquals(GameMaster.Descriptor, null);
        }

        private SubscribeRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(SubscribeRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            SubscribeRequest request = obj as SubscribeRequest;
            if (request == null)
            {
                return false;
            }
            return ((this.hasObjectId == request.hasObjectId) && (!this.hasObjectId || this.objectId_.Equals(request.objectId_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasObjectId)
            {
                hashCode ^= this.objectId_.GetHashCode();
            }
            return hashCode;
        }

        private SubscribeRequest MakeReadOnly()
        {
            return this;
        }

        public static SubscribeRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static SubscribeRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static SubscribeRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static SubscribeRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static SubscribeRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static SubscribeRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static SubscribeRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static SubscribeRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static SubscribeRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static SubscribeRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<SubscribeRequest, Builder>.PrintField("object_id", this.hasObjectId, this.objectId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _subscribeRequestFieldNames;
            if (this.hasObjectId)
            {
                output.WriteUInt64(1, strArray[0], this.ObjectId);
            }
        }

        public static SubscribeRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override SubscribeRequest DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasObjectId
        {
            get
            {
                return this.hasObjectId;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasObjectId)
                {
                    return false;
                }
                return true;
            }
        }

        [CLSCompliant(false)]
        public ulong ObjectId
        {
            get
            {
                return this.objectId_;
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
                    if (this.hasObjectId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(1, this.ObjectId);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override SubscribeRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<SubscribeRequest, SubscribeRequest.Builder>
        {
            private SubscribeRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = SubscribeRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(SubscribeRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override SubscribeRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override SubscribeRequest.Builder Clear()
            {
                this.result = SubscribeRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public SubscribeRequest.Builder ClearObjectId()
            {
                this.PrepareBuilder();
                this.result.hasObjectId = false;
                this.result.objectId_ = 0L;
                return this;
            }

            public override SubscribeRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new SubscribeRequest.Builder(this.result);
                }
                return new SubscribeRequest.Builder().MergeFrom(this.result);
            }

            public override SubscribeRequest.Builder MergeFrom(SubscribeRequest other)
            {
                if (other != SubscribeRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasObjectId)
                    {
                        this.ObjectId = other.ObjectId;
                    }
                }
                return this;
            }

            public override SubscribeRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override SubscribeRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is SubscribeRequest)
                {
                    return this.MergeFrom((SubscribeRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override SubscribeRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(SubscribeRequest._subscribeRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = SubscribeRequest._subscribeRequestFieldTags[index];
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
                    this.result.hasObjectId = input.ReadUInt64(ref this.result.objectId_);
                }
                return this;
            }

            private SubscribeRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    SubscribeRequest result = this.result;
                    this.result = new SubscribeRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public SubscribeRequest.Builder SetObjectId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasObjectId = true;
                this.result.objectId_ = value;
                return this;
            }

            public override SubscribeRequest DefaultInstanceForType
            {
                get
                {
                    return SubscribeRequest.DefaultInstance;
                }
            }

            public bool HasObjectId
            {
                get
                {
                    return this.result.hasObjectId;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override SubscribeRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            [CLSCompliant(false)]
            public ulong ObjectId
            {
                get
                {
                    return this.result.ObjectId;
                }
                set
                {
                    this.SetObjectId(value);
                }
            }

            protected override SubscribeRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

