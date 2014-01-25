namespace bnet.protocol
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class AccountInfo : GeneratedMessageLite<AccountInfo, Builder>
    {
        private static readonly string[] _accountInfoFieldNames = new string[] { "account_paid", "battle_tag", "country_id", "manual_review" };
        private static readonly uint[] _accountInfoFieldTags = new uint[] { 8, 0x1a, 0x15, 0x20 };
        private bool accountPaid_;
        public const int AccountPaidFieldNumber = 1;
        private string battleTag_ = string.Empty;
        public const int BattleTagFieldNumber = 3;
        private uint countryId_;
        public const int CountryIdFieldNumber = 2;
        private static readonly AccountInfo defaultInstance = new AccountInfo().MakeReadOnly();
        private bool hasAccountPaid;
        private bool hasBattleTag;
        private bool hasCountryId;
        private bool hasManualReview;
        private bool manualReview_;
        public const int ManualReviewFieldNumber = 4;
        private int memoizedSerializedSize = -1;

        static AccountInfo()
        {
            object.ReferenceEquals(Entity.Descriptor, null);
        }

        private AccountInfo()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AccountInfo prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AccountInfo info = obj as AccountInfo;
            if (info == null)
            {
                return false;
            }
            if ((this.hasAccountPaid != info.hasAccountPaid) || (this.hasAccountPaid && !this.accountPaid_.Equals(info.accountPaid_)))
            {
                return false;
            }
            if ((this.hasCountryId != info.hasCountryId) || (this.hasCountryId && !this.countryId_.Equals(info.countryId_)))
            {
                return false;
            }
            if ((this.hasBattleTag != info.hasBattleTag) || (this.hasBattleTag && !this.battleTag_.Equals(info.battleTag_)))
            {
                return false;
            }
            return ((this.hasManualReview == info.hasManualReview) && (!this.hasManualReview || this.manualReview_.Equals(info.manualReview_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasAccountPaid)
            {
                hashCode ^= this.accountPaid_.GetHashCode();
            }
            if (this.hasCountryId)
            {
                hashCode ^= this.countryId_.GetHashCode();
            }
            if (this.hasBattleTag)
            {
                hashCode ^= this.battleTag_.GetHashCode();
            }
            if (this.hasManualReview)
            {
                hashCode ^= this.manualReview_.GetHashCode();
            }
            return hashCode;
        }

        private AccountInfo MakeReadOnly()
        {
            return this;
        }

        public static AccountInfo ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AccountInfo ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AccountInfo ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AccountInfo ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AccountInfo ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AccountInfo ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AccountInfo ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AccountInfo ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AccountInfo ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AccountInfo ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AccountInfo, Builder>.PrintField("account_paid", this.hasAccountPaid, this.accountPaid_, writer);
            GeneratedMessageLite<AccountInfo, Builder>.PrintField("country_id", this.hasCountryId, this.countryId_, writer);
            GeneratedMessageLite<AccountInfo, Builder>.PrintField("battle_tag", this.hasBattleTag, this.battleTag_, writer);
            GeneratedMessageLite<AccountInfo, Builder>.PrintField("manual_review", this.hasManualReview, this.manualReview_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _accountInfoFieldNames;
            if (this.hasAccountPaid)
            {
                output.WriteBool(1, strArray[0], this.AccountPaid);
            }
            if (this.hasCountryId)
            {
                output.WriteFixed32(2, strArray[2], this.CountryId);
            }
            if (this.hasBattleTag)
            {
                output.WriteString(3, strArray[1], this.BattleTag);
            }
            if (this.hasManualReview)
            {
                output.WriteBool(4, strArray[3], this.ManualReview);
            }
        }

        public bool AccountPaid
        {
            get
            {
                return this.accountPaid_;
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
        public uint CountryId
        {
            get
            {
                return this.countryId_;
            }
        }

        public static AccountInfo DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AccountInfo DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasAccountPaid
        {
            get
            {
                return this.hasAccountPaid;
            }
        }

        public bool HasBattleTag
        {
            get
            {
                return this.hasBattleTag;
            }
        }

        public bool HasCountryId
        {
            get
            {
                return this.hasCountryId;
            }
        }

        public bool HasManualReview
        {
            get
            {
                return this.hasManualReview;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                return true;
            }
        }

        public bool ManualReview
        {
            get
            {
                return this.manualReview_;
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
                    if (this.hasAccountPaid)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(1, this.AccountPaid);
                    }
                    if (this.hasCountryId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed32Size(2, this.CountryId);
                    }
                    if (this.hasBattleTag)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(3, this.BattleTag);
                    }
                    if (this.hasManualReview)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(4, this.ManualReview);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override AccountInfo ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<AccountInfo, AccountInfo.Builder>
        {
            private AccountInfo result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AccountInfo.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AccountInfo cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override AccountInfo BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AccountInfo.Builder Clear()
            {
                this.result = AccountInfo.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AccountInfo.Builder ClearAccountPaid()
            {
                this.PrepareBuilder();
                this.result.hasAccountPaid = false;
                this.result.accountPaid_ = false;
                return this;
            }

            public AccountInfo.Builder ClearBattleTag()
            {
                this.PrepareBuilder();
                this.result.hasBattleTag = false;
                this.result.battleTag_ = string.Empty;
                return this;
            }

            public AccountInfo.Builder ClearCountryId()
            {
                this.PrepareBuilder();
                this.result.hasCountryId = false;
                this.result.countryId_ = 0;
                return this;
            }

            public AccountInfo.Builder ClearManualReview()
            {
                this.PrepareBuilder();
                this.result.hasManualReview = false;
                this.result.manualReview_ = false;
                return this;
            }

            public override AccountInfo.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AccountInfo.Builder(this.result);
                }
                return new AccountInfo.Builder().MergeFrom(this.result);
            }

            public override AccountInfo.Builder MergeFrom(AccountInfo other)
            {
                if (other != AccountInfo.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAccountPaid)
                    {
                        this.AccountPaid = other.AccountPaid;
                    }
                    if (other.HasCountryId)
                    {
                        this.CountryId = other.CountryId;
                    }
                    if (other.HasBattleTag)
                    {
                        this.BattleTag = other.BattleTag;
                    }
                    if (other.HasManualReview)
                    {
                        this.ManualReview = other.ManualReview;
                    }
                }
                return this;
            }

            public override AccountInfo.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AccountInfo.Builder MergeFrom(IMessageLite other)
            {
                if (other is AccountInfo)
                {
                    return this.MergeFrom((AccountInfo) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AccountInfo.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AccountInfo._accountInfoFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AccountInfo._accountInfoFieldTags[index];
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
                            this.result.hasAccountPaid = input.ReadBool(ref this.result.accountPaid_);
                            continue;
                        }
                        case 0x15:
                        {
                            this.result.hasCountryId = input.ReadFixed32(ref this.result.countryId_);
                            continue;
                        }
                        case 0x1a:
                        {
                            this.result.hasBattleTag = input.ReadString(ref this.result.battleTag_);
                            continue;
                        }
                        case 0x20:
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
                    this.result.hasManualReview = input.ReadBool(ref this.result.manualReview_);
                }
                return this;
            }

            private AccountInfo PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AccountInfo result = this.result;
                    this.result = new AccountInfo();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public AccountInfo.Builder SetAccountPaid(bool value)
            {
                this.PrepareBuilder();
                this.result.hasAccountPaid = true;
                this.result.accountPaid_ = value;
                return this;
            }

            public AccountInfo.Builder SetBattleTag(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasBattleTag = true;
                this.result.battleTag_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public AccountInfo.Builder SetCountryId(uint value)
            {
                this.PrepareBuilder();
                this.result.hasCountryId = true;
                this.result.countryId_ = value;
                return this;
            }

            public AccountInfo.Builder SetManualReview(bool value)
            {
                this.PrepareBuilder();
                this.result.hasManualReview = true;
                this.result.manualReview_ = value;
                return this;
            }

            public bool AccountPaid
            {
                get
                {
                    return this.result.AccountPaid;
                }
                set
                {
                    this.SetAccountPaid(value);
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

            public override AccountInfo DefaultInstanceForType
            {
                get
                {
                    return AccountInfo.DefaultInstance;
                }
            }

            public bool HasAccountPaid
            {
                get
                {
                    return this.result.hasAccountPaid;
                }
            }

            public bool HasBattleTag
            {
                get
                {
                    return this.result.hasBattleTag;
                }
            }

            public bool HasCountryId
            {
                get
                {
                    return this.result.hasCountryId;
                }
            }

            public bool HasManualReview
            {
                get
                {
                    return this.result.hasManualReview;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public bool ManualReview
            {
                get
                {
                    return this.result.ManualReview;
                }
                set
                {
                    this.SetManualReview(value);
                }
            }

            protected override AccountInfo MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override AccountInfo.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

