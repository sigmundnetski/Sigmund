namespace PegasusShared
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class ProfileNoticeRewardMount : GeneratedMessageLite<ProfileNoticeRewardMount, Builder>
    {
        private static readonly string[] _profileNoticeRewardMountFieldNames = new string[] { "mount_id" };
        private static readonly uint[] _profileNoticeRewardMountFieldTags = new uint[] { 8 };
        private static readonly ProfileNoticeRewardMount defaultInstance = new ProfileNoticeRewardMount().MakeReadOnly();
        private bool hasMountId;
        private int memoizedSerializedSize = -1;
        private int mountId_;
        public const int MountIdFieldNumber = 1;

        static ProfileNoticeRewardMount()
        {
            object.ReferenceEquals(PegasusSharedlite.Descriptor, null);
        }

        private ProfileNoticeRewardMount()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ProfileNoticeRewardMount prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ProfileNoticeRewardMount mount = obj as ProfileNoticeRewardMount;
            if (mount == null)
            {
                return false;
            }
            return ((this.hasMountId == mount.hasMountId) && (!this.hasMountId || this.mountId_.Equals(mount.mountId_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasMountId)
            {
                hashCode ^= this.mountId_.GetHashCode();
            }
            return hashCode;
        }

        private ProfileNoticeRewardMount MakeReadOnly()
        {
            return this;
        }

        public static ProfileNoticeRewardMount ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ProfileNoticeRewardMount ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileNoticeRewardMount ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ProfileNoticeRewardMount ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ProfileNoticeRewardMount ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ProfileNoticeRewardMount ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ProfileNoticeRewardMount ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ProfileNoticeRewardMount ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileNoticeRewardMount ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileNoticeRewardMount ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ProfileNoticeRewardMount, Builder>.PrintField("mount_id", this.hasMountId, this.mountId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _profileNoticeRewardMountFieldNames;
            if (this.hasMountId)
            {
                output.WriteInt32(1, strArray[0], this.MountId);
            }
        }

        public static ProfileNoticeRewardMount DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ProfileNoticeRewardMount DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasMountId
        {
            get
            {
                return this.hasMountId;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasMountId)
                {
                    return false;
                }
                return true;
            }
        }

        public int MountId
        {
            get
            {
                return this.mountId_;
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
                    if (this.hasMountId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.MountId);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ProfileNoticeRewardMount ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<ProfileNoticeRewardMount, ProfileNoticeRewardMount.Builder>
        {
            private ProfileNoticeRewardMount result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ProfileNoticeRewardMount.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ProfileNoticeRewardMount cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override ProfileNoticeRewardMount BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ProfileNoticeRewardMount.Builder Clear()
            {
                this.result = ProfileNoticeRewardMount.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ProfileNoticeRewardMount.Builder ClearMountId()
            {
                this.PrepareBuilder();
                this.result.hasMountId = false;
                this.result.mountId_ = 0;
                return this;
            }

            public override ProfileNoticeRewardMount.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ProfileNoticeRewardMount.Builder(this.result);
                }
                return new ProfileNoticeRewardMount.Builder().MergeFrom(this.result);
            }

            public override ProfileNoticeRewardMount.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ProfileNoticeRewardMount.Builder MergeFrom(IMessageLite other)
            {
                if (other is ProfileNoticeRewardMount)
                {
                    return this.MergeFrom((ProfileNoticeRewardMount) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ProfileNoticeRewardMount.Builder MergeFrom(ProfileNoticeRewardMount other)
            {
                if (other != ProfileNoticeRewardMount.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasMountId)
                    {
                        this.MountId = other.MountId;
                    }
                }
                return this;
            }

            public override ProfileNoticeRewardMount.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ProfileNoticeRewardMount._profileNoticeRewardMountFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ProfileNoticeRewardMount._profileNoticeRewardMountFieldTags[index];
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
                    this.result.hasMountId = input.ReadInt32(ref this.result.mountId_);
                }
                return this;
            }

            private ProfileNoticeRewardMount PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ProfileNoticeRewardMount result = this.result;
                    this.result = new ProfileNoticeRewardMount();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ProfileNoticeRewardMount.Builder SetMountId(int value)
            {
                this.PrepareBuilder();
                this.result.hasMountId = true;
                this.result.mountId_ = value;
                return this;
            }

            public override ProfileNoticeRewardMount DefaultInstanceForType
            {
                get
                {
                    return ProfileNoticeRewardMount.DefaultInstance;
                }
            }

            public bool HasMountId
            {
                get
                {
                    return this.result.hasMountId;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override ProfileNoticeRewardMount MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int MountId
            {
                get
                {
                    return this.result.MountId;
                }
                set
                {
                    this.SetMountId(value);
                }
            }

            protected override ProfileNoticeRewardMount.Builder ThisBuilder
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
            public enum NoticeID
            {
                ID = 7
            }
        }
    }
}

