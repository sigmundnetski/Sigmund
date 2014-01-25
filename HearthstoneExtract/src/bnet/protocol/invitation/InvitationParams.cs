namespace bnet.protocol.invitation
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class InvitationParams : ExtendableMessageLite<InvitationParams, Builder>
    {
        private static readonly string[] _invitationParamsFieldNames = new string[] { "expiration_time", "invitation_message" };
        private static readonly uint[] _invitationParamsFieldTags = new uint[] { 0x10, 10 };
        private static readonly InvitationParams defaultInstance = new InvitationParams().MakeReadOnly();
        private ulong expirationTime_;
        public const int ExpirationTimeFieldNumber = 2;
        private bool hasExpirationTime;
        private bool hasInvitationMessage;
        private string invitationMessage_ = string.Empty;
        public const int InvitationMessageFieldNumber = 1;
        private int memoizedSerializedSize = -1;

        static InvitationParams()
        {
            object.ReferenceEquals(InvitationTypes.Descriptor, null);
        }

        private InvitationParams()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(InvitationParams prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            InvitationParams params = obj as InvitationParams;
            if (params == null)
            {
                return false;
            }
            if ((this.hasInvitationMessage != params.hasInvitationMessage) || (this.hasInvitationMessage && !this.invitationMessage_.Equals(params.invitationMessage_)))
            {
                return false;
            }
            if ((this.hasExpirationTime != params.hasExpirationTime) || (this.hasExpirationTime && !this.expirationTime_.Equals(params.expirationTime_)))
            {
                return false;
            }
            if (!base.Equals(params))
            {
                return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasInvitationMessage)
            {
                hashCode ^= this.invitationMessage_.GetHashCode();
            }
            if (this.hasExpirationTime)
            {
                hashCode ^= this.expirationTime_.GetHashCode();
            }
            return (hashCode ^ base.GetHashCode());
        }

        private InvitationParams MakeReadOnly()
        {
            return this;
        }

        public static InvitationParams ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static InvitationParams ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static InvitationParams ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static InvitationParams ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static InvitationParams ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static InvitationParams ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static InvitationParams ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static InvitationParams ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static InvitationParams ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static InvitationParams ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<InvitationParams, Builder>.PrintField("invitation_message", this.hasInvitationMessage, this.invitationMessage_, writer);
            GeneratedMessageLite<InvitationParams, Builder>.PrintField("expiration_time", this.hasExpirationTime, this.expirationTime_, writer);
            base.PrintTo(writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _invitationParamsFieldNames;
            ExtendableMessageLite<InvitationParams, Builder>.ExtensionWriter writer = base.CreateExtensionWriter(this);
            if (this.hasInvitationMessage)
            {
                output.WriteString(1, strArray[1], this.InvitationMessage);
            }
            if (this.hasExpirationTime)
            {
                output.WriteUInt64(2, strArray[0], this.ExpirationTime);
            }
            writer.WriteUntil(0x2710, output);
        }

        public static InvitationParams DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override InvitationParams DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        [CLSCompliant(false)]
        public ulong ExpirationTime
        {
            get
            {
                return this.expirationTime_;
            }
        }

        public bool HasExpirationTime
        {
            get
            {
                return this.hasExpirationTime;
            }
        }

        public bool HasInvitationMessage
        {
            get
            {
                return this.hasInvitationMessage;
            }
        }

        public string InvitationMessage
        {
            get
            {
                return this.invitationMessage_;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!base.ExtensionsAreInitialized)
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
                    if (this.hasInvitationMessage)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(1, this.InvitationMessage);
                    }
                    if (this.hasExpirationTime)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(2, this.ExpirationTime);
                    }
                    memoizedSerializedSize += base.ExtensionsSerializedSize;
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override InvitationParams ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : ExtendableBuilderLite<InvitationParams, InvitationParams.Builder>
        {
            private InvitationParams result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = InvitationParams.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(InvitationParams cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override InvitationParams BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override InvitationParams.Builder Clear()
            {
                this.result = InvitationParams.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public InvitationParams.Builder ClearExpirationTime()
            {
                this.PrepareBuilder();
                this.result.hasExpirationTime = false;
                this.result.expirationTime_ = 0L;
                return this;
            }

            public InvitationParams.Builder ClearInvitationMessage()
            {
                this.PrepareBuilder();
                this.result.hasInvitationMessage = false;
                this.result.invitationMessage_ = string.Empty;
                return this;
            }

            public override InvitationParams.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new InvitationParams.Builder(this.result);
                }
                return new InvitationParams.Builder().MergeFrom(this.result);
            }

            public override InvitationParams.Builder MergeFrom(InvitationParams other)
            {
                if (other != InvitationParams.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasInvitationMessage)
                    {
                        this.InvitationMessage = other.InvitationMessage;
                    }
                    if (other.HasExpirationTime)
                    {
                        this.ExpirationTime = other.ExpirationTime;
                    }
                    base.MergeExtensionFields(other);
                }
                return this;
            }

            public override InvitationParams.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override InvitationParams.Builder MergeFrom(IMessageLite other)
            {
                if (other is InvitationParams)
                {
                    return this.MergeFrom((InvitationParams) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override InvitationParams.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(InvitationParams._invitationParamsFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = InvitationParams._invitationParamsFieldTags[index];
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

                        case 10:
                        {
                            this.result.hasInvitationMessage = input.ReadString(ref this.result.invitationMessage_);
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
                    this.result.hasExpirationTime = input.ReadUInt64(ref this.result.expirationTime_);
                }
                return this;
            }

            private InvitationParams PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    InvitationParams result = this.result;
                    this.result = new InvitationParams();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public InvitationParams.Builder SetExpirationTime(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasExpirationTime = true;
                this.result.expirationTime_ = value;
                return this;
            }

            public InvitationParams.Builder SetInvitationMessage(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasInvitationMessage = true;
                this.result.invitationMessage_ = value;
                return this;
            }

            public override InvitationParams DefaultInstanceForType
            {
                get
                {
                    return InvitationParams.DefaultInstance;
                }
            }

            [CLSCompliant(false)]
            public ulong ExpirationTime
            {
                get
                {
                    return this.result.ExpirationTime;
                }
                set
                {
                    this.SetExpirationTime(value);
                }
            }

            public bool HasExpirationTime
            {
                get
                {
                    return this.result.hasExpirationTime;
                }
            }

            public bool HasInvitationMessage
            {
                get
                {
                    return this.result.hasInvitationMessage;
                }
            }

            public string InvitationMessage
            {
                get
                {
                    return this.result.InvitationMessage;
                }
                set
                {
                    this.SetInvitationMessage(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override InvitationParams MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override InvitationParams.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

