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
    public sealed class AtlasDecks : GeneratedMessageLite<AtlasDecks, Builder>
    {
        private static readonly string[] _atlasDecksFieldNames = new string[] { "decks" };
        private static readonly uint[] _atlasDecksFieldTags = new uint[] { 10 };
        private PopsicleList<AtlasDeck> decks_ = new PopsicleList<AtlasDeck>();
        public const int DecksFieldNumber = 1;
        private static readonly AtlasDecks defaultInstance = new AtlasDecks().MakeReadOnly();
        private int memoizedSerializedSize = -1;

        static AtlasDecks()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AtlasDecks()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AtlasDecks prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AtlasDecks decks = obj as AtlasDecks;
            if (decks == null)
            {
                return false;
            }
            if (this.decks_.Count != decks.decks_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.decks_.Count; i++)
            {
                if (!this.decks_[i].Equals(decks.decks_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public AtlasDeck GetDecks(int index)
        {
            return this.decks_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<AtlasDeck> enumerator = this.decks_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    AtlasDeck current = enumerator.Current;
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

        private AtlasDecks MakeReadOnly()
        {
            this.decks_.MakeReadOnly();
            return this;
        }

        public static AtlasDecks ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AtlasDecks ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasDecks ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasDecks ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasDecks ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasDecks ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasDecks ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AtlasDecks ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasDecks ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasDecks ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AtlasDecks, Builder>.PrintField<AtlasDeck>("decks", this.decks_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _atlasDecksFieldNames;
            if (this.decks_.Count > 0)
            {
                output.WriteMessageArray<AtlasDeck>(1, strArray[0], this.decks_);
            }
        }

        public int DecksCount
        {
            get
            {
                return this.decks_.Count;
            }
        }

        public IList<AtlasDeck> DecksList
        {
            get
            {
                return this.decks_;
            }
        }

        public static AtlasDecks DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AtlasDecks DefaultInstanceForType
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
                IEnumerator<AtlasDeck> enumerator = this.DecksList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        AtlasDeck current = enumerator.Current;
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
                    IEnumerator<AtlasDeck> enumerator = this.DecksList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            AtlasDeck current = enumerator.Current;
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

        protected override AtlasDecks ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<AtlasDecks, AtlasDecks.Builder>
        {
            private AtlasDecks result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AtlasDecks.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AtlasDecks cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public AtlasDecks.Builder AddDecks(AtlasDeck value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.decks_.Add(value);
                return this;
            }

            public AtlasDecks.Builder AddDecks(AtlasDeck.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.decks_.Add(builderForValue.Build());
                return this;
            }

            public AtlasDecks.Builder AddRangeDecks(IEnumerable<AtlasDeck> values)
            {
                this.PrepareBuilder();
                this.result.decks_.Add(values);
                return this;
            }

            public override AtlasDecks BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AtlasDecks.Builder Clear()
            {
                this.result = AtlasDecks.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AtlasDecks.Builder ClearDecks()
            {
                this.PrepareBuilder();
                this.result.decks_.Clear();
                return this;
            }

            public override AtlasDecks.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AtlasDecks.Builder(this.result);
                }
                return new AtlasDecks.Builder().MergeFrom(this.result);
            }

            public AtlasDeck GetDecks(int index)
            {
                return this.result.GetDecks(index);
            }

            public override AtlasDecks.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AtlasDecks.Builder MergeFrom(IMessageLite other)
            {
                if (other is AtlasDecks)
                {
                    return this.MergeFrom((AtlasDecks) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AtlasDecks.Builder MergeFrom(AtlasDecks other)
            {
                if (other != AtlasDecks.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.decks_.Count != 0)
                    {
                        this.result.decks_.Add(other.decks_);
                    }
                }
                return this;
            }

            public override AtlasDecks.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AtlasDecks._atlasDecksFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AtlasDecks._atlasDecksFieldTags[index];
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
                    input.ReadMessageArray<AtlasDeck>(num, str, this.result.decks_, AtlasDeck.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private AtlasDecks PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AtlasDecks result = this.result;
                    this.result = new AtlasDecks();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public AtlasDecks.Builder SetDecks(int index, AtlasDeck value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.decks_[index] = value;
                return this;
            }

            public AtlasDecks.Builder SetDecks(int index, AtlasDeck.Builder builderForValue)
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

            public IPopsicleList<AtlasDeck> DecksList
            {
                get
                {
                    return this.PrepareBuilder().decks_;
                }
            }

            public override AtlasDecks DefaultInstanceForType
            {
                get
                {
                    return AtlasDecks.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override AtlasDecks MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override AtlasDecks.Builder ThisBuilder
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
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0x68
            }
        }
    }
}

