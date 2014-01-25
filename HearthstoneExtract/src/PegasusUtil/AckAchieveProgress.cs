namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class AckAchieveProgress : GeneratedMessageLite<AckAchieveProgress, Builder>
    {
        private static readonly string[] _ackAchieveProgressFieldNames = new string[] { "ack_progress", "id" };
        private static readonly uint[] _ackAchieveProgressFieldTags = new uint[] { 0x10, 8 };
        private int ackProgress_;
        public const int AckProgressFieldNumber = 2;
        private static readonly AckAchieveProgress defaultInstance = new AckAchieveProgress().MakeReadOnly();
        private bool hasAckProgress;
        private bool hasId;
        private int id_;
        public const int IdFieldNumber = 1;
        private int memoizedSerializedSize = -1;

        static AckAchieveProgress()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AckAchieveProgress()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AckAchieveProgress prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AckAchieveProgress progress = obj as AckAchieveProgress;
            if (progress == null)
            {
                return false;
            }
            if ((this.hasId != progress.hasId) || (this.hasId && !this.id_.Equals(progress.id_)))
            {
                return false;
            }
            return ((this.hasAckProgress == progress.hasAckProgress) && (!this.hasAckProgress || this.ackProgress_.Equals(progress.ackProgress_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasId)
            {
                hashCode ^= this.id_.GetHashCode();
            }
            if (this.hasAckProgress)
            {
                hashCode ^= this.ackProgress_.GetHashCode();
            }
            return hashCode;
        }

        private AckAchieveProgress MakeReadOnly()
        {
            return this;
        }

        public static AckAchieveProgress ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AckAchieveProgress ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AckAchieveProgress ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AckAchieveProgress ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AckAchieveProgress ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AckAchieveProgress ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AckAchieveProgress ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AckAchieveProgress ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AckAchieveProgress ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AckAchieveProgress ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AckAchieveProgress, Builder>.PrintField("id", this.hasId, this.id_, writer);
            GeneratedMessageLite<AckAchieveProgress, Builder>.PrintField("ack_progress", this.hasAckProgress, this.ackProgress_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _ackAchieveProgressFieldNames;
            if (this.hasId)
            {
                output.WriteInt32(1, strArray[1], this.Id);
            }
            if (this.hasAckProgress)
            {
                output.WriteInt32(2, strArray[0], this.AckProgress);
            }
        }

        public int AckProgress
        {
            get
            {
                return this.ackProgress_;
            }
        }

        public static AckAchieveProgress DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AckAchieveProgress DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasAckProgress
        {
            get
            {
                return this.hasAckProgress;
            }
        }

        public bool HasId
        {
            get
            {
                return this.hasId;
            }
        }

        public int Id
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
                if (!this.hasAckProgress)
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
                    if (this.hasId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.Id);
                    }
                    if (this.hasAckProgress)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.AckProgress);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override AckAchieveProgress ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<AckAchieveProgress, AckAchieveProgress.Builder>
        {
            private AckAchieveProgress result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AckAchieveProgress.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AckAchieveProgress cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override AckAchieveProgress BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AckAchieveProgress.Builder Clear()
            {
                this.result = AckAchieveProgress.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AckAchieveProgress.Builder ClearAckProgress()
            {
                this.PrepareBuilder();
                this.result.hasAckProgress = false;
                this.result.ackProgress_ = 0;
                return this;
            }

            public AckAchieveProgress.Builder ClearId()
            {
                this.PrepareBuilder();
                this.result.hasId = false;
                this.result.id_ = 0;
                return this;
            }

            public override AckAchieveProgress.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AckAchieveProgress.Builder(this.result);
                }
                return new AckAchieveProgress.Builder().MergeFrom(this.result);
            }

            public override AckAchieveProgress.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AckAchieveProgress.Builder MergeFrom(IMessageLite other)
            {
                if (other is AckAchieveProgress)
                {
                    return this.MergeFrom((AckAchieveProgress) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AckAchieveProgress.Builder MergeFrom(AckAchieveProgress other)
            {
                if (other != AckAchieveProgress.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasId)
                    {
                        this.Id = other.Id;
                    }
                    if (other.HasAckProgress)
                    {
                        this.AckProgress = other.AckProgress;
                    }
                }
                return this;
            }

            public override AckAchieveProgress.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AckAchieveProgress._ackAchieveProgressFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AckAchieveProgress._ackAchieveProgressFieldTags[index];
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
                            this.result.hasId = input.ReadInt32(ref this.result.id_);
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
                    this.result.hasAckProgress = input.ReadInt32(ref this.result.ackProgress_);
                }
                return this;
            }

            private AckAchieveProgress PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AckAchieveProgress result = this.result;
                    this.result = new AckAchieveProgress();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public AckAchieveProgress.Builder SetAckProgress(int value)
            {
                this.PrepareBuilder();
                this.result.hasAckProgress = true;
                this.result.ackProgress_ = value;
                return this;
            }

            public AckAchieveProgress.Builder SetId(int value)
            {
                this.PrepareBuilder();
                this.result.hasId = true;
                this.result.id_ = value;
                return this;
            }

            public int AckProgress
            {
                get
                {
                    return this.result.AckProgress;
                }
                set
                {
                    this.SetAckProgress(value);
                }
            }

            public override AckAchieveProgress DefaultInstanceForType
            {
                get
                {
                    return AckAchieveProgress.DefaultInstance;
                }
            }

            public bool HasAckProgress
            {
                get
                {
                    return this.result.hasAckProgress;
                }
            }

            public bool HasId
            {
                get
                {
                    return this.result.hasId;
                }
            }

            public int Id
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

            protected override AckAchieveProgress MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override AckAchieveProgress.Builder ThisBuilder
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
                ID = 0xf3,
                System = 0
            }
        }
    }
}

