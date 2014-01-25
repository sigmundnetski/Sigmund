namespace bnet.protocol.account
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class Wallet : GeneratedMessageLite<Wallet, Builder>
    {
        private static readonly string[] _walletFieldNames = new string[] { "bin", "birth_date", "city", "country_id", "description", "first_name", "last_name", "locale_id", "payment_info", "postal_code", "region", "state", "street", "wallet_id", "wallet_type" };
        private static readonly uint[] _walletFieldTags = new uint[] { 0x52, 120, 0x3a, 40, 0x22, 0x6a, 0x72, 90, 0x4a, 0x42, 8, 50, 0x62, 0x10, 0x18 };
        private string bin_ = string.Empty;
        public const int BinFieldNumber = 10;
        private ulong birthDate_;
        public const int BirthDateFieldNumber = 15;
        private string city_ = string.Empty;
        public const int CityFieldNumber = 7;
        private uint countryId_;
        public const int CountryIdFieldNumber = 5;
        private static readonly Wallet defaultInstance = new Wallet().MakeReadOnly();
        private string description_ = string.Empty;
        public const int DescriptionFieldNumber = 4;
        private string firstName_ = string.Empty;
        public const int FirstNameFieldNumber = 13;
        private bool hasBin;
        private bool hasBirthDate;
        private bool hasCity;
        private bool hasCountryId;
        private bool hasDescription;
        private bool hasFirstName;
        private bool hasLastName;
        private bool hasLocaleId;
        private bool hasPaymentInfo;
        private bool hasPostalCode;
        private bool hasRegion;
        private bool hasState;
        private bool hasStreet;
        private bool hasWalletId;
        private bool hasWalletType;
        private string lastName_ = string.Empty;
        public const int LastNameFieldNumber = 14;
        private string localeId_ = string.Empty;
        public const int LocaleIdFieldNumber = 11;
        private int memoizedSerializedSize = -1;
        private ByteString paymentInfo_ = ByteString.Empty;
        public const int PaymentInfoFieldNumber = 9;
        private string postalCode_ = string.Empty;
        public const int PostalCodeFieldNumber = 8;
        private uint region_;
        public const int RegionFieldNumber = 1;
        private string state_ = string.Empty;
        public const int StateFieldNumber = 6;
        private string street_ = string.Empty;
        public const int StreetFieldNumber = 12;
        private ulong walletId_;
        public const int WalletIdFieldNumber = 2;
        private uint walletType_;
        public const int WalletTypeFieldNumber = 3;

        static Wallet()
        {
            object.ReferenceEquals(AccountTypes.Descriptor, null);
        }

        private Wallet()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(Wallet prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            Wallet wallet = obj as Wallet;
            if (wallet == null)
            {
                return false;
            }
            if ((this.hasRegion != wallet.hasRegion) || (this.hasRegion && !this.region_.Equals(wallet.region_)))
            {
                return false;
            }
            if ((this.hasWalletId != wallet.hasWalletId) || (this.hasWalletId && !this.walletId_.Equals(wallet.walletId_)))
            {
                return false;
            }
            if ((this.hasWalletType != wallet.hasWalletType) || (this.hasWalletType && !this.walletType_.Equals(wallet.walletType_)))
            {
                return false;
            }
            if ((this.hasDescription != wallet.hasDescription) || (this.hasDescription && !this.description_.Equals(wallet.description_)))
            {
                return false;
            }
            if ((this.hasCountryId != wallet.hasCountryId) || (this.hasCountryId && !this.countryId_.Equals(wallet.countryId_)))
            {
                return false;
            }
            if ((this.hasState != wallet.hasState) || (this.hasState && !this.state_.Equals(wallet.state_)))
            {
                return false;
            }
            if ((this.hasCity != wallet.hasCity) || (this.hasCity && !this.city_.Equals(wallet.city_)))
            {
                return false;
            }
            if ((this.hasPostalCode != wallet.hasPostalCode) || (this.hasPostalCode && !this.postalCode_.Equals(wallet.postalCode_)))
            {
                return false;
            }
            if ((this.hasPaymentInfo != wallet.hasPaymentInfo) || (this.hasPaymentInfo && !this.paymentInfo_.Equals(wallet.paymentInfo_)))
            {
                return false;
            }
            if ((this.hasBin != wallet.hasBin) || (this.hasBin && !this.bin_.Equals(wallet.bin_)))
            {
                return false;
            }
            if ((this.hasLocaleId != wallet.hasLocaleId) || (this.hasLocaleId && !this.localeId_.Equals(wallet.localeId_)))
            {
                return false;
            }
            if ((this.hasStreet != wallet.hasStreet) || (this.hasStreet && !this.street_.Equals(wallet.street_)))
            {
                return false;
            }
            if ((this.hasFirstName != wallet.hasFirstName) || (this.hasFirstName && !this.firstName_.Equals(wallet.firstName_)))
            {
                return false;
            }
            if ((this.hasLastName != wallet.hasLastName) || (this.hasLastName && !this.lastName_.Equals(wallet.lastName_)))
            {
                return false;
            }
            return ((this.hasBirthDate == wallet.hasBirthDate) && (!this.hasBirthDate || this.birthDate_.Equals(wallet.birthDate_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasRegion)
            {
                hashCode ^= this.region_.GetHashCode();
            }
            if (this.hasWalletId)
            {
                hashCode ^= this.walletId_.GetHashCode();
            }
            if (this.hasWalletType)
            {
                hashCode ^= this.walletType_.GetHashCode();
            }
            if (this.hasDescription)
            {
                hashCode ^= this.description_.GetHashCode();
            }
            if (this.hasCountryId)
            {
                hashCode ^= this.countryId_.GetHashCode();
            }
            if (this.hasState)
            {
                hashCode ^= this.state_.GetHashCode();
            }
            if (this.hasCity)
            {
                hashCode ^= this.city_.GetHashCode();
            }
            if (this.hasPostalCode)
            {
                hashCode ^= this.postalCode_.GetHashCode();
            }
            if (this.hasPaymentInfo)
            {
                hashCode ^= this.paymentInfo_.GetHashCode();
            }
            if (this.hasBin)
            {
                hashCode ^= this.bin_.GetHashCode();
            }
            if (this.hasLocaleId)
            {
                hashCode ^= this.localeId_.GetHashCode();
            }
            if (this.hasStreet)
            {
                hashCode ^= this.street_.GetHashCode();
            }
            if (this.hasFirstName)
            {
                hashCode ^= this.firstName_.GetHashCode();
            }
            if (this.hasLastName)
            {
                hashCode ^= this.lastName_.GetHashCode();
            }
            if (this.hasBirthDate)
            {
                hashCode ^= this.birthDate_.GetHashCode();
            }
            return hashCode;
        }

        private Wallet MakeReadOnly()
        {
            return this;
        }

        public static Wallet ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static Wallet ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static Wallet ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Wallet ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Wallet ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Wallet ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Wallet ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static Wallet ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Wallet ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Wallet ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<Wallet, Builder>.PrintField("region", this.hasRegion, this.region_, writer);
            GeneratedMessageLite<Wallet, Builder>.PrintField("wallet_id", this.hasWalletId, this.walletId_, writer);
            GeneratedMessageLite<Wallet, Builder>.PrintField("wallet_type", this.hasWalletType, this.walletType_, writer);
            GeneratedMessageLite<Wallet, Builder>.PrintField("description", this.hasDescription, this.description_, writer);
            GeneratedMessageLite<Wallet, Builder>.PrintField("country_id", this.hasCountryId, this.countryId_, writer);
            GeneratedMessageLite<Wallet, Builder>.PrintField("state", this.hasState, this.state_, writer);
            GeneratedMessageLite<Wallet, Builder>.PrintField("city", this.hasCity, this.city_, writer);
            GeneratedMessageLite<Wallet, Builder>.PrintField("postal_code", this.hasPostalCode, this.postalCode_, writer);
            GeneratedMessageLite<Wallet, Builder>.PrintField("payment_info", this.hasPaymentInfo, this.paymentInfo_, writer);
            GeneratedMessageLite<Wallet, Builder>.PrintField("bin", this.hasBin, this.bin_, writer);
            GeneratedMessageLite<Wallet, Builder>.PrintField("locale_id", this.hasLocaleId, this.localeId_, writer);
            GeneratedMessageLite<Wallet, Builder>.PrintField("street", this.hasStreet, this.street_, writer);
            GeneratedMessageLite<Wallet, Builder>.PrintField("first_name", this.hasFirstName, this.firstName_, writer);
            GeneratedMessageLite<Wallet, Builder>.PrintField("last_name", this.hasLastName, this.lastName_, writer);
            GeneratedMessageLite<Wallet, Builder>.PrintField("birth_date", this.hasBirthDate, this.birthDate_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _walletFieldNames;
            if (this.hasRegion)
            {
                output.WriteUInt32(1, strArray[10], this.Region);
            }
            if (this.hasWalletId)
            {
                output.WriteUInt64(2, strArray[13], this.WalletId);
            }
            if (this.hasWalletType)
            {
                output.WriteUInt32(3, strArray[14], this.WalletType);
            }
            if (this.hasDescription)
            {
                output.WriteString(4, strArray[4], this.Description);
            }
            if (this.hasCountryId)
            {
                output.WriteUInt32(5, strArray[3], this.CountryId);
            }
            if (this.hasState)
            {
                output.WriteString(6, strArray[11], this.State);
            }
            if (this.hasCity)
            {
                output.WriteString(7, strArray[2], this.City);
            }
            if (this.hasPostalCode)
            {
                output.WriteString(8, strArray[9], this.PostalCode);
            }
            if (this.hasPaymentInfo)
            {
                output.WriteBytes(9, strArray[8], this.PaymentInfo);
            }
            if (this.hasBin)
            {
                output.WriteString(10, strArray[0], this.Bin);
            }
            if (this.hasLocaleId)
            {
                output.WriteString(11, strArray[7], this.LocaleId);
            }
            if (this.hasStreet)
            {
                output.WriteString(12, strArray[12], this.Street);
            }
            if (this.hasFirstName)
            {
                output.WriteString(13, strArray[5], this.FirstName);
            }
            if (this.hasLastName)
            {
                output.WriteString(14, strArray[6], this.LastName);
            }
            if (this.hasBirthDate)
            {
                output.WriteUInt64(15, strArray[1], this.BirthDate);
            }
        }

        public string Bin
        {
            get
            {
                return this.bin_;
            }
        }

        [CLSCompliant(false)]
        public ulong BirthDate
        {
            get
            {
                return this.birthDate_;
            }
        }

        public string City
        {
            get
            {
                return this.city_;
            }
        }

        [CLSCompliant(false)]
        public uint CountryId
        {
            get
            {
                return this.countryId_;
            }
        }

        public static Wallet DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override Wallet DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public string Description
        {
            get
            {
                return this.description_;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName_;
            }
        }

        public bool HasBin
        {
            get
            {
                return this.hasBin;
            }
        }

        public bool HasBirthDate
        {
            get
            {
                return this.hasBirthDate;
            }
        }

        public bool HasCity
        {
            get
            {
                return this.hasCity;
            }
        }

        public bool HasCountryId
        {
            get
            {
                return this.hasCountryId;
            }
        }

        public bool HasDescription
        {
            get
            {
                return this.hasDescription;
            }
        }

        public bool HasFirstName
        {
            get
            {
                return this.hasFirstName;
            }
        }

        public bool HasLastName
        {
            get
            {
                return this.hasLastName;
            }
        }

        public bool HasLocaleId
        {
            get
            {
                return this.hasLocaleId;
            }
        }

        public bool HasPaymentInfo
        {
            get
            {
                return this.hasPaymentInfo;
            }
        }

        public bool HasPostalCode
        {
            get
            {
                return this.hasPostalCode;
            }
        }

        public bool HasRegion
        {
            get
            {
                return this.hasRegion;
            }
        }

        public bool HasState
        {
            get
            {
                return this.hasState;
            }
        }

        public bool HasStreet
        {
            get
            {
                return this.hasStreet;
            }
        }

        public bool HasWalletId
        {
            get
            {
                return this.hasWalletId;
            }
        }

        public bool HasWalletType
        {
            get
            {
                return this.hasWalletType;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasRegion)
                {
                    return false;
                }
                if (!this.hasWalletId)
                {
                    return false;
                }
                if (!this.hasWalletType)
                {
                    return false;
                }
                if (!this.hasCountryId)
                {
                    return false;
                }
                return true;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName_;
            }
        }

        public string LocaleId
        {
            get
            {
                return this.localeId_;
            }
        }

        public ByteString PaymentInfo
        {
            get
            {
                return this.paymentInfo_;
            }
        }

        public string PostalCode
        {
            get
            {
                return this.postalCode_;
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

        public override int SerializedSize
        {
            get
            {
                int memoizedSerializedSize = this.memoizedSerializedSize;
                if (memoizedSerializedSize == -1)
                {
                    memoizedSerializedSize = 0;
                    if (this.hasRegion)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(1, this.Region);
                    }
                    if (this.hasWalletId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(2, this.WalletId);
                    }
                    if (this.hasWalletType)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(3, this.WalletType);
                    }
                    if (this.hasDescription)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(4, this.Description);
                    }
                    if (this.hasCountryId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(5, this.CountryId);
                    }
                    if (this.hasState)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(6, this.State);
                    }
                    if (this.hasCity)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(7, this.City);
                    }
                    if (this.hasPostalCode)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(8, this.PostalCode);
                    }
                    if (this.hasPaymentInfo)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBytesSize(9, this.PaymentInfo);
                    }
                    if (this.hasBin)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(10, this.Bin);
                    }
                    if (this.hasLocaleId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(11, this.LocaleId);
                    }
                    if (this.hasStreet)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(12, this.Street);
                    }
                    if (this.hasFirstName)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(13, this.FirstName);
                    }
                    if (this.hasLastName)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(14, this.LastName);
                    }
                    if (this.hasBirthDate)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(15, this.BirthDate);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        public string State
        {
            get
            {
                return this.state_;
            }
        }

        public string Street
        {
            get
            {
                return this.street_;
            }
        }

        protected override Wallet ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CLSCompliant(false)]
        public ulong WalletId
        {
            get
            {
                return this.walletId_;
            }
        }

        [CLSCompliant(false)]
        public uint WalletType
        {
            get
            {
                return this.walletType_;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<Wallet, Wallet.Builder>
        {
            private Wallet result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = Wallet.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(Wallet cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override Wallet BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override Wallet.Builder Clear()
            {
                this.result = Wallet.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public Wallet.Builder ClearBin()
            {
                this.PrepareBuilder();
                this.result.hasBin = false;
                this.result.bin_ = string.Empty;
                return this;
            }

            public Wallet.Builder ClearBirthDate()
            {
                this.PrepareBuilder();
                this.result.hasBirthDate = false;
                this.result.birthDate_ = 0L;
                return this;
            }

            public Wallet.Builder ClearCity()
            {
                this.PrepareBuilder();
                this.result.hasCity = false;
                this.result.city_ = string.Empty;
                return this;
            }

            public Wallet.Builder ClearCountryId()
            {
                this.PrepareBuilder();
                this.result.hasCountryId = false;
                this.result.countryId_ = 0;
                return this;
            }

            public Wallet.Builder ClearDescription()
            {
                this.PrepareBuilder();
                this.result.hasDescription = false;
                this.result.description_ = string.Empty;
                return this;
            }

            public Wallet.Builder ClearFirstName()
            {
                this.PrepareBuilder();
                this.result.hasFirstName = false;
                this.result.firstName_ = string.Empty;
                return this;
            }

            public Wallet.Builder ClearLastName()
            {
                this.PrepareBuilder();
                this.result.hasLastName = false;
                this.result.lastName_ = string.Empty;
                return this;
            }

            public Wallet.Builder ClearLocaleId()
            {
                this.PrepareBuilder();
                this.result.hasLocaleId = false;
                this.result.localeId_ = string.Empty;
                return this;
            }

            public Wallet.Builder ClearPaymentInfo()
            {
                this.PrepareBuilder();
                this.result.hasPaymentInfo = false;
                this.result.paymentInfo_ = ByteString.Empty;
                return this;
            }

            public Wallet.Builder ClearPostalCode()
            {
                this.PrepareBuilder();
                this.result.hasPostalCode = false;
                this.result.postalCode_ = string.Empty;
                return this;
            }

            public Wallet.Builder ClearRegion()
            {
                this.PrepareBuilder();
                this.result.hasRegion = false;
                this.result.region_ = 0;
                return this;
            }

            public Wallet.Builder ClearState()
            {
                this.PrepareBuilder();
                this.result.hasState = false;
                this.result.state_ = string.Empty;
                return this;
            }

            public Wallet.Builder ClearStreet()
            {
                this.PrepareBuilder();
                this.result.hasStreet = false;
                this.result.street_ = string.Empty;
                return this;
            }

            public Wallet.Builder ClearWalletId()
            {
                this.PrepareBuilder();
                this.result.hasWalletId = false;
                this.result.walletId_ = 0L;
                return this;
            }

            public Wallet.Builder ClearWalletType()
            {
                this.PrepareBuilder();
                this.result.hasWalletType = false;
                this.result.walletType_ = 0;
                return this;
            }

            public override Wallet.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new Wallet.Builder(this.result);
                }
                return new Wallet.Builder().MergeFrom(this.result);
            }

            public override Wallet.Builder MergeFrom(Wallet other)
            {
                if (other != Wallet.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasRegion)
                    {
                        this.Region = other.Region;
                    }
                    if (other.HasWalletId)
                    {
                        this.WalletId = other.WalletId;
                    }
                    if (other.HasWalletType)
                    {
                        this.WalletType = other.WalletType;
                    }
                    if (other.HasDescription)
                    {
                        this.Description = other.Description;
                    }
                    if (other.HasCountryId)
                    {
                        this.CountryId = other.CountryId;
                    }
                    if (other.HasState)
                    {
                        this.State = other.State;
                    }
                    if (other.HasCity)
                    {
                        this.City = other.City;
                    }
                    if (other.HasPostalCode)
                    {
                        this.PostalCode = other.PostalCode;
                    }
                    if (other.HasPaymentInfo)
                    {
                        this.PaymentInfo = other.PaymentInfo;
                    }
                    if (other.HasBin)
                    {
                        this.Bin = other.Bin;
                    }
                    if (other.HasLocaleId)
                    {
                        this.LocaleId = other.LocaleId;
                    }
                    if (other.HasStreet)
                    {
                        this.Street = other.Street;
                    }
                    if (other.HasFirstName)
                    {
                        this.FirstName = other.FirstName;
                    }
                    if (other.HasLastName)
                    {
                        this.LastName = other.LastName;
                    }
                    if (other.HasBirthDate)
                    {
                        this.BirthDate = other.BirthDate;
                    }
                }
                return this;
            }

            public override Wallet.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override Wallet.Builder MergeFrom(IMessageLite other)
            {
                if (other is Wallet)
                {
                    return this.MergeFrom((Wallet) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override Wallet.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(Wallet._walletFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = Wallet._walletFieldTags[index];
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
                            this.result.hasRegion = input.ReadUInt32(ref this.result.region_);
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasWalletId = input.ReadUInt64(ref this.result.walletId_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasWalletType = input.ReadUInt32(ref this.result.walletType_);
                            continue;
                        }
                        case 0x22:
                        {
                            this.result.hasDescription = input.ReadString(ref this.result.description_);
                            continue;
                        }
                        case 40:
                        {
                            this.result.hasCountryId = input.ReadUInt32(ref this.result.countryId_);
                            continue;
                        }
                        case 50:
                        {
                            this.result.hasState = input.ReadString(ref this.result.state_);
                            continue;
                        }
                        case 0x3a:
                        {
                            this.result.hasCity = input.ReadString(ref this.result.city_);
                            continue;
                        }
                        case 0x42:
                        {
                            this.result.hasPostalCode = input.ReadString(ref this.result.postalCode_);
                            continue;
                        }
                        case 0x4a:
                        {
                            this.result.hasPaymentInfo = input.ReadBytes(ref this.result.paymentInfo_);
                            continue;
                        }
                        case 0x52:
                        {
                            this.result.hasBin = input.ReadString(ref this.result.bin_);
                            continue;
                        }
                        case 90:
                        {
                            this.result.hasLocaleId = input.ReadString(ref this.result.localeId_);
                            continue;
                        }
                        case 0x62:
                        {
                            this.result.hasStreet = input.ReadString(ref this.result.street_);
                            continue;
                        }
                        case 0x6a:
                        {
                            this.result.hasFirstName = input.ReadString(ref this.result.firstName_);
                            continue;
                        }
                        case 0x72:
                        {
                            this.result.hasLastName = input.ReadString(ref this.result.lastName_);
                            continue;
                        }
                        case 120:
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
                    this.result.hasBirthDate = input.ReadUInt64(ref this.result.birthDate_);
                }
                return this;
            }

            private Wallet PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    Wallet result = this.result;
                    this.result = new Wallet();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public Wallet.Builder SetBin(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasBin = true;
                this.result.bin_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public Wallet.Builder SetBirthDate(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasBirthDate = true;
                this.result.birthDate_ = value;
                return this;
            }

            public Wallet.Builder SetCity(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasCity = true;
                this.result.city_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public Wallet.Builder SetCountryId(uint value)
            {
                this.PrepareBuilder();
                this.result.hasCountryId = true;
                this.result.countryId_ = value;
                return this;
            }

            public Wallet.Builder SetDescription(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasDescription = true;
                this.result.description_ = value;
                return this;
            }

            public Wallet.Builder SetFirstName(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasFirstName = true;
                this.result.firstName_ = value;
                return this;
            }

            public Wallet.Builder SetLastName(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasLastName = true;
                this.result.lastName_ = value;
                return this;
            }

            public Wallet.Builder SetLocaleId(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasLocaleId = true;
                this.result.localeId_ = value;
                return this;
            }

            public Wallet.Builder SetPaymentInfo(ByteString value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasPaymentInfo = true;
                this.result.paymentInfo_ = value;
                return this;
            }

            public Wallet.Builder SetPostalCode(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasPostalCode = true;
                this.result.postalCode_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public Wallet.Builder SetRegion(uint value)
            {
                this.PrepareBuilder();
                this.result.hasRegion = true;
                this.result.region_ = value;
                return this;
            }

            public Wallet.Builder SetState(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasState = true;
                this.result.state_ = value;
                return this;
            }

            public Wallet.Builder SetStreet(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasStreet = true;
                this.result.street_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public Wallet.Builder SetWalletId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasWalletId = true;
                this.result.walletId_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public Wallet.Builder SetWalletType(uint value)
            {
                this.PrepareBuilder();
                this.result.hasWalletType = true;
                this.result.walletType_ = value;
                return this;
            }

            public string Bin
            {
                get
                {
                    return this.result.Bin;
                }
                set
                {
                    this.SetBin(value);
                }
            }

            [CLSCompliant(false)]
            public ulong BirthDate
            {
                get
                {
                    return this.result.BirthDate;
                }
                set
                {
                    this.SetBirthDate(value);
                }
            }

            public string City
            {
                get
                {
                    return this.result.City;
                }
                set
                {
                    this.SetCity(value);
                }
            }

            [CLSCompliant(false)]
            public uint CountryId
            {
                get
                {
                    return this.result.CountryId;
                }
                set
                {
                    this.SetCountryId(value);
                }
            }

            public override Wallet DefaultInstanceForType
            {
                get
                {
                    return Wallet.DefaultInstance;
                }
            }

            public string Description
            {
                get
                {
                    return this.result.Description;
                }
                set
                {
                    this.SetDescription(value);
                }
            }

            public string FirstName
            {
                get
                {
                    return this.result.FirstName;
                }
                set
                {
                    this.SetFirstName(value);
                }
            }

            public bool HasBin
            {
                get
                {
                    return this.result.hasBin;
                }
            }

            public bool HasBirthDate
            {
                get
                {
                    return this.result.hasBirthDate;
                }
            }

            public bool HasCity
            {
                get
                {
                    return this.result.hasCity;
                }
            }

            public bool HasCountryId
            {
                get
                {
                    return this.result.hasCountryId;
                }
            }

            public bool HasDescription
            {
                get
                {
                    return this.result.hasDescription;
                }
            }

            public bool HasFirstName
            {
                get
                {
                    return this.result.hasFirstName;
                }
            }

            public bool HasLastName
            {
                get
                {
                    return this.result.hasLastName;
                }
            }

            public bool HasLocaleId
            {
                get
                {
                    return this.result.hasLocaleId;
                }
            }

            public bool HasPaymentInfo
            {
                get
                {
                    return this.result.hasPaymentInfo;
                }
            }

            public bool HasPostalCode
            {
                get
                {
                    return this.result.hasPostalCode;
                }
            }

            public bool HasRegion
            {
                get
                {
                    return this.result.hasRegion;
                }
            }

            public bool HasState
            {
                get
                {
                    return this.result.hasState;
                }
            }

            public bool HasStreet
            {
                get
                {
                    return this.result.hasStreet;
                }
            }

            public bool HasWalletId
            {
                get
                {
                    return this.result.hasWalletId;
                }
            }

            public bool HasWalletType
            {
                get
                {
                    return this.result.hasWalletType;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public string LastName
            {
                get
                {
                    return this.result.LastName;
                }
                set
                {
                    this.SetLastName(value);
                }
            }

            public string LocaleId
            {
                get
                {
                    return this.result.LocaleId;
                }
                set
                {
                    this.SetLocaleId(value);
                }
            }

            protected override Wallet MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public ByteString PaymentInfo
            {
                get
                {
                    return this.result.PaymentInfo;
                }
                set
                {
                    this.SetPaymentInfo(value);
                }
            }

            public string PostalCode
            {
                get
                {
                    return this.result.PostalCode;
                }
                set
                {
                    this.SetPostalCode(value);
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

            public string State
            {
                get
                {
                    return this.result.State;
                }
                set
                {
                    this.SetState(value);
                }
            }

            public string Street
            {
                get
                {
                    return this.result.Street;
                }
                set
                {
                    this.SetStreet(value);
                }
            }

            protected override Wallet.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            [CLSCompliant(false)]
            public ulong WalletId
            {
                get
                {
                    return this.result.WalletId;
                }
                set
                {
                    this.SetWalletId(value);
                }
            }

            [CLSCompliant(false)]
            public uint WalletType
            {
                get
                {
                    return this.result.WalletType;
                }
                set
                {
                    this.SetWalletType(value);
                }
            }
        }
    }
}

