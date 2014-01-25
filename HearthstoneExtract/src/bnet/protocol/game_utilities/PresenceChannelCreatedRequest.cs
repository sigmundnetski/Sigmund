namespace bnet.protocol.game_utilities
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class PresenceChannelCreatedRequest : GeneratedMessageLite<PresenceChannelCreatedRequest, Builder>
    {
        private static readonly string[] _presenceChannelCreatedRequestFieldNames = new string[] { "bnet_account_id", "game_account_id", "host", "id" };
        private static readonly uint[] _presenceChannelCreatedRequestFieldTags = new uint[] { 0x22, 0x1a, 0x2a, 10 };
        private EntityId bnetAccountId_;
        public const int BnetAccountIdFieldNumber = 4;
        private static readonly PresenceChannelCreatedRequest defaultInstance = new PresenceChannelCreatedRequest().MakeReadOnly();
        private EntityId gameAccountId_;
        public const int GameAccountIdFieldNumber = 3;
        private bool hasBnetAccountId;
        private bool hasGameAccountId;
        private bool hasHost;
        private bool hasId;
        private ProcessId host_;
        public const int HostFieldNumber = 5;
        private EntityId id_;
        public const int IdFieldNumber = 1;
        private int memoizedSerializedSize = -1;

        static PresenceChannelCreatedRequest()
        {
            object.ReferenceEquals(GameUtils.Descriptor, null);
        }

        private PresenceChannelCreatedRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(PresenceChannelCreatedRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            PresenceChannelCreatedRequest request = obj as PresenceChannelCreatedRequest;
            if (request == null)
            {
                return false;
            }
            if ((this.hasId != request.hasId) || (this.hasId && !this.id_.Equals(request.id_)))
            {
                return false;
            }
            if ((this.hasGameAccountId != request.hasGameAccountId) || (this.hasGameAccountId && !this.gameAccountId_.Equals(request.gameAccountId_)))
            {
                return false;
            }
            if ((this.hasBnetAccountId != request.hasBnetAccountId) || (this.hasBnetAccountId && !this.bnetAccountId_.Equals(request.bnetAccountId_)))
            {
                return false;
            }
            return ((this.hasHost == request.hasHost) && (!this.hasHost || this.host_.Equals(request.host_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasId)
            {
                hashCode ^= this.id_.GetHashCode();
            }
            if (this.hasGameAccountId)
            {
                hashCode ^= this.gameAccountId_.GetHashCode();
            }
            if (this.hasBnetAccountId)
            {
                hashCode ^= this.bnetAccountId_.GetHashCode();
            }
            if (this.hasHost)
            {
                hashCode ^= this.host_.GetHashCode();
            }
            return hashCode;
        }

        private PresenceChannelCreatedRequest MakeReadOnly()
        {
            return this;
        }

        public static PresenceChannelCreatedRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static PresenceChannelCreatedRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static PresenceChannelCreatedRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PresenceChannelCreatedRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PresenceChannelCreatedRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PresenceChannelCreatedRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PresenceChannelCreatedRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static PresenceChannelCreatedRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PresenceChannelCreatedRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PresenceChannelCreatedRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<PresenceChannelCreatedRequest, Builder>.PrintField("id", this.hasId, this.id_, writer);
            GeneratedMessageLite<PresenceChannelCreatedRequest, Builder>.PrintField("game_account_id", this.hasGameAccountId, this.gameAccountId_, writer);
            GeneratedMessageLite<PresenceChannelCreatedRequest, Builder>.PrintField("bnet_account_id", this.hasBnetAccountId, this.bnetAccountId_, writer);
            GeneratedMessageLite<PresenceChannelCreatedRequest, Builder>.PrintField("host", this.hasHost, this.host_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _presenceChannelCreatedRequestFieldNames;
            if (this.hasId)
            {
                output.WriteMessage(1, strArray[3], this.Id);
            }
            if (this.hasGameAccountId)
            {
                output.WriteMessage(3, strArray[1], this.GameAccountId);
            }
            if (this.hasBnetAccountId)
            {
                output.WriteMessage(4, strArray[0], this.BnetAccountId);
            }
            if (this.hasHost)
            {
                output.WriteMessage(5, strArray[2], this.Host);
            }
        }

        public EntityId BnetAccountId
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.bnetAccountId_ != null)
                {
                    goto Label_0012;
                }
                return EntityId.DefaultInstance;
            }
        }

        public static PresenceChannelCreatedRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override PresenceChannelCreatedRequest DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public EntityId GameAccountId
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.gameAccountId_ != null)
                {
                    goto Label_0012;
                }
                return EntityId.DefaultInstance;
            }
        }

        public bool HasBnetAccountId
        {
            get
            {
                return this.hasBnetAccountId;
            }
        }

        public bool HasGameAccountId
        {
            get
            {
                return this.hasGameAccountId;
            }
        }

        public bool HasHost
        {
            get
            {
                return this.hasHost;
            }
        }

        public bool HasId
        {
            get
            {
                return this.hasId;
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

        public EntityId Id
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.id_ != null)
                {
                    goto Label_0012;
                }
                return EntityId.DefaultInstance;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasId)
                {
                    return false;
                }
                if (!this.Id.IsInitialized)
                {
                    return false;
                }
                if (this.HasGameAccountId && !this.GameAccountId.IsInitialized)
                {
                    return false;
                }
                if (this.HasBnetAccountId && !this.BnetAccountId.IsInitialized)
                {
                    return false;
                }
                if (this.HasHost && !this.Host.IsInitialized)
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
                    if (this.hasId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.Id);
                    }
                    if (this.hasGameAccountId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(3, this.GameAccountId);
                    }
                    if (this.hasBnetAccountId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(4, this.BnetAccountId);
                    }
                    if (this.hasHost)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(5, this.Host);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override PresenceChannelCreatedRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<PresenceChannelCreatedRequest, PresenceChannelCreatedRequest.Builder>
        {
            private PresenceChannelCreatedRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = PresenceChannelCreatedRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(PresenceChannelCreatedRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override PresenceChannelCreatedRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override PresenceChannelCreatedRequest.Builder Clear()
            {
                this.result = PresenceChannelCreatedRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public PresenceChannelCreatedRequest.Builder ClearBnetAccountId()
            {
                this.PrepareBuilder();
                this.result.hasBnetAccountId = false;
                this.result.bnetAccountId_ = null;
                return this;
            }

            public PresenceChannelCreatedRequest.Builder ClearGameAccountId()
            {
                this.PrepareBuilder();
                this.result.hasGameAccountId = false;
                this.result.gameAccountId_ = null;
                return this;
            }

            public PresenceChannelCreatedRequest.Builder ClearHost()
            {
                this.PrepareBuilder();
                this.result.hasHost = false;
                this.result.host_ = null;
                return this;
            }

            public PresenceChannelCreatedRequest.Builder ClearId()
            {
                this.PrepareBuilder();
                this.result.hasId = false;
                this.result.id_ = null;
                return this;
            }

            public override PresenceChannelCreatedRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new PresenceChannelCreatedRequest.Builder(this.result);
                }
                return new PresenceChannelCreatedRequest.Builder().MergeFrom(this.result);
            }

            public PresenceChannelCreatedRequest.Builder MergeBnetAccountId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasBnetAccountId && (this.result.bnetAccountId_ != EntityId.DefaultInstance))
                {
                    this.result.bnetAccountId_ = EntityId.CreateBuilder(this.result.bnetAccountId_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.bnetAccountId_ = value;
                }
                this.result.hasBnetAccountId = true;
                return this;
            }

            public override PresenceChannelCreatedRequest.Builder MergeFrom(PresenceChannelCreatedRequest other)
            {
                if (other != PresenceChannelCreatedRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasId)
                    {
                        this.MergeId(other.Id);
                    }
                    if (other.HasGameAccountId)
                    {
                        this.MergeGameAccountId(other.GameAccountId);
                    }
                    if (other.HasBnetAccountId)
                    {
                        this.MergeBnetAccountId(other.BnetAccountId);
                    }
                    if (other.HasHost)
                    {
                        this.MergeHost(other.Host);
                    }
                }
                return this;
            }

            public override PresenceChannelCreatedRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override PresenceChannelCreatedRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is PresenceChannelCreatedRequest)
                {
                    return this.MergeFrom((PresenceChannelCreatedRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override PresenceChannelCreatedRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(PresenceChannelCreatedRequest._presenceChannelCreatedRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = PresenceChannelCreatedRequest._presenceChannelCreatedRequestFieldTags[index];
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
                            EntityId.Builder builder = EntityId.CreateBuilder();
                            if (this.result.hasId)
                            {
                                builder.MergeFrom(this.Id);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.Id = builder.BuildPartial();
                            continue;
                        }
                        case 0x1a:
                        {
                            EntityId.Builder builder2 = EntityId.CreateBuilder();
                            if (this.result.hasGameAccountId)
                            {
                                builder2.MergeFrom(this.GameAccountId);
                            }
                            input.ReadMessage(builder2, extensionRegistry);
                            this.GameAccountId = builder2.BuildPartial();
                            continue;
                        }
                        case 0x22:
                        {
                            EntityId.Builder builder3 = EntityId.CreateBuilder();
                            if (this.result.hasBnetAccountId)
                            {
                                builder3.MergeFrom(this.BnetAccountId);
                            }
                            input.ReadMessage(builder3, extensionRegistry);
                            this.BnetAccountId = builder3.BuildPartial();
                            continue;
                        }
                        case 0x2a:
                        {
                            ProcessId.Builder builder4 = ProcessId.CreateBuilder();
                            if (this.result.hasHost)
                            {
                                builder4.MergeFrom(this.Host);
                            }
                            input.ReadMessage(builder4, extensionRegistry);
                            this.Host = builder4.BuildPartial();
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

            public PresenceChannelCreatedRequest.Builder MergeGameAccountId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasGameAccountId && (this.result.gameAccountId_ != EntityId.DefaultInstance))
                {
                    this.result.gameAccountId_ = EntityId.CreateBuilder(this.result.gameAccountId_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.gameAccountId_ = value;
                }
                this.result.hasGameAccountId = true;
                return this;
            }

            public PresenceChannelCreatedRequest.Builder MergeHost(ProcessId value)
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

            public PresenceChannelCreatedRequest.Builder MergeId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasId && (this.result.id_ != EntityId.DefaultInstance))
                {
                    this.result.id_ = EntityId.CreateBuilder(this.result.id_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.id_ = value;
                }
                this.result.hasId = true;
                return this;
            }

            private PresenceChannelCreatedRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    PresenceChannelCreatedRequest result = this.result;
                    this.result = new PresenceChannelCreatedRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public PresenceChannelCreatedRequest.Builder SetBnetAccountId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasBnetAccountId = true;
                this.result.bnetAccountId_ = value;
                return this;
            }

            public PresenceChannelCreatedRequest.Builder SetBnetAccountId(EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasBnetAccountId = true;
                this.result.bnetAccountId_ = builderForValue.Build();
                return this;
            }

            public PresenceChannelCreatedRequest.Builder SetGameAccountId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasGameAccountId = true;
                this.result.gameAccountId_ = value;
                return this;
            }

            public PresenceChannelCreatedRequest.Builder SetGameAccountId(EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasGameAccountId = true;
                this.result.gameAccountId_ = builderForValue.Build();
                return this;
            }

            public PresenceChannelCreatedRequest.Builder SetHost(ProcessId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasHost = true;
                this.result.host_ = value;
                return this;
            }

            public PresenceChannelCreatedRequest.Builder SetHost(ProcessId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasHost = true;
                this.result.host_ = builderForValue.Build();
                return this;
            }

            public PresenceChannelCreatedRequest.Builder SetId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasId = true;
                this.result.id_ = value;
                return this;
            }

            public PresenceChannelCreatedRequest.Builder SetId(EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasId = true;
                this.result.id_ = builderForValue.Build();
                return this;
            }

            public EntityId BnetAccountId
            {
                get
                {
                    return this.result.BnetAccountId;
                }
                set
                {
                    this.SetBnetAccountId(value);
                }
            }

            public override PresenceChannelCreatedRequest DefaultInstanceForType
            {
                get
                {
                    return PresenceChannelCreatedRequest.DefaultInstance;
                }
            }

            public EntityId GameAccountId
            {
                get
                {
                    return this.result.GameAccountId;
                }
                set
                {
                    this.SetGameAccountId(value);
                }
            }

            public bool HasBnetAccountId
            {
                get
                {
                    return this.result.hasBnetAccountId;
                }
            }

            public bool HasGameAccountId
            {
                get
                {
                    return this.result.hasGameAccountId;
                }
            }

            public bool HasHost
            {
                get
                {
                    return this.result.hasHost;
                }
            }

            public bool HasId
            {
                get
                {
                    return this.result.hasId;
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

            public EntityId Id
            {
                get
                {
                    return this.result.Id;
                }
                set
                {
                    this.SetId(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override PresenceChannelCreatedRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override PresenceChannelCreatedRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

