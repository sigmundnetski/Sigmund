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
    public sealed class DeckList : GeneratedMessageLite<DeckList, Builder>
    {
        private static readonly string[] _deckListFieldNames = new string[] { "decks" };
        private static readonly uint[] _deckListFieldTags = new uint[] { 10 };
        private PopsicleList<DeckInfo> decks_ = new PopsicleList<DeckInfo>();
        public const int DecksFieldNumber = 1;
        private static readonly DeckList defaultInstance = new DeckList().MakeReadOnly();
        private int memoizedSerializedSize = -1;

        static DeckList()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private DeckList()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DeckList prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DeckList list = obj as DeckList;
            if (list == null)
            {
                return false;
            }
            if (this.decks_.Count != list.decks_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.decks_.Count; i++)
            {
                if (!this.decks_[i].Equals(list.decks_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public DeckInfo GetDecks(int index)
        {
            return this.decks_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<DeckInfo> enumerator = this.decks_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    DeckInfo current = enumerator.Current;
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

        private DeckList MakeReadOnly()
        {
            this.decks_.MakeReadOnly();
            return this;
        }

        public static DeckList ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DeckList ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DeckList ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DeckList ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DeckList ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DeckList ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DeckList ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DeckList ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DeckList ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DeckList ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DeckList, Builder>.PrintField<DeckInfo>("decks", this.decks_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _deckListFieldNames;
            if (this.decks_.Count > 0)
            {
                output.WriteMessageArray<DeckInfo>(1, strArray[0], this.decks_);
            }
        }

        public int DecksCount
        {
            get
            {
                return this.decks_.Count;
            }
        }

        public IList<DeckInfo> DecksList
        {
            get
            {
                return this.decks_;
            }
        }

        public static DeckList DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DeckList DefaultInstanceForType
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
                IEnumerator<DeckInfo> enumerator = this.DecksList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        DeckInfo current = enumerator.Current;
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

        public override int SerializedSize
        {
            get
            {
                int memoizedSerializedSize = this.memoizedSerializedSize;
                if (memoizedSerializedSize == -1)
                {
                    memoizedSerializedSize = 0;
                    IEnumerator<DeckInfo> enumerator = this.DecksList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            DeckInfo current = enumerator.Current;
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

        protected override DeckList ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<DeckList, DeckList.Builder>
        {
            private DeckList result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DeckList.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DeckList cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public DeckList.Builder AddDecks(DeckInfo value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.decks_.Add(value);
                return this;
            }

            public DeckList.Builder AddDecks(DeckInfo.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.decks_.Add(builderForValue.Build());
                return this;
            }

            public DeckList.Builder AddRangeDecks(IEnumerable<DeckInfo> values)
            {
                this.PrepareBuilder();
                this.result.decks_.Add(values);
                return this;
            }

            public override DeckList BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DeckList.Builder Clear()
            {
                this.result = DeckList.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DeckList.Builder ClearDecks()
            {
                this.PrepareBuilder();
                this.result.decks_.Clear();
                return this;
            }

            public override DeckList.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DeckList.Builder(this.result);
                }
                return new DeckList.Builder().MergeFrom(this.result);
            }

            public DeckInfo GetDecks(int index)
            {
                return this.result.GetDecks(index);
            }

            public override DeckList.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DeckList.Builder MergeFrom(IMessageLite other)
            {
                if (other is DeckList)
                {
                    return this.MergeFrom((DeckList) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DeckList.Builder MergeFrom(DeckList other)
            {
                if (other != DeckList.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.decks_.Count != 0)
                    {
                        this.result.decks_.Add(other.decks_);
                    }
                }
                return this;
            }

            public override DeckList.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DeckList._deckListFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DeckList._deckListFieldTags[index];
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
                    input.ReadMessageArray<DeckInfo>(num, str, this.result.decks_, DeckInfo.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private DeckList PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DeckList result = this.result;
                    this.result = new DeckList();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DeckList.Builder SetDecks(int index, DeckInfo value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.decks_[index] = value;
                return this;
            }

            public DeckList.Builder SetDecks(int index, DeckInfo.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.decks_[index] = builderForValue.Build();
                return this;
            }

            public int DecksCount
            {
                get
                {
                    return this.result.DecksCount;
                }
            }

            public IPopsicleList<DeckInfo> DecksList
            {
                get
                {
                    return this.PrepareBuilder().decks_;
                }
            }

            public override DeckList DefaultInstanceForType
            {
                get
                {
                    return DeckList.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override DeckList MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override DeckList.Builder ThisBuilder
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
                ID = 0xca
            }
        }
    }
}

