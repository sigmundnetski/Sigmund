namespace bnet.protocol.channel
{
    using bnet.protocol.attribute;
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class Message : ExtendableMessageLite<Message, Builder>
    {
        private static readonly string[] _messageFieldNames = new string[] { "attribute", "role" };
        private static readonly uint[] _messageFieldTags = new uint[] { 10, 0x10 };
        private PopsicleList<bnet.protocol.attribute.Attribute> attribute_ = new PopsicleList<bnet.protocol.attribute.Attribute>();
        public const int AttributeFieldNumber = 1;
        private static readonly Message defaultInstance = new Message().MakeReadOnly();
        private bool hasRole;
        private int memoizedSerializedSize = -1;
        private uint role_;
        public const int RoleFieldNumber = 2;

        static Message()
        {
            object.ReferenceEquals(ChannelTypes.Descriptor, null);
        }

        private Message()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(Message prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            Message message = obj as Message;
            if (message == null)
            {
                return false;
            }
            if (this.attribute_.Count != message.attribute_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.attribute_.Count; i++)
            {
                if (!this.attribute_[i].Equals(message.attribute_[i]))
                {
                    return false;
                }
            }
            if ((this.hasRole != message.hasRole) || (this.hasRole && !this.role_.Equals(message.role_)))
            {
                return false;
            }
            if (!base.Equals(message))
            {
                return false;
            }
            return true;
        }

        public bnet.protocol.attribute.Attribute GetAttribute(int index)
        {
            return this.attribute_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<bnet.protocol.attribute.Attribute> enumerator = this.attribute_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    bnet.protocol.attribute.Attribute current = enumerator.Current;
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
            if (this.hasRole)
            {
                hashCode ^= this.role_.GetHashCode();
            }
            return (hashCode ^ base.GetHashCode());
        }

        private Message MakeReadOnly()
        {
            this.attribute_.MakeReadOnly();
            return this;
        }

        public static Message ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static Message ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static Message ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Message ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Message ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Message ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Message ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static Message ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Message ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Message ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<Message, Builder>.PrintField<bnet.protocol.attribute.Attribute>("attribute", this.attribute_, writer);
            GeneratedMessageLite<Message, Builder>.PrintField("role", this.hasRole, this.role_, writer);
            base.PrintTo(writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _messageFieldNames;
            ExtendableMessageLite<Message, Builder>.ExtensionWriter writer = base.CreateExtensionWriter(this);
            if (this.attribute_.Count > 0)
            {
                output.WriteMessageArray<bnet.protocol.attribute.Attribute>(1, strArray[0], this.attribute_);
            }
            if (this.hasRole)
            {
                output.WriteUInt32(2, strArray[1], this.Role);
            }
            writer.WriteUntil(0x2710, output);
        }

        public int AttributeCount
        {
            get
            {
                return this.attribute_.Count;
            }
        }

        public IList<bnet.protocol.attribute.Attribute> AttributeList
        {
            get
            {
                return this.attribute_;
            }
        }

        public static Message DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override Message DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasRole
        {
            get
            {
                return this.hasRole;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                IEnumerator<bnet.protocol.attribute.Attribute> enumerator = this.AttributeList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        bnet.protocol.attribute.Attribute current = enumerator.Current;
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
                if (!base.ExtensionsAreInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        [CLSCompliant(false)]
        public uint Role
        {
            get
            {
                return this.role_;
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
                    IEnumerator<bnet.protocol.attribute.Attribute> enumerator = this.AttributeList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            bnet.protocol.attribute.Attribute current = enumerator.Current;
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
                    if (this.hasRole)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(2, this.Role);
                    }
                    memoizedSerializedSize += base.ExtensionsSerializedSize;
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override Message ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : ExtendableBuilderLite<Message, Message.Builder>
        {
            private Message result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = Message.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(Message cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public Message.Builder AddAttribute(bnet.protocol.attribute.Attribute value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.attribute_.Add(value);
                return this;
            }

            public Message.Builder AddAttribute(bnet.protocol.attribute.Attribute.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.attribute_.Add(builderForValue.Build());
                return this;
            }

            public Message.Builder AddRangeAttribute(IEnumerable<bnet.protocol.attribute.Attribute> values)
            {
                this.PrepareBuilder();
                this.result.attribute_.Add(values);
                return this;
            }

            public override Message BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override Message.Builder Clear()
            {
                this.result = Message.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public Message.Builder ClearAttribute()
            {
                this.PrepareBuilder();
                this.result.attribute_.Clear();
                return this;
            }

            public Message.Builder ClearRole()
            {
                this.PrepareBuilder();
                this.result.hasRole = false;
                this.result.role_ = 0;
                return this;
            }

            public override Message.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new Message.Builder(this.result);
                }
                return new Message.Builder().MergeFrom(this.result);
            }

            public bnet.protocol.attribute.Attribute GetAttribute(int index)
            {
                return this.result.GetAttribute(index);
            }

            public override Message.Builder MergeFrom(Message other)
            {
                if (other != Message.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.attribute_.Count != 0)
                    {
                        this.result.attribute_.Add(other.attribute_);
                    }
                    if (other.HasRole)
                    {
                        this.Role = other.Role;
                    }
                    base.MergeExtensionFields(other);
                }
                return this;
            }

            public override Message.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override Message.Builder MergeFrom(IMessageLite other)
            {
                if (other is Message)
                {
                    return this.MergeFrom((Message) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override Message.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(Message._messageFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = Message._messageFieldTags[index];
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
                            input.ReadMessageArray<bnet.protocol.attribute.Attribute>(num, str, this.result.attribute_, bnet.protocol.attribute.Attribute.DefaultInstance, extensionRegistry);
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
                    this.result.hasRole = input.ReadUInt32(ref this.result.role_);
                }
                return this;
            }

            private Message PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    Message result = this.result;
                    this.result = new Message();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public Message.Builder SetAttribute(int index, bnet.protocol.attribute.Attribute value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.attribute_[index] = value;
                return this;
            }

            public Message.Builder SetAttribute(int index, bnet.protocol.attribute.Attribute.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.attribute_[index] = builderForValue.Build();
                return this;
            }

            [CLSCompliant(false)]
            public Message.Builder SetRole(uint value)
            {
                this.PrepareBuilder();
                this.result.hasRole = true;
                this.result.role_ = value;
                return this;
            }

            public int AttributeCount
            {
                get
                {
                    return this.result.AttributeCount;
                }
            }

            public IPopsicleList<bnet.protocol.attribute.Attribute> AttributeList
            {
                get
                {
                    return this.PrepareBuilder().attribute_;
                }
            }

            public override Message DefaultInstanceForType
            {
                get
                {
                    return Message.DefaultInstance;
                }
            }

            public bool HasRole
            {
                get
                {
                    return this.result.hasRole;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override Message MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            [CLSCompliant(false)]
            public uint Role
            {
                get
                {
                    return this.result.Role;
                }
                set
                {
                    this.SetRole(value);
                }
            }

            protected override Message.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

