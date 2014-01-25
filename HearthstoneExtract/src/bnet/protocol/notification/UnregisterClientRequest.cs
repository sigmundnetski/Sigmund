namespace bnet.protocol.notification
{
    using bnet.protocol.notification.Proto;
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class UnregisterClientRequest : GeneratedMessageLite<UnregisterClientRequest, Builder>
    {
        private static readonly string[] _unregisterClientRequestFieldNames = new string[] { "entity_id" };
        private static readonly uint[] _unregisterClientRequestFieldTags = new uint[] { 10 };
        private static readonly UnregisterClientRequest defaultInstance = new UnregisterClientRequest().MakeReadOnly();
        private bnet.protocol.notification.EntityId entityId_;
        public const int EntityIdFieldNumber = 1;
        private bool hasEntityId;
        private int memoizedSerializedSize = -1;

        static UnregisterClientRequest()
        {
            object.ReferenceEquals(bnet.protocol.notification.Proto.Notification.Descriptor, null);
        }

        private UnregisterClientRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(UnregisterClientRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            UnregisterClientRequest request = obj as UnregisterClientRequest;
            if (request == null)
            {
                return false;
            }
            return ((this.hasEntityId == request.hasEntityId) && (!this.hasEntityId || this.entityId_.Equals(request.entityId_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasEntityId)
            {
                hashCode ^= this.entityId_.GetHashCode();
            }
            return hashCode;
        }

        private UnregisterClientRequest MakeReadOnly()
        {
            return this;
        }

        public static UnregisterClientRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static UnregisterClientRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static UnregisterClientRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static UnregisterClientRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static UnregisterClientRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static UnregisterClientRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static UnregisterClientRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static UnregisterClientRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static UnregisterClientRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static UnregisterClientRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<UnregisterClientRequest, Builder>.PrintField("entity_id", this.hasEntityId, this.entityId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _unregisterClientRequestFieldNames;
            if (this.hasEntityId)
            {
                output.WriteMessage(1, strArray[0], this.EntityId);
            }
        }

        public static UnregisterClientRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override UnregisterClientRequest DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bnet.protocol.notification.EntityId EntityId
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.entityId_ != null)
                {
                    goto Label_0012;
                }
                return bnet.protocol.notification.EntityId.DefaultInstance;
            }
        }

        public bool HasEntityId
        {
            get
            {
                return this.hasEntityId;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasEntityId)
                {
                    return false;
                }
                if (!this.EntityId.IsInitialized)
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
                    if (this.hasEntityId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.EntityId);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override UnregisterClientRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<UnregisterClientRequest, UnregisterClientRequest.Builder>
        {
            private UnregisterClientRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = UnregisterClientRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(UnregisterClientRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override UnregisterClientRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override UnregisterClientRequest.Builder Clear()
            {
                this.result = UnregisterClientRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public UnregisterClientRequest.Builder ClearEntityId()
            {
                this.PrepareBuilder();
                this.result.hasEntityId = false;
                this.result.entityId_ = null;
                return this;
            }

            public override UnregisterClientRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new UnregisterClientRequest.Builder(this.result);
                }
                return new UnregisterClientRequest.Builder().MergeFrom(this.result);
            }

            public UnregisterClientRequest.Builder MergeEntityId(bnet.protocol.notification.EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasEntityId && (this.result.entityId_ != bnet.protocol.notification.EntityId.DefaultInstance))
                {
                    this.result.entityId_ = bnet.protocol.notification.EntityId.CreateBuilder(this.result.entityId_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.entityId_ = value;
                }
                this.result.hasEntityId = true;
                return this;
            }

            public override UnregisterClientRequest.Builder MergeFrom(UnregisterClientRequest other)
            {
                if (other != UnregisterClientRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasEntityId)
                    {
                        this.MergeEntityId(other.EntityId);
                    }
                }
                return this;
            }

            public override UnregisterClientRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override UnregisterClientRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is UnregisterClientRequest)
                {
                    return this.MergeFrom((UnregisterClientRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override UnregisterClientRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(UnregisterClientRequest._unregisterClientRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = UnregisterClientRequest._unregisterClientRequestFieldTags[index];
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
                            bnet.protocol.notification.EntityId.Builder builder = bnet.protocol.notification.EntityId.CreateBuilder();
                            if (this.result.hasEntityId)
                            {
                                builder.MergeFrom(this.EntityId);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.EntityId = builder.BuildPartial();
                            continue;
                        }
                    }
                    if (WireFormat.IsEndGroupTag(num))
                    {
                        return this;
                    }
                    this.ParseUnknownField(input, extensionRegistry, num, str);
                }
                return this;
            }

            private UnregisterClientRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    UnregisterClientRequest result = this.result;
                    this.result = new UnregisterClientRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public UnregisterClientRequest.Builder SetEntityId(bnet.protocol.notification.EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasEntityId = true;
                this.result.entityId_ = value;
                return this;
            }

            public UnregisterClientRequest.Builder SetEntityId(bnet.protocol.notification.EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasEntityId = true;
                this.result.entityId_ = builderForValue.Build();
                return this;
            }

            public override UnregisterClientRequest DefaultInstanceForType
            {
                get
                {
                    return UnregisterClientRequest.DefaultInstance;
                }
            }

            public bnet.protocol.notification.EntityId EntityId
            {
                get
                {
                    return this.result.EntityId;
                }
                set
                {
                    this.SetEntityId(value);
                }
            }

            public bool HasEntityId
            {
                get
                {
                    return this.result.hasEntityId;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override UnregisterClientRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override UnregisterClientRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

