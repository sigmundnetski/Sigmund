namespace bnet.protocol.channel
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
    public sealed class AddNotification : GeneratedMessageLite<AddNotification, Builder>
    {
        private static readonly string[] _addNotificationFieldNames = new string[] { "channel_state", "member", "self" };
        private static readonly uint[] _addNotificationFieldTags = new uint[] { 0x1a, 0x12, 10 };
        private bnet.protocol.channel.ChannelState channelState_;
        public const int ChannelStateFieldNumber = 3;
        private static readonly AddNotification defaultInstance = new AddNotification().MakeReadOnly();
        private bool hasChannelState;
        private bool hasSelf;
        private PopsicleList<Member> member_ = new PopsicleList<Member>();
        public const int MemberFieldNumber = 2;
        private int memoizedSerializedSize = -1;
        private Member self_;
        public const int SelfFieldNumber = 1;

        static AddNotification()
        {
            object.ReferenceEquals(ChannelService.Descriptor, null);
        }

        private AddNotification()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AddNotification prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AddNotification notification = obj as AddNotification;
            if (notification == null)
            {
                return false;
            }
            if ((this.hasSelf != notification.hasSelf) || (this.hasSelf && !this.self_.Equals(notification.self_)))
            {
                return false;
            }
            if (this.member_.Count != notification.member_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.member_.Count; i++)
            {
                if (!this.member_[i].Equals(notification.member_[i]))
                {
                    return false;
                }
            }
            return ((this.hasChannelState == notification.hasChannelState) && (!this.hasChannelState || this.channelState_.Equals(notification.channelState_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasSelf)
            {
                hashCode ^= this.self_.GetHashCode();
            }
            IEnumerator<Member> enumerator = this.member_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    Member current = enumerator.Current;
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
            if (this.hasChannelState)
            {
                hashCode ^= this.channelState_.GetHashCode();
            }
            return hashCode;
        }

        public Member GetMember(int index)
        {
            return this.member_[index];
        }

        private AddNotification MakeReadOnly()
        {
            this.member_.MakeReadOnly();
            return this;
        }

        public static AddNotification ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AddNotification ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AddNotification ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AddNotification ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AddNotification ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AddNotification ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AddNotification ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AddNotification ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AddNotification ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AddNotification ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AddNotification, Builder>.PrintField("self", this.hasSelf, this.self_, writer);
            GeneratedMessageLite<AddNotification, Builder>.PrintField<Member>("member", this.member_, writer);
            GeneratedMessageLite<AddNotification, Builder>.PrintField("channel_state", this.hasChannelState, this.channelState_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _addNotificationFieldNames;
            if (this.hasSelf)
            {
                output.WriteMessage(1, strArray[2], this.Self);
            }
            if (this.member_.Count > 0)
            {
                output.WriteMessageArray<Member>(2, strArray[1], this.member_);
            }
            if (this.hasChannelState)
            {
                output.WriteMessage(3, strArray[0], this.ChannelState);
            }
        }

        public bnet.protocol.channel.ChannelState ChannelState
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.channelState_ != null)
                {
                    goto Label_0012;
                }
                return bnet.protocol.channel.ChannelState.DefaultInstance;
            }
        }

        public static AddNotification DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AddNotification DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasChannelState
        {
            get
            {
                return this.hasChannelState;
            }
        }

        public bool HasSelf
        {
            get
            {
                return this.hasSelf;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasChannelState)
                {
                    return false;
                }
                if (this.HasSelf && !this.Self.IsInitialized)
                {
                    return false;
                }
                IEnumerator<Member> enumerator = this.MemberList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        Member current = enumerator.Current;
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
                if (!this.ChannelState.IsInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        public int MemberCount
        {
            get
            {
                return this.member_.Count;
            }
        }

        public IList<Member> MemberList
        {
            get
            {
                return this.member_;
            }
        }

        public Member Self
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.self_ != null)
                {
                    goto Label_0012;
                }
                return Member.DefaultInstance;
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
                    if (this.hasSelf)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.Self);
                    }
                    IEnumerator<Member> enumerator = this.MemberList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            Member current = enumerator.Current;
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
                    if (this.hasChannelState)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(3, this.ChannelState);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override AddNotification ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<AddNotification, AddNotification.Builder>
        {
            private AddNotification result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AddNotification.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AddNotification cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public AddNotification.Builder AddMember(Member value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.member_.Add(value);
                return this;
            }

            public AddNotification.Builder AddMember(Member.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.member_.Add(builderForValue.Build());
                return this;
            }

            public AddNotification.Builder AddRangeMember(IEnumerable<Member> values)
            {
                this.PrepareBuilder();
                this.result.member_.Add(values);
                return this;
            }

            public override AddNotification BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AddNotification.Builder Clear()
            {
                this.result = AddNotification.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AddNotification.Builder ClearChannelState()
            {
                this.PrepareBuilder();
                this.result.hasChannelState = false;
                this.result.channelState_ = null;
                return this;
            }

            public AddNotification.Builder ClearMember()
            {
                this.PrepareBuilder();
                this.result.member_.Clear();
                return this;
            }

            public AddNotification.Builder ClearSelf()
            {
                this.PrepareBuilder();
                this.result.hasSelf = false;
                this.result.self_ = null;
                return this;
            }

            public override AddNotification.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AddNotification.Builder(this.result);
                }
                return new AddNotification.Builder().MergeFrom(this.result);
            }

            public Member GetMember(int index)
            {
                return this.result.GetMember(index);
            }

            public AddNotification.Builder MergeChannelState(bnet.protocol.channel.ChannelState value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasChannelState && (this.result.channelState_ != bnet.protocol.channel.ChannelState.DefaultInstance))
                {
                    this.result.channelState_ = bnet.protocol.channel.ChannelState.CreateBuilder(this.result.channelState_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.channelState_ = value;
                }
                this.result.hasChannelState = true;
                return this;
            }

            public override AddNotification.Builder MergeFrom(AddNotification other)
            {
                if (other != AddNotification.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasSelf)
                    {
                        this.MergeSelf(other.Self);
                    }
                    if (other.member_.Count != 0)
                    {
                        this.result.member_.Add(other.member_);
                    }
                    if (other.HasChannelState)
                    {
                        this.MergeChannelState(other.ChannelState);
                    }
                }
                return this;
            }

            public override AddNotification.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AddNotification.Builder MergeFrom(IMessageLite other)
            {
                if (other is AddNotification)
                {
                    return this.MergeFrom((AddNotification) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AddNotification.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AddNotification._addNotificationFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AddNotification._addNotificationFieldTags[index];
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
                            Member.Builder builder = Member.CreateBuilder();
                            if (this.result.hasSelf)
                            {
                                builder.MergeFrom(this.Self);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.Self = builder.BuildPartial();
                            continue;
                        }
                        case 0x12:
                        {
                            input.ReadMessageArray<Member>(num, str, this.result.member_, Member.DefaultInstance, extensionRegistry);
                            continue;
                        }
                        case 0x1a:
                        {
                            bnet.protocol.channel.ChannelState.Builder builder2 = bnet.protocol.channel.ChannelState.CreateBuilder();
                            if (this.result.hasChannelState)
                            {
                                builder2.MergeFrom(this.ChannelState);
                            }
                            input.ReadMessage(builder2, extensionRegistry);
                            this.ChannelState = builder2.BuildPartial();
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

            public AddNotification.Builder MergeSelf(Member value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasSelf && (this.result.self_ != Member.DefaultInstance))
                {
                    this.result.self_ = Member.CreateBuilder(this.result.self_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.self_ = value;
                }
                this.result.hasSelf = true;
                return this;
            }

            private AddNotification PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AddNotification result = this.result;
                    this.result = new AddNotification();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public AddNotification.Builder SetChannelState(bnet.protocol.channel.ChannelState value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasChannelState = true;
                this.result.channelState_ = value;
                return this;
            }

            public AddNotification.Builder SetChannelState(bnet.protocol.channel.ChannelState.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasChannelState = true;
                this.result.channelState_ = builderForValue.Build();
                return this;
            }

            public AddNotification.Builder SetMember(int index, Member value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.member_[index] = value;
                return this;
            }

            public AddNotification.Builder SetMember(int index, Member.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.member_[index] = builderForValue.Build();
                return this;
            }

            public AddNotification.Builder SetSelf(Member value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasSelf = true;
                this.result.self_ = value;
                return this;
            }

            public AddNotification.Builder SetSelf(Member.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasSelf = true;
                this.result.self_ = builderForValue.Build();
                return this;
            }

            public bnet.protocol.channel.ChannelState ChannelState
            {
                get
                {
                    return this.result.ChannelState;
                }
                set
                {
                    this.SetChannelState(value);
                }
            }

            public override AddNotification DefaultInstanceForType
            {
                get
                {
                    return AddNotification.DefaultInstance;
                }
            }

            public bool HasChannelState
            {
                get
                {
                    return this.result.hasChannelState;
                }
            }

            public bool HasSelf
            {
                get
                {
                    return this.result.hasSelf;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public int MemberCount
            {
                get
                {
                    return this.result.MemberCount;
                }
            }

            public IPopsicleList<Member> MemberList
            {
                get
                {
                    return this.PrepareBuilder().member_;
                }
            }

            protected override AddNotification MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public Member Self
            {
                get
                {
                    return this.result.Self;
                }
                set
                {
                    this.SetSelf(value);
                }
            }

            protected override AddNotification.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

