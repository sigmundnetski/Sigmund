namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class Handshake : GeneratedMessageLite<Handshake, Builder>
    {
        private static readonly string[] _handshakeFieldNames = new string[] { "client_handle", "game_handle", "password" };
        private static readonly uint[] _handshakeFieldTags = new uint[] { 0x10, 8, 0x18 };
        private int clientHandle_;
        public const int ClientHandleFieldNumber = 2;
        private static readonly Handshake defaultInstance = new Handshake().MakeReadOnly();
        private int gameHandle_;
        public const int GameHandleFieldNumber = 1;
        private bool hasClientHandle;
        private bool hasGameHandle;
        private bool hasPassword;
        private int memoizedSerializedSize = -1;
        private int password_;
        public const int PasswordFieldNumber = 3;

        static Handshake()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private Handshake()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(Handshake prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            Handshake handshake = obj as Handshake;
            if (handshake == null)
            {
                return false;
            }
            if ((this.hasGameHandle != handshake.hasGameHandle) || (this.hasGameHandle && !this.gameHandle_.Equals(handshake.gameHandle_)))
            {
                return false;
            }
            if ((this.hasClientHandle != handshake.hasClientHandle) || (this.hasClientHandle && !this.clientHandle_.Equals(handshake.clientHandle_)))
            {
                return false;
            }
            return ((this.hasPassword == handshake.hasPassword) && (!this.hasPassword || this.password_.Equals(handshake.password_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasGameHandle)
            {
                hashCode ^= this.gameHandle_.GetHashCode();
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

        private Handshake MakeReadOnly()
        {
            return this;
        }

        public static Handshake ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static Handshake ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static Handshake ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Handshake ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Handshake ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Handshake ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Handshake ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static Handshake ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Handshake ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Handshake ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<Handshake, Builder>.PrintField("game_handle", this.hasGameHandle, this.gameHandle_, writer);
            GeneratedMessageLite<Handshake, Builder>.PrintField("client_handle", this.hasClientHandle, this.clientHandle_, writer);
            GeneratedMessageLite<Handshake, Builder>.PrintField("password", this.hasPassword, this.password_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _handshakeFieldNames;
            if (this.hasGameHandle)
            {
                output.WriteInt32(1, strArray[1], this.GameHandle);
            }
            if (this.hasClientHandle)
            {
                output.WriteInt32(2, strArray[0], this.ClientHandle);
            }
            if (this.hasPassword)
            {
                output.WriteInt32(3, strArray[2], this.Password);
            }
        }

        public int ClientHandle
        {
            get
            {
                return this.clientHandle_;
            }
        }

        public static Handshake DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override Handshake DefaultInstanceForType
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
                    if (this.hasClientHandle)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.ClientHandle);
                    }
                    if (this.hasPassword)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(3, this.Password);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override Handshake ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<Handshake, Handshake.Builder>
        {
            private Handshake result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = Handshake.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(Handshake cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override Handshake BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override Handshake.Builder Clear()
            {
                this.result = Handshake.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public Handshake.Builder ClearClientHandle()
            {
                this.PrepareBuilder();
                this.result.hasClientHandle = false;
                this.result.clientHandle_ = 0;
                return this;
            }

            public Handshake.Builder ClearGameHandle()
            {
                this.PrepareBuilder();
                this.result.hasGameHandle = false;
                this.result.gameHandle_ = 0;
                return this;
            }

            public Handshake.Builder ClearPassword()
            {
                this.PrepareBuilder();
                this.result.hasPassword = false;
                this.result.password_ = 0;
                return this;
            }

            public override Handshake.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new Handshake.Builder(this.result);
                }
                return new Handshake.Builder().MergeFrom(this.result);
            }

            public override Handshake.Builder MergeFrom(Handshake other)
            {
                if (other != Handshake.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasGameHandle)
                    {
                        this.GameHandle = other.GameHandle;
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

            public override Handshake.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override Handshake.Builder MergeFrom(IMessageLite other)
            {
                if (other is Handshake)
                {
                    return this.MergeFrom((Handshake) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override Handshake.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(Handshake._handshakeFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = Handshake._handshakeFieldTags[index];
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
                        case 0x10:
                        {
                            this.result.hasClientHandle = input.ReadInt32(ref this.result.clientHandle_);
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
                    this.result.hasPassword = input.ReadInt32(ref this.result.password_);
                }
                return this;
            }

            private Handshake PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    Handshake result = this.result;
                    this.result = new Handshake();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public Handshake.Builder SetClientHandle(int value)
            {
                this.PrepareBuilder();
                this.result.hasClientHandle = true;
                this.result.clientHandle_ = value;
                return this;
            }

            public Handshake.Builder SetGameHandle(int value)
            {
                this.PrepareBuilder();
                this.result.hasGameHandle = true;
                this.result.gameHandle_ = value;
                return this;
            }

            public Handshake.Builder SetPassword(int value)
            {
                this.PrepareBuilder();
                this.result.hasPassword = true;
                this.result.password_ = value;
                return this;
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

            public override Handshake DefaultInstanceForType
            {
                get
                {
                    return Handshake.DefaultInstance;
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

            protected override Handshake MessageBeingBuilt
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

            protected override Handshake.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0x70
            }
        }
    }
}

