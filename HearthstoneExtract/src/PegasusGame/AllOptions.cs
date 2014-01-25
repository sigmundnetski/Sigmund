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

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class AllOptions : GeneratedMessageLite<AllOptions, Builder>
    {
        private static readonly string[] _allOptionsFieldNames = new string[] { "id", "options" };
        private static readonly uint[] _allOptionsFieldTags = new uint[] { 8, 0x12 };
        private static readonly AllOptions defaultInstance = new AllOptions().MakeReadOnly();
        private bool hasId;
        private int id_;
        public const int IdFieldNumber = 1;
        private int memoizedSerializedSize = -1;
        private PopsicleList<Option> options_ = new PopsicleList<Option>();
        public const int OptionsFieldNumber = 2;

        static AllOptions()
        {
            object.ReferenceEquals(PegasusGamelite.Descriptor, null);
        }

        private AllOptions()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AllOptions prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AllOptions options = obj as AllOptions;
            if (options == null)
            {
                return false;
            }
            if ((this.hasId != options.hasId) || (this.hasId && !this.id_.Equals(options.id_)))
            {
                return false;
            }
            if (this.options_.Count != options.options_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.options_.Count; i++)
            {
                if (!this.options_[i].Equals(options.options_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasId)
            {
                hashCode ^= this.id_.GetHashCode();
            }
            IEnumerator<Option> enumerator = this.options_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    Option current = enumerator.Current;
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

        public Option GetOptions(int index)
        {
            return this.options_[index];
        }

        private AllOptions MakeReadOnly()
        {
            this.options_.MakeReadOnly();
            return this;
        }

        public static AllOptions ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AllOptions ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AllOptions ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AllOptions ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AllOptions ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AllOptions ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AllOptions ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AllOptions ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AllOptions ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AllOptions ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AllOptions, Builder>.PrintField("id", this.hasId, this.id_, writer);
            GeneratedMessageLite<AllOptions, Builder>.PrintField<Option>("options", this.options_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _allOptionsFieldNames;
            if (this.hasId)
            {
                output.WriteInt32(1, strArray[0], this.Id);
            }
            if (this.options_.Count > 0)
            {
                output.WriteMessageArray<Option>(2, strArray[1], this.options_);
            }
        }

        public static AllOptions DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AllOptions DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasId
        {
            get
            {
                return this.hasId;
            }
        }

        public int Id
        {
            get
            {
                return this.id_;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasId)
                {
                    return false;
                }
                IEnumerator<Option> enumerator = this.OptionsList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        Option current = enumerator.Current;
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

        public int OptionsCount
        {
            get
            {
                return this.options_.Count;
            }
        }

        public IList<Option> OptionsList
        {
            get
            {
                return this.options_;
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
                    if (this.hasId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.Id);
                    }
                    IEnumerator<Option> enumerator = this.OptionsList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            Option current = enumerator.Current;
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

        protected override AllOptions ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<AllOptions, AllOptions.Builder>
        {
            private AllOptions result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AllOptions.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AllOptions cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public AllOptions.Builder AddOptions(Option value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.options_.Add(value);
                return this;
            }

            public AllOptions.Builder AddOptions(Option.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.options_.Add(builderForValue.Build());
                return this;
            }

            public AllOptions.Builder AddRangeOptions(IEnumerable<Option> values)
            {
                this.PrepareBuilder();
                this.result.options_.Add(values);
                return this;
            }

            public override AllOptions BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AllOptions.Builder Clear()
            {
                this.result = AllOptions.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AllOptions.Builder ClearId()
            {
                this.PrepareBuilder();
                this.result.hasId = false;
                this.result.id_ = 0;
                return this;
            }

            public AllOptions.Builder ClearOptions()
            {
                this.PrepareBuilder();
                this.result.options_.Clear();
                return this;
            }

            public override AllOptions.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AllOptions.Builder(this.result);
                }
                return new AllOptions.Builder().MergeFrom(this.result);
            }

            public Option GetOptions(int index)
            {
                return this.result.GetOptions(index);
            }

            public override AllOptions.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AllOptions.Builder MergeFrom(IMessageLite other)
            {
                if (other is AllOptions)
                {
                    return this.MergeFrom((AllOptions) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AllOptions.Builder MergeFrom(AllOptions other)
            {
                if (other != AllOptions.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasId)
                    {
                        this.Id = other.Id;
                    }
                    if (other.options_.Count != 0)
                    {
                        this.result.options_.Add(other.options_);
                    }
                }
                return this;
            }

            public override AllOptions.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AllOptions._allOptionsFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AllOptions._allOptionsFieldTags[index];
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
                            this.result.hasId = input.ReadInt32(ref this.result.id_);
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
                    input.ReadMessageArray<Option>(num, str, this.result.options_, Option.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private AllOptions PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AllOptions result = this.result;
                    this.result = new AllOptions();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public AllOptions.Builder SetId(int value)
            {
                this.PrepareBuilder();
                this.result.hasId = true;
                this.result.id_ = value;
                return this;
            }

            public AllOptions.Builder SetOptions(int index, Option value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.options_[index] = value;
                return this;
            }

            public AllOptions.Builder SetOptions(int index, Option.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.options_[index] = builderForValue.Build();
                return this;
            }

            public override AllOptions DefaultInstanceForType
            {
                get
                {
                    return AllOptions.DefaultInstance;
                }
            }

            public bool HasId
            {
                get
                {
                    return this.result.hasId;
                }
            }

            public int Id
            {
                get
                {
                    return this.result.Id;
                }
                set
                {
                    this.SetId(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override AllOptions MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int OptionsCount
            {
                get
                {
                    return this.result.OptionsCount;
                }
            }

            public IPopsicleList<Option> OptionsList
            {
                get
                {
                    return this.PrepareBuilder().options_;
                }
            }

            protected override AllOptions.Builder ThisBuilder
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
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 14
            }
        }
    }
}

