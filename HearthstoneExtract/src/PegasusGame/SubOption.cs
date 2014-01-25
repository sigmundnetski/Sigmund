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
    public sealed class SubOption : GeneratedMessageLite<SubOption, Builder>
    {
        private static readonly string[] _subOptionFieldNames = new string[] { "id", "targets" };
        private static readonly uint[] _subOptionFieldTags = new uint[] { 8, 0x1a };
        private static readonly SubOption defaultInstance = new SubOption().MakeReadOnly();
        private bool hasId;
        private int id_;
        public const int IdFieldNumber = 1;
        private int memoizedSerializedSize = -1;
        private PopsicleList<int> targets_ = new PopsicleList<int>();
        public const int TargetsFieldNumber = 3;
        private int targetsMemoizedSerializedSize;

        static SubOption()
        {
            object.ReferenceEquals(PegasusGamelite.Descriptor, null);
        }

        private SubOption()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(SubOption prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            SubOption option = obj as SubOption;
            if (option == null)
            {
                return false;
            }
            if ((this.hasId != option.hasId) || (this.hasId && !this.id_.Equals(option.id_)))
            {
                return false;
            }
            if (this.targets_.Count != option.targets_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.targets_.Count; i++)
            {
                int num2 = this.targets_[i];
                if (!num2.Equals(option.targets_[i]))
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
            IEnumerator<int> enumerator = this.targets_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    int current = enumerator.Current;
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

        public int GetTargets(int index)
        {
            return this.targets_[index];
        }

        private SubOption MakeReadOnly()
        {
            this.targets_.MakeReadOnly();
            return this;
        }

        public static SubOption ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static SubOption ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static SubOption ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static SubOption ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static SubOption ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static SubOption ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static SubOption ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static SubOption ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static SubOption ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static SubOption ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<SubOption, Builder>.PrintField("id", this.hasId, this.id_, writer);
            GeneratedMessageLite<SubOption, Builder>.PrintField<int>("targets", this.targets_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _subOptionFieldNames;
            if (this.hasId)
            {
                output.WriteInt32(1, strArray[0], this.Id);
            }
            if (this.targets_.Count > 0)
            {
                output.WritePackedInt32Array(3, strArray[1], this.targetsMemoizedSerializedSize, this.targets_);
            }
        }

        public static SubOption DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override SubOption DefaultInstanceForType
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
                    if (this.hasId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.Id);
                    }
                    int num2 = 0;
                    IEnumerator<int> enumerator = this.TargetsList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            int current = enumerator.Current;
                            num2 += CodedOutputStream.ComputeInt32SizeNoTag(current);
                        }
                    }
                    finally
                    {
                        if (enumerator == null)
                        {
                        }
                        enumerator.Dispose();
                    }
                    memoizedSerializedSize += num2;
                    if (this.targets_.Count != 0)
                    {
                        memoizedSerializedSize += 1 + CodedOutputStream.ComputeInt32SizeNoTag(num2);
                    }
                    this.targetsMemoizedSerializedSize = num2;
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        public int TargetsCount
        {
            get
            {
                return this.targets_.Count;
            }
        }

        public IList<int> TargetsList
        {
            get
            {
                return Lists.AsReadOnly<int>(this.targets_);
            }
        }

        protected override SubOption ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<SubOption, SubOption.Builder>
        {
            private SubOption result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = SubOption.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(SubOption cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public SubOption.Builder AddRangeTargets(IEnumerable<int> values)
            {
                this.PrepareBuilder();
                this.result.targets_.Add(values);
                return this;
            }

            public SubOption.Builder AddTargets(int value)
            {
                this.PrepareBuilder();
                this.result.targets_.Add(value);
                return this;
            }

            public override SubOption BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override SubOption.Builder Clear()
            {
                this.result = SubOption.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public SubOption.Builder ClearId()
            {
                this.PrepareBuilder();
                this.result.hasId = false;
                this.result.id_ = 0;
                return this;
            }

            public SubOption.Builder ClearTargets()
            {
                this.PrepareBuilder();
                this.result.targets_.Clear();
                return this;
            }

            public override SubOption.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new SubOption.Builder(this.result);
                }
                return new SubOption.Builder().MergeFrom(this.result);
            }

            public int GetTargets(int index)
            {
                return this.result.GetTargets(index);
            }

            public override SubOption.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override SubOption.Builder MergeFrom(IMessageLite other)
            {
                if (other is SubOption)
                {
                    return this.MergeFrom((SubOption) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override SubOption.Builder MergeFrom(SubOption other)
            {
                if (other != SubOption.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasId)
                    {
                        this.Id = other.Id;
                    }
                    if (other.targets_.Count != 0)
                    {
                        this.result.targets_.Add(other.targets_);
                    }
                }
                return this;
            }

            public override SubOption.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(SubOption._subOptionFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = SubOption._subOptionFieldTags[index];
                        }
                        else
                        {
                            this.ParseUnknownField(input, extensionRegistry, num, str);
                            continue;
                        }
                    }
                    switch (num)
                    {
                        case 0x18:
                        case 0x1a:
                            goto Label_00BB;

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
                    this.result.hasId = input.ReadInt32(ref this.result.id_);
                    continue;
                Label_00BB:
                    input.ReadInt32Array(num, str, this.result.targets_);
                }
                return this;
            }

            private SubOption PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    SubOption result = this.result;
                    this.result = new SubOption();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public SubOption.Builder SetId(int value)
            {
                this.PrepareBuilder();
                this.result.hasId = true;
                this.result.id_ = value;
                return this;
            }

            public SubOption.Builder SetTargets(int index, int value)
            {
                this.PrepareBuilder();
                this.result.targets_[index] = value;
                return this;
            }

            public override SubOption DefaultInstanceForType
            {
                get
                {
                    return SubOption.DefaultInstance;
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

            protected override SubOption MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int TargetsCount
            {
                get
                {
                    return this.result.TargetsCount;
                }
            }

            public IPopsicleList<int> TargetsList
            {
                get
                {
                    return this.PrepareBuilder().targets_;
                }
            }

            protected override SubOption.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

