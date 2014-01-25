namespace bnet.protocol
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class NO_RESPONSE : GeneratedMessageLite<NO_RESPONSE, Builder>
    {
        private static readonly string[] _nORESPONSEFieldNames = new string[0];
        private static readonly uint[] _nORESPONSEFieldTags = new uint[0];
        private static readonly NO_RESPONSE defaultInstance = new NO_RESPONSE().MakeReadOnly();
        private int memoizedSerializedSize = -1;

        static NO_RESPONSE()
        {
            object.ReferenceEquals(Rpc.Descriptor, null);
        }

        private NO_RESPONSE()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(NO_RESPONSE prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            return (obj is NO_RESPONSE);
        }

        public override int GetHashCode()
        {
            return base.GetType().GetHashCode();
        }

        private NO_RESPONSE MakeReadOnly()
        {
            return this;
        }

        public static NO_RESPONSE ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static NO_RESPONSE ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static NO_RESPONSE ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static NO_RESPONSE ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static NO_RESPONSE ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static NO_RESPONSE ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static NO_RESPONSE ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static NO_RESPONSE ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static NO_RESPONSE ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static NO_RESPONSE ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
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
            string[] strArray = _nORESPONSEFieldNames;
        }

        public static NO_RESPONSE DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override NO_RESPONSE DefaultInstanceForType
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

        protected override NO_RESPONSE ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<NO_RESPONSE, NO_RESPONSE.Builder>
        {
            private NO_RESPONSE result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = NO_RESPONSE.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(NO_RESPONSE cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override NO_RESPONSE BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override NO_RESPONSE.Builder Clear()
            {
                this.result = NO_RESPONSE.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public override NO_RESPONSE.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new NO_RESPONSE.Builder(this.result);
                }
                return new NO_RESPONSE.Builder().MergeFrom(this.result);
            }

            public override NO_RESPONSE.Builder MergeFrom(NO_RESPONSE other)
            {
                if (other != NO_RESPONSE.DefaultInstance)
                {
                    this.PrepareBuilder();
                }
                return this;
            }

            public override NO_RESPONSE.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override NO_RESPONSE.Builder MergeFrom(IMessageLite other)
            {
                if (other is NO_RESPONSE)
                {
                    return this.MergeFrom((NO_RESPONSE) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override NO_RESPONSE.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(NO_RESPONSE._nORESPONSEFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = NO_RESPONSE._nORESPONSEFieldTags[index];
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

            private NO_RESPONSE PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    NO_RESPONSE result = this.result;
                    this.result = new NO_RESPONSE();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public override NO_RESPONSE DefaultInstanceForType
            {
                get
                {
                    return NO_RESPONSE.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override NO_RESPONSE MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override NO_RESPONSE.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

