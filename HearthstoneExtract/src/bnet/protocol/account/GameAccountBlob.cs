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

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class GameAccountBlob : GeneratedMessageLite<GameAccountBlob, Builder>
    {
        private static readonly string[] _gameAccountBlobFieldNames = new string[] { "billing_flags", "cache_expiration", "flags", "game_account", "licenses", "name", "realm_permissions", "status", "subscription_expiration", "units_remaining" };
        private static readonly uint[] _gameAccountBlobFieldTags = new uint[] { 0x30, 0x38, 40, 10, 0xa2, 0x12, 0x18, 0x20, 80, 0x58 };
        private uint billingFlags_;
        public const int BillingFlagsFieldNumber = 6;
        private ulong cacheExpiration_;
        public const int CacheExpirationFieldNumber = 7;
        private static readonly GameAccountBlob defaultInstance = new GameAccountBlob().MakeReadOnly();
        private ulong flags_;
        public const int FlagsFieldNumber = 5;
        private GameAccountHandle gameAccount_;
        public const int GameAccountFieldNumber = 1;
        private bool hasBillingFlags;
        private bool hasCacheExpiration;
        private bool hasFlags;
        private bool hasGameAccount;
        private bool hasName;
        private bool hasRealmPermissions;
        private bool hasStatus;
        private bool hasSubscriptionExpiration;
        private bool hasUnitsRemaining;
        private PopsicleList<AccountLicense> licenses_ = new PopsicleList<AccountLicense>();
        public const int LicensesFieldNumber = 20;
        private int memoizedSerializedSize = -1;
        private string name_ = string.Empty;
        public const int NameFieldNumber = 2;
        private uint realmPermissions_;
        public const int RealmPermissionsFieldNumber = 3;
        private uint status_;
        public const int StatusFieldNumber = 4;
        private ulong subscriptionExpiration_;
        public const int SubscriptionExpirationFieldNumber = 10;
        private uint unitsRemaining_;
        public const int UnitsRemainingFieldNumber = 11;

        static GameAccountBlob()
        {
            object.ReferenceEquals(AccountTypes.Descriptor, null);
        }

        private GameAccountBlob()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GameAccountBlob prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GameAccountBlob blob = obj as GameAccountBlob;
            if (blob == null)
            {
                return false;
            }
            if ((this.hasGameAccount != blob.hasGameAccount) || (this.hasGameAccount && !this.gameAccount_.Equals(blob.gameAccount_)))
            {
                return false;
            }
            if ((this.hasName != blob.hasName) || (this.hasName && !this.name_.Equals(blob.name_)))
            {
                return false;
            }
            if ((this.hasRealmPermissions != blob.hasRealmPermissions) || (this.hasRealmPermissions && !this.realmPermissions_.Equals(blob.realmPermissions_)))
            {
                return false;
            }
            if ((this.hasStatus != blob.hasStatus) || (this.hasStatus && !this.status_.Equals(blob.status_)))
            {
                return false;
            }
            if ((this.hasFlags != blob.hasFlags) || (this.hasFlags && !this.flags_.Equals(blob.flags_)))
            {
                return false;
            }
            if ((this.hasBillingFlags != blob.hasBillingFlags) || (this.hasBillingFlags && !this.billingFlags_.Equals(blob.billingFlags_)))
            {
                return false;
            }
            if ((this.hasCacheExpiration != blob.hasCacheExpiration) || (this.hasCacheExpiration && !this.cacheExpiration_.Equals(blob.cacheExpiration_)))
            {
                return false;
            }
            if ((this.hasSubscriptionExpiration != blob.hasSubscriptionExpiration) || (this.hasSubscriptionExpiration && !this.subscriptionExpiration_.Equals(blob.subscriptionExpiration_)))
            {
                return false;
            }
            if ((this.hasUnitsRemaining != blob.hasUnitsRemaining) || (this.hasUnitsRemaining && !this.unitsRemaining_.Equals(blob.unitsRemaining_)))
            {
                return false;
            }
            if (this.licenses_.Count != blob.licenses_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.licenses_.Count; i++)
            {
                if (!this.licenses_[i].Equals(blob.licenses_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasGameAccount)
            {
                hashCode ^= this.gameAccount_.GetHashCode();
            }
            if (this.hasName)
            {
                hashCode ^= this.name_.GetHashCode();
            }
            if (this.hasRealmPermissions)
            {
                hashCode ^= this.realmPermissions_.GetHashCode();
            }
            if (this.hasStatus)
            {
                hashCode ^= this.status_.GetHashCode();
            }
            if (this.hasFlags)
            {
                hashCode ^= this.flags_.GetHashCode();
            }
            if (this.hasBillingFlags)
            {
                hashCode ^= this.billingFlags_.GetHashCode();
            }
            if (this.hasCacheExpiration)
            {
                hashCode ^= this.cacheExpiration_.GetHashCode();
            }
            if (this.hasSubscriptionExpiration)
            {
                hashCode ^= this.subscriptionExpiration_.GetHashCode();
            }
            if (this.hasUnitsRemaining)
            {
                hashCode ^= this.unitsRemaining_.GetHashCode();
            }
            IEnumerator<AccountLicense> enumerator = this.licenses_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    AccountLicense current = enumerator.Current;
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
            return hashCode;
        }

        public AccountLicense GetLicenses(int index)
        {
            return this.licenses_[index];
        }

        private GameAccountBlob MakeReadOnly()
        {
            this.licenses_.MakeReadOnly();
            return this;
        }

        public static GameAccountBlob ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GameAccountBlob ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameAccountBlob ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GameAccountBlob ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GameAccountBlob ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GameAccountBlob ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GameAccountBlob ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GameAccountBlob ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameAccountBlob ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameAccountBlob ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GameAccountBlob, Builder>.PrintField("game_account", this.hasGameAccount, this.gameAccount_, writer);
            GeneratedMessageLite<GameAccountBlob, Builder>.PrintField("name", this.hasName, this.name_, writer);
            GeneratedMessageLite<GameAccountBlob, Builder>.PrintField("realm_permissions", this.hasRealmPermissions, this.realmPermissions_, writer);
            GeneratedMessageLite<GameAccountBlob, Builder>.PrintField("status", this.hasStatus, this.status_, writer);
            GeneratedMessageLite<GameAccountBlob, Builder>.PrintField("flags", this.hasFlags, this.flags_, writer);
            GeneratedMessageLite<GameAccountBlob, Builder>.PrintField("billing_flags", this.hasBillingFlags, this.billingFlags_, writer);
            GeneratedMessageLite<GameAccountBlob, Builder>.PrintField("cache_expiration", this.hasCacheExpiration, this.cacheExpiration_, writer);
            GeneratedMessageLite<GameAccountBlob, Builder>.PrintField("subscription_expiration", this.hasSubscriptionExpiration, this.subscriptionExpiration_, writer);
            GeneratedMessageLite<GameAccountBlob, Builder>.PrintField("units_remaining", this.hasUnitsRemaining, this.unitsRemaining_, writer);
            GeneratedMessageLite<GameAccountBlob, Builder>.PrintField<AccountLicense>("licenses", this.licenses_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _gameAccountBlobFieldNames;
            if (this.hasGameAccount)
            {
                output.WriteMessage(1, strArray[3], this.GameAccount);
            }
            if (this.hasName)
            {
                output.WriteString(2, strArray[5], this.Name);
            }
            if (this.hasRealmPermissions)
            {
                output.WriteUInt32(3, strArray[6], this.RealmPermissions);
            }
            if (this.hasStatus)
            {
                output.WriteUInt32(4, strArray[7], this.Status);
            }
            if (this.hasFlags)
            {
                output.WriteUInt64(5, strArray[2], this.Flags);
            }
            if (this.hasBillingFlags)
            {
                output.WriteUInt32(6, strArray[0], this.BillingFlags);
            }
            if (this.hasCacheExpiration)
            {
                output.WriteUInt64(7, strArray[1], this.CacheExpiration);
            }
            if (this.hasSubscriptionExpiration)
            {
                output.WriteUInt64(10, strArray[8], this.SubscriptionExpiration);
            }
            if (this.hasUnitsRemaining)
            {
                output.WriteUInt32(11, strArray[9], this.UnitsRemaining);
            }
            if (this.licenses_.Count > 0)
            {
                output.WriteMessageArray<AccountLicense>(20, strArray[4], this.licenses_);
            }
        }

        [CLSCompliant(false)]
        public uint BillingFlags
        {
            get
            {
                return this.billingFlags_;
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

        public static GameAccountBlob DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GameAccountBlob DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
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

        public GameAccountHandle GameAccount
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.gameAccount_ != null)
                {
                    goto Label_0012;
                }
                return GameAccountHandle.DefaultInstance;
            }
        }

        public bool HasBillingFlags
        {
            get
            {
                return this.hasBillingFlags;
            }
        }

        public bool HasCacheExpiration
        {
            get
            {
                return this.hasCacheExpiration;
            }
        }

        public bool HasFlags
        {
            get
            {
                return this.hasFlags;
            }
        }

        public bool HasGameAccount
        {
            get
            {
                return this.hasGameAccount;
            }
        }

        public bool HasName
        {
            get
            {
                return this.hasName;
            }
        }

        public bool HasRealmPermissions
        {
            get
            {
                return this.hasRealmPermissions;
            }
        }

        public bool HasStatus
        {
            get
            {
                return this.hasStatus;
            }
        }

        public bool HasSubscriptionExpiration
        {
            get
            {
                return this.hasSubscriptionExpiration;
            }
        }

        public bool HasUnitsRemaining
        {
            get
            {
                return this.hasUnitsRemaining;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasGameAccount)
                {
                    return false;
                }
                if (!this.hasStatus)
                {
                    return false;
                }
                if (!this.hasCacheExpiration)
                {
                    return false;
                }
                if (!this.GameAccount.IsInitialized)
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
                return true;
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

        public string Name
        {
            get
            {
                return this.name_;
            }
        }

        [CLSCompliant(false)]
        public uint RealmPermissions
        {
            get
            {
                return this.realmPermissions_;
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
                    if (this.hasGameAccount)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.GameAccount);
                    }
                    if (this.hasName)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(2, this.Name);
                    }
                    if (this.hasRealmPermissions)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(3, this.RealmPermissions);
                    }
                    if (this.hasStatus)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(4, this.Status);
                    }
                    if (this.hasFlags)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(5, this.Flags);
                    }
                    if (this.hasBillingFlags)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(6, this.BillingFlags);
                    }
                    if (this.hasCacheExpiration)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(7, this.CacheExpiration);
                    }
                    if (this.hasSubscriptionExpiration)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(10, this.SubscriptionExpiration);
                    }
                    if (this.hasUnitsRemaining)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(11, this.UnitsRemaining);
                    }
                    IEnumerator<AccountLicense> enumerator = this.LicensesList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            AccountLicense current = enumerator.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(20, current);
                        }
                    }
                    finally
                    {
                        if (enumerator == null)
                        {
                        }
                        enumerator.Dispose();
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        [CLSCompliant(false)]
        public uint Status
        {
            get
            {
                return this.status_;
            }
        }

        [CLSCompliant(false)]
        public ulong SubscriptionExpiration
        {
            get
            {
                return this.subscriptionExpiration_;
            }
        }

        protected override GameAccountBlob ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CLSCompliant(false)]
        public uint UnitsRemaining
        {
            get
            {
                return this.unitsRemaining_;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<GameAccountBlob, GameAccountBlob.Builder>
        {
            private GameAccountBlob result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GameAccountBlob.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GameAccountBlob cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public GameAccountBlob.Builder AddLicenses(AccountLicense value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.licenses_.Add(value);
                return this;
            }

            public GameAccountBlob.Builder AddLicenses(AccountLicense.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.licenses_.Add(builderForValue.Build());
                return this;
            }

            public GameAccountBlob.Builder AddRangeLicenses(IEnumerable<AccountLicense> values)
            {
                this.PrepareBuilder();
                this.result.licenses_.Add(values);
                return this;
            }

            public override GameAccountBlob BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GameAccountBlob.Builder Clear()
            {
                this.result = GameAccountBlob.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GameAccountBlob.Builder ClearBillingFlags()
            {
                this.PrepareBuilder();
                this.result.hasBillingFlags = false;
                this.result.billingFlags_ = 0;
                return this;
            }

            public GameAccountBlob.Builder ClearCacheExpiration()
            {
                this.PrepareBuilder();
                this.result.hasCacheExpiration = false;
                this.result.cacheExpiration_ = 0L;
                return this;
            }

            public GameAccountBlob.Builder ClearFlags()
            {
                this.PrepareBuilder();
                this.result.hasFlags = false;
                this.result.flags_ = 0L;
                return this;
            }

            public GameAccountBlob.Builder ClearGameAccount()
            {
                this.PrepareBuilder();
                this.result.hasGameAccount = false;
                this.result.gameAccount_ = null;
                return this;
            }

            public GameAccountBlob.Builder ClearLicenses()
            {
                this.PrepareBuilder();
                this.result.licenses_.Clear();
                return this;
            }

            public GameAccountBlob.Builder ClearName()
            {
                this.PrepareBuilder();
                this.result.hasName = false;
                this.result.name_ = string.Empty;
                return this;
            }

            public GameAccountBlob.Builder ClearRealmPermissions()
            {
                this.PrepareBuilder();
                this.result.hasRealmPermissions = false;
                this.result.realmPermissions_ = 0;
                return this;
            }

            public GameAccountBlob.Builder ClearStatus()
            {
                this.PrepareBuilder();
                this.result.hasStatus = false;
                this.result.status_ = 0;
                return this;
            }

            public GameAccountBlob.Builder ClearSubscriptionExpiration()
            {
                this.PrepareBuilder();
                this.result.hasSubscriptionExpiration = false;
                this.result.subscriptionExpiration_ = 0L;
                return this;
            }

            public GameAccountBlob.Builder ClearUnitsRemaining()
            {
                this.PrepareBuilder();
                this.result.hasUnitsRemaining = false;
                this.result.unitsRemaining_ = 0;
                return this;
            }

            public override GameAccountBlob.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GameAccountBlob.Builder(this.result);
                }
                return new GameAccountBlob.Builder().MergeFrom(this.result);
            }

            public AccountLicense GetLicenses(int index)
            {
                return this.result.GetLicenses(index);
            }

            public override GameAccountBlob.Builder MergeFrom(GameAccountBlob other)
            {
                if (other != GameAccountBlob.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasGameAccount)
                    {
                        this.MergeGameAccount(other.GameAccount);
                    }
                    if (other.HasName)
                    {
                        this.Name = other.Name;
                    }
                    if (other.HasRealmPermissions)
                    {
                        this.RealmPermissions = other.RealmPermissions;
                    }
                    if (other.HasStatus)
                    {
                        this.Status = other.Status;
                    }
                    if (other.HasFlags)
                    {
                        this.Flags = other.Flags;
                    }
                    if (other.HasBillingFlags)
                    {
                        this.BillingFlags = other.BillingFlags;
                    }
                    if (other.HasCacheExpiration)
                    {
                        this.CacheExpiration = other.CacheExpiration;
                    }
                    if (other.HasSubscriptionExpiration)
                    {
                        this.SubscriptionExpiration = other.SubscriptionExpiration;
                    }
                    if (other.HasUnitsRemaining)
                    {
                        this.UnitsRemaining = other.UnitsRemaining;
                    }
                    if (other.licenses_.Count != 0)
                    {
                        this.result.licenses_.Add(other.licenses_);
                    }
                }
                return this;
            }

            public override GameAccountBlob.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GameAccountBlob.Builder MergeFrom(IMessageLite other)
            {
                if (other is GameAccountBlob)
                {
                    return this.MergeFrom((GameAccountBlob) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GameAccountBlob.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GameAccountBlob._gameAccountBlobFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GameAccountBlob._gameAccountBlobFieldTags[index];
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
                            GameAccountHandle.Builder builder = GameAccountHandle.CreateBuilder();
                            if (this.result.hasGameAccount)
                            {
                                builder.MergeFrom(this.GameAccount);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.GameAccount = builder.BuildPartial();
                            continue;
                        }
                        case 0x12:
                        {
                            this.result.hasName = input.ReadString(ref this.result.name_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasRealmPermissions = input.ReadUInt32(ref this.result.realmPermissions_);
                            continue;
                        }
                        case 0x20:
                        {
                            this.result.hasStatus = input.ReadUInt32(ref this.result.status_);
                            continue;
                        }
                        case 40:
                        {
                            this.result.hasFlags = input.ReadUInt64(ref this.result.flags_);
                            continue;
                        }
                        case 0x30:
                        {
                            this.result.hasBillingFlags = input.ReadUInt32(ref this.result.billingFlags_);
                            continue;
                        }
                        case 0x38:
                        {
                            this.result.hasCacheExpiration = input.ReadUInt64(ref this.result.cacheExpiration_);
                            continue;
                        }
                        case 80:
                        {
                            this.result.hasSubscriptionExpiration = input.ReadUInt64(ref this.result.subscriptionExpiration_);
                            continue;
                        }
                        case 0x58:
                        {
                            this.result.hasUnitsRemaining = input.ReadUInt32(ref this.result.unitsRemaining_);
                            continue;
                        }
                        case 0xa2:
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
                    input.ReadMessageArray<AccountLicense>(num, str, this.result.licenses_, AccountLicense.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            public GameAccountBlob.Builder MergeGameAccount(GameAccountHandle value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasGameAccount && (this.result.gameAccount_ != GameAccountHandle.DefaultInstance))
                {
                    this.result.gameAccount_ = GameAccountHandle.CreateBuilder(this.result.gameAccount_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.gameAccount_ = value;
                }
                this.result.hasGameAccount = true;
                return this;
            }

            private GameAccountBlob PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GameAccountBlob result = this.result;
                    this.result = new GameAccountBlob();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public GameAccountBlob.Builder SetBillingFlags(uint value)
            {
                this.PrepareBuilder();
                this.result.hasBillingFlags = true;
                this.result.billingFlags_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public GameAccountBlob.Builder SetCacheExpiration(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasCacheExpiration = true;
                this.result.cacheExpiration_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public GameAccountBlob.Builder SetFlags(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasFlags = true;
                this.result.flags_ = value;
                return this;
            }

            public GameAccountBlob.Builder SetGameAccount(GameAccountHandle value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasGameAccount = true;
                this.result.gameAccount_ = value;
                return this;
            }

            public GameAccountBlob.Builder SetGameAccount(GameAccountHandle.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasGameAccount = true;
                this.result.gameAccount_ = builderForValue.Build();
                return this;
            }

            public GameAccountBlob.Builder SetLicenses(int index, AccountLicense value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.licenses_[index] = value;
                return this;
            }

            public GameAccountBlob.Builder SetLicenses(int index, AccountLicense.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.licenses_[index] = builderForValue.Build();
                return this;
            }

            public GameAccountBlob.Builder SetName(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasName = true;
                this.result.name_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public GameAccountBlob.Builder SetRealmPermissions(uint value)
            {
                this.PrepareBuilder();
                this.result.hasRealmPermissions = true;
                this.result.realmPermissions_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public GameAccountBlob.Builder SetStatus(uint value)
            {
                this.PrepareBuilder();
                this.result.hasStatus = true;
                this.result.status_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public GameAccountBlob.Builder SetSubscriptionExpiration(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasSubscriptionExpiration = true;
                this.result.subscriptionExpiration_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public GameAccountBlob.Builder SetUnitsRemaining(uint value)
            {
                this.PrepareBuilder();
                this.result.hasUnitsRemaining = true;
                this.result.unitsRemaining_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public uint BillingFlags
            {
                get
                {
                    return this.result.BillingFlags;
                }
                set
                {
                    this.SetBillingFlags(value);
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

            public override GameAccountBlob DefaultInstanceForType
            {
                get
                {
                    return GameAccountBlob.DefaultInstance;
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

            public GameAccountHandle GameAccount
            {
                get
                {
                    return this.result.GameAccount;
                }
                set
                {
                    this.SetGameAccount(value);
                }
            }

            public bool HasBillingFlags
            {
                get
                {
                    return this.result.hasBillingFlags;
                }
            }

            public bool HasCacheExpiration
            {
                get
                {
                    return this.result.hasCacheExpiration;
                }
            }

            public bool HasFlags
            {
                get
                {
                    return this.result.hasFlags;
                }
            }

            public bool HasGameAccount
            {
                get
                {
                    return this.result.hasGameAccount;
                }
            }

            public bool HasName
            {
                get
                {
                    return this.result.hasName;
                }
            }

            public bool HasRealmPermissions
            {
                get
                {
                    return this.result.hasRealmPermissions;
                }
            }

            public bool HasStatus
            {
                get
                {
                    return this.result.hasStatus;
                }
            }

            public bool HasSubscriptionExpiration
            {
                get
                {
                    return this.result.hasSubscriptionExpiration;
                }
            }

            public bool HasUnitsRemaining
            {
                get
                {
                    return this.result.hasUnitsRemaining;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
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

            protected override GameAccountBlob MessageBeingBuilt
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

            [CLSCompliant(false)]
            public uint RealmPermissions
            {
                get
                {
                    return this.result.RealmPermissions;
                }
                set
                {
                    this.SetRealmPermissions(value);
                }
            }

            [CLSCompliant(false)]
            public uint Status
            {
                get
                {
                    return this.result.Status;
                }
                set
                {
                    this.SetStatus(value);
                }
            }

            [CLSCompliant(false)]
            public ulong SubscriptionExpiration
            {
                get
                {
                    return this.result.SubscriptionExpiration;
                }
                set
                {
                    this.SetSubscriptionExpiration(value);
                }
            }

            protected override GameAccountBlob.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            [CLSCompliant(false)]
            public uint UnitsRemaining
            {
                get
                {
                    return this.result.UnitsRemaining;
                }
                set
                {
                    this.SetUnitsRemaining(value);
                }
            }
        }
    }
}

