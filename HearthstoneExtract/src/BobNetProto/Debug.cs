namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class Debug : GeneratedMessageLite<BobNetProto.Debug, Builder>
    {
        private static readonly string[] _debugFieldNames = new string[] { "message" };
        private static readonly uint[] _debugFieldTags = new uint[] { 10 };
        private static readonly BobNetProto.Debug defaultInstance = new BobNetProto.Debug().MakeReadOnly();
        private bool hasMessage;
        private int memoizedSerializedSize = -1;
        private string message_ = string.Empty;
        public const int MessageFieldNumber = 1;

        static Debug()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private Debug()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(BobNetProto.Debug prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            BobNetProto.Debug debug = obj as BobNetProto.Debug;
            if (debug == null)
            {
                return false;
            }
            return ((this.hasMessage == debug.hasMessage) && (!this.hasMessage || this.message_.Equals(debug.message_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasMessage)
            {
                hashCode ^= this.message_.GetHashCode();
            }
            return hashCode;
        }

        private BobNetProto.Debug MakeReadOnly()
        {
            return this;
        }

        public static BobNetProto.Debug ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static BobNetProto.Debug ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static BobNetProto.Debug ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static BobNetProto.Debug ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static BobNetProto.Debug ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static BobNetProto.Debug ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static BobNetProto.Debug ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static BobNetProto.Debug ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static BobNetProto.Debug ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static BobNetProto.Debug ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<BobNetProto.Debug, Builder>.PrintField("message", this.hasMessage, this.message_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _debugFieldNames;
            if (this.hasMessage)
            {
                output.WriteString(1, strArray[0], this.Message);
            }
        }

        public static BobNetProto.Debug DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override BobNetProto.Debug DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasMessage
        {
            get
            {
                return this.hasMessage;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasMessage)
                {
                    return false;
                }
                return true;
            }
        }

        public string Message
        {
            get
            {
                return this.message_;
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
                    if (this.hasMessage)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(1, this.Message);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override BobNetProto.Debug ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<BobNetProto.Debug, BobNetProto.Debug.Builder>
        {
            private BobNetProto.Debug result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = BobNetProto.Debug.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(BobNetProto.Debug cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override BobNetProto.Debug BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override BobNetProto.Debug.Builder Clear()
            {
                this.result = BobNetProto.Debug.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public BobNetProto.Debug.Builder ClearMessage()
            {
                this.PrepareBuilder();
                this.result.hasMessage = false;
                this.result.message_ = string.Empty;
                return this;
            }

            public override BobNetProto.Debug.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new BobNetProto.Debug.Builder(this.result);
                }
                return new BobNetProto.Debug.Builder().MergeFrom(this.result);
            }

            public override BobNetProto.Debug.Builder MergeFrom(BobNetProto.Debug other)
            {
                if (other != BobNetProto.Debug.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasMessage)
                    {
                        this.Message = other.Message;
                    }
                }
                return this;
            }

            public override BobNetProto.Debug.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override BobNetProto.Debug.Builder MergeFrom(IMessageLite other)
            {
                if (other is BobNetProto.Debug)
                {
                    return this.MergeFrom((BobNetProto.Debug) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override BobNetProto.Debug.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(BobNetProto.Debug._debugFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = BobNetProto.Debug._debugFieldTags[index];
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
                    this.result.hasMessage = input.ReadString(ref this.result.message_);
                }
                return this;
            }

            private BobNetProto.Debug PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    BobNetProto.Debug result = this.result;
                    this.result = new BobNetProto.Debug();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public BobNetProto.Debug.Builder SetMessage(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasMessage = true;
                this.result.message_ = value;
                return this;
            }

            public override BobNetProto.Debug DefaultInstanceForType
            {
                get
                {
                    return BobNetProto.Debug.DefaultInstance;
                }
            }

            public bool HasMessage
            {
                get
                {
                    return this.result.hasMessage;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public string Message
            {
                get
                {
                    return this.result.Message;
                }
                set
                {
                    this.SetMessage(value);
                }
            }

            protected override BobNetProto.Debug MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override BobNetProto.Debug.Builder ThisBuilder
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
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0x65
            }
        }
    }
}

