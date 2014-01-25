namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class DeckInfo : GeneratedMessageLite<DeckInfo, Builder>
    {
        private static readonly string[] _deckInfoFieldNames = new string[] { "box", "deck_type", "hero", "id", "name", "validity" };
        private static readonly uint[] _deckInfoFieldTags = new uint[] { 0x18, 40, 0x20, 8, 0x12, 0x30 };
        private int box_;
        public const int BoxFieldNumber = 3;
        private PegasusUtil.DeckInfo.Types.DeckType deckType_ = PegasusUtil.DeckInfo.Types.DeckType.NORMAL_DECK;
        public const int DeckTypeFieldNumber = 5;
        private static readonly DeckInfo defaultInstance = new DeckInfo().MakeReadOnly();
        private bool hasBox;
        private bool hasDeckType;
        private bool hasHero;
        private bool hasId;
        private bool hasName;
        private bool hasValidity;
        private int hero_;
        public const int HeroFieldNumber = 4;
        private long id_;
        public const int IdFieldNumber = 1;
        private int memoizedSerializedSize = -1;
        private string name_ = string.Empty;
        public const int NameFieldNumber = 2;
        private long validity_;
        public const int ValidityFieldNumber = 6;

        static DeckInfo()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private DeckInfo()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DeckInfo prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DeckInfo info = obj as DeckInfo;
            if (info == null)
            {
                return false;
            }
            if ((this.hasId != info.hasId) || (this.hasId && !this.id_.Equals(info.id_)))
            {
                return false;
            }
            if ((this.hasName != info.hasName) || (this.hasName && !this.name_.Equals(info.name_)))
            {
                return false;
            }
            if ((this.hasBox != info.hasBox) || (this.hasBox && !this.box_.Equals(info.box_)))
            {
                return false;
            }
            if ((this.hasHero != info.hasHero) || (this.hasHero && !this.hero_.Equals(info.hero_)))
            {
                return false;
            }
            if ((this.hasDeckType != info.hasDeckType) || (this.hasDeckType && !this.deckType_.Equals(info.deckType_)))
            {
                return false;
            }
            return ((this.hasValidity == info.hasValidity) && (!this.hasValidity || this.validity_.Equals(info.validity_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasId)
            {
                hashCode ^= this.id_.GetHashCode();
            }
            if (this.hasName)
            {
                hashCode ^= this.name_.GetHashCode();
            }
            if (this.hasBox)
            {
                hashCode ^= this.box_.GetHashCode();
            }
            if (this.hasHero)
            {
                hashCode ^= this.hero_.GetHashCode();
            }
            if (this.hasDeckType)
            {
                hashCode ^= this.deckType_.GetHashCode();
            }
            if (this.hasValidity)
            {
                hashCode ^= this.validity_.GetHashCode();
            }
            return hashCode;
        }

        private DeckInfo MakeReadOnly()
        {
            return this;
        }

        public static DeckInfo ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DeckInfo ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DeckInfo ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DeckInfo ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DeckInfo ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DeckInfo ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DeckInfo ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DeckInfo ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DeckInfo ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DeckInfo ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DeckInfo, Builder>.PrintField("id", this.hasId, this.id_, writer);
            GeneratedMessageLite<DeckInfo, Builder>.PrintField("name", this.hasName, this.name_, writer);
            GeneratedMessageLite<DeckInfo, Builder>.PrintField("box", this.hasBox, this.box_, writer);
            GeneratedMessageLite<DeckInfo, Builder>.PrintField("hero", this.hasHero, this.hero_, writer);
            GeneratedMessageLite<DeckInfo, Builder>.PrintField("deck_type", this.hasDeckType, this.deckType_, writer);
            GeneratedMessageLite<DeckInfo, Builder>.PrintField("validity", this.hasValidity, this.validity_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _deckInfoFieldNames;
            if (this.hasId)
            {
                output.WriteInt64(1, strArray[3], this.Id);
            }
            if (this.hasName)
            {
                output.WriteString(2, strArray[4], this.Name);
            }
            if (this.hasBox)
            {
                output.WriteInt32(3, strArray[0], this.Box);
            }
            if (this.hasHero)
            {
                output.WriteInt32(4, strArray[2], this.Hero);
            }
            if (this.hasDeckType)
            {
                output.WriteEnum(5, strArray[1], (int) this.DeckType, this.DeckType);
            }
            if (this.hasValidity)
            {
                output.WriteInt64(6, strArray[5], this.Validity);
            }
        }

        public int Box
        {
            get
            {
                return this.box_;
            }
        }

        public PegasusUtil.DeckInfo.Types.DeckType DeckType
        {
            get
            {
                return this.deckType_;
            }
        }

        public static DeckInfo DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DeckInfo DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasBox
        {
            get
            {
                return this.hasBox;
            }
        }

        public bool HasDeckType
        {
            get
            {
                return this.hasDeckType;
            }
        }

        public bool HasHero
        {
            get
            {
                return this.hasHero;
            }
        }

        public bool HasId
        {
            get
            {
                return this.hasId;
            }
        }

        public bool HasName
        {
            get
            {
                return this.hasName;
            }
        }

        public bool HasValidity
        {
            get
            {
                return this.hasValidity;
            }
        }

        public int Hero
        {
            get
            {
                return this.hero_;
            }
        }

        public long Id
        {
            get
            {
                return this.id_;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasId)
                {
                    return false;
                }
                if (!this.hasName)
                {
                    return false;
                }
                if (!this.hasBox)
                {
                    return false;
                }
                if (!this.hasHero)
                {
                    return false;
                }
                if (!this.hasDeckType)
                {
                    return false;
                }
                if (!this.hasValidity)
                {
                    return false;
                }
                return true;
            }
        }

        public string Name
        {
            get
            {
                return this.name_;
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
                    if (this.hasId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(1, this.Id);
                    }
                    if (this.hasName)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(2, this.Name);
                    }
                    if (this.hasBox)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(3, this.Box);
                    }
                    if (this.hasHero)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(4, this.Hero);
                    }
                    if (this.hasDeckType)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeEnumSize(5, (int) this.DeckType);
                    }
                    if (this.hasValidity)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(6, this.Validity);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override DeckInfo ThisMessage
        {
            get
            {
                return this;
            }
        }

        public long Validity
        {
            get
            {
                return this.validity_;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<DeckInfo, DeckInfo.Builder>
        {
            private DeckInfo result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DeckInfo.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DeckInfo cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override DeckInfo BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DeckInfo.Builder Clear()
            {
                this.result = DeckInfo.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DeckInfo.Builder ClearBox()
            {
                this.PrepareBuilder();
                this.result.hasBox = false;
                this.result.box_ = 0;
                return this;
            }

            public DeckInfo.Builder ClearDeckType()
            {
                this.PrepareBuilder();
                this.result.hasDeckType = false;
                this.result.deckType_ = PegasusUtil.DeckInfo.Types.DeckType.NORMAL_DECK;
                return this;
            }

            public DeckInfo.Builder ClearHero()
            {
                this.PrepareBuilder();
                this.result.hasHero = false;
                this.result.hero_ = 0;
                return this;
            }

            public DeckInfo.Builder ClearId()
            {
                this.PrepareBuilder();
                this.result.hasId = false;
                this.result.id_ = 0L;
                return this;
            }

            public DeckInfo.Builder ClearName()
            {
                this.PrepareBuilder();
                this.result.hasName = false;
                this.result.name_ = string.Empty;
                return this;
            }

            public DeckInfo.Builder ClearValidity()
            {
                this.PrepareBuilder();
                this.result.hasValidity = false;
                this.result.validity_ = 0L;
                return this;
            }

            public override DeckInfo.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DeckInfo.Builder(this.result);
                }
                return new DeckInfo.Builder().MergeFrom(this.result);
            }

            public override DeckInfo.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DeckInfo.Builder MergeFrom(IMessageLite other)
            {
                if (other is DeckInfo)
                {
                    return this.MergeFrom((DeckInfo) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DeckInfo.Builder MergeFrom(DeckInfo other)
            {
                if (other != DeckInfo.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasId)
                    {
                        this.Id = other.Id;
                    }
                    if (other.HasName)
                    {
                        this.Name = other.Name;
                    }
                    if (other.HasBox)
                    {
                        this.Box = other.Box;
                    }
                    if (other.HasHero)
                    {
                        this.Hero = other.Hero;
                    }
                    if (other.HasDeckType)
                    {
                        this.DeckType = other.DeckType;
                    }
                    if (other.HasValidity)
                    {
                        this.Validity = other.Validity;
                    }
                }
                return this;
            }

            public override DeckInfo.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DeckInfo._deckInfoFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DeckInfo._deckInfoFieldTags[index];
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
                            this.result.hasId = input.ReadInt64(ref this.result.id_);
                            continue;
                        }
                        case 0x12:
                        {
                            this.result.hasName = input.ReadString(ref this.result.name_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasBox = input.ReadInt32(ref this.result.box_);
                            continue;
                        }
                        case 0x20:
                        {
                            this.result.hasHero = input.ReadInt32(ref this.result.hero_);
                            continue;
                        }
                        case 40:
                        {
                            object obj2;
                            if (input.ReadEnum<PegasusUtil.DeckInfo.Types.DeckType>(ref this.result.deckType_, out obj2))
                            {
                                this.result.hasDeckType = true;
                            }
                            else if (obj2 is int)
                            {
                            }
                            continue;
                        }
                        case 0x30:
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
                    this.result.hasValidity = input.ReadInt64(ref this.result.validity_);
                }
                return this;
            }

            private DeckInfo PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DeckInfo result = this.result;
                    this.result = new DeckInfo();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DeckInfo.Builder SetBox(int value)
            {
                this.PrepareBuilder();
                this.result.hasBox = true;
                this.result.box_ = value;
                return this;
            }

            public DeckInfo.Builder SetDeckType(PegasusUtil.DeckInfo.Types.DeckType value)
            {
                this.PrepareBuilder();
                this.result.hasDeckType = true;
                this.result.deckType_ = value;
                return this;
            }

            public DeckInfo.Builder SetHero(int value)
            {
                this.PrepareBuilder();
                this.result.hasHero = true;
                this.result.hero_ = value;
                return this;
            }

            public DeckInfo.Builder SetId(long value)
            {
                this.PrepareBuilder();
                this.result.hasId = true;
                this.result.id_ = value;
                return this;
            }

            public DeckInfo.Builder SetName(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasName = true;
                this.result.name_ = value;
                return this;
            }

            public DeckInfo.Builder SetValidity(long value)
            {
                this.PrepareBuilder();
                this.result.hasValidity = true;
                this.result.validity_ = value;
                return this;
            }

            public int Box
            {
                get
                {
                    return this.result.Box;
                }
                set
                {
                    this.SetBox(value);
                }
            }

            public PegasusUtil.DeckInfo.Types.DeckType DeckType
            {
                get
                {
                    return this.result.DeckType;
                }
                set
                {
                    this.SetDeckType(value);
                }
            }

            public override DeckInfo DefaultInstanceForType
            {
                get
                {
                    return DeckInfo.DefaultInstance;
                }
            }

            public bool HasBox
            {
                get
                {
                    return this.result.hasBox;
                }
            }

            public bool HasDeckType
            {
                get
                {
                    return this.result.hasDeckType;
                }
            }

            public bool HasHero
            {
                get
                {
                    return this.result.hasHero;
                }
            }

            public bool HasId
            {
                get
                {
                    return this.result.hasId;
                }
            }

            public bool HasName
            {
                get
                {
                    return this.result.hasName;
                }
            }

            public bool HasValidity
            {
                get
                {
                    return this.result.hasValidity;
                }
            }

            public int Hero
            {
                get
                {
                    return this.result.Hero;
                }
                set
                {
                    this.SetHero(value);
                }
            }

            public long Id
            {
                get
                {
                    return this.result.Id;
                }
                set
                {
                    this.SetId(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override DeckInfo MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public string Name
            {
                get
                {
                    return this.result.Name;
                }
                set
                {
                    this.SetName(value);
                }
            }

            protected override DeckInfo.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public long Validity
            {
                get
                {
                    return this.result.Validity;
                }
                set
                {
                    this.SetValidity(value);
                }
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum DeckType
            {
                AI_DECK = 2,
                DRAFT_DECK = 4,
                NORMAL_DECK = 1,
                PRECON_DECK = 5
            }
        }
    }
}

