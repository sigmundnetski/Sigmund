namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class Load : GeneratedMessageLite<Load, Builder>
    {
        private static readonly string[] _loadFieldNames = new string[] { "available" };
        private static readonly uint[] _loadFieldTags = new uint[] { 8 };
        private int available_;
        public const int AvailableFieldNumber = 1;
        private static readonly Load defaultInstance = new Load().MakeReadOnly();
        private bool hasAvailable;
        private int memoizedSerializedSize = -1;

        static Load()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private Load()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(Load prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            Load load = obj as Load;
            if (load == null)
            {
                return false;
            }
            return ((this.hasAvailable == load.hasAvailable) && (!this.hasAvailable || this.available_.Equals(load.available_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasAvailable)
            {
                hashCode ^= this.available_.GetHashCode();
            }
            return hashCode;
        }

        private Load MakeReadOnly()
        {
            return this;
        }

        public static Load ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static Load ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static Load ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Load ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Load ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Load ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Load ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static Load ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Load ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Load ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<Load, Builder>.PrintField("available", this.hasAvailable, this.available_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _loadFieldNames;
            if (this.hasAvailable)
            {
                output.WriteInt32(1, strArray[0], this.Available);
            }
        }

        public int Available
        {
            get
            {
                return this.available_;
            }
        }

        public static Load DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override Load DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasAvailable
        {
            get
            {
                return this.hasAvailable;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasAvailable)
                {
                    return false;
                }
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
                    if (this.hasAvailable)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.Available);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override Load ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<Load, Load.Builder>
        {
            private Load result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = Load.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(Load cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override Load BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override Load.Builder Clear()
            {
                this.result = Load.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public Load.Builder ClearAvailable()
            {
                this.PrepareBuilder();
                this.result.hasAvailable = false;
                this.result.available_ = 0;
                return this;
            }

            public override Load.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new Load.Builder(this.result);
                }
                return new Load.Builder().MergeFrom(this.result);
            }

            public override Load.Builder MergeFrom(Load other)
            {
                if (other != Load.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAvailable)
                    {
                        this.Available = other.Available;
                    }
                }
                return this;
            }

            public override Load.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override Load.Builder MergeFrom(IMessageLite other)
            {
                if (other is Load)
                {
                    return this.MergeFrom((Load) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override Load.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(Load._loadFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = Load._loadFieldTags[index];
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

                        case 8:
                            break;

                        default:
                        {
                            if (WireFormat.IsEndGroupTag(num))
                            {
                                return this;
                            }
                            this.ParseUnknownField(input, extensionRegistry, num, str);
                            continue;
                        }
                    }
                    this.result.hasAvailable = input.ReadInt32(ref this.result.available_);
                }
                return this;
            }

            private Load PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    Load result = this.result;
                    this.result = new Load();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public Load.Builder SetAvailable(int value)
            {
                this.PrepareBuilder();
                this.result.hasAvailable = true;
                this.result.available_ = value;
                return this;
            }

            public int Available
            {
                get
                {
                    return this.result.Available;
                }
                set
                {
                    this.SetAvailable(value);
                }
            }

            public override Load DefaultInstanceForType
            {
                get
                {
                    return Load.DefaultInstance;
                }
            }

            public bool HasAvailable
            {
                get
                {
                    return this.result.hasAvailable;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override Load MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override Load.Builder ThisBuilder
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
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0x7a
            }
        }
    }
}

