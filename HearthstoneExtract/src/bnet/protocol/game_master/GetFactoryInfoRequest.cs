namespace bnet.protocol.game_master
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class GetFactoryInfoRequest : GeneratedMessageLite<GetFactoryInfoRequest, Builder>
    {
        private static readonly string[] _getFactoryInfoRequestFieldNames = new string[] { "factory_id" };
        private static readonly uint[] _getFactoryInfoRequestFieldTags = new uint[] { 9 };
        private static readonly GetFactoryInfoRequest defaultInstance = new GetFactoryInfoRequest().MakeReadOnly();
        private ulong factoryId_;
        public const int FactoryIdFieldNumber = 1;
        private bool hasFactoryId;
        private int memoizedSerializedSize = -1;

        static GetFactoryInfoRequest()
        {
            object.ReferenceEquals(GameMaster.Descriptor, null);
        }

        private GetFactoryInfoRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GetFactoryInfoRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GetFactoryInfoRequest request = obj as GetFactoryInfoRequest;
            if (request == null)
            {
                return false;
            }
            return ((this.hasFactoryId == request.hasFactoryId) && (!this.hasFactoryId || this.factoryId_.Equals(request.factoryId_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasFactoryId)
            {
                hashCode ^= this.factoryId_.GetHashCode();
            }
            return hashCode;
        }

        private GetFactoryInfoRequest MakeReadOnly()
        {
            return this;
        }

        public static GetFactoryInfoRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GetFactoryInfoRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetFactoryInfoRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GetFactoryInfoRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GetFactoryInfoRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GetFactoryInfoRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GetFactoryInfoRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GetFactoryInfoRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetFactoryInfoRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetFactoryInfoRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GetFactoryInfoRequest, Builder>.PrintField("factory_id", this.hasFactoryId, this.factoryId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _getFactoryInfoRequestFieldNames;
            if (this.hasFactoryId)
            {
                output.WriteFixed64(1, strArray[0], this.FactoryId);
            }
        }

        public static GetFactoryInfoRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GetFactoryInfoRequest DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        [CLSCompliant(false)]
        public ulong FactoryId
        {
            get
            {
                return this.factoryId_;
            }
        }

        public bool HasFactoryId
        {
            get
            {
                return this.hasFactoryId;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasFactoryId)
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
                    if (this.hasFactoryId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed64Size(1, this.FactoryId);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override GetFactoryInfoRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<GetFactoryInfoRequest, GetFactoryInfoRequest.Builder>
        {
            private GetFactoryInfoRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GetFactoryInfoRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GetFactoryInfoRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override GetFactoryInfoRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GetFactoryInfoRequest.Builder Clear()
            {
                this.result = GetFactoryInfoRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GetFactoryInfoRequest.Builder ClearFactoryId()
            {
                this.PrepareBuilder();
                this.result.hasFactoryId = false;
                this.result.factoryId_ = 0L;
                return this;
            }

            public override GetFactoryInfoRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GetFactoryInfoRequest.Builder(this.result);
                }
                return new GetFactoryInfoRequest.Builder().MergeFrom(this.result);
            }

            public override GetFactoryInfoRequest.Builder MergeFrom(GetFactoryInfoRequest other)
            {
                if (other != GetFactoryInfoRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasFactoryId)
                    {
                        this.FactoryId = other.FactoryId;
                    }
                }
                return this;
            }

            public override GetFactoryInfoRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GetFactoryInfoRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is GetFactoryInfoRequest)
                {
                    return this.MergeFrom((GetFactoryInfoRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GetFactoryInfoRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GetFactoryInfoRequest._getFactoryInfoRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GetFactoryInfoRequest._getFactoryInfoRequestFieldTags[index];
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

                        case 9:
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
                    this.result.hasFactoryId = input.ReadFixed64(ref this.result.factoryId_);
                }
                return this;
            }

            private GetFactoryInfoRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GetFactoryInfoRequest result = this.result;
                    this.result = new GetFactoryInfoRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public GetFactoryInfoRequest.Builder SetFactoryId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasFactoryId = true;
                this.result.factoryId_ = value;
                return this;
            }

            public override GetFactoryInfoRequest DefaultInstanceForType
            {
                get
                {
                    return GetFactoryInfoRequest.DefaultInstance;
                }
            }

            [CLSCompliant(false)]
            public ulong FactoryId
            {
                get
                {
                    return this.result.FactoryId;
                }
                set
                {
                    this.SetFactoryId(value);
                }
            }

            public bool HasFactoryId
            {
                get
                {
                    return this.result.hasFactoryId;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override GetFactoryInfoRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override GetFactoryInfoRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

