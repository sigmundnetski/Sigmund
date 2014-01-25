namespace bnet.protocol.channel
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class JoinNotification : GeneratedMessageLite<JoinNotification, Builder>
    {
        private static readonly string[] _joinNotificationFieldNames = new string[] { "member" };
        private static readonly uint[] _joinNotificationFieldTags = new uint[] { 10 };
        private static readonly JoinNotification defaultInstance = new JoinNotification().MakeReadOnly();
        private bool hasMember;
        private bnet.protocol.channel.Member member_;
        public const int MemberFieldNumber = 1;
        private int memoizedSerializedSize = -1;

        static JoinNotification()
        {
            object.ReferenceEquals(ChannelService.Descriptor, null);
        }

        private JoinNotification()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(JoinNotification prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            JoinNotification notification = obj as JoinNotification;
            if (notification == null)
            {
                return false;
            }
            return ((this.hasMember == notification.hasMember) && (!this.hasMember || this.member_.Equals(notification.member_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasMember)
            {
                hashCode ^= this.member_.GetHashCode();
            }
            return hashCode;
        }

        private JoinNotification MakeReadOnly()
        {
            return this;
        }

        public static JoinNotification ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static JoinNotification ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static JoinNotification ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static JoinNotification ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static JoinNotification ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static JoinNotification ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static JoinNotification ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static JoinNotification ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static JoinNotification ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static JoinNotification ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<JoinNotification, Builder>.PrintField("member", this.hasMember, this.member_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _joinNotificationFieldNames;
            if (this.hasMember)
            {
                output.WriteMessage(1, strArray[0], this.Member);
            }
        }

        public static JoinNotification DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override JoinNotification DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasMember
        {
            get
            {
                return this.hasMember;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasMember)
                {
                    return false;
                }
                if (!this.Member.IsInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        public bnet.protocol.channel.Member Member
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.member_ != null)
                {
                    goto Label_0012;
                }
                return bnet.protocol.channel.Member.DefaultInstance;
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
                    if (this.hasMember)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.Member);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override JoinNotification ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<JoinNotification, JoinNotification.Builder>
        {
            private JoinNotification result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = JoinNotification.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(JoinNotification cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override JoinNotification BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override JoinNotification.Builder Clear()
            {
                this.result = JoinNotification.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public JoinNotification.Builder ClearMember()
            {
                this.PrepareBuilder();
                this.result.hasMember = false;
                this.result.member_ = null;
                return this;
            }

            public override JoinNotification.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new JoinNotification.Builder(this.result);
                }
                return new JoinNotification.Builder().MergeFrom(this.result);
            }

            public override JoinNotification.Builder MergeFrom(JoinNotification other)
            {
                if (other != JoinNotification.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasMember)
                    {
                        this.MergeMember(other.Member);
                    }
                }
                return this;
            }

            public override JoinNotification.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override JoinNotification.Builder MergeFrom(IMessageLite other)
            {
                if (other is JoinNotification)
                {
                    return this.MergeFrom((JoinNotification) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override JoinNotification.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(JoinNotification._joinNotificationFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = JoinNotification._joinNotificationFieldTags[index];
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
                            bnet.protocol.channel.Member.Builder builder = bnet.protocol.channel.Member.CreateBuilder();
                            if (this.result.hasMember)
                            {
                                builder.MergeFrom(this.Member);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.Member = builder.BuildPartial();
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

            public JoinNotification.Builder MergeMember(bnet.protocol.channel.Member value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasMember && (this.result.member_ != bnet.protocol.channel.Member.DefaultInstance))
                {
                    this.result.member_ = bnet.protocol.channel.Member.CreateBuilder(this.result.member_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.member_ = value;
                }
                this.result.hasMember = true;
                return this;
            }

            private JoinNotification PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    JoinNotification result = this.result;
                    this.result = new JoinNotification();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public JoinNotification.Builder SetMember(bnet.protocol.channel.Member value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasMember = true;
                this.result.member_ = value;
                return this;
            }

            public JoinNotification.Builder SetMember(bnet.protocol.channel.Member.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasMember = true;
                this.result.member_ = builderForValue.Build();
                return this;
            }

            public override JoinNotification DefaultInstanceForType
            {
                get
                {
                    return JoinNotification.DefaultInstance;
                }
            }

            public bool HasMember
            {
                get
                {
                    return this.result.hasMember;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public bnet.protocol.channel.Member Member
            {
                get
                {
                    return this.result.Member;
                }
                set
                {
                    this.SetMember(value);
                }
            }

            protected override JoinNotification MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override JoinNotification.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

