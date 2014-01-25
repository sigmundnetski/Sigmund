namespace PegasusGame
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class NAckOption : GeneratedMessageLite<NAckOption, Builder>
    {
        private static readonly string[] _nAckOptionFieldNames = new string[] { "id" };
        private static readonly uint[] _nAckOptionFieldTags = new uint[] { 8 };
        private static readonly NAckOption defaultInstance = new NAckOption().MakeReadOnly();
        private bool hasId;
        private int id_;
        public const int IdFieldNumber = 1;
        private int memoizedSerializedSize = -1;

        static NAckOption()
        {
            object.ReferenceEquals(PegasusGamelite.Descriptor, null);
        }

        private NAckOption()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(NAckOption prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            NAckOption option = obj as NAckOption;
            if (option == null)
            {
                return false;
            }
            return ((this.hasId == option.hasId) && (!this.hasId || this.id_.Equals(option.id_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasId)
            {
                hashCode ^= this.id_.GetHashCode();
            }
            return hashCode;
        }

        private NAckOption MakeReadOnly()
        {
            return this;
        }

        public static NAckOption ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static NAckOption ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static NAckOption ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static NAckOption ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static NAckOption ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static NAckOption ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static NAckOption ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static NAckOption ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static NAckOption ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static NAckOption ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<NAckOption, Builder>.PrintField("id", this.hasId, this.id_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _nAckOptionFieldNames;
            if (this.hasId)
            {
                output.WriteInt32(1, strArray[0], this.Id);
            }
        }

        public static NAckOption DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override NAckOption DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasId
        {
            get
            {
                return this.hasId;
            }
        }

        public int Id
        {
            get
            {
                return this.id_;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasId)
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
                    if (this.hasId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.Id);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override NAckOption ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<NAckOption, NAckOption.Builder>
        {
            private NAckOption result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = NAckOption.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(NAckOption cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override NAckOption BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override NAckOption.Builder Clear()
            {
                this.result = NAckOption.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public NAckOption.Builder ClearId()
            {
                this.PrepareBuilder();
                this.result.hasId = false;
                this.result.id_ = 0;
                return this;
            }

            public override NAckOption.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new NAckOption.Builder(this.result);
                }
                return new NAckOption.Builder().MergeFrom(this.result);
            }

            public override NAckOption.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override NAckOption.Builder MergeFrom(IMessageLite other)
            {
                if (other is NAckOption)
                {
                    return this.MergeFrom((NAckOption) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override NAckOption.Builder MergeFrom(NAckOption other)
            {
                if (other != NAckOption.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasId)
                    {
                        this.Id = other.Id;
                    }
                }
                return this;
            }

            public override NAckOption.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(NAckOption._nAckOptionFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = NAckOption._nAckOptionFieldTags[index];
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
                    this.result.hasId = input.ReadInt32(ref this.result.id_);
                }
                return this;
            }

            private NAckOption PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    NAckOption result = this.result;
                    this.result = new NAckOption();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public NAckOption.Builder SetId(int value)
            {
                this.PrepareBuilder();
                this.result.hasId = true;
                this.result.id_ = value;
                return this;
            }

            public override NAckOption DefaultInstanceForType
            {
                get
                {
                    return NAckOption.DefaultInstance;
                }
            }

            public bool HasId
            {
                get
                {
                    return this.result.hasId;
                }
            }

            public int Id
            {
                get
                {
                    return this.result.Id;
                }
                set
                {
                    this.SetId(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override NAckOption MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override NAckOption.Builder ThisBuilder
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
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 10
            }
        }
    }
}

