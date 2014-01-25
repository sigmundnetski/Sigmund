namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class CreateDeck : GeneratedMessageLite<CreateDeck, Builder>
    {
        private static readonly string[] _createDeckFieldNames = new string[] { "hero", "name" };
        private static readonly uint[] _createDeckFieldTags = new uint[] { 0x10, 10 };
        private static readonly CreateDeck defaultInstance = new CreateDeck().MakeReadOnly();
        private bool hasHero;
        private bool hasName;
        private int hero_;
        public const int HeroFieldNumber = 2;
        private int memoizedSerializedSize = -1;
        private string name_ = string.Empty;
        public const int NameFieldNumber = 1;

        static CreateDeck()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private CreateDeck()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(CreateDeck prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            CreateDeck deck = obj as CreateDeck;
            if (deck == null)
            {
                return false;
            }
            if ((this.hasName != deck.hasName) || (this.hasName && !this.name_.Equals(deck.name_)))
            {
                return false;
            }
            return ((this.hasHero == deck.hasHero) && (!this.hasHero || this.hero_.Equals(deck.hero_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasName)
            {
                hashCode ^= this.name_.GetHashCode();
            }
            if (this.hasHero)
            {
                hashCode ^= this.hero_.GetHashCode();
            }
            return hashCode;
        }

        private CreateDeck MakeReadOnly()
        {
            return this;
        }

        public static CreateDeck ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static CreateDeck ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static CreateDeck ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static CreateDeck ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static CreateDeck ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static CreateDeck ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static CreateDeck ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static CreateDeck ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static CreateDeck ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static CreateDeck ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<CreateDeck, Builder>.PrintField("name", this.hasName, this.name_, writer);
            GeneratedMessageLite<CreateDeck, Builder>.PrintField("hero", this.hasHero, this.hero_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _createDeckFieldNames;
            if (this.hasName)
            {
                output.WriteString(1, strArray[1], this.Name);
            }
            if (this.hasHero)
            {
                output.WriteInt32(2, strArray[0], this.Hero);
            }
        }

        public static CreateDeck DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override CreateDeck DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasHero
        {
            get
            {
                return this.hasHero;
            }
        }

        public bool HasName
        {
            get
            {
                return this.hasName;
            }
        }

        public int Hero
        {
            get
            {
                return this.hero_;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasName)
                {
                    return false;
                }
                if (!this.hasHero)
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
                    if (this.hasName)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(1, this.Name);
                    }
                    if (this.hasHero)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.Hero);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override CreateDeck ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<CreateDeck, CreateDeck.Builder>
        {
            private CreateDeck result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = CreateDeck.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(CreateDeck cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override CreateDeck BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override CreateDeck.Builder Clear()
            {
                this.result = CreateDeck.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public CreateDeck.Builder ClearHero()
            {
                this.PrepareBuilder();
                this.result.hasHero = false;
                this.result.hero_ = 0;
                return this;
            }

            public CreateDeck.Builder ClearName()
            {
                this.PrepareBuilder();
                this.result.hasName = false;
                this.result.name_ = string.Empty;
                return this;
            }

            public override CreateDeck.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new CreateDeck.Builder(this.result);
                }
                return new CreateDeck.Builder().MergeFrom(this.result);
            }

            public override CreateDeck.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override CreateDeck.Builder MergeFrom(IMessageLite other)
            {
                if (other is CreateDeck)
                {
                    return this.MergeFrom((CreateDeck) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override CreateDeck.Builder MergeFrom(CreateDeck other)
            {
                if (other != CreateDeck.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasName)
                    {
                        this.Name = other.Name;
                    }
                    if (other.HasHero)
                    {
                        this.Hero = other.Hero;
                    }
                }
                return this;
            }

            public override CreateDeck.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(CreateDeck._createDeckFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = CreateDeck._createDeckFieldTags[index];
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
                            this.result.hasName = input.ReadString(ref this.result.name_);
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
                    this.result.hasHero = input.ReadInt32(ref this.result.hero_);
                }
                return this;
            }

            private CreateDeck PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    CreateDeck result = this.result;
                    this.result = new CreateDeck();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public CreateDeck.Builder SetHero(int value)
            {
                this.PrepareBuilder();
                this.result.hasHero = true;
                this.result.hero_ = value;
                return this;
            }

            public CreateDeck.Builder SetName(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasName = true;
                this.result.name_ = value;
                return this;
            }

            public override CreateDeck DefaultInstanceForType
            {
                get
                {
                    return CreateDeck.DefaultInstance;
                }
            }

            public bool HasHero
            {
                get
                {
                    return this.result.hasHero;
                }
            }

            public bool HasName
            {
                get
                {
                    return this.result.hasName;
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

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override CreateDeck MessageBeingBuilt
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

            protected override CreateDeck.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0xd1,
                System = 0
            }
        }
    }
}

