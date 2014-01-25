namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class CloseCardMarket : GeneratedMessageLite<CloseCardMarket, Builder>
    {
        private static readonly string[] _closeCardMarketFieldNames = new string[0];
        private static readonly uint[] _closeCardMarketFieldTags = new uint[0];
        private static readonly CloseCardMarket defaultInstance = new CloseCardMarket().MakeReadOnly();
        private int memoizedSerializedSize = -1;

        static CloseCardMarket()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private CloseCardMarket()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(CloseCardMarket prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            return (obj is CloseCardMarket);
        }

        public override int GetHashCode()
        {
            return base.GetType().GetHashCode();
        }

        private CloseCardMarket MakeReadOnly()
        {
            return this;
        }

        public static CloseCardMarket ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static CloseCardMarket ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static CloseCardMarket ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static CloseCardMarket ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static CloseCardMarket ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static CloseCardMarket ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static CloseCardMarket ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static CloseCardMarket ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static CloseCardMarket ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static CloseCardMarket ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
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
            string[] strArray = _closeCardMarketFieldNames;
        }

        public static CloseCardMarket DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override CloseCardMarket DefaultInstanceForType
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

        protected override CloseCardMarket ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<CloseCardMarket, CloseCardMarket.Builder>
        {
            private CloseCardMarket result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = CloseCardMarket.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(CloseCardMarket cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override CloseCardMarket BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override CloseCardMarket.Builder Clear()
            {
                this.result = CloseCardMarket.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public override CloseCardMarket.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new CloseCardMarket.Builder(this.result);
                }
                return new CloseCardMarket.Builder().MergeFrom(this.result);
            }

            public override CloseCardMarket.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override CloseCardMarket.Builder MergeFrom(IMessageLite other)
            {
                if (other is CloseCardMarket)
                {
                    return this.MergeFrom((CloseCardMarket) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override CloseCardMarket.Builder MergeFrom(CloseCardMarket other)
            {
                if (other != CloseCardMarket.DefaultInstance)
                {
                    this.PrepareBuilder();
                }
                return this;
            }

            public override CloseCardMarket.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(CloseCardMarket._closeCardMarketFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = CloseCardMarket._closeCardMarketFieldTags[index];
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

            private CloseCardMarket PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    CloseCardMarket result = this.result;
                    this.result = new CloseCardMarket();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public override CloseCardMarket DefaultInstanceForType
            {
                get
                {
                    return CloseCardMarket.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override CloseCardMarket MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override CloseCardMarket.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0x107,
                System = 0
            }
        }
    }
}

