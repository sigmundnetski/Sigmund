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

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class DraftBeginning : GeneratedMessageLite<DraftBeginning, Builder>
    {
        private static readonly string[] _draftBeginningFieldNames = new string[] { "choices", "deck_id" };
        private static readonly uint[] _draftBeginningFieldTags = new uint[] { 0x12, 8 };
        private PopsicleList<int> choices_ = new PopsicleList<int>();
        public const int ChoicesFieldNumber = 2;
        private int choicesMemoizedSerializedSize;
        private long deckId_;
        public const int DeckIdFieldNumber = 1;
        private static readonly DraftBeginning defaultInstance = new DraftBeginning().MakeReadOnly();
        private bool hasDeckId;
        private int memoizedSerializedSize = -1;

        static DraftBeginning()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private DraftBeginning()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DraftBeginning prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DraftBeginning beginning = obj as DraftBeginning;
            if (beginning == null)
            {
                return false;
            }
            if ((this.hasDeckId != beginning.hasDeckId) || (this.hasDeckId && !this.deckId_.Equals(beginning.deckId_)))
            {
                return false;
            }
            if (this.choices_.Count != beginning.choices_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.choices_.Count; i++)
            {
                int num2 = this.choices_[i];
                if (!num2.Equals(beginning.choices_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public int GetChoices(int index)
        {
            return this.choices_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasDeckId)
            {
                hashCode ^= this.deckId_.GetHashCode();
            }
            IEnumerator<int> enumerator = this.choices_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    int current = enumerator.Current;
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

        private DraftBeginning MakeReadOnly()
        {
            this.choices_.MakeReadOnly();
            return this;
        }

        public static DraftBeginning ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DraftBeginning ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DraftBeginning ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DraftBeginning ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DraftBeginning ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DraftBeginning ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DraftBeginning ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DraftBeginning ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DraftBeginning ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DraftBeginning ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DraftBeginning, Builder>.PrintField("deck_id", this.hasDeckId, this.deckId_, writer);
            GeneratedMessageLite<DraftBeginning, Builder>.PrintField<int>("choices", this.choices_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _draftBeginningFieldNames;
            if (this.hasDeckId)
            {
                output.WriteInt64(1, strArray[1], this.DeckId);
            }
            if (this.choices_.Count > 0)
            {
                output.WritePackedInt32Array(2, strArray[0], this.choicesMemoizedSerializedSize, this.choices_);
            }
        }

        public int ChoicesCount
        {
            get
            {
                return this.choices_.Count;
            }
        }

        public IList<int> ChoicesList
        {
            get
            {
                return Lists.AsReadOnly<int>(this.choices_);
            }
        }

        public long DeckId
        {
            get
            {
                return this.deckId_;
            }
        }

        public static DraftBeginning DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DraftBeginning DefaultInstanceForType
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

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasDeckId)
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
                    int num2 = 0;
                    IEnumerator<int> enumerator = this.ChoicesList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            int current = enumerator.Current;
                            num2 += CodedOutputStream.ComputeInt32SizeNoTag(current);
                        }
                    }
                    finally
                    {
                        if (enumerator == null)
                        {
                        }
                        enumerator.Dispose();
                    }
                    memoizedSerializedSize += num2;
                    if (this.choices_.Count != 0)
                    {
                        memoizedSerializedSize += 1 + CodedOutputStream.ComputeInt32SizeNoTag(num2);
                    }
                    this.choicesMemoizedSerializedSize = num2;
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override DraftBeginning ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<DraftBeginning, DraftBeginning.Builder>
        {
            private DraftBeginning result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DraftBeginning.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DraftBeginning cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public DraftBeginning.Builder AddChoices(int value)
            {
                this.PrepareBuilder();
                this.result.choices_.Add(value);
                return this;
            }

            public DraftBeginning.Builder AddRangeChoices(IEnumerable<int> values)
            {
                this.PrepareBuilder();
                this.result.choices_.Add(values);
                return this;
            }

            public override DraftBeginning BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DraftBeginning.Builder Clear()
            {
                this.result = DraftBeginning.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DraftBeginning.Builder ClearChoices()
            {
                this.PrepareBuilder();
                this.result.choices_.Clear();
                return this;
            }

            public DraftBeginning.Builder ClearDeckId()
            {
                this.PrepareBuilder();
                this.result.hasDeckId = false;
                this.result.deckId_ = 0L;
                return this;
            }

            public override DraftBeginning.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DraftBeginning.Builder(this.result);
                }
                return new DraftBeginning.Builder().MergeFrom(this.result);
            }

            public int GetChoices(int index)
            {
                return this.result.GetChoices(index);
            }

            public override DraftBeginning.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DraftBeginning.Builder MergeFrom(IMessageLite other)
            {
                if (other is DraftBeginning)
                {
                    return this.MergeFrom((DraftBeginning) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DraftBeginning.Builder MergeFrom(DraftBeginning other)
            {
                if (other != DraftBeginning.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasDeckId)
                    {
                        this.DeckId = other.DeckId;
                    }
                    if (other.choices_.Count != 0)
                    {
                        this.result.choices_.Add(other.choices_);
                    }
                }
                return this;
            }

            public override DraftBeginning.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DraftBeginning._draftBeginningFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DraftBeginning._draftBeginningFieldTags[index];
                        }
                        else
                        {
                            this.ParseUnknownField(input, extensionRegistry, num, str);
                            continue;
                        }
                    }
                    switch (num)
                    {
                        case 0x10:
                        case 0x12:
                            goto Label_00BB;

                        case 0:
                            throw InvalidProtocolBufferException.InvalidTag();

                        case 8:
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
                    this.result.hasDeckId = input.ReadInt64(ref this.result.deckId_);
                    continue;
                Label_00BB:
                    input.ReadInt32Array(num, str, this.result.choices_);
                }
                return this;
            }

            private DraftBeginning PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DraftBeginning result = this.result;
                    this.result = new DraftBeginning();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DraftBeginning.Builder SetChoices(int index, int value)
            {
                this.PrepareBuilder();
                this.result.choices_[index] = value;
                return this;
            }

            public DraftBeginning.Builder SetDeckId(long value)
            {
                this.PrepareBuilder();
                this.result.hasDeckId = true;
                this.result.deckId_ = value;
                return this;
            }

            public int ChoicesCount
            {
                get
                {
                    return this.result.ChoicesCount;
                }
            }

            public IPopsicleList<int> ChoicesList
            {
                get
                {
                    return this.PrepareBuilder().choices_;
                }
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

            public override DraftBeginning DefaultInstanceForType
            {
                get
                {
                    return DraftBeginning.DefaultInstance;
                }
            }

            public bool HasDeckId
            {
                get
                {
                    return this.result.hasDeckId;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override DraftBeginning MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override DraftBeginning.Builder ThisBuilder
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
                ID = 0xf6
            }
        }
    }
}

