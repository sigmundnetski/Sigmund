namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class InviteFailed : GeneratedMessageLite<InviteFailed, Builder>
    {
        private static readonly string[] _inviteFailedFieldNames = new string[] { "friend_name", "reason" };
        private static readonly uint[] _inviteFailedFieldTags = new uint[] { 0x12, 8 };
        private static readonly InviteFailed defaultInstance = new InviteFailed().MakeReadOnly();
        private string friendName_ = string.Empty;
        public const int FriendNameFieldNumber = 2;
        private bool hasFriendName;
        private bool hasReason;
        private int memoizedSerializedSize = -1;
        private BobNetProto.InviteFailed.Types.Reason reason_ = BobNetProto.InviteFailed.Types.Reason.INVITE_DECLINED;
        public const int ReasonFieldNumber = 1;

        static InviteFailed()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private InviteFailed()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(InviteFailed prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            InviteFailed failed = obj as InviteFailed;
            if (failed == null)
            {
                return false;
            }
            if ((this.hasReason != failed.hasReason) || (this.hasReason && !this.reason_.Equals(failed.reason_)))
            {
                return false;
            }
            return ((this.hasFriendName == failed.hasFriendName) && (!this.hasFriendName || this.friendName_.Equals(failed.friendName_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasReason)
            {
                hashCode ^= this.reason_.GetHashCode();
            }
            if (this.hasFriendName)
            {
                hashCode ^= this.friendName_.GetHashCode();
            }
            return hashCode;
        }

        private InviteFailed MakeReadOnly()
        {
            return this;
        }

        public static InviteFailed ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static InviteFailed ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static InviteFailed ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static InviteFailed ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static InviteFailed ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static InviteFailed ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static InviteFailed ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static InviteFailed ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static InviteFailed ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static InviteFailed ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<InviteFailed, Builder>.PrintField("reason", this.hasReason, this.reason_, writer);
            GeneratedMessageLite<InviteFailed, Builder>.PrintField("friend_name", this.hasFriendName, this.friendName_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _inviteFailedFieldNames;
            if (this.hasReason)
            {
                output.WriteEnum(1, strArray[1], (int) this.Reason, this.Reason);
            }
            if (this.hasFriendName)
            {
                output.WriteString(2, strArray[0], this.FriendName);
            }
        }

        public static InviteFailed DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override InviteFailed DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public string FriendName
        {
            get
            {
                return this.friendName_;
            }
        }

        public bool HasFriendName
        {
            get
            {
                return this.hasFriendName;
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
                if (!this.hasReason)
                {
                    return false;
                }
                if (!this.hasFriendName)
                {
                    return false;
                }
                return true;
            }
        }

        public BobNetProto.InviteFailed.Types.Reason Reason
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
                    if (this.hasReason)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeEnumSize(1, (int) this.Reason);
                    }
                    if (this.hasFriendName)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(2, this.FriendName);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override InviteFailed ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<InviteFailed, InviteFailed.Builder>
        {
            private InviteFailed result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = InviteFailed.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(InviteFailed cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override InviteFailed BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override InviteFailed.Builder Clear()
            {
                this.result = InviteFailed.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public InviteFailed.Builder ClearFriendName()
            {
                this.PrepareBuilder();
                this.result.hasFriendName = false;
                this.result.friendName_ = string.Empty;
                return this;
            }

            public InviteFailed.Builder ClearReason()
            {
                this.PrepareBuilder();
                this.result.hasReason = false;
                this.result.reason_ = BobNetProto.InviteFailed.Types.Reason.INVITE_DECLINED;
                return this;
            }

            public override InviteFailed.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new InviteFailed.Builder(this.result);
                }
                return new InviteFailed.Builder().MergeFrom(this.result);
            }

            public override InviteFailed.Builder MergeFrom(InviteFailed other)
            {
                if (other != InviteFailed.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasReason)
                    {
                        this.Reason = other.Reason;
                    }
                    if (other.HasFriendName)
                    {
                        this.FriendName = other.FriendName;
                    }
                }
                return this;
            }

            public override InviteFailed.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override InviteFailed.Builder MergeFrom(IMessageLite other)
            {
                if (other is InviteFailed)
                {
                    return this.MergeFrom((InviteFailed) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override InviteFailed.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(InviteFailed._inviteFailedFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = InviteFailed._inviteFailedFieldTags[index];
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

                        case 8:
                        {
                            object obj2;
                            if (input.ReadEnum<BobNetProto.InviteFailed.Types.Reason>(ref this.result.reason_, out obj2))
                            {
                                this.result.hasReason = true;
                            }
                            else if (obj2 is int)
                            {
                            }
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
                    this.result.hasFriendName = input.ReadString(ref this.result.friendName_);
                }
                return this;
            }

            private InviteFailed PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    InviteFailed result = this.result;
                    this.result = new InviteFailed();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public InviteFailed.Builder SetFriendName(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasFriendName = true;
                this.result.friendName_ = value;
                return this;
            }

            public InviteFailed.Builder SetReason(BobNetProto.InviteFailed.Types.Reason value)
            {
                this.PrepareBuilder();
                this.result.hasReason = true;
                this.result.reason_ = value;
                return this;
            }

            public override InviteFailed DefaultInstanceForType
            {
                get
                {
                    return InviteFailed.DefaultInstance;
                }
            }

            public string FriendName
            {
                get
                {
                    return this.result.FriendName;
                }
                set
                {
                    this.SetFriendName(value);
                }
            }

            public bool HasFriendName
            {
                get
                {
                    return this.result.hasFriendName;
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

            protected override InviteFailed MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public BobNetProto.InviteFailed.Types.Reason Reason
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

            protected override InviteFailed.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0xa3
            }

            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum Reason
            {
                INVITE_DECLINED = 1,
                INVITE_FAILED = 2
            }
        }
    }
}

