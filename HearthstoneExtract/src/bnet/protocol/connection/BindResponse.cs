namespace bnet.protocol.connection
{
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class BindResponse : GeneratedMessageLite<BindResponse, Builder>
    {
        private static readonly string[] _bindResponseFieldNames = new string[] { "imported_service_id" };
        private static readonly uint[] _bindResponseFieldTags = new uint[] { 10 };
        private static readonly BindResponse defaultInstance = new BindResponse().MakeReadOnly();
        private PopsicleList<uint> importedServiceId_ = new PopsicleList<uint>();
        public const int ImportedServiceIdFieldNumber = 1;
        private int importedServiceIdMemoizedSerializedSize;
        private int memoizedSerializedSize = -1;

        static BindResponse()
        {
            object.ReferenceEquals(Connect.Descriptor, null);
        }

        private BindResponse()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(BindResponse prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            BindResponse response = obj as BindResponse;
            if (response == null)
            {
                return false;
            }
            if (this.importedServiceId_.Count != response.importedServiceId_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.importedServiceId_.Count; i++)
            {
                uint num2 = this.importedServiceId_[i];
                if (!num2.Equals(response.importedServiceId_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<uint> enumerator = this.importedServiceId_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    uint current = enumerator.Current;
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

        [CLSCompliant(false)]
        public uint GetImportedServiceId(int index)
        {
            return this.importedServiceId_[index];
        }

        private BindResponse MakeReadOnly()
        {
            this.importedServiceId_.MakeReadOnly();
            return this;
        }

        public static BindResponse ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static BindResponse ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static BindResponse ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static BindResponse ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static BindResponse ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static BindResponse ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static BindResponse ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static BindResponse ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static BindResponse ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static BindResponse ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<BindResponse, Builder>.PrintField<uint>("imported_service_id", this.importedServiceId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _bindResponseFieldNames;
            if (this.importedServiceId_.Count > 0)
            {
                output.WritePackedUInt32Array(1, strArray[0], this.importedServiceIdMemoizedSerializedSize, this.importedServiceId_);
            }
        }

        public static BindResponse DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override BindResponse DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public int ImportedServiceIdCount
        {
            get
            {
                return this.importedServiceId_.Count;
            }
        }

        [CLSCompliant(false)]
        public IList<uint> ImportedServiceIdList
        {
            get
            {
                return Lists.AsReadOnly<uint>(this.importedServiceId_);
            }
        }

        public override bool IsInitialized
        {
            get
            {
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
                    int num2 = 0;
                    IEnumerator<uint> enumerator = this.ImportedServiceIdList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            uint current = enumerator.Current;
                            num2 += CodedOutputStream.ComputeUInt32SizeNoTag(current);
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
                    if (this.importedServiceId_.Count != 0)
                    {
                        memoizedSerializedSize += 1 + CodedOutputStream.ComputeInt32SizeNoTag(num2);
                    }
                    this.importedServiceIdMemoizedSerializedSize = num2;
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override BindResponse ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<BindResponse, BindResponse.Builder>
        {
            private BindResponse result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = BindResponse.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(BindResponse cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            [CLSCompliant(false)]
            public BindResponse.Builder AddImportedServiceId(uint value)
            {
                this.PrepareBuilder();
                this.result.importedServiceId_.Add(value);
                return this;
            }

            [CLSCompliant(false)]
            public BindResponse.Builder AddRangeImportedServiceId(IEnumerable<uint> values)
            {
                this.PrepareBuilder();
                this.result.importedServiceId_.Add(values);
                return this;
            }

            public override BindResponse BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override BindResponse.Builder Clear()
            {
                this.result = BindResponse.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public BindResponse.Builder ClearImportedServiceId()
            {
                this.PrepareBuilder();
                this.result.importedServiceId_.Clear();
                return this;
            }

            public override BindResponse.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new BindResponse.Builder(this.result);
                }
                return new BindResponse.Builder().MergeFrom(this.result);
            }

            [CLSCompliant(false)]
            public uint GetImportedServiceId(int index)
            {
                return this.result.GetImportedServiceId(index);
            }

            public override BindResponse.Builder MergeFrom(BindResponse other)
            {
                if (other != BindResponse.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.importedServiceId_.Count != 0)
                    {
                        this.result.importedServiceId_.Add(other.importedServiceId_);
                    }
                }
                return this;
            }

            public override BindResponse.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override BindResponse.Builder MergeFrom(IMessageLite other)
            {
                if (other is BindResponse)
                {
                    return this.MergeFrom((BindResponse) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override BindResponse.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(BindResponse._bindResponseFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = BindResponse._bindResponseFieldTags[index];
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
                    input.ReadUInt32Array(num, str, this.result.importedServiceId_);
                }
                return this;
            }

            private BindResponse PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    BindResponse result = this.result;
                    this.result = new BindResponse();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public BindResponse.Builder SetImportedServiceId(int index, uint value)
            {
                this.PrepareBuilder();
                this.result.importedServiceId_[index] = value;
                return this;
            }

            public override BindResponse DefaultInstanceForType
            {
                get
                {
                    return BindResponse.DefaultInstance;
                }
            }

            public int ImportedServiceIdCount
            {
                get
                {
                    return this.result.ImportedServiceIdCount;
                }
            }

            [CLSCompliant(false)]
            public IPopsicleList<uint> ImportedServiceIdList
            {
                get
                {
                    return this.PrepareBuilder().importedServiceId_;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override BindResponse MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override BindResponse.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

