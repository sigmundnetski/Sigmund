namespace bnet.protocol.game_master
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class UnregisterServerRequest : GeneratedMessageLite<UnregisterServerRequest, Builder>
    {
        private static readonly string[] _unregisterServerRequestFieldNames = new string[0];
        private static readonly uint[] _unregisterServerRequestFieldTags = new uint[0];
        private static readonly UnregisterServerRequest defaultInstance = new UnregisterServerRequest().MakeReadOnly();
        private int memoizedSerializedSize = -1;

        static UnregisterServerRequest()
        {
            object.ReferenceEquals(GameMaster.Descriptor, null);
        }

        private UnregisterServerRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(UnregisterServerRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            return (obj is UnregisterServerRequest);
        }

        public override int GetHashCode()
        {
            return base.GetType().GetHashCode();
        }

        private UnregisterServerRequest MakeReadOnly()
        {
            return this;
        }

        public static UnregisterServerRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static UnregisterServerRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static UnregisterServerRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static UnregisterServerRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static UnregisterServerRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static UnregisterServerRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static UnregisterServerRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static UnregisterServerRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static UnregisterServerRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static UnregisterServerRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
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
            string[] strArray = _unregisterServerRequestFieldNames;
        }

        public static UnregisterServerRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override UnregisterServerRequest DefaultInstanceForType
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

        protected override UnregisterServerRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<UnregisterServerRequest, UnregisterServerRequest.Builder>
        {
            private UnregisterServerRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = UnregisterServerRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(UnregisterServerRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override UnregisterServerRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override UnregisterServerRequest.Builder Clear()
            {
                this.result = UnregisterServerRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public override UnregisterServerRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new UnregisterServerRequest.Builder(this.result);
                }
                return new UnregisterServerRequest.Builder().MergeFrom(this.result);
            }

            public override UnregisterServerRequest.Builder MergeFrom(UnregisterServerRequest other)
            {
                if (other != UnregisterServerRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                }
                return this;
            }

            public override UnregisterServerRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override UnregisterServerRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is UnregisterServerRequest)
                {
                    return this.MergeFrom((UnregisterServerRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override UnregisterServerRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(UnregisterServerRequest._unregisterServerRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = UnregisterServerRequest._unregisterServerRequestFieldTags[index];
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

            private UnregisterServerRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    UnregisterServerRequest result = this.result;
                    this.result = new UnregisterServerRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public override UnregisterServerRequest DefaultInstanceForType
            {
                get
                {
                    return UnregisterServerRequest.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override UnregisterServerRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override UnregisterServerRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

