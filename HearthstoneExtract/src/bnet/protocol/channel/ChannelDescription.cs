namespace bnet.protocol.channel
{
    using bnet.protocol;
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class ChannelDescription : GeneratedMessageLite<ChannelDescription, Builder>
    {
        private static readonly string[] _channelDescriptionFieldNames = new string[] { "channel_id", "current_members", "state" };
        private static readonly uint[] _channelDescriptionFieldTags = new uint[] { 10, 0x10, 0x1a };
        private EntityId channelId_;
        public const int ChannelIdFieldNumber = 1;
        private uint currentMembers_;
        public const int CurrentMembersFieldNumber = 2;
        private static readonly ChannelDescription defaultInstance = new ChannelDescription().MakeReadOnly();
        private bool hasChannelId;
        private bool hasCurrentMembers;
        private bool hasState;
        private int memoizedSerializedSize = -1;
        private ChannelState state_;
        public const int StateFieldNumber = 3;

        static ChannelDescription()
        {
            object.ReferenceEquals(ChannelTypes.Descriptor, null);
        }

        private ChannelDescription()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ChannelDescription prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ChannelDescription description = obj as ChannelDescription;
            if (description == null)
            {
                return false;
            }
            if ((this.hasChannelId != description.hasChannelId) || (this.hasChannelId && !this.channelId_.Equals(description.channelId_)))
            {
                return false;
            }
            if ((this.hasCurrentMembers != description.hasCurrentMembers) || (this.hasCurrentMembers && !this.currentMembers_.Equals(description.currentMembers_)))
            {
                return false;
            }
            return ((this.hasState == description.hasState) && (!this.hasState || this.state_.Equals(description.state_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasChannelId)
            {
                hashCode ^= this.channelId_.GetHashCode();
            }
            if (this.hasCurrentMembers)
            {
                hashCode ^= this.currentMembers_.GetHashCode();
            }
            if (this.hasState)
            {
                hashCode ^= this.state_.GetHashCode();
            }
            return hashCode;
        }

        private ChannelDescription MakeReadOnly()
        {
            return this;
        }

        public static ChannelDescription ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ChannelDescription ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ChannelDescription ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ChannelDescription ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ChannelDescription ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ChannelDescription ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ChannelDescription ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ChannelDescription ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ChannelDescription ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ChannelDescription ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ChannelDescription, Builder>.PrintField("channel_id", this.hasChannelId, this.channelId_, writer);
            GeneratedMessageLite<ChannelDescription, Builder>.PrintField("current_members", this.hasCurrentMembers, this.currentMembers_, writer);
            GeneratedMessageLite<ChannelDescription, Builder>.PrintField("state", this.hasState, this.state_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _channelDescriptionFieldNames;
            if (this.hasChannelId)
            {
                output.WriteMessage(1, strArray[0], this.ChannelId);
            }
            if (this.hasCurrentMembers)
            {
                output.WriteUInt32(2, strArray[1], this.CurrentMembers);
            }
            if (this.hasState)
            {
                output.WriteMessage(3, strArray[2], this.State);
            }
        }

        public EntityId ChannelId
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.channelId_ != null)
                {
                    goto Label_0012;
                }
                return EntityId.DefaultInstance;
            }
        }

        [CLSCompliant(false)]
        public uint CurrentMembers
        {
            get
            {
                return this.currentMembers_;
            }
        }

        public static ChannelDescription DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ChannelDescription DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasChannelId
        {
            get
            {
                return this.hasChannelId;
            }
        }

        public bool HasCurrentMembers
        {
            get
            {
                return this.hasCurrentMembers;
            }
        }

        public bool HasState
        {
            get
            {
                return this.hasState;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasChannelId)
                {
                    return false;
                }
                if (!this.ChannelId.IsInitialized)
                {
                    return false;
                }
                if (this.HasState && !this.State.IsInitialized)
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
                    if (this.hasChannelId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.ChannelId);
                    }
                    if (this.hasCurrentMembers)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(2, this.CurrentMembers);
                    }
                    if (this.hasState)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(3, this.State);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        public ChannelState State
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.state_ != null)
                {
                    goto Label_0012;
                }
                return ChannelState.DefaultInstance;
            }
        }

        protected override ChannelDescription ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<ChannelDescription, ChannelDescription.Builder>
        {
            private ChannelDescription result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ChannelDescription.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ChannelDescription cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override ChannelDescription BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ChannelDescription.Builder Clear()
            {
                this.result = ChannelDescription.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ChannelDescription.Builder ClearChannelId()
            {
                this.PrepareBuilder();
                this.result.hasChannelId = false;
                this.result.channelId_ = null;
                return this;
            }

            public ChannelDescription.Builder ClearCurrentMembers()
            {
                this.PrepareBuilder();
                this.result.hasCurrentMembers = false;
                this.result.currentMembers_ = 0;
                return this;
            }

            public ChannelDescription.Builder ClearState()
            {
                this.PrepareBuilder();
                this.result.hasState = false;
                this.result.state_ = null;
                return this;
            }

            public override ChannelDescription.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ChannelDescription.Builder(this.result);
                }
                return new ChannelDescription.Builder().MergeFrom(this.result);
            }

            public ChannelDescription.Builder MergeChannelId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasChannelId && (this.result.channelId_ != EntityId.DefaultInstance))
                {
                    this.result.channelId_ = EntityId.CreateBuilder(this.result.channelId_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.channelId_ = value;
                }
                this.result.hasChannelId = true;
                return this;
            }

            public override ChannelDescription.Builder MergeFrom(ChannelDescription other)
            {
                if (other != ChannelDescription.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasChannelId)
                    {
                        this.MergeChannelId(other.ChannelId);
                    }
                    if (other.HasCurrentMembers)
                    {
                        this.CurrentMembers = other.CurrentMembers;
                    }
                    if (other.HasState)
                    {
                        this.MergeState(other.State);
                    }
                }
                return this;
            }

            public override ChannelDescription.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ChannelDescription.Builder MergeFrom(IMessageLite other)
            {
                if (other is ChannelDescription)
                {
                    return this.MergeFrom((ChannelDescription) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ChannelDescription.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ChannelDescription._channelDescriptionFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ChannelDescription._channelDescriptionFieldTags[index];
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
                            EntityId.Builder builder = EntityId.CreateBuilder();
                            if (this.result.hasChannelId)
                            {
                                builder.MergeFrom(this.ChannelId);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.ChannelId = builder.BuildPartial();
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasCurrentMembers = input.ReadUInt32(ref this.result.currentMembers_);
                            continue;
                        }
                        case 0x1a:
                        {
                            ChannelState.Builder builder2 = ChannelState.CreateBuilder();
                            if (this.result.hasState)
                            {
                                builder2.MergeFrom(this.State);
                            }
                            input.ReadMessage(builder2, extensionRegistry);
                            this.State = builder2.BuildPartial();
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

            public ChannelDescription.Builder MergeState(ChannelState value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasState && (this.result.state_ != ChannelState.DefaultInstance))
                {
                    this.result.state_ = ChannelState.CreateBuilder(this.result.state_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.state_ = value;
                }
                this.result.hasState = true;
                return this;
            }

            private ChannelDescription PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ChannelDescription result = this.result;
                    this.result = new ChannelDescription();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ChannelDescription.Builder SetChannelId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasChannelId = true;
                this.result.channelId_ = value;
                return this;
            }

            public ChannelDescription.Builder SetChannelId(EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasChannelId = true;
                this.result.channelId_ = builderForValue.Build();
                return this;
            }

            [CLSCompliant(false)]
            public ChannelDescription.Builder SetCurrentMembers(uint value)
            {
                this.PrepareBuilder();
                this.result.hasCurrentMembers = true;
                this.result.currentMembers_ = value;
                return this;
            }

            public ChannelDescription.Builder SetState(ChannelState value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasState = true;
                this.result.state_ = value;
                return this;
            }

            public ChannelDescription.Builder SetState(ChannelState.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasState = true;
                this.result.state_ = builderForValue.Build();
                return this;
            }

            public EntityId ChannelId
            {
                get
                {
                    return this.result.ChannelId;
                }
                set
                {
                    this.SetChannelId(value);
                }
            }

            [CLSCompliant(false)]
            public uint CurrentMembers
            {
                get
                {
                    return this.result.CurrentMembers;
                }
                set
                {
                    this.SetCurrentMembers(value);
                }
            }

            public override ChannelDescription DefaultInstanceForType
            {
                get
                {
                    return ChannelDescription.DefaultInstance;
                }
            }

            public bool HasChannelId
            {
                get
                {
                    return this.result.hasChannelId;
                }
            }

            public bool HasCurrentMembers
            {
                get
                {
                    return this.result.hasCurrentMembers;
                }
            }

            public bool HasState
            {
                get
                {
                    return this.result.hasState;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override ChannelDescription MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public ChannelState State
            {
                get
                {
                    return this.result.State;
                }
                set
                {
                    this.SetState(value);
                }
            }

            protected override ChannelDescription.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

