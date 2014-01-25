namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class DraftRetire : GeneratedMessageLite<DraftRetire, Builder>
    {
        private static readonly string[] _draftRetireFieldNames = new string[] { "deck_id", "slot" };
        private static readonly uint[] _draftRetireFieldTags = new uint[] { 8, 0x10 };
        private long deckId_;
        public const int DeckIdFieldNumber = 1;
        private static readonly DraftRetire defaultInstance = new DraftRetire().MakeReadOnly();
        private bool hasDeckId;
        private bool hasSlot;
        private int memoizedSerializedSize = -1;
        private int slot_;
        public const int SlotFieldNumber = 2;

        static DraftRetire()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private DraftRetire()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DraftRetire prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DraftRetire retire = obj as DraftRetire;
            if (retire == null)
            {
                return false;
            }
            if ((this.hasDeckId != retire.hasDeckId) || (this.hasDeckId && !this.deckId_.Equals(retire.deckId_)))
            {
                return false;
            }
            return ((this.hasSlot == retire.hasSlot) && (!this.hasSlot || this.slot_.Equals(retire.slot_)));
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
            return hashCode;
        }

        private DraftRetire MakeReadOnly()
        {
            return this;
        }

        public static DraftRetire ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DraftRetire ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DraftRetire ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DraftRetire ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DraftRetire ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DraftRetire ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DraftRetire ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DraftRetire ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DraftRetire ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DraftRetire ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DraftRetire, Builder>.PrintField("deck_id", this.hasDeckId, this.deckId_, writer);
            GeneratedMessageLite<DraftRetire, Builder>.PrintField("slot", this.hasSlot, this.slot_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _draftRetireFieldNames;
            if (this.hasDeckId)
            {
                output.WriteInt64(1, strArray[0], this.DeckId);
            }
            if (this.hasSlot)
            {
                output.WriteInt32(2, strArray[1], this.Slot);
            }
        }

        public long DeckId
        {
            get
            {
                return this.deckId_;
            }
        }

        public static DraftRetire DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DraftRetire DefaultInstanceForType
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

        public bool HasSlot
        {
            get
            {
                return this.hasSlot;
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

        protected override DraftRetire ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<DraftRetire, DraftRetire.Builder>
        {
            private DraftRetire result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DraftRetire.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DraftRetire cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override DraftRetire BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DraftRetire.Builder Clear()
            {
                this.result = DraftRetire.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DraftRetire.Builder ClearDeckId()
            {
                this.PrepareBuilder();
                this.result.hasDeckId = false;
                this.result.deckId_ = 0L;
                return this;
            }

            public DraftRetire.Builder ClearSlot()
            {
                this.PrepareBuilder();
                this.result.hasSlot = false;
                this.result.slot_ = 0;
                return this;
            }

            public override DraftRetire.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DraftRetire.Builder(this.result);
                }
                return new DraftRetire.Builder().MergeFrom(this.result);
            }

            public override DraftRetire.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DraftRetire.Builder MergeFrom(IMessageLite other)
            {
                if (other is DraftRetire)
                {
                    return this.MergeFrom((DraftRetire) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DraftRetire.Builder MergeFrom(DraftRetire other)
            {
                if (other != DraftRetire.DefaultInstance)
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
                }
                return this;
            }

            public override DraftRetire.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DraftRetire._draftRetireFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DraftRetire._draftRetireFieldTags[index];
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
                    this.result.hasSlot = input.ReadInt32(ref this.result.slot_);
                }
                return this;
            }

            private DraftRetire PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DraftRetire result = this.result;
                    this.result = new DraftRetire();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DraftRetire.Builder SetDeckId(long value)
            {
                this.PrepareBuilder();
                this.result.hasDeckId = true;
                this.result.deckId_ = value;
                return this;
            }

            public DraftRetire.Builder SetSlot(int value)
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

            public override DraftRetire DefaultInstanceForType
            {
                get
                {
                    return DraftRetire.DefaultInstance;
                }
            }

            public bool HasDeckId
            {
                get
                {
                    return this.result.hasDeckId;
                }
            }

            public bool HasSlot
            {
                get
                {
                    return this.result.hasSlot;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override DraftRetire MessageBeingBuilt
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

            protected override DraftRetire.Builder ThisBuilder
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
                ID = 0xf2,
                System = 0
            }
        }
    }
}

