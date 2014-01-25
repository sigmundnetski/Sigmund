namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class DraftMakePick : GeneratedMessageLite<DraftMakePick, Builder>
    {
        private static readonly string[] _draftMakePickFieldNames = new string[] { "deck_id", "index", "slot" };
        private static readonly uint[] _draftMakePickFieldTags = new uint[] { 8, 0x18, 0x10 };
        private long deckId_;
        public const int DeckIdFieldNumber = 1;
        private static readonly DraftMakePick defaultInstance = new DraftMakePick().MakeReadOnly();
        private bool hasDeckId;
        private bool hasIndex;
        private bool hasSlot;
        private int index_;
        public const int IndexFieldNumber = 3;
        private int memoizedSerializedSize = -1;
        private int slot_;
        public const int SlotFieldNumber = 2;

        static DraftMakePick()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private DraftMakePick()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DraftMakePick prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DraftMakePick pick = obj as DraftMakePick;
            if (pick == null)
            {
                return false;
            }
            if ((this.hasDeckId != pick.hasDeckId) || (this.hasDeckId && !this.deckId_.Equals(pick.deckId_)))
            {
                return false;
            }
            if ((this.hasSlot != pick.hasSlot) || (this.hasSlot && !this.slot_.Equals(pick.slot_)))
            {
                return false;
            }
            return ((this.hasIndex == pick.hasIndex) && (!this.hasIndex || this.index_.Equals(pick.index_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasDeckId)
            {
                hashCode ^= this.deckId_.GetHashCode();
            }
            if (this.hasSlot)
            {
                hashCode ^= this.slot_.GetHashCode();
            }
            if (this.hasIndex)
            {
                hashCode ^= this.index_.GetHashCode();
            }
            return hashCode;
        }

        private DraftMakePick MakeReadOnly()
        {
            return this;
        }

        public static DraftMakePick ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DraftMakePick ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DraftMakePick ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DraftMakePick ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DraftMakePick ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DraftMakePick ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DraftMakePick ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DraftMakePick ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DraftMakePick ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DraftMakePick ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DraftMakePick, Builder>.PrintField("deck_id", this.hasDeckId, this.deckId_, writer);
            GeneratedMessageLite<DraftMakePick, Builder>.PrintField("slot", this.hasSlot, this.slot_, writer);
            GeneratedMessageLite<DraftMakePick, Builder>.PrintField("index", this.hasIndex, this.index_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _draftMakePickFieldNames;
            if (this.hasDeckId)
            {
                output.WriteInt64(1, strArray[0], this.DeckId);
            }
            if (this.hasSlot)
            {
                output.WriteInt32(2, strArray[2], this.Slot);
            }
            if (this.hasIndex)
            {
                output.WriteInt32(3, strArray[1], this.Index);
            }
        }

        public long DeckId
        {
            get
            {
                return this.deckId_;
            }
        }

        public static DraftMakePick DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DraftMakePick DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasDeckId
        {
            get
            {
                return this.hasDeckId;
            }
        }

        public bool HasIndex
        {
            get
            {
                return this.hasIndex;
            }
        }

        public bool HasSlot
        {
            get
            {
                return this.hasSlot;
            }
        }

        public int Index
        {
            get
            {
                return this.index_;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasDeckId)
                {
                    return false;
                }
                if (!this.hasSlot)
                {
                    return false;
                }
                if (!this.hasIndex)
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
                    if (this.hasDeckId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(1, this.DeckId);
                    }
                    if (this.hasSlot)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.Slot);
                    }
                    if (this.hasIndex)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(3, this.Index);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        public int Slot
        {
            get
            {
                return this.slot_;
            }
        }

        protected override DraftMakePick ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<DraftMakePick, DraftMakePick.Builder>
        {
            private DraftMakePick result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DraftMakePick.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DraftMakePick cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override DraftMakePick BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DraftMakePick.Builder Clear()
            {
                this.result = DraftMakePick.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DraftMakePick.Builder ClearDeckId()
            {
                this.PrepareBuilder();
                this.result.hasDeckId = false;
                this.result.deckId_ = 0L;
                return this;
            }

            public DraftMakePick.Builder ClearIndex()
            {
                this.PrepareBuilder();
                this.result.hasIndex = false;
                this.result.index_ = 0;
                return this;
            }

            public DraftMakePick.Builder ClearSlot()
            {
                this.PrepareBuilder();
                this.result.hasSlot = false;
                this.result.slot_ = 0;
                return this;
            }

            public override DraftMakePick.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DraftMakePick.Builder(this.result);
                }
                return new DraftMakePick.Builder().MergeFrom(this.result);
            }

            public override DraftMakePick.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DraftMakePick.Builder MergeFrom(IMessageLite other)
            {
                if (other is DraftMakePick)
                {
                    return this.MergeFrom((DraftMakePick) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DraftMakePick.Builder MergeFrom(DraftMakePick other)
            {
                if (other != DraftMakePick.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasDeckId)
                    {
                        this.DeckId = other.DeckId;
                    }
                    if (other.HasSlot)
                    {
                        this.Slot = other.Slot;
                    }
                    if (other.HasIndex)
                    {
                        this.Index = other.Index;
                    }
                }
                return this;
            }

            public override DraftMakePick.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DraftMakePick._draftMakePickFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DraftMakePick._draftMakePickFieldTags[index];
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
                            this.result.hasDeckId = input.ReadInt64(ref this.result.deckId_);
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasSlot = input.ReadInt32(ref this.result.slot_);
                            continue;
                        }
                        case 0x18:
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
                    this.result.hasIndex = input.ReadInt32(ref this.result.index_);
                }
                return this;
            }

            private DraftMakePick PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DraftMakePick result = this.result;
                    this.result = new DraftMakePick();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DraftMakePick.Builder SetDeckId(long value)
            {
                this.PrepareBuilder();
                this.result.hasDeckId = true;
                this.result.deckId_ = value;
                return this;
            }

            public DraftMakePick.Builder SetIndex(int value)
            {
                this.PrepareBuilder();
                this.result.hasIndex = true;
                this.result.index_ = value;
                return this;
            }

            public DraftMakePick.Builder SetSlot(int value)
            {
                this.PrepareBuilder();
                this.result.hasSlot = true;
                this.result.slot_ = value;
                return this;
            }

            public long DeckId
            {
                get
                {
                    return this.result.DeckId;
                }
                set
                {
                    this.SetDeckId(value);
                }
            }

            public override DraftMakePick DefaultInstanceForType
            {
                get
                {
                    return DraftMakePick.DefaultInstance;
                }
            }

            public bool HasDeckId
            {
                get
                {
                    return this.result.hasDeckId;
                }
            }

            public bool HasIndex
            {
                get
                {
                    return this.result.hasIndex;
                }
            }

            public bool HasSlot
            {
                get
                {
                    return this.result.hasSlot;
                }
            }

            public int Index
            {
                get
                {
                    return this.result.Index;
                }
                set
                {
                    this.SetIndex(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override DraftMakePick MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int Slot
            {
                get
                {
                    return this.result.Slot;
                }
                set
                {
                    this.SetSlot(value);
                }
            }

            protected override DraftMakePick.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0xf5,
                System = 0
            }
        }
    }
}

