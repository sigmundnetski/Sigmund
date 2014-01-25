namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class HostFriend : GeneratedMessageLite<HostFriend, Builder>
    {
        private static readonly string[] _hostFriendFieldNames = new string[] { "against", "debug_name", "deck" };
        private static readonly uint[] _hostFriendFieldTags = new uint[] { 0x1a, 0x12, 8 };
        private string against_ = string.Empty;
        public const int AgainstFieldNumber = 3;
        private string debugName_ = string.Empty;
        public const int DebugNameFieldNumber = 2;
        private long deck_;
        public const int DeckFieldNumber = 1;
        private static readonly HostFriend defaultInstance = new HostFriend().MakeReadOnly();
        private bool hasAgainst;
        private bool hasDebugName;
        private bool hasDeck;
        private int memoizedSerializedSize = -1;

        static HostFriend()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private HostFriend()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(HostFriend prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            HostFriend friend = obj as HostFriend;
            if (friend == null)
            {
                return false;
            }
            if ((this.hasDeck != friend.hasDeck) || (this.hasDeck && !this.deck_.Equals(friend.deck_)))
            {
                return false;
            }
            if ((this.hasDebugName != friend.hasDebugName) || (this.hasDebugName && !this.debugName_.Equals(friend.debugName_)))
            {
                return false;
            }
            return ((this.hasAgainst == friend.hasAgainst) && (!this.hasAgainst || this.against_.Equals(friend.against_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasDeck)
            {
                hashCode ^= this.deck_.GetHashCode();
            }
            if (this.hasDebugName)
            {
                hashCode ^= this.debugName_.GetHashCode();
            }
            if (this.hasAgainst)
            {
                hashCode ^= this.against_.GetHashCode();
            }
            return hashCode;
        }

        private HostFriend MakeReadOnly()
        {
            return this;
        }

        public static HostFriend ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static HostFriend ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static HostFriend ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static HostFriend ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static HostFriend ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static HostFriend ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static HostFriend ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static HostFriend ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static HostFriend ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static HostFriend ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<HostFriend, Builder>.PrintField("deck", this.hasDeck, this.deck_, writer);
            GeneratedMessageLite<HostFriend, Builder>.PrintField("debug_name", this.hasDebugName, this.debugName_, writer);
            GeneratedMessageLite<HostFriend, Builder>.PrintField("against", this.hasAgainst, this.against_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _hostFriendFieldNames;
            if (this.hasDeck)
            {
                output.WriteInt64(1, strArray[2], this.Deck);
            }
            if (this.hasDebugName)
            {
                output.WriteString(2, strArray[1], this.DebugName);
            }
            if (this.hasAgainst)
            {
                output.WriteString(3, strArray[0], this.Against);
            }
        }

        public string Against
        {
            get
            {
                return this.against_;
            }
        }

        public string DebugName
        {
            get
            {
                return this.debugName_;
            }
        }

        public long Deck
        {
            get
            {
                return this.deck_;
            }
        }

        public static HostFriend DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override HostFriend DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasAgainst
        {
            get
            {
                return this.hasAgainst;
            }
        }

        public bool HasDebugName
        {
            get
            {
                return this.hasDebugName;
            }
        }

        public bool HasDeck
        {
            get
            {
                return this.hasDeck;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasDeck)
                {
                    return false;
                }
                if (!this.hasDebugName)
                {
                    return false;
                }
                if (!this.hasAgainst)
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
                    if (this.hasDeck)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(1, this.Deck);
                    }
                    if (this.hasDebugName)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(2, this.DebugName);
                    }
                    if (this.hasAgainst)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(3, this.Against);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override HostFriend ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<HostFriend, HostFriend.Builder>
        {
            private HostFriend result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = HostFriend.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(HostFriend cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override HostFriend BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override HostFriend.Builder Clear()
            {
                this.result = HostFriend.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public HostFriend.Builder ClearAgainst()
            {
                this.PrepareBuilder();
                this.result.hasAgainst = false;
                this.result.against_ = string.Empty;
                return this;
            }

            public HostFriend.Builder ClearDebugName()
            {
                this.PrepareBuilder();
                this.result.hasDebugName = false;
                this.result.debugName_ = string.Empty;
                return this;
            }

            public HostFriend.Builder ClearDeck()
            {
                this.PrepareBuilder();
                this.result.hasDeck = false;
                this.result.deck_ = 0L;
                return this;
            }

            public override HostFriend.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new HostFriend.Builder(this.result);
                }
                return new HostFriend.Builder().MergeFrom(this.result);
            }

            public override HostFriend.Builder MergeFrom(HostFriend other)
            {
                if (other != HostFriend.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasDeck)
                    {
                        this.Deck = other.Deck;
                    }
                    if (other.HasDebugName)
                    {
                        this.DebugName = other.DebugName;
                    }
                    if (other.HasAgainst)
                    {
                        this.Against = other.Against;
                    }
                }
                return this;
            }

            public override HostFriend.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override HostFriend.Builder MergeFrom(IMessageLite other)
            {
                if (other is HostFriend)
                {
                    return this.MergeFrom((HostFriend) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override HostFriend.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(HostFriend._hostFriendFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = HostFriend._hostFriendFieldTags[index];
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
                            this.result.hasDeck = input.ReadInt64(ref this.result.deck_);
                            continue;
                        }
                        case 0x12:
                        {
                            this.result.hasDebugName = input.ReadString(ref this.result.debugName_);
                            continue;
                        }
                        case 0x1a:
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
                    this.result.hasAgainst = input.ReadString(ref this.result.against_);
                }
                return this;
            }

            private HostFriend PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    HostFriend result = this.result;
                    this.result = new HostFriend();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public HostFriend.Builder SetAgainst(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasAgainst = true;
                this.result.against_ = value;
                return this;
            }

            public HostFriend.Builder SetDebugName(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasDebugName = true;
                this.result.debugName_ = value;
                return this;
            }

            public HostFriend.Builder SetDeck(long value)
            {
                this.PrepareBuilder();
                this.result.hasDeck = true;
                this.result.deck_ = value;
                return this;
            }

            public string Against
            {
                get
                {
                    return this.result.Against;
                }
                set
                {
                    this.SetAgainst(value);
                }
            }

            public string DebugName
            {
                get
                {
                    return this.result.DebugName;
                }
                set
                {
                    this.SetDebugName(value);
                }
            }

            public long Deck
            {
                get
                {
                    return this.result.Deck;
                }
                set
                {
                    this.SetDeck(value);
                }
            }

            public override HostFriend DefaultInstanceForType
            {
                get
                {
                    return HostFriend.DefaultInstance;
                }
            }

            public bool HasAgainst
            {
                get
                {
                    return this.result.hasAgainst;
                }
            }

            public bool HasDebugName
            {
                get
                {
                    return this.result.hasDebugName;
                }
            }

            public bool HasDeck
            {
                get
                {
                    return this.result.hasDeck;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override HostFriend MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override HostFriend.Builder ThisBuilder
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
                ID = 0x9e
            }
        }
    }
}

