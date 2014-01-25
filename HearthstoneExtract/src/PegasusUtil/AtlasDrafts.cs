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
    public sealed class AtlasDrafts : GeneratedMessageLite<AtlasDrafts, Builder>
    {
        private static readonly string[] _atlasDraftsFieldNames = new string[] { "deck_id", "losses", "slot", "tickets", "wins" };
        private static readonly uint[] _atlasDraftsFieldTags = new uint[] { 0x10, 40, 0x18, 10, 0x20 };
        private ulong deckId_;
        public const int DeckIdFieldNumber = 2;
        private static readonly AtlasDrafts defaultInstance = new AtlasDrafts().MakeReadOnly();
        private bool hasDeckId;
        private bool hasLosses;
        private bool hasSlot;
        private bool hasWins;
        private int losses_;
        public const int LossesFieldNumber = 5;
        private int memoizedSerializedSize = -1;
        private int slot_;
        public const int SlotFieldNumber = 3;
        private PopsicleList<AtlasDraft> tickets_ = new PopsicleList<AtlasDraft>();
        public const int TicketsFieldNumber = 1;
        private int wins_;
        public const int WinsFieldNumber = 4;

        static AtlasDrafts()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AtlasDrafts()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AtlasDrafts prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AtlasDrafts drafts = obj as AtlasDrafts;
            if (drafts == null)
            {
                return false;
            }
            if (this.tickets_.Count != drafts.tickets_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.tickets_.Count; i++)
            {
                if (!this.tickets_[i].Equals(drafts.tickets_[i]))
                {
                    return false;
                }
            }
            if ((this.hasDeckId != drafts.hasDeckId) || (this.hasDeckId && !this.deckId_.Equals(drafts.deckId_)))
            {
                return false;
            }
            if ((this.hasSlot != drafts.hasSlot) || (this.hasSlot && !this.slot_.Equals(drafts.slot_)))
            {
                return false;
            }
            if ((this.hasWins != drafts.hasWins) || (this.hasWins && !this.wins_.Equals(drafts.wins_)))
            {
                return false;
            }
            return ((this.hasLosses == drafts.hasLosses) && (!this.hasLosses || this.losses_.Equals(drafts.losses_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<AtlasDraft> enumerator = this.tickets_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    AtlasDraft current = enumerator.Current;
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
            if (this.hasDeckId)
            {
                hashCode ^= this.deckId_.GetHashCode();
            }
            if (this.hasSlot)
            {
                hashCode ^= this.slot_.GetHashCode();
            }
            if (this.hasWins)
            {
                hashCode ^= this.wins_.GetHashCode();
            }
            if (this.hasLosses)
            {
                hashCode ^= this.losses_.GetHashCode();
            }
            return hashCode;
        }

        public AtlasDraft GetTickets(int index)
        {
            return this.tickets_[index];
        }

        private AtlasDrafts MakeReadOnly()
        {
            this.tickets_.MakeReadOnly();
            return this;
        }

        public static AtlasDrafts ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AtlasDrafts ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasDrafts ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasDrafts ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasDrafts ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasDrafts ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasDrafts ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AtlasDrafts ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasDrafts ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasDrafts ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AtlasDrafts, Builder>.PrintField<AtlasDraft>("tickets", this.tickets_, writer);
            GeneratedMessageLite<AtlasDrafts, Builder>.PrintField("deck_id", this.hasDeckId, this.deckId_, writer);
            GeneratedMessageLite<AtlasDrafts, Builder>.PrintField("slot", this.hasSlot, this.slot_, writer);
            GeneratedMessageLite<AtlasDrafts, Builder>.PrintField("wins", this.hasWins, this.wins_, writer);
            GeneratedMessageLite<AtlasDrafts, Builder>.PrintField("losses", this.hasLosses, this.losses_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _atlasDraftsFieldNames;
            if (this.tickets_.Count > 0)
            {
                output.WriteMessageArray<AtlasDraft>(1, strArray[3], this.tickets_);
            }
            if (this.hasDeckId)
            {
                output.WriteUInt64(2, strArray[0], this.DeckId);
            }
            if (this.hasSlot)
            {
                output.WriteInt32(3, strArray[2], this.Slot);
            }
            if (this.hasWins)
            {
                output.WriteInt32(4, strArray[4], this.Wins);
            }
            if (this.hasLosses)
            {
                output.WriteInt32(5, strArray[1], this.Losses);
            }
        }

        [CLSCompliant(false)]
        public ulong DeckId
        {
            get
            {
                return this.deckId_;
            }
        }

        public static AtlasDrafts DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AtlasDrafts DefaultInstanceForType
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

        public bool HasLosses
        {
            get
            {
                return this.hasLosses;
            }
        }

        public bool HasSlot
        {
            get
            {
                return this.hasSlot;
            }
        }

        public bool HasWins
        {
            get
            {
                return this.hasWins;
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
                if (!this.hasWins)
                {
                    return false;
                }
                if (!this.hasLosses)
                {
                    return false;
                }
                IEnumerator<AtlasDraft> enumerator = this.TicketsList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        AtlasDraft current = enumerator.Current;
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

        public int Losses
        {
            get
            {
                return this.losses_;
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
                    IEnumerator<AtlasDraft> enumerator = this.TicketsList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            AtlasDraft current = enumerator.Current;
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
                    if (this.hasDeckId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(2, this.DeckId);
                    }
                    if (this.hasSlot)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(3, this.Slot);
                    }
                    if (this.hasWins)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(4, this.Wins);
                    }
                    if (this.hasLosses)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(5, this.Losses);
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

        protected override AtlasDrafts ThisMessage
        {
            get
            {
                return this;
            }
        }

        public int TicketsCount
        {
            get
            {
                return this.tickets_.Count;
            }
        }

        public IList<AtlasDraft> TicketsList
        {
            get
            {
                return this.tickets_;
            }
        }

        public int Wins
        {
            get
            {
                return this.wins_;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<AtlasDrafts, AtlasDrafts.Builder>
        {
            private AtlasDrafts result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AtlasDrafts.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AtlasDrafts cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public AtlasDrafts.Builder AddRangeTickets(IEnumerable<AtlasDraft> values)
            {
                this.PrepareBuilder();
                this.result.tickets_.Add(values);
                return this;
            }

            public AtlasDrafts.Builder AddTickets(AtlasDraft value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.tickets_.Add(value);
                return this;
            }

            public AtlasDrafts.Builder AddTickets(AtlasDraft.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.tickets_.Add(builderForValue.Build());
                return this;
            }

            public override AtlasDrafts BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AtlasDrafts.Builder Clear()
            {
                this.result = AtlasDrafts.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AtlasDrafts.Builder ClearDeckId()
            {
                this.PrepareBuilder();
                this.result.hasDeckId = false;
                this.result.deckId_ = 0L;
                return this;
            }

            public AtlasDrafts.Builder ClearLosses()
            {
                this.PrepareBuilder();
                this.result.hasLosses = false;
                this.result.losses_ = 0;
                return this;
            }

            public AtlasDrafts.Builder ClearSlot()
            {
                this.PrepareBuilder();
                this.result.hasSlot = false;
                this.result.slot_ = 0;
                return this;
            }

            public AtlasDrafts.Builder ClearTickets()
            {
                this.PrepareBuilder();
                this.result.tickets_.Clear();
                return this;
            }

            public AtlasDrafts.Builder ClearWins()
            {
                this.PrepareBuilder();
                this.result.hasWins = false;
                this.result.wins_ = 0;
                return this;
            }

            public override AtlasDrafts.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AtlasDrafts.Builder(this.result);
                }
                return new AtlasDrafts.Builder().MergeFrom(this.result);
            }

            public AtlasDraft GetTickets(int index)
            {
                return this.result.GetTickets(index);
            }

            public override AtlasDrafts.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AtlasDrafts.Builder MergeFrom(IMessageLite other)
            {
                if (other is AtlasDrafts)
                {
                    return this.MergeFrom((AtlasDrafts) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AtlasDrafts.Builder MergeFrom(AtlasDrafts other)
            {
                if (other != AtlasDrafts.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.tickets_.Count != 0)
                    {
                        this.result.tickets_.Add(other.tickets_);
                    }
                    if (other.HasDeckId)
                    {
                        this.DeckId = other.DeckId;
                    }
                    if (other.HasSlot)
                    {
                        this.Slot = other.Slot;
                    }
                    if (other.HasWins)
                    {
                        this.Wins = other.Wins;
                    }
                    if (other.HasLosses)
                    {
                        this.Losses = other.Losses;
                    }
                }
                return this;
            }

            public override AtlasDrafts.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AtlasDrafts._atlasDraftsFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AtlasDrafts._atlasDraftsFieldTags[index];
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
                            input.ReadMessageArray<AtlasDraft>(num, str, this.result.tickets_, AtlasDraft.DefaultInstance, extensionRegistry);
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasDeckId = input.ReadUInt64(ref this.result.deckId_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasSlot = input.ReadInt32(ref this.result.slot_);
                            continue;
                        }
                        case 0x20:
                        {
                            this.result.hasWins = input.ReadInt32(ref this.result.wins_);
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
                    this.result.hasLosses = input.ReadInt32(ref this.result.losses_);
                }
                return this;
            }

            private AtlasDrafts PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AtlasDrafts result = this.result;
                    this.result = new AtlasDrafts();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public AtlasDrafts.Builder SetDeckId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasDeckId = true;
                this.result.deckId_ = value;
                return this;
            }

            public AtlasDrafts.Builder SetLosses(int value)
            {
                this.PrepareBuilder();
                this.result.hasLosses = true;
                this.result.losses_ = value;
                return this;
            }

            public AtlasDrafts.Builder SetSlot(int value)
            {
                this.PrepareBuilder();
                this.result.hasSlot = true;
                this.result.slot_ = value;
                return this;
            }

            public AtlasDrafts.Builder SetTickets(int index, AtlasDraft value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.tickets_[index] = value;
                return this;
            }

            public AtlasDrafts.Builder SetTickets(int index, AtlasDraft.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.tickets_[index] = builderForValue.Build();
                return this;
            }

            public AtlasDrafts.Builder SetWins(int value)
            {
                this.PrepareBuilder();
                this.result.hasWins = true;
                this.result.wins_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public ulong DeckId
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

            public override AtlasDrafts DefaultInstanceForType
            {
                get
                {
                    return AtlasDrafts.DefaultInstance;
                }
            }

            public bool HasDeckId
            {
                get
                {
                    return this.result.hasDeckId;
                }
            }

            public bool HasLosses
            {
                get
                {
                    return this.result.hasLosses;
                }
            }

            public bool HasSlot
            {
                get
                {
                    return this.result.hasSlot;
                }
            }

            public bool HasWins
            {
                get
                {
                    return this.result.hasWins;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public int Losses
            {
                get
                {
                    return this.result.Losses;
                }
                set
                {
                    this.SetLosses(value);
                }
            }

            protected override AtlasDrafts MessageBeingBuilt
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

            protected override AtlasDrafts.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public int TicketsCount
            {
                get
                {
                    return this.result.TicketsCount;
                }
            }

            public IPopsicleList<AtlasDraft> TicketsList
            {
                get
                {
                    return this.PrepareBuilder().tickets_;
                }
            }

            public int Wins
            {
                get
                {
                    return this.result.Wins;
                }
                set
                {
                    this.SetWins(value);
                }
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 110
            }
        }
    }
}

