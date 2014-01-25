namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class UtilHandshake : GeneratedMessageLite<UtilHandshake, Builder>
    {
        private static readonly string[] _utilHandshakeFieldNames = new string[] { "client_handle", "password" };
        private static readonly uint[] _utilHandshakeFieldTags = new uint[] { 8, 0x10 };
        private int clientHandle_;
        public const int ClientHandleFieldNumber = 1;
        private static readonly UtilHandshake defaultInstance = new UtilHandshake().MakeReadOnly();
        private bool hasClientHandle;
        private bool hasPassword;
        private int memoizedSerializedSize = -1;
        private int password_;
        public const int PasswordFieldNumber = 2;

        static UtilHandshake()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private UtilHandshake()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(UtilHandshake prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            UtilHandshake handshake = obj as UtilHandshake;
            if (handshake == null)
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

        private UtilHandshake MakeReadOnly()
        {
            return this;
        }

        public static UtilHandshake ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static UtilHandshake ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static UtilHandshake ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static UtilHandshake ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static UtilHandshake ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static UtilHandshake ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static UtilHandshake ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static UtilHandshake ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static UtilHandshake ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static UtilHandshake ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<UtilHandshake, Builder>.PrintField("client_handle", this.hasClientHandle, this.clientHandle_, writer);
            GeneratedMessageLite<UtilHandshake, Builder>.PrintField("password", this.hasPassword, this.password_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _utilHandshakeFieldNames;
            if (this.hasClientHandle)
            {
                output.WriteInt32(1, strArray[0], this.ClientHandle);
            }
            if (this.hasPassword)
            {
                output.WriteInt32(2, strArray[1], this.Password);
            }
        }

        public int ClientHandle
        {
            get
            {
                return this.clientHandle_;
            }
        }

        public static UtilHandshake DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override UtilHandshake DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
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

        public override bool IsInitialized
        {
            get
            {
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
                    if (this.hasClientHandle)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.ClientHandle);
                    }
                    if (this.hasPassword)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.Password);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override UtilHandshake ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<UtilHandshake, UtilHandshake.Builder>
        {
            private UtilHandshake result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = UtilHandshake.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(UtilHandshake cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override UtilHandshake BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override UtilHandshake.Builder Clear()
            {
                this.result = UtilHandshake.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public UtilHandshake.Builder ClearClientHandle()
            {
                this.PrepareBuilder();
                this.result.hasClientHandle = false;
                this.result.clientHandle_ = 0;
                return this;
            }

            public UtilHandshake.Builder ClearPassword()
            {
                this.PrepareBuilder();
                this.result.hasPassword = false;
                this.result.password_ = 0;
                return this;
            }

            public override UtilHandshake.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new UtilHandshake.Builder(this.result);
                }
                return new UtilHandshake.Builder().MergeFrom(this.result);
            }

            public override UtilHandshake.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override UtilHandshake.Builder MergeFrom(IMessageLite other)
            {
                if (other is UtilHandshake)
                {
                    return this.MergeFrom((UtilHandshake) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override UtilHandshake.Builder MergeFrom(UtilHandshake other)
            {
                if (other != UtilHandshake.DefaultInstance)
                {
                    this.PrepareBuilder();
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

            public override UtilHandshake.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(UtilHandshake._utilHandshakeFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = UtilHandshake._utilHandshakeFieldTags[index];
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
                            this.result.hasClientHandle = input.ReadInt32(ref this.result.clientHandle_);
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
                    this.result.hasPassword = input.ReadInt32(ref this.result.password_);
                }
                return this;
            }

            private UtilHandshake PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    UtilHandshake result = this.result;
                    this.result = new UtilHandshake();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public UtilHandshake.Builder SetClientHandle(int value)
            {
                this.PrepareBuilder();
                this.result.hasClientHandle = true;
                this.result.clientHandle_ = value;
                return this;
            }

            public UtilHandshake.Builder SetPassword(int value)
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

            public override UtilHandshake DefaultInstanceForType
            {
                get
                {
                    return UtilHandshake.DefaultInstance;
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

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override UtilHandshake MessageBeingBuilt
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

            protected override UtilHandshake.Builder ThisBuilder
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
                ID = 0xcb
            }
        }
    }
}

