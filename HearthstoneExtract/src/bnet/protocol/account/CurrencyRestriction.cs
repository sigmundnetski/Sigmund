namespace bnet.protocol.account
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class CurrencyRestriction : GeneratedMessageLite<CurrencyRestriction, Builder>
    {
        private static readonly string[] _currencyRestrictionFieldNames = new string[] { "authenticator_cap", "currency", "soft_cap" };
        private static readonly uint[] _currencyRestrictionFieldTags = new uint[] { 0x12, 10, 0x1a };
        private string authenticatorCap_ = string.Empty;
        public const int AuthenticatorCapFieldNumber = 2;
        private string currency_ = string.Empty;
        public const int CurrencyFieldNumber = 1;
        private static readonly CurrencyRestriction defaultInstance = new CurrencyRestriction().MakeReadOnly();
        private bool hasAuthenticatorCap;
        private bool hasCurrency;
        private bool hasSoftCap;
        private int memoizedSerializedSize = -1;
        private string softCap_ = string.Empty;
        public const int SoftCapFieldNumber = 3;

        static CurrencyRestriction()
        {
            object.ReferenceEquals(AccountTypes.Descriptor, null);
        }

        private CurrencyRestriction()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(CurrencyRestriction prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            CurrencyRestriction restriction = obj as CurrencyRestriction;
            if (restriction == null)
            {
                return false;
            }
            if ((this.hasCurrency != restriction.hasCurrency) || (this.hasCurrency && !this.currency_.Equals(restriction.currency_)))
            {
                return false;
            }
            if ((this.hasAuthenticatorCap != restriction.hasAuthenticatorCap) || (this.hasAuthenticatorCap && !this.authenticatorCap_.Equals(restriction.authenticatorCap_)))
            {
                return false;
            }
            return ((this.hasSoftCap == restriction.hasSoftCap) && (!this.hasSoftCap || this.softCap_.Equals(restriction.softCap_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasCurrency)
            {
                hashCode ^= this.currency_.GetHashCode();
            }
            if (this.hasAuthenticatorCap)
            {
                hashCode ^= this.authenticatorCap_.GetHashCode();
            }
            if (this.hasSoftCap)
            {
                hashCode ^= this.softCap_.GetHashCode();
            }
            return hashCode;
        }

        private CurrencyRestriction MakeReadOnly()
        {
            return this;
        }

        public static CurrencyRestriction ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static CurrencyRestriction ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static CurrencyRestriction ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static CurrencyRestriction ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static CurrencyRestriction ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static CurrencyRestriction ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static CurrencyRestriction ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static CurrencyRestriction ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static CurrencyRestriction ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static CurrencyRestriction ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<CurrencyRestriction, Builder>.PrintField("currency", this.hasCurrency, this.currency_, writer);
            GeneratedMessageLite<CurrencyRestriction, Builder>.PrintField("authenticator_cap", this.hasAuthenticatorCap, this.authenticatorCap_, writer);
            GeneratedMessageLite<CurrencyRestriction, Builder>.PrintField("soft_cap", this.hasSoftCap, this.softCap_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _currencyRestrictionFieldNames;
            if (this.hasCurrency)
            {
                output.WriteString(1, strArray[1], this.Currency);
            }
            if (this.hasAuthenticatorCap)
            {
                output.WriteString(2, strArray[0], this.AuthenticatorCap);
            }
            if (this.hasSoftCap)
            {
                output.WriteString(3, strArray[2], this.SoftCap);
            }
        }

        public string AuthenticatorCap
        {
            get
            {
                return this.authenticatorCap_;
            }
        }

        public string Currency
        {
            get
            {
                return this.currency_;
            }
        }

        public static CurrencyRestriction DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override CurrencyRestriction DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasAuthenticatorCap
        {
            get
            {
                return this.hasAuthenticatorCap;
            }
        }

        public bool HasCurrency
        {
            get
            {
                return this.hasCurrency;
            }
        }

        public bool HasSoftCap
        {
            get
            {
                return this.hasSoftCap;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasCurrency)
                {
                    return false;
                }
                if (!this.hasAuthenticatorCap)
                {
                    return false;
                }
                if (!this.hasSoftCap)
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
                    if (this.hasCurrency)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(1, this.Currency);
                    }
                    if (this.hasAuthenticatorCap)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(2, this.AuthenticatorCap);
                    }
                    if (this.hasSoftCap)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(3, this.SoftCap);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        public string SoftCap
        {
            get
            {
                return this.softCap_;
            }
        }

        protected override CurrencyRestriction ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<CurrencyRestriction, CurrencyRestriction.Builder>
        {
            private CurrencyRestriction result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = CurrencyRestriction.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(CurrencyRestriction cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override CurrencyRestriction BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override CurrencyRestriction.Builder Clear()
            {
                this.result = CurrencyRestriction.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public CurrencyRestriction.Builder ClearAuthenticatorCap()
            {
                this.PrepareBuilder();
                this.result.hasAuthenticatorCap = false;
                this.result.authenticatorCap_ = string.Empty;
                return this;
            }

            public CurrencyRestriction.Builder ClearCurrency()
            {
                this.PrepareBuilder();
                this.result.hasCurrency = false;
                this.result.currency_ = string.Empty;
                return this;
            }

            public CurrencyRestriction.Builder ClearSoftCap()
            {
                this.PrepareBuilder();
                this.result.hasSoftCap = false;
                this.result.softCap_ = string.Empty;
                return this;
            }

            public override CurrencyRestriction.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new CurrencyRestriction.Builder(this.result);
                }
                return new CurrencyRestriction.Builder().MergeFrom(this.result);
            }

            public override CurrencyRestriction.Builder MergeFrom(CurrencyRestriction other)
            {
                if (other != CurrencyRestriction.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasCurrency)
                    {
                        this.Currency = other.Currency;
                    }
                    if (other.HasAuthenticatorCap)
                    {
                        this.AuthenticatorCap = other.AuthenticatorCap;
                    }
                    if (other.HasSoftCap)
                    {
                        this.SoftCap = other.SoftCap;
                    }
                }
                return this;
            }

            public override CurrencyRestriction.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override CurrencyRestriction.Builder MergeFrom(IMessageLite other)
            {
                if (other is CurrencyRestriction)
                {
                    return this.MergeFrom((CurrencyRestriction) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override CurrencyRestriction.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(CurrencyRestriction._currencyRestrictionFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = CurrencyRestriction._currencyRestrictionFieldTags[index];
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
                            this.result.hasCurrency = input.ReadString(ref this.result.currency_);
                            continue;
                        }
                        case 0x12:
                        {
                            this.result.hasAuthenticatorCap = input.ReadString(ref this.result.authenticatorCap_);
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
                    this.result.hasSoftCap = input.ReadString(ref this.result.softCap_);
                }
                return this;
            }

            private CurrencyRestriction PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    CurrencyRestriction result = this.result;
                    this.result = new CurrencyRestriction();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public CurrencyRestriction.Builder SetAuthenticatorCap(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasAuthenticatorCap = true;
                this.result.authenticatorCap_ = value;
                return this;
            }

            public CurrencyRestriction.Builder SetCurrency(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasCurrency = true;
                this.result.currency_ = value;
                return this;
            }

            public CurrencyRestriction.Builder SetSoftCap(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasSoftCap = true;
                this.result.softCap_ = value;
                return this;
            }

            public string AuthenticatorCap
            {
                get
                {
                    return this.result.AuthenticatorCap;
                }
                set
                {
                    this.SetAuthenticatorCap(value);
                }
            }

            public string Currency
            {
                get
                {
                    return this.result.Currency;
                }
                set
                {
                    this.SetCurrency(value);
                }
            }

            public override CurrencyRestriction DefaultInstanceForType
            {
                get
                {
                    return CurrencyRestriction.DefaultInstance;
                }
            }

            public bool HasAuthenticatorCap
            {
                get
                {
                    return this.result.hasAuthenticatorCap;
                }
            }

            public bool HasCurrency
            {
                get
                {
                    return this.result.hasCurrency;
                }
            }

            public bool HasSoftCap
            {
                get
                {
                    return this.result.hasSoftCap;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override CurrencyRestriction MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public string SoftCap
            {
                get
                {
                    return this.result.SoftCap;
                }
                set
                {
                    this.SetSoftCap(value);
                }
            }

            protected override CurrencyRestriction.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

