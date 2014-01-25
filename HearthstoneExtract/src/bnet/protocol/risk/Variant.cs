namespace bnet.protocol.risk
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class Variant : GeneratedMessageLite<bnet.protocol.risk.Variant, Builder>
    {
        private static readonly string[] _variantFieldNames = new string[] { "blob_value", "bool_value", "entityid_value", "float_value", "fourcc_value", "int_value", "message_value", "string_value", "uint_value" };
        private static readonly uint[] _variantFieldTags = new uint[] { 50, 0x10, 0x52, 0x21, 0x42, 0x18, 0x3a, 0x2a, 0x48 };
        private ByteString blobValue_ = ByteString.Empty;
        public const int BlobValueFieldNumber = 6;
        private bool boolValue_;
        public const int BoolValueFieldNumber = 2;
        private static readonly bnet.protocol.risk.Variant defaultInstance = new bnet.protocol.risk.Variant().MakeReadOnly();
        private EntityId entityidValue_;
        public const int EntityidValueFieldNumber = 10;
        private double floatValue_;
        public const int FloatValueFieldNumber = 4;
        private string fourccValue_ = string.Empty;
        public const int FourccValueFieldNumber = 8;
        private bool hasBlobValue;
        private bool hasBoolValue;
        private bool hasEntityidValue;
        private bool hasFloatValue;
        private bool hasFourccValue;
        private bool hasIntValue;
        private bool hasMessageValue;
        private bool hasStringValue;
        private bool hasUintValue;
        private long intValue_;
        public const int IntValueFieldNumber = 3;
        private int memoizedSerializedSize = -1;
        private ByteString messageValue_ = ByteString.Empty;
        public const int MessageValueFieldNumber = 7;
        private string stringValue_ = string.Empty;
        public const int StringValueFieldNumber = 5;
        private ulong uintValue_;
        public const int UintValueFieldNumber = 9;

        static Variant()
        {
            object.ReferenceEquals(Throttle.Descriptor, null);
        }

        private Variant()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(bnet.protocol.risk.Variant prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            bnet.protocol.risk.Variant variant = obj as bnet.protocol.risk.Variant;
            if (variant == null)
            {
                return false;
            }
            if ((this.hasBoolValue != variant.hasBoolValue) || (this.hasBoolValue && !this.boolValue_.Equals(variant.boolValue_)))
            {
                return false;
            }
            if ((this.hasIntValue != variant.hasIntValue) || (this.hasIntValue && !this.intValue_.Equals(variant.intValue_)))
            {
                return false;
            }
            if ((this.hasFloatValue != variant.hasFloatValue) || (this.hasFloatValue && !this.floatValue_.Equals(variant.floatValue_)))
            {
                return false;
            }
            if ((this.hasStringValue != variant.hasStringValue) || (this.hasStringValue && !this.stringValue_.Equals(variant.stringValue_)))
            {
                return false;
            }
            if ((this.hasBlobValue != variant.hasBlobValue) || (this.hasBlobValue && !this.blobValue_.Equals(variant.blobValue_)))
            {
                return false;
            }
            if ((this.hasMessageValue != variant.hasMessageValue) || (this.hasMessageValue && !this.messageValue_.Equals(variant.messageValue_)))
            {
                return false;
            }
            if ((this.hasFourccValue != variant.hasFourccValue) || (this.hasFourccValue && !this.fourccValue_.Equals(variant.fourccValue_)))
            {
                return false;
            }
            if ((this.hasUintValue != variant.hasUintValue) || (this.hasUintValue && !this.uintValue_.Equals(variant.uintValue_)))
            {
                return false;
            }
            return ((this.hasEntityidValue == variant.hasEntityidValue) && (!this.hasEntityidValue || this.entityidValue_.Equals(variant.entityidValue_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasBoolValue)
            {
                hashCode ^= this.boolValue_.GetHashCode();
            }
            if (this.hasIntValue)
            {
                hashCode ^= this.intValue_.GetHashCode();
            }
            if (this.hasFloatValue)
            {
                hashCode ^= this.floatValue_.GetHashCode();
            }
            if (this.hasStringValue)
            {
                hashCode ^= this.stringValue_.GetHashCode();
            }
            if (this.hasBlobValue)
            {
                hashCode ^= this.blobValue_.GetHashCode();
            }
            if (this.hasMessageValue)
            {
                hashCode ^= this.messageValue_.GetHashCode();
            }
            if (this.hasFourccValue)
            {
                hashCode ^= this.fourccValue_.GetHashCode();
            }
            if (this.hasUintValue)
            {
                hashCode ^= this.uintValue_.GetHashCode();
            }
            if (this.hasEntityidValue)
            {
                hashCode ^= this.entityidValue_.GetHashCode();
            }
            return hashCode;
        }

        private bnet.protocol.risk.Variant MakeReadOnly()
        {
            return this;
        }

        public static bnet.protocol.risk.Variant ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static bnet.protocol.risk.Variant ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static bnet.protocol.risk.Variant ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static bnet.protocol.risk.Variant ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static bnet.protocol.risk.Variant ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static bnet.protocol.risk.Variant ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static bnet.protocol.risk.Variant ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static bnet.protocol.risk.Variant ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static bnet.protocol.risk.Variant ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static bnet.protocol.risk.Variant ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<bnet.protocol.risk.Variant, Builder>.PrintField("bool_value", this.hasBoolValue, this.boolValue_, writer);
            GeneratedMessageLite<bnet.protocol.risk.Variant, Builder>.PrintField("int_value", this.hasIntValue, this.intValue_, writer);
            GeneratedMessageLite<bnet.protocol.risk.Variant, Builder>.PrintField("float_value", this.hasFloatValue, this.floatValue_, writer);
            GeneratedMessageLite<bnet.protocol.risk.Variant, Builder>.PrintField("string_value", this.hasStringValue, this.stringValue_, writer);
            GeneratedMessageLite<bnet.protocol.risk.Variant, Builder>.PrintField("blob_value", this.hasBlobValue, this.blobValue_, writer);
            GeneratedMessageLite<bnet.protocol.risk.Variant, Builder>.PrintField("message_value", this.hasMessageValue, this.messageValue_, writer);
            GeneratedMessageLite<bnet.protocol.risk.Variant, Builder>.PrintField("fourcc_value", this.hasFourccValue, this.fourccValue_, writer);
            GeneratedMessageLite<bnet.protocol.risk.Variant, Builder>.PrintField("uint_value", this.hasUintValue, this.uintValue_, writer);
            GeneratedMessageLite<bnet.protocol.risk.Variant, Builder>.PrintField("entityid_value", this.hasEntityidValue, this.entityidValue_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _variantFieldNames;
            if (this.hasBoolValue)
            {
                output.WriteBool(2, strArray[1], this.BoolValue);
            }
            if (this.hasIntValue)
            {
                output.WriteInt64(3, strArray[5], this.IntValue);
            }
            if (this.hasFloatValue)
            {
                output.WriteDouble(4, strArray[3], this.FloatValue);
            }
            if (this.hasStringValue)
            {
                output.WriteString(5, strArray[7], this.StringValue);
            }
            if (this.hasBlobValue)
            {
                output.WriteBytes(6, strArray[0], this.BlobValue);
            }
            if (this.hasMessageValue)
            {
                output.WriteBytes(7, strArray[6], this.MessageValue);
            }
            if (this.hasFourccValue)
            {
                output.WriteString(8, strArray[4], this.FourccValue);
            }
            if (this.hasUintValue)
            {
                output.WriteUInt64(9, strArray[8], this.UintValue);
            }
            if (this.hasEntityidValue)
            {
                output.WriteMessage(10, strArray[2], this.EntityidValue);
            }
        }

        public ByteString BlobValue
        {
            get
            {
                return this.blobValue_;
            }
        }

        public bool BoolValue
        {
            get
            {
                return this.boolValue_;
            }
        }

        public static bnet.protocol.risk.Variant DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override bnet.protocol.risk.Variant DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public EntityId EntityidValue
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.entityidValue_ != null)
                {
                    goto Label_0012;
                }
                return EntityId.DefaultInstance;
            }
        }

        public double FloatValue
        {
            get
            {
                return this.floatValue_;
            }
        }

        public string FourccValue
        {
            get
            {
                return this.fourccValue_;
            }
        }

        public bool HasBlobValue
        {
            get
            {
                return this.hasBlobValue;
            }
        }

        public bool HasBoolValue
        {
            get
            {
                return this.hasBoolValue;
            }
        }

        public bool HasEntityidValue
        {
            get
            {
                return this.hasEntityidValue;
            }
        }

        public bool HasFloatValue
        {
            get
            {
                return this.hasFloatValue;
            }
        }

        public bool HasFourccValue
        {
            get
            {
                return this.hasFourccValue;
            }
        }

        public bool HasIntValue
        {
            get
            {
                return this.hasIntValue;
            }
        }

        public bool HasMessageValue
        {
            get
            {
                return this.hasMessageValue;
            }
        }

        public bool HasStringValue
        {
            get
            {
                return this.hasStringValue;
            }
        }

        public bool HasUintValue
        {
            get
            {
                return this.hasUintValue;
            }
        }

        public long IntValue
        {
            get
            {
                return this.intValue_;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (this.HasEntityidValue && !this.EntityidValue.IsInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        public ByteString MessageValue
        {
            get
            {
                return this.messageValue_;
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
                    if (this.hasBoolValue)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(2, this.BoolValue);
                    }
                    if (this.hasIntValue)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(3, this.IntValue);
                    }
                    if (this.hasFloatValue)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeDoubleSize(4, this.FloatValue);
                    }
                    if (this.hasStringValue)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(5, this.StringValue);
                    }
                    if (this.hasBlobValue)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBytesSize(6, this.BlobValue);
                    }
                    if (this.hasMessageValue)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBytesSize(7, this.MessageValue);
                    }
                    if (this.hasFourccValue)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(8, this.FourccValue);
                    }
                    if (this.hasUintValue)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(9, this.UintValue);
                    }
                    if (this.hasEntityidValue)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(10, this.EntityidValue);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        public string StringValue
        {
            get
            {
                return this.stringValue_;
            }
        }

        protected override bnet.protocol.risk.Variant ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CLSCompliant(false)]
        public ulong UintValue
        {
            get
            {
                return this.uintValue_;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<bnet.protocol.risk.Variant, bnet.protocol.risk.Variant.Builder>
        {
            private bnet.protocol.risk.Variant result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = bnet.protocol.risk.Variant.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(bnet.protocol.risk.Variant cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override bnet.protocol.risk.Variant BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override bnet.protocol.risk.Variant.Builder Clear()
            {
                this.result = bnet.protocol.risk.Variant.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public bnet.protocol.risk.Variant.Builder ClearBlobValue()
            {
                this.PrepareBuilder();
                this.result.hasBlobValue = false;
                this.result.blobValue_ = ByteString.Empty;
                return this;
            }

            public bnet.protocol.risk.Variant.Builder ClearBoolValue()
            {
                this.PrepareBuilder();
                this.result.hasBoolValue = false;
                this.result.boolValue_ = false;
                return this;
            }

            public bnet.protocol.risk.Variant.Builder ClearEntityidValue()
            {
                this.PrepareBuilder();
                this.result.hasEntityidValue = false;
                this.result.entityidValue_ = null;
                return this;
            }

            public bnet.protocol.risk.Variant.Builder ClearFloatValue()
            {
                this.PrepareBuilder();
                this.result.hasFloatValue = false;
                this.result.floatValue_ = 0.0;
                return this;
            }

            public bnet.protocol.risk.Variant.Builder ClearFourccValue()
            {
                this.PrepareBuilder();
                this.result.hasFourccValue = false;
                this.result.fourccValue_ = string.Empty;
                return this;
            }

            public bnet.protocol.risk.Variant.Builder ClearIntValue()
            {
                this.PrepareBuilder();
                this.result.hasIntValue = false;
                this.result.intValue_ = 0L;
                return this;
            }

            public bnet.protocol.risk.Variant.Builder ClearMessageValue()
            {
                this.PrepareBuilder();
                this.result.hasMessageValue = false;
                this.result.messageValue_ = ByteString.Empty;
                return this;
            }

            public bnet.protocol.risk.Variant.Builder ClearStringValue()
            {
                this.PrepareBuilder();
                this.result.hasStringValue = false;
                this.result.stringValue_ = string.Empty;
                return this;
            }

            public bnet.protocol.risk.Variant.Builder ClearUintValue()
            {
                this.PrepareBuilder();
                this.result.hasUintValue = false;
                this.result.uintValue_ = 0L;
                return this;
            }

            public override bnet.protocol.risk.Variant.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new bnet.protocol.risk.Variant.Builder(this.result);
                }
                return new bnet.protocol.risk.Variant.Builder().MergeFrom(this.result);
            }

            public bnet.protocol.risk.Variant.Builder MergeEntityidValue(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasEntityidValue && (this.result.entityidValue_ != EntityId.DefaultInstance))
                {
                    this.result.entityidValue_ = EntityId.CreateBuilder(this.result.entityidValue_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.entityidValue_ = value;
                }
                this.result.hasEntityidValue = true;
                return this;
            }

            public override bnet.protocol.risk.Variant.Builder MergeFrom(bnet.protocol.risk.Variant other)
            {
                if (other != bnet.protocol.risk.Variant.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasBoolValue)
                    {
                        this.BoolValue = other.BoolValue;
                    }
                    if (other.HasIntValue)
                    {
                        this.IntValue = other.IntValue;
                    }
                    if (other.HasFloatValue)
                    {
                        this.FloatValue = other.FloatValue;
                    }
                    if (other.HasStringValue)
                    {
                        this.StringValue = other.StringValue;
                    }
                    if (other.HasBlobValue)
                    {
                        this.BlobValue = other.BlobValue;
                    }
                    if (other.HasMessageValue)
                    {
                        this.MessageValue = other.MessageValue;
                    }
                    if (other.HasFourccValue)
                    {
                        this.FourccValue = other.FourccValue;
                    }
                    if (other.HasUintValue)
                    {
                        this.UintValue = other.UintValue;
                    }
                    if (other.HasEntityidValue)
                    {
                        this.MergeEntityidValue(other.EntityidValue);
                    }
                }
                return this;
            }

            public override bnet.protocol.risk.Variant.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override bnet.protocol.risk.Variant.Builder MergeFrom(IMessageLite other)
            {
                if (other is bnet.protocol.risk.Variant)
                {
                    return this.MergeFrom((bnet.protocol.risk.Variant) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override bnet.protocol.risk.Variant.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(bnet.protocol.risk.Variant._variantFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = bnet.protocol.risk.Variant._variantFieldTags[index];
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

                        case 0x10:
                        {
                            this.result.hasBoolValue = input.ReadBool(ref this.result.boolValue_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasIntValue = input.ReadInt64(ref this.result.intValue_);
                            continue;
                        }
                        case 0x21:
                        {
                            this.result.hasFloatValue = input.ReadDouble(ref this.result.floatValue_);
                            continue;
                        }
                        case 0x2a:
                        {
                            this.result.hasStringValue = input.ReadString(ref this.result.stringValue_);
                            continue;
                        }
                        case 50:
                        {
                            this.result.hasBlobValue = input.ReadBytes(ref this.result.blobValue_);
                            continue;
                        }
                        case 0x3a:
                        {
                            this.result.hasMessageValue = input.ReadBytes(ref this.result.messageValue_);
                            continue;
                        }
                        case 0x42:
                        {
                            this.result.hasFourccValue = input.ReadString(ref this.result.fourccValue_);
                            continue;
                        }
                        case 0x48:
                        {
                            this.result.hasUintValue = input.ReadUInt64(ref this.result.uintValue_);
                            continue;
                        }
                        case 0x52:
                        {
                            EntityId.Builder builder = EntityId.CreateBuilder();
                            if (this.result.hasEntityidValue)
                            {
                                builder.MergeFrom(this.EntityidValue);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.EntityidValue = builder.BuildPartial();
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

            private bnet.protocol.risk.Variant PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    bnet.protocol.risk.Variant result = this.result;
                    this.result = new bnet.protocol.risk.Variant();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public bnet.protocol.risk.Variant.Builder SetBlobValue(ByteString value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasBlobValue = true;
                this.result.blobValue_ = value;
                return this;
            }

            public bnet.protocol.risk.Variant.Builder SetBoolValue(bool value)
            {
                this.PrepareBuilder();
                this.result.hasBoolValue = true;
                this.result.boolValue_ = value;
                return this;
            }

            public bnet.protocol.risk.Variant.Builder SetEntityidValue(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasEntityidValue = true;
                this.result.entityidValue_ = value;
                return this;
            }

            public bnet.protocol.risk.Variant.Builder SetEntityidValue(EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasEntityidValue = true;
                this.result.entityidValue_ = builderForValue.Build();
                return this;
            }

            public bnet.protocol.risk.Variant.Builder SetFloatValue(double value)
            {
                this.PrepareBuilder();
                this.result.hasFloatValue = true;
                this.result.floatValue_ = value;
                return this;
            }

            public bnet.protocol.risk.Variant.Builder SetFourccValue(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasFourccValue = true;
                this.result.fourccValue_ = value;
                return this;
            }

            public bnet.protocol.risk.Variant.Builder SetIntValue(long value)
            {
                this.PrepareBuilder();
                this.result.hasIntValue = true;
                this.result.intValue_ = value;
                return this;
            }

            public bnet.protocol.risk.Variant.Builder SetMessageValue(ByteString value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasMessageValue = true;
                this.result.messageValue_ = value;
                return this;
            }

            public bnet.protocol.risk.Variant.Builder SetStringValue(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasStringValue = true;
                this.result.stringValue_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public bnet.protocol.risk.Variant.Builder SetUintValue(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasUintValue = true;
                this.result.uintValue_ = value;
                return this;
            }

            public ByteString BlobValue
            {
                get
                {
                    return this.result.BlobValue;
                }
                set
                {
                    this.SetBlobValue(value);
                }
            }

            public bool BoolValue
            {
                get
                {
                    return this.result.BoolValue;
                }
                set
                {
                    this.SetBoolValue(value);
                }
            }

            public override bnet.protocol.risk.Variant DefaultInstanceForType
            {
                get
                {
                    return bnet.protocol.risk.Variant.DefaultInstance;
                }
            }

            public EntityId EntityidValue
            {
                get
                {
                    return this.result.EntityidValue;
                }
                set
                {
                    this.SetEntityidValue(value);
                }
            }

            public double FloatValue
            {
                get
                {
                    return this.result.FloatValue;
                }
                set
                {
                    this.SetFloatValue(value);
                }
            }

            public string FourccValue
            {
                get
                {
                    return this.result.FourccValue;
                }
                set
                {
                    this.SetFourccValue(value);
                }
            }

            public bool HasBlobValue
            {
                get
                {
                    return this.result.hasBlobValue;
                }
            }

            public bool HasBoolValue
            {
                get
                {
                    return this.result.hasBoolValue;
                }
            }

            public bool HasEntityidValue
            {
                get
                {
                    return this.result.hasEntityidValue;
                }
            }

            public bool HasFloatValue
            {
                get
                {
                    return this.result.hasFloatValue;
                }
            }

            public bool HasFourccValue
            {
                get
                {
                    return this.result.hasFourccValue;
                }
            }

            public bool HasIntValue
            {
                get
                {
                    return this.result.hasIntValue;
                }
            }

            public bool HasMessageValue
            {
                get
                {
                    return this.result.hasMessageValue;
                }
            }

            public bool HasStringValue
            {
                get
                {
                    return this.result.hasStringValue;
                }
            }

            public bool HasUintValue
            {
                get
                {
                    return this.result.hasUintValue;
                }
            }

            public long IntValue
            {
                get
                {
                    return this.result.IntValue;
                }
                set
                {
                    this.SetIntValue(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override bnet.protocol.risk.Variant MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public ByteString MessageValue
            {
                get
                {
                    return this.result.MessageValue;
                }
                set
                {
                    this.SetMessageValue(value);
                }
            }

            public string StringValue
            {
                get
                {
                    return this.result.StringValue;
                }
                set
                {
                    this.SetStringValue(value);
                }
            }

            protected override bnet.protocol.risk.Variant.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            [CLSCompliant(false)]
            public ulong UintValue
            {
                get
                {
                    return this.result.UintValue;
                }
                set
                {
                    this.SetUintValue(value);
                }
            }
        }
    }
}

