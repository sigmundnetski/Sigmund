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

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class ConnectInfo : GeneratedMessageLite<ConnectInfo, Builder>
    {
        private static readonly string[] _connectInfoFieldNames = new string[] { "attribute", "host", "member_id", "port", "token" };
        private static readonly uint[] _connectInfoFieldTags = new uint[] { 0x2a, 0x12, 10, 0x18, 0x22 };
        private PopsicleList<bnet.protocol.game_master.Attribute> attribute_ = new PopsicleList<bnet.protocol.game_master.Attribute>();
        public const int AttributeFieldNumber = 5;
        private static readonly ConnectInfo defaultInstance = new ConnectInfo().MakeReadOnly();
        private bool hasHost;
        private bool hasMemberId;
        private bool hasPort;
        private bool hasToken;
        private string host_ = string.Empty;
        public const int HostFieldNumber = 2;
        private EntityId memberId_;
        public const int MemberIdFieldNumber = 1;
        private int memoizedSerializedSize = -1;
        private int port_;
        public const int PortFieldNumber = 3;
        private ByteString token_ = ByteString.Empty;
        public const int TokenFieldNumber = 4;

        static ConnectInfo()
        {
            object.ReferenceEquals(GameMaster.Descriptor, null);
        }

        private ConnectInfo()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ConnectInfo prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ConnectInfo info = obj as ConnectInfo;
            if (info == null)
            {
                return false;
            }
            if ((this.hasMemberId != info.hasMemberId) || (this.hasMemberId && !this.memberId_.Equals(info.memberId_)))
            {
                return false;
            }
            if ((this.hasHost != info.hasHost) || (this.hasHost && !this.host_.Equals(info.host_)))
            {
                return false;
            }
            if ((this.hasPort != info.hasPort) || (this.hasPort && !this.port_.Equals(info.port_)))
            {
                return false;
            }
            if ((this.hasToken != info.hasToken) || (this.hasToken && !this.token_.Equals(info.token_)))
            {
                return false;
            }
            if (this.attribute_.Count != info.attribute_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.attribute_.Count; i++)
            {
                if (!this.attribute_[i].Equals(info.attribute_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public bnet.protocol.game_master.Attribute GetAttribute(int index)
        {
            return this.attribute_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasMemberId)
            {
                hashCode ^= this.memberId_.GetHashCode();
            }
            if (this.hasHost)
            {
                hashCode ^= this.host_.GetHashCode();
            }
            if (this.hasPort)
            {
                hashCode ^= this.port_.GetHashCode();
            }
            if (this.hasToken)
            {
                hashCode ^= this.token_.GetHashCode();
            }
            IEnumerator<bnet.protocol.game_master.Attribute> enumerator = this.attribute_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    bnet.protocol.game_master.Attribute current = enumerator.Current;
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
            return hashCode;
        }

        private ConnectInfo MakeReadOnly()
        {
            this.attribute_.MakeReadOnly();
            return this;
        }

        public static ConnectInfo ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ConnectInfo ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ConnectInfo ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ConnectInfo ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ConnectInfo ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ConnectInfo ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ConnectInfo ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ConnectInfo ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ConnectInfo ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ConnectInfo ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ConnectInfo, Builder>.PrintField("member_id", this.hasMemberId, this.memberId_, writer);
            GeneratedMessageLite<ConnectInfo, Builder>.PrintField("host", this.hasHost, this.host_, writer);
            GeneratedMessageLite<ConnectInfo, Builder>.PrintField("port", this.hasPort, this.port_, writer);
            GeneratedMessageLite<ConnectInfo, Builder>.PrintField("token", this.hasToken, this.token_, writer);
            GeneratedMessageLite<ConnectInfo, Builder>.PrintField<bnet.protocol.game_master.Attribute>("attribute", this.attribute_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _connectInfoFieldNames;
            if (this.hasMemberId)
            {
                output.WriteMessage(1, strArray[2], this.MemberId);
            }
            if (this.hasHost)
            {
                output.WriteString(2, strArray[1], this.Host);
            }
            if (this.hasPort)
            {
                output.WriteInt32(3, strArray[3], this.Port);
            }
            if (this.hasToken)
            {
                output.WriteBytes(4, strArray[4], this.Token);
            }
            if (this.attribute_.Count > 0)
            {
                output.WriteMessageArray<bnet.protocol.game_master.Attribute>(5, strArray[0], this.attribute_);
            }
        }

        public int AttributeCount
        {
            get
            {
                return this.attribute_.Count;
            }
        }

        public IList<bnet.protocol.game_master.Attribute> AttributeList
        {
            get
            {
                return this.attribute_;
            }
        }

        public static ConnectInfo DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ConnectInfo DefaultInstanceForType
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

        public bool HasMemberId
        {
            get
            {
                return this.hasMemberId;
            }
        }

        public bool HasPort
        {
            get
            {
                return this.hasPort;
            }
        }

        public bool HasToken
        {
            get
            {
                return this.hasToken;
            }
        }

        public string Host
        {
            get
            {
                return this.host_;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasMemberId)
                {
                    return false;
                }
                if (!this.hasHost)
                {
                    return false;
                }
                if (!this.hasPort)
                {
                    return false;
                }
                if (!this.MemberId.IsInitialized)
                {
                    return false;
                }
                IEnumerator<bnet.protocol.game_master.Attribute> enumerator = this.AttributeList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        bnet.protocol.game_master.Attribute current = enumerator.Current;
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
                return true;
            }
        }

        public EntityId MemberId
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.memberId_ != null)
                {
                    goto Label_0012;
                }
                return EntityId.DefaultInstance;
            }
        }

        public int Port
        {
            get
            {
                return this.port_;
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
                    if (this.hasMemberId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.MemberId);
                    }
                    if (this.hasHost)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(2, this.Host);
                    }
                    if (this.hasPort)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(3, this.Port);
                    }
                    if (this.hasToken)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBytesSize(4, this.Token);
                    }
                    IEnumerator<bnet.protocol.game_master.Attribute> enumerator = this.AttributeList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            bnet.protocol.game_master.Attribute current = enumerator.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(5, current);
                        }
                    }
                    finally
                    {
                        if (enumerator == null)
                        {
                        }
                        enumerator.Dispose();
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ConnectInfo ThisMessage
        {
            get
            {
                return this;
            }
        }

        public ByteString Token
        {
            get
            {
                return this.token_;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<ConnectInfo, ConnectInfo.Builder>
        {
            private ConnectInfo result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ConnectInfo.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ConnectInfo cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public ConnectInfo.Builder AddAttribute(bnet.protocol.game_master.Attribute value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.attribute_.Add(value);
                return this;
            }

            public ConnectInfo.Builder AddAttribute(bnet.protocol.game_master.Attribute.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.attribute_.Add(builderForValue.Build());
                return this;
            }

            public ConnectInfo.Builder AddRangeAttribute(IEnumerable<bnet.protocol.game_master.Attribute> values)
            {
                this.PrepareBuilder();
                this.result.attribute_.Add(values);
                return this;
            }

            public override ConnectInfo BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ConnectInfo.Builder Clear()
            {
                this.result = ConnectInfo.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ConnectInfo.Builder ClearAttribute()
            {
                this.PrepareBuilder();
                this.result.attribute_.Clear();
                return this;
            }

            public ConnectInfo.Builder ClearHost()
            {
                this.PrepareBuilder();
                this.result.hasHost = false;
                this.result.host_ = string.Empty;
                return this;
            }

            public ConnectInfo.Builder ClearMemberId()
            {
                this.PrepareBuilder();
                this.result.hasMemberId = false;
                this.result.memberId_ = null;
                return this;
            }

            public ConnectInfo.Builder ClearPort()
            {
                this.PrepareBuilder();
                this.result.hasPort = false;
                this.result.port_ = 0;
                return this;
            }

            public ConnectInfo.Builder ClearToken()
            {
                this.PrepareBuilder();
                this.result.hasToken = false;
                this.result.token_ = ByteString.Empty;
                return this;
            }

            public override ConnectInfo.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ConnectInfo.Builder(this.result);
                }
                return new ConnectInfo.Builder().MergeFrom(this.result);
            }

            public bnet.protocol.game_master.Attribute GetAttribute(int index)
            {
                return this.result.GetAttribute(index);
            }

            public override ConnectInfo.Builder MergeFrom(ConnectInfo other)
            {
                if (other != ConnectInfo.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasMemberId)
                    {
                        this.MergeMemberId(other.MemberId);
                    }
                    if (other.HasHost)
                    {
                        this.Host = other.Host;
                    }
                    if (other.HasPort)
                    {
                        this.Port = other.Port;
                    }
                    if (other.HasToken)
                    {
                        this.Token = other.Token;
                    }
                    if (other.attribute_.Count != 0)
                    {
                        this.result.attribute_.Add(other.attribute_);
                    }
                }
                return this;
            }

            public override ConnectInfo.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ConnectInfo.Builder MergeFrom(IMessageLite other)
            {
                if (other is ConnectInfo)
                {
                    return this.MergeFrom((ConnectInfo) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ConnectInfo.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ConnectInfo._connectInfoFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ConnectInfo._connectInfoFieldTags[index];
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
                            if (this.result.hasMemberId)
                            {
                                builder.MergeFrom(this.MemberId);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.MemberId = builder.BuildPartial();
                            continue;
                        }
                        case 0x12:
                        {
                            this.result.hasHost = input.ReadString(ref this.result.host_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasPort = input.ReadInt32(ref this.result.port_);
                            continue;
                        }
                        case 0x22:
                        {
                            this.result.hasToken = input.ReadBytes(ref this.result.token_);
                            continue;
                        }
                        case 0x2a:
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
                    input.ReadMessageArray<bnet.protocol.game_master.Attribute>(num, str, this.result.attribute_, bnet.protocol.game_master.Attribute.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            public ConnectInfo.Builder MergeMemberId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasMemberId && (this.result.memberId_ != EntityId.DefaultInstance))
                {
                    this.result.memberId_ = EntityId.CreateBuilder(this.result.memberId_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.memberId_ = value;
                }
                this.result.hasMemberId = true;
                return this;
            }

            private ConnectInfo PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ConnectInfo result = this.result;
                    this.result = new ConnectInfo();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ConnectInfo.Builder SetAttribute(int index, bnet.protocol.game_master.Attribute value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.attribute_[index] = value;
                return this;
            }

            public ConnectInfo.Builder SetAttribute(int index, bnet.protocol.game_master.Attribute.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.attribute_[index] = builderForValue.Build();
                return this;
            }

            public ConnectInfo.Builder SetHost(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasHost = true;
                this.result.host_ = value;
                return this;
            }

            public ConnectInfo.Builder SetMemberId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasMemberId = true;
                this.result.memberId_ = value;
                return this;
            }

            public ConnectInfo.Builder SetMemberId(EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasMemberId = true;
                this.result.memberId_ = builderForValue.Build();
                return this;
            }

            public ConnectInfo.Builder SetPort(int value)
            {
                this.PrepareBuilder();
                this.result.hasPort = true;
                this.result.port_ = value;
                return this;
            }

            public ConnectInfo.Builder SetToken(ByteString value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasToken = true;
                this.result.token_ = value;
                return this;
            }

            public int AttributeCount
            {
                get
                {
                    return this.result.AttributeCount;
                }
            }

            public IPopsicleList<bnet.protocol.game_master.Attribute> AttributeList
            {
                get
                {
                    return this.PrepareBuilder().attribute_;
                }
            }

            public override ConnectInfo DefaultInstanceForType
            {
                get
                {
                    return ConnectInfo.DefaultInstance;
                }
            }

            public bool HasHost
            {
                get
                {
                    return this.result.hasHost;
                }
            }

            public bool HasMemberId
            {
                get
                {
                    return this.result.hasMemberId;
                }
            }

            public bool HasPort
            {
                get
                {
                    return this.result.hasPort;
                }
            }

            public bool HasToken
            {
                get
                {
                    return this.result.hasToken;
                }
            }

            public string Host
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

            public EntityId MemberId
            {
                get
                {
                    return this.result.MemberId;
                }
                set
                {
                    this.SetMemberId(value);
                }
            }

            protected override ConnectInfo MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int Port
            {
                get
                {
                    return this.result.Port;
                }
                set
                {
                    this.SetPort(value);
                }
            }

            protected override ConnectInfo.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public ByteString Token
            {
                get
                {
                    return this.result.Token;
                }
                set
                {
                    this.SetToken(value);
                }
            }
        }
    }
}

