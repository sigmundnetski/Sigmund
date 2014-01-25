namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class DraftError : GeneratedMessageLite<DraftError, Builder>
    {
        private static readonly string[] _draftErrorFieldNames = new string[] { "error_code" };
        private static readonly uint[] _draftErrorFieldTags = new uint[] { 8 };
        private static readonly DraftError defaultInstance = new DraftError().MakeReadOnly();
        private PegasusUtil.DraftError.Types.ErrorCode errorCode_;
        public const int ErrorCodeFieldNumber = 1;
        private bool hasErrorCode;
        private int memoizedSerializedSize = -1;

        static DraftError()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private DraftError()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DraftError prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DraftError error = obj as DraftError;
            if (error == null)
            {
                return false;
            }
            return ((this.hasErrorCode == error.hasErrorCode) && (!this.hasErrorCode || this.errorCode_.Equals(error.errorCode_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasErrorCode)
            {
                hashCode ^= this.errorCode_.GetHashCode();
            }
            return hashCode;
        }

        private DraftError MakeReadOnly()
        {
            return this;
        }

        public static DraftError ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DraftError ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DraftError ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DraftError ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DraftError ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DraftError ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DraftError ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DraftError ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DraftError ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DraftError ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DraftError, Builder>.PrintField("error_code", this.hasErrorCode, this.errorCode_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _draftErrorFieldNames;
            if (this.hasErrorCode)
            {
                output.WriteEnum(1, strArray[0], (int) this.ErrorCode, this.ErrorCode);
            }
        }

        public static DraftError DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DraftError DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public PegasusUtil.DraftError.Types.ErrorCode ErrorCode
        {
            get
            {
                return this.errorCode_;
            }
        }

        public bool HasErrorCode
        {
            get
            {
                return this.hasErrorCode;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasErrorCode)
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
                    if (this.hasErrorCode)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeEnumSize(1, (int) this.ErrorCode);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override DraftError ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<DraftError, DraftError.Builder>
        {
            private DraftError result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DraftError.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DraftError cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override DraftError BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DraftError.Builder Clear()
            {
                this.result = DraftError.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DraftError.Builder ClearErrorCode()
            {
                this.PrepareBuilder();
                this.result.hasErrorCode = false;
                this.result.errorCode_ = PegasusUtil.DraftError.Types.ErrorCode.DE_UNKNOWN;
                return this;
            }

            public override DraftError.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DraftError.Builder(this.result);
                }
                return new DraftError.Builder().MergeFrom(this.result);
            }

            public override DraftError.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DraftError.Builder MergeFrom(IMessageLite other)
            {
                if (other is DraftError)
                {
                    return this.MergeFrom((DraftError) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DraftError.Builder MergeFrom(DraftError other)
            {
                if (other != DraftError.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasErrorCode)
                    {
                        this.ErrorCode = other.ErrorCode;
                    }
                }
                return this;
            }

            public override DraftError.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    object obj2;
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DraftError._draftErrorFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DraftError._draftErrorFieldTags[index];
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
                    if (input.ReadEnum<PegasusUtil.DraftError.Types.ErrorCode>(ref this.result.errorCode_, out obj2))
                    {
                        this.result.hasErrorCode = true;
                    }
                    else if (!(obj2 is int))
                    {
                        continue;
                    }
                }
                return this;
            }

            private DraftError PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DraftError result = this.result;
                    this.result = new DraftError();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DraftError.Builder SetErrorCode(PegasusUtil.DraftError.Types.ErrorCode value)
            {
                this.PrepareBuilder();
                this.result.hasErrorCode = true;
                this.result.errorCode_ = value;
                return this;
            }

            public override DraftError DefaultInstanceForType
            {
                get
                {
                    return DraftError.DefaultInstance;
                }
            }

            public PegasusUtil.DraftError.Types.ErrorCode ErrorCode
            {
                get
                {
                    return this.result.ErrorCode;
                }
                set
                {
                    this.SetErrorCode(value);
                }
            }

            public bool HasErrorCode
            {
                get
                {
                    return this.result.hasErrorCode;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override DraftError MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override DraftError.Builder ThisBuilder
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
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum ErrorCode
            {
                DE_UNKNOWN,
                DE_NO_LICENSE,
                DE_RETIRE_FIRST,
                DE_NOT_IN_DRAFT,
                DE_BAD_DECK,
                DE_BAD_SLOT,
                DE_BAD_INDEX,
                DE_NOT_IN_DRAFT_BUT_COULD_BE,
                DE_FEATURE_DISABLED
            }

            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0xfb
            }
        }
    }
}

