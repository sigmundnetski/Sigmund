namespace PegasusGame
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class DebugMessage : GeneratedMessageLite<DebugMessage, Builder>
    {
        private static readonly string[] _debugMessageFieldNames = new string[] { "message" };
        private static readonly uint[] _debugMessageFieldTags = new uint[] { 10 };
        private static readonly DebugMessage defaultInstance = new DebugMessage().MakeReadOnly();
        private bool hasMessage;
        private int memoizedSerializedSize = -1;
        private string message_ = string.Empty;
        public const int MessageFieldNumber = 1;

        static DebugMessage()
        {
            object.ReferenceEquals(PegasusGamelite.Descriptor, null);
        }

        private DebugMessage()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DebugMessage prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DebugMessage message = obj as DebugMessage;
            if (message == null)
            {
                return false;
            }
            return ((this.hasMessage == message.hasMessage) && (!this.hasMessage || this.message_.Equals(message.message_)));
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

        private DebugMessage MakeReadOnly()
        {
            return this;
        }

        public static DebugMessage ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DebugMessage ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DebugMessage ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DebugMessage ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DebugMessage ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DebugMessage ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DebugMessage ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DebugMessage ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DebugMessage ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DebugMessage ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DebugMessage, Builder>.PrintField("message", this.hasMessage, this.message_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _debugMessageFieldNames;
            if (this.hasMessage)
            {
                output.WriteString(1, strArray[0], this.Message);
            }
        }

        public static DebugMessage DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DebugMessage DefaultInstanceForType
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

        protected override DebugMessage ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<DebugMessage, DebugMessage.Builder>
        {
            private DebugMessage result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DebugMessage.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DebugMessage cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override DebugMessage BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DebugMessage.Builder Clear()
            {
                this.result = DebugMessage.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DebugMessage.Builder ClearMessage()
            {
                this.PrepareBuilder();
                this.result.hasMessage = false;
                this.result.message_ = string.Empty;
                return this;
            }

            public override DebugMessage.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DebugMessage.Builder(this.result);
                }
                return new DebugMessage.Builder().MergeFrom(this.result);
            }

            public override DebugMessage.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DebugMessage.Builder MergeFrom(IMessageLite other)
            {
                if (other is DebugMessage)
                {
                    return this.MergeFrom((DebugMessage) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DebugMessage.Builder MergeFrom(DebugMessage other)
            {
                if (other != DebugMessage.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasMessage)
                    {
                        this.Message = other.Message;
                    }
                }
                return this;
            }

            public override DebugMessage.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DebugMessage._debugMessageFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DebugMessage._debugMessageFieldTags[index];
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

            private DebugMessage PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DebugMessage result = this.result;
                    this.result = new DebugMessage();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DebugMessage.Builder SetMessage(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasMessage = true;
                this.result.message_ = value;
                return this;
            }

            public override DebugMessage DefaultInstanceForType
            {
                get
                {
                    return DebugMessage.DefaultInstance;
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

            protected override DebugMessage MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override DebugMessage.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 5
            }
        }
    }
}

