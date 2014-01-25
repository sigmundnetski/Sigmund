namespace PegasusGame
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class GameCanceled : GeneratedMessageLite<GameCanceled, Builder>
    {
        private static readonly string[] _gameCanceledFieldNames = new string[] { "reason" };
        private static readonly uint[] _gameCanceledFieldTags = new uint[] { 8 };
        private static readonly GameCanceled defaultInstance = new GameCanceled().MakeReadOnly();
        private bool hasReason;
        private int memoizedSerializedSize = -1;
        private PegasusGame.GameCanceled.Types.Reason reason_ = PegasusGame.GameCanceled.Types.Reason.OPPONENT_TIMEOUT;
        public const int ReasonFieldNumber = 1;

        static GameCanceled()
        {
            object.ReferenceEquals(PegasusGamelite.Descriptor, null);
        }

        private GameCanceled()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GameCanceled prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GameCanceled canceled = obj as GameCanceled;
            if (canceled == null)
            {
                return false;
            }
            return ((this.hasReason == canceled.hasReason) && (!this.hasReason || this.reason_.Equals(canceled.reason_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasReason)
            {
                hashCode ^= this.reason_.GetHashCode();
            }
            return hashCode;
        }

        private GameCanceled MakeReadOnly()
        {
            return this;
        }

        public static GameCanceled ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GameCanceled ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameCanceled ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GameCanceled ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GameCanceled ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GameCanceled ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GameCanceled ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GameCanceled ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameCanceled ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GameCanceled ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GameCanceled, Builder>.PrintField("reason", this.hasReason, this.reason_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _gameCanceledFieldNames;
            if (this.hasReason)
            {
                output.WriteEnum(1, strArray[0], (int) this.Reason, this.Reason);
            }
        }

        public static GameCanceled DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GameCanceled DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasReason
        {
            get
            {
                return this.hasReason;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasReason)
                {
                    return false;
                }
                return true;
            }
        }

        public PegasusGame.GameCanceled.Types.Reason Reason
        {
            get
            {
                return this.reason_;
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
                    if (this.hasReason)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeEnumSize(1, (int) this.Reason);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override GameCanceled ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<GameCanceled, GameCanceled.Builder>
        {
            private GameCanceled result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GameCanceled.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GameCanceled cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override GameCanceled BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GameCanceled.Builder Clear()
            {
                this.result = GameCanceled.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GameCanceled.Builder ClearReason()
            {
                this.PrepareBuilder();
                this.result.hasReason = false;
                this.result.reason_ = PegasusGame.GameCanceled.Types.Reason.OPPONENT_TIMEOUT;
                return this;
            }

            public override GameCanceled.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GameCanceled.Builder(this.result);
                }
                return new GameCanceled.Builder().MergeFrom(this.result);
            }

            public override GameCanceled.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GameCanceled.Builder MergeFrom(IMessageLite other)
            {
                if (other is GameCanceled)
                {
                    return this.MergeFrom((GameCanceled) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GameCanceled.Builder MergeFrom(GameCanceled other)
            {
                if (other != GameCanceled.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasReason)
                    {
                        this.Reason = other.Reason;
                    }
                }
                return this;
            }

            public override GameCanceled.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    object obj2;
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GameCanceled._gameCanceledFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GameCanceled._gameCanceledFieldTags[index];
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
                    if (input.ReadEnum<PegasusGame.GameCanceled.Types.Reason>(ref this.result.reason_, out obj2))
                    {
                        this.result.hasReason = true;
                    }
                    else if (!(obj2 is int))
                    {
                        continue;
                    }
                }
                return this;
            }

            private GameCanceled PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GameCanceled result = this.result;
                    this.result = new GameCanceled();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public GameCanceled.Builder SetReason(PegasusGame.GameCanceled.Types.Reason value)
            {
                this.PrepareBuilder();
                this.result.hasReason = true;
                this.result.reason_ = value;
                return this;
            }

            public override GameCanceled DefaultInstanceForType
            {
                get
                {
                    return GameCanceled.DefaultInstance;
                }
            }

            public bool HasReason
            {
                get
                {
                    return this.result.hasReason;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override GameCanceled MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public PegasusGame.GameCanceled.Types.Reason Reason
            {
                get
                {
                    return this.result.Reason;
                }
                set
                {
                    this.SetReason(value);
                }
            }

            protected override GameCanceled.Builder ThisBuilder
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
                ID = 12
            }

            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum Reason
            {
                OPPONENT_TIMEOUT = 1
            }
        }
    }
}

