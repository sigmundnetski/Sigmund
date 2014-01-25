namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class BeginPlaying : GeneratedMessageLite<BeginPlaying, Builder>
    {
        private static readonly string[] _beginPlayingFieldNames = new string[] { "mode" };
        private static readonly uint[] _beginPlayingFieldTags = new uint[] { 8 };
        private static readonly BeginPlaying defaultInstance = new BeginPlaying().MakeReadOnly();
        private bool hasMode;
        private int memoizedSerializedSize = -1;
        private BobNetProto.BeginPlaying.Types.Mode mode_ = BobNetProto.BeginPlaying.Types.Mode.COUNTDOWN;
        public const int ModeFieldNumber = 1;

        static BeginPlaying()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private BeginPlaying()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(BeginPlaying prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            BeginPlaying playing = obj as BeginPlaying;
            if (playing == null)
            {
                return false;
            }
            return ((this.hasMode == playing.hasMode) && (!this.hasMode || this.mode_.Equals(playing.mode_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasMode)
            {
                hashCode ^= this.mode_.GetHashCode();
            }
            return hashCode;
        }

        private BeginPlaying MakeReadOnly()
        {
            return this;
        }

        public static BeginPlaying ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static BeginPlaying ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static BeginPlaying ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static BeginPlaying ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static BeginPlaying ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static BeginPlaying ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static BeginPlaying ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static BeginPlaying ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static BeginPlaying ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static BeginPlaying ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<BeginPlaying, Builder>.PrintField("mode", this.hasMode, this.mode_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _beginPlayingFieldNames;
            if (this.hasMode)
            {
                output.WriteEnum(1, strArray[0], (int) this.Mode, this.Mode);
            }
        }

        public static BeginPlaying DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override BeginPlaying DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasMode
        {
            get
            {
                return this.hasMode;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasMode)
                {
                    return false;
                }
                return true;
            }
        }

        public BobNetProto.BeginPlaying.Types.Mode Mode
        {
            get
            {
                return this.mode_;
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
                    if (this.hasMode)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeEnumSize(1, (int) this.Mode);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override BeginPlaying ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<BeginPlaying, BeginPlaying.Builder>
        {
            private BeginPlaying result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = BeginPlaying.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(BeginPlaying cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override BeginPlaying BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override BeginPlaying.Builder Clear()
            {
                this.result = BeginPlaying.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public BeginPlaying.Builder ClearMode()
            {
                this.PrepareBuilder();
                this.result.hasMode = false;
                this.result.mode_ = BobNetProto.BeginPlaying.Types.Mode.COUNTDOWN;
                return this;
            }

            public override BeginPlaying.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new BeginPlaying.Builder(this.result);
                }
                return new BeginPlaying.Builder().MergeFrom(this.result);
            }

            public override BeginPlaying.Builder MergeFrom(BeginPlaying other)
            {
                if (other != BeginPlaying.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasMode)
                    {
                        this.Mode = other.Mode;
                    }
                }
                return this;
            }

            public override BeginPlaying.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override BeginPlaying.Builder MergeFrom(IMessageLite other)
            {
                if (other is BeginPlaying)
                {
                    return this.MergeFrom((BeginPlaying) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override BeginPlaying.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    object obj2;
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(BeginPlaying._beginPlayingFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = BeginPlaying._beginPlayingFieldTags[index];
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
                    if (input.ReadEnum<BobNetProto.BeginPlaying.Types.Mode>(ref this.result.mode_, out obj2))
                    {
                        this.result.hasMode = true;
                    }
                    else if (!(obj2 is int))
                    {
                        continue;
                    }
                }
                return this;
            }

            private BeginPlaying PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    BeginPlaying result = this.result;
                    this.result = new BeginPlaying();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public BeginPlaying.Builder SetMode(BobNetProto.BeginPlaying.Types.Mode value)
            {
                this.PrepareBuilder();
                this.result.hasMode = true;
                this.result.mode_ = value;
                return this;
            }

            public override BeginPlaying DefaultInstanceForType
            {
                get
                {
                    return BeginPlaying.DefaultInstance;
                }
            }

            public bool HasMode
            {
                get
                {
                    return this.result.hasMode;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override BeginPlaying MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public BobNetProto.BeginPlaying.Types.Mode Mode
            {
                get
                {
                    return this.result.Mode;
                }
                set
                {
                    this.SetMode(value);
                }
            }

            protected override BeginPlaying.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum Mode
            {
                COUNTDOWN = 1,
                READY = 2
            }

            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0x71
            }
        }
    }
}

