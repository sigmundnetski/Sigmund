namespace bnet.protocol.account
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class AccountLicense : GeneratedMessageLite<AccountLicense, Builder>
    {
        private static readonly string[] _accountLicenseFieldNames = new string[] { "expires", "id" };
        private static readonly uint[] _accountLicenseFieldTags = new uint[] { 0x10, 8 };
        private static readonly AccountLicense defaultInstance = new AccountLicense().MakeReadOnly();
        private ulong expires_;
        public const int ExpiresFieldNumber = 2;
        private bool hasExpires;
        private bool hasId;
        private uint id_;
        public const int IdFieldNumber = 1;
        private int memoizedSerializedSize = -1;

        static AccountLicense()
        {
            object.ReferenceEquals(AccountTypes.Descriptor, null);
        }

        private AccountLicense()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AccountLicense prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AccountLicense license = obj as AccountLicense;
            if (license == null)
            {
                return false;
            }
            if ((this.hasId != license.hasId) || (this.hasId && !this.id_.Equals(license.id_)))
            {
                return false;
            }
            return ((this.hasExpires == license.hasExpires) && (!this.hasExpires || this.expires_.Equals(license.expires_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasId)
            {
                hashCode ^= this.id_.GetHashCode();
            }
            if (this.hasExpires)
            {
                hashCode ^= this.expires_.GetHashCode();
            }
            return hashCode;
        }

        private AccountLicense MakeReadOnly()
        {
            return this;
        }

        public static AccountLicense ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AccountLicense ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AccountLicense ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AccountLicense ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AccountLicense ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AccountLicense ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AccountLicense ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AccountLicense ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AccountLicense ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AccountLicense ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AccountLicense, Builder>.PrintField("id", this.hasId, this.id_, writer);
            GeneratedMessageLite<AccountLicense, Builder>.PrintField("expires", this.hasExpires, this.expires_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _accountLicenseFieldNames;
            if (this.hasId)
            {
                output.WriteUInt32(1, strArray[1], this.Id);
            }
            if (this.hasExpires)
            {
                output.WriteUInt64(2, strArray[0], this.Expires);
            }
        }

        public static AccountLicense DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AccountLicense DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        [CLSCompliant(false)]
        public ulong Expires
        {
            get
            {
                return this.expires_;
            }
        }

        public bool HasExpires
        {
            get
            {
                return this.hasExpires;
            }
        }

        public bool HasId
        {
            get
            {
                return this.hasId;
            }
        }

        [CLSCompliant(false)]
        public uint Id
        {
            get
            {
                return this.id_;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasId)
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
                    if (this.hasId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(1, this.Id);
                    }
                    if (this.hasExpires)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(2, this.Expires);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override AccountLicense ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<AccountLicense, AccountLicense.Builder>
        {
            private AccountLicense result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AccountLicense.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AccountLicense cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override AccountLicense BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AccountLicense.Builder Clear()
            {
                this.result = AccountLicense.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AccountLicense.Builder ClearExpires()
            {
                this.PrepareBuilder();
                this.result.hasExpires = false;
                this.result.expires_ = 0L;
                return this;
            }

            public AccountLicense.Builder ClearId()
            {
                this.PrepareBuilder();
                this.result.hasId = false;
                this.result.id_ = 0;
                return this;
            }

            public override AccountLicense.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AccountLicense.Builder(this.result);
                }
                return new AccountLicense.Builder().MergeFrom(this.result);
            }

            public override AccountLicense.Builder MergeFrom(AccountLicense other)
            {
                if (other != AccountLicense.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasId)
                    {
                        this.Id = other.Id;
                    }
                    if (other.HasExpires)
                    {
                        this.Expires = other.Expires;
                    }
                }
                return this;
            }

            public override AccountLicense.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AccountLicense.Builder MergeFrom(IMessageLite other)
            {
                if (other is AccountLicense)
                {
                    return this.MergeFrom((AccountLicense) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AccountLicense.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AccountLicense._accountLicenseFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AccountLicense._accountLicenseFieldTags[index];
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
                            this.result.hasId = input.ReadUInt32(ref this.result.id_);
                            continue;
                        }
                        case 0x10:
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
                    this.result.hasExpires = input.ReadUInt64(ref this.result.expires_);
                }
                return this;
            }

            private AccountLicense PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AccountLicense result = this.result;
                    this.result = new AccountLicense();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public AccountLicense.Builder SetExpires(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasExpires = true;
                this.result.expires_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public AccountLicense.Builder SetId(uint value)
            {
                this.PrepareBuilder();
                this.result.hasId = true;
                this.result.id_ = value;
                return this;
            }

            public override AccountLicense DefaultInstanceForType
            {
                get
                {
                    return AccountLicense.DefaultInstance;
                }
            }

            [CLSCompliant(false)]
            public ulong Expires
            {
                get
                {
                    return this.result.Expires;
                }
                set
                {
                    this.SetExpires(value);
                }
            }

            public bool HasExpires
            {
                get
                {
                    return this.result.hasExpires;
                }
            }

            public bool HasId
            {
                get
                {
                    return this.result.hasId;
                }
            }

            [CLSCompliant(false)]
            public uint Id
            {
                get
                {
                    return this.result.Id;
                }
                set
                {
                    this.SetId(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override AccountLicense MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override AccountLicense.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

