namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class ValidateAchieveResponse : GeneratedMessageLite<ValidateAchieveResponse, Builder>
    {
        private static readonly string[] _validateAchieveResponseFieldNames = new string[] { "achieve" };
        private static readonly uint[] _validateAchieveResponseFieldTags = new uint[] { 8 };
        private int achieve_;
        public const int AchieveFieldNumber = 1;
        private static readonly ValidateAchieveResponse defaultInstance = new ValidateAchieveResponse().MakeReadOnly();
        private bool hasAchieve;
        private int memoizedSerializedSize = -1;

        static ValidateAchieveResponse()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private ValidateAchieveResponse()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ValidateAchieveResponse prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ValidateAchieveResponse response = obj as ValidateAchieveResponse;
            if (response == null)
            {
                return false;
            }
            return ((this.hasAchieve == response.hasAchieve) && (!this.hasAchieve || this.achieve_.Equals(response.achieve_)));
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

        private ValidateAchieveResponse MakeReadOnly()
        {
            return this;
        }

        public static ValidateAchieveResponse ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ValidateAchieveResponse ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ValidateAchieveResponse ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ValidateAchieveResponse ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ValidateAchieveResponse ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ValidateAchieveResponse ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ValidateAchieveResponse ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ValidateAchieveResponse ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ValidateAchieveResponse ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ValidateAchieveResponse ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ValidateAchieveResponse, Builder>.PrintField("achieve", this.hasAchieve, this.achieve_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _validateAchieveResponseFieldNames;
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

        public static ValidateAchieveResponse DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ValidateAchieveResponse DefaultInstanceForType
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

        protected override ValidateAchieveResponse ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<ValidateAchieveResponse, ValidateAchieveResponse.Builder>
        {
            private ValidateAchieveResponse result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ValidateAchieveResponse.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ValidateAchieveResponse cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override ValidateAchieveResponse BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ValidateAchieveResponse.Builder Clear()
            {
                this.result = ValidateAchieveResponse.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ValidateAchieveResponse.Builder ClearAchieve()
            {
                this.PrepareBuilder();
                this.result.hasAchieve = false;
                this.result.achieve_ = 0;
                return this;
            }

            public override ValidateAchieveResponse.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ValidateAchieveResponse.Builder(this.result);
                }
                return new ValidateAchieveResponse.Builder().MergeFrom(this.result);
            }

            public override ValidateAchieveResponse.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ValidateAchieveResponse.Builder MergeFrom(IMessageLite other)
            {
                if (other is ValidateAchieveResponse)
                {
                    return this.MergeFrom((ValidateAchieveResponse) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ValidateAchieveResponse.Builder MergeFrom(ValidateAchieveResponse other)
            {
                if (other != ValidateAchieveResponse.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAchieve)
                    {
                        this.Achieve = other.Achieve;
                    }
                }
                return this;
            }

            public override ValidateAchieveResponse.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ValidateAchieveResponse._validateAchieveResponseFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ValidateAchieveResponse._validateAchieveResponseFieldTags[index];
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

            private ValidateAchieveResponse PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ValidateAchieveResponse result = this.result;
                    this.result = new ValidateAchieveResponse();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ValidateAchieveResponse.Builder SetAchieve(int value)
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

            public override ValidateAchieveResponse DefaultInstanceForType
            {
                get
                {
                    return ValidateAchieveResponse.DefaultInstance;
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

            protected override ValidateAchieveResponse MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override ValidateAchieveResponse.Builder ThisBuilder
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
            public enum PacketID
            {
                ID = 0x11d
            }
        }
    }
}

