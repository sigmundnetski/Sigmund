namespace bnet.protocol.game_master
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
    public sealed class GetFactoryInfoResponse : GeneratedMessageLite<GetFactoryInfoResponse, Builder>
    {
        private static readonly string[] _getFactoryInfoResponseFieldNames = new string[] { "attribute", "stats_bucket" };
        private static readonly uint[] _getFactoryInfoResponseFieldTags = new uint[] { 10, 0x12 };
        private PopsicleList<bnet.protocol.game_master.Attribute> attribute_ = new PopsicleList<bnet.protocol.game_master.Attribute>();
        public const int AttributeFieldNumber = 1;
        private static readonly GetFactoryInfoResponse defaultInstance = new GetFactoryInfoResponse().MakeReadOnly();
        private int memoizedSerializedSize = -1;
        private PopsicleList<GameStatsBucket> statsBucket_ = new PopsicleList<GameStatsBucket>();
        public const int StatsBucketFieldNumber = 2;

        static GetFactoryInfoResponse()
        {
            object.ReferenceEquals(GameMaster.Descriptor, null);
        }

        private GetFactoryInfoResponse()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GetFactoryInfoResponse prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GetFactoryInfoResponse response = obj as GetFactoryInfoResponse;
            if (response == null)
            {
                return false;
            }
            if (this.attribute_.Count != response.attribute_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.attribute_.Count; i++)
            {
                if (!this.attribute_[i].Equals(response.attribute_[i]))
                {
                    return false;
                }
            }
            if (this.statsBucket_.Count != response.statsBucket_.Count)
            {
                return false;
            }
            for (int j = 0; j < this.statsBucket_.Count; j++)
            {
                if (!this.statsBucket_[j].Equals(response.statsBucket_[j]))
                {
                    return false;
                }
            }
            return true;
        }

        public bnet.protocol.game_master.Attribute GetAttribute(int index)
        {
            return this.attribute_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<bnet.protocol.game_master.Attribute> enumerator = this.attribute_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    bnet.protocol.game_master.Attribute current = enumerator.Current;
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
            IEnumerator<GameStatsBucket> enumerator2 = this.statsBucket_.GetEnumerator();
            try
            {
                while (enumerator2.MoveNext())
                {
                    GameStatsBucket bucket = enumerator2.Current;
                    hashCode ^= bucket.GetHashCode();
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

        public GameStatsBucket GetStatsBucket(int index)
        {
            return this.statsBucket_[index];
        }

        private GetFactoryInfoResponse MakeReadOnly()
        {
            this.attribute_.MakeReadOnly();
            this.statsBucket_.MakeReadOnly();
            return this;
        }

        public static GetFactoryInfoResponse ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GetFactoryInfoResponse ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetFactoryInfoResponse ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GetFactoryInfoResponse ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GetFactoryInfoResponse ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GetFactoryInfoResponse ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GetFactoryInfoResponse ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GetFactoryInfoResponse ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetFactoryInfoResponse ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetFactoryInfoResponse ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GetFactoryInfoResponse, Builder>.PrintField<bnet.protocol.game_master.Attribute>("attribute", this.attribute_, writer);
            GeneratedMessageLite<GetFactoryInfoResponse, Builder>.PrintField<GameStatsBucket>("stats_bucket", this.statsBucket_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _getFactoryInfoResponseFieldNames;
            if (this.attribute_.Count > 0)
            {
                output.WriteMessageArray<bnet.protocol.game_master.Attribute>(1, strArray[0], this.attribute_);
            }
            if (this.statsBucket_.Count > 0)
            {
                output.WriteMessageArray<GameStatsBucket>(2, strArray[1], this.statsBucket_);
            }
        }

        public int AttributeCount
        {
            get
            {
                return this.attribute_.Count;
            }
        }

        public IList<bnet.protocol.game_master.Attribute> AttributeList
        {
            get
            {
                return this.attribute_;
            }
        }

        public static GetFactoryInfoResponse DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GetFactoryInfoResponse DefaultInstanceForType
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
                IEnumerator<bnet.protocol.game_master.Attribute> enumerator = this.AttributeList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        bnet.protocol.game_master.Attribute current = enumerator.Current;
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
                    IEnumerator<bnet.protocol.game_master.Attribute> enumerator = this.AttributeList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            bnet.protocol.game_master.Attribute current = enumerator.Current;
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
                    IEnumerator<GameStatsBucket> enumerator2 = this.StatsBucketList.GetEnumerator();
                    try
                    {
                        while (enumerator2.MoveNext())
                        {
                            GameStatsBucket bucket = enumerator2.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, bucket);
                        }
                    }
                    finally
                    {
                        if (enumerator2 == null)
                        {
                        }
                        enumerator2.Dispose();
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        public int StatsBucketCount
        {
            get
            {
                return this.statsBucket_.Count;
            }
        }

        public IList<GameStatsBucket> StatsBucketList
        {
            get
            {
                return this.statsBucket_;
            }
        }

        protected override GetFactoryInfoResponse ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<GetFactoryInfoResponse, GetFactoryInfoResponse.Builder>
        {
            private GetFactoryInfoResponse result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GetFactoryInfoResponse.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GetFactoryInfoResponse cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public GetFactoryInfoResponse.Builder AddAttribute(bnet.protocol.game_master.Attribute value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.attribute_.Add(value);
                return this;
            }

            public GetFactoryInfoResponse.Builder AddAttribute(bnet.protocol.game_master.Attribute.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.attribute_.Add(builderForValue.Build());
                return this;
            }

            public GetFactoryInfoResponse.Builder AddRangeAttribute(IEnumerable<bnet.protocol.game_master.Attribute> values)
            {
                this.PrepareBuilder();
                this.result.attribute_.Add(values);
                return this;
            }

            public GetFactoryInfoResponse.Builder AddRangeStatsBucket(IEnumerable<GameStatsBucket> values)
            {
                this.PrepareBuilder();
                this.result.statsBucket_.Add(values);
                return this;
            }

            public GetFactoryInfoResponse.Builder AddStatsBucket(GameStatsBucket value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.statsBucket_.Add(value);
                return this;
            }

            public GetFactoryInfoResponse.Builder AddStatsBucket(GameStatsBucket.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.statsBucket_.Add(builderForValue.Build());
                return this;
            }

            public override GetFactoryInfoResponse BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GetFactoryInfoResponse.Builder Clear()
            {
                this.result = GetFactoryInfoResponse.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GetFactoryInfoResponse.Builder ClearAttribute()
            {
                this.PrepareBuilder();
                this.result.attribute_.Clear();
                return this;
            }

            public GetFactoryInfoResponse.Builder ClearStatsBucket()
            {
                this.PrepareBuilder();
                this.result.statsBucket_.Clear();
                return this;
            }

            public override GetFactoryInfoResponse.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GetFactoryInfoResponse.Builder(this.result);
                }
                return new GetFactoryInfoResponse.Builder().MergeFrom(this.result);
            }

            public bnet.protocol.game_master.Attribute GetAttribute(int index)
            {
                return this.result.GetAttribute(index);
            }

            public GameStatsBucket GetStatsBucket(int index)
            {
                return this.result.GetStatsBucket(index);
            }

            public override GetFactoryInfoResponse.Builder MergeFrom(GetFactoryInfoResponse other)
            {
                if (other != GetFactoryInfoResponse.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.attribute_.Count != 0)
                    {
                        this.result.attribute_.Add(other.attribute_);
                    }
                    if (other.statsBucket_.Count != 0)
                    {
                        this.result.statsBucket_.Add(other.statsBucket_);
                    }
                }
                return this;
            }

            public override GetFactoryInfoResponse.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GetFactoryInfoResponse.Builder MergeFrom(IMessageLite other)
            {
                if (other is GetFactoryInfoResponse)
                {
                    return this.MergeFrom((GetFactoryInfoResponse) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GetFactoryInfoResponse.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GetFactoryInfoResponse._getFactoryInfoResponseFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GetFactoryInfoResponse._getFactoryInfoResponseFieldTags[index];
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
                            input.ReadMessageArray<bnet.protocol.game_master.Attribute>(num, str, this.result.attribute_, bnet.protocol.game_master.Attribute.DefaultInstance, extensionRegistry);
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
                    input.ReadMessageArray<GameStatsBucket>(num, str, this.result.statsBucket_, GameStatsBucket.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private GetFactoryInfoResponse PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GetFactoryInfoResponse result = this.result;
                    this.result = new GetFactoryInfoResponse();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public GetFactoryInfoResponse.Builder SetAttribute(int index, bnet.protocol.game_master.Attribute value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.attribute_[index] = value;
                return this;
            }

            public GetFactoryInfoResponse.Builder SetAttribute(int index, bnet.protocol.game_master.Attribute.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.attribute_[index] = builderForValue.Build();
                return this;
            }

            public GetFactoryInfoResponse.Builder SetStatsBucket(int index, GameStatsBucket value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.statsBucket_[index] = value;
                return this;
            }

            public GetFactoryInfoResponse.Builder SetStatsBucket(int index, GameStatsBucket.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.statsBucket_[index] = builderForValue.Build();
                return this;
            }

            public int AttributeCount
            {
                get
                {
                    return this.result.AttributeCount;
                }
            }

            public IPopsicleList<bnet.protocol.game_master.Attribute> AttributeList
            {
                get
                {
                    return this.PrepareBuilder().attribute_;
                }
            }

            public override GetFactoryInfoResponse DefaultInstanceForType
            {
                get
                {
                    return GetFactoryInfoResponse.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override GetFactoryInfoResponse MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int StatsBucketCount
            {
                get
                {
                    return this.result.StatsBucketCount;
                }
            }

            public IPopsicleList<GameStatsBucket> StatsBucketList
            {
                get
                {
                    return this.PrepareBuilder().statsBucket_;
                }
            }

            protected override GetFactoryInfoResponse.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

