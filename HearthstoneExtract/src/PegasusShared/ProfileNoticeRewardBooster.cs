namespace PegasusShared
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class ProfileNoticeRewardBooster : GeneratedMessageLite<ProfileNoticeRewardBooster, Builder>
    {
        private static readonly string[] _profileNoticeRewardBoosterFieldNames = new string[] { "booster_count", "booster_type" };
        private static readonly uint[] _profileNoticeRewardBoosterFieldTags = new uint[] { 0x10, 8 };
        private int boosterCount_;
        public const int BoosterCountFieldNumber = 2;
        private int boosterType_;
        public const int BoosterTypeFieldNumber = 1;
        private static readonly ProfileNoticeRewardBooster defaultInstance = new ProfileNoticeRewardBooster().MakeReadOnly();
        private bool hasBoosterCount;
        private bool hasBoosterType;
        private int memoizedSerializedSize = -1;

        static ProfileNoticeRewardBooster()
        {
            object.ReferenceEquals(PegasusSharedlite.Descriptor, null);
        }

        private ProfileNoticeRewardBooster()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ProfileNoticeRewardBooster prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ProfileNoticeRewardBooster booster = obj as ProfileNoticeRewardBooster;
            if (booster == null)
            {
                return false;
            }
            if ((this.hasBoosterType != booster.hasBoosterType) || (this.hasBoosterType && !this.boosterType_.Equals(booster.boosterType_)))
            {
                return false;
            }
            return ((this.hasBoosterCount == booster.hasBoosterCount) && (!this.hasBoosterCount || this.boosterCount_.Equals(booster.boosterCount_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasBoosterType)
            {
                hashCode ^= this.boosterType_.GetHashCode();
            }
            if (this.hasBoosterCount)
            {
                hashCode ^= this.boosterCount_.GetHashCode();
            }
            return hashCode;
        }

        private ProfileNoticeRewardBooster MakeReadOnly()
        {
            return this;
        }

        public static ProfileNoticeRewardBooster ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ProfileNoticeRewardBooster ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileNoticeRewardBooster ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ProfileNoticeRewardBooster ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ProfileNoticeRewardBooster ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ProfileNoticeRewardBooster ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ProfileNoticeRewardBooster ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ProfileNoticeRewardBooster ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileNoticeRewardBooster ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileNoticeRewardBooster ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ProfileNoticeRewardBooster, Builder>.PrintField("booster_type", this.hasBoosterType, this.boosterType_, writer);
            GeneratedMessageLite<ProfileNoticeRewardBooster, Builder>.PrintField("booster_count", this.hasBoosterCount, this.boosterCount_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _profileNoticeRewardBoosterFieldNames;
            if (this.hasBoosterType)
            {
                output.WriteInt32(1, strArray[1], this.BoosterType);
            }
            if (this.hasBoosterCount)
            {
                output.WriteInt32(2, strArray[0], this.BoosterCount);
            }
        }

        public int BoosterCount
        {
            get
            {
                return this.boosterCount_;
            }
        }

        public int BoosterType
        {
            get
            {
                return this.boosterType_;
            }
        }

        public static ProfileNoticeRewardBooster DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ProfileNoticeRewardBooster DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasBoosterCount
        {
            get
            {
                return this.hasBoosterCount;
            }
        }

        public bool HasBoosterType
        {
            get
            {
                return this.hasBoosterType;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasBoosterType)
                {
                    return false;
                }
                if (!this.hasBoosterCount)
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
                    if (this.hasBoosterType)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.BoosterType);
                    }
                    if (this.hasBoosterCount)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.BoosterCount);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ProfileNoticeRewardBooster ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<ProfileNoticeRewardBooster, ProfileNoticeRewardBooster.Builder>
        {
            private ProfileNoticeRewardBooster result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ProfileNoticeRewardBooster.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ProfileNoticeRewardBooster cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override ProfileNoticeRewardBooster BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ProfileNoticeRewardBooster.Builder Clear()
            {
                this.result = ProfileNoticeRewardBooster.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ProfileNoticeRewardBooster.Builder ClearBoosterCount()
            {
                this.PrepareBuilder();
                this.result.hasBoosterCount = false;
                this.result.boosterCount_ = 0;
                return this;
            }

            public ProfileNoticeRewardBooster.Builder ClearBoosterType()
            {
                this.PrepareBuilder();
                this.result.hasBoosterType = false;
                this.result.boosterType_ = 0;
                return this;
            }

            public override ProfileNoticeRewardBooster.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ProfileNoticeRewardBooster.Builder(this.result);
                }
                return new ProfileNoticeRewardBooster.Builder().MergeFrom(this.result);
            }

            public override ProfileNoticeRewardBooster.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ProfileNoticeRewardBooster.Builder MergeFrom(IMessageLite other)
            {
                if (other is ProfileNoticeRewardBooster)
                {
                    return this.MergeFrom((ProfileNoticeRewardBooster) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ProfileNoticeRewardBooster.Builder MergeFrom(ProfileNoticeRewardBooster other)
            {
                if (other != ProfileNoticeRewardBooster.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasBoosterType)
                    {
                        this.BoosterType = other.BoosterType;
                    }
                    if (other.HasBoosterCount)
                    {
                        this.BoosterCount = other.BoosterCount;
                    }
                }
                return this;
            }

            public override ProfileNoticeRewardBooster.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ProfileNoticeRewardBooster._profileNoticeRewardBoosterFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ProfileNoticeRewardBooster._profileNoticeRewardBoosterFieldTags[index];
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
                            this.result.hasBoosterType = input.ReadInt32(ref this.result.boosterType_);
                            continue;
                        }
                        case 0x10:
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
                    this.result.hasBoosterCount = input.ReadInt32(ref this.result.boosterCount_);
                }
                return this;
            }

            private ProfileNoticeRewardBooster PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ProfileNoticeRewardBooster result = this.result;
                    this.result = new ProfileNoticeRewardBooster();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ProfileNoticeRewardBooster.Builder SetBoosterCount(int value)
            {
                this.PrepareBuilder();
                this.result.hasBoosterCount = true;
                this.result.boosterCount_ = value;
                return this;
            }

            public ProfileNoticeRewardBooster.Builder SetBoosterType(int value)
            {
                this.PrepareBuilder();
                this.result.hasBoosterType = true;
                this.result.boosterType_ = value;
                return this;
            }

            public int BoosterCount
            {
                get
                {
                    return this.result.BoosterCount;
                }
                set
                {
                    this.SetBoosterCount(value);
                }
            }

            public int BoosterType
            {
                get
                {
                    return this.result.BoosterType;
                }
                set
                {
                    this.SetBoosterType(value);
                }
            }

            public override ProfileNoticeRewardBooster DefaultInstanceForType
            {
                get
                {
                    return ProfileNoticeRewardBooster.DefaultInstance;
                }
            }

            public bool HasBoosterCount
            {
                get
                {
                    return this.result.hasBoosterCount;
                }
            }

            public bool HasBoosterType
            {
                get
                {
                    return this.result.hasBoosterType;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override ProfileNoticeRewardBooster MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override ProfileNoticeRewardBooster.Builder ThisBuilder
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
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum NoticeID
            {
                ID = 2
            }
        }
    }
}

