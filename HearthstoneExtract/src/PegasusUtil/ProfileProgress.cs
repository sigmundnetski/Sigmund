namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using PegasusShared;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class ProfileProgress : GeneratedMessageLite<ProfileProgress, Builder>
    {
        private static readonly string[] _profileProgressFieldNames = new string[] { "best_forge", "last_forge", "progress" };
        private static readonly uint[] _profileProgressFieldTags = new uint[] { 0x10, 0x1a, 8 };
        private int bestForge_;
        public const int BestForgeFieldNumber = 2;
        private static readonly ProfileProgress defaultInstance = new ProfileProgress().MakeReadOnly();
        private bool hasBestForge;
        private bool hasLastForge;
        private bool hasProgress;
        private Date lastForge_;
        public const int LastForgeFieldNumber = 3;
        private int memoizedSerializedSize = -1;
        private long progress_;
        public const int ProgressFieldNumber = 1;

        static ProfileProgress()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private ProfileProgress()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ProfileProgress prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ProfileProgress progress = obj as ProfileProgress;
            if (progress == null)
            {
                return false;
            }
            if ((this.hasProgress != progress.hasProgress) || (this.hasProgress && !this.progress_.Equals(progress.progress_)))
            {
                return false;
            }
            if ((this.hasBestForge != progress.hasBestForge) || (this.hasBestForge && !this.bestForge_.Equals(progress.bestForge_)))
            {
                return false;
            }
            return ((this.hasLastForge == progress.hasLastForge) && (!this.hasLastForge || this.lastForge_.Equals(progress.lastForge_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasProgress)
            {
                hashCode ^= this.progress_.GetHashCode();
            }
            if (this.hasBestForge)
            {
                hashCode ^= this.bestForge_.GetHashCode();
            }
            if (this.hasLastForge)
            {
                hashCode ^= this.lastForge_.GetHashCode();
            }
            return hashCode;
        }

        private ProfileProgress MakeReadOnly()
        {
            return this;
        }

        public static ProfileProgress ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ProfileProgress ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileProgress ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ProfileProgress ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ProfileProgress ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ProfileProgress ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ProfileProgress ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ProfileProgress ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileProgress ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileProgress ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ProfileProgress, Builder>.PrintField("progress", this.hasProgress, this.progress_, writer);
            GeneratedMessageLite<ProfileProgress, Builder>.PrintField("best_forge", this.hasBestForge, this.bestForge_, writer);
            GeneratedMessageLite<ProfileProgress, Builder>.PrintField("last_forge", this.hasLastForge, this.lastForge_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _profileProgressFieldNames;
            if (this.hasProgress)
            {
                output.WriteInt64(1, strArray[2], this.Progress);
            }
            if (this.hasBestForge)
            {
                output.WriteInt32(2, strArray[0], this.BestForge);
            }
            if (this.hasLastForge)
            {
                output.WriteMessage(3, strArray[1], this.LastForge);
            }
        }

        public int BestForge
        {
            get
            {
                return this.bestForge_;
            }
        }

        public static ProfileProgress DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ProfileProgress DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasBestForge
        {
            get
            {
                return this.hasBestForge;
            }
        }

        public bool HasLastForge
        {
            get
            {
                return this.hasLastForge;
            }
        }

        public bool HasProgress
        {
            get
            {
                return this.hasProgress;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasProgress)
                {
                    return false;
                }
                if (!this.hasBestForge)
                {
                    return false;
                }
                if (this.HasLastForge && !this.LastForge.IsInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        public Date LastForge
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.lastForge_ != null)
                {
                    goto Label_0012;
                }
                return Date.DefaultInstance;
            }
        }

        public long Progress
        {
            get
            {
                return this.progress_;
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
                    if (this.hasProgress)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(1, this.Progress);
                    }
                    if (this.hasBestForge)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.BestForge);
                    }
                    if (this.hasLastForge)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(3, this.LastForge);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ProfileProgress ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<ProfileProgress, ProfileProgress.Builder>
        {
            private ProfileProgress result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ProfileProgress.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ProfileProgress cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override ProfileProgress BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ProfileProgress.Builder Clear()
            {
                this.result = ProfileProgress.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ProfileProgress.Builder ClearBestForge()
            {
                this.PrepareBuilder();
                this.result.hasBestForge = false;
                this.result.bestForge_ = 0;
                return this;
            }

            public ProfileProgress.Builder ClearLastForge()
            {
                this.PrepareBuilder();
                this.result.hasLastForge = false;
                this.result.lastForge_ = null;
                return this;
            }

            public ProfileProgress.Builder ClearProgress()
            {
                this.PrepareBuilder();
                this.result.hasProgress = false;
                this.result.progress_ = 0L;
                return this;
            }

            public override ProfileProgress.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ProfileProgress.Builder(this.result);
                }
                return new ProfileProgress.Builder().MergeFrom(this.result);
            }

            public override ProfileProgress.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ProfileProgress.Builder MergeFrom(IMessageLite other)
            {
                if (other is ProfileProgress)
                {
                    return this.MergeFrom((ProfileProgress) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ProfileProgress.Builder MergeFrom(ProfileProgress other)
            {
                if (other != ProfileProgress.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasProgress)
                    {
                        this.Progress = other.Progress;
                    }
                    if (other.HasBestForge)
                    {
                        this.BestForge = other.BestForge;
                    }
                    if (other.HasLastForge)
                    {
                        this.MergeLastForge(other.LastForge);
                    }
                }
                return this;
            }

            public override ProfileProgress.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ProfileProgress._profileProgressFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ProfileProgress._profileProgressFieldTags[index];
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
                            this.result.hasProgress = input.ReadInt64(ref this.result.progress_);
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasBestForge = input.ReadInt32(ref this.result.bestForge_);
                            continue;
                        }
                        case 0x1a:
                        {
                            Date.Builder builder = Date.CreateBuilder();
                            if (this.result.hasLastForge)
                            {
                                builder.MergeFrom(this.LastForge);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.LastForge = builder.BuildPartial();
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

            public ProfileProgress.Builder MergeLastForge(Date value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasLastForge && (this.result.lastForge_ != Date.DefaultInstance))
                {
                    this.result.lastForge_ = Date.CreateBuilder(this.result.lastForge_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.lastForge_ = value;
                }
                this.result.hasLastForge = true;
                return this;
            }

            private ProfileProgress PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ProfileProgress result = this.result;
                    this.result = new ProfileProgress();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ProfileProgress.Builder SetBestForge(int value)
            {
                this.PrepareBuilder();
                this.result.hasBestForge = true;
                this.result.bestForge_ = value;
                return this;
            }

            public ProfileProgress.Builder SetLastForge(Date value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasLastForge = true;
                this.result.lastForge_ = value;
                return this;
            }

            public ProfileProgress.Builder SetLastForge(Date.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasLastForge = true;
                this.result.lastForge_ = builderForValue.Build();
                return this;
            }

            public ProfileProgress.Builder SetProgress(long value)
            {
                this.PrepareBuilder();
                this.result.hasProgress = true;
                this.result.progress_ = value;
                return this;
            }

            public int BestForge
            {
                get
                {
                    return this.result.BestForge;
                }
                set
                {
                    this.SetBestForge(value);
                }
            }

            public override ProfileProgress DefaultInstanceForType
            {
                get
                {
                    return ProfileProgress.DefaultInstance;
                }
            }

            public bool HasBestForge
            {
                get
                {
                    return this.result.hasBestForge;
                }
            }

            public bool HasLastForge
            {
                get
                {
                    return this.result.hasLastForge;
                }
            }

            public bool HasProgress
            {
                get
                {
                    return this.result.hasProgress;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public Date LastForge
            {
                get
                {
                    return this.result.LastForge;
                }
                set
                {
                    this.SetLastForge(value);
                }
            }

            protected override ProfileProgress MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public long Progress
            {
                get
                {
                    return this.result.Progress;
                }
                set
                {
                    this.SetProgress(value);
                }
            }

            protected override ProfileProgress.Builder ThisBuilder
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
            public enum PacketID
            {
                ID = 0xe9
            }
        }
    }
}

