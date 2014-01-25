namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class GuardianTrack : GeneratedMessageLite<GuardianTrack, Builder>
    {
        private static readonly string[] _guardianTrackFieldNames = new string[] { "what" };
        private static readonly uint[] _guardianTrackFieldTags = new uint[] { 8 };
        private static readonly GuardianTrack defaultInstance = new GuardianTrack().MakeReadOnly();
        private bool hasWhat;
        private int memoizedSerializedSize = -1;
        private int what_;
        public const int WhatFieldNumber = 1;

        static GuardianTrack()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private GuardianTrack()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GuardianTrack prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GuardianTrack track = obj as GuardianTrack;
            if (track == null)
            {
                return false;
            }
            return ((this.hasWhat == track.hasWhat) && (!this.hasWhat || this.what_.Equals(track.what_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasWhat)
            {
                hashCode ^= this.what_.GetHashCode();
            }
            return hashCode;
        }

        private GuardianTrack MakeReadOnly()
        {
            return this;
        }

        public static GuardianTrack ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GuardianTrack ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GuardianTrack ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GuardianTrack ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GuardianTrack ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GuardianTrack ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GuardianTrack ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GuardianTrack ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GuardianTrack ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GuardianTrack ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GuardianTrack, Builder>.PrintField("what", this.hasWhat, this.what_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _guardianTrackFieldNames;
            if (this.hasWhat)
            {
                output.WriteInt32(1, strArray[0], this.What);
            }
        }

        public static GuardianTrack DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GuardianTrack DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
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
                if (!this.hasWhat)
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
                    if (this.hasWhat)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.What);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override GuardianTrack ThisMessage
        {
            get
            {
                return this;
            }
        }

        public int What
        {
            get
            {
                return this.what_;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<GuardianTrack, GuardianTrack.Builder>
        {
            private GuardianTrack result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GuardianTrack.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GuardianTrack cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override GuardianTrack BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GuardianTrack.Builder Clear()
            {
                this.result = GuardianTrack.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GuardianTrack.Builder ClearWhat()
            {
                this.PrepareBuilder();
                this.result.hasWhat = false;
                this.result.what_ = 0;
                return this;
            }

            public override GuardianTrack.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GuardianTrack.Builder(this.result);
                }
                return new GuardianTrack.Builder().MergeFrom(this.result);
            }

            public override GuardianTrack.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GuardianTrack.Builder MergeFrom(IMessageLite other)
            {
                if (other is GuardianTrack)
                {
                    return this.MergeFrom((GuardianTrack) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GuardianTrack.Builder MergeFrom(GuardianTrack other)
            {
                if (other != GuardianTrack.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasWhat)
                    {
                        this.What = other.What;
                    }
                }
                return this;
            }

            public override GuardianTrack.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GuardianTrack._guardianTrackFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GuardianTrack._guardianTrackFieldTags[index];
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
                    this.result.hasWhat = input.ReadInt32(ref this.result.what_);
                }
                return this;
            }

            private GuardianTrack PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GuardianTrack result = this.result;
                    this.result = new GuardianTrack();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public GuardianTrack.Builder SetWhat(int value)
            {
                this.PrepareBuilder();
                this.result.hasWhat = true;
                this.result.what_ = value;
                return this;
            }

            public override GuardianTrack DefaultInstanceForType
            {
                get
                {
                    return GuardianTrack.DefaultInstance;
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

            protected override GuardianTrack MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override GuardianTrack.Builder ThisBuilder
            {
                get
                {
                    return this;
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

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0x105,
                System = 0
            }
        }
    }
}

