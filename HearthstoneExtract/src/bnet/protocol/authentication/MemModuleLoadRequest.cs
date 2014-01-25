namespace bnet.protocol.authentication
{
    using bnet.protocol;
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class MemModuleLoadRequest : GeneratedMessageLite<MemModuleLoadRequest, Builder>
    {
        private static readonly string[] _memModuleLoadRequestFieldNames = new string[] { "handle", "input", "key" };
        private static readonly uint[] _memModuleLoadRequestFieldTags = new uint[] { 10, 0x1a, 0x12 };
        private static readonly MemModuleLoadRequest defaultInstance = new MemModuleLoadRequest().MakeReadOnly();
        private ContentHandle handle_;
        public const int HandleFieldNumber = 1;
        private bool hasHandle;
        private bool hasInput;
        private bool hasKey;
        private ByteString input_ = ByteString.Empty;
        public const int InputFieldNumber = 3;
        private ByteString key_ = ByteString.Empty;
        public const int KeyFieldNumber = 2;
        private int memoizedSerializedSize = -1;

        static MemModuleLoadRequest()
        {
            object.ReferenceEquals(AuthenticationService.Descriptor, null);
        }

        private MemModuleLoadRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(MemModuleLoadRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            MemModuleLoadRequest request = obj as MemModuleLoadRequest;
            if (request == null)
            {
                return false;
            }
            if ((this.hasHandle != request.hasHandle) || (this.hasHandle && !this.handle_.Equals(request.handle_)))
            {
                return false;
            }
            if ((this.hasKey != request.hasKey) || (this.hasKey && !this.key_.Equals(request.key_)))
            {
                return false;
            }
            return ((this.hasInput == request.hasInput) && (!this.hasInput || this.input_.Equals(request.input_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasHandle)
            {
                hashCode ^= this.handle_.GetHashCode();
            }
            if (this.hasKey)
            {
                hashCode ^= this.key_.GetHashCode();
            }
            if (this.hasInput)
            {
                hashCode ^= this.input_.GetHashCode();
            }
            return hashCode;
        }

        private MemModuleLoadRequest MakeReadOnly()
        {
            return this;
        }

        public static MemModuleLoadRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static MemModuleLoadRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static MemModuleLoadRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static MemModuleLoadRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static MemModuleLoadRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static MemModuleLoadRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static MemModuleLoadRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static MemModuleLoadRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static MemModuleLoadRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static MemModuleLoadRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<MemModuleLoadRequest, Builder>.PrintField("handle", this.hasHandle, this.handle_, writer);
            GeneratedMessageLite<MemModuleLoadRequest, Builder>.PrintField("key", this.hasKey, this.key_, writer);
            GeneratedMessageLite<MemModuleLoadRequest, Builder>.PrintField("input", this.hasInput, this.input_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _memModuleLoadRequestFieldNames;
            if (this.hasHandle)
            {
                output.WriteMessage(1, strArray[0], this.Handle);
            }
            if (this.hasKey)
            {
                output.WriteBytes(2, strArray[2], this.Key);
            }
            if (this.hasInput)
            {
                output.WriteBytes(3, strArray[1], this.Input);
            }
        }

        public static MemModuleLoadRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override MemModuleLoadRequest DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public ContentHandle Handle
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.handle_ != null)
                {
                    goto Label_0012;
                }
                return ContentHandle.DefaultInstance;
            }
        }

        public bool HasHandle
        {
            get
            {
                return this.hasHandle;
            }
        }

        public bool HasInput
        {
            get
            {
                return this.hasInput;
            }
        }

        public bool HasKey
        {
            get
            {
                return this.hasKey;
            }
        }

        public ByteString Input
        {
            get
            {
                return this.input_;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasHandle)
                {
                    return false;
                }
                if (!this.hasKey)
                {
                    return false;
                }
                if (!this.hasInput)
                {
                    return false;
                }
                if (!this.Handle.IsInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        public ByteString Key
        {
            get
            {
                return this.key_;
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
                    if (this.hasHandle)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.Handle);
                    }
                    if (this.hasKey)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBytesSize(2, this.Key);
                    }
                    if (this.hasInput)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBytesSize(3, this.Input);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override MemModuleLoadRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<MemModuleLoadRequest, MemModuleLoadRequest.Builder>
        {
            private MemModuleLoadRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = MemModuleLoadRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(MemModuleLoadRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override MemModuleLoadRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override MemModuleLoadRequest.Builder Clear()
            {
                this.result = MemModuleLoadRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public MemModuleLoadRequest.Builder ClearHandle()
            {
                this.PrepareBuilder();
                this.result.hasHandle = false;
                this.result.handle_ = null;
                return this;
            }

            public MemModuleLoadRequest.Builder ClearInput()
            {
                this.PrepareBuilder();
                this.result.hasInput = false;
                this.result.input_ = ByteString.Empty;
                return this;
            }

            public MemModuleLoadRequest.Builder ClearKey()
            {
                this.PrepareBuilder();
                this.result.hasKey = false;
                this.result.key_ = ByteString.Empty;
                return this;
            }

            public override MemModuleLoadRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new MemModuleLoadRequest.Builder(this.result);
                }
                return new MemModuleLoadRequest.Builder().MergeFrom(this.result);
            }

            public override MemModuleLoadRequest.Builder MergeFrom(MemModuleLoadRequest other)
            {
                if (other != MemModuleLoadRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasHandle)
                    {
                        this.MergeHandle(other.Handle);
                    }
                    if (other.HasKey)
                    {
                        this.Key = other.Key;
                    }
                    if (other.HasInput)
                    {
                        this.Input = other.Input;
                    }
                }
                return this;
            }

            public override MemModuleLoadRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override MemModuleLoadRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is MemModuleLoadRequest)
                {
                    return this.MergeFrom((MemModuleLoadRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override MemModuleLoadRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(MemModuleLoadRequest._memModuleLoadRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = MemModuleLoadRequest._memModuleLoadRequestFieldTags[index];
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
                            ContentHandle.Builder builder = ContentHandle.CreateBuilder();
                            if (this.result.hasHandle)
                            {
                                builder.MergeFrom(this.Handle);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.Handle = builder.BuildPartial();
                            continue;
                        }
                        case 0x12:
                        {
                            this.result.hasKey = input.ReadBytes(ref this.result.key_);
                            continue;
                        }
                        case 0x1a:
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
                    this.result.hasInput = input.ReadBytes(ref this.result.input_);
                }
                return this;
            }

            public MemModuleLoadRequest.Builder MergeHandle(ContentHandle value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasHandle && (this.result.handle_ != ContentHandle.DefaultInstance))
                {
                    this.result.handle_ = ContentHandle.CreateBuilder(this.result.handle_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.handle_ = value;
                }
                this.result.hasHandle = true;
                return this;
            }

            private MemModuleLoadRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    MemModuleLoadRequest result = this.result;
                    this.result = new MemModuleLoadRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public MemModuleLoadRequest.Builder SetHandle(ContentHandle value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasHandle = true;
                this.result.handle_ = value;
                return this;
            }

            public MemModuleLoadRequest.Builder SetHandle(ContentHandle.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasHandle = true;
                this.result.handle_ = builderForValue.Build();
                return this;
            }

            public MemModuleLoadRequest.Builder SetInput(ByteString value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasInput = true;
                this.result.input_ = value;
                return this;
            }

            public MemModuleLoadRequest.Builder SetKey(ByteString value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasKey = true;
                this.result.key_ = value;
                return this;
            }

            public override MemModuleLoadRequest DefaultInstanceForType
            {
                get
                {
                    return MemModuleLoadRequest.DefaultInstance;
                }
            }

            public ContentHandle Handle
            {
                get
                {
                    return this.result.Handle;
                }
                set
                {
                    this.SetHandle(value);
                }
            }

            public bool HasHandle
            {
                get
                {
                    return this.result.hasHandle;
                }
            }

            public bool HasInput
            {
                get
                {
                    return this.result.hasInput;
                }
            }

            public bool HasKey
            {
                get
                {
                    return this.result.hasKey;
                }
            }

            public ByteString Input
            {
                get
                {
                    return this.result.Input;
                }
                set
                {
                    this.SetInput(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public ByteString Key
            {
                get
                {
                    return this.result.Key;
                }
                set
                {
                    this.SetKey(value);
                }
            }

            protected override MemModuleLoadRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override MemModuleLoadRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

