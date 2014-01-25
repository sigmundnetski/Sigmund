namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class AtlasError : GeneratedMessageLite<AtlasError, Builder>
    {
        private static readonly string[] _atlasErrorFieldNames = new string[] { "error", "type" };
        private static readonly uint[] _atlasErrorFieldTags = new uint[] { 0x10, 8 };
        private static readonly AtlasError defaultInstance = new AtlasError().MakeReadOnly();
        private int error_;
        public const int ErrorFieldNumber = 2;
        private bool hasError;
        private bool hasType;
        private int memoizedSerializedSize = -1;
        private Types.ErrorType type_ = Types.ErrorType.BNET_ERROR;
        public const int TypeFieldNumber = 1;

        static AtlasError()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AtlasError()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AtlasError prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AtlasError error = obj as AtlasError;
            if (error == null)
            {
                return false;
            }
            if ((this.hasType != error.hasType) || (this.hasType && !this.type_.Equals(error.type_)))
            {
                return false;
            }
            return ((this.hasError == error.hasError) && (!this.hasError || this.error_.Equals(error.error_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasType)
            {
                hashCode ^= this.type_.GetHashCode();
            }
            if (this.hasError)
            {
                hashCode ^= this.error_.GetHashCode();
            }
            return hashCode;
        }

        private AtlasError MakeReadOnly()
        {
            return this;
        }

        public static AtlasError ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AtlasError ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasError ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasError ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasError ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasError ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasError ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AtlasError ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasError ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasError ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AtlasError, Builder>.PrintField("type", this.hasType, this.type_, writer);
            GeneratedMessageLite<AtlasError, Builder>.PrintField("error", this.hasError, this.error_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _atlasErrorFieldNames;
            if (this.hasType)
            {
                output.WriteEnum(1, strArray[1], (int) this.Type, this.Type);
            }
            if (this.hasError)
            {
                output.WriteInt32(2, strArray[0], this.Error);
            }
        }

        public static AtlasError DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AtlasError DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public int Error
        {
            get
            {
                return this.error_;
            }
        }

        public bool HasError
        {
            get
            {
                return this.hasError;
            }
        }

        public bool HasType
        {
            get
            {
                return this.hasType;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasType)
                {
                    return false;
                }
                if (!this.hasError)
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
                    if (this.hasType)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeEnumSize(1, (int) this.Type);
                    }
                    if (this.hasError)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.Error);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override AtlasError ThisMessage
        {
            get
            {
                return this;
            }
        }

        public Types.ErrorType Type
        {
            get
            {
                return this.type_;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<AtlasError, AtlasError.Builder>
        {
            private AtlasError result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AtlasError.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AtlasError cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override AtlasError BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AtlasError.Builder Clear()
            {
                this.result = AtlasError.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AtlasError.Builder ClearError()
            {
                this.PrepareBuilder();
                this.result.hasError = false;
                this.result.error_ = 0;
                return this;
            }

            public AtlasError.Builder ClearType()
            {
                this.PrepareBuilder();
                this.result.hasType = false;
                this.result.type_ = AtlasError.Types.ErrorType.BNET_ERROR;
                return this;
            }

            public override AtlasError.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AtlasError.Builder(this.result);
                }
                return new AtlasError.Builder().MergeFrom(this.result);
            }

            public override AtlasError.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AtlasError.Builder MergeFrom(IMessageLite other)
            {
                if (other is AtlasError)
                {
                    return this.MergeFrom((AtlasError) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AtlasError.Builder MergeFrom(AtlasError other)
            {
                if (other != AtlasError.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasType)
                    {
                        this.Type = other.Type;
                    }
                    if (other.HasError)
                    {
                        this.Error = other.Error;
                    }
                }
                return this;
            }

            public override AtlasError.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AtlasError._atlasErrorFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AtlasError._atlasErrorFieldTags[index];
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
                            object obj2;
                            if (input.ReadEnum<AtlasError.Types.ErrorType>(ref this.result.type_, out obj2))
                            {
                                this.result.hasType = true;
                            }
                            else if (obj2 is int)
                            {
                            }
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
                    this.result.hasError = input.ReadInt32(ref this.result.error_);
                }
                return this;
            }

            private AtlasError PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AtlasError result = this.result;
                    this.result = new AtlasError();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public AtlasError.Builder SetError(int value)
            {
                this.PrepareBuilder();
                this.result.hasError = true;
                this.result.error_ = value;
                return this;
            }

            public AtlasError.Builder SetType(AtlasError.Types.ErrorType value)
            {
                this.PrepareBuilder();
                this.result.hasType = true;
                this.result.type_ = value;
                return this;
            }

            public override AtlasError DefaultInstanceForType
            {
                get
                {
                    return AtlasError.DefaultInstance;
                }
            }

            public int Error
            {
                get
                {
                    return this.result.Error;
                }
                set
                {
                    this.SetError(value);
                }
            }

            public bool HasError
            {
                get
                {
                    return this.result.hasError;
                }
            }

            public bool HasType
            {
                get
                {
                    return this.result.hasType;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override AtlasError MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override AtlasError.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public AtlasError.Types.ErrorType Type
            {
                get
                {
                    return this.result.Type;
                }
                set
                {
                    this.SetType(value);
                }
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum ErrorType
            {
                BNET_ERROR = 1,
                PEGASUS_ERROR = 2
            }

            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0x65
            }
        }
    }
}

