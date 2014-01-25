namespace bnet.protocol.presence
{
    using bnet.protocol.attribute;
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class Field : GeneratedMessageLite<Field, Builder>
    {
        private static readonly string[] _fieldFieldNames = new string[] { "key", "value" };
        private static readonly uint[] _fieldFieldTags = new uint[] { 10, 0x12 };
        private static readonly Field defaultInstance = new Field().MakeReadOnly();
        private bool hasKey;
        private bool hasValue;
        private FieldKey key_;
        public const int KeyFieldNumber = 1;
        private int memoizedSerializedSize = -1;
        private bnet.protocol.attribute.Variant value_;
        public const int ValueFieldNumber = 2;

        static Field()
        {
            object.ReferenceEquals(PresenceTypes.Descriptor, null);
        }

        private Field()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(Field prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            Field field = obj as Field;
            if (field == null)
            {
                return false;
            }
            if ((this.hasKey != field.hasKey) || (this.hasKey && !this.key_.Equals(field.key_)))
            {
                return false;
            }
            return ((this.hasValue == field.hasValue) && (!this.hasValue || this.value_.Equals(field.value_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasKey)
            {
                hashCode ^= this.key_.GetHashCode();
            }
            if (this.hasValue)
            {
                hashCode ^= this.value_.GetHashCode();
            }
            return hashCode;
        }

        private Field MakeReadOnly()
        {
            return this;
        }

        public static Field ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static Field ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static Field ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Field ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Field ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Field ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Field ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static Field ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Field ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Field ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<Field, Builder>.PrintField("key", this.hasKey, this.key_, writer);
            GeneratedMessageLite<Field, Builder>.PrintField("value", this.hasValue, this.value_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _fieldFieldNames;
            if (this.hasKey)
            {
                output.WriteMessage(1, strArray[0], this.Key);
            }
            if (this.hasValue)
            {
                output.WriteMessage(2, strArray[1], this.Value);
            }
        }

        public static Field DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override Field DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasKey
        {
            get
            {
                return this.hasKey;
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
                if (!this.hasKey)
                {
                    return false;
                }
                if (!this.hasValue)
                {
                    return false;
                }
                if (!this.Key.IsInitialized)
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

        public FieldKey Key
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.key_ != null)
                {
                    goto Label_0012;
                }
                return FieldKey.DefaultInstance;
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
                    if (this.hasKey)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.Key);
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

        protected override Field ThisMessage
        {
            get
            {
                return this;
            }
        }

        public bnet.protocol.attribute.Variant Value
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.value_ != null)
                {
                    goto Label_0012;
                }
                return bnet.protocol.attribute.Variant.DefaultInstance;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<Field, Field.Builder>
        {
            private Field result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = Field.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(Field cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override Field BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override Field.Builder Clear()
            {
                this.result = Field.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public Field.Builder ClearKey()
            {
                this.PrepareBuilder();
                this.result.hasKey = false;
                this.result.key_ = null;
                return this;
            }

            public Field.Builder ClearValue()
            {
                this.PrepareBuilder();
                this.result.hasValue = false;
                this.result.value_ = null;
                return this;
            }

            public override Field.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new Field.Builder(this.result);
                }
                return new Field.Builder().MergeFrom(this.result);
            }

            public override Field.Builder MergeFrom(Field other)
            {
                if (other != Field.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasKey)
                    {
                        this.MergeKey(other.Key);
                    }
                    if (other.HasValue)
                    {
                        this.MergeValue(other.Value);
                    }
                }
                return this;
            }

            public override Field.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override Field.Builder MergeFrom(IMessageLite other)
            {
                if (other is Field)
                {
                    return this.MergeFrom((Field) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override Field.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(Field._fieldFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = Field._fieldFieldTags[index];
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
                            FieldKey.Builder builder = FieldKey.CreateBuilder();
                            if (this.result.hasKey)
                            {
                                builder.MergeFrom(this.Key);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.Key = builder.BuildPartial();
                            continue;
                        }
                        case 0x12:
                        {
                            bnet.protocol.attribute.Variant.Builder builder2 = bnet.protocol.attribute.Variant.CreateBuilder();
                            if (this.result.hasValue)
                            {
                                builder2.MergeFrom(this.Value);
                            }
                            input.ReadMessage(builder2, extensionRegistry);
                            this.Value = builder2.BuildPartial();
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

            public Field.Builder MergeKey(FieldKey value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasKey && (this.result.key_ != FieldKey.DefaultInstance))
                {
                    this.result.key_ = FieldKey.CreateBuilder(this.result.key_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.key_ = value;
                }
                this.result.hasKey = true;
                return this;
            }

            public Field.Builder MergeValue(bnet.protocol.attribute.Variant value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasValue && (this.result.value_ != bnet.protocol.attribute.Variant.DefaultInstance))
                {
                    this.result.value_ = bnet.protocol.attribute.Variant.CreateBuilder(this.result.value_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.value_ = value;
                }
                this.result.hasValue = true;
                return this;
            }

            private Field PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    Field result = this.result;
                    this.result = new Field();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public Field.Builder SetKey(FieldKey value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasKey = true;
                this.result.key_ = value;
                return this;
            }

            public Field.Builder SetKey(FieldKey.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasKey = true;
                this.result.key_ = builderForValue.Build();
                return this;
            }

            public Field.Builder SetValue(bnet.protocol.attribute.Variant value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasValue = true;
                this.result.value_ = value;
                return this;
            }

            public Field.Builder SetValue(bnet.protocol.attribute.Variant.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasValue = true;
                this.result.value_ = builderForValue.Build();
                return this;
            }

            public override Field DefaultInstanceForType
            {
                get
                {
                    return Field.DefaultInstance;
                }
            }

            public bool HasKey
            {
                get
                {
                    return this.result.hasKey;
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

            public FieldKey Key
            {
                get
                {
                    return this.result.Key;
                }
                set
                {
                    this.SetKey(value);
                }
            }

            protected override Field MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override Field.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public bnet.protocol.attribute.Variant Value
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

