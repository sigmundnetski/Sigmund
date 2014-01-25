namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class ProfileNotices : GeneratedMessageLite<ProfileNotices, Builder>
    {
        private static readonly string[] _profileNoticesFieldNames = new string[] { "list" };
        private static readonly uint[] _profileNoticesFieldTags = new uint[] { 10 };
        private static readonly ProfileNotices defaultInstance = new ProfileNotices().MakeReadOnly();
        private PopsicleList<ProfileNotice> list_ = new PopsicleList<ProfileNotice>();
        public const int ListFieldNumber = 1;
        private int memoizedSerializedSize = -1;

        static ProfileNotices()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private ProfileNotices()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ProfileNotices prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ProfileNotices notices = obj as ProfileNotices;
            if (notices == null)
            {
                return false;
            }
            if (this.list_.Count != notices.list_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.list_.Count; i++)
            {
                if (!this.list_[i].Equals(notices.list_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<ProfileNotice> enumerator = this.list_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    ProfileNotice current = enumerator.Current;
                    hashCode ^= current.GetHashCode();
                }
            }
            finally
            {
                if (enumerator == null)
                {
                }
                enumerator.Dispose();
            }
            return hashCode;
        }

        public ProfileNotice GetList(int index)
        {
            return this.list_[index];
        }

        private ProfileNotices MakeReadOnly()
        {
            this.list_.MakeReadOnly();
            return this;
        }

        public static ProfileNotices ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ProfileNotices ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileNotices ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ProfileNotices ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ProfileNotices ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ProfileNotices ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ProfileNotices ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ProfileNotices ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileNotices ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ProfileNotices ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ProfileNotices, Builder>.PrintField<ProfileNotice>("list", this.list_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _profileNoticesFieldNames;
            if (this.list_.Count > 0)
            {
                output.WriteMessageArray<ProfileNotice>(1, strArray[0], this.list_);
            }
        }

        public static ProfileNotices DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ProfileNotices DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                IEnumerator<ProfileNotice> enumerator = this.ListList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        ProfileNotice current = enumerator.Current;
                        if (!current.IsInitialized)
                        {
                            return false;
                        }
                    }
                }
                finally
                {
                    if (enumerator == null)
                    {
                    }
                    enumerator.Dispose();
                }
                return true;
            }
        }

        public int ListCount
        {
            get
            {
                return this.list_.Count;
            }
        }

        public IList<ProfileNotice> ListList
        {
            get
            {
                return this.list_;
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
                    IEnumerator<ProfileNotice> enumerator = this.ListList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            ProfileNotice current = enumerator.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, current);
                        }
                    }
                    finally
                    {
                        if (enumerator == null)
                        {
                        }
                        enumerator.Dispose();
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ProfileNotices ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<ProfileNotices, ProfileNotices.Builder>
        {
            private ProfileNotices result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ProfileNotices.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ProfileNotices cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public ProfileNotices.Builder AddList(ProfileNotice value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.list_.Add(value);
                return this;
            }

            public ProfileNotices.Builder AddList(ProfileNotice.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.list_.Add(builderForValue.Build());
                return this;
            }

            public ProfileNotices.Builder AddRangeList(IEnumerable<ProfileNotice> values)
            {
                this.PrepareBuilder();
                this.result.list_.Add(values);
                return this;
            }

            public override ProfileNotices BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ProfileNotices.Builder Clear()
            {
                this.result = ProfileNotices.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ProfileNotices.Builder ClearList()
            {
                this.PrepareBuilder();
                this.result.list_.Clear();
                return this;
            }

            public override ProfileNotices.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ProfileNotices.Builder(this.result);
                }
                return new ProfileNotices.Builder().MergeFrom(this.result);
            }

            public ProfileNotice GetList(int index)
            {
                return this.result.GetList(index);
            }

            public override ProfileNotices.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ProfileNotices.Builder MergeFrom(IMessageLite other)
            {
                if (other is ProfileNotices)
                {
                    return this.MergeFrom((ProfileNotices) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ProfileNotices.Builder MergeFrom(ProfileNotices other)
            {
                if (other != ProfileNotices.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.list_.Count != 0)
                    {
                        this.result.list_.Add(other.list_);
                    }
                }
                return this;
            }

            public override ProfileNotices.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ProfileNotices._profileNoticesFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ProfileNotices._profileNoticesFieldTags[index];
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

                        case 10:
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
                    input.ReadMessageArray<ProfileNotice>(num, str, this.result.list_, ProfileNotice.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private ProfileNotices PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ProfileNotices result = this.result;
                    this.result = new ProfileNotices();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ProfileNotices.Builder SetList(int index, ProfileNotice value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.list_[index] = value;
                return this;
            }

            public ProfileNotices.Builder SetList(int index, ProfileNotice.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.list_[index] = builderForValue.Build();
                return this;
            }

            public override ProfileNotices DefaultInstanceForType
            {
                get
                {
                    return ProfileNotices.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public int ListCount
            {
                get
                {
                    return this.result.ListCount;
                }
            }

            public IPopsicleList<ProfileNotice> ListList
            {
                get
                {
                    return this.PrepareBuilder().list_;
                }
            }

            protected override ProfileNotices MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override ProfileNotices.Builder ThisBuilder
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
            public enum PacketID
            {
                ID = 0xd4
            }
        }
    }
}

