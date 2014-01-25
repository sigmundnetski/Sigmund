namespace bnet.protocol.authentication
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class ModuleNotification : GeneratedMessageLite<ModuleNotification, Builder>
    {
        private static readonly string[] _moduleNotificationFieldNames = new string[] { "module_id", "result" };
        private static readonly uint[] _moduleNotificationFieldTags = new uint[] { 0x10, 0x18 };
        private static readonly ModuleNotification defaultInstance = new ModuleNotification().MakeReadOnly();
        private bool hasModuleId;
        private bool hasResult;
        private int memoizedSerializedSize = -1;
        private int moduleId_;
        public const int ModuleIdFieldNumber = 2;
        private uint result_;
        public const int ResultFieldNumber = 3;

        static ModuleNotification()
        {
            object.ReferenceEquals(AuthenticationService.Descriptor, null);
        }

        private ModuleNotification()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ModuleNotification prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ModuleNotification notification = obj as ModuleNotification;
            if (notification == null)
            {
                return false;
            }
            if ((this.hasModuleId != notification.hasModuleId) || (this.hasModuleId && !this.moduleId_.Equals(notification.moduleId_)))
            {
                return false;
            }
            return ((this.hasResult == notification.hasResult) && (!this.hasResult || this.result_.Equals(notification.result_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasModuleId)
            {
                hashCode ^= this.moduleId_.GetHashCode();
            }
            if (this.hasResult)
            {
                hashCode ^= this.result_.GetHashCode();
            }
            return hashCode;
        }

        private ModuleNotification MakeReadOnly()
        {
            return this;
        }

        public static ModuleNotification ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ModuleNotification ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ModuleNotification ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ModuleNotification ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ModuleNotification ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ModuleNotification ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ModuleNotification ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ModuleNotification ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ModuleNotification ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ModuleNotification ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ModuleNotification, Builder>.PrintField("module_id", this.hasModuleId, this.moduleId_, writer);
            GeneratedMessageLite<ModuleNotification, Builder>.PrintField("result", this.hasResult, this.result_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _moduleNotificationFieldNames;
            if (this.hasModuleId)
            {
                output.WriteInt32(2, strArray[0], this.ModuleId);
            }
            if (this.hasResult)
            {
                output.WriteUInt32(3, strArray[1], this.Result);
            }
        }

        public static ModuleNotification DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ModuleNotification DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasModuleId
        {
            get
            {
                return this.hasModuleId;
            }
        }

        public bool HasResult
        {
            get
            {
                return this.hasResult;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                return true;
            }
        }

        public int ModuleId
        {
            get
            {
                return this.moduleId_;
            }
        }

        [CLSCompliant(false)]
        public uint Result
        {
            get
            {
                return this.result_;
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
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.ModuleId);
                    }
                    if (this.hasResult)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(3, this.Result);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ModuleNotification ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<ModuleNotification, ModuleNotification.Builder>
        {
            private ModuleNotification result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ModuleNotification.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ModuleNotification cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override ModuleNotification BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ModuleNotification.Builder Clear()
            {
                this.result = ModuleNotification.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ModuleNotification.Builder ClearModuleId()
            {
                this.PrepareBuilder();
                this.result.hasModuleId = false;
                this.result.moduleId_ = 0;
                return this;
            }

            public ModuleNotification.Builder ClearResult()
            {
                this.PrepareBuilder();
                this.result.hasResult = false;
                this.result.result_ = 0;
                return this;
            }

            public override ModuleNotification.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ModuleNotification.Builder(this.result);
                }
                return new ModuleNotification.Builder().MergeFrom(this.result);
            }

            public override ModuleNotification.Builder MergeFrom(ModuleNotification other)
            {
                if (other != ModuleNotification.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasModuleId)
                    {
                        this.ModuleId = other.ModuleId;
                    }
                    if (other.HasResult)
                    {
                        this.Result = other.Result;
                    }
                }
                return this;
            }

            public override ModuleNotification.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ModuleNotification.Builder MergeFrom(IMessageLite other)
            {
                if (other is ModuleNotification)
                {
                    return this.MergeFrom((ModuleNotification) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ModuleNotification.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ModuleNotification._moduleNotificationFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ModuleNotification._moduleNotificationFieldTags[index];
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

                        case 0x10:
                        {
                            this.result.hasModuleId = input.ReadInt32(ref this.result.moduleId_);
                            continue;
                        }
                        case 0x18:
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
                    this.result.hasResult = input.ReadUInt32(ref this.result.result_);
                }
                return this;
            }

            private ModuleNotification PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ModuleNotification result = this.result;
                    this.result = new ModuleNotification();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ModuleNotification.Builder SetModuleId(int value)
            {
                this.PrepareBuilder();
                this.result.hasModuleId = true;
                this.result.moduleId_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public ModuleNotification.Builder SetResult(uint value)
            {
                this.PrepareBuilder();
                this.result.hasResult = true;
                this.result.result_ = value;
                return this;
            }

            public override ModuleNotification DefaultInstanceForType
            {
                get
                {
                    return ModuleNotification.DefaultInstance;
                }
            }

            public bool HasModuleId
            {
                get
                {
                    return this.result.hasModuleId;
                }
            }

            public bool HasResult
            {
                get
                {
                    return this.result.hasResult;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override ModuleNotification MessageBeingBuilt
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

            [CLSCompliant(false)]
            public uint Result
            {
                get
                {
                    return this.result.Result;
                }
                set
                {
                    this.SetResult(value);
                }
            }

            protected override ModuleNotification.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

