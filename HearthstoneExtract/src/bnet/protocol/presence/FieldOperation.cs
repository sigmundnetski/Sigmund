namespace bnet.protocol.presence
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class FieldOperation : GeneratedMessageLite<FieldOperation, Builder>
    {
        private static readonly string[] _fieldOperationFieldNames = new string[] { "field", "operation" };
        private static readonly uint[] _fieldOperationFieldTags = new uint[] { 10, 0x10 };
        private static readonly FieldOperation defaultInstance = new FieldOperation().MakeReadOnly();
        private bnet.protocol.presence.Field field_;
        public const int FieldFieldNumber = 1;
        private bool hasField;
        private bool hasOperation;
        private int memoizedSerializedSize = -1;
        private Types.OperationType operation_;
        public const int OperationFieldNumber = 2;

        static FieldOperation()
        {
            object.ReferenceEquals(PresenceTypes.Descriptor, null);
        }

        private FieldOperation()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(FieldOperation prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            FieldOperation operation = obj as FieldOperation;
            if (operation == null)
            {
                return false;
            }
            if ((this.hasField != operation.hasField) || (this.hasField && !this.field_.Equals(operation.field_)))
            {
                return false;
            }
            return ((this.hasOperation == operation.hasOperation) && (!this.hasOperation || this.operation_.Equals(operation.operation_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasField)
            {
                hashCode ^= this.field_.GetHashCode();
            }
            if (this.hasOperation)
            {
                hashCode ^= this.operation_.GetHashCode();
            }
            return hashCode;
        }

        private FieldOperation MakeReadOnly()
        {
            return this;
        }

        public static FieldOperation ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static FieldOperation ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static FieldOperation ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static FieldOperation ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static FieldOperation ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static FieldOperation ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static FieldOperation ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static FieldOperation ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static FieldOperation ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static FieldOperation ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<FieldOperation, Builder>.PrintField("field", this.hasField, this.field_, writer);
            GeneratedMessageLite<FieldOperation, Builder>.PrintField("operation", this.hasOperation, this.operation_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _fieldOperationFieldNames;
            if (this.hasField)
            {
                output.WriteMessage(1, strArray[0], this.Field);
            }
            if (this.hasOperation)
            {
                output.WriteEnum(2, strArray[1], (int) this.Operation, this.Operation);
            }
        }

        public static FieldOperation DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override FieldOperation DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bnet.protocol.presence.Field Field
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.field_ != null)
                {
                    goto Label_0012;
                }
                return bnet.protocol.presence.Field.DefaultInstance;
            }
        }

        public bool HasField
        {
            get
            {
                return this.hasField;
            }
        }

        public bool HasOperation
        {
            get
            {
                return this.hasOperation;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasField)
                {
                    return false;
                }
                if (!this.Field.IsInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        public Types.OperationType Operation
        {
            get
            {
                return this.operation_;
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
                    if (this.hasField)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.Field);
                    }
                    if (this.hasOperation)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeEnumSize(2, (int) this.Operation);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override FieldOperation ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<FieldOperation, FieldOperation.Builder>
        {
            private FieldOperation result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = FieldOperation.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(FieldOperation cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override FieldOperation BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override FieldOperation.Builder Clear()
            {
                this.result = FieldOperation.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public FieldOperation.Builder ClearField()
            {
                this.PrepareBuilder();
                this.result.hasField = false;
                this.result.field_ = null;
                return this;
            }

            public FieldOperation.Builder ClearOperation()
            {
                this.PrepareBuilder();
                this.result.hasOperation = false;
                this.result.operation_ = FieldOperation.Types.OperationType.SET;
                return this;
            }

            public override FieldOperation.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new FieldOperation.Builder(this.result);
                }
                return new FieldOperation.Builder().MergeFrom(this.result);
            }

            public FieldOperation.Builder MergeField(bnet.protocol.presence.Field value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasField && (this.result.field_ != bnet.protocol.presence.Field.DefaultInstance))
                {
                    this.result.field_ = bnet.protocol.presence.Field.CreateBuilder(this.result.field_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.field_ = value;
                }
                this.result.hasField = true;
                return this;
            }

            public override FieldOperation.Builder MergeFrom(FieldOperation other)
            {
                if (other != FieldOperation.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasField)
                    {
                        this.MergeField(other.Field);
                    }
                    if (other.HasOperation)
                    {
                        this.Operation = other.Operation;
                    }
                }
                return this;
            }

            public override FieldOperation.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override FieldOperation.Builder MergeFrom(IMessageLite other)
            {
                if (other is FieldOperation)
                {
                    return this.MergeFrom((FieldOperation) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override FieldOperation.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    object obj2;
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(FieldOperation._fieldOperationFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = FieldOperation._fieldOperationFieldTags[index];
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
                            bnet.protocol.presence.Field.Builder builder = bnet.protocol.presence.Field.CreateBuilder();
                            if (this.result.hasField)
                            {
                                builder.MergeFrom(this.Field);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.Field = builder.BuildPartial();
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
                    if (input.ReadEnum<FieldOperation.Types.OperationType>(ref this.result.operation_, out obj2))
                    {
                        this.result.hasOperation = true;
                    }
                    else if (!(obj2 is int))
                    {
                        continue;
                    }
                }
                return this;
            }

            private FieldOperation PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    FieldOperation result = this.result;
                    this.result = new FieldOperation();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public FieldOperation.Builder SetField(bnet.protocol.presence.Field value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasField = true;
                this.result.field_ = value;
                return this;
            }

            public FieldOperation.Builder SetField(bnet.protocol.presence.Field.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasField = true;
                this.result.field_ = builderForValue.Build();
                return this;
            }

            public FieldOperation.Builder SetOperation(FieldOperation.Types.OperationType value)
            {
                this.PrepareBuilder();
                this.result.hasOperation = true;
                this.result.operation_ = value;
                return this;
            }

            public override FieldOperation DefaultInstanceForType
            {
                get
                {
                    return FieldOperation.DefaultInstance;
                }
            }

            public bnet.protocol.presence.Field Field
            {
                get
                {
                    return this.result.Field;
                }
                set
                {
                    this.SetField(value);
                }
            }

            public bool HasField
            {
                get
                {
                    return this.result.hasField;
                }
            }

            public bool HasOperation
            {
                get
                {
                    return this.result.hasOperation;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override FieldOperation MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public FieldOperation.Types.OperationType Operation
            {
                get
                {
                    return this.result.Operation;
                }
                set
                {
                    this.SetOperation(value);
                }
            }

            protected override FieldOperation.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum OperationType
            {
                SET,
                CLEAR
            }
        }
    }
}

