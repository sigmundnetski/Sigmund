namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class ValidateAchieve : GeneratedMessageLite<ValidateAchieve, Builder>
    {
        private static readonly string[] _validateAchieveFieldNames = new string[] { "achieve" };
        private static readonly uint[] _validateAchieveFieldTags = new uint[] { 8 };
        private int achieve_;
        public const int AchieveFieldNumber = 1;
        private static readonly ValidateAchieve defaultInstance = new ValidateAchieve().MakeReadOnly();
        private bool hasAchieve;
        private int memoizedSerializedSize = -1;

        static ValidateAchieve()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private ValidateAchieve()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ValidateAchieve prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ValidateAchieve achieve = obj as ValidateAchieve;
            if (achieve == null)
            {
                return false;
            }
            return ((this.hasAchieve == achieve.hasAchieve) && (!this.hasAchieve || this.achieve_.Equals(achieve.achieve_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasAchieve)
            {
                hashCode ^= this.achieve_.GetHashCode();
            }
            return hashCode;
        }

        private ValidateAchieve MakeReadOnly()
        {
            return this;
        }

        public static ValidateAchieve ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ValidateAchieve ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ValidateAchieve ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ValidateAchieve ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ValidateAchieve ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ValidateAchieve ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ValidateAchieve ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ValidateAchieve ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ValidateAchieve ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ValidateAchieve ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ValidateAchieve, Builder>.PrintField("achieve", this.hasAchieve, this.achieve_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _validateAchieveFieldNames;
            if (this.hasAchieve)
            {
                output.WriteInt32(1, strArray[0], this.Achieve);
            }
        }

        public int Achieve
        {
            get
            {
                return this.achieve_;
            }
        }

        public static ValidateAchieve DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ValidateAchieve DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasAchieve
        {
            get
            {
                return this.hasAchieve;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasAchieve)
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
                    if (this.hasAchieve)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.Achieve);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ValidateAchieve ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<ValidateAchieve, ValidateAchieve.Builder>
        {
            private ValidateAchieve result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ValidateAchieve.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ValidateAchieve cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override ValidateAchieve BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ValidateAchieve.Builder Clear()
            {
                this.result = ValidateAchieve.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ValidateAchieve.Builder ClearAchieve()
            {
                this.PrepareBuilder();
                this.result.hasAchieve = false;
                this.result.achieve_ = 0;
                return this;
            }

            public override ValidateAchieve.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ValidateAchieve.Builder(this.result);
                }
                return new ValidateAchieve.Builder().MergeFrom(this.result);
            }

            public override ValidateAchieve.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ValidateAchieve.Builder MergeFrom(IMessageLite other)
            {
                if (other is ValidateAchieve)
                {
                    return this.MergeFrom((ValidateAchieve) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ValidateAchieve.Builder MergeFrom(ValidateAchieve other)
            {
                if (other != ValidateAchieve.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAchieve)
                    {
                        this.Achieve = other.Achieve;
                    }
                }
                return this;
            }

            public override ValidateAchieve.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ValidateAchieve._validateAchieveFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ValidateAchieve._validateAchieveFieldTags[index];
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
                    this.result.hasAchieve = input.ReadInt32(ref this.result.achieve_);
                }
                return this;
            }

            private ValidateAchieve PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ValidateAchieve result = this.result;
                    this.result = new ValidateAchieve();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ValidateAchieve.Builder SetAchieve(int value)
            {
                this.PrepareBuilder();
                this.result.hasAchieve = true;
                this.result.achieve_ = value;
                return this;
            }

            public int Achieve
            {
                get
                {
                    return this.result.Achieve;
                }
                set
                {
                    this.SetAchieve(value);
                }
            }

            public override ValidateAchieve DefaultInstanceForType
            {
                get
                {
                    return ValidateAchieve.DefaultInstance;
                }
            }

            public bool HasAchieve
            {
                get
                {
                    return this.result.hasAchieve;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override ValidateAchieve MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override ValidateAchieve.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0x11c,
                System = 0
            }
        }
    }
}

