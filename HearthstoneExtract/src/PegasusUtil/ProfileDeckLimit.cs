namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class ProfileDeckLimit : GeneratedMessageLite<ProfileDeckLimit, Builder>
    {
        private static readonly string[] _profileDeckLimitFieldNames = new string[] { "deck_limit" };
        private static readonly uint[] _profileDeckLimitFieldTags = new uint[] { 8 };
        private int deckLimit_;
        public const int DeckLimitFieldNumber = 1;
        private static readonly ProfileDeckLimit defaultInstance = new ProfileDeckLimit().MakeReadOnly();
        private bool hasDeckLimit;
        private int memoizedSerializedSize = -1;

        static ProfileDeckLimit()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private ProfileDeckLimit()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ProfileDeckLimit prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ProfileDeckLimit limit = obj as ProfileDeckLimit;
            if (limit == null)
            {
                return false;
            }
            return ((this.hasDeckLimit == limit.hasDeckLimit) && (!this.hasDeckLimit || this.deckLimit_.Equals(limit.deckLimit_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasDeckLimit)
            {
                hashCode ^= this.deckLimit_.GetHashCode();
            }
            return hashCode;
        }

        private ProfileDeckLimit MakeReadOnly()
        {
            return this;
        }

        public static ProfileDeckLimit ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ProfileDeckLimit ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileDeckLimit ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ProfileDeckLimit ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ProfileDeckLimit ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ProfileDeckLimit ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ProfileDeckLimit ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ProfileDeckLimit ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileDeckLimit ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileDeckLimit ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ProfileDeckLimit, Builder>.PrintField("deck_limit", this.hasDeckLimit, this.deckLimit_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _profileDeckLimitFieldNames;
            if (this.hasDeckLimit)
            {
                output.WriteInt32(1, strArray[0], this.DeckLimit);
            }
        }

        public int DeckLimit
        {
            get
            {
                return this.deckLimit_;
            }
        }

        public static ProfileDeckLimit DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ProfileDeckLimit DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasDeckLimit
        {
            get
            {
                return this.hasDeckLimit;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasDeckLimit)
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
                    if (this.hasDeckLimit)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.DeckLimit);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ProfileDeckLimit ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<ProfileDeckLimit, ProfileDeckLimit.Builder>
        {
            private ProfileDeckLimit result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ProfileDeckLimit.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ProfileDeckLimit cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override ProfileDeckLimit BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ProfileDeckLimit.Builder Clear()
            {
                this.result = ProfileDeckLimit.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ProfileDeckLimit.Builder ClearDeckLimit()
            {
                this.PrepareBuilder();
                this.result.hasDeckLimit = false;
                this.result.deckLimit_ = 0;
                return this;
            }

            public override ProfileDeckLimit.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ProfileDeckLimit.Builder(this.result);
                }
                return new ProfileDeckLimit.Builder().MergeFrom(this.result);
            }

            public override ProfileDeckLimit.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ProfileDeckLimit.Builder MergeFrom(IMessageLite other)
            {
                if (other is ProfileDeckLimit)
                {
                    return this.MergeFrom((ProfileDeckLimit) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ProfileDeckLimit.Builder MergeFrom(ProfileDeckLimit other)
            {
                if (other != ProfileDeckLimit.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasDeckLimit)
                    {
                        this.DeckLimit = other.DeckLimit;
                    }
                }
                return this;
            }

            public override ProfileDeckLimit.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ProfileDeckLimit._profileDeckLimitFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ProfileDeckLimit._profileDeckLimitFieldTags[index];
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
                    this.result.hasDeckLimit = input.ReadInt32(ref this.result.deckLimit_);
                }
                return this;
            }

            private ProfileDeckLimit PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ProfileDeckLimit result = this.result;
                    this.result = new ProfileDeckLimit();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ProfileDeckLimit.Builder SetDeckLimit(int value)
            {
                this.PrepareBuilder();
                this.result.hasDeckLimit = true;
                this.result.deckLimit_ = value;
                return this;
            }

            public int DeckLimit
            {
                get
                {
                    return this.result.DeckLimit;
                }
                set
                {
                    this.SetDeckLimit(value);
                }
            }

            public override ProfileDeckLimit DefaultInstanceForType
            {
                get
                {
                    return ProfileDeckLimit.DefaultInstance;
                }
            }

            public bool HasDeckLimit
            {
                get
                {
                    return this.result.hasDeckLimit;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override ProfileDeckLimit MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override ProfileDeckLimit.Builder ThisBuilder
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
                ID = 0xe7
            }
        }
    }
}

