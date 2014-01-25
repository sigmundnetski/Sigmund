namespace bnet.protocol.notification
{
    using bnet.protocol.notification.Proto;
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class FindClientRequest : GeneratedMessageLite<FindClientRequest, Builder>
    {
        private static readonly string[] _findClientRequestFieldNames = new string[] { "entity_id" };
        private static readonly uint[] _findClientRequestFieldTags = new uint[] { 10 };
        private static readonly FindClientRequest defaultInstance = new FindClientRequest().MakeReadOnly();
        private bnet.protocol.notification.EntityId entityId_;
        public const int EntityIdFieldNumber = 1;
        private bool hasEntityId;
        private int memoizedSerializedSize = -1;

        static FindClientRequest()
        {
            object.ReferenceEquals(bnet.protocol.notification.Proto.Notification.Descriptor, null);
        }

        private FindClientRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(FindClientRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            FindClientRequest request = obj as FindClientRequest;
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

        private FindClientRequest MakeReadOnly()
        {
            return this;
        }

        public static FindClientRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static FindClientRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static FindClientRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static FindClientRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static FindClientRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static FindClientRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static FindClientRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static FindClientRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static FindClientRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static FindClientRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<FindClientRequest, Builder>.PrintField("entity_id", this.hasEntityId, this.entityId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _findClientRequestFieldNames;
            if (this.hasEntityId)
            {
                output.WriteMessage(1, strArray[0], this.EntityId);
            }
        }

        public static FindClientRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override FindClientRequest DefaultInstanceForType
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

        protected override FindClientRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<FindClientRequest, FindClientRequest.Builder>
        {
            private FindClientRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = FindClientRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(FindClientRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override FindClientRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override FindClientRequest.Builder Clear()
            {
                this.result = FindClientRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public FindClientRequest.Builder ClearEntityId()
            {
                this.PrepareBuilder();
                this.result.hasEntityId = false;
                this.result.entityId_ = null;
                return this;
            }

            public override FindClientRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new FindClientRequest.Builder(this.result);
                }
                return new FindClientRequest.Builder().MergeFrom(this.result);
            }

            public FindClientRequest.Builder MergeEntityId(bnet.protocol.notification.EntityId value)
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

            public override FindClientRequest.Builder MergeFrom(FindClientRequest other)
            {
                if (other != FindClientRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasEntityId)
                    {
                        this.MergeEntityId(other.EntityId);
                    }
                }
                return this;
            }

            public override FindClientRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override FindClientRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is FindClientRequest)
                {
                    return this.MergeFrom((FindClientRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override FindClientRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(FindClientRequest._findClientRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = FindClientRequest._findClientRequestFieldTags[index];
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

            private FindClientRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    FindClientRequest result = this.result;
                    this.result = new FindClientRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public FindClientRequest.Builder SetEntityId(bnet.protocol.notification.EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasEntityId = true;
                this.result.entityId_ = value;
                return this;
            }

            public FindClientRequest.Builder SetEntityId(bnet.protocol.notification.EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasEntityId = true;
                this.result.entityId_ = builderForValue.Build();
                return this;
            }

            public override FindClientRequest DefaultInstanceForType
            {
                get
                {
                    return FindClientRequest.DefaultInstance;
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

            protected override FindClientRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override FindClientRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

