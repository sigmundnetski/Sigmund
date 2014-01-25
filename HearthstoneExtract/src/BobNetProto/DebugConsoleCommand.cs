namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class DebugConsoleCommand : GeneratedMessageLite<DebugConsoleCommand, Builder>
    {
        private static readonly string[] _debugConsoleCommandFieldNames = new string[] { "command" };
        private static readonly uint[] _debugConsoleCommandFieldTags = new uint[] { 10 };
        private string command_ = string.Empty;
        public const int CommandFieldNumber = 1;
        private static readonly DebugConsoleCommand defaultInstance = new DebugConsoleCommand().MakeReadOnly();
        private bool hasCommand;
        private int memoizedSerializedSize = -1;

        static DebugConsoleCommand()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private DebugConsoleCommand()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DebugConsoleCommand prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DebugConsoleCommand command = obj as DebugConsoleCommand;
            if (command == null)
            {
                return false;
            }
            return ((this.hasCommand == command.hasCommand) && (!this.hasCommand || this.command_.Equals(command.command_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasCommand)
            {
                hashCode ^= this.command_.GetHashCode();
            }
            return hashCode;
        }

        private DebugConsoleCommand MakeReadOnly()
        {
            return this;
        }

        public static DebugConsoleCommand ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DebugConsoleCommand ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DebugConsoleCommand ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DebugConsoleCommand ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DebugConsoleCommand ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DebugConsoleCommand ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DebugConsoleCommand ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DebugConsoleCommand ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DebugConsoleCommand ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DebugConsoleCommand ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DebugConsoleCommand, Builder>.PrintField("command", this.hasCommand, this.command_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _debugConsoleCommandFieldNames;
            if (this.hasCommand)
            {
                output.WriteString(1, strArray[0], this.Command);
            }
        }

        public string Command
        {
            get
            {
                return this.command_;
            }
        }

        public static DebugConsoleCommand DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DebugConsoleCommand DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasCommand
        {
            get
            {
                return this.hasCommand;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasCommand)
                {
                    return false;
                }
                return true;
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
                    if (this.hasCommand)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(1, this.Command);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override DebugConsoleCommand ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<DebugConsoleCommand, DebugConsoleCommand.Builder>
        {
            private DebugConsoleCommand result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DebugConsoleCommand.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DebugConsoleCommand cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override DebugConsoleCommand BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DebugConsoleCommand.Builder Clear()
            {
                this.result = DebugConsoleCommand.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DebugConsoleCommand.Builder ClearCommand()
            {
                this.PrepareBuilder();
                this.result.hasCommand = false;
                this.result.command_ = string.Empty;
                return this;
            }

            public override DebugConsoleCommand.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DebugConsoleCommand.Builder(this.result);
                }
                return new DebugConsoleCommand.Builder().MergeFrom(this.result);
            }

            public override DebugConsoleCommand.Builder MergeFrom(DebugConsoleCommand other)
            {
                if (other != DebugConsoleCommand.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasCommand)
                    {
                        this.Command = other.Command;
                    }
                }
                return this;
            }

            public override DebugConsoleCommand.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DebugConsoleCommand.Builder MergeFrom(IMessageLite other)
            {
                if (other is DebugConsoleCommand)
                {
                    return this.MergeFrom((DebugConsoleCommand) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DebugConsoleCommand.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DebugConsoleCommand._debugConsoleCommandFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DebugConsoleCommand._debugConsoleCommandFieldTags[index];
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
                    this.result.hasCommand = input.ReadString(ref this.result.command_);
                }
                return this;
            }

            private DebugConsoleCommand PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DebugConsoleCommand result = this.result;
                    this.result = new DebugConsoleCommand();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DebugConsoleCommand.Builder SetCommand(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasCommand = true;
                this.result.command_ = value;
                return this;
            }

            public string Command
            {
                get
                {
                    return this.result.Command;
                }
                set
                {
                    this.SetCommand(value);
                }
            }

            public override DebugConsoleCommand DefaultInstanceForType
            {
                get
                {
                    return DebugConsoleCommand.DefaultInstance;
                }
            }

            public bool HasCommand
            {
                get
                {
                    return this.result.hasCommand;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override DebugConsoleCommand MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override DebugConsoleCommand.Builder ThisBuilder
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
                ID = 0x7b
            }
        }
    }
}

