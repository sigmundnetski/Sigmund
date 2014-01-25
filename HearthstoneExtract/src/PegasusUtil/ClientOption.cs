namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class ClientOption : GeneratedMessageLite<ClientOption, Builder>
    {
        private static readonly string[] _clientOptionFieldNames = new string[] { "as_bool", "as_float", "as_int32", "as_int64", "index" };
        private static readonly uint[] _clientOptionFieldTags = new uint[] { 0x10, 0x2d, 0x18, 0x20, 8 };
        private bool asBool_;
        public const int AsBoolFieldNumber = 2;
        private float asFloat_;
        public const int AsFloatFieldNumber = 5;
        private int asInt32_;
        public const int AsInt32FieldNumber = 3;
        private long asInt64_;
        public const int AsInt64FieldNumber = 4;
        private static readonly ClientOption defaultInstance = new ClientOption().MakeReadOnly();
        private bool hasAsBool;
        private bool hasAsFloat;
        private bool hasAsInt32;
        private bool hasAsInt64;
        private bool hasIndex;
        private int index_;
        public const int IndexFieldNumber = 1;
        private int memoizedSerializedSize = -1;

        static ClientOption()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private ClientOption()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ClientOption prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ClientOption option = obj as ClientOption;
            if (option == null)
            {
                return false;
            }
            if ((this.hasIndex != option.hasIndex) || (this.hasIndex && !this.index_.Equals(option.index_)))
            {
                return false;
            }
            if ((this.hasAsBool != option.hasAsBool) || (this.hasAsBool && !this.asBool_.Equals(option.asBool_)))
            {
                return false;
            }
            if ((this.hasAsInt32 != option.hasAsInt32) || (this.hasAsInt32 && !this.asInt32_.Equals(option.asInt32_)))
            {
                return false;
            }
            if ((this.hasAsInt64 != option.hasAsInt64) || (this.hasAsInt64 && !this.asInt64_.Equals(option.asInt64_)))
            {
                return false;
            }
            return ((this.hasAsFloat == option.hasAsFloat) && (!this.hasAsFloat || this.asFloat_.Equals(option.asFloat_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasIndex)
            {
                hashCode ^= this.index_.GetHashCode();
            }
            if (this.hasAsBool)
            {
                hashCode ^= this.asBool_.GetHashCode();
            }
            if (this.hasAsInt32)
            {
                hashCode ^= this.asInt32_.GetHashCode();
            }
            if (this.hasAsInt64)
            {
                hashCode ^= this.asInt64_.GetHashCode();
            }
            if (this.hasAsFloat)
            {
                hashCode ^= this.asFloat_.GetHashCode();
            }
            return hashCode;
        }

        private ClientOption MakeReadOnly()
        {
            return this;
        }

        public static ClientOption ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ClientOption ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ClientOption ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ClientOption ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ClientOption ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ClientOption ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ClientOption ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ClientOption ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ClientOption ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ClientOption ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ClientOption, Builder>.PrintField("index", this.hasIndex, this.index_, writer);
            GeneratedMessageLite<ClientOption, Builder>.PrintField("as_bool", this.hasAsBool, this.asBool_, writer);
            GeneratedMessageLite<ClientOption, Builder>.PrintField("as_int32", this.hasAsInt32, this.asInt32_, writer);
            GeneratedMessageLite<ClientOption, Builder>.PrintField("as_int64", this.hasAsInt64, this.asInt64_, writer);
            GeneratedMessageLite<ClientOption, Builder>.PrintField("as_float", this.hasAsFloat, this.asFloat_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _clientOptionFieldNames;
            if (this.hasIndex)
            {
                output.WriteInt32(1, strArray[4], this.Index);
            }
            if (this.hasAsBool)
            {
                output.WriteBool(2, strArray[0], this.AsBool);
            }
            if (this.hasAsInt32)
            {
                output.WriteInt32(3, strArray[2], this.AsInt32);
            }
            if (this.hasAsInt64)
            {
                output.WriteInt64(4, strArray[3], this.AsInt64);
            }
            if (this.hasAsFloat)
            {
                output.WriteFloat(5, strArray[1], this.AsFloat);
            }
        }

        public bool AsBool
        {
            get
            {
                return this.asBool_;
            }
        }

        public float AsFloat
        {
            get
            {
                return this.asFloat_;
            }
        }

        public int AsInt32
        {
            get
            {
                return this.asInt32_;
            }
        }

        public long AsInt64
        {
            get
            {
                return this.asInt64_;
            }
        }

        public static ClientOption DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ClientOption DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasAsBool
        {
            get
            {
                return this.hasAsBool;
            }
        }

        public bool HasAsFloat
        {
            get
            {
                return this.hasAsFloat;
            }
        }

        public bool HasAsInt32
        {
            get
            {
                return this.hasAsInt32;
            }
        }

        public bool HasAsInt64
        {
            get
            {
                return this.hasAsInt64;
            }
        }

        public bool HasIndex
        {
            get
            {
                return this.hasIndex;
            }
        }

        public int Index
        {
            get
            {
                return this.index_;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasIndex)
                {
                    return false;
                }
                return true;
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
                    if (this.hasIndex)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.Index);
                    }
                    if (this.hasAsBool)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(2, this.AsBool);
                    }
                    if (this.hasAsInt32)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(3, this.AsInt32);
                    }
                    if (this.hasAsInt64)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(4, this.AsInt64);
                    }
                    if (this.hasAsFloat)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFloatSize(5, this.AsFloat);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ClientOption ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<ClientOption, ClientOption.Builder>
        {
            private ClientOption result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ClientOption.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ClientOption cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override ClientOption BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ClientOption.Builder Clear()
            {
                this.result = ClientOption.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ClientOption.Builder ClearAsBool()
            {
                this.PrepareBuilder();
                this.result.hasAsBool = false;
                this.result.asBool_ = false;
                return this;
            }

            public ClientOption.Builder ClearAsFloat()
            {
                this.PrepareBuilder();
                this.result.hasAsFloat = false;
                this.result.asFloat_ = 0f;
                return this;
            }

            public ClientOption.Builder ClearAsInt32()
            {
                this.PrepareBuilder();
                this.result.hasAsInt32 = false;
                this.result.asInt32_ = 0;
                return this;
            }

            public ClientOption.Builder ClearAsInt64()
            {
                this.PrepareBuilder();
                this.result.hasAsInt64 = false;
                this.result.asInt64_ = 0L;
                return this;
            }

            public ClientOption.Builder ClearIndex()
            {
                this.PrepareBuilder();
                this.result.hasIndex = false;
                this.result.index_ = 0;
                return this;
            }

            public override ClientOption.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ClientOption.Builder(this.result);
                }
                return new ClientOption.Builder().MergeFrom(this.result);
            }

            public override ClientOption.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ClientOption.Builder MergeFrom(IMessageLite other)
            {
                if (other is ClientOption)
                {
                    return this.MergeFrom((ClientOption) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ClientOption.Builder MergeFrom(ClientOption other)
            {
                if (other != ClientOption.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasIndex)
                    {
                        this.Index = other.Index;
                    }
                    if (other.HasAsBool)
                    {
                        this.AsBool = other.AsBool;
                    }
                    if (other.HasAsInt32)
                    {
                        this.AsInt32 = other.AsInt32;
                    }
                    if (other.HasAsInt64)
                    {
                        this.AsInt64 = other.AsInt64;
                    }
                    if (other.HasAsFloat)
                    {
                        this.AsFloat = other.AsFloat;
                    }
                }
                return this;
            }

            public override ClientOption.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ClientOption._clientOptionFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ClientOption._clientOptionFieldTags[index];
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
                            this.result.hasIndex = input.ReadInt32(ref this.result.index_);
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasAsBool = input.ReadBool(ref this.result.asBool_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasAsInt32 = input.ReadInt32(ref this.result.asInt32_);
                            continue;
                        }
                        case 0x20:
                        {
                            this.result.hasAsInt64 = input.ReadInt64(ref this.result.asInt64_);
                            continue;
                        }
                        case 0x2d:
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
                    this.result.hasAsFloat = input.ReadFloat(ref this.result.asFloat_);
                }
                return this;
            }

            private ClientOption PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ClientOption result = this.result;
                    this.result = new ClientOption();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ClientOption.Builder SetAsBool(bool value)
            {
                this.PrepareBuilder();
                this.result.hasAsBool = true;
                this.result.asBool_ = value;
                return this;
            }

            public ClientOption.Builder SetAsFloat(float value)
            {
                this.PrepareBuilder();
                this.result.hasAsFloat = true;
                this.result.asFloat_ = value;
                return this;
            }

            public ClientOption.Builder SetAsInt32(int value)
            {
                this.PrepareBuilder();
                this.result.hasAsInt32 = true;
                this.result.asInt32_ = value;
                return this;
            }

            public ClientOption.Builder SetAsInt64(long value)
            {
                this.PrepareBuilder();
                this.result.hasAsInt64 = true;
                this.result.asInt64_ = value;
                return this;
            }

            public ClientOption.Builder SetIndex(int value)
            {
                this.PrepareBuilder();
                this.result.hasIndex = true;
                this.result.index_ = value;
                return this;
            }

            public bool AsBool
            {
                get
                {
                    return this.result.AsBool;
                }
                set
                {
                    this.SetAsBool(value);
                }
            }

            public float AsFloat
            {
                get
                {
                    return this.result.AsFloat;
                }
                set
                {
                    this.SetAsFloat(value);
                }
            }

            public int AsInt32
            {
                get
                {
                    return this.result.AsInt32;
                }
                set
                {
                    this.SetAsInt32(value);
                }
            }

            public long AsInt64
            {
                get
                {
                    return this.result.AsInt64;
                }
                set
                {
                    this.SetAsInt64(value);
                }
            }

            public override ClientOption DefaultInstanceForType
            {
                get
                {
                    return ClientOption.DefaultInstance;
                }
            }

            public bool HasAsBool
            {
                get
                {
                    return this.result.hasAsBool;
                }
            }

            public bool HasAsFloat
            {
                get
                {
                    return this.result.hasAsFloat;
                }
            }

            public bool HasAsInt32
            {
                get
                {
                    return this.result.hasAsInt32;
                }
            }

            public bool HasAsInt64
            {
                get
                {
                    return this.result.hasAsInt64;
                }
            }

            public bool HasIndex
            {
                get
                {
                    return this.result.hasIndex;
                }
            }

            public int Index
            {
                get
                {
                    return this.result.Index;
                }
                set
                {
                    this.SetIndex(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override ClientOption MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override ClientOption.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

