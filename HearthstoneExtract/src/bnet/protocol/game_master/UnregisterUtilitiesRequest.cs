namespace bnet.protocol.game_master
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class UnregisterUtilitiesRequest : GeneratedMessageLite<UnregisterUtilitiesRequest, Builder>
    {
        private static readonly string[] _unregisterUtilitiesRequestFieldNames = new string[0];
        private static readonly uint[] _unregisterUtilitiesRequestFieldTags = new uint[0];
        private static readonly UnregisterUtilitiesRequest defaultInstance = new UnregisterUtilitiesRequest().MakeReadOnly();
        private int memoizedSerializedSize = -1;

        static UnregisterUtilitiesRequest()
        {
            object.ReferenceEquals(GameMaster.Descriptor, null);
        }

        private UnregisterUtilitiesRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(UnregisterUtilitiesRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            return (obj is UnregisterUtilitiesRequest);
        }

        public override int GetHashCode()
        {
            return base.GetType().GetHashCode();
        }

        private UnregisterUtilitiesRequest MakeReadOnly()
        {
            return this;
        }

        public static UnregisterUtilitiesRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static UnregisterUtilitiesRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static UnregisterUtilitiesRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static UnregisterUtilitiesRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static UnregisterUtilitiesRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static UnregisterUtilitiesRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static UnregisterUtilitiesRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static UnregisterUtilitiesRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static UnregisterUtilitiesRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static UnregisterUtilitiesRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
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
            string[] strArray = _unregisterUtilitiesRequestFieldNames;
        }

        public static UnregisterUtilitiesRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override UnregisterUtilitiesRequest DefaultInstanceForType
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

        protected override UnregisterUtilitiesRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<UnregisterUtilitiesRequest, UnregisterUtilitiesRequest.Builder>
        {
            private UnregisterUtilitiesRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = UnregisterUtilitiesRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(UnregisterUtilitiesRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override UnregisterUtilitiesRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override UnregisterUtilitiesRequest.Builder Clear()
            {
                this.result = UnregisterUtilitiesRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public override UnregisterUtilitiesRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new UnregisterUtilitiesRequest.Builder(this.result);
                }
                return new UnregisterUtilitiesRequest.Builder().MergeFrom(this.result);
            }

            public override UnregisterUtilitiesRequest.Builder MergeFrom(UnregisterUtilitiesRequest other)
            {
                if (other != UnregisterUtilitiesRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                }
                return this;
            }

            public override UnregisterUtilitiesRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override UnregisterUtilitiesRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is UnregisterUtilitiesRequest)
                {
                    return this.MergeFrom((UnregisterUtilitiesRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override UnregisterUtilitiesRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(UnregisterUtilitiesRequest._unregisterUtilitiesRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = UnregisterUtilitiesRequest._unregisterUtilitiesRequestFieldTags[index];
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

            private UnregisterUtilitiesRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    UnregisterUtilitiesRequest result = this.result;
                    this.result = new UnregisterUtilitiesRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public override UnregisterUtilitiesRequest DefaultInstanceForType
            {
                get
                {
                    return UnregisterUtilitiesRequest.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override UnregisterUtilitiesRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override UnregisterUtilitiesRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

