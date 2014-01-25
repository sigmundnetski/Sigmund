namespace PegasusGame
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class ClientPacket : GeneratedMessageLite<ClientPacket, Builder>
    {
        private static readonly string[] _clientPacketFieldNames = new string[] { "packet" };
        private static readonly uint[] _clientPacketFieldTags = new uint[] { 10 };
        private static readonly ClientPacket defaultInstance = new ClientPacket().MakeReadOnly();
        private bool hasPacket;
        private int memoizedSerializedSize = -1;
        private ByteString packet_ = ByteString.Empty;
        public const int PacketFieldNumber = 1;

        static ClientPacket()
        {
            object.ReferenceEquals(PegasusGamelite.Descriptor, null);
        }

        private ClientPacket()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ClientPacket prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ClientPacket packet = obj as ClientPacket;
            if (packet == null)
            {
                return false;
            }
            return ((this.hasPacket == packet.hasPacket) && (!this.hasPacket || this.packet_.Equals(packet.packet_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasPacket)
            {
                hashCode ^= this.packet_.GetHashCode();
            }
            return hashCode;
        }

        private ClientPacket MakeReadOnly()
        {
            return this;
        }

        public static ClientPacket ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ClientPacket ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ClientPacket ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ClientPacket ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ClientPacket ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ClientPacket ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ClientPacket ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ClientPacket ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ClientPacket ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ClientPacket ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ClientPacket, Builder>.PrintField("packet", this.hasPacket, this.packet_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _clientPacketFieldNames;
            if (this.hasPacket)
            {
                output.WriteBytes(1, strArray[0], this.Packet);
            }
        }

        public static ClientPacket DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ClientPacket DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasPacket
        {
            get
            {
                return this.hasPacket;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasPacket)
                {
                    return false;
                }
                return true;
            }
        }

        public ByteString Packet
        {
            get
            {
                return this.packet_;
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
                    if (this.hasPacket)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBytesSize(1, this.Packet);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ClientPacket ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<ClientPacket, ClientPacket.Builder>
        {
            private ClientPacket result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ClientPacket.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ClientPacket cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override ClientPacket BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ClientPacket.Builder Clear()
            {
                this.result = ClientPacket.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ClientPacket.Builder ClearPacket()
            {
                this.PrepareBuilder();
                this.result.hasPacket = false;
                this.result.packet_ = ByteString.Empty;
                return this;
            }

            public override ClientPacket.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ClientPacket.Builder(this.result);
                }
                return new ClientPacket.Builder().MergeFrom(this.result);
            }

            public override ClientPacket.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ClientPacket.Builder MergeFrom(IMessageLite other)
            {
                if (other is ClientPacket)
                {
                    return this.MergeFrom((ClientPacket) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ClientPacket.Builder MergeFrom(ClientPacket other)
            {
                if (other != ClientPacket.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasPacket)
                    {
                        this.Packet = other.Packet;
                    }
                }
                return this;
            }

            public override ClientPacket.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ClientPacket._clientPacketFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ClientPacket._clientPacketFieldTags[index];
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
                    this.result.hasPacket = input.ReadBytes(ref this.result.packet_);
                }
                return this;
            }

            private ClientPacket PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ClientPacket result = this.result;
                    this.result = new ClientPacket();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ClientPacket.Builder SetPacket(ByteString value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasPacket = true;
                this.result.packet_ = value;
                return this;
            }

            public override ClientPacket DefaultInstanceForType
            {
                get
                {
                    return ClientPacket.DefaultInstance;
                }
            }

            public bool HasPacket
            {
                get
                {
                    return this.result.hasPacket;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override ClientPacket MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public ByteString Packet
            {
                get
                {
                    return this.result.Packet;
                }
                set
                {
                    this.SetPacket(value);
                }
            }

            protected override ClientPacket.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 6
            }
        }
    }
}

