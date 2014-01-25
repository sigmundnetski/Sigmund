namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class ReportGame : GeneratedMessageLite<ReportGame, Builder>
    {
        private static readonly string[] _reportGameFieldNames = new string[] { "game_handle", "type" };
        private static readonly uint[] _reportGameFieldTags = new uint[] { 8, 0x10 };
        private static readonly ReportGame defaultInstance = new ReportGame().MakeReadOnly();
        private int gameHandle_;
        public const int GameHandleFieldNumber = 1;
        private bool hasGameHandle;
        private bool hasType;
        private int memoizedSerializedSize = -1;
        private BobNetProto.ReportGame.Types.Type type_ = BobNetProto.ReportGame.Types.Type.GT_1V1;
        public const int TypeFieldNumber = 2;

        static ReportGame()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private ReportGame()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ReportGame prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ReportGame game = obj as ReportGame;
            if (game == null)
            {
                return false;
            }
            if ((this.hasGameHandle != game.hasGameHandle) || (this.hasGameHandle && !this.gameHandle_.Equals(game.gameHandle_)))
            {
                return false;
            }
            return ((this.hasType == game.hasType) && (!this.hasType || this.type_.Equals(game.type_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasGameHandle)
            {
                hashCode ^= this.gameHandle_.GetHashCode();
            }
            if (this.hasType)
            {
                hashCode ^= this.type_.GetHashCode();
            }
            return hashCode;
        }

        private ReportGame MakeReadOnly()
        {
            return this;
        }

        public static ReportGame ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ReportGame ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ReportGame ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ReportGame ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ReportGame ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ReportGame ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ReportGame ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ReportGame ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ReportGame ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ReportGame ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ReportGame, Builder>.PrintField("game_handle", this.hasGameHandle, this.gameHandle_, writer);
            GeneratedMessageLite<ReportGame, Builder>.PrintField("type", this.hasType, this.type_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _reportGameFieldNames;
            if (this.hasGameHandle)
            {
                output.WriteInt32(1, strArray[0], this.GameHandle);
            }
            if (this.hasType)
            {
                output.WriteEnum(2, strArray[1], (int) this.Type, this.Type);
            }
        }

        public static ReportGame DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ReportGame DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public int GameHandle
        {
            get
            {
                return this.gameHandle_;
            }
        }

        public bool HasGameHandle
        {
            get
            {
                return this.hasGameHandle;
            }
        }

        public bool HasType
        {
            get
            {
                return this.hasType;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasGameHandle)
                {
                    return false;
                }
                if (!this.hasType)
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
                    if (this.hasGameHandle)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.GameHandle);
                    }
                    if (this.hasType)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeEnumSize(2, (int) this.Type);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ReportGame ThisMessage
        {
            get
            {
                return this;
            }
        }

        public BobNetProto.ReportGame.Types.Type Type
        {
            get
            {
                return this.type_;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<ReportGame, ReportGame.Builder>
        {
            private ReportGame result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ReportGame.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ReportGame cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override ReportGame BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ReportGame.Builder Clear()
            {
                this.result = ReportGame.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ReportGame.Builder ClearGameHandle()
            {
                this.PrepareBuilder();
                this.result.hasGameHandle = false;
                this.result.gameHandle_ = 0;
                return this;
            }

            public ReportGame.Builder ClearType()
            {
                this.PrepareBuilder();
                this.result.hasType = false;
                this.result.type_ = BobNetProto.ReportGame.Types.Type.GT_1V1;
                return this;
            }

            public override ReportGame.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ReportGame.Builder(this.result);
                }
                return new ReportGame.Builder().MergeFrom(this.result);
            }

            public override ReportGame.Builder MergeFrom(ReportGame other)
            {
                if (other != ReportGame.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasGameHandle)
                    {
                        this.GameHandle = other.GameHandle;
                    }
                    if (other.HasType)
                    {
                        this.Type = other.Type;
                    }
                }
                return this;
            }

            public override ReportGame.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ReportGame.Builder MergeFrom(IMessageLite other)
            {
                if (other is ReportGame)
                {
                    return this.MergeFrom((ReportGame) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ReportGame.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    object obj2;
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ReportGame._reportGameFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ReportGame._reportGameFieldTags[index];
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
                        {
                            this.result.hasGameHandle = input.ReadInt32(ref this.result.gameHandle_);
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
                    if (input.ReadEnum<BobNetProto.ReportGame.Types.Type>(ref this.result.type_, out obj2))
                    {
                        this.result.hasType = true;
                    }
                    else if (!(obj2 is int))
                    {
                        continue;
                    }
                }
                return this;
            }

            private ReportGame PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ReportGame result = this.result;
                    this.result = new ReportGame();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ReportGame.Builder SetGameHandle(int value)
            {
                this.PrepareBuilder();
                this.result.hasGameHandle = true;
                this.result.gameHandle_ = value;
                return this;
            }

            public ReportGame.Builder SetType(BobNetProto.ReportGame.Types.Type value)
            {
                this.PrepareBuilder();
                this.result.hasType = true;
                this.result.type_ = value;
                return this;
            }

            public override ReportGame DefaultInstanceForType
            {
                get
                {
                    return ReportGame.DefaultInstance;
                }
            }

            public int GameHandle
            {
                get
                {
                    return this.result.GameHandle;
                }
                set
                {
                    this.SetGameHandle(value);
                }
            }

            public bool HasGameHandle
            {
                get
                {
                    return this.result.hasGameHandle;
                }
            }

            public bool HasType
            {
                get
                {
                    return this.result.hasType;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override ReportGame MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override ReportGame.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public BobNetProto.ReportGame.Types.Type Type
            {
                get
                {
                    return this.result.Type;
                }
                set
                {
                    this.SetType(value);
                }
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0x74
            }

            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum Type
            {
                GT_1V1 = 1,
                GT_1VAI = 2
            }
        }
    }
}

