namespace bnet.protocol.game_utilities
{
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class ClientRequest : GeneratedMessageLite<ClientRequest, Builder>
    {
        private static readonly string[] _clientRequestFieldNames = new string[] { "attribute", "bnet_account_id", "game_account_id", "host" };
        private static readonly uint[] _clientRequestFieldTags = new uint[] { 10, 0x1a, 0x22, 0x12 };
        private PopsicleList<bnet.protocol.game_utilities.Attribute> attribute_ = new PopsicleList<bnet.protocol.game_utilities.Attribute>();
        public const int AttributeFieldNumber = 1;
        private EntityId bnetAccountId_;
        public const int BnetAccountIdFieldNumber = 3;
        private static readonly ClientRequest defaultInstance = new ClientRequest().MakeReadOnly();
        private EntityId gameAccountId_;
        public const int GameAccountIdFieldNumber = 4;
        private bool hasBnetAccountId;
        private bool hasGameAccountId;
        private bool hasHost;
        private ProcessId host_;
        public const int HostFieldNumber = 2;
        private int memoizedSerializedSize = -1;

        static ClientRequest()
        {
            object.ReferenceEquals(GameUtils.Descriptor, null);
        }

        private ClientRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ClientRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ClientRequest request = obj as ClientRequest;
            if (request == null)
            {
                return false;
            }
            if (this.attribute_.Count != request.attribute_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.attribute_.Count; i++)
            {
                if (!this.attribute_[i].Equals(request.attribute_[i]))
                {
                    return false;
                }
            }
            if ((this.hasHost != request.hasHost) || (this.hasHost && !this.host_.Equals(request.host_)))
            {
                return false;
            }
            if ((this.hasBnetAccountId != request.hasBnetAccountId) || (this.hasBnetAccountId && !this.bnetAccountId_.Equals(request.bnetAccountId_)))
            {
                return false;
            }
            return ((this.hasGameAccountId == request.hasGameAccountId) && (!this.hasGameAccountId || this.gameAccountId_.Equals(request.gameAccountId_)));
        }

        public bnet.protocol.game_utilities.Attribute GetAttribute(int index)
        {
            return this.attribute_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<bnet.protocol.game_utilities.Attribute> enumerator = this.attribute_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    bnet.protocol.game_utilities.Attribute current = enumerator.Current;
                    hashCode ^= current.GetHashCode();
                }
            }
            finally
            {
                if (enumerator == null)
                {
                }
                enumerator.Dispose();
            }
            if (this.hasHost)
            {
                hashCode ^= this.host_.GetHashCode();
            }
            if (this.hasBnetAccountId)
            {
                hashCode ^= this.bnetAccountId_.GetHashCode();
            }
            if (this.hasGameAccountId)
            {
                hashCode ^= this.gameAccountId_.GetHashCode();
            }
            return hashCode;
        }

        private ClientRequest MakeReadOnly()
        {
            this.attribute_.MakeReadOnly();
            return this;
        }

        public static ClientRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ClientRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ClientRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ClientRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ClientRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ClientRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ClientRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ClientRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ClientRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ClientRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ClientRequest, Builder>.PrintField<bnet.protocol.game_utilities.Attribute>("attribute", this.attribute_, writer);
            GeneratedMessageLite<ClientRequest, Builder>.PrintField("host", this.hasHost, this.host_, writer);
            GeneratedMessageLite<ClientRequest, Builder>.PrintField("bnet_account_id", this.hasBnetAccountId, this.bnetAccountId_, writer);
            GeneratedMessageLite<ClientRequest, Builder>.PrintField("game_account_id", this.hasGameAccountId, this.gameAccountId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _clientRequestFieldNames;
            if (this.attribute_.Count > 0)
            {
                output.WriteMessageArray<bnet.protocol.game_utilities.Attribute>(1, strArray[0], this.attribute_);
            }
            if (this.hasHost)
            {
                output.WriteMessage(2, strArray[3], this.Host);
            }
            if (this.hasBnetAccountId)
            {
                output.WriteMessage(3, strArray[1], this.BnetAccountId);
            }
            if (this.hasGameAccountId)
            {
                output.WriteMessage(4, strArray[2], this.GameAccountId);
            }
        }

        public int AttributeCount
        {
            get
            {
                return this.attribute_.Count;
            }
        }

        public IList<bnet.protocol.game_utilities.Attribute> AttributeList
        {
            get
            {
                return this.attribute_;
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

        public static ClientRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ClientRequest DefaultInstanceForType
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
                IEnumerator<bnet.protocol.game_utilities.Attribute> enumerator = this.AttributeList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        bnet.protocol.game_utilities.Attribute current = enumerator.Current;
                        if (!current.IsInitialized)
                        {
                            return false;
                        }
                    }
                }
                finally
                {
                    if (enumerator == null)
                    {
                    }
                    enumerator.Dispose();
                }
                if (this.HasHost && !this.Host.IsInitialized)
                {
                    return false;
                }
                if (this.HasBnetAccountId && !this.BnetAccountId.IsInitialized)
                {
                    return false;
                }
                if (this.HasGameAccountId && !this.GameAccountId.IsInitialized)
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
                    IEnumerator<bnet.protocol.game_utilities.Attribute> enumerator = this.AttributeList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            bnet.protocol.game_utilities.Attribute current = enumerator.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, current);
                        }
                    }
                    finally
                    {
                        if (enumerator == null)
                        {
                        }
                        enumerator.Dispose();
                    }
                    if (this.hasHost)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, this.Host);
                    }
                    if (this.hasBnetAccountId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(3, this.BnetAccountId);
                    }
                    if (this.hasGameAccountId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(4, this.GameAccountId);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ClientRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<ClientRequest, ClientRequest.Builder>
        {
            private ClientRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ClientRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ClientRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public ClientRequest.Builder AddAttribute(bnet.protocol.game_utilities.Attribute value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.attribute_.Add(value);
                return this;
            }

            public ClientRequest.Builder AddAttribute(bnet.protocol.game_utilities.Attribute.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.attribute_.Add(builderForValue.Build());
                return this;
            }

            public ClientRequest.Builder AddRangeAttribute(IEnumerable<bnet.protocol.game_utilities.Attribute> values)
            {
                this.PrepareBuilder();
                this.result.attribute_.Add(values);
                return this;
            }

            public override ClientRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ClientRequest.Builder Clear()
            {
                this.result = ClientRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ClientRequest.Builder ClearAttribute()
            {
                this.PrepareBuilder();
                this.result.attribute_.Clear();
                return this;
            }

            public ClientRequest.Builder ClearBnetAccountId()
            {
                this.PrepareBuilder();
                this.result.hasBnetAccountId = false;
                this.result.bnetAccountId_ = null;
                return this;
            }

            public ClientRequest.Builder ClearGameAccountId()
            {
                this.PrepareBuilder();
                this.result.hasGameAccountId = false;
                this.result.gameAccountId_ = null;
                return this;
            }

            public ClientRequest.Builder ClearHost()
            {
                this.PrepareBuilder();
                this.result.hasHost = false;
                this.result.host_ = null;
                return this;
            }

            public override ClientRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ClientRequest.Builder(this.result);
                }
                return new ClientRequest.Builder().MergeFrom(this.result);
            }

            public bnet.protocol.game_utilities.Attribute GetAttribute(int index)
            {
                return this.result.GetAttribute(index);
            }

            public ClientRequest.Builder MergeBnetAccountId(EntityId value)
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

            public override ClientRequest.Builder MergeFrom(ClientRequest other)
            {
                if (other != ClientRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.attribute_.Count != 0)
                    {
                        this.result.attribute_.Add(other.attribute_);
                    }
                    if (other.HasHost)
                    {
                        this.MergeHost(other.Host);
                    }
                    if (other.HasBnetAccountId)
                    {
                        this.MergeBnetAccountId(other.BnetAccountId);
                    }
                    if (other.HasGameAccountId)
                    {
                        this.MergeGameAccountId(other.GameAccountId);
                    }
                }
                return this;
            }

            public override ClientRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ClientRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is ClientRequest)
                {
                    return this.MergeFrom((ClientRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ClientRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ClientRequest._clientRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ClientRequest._clientRequestFieldTags[index];
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
                            input.ReadMessageArray<bnet.protocol.game_utilities.Attribute>(num, str, this.result.attribute_, bnet.protocol.game_utilities.Attribute.DefaultInstance, extensionRegistry);
                            continue;
                        }
                        case 0x12:
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
                        case 0x1a:
                        {
                            EntityId.Builder builder2 = EntityId.CreateBuilder();
                            if (this.result.hasBnetAccountId)
                            {
                                builder2.MergeFrom(this.BnetAccountId);
                            }
                            input.ReadMessage(builder2, extensionRegistry);
                            this.BnetAccountId = builder2.BuildPartial();
                            continue;
                        }
                        case 0x22:
                        {
                            EntityId.Builder builder3 = EntityId.CreateBuilder();
                            if (this.result.hasGameAccountId)
                            {
                                builder3.MergeFrom(this.GameAccountId);
                            }
                            input.ReadMessage(builder3, extensionRegistry);
                            this.GameAccountId = builder3.BuildPartial();
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

            public ClientRequest.Builder MergeGameAccountId(EntityId value)
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

            public ClientRequest.Builder MergeHost(ProcessId value)
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

            private ClientRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ClientRequest result = this.result;
                    this.result = new ClientRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ClientRequest.Builder SetAttribute(int index, bnet.protocol.game_utilities.Attribute value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.attribute_[index] = value;
                return this;
            }

            public ClientRequest.Builder SetAttribute(int index, bnet.protocol.game_utilities.Attribute.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.attribute_[index] = builderForValue.Build();
                return this;
            }

            public ClientRequest.Builder SetBnetAccountId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasBnetAccountId = true;
                this.result.bnetAccountId_ = value;
                return this;
            }

            public ClientRequest.Builder SetBnetAccountId(EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasBnetAccountId = true;
                this.result.bnetAccountId_ = builderForValue.Build();
                return this;
            }

            public ClientRequest.Builder SetGameAccountId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasGameAccountId = true;
                this.result.gameAccountId_ = value;
                return this;
            }

            public ClientRequest.Builder SetGameAccountId(EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasGameAccountId = true;
                this.result.gameAccountId_ = builderForValue.Build();
                return this;
            }

            public ClientRequest.Builder SetHost(ProcessId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasHost = true;
                this.result.host_ = value;
                return this;
            }

            public ClientRequest.Builder SetHost(ProcessId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasHost = true;
                this.result.host_ = builderForValue.Build();
                return this;
            }

            public int AttributeCount
            {
                get
                {
                    return this.result.AttributeCount;
                }
            }

            public IPopsicleList<bnet.protocol.game_utilities.Attribute> AttributeList
            {
                get
                {
                    return this.PrepareBuilder().attribute_;
                }
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

            public override ClientRequest DefaultInstanceForType
            {
                get
                {
                    return ClientRequest.DefaultInstance;
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

            protected override ClientRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override ClientRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

