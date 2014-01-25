namespace bnet.protocol.connection
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class EncryptRequest : GeneratedMessageLite<EncryptRequest, Builder>
    {
        private static readonly string[] _encryptRequestFieldNames = new string[0];
        private static readonly uint[] _encryptRequestFieldTags = new uint[0];
        private static readonly EncryptRequest defaultInstance = new EncryptRequest().MakeReadOnly();
        private int memoizedSerializedSize = -1;

        static EncryptRequest()
        {
            object.ReferenceEquals(Connect.Descriptor, null);
        }

        private EncryptRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(EncryptRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            return (obj is EncryptRequest);
        }

        public override int GetHashCode()
        {
            return base.GetType().GetHashCode();
        }

        private EncryptRequest MakeReadOnly()
        {
            return this;
        }

        public static EncryptRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static EncryptRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static EncryptRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static EncryptRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static EncryptRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static EncryptRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static EncryptRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static EncryptRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static EncryptRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static EncryptRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _encryptRequestFieldNames;
        }

        public static EncryptRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override EncryptRequest DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public override bool IsInitialized
        {
            get
            {
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
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override EncryptRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<EncryptRequest, EncryptRequest.Builder>
        {
            private EncryptRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = EncryptRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(EncryptRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override EncryptRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override EncryptRequest.Builder Clear()
            {
                this.result = EncryptRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public override EncryptRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new EncryptRequest.Builder(this.result);
                }
                return new EncryptRequest.Builder().MergeFrom(this.result);
            }

            public override EncryptRequest.Builder MergeFrom(EncryptRequest other)
            {
                if (other != EncryptRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                }
                return this;
            }

            public override EncryptRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override EncryptRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is EncryptRequest)
                {
                    return this.MergeFrom((EncryptRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override EncryptRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(EncryptRequest._encryptRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = EncryptRequest._encryptRequestFieldTags[index];
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
                    }
                    if (WireFormat.IsEndGroupTag(num))
                    {
                        return this;
                    }
                    this.ParseUnknownField(input, extensionRegistry, num, str);
                }
                return this;
            }

            private EncryptRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    EncryptRequest result = this.result;
                    this.result = new EncryptRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public override EncryptRequest DefaultInstanceForType
            {
                get
                {
                    return EncryptRequest.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override EncryptRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override EncryptRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

