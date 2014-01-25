namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class Auth : GeneratedMessageLite<Auth, Builder>
    {
        private static readonly string[] _authFieldNames = new string[] { "auth", "motd" };
        private static readonly uint[] _authFieldTags = new uint[] { 8, 0x12 };
        private Types.Result auth_;
        public const int Auth_FieldNumber = 1;
        private static readonly Auth defaultInstance = new Auth().MakeReadOnly();
        private bool hasAuth_;
        private bool hasMotd;
        private int memoizedSerializedSize = -1;
        private string motd_ = string.Empty;
        public const int MotdFieldNumber = 2;

        static Auth()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private Auth()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(Auth prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            Auth auth = obj as Auth;
            if (auth == null)
            {
                return false;
            }
            if ((this.hasAuth_ != auth.hasAuth_) || (this.hasAuth_ && !this.auth_.Equals(auth.auth_)))
            {
                return false;
            }
            return ((this.hasMotd == auth.hasMotd) && (!this.hasMotd || this.motd_.Equals(auth.motd_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasAuth_)
            {
                hashCode ^= this.auth_.GetHashCode();
            }
            if (this.hasMotd)
            {
                hashCode ^= this.motd_.GetHashCode();
            }
            return hashCode;
        }

        private Auth MakeReadOnly()
        {
            return this;
        }

        public static Auth ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static Auth ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static Auth ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Auth ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Auth ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Auth ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Auth ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static Auth ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Auth ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Auth ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<Auth, Builder>.PrintField("auth", this.hasAuth_, this.auth_, writer);
            GeneratedMessageLite<Auth, Builder>.PrintField("motd", this.hasMotd, this.motd_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _authFieldNames;
            if (this.hasAuth_)
            {
                output.WriteEnum(1, strArray[0], (int) this.Auth_, this.Auth_);
            }
            if (this.hasMotd)
            {
                output.WriteString(2, strArray[1], this.Motd);
            }
        }

        public Types.Result Auth_
        {
            get
            {
                return this.auth_;
            }
        }

        public static Auth DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override Auth DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasAuth_
        {
            get
            {
                return this.hasAuth_;
            }
        }

        public bool HasMotd
        {
            get
            {
                return this.hasMotd;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasAuth_)
                {
                    return false;
                }
                if (!this.hasMotd)
                {
                    return false;
                }
                return true;
            }
        }

        public string Motd
        {
            get
            {
                return this.motd_;
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
                    if (this.hasAuth_)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeEnumSize(1, (int) this.Auth_);
                    }
                    if (this.hasMotd)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(2, this.Motd);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override Auth ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<Auth, Auth.Builder>
        {
            private Auth result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = Auth.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(Auth cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override Auth BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override Auth.Builder Clear()
            {
                this.result = Auth.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public Auth.Builder ClearAuth_()
            {
                this.PrepareBuilder();
                this.result.hasAuth_ = false;
                this.result.auth_ = Auth.Types.Result.UNKNOWN;
                return this;
            }

            public Auth.Builder ClearMotd()
            {
                this.PrepareBuilder();
                this.result.hasMotd = false;
                this.result.motd_ = string.Empty;
                return this;
            }

            public override Auth.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new Auth.Builder(this.result);
                }
                return new Auth.Builder().MergeFrom(this.result);
            }

            public override Auth.Builder MergeFrom(Auth other)
            {
                if (other != Auth.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAuth_)
                    {
                        this.Auth_ = other.Auth_;
                    }
                    if (other.HasMotd)
                    {
                        this.Motd = other.Motd;
                    }
                }
                return this;
            }

            public override Auth.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override Auth.Builder MergeFrom(IMessageLite other)
            {
                if (other is Auth)
                {
                    return this.MergeFrom((Auth) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override Auth.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(Auth._authFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = Auth._authFieldTags[index];
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
                            if (input.ReadEnum<Auth.Types.Result>(ref this.result.auth_, out obj2))
                            {
                                this.result.hasAuth_ = true;
                            }
                            else if (obj2 is int)
                            {
                            }
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
                    this.result.hasMotd = input.ReadString(ref this.result.motd_);
                }
                return this;
            }

            private Auth PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    Auth result = this.result;
                    this.result = new Auth();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public Auth.Builder SetAuth_(Auth.Types.Result value)
            {
                this.PrepareBuilder();
                this.result.hasAuth_ = true;
                this.result.auth_ = value;
                return this;
            }

            public Auth.Builder SetMotd(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasMotd = true;
                this.result.motd_ = value;
                return this;
            }

            public Auth.Types.Result Auth_
            {
                get
                {
                    return this.result.Auth_;
                }
                set
                {
                    this.SetAuth_(value);
                }
            }

            public override Auth DefaultInstanceForType
            {
                get
                {
                    return Auth.DefaultInstance;
                }
            }

            public bool HasAuth_
            {
                get
                {
                    return this.result.hasAuth_;
                }
            }

            public bool HasMotd
            {
                get
                {
                    return this.result.hasMotd;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override Auth MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public string Motd
            {
                get
                {
                    return this.result.Motd;
                }
                set
                {
                    this.SetMotd(value);
                }
            }

            protected override Auth.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0x6a
            }

            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum Result
            {
                UNKNOWN,
                ALLOWED,
                INVALID,
                SECOND,
                OFFLINE
            }
        }
    }
}

