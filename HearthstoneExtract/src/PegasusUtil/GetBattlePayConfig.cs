namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class GetBattlePayConfig : GeneratedMessageLite<GetBattlePayConfig, Builder>
    {
        private static readonly string[] _getBattlePayConfigFieldNames = new string[0];
        private static readonly uint[] _getBattlePayConfigFieldTags = new uint[0];
        private static readonly GetBattlePayConfig defaultInstance = new GetBattlePayConfig().MakeReadOnly();
        private int memoizedSerializedSize = -1;

        static GetBattlePayConfig()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private GetBattlePayConfig()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GetBattlePayConfig prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            return (obj is GetBattlePayConfig);
        }

        public override int GetHashCode()
        {
            return base.GetType().GetHashCode();
        }

        private GetBattlePayConfig MakeReadOnly()
        {
            return this;
        }

        public static GetBattlePayConfig ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GetBattlePayConfig ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetBattlePayConfig ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GetBattlePayConfig ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GetBattlePayConfig ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GetBattlePayConfig ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GetBattlePayConfig ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GetBattlePayConfig ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetBattlePayConfig ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetBattlePayConfig ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
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
            string[] strArray = _getBattlePayConfigFieldNames;
        }

        public static GetBattlePayConfig DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GetBattlePayConfig DefaultInstanceForType
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

        protected override GetBattlePayConfig ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<GetBattlePayConfig, GetBattlePayConfig.Builder>
        {
            private GetBattlePayConfig result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GetBattlePayConfig.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GetBattlePayConfig cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override GetBattlePayConfig BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GetBattlePayConfig.Builder Clear()
            {
                this.result = GetBattlePayConfig.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public override GetBattlePayConfig.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GetBattlePayConfig.Builder(this.result);
                }
                return new GetBattlePayConfig.Builder().MergeFrom(this.result);
            }

            public override GetBattlePayConfig.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GetBattlePayConfig.Builder MergeFrom(IMessageLite other)
            {
                if (other is GetBattlePayConfig)
                {
                    return this.MergeFrom((GetBattlePayConfig) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GetBattlePayConfig.Builder MergeFrom(GetBattlePayConfig other)
            {
                if (other != GetBattlePayConfig.DefaultInstance)
                {
                    this.PrepareBuilder();
                }
                return this;
            }

            public override GetBattlePayConfig.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GetBattlePayConfig._getBattlePayConfigFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GetBattlePayConfig._getBattlePayConfigFieldTags[index];
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

            private GetBattlePayConfig PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GetBattlePayConfig result = this.result;
                    this.result = new GetBattlePayConfig();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public override GetBattlePayConfig DefaultInstanceForType
            {
                get
                {
                    return GetBattlePayConfig.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override GetBattlePayConfig MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override GetBattlePayConfig.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0xed,
                System = 1
            }
        }
    }
}

