namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class DebugPaneNewItems : GeneratedMessageLite<DebugPaneNewItems, Builder>
    {
        private static readonly string[] _debugPaneNewItemsFieldNames = new string[] { "items" };
        private static readonly uint[] _debugPaneNewItemsFieldTags = new uint[] { 10 };
        private static readonly DebugPaneNewItems defaultInstance = new DebugPaneNewItems().MakeReadOnly();
        private PopsicleList<Types.DebugPaneNewItem> items_ = new PopsicleList<Types.DebugPaneNewItem>();
        public const int ItemsFieldNumber = 1;
        private int memoizedSerializedSize = -1;

        static DebugPaneNewItems()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private DebugPaneNewItems()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DebugPaneNewItems prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DebugPaneNewItems items = obj as DebugPaneNewItems;
            if (items == null)
            {
                return false;
            }
            if (this.items_.Count != items.items_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.items_.Count; i++)
            {
                if (!this.items_[i].Equals(items.items_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<Types.DebugPaneNewItem> enumerator = this.items_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    Types.DebugPaneNewItem current = enumerator.Current;
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

        public Types.DebugPaneNewItem GetItems(int index)
        {
            return this.items_[index];
        }

        private DebugPaneNewItems MakeReadOnly()
        {
            this.items_.MakeReadOnly();
            return this;
        }

        public static DebugPaneNewItems ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DebugPaneNewItems ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DebugPaneNewItems ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DebugPaneNewItems ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DebugPaneNewItems ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DebugPaneNewItems ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DebugPaneNewItems ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DebugPaneNewItems ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DebugPaneNewItems ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DebugPaneNewItems ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DebugPaneNewItems, Builder>.PrintField<Types.DebugPaneNewItem>("items", this.items_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _debugPaneNewItemsFieldNames;
            if (this.items_.Count > 0)
            {
                output.WriteMessageArray<Types.DebugPaneNewItem>(1, strArray[0], this.items_);
            }
        }

        public static DebugPaneNewItems DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DebugPaneNewItems DefaultInstanceForType
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
                IEnumerator<Types.DebugPaneNewItem> enumerator = this.ItemsList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        Types.DebugPaneNewItem current = enumerator.Current;
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

        public int ItemsCount
        {
            get
            {
                return this.items_.Count;
            }
        }

        public IList<Types.DebugPaneNewItem> ItemsList
        {
            get
            {
                return this.items_;
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
                    IEnumerator<Types.DebugPaneNewItem> enumerator = this.ItemsList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            Types.DebugPaneNewItem current = enumerator.Current;
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

        protected override DebugPaneNewItems ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<DebugPaneNewItems, DebugPaneNewItems.Builder>
        {
            private DebugPaneNewItems result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DebugPaneNewItems.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DebugPaneNewItems cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public DebugPaneNewItems.Builder AddItems(DebugPaneNewItems.Types.DebugPaneNewItem value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.items_.Add(value);
                return this;
            }

            public DebugPaneNewItems.Builder AddItems(DebugPaneNewItems.Types.DebugPaneNewItem.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.items_.Add(builderForValue.Build());
                return this;
            }

            public DebugPaneNewItems.Builder AddRangeItems(IEnumerable<DebugPaneNewItems.Types.DebugPaneNewItem> values)
            {
                this.PrepareBuilder();
                this.result.items_.Add(values);
                return this;
            }

            public override DebugPaneNewItems BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DebugPaneNewItems.Builder Clear()
            {
                this.result = DebugPaneNewItems.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DebugPaneNewItems.Builder ClearItems()
            {
                this.PrepareBuilder();
                this.result.items_.Clear();
                return this;
            }

            public override DebugPaneNewItems.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DebugPaneNewItems.Builder(this.result);
                }
                return new DebugPaneNewItems.Builder().MergeFrom(this.result);
            }

            public DebugPaneNewItems.Types.DebugPaneNewItem GetItems(int index)
            {
                return this.result.GetItems(index);
            }

            public override DebugPaneNewItems.Builder MergeFrom(DebugPaneNewItems other)
            {
                if (other != DebugPaneNewItems.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.items_.Count != 0)
                    {
                        this.result.items_.Add(other.items_);
                    }
                }
                return this;
            }

            public override DebugPaneNewItems.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DebugPaneNewItems.Builder MergeFrom(IMessageLite other)
            {
                if (other is DebugPaneNewItems)
                {
                    return this.MergeFrom((DebugPaneNewItems) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DebugPaneNewItems.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DebugPaneNewItems._debugPaneNewItemsFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DebugPaneNewItems._debugPaneNewItemsFieldTags[index];
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
                    input.ReadMessageArray<DebugPaneNewItems.Types.DebugPaneNewItem>(num, str, this.result.items_, DebugPaneNewItems.Types.DebugPaneNewItem.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private DebugPaneNewItems PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DebugPaneNewItems result = this.result;
                    this.result = new DebugPaneNewItems();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DebugPaneNewItems.Builder SetItems(int index, DebugPaneNewItems.Types.DebugPaneNewItem value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.items_[index] = value;
                return this;
            }

            public DebugPaneNewItems.Builder SetItems(int index, DebugPaneNewItems.Types.DebugPaneNewItem.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.items_[index] = builderForValue.Build();
                return this;
            }

            public override DebugPaneNewItems DefaultInstanceForType
            {
                get
                {
                    return DebugPaneNewItems.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public int ItemsCount
            {
                get
                {
                    return this.result.ItemsCount;
                }
            }

            public IPopsicleList<DebugPaneNewItems.Types.DebugPaneNewItem> ItemsList
            {
                get
                {
                    return this.PrepareBuilder().items_;
                }
            }

            protected override DebugPaneNewItems MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override DebugPaneNewItems.Builder ThisBuilder
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
            [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public sealed class DebugPaneNewItem : GeneratedMessageLite<DebugPaneNewItems.Types.DebugPaneNewItem, Builder>
            {
                private static readonly string[] _debugPaneNewItemFieldNames = new string[] { "name", "value" };
                private static readonly uint[] _debugPaneNewItemFieldTags = new uint[] { 10, 0x12 };
                private static readonly DebugPaneNewItems.Types.DebugPaneNewItem defaultInstance = new DebugPaneNewItems.Types.DebugPaneNewItem().MakeReadOnly();
                private bool hasName;
                private bool hasValue;
                private int memoizedSerializedSize = -1;
                private string name_ = string.Empty;
                public const int NameFieldNumber = 1;
                private string value_ = string.Empty;
                public const int ValueFieldNumber = 2;

                static DebugPaneNewItem()
                {
                    object.ReferenceEquals(BobNetlite.Descriptor, null);
                }

                private DebugPaneNewItem()
                {
                }

                public static Builder CreateBuilder()
                {
                    return new Builder();
                }

                public static Builder CreateBuilder(DebugPaneNewItems.Types.DebugPaneNewItem prototype)
                {
                    return new Builder(prototype);
                }

                public override Builder CreateBuilderForType()
                {
                    return new Builder();
                }

                public override bool Equals(object obj)
                {
                    DebugPaneNewItems.Types.DebugPaneNewItem item = obj as DebugPaneNewItems.Types.DebugPaneNewItem;
                    if (item == null)
                    {
                        return false;
                    }
                    if ((this.hasName != item.hasName) || (this.hasName && !this.name_.Equals(item.name_)))
                    {
                        return false;
                    }
                    return ((this.hasValue == item.hasValue) && (!this.hasValue || this.value_.Equals(item.value_)));
                }

                public override int GetHashCode()
                {
                    int hashCode = base.GetType().GetHashCode();
                    if (this.hasName)
                    {
                        hashCode ^= this.name_.GetHashCode();
                    }
                    if (this.hasValue)
                    {
                        hashCode ^= this.value_.GetHashCode();
                    }
                    return hashCode;
                }

                private DebugPaneNewItems.Types.DebugPaneNewItem MakeReadOnly()
                {
                    return this;
                }

                public static DebugPaneNewItems.Types.DebugPaneNewItem ParseDelimitedFrom(Stream input)
                {
                    return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
                }

                public static DebugPaneNewItems.Types.DebugPaneNewItem ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
                {
                    return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
                }

                public static DebugPaneNewItems.Types.DebugPaneNewItem ParseFrom(byte[] data)
                {
                    return CreateBuilder().MergeFrom(data).BuildParsed();
                }

                public static DebugPaneNewItems.Types.DebugPaneNewItem ParseFrom(ByteString data)
                {
                    return CreateBuilder().MergeFrom(data).BuildParsed();
                }

                public static DebugPaneNewItems.Types.DebugPaneNewItem ParseFrom(ICodedInputStream input)
                {
                    return CreateBuilder().MergeFrom(input).BuildParsed();
                }

                public static DebugPaneNewItems.Types.DebugPaneNewItem ParseFrom(Stream input)
                {
                    return CreateBuilder().MergeFrom(input).BuildParsed();
                }

                public static DebugPaneNewItems.Types.DebugPaneNewItem ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
                {
                    return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
                }

                public static DebugPaneNewItems.Types.DebugPaneNewItem ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
                {
                    return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
                }

                public static DebugPaneNewItems.Types.DebugPaneNewItem ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
                {
                    return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
                }

                public static DebugPaneNewItems.Types.DebugPaneNewItem ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
                {
                    return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
                }

                public override void PrintTo(TextWriter writer)
                {
                    GeneratedMessageLite<DebugPaneNewItems.Types.DebugPaneNewItem, Builder>.PrintField("name", this.hasName, this.name_, writer);
                    GeneratedMessageLite<DebugPaneNewItems.Types.DebugPaneNewItem, Builder>.PrintField("value", this.hasValue, this.value_, writer);
                }

                public override Builder ToBuilder()
                {
                    return CreateBuilder(this);
                }

                public override void WriteTo(ICodedOutputStream output)
                {
                    int serializedSize = this.SerializedSize;
                    string[] strArray = _debugPaneNewItemFieldNames;
                    if (this.hasName)
                    {
                        output.WriteString(1, strArray[0], this.Name);
                    }
                    if (this.hasValue)
                    {
                        output.WriteString(2, strArray[1], this.Value);
                    }
                }

                public static DebugPaneNewItems.Types.DebugPaneNewItem DefaultInstance
                {
                    get
                    {
                        return defaultInstance;
                    }
                }

                public override DebugPaneNewItems.Types.DebugPaneNewItem DefaultInstanceForType
                {
                    get
                    {
                        return DefaultInstance;
                    }
                }

                public bool HasName
                {
                    get
                    {
                        return this.hasName;
                    }
                }

                public bool HasValue
                {
                    get
                    {
                        return this.hasValue;
                    }
                }

                public override bool IsInitialized
                {
                    get
                    {
                        if (!this.hasName)
                        {
                            return false;
                        }
                        if (!this.hasValue)
                        {
                            return false;
                        }
                        return true;
                    }
                }

                public string Name
                {
                    get
                    {
                        return this.name_;
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
                            if (this.hasName)
                            {
                                memoizedSerializedSize += CodedOutputStream.ComputeStringSize(1, this.Name);
                            }
                            if (this.hasValue)
                            {
                                memoizedSerializedSize += CodedOutputStream.ComputeStringSize(2, this.Value);
                            }
                            this.memoizedSerializedSize = memoizedSerializedSize;
                        }
                        return memoizedSerializedSize;
                    }
                }

                protected override DebugPaneNewItems.Types.DebugPaneNewItem ThisMessage
                {
                    get
                    {
                        return this;
                    }
                }

                public string Value
                {
                    get
                    {
                        return this.value_;
                    }
                }

                [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
                public sealed class Builder : GeneratedBuilderLite<DebugPaneNewItems.Types.DebugPaneNewItem, DebugPaneNewItems.Types.DebugPaneNewItem.Builder>
                {
                    private DebugPaneNewItems.Types.DebugPaneNewItem result;
                    private bool resultIsReadOnly;

                    public Builder()
                    {
                        this.result = DebugPaneNewItems.Types.DebugPaneNewItem.DefaultInstance;
                        this.resultIsReadOnly = true;
                    }

                    internal Builder(DebugPaneNewItems.Types.DebugPaneNewItem cloneFrom)
                    {
                        this.result = cloneFrom;
                        this.resultIsReadOnly = true;
                    }

                    public override DebugPaneNewItems.Types.DebugPaneNewItem BuildPartial()
                    {
                        if (this.resultIsReadOnly)
                        {
                            return this.result;
                        }
                        this.resultIsReadOnly = true;
                        return this.result.MakeReadOnly();
                    }

                    public override DebugPaneNewItems.Types.DebugPaneNewItem.Builder Clear()
                    {
                        this.result = DebugPaneNewItems.Types.DebugPaneNewItem.DefaultInstance;
                        this.resultIsReadOnly = true;
                        return this;
                    }

                    public DebugPaneNewItems.Types.DebugPaneNewItem.Builder ClearName()
                    {
                        this.PrepareBuilder();
                        this.result.hasName = false;
                        this.result.name_ = string.Empty;
                        return this;
                    }

                    public DebugPaneNewItems.Types.DebugPaneNewItem.Builder ClearValue()
                    {
                        this.PrepareBuilder();
                        this.result.hasValue = false;
                        this.result.value_ = string.Empty;
                        return this;
                    }

                    public override DebugPaneNewItems.Types.DebugPaneNewItem.Builder Clone()
                    {
                        if (this.resultIsReadOnly)
                        {
                            return new DebugPaneNewItems.Types.DebugPaneNewItem.Builder(this.result);
                        }
                        return new DebugPaneNewItems.Types.DebugPaneNewItem.Builder().MergeFrom(this.result);
                    }

                    public override DebugPaneNewItems.Types.DebugPaneNewItem.Builder MergeFrom(DebugPaneNewItems.Types.DebugPaneNewItem other)
                    {
                        if (other != DebugPaneNewItems.Types.DebugPaneNewItem.DefaultInstance)
                        {
                            this.PrepareBuilder();
                            if (other.HasName)
                            {
                                this.Name = other.Name;
                            }
                            if (other.HasValue)
                            {
                                this.Value = other.Value;
                            }
                        }
                        return this;
                    }

                    public override DebugPaneNewItems.Types.DebugPaneNewItem.Builder MergeFrom(ICodedInputStream input)
                    {
                        return this.MergeFrom(input, ExtensionRegistry.Empty);
                    }

                    public override DebugPaneNewItems.Types.DebugPaneNewItem.Builder MergeFrom(IMessageLite other)
                    {
                        if (other is DebugPaneNewItems.Types.DebugPaneNewItem)
                        {
                            return this.MergeFrom((DebugPaneNewItems.Types.DebugPaneNewItem) other);
                        }
                        base.MergeFrom(other);
                        return this;
                    }

                    public override DebugPaneNewItems.Types.DebugPaneNewItem.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
                    {
                        uint num;
                        string str;
                        this.PrepareBuilder();
                        while (input.ReadTag(out num, out str))
                        {
                            if ((num == 0) && (str != null))
                            {
                                int index = Array.BinarySearch<string>(DebugPaneNewItems.Types.DebugPaneNewItem._debugPaneNewItemFieldNames, str, StringComparer.Ordinal);
                                if (index >= 0)
                                {
                                    num = DebugPaneNewItems.Types.DebugPaneNewItem._debugPaneNewItemFieldTags[index];
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
                                    this.result.hasName = input.ReadString(ref this.result.name_);
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
                            this.result.hasValue = input.ReadString(ref this.result.value_);
                        }
                        return this;
                    }

                    private DebugPaneNewItems.Types.DebugPaneNewItem PrepareBuilder()
                    {
                        if (this.resultIsReadOnly)
                        {
                            DebugPaneNewItems.Types.DebugPaneNewItem result = this.result;
                            this.result = new DebugPaneNewItems.Types.DebugPaneNewItem();
                            this.resultIsReadOnly = false;
                            this.MergeFrom(result);
                        }
                        return this.result;
                    }

                    public DebugPaneNewItems.Types.DebugPaneNewItem.Builder SetName(string value)
                    {
                        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                        this.PrepareBuilder();
                        this.result.hasName = true;
                        this.result.name_ = value;
                        return this;
                    }

                    public DebugPaneNewItems.Types.DebugPaneNewItem.Builder SetValue(string value)
                    {
                        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                        this.PrepareBuilder();
                        this.result.hasValue = true;
                        this.result.value_ = value;
                        return this;
                    }

                    public override DebugPaneNewItems.Types.DebugPaneNewItem DefaultInstanceForType
                    {
                        get
                        {
                            return DebugPaneNewItems.Types.DebugPaneNewItem.DefaultInstance;
                        }
                    }

                    public bool HasName
                    {
                        get
                        {
                            return this.result.hasName;
                        }
                    }

                    public bool HasValue
                    {
                        get
                        {
                            return this.result.hasValue;
                        }
                    }

                    public override bool IsInitialized
                    {
                        get
                        {
                            return this.result.IsInitialized;
                        }
                    }

                    protected override DebugPaneNewItems.Types.DebugPaneNewItem MessageBeingBuilt
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

                    protected override DebugPaneNewItems.Types.DebugPaneNewItem.Builder ThisBuilder
                    {
                        get
                        {
                            return this;
                        }
                    }

                    public string Value
                    {
                        get
                        {
                            return this.result.Value;
                        }
                        set
                        {
                            this.SetValue(value);
                        }
                    }
                }
            }

            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0x8e
            }
        }
    }
}

