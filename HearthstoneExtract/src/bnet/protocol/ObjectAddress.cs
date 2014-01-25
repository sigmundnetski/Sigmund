namespace bnet.protocol
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class ObjectAddress : GeneratedMessageLite<ObjectAddress, Builder>
    {
        private static readonly string[] _objectAddressFieldNames = new string[] { "host", "object_id" };
        private static readonly uint[] _objectAddressFieldTags = new uint[] { 10, 0x10 };
        private static readonly ObjectAddress defaultInstance = new ObjectAddress().MakeReadOnly();
        private bool hasHost;
        private bool hasObjectId;
        private ProcessId host_;
        public const int HostFieldNumber = 1;
        private int memoizedSerializedSize = -1;
        private ulong objectId_;
        public const int ObjectIdFieldNumber = 2;

        static ObjectAddress()
        {
            object.ReferenceEquals(Rpc.Descriptor, null);
        }

        private ObjectAddress()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ObjectAddress prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ObjectAddress address = obj as ObjectAddress;
            if (address == null)
            {
                return false;
            }
            if ((this.hasHost != address.hasHost) || (this.hasHost && !this.host_.Equals(address.host_)))
            {
                return false;
            }
            return ((this.hasObjectId == address.hasObjectId) && (!this.hasObjectId || this.objectId_.Equals(address.objectId_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasHost)
            {
                hashCode ^= this.host_.GetHashCode();
            }
            if (this.hasObjectId)
            {
                hashCode ^= this.objectId_.GetHashCode();
            }
            return hashCode;
        }

        private ObjectAddress MakeReadOnly()
        {
            return this;
        }

        public static ObjectAddress ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ObjectAddress ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ObjectAddress ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ObjectAddress ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ObjectAddress ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ObjectAddress ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ObjectAddress ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ObjectAddress ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ObjectAddress ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ObjectAddress ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ObjectAddress, Builder>.PrintField("host", this.hasHost, this.host_, writer);
            GeneratedMessageLite<ObjectAddress, Builder>.PrintField("object_id", this.hasObjectId, this.objectId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _objectAddressFieldNames;
            if (this.hasHost)
            {
                output.WriteMessage(1, strArray[0], this.Host);
            }
            if (this.hasObjectId)
            {
                output.WriteUInt64(2, strArray[1], this.ObjectId);
            }
        }

        public static ObjectAddress DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ObjectAddress DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasHost
        {
            get
            {
                return this.hasHost;
            }
        }

        public bool HasObjectId
        {
            get
            {
                return this.hasObjectId;
            }
        }

        public ProcessId Host
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.host_ != null)
                {
                    goto Label_0012;
                }
                return ProcessId.DefaultInstance;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasHost)
                {
                    return false;
                }
                if (!this.Host.IsInitialized)
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
                    if (this.hasHost)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.Host);
                    }
                    if (this.hasObjectId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(2, this.ObjectId);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ObjectAddress ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<ObjectAddress, ObjectAddress.Builder>
        {
            private ObjectAddress result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ObjectAddress.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ObjectAddress cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override ObjectAddress BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ObjectAddress.Builder Clear()
            {
                this.result = ObjectAddress.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ObjectAddress.Builder ClearHost()
            {
                this.PrepareBuilder();
                this.result.hasHost = false;
                this.result.host_ = null;
                return this;
            }

            public ObjectAddress.Builder ClearObjectId()
            {
                this.PrepareBuilder();
                this.result.hasObjectId = false;
                this.result.objectId_ = 0L;
                return this;
            }

            public override ObjectAddress.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ObjectAddress.Builder(this.result);
                }
                return new ObjectAddress.Builder().MergeFrom(this.result);
            }

            public override ObjectAddress.Builder MergeFrom(ObjectAddress other)
            {
                if (other != ObjectAddress.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasHost)
                    {
                        this.MergeHost(other.Host);
                    }
                    if (other.HasObjectId)
                    {
                        this.ObjectId = other.ObjectId;
                    }
                }
                return this;
            }

            public override ObjectAddress.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ObjectAddress.Builder MergeFrom(IMessageLite other)
            {
                if (other is ObjectAddress)
                {
                    return this.MergeFrom((ObjectAddress) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ObjectAddress.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ObjectAddress._objectAddressFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ObjectAddress._objectAddressFieldTags[index];
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

                        case 10:
                        {
                            ProcessId.Builder builder = ProcessId.CreateBuilder();
                            if (this.result.hasHost)
                            {
                                builder.MergeFrom(this.Host);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.Host = builder.BuildPartial();
                            continue;
                        }
                        case 0x10:
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

            public ObjectAddress.Builder MergeHost(ProcessId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasHost && (this.result.host_ != ProcessId.DefaultInstance))
                {
                    this.result.host_ = ProcessId.CreateBuilder(this.result.host_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.host_ = value;
                }
                this.result.hasHost = true;
                return this;
            }

            private ObjectAddress PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ObjectAddress result = this.result;
                    this.result = new ObjectAddress();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ObjectAddress.Builder SetHost(ProcessId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasHost = true;
                this.result.host_ = value;
                return this;
            }

            public ObjectAddress.Builder SetHost(ProcessId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasHost = true;
                this.result.host_ = builderForValue.Build();
                return this;
            }

            [CLSCompliant(false)]
            public ObjectAddress.Builder SetObjectId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasObjectId = true;
                this.result.objectId_ = value;
                return this;
            }

            public override ObjectAddress DefaultInstanceForType
            {
                get
                {
                    return ObjectAddress.DefaultInstance;
                }
            }

            public bool HasHost
            {
                get
                {
                    return this.result.hasHost;
                }
            }

            public bool HasObjectId
            {
                get
                {
                    return this.result.hasObjectId;
                }
            }

            public ProcessId Host
            {
                get
                {
                    return this.result.Host;
                }
                set
                {
                    this.SetHost(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override ObjectAddress MessageBeingBuilt
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

            protected override ObjectAddress.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

