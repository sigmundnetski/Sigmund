namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class Message : GeneratedMessageLite<Message, Builder>
    {
        private static readonly string[] _messageFieldNames = new string[] { "msg" };
        private static readonly uint[] _messageFieldTags = new uint[] { 10 };
        private static readonly Message defaultInstance = new Message().MakeReadOnly();
        private bool hasMsg;
        private int memoizedSerializedSize = -1;
        private string msg_ = string.Empty;
        public const int MsgFieldNumber = 1;

        static Message()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private Message()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(Message prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            Message message = obj as Message;
            if (message == null)
            {
                return false;
            }
            return ((this.hasMsg == message.hasMsg) && (!this.hasMsg || this.msg_.Equals(message.msg_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasMsg)
            {
                hashCode ^= this.msg_.GetHashCode();
            }
            return hashCode;
        }

        private Message MakeReadOnly()
        {
            return this;
        }

        public static Message ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static Message ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static Message ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Message ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Message ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Message ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Message ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static Message ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Message ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Message ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<Message, Builder>.PrintField("msg", this.hasMsg, this.msg_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _messageFieldNames;
            if (this.hasMsg)
            {
                output.WriteString(1, strArray[0], this.Msg);
            }
        }

        public static Message DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override Message DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasMsg
        {
            get
            {
                return this.hasMsg;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasMsg)
                {
                    return false;
                }
                return true;
            }
        }

        public string Msg
        {
            get
            {
                return this.msg_;
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
                    if (this.hasMsg)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(1, this.Msg);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override Message ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<Message, Message.Builder>
        {
            private Message result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = Message.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(Message cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override Message BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override Message.Builder Clear()
            {
                this.result = Message.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public Message.Builder ClearMsg()
            {
                this.PrepareBuilder();
                this.result.hasMsg = false;
                this.result.msg_ = string.Empty;
                return this;
            }

            public override Message.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new Message.Builder(this.result);
                }
                return new Message.Builder().MergeFrom(this.result);
            }

            public override Message.Builder MergeFrom(Message other)
            {
                if (other != Message.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasMsg)
                    {
                        this.Msg = other.Msg;
                    }
                }
                return this;
            }

            public override Message.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override Message.Builder MergeFrom(IMessageLite other)
            {
                if (other is Message)
                {
                    return this.MergeFrom((Message) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override Message.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(Message._messageFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = Message._messageFieldTags[index];
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
                    this.result.hasMsg = input.ReadString(ref this.result.msg_);
                }
                return this;
            }

            private Message PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    Message result = this.result;
                    this.result = new Message();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public Message.Builder SetMsg(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasMsg = true;
                this.result.msg_ = value;
                return this;
            }

            public override Message DefaultInstanceForType
            {
                get
                {
                    return Message.DefaultInstance;
                }
            }

            public bool HasMsg
            {
                get
                {
                    return this.result.hasMsg;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override Message MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public string Msg
            {
                get
                {
                    return this.result.Msg;
                }
                set
                {
                    this.SetMsg(value);
                }
            }

            protected override Message.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0x7e
            }
        }
    }
}

