namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class AutoLogin : GeneratedMessageLite<AutoLogin, Builder>
    {
        private static readonly string[] _autoLoginFieldNames = new string[] { "build_id", "debug_name", "pwd", "source", "user" };
        private static readonly uint[] _autoLoginFieldTags = new uint[] { 0x18, 0x22, 0x12, 40, 10 };
        private int buildId_;
        public const int BuildIdFieldNumber = 3;
        private string debugName_ = string.Empty;
        public const int DebugNameFieldNumber = 4;
        private static readonly AutoLogin defaultInstance = new AutoLogin().MakeReadOnly();
        private bool hasBuildId;
        private bool hasDebugName;
        private bool hasPwd;
        private bool hasSource;
        private bool hasUser;
        private int memoizedSerializedSize = -1;
        private string pwd_ = string.Empty;
        public const int PwdFieldNumber = 2;
        private int source_;
        public const int SourceFieldNumber = 5;
        private string user_ = string.Empty;
        public const int UserFieldNumber = 1;

        static AutoLogin()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private AutoLogin()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AutoLogin prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AutoLogin login = obj as AutoLogin;
            if (login == null)
            {
                return false;
            }
            if ((this.hasUser != login.hasUser) || (this.hasUser && !this.user_.Equals(login.user_)))
            {
                return false;
            }
            if ((this.hasPwd != login.hasPwd) || (this.hasPwd && !this.pwd_.Equals(login.pwd_)))
            {
                return false;
            }
            if ((this.hasBuildId != login.hasBuildId) || (this.hasBuildId && !this.buildId_.Equals(login.buildId_)))
            {
                return false;
            }
            if ((this.hasDebugName != login.hasDebugName) || (this.hasDebugName && !this.debugName_.Equals(login.debugName_)))
            {
                return false;
            }
            return ((this.hasSource == login.hasSource) && (!this.hasSource || this.source_.Equals(login.source_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasUser)
            {
                hashCode ^= this.user_.GetHashCode();
            }
            if (this.hasPwd)
            {
                hashCode ^= this.pwd_.GetHashCode();
            }
            if (this.hasBuildId)
            {
                hashCode ^= this.buildId_.GetHashCode();
            }
            if (this.hasDebugName)
            {
                hashCode ^= this.debugName_.GetHashCode();
            }
            if (this.hasSource)
            {
                hashCode ^= this.source_.GetHashCode();
            }
            return hashCode;
        }

        private AutoLogin MakeReadOnly()
        {
            return this;
        }

        public static AutoLogin ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AutoLogin ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AutoLogin ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AutoLogin ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AutoLogin ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AutoLogin ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AutoLogin ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AutoLogin ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AutoLogin ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AutoLogin ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AutoLogin, Builder>.PrintField("user", this.hasUser, this.user_, writer);
            GeneratedMessageLite<AutoLogin, Builder>.PrintField("pwd", this.hasPwd, this.pwd_, writer);
            GeneratedMessageLite<AutoLogin, Builder>.PrintField("build_id", this.hasBuildId, this.buildId_, writer);
            GeneratedMessageLite<AutoLogin, Builder>.PrintField("debug_name", this.hasDebugName, this.debugName_, writer);
            GeneratedMessageLite<AutoLogin, Builder>.PrintField("source", this.hasSource, this.source_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _autoLoginFieldNames;
            if (this.hasUser)
            {
                output.WriteString(1, strArray[4], this.User);
            }
            if (this.hasPwd)
            {
                output.WriteString(2, strArray[2], this.Pwd);
            }
            if (this.hasBuildId)
            {
                output.WriteInt32(3, strArray[0], this.BuildId);
            }
            if (this.hasDebugName)
            {
                output.WriteString(4, strArray[1], this.DebugName);
            }
            if (this.hasSource)
            {
                output.WriteInt32(5, strArray[3], this.Source);
            }
        }

        public int BuildId
        {
            get
            {
                return this.buildId_;
            }
        }

        public string DebugName
        {
            get
            {
                return this.debugName_;
            }
        }

        public static AutoLogin DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AutoLogin DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasBuildId
        {
            get
            {
                return this.hasBuildId;
            }
        }

        public bool HasDebugName
        {
            get
            {
                return this.hasDebugName;
            }
        }

        public bool HasPwd
        {
            get
            {
                return this.hasPwd;
            }
        }

        public bool HasSource
        {
            get
            {
                return this.hasSource;
            }
        }

        public bool HasUser
        {
            get
            {
                return this.hasUser;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasUser)
                {
                    return false;
                }
                if (!this.hasPwd)
                {
                    return false;
                }
                if (!this.hasBuildId)
                {
                    return false;
                }
                if (!this.hasDebugName)
                {
                    return false;
                }
                if (!this.hasSource)
                {
                    return false;
                }
                return true;
            }
        }

        public string Pwd
        {
            get
            {
                return this.pwd_;
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
                    if (this.hasUser)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(1, this.User);
                    }
                    if (this.hasPwd)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(2, this.Pwd);
                    }
                    if (this.hasBuildId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(3, this.BuildId);
                    }
                    if (this.hasDebugName)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(4, this.DebugName);
                    }
                    if (this.hasSource)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(5, this.Source);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        public int Source
        {
            get
            {
                return this.source_;
            }
        }

        protected override AutoLogin ThisMessage
        {
            get
            {
                return this;
            }
        }

        public string User
        {
            get
            {
                return this.user_;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<AutoLogin, AutoLogin.Builder>
        {
            private AutoLogin result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AutoLogin.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AutoLogin cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override AutoLogin BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AutoLogin.Builder Clear()
            {
                this.result = AutoLogin.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AutoLogin.Builder ClearBuildId()
            {
                this.PrepareBuilder();
                this.result.hasBuildId = false;
                this.result.buildId_ = 0;
                return this;
            }

            public AutoLogin.Builder ClearDebugName()
            {
                this.PrepareBuilder();
                this.result.hasDebugName = false;
                this.result.debugName_ = string.Empty;
                return this;
            }

            public AutoLogin.Builder ClearPwd()
            {
                this.PrepareBuilder();
                this.result.hasPwd = false;
                this.result.pwd_ = string.Empty;
                return this;
            }

            public AutoLogin.Builder ClearSource()
            {
                this.PrepareBuilder();
                this.result.hasSource = false;
                this.result.source_ = 0;
                return this;
            }

            public AutoLogin.Builder ClearUser()
            {
                this.PrepareBuilder();
                this.result.hasUser = false;
                this.result.user_ = string.Empty;
                return this;
            }

            public override AutoLogin.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AutoLogin.Builder(this.result);
                }
                return new AutoLogin.Builder().MergeFrom(this.result);
            }

            public override AutoLogin.Builder MergeFrom(AutoLogin other)
            {
                if (other != AutoLogin.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasUser)
                    {
                        this.User = other.User;
                    }
                    if (other.HasPwd)
                    {
                        this.Pwd = other.Pwd;
                    }
                    if (other.HasBuildId)
                    {
                        this.BuildId = other.BuildId;
                    }
                    if (other.HasDebugName)
                    {
                        this.DebugName = other.DebugName;
                    }
                    if (other.HasSource)
                    {
                        this.Source = other.Source;
                    }
                }
                return this;
            }

            public override AutoLogin.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AutoLogin.Builder MergeFrom(IMessageLite other)
            {
                if (other is AutoLogin)
                {
                    return this.MergeFrom((AutoLogin) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AutoLogin.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AutoLogin._autoLoginFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AutoLogin._autoLoginFieldTags[index];
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
                            this.result.hasUser = input.ReadString(ref this.result.user_);
                            continue;
                        }
                        case 0x12:
                        {
                            this.result.hasPwd = input.ReadString(ref this.result.pwd_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasBuildId = input.ReadInt32(ref this.result.buildId_);
                            continue;
                        }
                        case 0x22:
                        {
                            this.result.hasDebugName = input.ReadString(ref this.result.debugName_);
                            continue;
                        }
                        case 40:
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
                    this.result.hasSource = input.ReadInt32(ref this.result.source_);
                }
                return this;
            }

            private AutoLogin PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AutoLogin result = this.result;
                    this.result = new AutoLogin();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public AutoLogin.Builder SetBuildId(int value)
            {
                this.PrepareBuilder();
                this.result.hasBuildId = true;
                this.result.buildId_ = value;
                return this;
            }

            public AutoLogin.Builder SetDebugName(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasDebugName = true;
                this.result.debugName_ = value;
                return this;
            }

            public AutoLogin.Builder SetPwd(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasPwd = true;
                this.result.pwd_ = value;
                return this;
            }

            public AutoLogin.Builder SetSource(int value)
            {
                this.PrepareBuilder();
                this.result.hasSource = true;
                this.result.source_ = value;
                return this;
            }

            public AutoLogin.Builder SetUser(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasUser = true;
                this.result.user_ = value;
                return this;
            }

            public int BuildId
            {
                get
                {
                    return this.result.BuildId;
                }
                set
                {
                    this.SetBuildId(value);
                }
            }

            public string DebugName
            {
                get
                {
                    return this.result.DebugName;
                }
                set
                {
                    this.SetDebugName(value);
                }
            }

            public override AutoLogin DefaultInstanceForType
            {
                get
                {
                    return AutoLogin.DefaultInstance;
                }
            }

            public bool HasBuildId
            {
                get
                {
                    return this.result.hasBuildId;
                }
            }

            public bool HasDebugName
            {
                get
                {
                    return this.result.hasDebugName;
                }
            }

            public bool HasPwd
            {
                get
                {
                    return this.result.hasPwd;
                }
            }

            public bool HasSource
            {
                get
                {
                    return this.result.hasSource;
                }
            }

            public bool HasUser
            {
                get
                {
                    return this.result.hasUser;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override AutoLogin MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public string Pwd
            {
                get
                {
                    return this.result.Pwd;
                }
                set
                {
                    this.SetPwd(value);
                }
            }

            public int Source
            {
                get
                {
                    return this.result.Source;
                }
                set
                {
                    this.SetSource(value);
                }
            }

            protected override AutoLogin.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public string User
            {
                get
                {
                    return this.result.User;
                }
                set
                {
                    this.SetUser(value);
                }
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0x67
            }
        }
    }
}

