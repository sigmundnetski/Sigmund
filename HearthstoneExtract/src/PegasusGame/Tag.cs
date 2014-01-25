namespace PegasusGame
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class Tag : GeneratedMessageLite<Tag, Builder>
    {
        private static readonly string[] _tagFieldNames = new string[] { "name", "value" };
        private static readonly uint[] _tagFieldTags = new uint[] { 8, 0x10 };
        private static readonly Tag defaultInstance = new Tag().MakeReadOnly();
        private bool hasName;
        private bool hasValue;
        private int memoizedSerializedSize = -1;
        private int name_;
        public const int NameFieldNumber = 1;
        private int value_;
        public const int ValueFieldNumber = 2;

        static Tag()
        {
            object.ReferenceEquals(PegasusGamelite.Descriptor, null);
        }

        private Tag()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(Tag prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            Tag tag = obj as Tag;
            if (tag == null)
            {
                return false;
            }
            if ((this.hasName != tag.hasName) || (this.hasName && !this.name_.Equals(tag.name_)))
            {
                return false;
            }
            return ((this.hasValue == tag.hasValue) && (!this.hasValue || this.value_.Equals(tag.value_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasName)
            {
                hashCode ^= this.name_.GetHashCode();
            }
            if (this.hasValue)
            {
                hashCode ^= this.value_.GetHashCode();
            }
            return hashCode;
        }

        private Tag MakeReadOnly()
        {
            return this;
        }

        public static Tag ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static Tag ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static Tag ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Tag ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Tag ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Tag ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Tag ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static Tag ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Tag ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Tag ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<Tag, Builder>.PrintField("name", this.hasName, this.name_, writer);
            GeneratedMessageLite<Tag, Builder>.PrintField("value", this.hasValue, this.value_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _tagFieldNames;
            if (this.hasName)
            {
                output.WriteInt32(1, strArray[0], this.Name);
            }
            if (this.hasValue)
            {
                output.WriteInt32(2, strArray[1], this.Value);
            }
        }

        public static Tag DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override Tag DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasName
        {
            get
            {
                return this.hasName;
            }
        }

        public bool HasValue
        {
            get
            {
                return this.hasValue;
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
                if (!this.hasValue)
                {
                    return false;
                }
                return true;
            }
        }

        public int Name
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
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.Name);
                    }
                    if (this.hasValue)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.Value);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override Tag ThisMessage
        {
            get
            {
                return this;
            }
        }

        public int Value
        {
            get
            {
                return this.value_;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<Tag, Tag.Builder>
        {
            private Tag result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = Tag.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(Tag cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override Tag BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override Tag.Builder Clear()
            {
                this.result = Tag.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public Tag.Builder ClearName()
            {
                this.PrepareBuilder();
                this.result.hasName = false;
                this.result.name_ = 0;
                return this;
            }

            public Tag.Builder ClearValue()
            {
                this.PrepareBuilder();
                this.result.hasValue = false;
                this.result.value_ = 0;
                return this;
            }

            public override Tag.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new Tag.Builder(this.result);
                }
                return new Tag.Builder().MergeFrom(this.result);
            }

            public override Tag.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override Tag.Builder MergeFrom(IMessageLite other)
            {
                if (other is Tag)
                {
                    return this.MergeFrom((Tag) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override Tag.Builder MergeFrom(Tag other)
            {
                if (other != Tag.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasName)
                    {
                        this.Name = other.Name;
                    }
                    if (other.HasValue)
                    {
                        this.Value = other.Value;
                    }
                }
                return this;
            }

            public override Tag.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(Tag._tagFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = Tag._tagFieldTags[index];
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
                            this.result.hasName = input.ReadInt32(ref this.result.name_);
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
                    this.result.hasValue = input.ReadInt32(ref this.result.value_);
                }
                return this;
            }

            private Tag PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    Tag result = this.result;
                    this.result = new Tag();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public Tag.Builder SetName(int value)
            {
                this.PrepareBuilder();
                this.result.hasName = true;
                this.result.name_ = value;
                return this;
            }

            public Tag.Builder SetValue(int value)
            {
                this.PrepareBuilder();
                this.result.hasValue = true;
                this.result.value_ = value;
                return this;
            }

            public override Tag DefaultInstanceForType
            {
                get
                {
                    return Tag.DefaultInstance;
                }
            }

            public bool HasName
            {
                get
                {
                    return this.result.hasName;
                }
            }

            public bool HasValue
            {
                get
                {
                    return this.result.hasValue;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override Tag MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int Name
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

            protected override Tag.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public int Value
            {
                get
                {
                    return this.result.Value;
                }
                set
                {
                    this.SetValue(value);
                }
            }
        }
    }
}

