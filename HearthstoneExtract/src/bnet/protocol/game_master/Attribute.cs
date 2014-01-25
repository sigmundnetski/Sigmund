namespace bnet.protocol.game_master
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class Attribute : GeneratedMessageLite<bnet.protocol.game_master.Attribute, Builder>
    {
        private static readonly string[] _attributeFieldNames = new string[] { "name", "value" };
        private static readonly uint[] _attributeFieldTags = new uint[] { 10, 0x12 };
        private static readonly bnet.protocol.game_master.Attribute defaultInstance = new bnet.protocol.game_master.Attribute().MakeReadOnly();
        private bool hasName;
        private bool hasValue;
        private int memoizedSerializedSize = -1;
        private string name_ = string.Empty;
        public const int NameFieldNumber = 1;
        private bnet.protocol.game_master.Variant value_;
        public const int ValueFieldNumber = 2;

        static Attribute()
        {
            object.ReferenceEquals(GameMaster.Descriptor, null);
        }

        private Attribute()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(bnet.protocol.game_master.Attribute prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            bnet.protocol.game_master.Attribute attribute = obj as bnet.protocol.game_master.Attribute;
            if (attribute == null)
            {
                return false;
            }
            if ((this.hasName != attribute.hasName) || (this.hasName && !this.name_.Equals(attribute.name_)))
            {
                return false;
            }
            return ((this.hasValue == attribute.hasValue) && (!this.hasValue || this.value_.Equals(attribute.value_)));
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

        private bnet.protocol.game_master.Attribute MakeReadOnly()
        {
            return this;
        }

        public static bnet.protocol.game_master.Attribute ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static bnet.protocol.game_master.Attribute ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static bnet.protocol.game_master.Attribute ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static bnet.protocol.game_master.Attribute ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static bnet.protocol.game_master.Attribute ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static bnet.protocol.game_master.Attribute ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static bnet.protocol.game_master.Attribute ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static bnet.protocol.game_master.Attribute ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static bnet.protocol.game_master.Attribute ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static bnet.protocol.game_master.Attribute ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<bnet.protocol.game_master.Attribute, Builder>.PrintField("name", this.hasName, this.name_, writer);
            GeneratedMessageLite<bnet.protocol.game_master.Attribute, Builder>.PrintField("value", this.hasValue, this.value_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _attributeFieldNames;
            if (this.hasName)
            {
                output.WriteString(1, strArray[0], this.Name);
            }
            if (this.hasValue)
            {
                output.WriteMessage(2, strArray[1], this.Value);
            }
        }

        public static bnet.protocol.game_master.Attribute DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override bnet.protocol.game_master.Attribute DefaultInstanceForType
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
                if (!this.Value.IsInitialized)
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
                    if (this.hasValue)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, this.Value);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override bnet.protocol.game_master.Attribute ThisMessage
        {
            get
            {
                return this;
            }
        }

        public bnet.protocol.game_master.Variant Value
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.value_ != null)
                {
                    goto Label_0012;
                }
                return bnet.protocol.game_master.Variant.DefaultInstance;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<bnet.protocol.game_master.Attribute, bnet.protocol.game_master.Attribute.Builder>
        {
            private bnet.protocol.game_master.Attribute result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = bnet.protocol.game_master.Attribute.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(bnet.protocol.game_master.Attribute cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override bnet.protocol.game_master.Attribute BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override bnet.protocol.game_master.Attribute.Builder Clear()
            {
                this.result = bnet.protocol.game_master.Attribute.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public bnet.protocol.game_master.Attribute.Builder ClearName()
            {
                this.PrepareBuilder();
                this.result.hasName = false;
                this.result.name_ = string.Empty;
                return this;
            }

            public bnet.protocol.game_master.Attribute.Builder ClearValue()
            {
                this.PrepareBuilder();
                this.result.hasValue = false;
                this.result.value_ = null;
                return this;
            }

            public override bnet.protocol.game_master.Attribute.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new bnet.protocol.game_master.Attribute.Builder(this.result);
                }
                return new bnet.protocol.game_master.Attribute.Builder().MergeFrom(this.result);
            }

            public override bnet.protocol.game_master.Attribute.Builder MergeFrom(bnet.protocol.game_master.Attribute other)
            {
                if (other != bnet.protocol.game_master.Attribute.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasName)
                    {
                        this.Name = other.Name;
                    }
                    if (other.HasValue)
                    {
                        this.MergeValue(other.Value);
                    }
                }
                return this;
            }

            public override bnet.protocol.game_master.Attribute.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override bnet.protocol.game_master.Attribute.Builder MergeFrom(IMessageLite other)
            {
                if (other is bnet.protocol.game_master.Attribute)
                {
                    return this.MergeFrom((bnet.protocol.game_master.Attribute) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override bnet.protocol.game_master.Attribute.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(bnet.protocol.game_master.Attribute._attributeFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = bnet.protocol.game_master.Attribute._attributeFieldTags[index];
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
                        case 0x12:
                        {
                            bnet.protocol.game_master.Variant.Builder builder = bnet.protocol.game_master.Variant.CreateBuilder();
                            if (this.result.hasValue)
                            {
                                builder.MergeFrom(this.Value);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.Value = builder.BuildPartial();
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

            public bnet.protocol.game_master.Attribute.Builder MergeValue(bnet.protocol.game_master.Variant value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasValue && (this.result.value_ != bnet.protocol.game_master.Variant.DefaultInstance))
                {
                    this.result.value_ = bnet.protocol.game_master.Variant.CreateBuilder(this.result.value_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.value_ = value;
                }
                this.result.hasValue = true;
                return this;
            }

            private bnet.protocol.game_master.Attribute PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    bnet.protocol.game_master.Attribute result = this.result;
                    this.result = new bnet.protocol.game_master.Attribute();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public bnet.protocol.game_master.Attribute.Builder SetName(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasName = true;
                this.result.name_ = value;
                return this;
            }

            public bnet.protocol.game_master.Attribute.Builder SetValue(bnet.protocol.game_master.Variant value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasValue = true;
                this.result.value_ = value;
                return this;
            }

            public bnet.protocol.game_master.Attribute.Builder SetValue(bnet.protocol.game_master.Variant.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasValue = true;
                this.result.value_ = builderForValue.Build();
                return this;
            }

            public override bnet.protocol.game_master.Attribute DefaultInstanceForType
            {
                get
                {
                    return bnet.protocol.game_master.Attribute.DefaultInstance;
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

            protected override bnet.protocol.game_master.Attribute MessageBeingBuilt
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

            protected override bnet.protocol.game_master.Attribute.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public bnet.protocol.game_master.Variant Value
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

