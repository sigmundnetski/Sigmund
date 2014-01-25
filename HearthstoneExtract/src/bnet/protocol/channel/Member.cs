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
    public sealed class Member : GeneratedMessageLite<Member, Builder>
    {
        private static readonly string[] _memberFieldNames = new string[] { "identity", "state" };
        private static readonly uint[] _memberFieldTags = new uint[] { 10, 0x12 };
        private static readonly Member defaultInstance = new Member().MakeReadOnly();
        private bool hasIdentity;
        private bool hasState;
        private bnet.protocol.Identity identity_;
        public const int IdentityFieldNumber = 1;
        private int memoizedSerializedSize = -1;
        private MemberState state_;
        public const int StateFieldNumber = 2;

        static Member()
        {
            object.ReferenceEquals(ChannelTypes.Descriptor, null);
        }

        private Member()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(Member prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            Member member = obj as Member;
            if (member == null)
            {
                return false;
            }
            if ((this.hasIdentity != member.hasIdentity) || (this.hasIdentity && !this.identity_.Equals(member.identity_)))
            {
                return false;
            }
            return ((this.hasState == member.hasState) && (!this.hasState || this.state_.Equals(member.state_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasIdentity)
            {
                hashCode ^= this.identity_.GetHashCode();
            }
            if (this.hasState)
            {
                hashCode ^= this.state_.GetHashCode();
            }
            return hashCode;
        }

        private Member MakeReadOnly()
        {
            return this;
        }

        public static Member ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static Member ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static Member ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Member ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Member ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Member ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Member ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static Member ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Member ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Member ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<Member, Builder>.PrintField("identity", this.hasIdentity, this.identity_, writer);
            GeneratedMessageLite<Member, Builder>.PrintField("state", this.hasState, this.state_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _memberFieldNames;
            if (this.hasIdentity)
            {
                output.WriteMessage(1, strArray[0], this.Identity);
            }
            if (this.hasState)
            {
                output.WriteMessage(2, strArray[1], this.State);
            }
        }

        public static Member DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override Member DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasIdentity
        {
            get
            {
                return this.hasIdentity;
            }
        }

        public bool HasState
        {
            get
            {
                return this.hasState;
            }
        }

        public bnet.protocol.Identity Identity
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.identity_ != null)
                {
                    goto Label_0012;
                }
                return bnet.protocol.Identity.DefaultInstance;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasIdentity)
                {
                    return false;
                }
                if (!this.hasState)
                {
                    return false;
                }
                if (!this.Identity.IsInitialized)
                {
                    return false;
                }
                if (!this.State.IsInitialized)
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
                    if (this.hasIdentity)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.Identity);
                    }
                    if (this.hasState)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, this.State);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        public MemberState State
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.state_ != null)
                {
                    goto Label_0012;
                }
                return MemberState.DefaultInstance;
            }
        }

        protected override Member ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<Member, Member.Builder>
        {
            private Member result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = Member.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(Member cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override Member BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override Member.Builder Clear()
            {
                this.result = Member.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public Member.Builder ClearIdentity()
            {
                this.PrepareBuilder();
                this.result.hasIdentity = false;
                this.result.identity_ = null;
                return this;
            }

            public Member.Builder ClearState()
            {
                this.PrepareBuilder();
                this.result.hasState = false;
                this.result.state_ = null;
                return this;
            }

            public override Member.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new Member.Builder(this.result);
                }
                return new Member.Builder().MergeFrom(this.result);
            }

            public override Member.Builder MergeFrom(Member other)
            {
                if (other != Member.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasIdentity)
                    {
                        this.MergeIdentity(other.Identity);
                    }
                    if (other.HasState)
                    {
                        this.MergeState(other.State);
                    }
                }
                return this;
            }

            public override Member.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override Member.Builder MergeFrom(IMessageLite other)
            {
                if (other is Member)
                {
                    return this.MergeFrom((Member) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override Member.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(Member._memberFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = Member._memberFieldTags[index];
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
                            bnet.protocol.Identity.Builder builder = bnet.protocol.Identity.CreateBuilder();
                            if (this.result.hasIdentity)
                            {
                                builder.MergeFrom(this.Identity);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.Identity = builder.BuildPartial();
                            continue;
                        }
                        case 0x12:
                        {
                            MemberState.Builder builder2 = MemberState.CreateBuilder();
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

            public Member.Builder MergeIdentity(bnet.protocol.Identity value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasIdentity && (this.result.identity_ != bnet.protocol.Identity.DefaultInstance))
                {
                    this.result.identity_ = bnet.protocol.Identity.CreateBuilder(this.result.identity_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.identity_ = value;
                }
                this.result.hasIdentity = true;
                return this;
            }

            public Member.Builder MergeState(MemberState value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasState && (this.result.state_ != MemberState.DefaultInstance))
                {
                    this.result.state_ = MemberState.CreateBuilder(this.result.state_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.state_ = value;
                }
                this.result.hasState = true;
                return this;
            }

            private Member PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    Member result = this.result;
                    this.result = new Member();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public Member.Builder SetIdentity(bnet.protocol.Identity value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasIdentity = true;
                this.result.identity_ = value;
                return this;
            }

            public Member.Builder SetIdentity(bnet.protocol.Identity.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasIdentity = true;
                this.result.identity_ = builderForValue.Build();
                return this;
            }

            public Member.Builder SetState(MemberState value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasState = true;
                this.result.state_ = value;
                return this;
            }

            public Member.Builder SetState(MemberState.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasState = true;
                this.result.state_ = builderForValue.Build();
                return this;
            }

            public override Member DefaultInstanceForType
            {
                get
                {
                    return Member.DefaultInstance;
                }
            }

            public bool HasIdentity
            {
                get
                {
                    return this.result.hasIdentity;
                }
            }

            public bool HasState
            {
                get
                {
                    return this.result.hasState;
                }
            }

            public bnet.protocol.Identity Identity
            {
                get
                {
                    return this.result.Identity;
                }
                set
                {
                    this.SetIdentity(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override Member MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public MemberState State
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

            protected override Member.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

