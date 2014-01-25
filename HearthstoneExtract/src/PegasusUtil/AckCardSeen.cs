namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using PegasusShared;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class AckCardSeen : GeneratedMessageLite<AckCardSeen, Builder>
    {
        private static readonly string[] _ackCardSeenFieldNames = new string[] { "card_def", "card_defs" };
        private static readonly uint[] _ackCardSeenFieldTags = new uint[] { 0x12, 10 };
        private PegasusShared.CardDef cardDef_;
        public const int CardDefFieldNumber = 2;
        private PopsicleList<PegasusShared.CardDef> cardDefs_ = new PopsicleList<PegasusShared.CardDef>();
        public const int CardDefsFieldNumber = 1;
        private static readonly AckCardSeen defaultInstance = new AckCardSeen().MakeReadOnly();
        private bool hasCardDef;
        private int memoizedSerializedSize = -1;

        static AckCardSeen()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AckCardSeen()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AckCardSeen prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AckCardSeen seen = obj as AckCardSeen;
            if (seen == null)
            {
                return false;
            }
            if (this.cardDefs_.Count != seen.cardDefs_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.cardDefs_.Count; i++)
            {
                if (!this.cardDefs_[i].Equals(seen.cardDefs_[i]))
                {
                    return false;
                }
            }
            return ((this.hasCardDef == seen.hasCardDef) && (!this.hasCardDef || this.cardDef_.Equals(seen.cardDef_)));
        }

        public PegasusShared.CardDef GetCardDefs(int index)
        {
            return this.cardDefs_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<PegasusShared.CardDef> enumerator = this.cardDefs_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    PegasusShared.CardDef current = enumerator.Current;
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
            if (this.hasCardDef)
            {
                hashCode ^= this.cardDef_.GetHashCode();
            }
            return hashCode;
        }

        private AckCardSeen MakeReadOnly()
        {
            this.cardDefs_.MakeReadOnly();
            return this;
        }

        public static AckCardSeen ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AckCardSeen ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AckCardSeen ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AckCardSeen ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AckCardSeen ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AckCardSeen ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AckCardSeen ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AckCardSeen ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AckCardSeen ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AckCardSeen ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AckCardSeen, Builder>.PrintField<PegasusShared.CardDef>("card_defs", this.cardDefs_, writer);
            GeneratedMessageLite<AckCardSeen, Builder>.PrintField("card_def", this.hasCardDef, this.cardDef_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _ackCardSeenFieldNames;
            if (this.cardDefs_.Count > 0)
            {
                output.WriteMessageArray<PegasusShared.CardDef>(1, strArray[1], this.cardDefs_);
            }
            if (this.hasCardDef)
            {
                output.WriteMessage(2, strArray[0], this.CardDef);
            }
        }

        public PegasusShared.CardDef CardDef
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.cardDef_ != null)
                {
                    goto Label_0012;
                }
                return PegasusShared.CardDef.DefaultInstance;
            }
        }

        public int CardDefsCount
        {
            get
            {
                return this.cardDefs_.Count;
            }
        }

        public IList<PegasusShared.CardDef> CardDefsList
        {
            get
            {
                return this.cardDefs_;
            }
        }

        public static AckCardSeen DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AckCardSeen DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasCardDef
        {
            get
            {
                return this.hasCardDef;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                IEnumerator<PegasusShared.CardDef> enumerator = this.CardDefsList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        PegasusShared.CardDef current = enumerator.Current;
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
                if (this.HasCardDef && !this.CardDef.IsInitialized)
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
                    IEnumerator<PegasusShared.CardDef> enumerator = this.CardDefsList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            PegasusShared.CardDef current = enumerator.Current;
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
                    if (this.hasCardDef)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, this.CardDef);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override AckCardSeen ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<AckCardSeen, AckCardSeen.Builder>
        {
            private AckCardSeen result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AckCardSeen.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AckCardSeen cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public AckCardSeen.Builder AddCardDefs(PegasusShared.CardDef value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.cardDefs_.Add(value);
                return this;
            }

            public AckCardSeen.Builder AddCardDefs(PegasusShared.CardDef.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.cardDefs_.Add(builderForValue.Build());
                return this;
            }

            public AckCardSeen.Builder AddRangeCardDefs(IEnumerable<PegasusShared.CardDef> values)
            {
                this.PrepareBuilder();
                this.result.cardDefs_.Add(values);
                return this;
            }

            public override AckCardSeen BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AckCardSeen.Builder Clear()
            {
                this.result = AckCardSeen.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AckCardSeen.Builder ClearCardDef()
            {
                this.PrepareBuilder();
                this.result.hasCardDef = false;
                this.result.cardDef_ = null;
                return this;
            }

            public AckCardSeen.Builder ClearCardDefs()
            {
                this.PrepareBuilder();
                this.result.cardDefs_.Clear();
                return this;
            }

            public override AckCardSeen.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AckCardSeen.Builder(this.result);
                }
                return new AckCardSeen.Builder().MergeFrom(this.result);
            }

            public PegasusShared.CardDef GetCardDefs(int index)
            {
                return this.result.GetCardDefs(index);
            }

            public AckCardSeen.Builder MergeCardDef(PegasusShared.CardDef value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasCardDef && (this.result.cardDef_ != PegasusShared.CardDef.DefaultInstance))
                {
                    this.result.cardDef_ = PegasusShared.CardDef.CreateBuilder(this.result.cardDef_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.cardDef_ = value;
                }
                this.result.hasCardDef = true;
                return this;
            }

            public override AckCardSeen.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AckCardSeen.Builder MergeFrom(IMessageLite other)
            {
                if (other is AckCardSeen)
                {
                    return this.MergeFrom((AckCardSeen) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AckCardSeen.Builder MergeFrom(AckCardSeen other)
            {
                if (other != AckCardSeen.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.cardDefs_.Count != 0)
                    {
                        this.result.cardDefs_.Add(other.cardDefs_);
                    }
                    if (other.HasCardDef)
                    {
                        this.MergeCardDef(other.CardDef);
                    }
                }
                return this;
            }

            public override AckCardSeen.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AckCardSeen._ackCardSeenFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AckCardSeen._ackCardSeenFieldTags[index];
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
                            input.ReadMessageArray<PegasusShared.CardDef>(num, str, this.result.cardDefs_, PegasusShared.CardDef.DefaultInstance, extensionRegistry);
                            continue;
                        }
                        case 0x12:
                        {
                            PegasusShared.CardDef.Builder builder = PegasusShared.CardDef.CreateBuilder();
                            if (this.result.hasCardDef)
                            {
                                builder.MergeFrom(this.CardDef);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.CardDef = builder.BuildPartial();
                            continue;
                        }
                    }
                    if (WireFormat.IsEndGroupTag(num))
                    {
                        return this;
                    }
                    this.ParseUnknownField(input, extensionRegistry, num, str);
                }
                return this;
            }

            private AckCardSeen PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AckCardSeen result = this.result;
                    this.result = new AckCardSeen();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public AckCardSeen.Builder SetCardDef(PegasusShared.CardDef value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasCardDef = true;
                this.result.cardDef_ = value;
                return this;
            }

            public AckCardSeen.Builder SetCardDef(PegasusShared.CardDef.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasCardDef = true;
                this.result.cardDef_ = builderForValue.Build();
                return this;
            }

            public AckCardSeen.Builder SetCardDefs(int index, PegasusShared.CardDef value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.cardDefs_[index] = value;
                return this;
            }

            public AckCardSeen.Builder SetCardDefs(int index, PegasusShared.CardDef.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.cardDefs_[index] = builderForValue.Build();
                return this;
            }

            public PegasusShared.CardDef CardDef
            {
                get
                {
                    return this.result.CardDef;
                }
                set
                {
                    this.SetCardDef(value);
                }
            }

            public int CardDefsCount
            {
                get
                {
                    return this.result.CardDefsCount;
                }
            }

            public IPopsicleList<PegasusShared.CardDef> CardDefsList
            {
                get
                {
                    return this.PrepareBuilder().cardDefs_;
                }
            }

            public override AckCardSeen DefaultInstanceForType
            {
                get
                {
                    return AckCardSeen.DefaultInstance;
                }
            }

            public bool HasCardDef
            {
                get
                {
                    return this.result.hasCardDef;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override AckCardSeen MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override AckCardSeen.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0xdf,
                System = 0
            }
        }
    }
}

