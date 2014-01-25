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

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class GetOptions : GeneratedMessageLite<GetOptions, Builder>
    {
        private static readonly string[] _getOptionsFieldNames = new string[] { "keys" };
        private static readonly uint[] _getOptionsFieldTags = new uint[] { 10 };
        private static readonly GetOptions defaultInstance = new GetOptions().MakeReadOnly();
        private PopsicleList<int> keys_ = new PopsicleList<int>();
        public const int KeysFieldNumber = 1;
        private int keysMemoizedSerializedSize;
        private int memoizedSerializedSize = -1;

        static GetOptions()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private GetOptions()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GetOptions prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GetOptions options = obj as GetOptions;
            if (options == null)
            {
                return false;
            }
            if (this.keys_.Count != options.keys_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.keys_.Count; i++)
            {
                int num2 = this.keys_[i];
                if (!num2.Equals(options.keys_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<int> enumerator = this.keys_.GetEnumerator();
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

        public int GetKeys(int index)
        {
            return this.keys_[index];
        }

        private GetOptions MakeReadOnly()
        {
            this.keys_.MakeReadOnly();
            return this;
        }

        public static GetOptions ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GetOptions ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetOptions ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GetOptions ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GetOptions ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GetOptions ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GetOptions ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GetOptions ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetOptions ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetOptions ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GetOptions, Builder>.PrintField<int>("keys", this.keys_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _getOptionsFieldNames;
            if (this.keys_.Count > 0)
            {
                output.WritePackedInt32Array(1, strArray[0], this.keysMemoizedSerializedSize, this.keys_);
            }
        }

        public static GetOptions DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GetOptions DefaultInstanceForType
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
                return true;
            }
        }

        public int KeysCount
        {
            get
            {
                return this.keys_.Count;
            }
        }

        public IList<int> KeysList
        {
            get
            {
                return Lists.AsReadOnly<int>(this.keys_);
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
                    int num2 = 0;
                    IEnumerator<int> enumerator = this.KeysList.GetEnumerator();
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
                    if (this.keys_.Count != 0)
                    {
                        memoizedSerializedSize += 1 + CodedOutputStream.ComputeInt32SizeNoTag(num2);
                    }
                    this.keysMemoizedSerializedSize = num2;
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override GetOptions ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<GetOptions, GetOptions.Builder>
        {
            private GetOptions result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GetOptions.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GetOptions cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public GetOptions.Builder AddKeys(int value)
            {
                this.PrepareBuilder();
                this.result.keys_.Add(value);
                return this;
            }

            public GetOptions.Builder AddRangeKeys(IEnumerable<int> values)
            {
                this.PrepareBuilder();
                this.result.keys_.Add(values);
                return this;
            }

            public override GetOptions BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GetOptions.Builder Clear()
            {
                this.result = GetOptions.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GetOptions.Builder ClearKeys()
            {
                this.PrepareBuilder();
                this.result.keys_.Clear();
                return this;
            }

            public override GetOptions.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GetOptions.Builder(this.result);
                }
                return new GetOptions.Builder().MergeFrom(this.result);
            }

            public int GetKeys(int index)
            {
                return this.result.GetKeys(index);
            }

            public override GetOptions.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GetOptions.Builder MergeFrom(IMessageLite other)
            {
                if (other is GetOptions)
                {
                    return this.MergeFrom((GetOptions) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GetOptions.Builder MergeFrom(GetOptions other)
            {
                if (other != GetOptions.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.keys_.Count != 0)
                    {
                        this.result.keys_.Add(other.keys_);
                    }
                }
                return this;
            }

            public override GetOptions.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GetOptions._getOptionsFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GetOptions._getOptionsFieldTags[index];
                        }
                        else
                        {
                            this.ParseUnknownField(input, extensionRegistry, num, str);
                            continue;
                        }
                    }
                    switch (num)
                    {
                        case 8:
                        case 10:
                            break;

                        case 0:
                            throw InvalidProtocolBufferException.InvalidTag();

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
                    input.ReadInt32Array(num, str, this.result.keys_);
                }
                return this;
            }

            private GetOptions PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GetOptions result = this.result;
                    this.result = new GetOptions();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public GetOptions.Builder SetKeys(int index, int value)
            {
                this.PrepareBuilder();
                this.result.keys_[index] = value;
                return this;
            }

            public override GetOptions DefaultInstanceForType
            {
                get
                {
                    return GetOptions.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public int KeysCount
            {
                get
                {
                    return this.result.KeysCount;
                }
            }

            public IPopsicleList<int> KeysList
            {
                get
                {
                    return this.PrepareBuilder().keys_;
                }
            }

            protected override GetOptions MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override GetOptions.Builder ThisBuilder
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
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 240,
                System = 0
            }
        }
    }
}

