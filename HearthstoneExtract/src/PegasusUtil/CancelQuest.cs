namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class CancelQuest : GeneratedMessageLite<CancelQuest, Builder>
    {
        private static readonly string[] _cancelQuestFieldNames = new string[] { "quest_id" };
        private static readonly uint[] _cancelQuestFieldTags = new uint[] { 8 };
        private static readonly CancelQuest defaultInstance = new CancelQuest().MakeReadOnly();
        private bool hasQuestId;
        private int memoizedSerializedSize = -1;
        private int questId_;
        public const int QuestIdFieldNumber = 1;

        static CancelQuest()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private CancelQuest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(CancelQuest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            CancelQuest quest = obj as CancelQuest;
            if (quest == null)
            {
                return false;
            }
            return ((this.hasQuestId == quest.hasQuestId) && (!this.hasQuestId || this.questId_.Equals(quest.questId_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasQuestId)
            {
                hashCode ^= this.questId_.GetHashCode();
            }
            return hashCode;
        }

        private CancelQuest MakeReadOnly()
        {
            return this;
        }

        public static CancelQuest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static CancelQuest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static CancelQuest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static CancelQuest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static CancelQuest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static CancelQuest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static CancelQuest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static CancelQuest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static CancelQuest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static CancelQuest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<CancelQuest, Builder>.PrintField("quest_id", this.hasQuestId, this.questId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _cancelQuestFieldNames;
            if (this.hasQuestId)
            {
                output.WriteInt32(1, strArray[0], this.QuestId);
            }
        }

        public static CancelQuest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override CancelQuest DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasQuestId
        {
            get
            {
                return this.hasQuestId;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasQuestId)
                {
                    return false;
                }
                return true;
            }
        }

        public int QuestId
        {
            get
            {
                return this.questId_;
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
                    if (this.hasQuestId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.QuestId);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override CancelQuest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<CancelQuest, CancelQuest.Builder>
        {
            private CancelQuest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = CancelQuest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(CancelQuest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override CancelQuest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override CancelQuest.Builder Clear()
            {
                this.result = CancelQuest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public CancelQuest.Builder ClearQuestId()
            {
                this.PrepareBuilder();
                this.result.hasQuestId = false;
                this.result.questId_ = 0;
                return this;
            }

            public override CancelQuest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new CancelQuest.Builder(this.result);
                }
                return new CancelQuest.Builder().MergeFrom(this.result);
            }

            public override CancelQuest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override CancelQuest.Builder MergeFrom(IMessageLite other)
            {
                if (other is CancelQuest)
                {
                    return this.MergeFrom((CancelQuest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override CancelQuest.Builder MergeFrom(CancelQuest other)
            {
                if (other != CancelQuest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasQuestId)
                    {
                        this.QuestId = other.QuestId;
                    }
                }
                return this;
            }

            public override CancelQuest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(CancelQuest._cancelQuestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = CancelQuest._cancelQuestFieldTags[index];
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
                    this.result.hasQuestId = input.ReadInt32(ref this.result.questId_);
                }
                return this;
            }

            private CancelQuest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    CancelQuest result = this.result;
                    this.result = new CancelQuest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public CancelQuest.Builder SetQuestId(int value)
            {
                this.PrepareBuilder();
                this.result.hasQuestId = true;
                this.result.questId_ = value;
                return this;
            }

            public override CancelQuest DefaultInstanceForType
            {
                get
                {
                    return CancelQuest.DefaultInstance;
                }
            }

            public bool HasQuestId
            {
                get
                {
                    return this.result.hasQuestId;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override CancelQuest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int QuestId
            {
                get
                {
                    return this.result.QuestId;
                }
                set
                {
                    this.SetQuestId(value);
                }
            }

            protected override CancelQuest.Builder ThisBuilder
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
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0x119,
                System = 0
            }
        }
    }
}

