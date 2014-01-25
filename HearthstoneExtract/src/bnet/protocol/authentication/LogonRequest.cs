namespace bnet.protocol.authentication
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class LogonRequest : GeneratedMessageLite<LogonRequest, Builder>
    {
        private static readonly string[] _logonRequestFieldNames = new string[] { "application_version", "email", "locale", "platform", "program", "public_computer", "sso_id", "version" };
        private static readonly uint[] _logonRequestFieldTags = new uint[] { 0x30, 0x22, 0x1a, 0x12, 10, 0x38, 0x42, 0x2a };
        private int applicationVersion_;
        public const int ApplicationVersionFieldNumber = 6;
        private static readonly LogonRequest defaultInstance = new LogonRequest().MakeReadOnly();
        private string email_ = string.Empty;
        public const int EmailFieldNumber = 4;
        private bool hasApplicationVersion;
        private bool hasEmail;
        private bool hasLocale;
        private bool hasPlatform;
        private bool hasProgram;
        private bool hasPublicComputer;
        private bool hasSsoId;
        private bool hasVersion;
        private string locale_ = string.Empty;
        public const int LocaleFieldNumber = 3;
        private int memoizedSerializedSize = -1;
        private string platform_ = string.Empty;
        public const int PlatformFieldNumber = 2;
        private string program_ = string.Empty;
        public const int ProgramFieldNumber = 1;
        private bool publicComputer_;
        public const int PublicComputerFieldNumber = 7;
        private ByteString ssoId_ = ByteString.Empty;
        public const int SsoIdFieldNumber = 8;
        private string version_ = string.Empty;
        public const int VersionFieldNumber = 5;

        static LogonRequest()
        {
            object.ReferenceEquals(AuthenticationService.Descriptor, null);
        }

        private LogonRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(LogonRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            LogonRequest request = obj as LogonRequest;
            if (request == null)
            {
                return false;
            }
            if ((this.hasProgram != request.hasProgram) || (this.hasProgram && !this.program_.Equals(request.program_)))
            {
                return false;
            }
            if ((this.hasPlatform != request.hasPlatform) || (this.hasPlatform && !this.platform_.Equals(request.platform_)))
            {
                return false;
            }
            if ((this.hasLocale != request.hasLocale) || (this.hasLocale && !this.locale_.Equals(request.locale_)))
            {
                return false;
            }
            if ((this.hasEmail != request.hasEmail) || (this.hasEmail && !this.email_.Equals(request.email_)))
            {
                return false;
            }
            if ((this.hasVersion != request.hasVersion) || (this.hasVersion && !this.version_.Equals(request.version_)))
            {
                return false;
            }
            if ((this.hasApplicationVersion != request.hasApplicationVersion) || (this.hasApplicationVersion && !this.applicationVersion_.Equals(request.applicationVersion_)))
            {
                return false;
            }
            if ((this.hasPublicComputer != request.hasPublicComputer) || (this.hasPublicComputer && !this.publicComputer_.Equals(request.publicComputer_)))
            {
                return false;
            }
            return ((this.hasSsoId == request.hasSsoId) && (!this.hasSsoId || this.ssoId_.Equals(request.ssoId_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasProgram)
            {
                hashCode ^= this.program_.GetHashCode();
            }
            if (this.hasPlatform)
            {
                hashCode ^= this.platform_.GetHashCode();
            }
            if (this.hasLocale)
            {
                hashCode ^= this.locale_.GetHashCode();
            }
            if (this.hasEmail)
            {
                hashCode ^= this.email_.GetHashCode();
            }
            if (this.hasVersion)
            {
                hashCode ^= this.version_.GetHashCode();
            }
            if (this.hasApplicationVersion)
            {
                hashCode ^= this.applicationVersion_.GetHashCode();
            }
            if (this.hasPublicComputer)
            {
                hashCode ^= this.publicComputer_.GetHashCode();
            }
            if (this.hasSsoId)
            {
                hashCode ^= this.ssoId_.GetHashCode();
            }
            return hashCode;
        }

        private LogonRequest MakeReadOnly()
        {
            return this;
        }

        public static LogonRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static LogonRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static LogonRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static LogonRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static LogonRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static LogonRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static LogonRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static LogonRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static LogonRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static LogonRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<LogonRequest, Builder>.PrintField("program", this.hasProgram, this.program_, writer);
            GeneratedMessageLite<LogonRequest, Builder>.PrintField("platform", this.hasPlatform, this.platform_, writer);
            GeneratedMessageLite<LogonRequest, Builder>.PrintField("locale", this.hasLocale, this.locale_, writer);
            GeneratedMessageLite<LogonRequest, Builder>.PrintField("email", this.hasEmail, this.email_, writer);
            GeneratedMessageLite<LogonRequest, Builder>.PrintField("version", this.hasVersion, this.version_, writer);
            GeneratedMessageLite<LogonRequest, Builder>.PrintField("application_version", this.hasApplicationVersion, this.applicationVersion_, writer);
            GeneratedMessageLite<LogonRequest, Builder>.PrintField("public_computer", this.hasPublicComputer, this.publicComputer_, writer);
            GeneratedMessageLite<LogonRequest, Builder>.PrintField("sso_id", this.hasSsoId, this.ssoId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _logonRequestFieldNames;
            if (this.hasProgram)
            {
                output.WriteString(1, strArray[4], this.Program);
            }
            if (this.hasPlatform)
            {
                output.WriteString(2, strArray[3], this.Platform);
            }
            if (this.hasLocale)
            {
                output.WriteString(3, strArray[2], this.Locale);
            }
            if (this.hasEmail)
            {
                output.WriteString(4, strArray[1], this.Email);
            }
            if (this.hasVersion)
            {
                output.WriteString(5, strArray[7], this.Version);
            }
            if (this.hasApplicationVersion)
            {
                output.WriteInt32(6, strArray[0], this.ApplicationVersion);
            }
            if (this.hasPublicComputer)
            {
                output.WriteBool(7, strArray[5], this.PublicComputer);
            }
            if (this.hasSsoId)
            {
                output.WriteBytes(8, strArray[6], this.SsoId);
            }
        }

        public int ApplicationVersion
        {
            get
            {
                return this.applicationVersion_;
            }
        }

        public static LogonRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override LogonRequest DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public string Email
        {
            get
            {
                return this.email_;
            }
        }

        public bool HasApplicationVersion
        {
            get
            {
                return this.hasApplicationVersion;
            }
        }

        public bool HasEmail
        {
            get
            {
                return this.hasEmail;
            }
        }

        public bool HasLocale
        {
            get
            {
                return this.hasLocale;
            }
        }

        public bool HasPlatform
        {
            get
            {
                return this.hasPlatform;
            }
        }

        public bool HasProgram
        {
            get
            {
                return this.hasProgram;
            }
        }

        public bool HasPublicComputer
        {
            get
            {
                return this.hasPublicComputer;
            }
        }

        public bool HasSsoId
        {
            get
            {
                return this.hasSsoId;
            }
        }

        public bool HasVersion
        {
            get
            {
                return this.hasVersion;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                return true;
            }
        }

        public string Locale
        {
            get
            {
                return this.locale_;
            }
        }

        public string Platform
        {
            get
            {
                return this.platform_;
            }
        }

        public string Program
        {
            get
            {
                return this.program_;
            }
        }

        public bool PublicComputer
        {
            get
            {
                return this.publicComputer_;
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
                    if (this.hasProgram)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(1, this.Program);
                    }
                    if (this.hasPlatform)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(2, this.Platform);
                    }
                    if (this.hasLocale)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(3, this.Locale);
                    }
                    if (this.hasEmail)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(4, this.Email);
                    }
                    if (this.hasVersion)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(5, this.Version);
                    }
                    if (this.hasApplicationVersion)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(6, this.ApplicationVersion);
                    }
                    if (this.hasPublicComputer)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(7, this.PublicComputer);
                    }
                    if (this.hasSsoId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBytesSize(8, this.SsoId);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        public ByteString SsoId
        {
            get
            {
                return this.ssoId_;
            }
        }

        protected override LogonRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        public string Version
        {
            get
            {
                return this.version_;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<LogonRequest, LogonRequest.Builder>
        {
            private LogonRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = LogonRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(LogonRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override LogonRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override LogonRequest.Builder Clear()
            {
                this.result = LogonRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public LogonRequest.Builder ClearApplicationVersion()
            {
                this.PrepareBuilder();
                this.result.hasApplicationVersion = false;
                this.result.applicationVersion_ = 0;
                return this;
            }

            public LogonRequest.Builder ClearEmail()
            {
                this.PrepareBuilder();
                this.result.hasEmail = false;
                this.result.email_ = string.Empty;
                return this;
            }

            public LogonRequest.Builder ClearLocale()
            {
                this.PrepareBuilder();
                this.result.hasLocale = false;
                this.result.locale_ = string.Empty;
                return this;
            }

            public LogonRequest.Builder ClearPlatform()
            {
                this.PrepareBuilder();
                this.result.hasPlatform = false;
                this.result.platform_ = string.Empty;
                return this;
            }

            public LogonRequest.Builder ClearProgram()
            {
                this.PrepareBuilder();
                this.result.hasProgram = false;
                this.result.program_ = string.Empty;
                return this;
            }

            public LogonRequest.Builder ClearPublicComputer()
            {
                this.PrepareBuilder();
                this.result.hasPublicComputer = false;
                this.result.publicComputer_ = false;
                return this;
            }

            public LogonRequest.Builder ClearSsoId()
            {
                this.PrepareBuilder();
                this.result.hasSsoId = false;
                this.result.ssoId_ = ByteString.Empty;
                return this;
            }

            public LogonRequest.Builder ClearVersion()
            {
                this.PrepareBuilder();
                this.result.hasVersion = false;
                this.result.version_ = string.Empty;
                return this;
            }

            public override LogonRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new LogonRequest.Builder(this.result);
                }
                return new LogonRequest.Builder().MergeFrom(this.result);
            }

            public override LogonRequest.Builder MergeFrom(LogonRequest other)
            {
                if (other != LogonRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasProgram)
                    {
                        this.Program = other.Program;
                    }
                    if (other.HasPlatform)
                    {
                        this.Platform = other.Platform;
                    }
                    if (other.HasLocale)
                    {
                        this.Locale = other.Locale;
                    }
                    if (other.HasEmail)
                    {
                        this.Email = other.Email;
                    }
                    if (other.HasVersion)
                    {
                        this.Version = other.Version;
                    }
                    if (other.HasApplicationVersion)
                    {
                        this.ApplicationVersion = other.ApplicationVersion;
                    }
                    if (other.HasPublicComputer)
                    {
                        this.PublicComputer = other.PublicComputer;
                    }
                    if (other.HasSsoId)
                    {
                        this.SsoId = other.SsoId;
                    }
                }
                return this;
            }

            public override LogonRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override LogonRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is LogonRequest)
                {
                    return this.MergeFrom((LogonRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override LogonRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(LogonRequest._logonRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = LogonRequest._logonRequestFieldTags[index];
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
                            this.result.hasProgram = input.ReadString(ref this.result.program_);
                            continue;
                        }
                        case 0x12:
                        {
                            this.result.hasPlatform = input.ReadString(ref this.result.platform_);
                            continue;
                        }
                        case 0x1a:
                        {
                            this.result.hasLocale = input.ReadString(ref this.result.locale_);
                            continue;
                        }
                        case 0x22:
                        {
                            this.result.hasEmail = input.ReadString(ref this.result.email_);
                            continue;
                        }
                        case 0x2a:
                        {
                            this.result.hasVersion = input.ReadString(ref this.result.version_);
                            continue;
                        }
                        case 0x30:
                        {
                            this.result.hasApplicationVersion = input.ReadInt32(ref this.result.applicationVersion_);
                            continue;
                        }
                        case 0x38:
                        {
                            this.result.hasPublicComputer = input.ReadBool(ref this.result.publicComputer_);
                            continue;
                        }
                        case 0x42:
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
                    this.result.hasSsoId = input.ReadBytes(ref this.result.ssoId_);
                }
                return this;
            }

            private LogonRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    LogonRequest result = this.result;
                    this.result = new LogonRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public LogonRequest.Builder SetApplicationVersion(int value)
            {
                this.PrepareBuilder();
                this.result.hasApplicationVersion = true;
                this.result.applicationVersion_ = value;
                return this;
            }

            public LogonRequest.Builder SetEmail(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasEmail = true;
                this.result.email_ = value;
                return this;
            }

            public LogonRequest.Builder SetLocale(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasLocale = true;
                this.result.locale_ = value;
                return this;
            }

            public LogonRequest.Builder SetPlatform(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasPlatform = true;
                this.result.platform_ = value;
                return this;
            }

            public LogonRequest.Builder SetProgram(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasProgram = true;
                this.result.program_ = value;
                return this;
            }

            public LogonRequest.Builder SetPublicComputer(bool value)
            {
                this.PrepareBuilder();
                this.result.hasPublicComputer = true;
                this.result.publicComputer_ = value;
                return this;
            }

            public LogonRequest.Builder SetSsoId(ByteString value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasSsoId = true;
                this.result.ssoId_ = value;
                return this;
            }

            public LogonRequest.Builder SetVersion(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasVersion = true;
                this.result.version_ = value;
                return this;
            }

            public int ApplicationVersion
            {
                get
                {
                    return this.result.ApplicationVersion;
                }
                set
                {
                    this.SetApplicationVersion(value);
                }
            }

            public override LogonRequest DefaultInstanceForType
            {
                get
                {
                    return LogonRequest.DefaultInstance;
                }
            }

            public string Email
            {
                get
                {
                    return this.result.Email;
                }
                set
                {
                    this.SetEmail(value);
                }
            }

            public bool HasApplicationVersion
            {
                get
                {
                    return this.result.hasApplicationVersion;
                }
            }

            public bool HasEmail
            {
                get
                {
                    return this.result.hasEmail;
                }
            }

            public bool HasLocale
            {
                get
                {
                    return this.result.hasLocale;
                }
            }

            public bool HasPlatform
            {
                get
                {
                    return this.result.hasPlatform;
                }
            }

            public bool HasProgram
            {
                get
                {
                    return this.result.hasProgram;
                }
            }

            public bool HasPublicComputer
            {
                get
                {
                    return this.result.hasPublicComputer;
                }
            }

            public bool HasSsoId
            {
                get
                {
                    return this.result.hasSsoId;
                }
            }

            public bool HasVersion
            {
                get
                {
                    return this.result.hasVersion;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public string Locale
            {
                get
                {
                    return this.result.Locale;
                }
                set
                {
                    this.SetLocale(value);
                }
            }

            protected override LogonRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public string Platform
            {
                get
                {
                    return this.result.Platform;
                }
                set
                {
                    this.SetPlatform(value);
                }
            }

            public string Program
            {
                get
                {
                    return this.result.Program;
                }
                set
                {
                    this.SetProgram(value);
                }
            }

            public bool PublicComputer
            {
                get
                {
                    return this.result.PublicComputer;
                }
                set
                {
                    this.SetPublicComputer(value);
                }
            }

            public ByteString SsoId
            {
                get
                {
                    return this.result.SsoId;
                }
                set
                {
                    this.SetSsoId(value);
                }
            }

            protected override LogonRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public string Version
            {
                get
                {
                    return this.result.Version;
                }
                set
                {
                    this.SetVersion(value);
                }
            }
        }
    }
}

