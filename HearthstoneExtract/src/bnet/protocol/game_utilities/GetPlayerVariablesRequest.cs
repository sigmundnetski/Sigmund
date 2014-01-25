namespace bnet.protocol.game_utilities
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
    public sealed class GetPlayerVariablesRequest : GeneratedMessageLite<GetPlayerVariablesRequest, Builder>
    {
        private static readonly string[] _getPlayerVariablesRequestFieldNames = new string[] { "host", "player_variables" };
        private static readonly uint[] _getPlayerVariablesRequestFieldTags = new uint[] { 0x12, 10 };
        private static readonly GetPlayerVariablesRequest defaultInstance = new GetPlayerVariablesRequest().MakeReadOnly();
        private bool hasHost;
        private ProcessId host_;
        public const int HostFieldNumber = 2;
        private int memoizedSerializedSize = -1;
        private PopsicleList<PlayerVariables> playerVariables_ = new PopsicleList<PlayerVariables>();
        public const int PlayerVariablesFieldNumber = 1;

        static GetPlayerVariablesRequest()
        {
            object.ReferenceEquals(GameUtils.Descriptor, null);
        }

        private GetPlayerVariablesRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GetPlayerVariablesRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GetPlayerVariablesRequest request = obj as GetPlayerVariablesRequest;
            if (request == null)
            {
                return false;
            }
            if (this.playerVariables_.Count != request.playerVariables_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.playerVariables_.Count; i++)
            {
                if (!this.playerVariables_[i].Equals(request.playerVariables_[i]))
                {
                    return false;
                }
            }
            return ((this.hasHost == request.hasHost) && (!this.hasHost || this.host_.Equals(request.host_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<PlayerVariables> enumerator = this.playerVariables_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    PlayerVariables current = enumerator.Current;
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
            if (this.hasHost)
            {
                hashCode ^= this.host_.GetHashCode();
            }
            return hashCode;
        }

        public PlayerVariables GetPlayerVariables(int index)
        {
            return this.playerVariables_[index];
        }

        private GetPlayerVariablesRequest MakeReadOnly()
        {
            this.playerVariables_.MakeReadOnly();
            return this;
        }

        public static GetPlayerVariablesRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GetPlayerVariablesRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetPlayerVariablesRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GetPlayerVariablesRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GetPlayerVariablesRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GetPlayerVariablesRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GetPlayerVariablesRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GetPlayerVariablesRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetPlayerVariablesRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetPlayerVariablesRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GetPlayerVariablesRequest, Builder>.PrintField<PlayerVariables>("player_variables", this.playerVariables_, writer);
            GeneratedMessageLite<GetPlayerVariablesRequest, Builder>.PrintField("host", this.hasHost, this.host_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _getPlayerVariablesRequestFieldNames;
            if (this.playerVariables_.Count > 0)
            {
                output.WriteMessageArray<PlayerVariables>(1, strArray[1], this.playerVariables_);
            }
            if (this.hasHost)
            {
                output.WriteMessage(2, strArray[0], this.Host);
            }
        }

        public static GetPlayerVariablesRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GetPlayerVariablesRequest DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasHost
        {
            get
            {
                return this.hasHost;
            }
        }

        public ProcessId Host
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.host_ != null)
                {
                    goto Label_0012;
                }
                return ProcessId.DefaultInstance;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                IEnumerator<PlayerVariables> enumerator = this.PlayerVariablesList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        PlayerVariables current = enumerator.Current;
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
                if (this.HasHost && !this.Host.IsInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        public int PlayerVariablesCount
        {
            get
            {
                return this.playerVariables_.Count;
            }
        }

        public IList<PlayerVariables> PlayerVariablesList
        {
            get
            {
                return this.playerVariables_;
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
                    IEnumerator<PlayerVariables> enumerator = this.PlayerVariablesList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            PlayerVariables current = enumerator.Current;
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
                    if (this.hasHost)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, this.Host);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override GetPlayerVariablesRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<GetPlayerVariablesRequest, GetPlayerVariablesRequest.Builder>
        {
            private GetPlayerVariablesRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GetPlayerVariablesRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GetPlayerVariablesRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public GetPlayerVariablesRequest.Builder AddPlayerVariables(PlayerVariables value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.playerVariables_.Add(value);
                return this;
            }

            public GetPlayerVariablesRequest.Builder AddPlayerVariables(PlayerVariables.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.playerVariables_.Add(builderForValue.Build());
                return this;
            }

            public GetPlayerVariablesRequest.Builder AddRangePlayerVariables(IEnumerable<PlayerVariables> values)
            {
                this.PrepareBuilder();
                this.result.playerVariables_.Add(values);
                return this;
            }

            public override GetPlayerVariablesRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GetPlayerVariablesRequest.Builder Clear()
            {
                this.result = GetPlayerVariablesRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GetPlayerVariablesRequest.Builder ClearHost()
            {
                this.PrepareBuilder();
                this.result.hasHost = false;
                this.result.host_ = null;
                return this;
            }

            public GetPlayerVariablesRequest.Builder ClearPlayerVariables()
            {
                this.PrepareBuilder();
                this.result.playerVariables_.Clear();
                return this;
            }

            public override GetPlayerVariablesRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GetPlayerVariablesRequest.Builder(this.result);
                }
                return new GetPlayerVariablesRequest.Builder().MergeFrom(this.result);
            }

            public PlayerVariables GetPlayerVariables(int index)
            {
                return this.result.GetPlayerVariables(index);
            }

            public override GetPlayerVariablesRequest.Builder MergeFrom(GetPlayerVariablesRequest other)
            {
                if (other != GetPlayerVariablesRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.playerVariables_.Count != 0)
                    {
                        this.result.playerVariables_.Add(other.playerVariables_);
                    }
                    if (other.HasHost)
                    {
                        this.MergeHost(other.Host);
                    }
                }
                return this;
            }

            public override GetPlayerVariablesRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GetPlayerVariablesRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is GetPlayerVariablesRequest)
                {
                    return this.MergeFrom((GetPlayerVariablesRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GetPlayerVariablesRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GetPlayerVariablesRequest._getPlayerVariablesRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GetPlayerVariablesRequest._getPlayerVariablesRequestFieldTags[index];
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
                            input.ReadMessageArray<PlayerVariables>(num, str, this.result.playerVariables_, PlayerVariables.DefaultInstance, extensionRegistry);
                            continue;
                        }
                        case 0x12:
                        {
                            ProcessId.Builder builder = ProcessId.CreateBuilder();
                            if (this.result.hasHost)
                            {
                                builder.MergeFrom(this.Host);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.Host = builder.BuildPartial();
                            continue;
                        }
                    }
                    if (WireFormat.IsEndGroupTag(num))
                    {
                        return this;
                    }
                    this.ParseUnknownField(input, extensionRegistry, num, str);
                }
                return this;
            }

            public GetPlayerVariablesRequest.Builder MergeHost(ProcessId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasHost && (this.result.host_ != ProcessId.DefaultInstance))
                {
                    this.result.host_ = ProcessId.CreateBuilder(this.result.host_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.host_ = value;
                }
                this.result.hasHost = true;
                return this;
            }

            private GetPlayerVariablesRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GetPlayerVariablesRequest result = this.result;
                    this.result = new GetPlayerVariablesRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public GetPlayerVariablesRequest.Builder SetHost(ProcessId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasHost = true;
                this.result.host_ = value;
                return this;
            }

            public GetPlayerVariablesRequest.Builder SetHost(ProcessId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasHost = true;
                this.result.host_ = builderForValue.Build();
                return this;
            }

            public GetPlayerVariablesRequest.Builder SetPlayerVariables(int index, PlayerVariables value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.playerVariables_[index] = value;
                return this;
            }

            public GetPlayerVariablesRequest.Builder SetPlayerVariables(int index, PlayerVariables.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.playerVariables_[index] = builderForValue.Build();
                return this;
            }

            public override GetPlayerVariablesRequest DefaultInstanceForType
            {
                get
                {
                    return GetPlayerVariablesRequest.DefaultInstance;
                }
            }

            public bool HasHost
            {
                get
                {
                    return this.result.hasHost;
                }
            }

            public ProcessId Host
            {
                get
                {
                    return this.result.Host;
                }
                set
                {
                    this.SetHost(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override GetPlayerVariablesRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int PlayerVariablesCount
            {
                get
                {
                    return this.result.PlayerVariablesCount;
                }
            }

            public IPopsicleList<PlayerVariables> PlayerVariablesList
            {
                get
                {
                    return this.PrepareBuilder().playerVariables_;
                }
            }

            protected override GetPlayerVariablesRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

