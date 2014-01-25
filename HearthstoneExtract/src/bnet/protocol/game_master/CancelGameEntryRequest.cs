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

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class CancelGameEntryRequest : GeneratedMessageLite<CancelGameEntryRequest, Builder>
    {
        private static readonly string[] _cancelGameEntryRequestFieldNames = new string[] { "factory_id", "player", "request_id" };
        private static readonly uint[] _cancelGameEntryRequestFieldTags = new uint[] { 0x11, 0x1a, 9 };
        private static readonly CancelGameEntryRequest defaultInstance = new CancelGameEntryRequest().MakeReadOnly();
        private ulong factoryId_;
        public const int FactoryIdFieldNumber = 2;
        private bool hasFactoryId;
        private bool hasRequestId;
        private int memoizedSerializedSize = -1;
        private PopsicleList<Player> player_ = new PopsicleList<Player>();
        public const int PlayerFieldNumber = 3;
        private ulong requestId_;
        public const int RequestIdFieldNumber = 1;

        static CancelGameEntryRequest()
        {
            object.ReferenceEquals(GameMaster.Descriptor, null);
        }

        private CancelGameEntryRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(CancelGameEntryRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            CancelGameEntryRequest request = obj as CancelGameEntryRequest;
            if (request == null)
            {
                return false;
            }
            if ((this.hasRequestId != request.hasRequestId) || (this.hasRequestId && !this.requestId_.Equals(request.requestId_)))
            {
                return false;
            }
            if ((this.hasFactoryId != request.hasFactoryId) || (this.hasFactoryId && !this.factoryId_.Equals(request.factoryId_)))
            {
                return false;
            }
            if (this.player_.Count != request.player_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.player_.Count; i++)
            {
                if (!this.player_[i].Equals(request.player_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasRequestId)
            {
                hashCode ^= this.requestId_.GetHashCode();
            }
            if (this.hasFactoryId)
            {
                hashCode ^= this.factoryId_.GetHashCode();
            }
            IEnumerator<Player> enumerator = this.player_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    Player current = enumerator.Current;
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

        public Player GetPlayer(int index)
        {
            return this.player_[index];
        }

        private CancelGameEntryRequest MakeReadOnly()
        {
            this.player_.MakeReadOnly();
            return this;
        }

        public static CancelGameEntryRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static CancelGameEntryRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static CancelGameEntryRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static CancelGameEntryRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static CancelGameEntryRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static CancelGameEntryRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static CancelGameEntryRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static CancelGameEntryRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static CancelGameEntryRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static CancelGameEntryRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<CancelGameEntryRequest, Builder>.PrintField("request_id", this.hasRequestId, this.requestId_, writer);
            GeneratedMessageLite<CancelGameEntryRequest, Builder>.PrintField("factory_id", this.hasFactoryId, this.factoryId_, writer);
            GeneratedMessageLite<CancelGameEntryRequest, Builder>.PrintField<Player>("player", this.player_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _cancelGameEntryRequestFieldNames;
            if (this.hasRequestId)
            {
                output.WriteFixed64(1, strArray[2], this.RequestId);
            }
            if (this.hasFactoryId)
            {
                output.WriteFixed64(2, strArray[0], this.FactoryId);
            }
            if (this.player_.Count > 0)
            {
                output.WriteMessageArray<Player>(3, strArray[1], this.player_);
            }
        }

        public static CancelGameEntryRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override CancelGameEntryRequest DefaultInstanceForType
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

        public bool HasRequestId
        {
            get
            {
                return this.hasRequestId;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasRequestId)
                {
                    return false;
                }
                IEnumerator<Player> enumerator = this.PlayerList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        Player current = enumerator.Current;
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

        public int PlayerCount
        {
            get
            {
                return this.player_.Count;
            }
        }

        public IList<Player> PlayerList
        {
            get
            {
                return this.player_;
            }
        }

        [CLSCompliant(false)]
        public ulong RequestId
        {
            get
            {
                return this.requestId_;
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
                    if (this.hasRequestId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed64Size(1, this.RequestId);
                    }
                    if (this.hasFactoryId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed64Size(2, this.FactoryId);
                    }
                    IEnumerator<Player> enumerator = this.PlayerList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            Player current = enumerator.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(3, current);
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

        protected override CancelGameEntryRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<CancelGameEntryRequest, CancelGameEntryRequest.Builder>
        {
            private CancelGameEntryRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = CancelGameEntryRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(CancelGameEntryRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public CancelGameEntryRequest.Builder AddPlayer(Player value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.player_.Add(value);
                return this;
            }

            public CancelGameEntryRequest.Builder AddPlayer(Player.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.player_.Add(builderForValue.Build());
                return this;
            }

            public CancelGameEntryRequest.Builder AddRangePlayer(IEnumerable<Player> values)
            {
                this.PrepareBuilder();
                this.result.player_.Add(values);
                return this;
            }

            public override CancelGameEntryRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override CancelGameEntryRequest.Builder Clear()
            {
                this.result = CancelGameEntryRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public CancelGameEntryRequest.Builder ClearFactoryId()
            {
                this.PrepareBuilder();
                this.result.hasFactoryId = false;
                this.result.factoryId_ = 0L;
                return this;
            }

            public CancelGameEntryRequest.Builder ClearPlayer()
            {
                this.PrepareBuilder();
                this.result.player_.Clear();
                return this;
            }

            public CancelGameEntryRequest.Builder ClearRequestId()
            {
                this.PrepareBuilder();
                this.result.hasRequestId = false;
                this.result.requestId_ = 0L;
                return this;
            }

            public override CancelGameEntryRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new CancelGameEntryRequest.Builder(this.result);
                }
                return new CancelGameEntryRequest.Builder().MergeFrom(this.result);
            }

            public Player GetPlayer(int index)
            {
                return this.result.GetPlayer(index);
            }

            public override CancelGameEntryRequest.Builder MergeFrom(CancelGameEntryRequest other)
            {
                if (other != CancelGameEntryRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasRequestId)
                    {
                        this.RequestId = other.RequestId;
                    }
                    if (other.HasFactoryId)
                    {
                        this.FactoryId = other.FactoryId;
                    }
                    if (other.player_.Count != 0)
                    {
                        this.result.player_.Add(other.player_);
                    }
                }
                return this;
            }

            public override CancelGameEntryRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override CancelGameEntryRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is CancelGameEntryRequest)
                {
                    return this.MergeFrom((CancelGameEntryRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override CancelGameEntryRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(CancelGameEntryRequest._cancelGameEntryRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = CancelGameEntryRequest._cancelGameEntryRequestFieldTags[index];
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
                        {
                            this.result.hasRequestId = input.ReadFixed64(ref this.result.requestId_);
                            continue;
                        }
                        case 0x11:
                        {
                            this.result.hasFactoryId = input.ReadFixed64(ref this.result.factoryId_);
                            continue;
                        }
                        case 0x1a:
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
                    input.ReadMessageArray<Player>(num, str, this.result.player_, Player.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private CancelGameEntryRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    CancelGameEntryRequest result = this.result;
                    this.result = new CancelGameEntryRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public CancelGameEntryRequest.Builder SetFactoryId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasFactoryId = true;
                this.result.factoryId_ = value;
                return this;
            }

            public CancelGameEntryRequest.Builder SetPlayer(int index, Player value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.player_[index] = value;
                return this;
            }

            public CancelGameEntryRequest.Builder SetPlayer(int index, Player.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.player_[index] = builderForValue.Build();
                return this;
            }

            [CLSCompliant(false)]
            public CancelGameEntryRequest.Builder SetRequestId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasRequestId = true;
                this.result.requestId_ = value;
                return this;
            }

            public override CancelGameEntryRequest DefaultInstanceForType
            {
                get
                {
                    return CancelGameEntryRequest.DefaultInstance;
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

            public bool HasRequestId
            {
                get
                {
                    return this.result.hasRequestId;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override CancelGameEntryRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int PlayerCount
            {
                get
                {
                    return this.result.PlayerCount;
                }
            }

            public IPopsicleList<Player> PlayerList
            {
                get
                {
                    return this.PrepareBuilder().player_;
                }
            }

            [CLSCompliant(false)]
            public ulong RequestId
            {
                get
                {
                    return this.result.RequestId;
                }
                set
                {
                    this.SetRequestId(value);
                }
            }

            protected override CancelGameEntryRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

