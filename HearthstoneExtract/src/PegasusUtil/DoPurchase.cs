namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class DoPurchase : GeneratedMessageLite<DoPurchase, Builder>
    {
        private static readonly string[] _doPurchaseFieldNames = new string[0];
        private static readonly uint[] _doPurchaseFieldTags = new uint[0];
        private static readonly DoPurchase defaultInstance = new DoPurchase().MakeReadOnly();
        private int memoizedSerializedSize = -1;

        static DoPurchase()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private DoPurchase()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DoPurchase prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            return (obj is DoPurchase);
        }

        public override int GetHashCode()
        {
            return base.GetType().GetHashCode();
        }

        private DoPurchase MakeReadOnly()
        {
            return this;
        }

        public static DoPurchase ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DoPurchase ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DoPurchase ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DoPurchase ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DoPurchase ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DoPurchase ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DoPurchase ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DoPurchase ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DoPurchase ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DoPurchase ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
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
            string[] strArray = _doPurchaseFieldNames;
        }

        public static DoPurchase DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DoPurchase DefaultInstanceForType
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

        protected override DoPurchase ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<DoPurchase, DoPurchase.Builder>
        {
            private DoPurchase result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DoPurchase.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DoPurchase cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override DoPurchase BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DoPurchase.Builder Clear()
            {
                this.result = DoPurchase.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public override DoPurchase.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DoPurchase.Builder(this.result);
                }
                return new DoPurchase.Builder().MergeFrom(this.result);
            }

            public override DoPurchase.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DoPurchase.Builder MergeFrom(IMessageLite other)
            {
                if (other is DoPurchase)
                {
                    return this.MergeFrom((DoPurchase) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DoPurchase.Builder MergeFrom(DoPurchase other)
            {
                if (other != DoPurchase.DefaultInstance)
                {
                    this.PrepareBuilder();
                }
                return this;
            }

            public override DoPurchase.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DoPurchase._doPurchaseFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DoPurchase._doPurchaseFieldTags[index];
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

            private DoPurchase PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DoPurchase result = this.result;
                    this.result = new DoPurchase();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public override DoPurchase DefaultInstanceForType
            {
                get
                {
                    return DoPurchase.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override DoPurchase MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override DoPurchase.Builder ThisBuilder
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
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0x111,
                System = 1
            }
        }
    }
}

