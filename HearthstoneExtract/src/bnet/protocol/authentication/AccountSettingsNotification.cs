namespace bnet.protocol.authentication
{
    using bnet.protocol.account;
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class AccountSettingsNotification : GeneratedMessageLite<AccountSettingsNotification, Builder>
    {
        private static readonly string[] _accountSettingsNotificationFieldNames = new string[] { "can_receive_voice", "can_send_voice", "is_playing_from_igr", "is_using_rid", "licenses" };
        private static readonly uint[] _accountSettingsNotificationFieldTags = new uint[] { 0x20, 40, 0x18, 0x10, 10 };
        private bool canReceiveVoice_;
        public const int CanReceiveVoiceFieldNumber = 4;
        private bool canSendVoice_;
        public const int CanSendVoiceFieldNumber = 5;
        private static readonly AccountSettingsNotification defaultInstance = new AccountSettingsNotification().MakeReadOnly();
        private bool hasCanReceiveVoice;
        private bool hasCanSendVoice;
        private bool hasIsPlayingFromIgr;
        private bool hasIsUsingRid;
        private bool isPlayingFromIgr_;
        public const int IsPlayingFromIgrFieldNumber = 3;
        private bool isUsingRid_;
        public const int IsUsingRidFieldNumber = 2;
        private PopsicleList<AccountLicense> licenses_ = new PopsicleList<AccountLicense>();
        public const int LicensesFieldNumber = 1;
        private int memoizedSerializedSize = -1;

        static AccountSettingsNotification()
        {
            object.ReferenceEquals(AuthenticationService.Descriptor, null);
        }

        private AccountSettingsNotification()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AccountSettingsNotification prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AccountSettingsNotification notification = obj as AccountSettingsNotification;
            if (notification == null)
            {
                return false;
            }
            if (this.licenses_.Count != notification.licenses_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.licenses_.Count; i++)
            {
                if (!this.licenses_[i].Equals(notification.licenses_[i]))
                {
                    return false;
                }
            }
            if ((this.hasIsUsingRid != notification.hasIsUsingRid) || (this.hasIsUsingRid && !this.isUsingRid_.Equals(notification.isUsingRid_)))
            {
                return false;
            }
            if ((this.hasIsPlayingFromIgr != notification.hasIsPlayingFromIgr) || (this.hasIsPlayingFromIgr && !this.isPlayingFromIgr_.Equals(notification.isPlayingFromIgr_)))
            {
                return false;
            }
            if ((this.hasCanReceiveVoice != notification.hasCanReceiveVoice) || (this.hasCanReceiveVoice && !this.canReceiveVoice_.Equals(notification.canReceiveVoice_)))
            {
                return false;
            }
            return ((this.hasCanSendVoice == notification.hasCanSendVoice) && (!this.hasCanSendVoice || this.canSendVoice_.Equals(notification.canSendVoice_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
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
            if (this.hasIsUsingRid)
            {
                hashCode ^= this.isUsingRid_.GetHashCode();
            }
            if (this.hasIsPlayingFromIgr)
            {
                hashCode ^= this.isPlayingFromIgr_.GetHashCode();
            }
            if (this.hasCanReceiveVoice)
            {
                hashCode ^= this.canReceiveVoice_.GetHashCode();
            }
            if (this.hasCanSendVoice)
            {
                hashCode ^= this.canSendVoice_.GetHashCode();
            }
            return hashCode;
        }

        public AccountLicense GetLicenses(int index)
        {
            return this.licenses_[index];
        }

        private AccountSettingsNotification MakeReadOnly()
        {
            this.licenses_.MakeReadOnly();
            return this;
        }

        public static AccountSettingsNotification ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AccountSettingsNotification ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AccountSettingsNotification ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AccountSettingsNotification ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AccountSettingsNotification ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AccountSettingsNotification ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AccountSettingsNotification ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AccountSettingsNotification ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AccountSettingsNotification ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AccountSettingsNotification ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AccountSettingsNotification, Builder>.PrintField<AccountLicense>("licenses", this.licenses_, writer);
            GeneratedMessageLite<AccountSettingsNotification, Builder>.PrintField("is_using_rid", this.hasIsUsingRid, this.isUsingRid_, writer);
            GeneratedMessageLite<AccountSettingsNotification, Builder>.PrintField("is_playing_from_igr", this.hasIsPlayingFromIgr, this.isPlayingFromIgr_, writer);
            GeneratedMessageLite<AccountSettingsNotification, Builder>.PrintField("can_receive_voice", this.hasCanReceiveVoice, this.canReceiveVoice_, writer);
            GeneratedMessageLite<AccountSettingsNotification, Builder>.PrintField("can_send_voice", this.hasCanSendVoice, this.canSendVoice_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _accountSettingsNotificationFieldNames;
            if (this.licenses_.Count > 0)
            {
                output.WriteMessageArray<AccountLicense>(1, strArray[4], this.licenses_);
            }
            if (this.hasIsUsingRid)
            {
                output.WriteBool(2, strArray[3], this.IsUsingRid);
            }
            if (this.hasIsPlayingFromIgr)
            {
                output.WriteBool(3, strArray[2], this.IsPlayingFromIgr);
            }
            if (this.hasCanReceiveVoice)
            {
                output.WriteBool(4, strArray[0], this.CanReceiveVoice);
            }
            if (this.hasCanSendVoice)
            {
                output.WriteBool(5, strArray[1], this.CanSendVoice);
            }
        }

        public bool CanReceiveVoice
        {
            get
            {
                return this.canReceiveVoice_;
            }
        }

        public bool CanSendVoice
        {
            get
            {
                return this.canSendVoice_;
            }
        }

        public static AccountSettingsNotification DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AccountSettingsNotification DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasCanReceiveVoice
        {
            get
            {
                return this.hasCanReceiveVoice;
            }
        }

        public bool HasCanSendVoice
        {
            get
            {
                return this.hasCanSendVoice;
            }
        }

        public bool HasIsPlayingFromIgr
        {
            get
            {
                return this.hasIsPlayingFromIgr;
            }
        }

        public bool HasIsUsingRid
        {
            get
            {
                return this.hasIsUsingRid;
            }
        }

        public override bool IsInitialized
        {
            get
            {
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

        public bool IsPlayingFromIgr
        {
            get
            {
                return this.isPlayingFromIgr_;
            }
        }

        public bool IsUsingRid
        {
            get
            {
                return this.isUsingRid_;
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

        public override int SerializedSize
        {
            get
            {
                int memoizedSerializedSize = this.memoizedSerializedSize;
                if (memoizedSerializedSize == -1)
                {
                    memoizedSerializedSize = 0;
                    IEnumerator<AccountLicense> enumerator = this.LicensesList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            AccountLicense current = enumerator.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, current);
                        }
                    }
                    finally
                    {
                        if (enumerator == null)
                        {
                        }
                        enumerator.Dispose();
                    }
                    if (this.hasIsUsingRid)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(2, this.IsUsingRid);
                    }
                    if (this.hasIsPlayingFromIgr)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(3, this.IsPlayingFromIgr);
                    }
                    if (this.hasCanReceiveVoice)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(4, this.CanReceiveVoice);
                    }
                    if (this.hasCanSendVoice)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(5, this.CanSendVoice);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override AccountSettingsNotification ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<AccountSettingsNotification, AccountSettingsNotification.Builder>
        {
            private AccountSettingsNotification result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AccountSettingsNotification.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AccountSettingsNotification cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public AccountSettingsNotification.Builder AddLicenses(AccountLicense value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.licenses_.Add(value);
                return this;
            }

            public AccountSettingsNotification.Builder AddLicenses(AccountLicense.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.licenses_.Add(builderForValue.Build());
                return this;
            }

            public AccountSettingsNotification.Builder AddRangeLicenses(IEnumerable<AccountLicense> values)
            {
                this.PrepareBuilder();
                this.result.licenses_.Add(values);
                return this;
            }

            public override AccountSettingsNotification BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AccountSettingsNotification.Builder Clear()
            {
                this.result = AccountSettingsNotification.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AccountSettingsNotification.Builder ClearCanReceiveVoice()
            {
                this.PrepareBuilder();
                this.result.hasCanReceiveVoice = false;
                this.result.canReceiveVoice_ = false;
                return this;
            }

            public AccountSettingsNotification.Builder ClearCanSendVoice()
            {
                this.PrepareBuilder();
                this.result.hasCanSendVoice = false;
                this.result.canSendVoice_ = false;
                return this;
            }

            public AccountSettingsNotification.Builder ClearIsPlayingFromIgr()
            {
                this.PrepareBuilder();
                this.result.hasIsPlayingFromIgr = false;
                this.result.isPlayingFromIgr_ = false;
                return this;
            }

            public AccountSettingsNotification.Builder ClearIsUsingRid()
            {
                this.PrepareBuilder();
                this.result.hasIsUsingRid = false;
                this.result.isUsingRid_ = false;
                return this;
            }

            public AccountSettingsNotification.Builder ClearLicenses()
            {
                this.PrepareBuilder();
                this.result.licenses_.Clear();
                return this;
            }

            public override AccountSettingsNotification.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AccountSettingsNotification.Builder(this.result);
                }
                return new AccountSettingsNotification.Builder().MergeFrom(this.result);
            }

            public AccountLicense GetLicenses(int index)
            {
                return this.result.GetLicenses(index);
            }

            public override AccountSettingsNotification.Builder MergeFrom(AccountSettingsNotification other)
            {
                if (other != AccountSettingsNotification.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.licenses_.Count != 0)
                    {
                        this.result.licenses_.Add(other.licenses_);
                    }
                    if (other.HasIsUsingRid)
                    {
                        this.IsUsingRid = other.IsUsingRid;
                    }
                    if (other.HasIsPlayingFromIgr)
                    {
                        this.IsPlayingFromIgr = other.IsPlayingFromIgr;
                    }
                    if (other.HasCanReceiveVoice)
                    {
                        this.CanReceiveVoice = other.CanReceiveVoice;
                    }
                    if (other.HasCanSendVoice)
                    {
                        this.CanSendVoice = other.CanSendVoice;
                    }
                }
                return this;
            }

            public override AccountSettingsNotification.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AccountSettingsNotification.Builder MergeFrom(IMessageLite other)
            {
                if (other is AccountSettingsNotification)
                {
                    return this.MergeFrom((AccountSettingsNotification) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AccountSettingsNotification.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AccountSettingsNotification._accountSettingsNotificationFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AccountSettingsNotification._accountSettingsNotificationFieldTags[index];
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
                            input.ReadMessageArray<AccountLicense>(num, str, this.result.licenses_, AccountLicense.DefaultInstance, extensionRegistry);
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasIsUsingRid = input.ReadBool(ref this.result.isUsingRid_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasIsPlayingFromIgr = input.ReadBool(ref this.result.isPlayingFromIgr_);
                            continue;
                        }
                        case 0x20:
                        {
                            this.result.hasCanReceiveVoice = input.ReadBool(ref this.result.canReceiveVoice_);
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
                    this.result.hasCanSendVoice = input.ReadBool(ref this.result.canSendVoice_);
                }
                return this;
            }

            private AccountSettingsNotification PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AccountSettingsNotification result = this.result;
                    this.result = new AccountSettingsNotification();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public AccountSettingsNotification.Builder SetCanReceiveVoice(bool value)
            {
                this.PrepareBuilder();
                this.result.hasCanReceiveVoice = true;
                this.result.canReceiveVoice_ = value;
                return this;
            }

            public AccountSettingsNotification.Builder SetCanSendVoice(bool value)
            {
                this.PrepareBuilder();
                this.result.hasCanSendVoice = true;
                this.result.canSendVoice_ = value;
                return this;
            }

            public AccountSettingsNotification.Builder SetIsPlayingFromIgr(bool value)
            {
                this.PrepareBuilder();
                this.result.hasIsPlayingFromIgr = true;
                this.result.isPlayingFromIgr_ = value;
                return this;
            }

            public AccountSettingsNotification.Builder SetIsUsingRid(bool value)
            {
                this.PrepareBuilder();
                this.result.hasIsUsingRid = true;
                this.result.isUsingRid_ = value;
                return this;
            }

            public AccountSettingsNotification.Builder SetLicenses(int index, AccountLicense value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.licenses_[index] = value;
                return this;
            }

            public AccountSettingsNotification.Builder SetLicenses(int index, AccountLicense.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.licenses_[index] = builderForValue.Build();
                return this;
            }

            public bool CanReceiveVoice
            {
                get
                {
                    return this.result.CanReceiveVoice;
                }
                set
                {
                    this.SetCanReceiveVoice(value);
                }
            }

            public bool CanSendVoice
            {
                get
                {
                    return this.result.CanSendVoice;
                }
                set
                {
                    this.SetCanSendVoice(value);
                }
            }

            public override AccountSettingsNotification DefaultInstanceForType
            {
                get
                {
                    return AccountSettingsNotification.DefaultInstance;
                }
            }

            public bool HasCanReceiveVoice
            {
                get
                {
                    return this.result.hasCanReceiveVoice;
                }
            }

            public bool HasCanSendVoice
            {
                get
                {
                    return this.result.hasCanSendVoice;
                }
            }

            public bool HasIsPlayingFromIgr
            {
                get
                {
                    return this.result.hasIsPlayingFromIgr;
                }
            }

            public bool HasIsUsingRid
            {
                get
                {
                    return this.result.hasIsUsingRid;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public bool IsPlayingFromIgr
            {
                get
                {
                    return this.result.IsPlayingFromIgr;
                }
                set
                {
                    this.SetIsPlayingFromIgr(value);
                }
            }

            public bool IsUsingRid
            {
                get
                {
                    return this.result.IsUsingRid;
                }
                set
                {
                    this.SetIsUsingRid(value);
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

            protected override AccountSettingsNotification MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override AccountSettingsNotification.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

