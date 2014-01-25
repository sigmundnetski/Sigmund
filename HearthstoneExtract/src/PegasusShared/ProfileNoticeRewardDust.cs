namespace PegasusShared
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class ProfileNoticeRewardDust : GeneratedMessageLite<ProfileNoticeRewardDust, Builder>
    {
        private static readonly string[] _profileNoticeRewardDustFieldNames = new string[] { "amount" };
        private static readonly uint[] _profileNoticeRewardDustFieldTags = new uint[] { 8 };
        private int amount_;
        public const int AmountFieldNumber = 1;
        private static readonly ProfileNoticeRewardDust defaultInstance = new ProfileNoticeRewardDust().MakeReadOnly();
        private bool hasAmount;
        private int memoizedSerializedSize = -1;

        static ProfileNoticeRewardDust()
        {
            object.ReferenceEquals(PegasusSharedlite.Descriptor, null);
        }

        private ProfileNoticeRewardDust()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ProfileNoticeRewardDust prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ProfileNoticeRewardDust dust = obj as ProfileNoticeRewardDust;
            if (dust == null)
            {
                return false;
            }
            return ((this.hasAmount == dust.hasAmount) && (!this.hasAmount || this.amount_.Equals(dust.amount_)));
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

        private ProfileNoticeRewardDust MakeReadOnly()
        {
            return this;
        }

        public static ProfileNoticeRewardDust ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ProfileNoticeRewardDust ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileNoticeRewardDust ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ProfileNoticeRewardDust ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ProfileNoticeRewardDust ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ProfileNoticeRewardDust ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ProfileNoticeRewardDust ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ProfileNoticeRewardDust ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileNoticeRewardDust ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileNoticeRewardDust ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ProfileNoticeRewardDust, Builder>.PrintField("amount", this.hasAmount, this.amount_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _profileNoticeRewardDustFieldNames;
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

        public static ProfileNoticeRewardDust DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ProfileNoticeRewardDust DefaultInstanceForType
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

        protected override ProfileNoticeRewardDust ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<ProfileNoticeRewardDust, ProfileNoticeRewardDust.Builder>
        {
            private ProfileNoticeRewardDust result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ProfileNoticeRewardDust.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ProfileNoticeRewardDust cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override ProfileNoticeRewardDust BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ProfileNoticeRewardDust.Builder Clear()
            {
                this.result = ProfileNoticeRewardDust.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ProfileNoticeRewardDust.Builder ClearAmount()
            {
                this.PrepareBuilder();
                this.result.hasAmount = false;
                this.result.amount_ = 0;
                return this;
            }

            public override ProfileNoticeRewardDust.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ProfileNoticeRewardDust.Builder(this.result);
                }
                return new ProfileNoticeRewardDust.Builder().MergeFrom(this.result);
            }

            public override ProfileNoticeRewardDust.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ProfileNoticeRewardDust.Builder MergeFrom(IMessageLite other)
            {
                if (other is ProfileNoticeRewardDust)
                {
                    return this.MergeFrom((ProfileNoticeRewardDust) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ProfileNoticeRewardDust.Builder MergeFrom(ProfileNoticeRewardDust other)
            {
                if (other != ProfileNoticeRewardDust.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAmount)
                    {
                        this.Amount = other.Amount;
                    }
                }
                return this;
            }

            public override ProfileNoticeRewardDust.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ProfileNoticeRewardDust._profileNoticeRewardDustFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ProfileNoticeRewardDust._profileNoticeRewardDustFieldTags[index];
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

            private ProfileNoticeRewardDust PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ProfileNoticeRewardDust result = this.result;
                    this.result = new ProfileNoticeRewardDust();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ProfileNoticeRewardDust.Builder SetAmount(int value)
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

            public override ProfileNoticeRewardDust DefaultInstanceForType
            {
                get
                {
                    return ProfileNoticeRewardDust.DefaultInstance;
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

            protected override ProfileNoticeRewardDust MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override ProfileNoticeRewardDust.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum NoticeID
            {
                ID = 6
            }
        }
    }
}

