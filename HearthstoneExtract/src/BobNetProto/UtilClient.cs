namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class UtilClient : GeneratedMessageLite<UtilClient, Builder>
    {
        private static readonly string[] _utilClientFieldNames = new string[] { "client_handle", "password" };
        private static readonly uint[] _utilClientFieldTags = new uint[] { 8, 0x10 };
        private int clientHandle_;
        public const int ClientHandleFieldNumber = 1;
        private static readonly UtilClient defaultInstance = new UtilClient().MakeReadOnly();
        private bool hasClientHandle;
        private bool hasPassword;
        private int memoizedSerializedSize = -1;
        private int password_;
        public const int PasswordFieldNumber = 2;

        static UtilClient()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private UtilClient()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(UtilClient prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            UtilClient client = obj as UtilClient;
            if (client == null)
            {
                return false;
            }
            if ((this.hasClientHandle != client.hasClientHandle) || (this.hasClientHandle && !this.clientHandle_.Equals(client.clientHandle_)))
            {
                return false;
            }
            return ((this.hasPassword == client.hasPassword) && (!this.hasPassword || this.password_.Equals(client.password_)));
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

        private UtilClient MakeReadOnly()
        {
            return this;
        }

        public static UtilClient ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static UtilClient ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static UtilClient ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static UtilClient ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static UtilClient ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static UtilClient ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static UtilClient ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static UtilClient ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static UtilClient ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static UtilClient ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<UtilClient, Builder>.PrintField("client_handle", this.hasClientHandle, this.clientHandle_, writer);
            GeneratedMessageLite<UtilClient, Builder>.PrintField("password", this.hasPassword, this.password_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _utilClientFieldNames;
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

        public static UtilClient DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override UtilClient DefaultInstanceForType
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

        protected override UtilClient ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<UtilClient, UtilClient.Builder>
        {
            private UtilClient result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = UtilClient.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(UtilClient cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override UtilClient BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override UtilClient.Builder Clear()
            {
                this.result = UtilClient.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public UtilClient.Builder ClearClientHandle()
            {
                this.PrepareBuilder();
                this.result.hasClientHandle = false;
                this.result.clientHandle_ = 0;
                return this;
            }

            public UtilClient.Builder ClearPassword()
            {
                this.PrepareBuilder();
                this.result.hasPassword = false;
                this.result.password_ = 0;
                return this;
            }

            public override UtilClient.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new UtilClient.Builder(this.result);
                }
                return new UtilClient.Builder().MergeFrom(this.result);
            }

            public override UtilClient.Builder MergeFrom(UtilClient other)
            {
                if (other != UtilClient.DefaultInstance)
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

            public override UtilClient.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override UtilClient.Builder MergeFrom(IMessageLite other)
            {
                if (other is UtilClient)
                {
                    return this.MergeFrom((UtilClient) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override UtilClient.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(UtilClient._utilClientFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = UtilClient._utilClientFieldTags[index];
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

            private UtilClient PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    UtilClient result = this.result;
                    this.result = new UtilClient();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public UtilClient.Builder SetClientHandle(int value)
            {
                this.PrepareBuilder();
                this.result.hasClientHandle = true;
                this.result.clientHandle_ = value;
                return this;
            }

            public UtilClient.Builder SetPassword(int value)
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

            public override UtilClient DefaultInstanceForType
            {
                get
                {
                    return UtilClient.DefaultInstance;
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

            protected override UtilClient MessageBeingBuilt
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

            protected override UtilClient.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0x98
            }
        }
    }
}

