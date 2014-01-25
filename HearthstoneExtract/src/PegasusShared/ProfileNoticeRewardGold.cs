namespace PegasusShared
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class ProfileNoticeRewardGold : GeneratedMessageLite<ProfileNoticeRewardGold, Builder>
    {
        private static readonly string[] _profileNoticeRewardGoldFieldNames = new string[] { "amount" };
        private static readonly uint[] _profileNoticeRewardGoldFieldTags = new uint[] { 8 };
        private int amount_;
        public const int AmountFieldNumber = 1;
        private static readonly ProfileNoticeRewardGold defaultInstance = new ProfileNoticeRewardGold().MakeReadOnly();
        private bool hasAmount;
        private int memoizedSerializedSize = -1;

        static ProfileNoticeRewardGold()
        {
            object.ReferenceEquals(PegasusSharedlite.Descriptor, null);
        }

        private ProfileNoticeRewardGold()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ProfileNoticeRewardGold prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ProfileNoticeRewardGold gold = obj as ProfileNoticeRewardGold;
            if (gold == null)
            {
                return false;
            }
            return ((this.hasAmount == gold.hasAmount) && (!this.hasAmount || this.amount_.Equals(gold.amount_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasAmount)
            {
                hashCode ^= this.amount_.GetHashCode();
            }
            return hashCode;
        }

        private ProfileNoticeRewardGold MakeReadOnly()
        {
            return this;
        }

        public static ProfileNoticeRewardGold ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ProfileNoticeRewardGold ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileNoticeRewardGold ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ProfileNoticeRewardGold ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ProfileNoticeRewardGold ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ProfileNoticeRewardGold ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ProfileNoticeRewardGold ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ProfileNoticeRewardGold ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileNoticeRewardGold ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileNoticeRewardGold ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ProfileNoticeRewardGold, Builder>.PrintField("amount", this.hasAmount, this.amount_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _profileNoticeRewardGoldFieldNames;
            if (this.hasAmount)
            {
                output.WriteInt32(1, strArray[0], this.Amount);
            }
        }

        public int Amount
        {
            get
            {
                return this.amount_;
            }
        }

        public static ProfileNoticeRewardGold DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ProfileNoticeRewardGold DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasAmount
        {
            get
            {
                return this.hasAmount;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasAmount)
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
                    if (this.hasAmount)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.Amount);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ProfileNoticeRewardGold ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<ProfileNoticeRewardGold, ProfileNoticeRewardGold.Builder>
        {
            private ProfileNoticeRewardGold result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ProfileNoticeRewardGold.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ProfileNoticeRewardGold cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override ProfileNoticeRewardGold BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ProfileNoticeRewardGold.Builder Clear()
            {
                this.result = ProfileNoticeRewardGold.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ProfileNoticeRewardGold.Builder ClearAmount()
            {
                this.PrepareBuilder();
                this.result.hasAmount = false;
                this.result.amount_ = 0;
                return this;
            }

            public override ProfileNoticeRewardGold.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ProfileNoticeRewardGold.Builder(this.result);
                }
                return new ProfileNoticeRewardGold.Builder().MergeFrom(this.result);
            }

            public override ProfileNoticeRewardGold.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ProfileNoticeRewardGold.Builder MergeFrom(IMessageLite other)
            {
                if (other is ProfileNoticeRewardGold)
                {
                    return this.MergeFrom((ProfileNoticeRewardGold) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ProfileNoticeRewardGold.Builder MergeFrom(ProfileNoticeRewardGold other)
            {
                if (other != ProfileNoticeRewardGold.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAmount)
                    {
                        this.Amount = other.Amount;
                    }
                }
                return this;
            }

            public override ProfileNoticeRewardGold.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ProfileNoticeRewardGold._profileNoticeRewardGoldFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ProfileNoticeRewardGold._profileNoticeRewardGoldFieldTags[index];
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
                    this.result.hasAmount = input.ReadInt32(ref this.result.amount_);
                }
                return this;
            }

            private ProfileNoticeRewardGold PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ProfileNoticeRewardGold result = this.result;
                    this.result = new ProfileNoticeRewardGold();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ProfileNoticeRewardGold.Builder SetAmount(int value)
            {
                this.PrepareBuilder();
                this.result.hasAmount = true;
                this.result.amount_ = value;
                return this;
            }

            public int Amount
            {
                get
                {
                    return this.result.Amount;
                }
                set
                {
                    this.SetAmount(value);
                }
            }

            public override ProfileNoticeRewardGold DefaultInstanceForType
            {
                get
                {
                    return ProfileNoticeRewardGold.DefaultInstance;
                }
            }

            public bool HasAmount
            {
                get
                {
                    return this.result.hasAmount;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override ProfileNoticeRewardGold MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override ProfileNoticeRewardGold.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum NoticeID
            {
                ID = 9
            }
        }
    }
}

