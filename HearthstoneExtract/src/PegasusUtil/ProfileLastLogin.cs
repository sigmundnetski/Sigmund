namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using PegasusShared;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class ProfileLastLogin : GeneratedMessageLite<ProfileLastLogin, Builder>
    {
        private static readonly string[] _profileLastLoginFieldNames = new string[] { "last_login" };
        private static readonly uint[] _profileLastLoginFieldTags = new uint[] { 10 };
        private static readonly ProfileLastLogin defaultInstance = new ProfileLastLogin().MakeReadOnly();
        private bool hasLastLogin;
        private Date lastLogin_;
        public const int LastLoginFieldNumber = 1;
        private int memoizedSerializedSize = -1;

        static ProfileLastLogin()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private ProfileLastLogin()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ProfileLastLogin prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ProfileLastLogin login = obj as ProfileLastLogin;
            if (login == null)
            {
                return false;
            }
            return ((this.hasLastLogin == login.hasLastLogin) && (!this.hasLastLogin || this.lastLogin_.Equals(login.lastLogin_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasLastLogin)
            {
                hashCode ^= this.lastLogin_.GetHashCode();
            }
            return hashCode;
        }

        private ProfileLastLogin MakeReadOnly()
        {
            return this;
        }

        public static ProfileLastLogin ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ProfileLastLogin ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileLastLogin ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ProfileLastLogin ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ProfileLastLogin ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ProfileLastLogin ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ProfileLastLogin ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ProfileLastLogin ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileLastLogin ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileLastLogin ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ProfileLastLogin, Builder>.PrintField("last_login", this.hasLastLogin, this.lastLogin_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _profileLastLoginFieldNames;
            if (this.hasLastLogin)
            {
                output.WriteMessage(1, strArray[0], this.LastLogin);
            }
        }

        public static ProfileLastLogin DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ProfileLastLogin DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasLastLogin
        {
            get
            {
                return this.hasLastLogin;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasLastLogin)
                {
                    return false;
                }
                if (!this.LastLogin.IsInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        public Date LastLogin
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.lastLogin_ != null)
                {
                    goto Label_0012;
                }
                return Date.DefaultInstance;
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
                    if (this.hasLastLogin)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.LastLogin);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ProfileLastLogin ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<ProfileLastLogin, ProfileLastLogin.Builder>
        {
            private ProfileLastLogin result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ProfileLastLogin.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ProfileLastLogin cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override ProfileLastLogin BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ProfileLastLogin.Builder Clear()
            {
                this.result = ProfileLastLogin.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ProfileLastLogin.Builder ClearLastLogin()
            {
                this.PrepareBuilder();
                this.result.hasLastLogin = false;
                this.result.lastLogin_ = null;
                return this;
            }

            public override ProfileLastLogin.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ProfileLastLogin.Builder(this.result);
                }
                return new ProfileLastLogin.Builder().MergeFrom(this.result);
            }

            public override ProfileLastLogin.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ProfileLastLogin.Builder MergeFrom(IMessageLite other)
            {
                if (other is ProfileLastLogin)
                {
                    return this.MergeFrom((ProfileLastLogin) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ProfileLastLogin.Builder MergeFrom(ProfileLastLogin other)
            {
                if (other != ProfileLastLogin.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasLastLogin)
                    {
                        this.MergeLastLogin(other.LastLogin);
                    }
                }
                return this;
            }

            public override ProfileLastLogin.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ProfileLastLogin._profileLastLoginFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ProfileLastLogin._profileLastLoginFieldTags[index];
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
                            Date.Builder builder = Date.CreateBuilder();
                            if (this.result.hasLastLogin)
                            {
                                builder.MergeFrom(this.LastLogin);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.LastLogin = builder.BuildPartial();
                            continue;
                        }
                    }
                    if (WireFormat.IsEndGroupTag(num))
                    {
                        return this;
                    }
                    this.ParseUnknownField(input, extensionRegistry, num, str);
                }
                return this;
            }

            public ProfileLastLogin.Builder MergeLastLogin(Date value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasLastLogin && (this.result.lastLogin_ != Date.DefaultInstance))
                {
                    this.result.lastLogin_ = Date.CreateBuilder(this.result.lastLogin_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.lastLogin_ = value;
                }
                this.result.hasLastLogin = true;
                return this;
            }

            private ProfileLastLogin PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ProfileLastLogin result = this.result;
                    this.result = new ProfileLastLogin();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ProfileLastLogin.Builder SetLastLogin(Date value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasLastLogin = true;
                this.result.lastLogin_ = value;
                return this;
            }

            public ProfileLastLogin.Builder SetLastLogin(Date.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasLastLogin = true;
                this.result.lastLogin_ = builderForValue.Build();
                return this;
            }

            public override ProfileLastLogin DefaultInstanceForType
            {
                get
                {
                    return ProfileLastLogin.DefaultInstance;
                }
            }

            public bool HasLastLogin
            {
                get
                {
                    return this.result.hasLastLogin;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public Date LastLogin
            {
                get
                {
                    return this.result.LastLogin;
                }
                set
                {
                    this.SetLastLogin(value);
                }
            }

            protected override ProfileLastLogin MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override ProfileLastLogin.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0xe3
            }
        }
    }
}

