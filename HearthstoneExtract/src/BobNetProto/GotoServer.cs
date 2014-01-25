namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class GotoServer : GeneratedMessageLite<GotoServer, Builder>
    {
        private static readonly string[] _gotoServerFieldNames = new string[] { "address", "aurora_password", "bobnet_password", "client_handle", "game_handle", "port", "version" };
        private static readonly uint[] _gotoServerFieldTags = new uint[] { 10, 0x3a, 0x20, 0x18, 0x10, 40, 50 };
        private string address_ = string.Empty;
        public const int AddressFieldNumber = 1;
        private string auroraPassword_ = string.Empty;
        public const int AuroraPasswordFieldNumber = 7;
        private int bobnetPassword_;
        public const int BobnetPasswordFieldNumber = 4;
        private long clientHandle_;
        public const int ClientHandleFieldNumber = 3;
        private static readonly GotoServer defaultInstance = new GotoServer().MakeReadOnly();
        private int gameHandle_;
        public const int GameHandleFieldNumber = 2;
        private bool hasAddress;
        private bool hasAuroraPassword;
        private bool hasBobnetPassword;
        private bool hasClientHandle;
        private bool hasGameHandle;
        private bool hasPort;
        private bool hasVersion;
        private int memoizedSerializedSize = -1;
        private int port_;
        public const int PortFieldNumber = 5;
        private string version_ = string.Empty;
        public const int VersionFieldNumber = 6;

        static GotoServer()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private GotoServer()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GotoServer prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GotoServer server = obj as GotoServer;
            if (server == null)
            {
                return false;
            }
            if ((this.hasAddress != server.hasAddress) || (this.hasAddress && !this.address_.Equals(server.address_)))
            {
                return false;
            }
            if ((this.hasGameHandle != server.hasGameHandle) || (this.hasGameHandle && !this.gameHandle_.Equals(server.gameHandle_)))
            {
                return false;
            }
            if ((this.hasClientHandle != server.hasClientHandle) || (this.hasClientHandle && !this.clientHandle_.Equals(server.clientHandle_)))
            {
                return false;
            }
            if ((this.hasBobnetPassword != server.hasBobnetPassword) || (this.hasBobnetPassword && !this.bobnetPassword_.Equals(server.bobnetPassword_)))
            {
                return false;
            }
            if ((this.hasPort != server.hasPort) || (this.hasPort && !this.port_.Equals(server.port_)))
            {
                return false;
            }
            if ((this.hasVersion != server.hasVersion) || (this.hasVersion && !this.version_.Equals(server.version_)))
            {
                return false;
            }
            return ((this.hasAuroraPassword == server.hasAuroraPassword) && (!this.hasAuroraPassword || this.auroraPassword_.Equals(server.auroraPassword_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasAddress)
            {
                hashCode ^= this.address_.GetHashCode();
            }
            if (this.hasGameHandle)
            {
                hashCode ^= this.gameHandle_.GetHashCode();
            }
            if (this.hasClientHandle)
            {
                hashCode ^= this.clientHandle_.GetHashCode();
            }
            if (this.hasBobnetPassword)
            {
                hashCode ^= this.bobnetPassword_.GetHashCode();
            }
            if (this.hasPort)
            {
                hashCode ^= this.port_.GetHashCode();
            }
            if (this.hasVersion)
            {
                hashCode ^= this.version_.GetHashCode();
            }
            if (this.hasAuroraPassword)
            {
                hashCode ^= this.auroraPassword_.GetHashCode();
            }
            return hashCode;
        }

        private GotoServer MakeReadOnly()
        {
            return this;
        }

        public static GotoServer ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GotoServer ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GotoServer ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GotoServer ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GotoServer ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GotoServer ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GotoServer ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GotoServer ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GotoServer ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GotoServer ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GotoServer, Builder>.PrintField("address", this.hasAddress, this.address_, writer);
            GeneratedMessageLite<GotoServer, Builder>.PrintField("game_handle", this.hasGameHandle, this.gameHandle_, writer);
            GeneratedMessageLite<GotoServer, Builder>.PrintField("client_handle", this.hasClientHandle, this.clientHandle_, writer);
            GeneratedMessageLite<GotoServer, Builder>.PrintField("bobnet_password", this.hasBobnetPassword, this.bobnetPassword_, writer);
            GeneratedMessageLite<GotoServer, Builder>.PrintField("port", this.hasPort, this.port_, writer);
            GeneratedMessageLite<GotoServer, Builder>.PrintField("version", this.hasVersion, this.version_, writer);
            GeneratedMessageLite<GotoServer, Builder>.PrintField("aurora_password", this.hasAuroraPassword, this.auroraPassword_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _gotoServerFieldNames;
            if (this.hasAddress)
            {
                output.WriteString(1, strArray[0], this.Address);
            }
            if (this.hasGameHandle)
            {
                output.WriteInt32(2, strArray[4], this.GameHandle);
            }
            if (this.hasClientHandle)
            {
                output.WriteInt64(3, strArray[3], this.ClientHandle);
            }
            if (this.hasBobnetPassword)
            {
                output.WriteInt32(4, strArray[2], this.BobnetPassword);
            }
            if (this.hasPort)
            {
                output.WriteInt32(5, strArray[5], this.Port);
            }
            if (this.hasVersion)
            {
                output.WriteString(6, strArray[6], this.Version);
            }
            if (this.hasAuroraPassword)
            {
                output.WriteString(7, strArray[1], this.AuroraPassword);
            }
        }

        public string Address
        {
            get
            {
                return this.address_;
            }
        }

        public string AuroraPassword
        {
            get
            {
                return this.auroraPassword_;
            }
        }

        public int BobnetPassword
        {
            get
            {
                return this.bobnetPassword_;
            }
        }

        public long ClientHandle
        {
            get
            {
                return this.clientHandle_;
            }
        }

        public static GotoServer DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GotoServer DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public int GameHandle
        {
            get
            {
                return this.gameHandle_;
            }
        }

        public bool HasAddress
        {
            get
            {
                return this.hasAddress;
            }
        }

        public bool HasAuroraPassword
        {
            get
            {
                return this.hasAuroraPassword;
            }
        }

        public bool HasBobnetPassword
        {
            get
            {
                return this.hasBobnetPassword;
            }
        }

        public bool HasClientHandle
        {
            get
            {
                return this.hasClientHandle;
            }
        }

        public bool HasGameHandle
        {
            get
            {
                return this.hasGameHandle;
            }
        }

        public bool HasPort
        {
            get
            {
                return this.hasPort;
            }
        }

        public bool HasVersion
        {
            get
            {
                return this.hasVersion;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasAddress)
                {
                    return false;
                }
                if (!this.hasGameHandle)
                {
                    return false;
                }
                if (!this.hasClientHandle)
                {
                    return false;
                }
                if (!this.hasBobnetPassword)
                {
                    return false;
                }
                if (!this.hasPort)
                {
                    return false;
                }
                if (!this.hasVersion)
                {
                    return false;
                }
                return true;
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
                    if (this.hasAddress)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(1, this.Address);
                    }
                    if (this.hasGameHandle)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.GameHandle);
                    }
                    if (this.hasClientHandle)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(3, this.ClientHandle);
                    }
                    if (this.hasBobnetPassword)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(4, this.BobnetPassword);
                    }
                    if (this.hasPort)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(5, this.Port);
                    }
                    if (this.hasVersion)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(6, this.Version);
                    }
                    if (this.hasAuroraPassword)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(7, this.AuroraPassword);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override GotoServer ThisMessage
        {
            get
            {
                return this;
            }
        }

        public string Version
        {
            get
            {
                return this.version_;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<GotoServer, GotoServer.Builder>
        {
            private GotoServer result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GotoServer.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GotoServer cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override GotoServer BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GotoServer.Builder Clear()
            {
                this.result = GotoServer.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GotoServer.Builder ClearAddress()
            {
                this.PrepareBuilder();
                this.result.hasAddress = false;
                this.result.address_ = string.Empty;
                return this;
            }

            public GotoServer.Builder ClearAuroraPassword()
            {
                this.PrepareBuilder();
                this.result.hasAuroraPassword = false;
                this.result.auroraPassword_ = string.Empty;
                return this;
            }

            public GotoServer.Builder ClearBobnetPassword()
            {
                this.PrepareBuilder();
                this.result.hasBobnetPassword = false;
                this.result.bobnetPassword_ = 0;
                return this;
            }

            public GotoServer.Builder ClearClientHandle()
            {
                this.PrepareBuilder();
                this.result.hasClientHandle = false;
                this.result.clientHandle_ = 0L;
                return this;
            }

            public GotoServer.Builder ClearGameHandle()
            {
                this.PrepareBuilder();
                this.result.hasGameHandle = false;
                this.result.gameHandle_ = 0;
                return this;
            }

            public GotoServer.Builder ClearPort()
            {
                this.PrepareBuilder();
                this.result.hasPort = false;
                this.result.port_ = 0;
                return this;
            }

            public GotoServer.Builder ClearVersion()
            {
                this.PrepareBuilder();
                this.result.hasVersion = false;
                this.result.version_ = string.Empty;
                return this;
            }

            public override GotoServer.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GotoServer.Builder(this.result);
                }
                return new GotoServer.Builder().MergeFrom(this.result);
            }

            public override GotoServer.Builder MergeFrom(GotoServer other)
            {
                if (other != GotoServer.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAddress)
                    {
                        this.Address = other.Address;
                    }
                    if (other.HasGameHandle)
                    {
                        this.GameHandle = other.GameHandle;
                    }
                    if (other.HasClientHandle)
                    {
                        this.ClientHandle = other.ClientHandle;
                    }
                    if (other.HasBobnetPassword)
                    {
                        this.BobnetPassword = other.BobnetPassword;
                    }
                    if (other.HasPort)
                    {
                        this.Port = other.Port;
                    }
                    if (other.HasVersion)
                    {
                        this.Version = other.Version;
                    }
                    if (other.HasAuroraPassword)
                    {
                        this.AuroraPassword = other.AuroraPassword;
                    }
                }
                return this;
            }

            public override GotoServer.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GotoServer.Builder MergeFrom(IMessageLite other)
            {
                if (other is GotoServer)
                {
                    return this.MergeFrom((GotoServer) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GotoServer.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GotoServer._gotoServerFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GotoServer._gotoServerFieldTags[index];
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
                            this.result.hasAddress = input.ReadString(ref this.result.address_);
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasGameHandle = input.ReadInt32(ref this.result.gameHandle_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasClientHandle = input.ReadInt64(ref this.result.clientHandle_);
                            continue;
                        }
                        case 0x20:
                        {
                            this.result.hasBobnetPassword = input.ReadInt32(ref this.result.bobnetPassword_);
                            continue;
                        }
                        case 40:
                        {
                            this.result.hasPort = input.ReadInt32(ref this.result.port_);
                            continue;
                        }
                        case 50:
                        {
                            this.result.hasVersion = input.ReadString(ref this.result.version_);
                            continue;
                        }
                        case 0x3a:
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
                    this.result.hasAuroraPassword = input.ReadString(ref this.result.auroraPassword_);
                }
                return this;
            }

            private GotoServer PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GotoServer result = this.result;
                    this.result = new GotoServer();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public GotoServer.Builder SetAddress(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasAddress = true;
                this.result.address_ = value;
                return this;
            }

            public GotoServer.Builder SetAuroraPassword(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasAuroraPassword = true;
                this.result.auroraPassword_ = value;
                return this;
            }

            public GotoServer.Builder SetBobnetPassword(int value)
            {
                this.PrepareBuilder();
                this.result.hasBobnetPassword = true;
                this.result.bobnetPassword_ = value;
                return this;
            }

            public GotoServer.Builder SetClientHandle(long value)
            {
                this.PrepareBuilder();
                this.result.hasClientHandle = true;
                this.result.clientHandle_ = value;
                return this;
            }

            public GotoServer.Builder SetGameHandle(int value)
            {
                this.PrepareBuilder();
                this.result.hasGameHandle = true;
                this.result.gameHandle_ = value;
                return this;
            }

            public GotoServer.Builder SetPort(int value)
            {
                this.PrepareBuilder();
                this.result.hasPort = true;
                this.result.port_ = value;
                return this;
            }

            public GotoServer.Builder SetVersion(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasVersion = true;
                this.result.version_ = value;
                return this;
            }

            public string Address
            {
                get
                {
                    return this.result.Address;
                }
                set
                {
                    this.SetAddress(value);
                }
            }

            public string AuroraPassword
            {
                get
                {
                    return this.result.AuroraPassword;
                }
                set
                {
                    this.SetAuroraPassword(value);
                }
            }

            public int BobnetPassword
            {
                get
                {
                    return this.result.BobnetPassword;
                }
                set
                {
                    this.SetBobnetPassword(value);
                }
            }

            public long ClientHandle
            {
                get
                {
                    return this.result.ClientHandle;
                }
                set
                {
                    this.SetClientHandle(value);
                }
            }

            public override GotoServer DefaultInstanceForType
            {
                get
                {
                    return GotoServer.DefaultInstance;
                }
            }

            public int GameHandle
            {
                get
                {
                    return this.result.GameHandle;
                }
                set
                {
                    this.SetGameHandle(value);
                }
            }

            public bool HasAddress
            {
                get
                {
                    return this.result.hasAddress;
                }
            }

            public bool HasAuroraPassword
            {
                get
                {
                    return this.result.hasAuroraPassword;
                }
            }

            public bool HasBobnetPassword
            {
                get
                {
                    return this.result.hasBobnetPassword;
                }
            }

            public bool HasClientHandle
            {
                get
                {
                    return this.result.hasClientHandle;
                }
            }

            public bool HasGameHandle
            {
                get
                {
                    return this.result.hasGameHandle;
                }
            }

            public bool HasPort
            {
                get
                {
                    return this.result.hasPort;
                }
            }

            public bool HasVersion
            {
                get
                {
                    return this.result.hasVersion;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override GotoServer MessageBeingBuilt
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

            protected override GotoServer.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public string Version
            {
                get
                {
                    return this.result.Version;
                }
                set
                {
                    this.SetVersion(value);
                }
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0x6d
            }
        }
    }
}

