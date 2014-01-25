namespace bnet.protocol.authentication
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class VersionInfo : GeneratedMessageLite<VersionInfo, Builder>
    {
        private static readonly string[] _versionInfoFieldNames = new string[] { "is_optional", "kick_time", "number", "patch" };
        private static readonly uint[] _versionInfoFieldTags = new uint[] { 0x18, 0x20, 8, 0x12 };
        private static readonly VersionInfo defaultInstance = new VersionInfo().MakeReadOnly();
        private bool hasIsOptional;
        private bool hasKickTime;
        private bool hasNumber;
        private bool hasPatch;
        private bool isOptional_;
        public const int IsOptionalFieldNumber = 3;
        private ulong kickTime_;
        public const int KickTimeFieldNumber = 4;
        private int memoizedSerializedSize = -1;
        private uint number_;
        public const int NumberFieldNumber = 1;
        private string patch_ = string.Empty;
        public const int PatchFieldNumber = 2;

        static VersionInfo()
        {
            object.ReferenceEquals(AuthenticationService.Descriptor, null);
        }

        private VersionInfo()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(VersionInfo prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            VersionInfo info = obj as VersionInfo;
            if (info == null)
            {
                return false;
            }
            if ((this.hasNumber != info.hasNumber) || (this.hasNumber && !this.number_.Equals(info.number_)))
            {
                return false;
            }
            if ((this.hasPatch != info.hasPatch) || (this.hasPatch && !this.patch_.Equals(info.patch_)))
            {
                return false;
            }
            if ((this.hasIsOptional != info.hasIsOptional) || (this.hasIsOptional && !this.isOptional_.Equals(info.isOptional_)))
            {
                return false;
            }
            return ((this.hasKickTime == info.hasKickTime) && (!this.hasKickTime || this.kickTime_.Equals(info.kickTime_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasNumber)
            {
                hashCode ^= this.number_.GetHashCode();
            }
            if (this.hasPatch)
            {
                hashCode ^= this.patch_.GetHashCode();
            }
            if (this.hasIsOptional)
            {
                hashCode ^= this.isOptional_.GetHashCode();
            }
            if (this.hasKickTime)
            {
                hashCode ^= this.kickTime_.GetHashCode();
            }
            return hashCode;
        }

        private VersionInfo MakeReadOnly()
        {
            return this;
        }

        public static VersionInfo ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static VersionInfo ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static VersionInfo ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static VersionInfo ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static VersionInfo ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static VersionInfo ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static VersionInfo ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static VersionInfo ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static VersionInfo ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static VersionInfo ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<VersionInfo, Builder>.PrintField("number", this.hasNumber, this.number_, writer);
            GeneratedMessageLite<VersionInfo, Builder>.PrintField("patch", this.hasPatch, this.patch_, writer);
            GeneratedMessageLite<VersionInfo, Builder>.PrintField("is_optional", this.hasIsOptional, this.isOptional_, writer);
            GeneratedMessageLite<VersionInfo, Builder>.PrintField("kick_time", this.hasKickTime, this.kickTime_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _versionInfoFieldNames;
            if (this.hasNumber)
            {
                output.WriteUInt32(1, strArray[2], this.Number);
            }
            if (this.hasPatch)
            {
                output.WriteString(2, strArray[3], this.Patch);
            }
            if (this.hasIsOptional)
            {
                output.WriteBool(3, strArray[0], this.IsOptional);
            }
            if (this.hasKickTime)
            {
                output.WriteUInt64(4, strArray[1], this.KickTime);
            }
        }

        public static VersionInfo DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override VersionInfo DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasIsOptional
        {
            get
            {
                return this.hasIsOptional;
            }
        }

        public bool HasKickTime
        {
            get
            {
                return this.hasKickTime;
            }
        }

        public bool HasNumber
        {
            get
            {
                return this.hasNumber;
            }
        }

        public bool HasPatch
        {
            get
            {
                return this.hasPatch;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                return true;
            }
        }

        public bool IsOptional
        {
            get
            {
                return this.isOptional_;
            }
        }

        [CLSCompliant(false)]
        public ulong KickTime
        {
            get
            {
                return this.kickTime_;
            }
        }

        [CLSCompliant(false)]
        public uint Number
        {
            get
            {
                return this.number_;
            }
        }

        public string Patch
        {
            get
            {
                return this.patch_;
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
                    if (this.hasNumber)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(1, this.Number);
                    }
                    if (this.hasPatch)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(2, this.Patch);
                    }
                    if (this.hasIsOptional)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(3, this.IsOptional);
                    }
                    if (this.hasKickTime)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(4, this.KickTime);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override VersionInfo ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<VersionInfo, VersionInfo.Builder>
        {
            private VersionInfo result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = VersionInfo.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(VersionInfo cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override VersionInfo BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override VersionInfo.Builder Clear()
            {
                this.result = VersionInfo.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public VersionInfo.Builder ClearIsOptional()
            {
                this.PrepareBuilder();
                this.result.hasIsOptional = false;
                this.result.isOptional_ = false;
                return this;
            }

            public VersionInfo.Builder ClearKickTime()
            {
                this.PrepareBuilder();
                this.result.hasKickTime = false;
                this.result.kickTime_ = 0L;
                return this;
            }

            public VersionInfo.Builder ClearNumber()
            {
                this.PrepareBuilder();
                this.result.hasNumber = false;
                this.result.number_ = 0;
                return this;
            }

            public VersionInfo.Builder ClearPatch()
            {
                this.PrepareBuilder();
                this.result.hasPatch = false;
                this.result.patch_ = string.Empty;
                return this;
            }

            public override VersionInfo.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new VersionInfo.Builder(this.result);
                }
                return new VersionInfo.Builder().MergeFrom(this.result);
            }

            public override VersionInfo.Builder MergeFrom(VersionInfo other)
            {
                if (other != VersionInfo.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasNumber)
                    {
                        this.Number = other.Number;
                    }
                    if (other.HasPatch)
                    {
                        this.Patch = other.Patch;
                    }
                    if (other.HasIsOptional)
                    {
                        this.IsOptional = other.IsOptional;
                    }
                    if (other.HasKickTime)
                    {
                        this.KickTime = other.KickTime;
                    }
                }
                return this;
            }

            public override VersionInfo.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override VersionInfo.Builder MergeFrom(IMessageLite other)
            {
                if (other is VersionInfo)
                {
                    return this.MergeFrom((VersionInfo) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override VersionInfo.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(VersionInfo._versionInfoFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = VersionInfo._versionInfoFieldTags[index];
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
                            this.result.hasNumber = input.ReadUInt32(ref this.result.number_);
                            continue;
                        }
                        case 0x12:
                        {
                            this.result.hasPatch = input.ReadString(ref this.result.patch_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasIsOptional = input.ReadBool(ref this.result.isOptional_);
                            continue;
                        }
                        case 0x20:
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
                    this.result.hasKickTime = input.ReadUInt64(ref this.result.kickTime_);
                }
                return this;
            }

            private VersionInfo PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    VersionInfo result = this.result;
                    this.result = new VersionInfo();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public VersionInfo.Builder SetIsOptional(bool value)
            {
                this.PrepareBuilder();
                this.result.hasIsOptional = true;
                this.result.isOptional_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public VersionInfo.Builder SetKickTime(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasKickTime = true;
                this.result.kickTime_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public VersionInfo.Builder SetNumber(uint value)
            {
                this.PrepareBuilder();
                this.result.hasNumber = true;
                this.result.number_ = value;
                return this;
            }

            public VersionInfo.Builder SetPatch(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasPatch = true;
                this.result.patch_ = value;
                return this;
            }

            public override VersionInfo DefaultInstanceForType
            {
                get
                {
                    return VersionInfo.DefaultInstance;
                }
            }

            public bool HasIsOptional
            {
                get
                {
                    return this.result.hasIsOptional;
                }
            }

            public bool HasKickTime
            {
                get
                {
                    return this.result.hasKickTime;
                }
            }

            public bool HasNumber
            {
                get
                {
                    return this.result.hasNumber;
                }
            }

            public bool HasPatch
            {
                get
                {
                    return this.result.hasPatch;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public bool IsOptional
            {
                get
                {
                    return this.result.IsOptional;
                }
                set
                {
                    this.SetIsOptional(value);
                }
            }

            [CLSCompliant(false)]
            public ulong KickTime
            {
                get
                {
                    return this.result.KickTime;
                }
                set
                {
                    this.SetKickTime(value);
                }
            }

            protected override VersionInfo MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            [CLSCompliant(false)]
            public uint Number
            {
                get
                {
                    return this.result.Number;
                }
                set
                {
                    this.SetNumber(value);
                }
            }

            public string Patch
            {
                get
                {
                    return this.result.Patch;
                }
                set
                {
                    this.SetPatch(value);
                }
            }

            protected override VersionInfo.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

