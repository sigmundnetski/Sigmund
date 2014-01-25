namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class ProfileNoticeMedal : GeneratedMessageLite<ProfileNoticeMedal, Builder>
    {
        private static readonly string[] _profileNoticeMedalFieldNames = new string[] { "medal" };
        private static readonly uint[] _profileNoticeMedalFieldTags = new uint[] { 8 };
        private static readonly ProfileNoticeMedal defaultInstance = new ProfileNoticeMedal().MakeReadOnly();
        private bool hasMedal;
        private int medal_;
        public const int MedalFieldNumber = 1;
        private int memoizedSerializedSize = -1;

        static ProfileNoticeMedal()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private ProfileNoticeMedal()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ProfileNoticeMedal prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ProfileNoticeMedal medal = obj as ProfileNoticeMedal;
            if (medal == null)
            {
                return false;
            }
            return ((this.hasMedal == medal.hasMedal) && (!this.hasMedal || this.medal_.Equals(medal.medal_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasMedal)
            {
                hashCode ^= this.medal_.GetHashCode();
            }
            return hashCode;
        }

        private ProfileNoticeMedal MakeReadOnly()
        {
            return this;
        }

        public static ProfileNoticeMedal ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ProfileNoticeMedal ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileNoticeMedal ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ProfileNoticeMedal ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ProfileNoticeMedal ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ProfileNoticeMedal ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ProfileNoticeMedal ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ProfileNoticeMedal ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileNoticeMedal ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileNoticeMedal ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ProfileNoticeMedal, Builder>.PrintField("medal", this.hasMedal, this.medal_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _profileNoticeMedalFieldNames;
            if (this.hasMedal)
            {
                output.WriteInt32(1, strArray[0], this.Medal);
            }
        }

        public static ProfileNoticeMedal DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ProfileNoticeMedal DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasMedal
        {
            get
            {
                return this.hasMedal;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasMedal)
                {
                    return false;
                }
                return true;
            }
        }

        public int Medal
        {
            get
            {
                return this.medal_;
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
                    if (this.hasMedal)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.Medal);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ProfileNoticeMedal ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<ProfileNoticeMedal, ProfileNoticeMedal.Builder>
        {
            private ProfileNoticeMedal result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ProfileNoticeMedal.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ProfileNoticeMedal cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override ProfileNoticeMedal BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ProfileNoticeMedal.Builder Clear()
            {
                this.result = ProfileNoticeMedal.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ProfileNoticeMedal.Builder ClearMedal()
            {
                this.PrepareBuilder();
                this.result.hasMedal = false;
                this.result.medal_ = 0;
                return this;
            }

            public override ProfileNoticeMedal.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ProfileNoticeMedal.Builder(this.result);
                }
                return new ProfileNoticeMedal.Builder().MergeFrom(this.result);
            }

            public override ProfileNoticeMedal.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ProfileNoticeMedal.Builder MergeFrom(IMessageLite other)
            {
                if (other is ProfileNoticeMedal)
                {
                    return this.MergeFrom((ProfileNoticeMedal) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ProfileNoticeMedal.Builder MergeFrom(ProfileNoticeMedal other)
            {
                if (other != ProfileNoticeMedal.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasMedal)
                    {
                        this.Medal = other.Medal;
                    }
                }
                return this;
            }

            public override ProfileNoticeMedal.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ProfileNoticeMedal._profileNoticeMedalFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ProfileNoticeMedal._profileNoticeMedalFieldTags[index];
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
                    this.result.hasMedal = input.ReadInt32(ref this.result.medal_);
                }
                return this;
            }

            private ProfileNoticeMedal PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ProfileNoticeMedal result = this.result;
                    this.result = new ProfileNoticeMedal();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ProfileNoticeMedal.Builder SetMedal(int value)
            {
                this.PrepareBuilder();
                this.result.hasMedal = true;
                this.result.medal_ = value;
                return this;
            }

            public override ProfileNoticeMedal DefaultInstanceForType
            {
                get
                {
                    return ProfileNoticeMedal.DefaultInstance;
                }
            }

            public bool HasMedal
            {
                get
                {
                    return this.result.hasMedal;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public int Medal
            {
                get
                {
                    return this.result.Medal;
                }
                set
                {
                    this.SetMedal(value);
                }
            }

            protected override ProfileNoticeMedal MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override ProfileNoticeMedal.Builder ThisBuilder
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
                ID = 1
            }
        }
    }
}

