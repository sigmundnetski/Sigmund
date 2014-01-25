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

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class CardValues : GeneratedMessageLite<CardValues, Builder>
    {
        private static readonly string[] _cardValuesFieldNames = new string[] { "cards" };
        private static readonly uint[] _cardValuesFieldTags = new uint[] { 10 };
        private PopsicleList<CardValue> cards_ = new PopsicleList<CardValue>();
        public const int CardsFieldNumber = 1;
        private static readonly CardValues defaultInstance = new CardValues().MakeReadOnly();
        private int memoizedSerializedSize = -1;

        static CardValues()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private CardValues()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(CardValues prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            CardValues values = obj as CardValues;
            if (values == null)
            {
                return false;
            }
            if (this.cards_.Count != values.cards_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.cards_.Count; i++)
            {
                if (!this.cards_[i].Equals(values.cards_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public CardValue GetCards(int index)
        {
            return this.cards_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<CardValue> enumerator = this.cards_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    CardValue current = enumerator.Current;
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

        private CardValues MakeReadOnly()
        {
            this.cards_.MakeReadOnly();
            return this;
        }

        public static CardValues ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static CardValues ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static CardValues ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static CardValues ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static CardValues ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static CardValues ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static CardValues ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static CardValues ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static CardValues ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static CardValues ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<CardValues, Builder>.PrintField<CardValue>("cards", this.cards_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _cardValuesFieldNames;
            if (this.cards_.Count > 0)
            {
                output.WriteMessageArray<CardValue>(1, strArray[0], this.cards_);
            }
        }

        public int CardsCount
        {
            get
            {
                return this.cards_.Count;
            }
        }

        public IList<CardValue> CardsList
        {
            get
            {
                return this.cards_;
            }
        }

        public static CardValues DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override CardValues DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                IEnumerator<CardValue> enumerator = this.CardsList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        CardValue current = enumerator.Current;
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

        public override int SerializedSize
        {
            get
            {
                int memoizedSerializedSize = this.memoizedSerializedSize;
                if (memoizedSerializedSize == -1)
                {
                    memoizedSerializedSize = 0;
                    IEnumerator<CardValue> enumerator = this.CardsList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            CardValue current = enumerator.Current;
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
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override CardValues ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<CardValues, CardValues.Builder>
        {
            private CardValues result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = CardValues.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(CardValues cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public CardValues.Builder AddCards(CardValue value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.cards_.Add(value);
                return this;
            }

            public CardValues.Builder AddCards(CardValue.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.cards_.Add(builderForValue.Build());
                return this;
            }

            public CardValues.Builder AddRangeCards(IEnumerable<CardValue> values)
            {
                this.PrepareBuilder();
                this.result.cards_.Add(values);
                return this;
            }

            public override CardValues BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override CardValues.Builder Clear()
            {
                this.result = CardValues.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public CardValues.Builder ClearCards()
            {
                this.PrepareBuilder();
                this.result.cards_.Clear();
                return this;
            }

            public override CardValues.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new CardValues.Builder(this.result);
                }
                return new CardValues.Builder().MergeFrom(this.result);
            }

            public CardValue GetCards(int index)
            {
                return this.result.GetCards(index);
            }

            public override CardValues.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override CardValues.Builder MergeFrom(IMessageLite other)
            {
                if (other is CardValues)
                {
                    return this.MergeFrom((CardValues) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override CardValues.Builder MergeFrom(CardValues other)
            {
                if (other != CardValues.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.cards_.Count != 0)
                    {
                        this.result.cards_.Add(other.cards_);
                    }
                }
                return this;
            }

            public override CardValues.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(CardValues._cardValuesFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = CardValues._cardValuesFieldTags[index];
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
                    input.ReadMessageArray<CardValue>(num, str, this.result.cards_, CardValue.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private CardValues PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    CardValues result = this.result;
                    this.result = new CardValues();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public CardValues.Builder SetCards(int index, CardValue value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.cards_[index] = value;
                return this;
            }

            public CardValues.Builder SetCards(int index, CardValue.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.cards_[index] = builderForValue.Build();
                return this;
            }

            public int CardsCount
            {
                get
                {
                    return this.result.CardsCount;
                }
            }

            public IPopsicleList<CardValue> CardsList
            {
                get
                {
                    return this.PrepareBuilder().cards_;
                }
            }

            public override CardValues DefaultInstanceForType
            {
                get
                {
                    return CardValues.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override CardValues MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override CardValues.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 260
            }
        }
    }
}

