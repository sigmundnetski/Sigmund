namespace bnet.protocol.channel
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
    public sealed class ChannelInfo : ExtendableMessageLite<ChannelInfo, Builder>
    {
        private static readonly string[] _channelInfoFieldNames = new string[] { "description", "member" };
        private static readonly uint[] _channelInfoFieldTags = new uint[] { 10, 0x12 };
        private static readonly ChannelInfo defaultInstance = new ChannelInfo().MakeReadOnly();
        private ChannelDescription description_;
        public const int DescriptionFieldNumber = 1;
        private bool hasDescription;
        private PopsicleList<Member> member_ = new PopsicleList<Member>();
        public const int MemberFieldNumber = 2;
        private int memoizedSerializedSize = -1;

        static ChannelInfo()
        {
            object.ReferenceEquals(ChannelTypes.Descriptor, null);
        }

        private ChannelInfo()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ChannelInfo prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ChannelInfo info = obj as ChannelInfo;
            if (info == null)
            {
                return false;
            }
            if ((this.hasDescription != info.hasDescription) || (this.hasDescription && !this.description_.Equals(info.description_)))
            {
                return false;
            }
            if (this.member_.Count != info.member_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.member_.Count; i++)
            {
                if (!this.member_[i].Equals(info.member_[i]))
                {
                    return false;
                }
            }
            if (!base.Equals(info))
            {
                return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasDescription)
            {
                hashCode ^= this.description_.GetHashCode();
            }
            IEnumerator<Member> enumerator = this.member_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    Member current = enumerator.Current;
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
            return (hashCode ^ base.GetHashCode());
        }

        public Member GetMember(int index)
        {
            return this.member_[index];
        }

        private ChannelInfo MakeReadOnly()
        {
            this.member_.MakeReadOnly();
            return this;
        }

        public static ChannelInfo ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ChannelInfo ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ChannelInfo ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ChannelInfo ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ChannelInfo ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ChannelInfo ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ChannelInfo ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ChannelInfo ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ChannelInfo ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ChannelInfo ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ChannelInfo, Builder>.PrintField("description", this.hasDescription, this.description_, writer);
            GeneratedMessageLite<ChannelInfo, Builder>.PrintField<Member>("member", this.member_, writer);
            base.PrintTo(writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _channelInfoFieldNames;
            ExtendableMessageLite<ChannelInfo, Builder>.ExtensionWriter writer = base.CreateExtensionWriter(this);
            if (this.hasDescription)
            {
                output.WriteMessage(1, strArray[0], this.Description);
            }
            if (this.member_.Count > 0)
            {
                output.WriteMessageArray<Member>(2, strArray[1], this.member_);
            }
            writer.WriteUntil(0x2710, output);
        }

        public static ChannelInfo DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ChannelInfo DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public ChannelDescription Description
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.description_ != null)
                {
                    goto Label_0012;
                }
                return ChannelDescription.DefaultInstance;
            }
        }

        public bool HasDescription
        {
            get
            {
                return this.hasDescription;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasDescription)
                {
                    return false;
                }
                if (!this.Description.IsInitialized)
                {
                    return false;
                }
                IEnumerator<Member> enumerator = this.MemberList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        Member current = enumerator.Current;
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
                if (!base.ExtensionsAreInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        public int MemberCount
        {
            get
            {
                return this.member_.Count;
            }
        }

        public IList<Member> MemberList
        {
            get
            {
                return this.member_;
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
                    if (this.hasDescription)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.Description);
                    }
                    IEnumerator<Member> enumerator = this.MemberList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            Member current = enumerator.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, current);
                        }
                    }
                    finally
                    {
                        if (enumerator == null)
                        {
                        }
                        enumerator.Dispose();
                    }
                    memoizedSerializedSize += base.ExtensionsSerializedSize;
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ChannelInfo ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : ExtendableBuilderLite<ChannelInfo, ChannelInfo.Builder>
        {
            private ChannelInfo result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ChannelInfo.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ChannelInfo cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public ChannelInfo.Builder AddMember(Member value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.member_.Add(value);
                return this;
            }

            public ChannelInfo.Builder AddMember(Member.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.member_.Add(builderForValue.Build());
                return this;
            }

            public ChannelInfo.Builder AddRangeMember(IEnumerable<Member> values)
            {
                this.PrepareBuilder();
                this.result.member_.Add(values);
                return this;
            }

            public override ChannelInfo BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ChannelInfo.Builder Clear()
            {
                this.result = ChannelInfo.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ChannelInfo.Builder ClearDescription()
            {
                this.PrepareBuilder();
                this.result.hasDescription = false;
                this.result.description_ = null;
                return this;
            }

            public ChannelInfo.Builder ClearMember()
            {
                this.PrepareBuilder();
                this.result.member_.Clear();
                return this;
            }

            public override ChannelInfo.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ChannelInfo.Builder(this.result);
                }
                return new ChannelInfo.Builder().MergeFrom(this.result);
            }

            public Member GetMember(int index)
            {
                return this.result.GetMember(index);
            }

            public ChannelInfo.Builder MergeDescription(ChannelDescription value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasDescription && (this.result.description_ != ChannelDescription.DefaultInstance))
                {
                    this.result.description_ = ChannelDescription.CreateBuilder(this.result.description_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.description_ = value;
                }
                this.result.hasDescription = true;
                return this;
            }

            public override ChannelInfo.Builder MergeFrom(ChannelInfo other)
            {
                if (other != ChannelInfo.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasDescription)
                    {
                        this.MergeDescription(other.Description);
                    }
                    if (other.member_.Count != 0)
                    {
                        this.result.member_.Add(other.member_);
                    }
                    base.MergeExtensionFields(other);
                }
                return this;
            }

            public override ChannelInfo.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ChannelInfo.Builder MergeFrom(IMessageLite other)
            {
                if (other is ChannelInfo)
                {
                    return this.MergeFrom((ChannelInfo) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ChannelInfo.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ChannelInfo._channelInfoFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ChannelInfo._channelInfoFieldTags[index];
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
                        {
                            ChannelDescription.Builder builder = ChannelDescription.CreateBuilder();
                            if (this.result.hasDescription)
                            {
                                builder.MergeFrom(this.Description);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.Description = builder.BuildPartial();
                            continue;
                        }
                        case 0x12:
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
                    input.ReadMessageArray<Member>(num, str, this.result.member_, Member.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private ChannelInfo PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ChannelInfo result = this.result;
                    this.result = new ChannelInfo();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ChannelInfo.Builder SetDescription(ChannelDescription value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasDescription = true;
                this.result.description_ = value;
                return this;
            }

            public ChannelInfo.Builder SetDescription(ChannelDescription.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasDescription = true;
                this.result.description_ = builderForValue.Build();
                return this;
            }

            public ChannelInfo.Builder SetMember(int index, Member value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.member_[index] = value;
                return this;
            }

            public ChannelInfo.Builder SetMember(int index, Member.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.member_[index] = builderForValue.Build();
                return this;
            }

            public override ChannelInfo DefaultInstanceForType
            {
                get
                {
                    return ChannelInfo.DefaultInstance;
                }
            }

            public ChannelDescription Description
            {
                get
                {
                    return this.result.Description;
                }
                set
                {
                    this.SetDescription(value);
                }
            }

            public bool HasDescription
            {
                get
                {
                    return this.result.hasDescription;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public int MemberCount
            {
                get
                {
                    return this.result.MemberCount;
                }
            }

            public IPopsicleList<Member> MemberList
            {
                get
                {
                    return this.PrepareBuilder().member_;
                }
            }

            protected override ChannelInfo MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override ChannelInfo.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

