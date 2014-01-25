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
    public sealed class GetGameStatsResponse : GeneratedMessageLite<GetGameStatsResponse, Builder>
    {
        private static readonly string[] _getGameStatsResponseFieldNames = new string[] { "stats_bucket" };
        private static readonly uint[] _getGameStatsResponseFieldTags = new uint[] { 10 };
        private static readonly GetGameStatsResponse defaultInstance = new GetGameStatsResponse().MakeReadOnly();
        private int memoizedSerializedSize = -1;
        private PopsicleList<GameStatsBucket> statsBucket_ = new PopsicleList<GameStatsBucket>();
        public const int StatsBucketFieldNumber = 1;

        static GetGameStatsResponse()
        {
            object.ReferenceEquals(GameMaster.Descriptor, null);
        }

        private GetGameStatsResponse()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GetGameStatsResponse prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GetGameStatsResponse response = obj as GetGameStatsResponse;
            if (response == null)
            {
                return false;
            }
            if (this.statsBucket_.Count != response.statsBucket_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.statsBucket_.Count; i++)
            {
                if (!this.statsBucket_[i].Equals(response.statsBucket_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<GameStatsBucket> enumerator = this.statsBucket_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    GameStatsBucket current = enumerator.Current;
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

        public GameStatsBucket GetStatsBucket(int index)
        {
            return this.statsBucket_[index];
        }

        private GetGameStatsResponse MakeReadOnly()
        {
            this.statsBucket_.MakeReadOnly();
            return this;
        }

        public static GetGameStatsResponse ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GetGameStatsResponse ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetGameStatsResponse ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GetGameStatsResponse ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GetGameStatsResponse ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GetGameStatsResponse ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GetGameStatsResponse ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GetGameStatsResponse ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetGameStatsResponse ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetGameStatsResponse ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GetGameStatsResponse, Builder>.PrintField<GameStatsBucket>("stats_bucket", this.statsBucket_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _getGameStatsResponseFieldNames;
            if (this.statsBucket_.Count > 0)
            {
                output.WriteMessageArray<GameStatsBucket>(1, strArray[0], this.statsBucket_);
            }
        }

        public static GetGameStatsResponse DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GetGameStatsResponse DefaultInstanceForType
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

        public override int SerializedSize
        {
            get
            {
                int memoizedSerializedSize = this.memoizedSerializedSize;
                if (memoizedSerializedSize == -1)
                {
                    memoizedSerializedSize = 0;
                    IEnumerator<GameStatsBucket> enumerator = this.StatsBucketList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            GameStatsBucket current = enumerator.Current;
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

        protected override GetGameStatsResponse ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<GetGameStatsResponse, GetGameStatsResponse.Builder>
        {
            private GetGameStatsResponse result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GetGameStatsResponse.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GetGameStatsResponse cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public GetGameStatsResponse.Builder AddRangeStatsBucket(IEnumerable<GameStatsBucket> values)
            {
                this.PrepareBuilder();
                this.result.statsBucket_.Add(values);
                return this;
            }

            public GetGameStatsResponse.Builder AddStatsBucket(GameStatsBucket value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.statsBucket_.Add(value);
                return this;
            }

            public GetGameStatsResponse.Builder AddStatsBucket(GameStatsBucket.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.statsBucket_.Add(builderForValue.Build());
                return this;
            }

            public override GetGameStatsResponse BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GetGameStatsResponse.Builder Clear()
            {
                this.result = GetGameStatsResponse.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GetGameStatsResponse.Builder ClearStatsBucket()
            {
                this.PrepareBuilder();
                this.result.statsBucket_.Clear();
                return this;
            }

            public override GetGameStatsResponse.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GetGameStatsResponse.Builder(this.result);
                }
                return new GetGameStatsResponse.Builder().MergeFrom(this.result);
            }

            public GameStatsBucket GetStatsBucket(int index)
            {
                return this.result.GetStatsBucket(index);
            }

            public override GetGameStatsResponse.Builder MergeFrom(GetGameStatsResponse other)
            {
                if (other != GetGameStatsResponse.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.statsBucket_.Count != 0)
                    {
                        this.result.statsBucket_.Add(other.statsBucket_);
                    }
                }
                return this;
            }

            public override GetGameStatsResponse.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GetGameStatsResponse.Builder MergeFrom(IMessageLite other)
            {
                if (other is GetGameStatsResponse)
                {
                    return this.MergeFrom((GetGameStatsResponse) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GetGameStatsResponse.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GetGameStatsResponse._getGameStatsResponseFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GetGameStatsResponse._getGameStatsResponseFieldTags[index];
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
                    input.ReadMessageArray<GameStatsBucket>(num, str, this.result.statsBucket_, GameStatsBucket.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private GetGameStatsResponse PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GetGameStatsResponse result = this.result;
                    this.result = new GetGameStatsResponse();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public GetGameStatsResponse.Builder SetStatsBucket(int index, GameStatsBucket value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.statsBucket_[index] = value;
                return this;
            }

            public GetGameStatsResponse.Builder SetStatsBucket(int index, GameStatsBucket.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.statsBucket_[index] = builderForValue.Build();
                return this;
            }

            public override GetGameStatsResponse DefaultInstanceForType
            {
                get
                {
                    return GetGameStatsResponse.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override GetGameStatsResponse MessageBeingBuilt
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

            protected override GetGameStatsResponse.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

