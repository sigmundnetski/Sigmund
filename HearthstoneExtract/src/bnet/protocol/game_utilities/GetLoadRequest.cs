namespace bnet.protocol.game_utilities
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class GetLoadRequest : GeneratedMessageLite<GetLoadRequest, Builder>
    {
        private static readonly string[] _getLoadRequestFieldNames = new string[0];
        private static readonly uint[] _getLoadRequestFieldTags = new uint[0];
        private static readonly GetLoadRequest defaultInstance = new GetLoadRequest().MakeReadOnly();
        private int memoizedSerializedSize = -1;

        static GetLoadRequest()
        {
            object.ReferenceEquals(GameUtils.Descriptor, null);
        }

        private GetLoadRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GetLoadRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            return (obj is GetLoadRequest);
        }

        public override int GetHashCode()
        {
            return base.GetType().GetHashCode();
        }

        private GetLoadRequest MakeReadOnly()
        {
            return this;
        }

        public static GetLoadRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GetLoadRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetLoadRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GetLoadRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GetLoadRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GetLoadRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GetLoadRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GetLoadRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetLoadRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetLoadRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
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
            string[] strArray = _getLoadRequestFieldNames;
        }

        public static GetLoadRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GetLoadRequest DefaultInstanceForType
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

        protected override GetLoadRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<GetLoadRequest, GetLoadRequest.Builder>
        {
            private GetLoadRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GetLoadRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GetLoadRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override GetLoadRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GetLoadRequest.Builder Clear()
            {
                this.result = GetLoadRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public override GetLoadRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GetLoadRequest.Builder(this.result);
                }
                return new GetLoadRequest.Builder().MergeFrom(this.result);
            }

            public override GetLoadRequest.Builder MergeFrom(GetLoadRequest other)
            {
                if (other != GetLoadRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                }
                return this;
            }

            public override GetLoadRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GetLoadRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is GetLoadRequest)
                {
                    return this.MergeFrom((GetLoadRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GetLoadRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GetLoadRequest._getLoadRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GetLoadRequest._getLoadRequestFieldTags[index];
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

            private GetLoadRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GetLoadRequest result = this.result;
                    this.result = new GetLoadRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public override GetLoadRequest DefaultInstanceForType
            {
                get
                {
                    return GetLoadRequest.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override GetLoadRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override GetLoadRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

