namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class OneClientTracking : GeneratedMessageLite<OneClientTracking, Builder>
    {
        private static readonly string[] _oneClientTrackingFieldNames = new string[] { "level", "message", "timestamp", "what" };
        private static readonly uint[] _oneClientTrackingFieldTags = new uint[] { 8, 0x1a, 0x20, 0x10 };
        private static readonly OneClientTracking defaultInstance = new OneClientTracking().MakeReadOnly();
        private bool hasLevel;
        private bool hasMessage;
        private bool hasTimestamp;
        private bool hasWhat;
        private PegasusUtil.OneClientTracking.Types.Level level_ = PegasusUtil.OneClientTracking.Types.Level.L_INFO;
        public const int LevelFieldNumber = 1;
        private int memoizedSerializedSize = -1;
        private string message_ = string.Empty;
        public const int MessageFieldNumber = 3;
        private ulong timestamp_;
        public const int TimestampFieldNumber = 4;
        private int what_;
        public const int WhatFieldNumber = 2;

        static OneClientTracking()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private OneClientTracking()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(OneClientTracking prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            OneClientTracking tracking = obj as OneClientTracking;
            if (tracking == null)
            {
                return false;
            }
            if ((this.hasLevel != tracking.hasLevel) || (this.hasLevel && !this.level_.Equals(tracking.level_)))
            {
                return false;
            }
            if ((this.hasWhat != tracking.hasWhat) || (this.hasWhat && !this.what_.Equals(tracking.what_)))
            {
                return false;
            }
            if ((this.hasTimestamp != tracking.hasTimestamp) || (this.hasTimestamp && !this.timestamp_.Equals(tracking.timestamp_)))
            {
                return false;
            }
            return ((this.hasMessage == tracking.hasMessage) && (!this.hasMessage || this.message_.Equals(tracking.message_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasLevel)
            {
                hashCode ^= this.level_.GetHashCode();
            }
            if (this.hasWhat)
            {
                hashCode ^= this.what_.GetHashCode();
            }
            if (this.hasTimestamp)
            {
                hashCode ^= this.timestamp_.GetHashCode();
            }
            if (this.hasMessage)
            {
                hashCode ^= this.message_.GetHashCode();
            }
            return hashCode;
        }

        private OneClientTracking MakeReadOnly()
        {
            return this;
        }

        public static OneClientTracking ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static OneClientTracking ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static OneClientTracking ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static OneClientTracking ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static OneClientTracking ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static OneClientTracking ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static OneClientTracking ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static OneClientTracking ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static OneClientTracking ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static OneClientTracking ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<OneClientTracking, Builder>.PrintField("level", this.hasLevel, this.level_, writer);
            GeneratedMessageLite<OneClientTracking, Builder>.PrintField("what", this.hasWhat, this.what_, writer);
            GeneratedMessageLite<OneClientTracking, Builder>.PrintField("message", this.hasMessage, this.message_, writer);
            GeneratedMessageLite<OneClientTracking, Builder>.PrintField("timestamp", this.hasTimestamp, this.timestamp_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _oneClientTrackingFieldNames;
            if (this.hasLevel)
            {
                output.WriteEnum(1, strArray[0], (int) this.Level, this.Level);
            }
            if (this.hasWhat)
            {
                output.WriteInt32(2, strArray[3], this.What);
            }
            if (this.hasMessage)
            {
                output.WriteString(3, strArray[1], this.Message);
            }
            if (this.hasTimestamp)
            {
                output.WriteUInt64(4, strArray[2], this.Timestamp);
            }
        }

        public static OneClientTracking DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override OneClientTracking DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasLevel
        {
            get
            {
                return this.hasLevel;
            }
        }

        public bool HasMessage
        {
            get
            {
                return this.hasMessage;
            }
        }

        public bool HasTimestamp
        {
            get
            {
                return this.hasTimestamp;
            }
        }

        public bool HasWhat
        {
            get
            {
                return this.hasWhat;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasLevel)
                {
                    return false;
                }
                if (!this.hasWhat)
                {
                    return false;
                }
                if (!this.hasTimestamp)
                {
                    return false;
                }
                return true;
            }
        }

        public PegasusUtil.OneClientTracking.Types.Level Level
        {
            get
            {
                return this.level_;
            }
        }

        public string Message
        {
            get
            {
                return this.message_;
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
                    if (this.hasLevel)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeEnumSize(1, (int) this.Level);
                    }
                    if (this.hasWhat)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.What);
                    }
                    if (this.hasTimestamp)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(4, this.Timestamp);
                    }
                    if (this.hasMessage)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(3, this.Message);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override OneClientTracking ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CLSCompliant(false)]
        public ulong Timestamp
        {
            get
            {
                return this.timestamp_;
            }
        }

        public int What
        {
            get
            {
                return this.what_;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<OneClientTracking, OneClientTracking.Builder>
        {
            private OneClientTracking result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = OneClientTracking.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(OneClientTracking cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override OneClientTracking BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override OneClientTracking.Builder Clear()
            {
                this.result = OneClientTracking.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public OneClientTracking.Builder ClearLevel()
            {
                this.PrepareBuilder();
                this.result.hasLevel = false;
                this.result.level_ = PegasusUtil.OneClientTracking.Types.Level.L_INFO;
                return this;
            }

            public OneClientTracking.Builder ClearMessage()
            {
                this.PrepareBuilder();
                this.result.hasMessage = false;
                this.result.message_ = string.Empty;
                return this;
            }

            public OneClientTracking.Builder ClearTimestamp()
            {
                this.PrepareBuilder();
                this.result.hasTimestamp = false;
                this.result.timestamp_ = 0L;
                return this;
            }

            public OneClientTracking.Builder ClearWhat()
            {
                this.PrepareBuilder();
                this.result.hasWhat = false;
                this.result.what_ = 0;
                return this;
            }

            public override OneClientTracking.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new OneClientTracking.Builder(this.result);
                }
                return new OneClientTracking.Builder().MergeFrom(this.result);
            }

            public override OneClientTracking.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override OneClientTracking.Builder MergeFrom(IMessageLite other)
            {
                if (other is OneClientTracking)
                {
                    return this.MergeFrom((OneClientTracking) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override OneClientTracking.Builder MergeFrom(OneClientTracking other)
            {
                if (other != OneClientTracking.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasLevel)
                    {
                        this.Level = other.Level;
                    }
                    if (other.HasWhat)
                    {
                        this.What = other.What;
                    }
                    if (other.HasTimestamp)
                    {
                        this.Timestamp = other.Timestamp;
                    }
                    if (other.HasMessage)
                    {
                        this.Message = other.Message;
                    }
                }
                return this;
            }

            public override OneClientTracking.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(OneClientTracking._oneClientTrackingFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = OneClientTracking._oneClientTrackingFieldTags[index];
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
                            object obj2;
                            if (input.ReadEnum<PegasusUtil.OneClientTracking.Types.Level>(ref this.result.level_, out obj2))
                            {
                                this.result.hasLevel = true;
                            }
                            else if (obj2 is int)
                            {
                            }
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasWhat = input.ReadInt32(ref this.result.what_);
                            continue;
                        }
                        case 0x1a:
                        {
                            this.result.hasMessage = input.ReadString(ref this.result.message_);
                            continue;
                        }
                        case 0x20:
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
                    this.result.hasTimestamp = input.ReadUInt64(ref this.result.timestamp_);
                }
                return this;
            }

            private OneClientTracking PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    OneClientTracking result = this.result;
                    this.result = new OneClientTracking();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public OneClientTracking.Builder SetLevel(PegasusUtil.OneClientTracking.Types.Level value)
            {
                this.PrepareBuilder();
                this.result.hasLevel = true;
                this.result.level_ = value;
                return this;
            }

            public OneClientTracking.Builder SetMessage(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasMessage = true;
                this.result.message_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public OneClientTracking.Builder SetTimestamp(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasTimestamp = true;
                this.result.timestamp_ = value;
                return this;
            }

            public OneClientTracking.Builder SetWhat(int value)
            {
                this.PrepareBuilder();
                this.result.hasWhat = true;
                this.result.what_ = value;
                return this;
            }

            public override OneClientTracking DefaultInstanceForType
            {
                get
                {
                    return OneClientTracking.DefaultInstance;
                }
            }

            public bool HasLevel
            {
                get
                {
                    return this.result.hasLevel;
                }
            }

            public bool HasMessage
            {
                get
                {
                    return this.result.hasMessage;
                }
            }

            public bool HasTimestamp
            {
                get
                {
                    return this.result.hasTimestamp;
                }
            }

            public bool HasWhat
            {
                get
                {
                    return this.result.hasWhat;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public PegasusUtil.OneClientTracking.Types.Level Level
            {
                get
                {
                    return this.result.Level;
                }
                set
                {
                    this.SetLevel(value);
                }
            }

            public string Message
            {
                get
                {
                    return this.result.Message;
                }
                set
                {
                    this.SetMessage(value);
                }
            }

            protected override OneClientTracking MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override OneClientTracking.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            [CLSCompliant(false)]
            public ulong Timestamp
            {
                get
                {
                    return this.result.Timestamp;
                }
                set
                {
                    this.SetTimestamp(value);
                }
            }

            public int What
            {
                get
                {
                    return this.result.What;
                }
                set
                {
                    this.SetWhat(value);
                }
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum Level
            {
                L_ERROR = 3,
                L_INFO = 1,
                L_WARNING = 2
            }
        }
    }
}

