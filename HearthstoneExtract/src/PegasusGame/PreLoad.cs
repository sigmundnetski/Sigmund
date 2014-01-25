namespace PegasusGame
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
    public sealed class PreLoad : GeneratedMessageLite<PreLoad, Builder>
    {
        private static readonly string[] _preLoadFieldNames = new string[] { "cards" };
        private static readonly uint[] _preLoadFieldTags = new uint[] { 10 };
        private PopsicleList<int> cards_ = new PopsicleList<int>();
        public const int CardsFieldNumber = 1;
        private int cardsMemoizedSerializedSize;
        private static readonly PreLoad defaultInstance = new PreLoad().MakeReadOnly();
        private int memoizedSerializedSize = -1;

        static PreLoad()
        {
            object.ReferenceEquals(PegasusGamelite.Descriptor, null);
        }

        private PreLoad()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(PreLoad prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            PreLoad load = obj as PreLoad;
            if (load == null)
            {
                return false;
            }
            if (this.cards_.Count != load.cards_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.cards_.Count; i++)
            {
                int num2 = this.cards_[i];
                if (!num2.Equals(load.cards_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public int GetCards(int index)
        {
            return this.cards_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<int> enumerator = this.cards_.GetEnumerator();
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

        private PreLoad MakeReadOnly()
        {
            this.cards_.MakeReadOnly();
            return this;
        }

        public static PreLoad ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static PreLoad ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static PreLoad ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PreLoad ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PreLoad ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PreLoad ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PreLoad ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static PreLoad ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PreLoad ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PreLoad ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<PreLoad, Builder>.PrintField<int>("cards", this.cards_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _preLoadFieldNames;
            if (this.cards_.Count > 0)
            {
                output.WritePackedInt32Array(1, strArray[0], this.cardsMemoizedSerializedSize, this.cards_);
            }
        }

        public int CardsCount
        {
            get
            {
                return this.cards_.Count;
            }
        }

        public IList<int> CardsList
        {
            get
            {
                return Lists.AsReadOnly<int>(this.cards_);
            }
        }

        public static PreLoad DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override PreLoad DefaultInstanceForType
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
                    int num2 = 0;
                    IEnumerator<int> enumerator = this.CardsList.GetEnumerator();
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
                    if (this.cards_.Count != 0)
                    {
                        memoizedSerializedSize += 1 + CodedOutputStream.ComputeInt32SizeNoTag(num2);
                    }
                    this.cardsMemoizedSerializedSize = num2;
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override PreLoad ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<PreLoad, PreLoad.Builder>
        {
            private PreLoad result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = PreLoad.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(PreLoad cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public PreLoad.Builder AddCards(int value)
            {
                this.PrepareBuilder();
                this.result.cards_.Add(value);
                return this;
            }

            public PreLoad.Builder AddRangeCards(IEnumerable<int> values)
            {
                this.PrepareBuilder();
                this.result.cards_.Add(values);
                return this;
            }

            public override PreLoad BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override PreLoad.Builder Clear()
            {
                this.result = PreLoad.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public PreLoad.Builder ClearCards()
            {
                this.PrepareBuilder();
                this.result.cards_.Clear();
                return this;
            }

            public override PreLoad.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new PreLoad.Builder(this.result);
                }
                return new PreLoad.Builder().MergeFrom(this.result);
            }

            public int GetCards(int index)
            {
                return this.result.GetCards(index);
            }

            public override PreLoad.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override PreLoad.Builder MergeFrom(IMessageLite other)
            {
                if (other is PreLoad)
                {
                    return this.MergeFrom((PreLoad) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override PreLoad.Builder MergeFrom(PreLoad other)
            {
                if (other != PreLoad.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.cards_.Count != 0)
                    {
                        this.result.cards_.Add(other.cards_);
                    }
                }
                return this;
            }

            public override PreLoad.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(PreLoad._preLoadFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = PreLoad._preLoadFieldTags[index];
                        }
                        else
                        {
                            this.ParseUnknownField(input, extensionRegistry, num, str);
                            continue;
                        }
                    }
                    switch (num)
                    {
                        case 8:
                        case 10:
                            break;

                        case 0:
                            throw InvalidProtocolBufferException.InvalidTag();

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
                    input.ReadInt32Array(num, str, this.result.cards_);
                }
                return this;
            }

            private PreLoad PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    PreLoad result = this.result;
                    this.result = new PreLoad();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public PreLoad.Builder SetCards(int index, int value)
            {
                this.PrepareBuilder();
                this.result.cards_[index] = value;
                return this;
            }

            public int CardsCount
            {
                get
                {
                    return this.result.CardsCount;
                }
            }

            public IPopsicleList<int> CardsList
            {
                get
                {
                    return this.PrepareBuilder().cards_;
                }
            }

            public override PreLoad DefaultInstanceForType
            {
                get
                {
                    return PreLoad.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override PreLoad MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override PreLoad.Builder ThisBuilder
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
                ID = 0x12
            }
        }
    }
}

