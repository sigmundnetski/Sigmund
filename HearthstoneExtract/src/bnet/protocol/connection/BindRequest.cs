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

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class BindRequest : GeneratedMessageLite<BindRequest, Builder>
    {
        private static readonly string[] _bindRequestFieldNames = new string[] { "exported_service", "imported_service_hash" };
        private static readonly uint[] _bindRequestFieldTags = new uint[] { 0x12, 10 };
        private static readonly BindRequest defaultInstance = new BindRequest().MakeReadOnly();
        private PopsicleList<BoundService> exportedService_ = new PopsicleList<BoundService>();
        public const int ExportedServiceFieldNumber = 2;
        private PopsicleList<uint> importedServiceHash_ = new PopsicleList<uint>();
        public const int ImportedServiceHashFieldNumber = 1;
        private int importedServiceHashMemoizedSerializedSize;
        private int memoizedSerializedSize = -1;

        static BindRequest()
        {
            object.ReferenceEquals(Connect.Descriptor, null);
        }

        private BindRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(BindRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            BindRequest request = obj as BindRequest;
            if (request == null)
            {
                return false;
            }
            if (this.importedServiceHash_.Count != request.importedServiceHash_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.importedServiceHash_.Count; i++)
            {
                uint num3 = this.importedServiceHash_[i];
                if (!num3.Equals(request.importedServiceHash_[i]))
                {
                    return false;
                }
            }
            if (this.exportedService_.Count != request.exportedService_.Count)
            {
                return false;
            }
            for (int j = 0; j < this.exportedService_.Count; j++)
            {
                if (!this.exportedService_[j].Equals(request.exportedService_[j]))
                {
                    return false;
                }
            }
            return true;
        }

        public BoundService GetExportedService(int index)
        {
            return this.exportedService_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<uint> enumerator = this.importedServiceHash_.GetEnumerator();
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
            IEnumerator<BoundService> enumerator2 = this.exportedService_.GetEnumerator();
            try
            {
                while (enumerator2.MoveNext())
                {
                    BoundService service = enumerator2.Current;
                    hashCode ^= service.GetHashCode();
                }
            }
            finally
            {
                if (enumerator2 == null)
                {
                }
                enumerator2.Dispose();
            }
            return hashCode;
        }

        [CLSCompliant(false)]
        public uint GetImportedServiceHash(int index)
        {
            return this.importedServiceHash_[index];
        }

        private BindRequest MakeReadOnly()
        {
            this.importedServiceHash_.MakeReadOnly();
            this.exportedService_.MakeReadOnly();
            return this;
        }

        public static BindRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static BindRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static BindRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static BindRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static BindRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static BindRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static BindRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static BindRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static BindRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static BindRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<BindRequest, Builder>.PrintField<uint>("imported_service_hash", this.importedServiceHash_, writer);
            GeneratedMessageLite<BindRequest, Builder>.PrintField<BoundService>("exported_service", this.exportedService_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _bindRequestFieldNames;
            if (this.importedServiceHash_.Count > 0)
            {
                output.WritePackedFixed32Array(1, strArray[1], this.importedServiceHashMemoizedSerializedSize, this.importedServiceHash_);
            }
            if (this.exportedService_.Count > 0)
            {
                output.WriteMessageArray<BoundService>(2, strArray[0], this.exportedService_);
            }
        }

        public static BindRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override BindRequest DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public int ExportedServiceCount
        {
            get
            {
                return this.exportedService_.Count;
            }
        }

        public IList<BoundService> ExportedServiceList
        {
            get
            {
                return this.exportedService_;
            }
        }

        public int ImportedServiceHashCount
        {
            get
            {
                return this.importedServiceHash_.Count;
            }
        }

        [CLSCompliant(false)]
        public IList<uint> ImportedServiceHashList
        {
            get
            {
                return Lists.AsReadOnly<uint>(this.importedServiceHash_);
            }
        }

        public override bool IsInitialized
        {
            get
            {
                IEnumerator<BoundService> enumerator = this.ExportedServiceList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        BoundService current = enumerator.Current;
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
                    int num2 = 0;
                    num2 = 4 * this.importedServiceHash_.Count;
                    memoizedSerializedSize += num2;
                    if (this.importedServiceHash_.Count != 0)
                    {
                        memoizedSerializedSize += 1 + CodedOutputStream.ComputeInt32SizeNoTag(num2);
                    }
                    this.importedServiceHashMemoizedSerializedSize = num2;
                    IEnumerator<BoundService> enumerator = this.ExportedServiceList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            BoundService current = enumerator.Current;
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

        protected override BindRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<BindRequest, BindRequest.Builder>
        {
            private BindRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = BindRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(BindRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public BindRequest.Builder AddExportedService(BoundService value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.exportedService_.Add(value);
                return this;
            }

            public BindRequest.Builder AddExportedService(BoundService.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.exportedService_.Add(builderForValue.Build());
                return this;
            }

            [CLSCompliant(false)]
            public BindRequest.Builder AddImportedServiceHash(uint value)
            {
                this.PrepareBuilder();
                this.result.importedServiceHash_.Add(value);
                return this;
            }

            public BindRequest.Builder AddRangeExportedService(IEnumerable<BoundService> values)
            {
                this.PrepareBuilder();
                this.result.exportedService_.Add(values);
                return this;
            }

            [CLSCompliant(false)]
            public BindRequest.Builder AddRangeImportedServiceHash(IEnumerable<uint> values)
            {
                this.PrepareBuilder();
                this.result.importedServiceHash_.Add(values);
                return this;
            }

            public override BindRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override BindRequest.Builder Clear()
            {
                this.result = BindRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public BindRequest.Builder ClearExportedService()
            {
                this.PrepareBuilder();
                this.result.exportedService_.Clear();
                return this;
            }

            public BindRequest.Builder ClearImportedServiceHash()
            {
                this.PrepareBuilder();
                this.result.importedServiceHash_.Clear();
                return this;
            }

            public override BindRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new BindRequest.Builder(this.result);
                }
                return new BindRequest.Builder().MergeFrom(this.result);
            }

            public BoundService GetExportedService(int index)
            {
                return this.result.GetExportedService(index);
            }

            [CLSCompliant(false)]
            public uint GetImportedServiceHash(int index)
            {
                return this.result.GetImportedServiceHash(index);
            }

            public override BindRequest.Builder MergeFrom(BindRequest other)
            {
                if (other != BindRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.importedServiceHash_.Count != 0)
                    {
                        this.result.importedServiceHash_.Add(other.importedServiceHash_);
                    }
                    if (other.exportedService_.Count != 0)
                    {
                        this.result.exportedService_.Add(other.exportedService_);
                    }
                }
                return this;
            }

            public override BindRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override BindRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is BindRequest)
                {
                    return this.MergeFrom((BindRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override BindRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(BindRequest._bindRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = BindRequest._bindRequestFieldTags[index];
                        }
                        else
                        {
                            this.ParseUnknownField(input, extensionRegistry, num, str);
                            continue;
                        }
                    }
                    switch (num)
                    {
                        case 10:
                        case 13:
                        {
                            input.ReadFixed32Array(num, str, this.result.importedServiceHash_);
                            continue;
                        }
                        case 0:
                            throw InvalidProtocolBufferException.InvalidTag();

                        case 0x12:
                            goto Label_00B7;

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
                Label_00B7:
                    input.ReadMessageArray<BoundService>(num, str, this.result.exportedService_, BoundService.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private BindRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    BindRequest result = this.result;
                    this.result = new BindRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public BindRequest.Builder SetExportedService(int index, BoundService value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.exportedService_[index] = value;
                return this;
            }

            public BindRequest.Builder SetExportedService(int index, BoundService.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.exportedService_[index] = builderForValue.Build();
                return this;
            }

            [CLSCompliant(false)]
            public BindRequest.Builder SetImportedServiceHash(int index, uint value)
            {
                this.PrepareBuilder();
                this.result.importedServiceHash_[index] = value;
                return this;
            }

            public override BindRequest DefaultInstanceForType
            {
                get
                {
                    return BindRequest.DefaultInstance;
                }
            }

            public int ExportedServiceCount
            {
                get
                {
                    return this.result.ExportedServiceCount;
                }
            }

            public IPopsicleList<BoundService> ExportedServiceList
            {
                get
                {
                    return this.PrepareBuilder().exportedService_;
                }
            }

            public int ImportedServiceHashCount
            {
                get
                {
                    return this.result.ImportedServiceHashCount;
                }
            }

            [CLSCompliant(false)]
            public IPopsicleList<uint> ImportedServiceHashList
            {
                get
                {
                    return this.PrepareBuilder().importedServiceHash_;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override BindRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override BindRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

