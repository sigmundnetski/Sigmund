namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class UtilAuth : GeneratedMessageLite<UtilAuth, Builder>
    {
        private static readonly string[] _utilAuthFieldNames = new string[] { "result" };
        private static readonly uint[] _utilAuthFieldTags = new uint[] { 8 };
        private static readonly UtilAuth defaultInstance = new UtilAuth().MakeReadOnly();
        private bool hasResult;
        private int memoizedSerializedSize = -1;
        private PegasusUtil.UtilAuth.Types.Result result_;
        public const int ResultFieldNumber = 1;

        static UtilAuth()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private UtilAuth()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(UtilAuth prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            UtilAuth auth = obj as UtilAuth;
            if (auth == null)
            {
                return false;
            }
            return ((this.hasResult == auth.hasResult) && (!this.hasResult || this.result_.Equals(auth.result_)));
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

        private UtilAuth MakeReadOnly()
        {
            return this;
        }

        public static UtilAuth ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static UtilAuth ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static UtilAuth ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static UtilAuth ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static UtilAuth ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static UtilAuth ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static UtilAuth ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static UtilAuth ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static UtilAuth ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static UtilAuth ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<UtilAuth, Builder>.PrintField("result", this.hasResult, this.result_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _utilAuthFieldNames;
            if (this.hasResult)
            {
                output.WriteEnum(1, strArray[0], (int) this.Result, this.Result);
            }
        }

        public static UtilAuth DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override UtilAuth DefaultInstanceForType
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

        public PegasusUtil.UtilAuth.Types.Result Result
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
                        memoizedSerializedSize += CodedOutputStream.ComputeEnumSize(1, (int) this.Result);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override UtilAuth ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<UtilAuth, UtilAuth.Builder>
        {
            private UtilAuth result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = UtilAuth.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(UtilAuth cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override UtilAuth BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override UtilAuth.Builder Clear()
            {
                this.result = UtilAuth.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public UtilAuth.Builder ClearResult()
            {
                this.PrepareBuilder();
                this.result.hasResult = false;
                this.result.result_ = PegasusUtil.UtilAuth.Types.Result.UNKNOWN;
                return this;
            }

            public override UtilAuth.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new UtilAuth.Builder(this.result);
                }
                return new UtilAuth.Builder().MergeFrom(this.result);
            }

            public override UtilAuth.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override UtilAuth.Builder MergeFrom(IMessageLite other)
            {
                if (other is UtilAuth)
                {
                    return this.MergeFrom((UtilAuth) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override UtilAuth.Builder MergeFrom(UtilAuth other)
            {
                if (other != UtilAuth.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasResult)
                    {
                        this.Result = other.Result;
                    }
                }
                return this;
            }

            public override UtilAuth.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    object obj2;
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(UtilAuth._utilAuthFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = UtilAuth._utilAuthFieldTags[index];
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
                    if (input.ReadEnum<PegasusUtil.UtilAuth.Types.Result>(ref this.result.result_, out obj2))
                    {
                        this.result.hasResult = true;
                    }
                    else if (!(obj2 is int))
                    {
                        continue;
                    }
                }
                return this;
            }

            private UtilAuth PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    UtilAuth result = this.result;
                    this.result = new UtilAuth();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public UtilAuth.Builder SetResult(PegasusUtil.UtilAuth.Types.Result value)
            {
                this.PrepareBuilder();
                this.result.hasResult = true;
                this.result.result_ = value;
                return this;
            }

            public override UtilAuth DefaultInstanceForType
            {
                get
                {
                    return UtilAuth.DefaultInstance;
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

            protected override UtilAuth MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public PegasusUtil.UtilAuth.Types.Result Result
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

            protected override UtilAuth.Builder ThisBuilder
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
                ID = 0xcc
            }

            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum Result
            {
                UNKNOWN,
                ALLOWED,
                INVALID,
                NO_SERVER
            }
        }
    }
}

