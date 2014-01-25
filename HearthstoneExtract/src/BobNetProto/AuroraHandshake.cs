namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class AuroraHandshake : GeneratedMessageLite<AuroraHandshake, Builder>
    {
        private static readonly string[] _auroraHandshakeFieldNames = new string[] { "client_handle", "game_handle", "password" };
        private static readonly uint[] _auroraHandshakeFieldTags = new uint[] { 0x18, 8, 0x12 };
        private long clientHandle_;
        public const int ClientHandleFieldNumber = 3;
        private static readonly AuroraHandshake defaultInstance = new AuroraHandshake().MakeReadOnly();
        private int gameHandle_;
        public const int GameHandleFieldNumber = 1;
        private bool hasClientHandle;
        private bool hasGameHandle;
        private bool hasPassword;
        private int memoizedSerializedSize = -1;
        private string password_ = string.Empty;
        public const int PasswordFieldNumber = 2;

        static AuroraHandshake()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private AuroraHandshake()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AuroraHandshake prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AuroraHandshake handshake = obj as AuroraHandshake;
            if (handshake == null)
            {
                return false;
            }
            if ((this.hasGameHandle != handshake.hasGameHandle) || (this.hasGameHandle && !this.gameHandle_.Equals(handshake.gameHandle_)))
            {
                return false;
            }
            if ((this.hasPassword != handshake.hasPassword) || (this.hasPassword && !this.password_.Equals(handshake.password_)))
            {
                return false;
            }
            return ((this.hasClientHandle == handshake.hasClientHandle) && (!this.hasClientHandle || this.clientHandle_.Equals(handshake.clientHandle_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasGameHandle)
            {
                hashCode ^= this.gameHandle_.GetHashCode();
            }
            if (this.hasPassword)
            {
                hashCode ^= this.password_.GetHashCode();
            }
            if (this.hasClientHandle)
            {
                hashCode ^= this.clientHandle_.GetHashCode();
            }
            return hashCode;
        }

        private AuroraHandshake MakeReadOnly()
        {
            return this;
        }

        public static AuroraHandshake ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AuroraHandshake ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AuroraHandshake ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AuroraHandshake ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AuroraHandshake ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AuroraHandshake ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AuroraHandshake ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AuroraHandshake ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AuroraHandshake ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AuroraHandshake ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AuroraHandshake, Builder>.PrintField("game_handle", this.hasGameHandle, this.gameHandle_, writer);
            GeneratedMessageLite<AuroraHandshake, Builder>.PrintField("password", this.hasPassword, this.password_, writer);
            GeneratedMessageLite<AuroraHandshake, Builder>.PrintField("client_handle", this.hasClientHandle, this.clientHandle_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _auroraHandshakeFieldNames;
            if (this.hasGameHandle)
            {
                output.WriteInt32(1, strArray[1], this.GameHandle);
            }
            if (this.hasPassword)
            {
                output.WriteString(2, strArray[2], this.Password);
            }
            if (this.hasClientHandle)
            {
                output.WriteInt64(3, strArray[0], this.ClientHandle);
            }
        }

        public long ClientHandle
        {
            get
            {
                return this.clientHandle_;
            }
        }

        public static AuroraHandshake DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AuroraHandshake DefaultInstanceForType
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

        public bool HasPassword
        {
            get
            {
                return this.hasPassword;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasGameHandle)
                {
                    return false;
                }
                if (!this.hasPassword)
                {
                    return false;
                }
                if (!this.hasClientHandle)
                {
                    return false;
                }
                return true;
            }
        }

        public string Password
        {
            get
            {
                return this.password_;
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
                    if (this.hasGameHandle)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.GameHandle);
                    }
                    if (this.hasPassword)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(2, this.Password);
                    }
                    if (this.hasClientHandle)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(3, this.ClientHandle);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override AuroraHandshake ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<AuroraHandshake, AuroraHandshake.Builder>
        {
            private AuroraHandshake result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AuroraHandshake.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AuroraHandshake cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override AuroraHandshake BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AuroraHandshake.Builder Clear()
            {
                this.result = AuroraHandshake.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AuroraHandshake.Builder ClearClientHandle()
            {
                this.PrepareBuilder();
                this.result.hasClientHandle = false;
                this.result.clientHandle_ = 0L;
                return this;
            }

            public AuroraHandshake.Builder ClearGameHandle()
            {
                this.PrepareBuilder();
                this.result.hasGameHandle = false;
                this.result.gameHandle_ = 0;
                return this;
            }

            public AuroraHandshake.Builder ClearPassword()
            {
                this.PrepareBuilder();
                this.result.hasPassword = false;
                this.result.password_ = string.Empty;
                return this;
            }

            public override AuroraHandshake.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AuroraHandshake.Builder(this.result);
                }
                return new AuroraHandshake.Builder().MergeFrom(this.result);
            }

            public override AuroraHandshake.Builder MergeFrom(AuroraHandshake other)
            {
                if (other != AuroraHandshake.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasGameHandle)
                    {
                        this.GameHandle = other.GameHandle;
                    }
                    if (other.HasPassword)
                    {
                        this.Password = other.Password;
                    }
                    if (other.HasClientHandle)
                    {
                        this.ClientHandle = other.ClientHandle;
                    }
                }
                return this;
            }

            public override AuroraHandshake.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AuroraHandshake.Builder MergeFrom(IMessageLite other)
            {
                if (other is AuroraHandshake)
                {
                    return this.MergeFrom((AuroraHandshake) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AuroraHandshake.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AuroraHandshake._auroraHandshakeFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AuroraHandshake._auroraHandshakeFieldTags[index];
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

                        case 8:
                        {
                            this.result.hasGameHandle = input.ReadInt32(ref this.result.gameHandle_);
                            continue;
                        }
                        case 0x12:
                        {
                            this.result.hasPassword = input.ReadString(ref this.result.password_);
                            continue;
                        }
                        case 0x18:
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
                    this.result.hasClientHandle = input.ReadInt64(ref this.result.clientHandle_);
                }
                return this;
            }

            private AuroraHandshake PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AuroraHandshake result = this.result;
                    this.result = new AuroraHandshake();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public AuroraHandshake.Builder SetClientHandle(long value)
            {
                this.PrepareBuilder();
                this.result.hasClientHandle = true;
                this.result.clientHandle_ = value;
                return this;
            }

            public AuroraHandshake.Builder SetGameHandle(int value)
            {
                this.PrepareBuilder();
                this.result.hasGameHandle = true;
                this.result.gameHandle_ = value;
                return this;
            }

            public AuroraHandshake.Builder SetPassword(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasPassword = true;
                this.result.password_ = value;
                return this;
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

            public override AuroraHandshake DefaultInstanceForType
            {
                get
                {
                    return AuroraHandshake.DefaultInstance;
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

            public bool HasPassword
            {
                get
                {
                    return this.result.hasPassword;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override AuroraHandshake MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public string Password
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

            protected override AuroraHandshake.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0xa8
            }
        }
    }
}

