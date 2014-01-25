namespace bnet.protocol.game_master
{
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class FindGameRequest : GeneratedMessageLite<FindGameRequest, Builder>
    {
        private static readonly string[] _findGameRequestFieldNames = new string[] { "factory_id", "factory_object_id", "player", "properties", "request_id" };
        private static readonly uint[] _findGameRequestFieldTags = new uint[] { 0x11, 0x20, 10, 0x1a, 0x29 };
        private static readonly FindGameRequest defaultInstance = new FindGameRequest().MakeReadOnly();
        private ulong factoryId_;
        public const int FactoryIdFieldNumber = 2;
        private ulong factoryObjectId_;
        public const int FactoryObjectIdFieldNumber = 4;
        private bool hasFactoryId;
        private bool hasFactoryObjectId;
        private bool hasProperties;
        private bool hasRequestId;
        private int memoizedSerializedSize = -1;
        private PopsicleList<Player> player_ = new PopsicleList<Player>();
        public const int PlayerFieldNumber = 1;
        private GameProperties properties_;
        public const int PropertiesFieldNumber = 3;
        private ulong requestId_;
        public const int RequestIdFieldNumber = 5;

        static FindGameRequest()
        {
            object.ReferenceEquals(GameMaster.Descriptor, null);
        }

        private FindGameRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(FindGameRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            FindGameRequest request = obj as FindGameRequest;
            if (request == null)
            {
                return false;
            }
            if (this.player_.Count != request.player_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.player_.Count; i++)
            {
                if (!this.player_[i].Equals(request.player_[i]))
                {
                    return false;
                }
            }
            if ((this.hasFactoryId != request.hasFactoryId) || (this.hasFactoryId && !this.factoryId_.Equals(request.factoryId_)))
            {
                return false;
            }
            if ((this.hasProperties != request.hasProperties) || (this.hasProperties && !this.properties_.Equals(request.properties_)))
            {
                return false;
            }
            if ((this.hasFactoryObjectId != request.hasFactoryObjectId) || (this.hasFactoryObjectId && !this.factoryObjectId_.Equals(request.factoryObjectId_)))
            {
                return false;
            }
            return ((this.hasRequestId == request.hasRequestId) && (!this.hasRequestId || this.requestId_.Equals(request.requestId_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<Player> enumerator = this.player_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    Player current = enumerator.Current;
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
            if (this.hasFactoryId)
            {
                hashCode ^= this.factoryId_.GetHashCode();
            }
            if (this.hasProperties)
            {
                hashCode ^= this.properties_.GetHashCode();
            }
            if (this.hasFactoryObjectId)
            {
                hashCode ^= this.factoryObjectId_.GetHashCode();
            }
            if (this.hasRequestId)
            {
                hashCode ^= this.requestId_.GetHashCode();
            }
            return hashCode;
        }

        public Player GetPlayer(int index)
        {
            return this.player_[index];
        }

        private FindGameRequest MakeReadOnly()
        {
            this.player_.MakeReadOnly();
            return this;
        }

        public static FindGameRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static FindGameRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static FindGameRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static FindGameRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static FindGameRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static FindGameRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static FindGameRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static FindGameRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static FindGameRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static FindGameRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<FindGameRequest, Builder>.PrintField<Player>("player", this.player_, writer);
            GeneratedMessageLite<FindGameRequest, Builder>.PrintField("factory_id", this.hasFactoryId, this.factoryId_, writer);
            GeneratedMessageLite<FindGameRequest, Builder>.PrintField("properties", this.hasProperties, this.properties_, writer);
            GeneratedMessageLite<FindGameRequest, Builder>.PrintField("factory_object_id", this.hasFactoryObjectId, this.factoryObjectId_, writer);
            GeneratedMessageLite<FindGameRequest, Builder>.PrintField("request_id", this.hasRequestId, this.requestId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _findGameRequestFieldNames;
            if (this.player_.Count > 0)
            {
                output.WriteMessageArray<Player>(1, strArray[2], this.player_);
            }
            if (this.hasFactoryId)
            {
                output.WriteFixed64(2, strArray[0], this.FactoryId);
            }
            if (this.hasProperties)
            {
                output.WriteMessage(3, strArray[3], this.Properties);
            }
            if (this.hasFactoryObjectId)
            {
                output.WriteUInt64(4, strArray[1], this.FactoryObjectId);
            }
            if (this.hasRequestId)
            {
                output.WriteFixed64(5, strArray[4], this.RequestId);
            }
        }

        public static FindGameRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override FindGameRequest DefaultInstanceForType
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

        [CLSCompliant(false)]
        public ulong FactoryObjectId
        {
            get
            {
                return this.factoryObjectId_;
            }
        }

        public bool HasFactoryId
        {
            get
            {
                return this.hasFactoryId;
            }
        }

        public bool HasFactoryObjectId
        {
            get
            {
                return this.hasFactoryObjectId;
            }
        }

        public bool HasProperties
        {
            get
            {
                return this.hasProperties;
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
                IEnumerator<Player> enumerator = this.PlayerList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        Player current = enumerator.Current;
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
                if (this.HasProperties && !this.Properties.IsInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        public int PlayerCount
        {
            get
            {
                return this.player_.Count;
            }
        }

        public IList<Player> PlayerList
        {
            get
            {
                return this.player_;
            }
        }

        public GameProperties Properties
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.properties_ != null)
                {
                    goto Label_0012;
                }
                return GameProperties.DefaultInstance;
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
                    IEnumerator<Player> enumerator = this.PlayerList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            Player current = enumerator.Current;
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
                    if (this.hasFactoryId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed64Size(2, this.FactoryId);
                    }
                    if (this.hasProperties)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(3, this.Properties);
                    }
                    if (this.hasFactoryObjectId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(4, this.FactoryObjectId);
                    }
                    if (this.hasRequestId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed64Size(5, this.RequestId);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override FindGameRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<FindGameRequest, FindGameRequest.Builder>
        {
            private FindGameRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = FindGameRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(FindGameRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public FindGameRequest.Builder AddPlayer(Player value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.player_.Add(value);
                return this;
            }

            public FindGameRequest.Builder AddPlayer(Player.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.player_.Add(builderForValue.Build());
                return this;
            }

            public FindGameRequest.Builder AddRangePlayer(IEnumerable<Player> values)
            {
                this.PrepareBuilder();
                this.result.player_.Add(values);
                return this;
            }

            public override FindGameRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override FindGameRequest.Builder Clear()
            {
                this.result = FindGameRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public FindGameRequest.Builder ClearFactoryId()
            {
                this.PrepareBuilder();
                this.result.hasFactoryId = false;
                this.result.factoryId_ = 0L;
                return this;
            }

            public FindGameRequest.Builder ClearFactoryObjectId()
            {
                this.PrepareBuilder();
                this.result.hasFactoryObjectId = false;
                this.result.factoryObjectId_ = 0L;
                return this;
            }

            public FindGameRequest.Builder ClearPlayer()
            {
                this.PrepareBuilder();
                this.result.player_.Clear();
                return this;
            }

            public FindGameRequest.Builder ClearProperties()
            {
                this.PrepareBuilder();
                this.result.hasProperties = false;
                this.result.properties_ = null;
                return this;
            }

            public FindGameRequest.Builder ClearRequestId()
            {
                this.PrepareBuilder();
                this.result.hasRequestId = false;
                this.result.requestId_ = 0L;
                return this;
            }

            public override FindGameRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new FindGameRequest.Builder(this.result);
                }
                return new FindGameRequest.Builder().MergeFrom(this.result);
            }

            public Player GetPlayer(int index)
            {
                return this.result.GetPlayer(index);
            }

            public override FindGameRequest.Builder MergeFrom(FindGameRequest other)
            {
                if (other != FindGameRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.player_.Count != 0)
                    {
                        this.result.player_.Add(other.player_);
                    }
                    if (other.HasFactoryId)
                    {
                        this.FactoryId = other.FactoryId;
                    }
                    if (other.HasProperties)
                    {
                        this.MergeProperties(other.Properties);
                    }
                    if (other.HasFactoryObjectId)
                    {
                        this.FactoryObjectId = other.FactoryObjectId;
                    }
                    if (other.HasRequestId)
                    {
                        this.RequestId = other.RequestId;
                    }
                }
                return this;
            }

            public override FindGameRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override FindGameRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is FindGameRequest)
                {
                    return this.MergeFrom((FindGameRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override FindGameRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(FindGameRequest._findGameRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = FindGameRequest._findGameRequestFieldTags[index];
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
                            input.ReadMessageArray<Player>(num, str, this.result.player_, Player.DefaultInstance, extensionRegistry);
                            continue;
                        }
                        case 0x11:
                        {
                            this.result.hasFactoryId = input.ReadFixed64(ref this.result.factoryId_);
                            continue;
                        }
                        case 0x1a:
                        {
                            GameProperties.Builder builder = GameProperties.CreateBuilder();
                            if (this.result.hasProperties)
                            {
                                builder.MergeFrom(this.Properties);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.Properties = builder.BuildPartial();
                            continue;
                        }
                        case 0x20:
                        {
                            this.result.hasFactoryObjectId = input.ReadUInt64(ref this.result.factoryObjectId_);
                            continue;
                        }
                        case 0x29:
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
                    this.result.hasRequestId = input.ReadFixed64(ref this.result.requestId_);
                }
                return this;
            }

            public FindGameRequest.Builder MergeProperties(GameProperties value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasProperties && (this.result.properties_ != GameProperties.DefaultInstance))
                {
                    this.result.properties_ = GameProperties.CreateBuilder(this.result.properties_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.properties_ = value;
                }
                this.result.hasProperties = true;
                return this;
            }

            private FindGameRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    FindGameRequest result = this.result;
                    this.result = new FindGameRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public FindGameRequest.Builder SetFactoryId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasFactoryId = true;
                this.result.factoryId_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public FindGameRequest.Builder SetFactoryObjectId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasFactoryObjectId = true;
                this.result.factoryObjectId_ = value;
                return this;
            }

            public FindGameRequest.Builder SetPlayer(int index, Player value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.player_[index] = value;
                return this;
            }

            public FindGameRequest.Builder SetPlayer(int index, Player.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.player_[index] = builderForValue.Build();
                return this;
            }

            public FindGameRequest.Builder SetProperties(GameProperties value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasProperties = true;
                this.result.properties_ = value;
                return this;
            }

            public FindGameRequest.Builder SetProperties(GameProperties.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasProperties = true;
                this.result.properties_ = builderForValue.Build();
                return this;
            }

            [CLSCompliant(false)]
            public FindGameRequest.Builder SetRequestId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasRequestId = true;
                this.result.requestId_ = value;
                return this;
            }

            public override FindGameRequest DefaultInstanceForType
            {
                get
                {
                    return FindGameRequest.DefaultInstance;
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

            [CLSCompliant(false)]
            public ulong FactoryObjectId
            {
                get
                {
                    return this.result.FactoryObjectId;
                }
                set
                {
                    this.SetFactoryObjectId(value);
                }
            }

            public bool HasFactoryId
            {
                get
                {
                    return this.result.hasFactoryId;
                }
            }

            public bool HasFactoryObjectId
            {
                get
                {
                    return this.result.hasFactoryObjectId;
                }
            }

            public bool HasProperties
            {
                get
                {
                    return this.result.hasProperties;
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

            protected override FindGameRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int PlayerCount
            {
                get
                {
                    return this.result.PlayerCount;
                }
            }

            public IPopsicleList<Player> PlayerList
            {
                get
                {
                    return this.PrepareBuilder().player_;
                }
            }

            public GameProperties Properties
            {
                get
                {
                    return this.result.Properties;
                }
                set
                {
                    this.SetProperties(value);
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

            protected override FindGameRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

