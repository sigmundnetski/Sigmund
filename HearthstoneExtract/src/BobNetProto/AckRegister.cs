namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class AckRegister : GeneratedMessageLite<AckRegister, Builder>
    {
        private static readonly string[] _ackRegisterFieldNames = new string[0];
        private static readonly uint[] _ackRegisterFieldTags = new uint[0];
        private static readonly AckRegister defaultInstance = new AckRegister().MakeReadOnly();
        private int memoizedSerializedSize = -1;

        static AckRegister()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private AckRegister()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AckRegister prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            return (obj is AckRegister);
        }

        public override int GetHashCode()
        {
            return base.GetType().GetHashCode();
        }

        private AckRegister MakeReadOnly()
        {
            return this;
        }

        public static AckRegister ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AckRegister ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AckRegister ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AckRegister ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AckRegister ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AckRegister ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AckRegister ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AckRegister ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AckRegister ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AckRegister ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
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
            string[] strArray = _ackRegisterFieldNames;
        }

        public static AckRegister DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AckRegister DefaultInstanceForType
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

        protected override AckRegister ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<AckRegister, AckRegister.Builder>
        {
            private AckRegister result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AckRegister.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AckRegister cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override AckRegister BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AckRegister.Builder Clear()
            {
                this.result = AckRegister.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public override AckRegister.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AckRegister.Builder(this.result);
                }
                return new AckRegister.Builder().MergeFrom(this.result);
            }

            public override AckRegister.Builder MergeFrom(AckRegister other)
            {
                if (other != AckRegister.DefaultInstance)
                {
                    this.PrepareBuilder();
                }
                return this;
            }

            public override AckRegister.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AckRegister.Builder MergeFrom(IMessageLite other)
            {
                if (other is AckRegister)
                {
                    return this.MergeFrom((AckRegister) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AckRegister.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AckRegister._ackRegisterFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AckRegister._ackRegisterFieldTags[index];
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

            private AckRegister PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AckRegister result = this.result;
                    this.result = new AckRegister();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public override AckRegister DefaultInstanceForType
            {
                get
                {
                    return AckRegister.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override AckRegister MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override AckRegister.Builder ThisBuilder
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
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0x76
            }
        }
    }
}

