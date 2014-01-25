namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class DatabaseNewProfile : GeneratedMessageLite<DatabaseNewProfile, Builder>
    {
        private static readonly string[] _databaseNewProfileFieldNames = new string[] { "email", "name", "password" };
        private static readonly uint[] _databaseNewProfileFieldTags = new uint[] { 10, 0x1a, 0x12 };
        private static readonly DatabaseNewProfile defaultInstance = new DatabaseNewProfile().MakeReadOnly();
        private string email_ = string.Empty;
        public const int EmailFieldNumber = 1;
        private bool hasEmail;
        private bool hasName;
        private bool hasPassword;
        private int memoizedSerializedSize = -1;
        private string name_ = string.Empty;
        public const int NameFieldNumber = 3;
        private string password_ = string.Empty;
        public const int PasswordFieldNumber = 2;

        static DatabaseNewProfile()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private DatabaseNewProfile()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DatabaseNewProfile prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DatabaseNewProfile profile = obj as DatabaseNewProfile;
            if (profile == null)
            {
                return false;
            }
            if ((this.hasEmail != profile.hasEmail) || (this.hasEmail && !this.email_.Equals(profile.email_)))
            {
                return false;
            }
            if ((this.hasPassword != profile.hasPassword) || (this.hasPassword && !this.password_.Equals(profile.password_)))
            {
                return false;
            }
            return ((this.hasName == profile.hasName) && (!this.hasName || this.name_.Equals(profile.name_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasEmail)
            {
                hashCode ^= this.email_.GetHashCode();
            }
            if (this.hasPassword)
            {
                hashCode ^= this.password_.GetHashCode();
            }
            if (this.hasName)
            {
                hashCode ^= this.name_.GetHashCode();
            }
            return hashCode;
        }

        private DatabaseNewProfile MakeReadOnly()
        {
            return this;
        }

        public static DatabaseNewProfile ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DatabaseNewProfile ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DatabaseNewProfile ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DatabaseNewProfile ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DatabaseNewProfile ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DatabaseNewProfile ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DatabaseNewProfile ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DatabaseNewProfile ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DatabaseNewProfile ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DatabaseNewProfile ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DatabaseNewProfile, Builder>.PrintField("email", this.hasEmail, this.email_, writer);
            GeneratedMessageLite<DatabaseNewProfile, Builder>.PrintField("password", this.hasPassword, this.password_, writer);
            GeneratedMessageLite<DatabaseNewProfile, Builder>.PrintField("name", this.hasName, this.name_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _databaseNewProfileFieldNames;
            if (this.hasEmail)
            {
                output.WriteString(1, strArray[0], this.Email);
            }
            if (this.hasPassword)
            {
                output.WriteString(2, strArray[2], this.Password);
            }
            if (this.hasName)
            {
                output.WriteString(3, strArray[1], this.Name);
            }
        }

        public static DatabaseNewProfile DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DatabaseNewProfile DefaultInstanceForType
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

        public bool HasEmail
        {
            get
            {
                return this.hasEmail;
            }
        }

        public bool HasName
        {
            get
            {
                return this.hasName;
            }
        }

        public bool HasPassword
        {
            get
            {
                return this.hasPassword;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasEmail)
                {
                    return false;
                }
                if (!this.hasPassword)
                {
                    return false;
                }
                if (!this.hasName)
                {
                    return false;
                }
                return true;
            }
        }

        public string Name
        {
            get
            {
                return this.name_;
            }
        }

        public string Password
        {
            get
            {
                return this.password_;
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
                    if (this.hasEmail)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(1, this.Email);
                    }
                    if (this.hasPassword)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(2, this.Password);
                    }
                    if (this.hasName)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(3, this.Name);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override DatabaseNewProfile ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<DatabaseNewProfile, DatabaseNewProfile.Builder>
        {
            private DatabaseNewProfile result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DatabaseNewProfile.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DatabaseNewProfile cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override DatabaseNewProfile BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DatabaseNewProfile.Builder Clear()
            {
                this.result = DatabaseNewProfile.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DatabaseNewProfile.Builder ClearEmail()
            {
                this.PrepareBuilder();
                this.result.hasEmail = false;
                this.result.email_ = string.Empty;
                return this;
            }

            public DatabaseNewProfile.Builder ClearName()
            {
                this.PrepareBuilder();
                this.result.hasName = false;
                this.result.name_ = string.Empty;
                return this;
            }

            public DatabaseNewProfile.Builder ClearPassword()
            {
                this.PrepareBuilder();
                this.result.hasPassword = false;
                this.result.password_ = string.Empty;
                return this;
            }

            public override DatabaseNewProfile.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DatabaseNewProfile.Builder(this.result);
                }
                return new DatabaseNewProfile.Builder().MergeFrom(this.result);
            }

            public override DatabaseNewProfile.Builder MergeFrom(DatabaseNewProfile other)
            {
                if (other != DatabaseNewProfile.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasEmail)
                    {
                        this.Email = other.Email;
                    }
                    if (other.HasPassword)
                    {
                        this.Password = other.Password;
                    }
                    if (other.HasName)
                    {
                        this.Name = other.Name;
                    }
                }
                return this;
            }

            public override DatabaseNewProfile.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DatabaseNewProfile.Builder MergeFrom(IMessageLite other)
            {
                if (other is DatabaseNewProfile)
                {
                    return this.MergeFrom((DatabaseNewProfile) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DatabaseNewProfile.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DatabaseNewProfile._databaseNewProfileFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DatabaseNewProfile._databaseNewProfileFieldTags[index];
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
                            this.result.hasEmail = input.ReadString(ref this.result.email_);
                            continue;
                        }
                        case 0x12:
                        {
                            this.result.hasPassword = input.ReadString(ref this.result.password_);
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
                    this.result.hasName = input.ReadString(ref this.result.name_);
                }
                return this;
            }

            private DatabaseNewProfile PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DatabaseNewProfile result = this.result;
                    this.result = new DatabaseNewProfile();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DatabaseNewProfile.Builder SetEmail(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasEmail = true;
                this.result.email_ = value;
                return this;
            }

            public DatabaseNewProfile.Builder SetName(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasName = true;
                this.result.name_ = value;
                return this;
            }

            public DatabaseNewProfile.Builder SetPassword(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasPassword = true;
                this.result.password_ = value;
                return this;
            }

            public override DatabaseNewProfile DefaultInstanceForType
            {
                get
                {
                    return DatabaseNewProfile.DefaultInstance;
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

            public bool HasEmail
            {
                get
                {
                    return this.result.hasEmail;
                }
            }

            public bool HasName
            {
                get
                {
                    return this.result.hasName;
                }
            }

            public bool HasPassword
            {
                get
                {
                    return this.result.hasPassword;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override DatabaseNewProfile MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public string Name
            {
                get
                {
                    return this.result.Name;
                }
                set
                {
                    this.SetName(value);
                }
            }

            public string Password
            {
                get
                {
                    return this.result.Password;
                }
                set
                {
                    this.SetPassword(value);
                }
            }

            protected override DatabaseNewProfile.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0x89
            }
        }
    }
}

