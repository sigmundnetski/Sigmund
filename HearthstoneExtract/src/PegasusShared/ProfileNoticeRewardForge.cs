namespace PegasusShared
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class ProfileNoticeRewardForge : GeneratedMessageLite<ProfileNoticeRewardForge, Builder>
    {
        private static readonly string[] _profileNoticeRewardForgeFieldNames = new string[] { "quantity" };
        private static readonly uint[] _profileNoticeRewardForgeFieldTags = new uint[] { 8 };
        private static readonly ProfileNoticeRewardForge defaultInstance = new ProfileNoticeRewardForge().MakeReadOnly();
        private bool hasQuantity;
        private int memoizedSerializedSize = -1;
        private int quantity_;
        public const int QuantityFieldNumber = 1;

        static ProfileNoticeRewardForge()
        {
            object.ReferenceEquals(PegasusSharedlite.Descriptor, null);
        }

        private ProfileNoticeRewardForge()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ProfileNoticeRewardForge prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ProfileNoticeRewardForge forge = obj as ProfileNoticeRewardForge;
            if (forge == null)
            {
                return false;
            }
            return ((this.hasQuantity == forge.hasQuantity) && (!this.hasQuantity || this.quantity_.Equals(forge.quantity_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasQuantity)
            {
                hashCode ^= this.quantity_.GetHashCode();
            }
            return hashCode;
        }

        private ProfileNoticeRewardForge MakeReadOnly()
        {
            return this;
        }

        public static ProfileNoticeRewardForge ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ProfileNoticeRewardForge ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileNoticeRewardForge ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ProfileNoticeRewardForge ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ProfileNoticeRewardForge ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ProfileNoticeRewardForge ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ProfileNoticeRewardForge ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ProfileNoticeRewardForge ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileNoticeRewardForge ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileNoticeRewardForge ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ProfileNoticeRewardForge, Builder>.PrintField("quantity", this.hasQuantity, this.quantity_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _profileNoticeRewardForgeFieldNames;
            if (this.hasQuantity)
            {
                output.WriteInt32(1, strArray[0], this.Quantity);
            }
        }

        public static ProfileNoticeRewardForge DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ProfileNoticeRewardForge DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasQuantity
        {
            get
            {
                return this.hasQuantity;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasQuantity)
                {
                    return false;
                }
                return true;
            }
        }

        public int Quantity
        {
            get
            {
                return this.quantity_;
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
                    if (this.hasQuantity)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.Quantity);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ProfileNoticeRewardForge ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<ProfileNoticeRewardForge, ProfileNoticeRewardForge.Builder>
        {
            private ProfileNoticeRewardForge result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ProfileNoticeRewardForge.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ProfileNoticeRewardForge cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override ProfileNoticeRewardForge BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ProfileNoticeRewardForge.Builder Clear()
            {
                this.result = ProfileNoticeRewardForge.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ProfileNoticeRewardForge.Builder ClearQuantity()
            {
                this.PrepareBuilder();
                this.result.hasQuantity = false;
                this.result.quantity_ = 0;
                return this;
            }

            public override ProfileNoticeRewardForge.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ProfileNoticeRewardForge.Builder(this.result);
                }
                return new ProfileNoticeRewardForge.Builder().MergeFrom(this.result);
            }

            public override ProfileNoticeRewardForge.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ProfileNoticeRewardForge.Builder MergeFrom(IMessageLite other)
            {
                if (other is ProfileNoticeRewardForge)
                {
                    return this.MergeFrom((ProfileNoticeRewardForge) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ProfileNoticeRewardForge.Builder MergeFrom(ProfileNoticeRewardForge other)
            {
                if (other != ProfileNoticeRewardForge.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasQuantity)
                    {
                        this.Quantity = other.Quantity;
                    }
                }
                return this;
            }

            public override ProfileNoticeRewardForge.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ProfileNoticeRewardForge._profileNoticeRewardForgeFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ProfileNoticeRewardForge._profileNoticeRewardForgeFieldTags[index];
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
                    this.result.hasQuantity = input.ReadInt32(ref this.result.quantity_);
                }
                return this;
            }

            private ProfileNoticeRewardForge PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ProfileNoticeRewardForge result = this.result;
                    this.result = new ProfileNoticeRewardForge();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ProfileNoticeRewardForge.Builder SetQuantity(int value)
            {
                this.PrepareBuilder();
                this.result.hasQuantity = true;
                this.result.quantity_ = value;
                return this;
            }

            public override ProfileNoticeRewardForge DefaultInstanceForType
            {
                get
                {
                    return ProfileNoticeRewardForge.DefaultInstance;
                }
            }

            public bool HasQuantity
            {
                get
                {
                    return this.result.hasQuantity;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override ProfileNoticeRewardForge MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int Quantity
            {
                get
                {
                    return this.result.Quantity;
                }
                set
                {
                    this.SetQuantity(value);
                }
            }

            protected override ProfileNoticeRewardForge.Builder ThisBuilder
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
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum NoticeID
            {
                ID = 8
            }
        }
    }
}

