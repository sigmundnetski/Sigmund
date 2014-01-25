namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class SetProgress : GeneratedMessageLite<SetProgress, Builder>
    {
        private static readonly string[] _setProgressFieldNames = new string[] { "value" };
        private static readonly uint[] _setProgressFieldTags = new uint[] { 8 };
        private static readonly SetProgress defaultInstance = new SetProgress().MakeReadOnly();
        private bool hasValue;
        private int memoizedSerializedSize = -1;
        private long value_;
        public const int ValueFieldNumber = 1;

        static SetProgress()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private SetProgress()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(SetProgress prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            SetProgress progress = obj as SetProgress;
            if (progress == null)
            {
                return false;
            }
            return ((this.hasValue == progress.hasValue) && (!this.hasValue || this.value_.Equals(progress.value_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasValue)
            {
                hashCode ^= this.value_.GetHashCode();
            }
            return hashCode;
        }

        private SetProgress MakeReadOnly()
        {
            return this;
        }

        public static SetProgress ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static SetProgress ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static SetProgress ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static SetProgress ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static SetProgress ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static SetProgress ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static SetProgress ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static SetProgress ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static SetProgress ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static SetProgress ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<SetProgress, Builder>.PrintField("value", this.hasValue, this.value_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _setProgressFieldNames;
            if (this.hasValue)
            {
                output.WriteInt64(1, strArray[0], this.Value);
            }
        }

        public static SetProgress DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override SetProgress DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasValue
        {
            get
            {
                return this.hasValue;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasValue)
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
                    if (this.hasValue)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(1, this.Value);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override SetProgress ThisMessage
        {
            get
            {
                return this;
            }
        }

        public long Value
        {
            get
            {
                return this.value_;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<SetProgress, SetProgress.Builder>
        {
            private SetProgress result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = SetProgress.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(SetProgress cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override SetProgress BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override SetProgress.Builder Clear()
            {
                this.result = SetProgress.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public SetProgress.Builder ClearValue()
            {
                this.PrepareBuilder();
                this.result.hasValue = false;
                this.result.value_ = 0L;
                return this;
            }

            public override SetProgress.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new SetProgress.Builder(this.result);
                }
                return new SetProgress.Builder().MergeFrom(this.result);
            }

            public override SetProgress.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override SetProgress.Builder MergeFrom(IMessageLite other)
            {
                if (other is SetProgress)
                {
                    return this.MergeFrom((SetProgress) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override SetProgress.Builder MergeFrom(SetProgress other)
            {
                if (other != SetProgress.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasValue)
                    {
                        this.Value = other.Value;
                    }
                }
                return this;
            }

            public override SetProgress.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(SetProgress._setProgressFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = SetProgress._setProgressFieldTags[index];
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
                    this.result.hasValue = input.ReadInt64(ref this.result.value_);
                }
                return this;
            }

            private SetProgress PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    SetProgress result = this.result;
                    this.result = new SetProgress();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public SetProgress.Builder SetValue(long value)
            {
                this.PrepareBuilder();
                this.result.hasValue = true;
                this.result.value_ = value;
                return this;
            }

            public override SetProgress DefaultInstanceForType
            {
                get
                {
                    return SetProgress.DefaultInstance;
                }
            }

            public bool HasValue
            {
                get
                {
                    return this.result.hasValue;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override SetProgress MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override SetProgress.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public long Value
            {
                get
                {
                    return this.result.Value;
                }
                set
                {
                    this.SetValue(value);
                }
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 230,
                System = 0
            }
        }
    }
}

