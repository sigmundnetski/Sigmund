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

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class JoinGameRequest : GeneratedMessageLite<JoinGameRequest, Builder>
    {
        private static readonly string[] _joinGameRequestFieldNames = new string[] { "game_handle", "player" };
        private static readonly uint[] _joinGameRequestFieldTags = new uint[] { 10, 0x12 };
        private static readonly JoinGameRequest defaultInstance = new JoinGameRequest().MakeReadOnly();
        private bnet.protocol.game_master.GameHandle gameHandle_;
        public const int GameHandleFieldNumber = 1;
        private bool hasGameHandle;
        private int memoizedSerializedSize = -1;
        private PopsicleList<Player> player_ = new PopsicleList<Player>();
        public const int PlayerFieldNumber = 2;

        static JoinGameRequest()
        {
            object.ReferenceEquals(GameMaster.Descriptor, null);
        }

        private JoinGameRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(JoinGameRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            JoinGameRequest request = obj as JoinGameRequest;
            if (request == null)
            {
                return false;
            }
            if ((this.hasGameHandle != request.hasGameHandle) || (this.hasGameHandle && !this.gameHandle_.Equals(request.gameHandle_)))
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
            if (this.hasGameHandle)
            {
                hashCode ^= this.gameHandle_.GetHashCode();
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

        private JoinGameRequest MakeReadOnly()
        {
            this.player_.MakeReadOnly();
            return this;
        }

        public static JoinGameRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static JoinGameRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static JoinGameRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static JoinGameRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static JoinGameRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static JoinGameRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static JoinGameRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static JoinGameRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static JoinGameRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static JoinGameRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<JoinGameRequest, Builder>.PrintField("game_handle", this.hasGameHandle, this.gameHandle_, writer);
            GeneratedMessageLite<JoinGameRequest, Builder>.PrintField<Player>("player", this.player_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _joinGameRequestFieldNames;
            if (this.hasGameHandle)
            {
                output.WriteMessage(1, strArray[0], this.GameHandle);
            }
            if (this.player_.Count > 0)
            {
                output.WriteMessageArray<Player>(2, strArray[1], this.player_);
            }
        }

        public static JoinGameRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override JoinGameRequest DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bnet.protocol.game_master.GameHandle GameHandle
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.gameHandle_ != null)
                {
                    goto Label_0012;
                }
                return bnet.protocol.game_master.GameHandle.DefaultInstance;
            }
        }

        public bool HasGameHandle
        {
            get
            {
                return this.hasGameHandle;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasGameHandle)
                {
                    return false;
                }
                if (!this.GameHandle.IsInitialized)
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

        public override int SerializedSize
        {
            get
            {
                int memoizedSerializedSize = this.memoizedSerializedSize;
                if (memoizedSerializedSize == -1)
                {
                    memoizedSerializedSize = 0;
                    if (this.hasGameHandle)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.GameHandle);
                    }
                    IEnumerator<Player> enumerator = this.PlayerList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            Player current = enumerator.Current;
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

        protected override JoinGameRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<JoinGameRequest, JoinGameRequest.Builder>
        {
            private JoinGameRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = JoinGameRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(JoinGameRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public JoinGameRequest.Builder AddPlayer(Player value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.player_.Add(value);
                return this;
            }

            public JoinGameRequest.Builder AddPlayer(Player.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.player_.Add(builderForValue.Build());
                return this;
            }

            public JoinGameRequest.Builder AddRangePlayer(IEnumerable<Player> values)
            {
                this.PrepareBuilder();
                this.result.player_.Add(values);
                return this;
            }

            public override JoinGameRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override JoinGameRequest.Builder Clear()
            {
                this.result = JoinGameRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public JoinGameRequest.Builder ClearGameHandle()
            {
                this.PrepareBuilder();
                this.result.hasGameHandle = false;
                this.result.gameHandle_ = null;
                return this;
            }

            public JoinGameRequest.Builder ClearPlayer()
            {
                this.PrepareBuilder();
                this.result.player_.Clear();
                return this;
            }

            public override JoinGameRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new JoinGameRequest.Builder(this.result);
                }
                return new JoinGameRequest.Builder().MergeFrom(this.result);
            }

            public Player GetPlayer(int index)
            {
                return this.result.GetPlayer(index);
            }

            public override JoinGameRequest.Builder MergeFrom(JoinGameRequest other)
            {
                if (other != JoinGameRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasGameHandle)
                    {
                        this.MergeGameHandle(other.GameHandle);
                    }
                    if (other.player_.Count != 0)
                    {
                        this.result.player_.Add(other.player_);
                    }
                }
                return this;
            }

            public override JoinGameRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override JoinGameRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is JoinGameRequest)
                {
                    return this.MergeFrom((JoinGameRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override JoinGameRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(JoinGameRequest._joinGameRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = JoinGameRequest._joinGameRequestFieldTags[index];
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
                            bnet.protocol.game_master.GameHandle.Builder builder = bnet.protocol.game_master.GameHandle.CreateBuilder();
                            if (this.result.hasGameHandle)
                            {
                                builder.MergeFrom(this.GameHandle);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.GameHandle = builder.BuildPartial();
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
                    input.ReadMessageArray<Player>(num, str, this.result.player_, Player.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            public JoinGameRequest.Builder MergeGameHandle(bnet.protocol.game_master.GameHandle value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasGameHandle && (this.result.gameHandle_ != bnet.protocol.game_master.GameHandle.DefaultInstance))
                {
                    this.result.gameHandle_ = bnet.protocol.game_master.GameHandle.CreateBuilder(this.result.gameHandle_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.gameHandle_ = value;
                }
                this.result.hasGameHandle = true;
                return this;
            }

            private JoinGameRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    JoinGameRequest result = this.result;
                    this.result = new JoinGameRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public JoinGameRequest.Builder SetGameHandle(bnet.protocol.game_master.GameHandle value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasGameHandle = true;
                this.result.gameHandle_ = value;
                return this;
            }

            public JoinGameRequest.Builder SetGameHandle(bnet.protocol.game_master.GameHandle.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasGameHandle = true;
                this.result.gameHandle_ = builderForValue.Build();
                return this;
            }

            public JoinGameRequest.Builder SetPlayer(int index, Player value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.player_[index] = value;
                return this;
            }

            public JoinGameRequest.Builder SetPlayer(int index, Player.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.player_[index] = builderForValue.Build();
                return this;
            }

            public override JoinGameRequest DefaultInstanceForType
            {
                get
                {
                    return JoinGameRequest.DefaultInstance;
                }
            }

            public bnet.protocol.game_master.GameHandle GameHandle
            {
                get
                {
                    return this.result.GameHandle;
                }
                set
                {
                    this.SetGameHandle(value);
                }
            }

            public bool HasGameHandle
            {
                get
                {
                    return this.result.hasGameHandle;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override JoinGameRequest MessageBeingBuilt
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

            protected override JoinGameRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

