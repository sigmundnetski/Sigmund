namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class HostScenario : GeneratedMessageLite<HostScenario, Builder>
    {
        private static readonly string[] _hostScenarioFieldNames = new string[] { "ai_deck", "debug_name", "deck", "scenario" };
        private static readonly uint[] _hostScenarioFieldTags = new uint[] { 0x18, 0x22, 0x10, 8 };
        private long aiDeck_;
        public const int AiDeckFieldNumber = 3;
        private string debugName_ = string.Empty;
        public const int DebugNameFieldNumber = 4;
        private long deck_;
        public const int DeckFieldNumber = 2;
        private static readonly HostScenario defaultInstance = new HostScenario().MakeReadOnly();
        private bool hasAiDeck;
        private bool hasDebugName;
        private bool hasDeck;
        private bool hasScenario;
        private int memoizedSerializedSize = -1;
        private int scenario_;
        public const int ScenarioFieldNumber = 1;

        static HostScenario()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private HostScenario()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(HostScenario prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            HostScenario scenario = obj as HostScenario;
            if (scenario == null)
            {
                return false;
            }
            if ((this.hasScenario != scenario.hasScenario) || (this.hasScenario && !this.scenario_.Equals(scenario.scenario_)))
            {
                return false;
            }
            if ((this.hasDeck != scenario.hasDeck) || (this.hasDeck && !this.deck_.Equals(scenario.deck_)))
            {
                return false;
            }
            if ((this.hasAiDeck != scenario.hasAiDeck) || (this.hasAiDeck && !this.aiDeck_.Equals(scenario.aiDeck_)))
            {
                return false;
            }
            return ((this.hasDebugName == scenario.hasDebugName) && (!this.hasDebugName || this.debugName_.Equals(scenario.debugName_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasScenario)
            {
                hashCode ^= this.scenario_.GetHashCode();
            }
            if (this.hasDeck)
            {
                hashCode ^= this.deck_.GetHashCode();
            }
            if (this.hasAiDeck)
            {
                hashCode ^= this.aiDeck_.GetHashCode();
            }
            if (this.hasDebugName)
            {
                hashCode ^= this.debugName_.GetHashCode();
            }
            return hashCode;
        }

        private HostScenario MakeReadOnly()
        {
            return this;
        }

        public static HostScenario ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static HostScenario ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static HostScenario ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static HostScenario ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static HostScenario ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static HostScenario ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static HostScenario ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static HostScenario ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static HostScenario ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static HostScenario ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<HostScenario, Builder>.PrintField("scenario", this.hasScenario, this.scenario_, writer);
            GeneratedMessageLite<HostScenario, Builder>.PrintField("deck", this.hasDeck, this.deck_, writer);
            GeneratedMessageLite<HostScenario, Builder>.PrintField("ai_deck", this.hasAiDeck, this.aiDeck_, writer);
            GeneratedMessageLite<HostScenario, Builder>.PrintField("debug_name", this.hasDebugName, this.debugName_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _hostScenarioFieldNames;
            if (this.hasScenario)
            {
                output.WriteInt32(1, strArray[3], this.Scenario);
            }
            if (this.hasDeck)
            {
                output.WriteInt64(2, strArray[2], this.Deck);
            }
            if (this.hasAiDeck)
            {
                output.WriteInt64(3, strArray[0], this.AiDeck);
            }
            if (this.hasDebugName)
            {
                output.WriteString(4, strArray[1], this.DebugName);
            }
        }

        public long AiDeck
        {
            get
            {
                return this.aiDeck_;
            }
        }

        public string DebugName
        {
            get
            {
                return this.debugName_;
            }
        }

        public long Deck
        {
            get
            {
                return this.deck_;
            }
        }

        public static HostScenario DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override HostScenario DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasAiDeck
        {
            get
            {
                return this.hasAiDeck;
            }
        }

        public bool HasDebugName
        {
            get
            {
                return this.hasDebugName;
            }
        }

        public bool HasDeck
        {
            get
            {
                return this.hasDeck;
            }
        }

        public bool HasScenario
        {
            get
            {
                return this.hasScenario;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasScenario)
                {
                    return false;
                }
                if (!this.hasDeck)
                {
                    return false;
                }
                if (!this.hasDebugName)
                {
                    return false;
                }
                return true;
            }
        }

        public int Scenario
        {
            get
            {
                return this.scenario_;
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
                    if (this.hasScenario)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.Scenario);
                    }
                    if (this.hasDeck)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(2, this.Deck);
                    }
                    if (this.hasAiDeck)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(3, this.AiDeck);
                    }
                    if (this.hasDebugName)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(4, this.DebugName);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override HostScenario ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<HostScenario, HostScenario.Builder>
        {
            private HostScenario result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = HostScenario.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(HostScenario cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override HostScenario BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override HostScenario.Builder Clear()
            {
                this.result = HostScenario.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public HostScenario.Builder ClearAiDeck()
            {
                this.PrepareBuilder();
                this.result.hasAiDeck = false;
                this.result.aiDeck_ = 0L;
                return this;
            }

            public HostScenario.Builder ClearDebugName()
            {
                this.PrepareBuilder();
                this.result.hasDebugName = false;
                this.result.debugName_ = string.Empty;
                return this;
            }

            public HostScenario.Builder ClearDeck()
            {
                this.PrepareBuilder();
                this.result.hasDeck = false;
                this.result.deck_ = 0L;
                return this;
            }

            public HostScenario.Builder ClearScenario()
            {
                this.PrepareBuilder();
                this.result.hasScenario = false;
                this.result.scenario_ = 0;
                return this;
            }

            public override HostScenario.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new HostScenario.Builder(this.result);
                }
                return new HostScenario.Builder().MergeFrom(this.result);
            }

            public override HostScenario.Builder MergeFrom(HostScenario other)
            {
                if (other != HostScenario.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasScenario)
                    {
                        this.Scenario = other.Scenario;
                    }
                    if (other.HasDeck)
                    {
                        this.Deck = other.Deck;
                    }
                    if (other.HasAiDeck)
                    {
                        this.AiDeck = other.AiDeck;
                    }
                    if (other.HasDebugName)
                    {
                        this.DebugName = other.DebugName;
                    }
                }
                return this;
            }

            public override HostScenario.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override HostScenario.Builder MergeFrom(IMessageLite other)
            {
                if (other is HostScenario)
                {
                    return this.MergeFrom((HostScenario) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override HostScenario.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(HostScenario._hostScenarioFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = HostScenario._hostScenarioFieldTags[index];
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
                            this.result.hasScenario = input.ReadInt32(ref this.result.scenario_);
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasDeck = input.ReadInt64(ref this.result.deck_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasAiDeck = input.ReadInt64(ref this.result.aiDeck_);
                            continue;
                        }
                        case 0x22:
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
                    this.result.hasDebugName = input.ReadString(ref this.result.debugName_);
                }
                return this;
            }

            private HostScenario PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    HostScenario result = this.result;
                    this.result = new HostScenario();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public HostScenario.Builder SetAiDeck(long value)
            {
                this.PrepareBuilder();
                this.result.hasAiDeck = true;
                this.result.aiDeck_ = value;
                return this;
            }

            public HostScenario.Builder SetDebugName(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasDebugName = true;
                this.result.debugName_ = value;
                return this;
            }

            public HostScenario.Builder SetDeck(long value)
            {
                this.PrepareBuilder();
                this.result.hasDeck = true;
                this.result.deck_ = value;
                return this;
            }

            public HostScenario.Builder SetScenario(int value)
            {
                this.PrepareBuilder();
                this.result.hasScenario = true;
                this.result.scenario_ = value;
                return this;
            }

            public long AiDeck
            {
                get
                {
                    return this.result.AiDeck;
                }
                set
                {
                    this.SetAiDeck(value);
                }
            }

            public string DebugName
            {
                get
                {
                    return this.result.DebugName;
                }
                set
                {
                    this.SetDebugName(value);
                }
            }

            public long Deck
            {
                get
                {
                    return this.result.Deck;
                }
                set
                {
                    this.SetDeck(value);
                }
            }

            public override HostScenario DefaultInstanceForType
            {
                get
                {
                    return HostScenario.DefaultInstance;
                }
            }

            public bool HasAiDeck
            {
                get
                {
                    return this.result.hasAiDeck;
                }
            }

            public bool HasDebugName
            {
                get
                {
                    return this.result.hasDebugName;
                }
            }

            public bool HasDeck
            {
                get
                {
                    return this.result.hasDeck;
                }
            }

            public bool HasScenario
            {
                get
                {
                    return this.result.hasScenario;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override HostScenario MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int Scenario
            {
                get
                {
                    return this.result.Scenario;
                }
                set
                {
                    this.SetScenario(value);
                }
            }

            protected override HostScenario.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0x99
            }
        }
    }
}

