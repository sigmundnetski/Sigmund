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

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class CardUsage : GeneratedMessageLite<CardUsage, Builder>
    {
        private static readonly string[] _cardUsageFieldNames = new string[] { "list" };
        private static readonly uint[] _cardUsageFieldTags = new uint[] { 10 };
        private static readonly CardUsage defaultInstance = new CardUsage().MakeReadOnly();
        private PopsicleList<CardUseCount> list_ = new PopsicleList<CardUseCount>();
        public const int ListFieldNumber = 1;
        private int memoizedSerializedSize = -1;

        static CardUsage()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private CardUsage()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(CardUsage prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            CardUsage usage = obj as CardUsage;
            if (usage == null)
            {
                return false;
            }
            if (this.list_.Count != usage.list_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.list_.Count; i++)
            {
                if (!this.list_[i].Equals(usage.list_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<CardUseCount> enumerator = this.list_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    CardUseCount current = enumerator.Current;
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

        public CardUseCount GetList(int index)
        {
            return this.list_[index];
        }

        private CardUsage MakeReadOnly()
        {
            this.list_.MakeReadOnly();
            return this;
        }

        public static CardUsage ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static CardUsage ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static CardUsage ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static CardUsage ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static CardUsage ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static CardUsage ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static CardUsage ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static CardUsage ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static CardUsage ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static CardUsage ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<CardUsage, Builder>.PrintField<CardUseCount>("list", this.list_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _cardUsageFieldNames;
            if (this.list_.Count > 0)
            {
                output.WriteMessageArray<CardUseCount>(1, strArray[0], this.list_);
            }
        }

        public static CardUsage DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override CardUsage DefaultInstanceForType
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
                IEnumerator<CardUseCount> enumerator = this.ListList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        CardUseCount current = enumerator.Current;
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

        public int ListCount
        {
            get
            {
                return this.list_.Count;
            }
        }

        public IList<CardUseCount> ListList
        {
            get
            {
                return this.list_;
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
                    IEnumerator<CardUseCount> enumerator = this.ListList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            CardUseCount current = enumerator.Current;
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

        protected override CardUsage ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<CardUsage, CardUsage.Builder>
        {
            private CardUsage result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = CardUsage.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(CardUsage cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public CardUsage.Builder AddList(CardUseCount value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.list_.Add(value);
                return this;
            }

            public CardUsage.Builder AddList(CardUseCount.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.list_.Add(builderForValue.Build());
                return this;
            }

            public CardUsage.Builder AddRangeList(IEnumerable<CardUseCount> values)
            {
                this.PrepareBuilder();
                this.result.list_.Add(values);
                return this;
            }

            public override CardUsage BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override CardUsage.Builder Clear()
            {
                this.result = CardUsage.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public CardUsage.Builder ClearList()
            {
                this.PrepareBuilder();
                this.result.list_.Clear();
                return this;
            }

            public override CardUsage.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new CardUsage.Builder(this.result);
                }
                return new CardUsage.Builder().MergeFrom(this.result);
            }

            public CardUseCount GetList(int index)
            {
                return this.result.GetList(index);
            }

            public override CardUsage.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override CardUsage.Builder MergeFrom(IMessageLite other)
            {
                if (other is CardUsage)
                {
                    return this.MergeFrom((CardUsage) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override CardUsage.Builder MergeFrom(CardUsage other)
            {
                if (other != CardUsage.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.list_.Count != 0)
                    {
                        this.result.list_.Add(other.list_);
                    }
                }
                return this;
            }

            public override CardUsage.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(CardUsage._cardUsageFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = CardUsage._cardUsageFieldTags[index];
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
                    input.ReadMessageArray<CardUseCount>(num, str, this.result.list_, CardUseCount.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private CardUsage PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    CardUsage result = this.result;
                    this.result = new CardUsage();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public CardUsage.Builder SetList(int index, CardUseCount value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.list_[index] = value;
                return this;
            }

            public CardUsage.Builder SetList(int index, CardUseCount.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.list_[index] = builderForValue.Build();
                return this;
            }

            public override CardUsage DefaultInstanceForType
            {
                get
                {
                    return CardUsage.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public int ListCount
            {
                get
                {
                    return this.result.ListCount;
                }
            }

            public IPopsicleList<CardUseCount> ListList
            {
                get
                {
                    return this.PrepareBuilder().list_;
                }
            }

            protected override CardUsage MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override CardUsage.Builder ThisBuilder
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
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0xec
            }
        }
    }
}

