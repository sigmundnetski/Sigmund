namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class DatabaseCommand : GeneratedMessageLite<DatabaseCommand, Builder>
    {
        private static readonly string[] _databaseCommandFieldNames = new string[] { "command" };
        private static readonly uint[] _databaseCommandFieldTags = new uint[] { 8 };
        private Types.TCommand command_ = Types.TCommand.GET_PROFILE;
        public const int CommandFieldNumber = 1;
        private static readonly DatabaseCommand defaultInstance = new DatabaseCommand().MakeReadOnly();
        private bool hasCommand;
        private int memoizedSerializedSize = -1;

        static DatabaseCommand()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private DatabaseCommand()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DatabaseCommand prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DatabaseCommand command = obj as DatabaseCommand;
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

        private DatabaseCommand MakeReadOnly()
        {
            return this;
        }

        public static DatabaseCommand ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DatabaseCommand ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DatabaseCommand ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DatabaseCommand ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DatabaseCommand ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DatabaseCommand ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DatabaseCommand ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DatabaseCommand ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DatabaseCommand ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DatabaseCommand ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DatabaseCommand, Builder>.PrintField("command", this.hasCommand, this.command_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _databaseCommandFieldNames;
            if (this.hasCommand)
            {
                output.WriteEnum(1, strArray[0], (int) this.Command, this.Command);
            }
        }

        public Types.TCommand Command
        {
            get
            {
                return this.command_;
            }
        }

        public static DatabaseCommand DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DatabaseCommand DefaultInstanceForType
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
                        memoizedSerializedSize += CodedOutputStream.ComputeEnumSize(1, (int) this.Command);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override DatabaseCommand ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<DatabaseCommand, DatabaseCommand.Builder>
        {
            private DatabaseCommand result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DatabaseCommand.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DatabaseCommand cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override DatabaseCommand BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DatabaseCommand.Builder Clear()
            {
                this.result = DatabaseCommand.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DatabaseCommand.Builder ClearCommand()
            {
                this.PrepareBuilder();
                this.result.hasCommand = false;
                this.result.command_ = DatabaseCommand.Types.TCommand.GET_PROFILE;
                return this;
            }

            public override DatabaseCommand.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DatabaseCommand.Builder(this.result);
                }
                return new DatabaseCommand.Builder().MergeFrom(this.result);
            }

            public override DatabaseCommand.Builder MergeFrom(DatabaseCommand other)
            {
                if (other != DatabaseCommand.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasCommand)
                    {
                        this.Command = other.Command;
                    }
                }
                return this;
            }

            public override DatabaseCommand.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DatabaseCommand.Builder MergeFrom(IMessageLite other)
            {
                if (other is DatabaseCommand)
                {
                    return this.MergeFrom((DatabaseCommand) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DatabaseCommand.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    object obj2;
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DatabaseCommand._databaseCommandFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DatabaseCommand._databaseCommandFieldTags[index];
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
                    if (input.ReadEnum<DatabaseCommand.Types.TCommand>(ref this.result.command_, out obj2))
                    {
                        this.result.hasCommand = true;
                    }
                    else if (!(obj2 is int))
                    {
                        continue;
                    }
                }
                return this;
            }

            private DatabaseCommand PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DatabaseCommand result = this.result;
                    this.result = new DatabaseCommand();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DatabaseCommand.Builder SetCommand(DatabaseCommand.Types.TCommand value)
            {
                this.PrepareBuilder();
                this.result.hasCommand = true;
                this.result.command_ = value;
                return this;
            }

            public DatabaseCommand.Types.TCommand Command
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

            public override DatabaseCommand DefaultInstanceForType
            {
                get
                {
                    return DatabaseCommand.DefaultInstance;
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

            protected override DatabaseCommand MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override DatabaseCommand.Builder ThisBuilder
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
                ID = 0x7f
            }

            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum TCommand
            {
                DELETE_PROFILE = 2,
                GET_PROFILE = 1
            }
        }
    }
}

