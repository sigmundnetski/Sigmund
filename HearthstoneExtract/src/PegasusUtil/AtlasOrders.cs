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
    public sealed class AtlasOrders : GeneratedMessageLite<AtlasOrders, Builder>
    {
        private static readonly string[] _atlasOrdersFieldNames = new string[] { "orders" };
        private static readonly uint[] _atlasOrdersFieldTags = new uint[] { 10 };
        private static readonly AtlasOrders defaultInstance = new AtlasOrders().MakeReadOnly();
        private int memoizedSerializedSize = -1;
        private PopsicleList<AtlasOrder> orders_ = new PopsicleList<AtlasOrder>();
        public const int OrdersFieldNumber = 1;

        static AtlasOrders()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AtlasOrders()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AtlasOrders prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AtlasOrders orders = obj as AtlasOrders;
            if (orders == null)
            {
                return false;
            }
            if (this.orders_.Count != orders.orders_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.orders_.Count; i++)
            {
                if (!this.orders_[i].Equals(orders.orders_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<AtlasOrder> enumerator = this.orders_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    AtlasOrder current = enumerator.Current;
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

        public AtlasOrder GetOrders(int index)
        {
            return this.orders_[index];
        }

        private AtlasOrders MakeReadOnly()
        {
            this.orders_.MakeReadOnly();
            return this;
        }

        public static AtlasOrders ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AtlasOrders ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasOrders ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasOrders ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasOrders ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasOrders ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasOrders ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AtlasOrders ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasOrders ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasOrders ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AtlasOrders, Builder>.PrintField<AtlasOrder>("orders", this.orders_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _atlasOrdersFieldNames;
            if (this.orders_.Count > 0)
            {
                output.WriteMessageArray<AtlasOrder>(1, strArray[0], this.orders_);
            }
        }

        public static AtlasOrders DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AtlasOrders DefaultInstanceForType
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
                IEnumerator<AtlasOrder> enumerator = this.OrdersList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        AtlasOrder current = enumerator.Current;
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

        public int OrdersCount
        {
            get
            {
                return this.orders_.Count;
            }
        }

        public IList<AtlasOrder> OrdersList
        {
            get
            {
                return this.orders_;
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
                    IEnumerator<AtlasOrder> enumerator = this.OrdersList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            AtlasOrder current = enumerator.Current;
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

        protected override AtlasOrders ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<AtlasOrders, AtlasOrders.Builder>
        {
            private AtlasOrders result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AtlasOrders.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AtlasOrders cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public AtlasOrders.Builder AddOrders(AtlasOrder value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.orders_.Add(value);
                return this;
            }

            public AtlasOrders.Builder AddOrders(AtlasOrder.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.orders_.Add(builderForValue.Build());
                return this;
            }

            public AtlasOrders.Builder AddRangeOrders(IEnumerable<AtlasOrder> values)
            {
                this.PrepareBuilder();
                this.result.orders_.Add(values);
                return this;
            }

            public override AtlasOrders BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AtlasOrders.Builder Clear()
            {
                this.result = AtlasOrders.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AtlasOrders.Builder ClearOrders()
            {
                this.PrepareBuilder();
                this.result.orders_.Clear();
                return this;
            }

            public override AtlasOrders.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AtlasOrders.Builder(this.result);
                }
                return new AtlasOrders.Builder().MergeFrom(this.result);
            }

            public AtlasOrder GetOrders(int index)
            {
                return this.result.GetOrders(index);
            }

            public override AtlasOrders.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AtlasOrders.Builder MergeFrom(IMessageLite other)
            {
                if (other is AtlasOrders)
                {
                    return this.MergeFrom((AtlasOrders) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AtlasOrders.Builder MergeFrom(AtlasOrders other)
            {
                if (other != AtlasOrders.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.orders_.Count != 0)
                    {
                        this.result.orders_.Add(other.orders_);
                    }
                }
                return this;
            }

            public override AtlasOrders.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AtlasOrders._atlasOrdersFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AtlasOrders._atlasOrdersFieldTags[index];
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
                    input.ReadMessageArray<AtlasOrder>(num, str, this.result.orders_, AtlasOrder.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private AtlasOrders PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AtlasOrders result = this.result;
                    this.result = new AtlasOrders();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public AtlasOrders.Builder SetOrders(int index, AtlasOrder value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.orders_[index] = value;
                return this;
            }

            public AtlasOrders.Builder SetOrders(int index, AtlasOrder.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.orders_[index] = builderForValue.Build();
                return this;
            }

            public override AtlasOrders DefaultInstanceForType
            {
                get
                {
                    return AtlasOrders.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override AtlasOrders MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int OrdersCount
            {
                get
                {
                    return this.result.OrdersCount;
                }
            }

            public IPopsicleList<AtlasOrder> OrdersList
            {
                get
                {
                    return this.PrepareBuilder().orders_;
                }
            }

            protected override AtlasOrders.Builder ThisBuilder
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
                ID = 0x6a
            }
        }
    }
}

