namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class AchieveTest : GeneratedMessageLite<AchieveTest, Builder>
    {
        private static readonly string[] _achieveTestFieldNames = new string[] { "achieve_id" };
        private static readonly uint[] _achieveTestFieldTags = new uint[] { 8 };
        private int achieveId_;
        public const int AchieveIdFieldNumber = 1;
        private static readonly AchieveTest defaultInstance = new AchieveTest().MakeReadOnly();
        private bool hasAchieveId;
        private int memoizedSerializedSize = -1;

        static AchieveTest()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AchieveTest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AchieveTest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AchieveTest test = obj as AchieveTest;
            if (test == null)
            {
                return false;
            }
            return ((this.hasAchieveId == test.hasAchieveId) && (!this.hasAchieveId || this.achieveId_.Equals(test.achieveId_)));
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

        private AchieveTest MakeReadOnly()
        {
            return this;
        }

        public static AchieveTest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AchieveTest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AchieveTest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AchieveTest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AchieveTest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AchieveTest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AchieveTest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AchieveTest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AchieveTest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AchieveTest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AchieveTest, Builder>.PrintField("achieve_id", this.hasAchieveId, this.achieveId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _achieveTestFieldNames;
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

        public static AchieveTest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AchieveTest DefaultInstanceForType
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

        protected override AchieveTest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<AchieveTest, AchieveTest.Builder>
        {
            private AchieveTest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AchieveTest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AchieveTest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override AchieveTest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AchieveTest.Builder Clear()
            {
                this.result = AchieveTest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AchieveTest.Builder ClearAchieveId()
            {
                this.PrepareBuilder();
                this.result.hasAchieveId = false;
                this.result.achieveId_ = 0;
                return this;
            }

            public override AchieveTest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AchieveTest.Builder(this.result);
                }
                return new AchieveTest.Builder().MergeFrom(this.result);
            }

            public override AchieveTest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AchieveTest.Builder MergeFrom(IMessageLite other)
            {
                if (other is AchieveTest)
                {
                    return this.MergeFrom((AchieveTest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AchieveTest.Builder MergeFrom(AchieveTest other)
            {
                if (other != AchieveTest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAchieveId)
                    {
                        this.AchieveId = other.AchieveId;
                    }
                }
                return this;
            }

            public override AchieveTest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AchieveTest._achieveTestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AchieveTest._achieveTestFieldTags[index];
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

            private AchieveTest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AchieveTest result = this.result;
                    this.result = new AchieveTest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public AchieveTest.Builder SetAchieveId(int value)
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

            public override AchieveTest DefaultInstanceForType
            {
                get
                {
                    return AchieveTest.DefaultInstance;
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

            protected override AchieveTest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override AchieveTest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0x10a
            }
        }
    }
}

