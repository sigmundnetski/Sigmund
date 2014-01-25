namespace bnet.protocol.authentication
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class ModuleMessageRequest : GeneratedMessageLite<ModuleMessageRequest, Builder>
    {
        private static readonly string[] _moduleMessageRequestFieldNames = new string[] { "message", "module_id" };
        private static readonly uint[] _moduleMessageRequestFieldTags = new uint[] { 0x12, 8 };
        private static readonly ModuleMessageRequest defaultInstance = new ModuleMessageRequest().MakeReadOnly();
        private bool hasMessage;
        private bool hasModuleId;
        private int memoizedSerializedSize = -1;
        private ByteString message_ = ByteString.Empty;
        public const int MessageFieldNumber = 2;
        private int moduleId_;
        public const int ModuleIdFieldNumber = 1;

        static ModuleMessageRequest()
        {
            object.ReferenceEquals(AuthenticationService.Descriptor, null);
        }

        private ModuleMessageRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ModuleMessageRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ModuleMessageRequest request = obj as ModuleMessageRequest;
            if (request == null)
            {
                return false;
            }
            if ((this.hasModuleId != request.hasModuleId) || (this.hasModuleId && !this.moduleId_.Equals(request.moduleId_)))
            {
                return false;
            }
            return ((this.hasMessage == request.hasMessage) && (!this.hasMessage || this.message_.Equals(request.message_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasModuleId)
            {
                hashCode ^= this.moduleId_.GetHashCode();
            }
            if (this.hasMessage)
            {
                hashCode ^= this.message_.GetHashCode();
            }
            return hashCode;
        }

        private ModuleMessageRequest MakeReadOnly()
        {
            return this;
        }

        public static ModuleMessageRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ModuleMessageRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ModuleMessageRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ModuleMessageRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ModuleMessageRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ModuleMessageRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ModuleMessageRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ModuleMessageRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ModuleMessageRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ModuleMessageRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ModuleMessageRequest, Builder>.PrintField("module_id", this.hasModuleId, this.moduleId_, writer);
            GeneratedMessageLite<ModuleMessageRequest, Builder>.PrintField("message", this.hasMessage, this.message_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _moduleMessageRequestFieldNames;
            if (this.hasModuleId)
            {
                output.WriteInt32(1, strArray[1], this.ModuleId);
            }
            if (this.hasMessage)
            {
                output.WriteBytes(2, strArray[0], this.Message);
            }
        }

        public static ModuleMessageRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ModuleMessageRequest DefaultInstanceForType
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

        public bool HasModuleId
        {
            get
            {
                return this.hasModuleId;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasModuleId)
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

        public int ModuleId
        {
            get
            {
                return this.moduleId_;
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
                    if (this.hasModuleId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.ModuleId);
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

        protected override ModuleMessageRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<ModuleMessageRequest, ModuleMessageRequest.Builder>
        {
            private ModuleMessageRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ModuleMessageRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ModuleMessageRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override ModuleMessageRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ModuleMessageRequest.Builder Clear()
            {
                this.result = ModuleMessageRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ModuleMessageRequest.Builder ClearMessage()
            {
                this.PrepareBuilder();
                this.result.hasMessage = false;
                this.result.message_ = ByteString.Empty;
                return this;
            }

            public ModuleMessageRequest.Builder ClearModuleId()
            {
                this.PrepareBuilder();
                this.result.hasModuleId = false;
                this.result.moduleId_ = 0;
                return this;
            }

            public override ModuleMessageRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ModuleMessageRequest.Builder(this.result);
                }
                return new ModuleMessageRequest.Builder().MergeFrom(this.result);
            }

            public override ModuleMessageRequest.Builder MergeFrom(ModuleMessageRequest other)
            {
                if (other != ModuleMessageRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasModuleId)
                    {
                        this.ModuleId = other.ModuleId;
                    }
                    if (other.HasMessage)
                    {
                        this.Message = other.Message;
                    }
                }
                return this;
            }

            public override ModuleMessageRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ModuleMessageRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is ModuleMessageRequest)
                {
                    return this.MergeFrom((ModuleMessageRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ModuleMessageRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ModuleMessageRequest._moduleMessageRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ModuleMessageRequest._moduleMessageRequestFieldTags[index];
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
                            this.result.hasModuleId = input.ReadInt32(ref this.result.moduleId_);
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

            private ModuleMessageRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ModuleMessageRequest result = this.result;
                    this.result = new ModuleMessageRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ModuleMessageRequest.Builder SetMessage(ByteString value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasMessage = true;
                this.result.message_ = value;
                return this;
            }

            public ModuleMessageRequest.Builder SetModuleId(int value)
            {
                this.PrepareBuilder();
                this.result.hasModuleId = true;
                this.result.moduleId_ = value;
                return this;
            }

            public override ModuleMessageRequest DefaultInstanceForType
            {
                get
                {
                    return ModuleMessageRequest.DefaultInstance;
                }
            }

            public bool HasMessage
            {
                get
                {
                    return this.result.hasMessage;
                }
            }

            public bool HasModuleId
            {
                get
                {
                    return this.result.hasModuleId;
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

            protected override ModuleMessageRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int ModuleId
            {
                get
                {
                    return this.result.ModuleId;
                }
                set
                {
                    this.SetModuleId(value);
                }
            }

            protected override ModuleMessageRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

