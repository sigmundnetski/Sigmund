namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class FriendInvite : GeneratedMessageLite<FriendInvite, Builder>
    {
        private static readonly string[] _friendInviteFieldNames = new string[] { "bn_game_handle", "friend_name" };
        private static readonly uint[] _friendInviteFieldTags = new uint[] { 8, 0x12 };
        private int bnGameHandle_;
        public const int BnGameHandleFieldNumber = 1;
        private static readonly FriendInvite defaultInstance = new FriendInvite().MakeReadOnly();
        private string friendName_ = string.Empty;
        public const int FriendNameFieldNumber = 2;
        private bool hasBnGameHandle;
        private bool hasFriendName;
        private int memoizedSerializedSize = -1;

        static FriendInvite()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private FriendInvite()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(FriendInvite prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            FriendInvite invite = obj as FriendInvite;
            if (invite == null)
            {
                return false;
            }
            if ((this.hasBnGameHandle != invite.hasBnGameHandle) || (this.hasBnGameHandle && !this.bnGameHandle_.Equals(invite.bnGameHandle_)))
            {
                return false;
            }
            return ((this.hasFriendName == invite.hasFriendName) && (!this.hasFriendName || this.friendName_.Equals(invite.friendName_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasBnGameHandle)
            {
                hashCode ^= this.bnGameHandle_.GetHashCode();
            }
            if (this.hasFriendName)
            {
                hashCode ^= this.friendName_.GetHashCode();
            }
            return hashCode;
        }

        private FriendInvite MakeReadOnly()
        {
            return this;
        }

        public static FriendInvite ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static FriendInvite ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static FriendInvite ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static FriendInvite ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static FriendInvite ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static FriendInvite ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static FriendInvite ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static FriendInvite ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static FriendInvite ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static FriendInvite ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<FriendInvite, Builder>.PrintField("bn_game_handle", this.hasBnGameHandle, this.bnGameHandle_, writer);
            GeneratedMessageLite<FriendInvite, Builder>.PrintField("friend_name", this.hasFriendName, this.friendName_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _friendInviteFieldNames;
            if (this.hasBnGameHandle)
            {
                output.WriteInt32(1, strArray[0], this.BnGameHandle);
            }
            if (this.hasFriendName)
            {
                output.WriteString(2, strArray[1], this.FriendName);
            }
        }

        public int BnGameHandle
        {
            get
            {
                return this.bnGameHandle_;
            }
        }

        public static FriendInvite DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override FriendInvite DefaultInstanceForType
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

        public bool HasBnGameHandle
        {
            get
            {
                return this.hasBnGameHandle;
            }
        }

        public bool HasFriendName
        {
            get
            {
                return this.hasFriendName;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasBnGameHandle)
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

        public override int SerializedSize
        {
            get
            {
                int memoizedSerializedSize = this.memoizedSerializedSize;
                if (memoizedSerializedSize == -1)
                {
                    memoizedSerializedSize = 0;
                    if (this.hasBnGameHandle)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.BnGameHandle);
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

        protected override FriendInvite ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<FriendInvite, FriendInvite.Builder>
        {
            private FriendInvite result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = FriendInvite.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(FriendInvite cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override FriendInvite BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override FriendInvite.Builder Clear()
            {
                this.result = FriendInvite.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public FriendInvite.Builder ClearBnGameHandle()
            {
                this.PrepareBuilder();
                this.result.hasBnGameHandle = false;
                this.result.bnGameHandle_ = 0;
                return this;
            }

            public FriendInvite.Builder ClearFriendName()
            {
                this.PrepareBuilder();
                this.result.hasFriendName = false;
                this.result.friendName_ = string.Empty;
                return this;
            }

            public override FriendInvite.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new FriendInvite.Builder(this.result);
                }
                return new FriendInvite.Builder().MergeFrom(this.result);
            }

            public override FriendInvite.Builder MergeFrom(FriendInvite other)
            {
                if (other != FriendInvite.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasBnGameHandle)
                    {
                        this.BnGameHandle = other.BnGameHandle;
                    }
                    if (other.HasFriendName)
                    {
                        this.FriendName = other.FriendName;
                    }
                }
                return this;
            }

            public override FriendInvite.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override FriendInvite.Builder MergeFrom(IMessageLite other)
            {
                if (other is FriendInvite)
                {
                    return this.MergeFrom((FriendInvite) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override FriendInvite.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(FriendInvite._friendInviteFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = FriendInvite._friendInviteFieldTags[index];
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
                            this.result.hasBnGameHandle = input.ReadInt32(ref this.result.bnGameHandle_);
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

            private FriendInvite PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    FriendInvite result = this.result;
                    this.result = new FriendInvite();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public FriendInvite.Builder SetBnGameHandle(int value)
            {
                this.PrepareBuilder();
                this.result.hasBnGameHandle = true;
                this.result.bnGameHandle_ = value;
                return this;
            }

            public FriendInvite.Builder SetFriendName(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasFriendName = true;
                this.result.friendName_ = value;
                return this;
            }

            public int BnGameHandle
            {
                get
                {
                    return this.result.BnGameHandle;
                }
                set
                {
                    this.SetBnGameHandle(value);
                }
            }

            public override FriendInvite DefaultInstanceForType
            {
                get
                {
                    return FriendInvite.DefaultInstance;
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

            public bool HasBnGameHandle
            {
                get
                {
                    return this.result.hasBnGameHandle;
                }
            }

            public bool HasFriendName
            {
                get
                {
                    return this.result.hasFriendName;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override FriendInvite MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override FriendInvite.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0x9f
            }
        }
    }
}

