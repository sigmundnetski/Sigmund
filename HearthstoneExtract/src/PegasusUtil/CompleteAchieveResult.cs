namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class CompleteAchieveResult : GeneratedMessageLite<CompleteAchieveResult, Builder>
    {
        private static readonly string[] _completeAchieveResultFieldNames = new string[] { "result" };
        private static readonly uint[] _completeAchieveResultFieldTags = new uint[] { 8 };
        private static readonly CompleteAchieveResult defaultInstance = new CompleteAchieveResult().MakeReadOnly();
        private bool hasResult;
        private int memoizedSerializedSize = -1;
        private int result_;
        public const int ResultFieldNumber = 1;

        static CompleteAchieveResult()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private CompleteAchieveResult()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(CompleteAchieveResult prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            CompleteAchieveResult result = obj as CompleteAchieveResult;
            if (result == null)
            {
                return false;
            }
            return ((this.hasResult == result.hasResult) && (!this.hasResult || this.result_.Equals(result.result_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasResult)
            {
                hashCode ^= this.result_.GetHashCode();
            }
            return hashCode;
        }

        private CompleteAchieveResult MakeReadOnly()
        {
            return this;
        }

        public static CompleteAchieveResult ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static CompleteAchieveResult ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static CompleteAchieveResult ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static CompleteAchieveResult ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static CompleteAchieveResult ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static CompleteAchieveResult ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static CompleteAchieveResult ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static CompleteAchieveResult ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static CompleteAchieveResult ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static CompleteAchieveResult ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<CompleteAchieveResult, Builder>.PrintField("result", this.hasResult, this.result_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _completeAchieveResultFieldNames;
            if (this.hasResult)
            {
                output.WriteInt32(1, strArray[0], this.Result);
            }
        }

        public static CompleteAchieveResult DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override CompleteAchieveResult DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasResult
        {
            get
            {
                return this.hasResult;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasResult)
                {
                    return false;
                }
                return true;
            }
        }

        public int Result
        {
            get
            {
                return this.result_;
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
                    if (this.hasResult)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.Result);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override CompleteAchieveResult ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<CompleteAchieveResult, CompleteAchieveResult.Builder>
        {
            private CompleteAchieveResult result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = CompleteAchieveResult.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(CompleteAchieveResult cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override CompleteAchieveResult BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override CompleteAchieveResult.Builder Clear()
            {
                this.result = CompleteAchieveResult.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public CompleteAchieveResult.Builder ClearResult()
            {
                this.PrepareBuilder();
                this.result.hasResult = false;
                this.result.result_ = 0;
                return this;
            }

            public override CompleteAchieveResult.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new CompleteAchieveResult.Builder(this.result);
                }
                return new CompleteAchieveResult.Builder().MergeFrom(this.result);
            }

            public override CompleteAchieveResult.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override CompleteAchieveResult.Builder MergeFrom(IMessageLite other)
            {
                if (other is CompleteAchieveResult)
                {
                    return this.MergeFrom((CompleteAchieveResult) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override CompleteAchieveResult.Builder MergeFrom(CompleteAchieveResult other)
            {
                if (other != CompleteAchieveResult.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasResult)
                    {
                        this.Result = other.Result;
                    }
                }
                return this;
            }

            public override CompleteAchieveResult.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(CompleteAchieveResult._completeAchieveResultFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = CompleteAchieveResult._completeAchieveResultFieldTags[index];
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
                    this.result.hasResult = input.ReadInt32(ref this.result.result_);
                }
                return this;
            }

            private CompleteAchieveResult PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    CompleteAchieveResult other = this.result;
                    this.result = new CompleteAchieveResult();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(other);
                }
                return this.result;
            }

            public CompleteAchieveResult.Builder SetResult(int value)
            {
                this.PrepareBuilder();
                this.result.hasResult = true;
                this.result.result_ = value;
                return this;
            }

            public override CompleteAchieveResult DefaultInstanceForType
            {
                get
                {
                    return CompleteAchieveResult.DefaultInstance;
                }
            }

            public bool HasResult
            {
                get
                {
                    return this.result.hasResult;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override CompleteAchieveResult MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int Result
            {
                get
                {
                    return this.result.Result;
                }
                set
                {
                    this.SetResult(value);
                }
            }

            protected override CompleteAchieveResult.Builder ThisBuilder
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
                ID = 0x115
            }
        }
    }
}

