namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using PegasusShared;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class AtlasCollection : GeneratedMessageLite<AtlasCollection, Builder>
    {
        private static readonly string[] _atlasCollectionFieldNames = new string[] { "stacks" };
        private static readonly uint[] _atlasCollectionFieldTags = new uint[] { 10 };
        private static readonly AtlasCollection defaultInstance = new AtlasCollection().MakeReadOnly();
        private int memoizedSerializedSize = -1;
        private PopsicleList<CardStack> stacks_ = new PopsicleList<CardStack>();
        public const int StacksFieldNumber = 1;

        static AtlasCollection()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AtlasCollection()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AtlasCollection prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AtlasCollection atlass = obj as AtlasCollection;
            if (atlass == null)
            {
                return false;
            }
            if (this.stacks_.Count != atlass.stacks_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.stacks_.Count; i++)
            {
                if (!this.stacks_[i].Equals(atlass.stacks_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<CardStack> enumerator = this.stacks_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    CardStack current = enumerator.Current;
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

        public CardStack GetStacks(int index)
        {
            return this.stacks_[index];
        }

        private AtlasCollection MakeReadOnly()
        {
            this.stacks_.MakeReadOnly();
            return this;
        }

        public static AtlasCollection ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AtlasCollection ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasCollection ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasCollection ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasCollection ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasCollection ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasCollection ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AtlasCollection ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasCollection ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasCollection ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AtlasCollection, Builder>.PrintField<CardStack>("stacks", this.stacks_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _atlasCollectionFieldNames;
            if (this.stacks_.Count > 0)
            {
                output.WriteMessageArray<CardStack>(1, strArray[0], this.stacks_);
            }
        }

        public static AtlasCollection DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AtlasCollection DefaultInstanceForType
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
                IEnumerator<CardStack> enumerator = this.StacksList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        CardStack current = enumerator.Current;
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
                    IEnumerator<CardStack> enumerator = this.StacksList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            CardStack current = enumerator.Current;
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

        public int StacksCount
        {
            get
            {
                return this.stacks_.Count;
            }
        }

        public IList<CardStack> StacksList
        {
            get
            {
                return this.stacks_;
            }
        }

        protected override AtlasCollection ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<AtlasCollection, AtlasCollection.Builder>
        {
            private AtlasCollection result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AtlasCollection.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AtlasCollection cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public AtlasCollection.Builder AddRangeStacks(IEnumerable<CardStack> values)
            {
                this.PrepareBuilder();
                this.result.stacks_.Add(values);
                return this;
            }

            public AtlasCollection.Builder AddStacks(CardStack value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.stacks_.Add(value);
                return this;
            }

            public AtlasCollection.Builder AddStacks(CardStack.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.stacks_.Add(builderForValue.Build());
                return this;
            }

            public override AtlasCollection BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AtlasCollection.Builder Clear()
            {
                this.result = AtlasCollection.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AtlasCollection.Builder ClearStacks()
            {
                this.PrepareBuilder();
                this.result.stacks_.Clear();
                return this;
            }

            public override AtlasCollection.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AtlasCollection.Builder(this.result);
                }
                return new AtlasCollection.Builder().MergeFrom(this.result);
            }

            public CardStack GetStacks(int index)
            {
                return this.result.GetStacks(index);
            }

            public override AtlasCollection.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AtlasCollection.Builder MergeFrom(IMessageLite other)
            {
                if (other is AtlasCollection)
                {
                    return this.MergeFrom((AtlasCollection) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AtlasCollection.Builder MergeFrom(AtlasCollection other)
            {
                if (other != AtlasCollection.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.stacks_.Count != 0)
                    {
                        this.result.stacks_.Add(other.stacks_);
                    }
                }
                return this;
            }

            public override AtlasCollection.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AtlasCollection._atlasCollectionFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AtlasCollection._atlasCollectionFieldTags[index];
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
                    input.ReadMessageArray<CardStack>(num, str, this.result.stacks_, CardStack.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private AtlasCollection PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AtlasCollection result = this.result;
                    this.result = new AtlasCollection();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public AtlasCollection.Builder SetStacks(int index, CardStack value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.stacks_[index] = value;
                return this;
            }

            public AtlasCollection.Builder SetStacks(int index, CardStack.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.stacks_[index] = builderForValue.Build();
                return this;
            }

            public override AtlasCollection DefaultInstanceForType
            {
                get
                {
                    return AtlasCollection.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override AtlasCollection MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int StacksCount
            {
                get
                {
                    return this.result.StacksCount;
                }
            }

            public IPopsicleList<CardStack> StacksList
            {
                get
                {
                    return this.PrepareBuilder().stacks_;
                }
            }

            protected override AtlasCollection.Builder ThisBuilder
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
                ID = 0x66
            }
        }
    }
}

