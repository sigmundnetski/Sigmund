namespace bnet.protocol.game_master
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class PlayerLeftNotification : GeneratedMessageLite<PlayerLeftNotification, Builder>
    {
        private static readonly string[] _playerLeftNotificationFieldNames = new string[] { "game_handle", "member_id", "reason" };
        private static readonly uint[] _playerLeftNotificationFieldTags = new uint[] { 10, 0x12, 0x18 };
        private static readonly PlayerLeftNotification defaultInstance = new PlayerLeftNotification().MakeReadOnly();
        private bnet.protocol.game_master.GameHandle gameHandle_;
        public const int GameHandleFieldNumber = 1;
        private bool hasGameHandle;
        private bool hasMemberId;
        private bool hasReason;
        private EntityId memberId_;
        public const int MemberIdFieldNumber = 2;
        private int memoizedSerializedSize = -1;
        private uint reason_ = 1;
        public const int ReasonFieldNumber = 3;

        static PlayerLeftNotification()
        {
            object.ReferenceEquals(GameMaster.Descriptor, null);
        }

        private PlayerLeftNotification()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(PlayerLeftNotification prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            PlayerLeftNotification notification = obj as PlayerLeftNotification;
            if (notification == null)
            {
                return false;
            }
            if ((this.hasGameHandle != notification.hasGameHandle) || (this.hasGameHandle && !this.gameHandle_.Equals(notification.gameHandle_)))
            {
                return false;
            }
            if ((this.hasMemberId != notification.hasMemberId) || (this.hasMemberId && !this.memberId_.Equals(notification.memberId_)))
            {
                return false;
            }
            return ((this.hasReason == notification.hasReason) && (!this.hasReason || this.reason_.Equals(notification.reason_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasGameHandle)
            {
                hashCode ^= this.gameHandle_.GetHashCode();
            }
            if (this.hasMemberId)
            {
                hashCode ^= this.memberId_.GetHashCode();
            }
            if (this.hasReason)
            {
                hashCode ^= this.reason_.GetHashCode();
            }
            return hashCode;
        }

        private PlayerLeftNotification MakeReadOnly()
        {
            return this;
        }

        public static PlayerLeftNotification ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static PlayerLeftNotification ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static PlayerLeftNotification ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PlayerLeftNotification ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PlayerLeftNotification ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PlayerLeftNotification ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PlayerLeftNotification ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static PlayerLeftNotification ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PlayerLeftNotification ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PlayerLeftNotification ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<PlayerLeftNotification, Builder>.PrintField("game_handle", this.hasGameHandle, this.gameHandle_, writer);
            GeneratedMessageLite<PlayerLeftNotification, Builder>.PrintField("member_id", this.hasMemberId, this.memberId_, writer);
            GeneratedMessageLite<PlayerLeftNotification, Builder>.PrintField("reason", this.hasReason, this.reason_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _playerLeftNotificationFieldNames;
            if (this.hasGameHandle)
            {
                output.WriteMessage(1, strArray[0], this.GameHandle);
            }
            if (this.hasMemberId)
            {
                output.WriteMessage(2, strArray[1], this.MemberId);
            }
            if (this.hasReason)
            {
                output.WriteUInt32(3, strArray[2], this.Reason);
            }
        }

        public static PlayerLeftNotification DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override PlayerLeftNotification DefaultInstanceForType
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

        public bool HasMemberId
        {
            get
            {
                return this.hasMemberId;
            }
        }

        public bool HasReason
        {
            get
            {
                return this.hasReason;
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
                if (!this.hasMemberId)
                {
                    return false;
                }
                if (!this.GameHandle.IsInitialized)
                {
                    return false;
                }
                if (!this.MemberId.IsInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        public EntityId MemberId
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.memberId_ != null)
                {
                    goto Label_0012;
                }
                return EntityId.DefaultInstance;
            }
        }

        [CLSCompliant(false)]
        public uint Reason
        {
            get
            {
                return this.reason_;
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
                    if (this.hasMemberId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, this.MemberId);
                    }
                    if (this.hasReason)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(3, this.Reason);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override PlayerLeftNotification ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<PlayerLeftNotification, PlayerLeftNotification.Builder>
        {
            private PlayerLeftNotification result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = PlayerLeftNotification.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(PlayerLeftNotification cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override PlayerLeftNotification BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override PlayerLeftNotification.Builder Clear()
            {
                this.result = PlayerLeftNotification.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public PlayerLeftNotification.Builder ClearGameHandle()
            {
                this.PrepareBuilder();
                this.result.hasGameHandle = false;
                this.result.gameHandle_ = null;
                return this;
            }

            public PlayerLeftNotification.Builder ClearMemberId()
            {
                this.PrepareBuilder();
                this.result.hasMemberId = false;
                this.result.memberId_ = null;
                return this;
            }

            public PlayerLeftNotification.Builder ClearReason()
            {
                this.PrepareBuilder();
                this.result.hasReason = false;
                this.result.reason_ = 1;
                return this;
            }

            public override PlayerLeftNotification.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new PlayerLeftNotification.Builder(this.result);
                }
                return new PlayerLeftNotification.Builder().MergeFrom(this.result);
            }

            public override PlayerLeftNotification.Builder MergeFrom(PlayerLeftNotification other)
            {
                if (other != PlayerLeftNotification.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasGameHandle)
                    {
                        this.MergeGameHandle(other.GameHandle);
                    }
                    if (other.HasMemberId)
                    {
                        this.MergeMemberId(other.MemberId);
                    }
                    if (other.HasReason)
                    {
                        this.Reason = other.Reason;
                    }
                }
                return this;
            }

            public override PlayerLeftNotification.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override PlayerLeftNotification.Builder MergeFrom(IMessageLite other)
            {
                if (other is PlayerLeftNotification)
                {
                    return this.MergeFrom((PlayerLeftNotification) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override PlayerLeftNotification.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(PlayerLeftNotification._playerLeftNotificationFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = PlayerLeftNotification._playerLeftNotificationFieldTags[index];
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
                        {
                            EntityId.Builder builder2 = EntityId.CreateBuilder();
                            if (this.result.hasMemberId)
                            {
                                builder2.MergeFrom(this.MemberId);
                            }
                            input.ReadMessage(builder2, extensionRegistry);
                            this.MemberId = builder2.BuildPartial();
                            continue;
                        }
                        case 0x18:
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
                    this.result.hasReason = input.ReadUInt32(ref this.result.reason_);
                }
                return this;
            }

            public PlayerLeftNotification.Builder MergeGameHandle(bnet.protocol.game_master.GameHandle value)
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

            public PlayerLeftNotification.Builder MergeMemberId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasMemberId && (this.result.memberId_ != EntityId.DefaultInstance))
                {
                    this.result.memberId_ = EntityId.CreateBuilder(this.result.memberId_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.memberId_ = value;
                }
                this.result.hasMemberId = true;
                return this;
            }

            private PlayerLeftNotification PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    PlayerLeftNotification result = this.result;
                    this.result = new PlayerLeftNotification();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public PlayerLeftNotification.Builder SetGameHandle(bnet.protocol.game_master.GameHandle value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasGameHandle = true;
                this.result.gameHandle_ = value;
                return this;
            }

            public PlayerLeftNotification.Builder SetGameHandle(bnet.protocol.game_master.GameHandle.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasGameHandle = true;
                this.result.gameHandle_ = builderForValue.Build();
                return this;
            }

            public PlayerLeftNotification.Builder SetMemberId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasMemberId = true;
                this.result.memberId_ = value;
                return this;
            }

            public PlayerLeftNotification.Builder SetMemberId(EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasMemberId = true;
                this.result.memberId_ = builderForValue.Build();
                return this;
            }

            [CLSCompliant(false)]
            public PlayerLeftNotification.Builder SetReason(uint value)
            {
                this.PrepareBuilder();
                this.result.hasReason = true;
                this.result.reason_ = value;
                return this;
            }

            public override PlayerLeftNotification DefaultInstanceForType
            {
                get
                {
                    return PlayerLeftNotification.DefaultInstance;
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

            public bool HasMemberId
            {
                get
                {
                    return this.result.hasMemberId;
                }
            }

            public bool HasReason
            {
                get
                {
                    return this.result.hasReason;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public EntityId MemberId
            {
                get
                {
                    return this.result.MemberId;
                }
                set
                {
                    this.SetMemberId(value);
                }
            }

            protected override PlayerLeftNotification MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            [CLSCompliant(false)]
            public uint Reason
            {
                get
                {
                    return this.result.Reason;
                }
                set
                {
                    this.SetReason(value);
                }
            }

            protected override PlayerLeftNotification.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

