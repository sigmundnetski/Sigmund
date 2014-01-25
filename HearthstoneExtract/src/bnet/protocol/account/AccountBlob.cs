namespace bnet.protocol.account
{
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class AccountBlob : GeneratedMessageLite<AccountBlob, Builder>
    {
        private static readonly string[] _accountBlobFieldNames = new string[] { "account_links", "battle_tag", "cache_expiration", "credentials", "default_currency", "email", "flags", "full_name", "id", "legal_locale", "legal_region", "licenses", "region", "secure_release", "whitelist_end", "whitelist_start" };
        private static readonly uint[] _accountBlobFieldTags = new uint[] { 0xb2, 0xba, 240, 170, 0xcd, 0x22, 40, 0x52, 0x15, 0xdd, 0xd0, 0xa2, 0x18, 0x30, 0x40, 0x38 };
        private PopsicleList<GameAccountLink> accountLinks_ = new PopsicleList<GameAccountLink>();
        public const int AccountLinksFieldNumber = 0x16;
        private string battleTag_ = string.Empty;
        public const int BattleTagFieldNumber = 0x17;
        private ulong cacheExpiration_;
        public const int CacheExpirationFieldNumber = 30;
        private PopsicleList<AccountCredential> credentials_ = new PopsicleList<AccountCredential>();
        public const int CredentialsFieldNumber = 0x15;
        private uint defaultCurrency_;
        public const int DefaultCurrencyFieldNumber = 0x19;
        private static readonly AccountBlob defaultInstance = new AccountBlob().MakeReadOnly();
        private PopsicleList<string> email_ = new PopsicleList<string>();
        public const int EmailFieldNumber = 4;
        private ulong flags_;
        public const int FlagsFieldNumber = 5;
        private string fullName_ = string.Empty;
        public const int FullNameFieldNumber = 10;
        private bool hasBattleTag;
        private bool hasCacheExpiration;
        private bool hasDefaultCurrency;
        private bool hasFlags;
        private bool hasFullName;
        private bool hasId;
        private bool hasLegalLocale;
        private bool hasLegalRegion;
        private bool hasRegion;
        private bool hasSecureRelease;
        private bool hasWhitelistEnd;
        private bool hasWhitelistStart;
        private uint id_;
        public const int IdFieldNumber = 2;
        private uint legalLocale_;
        public const int LegalLocaleFieldNumber = 0x1b;
        private uint legalRegion_;
        public const int LegalRegionFieldNumber = 0x1a;
        private PopsicleList<AccountLicense> licenses_ = new PopsicleList<AccountLicense>();
        public const int LicensesFieldNumber = 20;
        private int memoizedSerializedSize = -1;
        private uint region_;
        public const int RegionFieldNumber = 3;
        private ulong secureRelease_;
        public const int SecureReleaseFieldNumber = 6;
        private ulong whitelistEnd_;
        public const int WhitelistEndFieldNumber = 8;
        private ulong whitelistStart_;
        public const int WhitelistStartFieldNumber = 7;

        static AccountBlob()
        {
            object.ReferenceEquals(AccountTypes.Descriptor, null);
        }

        private AccountBlob()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AccountBlob prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AccountBlob blob = obj as AccountBlob;
            if (blob == null)
            {
                return false;
            }
            if ((this.hasId != blob.hasId) || (this.hasId && !this.id_.Equals(blob.id_)))
            {
                return false;
            }
            if ((this.hasRegion != blob.hasRegion) || (this.hasRegion && !this.region_.Equals(blob.region_)))
            {
                return false;
            }
            if (this.email_.Count != blob.email_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.email_.Count; i++)
            {
                if (!this.email_[i].Equals(blob.email_[i]))
                {
                    return false;
                }
            }
            if ((this.hasFlags != blob.hasFlags) || (this.hasFlags && !this.flags_.Equals(blob.flags_)))
            {
                return false;
            }
            if ((this.hasSecureRelease != blob.hasSecureRelease) || (this.hasSecureRelease && !this.secureRelease_.Equals(blob.secureRelease_)))
            {
                return false;
            }
            if ((this.hasWhitelistStart != blob.hasWhitelistStart) || (this.hasWhitelistStart && !this.whitelistStart_.Equals(blob.whitelistStart_)))
            {
                return false;
            }
            if ((this.hasWhitelistEnd != blob.hasWhitelistEnd) || (this.hasWhitelistEnd && !this.whitelistEnd_.Equals(blob.whitelistEnd_)))
            {
                return false;
            }
            if ((this.hasFullName != blob.hasFullName) || (this.hasFullName && !this.fullName_.Equals(blob.fullName_)))
            {
                return false;
            }
            if (this.licenses_.Count != blob.licenses_.Count)
            {
                return false;
            }
            for (int j = 0; j < this.licenses_.Count; j++)
            {
                if (!this.licenses_[j].Equals(blob.licenses_[j]))
                {
                    return false;
                }
            }
            if (this.credentials_.Count != blob.credentials_.Count)
            {
                return false;
            }
            for (int k = 0; k < this.credentials_.Count; k++)
            {
                if (!this.credentials_[k].Equals(blob.credentials_[k]))
                {
                    return false;
                }
            }
            if (this.accountLinks_.Count != blob.accountLinks_.Count)
            {
                return false;
            }
            for (int m = 0; m < this.accountLinks_.Count; m++)
            {
                if (!this.accountLinks_[m].Equals(blob.accountLinks_[m]))
                {
                    return false;
                }
            }
            if ((this.hasBattleTag != blob.hasBattleTag) || (this.hasBattleTag && !this.battleTag_.Equals(blob.battleTag_)))
            {
                return false;
            }
            if ((this.hasDefaultCurrency != blob.hasDefaultCurrency) || (this.hasDefaultCurrency && !this.defaultCurrency_.Equals(blob.defaultCurrency_)))
            {
                return false;
            }
            if ((this.hasLegalRegion != blob.hasLegalRegion) || (this.hasLegalRegion && !this.legalRegion_.Equals(blob.legalRegion_)))
            {
                return false;
            }
            if ((this.hasLegalLocale != blob.hasLegalLocale) || (this.hasLegalLocale && !this.legalLocale_.Equals(blob.legalLocale_)))
            {
                return false;
            }
            return ((this.hasCacheExpiration == blob.hasCacheExpiration) && (!this.hasCacheExpiration || this.cacheExpiration_.Equals(blob.cacheExpiration_)));
        }

        public GameAccountLink GetAccountLinks(int index)
        {
            return this.accountLinks_[index];
        }

        public AccountCredential GetCredentials(int index)
        {
            return this.credentials_[index];
        }

        public string GetEmail(int index)
        {
            return this.email_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasId)
            {
                hashCode ^= this.id_.GetHashCode();
            }
            if (this.hasRegion)
            {
                hashCode ^= this.region_.GetHashCode();
            }
            IEnumerator<string> enumerator = this.email_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    string current = enumerator.Current;
                    hashCode ^= current.GetHashCode();
                }
            }
            finally
            {
                if (enumerator == null)
                {
                }
                enumerator.Dispose();
            }
            if (this.hasFlags)
            {
                hashCode ^= this.flags_.GetHashCode();
            }
            if (this.hasSecureRelease)
            {
                hashCode ^= this.secureRelease_.GetHashCode();
            }
            if (this.hasWhitelistStart)
            {
                hashCode ^= this.whitelistStart_.GetHashCode();
            }
            if (this.hasWhitelistEnd)
            {
                hashCode ^= this.whitelistEnd_.GetHashCode();
            }
            if (this.hasFullName)
            {
                hashCode ^= this.fullName_.GetHashCode();
            }
            IEnumerator<AccountLicense> enumerator2 = this.licenses_.GetEnumerator();
            try
            {
                while (enumerator2.MoveNext())
                {
                    AccountLicense license = enumerator2.Current;
                    hashCode ^= license.GetHashCode();
                }
            }
            finally
            {
                if (enumerator2 == null)
                {
                }
                enumerator2.Dispose();
            }
            IEnumerator<AccountCredential> enumerator3 = this.credentials_.GetEnumerator();
            try
            {
                while (enumerator3.MoveNext())
                {
                    AccountCredential credential = enumerator3.Current;
                    hashCode ^= credential.GetHashCode();
                }
            }
            finally
            {
                if (enumerator3 == null)
                {
                }
                enumerator3.Dispose();
            }
            IEnumerator<GameAccountLink> enumerator4 = this.accountLinks_.GetEnumerator();
            try
            {
                while (enumerator4.MoveNext())
                {
                    GameAccountLink link = enumerator4.Current;
                    hashCode ^= link.GetHashCode();
                }
            }
            finally
            {
                if (enumerator4 == null)
                {
                }
                enumerator4.Dispose();
            }
            if (this.hasBattleTag)
            {
                hashCode ^= this.battleTag_.GetHashCode();
            }
            if (this.hasDefaultCurrency)
            {
                hashCode ^= this.defaultCurrency_.GetHashCode();
            }
            if (this.hasLegalRegion)
            {
                hashCode ^= this.legalRegion_.GetHashCode();
            }
            if (this.hasLegalLocale)
            {
                hashCode ^= this.legalLocale_.GetHashCode();
            }
            if (this.hasCacheExpiration)
            {
                hashCode ^= this.cacheExpiration_.GetHashCode();
            }
            return hashCode;
        }

        public AccountLicense GetLicenses(int index)
        {
            return this.licenses_[index];
        }

        private AccountBlob MakeReadOnly()
        {
            this.email_.MakeReadOnly();
            this.licenses_.MakeReadOnly();
            this.credentials_.MakeReadOnly();
            this.accountLinks_.MakeReadOnly();
            return this;
        }

        public static AccountBlob ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AccountBlob ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AccountBlob ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AccountBlob ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AccountBlob ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AccountBlob ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AccountBlob ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AccountBlob ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AccountBlob ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AccountBlob ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AccountBlob, Builder>.PrintField("id", this.hasId, this.id_, writer);
            GeneratedMessageLite<AccountBlob, Builder>.PrintField("region", this.hasRegion, this.region_, writer);
            GeneratedMessageLite<AccountBlob, Builder>.PrintField<string>("email", this.email_, writer);
            GeneratedMessageLite<AccountBlob, Builder>.PrintField("flags", this.hasFlags, this.flags_, writer);
            GeneratedMessageLite<AccountBlob, Builder>.PrintField("secure_release", this.hasSecureRelease, this.secureRelease_, writer);
            GeneratedMessageLite<AccountBlob, Builder>.PrintField("whitelist_start", this.hasWhitelistStart, this.whitelistStart_, writer);
            GeneratedMessageLite<AccountBlob, Builder>.PrintField("whitelist_end", this.hasWhitelistEnd, this.whitelistEnd_, writer);
            GeneratedMessageLite<AccountBlob, Builder>.PrintField("full_name", this.hasFullName, this.fullName_, writer);
            GeneratedMessageLite<AccountBlob, Builder>.PrintField<AccountLicense>("licenses", this.licenses_, writer);
            GeneratedMessageLite<AccountBlob, Builder>.PrintField<AccountCredential>("credentials", this.credentials_, writer);
            GeneratedMessageLite<AccountBlob, Builder>.PrintField<GameAccountLink>("account_links", this.accountLinks_, writer);
            GeneratedMessageLite<AccountBlob, Builder>.PrintField("battle_tag", this.hasBattleTag, this.battleTag_, writer);
            GeneratedMessageLite<AccountBlob, Builder>.PrintField("default_currency", this.hasDefaultCurrency, this.defaultCurrency_, writer);
            GeneratedMessageLite<AccountBlob, Builder>.PrintField("legal_region", this.hasLegalRegion, this.legalRegion_, writer);
            GeneratedMessageLite<AccountBlob, Builder>.PrintField("legal_locale", this.hasLegalLocale, this.legalLocale_, writer);
            GeneratedMessageLite<AccountBlob, Builder>.PrintField("cache_expiration", this.hasCacheExpiration, this.cacheExpiration_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _accountBlobFieldNames;
            if (this.hasId)
            {
                output.WriteFixed32(2, strArray[8], this.Id);
            }
            if (this.hasRegion)
            {
                output.WriteUInt32(3, strArray[12], this.Region);
            }
            if (this.email_.Count > 0)
            {
                output.WriteStringArray(4, strArray[5], this.email_);
            }
            if (this.hasFlags)
            {
                output.WriteUInt64(5, strArray[6], this.Flags);
            }
            if (this.hasSecureRelease)
            {
                output.WriteUInt64(6, strArray[13], this.SecureRelease);
            }
            if (this.hasWhitelistStart)
            {
                output.WriteUInt64(7, strArray[15], this.WhitelistStart);
            }
            if (this.hasWhitelistEnd)
            {
                output.WriteUInt64(8, strArray[14], this.WhitelistEnd);
            }
            if (this.hasFullName)
            {
                output.WriteString(10, strArray[7], this.FullName);
            }
            if (this.licenses_.Count > 0)
            {
                output.WriteMessageArray<AccountLicense>(20, strArray[11], this.licenses_);
            }
            if (this.credentials_.Count > 0)
            {
                output.WriteMessageArray<AccountCredential>(0x15, strArray[3], this.credentials_);
            }
            if (this.accountLinks_.Count > 0)
            {
                output.WriteMessageArray<GameAccountLink>(0x16, strArray[0], this.accountLinks_);
            }
            if (this.hasBattleTag)
            {
                output.WriteString(0x17, strArray[1], this.BattleTag);
            }
            if (this.hasDefaultCurrency)
            {
                output.WriteFixed32(0x19, strArray[4], this.DefaultCurrency);
            }
            if (this.hasLegalRegion)
            {
                output.WriteUInt32(0x1a, strArray[10], this.LegalRegion);
            }
            if (this.hasLegalLocale)
            {
                output.WriteFixed32(0x1b, strArray[9], this.LegalLocale);
            }
            if (this.hasCacheExpiration)
            {
                output.WriteUInt64(30, strArray[2], this.CacheExpiration);
            }
        }

        public int AccountLinksCount
        {
            get
            {
                return this.accountLinks_.Count;
            }
        }

        public IList<GameAccountLink> AccountLinksList
        {
            get
            {
                return this.accountLinks_;
            }
        }

        public string BattleTag
        {
            get
            {
                return this.battleTag_;
            }
        }

        [CLSCompliant(false)]
        public ulong CacheExpiration
        {
            get
            {
                return this.cacheExpiration_;
            }
        }

        public int CredentialsCount
        {
            get
            {
                return this.credentials_.Count;
            }
        }

        public IList<AccountCredential> CredentialsList
        {
            get
            {
                return this.credentials_;
            }
        }

        [CLSCompliant(false)]
        public uint DefaultCurrency
        {
            get
            {
                return this.defaultCurrency_;
            }
        }

        public static AccountBlob DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AccountBlob DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public int EmailCount
        {
            get
            {
                return this.email_.Count;
            }
        }

        public IList<string> EmailList
        {
            get
            {
                return Lists.AsReadOnly<string>(this.email_);
            }
        }

        [CLSCompliant(false)]
        public ulong Flags
        {
            get
            {
                return this.flags_;
            }
        }

        public string FullName
        {
            get
            {
                return this.fullName_;
            }
        }

        public bool HasBattleTag
        {
            get
            {
                return this.hasBattleTag;
            }
        }

        public bool HasCacheExpiration
        {
            get
            {
                return this.hasCacheExpiration;
            }
        }

        public bool HasDefaultCurrency
        {
            get
            {
                return this.hasDefaultCurrency;
            }
        }

        public bool HasFlags
        {
            get
            {
                return this.hasFlags;
            }
        }

        public bool HasFullName
        {
            get
            {
                return this.hasFullName;
            }
        }

        public bool HasId
        {
            get
            {
                return this.hasId;
            }
        }

        public bool HasLegalLocale
        {
            get
            {
                return this.hasLegalLocale;
            }
        }

        public bool HasLegalRegion
        {
            get
            {
                return this.hasLegalRegion;
            }
        }

        public bool HasRegion
        {
            get
            {
                return this.hasRegion;
            }
        }

        public bool HasSecureRelease
        {
            get
            {
                return this.hasSecureRelease;
            }
        }

        public bool HasWhitelistEnd
        {
            get
            {
                return this.hasWhitelistEnd;
            }
        }

        public bool HasWhitelistStart
        {
            get
            {
                return this.hasWhitelistStart;
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
                if (!this.hasRegion)
                {
                    return false;
                }
                if (!this.hasFlags)
                {
                    return false;
                }
                if (!this.hasFullName)
                {
                    return false;
                }
                if (!this.hasCacheExpiration)
                {
                    return false;
                }
                IEnumerator<AccountLicense> enumerator = this.LicensesList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        AccountLicense current = enumerator.Current;
                        if (!current.IsInitialized)
                        {
                            return false;
                        }
                    }
                }
                finally
                {
                    if (enumerator == null)
                    {
                    }
                    enumerator.Dispose();
                }
                IEnumerator<AccountCredential> enumerator2 = this.CredentialsList.GetEnumerator();
                try
                {
                    while (enumerator2.MoveNext())
                    {
                        AccountCredential credential = enumerator2.Current;
                        if (!credential.IsInitialized)
                        {
                            return false;
                        }
                    }
                }
                finally
                {
                    if (enumerator2 == null)
                    {
                    }
                    enumerator2.Dispose();
                }
                IEnumerator<GameAccountLink> enumerator3 = this.AccountLinksList.GetEnumerator();
                try
                {
                    while (enumerator3.MoveNext())
                    {
                        GameAccountLink link = enumerator3.Current;
                        if (!link.IsInitialized)
                        {
                            return false;
                        }
                    }
                }
                finally
                {
                    if (enumerator3 == null)
                    {
                    }
                    enumerator3.Dispose();
                }
                return true;
            }
        }

        [CLSCompliant(false)]
        public uint LegalLocale
        {
            get
            {
                return this.legalLocale_;
            }
        }

        [CLSCompliant(false)]
        public uint LegalRegion
        {
            get
            {
                return this.legalRegion_;
            }
        }

        public int LicensesCount
        {
            get
            {
                return this.licenses_.Count;
            }
        }

        public IList<AccountLicense> LicensesList
        {
            get
            {
                return this.licenses_;
            }
        }

        [CLSCompliant(false)]
        public uint Region
        {
            get
            {
                return this.region_;
            }
        }

        [CLSCompliant(false)]
        public ulong SecureRelease
        {
            get
            {
                return this.secureRelease_;
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
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed32Size(2, this.Id);
                    }
                    if (this.hasRegion)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(3, this.Region);
                    }
                    int num2 = 0;
                    IEnumerator<string> enumerator = this.EmailList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            string current = enumerator.Current;
                            num2 += CodedOutputStream.ComputeStringSizeNoTag(current);
                        }
                    }
                    finally
                    {
                        if (enumerator == null)
                        {
                        }
                        enumerator.Dispose();
                    }
                    memoizedSerializedSize += num2;
                    memoizedSerializedSize += 1 * this.email_.Count;
                    if (this.hasFlags)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(5, this.Flags);
                    }
                    if (this.hasSecureRelease)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(6, this.SecureRelease);
                    }
                    if (this.hasWhitelistStart)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(7, this.WhitelistStart);
                    }
                    if (this.hasWhitelistEnd)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(8, this.WhitelistEnd);
                    }
                    if (this.hasFullName)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(10, this.FullName);
                    }
                    IEnumerator<AccountLicense> enumerator2 = this.LicensesList.GetEnumerator();
                    try
                    {
                        while (enumerator2.MoveNext())
                        {
                            AccountLicense license = enumerator2.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(20, license);
                        }
                    }
                    finally
                    {
                        if (enumerator2 == null)
                        {
                        }
                        enumerator2.Dispose();
                    }
                    IEnumerator<AccountCredential> enumerator3 = this.CredentialsList.GetEnumerator();
                    try
                    {
                        while (enumerator3.MoveNext())
                        {
                            AccountCredential credential = enumerator3.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(0x15, credential);
                        }
                    }
                    finally
                    {
                        if (enumerator3 == null)
                        {
                        }
                        enumerator3.Dispose();
                    }
                    IEnumerator<GameAccountLink> enumerator4 = this.AccountLinksList.GetEnumerator();
                    try
                    {
                        while (enumerator4.MoveNext())
                        {
                            GameAccountLink link = enumerator4.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(0x16, link);
                        }
                    }
                    finally
                    {
                        if (enumerator4 == null)
                        {
                        }
                        enumerator4.Dispose();
                    }
                    if (this.hasBattleTag)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(0x17, this.BattleTag);
                    }
                    if (this.hasDefaultCurrency)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed32Size(0x19, this.DefaultCurrency);
                    }
                    if (this.hasLegalRegion)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(0x1a, this.LegalRegion);
                    }
                    if (this.hasLegalLocale)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed32Size(0x1b, this.LegalLocale);
                    }
                    if (this.hasCacheExpiration)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(30, this.CacheExpiration);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override AccountBlob ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CLSCompliant(false)]
        public ulong WhitelistEnd
        {
            get
            {
                return this.whitelistEnd_;
            }
        }

        [CLSCompliant(false)]
        public ulong WhitelistStart
        {
            get
            {
                return this.whitelistStart_;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<AccountBlob, AccountBlob.Builder>
        {
            private AccountBlob result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AccountBlob.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AccountBlob cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public AccountBlob.Builder AddAccountLinks(GameAccountLink value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.accountLinks_.Add(value);
                return this;
            }

            public AccountBlob.Builder AddAccountLinks(GameAccountLink.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.accountLinks_.Add(builderForValue.Build());
                return this;
            }

            public AccountBlob.Builder AddCredentials(AccountCredential value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.credentials_.Add(value);
                return this;
            }

            public AccountBlob.Builder AddCredentials(AccountCredential.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.credentials_.Add(builderForValue.Build());
                return this;
            }

            public AccountBlob.Builder AddEmail(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.email_.Add(value);
                return this;
            }

            public AccountBlob.Builder AddLicenses(AccountLicense value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.licenses_.Add(value);
                return this;
            }

            public AccountBlob.Builder AddLicenses(AccountLicense.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.licenses_.Add(builderForValue.Build());
                return this;
            }

            public AccountBlob.Builder AddRangeAccountLinks(IEnumerable<GameAccountLink> values)
            {
                this.PrepareBuilder();
                this.result.accountLinks_.Add(values);
                return this;
            }

            public AccountBlob.Builder AddRangeCredentials(IEnumerable<AccountCredential> values)
            {
                this.PrepareBuilder();
                this.result.credentials_.Add(values);
                return this;
            }

            public AccountBlob.Builder AddRangeEmail(IEnumerable<string> values)
            {
                this.PrepareBuilder();
                this.result.email_.Add(values);
                return this;
            }

            public AccountBlob.Builder AddRangeLicenses(IEnumerable<AccountLicense> values)
            {
                this.PrepareBuilder();
                this.result.licenses_.Add(values);
                return this;
            }

            public override AccountBlob BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AccountBlob.Builder Clear()
            {
                this.result = AccountBlob.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AccountBlob.Builder ClearAccountLinks()
            {
                this.PrepareBuilder();
                this.result.accountLinks_.Clear();
                return this;
            }

            public AccountBlob.Builder ClearBattleTag()
            {
                this.PrepareBuilder();
                this.result.hasBattleTag = false;
                this.result.battleTag_ = string.Empty;
                return this;
            }

            public AccountBlob.Builder ClearCacheExpiration()
            {
                this.PrepareBuilder();
                this.result.hasCacheExpiration = false;
                this.result.cacheExpiration_ = 0L;
                return this;
            }

            public AccountBlob.Builder ClearCredentials()
            {
                this.PrepareBuilder();
                this.result.credentials_.Clear();
                return this;
            }

            public AccountBlob.Builder ClearDefaultCurrency()
            {
                this.PrepareBuilder();
                this.result.hasDefaultCurrency = false;
                this.result.defaultCurrency_ = 0;
                return this;
            }

            public AccountBlob.Builder ClearEmail()
            {
                this.PrepareBuilder();
                this.result.email_.Clear();
                return this;
            }

            public AccountBlob.Builder ClearFlags()
            {
                this.PrepareBuilder();
                this.result.hasFlags = false;
                this.result.flags_ = 0L;
                return this;
            }

            public AccountBlob.Builder ClearFullName()
            {
                this.PrepareBuilder();
                this.result.hasFullName = false;
                this.result.fullName_ = string.Empty;
                return this;
            }

            public AccountBlob.Builder ClearId()
            {
                this.PrepareBuilder();
                this.result.hasId = false;
                this.result.id_ = 0;
                return this;
            }

            public AccountBlob.Builder ClearLegalLocale()
            {
                this.PrepareBuilder();
                this.result.hasLegalLocale = false;
                this.result.legalLocale_ = 0;
                return this;
            }

            public AccountBlob.Builder ClearLegalRegion()
            {
                this.PrepareBuilder();
                this.result.hasLegalRegion = false;
                this.result.legalRegion_ = 0;
                return this;
            }

            public AccountBlob.Builder ClearLicenses()
            {
                this.PrepareBuilder();
                this.result.licenses_.Clear();
                return this;
            }

            public AccountBlob.Builder ClearRegion()
            {
                this.PrepareBuilder();
                this.result.hasRegion = false;
                this.result.region_ = 0;
                return this;
            }

            public AccountBlob.Builder ClearSecureRelease()
            {
                this.PrepareBuilder();
                this.result.hasSecureRelease = false;
                this.result.secureRelease_ = 0L;
                return this;
            }

            public AccountBlob.Builder ClearWhitelistEnd()
            {
                this.PrepareBuilder();
                this.result.hasWhitelistEnd = false;
                this.result.whitelistEnd_ = 0L;
                return this;
            }

            public AccountBlob.Builder ClearWhitelistStart()
            {
                this.PrepareBuilder();
                this.result.hasWhitelistStart = false;
                this.result.whitelistStart_ = 0L;
                return this;
            }

            public override AccountBlob.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AccountBlob.Builder(this.result);
                }
                return new AccountBlob.Builder().MergeFrom(this.result);
            }

            public GameAccountLink GetAccountLinks(int index)
            {
                return this.result.GetAccountLinks(index);
            }

            public AccountCredential GetCredentials(int index)
            {
                return this.result.GetCredentials(index);
            }

            public string GetEmail(int index)
            {
                return this.result.GetEmail(index);
            }

            public AccountLicense GetLicenses(int index)
            {
                return this.result.GetLicenses(index);
            }

            public override AccountBlob.Builder MergeFrom(AccountBlob other)
            {
                if (other != AccountBlob.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasId)
                    {
                        this.Id = other.Id;
                    }
                    if (other.HasRegion)
                    {
                        this.Region = other.Region;
                    }
                    if (other.email_.Count != 0)
                    {
                        this.result.email_.Add(other.email_);
                    }
                    if (other.HasFlags)
                    {
                        this.Flags = other.Flags;
                    }
                    if (other.HasSecureRelease)
                    {
                        this.SecureRelease = other.SecureRelease;
                    }
                    if (other.HasWhitelistStart)
                    {
                        this.WhitelistStart = other.WhitelistStart;
                    }
                    if (other.HasWhitelistEnd)
                    {
                        this.WhitelistEnd = other.WhitelistEnd;
                    }
                    if (other.HasFullName)
                    {
                        this.FullName = other.FullName;
                    }
                    if (other.licenses_.Count != 0)
                    {
                        this.result.licenses_.Add(other.licenses_);
                    }
                    if (other.credentials_.Count != 0)
                    {
                        this.result.credentials_.Add(other.credentials_);
                    }
                    if (other.accountLinks_.Count != 0)
                    {
                        this.result.accountLinks_.Add(other.accountLinks_);
                    }
                    if (other.HasBattleTag)
                    {
                        this.BattleTag = other.BattleTag;
                    }
                    if (other.HasDefaultCurrency)
                    {
                        this.DefaultCurrency = other.DefaultCurrency;
                    }
                    if (other.HasLegalRegion)
                    {
                        this.LegalRegion = other.LegalRegion;
                    }
                    if (other.HasLegalLocale)
                    {
                        this.LegalLocale = other.LegalLocale;
                    }
                    if (other.HasCacheExpiration)
                    {
                        this.CacheExpiration = other.CacheExpiration;
                    }
                }
                return this;
            }

            public override AccountBlob.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AccountBlob.Builder MergeFrom(IMessageLite other)
            {
                if (other is AccountBlob)
                {
                    return this.MergeFrom((AccountBlob) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AccountBlob.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AccountBlob._accountBlobFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AccountBlob._accountBlobFieldTags[index];
                        }
                        else
                        {
                            this.ParseUnknownField(input, extensionRegistry, num, str);
                            continue;
                        }
                    }
                    switch (num)
                    {
                        case 0x15:
                        {
                            this.result.hasId = input.ReadFixed32(ref this.result.id_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasRegion = input.ReadUInt32(ref this.result.region_);
                            continue;
                        }
                        case 0xcd:
                        {
                            this.result.hasDefaultCurrency = input.ReadFixed32(ref this.result.defaultCurrency_);
                            continue;
                        }
                        case 0xd0:
                        {
                            this.result.hasLegalRegion = input.ReadUInt32(ref this.result.legalRegion_);
                            continue;
                        }
                        case 0:
                            throw InvalidProtocolBufferException.InvalidTag();

                        case 0x22:
                            goto Label_0167;

                        case 40:
                            goto Label_017F;

                        case 0x30:
                            goto Label_01A0;

                        case 0x38:
                            goto Label_01C1;

                        case 0x40:
                            goto Label_01E2;

                        case 0x52:
                            goto Label_0203;

                        case 0xa2:
                            goto Label_0224;

                        case 170:
                            goto Label_0242;

                        case 0xb2:
                            goto Label_0260;

                        case 0xba:
                            goto Label_027E;

                        case 0xdd:
                            goto Label_02E1;

                        case 240:
                            goto Label_0302;

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
                Label_0167:
                    input.ReadStringArray(num, str, this.result.email_);
                    continue;
                Label_017F:
                    this.result.hasFlags = input.ReadUInt64(ref this.result.flags_);
                    continue;
                Label_01A0:
                    this.result.hasSecureRelease = input.ReadUInt64(ref this.result.secureRelease_);
                    continue;
                Label_01C1:
                    this.result.hasWhitelistStart = input.ReadUInt64(ref this.result.whitelistStart_);
                    continue;
                Label_01E2:
                    this.result.hasWhitelistEnd = input.ReadUInt64(ref this.result.whitelistEnd_);
                    continue;
                Label_0203:
                    this.result.hasFullName = input.ReadString(ref this.result.fullName_);
                    continue;
                Label_0224:
                    input.ReadMessageArray<AccountLicense>(num, str, this.result.licenses_, AccountLicense.DefaultInstance, extensionRegistry);
                    continue;
                Label_0242:
                    input.ReadMessageArray<AccountCredential>(num, str, this.result.credentials_, AccountCredential.DefaultInstance, extensionRegistry);
                    continue;
                Label_0260:
                    input.ReadMessageArray<GameAccountLink>(num, str, this.result.accountLinks_, GameAccountLink.DefaultInstance, extensionRegistry);
                    continue;
                Label_027E:
                    this.result.hasBattleTag = input.ReadString(ref this.result.battleTag_);
                    continue;
                Label_02E1:
                    this.result.hasLegalLocale = input.ReadFixed32(ref this.result.legalLocale_);
                    continue;
                Label_0302:
                    this.result.hasCacheExpiration = input.ReadUInt64(ref this.result.cacheExpiration_);
                }
                return this;
            }

            private AccountBlob PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AccountBlob result = this.result;
                    this.result = new AccountBlob();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public AccountBlob.Builder SetAccountLinks(int index, GameAccountLink value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.accountLinks_[index] = value;
                return this;
            }

            public AccountBlob.Builder SetAccountLinks(int index, GameAccountLink.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.accountLinks_[index] = builderForValue.Build();
                return this;
            }

            public AccountBlob.Builder SetBattleTag(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasBattleTag = true;
                this.result.battleTag_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public AccountBlob.Builder SetCacheExpiration(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasCacheExpiration = true;
                this.result.cacheExpiration_ = value;
                return this;
            }

            public AccountBlob.Builder SetCredentials(int index, AccountCredential value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.credentials_[index] = value;
                return this;
            }

            public AccountBlob.Builder SetCredentials(int index, AccountCredential.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.credentials_[index] = builderForValue.Build();
                return this;
            }

            [CLSCompliant(false)]
            public AccountBlob.Builder SetDefaultCurrency(uint value)
            {
                this.PrepareBuilder();
                this.result.hasDefaultCurrency = true;
                this.result.defaultCurrency_ = value;
                return this;
            }

            public AccountBlob.Builder SetEmail(int index, string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.email_[index] = value;
                return this;
            }

            [CLSCompliant(false)]
            public AccountBlob.Builder SetFlags(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasFlags = true;
                this.result.flags_ = value;
                return this;
            }

            public AccountBlob.Builder SetFullName(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasFullName = true;
                this.result.fullName_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public AccountBlob.Builder SetId(uint value)
            {
                this.PrepareBuilder();
                this.result.hasId = true;
                this.result.id_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public AccountBlob.Builder SetLegalLocale(uint value)
            {
                this.PrepareBuilder();
                this.result.hasLegalLocale = true;
                this.result.legalLocale_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public AccountBlob.Builder SetLegalRegion(uint value)
            {
                this.PrepareBuilder();
                this.result.hasLegalRegion = true;
                this.result.legalRegion_ = value;
                return this;
            }

            public AccountBlob.Builder SetLicenses(int index, AccountLicense value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.licenses_[index] = value;
                return this;
            }

            public AccountBlob.Builder SetLicenses(int index, AccountLicense.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.licenses_[index] = builderForValue.Build();
                return this;
            }

            [CLSCompliant(false)]
            public AccountBlob.Builder SetRegion(uint value)
            {
                this.PrepareBuilder();
                this.result.hasRegion = true;
                this.result.region_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public AccountBlob.Builder SetSecureRelease(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasSecureRelease = true;
                this.result.secureRelease_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public AccountBlob.Builder SetWhitelistEnd(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasWhitelistEnd = true;
                this.result.whitelistEnd_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public AccountBlob.Builder SetWhitelistStart(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasWhitelistStart = true;
                this.result.whitelistStart_ = value;
                return this;
            }

            public int AccountLinksCount
            {
                get
                {
                    return this.result.AccountLinksCount;
                }
            }

            public IPopsicleList<GameAccountLink> AccountLinksList
            {
                get
                {
                    return this.PrepareBuilder().accountLinks_;
                }
            }

            public string BattleTag
            {
                get
                {
                    return this.result.BattleTag;
                }
                set
                {
                    this.SetBattleTag(value);
                }
            }

            [CLSCompliant(false)]
            public ulong CacheExpiration
            {
                get
                {
                    return this.result.CacheExpiration;
                }
                set
                {
                    this.SetCacheExpiration(value);
                }
            }

            public int CredentialsCount
            {
                get
                {
                    return this.result.CredentialsCount;
                }
            }

            public IPopsicleList<AccountCredential> CredentialsList
            {
                get
                {
                    return this.PrepareBuilder().credentials_;
                }
            }

            [CLSCompliant(false)]
            public uint DefaultCurrency
            {
                get
                {
                    return this.result.DefaultCurrency;
                }
                set
                {
                    this.SetDefaultCurrency(value);
                }
            }

            public override AccountBlob DefaultInstanceForType
            {
                get
                {
                    return AccountBlob.DefaultInstance;
                }
            }

            public int EmailCount
            {
                get
                {
                    return this.result.EmailCount;
                }
            }

            public IPopsicleList<string> EmailList
            {
                get
                {
                    return this.PrepareBuilder().email_;
                }
            }

            [CLSCompliant(false)]
            public ulong Flags
            {
                get
                {
                    return this.result.Flags;
                }
                set
                {
                    this.SetFlags(value);
                }
            }

            public string FullName
            {
                get
                {
                    return this.result.FullName;
                }
                set
                {
                    this.SetFullName(value);
                }
            }

            public bool HasBattleTag
            {
                get
                {
                    return this.result.hasBattleTag;
                }
            }

            public bool HasCacheExpiration
            {
                get
                {
                    return this.result.hasCacheExpiration;
                }
            }

            public bool HasDefaultCurrency
            {
                get
                {
                    return this.result.hasDefaultCurrency;
                }
            }

            public bool HasFlags
            {
                get
                {
                    return this.result.hasFlags;
                }
            }

            public bool HasFullName
            {
                get
                {
                    return this.result.hasFullName;
                }
            }

            public bool HasId
            {
                get
                {
                    return this.result.hasId;
                }
            }

            public bool HasLegalLocale
            {
                get
                {
                    return this.result.hasLegalLocale;
                }
            }

            public bool HasLegalRegion
            {
                get
                {
                    return this.result.hasLegalRegion;
                }
            }

            public bool HasRegion
            {
                get
                {
                    return this.result.hasRegion;
                }
            }

            public bool HasSecureRelease
            {
                get
                {
                    return this.result.hasSecureRelease;
                }
            }

            public bool HasWhitelistEnd
            {
                get
                {
                    return this.result.hasWhitelistEnd;
                }
            }

            public bool HasWhitelistStart
            {
                get
                {
                    return this.result.hasWhitelistStart;
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

            [CLSCompliant(false)]
            public uint LegalLocale
            {
                get
                {
                    return this.result.LegalLocale;
                }
                set
                {
                    this.SetLegalLocale(value);
                }
            }

            [CLSCompliant(false)]
            public uint LegalRegion
            {
                get
                {
                    return this.result.LegalRegion;
                }
                set
                {
                    this.SetLegalRegion(value);
                }
            }

            public int LicensesCount
            {
                get
                {
                    return this.result.LicensesCount;
                }
            }

            public IPopsicleList<AccountLicense> LicensesList
            {
                get
                {
                    return this.PrepareBuilder().licenses_;
                }
            }

            protected override AccountBlob MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            [CLSCompliant(false)]
            public uint Region
            {
                get
                {
                    return this.result.Region;
                }
                set
                {
                    this.SetRegion(value);
                }
            }

            [CLSCompliant(false)]
            public ulong SecureRelease
            {
                get
                {
                    return this.result.SecureRelease;
                }
                set
                {
                    this.SetSecureRelease(value);
                }
            }

            protected override AccountBlob.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            [CLSCompliant(false)]
            public ulong WhitelistEnd
            {
                get
                {
                    return this.result.WhitelistEnd;
                }
                set
                {
                    this.SetWhitelistEnd(value);
                }
            }

            [CLSCompliant(false)]
            public ulong WhitelistStart
            {
                get
                {
                    return this.result.WhitelistStart;
                }
                set
                {
                    this.SetWhitelistStart(value);
                }
            }
        }
    }
}

