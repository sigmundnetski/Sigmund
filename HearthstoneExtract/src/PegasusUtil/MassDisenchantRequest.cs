namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class MassDisenchantRequest : GeneratedMessageLite<MassDisenchantRequest, Builder>
    {
        private static readonly string[] _massDisenchantRequestFieldNames = new string[0];
        private static readonly uint[] _massDisenchantRequestFieldTags = new uint[0];
        private static readonly MassDisenchantRequest defaultInstance = new MassDisenchantRequest().MakeReadOnly();
        private int memoizedSerializedSize = -1;

        static MassDisenchantRequest()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private MassDisenchantRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(MassDisenchantRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            return (obj is MassDisenchantRequest);
        }

        public override int GetHashCode()
        {
            return base.GetType().GetHashCode();
        }

        private MassDisenchantRequest MakeReadOnly()
        {
            return this;
        }

        public static MassDisenchantRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static MassDisenchantRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static MassDisenchantRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static MassDisenchantRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static MassDisenchantRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static MassDisenchantRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static MassDisenchantRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static MassDisenchantRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static MassDisenchantRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static MassDisenchantRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
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
            string[] strArray = _massDisenchantRequestFieldNames;
        }

        public static MassDisenchantRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override MassDisenchantRequest DefaultInstanceForType
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

        protected override MassDisenchantRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<MassDisenchantRequest, MassDisenchantRequest.Builder>
        {
            private MassDisenchantRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = MassDisenchantRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(MassDisenchantRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override MassDisenchantRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override MassDisenchantRequest.Builder Clear()
            {
                this.result = MassDisenchantRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public override MassDisenchantRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new MassDisenchantRequest.Builder(this.result);
                }
                return new MassDisenchantRequest.Builder().MergeFrom(this.result);
            }

            public override MassDisenchantRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override MassDisenchantRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is MassDisenchantRequest)
                {
                    return this.MergeFrom((MassDisenchantRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override MassDisenchantRequest.Builder MergeFrom(MassDisenchantRequest other)
            {
                if (other != MassDisenchantRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                }
                return this;
            }

            public override MassDisenchantRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(MassDisenchantRequest._massDisenchantRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = MassDisenchantRequest._massDisenchantRequestFieldTags[index];
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

            private MassDisenchantRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    MassDisenchantRequest result = this.result;
                    this.result = new MassDisenchantRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public override MassDisenchantRequest DefaultInstanceForType
            {
                get
                {
                    return MassDisenchantRequest.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override MassDisenchantRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override MassDisenchantRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0x10c,
                System = 0
            }
        }
    }
}

