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

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class DebugPaneDelItems : GeneratedMessageLite<DebugPaneDelItems, Builder>
    {
        private static readonly string[] _debugPaneDelItemsFieldNames = new string[] { "items" };
        private static readonly uint[] _debugPaneDelItemsFieldTags = new uint[] { 10 };
        private static readonly DebugPaneDelItems defaultInstance = new DebugPaneDelItems().MakeReadOnly();
        private PopsicleList<Types.DebugPaneDelItem> items_ = new PopsicleList<Types.DebugPaneDelItem>();
        public const int ItemsFieldNumber = 1;
        private int memoizedSerializedSize = -1;

        static DebugPaneDelItems()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private DebugPaneDelItems()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DebugPaneDelItems prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DebugPaneDelItems items = obj as DebugPaneDelItems;
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
            IEnumerator<Types.DebugPaneDelItem> enumerator = this.items_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    Types.DebugPaneDelItem current = enumerator.Current;
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

        public Types.DebugPaneDelItem GetItems(int index)
        {
            return this.items_[index];
        }

        private DebugPaneDelItems MakeReadOnly()
        {
            this.items_.MakeReadOnly();
            return this;
        }

        public static DebugPaneDelItems ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DebugPaneDelItems ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DebugPaneDelItems ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DebugPaneDelItems ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DebugPaneDelItems ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DebugPaneDelItems ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DebugPaneDelItems ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DebugPaneDelItems ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DebugPaneDelItems ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DebugPaneDelItems ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DebugPaneDelItems, Builder>.PrintField<Types.DebugPaneDelItem>("items", this.items_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _debugPaneDelItemsFieldNames;
            if (this.items_.Count > 0)
            {
                output.WriteMessageArray<Types.DebugPaneDelItem>(1, strArray[0], this.items_);
            }
        }

        public static DebugPaneDelItems DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DebugPaneDelItems DefaultInstanceForType
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
                IEnumerator<Types.DebugPaneDelItem> enumerator = this.ItemsList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        Types.DebugPaneDelItem current = enumerator.Current;
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

        public IList<Types.DebugPaneDelItem> ItemsList
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
                    IEnumerator<Types.DebugPaneDelItem> enumerator = this.ItemsList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            Types.DebugPaneDelItem current = enumerator.Current;
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

        protected override DebugPaneDelItems ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<DebugPaneDelItems, DebugPaneDelItems.Builder>
        {
            private DebugPaneDelItems result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DebugPaneDelItems.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DebugPaneDelItems cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public DebugPaneDelItems.Builder AddItems(DebugPaneDelItems.Types.DebugPaneDelItem value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.items_.Add(value);
                return this;
            }

            public DebugPaneDelItems.Builder AddItems(DebugPaneDelItems.Types.DebugPaneDelItem.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.items_.Add(builderForValue.Build());
                return this;
            }

            public DebugPaneDelItems.Builder AddRangeItems(IEnumerable<DebugPaneDelItems.Types.DebugPaneDelItem> values)
            {
                this.PrepareBuilder();
                this.result.items_.Add(values);
                return this;
            }

            public override DebugPaneDelItems BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DebugPaneDelItems.Builder Clear()
            {
                this.result = DebugPaneDelItems.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DebugPaneDelItems.Builder ClearItems()
            {
                this.PrepareBuilder();
                this.result.items_.Clear();
                return this;
            }

            public override DebugPaneDelItems.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DebugPaneDelItems.Builder(this.result);
                }
                return new DebugPaneDelItems.Builder().MergeFrom(this.result);
            }

            public DebugPaneDelItems.Types.DebugPaneDelItem GetItems(int index)
            {
                return this.result.GetItems(index);
            }

            public override DebugPaneDelItems.Builder MergeFrom(DebugPaneDelItems other)
            {
                if (other != DebugPaneDelItems.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.items_.Count != 0)
                    {
                        this.result.items_.Add(other.items_);
                    }
                }
                return this;
            }

            public override DebugPaneDelItems.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DebugPaneDelItems.Builder MergeFrom(IMessageLite other)
            {
                if (other is DebugPaneDelItems)
                {
                    return this.MergeFrom((DebugPaneDelItems) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DebugPaneDelItems.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DebugPaneDelItems._debugPaneDelItemsFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DebugPaneDelItems._debugPaneDelItemsFieldTags[index];
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
                    input.ReadMessageArray<DebugPaneDelItems.Types.DebugPaneDelItem>(num, str, this.result.items_, DebugPaneDelItems.Types.DebugPaneDelItem.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private DebugPaneDelItems PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DebugPaneDelItems result = this.result;
                    this.result = new DebugPaneDelItems();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DebugPaneDelItems.Builder SetItems(int index, DebugPaneDelItems.Types.DebugPaneDelItem value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.items_[index] = value;
                return this;
            }

            public DebugPaneDelItems.Builder SetItems(int index, DebugPaneDelItems.Types.DebugPaneDelItem.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.items_[index] = builderForValue.Build();
                return this;
            }

            public override DebugPaneDelItems DefaultInstanceForType
            {
                get
                {
                    return DebugPaneDelItems.DefaultInstance;
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

            public IPopsicleList<DebugPaneDelItems.Types.DebugPaneDelItem> ItemsList
            {
                get
                {
                    return this.PrepareBuilder().items_;
                }
            }

            protected override DebugPaneDelItems MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override DebugPaneDelItems.Builder ThisBuilder
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
            [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public sealed class DebugPaneDelItem : GeneratedMessageLite<DebugPaneDelItems.Types.DebugPaneDelItem, Builder>
            {
                private static readonly string[] _debugPaneDelItemFieldNames = new string[] { "name" };
                private static readonly uint[] _debugPaneDelItemFieldTags = new uint[] { 10 };
                private static readonly DebugPaneDelItems.Types.DebugPaneDelItem defaultInstance = new DebugPaneDelItems.Types.DebugPaneDelItem().MakeReadOnly();
                private bool hasName;
                private int memoizedSerializedSize = -1;
                private string name_ = string.Empty;
                public const int NameFieldNumber = 1;

                static DebugPaneDelItem()
                {
                    object.ReferenceEquals(BobNetlite.Descriptor, null);
                }

                private DebugPaneDelItem()
                {
                }

                public static Builder CreateBuilder()
                {
                    return new Builder();
                }

                public static Builder CreateBuilder(DebugPaneDelItems.Types.DebugPaneDelItem prototype)
                {
                    return new Builder(prototype);
                }

                public override Builder CreateBuilderForType()
                {
                    return new Builder();
                }

                public override bool Equals(object obj)
                {
                    DebugPaneDelItems.Types.DebugPaneDelItem item = obj as DebugPaneDelItems.Types.DebugPaneDelItem;
                    if (item == null)
                    {
                        return false;
                    }
                    return ((this.hasName == item.hasName) && (!this.hasName || this.name_.Equals(item.name_)));
                }

                public override int GetHashCode()
                {
                    int hashCode = base.GetType().GetHashCode();
                    if (this.hasName)
                    {
                        hashCode ^= this.name_.GetHashCode();
                    }
                    return hashCode;
                }

                private DebugPaneDelItems.Types.DebugPaneDelItem MakeReadOnly()
                {
                    return this;
                }

                public static DebugPaneDelItems.Types.DebugPaneDelItem ParseDelimitedFrom(Stream input)
                {
                    return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
                }

                public static DebugPaneDelItems.Types.DebugPaneDelItem ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
                {
                    return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
                }

                public static DebugPaneDelItems.Types.DebugPaneDelItem ParseFrom(byte[] data)
                {
                    return CreateBuilder().MergeFrom(data).BuildParsed();
                }

                public static DebugPaneDelItems.Types.DebugPaneDelItem ParseFrom(ByteString data)
                {
                    return CreateBuilder().MergeFrom(data).BuildParsed();
                }

                public static DebugPaneDelItems.Types.DebugPaneDelItem ParseFrom(ICodedInputStream input)
                {
                    return CreateBuilder().MergeFrom(input).BuildParsed();
                }

                public static DebugPaneDelItems.Types.DebugPaneDelItem ParseFrom(Stream input)
                {
                    return CreateBuilder().MergeFrom(input).BuildParsed();
                }

                public static DebugPaneDelItems.Types.DebugPaneDelItem ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
                {
                    return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
                }

                public static DebugPaneDelItems.Types.DebugPaneDelItem ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
                {
                    return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
                }

                public static DebugPaneDelItems.Types.DebugPaneDelItem ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
                {
                    return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
                }

                public static DebugPaneDelItems.Types.DebugPaneDelItem ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
                {
                    return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
                }

                public override void PrintTo(TextWriter writer)
                {
                    GeneratedMessageLite<DebugPaneDelItems.Types.DebugPaneDelItem, Builder>.PrintField("name", this.hasName, this.name_, writer);
                }

                public override Builder ToBuilder()
                {
                    return CreateBuilder(this);
                }

                public override void WriteTo(ICodedOutputStream output)
                {
                    int serializedSize = this.SerializedSize;
                    string[] strArray = _debugPaneDelItemFieldNames;
                    if (this.hasName)
                    {
                        output.WriteString(1, strArray[0], this.Name);
                    }
                }

                public static DebugPaneDelItems.Types.DebugPaneDelItem DefaultInstance
                {
                    get
                    {
                        return defaultInstance;
                    }
                }

                public override DebugPaneDelItems.Types.DebugPaneDelItem DefaultInstanceForType
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

                public override bool IsInitialized
                {
                    get
                    {
                        if (!this.hasName)
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
                            this.memoizedSerializedSize = memoizedSerializedSize;
                        }
                        return memoizedSerializedSize;
                    }
                }

                protected override DebugPaneDelItems.Types.DebugPaneDelItem ThisMessage
                {
                    get
                    {
                        return this;
                    }
                }

                [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
                public sealed class Builder : GeneratedBuilderLite<DebugPaneDelItems.Types.DebugPaneDelItem, DebugPaneDelItems.Types.DebugPaneDelItem.Builder>
                {
                    private DebugPaneDelItems.Types.DebugPaneDelItem result;
                    private bool resultIsReadOnly;

                    public Builder()
                    {
                        this.result = DebugPaneDelItems.Types.DebugPaneDelItem.DefaultInstance;
                        this.resultIsReadOnly = true;
                    }

                    internal Builder(DebugPaneDelItems.Types.DebugPaneDelItem cloneFrom)
                    {
                        this.result = cloneFrom;
                        this.resultIsReadOnly = true;
                    }

                    public override DebugPaneDelItems.Types.DebugPaneDelItem BuildPartial()
                    {
                        if (this.resultIsReadOnly)
                        {
                            return this.result;
                        }
                        this.resultIsReadOnly = true;
                        return this.result.MakeReadOnly();
                    }

                    public override DebugPaneDelItems.Types.DebugPaneDelItem.Builder Clear()
                    {
                        this.result = DebugPaneDelItems.Types.DebugPaneDelItem.DefaultInstance;
                        this.resultIsReadOnly = true;
                        return this;
                    }

                    public DebugPaneDelItems.Types.DebugPaneDelItem.Builder ClearName()
                    {
                        this.PrepareBuilder();
                        this.result.hasName = false;
                        this.result.name_ = string.Empty;
                        return this;
                    }

                    public override DebugPaneDelItems.Types.DebugPaneDelItem.Builder Clone()
                    {
                        if (this.resultIsReadOnly)
                        {
                            return new DebugPaneDelItems.Types.DebugPaneDelItem.Builder(this.result);
                        }
                        return new DebugPaneDelItems.Types.DebugPaneDelItem.Builder().MergeFrom(this.result);
                    }

                    public override DebugPaneDelItems.Types.DebugPaneDelItem.Builder MergeFrom(DebugPaneDelItems.Types.DebugPaneDelItem other)
                    {
                        if (other != DebugPaneDelItems.Types.DebugPaneDelItem.DefaultInstance)
                        {
                            this.PrepareBuilder();
                            if (other.HasName)
                            {
                                this.Name = other.Name;
                            }
                        }
                        return this;
                    }

                    public override DebugPaneDelItems.Types.DebugPaneDelItem.Builder MergeFrom(ICodedInputStream input)
                    {
                        return this.MergeFrom(input, ExtensionRegistry.Empty);
                    }

                    public override DebugPaneDelItems.Types.DebugPaneDelItem.Builder MergeFrom(IMessageLite other)
                    {
                        if (other is DebugPaneDelItems.Types.DebugPaneDelItem)
                        {
                            return this.MergeFrom((DebugPaneDelItems.Types.DebugPaneDelItem) other);
                        }
                        base.MergeFrom(other);
                        return this;
                    }

                    public override DebugPaneDelItems.Types.DebugPaneDelItem.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
                    {
                        uint num;
                        string str;
                        this.PrepareBuilder();
                        while (input.ReadTag(out num, out str))
                        {
                            if ((num == 0) && (str != null))
                            {
                                int index = Array.BinarySearch<string>(DebugPaneDelItems.Types.DebugPaneDelItem._debugPaneDelItemFieldNames, str, StringComparer.Ordinal);
                                if (index >= 0)
                                {
                                    num = DebugPaneDelItems.Types.DebugPaneDelItem._debugPaneDelItemFieldTags[index];
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
                            this.result.hasName = input.ReadString(ref this.result.name_);
                        }
                        return this;
                    }

                    private DebugPaneDelItems.Types.DebugPaneDelItem PrepareBuilder()
                    {
                        if (this.resultIsReadOnly)
                        {
                            DebugPaneDelItems.Types.DebugPaneDelItem result = this.result;
                            this.result = new DebugPaneDelItems.Types.DebugPaneDelItem();
                            this.resultIsReadOnly = false;
                            this.MergeFrom(result);
                        }
                        return this.result;
                    }

                    public DebugPaneDelItems.Types.DebugPaneDelItem.Builder SetName(string value)
                    {
                        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                        this.PrepareBuilder();
                        this.result.hasName = true;
                        this.result.name_ = value;
                        return this;
                    }

                    public override DebugPaneDelItems.Types.DebugPaneDelItem DefaultInstanceForType
                    {
                        get
                        {
                            return DebugPaneDelItems.Types.DebugPaneDelItem.DefaultInstance;
                        }
                    }

                    public bool HasName
                    {
                        get
                        {
                            return this.result.hasName;
                        }
                    }

                    public override bool IsInitialized
                    {
                        get
                        {
                            return this.result.IsInitialized;
                        }
                    }

                    protected override DebugPaneDelItems.Types.DebugPaneDelItem MessageBeingBuilt
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

                    protected override DebugPaneDelItems.Types.DebugPaneDelItem.Builder ThisBuilder
                    {
                        get
                        {
                            return this;
                        }
                    }
                }
            }

            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0x8f
            }
        }
    }
}

