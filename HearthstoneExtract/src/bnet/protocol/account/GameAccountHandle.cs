namespace bnet.protocol.account
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class GameAccountHandle : GeneratedMessageLite<GameAccountHandle, Builder>
    {
        private static readonly string[] _gameAccountHandleFieldNames = new string[] { "id", "program", "region" };
        private static readonly uint[] _gameAccountHandleFieldTags = new uint[] { 13, 0x15, 0x18 };
        private static readonly GameAccountHandle defaultInstance = new GameAccountHandle().MakeReadOnly();
        private bool hasId;
        private bool hasProgram;
        private bool hasRegion;
        private uint id_;
        public const int IdFieldNumber = 1;
        private int memoizedSerializedSize = -1;
        private uint program_;
        public const int ProgramFieldNumber = 2;
        private uint region_;
        public const int RegionFieldNumber = 3;

        static GameAccountHandle()
        {
            object.ReferenceEquals(AccountTypes.Descriptor, null);
        }

        private GameAccountHandle()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GameAccountHandle prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GameAccountHandle handle = obj as GameAccountHandle;
            if (handle == null)
            {
                return false;
            }
            if ((this.hasId != handle.hasId) || (this.hasId && !this.id_.Equals(handle.id_)))
            {
                return false;
            }
            if ((this.hasProgram != handle.hasProgram) || (this.hasProgram && !this.program_.Equals(handle.program_)))
            {
                return false;
            }
            return ((this.hasRegion == handle.hasRegion) && (!this.hasRegion || this.region_.Equals(handle.region_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasId)
            {
                hashCode ^= this.id_.GetHashCode();
            }
            if (this.hasProgram)
            {
                hashCode ^= this.program_.GetHashCode();
            }
            if (this.hasRegion)
            {
                hashCode ^= this.region_.GetHashCode();
            }
            return hashCode;
        }

        private GameAccountHandle MakeReadOnly()
        {
            return this;
        }

        public static GameAccountHandle ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GameAccountHandle ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameAccountHandle ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GameAccountHandle ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GameAccountHandle ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GameAccountHandle ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GameAccountHandle ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GameAccountHandle ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameAccountHandle ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameAccountHandle ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GameAccountHandle, Builder>.PrintField("id", this.hasId, this.id_, writer);
            GeneratedMessageLite<GameAccountHandle, Builder>.PrintField("program", this.hasProgram, this.program_, writer);
            GeneratedMessageLite<GameAccountHandle, Builder>.PrintField("region", this.hasRegion, this.region_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _gameAccountHandleFieldNames;
            if (this.hasId)
            {
                output.WriteFixed32(1, strArray[0], this.Id);
            }
            if (this.hasProgram)
            {
                output.WriteFixed32(2, strArray[1], this.Program);
            }
            if (this.hasRegion)
            {
                output.WriteUInt32(3, strArray[2], this.Region);
            }
        }

        public static GameAccountHandle DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GameAccountHandle DefaultInstanceForType
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

        public bool HasProgram
        {
            get
            {
                return this.hasProgram;
            }
        }

        public bool HasRegion
        {
            get
            {
                return this.hasRegion;
            }
        }

        [CLSCompliant(false)]
        public uint Id
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
                if (!this.hasProgram)
                {
                    return false;
                }
                if (!this.hasRegion)
                {
                    return false;
                }
                return true;
            }
        }

        [CLSCompliant(false)]
        public uint Program
        {
            get
            {
                return this.program_;
            }
        }

        [CLSCompliant(false)]
        public uint Region
        {
            get
            {
                return this.region_;
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
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed32Size(1, this.Id);
                    }
                    if (this.hasProgram)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed32Size(2, this.Program);
                    }
                    if (this.hasRegion)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(3, this.Region);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override GameAccountHandle ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<GameAccountHandle, GameAccountHandle.Builder>
        {
            private GameAccountHandle result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GameAccountHandle.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GameAccountHandle cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override GameAccountHandle BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GameAccountHandle.Builder Clear()
            {
                this.result = GameAccountHandle.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GameAccountHandle.Builder ClearId()
            {
                this.PrepareBuilder();
                this.result.hasId = false;
                this.result.id_ = 0;
                return this;
            }

            public GameAccountHandle.Builder ClearProgram()
            {
                this.PrepareBuilder();
                this.result.hasProgram = false;
                this.result.program_ = 0;
                return this;
            }

            public GameAccountHandle.Builder ClearRegion()
            {
                this.PrepareBuilder();
                this.result.hasRegion = false;
                this.result.region_ = 0;
                return this;
            }

            public override GameAccountHandle.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GameAccountHandle.Builder(this.result);
                }
                return new GameAccountHandle.Builder().MergeFrom(this.result);
            }

            public override GameAccountHandle.Builder MergeFrom(GameAccountHandle other)
            {
                if (other != GameAccountHandle.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasId)
                    {
                        this.Id = other.Id;
                    }
                    if (other.HasProgram)
                    {
                        this.Program = other.Program;
                    }
                    if (other.HasRegion)
                    {
                        this.Region = other.Region;
                    }
                }
                return this;
            }

            public override GameAccountHandle.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GameAccountHandle.Builder MergeFrom(IMessageLite other)
            {
                if (other is GameAccountHandle)
                {
                    return this.MergeFrom((GameAccountHandle) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GameAccountHandle.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GameAccountHandle._gameAccountHandleFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GameAccountHandle._gameAccountHandleFieldTags[index];
                        }
                        else
                        {
                            this.ParseUnknownField(input, extensionRegistry, num, str);
                            continue;
                        }
                    }
                    switch (num)
                    {
                        case 0x15:
                        {
                            this.result.hasProgram = input.ReadFixed32(ref this.result.program_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasRegion = input.ReadUInt32(ref this.result.region_);
                            continue;
                        }
                        case 0:
                            throw InvalidProtocolBufferException.InvalidTag();

                        case 13:
                            goto Label_009F;

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
                Label_009F:
                    this.result.hasId = input.ReadFixed32(ref this.result.id_);
                }
                return this;
            }

            private GameAccountHandle PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GameAccountHandle result = this.result;
                    this.result = new GameAccountHandle();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public GameAccountHandle.Builder SetId(uint value)
            {
                this.PrepareBuilder();
                this.result.hasId = true;
                this.result.id_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public GameAccountHandle.Builder SetProgram(uint value)
            {
                this.PrepareBuilder();
                this.result.hasProgram = true;
                this.result.program_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public GameAccountHandle.Builder SetRegion(uint value)
            {
                this.PrepareBuilder();
                this.result.hasRegion = true;
                this.result.region_ = value;
                return this;
            }

            public override GameAccountHandle DefaultInstanceForType
            {
                get
                {
                    return GameAccountHandle.DefaultInstance;
                }
            }

            public bool HasId
            {
                get
                {
                    return this.result.hasId;
                }
            }

            public bool HasProgram
            {
                get
                {
                    return this.result.hasProgram;
                }
            }

            public bool HasRegion
            {
                get
                {
                    return this.result.hasRegion;
                }
            }

            [CLSCompliant(false)]
            public uint Id
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

            protected override GameAccountHandle MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            [CLSCompliant(false)]
            public uint Program
            {
                get
                {
                    return this.result.Program;
                }
                set
                {
                    this.SetProgram(value);
                }
            }

            [CLSCompliant(false)]
            public uint Region
            {
                get
                {
                    return this.result.Region;
                }
                set
                {
                    this.SetRegion(value);
                }
            }

            protected override GameAccountHandle.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

