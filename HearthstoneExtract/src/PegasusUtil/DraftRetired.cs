namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class DraftRetired : GeneratedMessageLite<DraftRetired, Builder>
    {
        private static readonly string[] _draftRetiredFieldNames = new string[] { "deck_id" };
        private static readonly uint[] _draftRetiredFieldTags = new uint[] { 8 };
        private long deckId_;
        public const int DeckIdFieldNumber = 1;
        private static readonly DraftRetired defaultInstance = new DraftRetired().MakeReadOnly();
        private bool hasDeckId;
        private int memoizedSerializedSize = -1;

        static DraftRetired()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private DraftRetired()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DraftRetired prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DraftRetired retired = obj as DraftRetired;
            if (retired == null)
            {
                return false;
            }
            return ((this.hasDeckId == retired.hasDeckId) && (!this.hasDeckId || this.deckId_.Equals(retired.deckId_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasDeckId)
            {
                hashCode ^= this.deckId_.GetHashCode();
            }
            return hashCode;
        }

        private DraftRetired MakeReadOnly()
        {
            return this;
        }

        public static DraftRetired ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DraftRetired ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DraftRetired ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DraftRetired ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DraftRetired ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DraftRetired ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DraftRetired ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DraftRetired ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DraftRetired ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DraftRetired ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DraftRetired, Builder>.PrintField("deck_id", this.hasDeckId, this.deckId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _draftRetiredFieldNames;
            if (this.hasDeckId)
            {
                output.WriteInt64(1, strArray[0], this.DeckId);
            }
        }

        public long DeckId
        {
            get
            {
                return this.deckId_;
            }
        }

        public static DraftRetired DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DraftRetired DefaultInstanceForType
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
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override DraftRetired ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<DraftRetired, DraftRetired.Builder>
        {
            private DraftRetired result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DraftRetired.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DraftRetired cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override DraftRetired BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DraftRetired.Builder Clear()
            {
                this.result = DraftRetired.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DraftRetired.Builder ClearDeckId()
            {
                this.PrepareBuilder();
                this.result.hasDeckId = false;
                this.result.deckId_ = 0L;
                return this;
            }

            public override DraftRetired.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DraftRetired.Builder(this.result);
                }
                return new DraftRetired.Builder().MergeFrom(this.result);
            }

            public override DraftRetired.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DraftRetired.Builder MergeFrom(IMessageLite other)
            {
                if (other is DraftRetired)
                {
                    return this.MergeFrom((DraftRetired) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DraftRetired.Builder MergeFrom(DraftRetired other)
            {
                if (other != DraftRetired.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasDeckId)
                    {
                        this.DeckId = other.DeckId;
                    }
                }
                return this;
            }

            public override DraftRetired.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DraftRetired._draftRetiredFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DraftRetired._draftRetiredFieldTags[index];
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
                }
                return this;
            }

            private DraftRetired PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DraftRetired result = this.result;
                    this.result = new DraftRetired();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DraftRetired.Builder SetDeckId(long value)
            {
                this.PrepareBuilder();
                this.result.hasDeckId = true;
                this.result.deckId_ = value;
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

            public override DraftRetired DefaultInstanceForType
            {
                get
                {
                    return DraftRetired.DefaultInstance;
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

            protected override DraftRetired MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override DraftRetired.Builder ThisBuilder
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
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0xf7
            }
        }
    }
}

