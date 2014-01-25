namespace PegasusGame
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class Precast : GeneratedMessageLite<Precast, Builder>
    {
        private static readonly string[] _precastFieldNames = new string[] { "entity" };
        private static readonly uint[] _precastFieldTags = new uint[] { 8 };
        private static readonly Precast defaultInstance = new Precast().MakeReadOnly();
        private int entity_;
        public const int EntityFieldNumber = 1;
        private bool hasEntity;
        private int memoizedSerializedSize = -1;

        static Precast()
        {
            object.ReferenceEquals(PegasusGamelite.Descriptor, null);
        }

        private Precast()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(Precast prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            Precast precast = obj as Precast;
            if (precast == null)
            {
                return false;
            }
            return ((this.hasEntity == precast.hasEntity) && (!this.hasEntity || this.entity_.Equals(precast.entity_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasEntity)
            {
                hashCode ^= this.entity_.GetHashCode();
            }
            return hashCode;
        }

        private Precast MakeReadOnly()
        {
            return this;
        }

        public static Precast ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static Precast ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static Precast ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Precast ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Precast ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Precast ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Precast ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static Precast ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Precast ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Precast ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<Precast, Builder>.PrintField("entity", this.hasEntity, this.entity_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _precastFieldNames;
            if (this.hasEntity)
            {
                output.WriteInt32(1, strArray[0], this.Entity);
            }
        }

        public static Precast DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override Precast DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public int Entity
        {
            get
            {
                return this.entity_;
            }
        }

        public bool HasEntity
        {
            get
            {
                return this.hasEntity;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasEntity)
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
                    if (this.hasEntity)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.Entity);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override Precast ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<Precast, Precast.Builder>
        {
            private Precast result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = Precast.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(Precast cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override Precast BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override Precast.Builder Clear()
            {
                this.result = Precast.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public Precast.Builder ClearEntity()
            {
                this.PrepareBuilder();
                this.result.hasEntity = false;
                this.result.entity_ = 0;
                return this;
            }

            public override Precast.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new Precast.Builder(this.result);
                }
                return new Precast.Builder().MergeFrom(this.result);
            }

            public override Precast.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override Precast.Builder MergeFrom(IMessageLite other)
            {
                if (other is Precast)
                {
                    return this.MergeFrom((Precast) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override Precast.Builder MergeFrom(Precast other)
            {
                if (other != Precast.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasEntity)
                    {
                        this.Entity = other.Entity;
                    }
                }
                return this;
            }

            public override Precast.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(Precast._precastFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = Precast._precastFieldTags[index];
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
                    this.result.hasEntity = input.ReadInt32(ref this.result.entity_);
                }
                return this;
            }

            private Precast PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    Precast result = this.result;
                    this.result = new Precast();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public Precast.Builder SetEntity(int value)
            {
                this.PrepareBuilder();
                this.result.hasEntity = true;
                this.result.entity_ = value;
                return this;
            }

            public override Precast DefaultInstanceForType
            {
                get
                {
                    return Precast.DefaultInstance;
                }
            }

            public int Entity
            {
                get
                {
                    return this.result.Entity;
                }
                set
                {
                    this.SetEntity(value);
                }
            }

            public bool HasEntity
            {
                get
                {
                    return this.result.hasEntity;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override Precast MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override Precast.Builder ThisBuilder
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
                ID = 4
            }
        }
    }
}

