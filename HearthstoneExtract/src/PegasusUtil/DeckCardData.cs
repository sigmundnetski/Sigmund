namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using PegasusShared;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class DeckCardData : GeneratedMessageLite<DeckCardData, Builder>
    {
        private static readonly string[] _deckCardDataFieldNames = new string[] { "def", "handle", "prev", "qty" };
        private static readonly uint[] _deckCardDataFieldTags = new uint[] { 10, 0x10, 40, 0x18 };
        private CardDef def_;
        private static readonly DeckCardData defaultInstance = new DeckCardData().MakeReadOnly();
        public const int DefFieldNumber = 1;
        private int handle_;
        public const int HandleFieldNumber = 2;
        private bool hasDef;
        private bool hasHandle;
        private bool hasPrev;
        private bool hasQty;
        private int memoizedSerializedSize = -1;
        private int prev_;
        public const int PrevFieldNumber = 5;
        private int qty_;
        public const int QtyFieldNumber = 3;

        static DeckCardData()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private DeckCardData()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DeckCardData prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DeckCardData data = obj as DeckCardData;
            if (data == null)
            {
                return false;
            }
            if ((this.hasDef != data.hasDef) || (this.hasDef && !this.def_.Equals(data.def_)))
            {
                return false;
            }
            if ((this.hasHandle != data.hasHandle) || (this.hasHandle && !this.handle_.Equals(data.handle_)))
            {
                return false;
            }
            if ((this.hasQty != data.hasQty) || (this.hasQty && !this.qty_.Equals(data.qty_)))
            {
                return false;
            }
            return ((this.hasPrev == data.hasPrev) && (!this.hasPrev || this.prev_.Equals(data.prev_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasDef)
            {
                hashCode ^= this.def_.GetHashCode();
            }
            if (this.hasHandle)
            {
                hashCode ^= this.handle_.GetHashCode();
            }
            if (this.hasQty)
            {
                hashCode ^= this.qty_.GetHashCode();
            }
            if (this.hasPrev)
            {
                hashCode ^= this.prev_.GetHashCode();
            }
            return hashCode;
        }

        private DeckCardData MakeReadOnly()
        {
            return this;
        }

        public static DeckCardData ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DeckCardData ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DeckCardData ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DeckCardData ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DeckCardData ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DeckCardData ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DeckCardData ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DeckCardData ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DeckCardData ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DeckCardData ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DeckCardData, Builder>.PrintField("def", this.hasDef, this.def_, writer);
            GeneratedMessageLite<DeckCardData, Builder>.PrintField("handle", this.hasHandle, this.handle_, writer);
            GeneratedMessageLite<DeckCardData, Builder>.PrintField("qty", this.hasQty, this.qty_, writer);
            GeneratedMessageLite<DeckCardData, Builder>.PrintField("prev", this.hasPrev, this.prev_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _deckCardDataFieldNames;
            if (this.hasDef)
            {
                output.WriteMessage(1, strArray[0], this.Def);
            }
            if (this.hasHandle)
            {
                output.WriteInt32(2, strArray[1], this.Handle);
            }
            if (this.hasQty)
            {
                output.WriteInt32(3, strArray[3], this.Qty);
            }
            if (this.hasPrev)
            {
                output.WriteInt32(5, strArray[2], this.Prev);
            }
        }

        public CardDef Def
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.def_ != null)
                {
                    goto Label_0012;
                }
                return CardDef.DefaultInstance;
            }
        }

        public static DeckCardData DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DeckCardData DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public int Handle
        {
            get
            {
                return this.handle_;
            }
        }

        public bool HasDef
        {
            get
            {
                return this.hasDef;
            }
        }

        public bool HasHandle
        {
            get
            {
                return this.hasHandle;
            }
        }

        public bool HasPrev
        {
            get
            {
                return this.hasPrev;
            }
        }

        public bool HasQty
        {
            get
            {
                return this.hasQty;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasDef)
                {
                    return false;
                }
                if (!this.hasHandle)
                {
                    return false;
                }
                if (!this.hasPrev)
                {
                    return false;
                }
                if (!this.Def.IsInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        public int Prev
        {
            get
            {
                return this.prev_;
            }
        }

        public int Qty
        {
            get
            {
                return this.qty_;
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
                    if (this.hasDef)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.Def);
                    }
                    if (this.hasHandle)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.Handle);
                    }
                    if (this.hasQty)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(3, this.Qty);
                    }
                    if (this.hasPrev)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(5, this.Prev);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override DeckCardData ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<DeckCardData, DeckCardData.Builder>
        {
            private DeckCardData result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DeckCardData.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DeckCardData cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override DeckCardData BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DeckCardData.Builder Clear()
            {
                this.result = DeckCardData.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DeckCardData.Builder ClearDef()
            {
                this.PrepareBuilder();
                this.result.hasDef = false;
                this.result.def_ = null;
                return this;
            }

            public DeckCardData.Builder ClearHandle()
            {
                this.PrepareBuilder();
                this.result.hasHandle = false;
                this.result.handle_ = 0;
                return this;
            }

            public DeckCardData.Builder ClearPrev()
            {
                this.PrepareBuilder();
                this.result.hasPrev = false;
                this.result.prev_ = 0;
                return this;
            }

            public DeckCardData.Builder ClearQty()
            {
                this.PrepareBuilder();
                this.result.hasQty = false;
                this.result.qty_ = 0;
                return this;
            }

            public override DeckCardData.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DeckCardData.Builder(this.result);
                }
                return new DeckCardData.Builder().MergeFrom(this.result);
            }

            public DeckCardData.Builder MergeDef(CardDef value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasDef && (this.result.def_ != CardDef.DefaultInstance))
                {
                    this.result.def_ = CardDef.CreateBuilder(this.result.def_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.def_ = value;
                }
                this.result.hasDef = true;
                return this;
            }

            public override DeckCardData.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DeckCardData.Builder MergeFrom(IMessageLite other)
            {
                if (other is DeckCardData)
                {
                    return this.MergeFrom((DeckCardData) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DeckCardData.Builder MergeFrom(DeckCardData other)
            {
                if (other != DeckCardData.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasDef)
                    {
                        this.MergeDef(other.Def);
                    }
                    if (other.HasHandle)
                    {
                        this.Handle = other.Handle;
                    }
                    if (other.HasQty)
                    {
                        this.Qty = other.Qty;
                    }
                    if (other.HasPrev)
                    {
                        this.Prev = other.Prev;
                    }
                }
                return this;
            }

            public override DeckCardData.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DeckCardData._deckCardDataFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DeckCardData._deckCardDataFieldTags[index];
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
                            CardDef.Builder builder = CardDef.CreateBuilder();
                            if (this.result.hasDef)
                            {
                                builder.MergeFrom(this.Def);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.Def = builder.BuildPartial();
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasHandle = input.ReadInt32(ref this.result.handle_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasQty = input.ReadInt32(ref this.result.qty_);
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
                    this.result.hasPrev = input.ReadInt32(ref this.result.prev_);
                }
                return this;
            }

            private DeckCardData PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DeckCardData result = this.result;
                    this.result = new DeckCardData();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DeckCardData.Builder SetDef(CardDef value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasDef = true;
                this.result.def_ = value;
                return this;
            }

            public DeckCardData.Builder SetDef(CardDef.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasDef = true;
                this.result.def_ = builderForValue.Build();
                return this;
            }

            public DeckCardData.Builder SetHandle(int value)
            {
                this.PrepareBuilder();
                this.result.hasHandle = true;
                this.result.handle_ = value;
                return this;
            }

            public DeckCardData.Builder SetPrev(int value)
            {
                this.PrepareBuilder();
                this.result.hasPrev = true;
                this.result.prev_ = value;
                return this;
            }

            public DeckCardData.Builder SetQty(int value)
            {
                this.PrepareBuilder();
                this.result.hasQty = true;
                this.result.qty_ = value;
                return this;
            }

            public CardDef Def
            {
                get
                {
                    return this.result.Def;
                }
                set
                {
                    this.SetDef(value);
                }
            }

            public override DeckCardData DefaultInstanceForType
            {
                get
                {
                    return DeckCardData.DefaultInstance;
                }
            }

            public int Handle
            {
                get
                {
                    return this.result.Handle;
                }
                set
                {
                    this.SetHandle(value);
                }
            }

            public bool HasDef
            {
                get
                {
                    return this.result.hasDef;
                }
            }

            public bool HasHandle
            {
                get
                {
                    return this.result.hasHandle;
                }
            }

            public bool HasPrev
            {
                get
                {
                    return this.result.hasPrev;
                }
            }

            public bool HasQty
            {
                get
                {
                    return this.result.hasQty;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override DeckCardData MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int Prev
            {
                get
                {
                    return this.result.Prev;
                }
                set
                {
                    this.SetPrev(value);
                }
            }

            public int Qty
            {
                get
                {
                    return this.result.Qty;
                }
                set
                {
                    this.SetQty(value);
                }
            }

            protected override DeckCardData.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

