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
    public sealed class GetPlayerVariablesResponse : GeneratedMessageLite<GetPlayerVariablesResponse, Builder>
    {
        private static readonly string[] _getPlayerVariablesResponseFieldNames = new string[] { "player_variables" };
        private static readonly uint[] _getPlayerVariablesResponseFieldTags = new uint[] { 10 };
        private static readonly GetPlayerVariablesResponse defaultInstance = new GetPlayerVariablesResponse().MakeReadOnly();
        private int memoizedSerializedSize = -1;
        private PopsicleList<PlayerVariables> playerVariables_ = new PopsicleList<PlayerVariables>();
        public const int PlayerVariablesFieldNumber = 1;

        static GetPlayerVariablesResponse()
        {
            object.ReferenceEquals(GameUtils.Descriptor, null);
        }

        private GetPlayerVariablesResponse()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GetPlayerVariablesResponse prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GetPlayerVariablesResponse response = obj as GetPlayerVariablesResponse;
            if (response == null)
            {
                return false;
            }
            if (this.playerVariables_.Count != response.playerVariables_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.playerVariables_.Count; i++)
            {
                if (!this.playerVariables_[i].Equals(response.playerVariables_[i]))
                {
                    return false;
                }
            }
            return true;
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
            return hashCode;
        }

        public PlayerVariables GetPlayerVariables(int index)
        {
            return this.playerVariables_[index];
        }

        private GetPlayerVariablesResponse MakeReadOnly()
        {
            this.playerVariables_.MakeReadOnly();
            return this;
        }

        public static GetPlayerVariablesResponse ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GetPlayerVariablesResponse ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetPlayerVariablesResponse ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GetPlayerVariablesResponse ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GetPlayerVariablesResponse ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GetPlayerVariablesResponse ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GetPlayerVariablesResponse ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GetPlayerVariablesResponse ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetPlayerVariablesResponse ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetPlayerVariablesResponse ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GetPlayerVariablesResponse, Builder>.PrintField<PlayerVariables>("player_variables", this.playerVariables_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _getPlayerVariablesResponseFieldNames;
            if (this.playerVariables_.Count > 0)
            {
                output.WriteMessageArray<PlayerVariables>(1, strArray[0], this.playerVariables_);
            }
        }

        public static GetPlayerVariablesResponse DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GetPlayerVariablesResponse DefaultInstanceForType
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
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override GetPlayerVariablesResponse ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<GetPlayerVariablesResponse, GetPlayerVariablesResponse.Builder>
        {
            private GetPlayerVariablesResponse result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GetPlayerVariablesResponse.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GetPlayerVariablesResponse cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public GetPlayerVariablesResponse.Builder AddPlayerVariables(PlayerVariables value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.playerVariables_.Add(value);
                return this;
            }

            public GetPlayerVariablesResponse.Builder AddPlayerVariables(PlayerVariables.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.playerVariables_.Add(builderForValue.Build());
                return this;
            }

            public GetPlayerVariablesResponse.Builder AddRangePlayerVariables(IEnumerable<PlayerVariables> values)
            {
                this.PrepareBuilder();
                this.result.playerVariables_.Add(values);
                return this;
            }

            public override GetPlayerVariablesResponse BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GetPlayerVariablesResponse.Builder Clear()
            {
                this.result = GetPlayerVariablesResponse.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GetPlayerVariablesResponse.Builder ClearPlayerVariables()
            {
                this.PrepareBuilder();
                this.result.playerVariables_.Clear();
                return this;
            }

            public override GetPlayerVariablesResponse.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GetPlayerVariablesResponse.Builder(this.result);
                }
                return new GetPlayerVariablesResponse.Builder().MergeFrom(this.result);
            }

            public PlayerVariables GetPlayerVariables(int index)
            {
                return this.result.GetPlayerVariables(index);
            }

            public override GetPlayerVariablesResponse.Builder MergeFrom(GetPlayerVariablesResponse other)
            {
                if (other != GetPlayerVariablesResponse.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.playerVariables_.Count != 0)
                    {
                        this.result.playerVariables_.Add(other.playerVariables_);
                    }
                }
                return this;
            }

            public override GetPlayerVariablesResponse.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GetPlayerVariablesResponse.Builder MergeFrom(IMessageLite other)
            {
                if (other is GetPlayerVariablesResponse)
                {
                    return this.MergeFrom((GetPlayerVariablesResponse) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GetPlayerVariablesResponse.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GetPlayerVariablesResponse._getPlayerVariablesResponseFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GetPlayerVariablesResponse._getPlayerVariablesResponseFieldTags[index];
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
                    input.ReadMessageArray<PlayerVariables>(num, str, this.result.playerVariables_, PlayerVariables.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private GetPlayerVariablesResponse PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GetPlayerVariablesResponse result = this.result;
                    this.result = new GetPlayerVariablesResponse();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public GetPlayerVariablesResponse.Builder SetPlayerVariables(int index, PlayerVariables value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.playerVariables_[index] = value;
                return this;
            }

            public GetPlayerVariablesResponse.Builder SetPlayerVariables(int index, PlayerVariables.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.playerVariables_[index] = builderForValue.Build();
                return this;
            }

            public override GetPlayerVariablesResponse DefaultInstanceForType
            {
                get
                {
                    return GetPlayerVariablesResponse.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override GetPlayerVariablesResponse MessageBeingBuilt
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

            protected override GetPlayerVariablesResponse.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

