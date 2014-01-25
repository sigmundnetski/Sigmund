namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class SubmitBug : GeneratedMessageLite<SubmitBug, Builder>
    {
        private static readonly string[] _submitBugFieldNames = new string[] { "desc", "game_code_version", "game_data_version", "hostname", "subject", "username" };
        private static readonly uint[] _submitBugFieldTags = new uint[] { 0x12, 40, 50, 0x22, 10, 0x1a };
        private static readonly SubmitBug defaultInstance = new SubmitBug().MakeReadOnly();
        private string desc_ = string.Empty;
        public const int DescFieldNumber = 2;
        private int gameCodeVersion_;
        public const int GameCodeVersionFieldNumber = 5;
        private string gameDataVersion_ = string.Empty;
        public const int GameDataVersionFieldNumber = 6;
        private bool hasDesc;
        private bool hasGameCodeVersion;
        private bool hasGameDataVersion;
        private bool hasHostname;
        private bool hasSubject;
        private bool hasUsername;
        private string hostname_ = string.Empty;
        public const int HostnameFieldNumber = 4;
        private int memoizedSerializedSize = -1;
        private string subject_ = string.Empty;
        public const int SubjectFieldNumber = 1;
        private string username_ = string.Empty;
        public const int UsernameFieldNumber = 3;

        static SubmitBug()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private SubmitBug()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(SubmitBug prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            SubmitBug bug = obj as SubmitBug;
            if (bug == null)
            {
                return false;
            }
            if ((this.hasSubject != bug.hasSubject) || (this.hasSubject && !this.subject_.Equals(bug.subject_)))
            {
                return false;
            }
            if ((this.hasDesc != bug.hasDesc) || (this.hasDesc && !this.desc_.Equals(bug.desc_)))
            {
                return false;
            }
            if ((this.hasUsername != bug.hasUsername) || (this.hasUsername && !this.username_.Equals(bug.username_)))
            {
                return false;
            }
            if ((this.hasHostname != bug.hasHostname) || (this.hasHostname && !this.hostname_.Equals(bug.hostname_)))
            {
                return false;
            }
            if ((this.hasGameCodeVersion != bug.hasGameCodeVersion) || (this.hasGameCodeVersion && !this.gameCodeVersion_.Equals(bug.gameCodeVersion_)))
            {
                return false;
            }
            return ((this.hasGameDataVersion == bug.hasGameDataVersion) && (!this.hasGameDataVersion || this.gameDataVersion_.Equals(bug.gameDataVersion_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasSubject)
            {
                hashCode ^= this.subject_.GetHashCode();
            }
            if (this.hasDesc)
            {
                hashCode ^= this.desc_.GetHashCode();
            }
            if (this.hasUsername)
            {
                hashCode ^= this.username_.GetHashCode();
            }
            if (this.hasHostname)
            {
                hashCode ^= this.hostname_.GetHashCode();
            }
            if (this.hasGameCodeVersion)
            {
                hashCode ^= this.gameCodeVersion_.GetHashCode();
            }
            if (this.hasGameDataVersion)
            {
                hashCode ^= this.gameDataVersion_.GetHashCode();
            }
            return hashCode;
        }

        private SubmitBug MakeReadOnly()
        {
            return this;
        }

        public static SubmitBug ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static SubmitBug ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static SubmitBug ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static SubmitBug ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static SubmitBug ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static SubmitBug ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static SubmitBug ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static SubmitBug ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static SubmitBug ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static SubmitBug ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<SubmitBug, Builder>.PrintField("subject", this.hasSubject, this.subject_, writer);
            GeneratedMessageLite<SubmitBug, Builder>.PrintField("desc", this.hasDesc, this.desc_, writer);
            GeneratedMessageLite<SubmitBug, Builder>.PrintField("username", this.hasUsername, this.username_, writer);
            GeneratedMessageLite<SubmitBug, Builder>.PrintField("hostname", this.hasHostname, this.hostname_, writer);
            GeneratedMessageLite<SubmitBug, Builder>.PrintField("game_code_version", this.hasGameCodeVersion, this.gameCodeVersion_, writer);
            GeneratedMessageLite<SubmitBug, Builder>.PrintField("game_data_version", this.hasGameDataVersion, this.gameDataVersion_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _submitBugFieldNames;
            if (this.hasSubject)
            {
                output.WriteString(1, strArray[4], this.Subject);
            }
            if (this.hasDesc)
            {
                output.WriteString(2, strArray[0], this.Desc);
            }
            if (this.hasUsername)
            {
                output.WriteString(3, strArray[5], this.Username);
            }
            if (this.hasHostname)
            {
                output.WriteString(4, strArray[3], this.Hostname);
            }
            if (this.hasGameCodeVersion)
            {
                output.WriteInt32(5, strArray[1], this.GameCodeVersion);
            }
            if (this.hasGameDataVersion)
            {
                output.WriteString(6, strArray[2], this.GameDataVersion);
            }
        }

        public static SubmitBug DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override SubmitBug DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public string Desc
        {
            get
            {
                return this.desc_;
            }
        }

        public int GameCodeVersion
        {
            get
            {
                return this.gameCodeVersion_;
            }
        }

        public string GameDataVersion
        {
            get
            {
                return this.gameDataVersion_;
            }
        }

        public bool HasDesc
        {
            get
            {
                return this.hasDesc;
            }
        }

        public bool HasGameCodeVersion
        {
            get
            {
                return this.hasGameCodeVersion;
            }
        }

        public bool HasGameDataVersion
        {
            get
            {
                return this.hasGameDataVersion;
            }
        }

        public bool HasHostname
        {
            get
            {
                return this.hasHostname;
            }
        }

        public bool HasSubject
        {
            get
            {
                return this.hasSubject;
            }
        }

        public bool HasUsername
        {
            get
            {
                return this.hasUsername;
            }
        }

        public string Hostname
        {
            get
            {
                return this.hostname_;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasSubject)
                {
                    return false;
                }
                if (!this.hasDesc)
                {
                    return false;
                }
                if (!this.hasUsername)
                {
                    return false;
                }
                if (!this.hasHostname)
                {
                    return false;
                }
                if (!this.hasGameCodeVersion)
                {
                    return false;
                }
                if (!this.hasGameDataVersion)
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
                    if (this.hasSubject)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(1, this.Subject);
                    }
                    if (this.hasDesc)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(2, this.Desc);
                    }
                    if (this.hasUsername)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(3, this.Username);
                    }
                    if (this.hasHostname)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(4, this.Hostname);
                    }
                    if (this.hasGameCodeVersion)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(5, this.GameCodeVersion);
                    }
                    if (this.hasGameDataVersion)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(6, this.GameDataVersion);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        public string Subject
        {
            get
            {
                return this.subject_;
            }
        }

        protected override SubmitBug ThisMessage
        {
            get
            {
                return this;
            }
        }

        public string Username
        {
            get
            {
                return this.username_;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<SubmitBug, SubmitBug.Builder>
        {
            private SubmitBug result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = SubmitBug.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(SubmitBug cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override SubmitBug BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override SubmitBug.Builder Clear()
            {
                this.result = SubmitBug.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public SubmitBug.Builder ClearDesc()
            {
                this.PrepareBuilder();
                this.result.hasDesc = false;
                this.result.desc_ = string.Empty;
                return this;
            }

            public SubmitBug.Builder ClearGameCodeVersion()
            {
                this.PrepareBuilder();
                this.result.hasGameCodeVersion = false;
                this.result.gameCodeVersion_ = 0;
                return this;
            }

            public SubmitBug.Builder ClearGameDataVersion()
            {
                this.PrepareBuilder();
                this.result.hasGameDataVersion = false;
                this.result.gameDataVersion_ = string.Empty;
                return this;
            }

            public SubmitBug.Builder ClearHostname()
            {
                this.PrepareBuilder();
                this.result.hasHostname = false;
                this.result.hostname_ = string.Empty;
                return this;
            }

            public SubmitBug.Builder ClearSubject()
            {
                this.PrepareBuilder();
                this.result.hasSubject = false;
                this.result.subject_ = string.Empty;
                return this;
            }

            public SubmitBug.Builder ClearUsername()
            {
                this.PrepareBuilder();
                this.result.hasUsername = false;
                this.result.username_ = string.Empty;
                return this;
            }

            public override SubmitBug.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new SubmitBug.Builder(this.result);
                }
                return new SubmitBug.Builder().MergeFrom(this.result);
            }

            public override SubmitBug.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override SubmitBug.Builder MergeFrom(IMessageLite other)
            {
                if (other is SubmitBug)
                {
                    return this.MergeFrom((SubmitBug) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override SubmitBug.Builder MergeFrom(SubmitBug other)
            {
                if (other != SubmitBug.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasSubject)
                    {
                        this.Subject = other.Subject;
                    }
                    if (other.HasDesc)
                    {
                        this.Desc = other.Desc;
                    }
                    if (other.HasUsername)
                    {
                        this.Username = other.Username;
                    }
                    if (other.HasHostname)
                    {
                        this.Hostname = other.Hostname;
                    }
                    if (other.HasGameCodeVersion)
                    {
                        this.GameCodeVersion = other.GameCodeVersion;
                    }
                    if (other.HasGameDataVersion)
                    {
                        this.GameDataVersion = other.GameDataVersion;
                    }
                }
                return this;
            }

            public override SubmitBug.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(SubmitBug._submitBugFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = SubmitBug._submitBugFieldTags[index];
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
                            this.result.hasSubject = input.ReadString(ref this.result.subject_);
                            continue;
                        }
                        case 0x12:
                        {
                            this.result.hasDesc = input.ReadString(ref this.result.desc_);
                            continue;
                        }
                        case 0x1a:
                        {
                            this.result.hasUsername = input.ReadString(ref this.result.username_);
                            continue;
                        }
                        case 0x22:
                        {
                            this.result.hasHostname = input.ReadString(ref this.result.hostname_);
                            continue;
                        }
                        case 40:
                        {
                            this.result.hasGameCodeVersion = input.ReadInt32(ref this.result.gameCodeVersion_);
                            continue;
                        }
                        case 50:
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
                    this.result.hasGameDataVersion = input.ReadString(ref this.result.gameDataVersion_);
                }
                return this;
            }

            private SubmitBug PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    SubmitBug result = this.result;
                    this.result = new SubmitBug();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public SubmitBug.Builder SetDesc(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasDesc = true;
                this.result.desc_ = value;
                return this;
            }

            public SubmitBug.Builder SetGameCodeVersion(int value)
            {
                this.PrepareBuilder();
                this.result.hasGameCodeVersion = true;
                this.result.gameCodeVersion_ = value;
                return this;
            }

            public SubmitBug.Builder SetGameDataVersion(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasGameDataVersion = true;
                this.result.gameDataVersion_ = value;
                return this;
            }

            public SubmitBug.Builder SetHostname(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasHostname = true;
                this.result.hostname_ = value;
                return this;
            }

            public SubmitBug.Builder SetSubject(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasSubject = true;
                this.result.subject_ = value;
                return this;
            }

            public SubmitBug.Builder SetUsername(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasUsername = true;
                this.result.username_ = value;
                return this;
            }

            public override SubmitBug DefaultInstanceForType
            {
                get
                {
                    return SubmitBug.DefaultInstance;
                }
            }

            public string Desc
            {
                get
                {
                    return this.result.Desc;
                }
                set
                {
                    this.SetDesc(value);
                }
            }

            public int GameCodeVersion
            {
                get
                {
                    return this.result.GameCodeVersion;
                }
                set
                {
                    this.SetGameCodeVersion(value);
                }
            }

            public string GameDataVersion
            {
                get
                {
                    return this.result.GameDataVersion;
                }
                set
                {
                    this.SetGameDataVersion(value);
                }
            }

            public bool HasDesc
            {
                get
                {
                    return this.result.hasDesc;
                }
            }

            public bool HasGameCodeVersion
            {
                get
                {
                    return this.result.hasGameCodeVersion;
                }
            }

            public bool HasGameDataVersion
            {
                get
                {
                    return this.result.hasGameDataVersion;
                }
            }

            public bool HasHostname
            {
                get
                {
                    return this.result.hasHostname;
                }
            }

            public bool HasSubject
            {
                get
                {
                    return this.result.hasSubject;
                }
            }

            public bool HasUsername
            {
                get
                {
                    return this.result.hasUsername;
                }
            }

            public string Hostname
            {
                get
                {
                    return this.result.Hostname;
                }
                set
                {
                    this.SetHostname(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override SubmitBug MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public string Subject
            {
                get
                {
                    return this.result.Subject;
                }
                set
                {
                    this.SetSubject(value);
                }
            }

            protected override SubmitBug.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public string Username
            {
                get
                {
                    return this.result.Username;
                }
                set
                {
                    this.SetUsername(value);
                }
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0xe5,
                System = 0
            }
        }
    }
}

