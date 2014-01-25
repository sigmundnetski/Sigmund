namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class CancelQuestResponse : GeneratedMessageLite<CancelQuestResponse, Builder>
    {
        private static readonly string[] _cancelQuestResponseFieldNames = new string[] { "quest_id", "success" };
        private static readonly uint[] _cancelQuestResponseFieldTags = new uint[] { 8, 0x10 };
        private static readonly CancelQuestResponse defaultInstance = new CancelQuestResponse().MakeReadOnly();
        private bool hasQuestId;
        private bool hasSuccess;
        private int memoizedSerializedSize = -1;
        private int questId_;
        public const int QuestIdFieldNumber = 1;
        private bool success_;
        public const int SuccessFieldNumber = 2;

        static CancelQuestResponse()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private CancelQuestResponse()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(CancelQuestResponse prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            CancelQuestResponse response = obj as CancelQuestResponse;
            if (response == null)
            {
                return false;
            }
            if ((this.hasQuestId != response.hasQuestId) || (this.hasQuestId && !this.questId_.Equals(response.questId_)))
            {
                return false;
            }
            return ((this.hasSuccess == response.hasSuccess) && (!this.hasSuccess || this.success_.Equals(response.success_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasQuestId)
            {
                hashCode ^= this.questId_.GetHashCode();
            }
            if (this.hasSuccess)
            {
                hashCode ^= this.success_.GetHashCode();
            }
            return hashCode;
        }

        private CancelQuestResponse MakeReadOnly()
        {
            return this;
        }

        public static CancelQuestResponse ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static CancelQuestResponse ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static CancelQuestResponse ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static CancelQuestResponse ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static CancelQuestResponse ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static CancelQuestResponse ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static CancelQuestResponse ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static CancelQuestResponse ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static CancelQuestResponse ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static CancelQuestResponse ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<CancelQuestResponse, Builder>.PrintField("quest_id", this.hasQuestId, this.questId_, writer);
            GeneratedMessageLite<CancelQuestResponse, Builder>.PrintField("success", this.hasSuccess, this.success_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _cancelQuestResponseFieldNames;
            if (this.hasQuestId)
            {
                output.WriteInt32(1, strArray[0], this.QuestId);
            }
            if (this.hasSuccess)
            {
                output.WriteBool(2, strArray[1], this.Success);
            }
        }

        public static CancelQuestResponse DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override CancelQuestResponse DefaultInstanceForType
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

        public bool HasSuccess
        {
            get
            {
                return this.hasSuccess;
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
                if (!this.hasSuccess)
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
                    if (this.hasSuccess)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(2, this.Success);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        public bool Success
        {
            get
            {
                return this.success_;
            }
        }

        protected override CancelQuestResponse ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<CancelQuestResponse, CancelQuestResponse.Builder>
        {
            private CancelQuestResponse result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = CancelQuestResponse.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(CancelQuestResponse cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override CancelQuestResponse BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override CancelQuestResponse.Builder Clear()
            {
                this.result = CancelQuestResponse.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public CancelQuestResponse.Builder ClearQuestId()
            {
                this.PrepareBuilder();
                this.result.hasQuestId = false;
                this.result.questId_ = 0;
                return this;
            }

            public CancelQuestResponse.Builder ClearSuccess()
            {
                this.PrepareBuilder();
                this.result.hasSuccess = false;
                this.result.success_ = false;
                return this;
            }

            public override CancelQuestResponse.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new CancelQuestResponse.Builder(this.result);
                }
                return new CancelQuestResponse.Builder().MergeFrom(this.result);
            }

            public override CancelQuestResponse.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override CancelQuestResponse.Builder MergeFrom(IMessageLite other)
            {
                if (other is CancelQuestResponse)
                {
                    return this.MergeFrom((CancelQuestResponse) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override CancelQuestResponse.Builder MergeFrom(CancelQuestResponse other)
            {
                if (other != CancelQuestResponse.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasQuestId)
                    {
                        this.QuestId = other.QuestId;
                    }
                    if (other.HasSuccess)
                    {
                        this.Success = other.Success;
                    }
                }
                return this;
            }

            public override CancelQuestResponse.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(CancelQuestResponse._cancelQuestResponseFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = CancelQuestResponse._cancelQuestResponseFieldTags[index];
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
                            this.result.hasQuestId = input.ReadInt32(ref this.result.questId_);
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
                    this.result.hasSuccess = input.ReadBool(ref this.result.success_);
                }
                return this;
            }

            private CancelQuestResponse PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    CancelQuestResponse result = this.result;
                    this.result = new CancelQuestResponse();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public CancelQuestResponse.Builder SetQuestId(int value)
            {
                this.PrepareBuilder();
                this.result.hasQuestId = true;
                this.result.questId_ = value;
                return this;
            }

            public CancelQuestResponse.Builder SetSuccess(bool value)
            {
                this.PrepareBuilder();
                this.result.hasSuccess = true;
                this.result.success_ = value;
                return this;
            }

            public override CancelQuestResponse DefaultInstanceForType
            {
                get
                {
                    return CancelQuestResponse.DefaultInstance;
                }
            }

            public bool HasQuestId
            {
                get
                {
                    return this.result.hasQuestId;
                }
            }

            public bool HasSuccess
            {
                get
                {
                    return this.result.hasSuccess;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override CancelQuestResponse MessageBeingBuilt
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

            public bool Success
            {
                get
                {
                    return this.result.Success;
                }
                set
                {
                    this.SetSuccess(value);
                }
            }

            protected override CancelQuestResponse.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0x11a
            }
        }
    }
}

