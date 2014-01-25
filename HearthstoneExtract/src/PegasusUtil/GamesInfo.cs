namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class GamesInfo : GeneratedMessageLite<GamesInfo, Builder>
    {
        private static readonly string[] _gamesInfoFieldNames = new string[] { "games_lost", "games_started", "games_won" };
        private static readonly uint[] _gamesInfoFieldTags = new uint[] { 0x18, 8, 0x10 };
        private static readonly GamesInfo defaultInstance = new GamesInfo().MakeReadOnly();
        private int gamesLost_;
        public const int GamesLostFieldNumber = 3;
        private int gamesStarted_;
        public const int GamesStartedFieldNumber = 1;
        private int gamesWon_;
        public const int GamesWonFieldNumber = 2;
        private bool hasGamesLost;
        private bool hasGamesStarted;
        private bool hasGamesWon;
        private int memoizedSerializedSize = -1;

        static GamesInfo()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private GamesInfo()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GamesInfo prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GamesInfo info = obj as GamesInfo;
            if (info == null)
            {
                return false;
            }
            if ((this.hasGamesStarted != info.hasGamesStarted) || (this.hasGamesStarted && !this.gamesStarted_.Equals(info.gamesStarted_)))
            {
                return false;
            }
            if ((this.hasGamesWon != info.hasGamesWon) || (this.hasGamesWon && !this.gamesWon_.Equals(info.gamesWon_)))
            {
                return false;
            }
            return ((this.hasGamesLost == info.hasGamesLost) && (!this.hasGamesLost || this.gamesLost_.Equals(info.gamesLost_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasGamesStarted)
            {
                hashCode ^= this.gamesStarted_.GetHashCode();
            }
            if (this.hasGamesWon)
            {
                hashCode ^= this.gamesWon_.GetHashCode();
            }
            if (this.hasGamesLost)
            {
                hashCode ^= this.gamesLost_.GetHashCode();
            }
            return hashCode;
        }

        private GamesInfo MakeReadOnly()
        {
            return this;
        }

        public static GamesInfo ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GamesInfo ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GamesInfo ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GamesInfo ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GamesInfo ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GamesInfo ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GamesInfo ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GamesInfo ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GamesInfo ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GamesInfo ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GamesInfo, Builder>.PrintField("games_started", this.hasGamesStarted, this.gamesStarted_, writer);
            GeneratedMessageLite<GamesInfo, Builder>.PrintField("games_won", this.hasGamesWon, this.gamesWon_, writer);
            GeneratedMessageLite<GamesInfo, Builder>.PrintField("games_lost", this.hasGamesLost, this.gamesLost_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _gamesInfoFieldNames;
            if (this.hasGamesStarted)
            {
                output.WriteInt32(1, strArray[1], this.GamesStarted);
            }
            if (this.hasGamesWon)
            {
                output.WriteInt32(2, strArray[2], this.GamesWon);
            }
            if (this.hasGamesLost)
            {
                output.WriteInt32(3, strArray[0], this.GamesLost);
            }
        }

        public static GamesInfo DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GamesInfo DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public int GamesLost
        {
            get
            {
                return this.gamesLost_;
            }
        }

        public int GamesStarted
        {
            get
            {
                return this.gamesStarted_;
            }
        }

        public int GamesWon
        {
            get
            {
                return this.gamesWon_;
            }
        }

        public bool HasGamesLost
        {
            get
            {
                return this.hasGamesLost;
            }
        }

        public bool HasGamesStarted
        {
            get
            {
                return this.hasGamesStarted;
            }
        }

        public bool HasGamesWon
        {
            get
            {
                return this.hasGamesWon;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasGamesStarted)
                {
                    return false;
                }
                if (!this.hasGamesWon)
                {
                    return false;
                }
                if (!this.hasGamesLost)
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
                    if (this.hasGamesStarted)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.GamesStarted);
                    }
                    if (this.hasGamesWon)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.GamesWon);
                    }
                    if (this.hasGamesLost)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(3, this.GamesLost);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override GamesInfo ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<GamesInfo, GamesInfo.Builder>
        {
            private GamesInfo result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GamesInfo.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GamesInfo cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override GamesInfo BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GamesInfo.Builder Clear()
            {
                this.result = GamesInfo.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GamesInfo.Builder ClearGamesLost()
            {
                this.PrepareBuilder();
                this.result.hasGamesLost = false;
                this.result.gamesLost_ = 0;
                return this;
            }

            public GamesInfo.Builder ClearGamesStarted()
            {
                this.PrepareBuilder();
                this.result.hasGamesStarted = false;
                this.result.gamesStarted_ = 0;
                return this;
            }

            public GamesInfo.Builder ClearGamesWon()
            {
                this.PrepareBuilder();
                this.result.hasGamesWon = false;
                this.result.gamesWon_ = 0;
                return this;
            }

            public override GamesInfo.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GamesInfo.Builder(this.result);
                }
                return new GamesInfo.Builder().MergeFrom(this.result);
            }

            public override GamesInfo.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GamesInfo.Builder MergeFrom(IMessageLite other)
            {
                if (other is GamesInfo)
                {
                    return this.MergeFrom((GamesInfo) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GamesInfo.Builder MergeFrom(GamesInfo other)
            {
                if (other != GamesInfo.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasGamesStarted)
                    {
                        this.GamesStarted = other.GamesStarted;
                    }
                    if (other.HasGamesWon)
                    {
                        this.GamesWon = other.GamesWon;
                    }
                    if (other.HasGamesLost)
                    {
                        this.GamesLost = other.GamesLost;
                    }
                }
                return this;
            }

            public override GamesInfo.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GamesInfo._gamesInfoFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GamesInfo._gamesInfoFieldTags[index];
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
                            this.result.hasGamesStarted = input.ReadInt32(ref this.result.gamesStarted_);
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasGamesWon = input.ReadInt32(ref this.result.gamesWon_);
                            continue;
                        }
                        case 0x18:
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
                    this.result.hasGamesLost = input.ReadInt32(ref this.result.gamesLost_);
                }
                return this;
            }

            private GamesInfo PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GamesInfo result = this.result;
                    this.result = new GamesInfo();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public GamesInfo.Builder SetGamesLost(int value)
            {
                this.PrepareBuilder();
                this.result.hasGamesLost = true;
                this.result.gamesLost_ = value;
                return this;
            }

            public GamesInfo.Builder SetGamesStarted(int value)
            {
                this.PrepareBuilder();
                this.result.hasGamesStarted = true;
                this.result.gamesStarted_ = value;
                return this;
            }

            public GamesInfo.Builder SetGamesWon(int value)
            {
                this.PrepareBuilder();
                this.result.hasGamesWon = true;
                this.result.gamesWon_ = value;
                return this;
            }

            public override GamesInfo DefaultInstanceForType
            {
                get
                {
                    return GamesInfo.DefaultInstance;
                }
            }

            public int GamesLost
            {
                get
                {
                    return this.result.GamesLost;
                }
                set
                {
                    this.SetGamesLost(value);
                }
            }

            public int GamesStarted
            {
                get
                {
                    return this.result.GamesStarted;
                }
                set
                {
                    this.SetGamesStarted(value);
                }
            }

            public int GamesWon
            {
                get
                {
                    return this.result.GamesWon;
                }
                set
                {
                    this.SetGamesWon(value);
                }
            }

            public bool HasGamesLost
            {
                get
                {
                    return this.result.hasGamesLost;
                }
            }

            public bool HasGamesStarted
            {
                get
                {
                    return this.result.hasGamesStarted;
                }
            }

            public bool HasGamesWon
            {
                get
                {
                    return this.result.hasGamesWon;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override GamesInfo MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override GamesInfo.Builder ThisBuilder
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
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0xd0
            }
        }
    }
}

