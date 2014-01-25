namespace bnet.protocol.authentication
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class GenerateSSOTokenRequest : GeneratedMessageLite<GenerateSSOTokenRequest, Builder>
    {
        private static readonly string[] _generateSSOTokenRequestFieldNames = new string[] { "program" };
        private static readonly uint[] _generateSSOTokenRequestFieldTags = new uint[] { 13 };
        private static readonly GenerateSSOTokenRequest defaultInstance = new GenerateSSOTokenRequest().MakeReadOnly();
        private bool hasProgram;
        private int memoizedSerializedSize = -1;
        private uint program_;
        public const int ProgramFieldNumber = 1;

        static GenerateSSOTokenRequest()
        {
            object.ReferenceEquals(AuthenticationService.Descriptor, null);
        }

        private GenerateSSOTokenRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GenerateSSOTokenRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GenerateSSOTokenRequest request = obj as GenerateSSOTokenRequest;
            if (request == null)
            {
                return false;
            }
            return ((this.hasProgram == request.hasProgram) && (!this.hasProgram || this.program_.Equals(request.program_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasProgram)
            {
                hashCode ^= this.program_.GetHashCode();
            }
            return hashCode;
        }

        private GenerateSSOTokenRequest MakeReadOnly()
        {
            return this;
        }

        public static GenerateSSOTokenRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GenerateSSOTokenRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GenerateSSOTokenRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GenerateSSOTokenRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GenerateSSOTokenRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GenerateSSOTokenRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GenerateSSOTokenRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GenerateSSOTokenRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GenerateSSOTokenRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GenerateSSOTokenRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GenerateSSOTokenRequest, Builder>.PrintField("program", this.hasProgram, this.program_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _generateSSOTokenRequestFieldNames;
            if (this.hasProgram)
            {
                output.WriteFixed32(1, strArray[0], this.Program);
            }
        }

        public static GenerateSSOTokenRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GenerateSSOTokenRequest DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasProgram
        {
            get
            {
                return this.hasProgram;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                return true;
            }
        }

        [CLSCompliant(false)]
        public uint Program
        {
            get
            {
                return this.program_;
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
                    if (this.hasProgram)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed32Size(1, this.Program);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override GenerateSSOTokenRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<GenerateSSOTokenRequest, GenerateSSOTokenRequest.Builder>
        {
            private GenerateSSOTokenRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GenerateSSOTokenRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GenerateSSOTokenRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override GenerateSSOTokenRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GenerateSSOTokenRequest.Builder Clear()
            {
                this.result = GenerateSSOTokenRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GenerateSSOTokenRequest.Builder ClearProgram()
            {
                this.PrepareBuilder();
                this.result.hasProgram = false;
                this.result.program_ = 0;
                return this;
            }

            public override GenerateSSOTokenRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GenerateSSOTokenRequest.Builder(this.result);
                }
                return new GenerateSSOTokenRequest.Builder().MergeFrom(this.result);
            }

            public override GenerateSSOTokenRequest.Builder MergeFrom(GenerateSSOTokenRequest other)
            {
                if (other != GenerateSSOTokenRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasProgram)
                    {
                        this.Program = other.Program;
                    }
                }
                return this;
            }

            public override GenerateSSOTokenRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GenerateSSOTokenRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is GenerateSSOTokenRequest)
                {
                    return this.MergeFrom((GenerateSSOTokenRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GenerateSSOTokenRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GenerateSSOTokenRequest._generateSSOTokenRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GenerateSSOTokenRequest._generateSSOTokenRequestFieldTags[index];
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

                        case 13:
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
                    this.result.hasProgram = input.ReadFixed32(ref this.result.program_);
                }
                return this;
            }

            private GenerateSSOTokenRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GenerateSSOTokenRequest result = this.result;
                    this.result = new GenerateSSOTokenRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public GenerateSSOTokenRequest.Builder SetProgram(uint value)
            {
                this.PrepareBuilder();
                this.result.hasProgram = true;
                this.result.program_ = value;
                return this;
            }

            public override GenerateSSOTokenRequest DefaultInstanceForType
            {
                get
                {
                    return GenerateSSOTokenRequest.DefaultInstance;
                }
            }

            public bool HasProgram
            {
                get
                {
                    return this.result.hasProgram;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override GenerateSSOTokenRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            [CLSCompliant(false)]
            public uint Program
            {
                get
                {
                    return this.result.Program;
                }
                set
                {
                    this.SetProgram(value);
                }
            }

            protected override GenerateSSOTokenRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

