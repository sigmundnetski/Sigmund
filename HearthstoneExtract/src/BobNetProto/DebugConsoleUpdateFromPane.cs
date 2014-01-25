namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class DebugConsoleUpdateFromPane : GeneratedMessageLite<DebugConsoleUpdateFromPane, Builder>
    {
        private static readonly string[] _debugConsoleUpdateFromPaneFieldNames = new string[] { "name", "value" };
        private static readonly uint[] _debugConsoleUpdateFromPaneFieldTags = new uint[] { 10, 0x12 };
        private static readonly DebugConsoleUpdateFromPane defaultInstance = new DebugConsoleUpdateFromPane().MakeReadOnly();
        private bool hasName;
        private bool hasValue;
        private int memoizedSerializedSize = -1;
        private string name_ = string.Empty;
        public const int NameFieldNumber = 1;
        private string value_ = string.Empty;
        public const int ValueFieldNumber = 2;

        static DebugConsoleUpdateFromPane()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private DebugConsoleUpdateFromPane()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DebugConsoleUpdateFromPane prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DebugConsoleUpdateFromPane pane = obj as DebugConsoleUpdateFromPane;
            if (pane == null)
            {
                return false;
            }
            if ((this.hasName != pane.hasName) || (this.hasName && !this.name_.Equals(pane.name_)))
            {
                return false;
            }
            return ((this.hasValue == pane.hasValue) && (!this.hasValue || this.value_.Equals(pane.value_)));
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

        private DebugConsoleUpdateFromPane MakeReadOnly()
        {
            return this;
        }

        public static DebugConsoleUpdateFromPane ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DebugConsoleUpdateFromPane ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DebugConsoleUpdateFromPane ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DebugConsoleUpdateFromPane ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DebugConsoleUpdateFromPane ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DebugConsoleUpdateFromPane ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DebugConsoleUpdateFromPane ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DebugConsoleUpdateFromPane ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DebugConsoleUpdateFromPane ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DebugConsoleUpdateFromPane ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DebugConsoleUpdateFromPane, Builder>.PrintField("name", this.hasName, this.name_, writer);
            GeneratedMessageLite<DebugConsoleUpdateFromPane, Builder>.PrintField("value", this.hasValue, this.value_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _debugConsoleUpdateFromPaneFieldNames;
            if (this.hasName)
            {
                output.WriteString(1, strArray[0], this.Name);
            }
            if (this.hasValue)
            {
                output.WriteString(2, strArray[1], this.Value);
            }
        }

        public static DebugConsoleUpdateFromPane DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DebugConsoleUpdateFromPane DefaultInstanceForType
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
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(2, this.Value);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override DebugConsoleUpdateFromPane ThisMessage
        {
            get
            {
                return this;
            }
        }

        public string Value
        {
            get
            {
                return this.value_;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<DebugConsoleUpdateFromPane, DebugConsoleUpdateFromPane.Builder>
        {
            private DebugConsoleUpdateFromPane result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DebugConsoleUpdateFromPane.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DebugConsoleUpdateFromPane cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override DebugConsoleUpdateFromPane BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DebugConsoleUpdateFromPane.Builder Clear()
            {
                this.result = DebugConsoleUpdateFromPane.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DebugConsoleUpdateFromPane.Builder ClearName()
            {
                this.PrepareBuilder();
                this.result.hasName = false;
                this.result.name_ = string.Empty;
                return this;
            }

            public DebugConsoleUpdateFromPane.Builder ClearValue()
            {
                this.PrepareBuilder();
                this.result.hasValue = false;
                this.result.value_ = string.Empty;
                return this;
            }

            public override DebugConsoleUpdateFromPane.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DebugConsoleUpdateFromPane.Builder(this.result);
                }
                return new DebugConsoleUpdateFromPane.Builder().MergeFrom(this.result);
            }

            public override DebugConsoleUpdateFromPane.Builder MergeFrom(DebugConsoleUpdateFromPane other)
            {
                if (other != DebugConsoleUpdateFromPane.DefaultInstance)
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

            public override DebugConsoleUpdateFromPane.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DebugConsoleUpdateFromPane.Builder MergeFrom(IMessageLite other)
            {
                if (other is DebugConsoleUpdateFromPane)
                {
                    return this.MergeFrom((DebugConsoleUpdateFromPane) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DebugConsoleUpdateFromPane.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DebugConsoleUpdateFromPane._debugConsoleUpdateFromPaneFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DebugConsoleUpdateFromPane._debugConsoleUpdateFromPaneFieldTags[index];
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
                    this.result.hasValue = input.ReadString(ref this.result.value_);
                }
                return this;
            }

            private DebugConsoleUpdateFromPane PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DebugConsoleUpdateFromPane result = this.result;
                    this.result = new DebugConsoleUpdateFromPane();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DebugConsoleUpdateFromPane.Builder SetName(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasName = true;
                this.result.name_ = value;
                return this;
            }

            public DebugConsoleUpdateFromPane.Builder SetValue(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasValue = true;
                this.result.value_ = value;
                return this;
            }

            public override DebugConsoleUpdateFromPane DefaultInstanceForType
            {
                get
                {
                    return DebugConsoleUpdateFromPane.DefaultInstance;
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

            protected override DebugConsoleUpdateFromPane MessageBeingBuilt
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

            protected override DebugConsoleUpdateFromPane.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public string Value
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

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0x91
            }
        }
    }
}

