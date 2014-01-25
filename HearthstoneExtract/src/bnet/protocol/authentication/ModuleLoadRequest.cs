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
    public sealed class ModuleLoadRequest : GeneratedMessageLite<ModuleLoadRequest, Builder>
    {
        private static readonly string[] _moduleLoadRequestFieldNames = new string[] { "message", "module_handle" };
        private static readonly uint[] _moduleLoadRequestFieldTags = new uint[] { 0x12, 10 };
        private static readonly ModuleLoadRequest defaultInstance = new ModuleLoadRequest().MakeReadOnly();
        private bool hasMessage;
        private bool hasModuleHandle;
        private int memoizedSerializedSize = -1;
        private ByteString message_ = ByteString.Empty;
        public const int MessageFieldNumber = 2;
        private ContentHandle moduleHandle_;
        public const int ModuleHandleFieldNumber = 1;

        static ModuleLoadRequest()
        {
            object.ReferenceEquals(AuthenticationService.Descriptor, null);
        }

        private ModuleLoadRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ModuleLoadRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ModuleLoadRequest request = obj as ModuleLoadRequest;
            if (request == null)
            {
                return false;
            }
            if ((this.hasModuleHandle != request.hasModuleHandle) || (this.hasModuleHandle && !this.moduleHandle_.Equals(request.moduleHandle_)))
            {
                return false;
            }
            return ((this.hasMessage == request.hasMessage) && (!this.hasMessage || this.message_.Equals(request.message_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasModuleHandle)
            {
                hashCode ^= this.moduleHandle_.GetHashCode();
            }
            if (this.hasMessage)
            {
                hashCode ^= this.message_.GetHashCode();
            }
            return hashCode;
        }

        private ModuleLoadRequest MakeReadOnly()
        {
            return this;
        }

        public static ModuleLoadRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ModuleLoadRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ModuleLoadRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ModuleLoadRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ModuleLoadRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ModuleLoadRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ModuleLoadRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ModuleLoadRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ModuleLoadRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ModuleLoadRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ModuleLoadRequest, Builder>.PrintField("module_handle", this.hasModuleHandle, this.moduleHandle_, writer);
            GeneratedMessageLite<ModuleLoadRequest, Builder>.PrintField("message", this.hasMessage, this.message_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _moduleLoadRequestFieldNames;
            if (this.hasModuleHandle)
            {
                output.WriteMessage(1, strArray[1], this.ModuleHandle);
            }
            if (this.hasMessage)
            {
                output.WriteBytes(2, strArray[0], this.Message);
            }
        }

        public static ModuleLoadRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ModuleLoadRequest DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasMessage
        {
            get
            {
                return this.hasMessage;
            }
        }

        public bool HasModuleHandle
        {
            get
            {
                return this.hasModuleHandle;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasModuleHandle)
                {
                    return false;
                }
                if (!this.ModuleHandle.IsInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        public ByteString Message
        {
            get
            {
                return this.message_;
            }
        }

        public ContentHandle ModuleHandle
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.moduleHandle_ != null)
                {
                    goto Label_0012;
                }
                return ContentHandle.DefaultInstance;
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
                    if (this.hasModuleHandle)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.ModuleHandle);
                    }
                    if (this.hasMessage)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBytesSize(2, this.Message);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ModuleLoadRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<ModuleLoadRequest, ModuleLoadRequest.Builder>
        {
            private ModuleLoadRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ModuleLoadRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ModuleLoadRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override ModuleLoadRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ModuleLoadRequest.Builder Clear()
            {
                this.result = ModuleLoadRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ModuleLoadRequest.Builder ClearMessage()
            {
                this.PrepareBuilder();
                this.result.hasMessage = false;
                this.result.message_ = ByteString.Empty;
                return this;
            }

            public ModuleLoadRequest.Builder ClearModuleHandle()
            {
                this.PrepareBuilder();
                this.result.hasModuleHandle = false;
                this.result.moduleHandle_ = null;
                return this;
            }

            public override ModuleLoadRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ModuleLoadRequest.Builder(this.result);
                }
                return new ModuleLoadRequest.Builder().MergeFrom(this.result);
            }

            public override ModuleLoadRequest.Builder MergeFrom(ModuleLoadRequest other)
            {
                if (other != ModuleLoadRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasModuleHandle)
                    {
                        this.MergeModuleHandle(other.ModuleHandle);
                    }
                    if (other.HasMessage)
                    {
                        this.Message = other.Message;
                    }
                }
                return this;
            }

            public override ModuleLoadRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ModuleLoadRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is ModuleLoadRequest)
                {
                    return this.MergeFrom((ModuleLoadRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ModuleLoadRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ModuleLoadRequest._moduleLoadRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ModuleLoadRequest._moduleLoadRequestFieldTags[index];
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
                            if (this.result.hasModuleHandle)
                            {
                                builder.MergeFrom(this.ModuleHandle);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.ModuleHandle = builder.BuildPartial();
                            continue;
                        }
                        case 0x12:
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
                    this.result.hasMessage = input.ReadBytes(ref this.result.message_);
                }
                return this;
            }

            public ModuleLoadRequest.Builder MergeModuleHandle(ContentHandle value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasModuleHandle && (this.result.moduleHandle_ != ContentHandle.DefaultInstance))
                {
                    this.result.moduleHandle_ = ContentHandle.CreateBuilder(this.result.moduleHandle_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.moduleHandle_ = value;
                }
                this.result.hasModuleHandle = true;
                return this;
            }

            private ModuleLoadRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ModuleLoadRequest result = this.result;
                    this.result = new ModuleLoadRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ModuleLoadRequest.Builder SetMessage(ByteString value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasMessage = true;
                this.result.message_ = value;
                return this;
            }

            public ModuleLoadRequest.Builder SetModuleHandle(ContentHandle value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasModuleHandle = true;
                this.result.moduleHandle_ = value;
                return this;
            }

            public ModuleLoadRequest.Builder SetModuleHandle(ContentHandle.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasModuleHandle = true;
                this.result.moduleHandle_ = builderForValue.Build();
                return this;
            }

            public override ModuleLoadRequest DefaultInstanceForType
            {
                get
                {
                    return ModuleLoadRequest.DefaultInstance;
                }
            }

            public bool HasMessage
            {
                get
                {
                    return this.result.hasMessage;
                }
            }

            public bool HasModuleHandle
            {
                get
                {
                    return this.result.hasModuleHandle;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public ByteString Message
            {
                get
                {
                    return this.result.Message;
                }
                set
                {
                    this.SetMessage(value);
                }
            }

            protected override ModuleLoadRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public ContentHandle ModuleHandle
            {
                get
                {
                    return this.result.ModuleHandle;
                }
                set
                {
                    this.SetModuleHandle(value);
                }
            }

            protected override ModuleLoadRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

