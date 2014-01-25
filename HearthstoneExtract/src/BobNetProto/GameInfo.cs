namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class GameInfo : GeneratedMessageLite<GameInfo, Builder>
    {
        private static readonly string[] _gameInfoFieldNames = new string[] { "bn_game_handle", "name" };
        private static readonly uint[] _gameInfoFieldTags = new uint[] { 0x10, 10 };
        private int bnGameHandle_;
        public const int BnGameHandleFieldNumber = 2;
        private static readonly GameInfo defaultInstance = new GameInfo().MakeReadOnly();
        private bool hasBnGameHandle;
        private bool hasName;
        private int memoizedSerializedSize = -1;
        private string name_ = string.Empty;
        public const int NameFieldNumber = 1;

        static GameInfo()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private GameInfo()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GameInfo prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GameInfo info = obj as GameInfo;
            if (info == null)
            {
                return false;
            }
            if ((this.hasName != info.hasName) || (this.hasName && !this.name_.Equals(info.name_)))
            {
                return false;
            }
            return ((this.hasBnGameHandle == info.hasBnGameHandle) && (!this.hasBnGameHandle || this.bnGameHandle_.Equals(info.bnGameHandle_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasName)
            {
                hashCode ^= this.name_.GetHashCode();
            }
            if (this.hasBnGameHandle)
            {
                hashCode ^= this.bnGameHandle_.GetHashCode();
            }
            return hashCode;
        }

        private GameInfo MakeReadOnly()
        {
            return this;
        }

        public static GameInfo ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GameInfo ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameInfo ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GameInfo ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GameInfo ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GameInfo ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GameInfo ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GameInfo ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameInfo ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameInfo ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GameInfo, Builder>.PrintField("name", this.hasName, this.name_, writer);
            GeneratedMessageLite<GameInfo, Builder>.PrintField("bn_game_handle", this.hasBnGameHandle, this.bnGameHandle_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _gameInfoFieldNames;
            if (this.hasName)
            {
                output.WriteString(1, strArray[1], this.Name);
            }
            if (this.hasBnGameHandle)
            {
                output.WriteInt32(2, strArray[0], this.BnGameHandle);
            }
        }

        public int BnGameHandle
        {
            get
            {
                return this.bnGameHandle_;
            }
        }

        public static GameInfo DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GameInfo DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasBnGameHandle
        {
            get
            {
                return this.hasBnGameHandle;
            }
        }

        public bool HasName
        {
            get
            {
                return this.hasName;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasName)
                {
                    return false;
                }
                if (!this.hasBnGameHandle)
                {
                    return false;
                }
                return true;
            }
        }

        public string Name
        {
            get
            {
                return this.name_;
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
                    if (this.hasName)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(1, this.Name);
                    }
                    if (this.hasBnGameHandle)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.BnGameHandle);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override GameInfo ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<GameInfo, GameInfo.Builder>
        {
            private GameInfo result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GameInfo.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GameInfo cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override GameInfo BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GameInfo.Builder Clear()
            {
                this.result = GameInfo.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GameInfo.Builder ClearBnGameHandle()
            {
                this.PrepareBuilder();
                this.result.hasBnGameHandle = false;
                this.result.bnGameHandle_ = 0;
                return this;
            }

            public GameInfo.Builder ClearName()
            {
                this.PrepareBuilder();
                this.result.hasName = false;
                this.result.name_ = string.Empty;
                return this;
            }

            public override GameInfo.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GameInfo.Builder(this.result);
                }
                return new GameInfo.Builder().MergeFrom(this.result);
            }

            public override GameInfo.Builder MergeFrom(GameInfo other)
            {
                if (other != GameInfo.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasName)
                    {
                        this.Name = other.Name;
                    }
                    if (other.HasBnGameHandle)
                    {
                        this.BnGameHandle = other.BnGameHandle;
                    }
                }
                return this;
            }

            public override GameInfo.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GameInfo.Builder MergeFrom(IMessageLite other)
            {
                if (other is GameInfo)
                {
                    return this.MergeFrom((GameInfo) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GameInfo.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GameInfo._gameInfoFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GameInfo._gameInfoFieldTags[index];
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

                        case 10:
                        {
                            this.result.hasName = input.ReadString(ref this.result.name_);
                            continue;
                        }
                        case 0x10:
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
                    this.result.hasBnGameHandle = input.ReadInt32(ref this.result.bnGameHandle_);
                }
                return this;
            }

            private GameInfo PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GameInfo result = this.result;
                    this.result = new GameInfo();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public GameInfo.Builder SetBnGameHandle(int value)
            {
                this.PrepareBuilder();
                this.result.hasBnGameHandle = true;
                this.result.bnGameHandle_ = value;
                return this;
            }

            public GameInfo.Builder SetName(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasName = true;
                this.result.name_ = value;
                return this;
            }

            public int BnGameHandle
            {
                get
                {
                    return this.result.BnGameHandle;
                }
                set
                {
                    this.SetBnGameHandle(value);
                }
            }

            public override GameInfo DefaultInstanceForType
            {
                get
                {
                    return GameInfo.DefaultInstance;
                }
            }

            public bool HasBnGameHandle
            {
                get
                {
                    return this.result.hasBnGameHandle;
                }
            }

            public bool HasName
            {
                get
                {
                    return this.result.hasName;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override GameInfo MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public string Name
            {
                get
                {
                    return this.result.Name;
                }
                set
                {
                    this.SetName(value);
                }
            }

            protected override GameInfo.Builder ThisBuilder
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
                ID = 0x6b
            }
        }
    }
}

