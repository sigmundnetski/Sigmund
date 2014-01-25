namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class CompleteAchieve : GeneratedMessageLite<CompleteAchieve, Builder>
    {
        private static readonly string[] _completeAchieveFieldNames = new string[] { "achieve_id" };
        private static readonly uint[] _completeAchieveFieldTags = new uint[] { 8 };
        private int achieveId_;
        public const int AchieveIdFieldNumber = 1;
        private static readonly CompleteAchieve defaultInstance = new CompleteAchieve().MakeReadOnly();
        private bool hasAchieveId;
        private int memoizedSerializedSize = -1;

        static CompleteAchieve()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private CompleteAchieve()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(CompleteAchieve prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            CompleteAchieve achieve = obj as CompleteAchieve;
            if (achieve == null)
            {
                return false;
            }
            return ((this.hasAchieveId == achieve.hasAchieveId) && (!this.hasAchieveId || this.achieveId_.Equals(achieve.achieveId_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasAchieveId)
            {
                hashCode ^= this.achieveId_.GetHashCode();
            }
            return hashCode;
        }

        private CompleteAchieve MakeReadOnly()
        {
            return this;
        }

        public static CompleteAchieve ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static CompleteAchieve ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static CompleteAchieve ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static CompleteAchieve ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static CompleteAchieve ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static CompleteAchieve ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static CompleteAchieve ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static CompleteAchieve ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static CompleteAchieve ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static CompleteAchieve ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<CompleteAchieve, Builder>.PrintField("achieve_id", this.hasAchieveId, this.achieveId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _completeAchieveFieldNames;
            if (this.hasAchieveId)
            {
                output.WriteInt32(1, strArray[0], this.AchieveId);
            }
        }

        public int AchieveId
        {
            get
            {
                return this.achieveId_;
            }
        }

        public static CompleteAchieve DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override CompleteAchieve DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasAchieveId
        {
            get
            {
                return this.hasAchieveId;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasAchieveId)
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
                    if (this.hasAchieveId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.AchieveId);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override CompleteAchieve ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<CompleteAchieve, CompleteAchieve.Builder>
        {
            private CompleteAchieve result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = CompleteAchieve.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(CompleteAchieve cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override CompleteAchieve BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override CompleteAchieve.Builder Clear()
            {
                this.result = CompleteAchieve.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public CompleteAchieve.Builder ClearAchieveId()
            {
                this.PrepareBuilder();
                this.result.hasAchieveId = false;
                this.result.achieveId_ = 0;
                return this;
            }

            public override CompleteAchieve.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new CompleteAchieve.Builder(this.result);
                }
                return new CompleteAchieve.Builder().MergeFrom(this.result);
            }

            public override CompleteAchieve.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override CompleteAchieve.Builder MergeFrom(IMessageLite other)
            {
                if (other is CompleteAchieve)
                {
                    return this.MergeFrom((CompleteAchieve) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override CompleteAchieve.Builder MergeFrom(CompleteAchieve other)
            {
                if (other != CompleteAchieve.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAchieveId)
                    {
                        this.AchieveId = other.AchieveId;
                    }
                }
                return this;
            }

            public override CompleteAchieve.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(CompleteAchieve._completeAchieveFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = CompleteAchieve._completeAchieveFieldTags[index];
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
                    this.result.hasAchieveId = input.ReadInt32(ref this.result.achieveId_);
                }
                return this;
            }

            private CompleteAchieve PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    CompleteAchieve result = this.result;
                    this.result = new CompleteAchieve();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public CompleteAchieve.Builder SetAchieveId(int value)
            {
                this.PrepareBuilder();
                this.result.hasAchieveId = true;
                this.result.achieveId_ = value;
                return this;
            }

            public int AchieveId
            {
                get
                {
                    return this.result.AchieveId;
                }
                set
                {
                    this.SetAchieveId(value);
                }
            }

            public override CompleteAchieve DefaultInstanceForType
            {
                get
                {
                    return CompleteAchieve.DefaultInstance;
                }
            }

            public bool HasAchieveId
            {
                get
                {
                    return this.result.hasAchieveId;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override CompleteAchieve MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override CompleteAchieve.Builder ThisBuilder
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
            public enum PacketID
            {
                ID = 0x114,
                System = 0
            }
        }
    }
}

