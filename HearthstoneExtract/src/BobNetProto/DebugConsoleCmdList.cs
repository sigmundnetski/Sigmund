namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class DebugConsoleCmdList : GeneratedMessageLite<DebugConsoleCmdList, Builder>
    {
        private static readonly string[] _debugConsoleCmdListFieldNames = new string[] { "commands" };
        private static readonly uint[] _debugConsoleCmdListFieldTags = new uint[] { 10 };
        private PopsicleList<Types.DebugConsoleCmd> commands_ = new PopsicleList<Types.DebugConsoleCmd>();
        public const int CommandsFieldNumber = 1;
        private static readonly DebugConsoleCmdList defaultInstance = new DebugConsoleCmdList().MakeReadOnly();
        private int memoizedSerializedSize = -1;

        static DebugConsoleCmdList()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private DebugConsoleCmdList()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DebugConsoleCmdList prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DebugConsoleCmdList list = obj as DebugConsoleCmdList;
            if (list == null)
            {
                return false;
            }
            if (this.commands_.Count != list.commands_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.commands_.Count; i++)
            {
                if (!this.commands_[i].Equals(list.commands_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public Types.DebugConsoleCmd GetCommands(int index)
        {
            return this.commands_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<Types.DebugConsoleCmd> enumerator = this.commands_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    Types.DebugConsoleCmd current = enumerator.Current;
                    hashCode ^= current.GetHashCode();
                }
            }
            finally
            {
                if (enumerator == null)
                {
                }
                enumerator.Dispose();
            }
            return hashCode;
        }

        private DebugConsoleCmdList MakeReadOnly()
        {
            this.commands_.MakeReadOnly();
            return this;
        }

        public static DebugConsoleCmdList ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DebugConsoleCmdList ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DebugConsoleCmdList ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DebugConsoleCmdList ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DebugConsoleCmdList ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DebugConsoleCmdList ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DebugConsoleCmdList ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DebugConsoleCmdList ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DebugConsoleCmdList ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DebugConsoleCmdList ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DebugConsoleCmdList, Builder>.PrintField<Types.DebugConsoleCmd>("commands", this.commands_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _debugConsoleCmdListFieldNames;
            if (this.commands_.Count > 0)
            {
                output.WriteMessageArray<Types.DebugConsoleCmd>(1, strArray[0], this.commands_);
            }
        }

        public int CommandsCount
        {
            get
            {
                return this.commands_.Count;
            }
        }

        public IList<Types.DebugConsoleCmd> CommandsList
        {
            get
            {
                return this.commands_;
            }
        }

        public static DebugConsoleCmdList DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DebugConsoleCmdList DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                IEnumerator<Types.DebugConsoleCmd> enumerator = this.CommandsList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        Types.DebugConsoleCmd current = enumerator.Current;
                        if (!current.IsInitialized)
                        {
                            return false;
                        }
                    }
                }
                finally
                {
                    if (enumerator == null)
                    {
                    }
                    enumerator.Dispose();
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
                    IEnumerator<Types.DebugConsoleCmd> enumerator = this.CommandsList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            Types.DebugConsoleCmd current = enumerator.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, current);
                        }
                    }
                    finally
                    {
                        if (enumerator == null)
                        {
                        }
                        enumerator.Dispose();
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override DebugConsoleCmdList ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<DebugConsoleCmdList, DebugConsoleCmdList.Builder>
        {
            private DebugConsoleCmdList result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DebugConsoleCmdList.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DebugConsoleCmdList cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public DebugConsoleCmdList.Builder AddCommands(DebugConsoleCmdList.Types.DebugConsoleCmd value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.commands_.Add(value);
                return this;
            }

            public DebugConsoleCmdList.Builder AddCommands(DebugConsoleCmdList.Types.DebugConsoleCmd.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.commands_.Add(builderForValue.Build());
                return this;
            }

            public DebugConsoleCmdList.Builder AddRangeCommands(IEnumerable<DebugConsoleCmdList.Types.DebugConsoleCmd> values)
            {
                this.PrepareBuilder();
                this.result.commands_.Add(values);
                return this;
            }

            public override DebugConsoleCmdList BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DebugConsoleCmdList.Builder Clear()
            {
                this.result = DebugConsoleCmdList.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DebugConsoleCmdList.Builder ClearCommands()
            {
                this.PrepareBuilder();
                this.result.commands_.Clear();
                return this;
            }

            public override DebugConsoleCmdList.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DebugConsoleCmdList.Builder(this.result);
                }
                return new DebugConsoleCmdList.Builder().MergeFrom(this.result);
            }

            public DebugConsoleCmdList.Types.DebugConsoleCmd GetCommands(int index)
            {
                return this.result.GetCommands(index);
            }

            public override DebugConsoleCmdList.Builder MergeFrom(DebugConsoleCmdList other)
            {
                if (other != DebugConsoleCmdList.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.commands_.Count != 0)
                    {
                        this.result.commands_.Add(other.commands_);
                    }
                }
                return this;
            }

            public override DebugConsoleCmdList.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DebugConsoleCmdList.Builder MergeFrom(IMessageLite other)
            {
                if (other is DebugConsoleCmdList)
                {
                    return this.MergeFrom((DebugConsoleCmdList) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DebugConsoleCmdList.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DebugConsoleCmdList._debugConsoleCmdListFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DebugConsoleCmdList._debugConsoleCmdListFieldTags[index];
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
                    input.ReadMessageArray<DebugConsoleCmdList.Types.DebugConsoleCmd>(num, str, this.result.commands_, DebugConsoleCmdList.Types.DebugConsoleCmd.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private DebugConsoleCmdList PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DebugConsoleCmdList result = this.result;
                    this.result = new DebugConsoleCmdList();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DebugConsoleCmdList.Builder SetCommands(int index, DebugConsoleCmdList.Types.DebugConsoleCmd value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.commands_[index] = value;
                return this;
            }

            public DebugConsoleCmdList.Builder SetCommands(int index, DebugConsoleCmdList.Types.DebugConsoleCmd.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.commands_[index] = builderForValue.Build();
                return this;
            }

            public int CommandsCount
            {
                get
                {
                    return this.result.CommandsCount;
                }
            }

            public IPopsicleList<DebugConsoleCmdList.Types.DebugConsoleCmd> CommandsList
            {
                get
                {
                    return this.PrepareBuilder().commands_;
                }
            }

            public override DebugConsoleCmdList DefaultInstanceForType
            {
                get
                {
                    return DebugConsoleCmdList.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override DebugConsoleCmdList MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override DebugConsoleCmdList.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public static class Types
        {
            [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public sealed class DebugConsoleCmd : GeneratedMessageLite<DebugConsoleCmdList.Types.DebugConsoleCmd, Builder>
            {
                private static readonly string[] _debugConsoleCmdFieldNames = new string[] { "name", "params" };
                private static readonly uint[] _debugConsoleCmdFieldTags = new uint[] { 10, 0x12 };
                private static readonly DebugConsoleCmdList.Types.DebugConsoleCmd defaultInstance = new DebugConsoleCmdList.Types.DebugConsoleCmd().MakeReadOnly();
                private bool hasName;
                private int memoizedSerializedSize = -1;
                private string name_ = string.Empty;
                public const int NameFieldNumber = 1;
                private PopsicleList<Types.DebugConsoleCmdParam> params_ = new PopsicleList<Types.DebugConsoleCmdParam>();
                public const int ParamsFieldNumber = 2;

                static DebugConsoleCmd()
                {
                    object.ReferenceEquals(BobNetlite.Descriptor, null);
                }

                private DebugConsoleCmd()
                {
                }

                public static Builder CreateBuilder()
                {
                    return new Builder();
                }

                public static Builder CreateBuilder(DebugConsoleCmdList.Types.DebugConsoleCmd prototype)
                {
                    return new Builder(prototype);
                }

                public override Builder CreateBuilderForType()
                {
                    return new Builder();
                }

                public override bool Equals(object obj)
                {
                    DebugConsoleCmdList.Types.DebugConsoleCmd cmd = obj as DebugConsoleCmdList.Types.DebugConsoleCmd;
                    if (cmd == null)
                    {
                        return false;
                    }
                    if ((this.hasName != cmd.hasName) || (this.hasName && !this.name_.Equals(cmd.name_)))
                    {
                        return false;
                    }
                    if (this.params_.Count != cmd.params_.Count)
                    {
                        return false;
                    }
                    for (int i = 0; i < this.params_.Count; i++)
                    {
                        if (!this.params_[i].Equals(cmd.params_[i]))
                        {
                            return false;
                        }
                    }
                    return true;
                }

                public override int GetHashCode()
                {
                    int hashCode = base.GetType().GetHashCode();
                    if (this.hasName)
                    {
                        hashCode ^= this.name_.GetHashCode();
                    }
                    IEnumerator<Types.DebugConsoleCmdParam> enumerator = this.params_.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            Types.DebugConsoleCmdParam current = enumerator.Current;
                            hashCode ^= current.GetHashCode();
                        }
                    }
                    finally
                    {
                        if (enumerator == null)
                        {
                        }
                        enumerator.Dispose();
                    }
                    return hashCode;
                }

                public Types.DebugConsoleCmdParam GetParams(int index)
                {
                    return this.params_[index];
                }

                private DebugConsoleCmdList.Types.DebugConsoleCmd MakeReadOnly()
                {
                    this.params_.MakeReadOnly();
                    return this;
                }

                public static DebugConsoleCmdList.Types.DebugConsoleCmd ParseDelimitedFrom(Stream input)
                {
                    return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
                }

                public static DebugConsoleCmdList.Types.DebugConsoleCmd ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
                {
                    return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
                }

                public static DebugConsoleCmdList.Types.DebugConsoleCmd ParseFrom(ByteString data)
                {
                    return CreateBuilder().MergeFrom(data).BuildParsed();
                }

                public static DebugConsoleCmdList.Types.DebugConsoleCmd ParseFrom(ICodedInputStream input)
                {
                    return CreateBuilder().MergeFrom(input).BuildParsed();
                }

                public static DebugConsoleCmdList.Types.DebugConsoleCmd ParseFrom(byte[] data)
                {
                    return CreateBuilder().MergeFrom(data).BuildParsed();
                }

                public static DebugConsoleCmdList.Types.DebugConsoleCmd ParseFrom(Stream input)
                {
                    return CreateBuilder().MergeFrom(input).BuildParsed();
                }

                public static DebugConsoleCmdList.Types.DebugConsoleCmd ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
                {
                    return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
                }

                public static DebugConsoleCmdList.Types.DebugConsoleCmd ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
                {
                    return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
                }

                public static DebugConsoleCmdList.Types.DebugConsoleCmd ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
                {
                    return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
                }

                public static DebugConsoleCmdList.Types.DebugConsoleCmd ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
                {
                    return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
                }

                public override void PrintTo(TextWriter writer)
                {
                    GeneratedMessageLite<DebugConsoleCmdList.Types.DebugConsoleCmd, Builder>.PrintField("name", this.hasName, this.name_, writer);
                    GeneratedMessageLite<DebugConsoleCmdList.Types.DebugConsoleCmd, Builder>.PrintField<Types.DebugConsoleCmdParam>("params", this.params_, writer);
                }

                public override Builder ToBuilder()
                {
                    return CreateBuilder(this);
                }

                public override void WriteTo(ICodedOutputStream output)
                {
                    int serializedSize = this.SerializedSize;
                    string[] strArray = _debugConsoleCmdFieldNames;
                    if (this.hasName)
                    {
                        output.WriteString(1, strArray[0], this.Name);
                    }
                    if (this.params_.Count > 0)
                    {
                        output.WriteMessageArray<Types.DebugConsoleCmdParam>(2, strArray[1], this.params_);
                    }
                }

                public static DebugConsoleCmdList.Types.DebugConsoleCmd DefaultInstance
                {
                    get
                    {
                        return defaultInstance;
                    }
                }

                public override DebugConsoleCmdList.Types.DebugConsoleCmd DefaultInstanceForType
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

                public override bool IsInitialized
                {
                    get
                    {
                        if (!this.hasName)
                        {
                            return false;
                        }
                        IEnumerator<Types.DebugConsoleCmdParam> enumerator = this.ParamsList.GetEnumerator();
                        try
                        {
                            while (enumerator.MoveNext())
                            {
                                Types.DebugConsoleCmdParam current = enumerator.Current;
                                if (!current.IsInitialized)
                                {
                                    return false;
                                }
                            }
                        }
                        finally
                        {
                            if (enumerator == null)
                            {
                            }
                            enumerator.Dispose();
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

                public int ParamsCount
                {
                    get
                    {
                        return this.params_.Count;
                    }
                }

                public IList<Types.DebugConsoleCmdParam> ParamsList
                {
                    get
                    {
                        return this.params_;
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
                            IEnumerator<Types.DebugConsoleCmdParam> enumerator = this.ParamsList.GetEnumerator();
                            try
                            {
                                while (enumerator.MoveNext())
                                {
                                    Types.DebugConsoleCmdParam current = enumerator.Current;
                                    memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, current);
                                }
                            }
                            finally
                            {
                                if (enumerator == null)
                                {
                                }
                                enumerator.Dispose();
                            }
                            this.memoizedSerializedSize = memoizedSerializedSize;
                        }
                        return memoizedSerializedSize;
                    }
                }

                protected override DebugConsoleCmdList.Types.DebugConsoleCmd ThisMessage
                {
                    get
                    {
                        return this;
                    }
                }

                [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
                public sealed class Builder : GeneratedBuilderLite<DebugConsoleCmdList.Types.DebugConsoleCmd, DebugConsoleCmdList.Types.DebugConsoleCmd.Builder>
                {
                    private DebugConsoleCmdList.Types.DebugConsoleCmd result;
                    private bool resultIsReadOnly;

                    public Builder()
                    {
                        this.result = DebugConsoleCmdList.Types.DebugConsoleCmd.DefaultInstance;
                        this.resultIsReadOnly = true;
                    }

                    internal Builder(DebugConsoleCmdList.Types.DebugConsoleCmd cloneFrom)
                    {
                        this.result = cloneFrom;
                        this.resultIsReadOnly = true;
                    }

                    public DebugConsoleCmdList.Types.DebugConsoleCmd.Builder AddParams(DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam value)
                    {
                        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                        this.PrepareBuilder();
                        this.result.params_.Add(value);
                        return this;
                    }

                    public DebugConsoleCmdList.Types.DebugConsoleCmd.Builder AddParams(DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam.Builder builderForValue)
                    {
                        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                        this.PrepareBuilder();
                        this.result.params_.Add(builderForValue.Build());
                        return this;
                    }

                    public DebugConsoleCmdList.Types.DebugConsoleCmd.Builder AddRangeParams(IEnumerable<DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam> values)
                    {
                        this.PrepareBuilder();
                        this.result.params_.Add(values);
                        return this;
                    }

                    public override DebugConsoleCmdList.Types.DebugConsoleCmd BuildPartial()
                    {
                        if (this.resultIsReadOnly)
                        {
                            return this.result;
                        }
                        this.resultIsReadOnly = true;
                        return this.result.MakeReadOnly();
                    }

                    public override DebugConsoleCmdList.Types.DebugConsoleCmd.Builder Clear()
                    {
                        this.result = DebugConsoleCmdList.Types.DebugConsoleCmd.DefaultInstance;
                        this.resultIsReadOnly = true;
                        return this;
                    }

                    public DebugConsoleCmdList.Types.DebugConsoleCmd.Builder ClearName()
                    {
                        this.PrepareBuilder();
                        this.result.hasName = false;
                        this.result.name_ = string.Empty;
                        return this;
                    }

                    public DebugConsoleCmdList.Types.DebugConsoleCmd.Builder ClearParams()
                    {
                        this.PrepareBuilder();
                        this.result.params_.Clear();
                        return this;
                    }

                    public override DebugConsoleCmdList.Types.DebugConsoleCmd.Builder Clone()
                    {
                        if (this.resultIsReadOnly)
                        {
                            return new DebugConsoleCmdList.Types.DebugConsoleCmd.Builder(this.result);
                        }
                        return new DebugConsoleCmdList.Types.DebugConsoleCmd.Builder().MergeFrom(this.result);
                    }

                    public DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam GetParams(int index)
                    {
                        return this.result.GetParams(index);
                    }

                    public override DebugConsoleCmdList.Types.DebugConsoleCmd.Builder MergeFrom(DebugConsoleCmdList.Types.DebugConsoleCmd other)
                    {
                        if (other != DebugConsoleCmdList.Types.DebugConsoleCmd.DefaultInstance)
                        {
                            this.PrepareBuilder();
                            if (other.HasName)
                            {
                                this.Name = other.Name;
                            }
                            if (other.params_.Count != 0)
                            {
                                this.result.params_.Add(other.params_);
                            }
                        }
                        return this;
                    }

                    public override DebugConsoleCmdList.Types.DebugConsoleCmd.Builder MergeFrom(ICodedInputStream input)
                    {
                        return this.MergeFrom(input, ExtensionRegistry.Empty);
                    }

                    public override DebugConsoleCmdList.Types.DebugConsoleCmd.Builder MergeFrom(IMessageLite other)
                    {
                        if (other is DebugConsoleCmdList.Types.DebugConsoleCmd)
                        {
                            return this.MergeFrom((DebugConsoleCmdList.Types.DebugConsoleCmd) other);
                        }
                        base.MergeFrom(other);
                        return this;
                    }

                    public override DebugConsoleCmdList.Types.DebugConsoleCmd.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
                    {
                        uint num;
                        string str;
                        this.PrepareBuilder();
                        while (input.ReadTag(out num, out str))
                        {
                            if ((num == 0) && (str != null))
                            {
                                int index = Array.BinarySearch<string>(DebugConsoleCmdList.Types.DebugConsoleCmd._debugConsoleCmdFieldNames, str, StringComparer.Ordinal);
                                if (index >= 0)
                                {
                                    num = DebugConsoleCmdList.Types.DebugConsoleCmd._debugConsoleCmdFieldTags[index];
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
                            input.ReadMessageArray<DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam>(num, str, this.result.params_, DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam.DefaultInstance, extensionRegistry);
                        }
                        return this;
                    }

                    private DebugConsoleCmdList.Types.DebugConsoleCmd PrepareBuilder()
                    {
                        if (this.resultIsReadOnly)
                        {
                            DebugConsoleCmdList.Types.DebugConsoleCmd result = this.result;
                            this.result = new DebugConsoleCmdList.Types.DebugConsoleCmd();
                            this.resultIsReadOnly = false;
                            this.MergeFrom(result);
                        }
                        return this.result;
                    }

                    public DebugConsoleCmdList.Types.DebugConsoleCmd.Builder SetName(string value)
                    {
                        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                        this.PrepareBuilder();
                        this.result.hasName = true;
                        this.result.name_ = value;
                        return this;
                    }

                    public DebugConsoleCmdList.Types.DebugConsoleCmd.Builder SetParams(int index, DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam value)
                    {
                        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                        this.PrepareBuilder();
                        this.result.params_[index] = value;
                        return this;
                    }

                    public DebugConsoleCmdList.Types.DebugConsoleCmd.Builder SetParams(int index, DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam.Builder builderForValue)
                    {
                        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                        this.PrepareBuilder();
                        this.result.params_[index] = builderForValue.Build();
                        return this;
                    }

                    public override DebugConsoleCmdList.Types.DebugConsoleCmd DefaultInstanceForType
                    {
                        get
                        {
                            return DebugConsoleCmdList.Types.DebugConsoleCmd.DefaultInstance;
                        }
                    }

                    public bool HasName
                    {
                        get
                        {
                            return this.result.hasName;
                        }
                    }

                    public override bool IsInitialized
                    {
                        get
                        {
                            return this.result.IsInitialized;
                        }
                    }

                    protected override DebugConsoleCmdList.Types.DebugConsoleCmd MessageBeingBuilt
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

                    public int ParamsCount
                    {
                        get
                        {
                            return this.result.ParamsCount;
                        }
                    }

                    public IPopsicleList<DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam> ParamsList
                    {
                        get
                        {
                            return this.PrepareBuilder().params_;
                        }
                    }

                    protected override DebugConsoleCmdList.Types.DebugConsoleCmd.Builder ThisBuilder
                    {
                        get
                        {
                            return this;
                        }
                    }
                }

                [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
                public static class Types
                {
                    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
                    public sealed class DebugConsoleCmdParam : GeneratedMessageLite<DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam, Builder>
                    {
                        private static readonly string[] _debugConsoleCmdParamFieldNames = new string[] { "paramName", "paramType" };
                        private static readonly uint[] _debugConsoleCmdParamFieldTags = new uint[] { 0x12, 10 };
                        private static readonly DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam defaultInstance = new DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam().MakeReadOnly();
                        private bool hasParamName;
                        private bool hasParamType;
                        private int memoizedSerializedSize = -1;
                        private string paramName_ = string.Empty;
                        public const int ParamNameFieldNumber = 2;
                        private string paramType_ = string.Empty;
                        public const int ParamTypeFieldNumber = 1;

                        static DebugConsoleCmdParam()
                        {
                            object.ReferenceEquals(BobNetlite.Descriptor, null);
                        }

                        private DebugConsoleCmdParam()
                        {
                        }

                        public static Builder CreateBuilder()
                        {
                            return new Builder();
                        }

                        public static Builder CreateBuilder(DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam prototype)
                        {
                            return new Builder(prototype);
                        }

                        public override Builder CreateBuilderForType()
                        {
                            return new Builder();
                        }

                        public override bool Equals(object obj)
                        {
                            DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam param = obj as DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam;
                            if (param == null)
                            {
                                return false;
                            }
                            if ((this.hasParamType != param.hasParamType) || (this.hasParamType && !this.paramType_.Equals(param.paramType_)))
                            {
                                return false;
                            }
                            return ((this.hasParamName == param.hasParamName) && (!this.hasParamName || this.paramName_.Equals(param.paramName_)));
                        }

                        public override int GetHashCode()
                        {
                            int hashCode = base.GetType().GetHashCode();
                            if (this.hasParamType)
                            {
                                hashCode ^= this.paramType_.GetHashCode();
                            }
                            if (this.hasParamName)
                            {
                                hashCode ^= this.paramName_.GetHashCode();
                            }
                            return hashCode;
                        }

                        private DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam MakeReadOnly()
                        {
                            return this;
                        }

                        public static DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam ParseDelimitedFrom(Stream input)
                        {
                            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
                        }

                        public static DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
                        {
                            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
                        }

                        public static DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam ParseFrom(byte[] data)
                        {
                            return CreateBuilder().MergeFrom(data).BuildParsed();
                        }

                        public static DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam ParseFrom(ByteString data)
                        {
                            return CreateBuilder().MergeFrom(data).BuildParsed();
                        }

                        public static DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam ParseFrom(ICodedInputStream input)
                        {
                            return CreateBuilder().MergeFrom(input).BuildParsed();
                        }

                        public static DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam ParseFrom(Stream input)
                        {
                            return CreateBuilder().MergeFrom(input).BuildParsed();
                        }

                        public static DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
                        {
                            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
                        }

                        public static DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
                        {
                            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
                        }

                        public static DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
                        {
                            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
                        }

                        public static DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
                        {
                            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
                        }

                        public override void PrintTo(TextWriter writer)
                        {
                            GeneratedMessageLite<DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam, Builder>.PrintField("paramType", this.hasParamType, this.paramType_, writer);
                            GeneratedMessageLite<DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam, Builder>.PrintField("paramName", this.hasParamName, this.paramName_, writer);
                        }

                        public override Builder ToBuilder()
                        {
                            return CreateBuilder(this);
                        }

                        public override void WriteTo(ICodedOutputStream output)
                        {
                            int serializedSize = this.SerializedSize;
                            string[] strArray = _debugConsoleCmdParamFieldNames;
                            if (this.hasParamType)
                            {
                                output.WriteString(1, strArray[1], this.ParamType);
                            }
                            if (this.hasParamName)
                            {
                                output.WriteString(2, strArray[0], this.ParamName);
                            }
                        }

                        public static DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam DefaultInstance
                        {
                            get
                            {
                                return defaultInstance;
                            }
                        }

                        public override DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam DefaultInstanceForType
                        {
                            get
                            {
                                return DefaultInstance;
                            }
                        }

                        public bool HasParamName
                        {
                            get
                            {
                                return this.hasParamName;
                            }
                        }

                        public bool HasParamType
                        {
                            get
                            {
                                return this.hasParamType;
                            }
                        }

                        public override bool IsInitialized
                        {
                            get
                            {
                                if (!this.hasParamType)
                                {
                                    return false;
                                }
                                if (!this.hasParamName)
                                {
                                    return false;
                                }
                                return true;
                            }
                        }

                        public string ParamName
                        {
                            get
                            {
                                return this.paramName_;
                            }
                        }

                        public string ParamType
                        {
                            get
                            {
                                return this.paramType_;
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
                                    if (this.hasParamType)
                                    {
                                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(1, this.ParamType);
                                    }
                                    if (this.hasParamName)
                                    {
                                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(2, this.ParamName);
                                    }
                                    this.memoizedSerializedSize = memoizedSerializedSize;
                                }
                                return memoizedSerializedSize;
                            }
                        }

                        protected override DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam ThisMessage
                        {
                            get
                            {
                                return this;
                            }
                        }

                        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
                        public sealed class Builder : GeneratedBuilderLite<DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam, DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam.Builder>
                        {
                            private DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam result;
                            private bool resultIsReadOnly;

                            public Builder()
                            {
                                this.result = DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam.DefaultInstance;
                                this.resultIsReadOnly = true;
                            }

                            internal Builder(DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam cloneFrom)
                            {
                                this.result = cloneFrom;
                                this.resultIsReadOnly = true;
                            }

                            public override DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam BuildPartial()
                            {
                                if (this.resultIsReadOnly)
                                {
                                    return this.result;
                                }
                                this.resultIsReadOnly = true;
                                return this.result.MakeReadOnly();
                            }

                            public override DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam.Builder Clear()
                            {
                                this.result = DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam.DefaultInstance;
                                this.resultIsReadOnly = true;
                                return this;
                            }

                            public DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam.Builder ClearParamName()
                            {
                                this.PrepareBuilder();
                                this.result.hasParamName = false;
                                this.result.paramName_ = string.Empty;
                                return this;
                            }

                            public DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam.Builder ClearParamType()
                            {
                                this.PrepareBuilder();
                                this.result.hasParamType = false;
                                this.result.paramType_ = string.Empty;
                                return this;
                            }

                            public override DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam.Builder Clone()
                            {
                                if (this.resultIsReadOnly)
                                {
                                    return new DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam.Builder(this.result);
                                }
                                return new DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam.Builder().MergeFrom(this.result);
                            }

                            public override DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam.Builder MergeFrom(DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam other)
                            {
                                if (other != DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam.DefaultInstance)
                                {
                                    this.PrepareBuilder();
                                    if (other.HasParamType)
                                    {
                                        this.ParamType = other.ParamType;
                                    }
                                    if (other.HasParamName)
                                    {
                                        this.ParamName = other.ParamName;
                                    }
                                }
                                return this;
                            }

                            public override DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam.Builder MergeFrom(ICodedInputStream input)
                            {
                                return this.MergeFrom(input, ExtensionRegistry.Empty);
                            }

                            public override DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam.Builder MergeFrom(IMessageLite other)
                            {
                                if (other is DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam)
                                {
                                    return this.MergeFrom((DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam) other);
                                }
                                base.MergeFrom(other);
                                return this;
                            }

                            public override DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
                            {
                                uint num;
                                string str;
                                this.PrepareBuilder();
                                while (input.ReadTag(out num, out str))
                                {
                                    if ((num == 0) && (str != null))
                                    {
                                        int index = Array.BinarySearch<string>(DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam._debugConsoleCmdParamFieldNames, str, StringComparer.Ordinal);
                                        if (index >= 0)
                                        {
                                            num = DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam._debugConsoleCmdParamFieldTags[index];
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
                                            this.result.hasParamType = input.ReadString(ref this.result.paramType_);
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
                                    this.result.hasParamName = input.ReadString(ref this.result.paramName_);
                                }
                                return this;
                            }

                            private DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam PrepareBuilder()
                            {
                                if (this.resultIsReadOnly)
                                {
                                    DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam result = this.result;
                                    this.result = new DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam();
                                    this.resultIsReadOnly = false;
                                    this.MergeFrom(result);
                                }
                                return this.result;
                            }

                            public DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam.Builder SetParamName(string value)
                            {
                                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                                this.PrepareBuilder();
                                this.result.hasParamName = true;
                                this.result.paramName_ = value;
                                return this;
                            }

                            public DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam.Builder SetParamType(string value)
                            {
                                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                                this.PrepareBuilder();
                                this.result.hasParamType = true;
                                this.result.paramType_ = value;
                                return this;
                            }

                            public override DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam DefaultInstanceForType
                            {
                                get
                                {
                                    return DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam.DefaultInstance;
                                }
                            }

                            public bool HasParamName
                            {
                                get
                                {
                                    return this.result.hasParamName;
                                }
                            }

                            public bool HasParamType
                            {
                                get
                                {
                                    return this.result.hasParamType;
                                }
                            }

                            public override bool IsInitialized
                            {
                                get
                                {
                                    return this.result.IsInitialized;
                                }
                            }

                            protected override DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam MessageBeingBuilt
                            {
                                get
                                {
                                    return this.PrepareBuilder();
                                }
                            }

                            public string ParamName
                            {
                                get
                                {
                                    return this.result.ParamName;
                                }
                                set
                                {
                                    this.SetParamName(value);
                                }
                            }

                            public string ParamType
                            {
                                get
                                {
                                    return this.result.ParamType;
                                }
                                set
                                {
                                    this.SetParamType(value);
                                }
                            }

                            protected override DebugConsoleCmdList.Types.DebugConsoleCmd.Types.DebugConsoleCmdParam.Builder ThisBuilder
                            {
                                get
                                {
                                    return this;
                                }
                            }
                        }
                    }
                }
            }

            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0x92
            }
        }
    }
}

