namespace bnet.protocol.game_utilities
{
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class AttributeFilter : GeneratedMessageLite<AttributeFilter, Builder>
    {
        private static readonly string[] _attributeFilterFieldNames = new string[] { "attribute", "op" };
        private static readonly uint[] _attributeFilterFieldTags = new uint[] { 0x12, 8 };
        private PopsicleList<bnet.protocol.game_utilities.Attribute> attribute_ = new PopsicleList<bnet.protocol.game_utilities.Attribute>();
        public const int AttributeFieldNumber = 2;
        private static readonly AttributeFilter defaultInstance = new AttributeFilter().MakeReadOnly();
        private bool hasOp;
        private int memoizedSerializedSize = -1;
        private Types.Operation op_;
        public const int OpFieldNumber = 1;

        static AttributeFilter()
        {
            object.ReferenceEquals(GameUtils.Descriptor, null);
        }

        private AttributeFilter()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AttributeFilter prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AttributeFilter filter = obj as AttributeFilter;
            if (filter == null)
            {
                return false;
            }
            if ((this.hasOp != filter.hasOp) || (this.hasOp && !this.op_.Equals(filter.op_)))
            {
                return false;
            }
            if (this.attribute_.Count != filter.attribute_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.attribute_.Count; i++)
            {
                if (!this.attribute_[i].Equals(filter.attribute_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public bnet.protocol.game_utilities.Attribute GetAttribute(int index)
        {
            return this.attribute_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasOp)
            {
                hashCode ^= this.op_.GetHashCode();
            }
            IEnumerator<bnet.protocol.game_utilities.Attribute> enumerator = this.attribute_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    bnet.protocol.game_utilities.Attribute current = enumerator.Current;
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

        private AttributeFilter MakeReadOnly()
        {
            this.attribute_.MakeReadOnly();
            return this;
        }

        public static AttributeFilter ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AttributeFilter ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AttributeFilter ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AttributeFilter ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AttributeFilter ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AttributeFilter ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AttributeFilter ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AttributeFilter ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AttributeFilter ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AttributeFilter ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AttributeFilter, Builder>.PrintField("op", this.hasOp, this.op_, writer);
            GeneratedMessageLite<AttributeFilter, Builder>.PrintField<bnet.protocol.game_utilities.Attribute>("attribute", this.attribute_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _attributeFilterFieldNames;
            if (this.hasOp)
            {
                output.WriteEnum(1, strArray[1], (int) this.Op, this.Op);
            }
            if (this.attribute_.Count > 0)
            {
                output.WriteMessageArray<bnet.protocol.game_utilities.Attribute>(2, strArray[0], this.attribute_);
            }
        }

        public int AttributeCount
        {
            get
            {
                return this.attribute_.Count;
            }
        }

        public IList<bnet.protocol.game_utilities.Attribute> AttributeList
        {
            get
            {
                return this.attribute_;
            }
        }

        public static AttributeFilter DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AttributeFilter DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasOp
        {
            get
            {
                return this.hasOp;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasOp)
                {
                    return false;
                }
                IEnumerator<bnet.protocol.game_utilities.Attribute> enumerator = this.AttributeList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        bnet.protocol.game_utilities.Attribute current = enumerator.Current;
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

        public Types.Operation Op
        {
            get
            {
                return this.op_;
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
                    if (this.hasOp)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeEnumSize(1, (int) this.Op);
                    }
                    IEnumerator<bnet.protocol.game_utilities.Attribute> enumerator = this.AttributeList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            bnet.protocol.game_utilities.Attribute current = enumerator.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, current);
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

        protected override AttributeFilter ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<AttributeFilter, AttributeFilter.Builder>
        {
            private AttributeFilter result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AttributeFilter.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AttributeFilter cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public AttributeFilter.Builder AddAttribute(bnet.protocol.game_utilities.Attribute value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.attribute_.Add(value);
                return this;
            }

            public AttributeFilter.Builder AddAttribute(bnet.protocol.game_utilities.Attribute.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.attribute_.Add(builderForValue.Build());
                return this;
            }

            public AttributeFilter.Builder AddRangeAttribute(IEnumerable<bnet.protocol.game_utilities.Attribute> values)
            {
                this.PrepareBuilder();
                this.result.attribute_.Add(values);
                return this;
            }

            public override AttributeFilter BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AttributeFilter.Builder Clear()
            {
                this.result = AttributeFilter.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AttributeFilter.Builder ClearAttribute()
            {
                this.PrepareBuilder();
                this.result.attribute_.Clear();
                return this;
            }

            public AttributeFilter.Builder ClearOp()
            {
                this.PrepareBuilder();
                this.result.hasOp = false;
                this.result.op_ = AttributeFilter.Types.Operation.MATCH_NONE;
                return this;
            }

            public override AttributeFilter.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AttributeFilter.Builder(this.result);
                }
                return new AttributeFilter.Builder().MergeFrom(this.result);
            }

            public bnet.protocol.game_utilities.Attribute GetAttribute(int index)
            {
                return this.result.GetAttribute(index);
            }

            public override AttributeFilter.Builder MergeFrom(AttributeFilter other)
            {
                if (other != AttributeFilter.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasOp)
                    {
                        this.Op = other.Op;
                    }
                    if (other.attribute_.Count != 0)
                    {
                        this.result.attribute_.Add(other.attribute_);
                    }
                }
                return this;
            }

            public override AttributeFilter.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AttributeFilter.Builder MergeFrom(IMessageLite other)
            {
                if (other is AttributeFilter)
                {
                    return this.MergeFrom((AttributeFilter) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AttributeFilter.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AttributeFilter._attributeFilterFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AttributeFilter._attributeFilterFieldTags[index];
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
                            object obj2;
                            if (input.ReadEnum<AttributeFilter.Types.Operation>(ref this.result.op_, out obj2))
                            {
                                this.result.hasOp = true;
                            }
                            else if (obj2 is int)
                            {
                            }
                            continue;
                        }
                        case 0x12:
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
                    input.ReadMessageArray<bnet.protocol.game_utilities.Attribute>(num, str, this.result.attribute_, bnet.protocol.game_utilities.Attribute.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private AttributeFilter PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AttributeFilter result = this.result;
                    this.result = new AttributeFilter();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public AttributeFilter.Builder SetAttribute(int index, bnet.protocol.game_utilities.Attribute value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.attribute_[index] = value;
                return this;
            }

            public AttributeFilter.Builder SetAttribute(int index, bnet.protocol.game_utilities.Attribute.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.attribute_[index] = builderForValue.Build();
                return this;
            }

            public AttributeFilter.Builder SetOp(AttributeFilter.Types.Operation value)
            {
                this.PrepareBuilder();
                this.result.hasOp = true;
                this.result.op_ = value;
                return this;
            }

            public int AttributeCount
            {
                get
                {
                    return this.result.AttributeCount;
                }
            }

            public IPopsicleList<bnet.protocol.game_utilities.Attribute> AttributeList
            {
                get
                {
                    return this.PrepareBuilder().attribute_;
                }
            }

            public override AttributeFilter DefaultInstanceForType
            {
                get
                {
                    return AttributeFilter.DefaultInstance;
                }
            }

            public bool HasOp
            {
                get
                {
                    return this.result.hasOp;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override AttributeFilter MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public AttributeFilter.Types.Operation Op
            {
                get
                {
                    return this.result.Op;
                }
                set
                {
                    this.SetOp(value);
                }
            }

            protected override AttributeFilter.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum Operation
            {
                MATCH_NONE,
                MATCH_ANY,
                MATCH_ALL,
                MATCH_ALL_MOST_SPECIFIC
            }
        }
    }
}

