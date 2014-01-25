namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class GotoUtil : GeneratedMessageLite<GotoUtil, Builder>
    {
        private static readonly string[] _gotoUtilFieldNames = new string[] { "address", "client_handle", "password", "port" };
        private static readonly uint[] _gotoUtilFieldTags = new uint[] { 10, 0x18, 0x20, 0x10 };
        private string address_ = string.Empty;
        public const int AddressFieldNumber = 1;
        private int clientHandle_;
        public const int ClientHandleFieldNumber = 3;
        private static readonly GotoUtil defaultInstance = new GotoUtil().MakeReadOnly();
        private bool hasAddress;
        private bool hasClientHandle;
        private bool hasPassword;
        private bool hasPort;
        private int memoizedSerializedSize = -1;
        private int password_;
        public const int PasswordFieldNumber = 4;
        private int port_;
        public const int PortFieldNumber = 2;

        static GotoUtil()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private GotoUtil()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GotoUtil prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GotoUtil util = obj as GotoUtil;
            if (util == null)
            {
                return false;
            }
            if ((this.hasAddress != util.hasAddress) || (this.hasAddress && !this.address_.Equals(util.address_)))
            {
                return false;
            }
            if ((this.hasPort != util.hasPort) || (this.hasPort && !this.port_.Equals(util.port_)))
            {
                return false;
            }
            if ((this.hasClientHandle != util.hasClientHandle) || (this.hasClientHandle && !this.clientHandle_.Equals(util.clientHandle_)))
            {
                return false;
            }
            return ((this.hasPassword == util.hasPassword) && (!this.hasPassword || this.password_.Equals(util.password_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasAddress)
            {
                hashCode ^= this.address_.GetHashCode();
            }
            if (this.hasPort)
            {
                hashCode ^= this.port_.GetHashCode();
            }
            if (this.hasClientHandle)
            {
                hashCode ^= this.clientHandle_.GetHashCode();
            }
            if (this.hasPassword)
            {
                hashCode ^= this.password_.GetHashCode();
            }
            return hashCode;
        }

        private GotoUtil MakeReadOnly()
        {
            return this;
        }

        public static GotoUtil ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GotoUtil ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GotoUtil ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GotoUtil ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GotoUtil ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GotoUtil ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GotoUtil ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GotoUtil ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GotoUtil ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GotoUtil ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GotoUtil, Builder>.PrintField("address", this.hasAddress, this.address_, writer);
            GeneratedMessageLite<GotoUtil, Builder>.PrintField("port", this.hasPort, this.port_, writer);
            GeneratedMessageLite<GotoUtil, Builder>.PrintField("client_handle", this.hasClientHandle, this.clientHandle_, writer);
            GeneratedMessageLite<GotoUtil, Builder>.PrintField("password", this.hasPassword, this.password_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _gotoUtilFieldNames;
            if (this.hasAddress)
            {
                output.WriteString(1, strArray[0], this.Address);
            }
            if (this.hasPort)
            {
                output.WriteInt32(2, strArray[3], this.Port);
            }
            if (this.hasClientHandle)
            {
                output.WriteInt32(3, strArray[1], this.ClientHandle);
            }
            if (this.hasPassword)
            {
                output.WriteInt32(4, strArray[2], this.Password);
            }
        }

        public string Address
        {
            get
            {
                return this.address_;
            }
        }

        public int ClientHandle
        {
            get
            {
                return this.clientHandle_;
            }
        }

        public static GotoUtil DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GotoUtil DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasAddress
        {
            get
            {
                return this.hasAddress;
            }
        }

        public bool HasClientHandle
        {
            get
            {
                return this.hasClientHandle;
            }
        }

        public bool HasPassword
        {
            get
            {
                return this.hasPassword;
            }
        }

        public bool HasPort
        {
            get
            {
                return this.hasPort;
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
                if (!this.hasPort)
                {
                    return false;
                }
                if (!this.hasClientHandle)
                {
                    return false;
                }
                if (!this.hasPassword)
                {
                    return false;
                }
                return true;
            }
        }

        public int Password
        {
            get
            {
                return this.password_;
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
                    if (this.hasPort)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.Port);
                    }
                    if (this.hasClientHandle)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(3, this.ClientHandle);
                    }
                    if (this.hasPassword)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(4, this.Password);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override GotoUtil ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<GotoUtil, GotoUtil.Builder>
        {
            private GotoUtil result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GotoUtil.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GotoUtil cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override GotoUtil BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GotoUtil.Builder Clear()
            {
                this.result = GotoUtil.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GotoUtil.Builder ClearAddress()
            {
                this.PrepareBuilder();
                this.result.hasAddress = false;
                this.result.address_ = string.Empty;
                return this;
            }

            public GotoUtil.Builder ClearClientHandle()
            {
                this.PrepareBuilder();
                this.result.hasClientHandle = false;
                this.result.clientHandle_ = 0;
                return this;
            }

            public GotoUtil.Builder ClearPassword()
            {
                this.PrepareBuilder();
                this.result.hasPassword = false;
                this.result.password_ = 0;
                return this;
            }

            public GotoUtil.Builder ClearPort()
            {
                this.PrepareBuilder();
                this.result.hasPort = false;
                this.result.port_ = 0;
                return this;
            }

            public override GotoUtil.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GotoUtil.Builder(this.result);
                }
                return new GotoUtil.Builder().MergeFrom(this.result);
            }

            public override GotoUtil.Builder MergeFrom(GotoUtil other)
            {
                if (other != GotoUtil.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAddress)
                    {
                        this.Address = other.Address;
                    }
                    if (other.HasPort)
                    {
                        this.Port = other.Port;
                    }
                    if (other.HasClientHandle)
                    {
                        this.ClientHandle = other.ClientHandle;
                    }
                    if (other.HasPassword)
                    {
                        this.Password = other.Password;
                    }
                }
                return this;
            }

            public override GotoUtil.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GotoUtil.Builder MergeFrom(IMessageLite other)
            {
                if (other is GotoUtil)
                {
                    return this.MergeFrom((GotoUtil) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GotoUtil.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GotoUtil._gotoUtilFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GotoUtil._gotoUtilFieldTags[index];
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
                            this.result.hasPort = input.ReadInt32(ref this.result.port_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasClientHandle = input.ReadInt32(ref this.result.clientHandle_);
                            continue;
                        }
                        case 0x20:
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
                    this.result.hasPassword = input.ReadInt32(ref this.result.password_);
                }
                return this;
            }

            private GotoUtil PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GotoUtil result = this.result;
                    this.result = new GotoUtil();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public GotoUtil.Builder SetAddress(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasAddress = true;
                this.result.address_ = value;
                return this;
            }

            public GotoUtil.Builder SetClientHandle(int value)
            {
                this.PrepareBuilder();
                this.result.hasClientHandle = true;
                this.result.clientHandle_ = value;
                return this;
            }

            public GotoUtil.Builder SetPassword(int value)
            {
                this.PrepareBuilder();
                this.result.hasPassword = true;
                this.result.password_ = value;
                return this;
            }

            public GotoUtil.Builder SetPort(int value)
            {
                this.PrepareBuilder();
                this.result.hasPort = true;
                this.result.port_ = value;
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

            public int ClientHandle
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

            public override GotoUtil DefaultInstanceForType
            {
                get
                {
                    return GotoUtil.DefaultInstance;
                }
            }

            public bool HasAddress
            {
                get
                {
                    return this.result.hasAddress;
                }
            }

            public bool HasClientHandle
            {
                get
                {
                    return this.result.hasClientHandle;
                }
            }

            public bool HasPassword
            {
                get
                {
                    return this.result.hasPassword;
                }
            }

            public bool HasPort
            {
                get
                {
                    return this.result.hasPort;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override GotoUtil MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int Password
            {
                get
                {
                    return this.result.Password;
                }
                set
                {
                    this.SetPassword(value);
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

            protected override GotoUtil.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0x97
            }
        }
    }
}

