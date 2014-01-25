namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class BattlePayConfigResponse : GeneratedMessageLite<BattlePayConfigResponse, Builder>
    {
        private static readonly string[] _battlePayConfigResponseFieldNames = new string[] { "bundles", "country", "currency", "gold_prices", "secs_before_auto_cancel", "unavailable" };
        private static readonly uint[] _battlePayConfigResponseFieldTags = new uint[] { 10, 0x1a, 0x10, 50, 40, 0x20 };
        private PopsicleList<Bundle> bundles_ = new PopsicleList<Bundle>();
        public const int BundlesFieldNumber = 1;
        private string country_ = string.Empty;
        public const int CountryFieldNumber = 3;
        private int currency_;
        public const int CurrencyFieldNumber = 2;
        private static readonly BattlePayConfigResponse defaultInstance = new BattlePayConfigResponse().MakeReadOnly();
        private PopsicleList<GoldPrice> goldPrices_ = new PopsicleList<GoldPrice>();
        public const int GoldPricesFieldNumber = 6;
        private bool hasCountry;
        private bool hasCurrency;
        private bool hasSecsBeforeAutoCancel;
        private bool hasUnavailable;
        private int memoizedSerializedSize = -1;
        private int secsBeforeAutoCancel_;
        public const int SecsBeforeAutoCancelFieldNumber = 5;
        private bool unavailable_;
        public const int UnavailableFieldNumber = 4;

        static BattlePayConfigResponse()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private BattlePayConfigResponse()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(BattlePayConfigResponse prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            BattlePayConfigResponse response = obj as BattlePayConfigResponse;
            if (response == null)
            {
                return false;
            }
            if (this.bundles_.Count != response.bundles_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.bundles_.Count; i++)
            {
                if (!this.bundles_[i].Equals(response.bundles_[i]))
                {
                    return false;
                }
            }
            if ((this.hasCurrency != response.hasCurrency) || (this.hasCurrency && !this.currency_.Equals(response.currency_)))
            {
                return false;
            }
            if ((this.hasCountry != response.hasCountry) || (this.hasCountry && !this.country_.Equals(response.country_)))
            {
                return false;
            }
            if ((this.hasUnavailable != response.hasUnavailable) || (this.hasUnavailable && !this.unavailable_.Equals(response.unavailable_)))
            {
                return false;
            }
            if ((this.hasSecsBeforeAutoCancel != response.hasSecsBeforeAutoCancel) || (this.hasSecsBeforeAutoCancel && !this.secsBeforeAutoCancel_.Equals(response.secsBeforeAutoCancel_)))
            {
                return false;
            }
            if (this.goldPrices_.Count != response.goldPrices_.Count)
            {
                return false;
            }
            for (int j = 0; j < this.goldPrices_.Count; j++)
            {
                if (!this.goldPrices_[j].Equals(response.goldPrices_[j]))
                {
                    return false;
                }
            }
            return true;
        }

        public Bundle GetBundles(int index)
        {
            return this.bundles_[index];
        }

        public GoldPrice GetGoldPrices(int index)
        {
            return this.goldPrices_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<Bundle> enumerator = this.bundles_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    Bundle current = enumerator.Current;
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
            if (this.hasCurrency)
            {
                hashCode ^= this.currency_.GetHashCode();
            }
            if (this.hasCountry)
            {
                hashCode ^= this.country_.GetHashCode();
            }
            if (this.hasUnavailable)
            {
                hashCode ^= this.unavailable_.GetHashCode();
            }
            if (this.hasSecsBeforeAutoCancel)
            {
                hashCode ^= this.secsBeforeAutoCancel_.GetHashCode();
            }
            IEnumerator<GoldPrice> enumerator2 = this.goldPrices_.GetEnumerator();
            try
            {
                while (enumerator2.MoveNext())
                {
                    GoldPrice price = enumerator2.Current;
                    hashCode ^= price.GetHashCode();
                }
            }
            finally
            {
                if (enumerator2 == null)
                {
                }
                enumerator2.Dispose();
            }
            return hashCode;
        }

        private BattlePayConfigResponse MakeReadOnly()
        {
            this.bundles_.MakeReadOnly();
            this.goldPrices_.MakeReadOnly();
            return this;
        }

        public static BattlePayConfigResponse ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static BattlePayConfigResponse ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static BattlePayConfigResponse ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static BattlePayConfigResponse ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static BattlePayConfigResponse ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static BattlePayConfigResponse ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static BattlePayConfigResponse ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static BattlePayConfigResponse ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static BattlePayConfigResponse ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static BattlePayConfigResponse ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<BattlePayConfigResponse, Builder>.PrintField<Bundle>("bundles", this.bundles_, writer);
            GeneratedMessageLite<BattlePayConfigResponse, Builder>.PrintField("currency", this.hasCurrency, this.currency_, writer);
            GeneratedMessageLite<BattlePayConfigResponse, Builder>.PrintField("country", this.hasCountry, this.country_, writer);
            GeneratedMessageLite<BattlePayConfigResponse, Builder>.PrintField("unavailable", this.hasUnavailable, this.unavailable_, writer);
            GeneratedMessageLite<BattlePayConfigResponse, Builder>.PrintField("secs_before_auto_cancel", this.hasSecsBeforeAutoCancel, this.secsBeforeAutoCancel_, writer);
            GeneratedMessageLite<BattlePayConfigResponse, Builder>.PrintField<GoldPrice>("gold_prices", this.goldPrices_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _battlePayConfigResponseFieldNames;
            if (this.bundles_.Count > 0)
            {
                output.WriteMessageArray<Bundle>(1, strArray[0], this.bundles_);
            }
            if (this.hasCurrency)
            {
                output.WriteInt32(2, strArray[2], this.Currency);
            }
            if (this.hasCountry)
            {
                output.WriteString(3, strArray[1], this.Country);
            }
            if (this.hasUnavailable)
            {
                output.WriteBool(4, strArray[5], this.Unavailable);
            }
            if (this.hasSecsBeforeAutoCancel)
            {
                output.WriteInt32(5, strArray[4], this.SecsBeforeAutoCancel);
            }
            if (this.goldPrices_.Count > 0)
            {
                output.WriteMessageArray<GoldPrice>(6, strArray[3], this.goldPrices_);
            }
        }

        public int BundlesCount
        {
            get
            {
                return this.bundles_.Count;
            }
        }

        public IList<Bundle> BundlesList
        {
            get
            {
                return this.bundles_;
            }
        }

        public string Country
        {
            get
            {
                return this.country_;
            }
        }

        public int Currency
        {
            get
            {
                return this.currency_;
            }
        }

        public static BattlePayConfigResponse DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override BattlePayConfigResponse DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public int GoldPricesCount
        {
            get
            {
                return this.goldPrices_.Count;
            }
        }

        public IList<GoldPrice> GoldPricesList
        {
            get
            {
                return this.goldPrices_;
            }
        }

        public bool HasCountry
        {
            get
            {
                return this.hasCountry;
            }
        }

        public bool HasCurrency
        {
            get
            {
                return this.hasCurrency;
            }
        }

        public bool HasSecsBeforeAutoCancel
        {
            get
            {
                return this.hasSecsBeforeAutoCancel;
            }
        }

        public bool HasUnavailable
        {
            get
            {
                return this.hasUnavailable;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                IEnumerator<Bundle> enumerator = this.BundlesList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        Bundle current = enumerator.Current;
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
                IEnumerator<GoldPrice> enumerator2 = this.GoldPricesList.GetEnumerator();
                try
                {
                    while (enumerator2.MoveNext())
                    {
                        GoldPrice price = enumerator2.Current;
                        if (!price.IsInitialized)
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
                return true;
            }
        }

        public int SecsBeforeAutoCancel
        {
            get
            {
                return this.secsBeforeAutoCancel_;
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
                    IEnumerator<Bundle> enumerator = this.BundlesList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            Bundle current = enumerator.Current;
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
                    if (this.hasCurrency)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.Currency);
                    }
                    if (this.hasCountry)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(3, this.Country);
                    }
                    if (this.hasUnavailable)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(4, this.Unavailable);
                    }
                    if (this.hasSecsBeforeAutoCancel)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(5, this.SecsBeforeAutoCancel);
                    }
                    IEnumerator<GoldPrice> enumerator2 = this.GoldPricesList.GetEnumerator();
                    try
                    {
                        while (enumerator2.MoveNext())
                        {
                            GoldPrice price = enumerator2.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(6, price);
                        }
                    }
                    finally
                    {
                        if (enumerator2 == null)
                        {
                        }
                        enumerator2.Dispose();
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override BattlePayConfigResponse ThisMessage
        {
            get
            {
                return this;
            }
        }

        public bool Unavailable
        {
            get
            {
                return this.unavailable_;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<BattlePayConfigResponse, BattlePayConfigResponse.Builder>
        {
            private BattlePayConfigResponse result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = BattlePayConfigResponse.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(BattlePayConfigResponse cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public BattlePayConfigResponse.Builder AddBundles(Bundle value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.bundles_.Add(value);
                return this;
            }

            public BattlePayConfigResponse.Builder AddBundles(Bundle.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.bundles_.Add(builderForValue.Build());
                return this;
            }

            public BattlePayConfigResponse.Builder AddGoldPrices(GoldPrice value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.goldPrices_.Add(value);
                return this;
            }

            public BattlePayConfigResponse.Builder AddGoldPrices(GoldPrice.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.goldPrices_.Add(builderForValue.Build());
                return this;
            }

            public BattlePayConfigResponse.Builder AddRangeBundles(IEnumerable<Bundle> values)
            {
                this.PrepareBuilder();
                this.result.bundles_.Add(values);
                return this;
            }

            public BattlePayConfigResponse.Builder AddRangeGoldPrices(IEnumerable<GoldPrice> values)
            {
                this.PrepareBuilder();
                this.result.goldPrices_.Add(values);
                return this;
            }

            public override BattlePayConfigResponse BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override BattlePayConfigResponse.Builder Clear()
            {
                this.result = BattlePayConfigResponse.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public BattlePayConfigResponse.Builder ClearBundles()
            {
                this.PrepareBuilder();
                this.result.bundles_.Clear();
                return this;
            }

            public BattlePayConfigResponse.Builder ClearCountry()
            {
                this.PrepareBuilder();
                this.result.hasCountry = false;
                this.result.country_ = string.Empty;
                return this;
            }

            public BattlePayConfigResponse.Builder ClearCurrency()
            {
                this.PrepareBuilder();
                this.result.hasCurrency = false;
                this.result.currency_ = 0;
                return this;
            }

            public BattlePayConfigResponse.Builder ClearGoldPrices()
            {
                this.PrepareBuilder();
                this.result.goldPrices_.Clear();
                return this;
            }

            public BattlePayConfigResponse.Builder ClearSecsBeforeAutoCancel()
            {
                this.PrepareBuilder();
                this.result.hasSecsBeforeAutoCancel = false;
                this.result.secsBeforeAutoCancel_ = 0;
                return this;
            }

            public BattlePayConfigResponse.Builder ClearUnavailable()
            {
                this.PrepareBuilder();
                this.result.hasUnavailable = false;
                this.result.unavailable_ = false;
                return this;
            }

            public override BattlePayConfigResponse.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new BattlePayConfigResponse.Builder(this.result);
                }
                return new BattlePayConfigResponse.Builder().MergeFrom(this.result);
            }

            public Bundle GetBundles(int index)
            {
                return this.result.GetBundles(index);
            }

            public GoldPrice GetGoldPrices(int index)
            {
                return this.result.GetGoldPrices(index);
            }

            public override BattlePayConfigResponse.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override BattlePayConfigResponse.Builder MergeFrom(IMessageLite other)
            {
                if (other is BattlePayConfigResponse)
                {
                    return this.MergeFrom((BattlePayConfigResponse) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override BattlePayConfigResponse.Builder MergeFrom(BattlePayConfigResponse other)
            {
                if (other != BattlePayConfigResponse.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.bundles_.Count != 0)
                    {
                        this.result.bundles_.Add(other.bundles_);
                    }
                    if (other.HasCurrency)
                    {
                        this.Currency = other.Currency;
                    }
                    if (other.HasCountry)
                    {
                        this.Country = other.Country;
                    }
                    if (other.HasUnavailable)
                    {
                        this.Unavailable = other.Unavailable;
                    }
                    if (other.HasSecsBeforeAutoCancel)
                    {
                        this.SecsBeforeAutoCancel = other.SecsBeforeAutoCancel;
                    }
                    if (other.goldPrices_.Count != 0)
                    {
                        this.result.goldPrices_.Add(other.goldPrices_);
                    }
                }
                return this;
            }

            public override BattlePayConfigResponse.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(BattlePayConfigResponse._battlePayConfigResponseFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = BattlePayConfigResponse._battlePayConfigResponseFieldTags[index];
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
                            input.ReadMessageArray<Bundle>(num, str, this.result.bundles_, Bundle.DefaultInstance, extensionRegistry);
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasCurrency = input.ReadInt32(ref this.result.currency_);
                            continue;
                        }
                        case 0x1a:
                        {
                            this.result.hasCountry = input.ReadString(ref this.result.country_);
                            continue;
                        }
                        case 0x20:
                        {
                            this.result.hasUnavailable = input.ReadBool(ref this.result.unavailable_);
                            continue;
                        }
                        case 40:
                        {
                            this.result.hasSecsBeforeAutoCancel = input.ReadInt32(ref this.result.secsBeforeAutoCancel_);
                            continue;
                        }
                        case 50:
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
                    input.ReadMessageArray<GoldPrice>(num, str, this.result.goldPrices_, GoldPrice.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private BattlePayConfigResponse PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    BattlePayConfigResponse result = this.result;
                    this.result = new BattlePayConfigResponse();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public BattlePayConfigResponse.Builder SetBundles(int index, Bundle value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.bundles_[index] = value;
                return this;
            }

            public BattlePayConfigResponse.Builder SetBundles(int index, Bundle.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.bundles_[index] = builderForValue.Build();
                return this;
            }

            public BattlePayConfigResponse.Builder SetCountry(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasCountry = true;
                this.result.country_ = value;
                return this;
            }

            public BattlePayConfigResponse.Builder SetCurrency(int value)
            {
                this.PrepareBuilder();
                this.result.hasCurrency = true;
                this.result.currency_ = value;
                return this;
            }

            public BattlePayConfigResponse.Builder SetGoldPrices(int index, GoldPrice value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.goldPrices_[index] = value;
                return this;
            }

            public BattlePayConfigResponse.Builder SetGoldPrices(int index, GoldPrice.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.goldPrices_[index] = builderForValue.Build();
                return this;
            }

            public BattlePayConfigResponse.Builder SetSecsBeforeAutoCancel(int value)
            {
                this.PrepareBuilder();
                this.result.hasSecsBeforeAutoCancel = true;
                this.result.secsBeforeAutoCancel_ = value;
                return this;
            }

            public BattlePayConfigResponse.Builder SetUnavailable(bool value)
            {
                this.PrepareBuilder();
                this.result.hasUnavailable = true;
                this.result.unavailable_ = value;
                return this;
            }

            public int BundlesCount
            {
                get
                {
                    return this.result.BundlesCount;
                }
            }

            public IPopsicleList<Bundle> BundlesList
            {
                get
                {
                    return this.PrepareBuilder().bundles_;
                }
            }

            public string Country
            {
                get
                {
                    return this.result.Country;
                }
                set
                {
                    this.SetCountry(value);
                }
            }

            public int Currency
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

            public override BattlePayConfigResponse DefaultInstanceForType
            {
                get
                {
                    return BattlePayConfigResponse.DefaultInstance;
                }
            }

            public int GoldPricesCount
            {
                get
                {
                    return this.result.GoldPricesCount;
                }
            }

            public IPopsicleList<GoldPrice> GoldPricesList
            {
                get
                {
                    return this.PrepareBuilder().goldPrices_;
                }
            }

            public bool HasCountry
            {
                get
                {
                    return this.result.hasCountry;
                }
            }

            public bool HasCurrency
            {
                get
                {
                    return this.result.hasCurrency;
                }
            }

            public bool HasSecsBeforeAutoCancel
            {
                get
                {
                    return this.result.hasSecsBeforeAutoCancel;
                }
            }

            public bool HasUnavailable
            {
                get
                {
                    return this.result.hasUnavailable;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override BattlePayConfigResponse MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int SecsBeforeAutoCancel
            {
                get
                {
                    return this.result.SecsBeforeAutoCancel;
                }
                set
                {
                    this.SetSecsBeforeAutoCancel(value);
                }
            }

            protected override BattlePayConfigResponse.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public bool Unavailable
            {
                get
                {
                    return this.result.Unavailable;
                }
                set
                {
                    this.SetUnavailable(value);
                }
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0xee
            }
        }
    }
}

