namespace bnet.protocol
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class Address : GeneratedMessageLite<Address, Builder>
    {
        private static readonly string[] _addressFieldNames = new string[] { "address", "port" };
        private static readonly uint[] _addressFieldTags = new uint[] { 10, 0x10 };
        private string address_ = string.Empty;
        public const int Address_FieldNumber = 1;
        private static readonly Address defaultInstance = new Address().MakeReadOnly();
        private bool hasAddress_;
        private bool hasPort;
        private int memoizedSerializedSize = -1;
        private uint port_;
        public const int PortFieldNumber = 2;

        static Address()
        {
            object.ReferenceEquals(Rpc.Descriptor, null);
        }

        private Address()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(Address prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            Address address = obj as Address;
            if (address == null)
            {
                return false;
            }
            if ((this.hasAddress_ != address.hasAddress_) || (this.hasAddress_ && !this.address_.Equals(address.address_)))
            {
                return false;
            }
            return ((this.hasPort == address.hasPort) && (!this.hasPort || this.port_.Equals(address.port_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasAddress_)
            {
                hashCode ^= this.address_.GetHashCode();
            }
            if (this.hasPort)
            {
                hashCode ^= this.port_.GetHashCode();
            }
            return hashCode;
        }

        private Address MakeReadOnly()
        {
            return this;
        }

        public static Address ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static Address ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static Address ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Address ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Address ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Address ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Address ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static Address ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Address ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Address ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<Address, Builder>.PrintField("address", this.hasAddress_, this.address_, writer);
            GeneratedMessageLite<Address, Builder>.PrintField("port", this.hasPort, this.port_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _addressFieldNames;
            if (this.hasAddress_)
            {
                output.WriteString(1, strArray[0], this.Address_);
            }
            if (this.hasPort)
            {
                output.WriteUInt32(2, strArray[1], this.Port);
            }
        }

        public string Address_
        {
            get
            {
                return this.address_;
            }
        }

        public static Address DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override Address DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasAddress_
        {
            get
            {
                return this.hasAddress_;
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
                if (!this.hasAddress_)
                {
                    return false;
                }
                return true;
            }
        }

        [CLSCompliant(false)]
        public uint Port
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
                    if (this.hasAddress_)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(1, this.Address_);
                    }
                    if (this.hasPort)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(2, this.Port);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override Address ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<Address, Address.Builder>
        {
            private Address result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = Address.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(Address cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override Address BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override Address.Builder Clear()
            {
                this.result = Address.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public Address.Builder ClearAddress_()
            {
                this.PrepareBuilder();
                this.result.hasAddress_ = false;
                this.result.address_ = string.Empty;
                return this;
            }

            public Address.Builder ClearPort()
            {
                this.PrepareBuilder();
                this.result.hasPort = false;
                this.result.port_ = 0;
                return this;
            }

            public override Address.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new Address.Builder(this.result);
                }
                return new Address.Builder().MergeFrom(this.result);
            }

            public override Address.Builder MergeFrom(Address other)
            {
                if (other != Address.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAddress_)
                    {
                        this.Address_ = other.Address_;
                    }
                    if (other.HasPort)
                    {
                        this.Port = other.Port;
                    }
                }
                return this;
            }

            public override Address.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override Address.Builder MergeFrom(IMessageLite other)
            {
                if (other is Address)
                {
                    return this.MergeFrom((Address) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override Address.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(Address._addressFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = Address._addressFieldTags[index];
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
                            this.result.hasAddress_ = input.ReadString(ref this.result.address_);
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
                    this.result.hasPort = input.ReadUInt32(ref this.result.port_);
                }
                return this;
            }

            private Address PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    Address result = this.result;
                    this.result = new Address();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public Address.Builder SetAddress_(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasAddress_ = true;
                this.result.address_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public Address.Builder SetPort(uint value)
            {
                this.PrepareBuilder();
                this.result.hasPort = true;
                this.result.port_ = value;
                return this;
            }

            public string Address_
            {
                get
                {
                    return this.result.Address_;
                }
                set
                {
                    this.SetAddress_(value);
                }
            }

            public override Address DefaultInstanceForType
            {
                get
                {
                    return Address.DefaultInstance;
                }
            }

            public bool HasAddress_
            {
                get
                {
                    return this.result.hasAddress_;
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

            protected override Address MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            [CLSCompliant(false)]
            public uint Port
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

            protected override Address.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

