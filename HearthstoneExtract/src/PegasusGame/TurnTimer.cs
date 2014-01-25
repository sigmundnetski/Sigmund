namespace PegasusGame
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class TurnTimer : GeneratedMessageLite<TurnTimer, Builder>
    {
        private static readonly string[] _turnTimerFieldNames = new string[] { "seconds", "turn" };
        private static readonly uint[] _turnTimerFieldTags = new uint[] { 8, 0x10 };
        private static readonly TurnTimer defaultInstance = new TurnTimer().MakeReadOnly();
        private bool hasSeconds;
        private bool hasTurn;
        private int memoizedSerializedSize = -1;
        private int seconds_;
        public const int SecondsFieldNumber = 1;
        private int turn_;
        public const int TurnFieldNumber = 2;

        static TurnTimer()
        {
            object.ReferenceEquals(PegasusGamelite.Descriptor, null);
        }

        private TurnTimer()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(TurnTimer prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            TurnTimer timer = obj as TurnTimer;
            if (timer == null)
            {
                return false;
            }
            if ((this.hasSeconds != timer.hasSeconds) || (this.hasSeconds && !this.seconds_.Equals(timer.seconds_)))
            {
                return false;
            }
            return ((this.hasTurn == timer.hasTurn) && (!this.hasTurn || this.turn_.Equals(timer.turn_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasSeconds)
            {
                hashCode ^= this.seconds_.GetHashCode();
            }
            if (this.hasTurn)
            {
                hashCode ^= this.turn_.GetHashCode();
            }
            return hashCode;
        }

        private TurnTimer MakeReadOnly()
        {
            return this;
        }

        public static TurnTimer ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static TurnTimer ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static TurnTimer ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static TurnTimer ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static TurnTimer ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static TurnTimer ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static TurnTimer ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static TurnTimer ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static TurnTimer ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static TurnTimer ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<TurnTimer, Builder>.PrintField("seconds", this.hasSeconds, this.seconds_, writer);
            GeneratedMessageLite<TurnTimer, Builder>.PrintField("turn", this.hasTurn, this.turn_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _turnTimerFieldNames;
            if (this.hasSeconds)
            {
                output.WriteInt32(1, strArray[0], this.Seconds);
            }
            if (this.hasTurn)
            {
                output.WriteInt32(2, strArray[1], this.Turn);
            }
        }

        public static TurnTimer DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override TurnTimer DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasSeconds
        {
            get
            {
                return this.hasSeconds;
            }
        }

        public bool HasTurn
        {
            get
            {
                return this.hasTurn;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasSeconds)
                {
                    return false;
                }
                if (!this.hasTurn)
                {
                    return false;
                }
                return true;
            }
        }

        public int Seconds
        {
            get
            {
                return this.seconds_;
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
                    if (this.hasSeconds)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.Seconds);
                    }
                    if (this.hasTurn)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.Turn);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override TurnTimer ThisMessage
        {
            get
            {
                return this;
            }
        }

        public int Turn
        {
            get
            {
                return this.turn_;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<TurnTimer, TurnTimer.Builder>
        {
            private TurnTimer result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = TurnTimer.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(TurnTimer cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override TurnTimer BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override TurnTimer.Builder Clear()
            {
                this.result = TurnTimer.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public TurnTimer.Builder ClearSeconds()
            {
                this.PrepareBuilder();
                this.result.hasSeconds = false;
                this.result.seconds_ = 0;
                return this;
            }

            public TurnTimer.Builder ClearTurn()
            {
                this.PrepareBuilder();
                this.result.hasTurn = false;
                this.result.turn_ = 0;
                return this;
            }

            public override TurnTimer.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new TurnTimer.Builder(this.result);
                }
                return new TurnTimer.Builder().MergeFrom(this.result);
            }

            public override TurnTimer.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override TurnTimer.Builder MergeFrom(IMessageLite other)
            {
                if (other is TurnTimer)
                {
                    return this.MergeFrom((TurnTimer) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override TurnTimer.Builder MergeFrom(TurnTimer other)
            {
                if (other != TurnTimer.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasSeconds)
                    {
                        this.Seconds = other.Seconds;
                    }
                    if (other.HasTurn)
                    {
                        this.Turn = other.Turn;
                    }
                }
                return this;
            }

            public override TurnTimer.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(TurnTimer._turnTimerFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = TurnTimer._turnTimerFieldTags[index];
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
                            this.result.hasSeconds = input.ReadInt32(ref this.result.seconds_);
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
                    this.result.hasTurn = input.ReadInt32(ref this.result.turn_);
                }
                return this;
            }

            private TurnTimer PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    TurnTimer result = this.result;
                    this.result = new TurnTimer();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public TurnTimer.Builder SetSeconds(int value)
            {
                this.PrepareBuilder();
                this.result.hasSeconds = true;
                this.result.seconds_ = value;
                return this;
            }

            public TurnTimer.Builder SetTurn(int value)
            {
                this.PrepareBuilder();
                this.result.hasTurn = true;
                this.result.turn_ = value;
                return this;
            }

            public override TurnTimer DefaultInstanceForType
            {
                get
                {
                    return TurnTimer.DefaultInstance;
                }
            }

            public bool HasSeconds
            {
                get
                {
                    return this.result.hasSeconds;
                }
            }

            public bool HasTurn
            {
                get
                {
                    return this.result.hasTurn;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override TurnTimer MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int Seconds
            {
                get
                {
                    return this.result.Seconds;
                }
                set
                {
                    this.SetSeconds(value);
                }
            }

            protected override TurnTimer.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public int Turn
            {
                get
                {
                    return this.result.Turn;
                }
                set
                {
                    this.SetTurn(value);
                }
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 9
            }
        }
    }
}

