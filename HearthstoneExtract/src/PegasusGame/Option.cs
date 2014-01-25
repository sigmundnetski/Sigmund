namespace PegasusGame
{
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class Option : GeneratedMessageLite<Option, Builder>
    {
        private static readonly string[] _optionFieldNames = new string[] { "main_option", "sub_options", "type" };
        private static readonly uint[] _optionFieldTags = new uint[] { 0x12, 0x1a, 8 };
        private static readonly Option defaultInstance = new Option().MakeReadOnly();
        private bool hasMainOption;
        private bool hasType;
        private SubOption mainOption_;
        public const int MainOptionFieldNumber = 2;
        private int memoizedSerializedSize = -1;
        private PopsicleList<SubOption> subOptions_ = new PopsicleList<SubOption>();
        public const int SubOptionsFieldNumber = 3;
        private PegasusGame.Option.Types.Type type_ = PegasusGame.Option.Types.Type.PASS;
        public const int TypeFieldNumber = 1;

        static Option()
        {
            object.ReferenceEquals(PegasusGamelite.Descriptor, null);
        }

        private Option()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(Option prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            Option option = obj as Option;
            if (option == null)
            {
                return false;
            }
            if ((this.hasType != option.hasType) || (this.hasType && !this.type_.Equals(option.type_)))
            {
                return false;
            }
            if ((this.hasMainOption != option.hasMainOption) || (this.hasMainOption && !this.mainOption_.Equals(option.mainOption_)))
            {
                return false;
            }
            if (this.subOptions_.Count != option.subOptions_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.subOptions_.Count; i++)
            {
                if (!this.subOptions_[i].Equals(option.subOptions_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasType)
            {
                hashCode ^= this.type_.GetHashCode();
            }
            if (this.hasMainOption)
            {
                hashCode ^= this.mainOption_.GetHashCode();
            }
            IEnumerator<SubOption> enumerator = this.subOptions_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    SubOption current = enumerator.Current;
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

        public SubOption GetSubOptions(int index)
        {
            return this.subOptions_[index];
        }

        private Option MakeReadOnly()
        {
            this.subOptions_.MakeReadOnly();
            return this;
        }

        public static Option ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static Option ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static Option ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Option ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Option ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Option ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Option ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static Option ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Option ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Option ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<Option, Builder>.PrintField("type", this.hasType, this.type_, writer);
            GeneratedMessageLite<Option, Builder>.PrintField("main_option", this.hasMainOption, this.mainOption_, writer);
            GeneratedMessageLite<Option, Builder>.PrintField<SubOption>("sub_options", this.subOptions_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _optionFieldNames;
            if (this.hasType)
            {
                output.WriteEnum(1, strArray[2], (int) this.Type, this.Type);
            }
            if (this.hasMainOption)
            {
                output.WriteMessage(2, strArray[0], this.MainOption);
            }
            if (this.subOptions_.Count > 0)
            {
                output.WriteMessageArray<SubOption>(3, strArray[1], this.subOptions_);
            }
        }

        public static Option DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override Option DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasMainOption
        {
            get
            {
                return this.hasMainOption;
            }
        }

        public bool HasType
        {
            get
            {
                return this.hasType;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasType)
                {
                    return false;
                }
                if (this.HasMainOption && !this.MainOption.IsInitialized)
                {
                    return false;
                }
                IEnumerator<SubOption> enumerator = this.SubOptionsList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        SubOption current = enumerator.Current;
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

        public SubOption MainOption
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.mainOption_ != null)
                {
                    goto Label_0012;
                }
                return SubOption.DefaultInstance;
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
                    if (this.hasType)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeEnumSize(1, (int) this.Type);
                    }
                    if (this.hasMainOption)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, this.MainOption);
                    }
                    IEnumerator<SubOption> enumerator = this.SubOptionsList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            SubOption current = enumerator.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(3, current);
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

        public int SubOptionsCount
        {
            get
            {
                return this.subOptions_.Count;
            }
        }

        public IList<SubOption> SubOptionsList
        {
            get
            {
                return this.subOptions_;
            }
        }

        protected override Option ThisMessage
        {
            get
            {
                return this;
            }
        }

        public PegasusGame.Option.Types.Type Type
        {
            get
            {
                return this.type_;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<Option, Option.Builder>
        {
            private Option result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = Option.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(Option cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public Option.Builder AddRangeSubOptions(IEnumerable<SubOption> values)
            {
                this.PrepareBuilder();
                this.result.subOptions_.Add(values);
                return this;
            }

            public Option.Builder AddSubOptions(SubOption value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.subOptions_.Add(value);
                return this;
            }

            public Option.Builder AddSubOptions(SubOption.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.subOptions_.Add(builderForValue.Build());
                return this;
            }

            public override Option BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override Option.Builder Clear()
            {
                this.result = Option.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public Option.Builder ClearMainOption()
            {
                this.PrepareBuilder();
                this.result.hasMainOption = false;
                this.result.mainOption_ = null;
                return this;
            }

            public Option.Builder ClearSubOptions()
            {
                this.PrepareBuilder();
                this.result.subOptions_.Clear();
                return this;
            }

            public Option.Builder ClearType()
            {
                this.PrepareBuilder();
                this.result.hasType = false;
                this.result.type_ = PegasusGame.Option.Types.Type.PASS;
                return this;
            }

            public override Option.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new Option.Builder(this.result);
                }
                return new Option.Builder().MergeFrom(this.result);
            }

            public SubOption GetSubOptions(int index)
            {
                return this.result.GetSubOptions(index);
            }

            public override Option.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override Option.Builder MergeFrom(IMessageLite other)
            {
                if (other is Option)
                {
                    return this.MergeFrom((Option) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override Option.Builder MergeFrom(Option other)
            {
                if (other != Option.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasType)
                    {
                        this.Type = other.Type;
                    }
                    if (other.HasMainOption)
                    {
                        this.MergeMainOption(other.MainOption);
                    }
                    if (other.subOptions_.Count != 0)
                    {
                        this.result.subOptions_.Add(other.subOptions_);
                    }
                }
                return this;
            }

            public override Option.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(Option._optionFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = Option._optionFieldTags[index];
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
                        {
                            object obj2;
                            if (input.ReadEnum<PegasusGame.Option.Types.Type>(ref this.result.type_, out obj2))
                            {
                                this.result.hasType = true;
                            }
                            else if (obj2 is int)
                            {
                            }
                            continue;
                        }
                        case 0x12:
                        {
                            SubOption.Builder builder = SubOption.CreateBuilder();
                            if (this.result.hasMainOption)
                            {
                                builder.MergeFrom(this.MainOption);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.MainOption = builder.BuildPartial();
                            continue;
                        }
                        case 0x1a:
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
                    input.ReadMessageArray<SubOption>(num, str, this.result.subOptions_, SubOption.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            public Option.Builder MergeMainOption(SubOption value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasMainOption && (this.result.mainOption_ != SubOption.DefaultInstance))
                {
                    this.result.mainOption_ = SubOption.CreateBuilder(this.result.mainOption_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.mainOption_ = value;
                }
                this.result.hasMainOption = true;
                return this;
            }

            private Option PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    Option result = this.result;
                    this.result = new Option();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public Option.Builder SetMainOption(SubOption value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasMainOption = true;
                this.result.mainOption_ = value;
                return this;
            }

            public Option.Builder SetMainOption(SubOption.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasMainOption = true;
                this.result.mainOption_ = builderForValue.Build();
                return this;
            }

            public Option.Builder SetSubOptions(int index, SubOption value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.subOptions_[index] = value;
                return this;
            }

            public Option.Builder SetSubOptions(int index, SubOption.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.subOptions_[index] = builderForValue.Build();
                return this;
            }

            public Option.Builder SetType(PegasusGame.Option.Types.Type value)
            {
                this.PrepareBuilder();
                this.result.hasType = true;
                this.result.type_ = value;
                return this;
            }

            public override Option DefaultInstanceForType
            {
                get
                {
                    return Option.DefaultInstance;
                }
            }

            public bool HasMainOption
            {
                get
                {
                    return this.result.hasMainOption;
                }
            }

            public bool HasType
            {
                get
                {
                    return this.result.hasType;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public SubOption MainOption
            {
                get
                {
                    return this.result.MainOption;
                }
                set
                {
                    this.SetMainOption(value);
                }
            }

            protected override Option MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int SubOptionsCount
            {
                get
                {
                    return this.result.SubOptionsCount;
                }
            }

            public IPopsicleList<SubOption> SubOptionsList
            {
                get
                {
                    return this.PrepareBuilder().subOptions_;
                }
            }

            protected override Option.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public PegasusGame.Option.Types.Type Type
            {
                get
                {
                    return this.result.Type;
                }
                set
                {
                    this.SetType(value);
                }
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum Type
            {
                END_TURN = 2,
                PASS = 1,
                POWER = 3
            }
        }
    }
}

