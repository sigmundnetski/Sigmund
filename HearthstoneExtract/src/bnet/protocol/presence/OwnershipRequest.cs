namespace bnet.protocol.presence
{
    using bnet.protocol;
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class OwnershipRequest : GeneratedMessageLite<OwnershipRequest, Builder>
    {
        private static readonly string[] _ownershipRequestFieldNames = new string[] { "entity_id", "release_ownership" };
        private static readonly uint[] _ownershipRequestFieldTags = new uint[] { 10, 0x10 };
        private static readonly OwnershipRequest defaultInstance = new OwnershipRequest().MakeReadOnly();
        private bnet.protocol.EntityId entityId_;
        public const int EntityIdFieldNumber = 1;
        private bool hasEntityId;
        private bool hasReleaseOwnership;
        private int memoizedSerializedSize = -1;
        private bool releaseOwnership_;
        public const int ReleaseOwnershipFieldNumber = 2;

        static OwnershipRequest()
        {
            object.ReferenceEquals(PresenceService.Descriptor, null);
        }

        private OwnershipRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(OwnershipRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            OwnershipRequest request = obj as OwnershipRequest;
            if (request == null)
            {
                return false;
            }
            if ((this.hasEntityId != request.hasEntityId) || (this.hasEntityId && !this.entityId_.Equals(request.entityId_)))
            {
                return false;
            }
            return ((this.hasReleaseOwnership == request.hasReleaseOwnership) && (!this.hasReleaseOwnership || this.releaseOwnership_.Equals(request.releaseOwnership_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasEntityId)
            {
                hashCode ^= this.entityId_.GetHashCode();
            }
            if (this.hasReleaseOwnership)
            {
                hashCode ^= this.releaseOwnership_.GetHashCode();
            }
            return hashCode;
        }

        private OwnershipRequest MakeReadOnly()
        {
            return this;
        }

        public static OwnershipRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static OwnershipRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static OwnershipRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static OwnershipRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static OwnershipRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static OwnershipRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static OwnershipRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static OwnershipRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static OwnershipRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static OwnershipRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<OwnershipRequest, Builder>.PrintField("entity_id", this.hasEntityId, this.entityId_, writer);
            GeneratedMessageLite<OwnershipRequest, Builder>.PrintField("release_ownership", this.hasReleaseOwnership, this.releaseOwnership_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _ownershipRequestFieldNames;
            if (this.hasEntityId)
            {
                output.WriteMessage(1, strArray[0], this.EntityId);
            }
            if (this.hasReleaseOwnership)
            {
                output.WriteBool(2, strArray[1], this.ReleaseOwnership);
            }
        }

        public static OwnershipRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override OwnershipRequest DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bnet.protocol.EntityId EntityId
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.entityId_ != null)
                {
                    goto Label_0012;
                }
                return bnet.protocol.EntityId.DefaultInstance;
            }
        }

        public bool HasEntityId
        {
            get
            {
                return this.hasEntityId;
            }
        }

        public bool HasReleaseOwnership
        {
            get
            {
                return this.hasReleaseOwnership;
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

        public bool ReleaseOwnership
        {
            get
            {
                return this.releaseOwnership_;
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
                    if (this.hasReleaseOwnership)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(2, this.ReleaseOwnership);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override OwnershipRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<OwnershipRequest, OwnershipRequest.Builder>
        {
            private OwnershipRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = OwnershipRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(OwnershipRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override OwnershipRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override OwnershipRequest.Builder Clear()
            {
                this.result = OwnershipRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public OwnershipRequest.Builder ClearEntityId()
            {
                this.PrepareBuilder();
                this.result.hasEntityId = false;
                this.result.entityId_ = null;
                return this;
            }

            public OwnershipRequest.Builder ClearReleaseOwnership()
            {
                this.PrepareBuilder();
                this.result.hasReleaseOwnership = false;
                this.result.releaseOwnership_ = false;
                return this;
            }

            public override OwnershipRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new OwnershipRequest.Builder(this.result);
                }
                return new OwnershipRequest.Builder().MergeFrom(this.result);
            }

            public OwnershipRequest.Builder MergeEntityId(bnet.protocol.EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasEntityId && (this.result.entityId_ != bnet.protocol.EntityId.DefaultInstance))
                {
                    this.result.entityId_ = bnet.protocol.EntityId.CreateBuilder(this.result.entityId_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.entityId_ = value;
                }
                this.result.hasEntityId = true;
                return this;
            }

            public override OwnershipRequest.Builder MergeFrom(OwnershipRequest other)
            {
                if (other != OwnershipRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasEntityId)
                    {
                        this.MergeEntityId(other.EntityId);
                    }
                    if (other.HasReleaseOwnership)
                    {
                        this.ReleaseOwnership = other.ReleaseOwnership;
                    }
                }
                return this;
            }

            public override OwnershipRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override OwnershipRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is OwnershipRequest)
                {
                    return this.MergeFrom((OwnershipRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override OwnershipRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(OwnershipRequest._ownershipRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = OwnershipRequest._ownershipRequestFieldTags[index];
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
                            bnet.protocol.EntityId.Builder builder = bnet.protocol.EntityId.CreateBuilder();
                            if (this.result.hasEntityId)
                            {
                                builder.MergeFrom(this.EntityId);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.EntityId = builder.BuildPartial();
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
                    this.result.hasReleaseOwnership = input.ReadBool(ref this.result.releaseOwnership_);
                }
                return this;
            }

            private OwnershipRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    OwnershipRequest result = this.result;
                    this.result = new OwnershipRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public OwnershipRequest.Builder SetEntityId(bnet.protocol.EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasEntityId = true;
                this.result.entityId_ = value;
                return this;
            }

            public OwnershipRequest.Builder SetEntityId(bnet.protocol.EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasEntityId = true;
                this.result.entityId_ = builderForValue.Build();
                return this;
            }

            public OwnershipRequest.Builder SetReleaseOwnership(bool value)
            {
                this.PrepareBuilder();
                this.result.hasReleaseOwnership = true;
                this.result.releaseOwnership_ = value;
                return this;
            }

            public override OwnershipRequest DefaultInstanceForType
            {
                get
                {
                    return OwnershipRequest.DefaultInstance;
                }
            }

            public bnet.protocol.EntityId EntityId
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

            public bool HasReleaseOwnership
            {
                get
                {
                    return this.result.hasReleaseOwnership;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override OwnershipRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public bool ReleaseOwnership
            {
                get
                {
                    return this.result.ReleaseOwnership;
                }
                set
                {
                    this.SetReleaseOwnership(value);
                }
            }

            protected override OwnershipRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

