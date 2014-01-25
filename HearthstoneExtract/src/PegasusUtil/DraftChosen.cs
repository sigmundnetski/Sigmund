namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class DraftChosen : GeneratedMessageLite<DraftChosen, Builder>
    {
        private static readonly string[] _draftChosenFieldNames = new string[] { "asset", "next_choices" };
        private static readonly uint[] _draftChosenFieldTags = new uint[] { 8, 0x12 };
        private int asset_;
        public const int AssetFieldNumber = 1;
        private static readonly DraftChosen defaultInstance = new DraftChosen().MakeReadOnly();
        private bool hasAsset;
        private int memoizedSerializedSize = -1;
        private PopsicleList<int> nextChoices_ = new PopsicleList<int>();
        public const int NextChoicesFieldNumber = 2;
        private int nextChoicesMemoizedSerializedSize;

        static DraftChosen()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private DraftChosen()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DraftChosen prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DraftChosen chosen = obj as DraftChosen;
            if (chosen == null)
            {
                return false;
            }
            if ((this.hasAsset != chosen.hasAsset) || (this.hasAsset && !this.asset_.Equals(chosen.asset_)))
            {
                return false;
            }
            if (this.nextChoices_.Count != chosen.nextChoices_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.nextChoices_.Count; i++)
            {
                int num2 = this.nextChoices_[i];
                if (!num2.Equals(chosen.nextChoices_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasAsset)
            {
                hashCode ^= this.asset_.GetHashCode();
            }
            IEnumerator<int> enumerator = this.nextChoices_.GetEnumerator();
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

        public int GetNextChoices(int index)
        {
            return this.nextChoices_[index];
        }

        private DraftChosen MakeReadOnly()
        {
            this.nextChoices_.MakeReadOnly();
            return this;
        }

        public static DraftChosen ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DraftChosen ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DraftChosen ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DraftChosen ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DraftChosen ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DraftChosen ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DraftChosen ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DraftChosen ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DraftChosen ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DraftChosen ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DraftChosen, Builder>.PrintField("asset", this.hasAsset, this.asset_, writer);
            GeneratedMessageLite<DraftChosen, Builder>.PrintField<int>("next_choices", this.nextChoices_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _draftChosenFieldNames;
            if (this.hasAsset)
            {
                output.WriteInt32(1, strArray[0], this.Asset);
            }
            if (this.nextChoices_.Count > 0)
            {
                output.WritePackedInt32Array(2, strArray[1], this.nextChoicesMemoizedSerializedSize, this.nextChoices_);
            }
        }

        public int Asset
        {
            get
            {
                return this.asset_;
            }
        }

        public static DraftChosen DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DraftChosen DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasAsset
        {
            get
            {
                return this.hasAsset;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasAsset)
                {
                    return false;
                }
                return true;
            }
        }

        public int NextChoicesCount
        {
            get
            {
                return this.nextChoices_.Count;
            }
        }

        public IList<int> NextChoicesList
        {
            get
            {
                return Lists.AsReadOnly<int>(this.nextChoices_);
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
                    if (this.hasAsset)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.Asset);
                    }
                    int num2 = 0;
                    IEnumerator<int> enumerator = this.NextChoicesList.GetEnumerator();
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
                    if (this.nextChoices_.Count != 0)
                    {
                        memoizedSerializedSize += 1 + CodedOutputStream.ComputeInt32SizeNoTag(num2);
                    }
                    this.nextChoicesMemoizedSerializedSize = num2;
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override DraftChosen ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<DraftChosen, DraftChosen.Builder>
        {
            private DraftChosen result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DraftChosen.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DraftChosen cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public DraftChosen.Builder AddNextChoices(int value)
            {
                this.PrepareBuilder();
                this.result.nextChoices_.Add(value);
                return this;
            }

            public DraftChosen.Builder AddRangeNextChoices(IEnumerable<int> values)
            {
                this.PrepareBuilder();
                this.result.nextChoices_.Add(values);
                return this;
            }

            public override DraftChosen BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DraftChosen.Builder Clear()
            {
                this.result = DraftChosen.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DraftChosen.Builder ClearAsset()
            {
                this.PrepareBuilder();
                this.result.hasAsset = false;
                this.result.asset_ = 0;
                return this;
            }

            public DraftChosen.Builder ClearNextChoices()
            {
                this.PrepareBuilder();
                this.result.nextChoices_.Clear();
                return this;
            }

            public override DraftChosen.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DraftChosen.Builder(this.result);
                }
                return new DraftChosen.Builder().MergeFrom(this.result);
            }

            public int GetNextChoices(int index)
            {
                return this.result.GetNextChoices(index);
            }

            public override DraftChosen.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DraftChosen.Builder MergeFrom(IMessageLite other)
            {
                if (other is DraftChosen)
                {
                    return this.MergeFrom((DraftChosen) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DraftChosen.Builder MergeFrom(DraftChosen other)
            {
                if (other != DraftChosen.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAsset)
                    {
                        this.Asset = other.Asset;
                    }
                    if (other.nextChoices_.Count != 0)
                    {
                        this.result.nextChoices_.Add(other.nextChoices_);
                    }
                }
                return this;
            }

            public override DraftChosen.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DraftChosen._draftChosenFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DraftChosen._draftChosenFieldTags[index];
                        }
                        else
                        {
                            this.ParseUnknownField(input, extensionRegistry, num, str);
                            continue;
                        }
                    }
                    switch (num)
                    {
                        case 0x10:
                        case 0x12:
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
                    this.result.hasAsset = input.ReadInt32(ref this.result.asset_);
                    continue;
                Label_00BB:
                    input.ReadInt32Array(num, str, this.result.nextChoices_);
                }
                return this;
            }

            private DraftChosen PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DraftChosen result = this.result;
                    this.result = new DraftChosen();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DraftChosen.Builder SetAsset(int value)
            {
                this.PrepareBuilder();
                this.result.hasAsset = true;
                this.result.asset_ = value;
                return this;
            }

            public DraftChosen.Builder SetNextChoices(int index, int value)
            {
                this.PrepareBuilder();
                this.result.nextChoices_[index] = value;
                return this;
            }

            public int Asset
            {
                get
                {
                    return this.result.Asset;
                }
                set
                {
                    this.SetAsset(value);
                }
            }

            public override DraftChosen DefaultInstanceForType
            {
                get
                {
                    return DraftChosen.DefaultInstance;
                }
            }

            public bool HasAsset
            {
                get
                {
                    return this.result.hasAsset;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override DraftChosen MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int NextChoicesCount
            {
                get
                {
                    return this.result.NextChoicesCount;
                }
            }

            public IPopsicleList<int> NextChoicesList
            {
                get
                {
                    return this.PrepareBuilder().nextChoices_;
                }
            }

            protected override DraftChosen.Builder ThisBuilder
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
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0xf9
            }
        }
    }
}

