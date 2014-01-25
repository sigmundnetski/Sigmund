namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class GetAchieves : GeneratedMessageLite<GetAchieves, Builder>
    {
        private static readonly string[] _getAchievesFieldNames = new string[] { "only_active" };
        private static readonly uint[] _getAchievesFieldTags = new uint[] { 8 };
        private static readonly GetAchieves defaultInstance = new GetAchieves().MakeReadOnly();
        private bool hasOnlyActive;
        private int memoizedSerializedSize = -1;
        private bool onlyActive_;
        public const int OnlyActiveFieldNumber = 1;

        static GetAchieves()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private GetAchieves()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GetAchieves prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GetAchieves achieves = obj as GetAchieves;
            if (achieves == null)
            {
                return false;
            }
            return ((this.hasOnlyActive == achieves.hasOnlyActive) && (!this.hasOnlyActive || this.onlyActive_.Equals(achieves.onlyActive_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasOnlyActive)
            {
                hashCode ^= this.onlyActive_.GetHashCode();
            }
            return hashCode;
        }

        private GetAchieves MakeReadOnly()
        {
            return this;
        }

        public static GetAchieves ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GetAchieves ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetAchieves ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GetAchieves ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GetAchieves ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GetAchieves ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GetAchieves ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GetAchieves ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetAchieves ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetAchieves ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GetAchieves, Builder>.PrintField("only_active", this.hasOnlyActive, this.onlyActive_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _getAchievesFieldNames;
            if (this.hasOnlyActive)
            {
                output.WriteBool(1, strArray[0], this.OnlyActive);
            }
        }

        public static GetAchieves DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GetAchieves DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasOnlyActive
        {
            get
            {
                return this.hasOnlyActive;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                return true;
            }
        }

        public bool OnlyActive
        {
            get
            {
                return this.onlyActive_;
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
                    if (this.hasOnlyActive)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(1, this.OnlyActive);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override GetAchieves ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<GetAchieves, GetAchieves.Builder>
        {
            private GetAchieves result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GetAchieves.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GetAchieves cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override GetAchieves BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GetAchieves.Builder Clear()
            {
                this.result = GetAchieves.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GetAchieves.Builder ClearOnlyActive()
            {
                this.PrepareBuilder();
                this.result.hasOnlyActive = false;
                this.result.onlyActive_ = false;
                return this;
            }

            public override GetAchieves.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GetAchieves.Builder(this.result);
                }
                return new GetAchieves.Builder().MergeFrom(this.result);
            }

            public override GetAchieves.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GetAchieves.Builder MergeFrom(IMessageLite other)
            {
                if (other is GetAchieves)
                {
                    return this.MergeFrom((GetAchieves) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GetAchieves.Builder MergeFrom(GetAchieves other)
            {
                if (other != GetAchieves.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasOnlyActive)
                    {
                        this.OnlyActive = other.OnlyActive;
                    }
                }
                return this;
            }

            public override GetAchieves.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GetAchieves._getAchievesFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GetAchieves._getAchievesFieldTags[index];
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
                    this.result.hasOnlyActive = input.ReadBool(ref this.result.onlyActive_);
                }
                return this;
            }

            private GetAchieves PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GetAchieves result = this.result;
                    this.result = new GetAchieves();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public GetAchieves.Builder SetOnlyActive(bool value)
            {
                this.PrepareBuilder();
                this.result.hasOnlyActive = true;
                this.result.onlyActive_ = value;
                return this;
            }

            public override GetAchieves DefaultInstanceForType
            {
                get
                {
                    return GetAchieves.DefaultInstance;
                }
            }

            public bool HasOnlyActive
            {
                get
                {
                    return this.result.hasOnlyActive;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override GetAchieves MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public bool OnlyActive
            {
                get
                {
                    return this.result.OnlyActive;
                }
                set
                {
                    this.SetOnlyActive(value);
                }
            }

            protected override GetAchieves.Builder ThisBuilder
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
                ID = 0xfd,
                System = 0
            }
        }
    }
}

