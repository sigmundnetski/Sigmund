namespace bnet.protocol.invitation
{
    using bnet.protocol;
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class Invitation : ExtendableMessageLite<Invitation, Builder>
    {
        private static readonly string[] _invitationFieldNames = new string[] { "creation_time", "expiration_time", "id", "invitation_message", "invitee_identity", "invitee_name", "inviter_identity", "inviter_name" };
        private static readonly uint[] _invitationFieldTags = new uint[] { 0x38, 0x40, 9, 50, 0x1a, 0x2a, 0x12, 0x22 };
        private ulong creationTime_;
        public const int CreationTimeFieldNumber = 7;
        private static readonly Invitation defaultInstance = new Invitation().MakeReadOnly();
        private ulong expirationTime_;
        public const int ExpirationTimeFieldNumber = 8;
        private bool hasCreationTime;
        private bool hasExpirationTime;
        private bool hasId;
        private bool hasInvitationMessage;
        private bool hasInviteeIdentity;
        private bool hasInviteeName;
        private bool hasInviterIdentity;
        private bool hasInviterName;
        private ulong id_;
        public const int IdFieldNumber = 1;
        private string invitationMessage_ = string.Empty;
        public const int InvitationMessageFieldNumber = 6;
        private Identity inviteeIdentity_;
        public const int InviteeIdentityFieldNumber = 3;
        private string inviteeName_ = string.Empty;
        public const int InviteeNameFieldNumber = 5;
        private Identity inviterIdentity_;
        public const int InviterIdentityFieldNumber = 2;
        private string inviterName_ = string.Empty;
        public const int InviterNameFieldNumber = 4;
        private int memoizedSerializedSize = -1;

        static Invitation()
        {
            object.ReferenceEquals(InvitationTypes.Descriptor, null);
        }

        private Invitation()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(Invitation prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            Invitation invitation = obj as Invitation;
            if (invitation == null)
            {
                return false;
            }
            if ((this.hasId != invitation.hasId) || (this.hasId && !this.id_.Equals(invitation.id_)))
            {
                return false;
            }
            if ((this.hasInviterIdentity != invitation.hasInviterIdentity) || (this.hasInviterIdentity && !this.inviterIdentity_.Equals(invitation.inviterIdentity_)))
            {
                return false;
            }
            if ((this.hasInviteeIdentity != invitation.hasInviteeIdentity) || (this.hasInviteeIdentity && !this.inviteeIdentity_.Equals(invitation.inviteeIdentity_)))
            {
                return false;
            }
            if ((this.hasInviterName != invitation.hasInviterName) || (this.hasInviterName && !this.inviterName_.Equals(invitation.inviterName_)))
            {
                return false;
            }
            if ((this.hasInviteeName != invitation.hasInviteeName) || (this.hasInviteeName && !this.inviteeName_.Equals(invitation.inviteeName_)))
            {
                return false;
            }
            if ((this.hasInvitationMessage != invitation.hasInvitationMessage) || (this.hasInvitationMessage && !this.invitationMessage_.Equals(invitation.invitationMessage_)))
            {
                return false;
            }
            if ((this.hasCreationTime != invitation.hasCreationTime) || (this.hasCreationTime && !this.creationTime_.Equals(invitation.creationTime_)))
            {
                return false;
            }
            if ((this.hasExpirationTime != invitation.hasExpirationTime) || (this.hasExpirationTime && !this.expirationTime_.Equals(invitation.expirationTime_)))
            {
                return false;
            }
            if (!base.Equals(invitation))
            {
                return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasId)
            {
                hashCode ^= this.id_.GetHashCode();
            }
            if (this.hasInviterIdentity)
            {
                hashCode ^= this.inviterIdentity_.GetHashCode();
            }
            if (this.hasInviteeIdentity)
            {
                hashCode ^= this.inviteeIdentity_.GetHashCode();
            }
            if (this.hasInviterName)
            {
                hashCode ^= this.inviterName_.GetHashCode();
            }
            if (this.hasInviteeName)
            {
                hashCode ^= this.inviteeName_.GetHashCode();
            }
            if (this.hasInvitationMessage)
            {
                hashCode ^= this.invitationMessage_.GetHashCode();
            }
            if (this.hasCreationTime)
            {
                hashCode ^= this.creationTime_.GetHashCode();
            }
            if (this.hasExpirationTime)
            {
                hashCode ^= this.expirationTime_.GetHashCode();
            }
            return (hashCode ^ base.GetHashCode());
        }

        private Invitation MakeReadOnly()
        {
            return this;
        }

        public static Invitation ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static Invitation ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static Invitation ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Invitation ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Invitation ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Invitation ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Invitation ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static Invitation ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Invitation ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Invitation ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<Invitation, Builder>.PrintField("id", this.hasId, this.id_, writer);
            GeneratedMessageLite<Invitation, Builder>.PrintField("inviter_identity", this.hasInviterIdentity, this.inviterIdentity_, writer);
            GeneratedMessageLite<Invitation, Builder>.PrintField("invitee_identity", this.hasInviteeIdentity, this.inviteeIdentity_, writer);
            GeneratedMessageLite<Invitation, Builder>.PrintField("inviter_name", this.hasInviterName, this.inviterName_, writer);
            GeneratedMessageLite<Invitation, Builder>.PrintField("invitee_name", this.hasInviteeName, this.inviteeName_, writer);
            GeneratedMessageLite<Invitation, Builder>.PrintField("invitation_message", this.hasInvitationMessage, this.invitationMessage_, writer);
            GeneratedMessageLite<Invitation, Builder>.PrintField("creation_time", this.hasCreationTime, this.creationTime_, writer);
            GeneratedMessageLite<Invitation, Builder>.PrintField("expiration_time", this.hasExpirationTime, this.expirationTime_, writer);
            base.PrintTo(writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _invitationFieldNames;
            ExtendableMessageLite<Invitation, Builder>.ExtensionWriter writer = base.CreateExtensionWriter(this);
            if (this.hasId)
            {
                output.WriteFixed64(1, strArray[2], this.Id);
            }
            if (this.hasInviterIdentity)
            {
                output.WriteMessage(2, strArray[6], this.InviterIdentity);
            }
            if (this.hasInviteeIdentity)
            {
                output.WriteMessage(3, strArray[4], this.InviteeIdentity);
            }
            if (this.hasInviterName)
            {
                output.WriteString(4, strArray[7], this.InviterName);
            }
            if (this.hasInviteeName)
            {
                output.WriteString(5, strArray[5], this.InviteeName);
            }
            if (this.hasInvitationMessage)
            {
                output.WriteString(6, strArray[3], this.InvitationMessage);
            }
            if (this.hasCreationTime)
            {
                output.WriteUInt64(7, strArray[0], this.CreationTime);
            }
            if (this.hasExpirationTime)
            {
                output.WriteUInt64(8, strArray[1], this.ExpirationTime);
            }
            writer.WriteUntil(0x2710, output);
        }

        [CLSCompliant(false)]
        public ulong CreationTime
        {
            get
            {
                return this.creationTime_;
            }
        }

        public static Invitation DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override Invitation DefaultInstanceForType
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

        public bool HasCreationTime
        {
            get
            {
                return this.hasCreationTime;
            }
        }

        public bool HasExpirationTime
        {
            get
            {
                return this.hasExpirationTime;
            }
        }

        public bool HasId
        {
            get
            {
                return this.hasId;
            }
        }

        public bool HasInvitationMessage
        {
            get
            {
                return this.hasInvitationMessage;
            }
        }

        public bool HasInviteeIdentity
        {
            get
            {
                return this.hasInviteeIdentity;
            }
        }

        public bool HasInviteeName
        {
            get
            {
                return this.hasInviteeName;
            }
        }

        public bool HasInviterIdentity
        {
            get
            {
                return this.hasInviterIdentity;
            }
        }

        public bool HasInviterName
        {
            get
            {
                return this.hasInviterName;
            }
        }

        [CLSCompliant(false)]
        public ulong Id
        {
            get
            {
                return this.id_;
            }
        }

        public string InvitationMessage
        {
            get
            {
                return this.invitationMessage_;
            }
        }

        public Identity InviteeIdentity
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.inviteeIdentity_ != null)
                {
                    goto Label_0012;
                }
                return Identity.DefaultInstance;
            }
        }

        public string InviteeName
        {
            get
            {
                return this.inviteeName_;
            }
        }

        public Identity InviterIdentity
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.inviterIdentity_ != null)
                {
                    goto Label_0012;
                }
                return Identity.DefaultInstance;
            }
        }

        public string InviterName
        {
            get
            {
                return this.inviterName_;
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
                if (!this.hasInviterIdentity)
                {
                    return false;
                }
                if (!this.hasInviteeIdentity)
                {
                    return false;
                }
                if (!this.InviterIdentity.IsInitialized)
                {
                    return false;
                }
                if (!this.InviteeIdentity.IsInitialized)
                {
                    return false;
                }
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
                    if (this.hasId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed64Size(1, this.Id);
                    }
                    if (this.hasInviterIdentity)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, this.InviterIdentity);
                    }
                    if (this.hasInviteeIdentity)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(3, this.InviteeIdentity);
                    }
                    if (this.hasInviterName)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(4, this.InviterName);
                    }
                    if (this.hasInviteeName)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(5, this.InviteeName);
                    }
                    if (this.hasInvitationMessage)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(6, this.InvitationMessage);
                    }
                    if (this.hasCreationTime)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(7, this.CreationTime);
                    }
                    if (this.hasExpirationTime)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(8, this.ExpirationTime);
                    }
                    memoizedSerializedSize += base.ExtensionsSerializedSize;
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override Invitation ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : ExtendableBuilderLite<Invitation, Invitation.Builder>
        {
            private Invitation result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = Invitation.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(Invitation cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override Invitation BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override Invitation.Builder Clear()
            {
                this.result = Invitation.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public Invitation.Builder ClearCreationTime()
            {
                this.PrepareBuilder();
                this.result.hasCreationTime = false;
                this.result.creationTime_ = 0L;
                return this;
            }

            public Invitation.Builder ClearExpirationTime()
            {
                this.PrepareBuilder();
                this.result.hasExpirationTime = false;
                this.result.expirationTime_ = 0L;
                return this;
            }

            public Invitation.Builder ClearId()
            {
                this.PrepareBuilder();
                this.result.hasId = false;
                this.result.id_ = 0L;
                return this;
            }

            public Invitation.Builder ClearInvitationMessage()
            {
                this.PrepareBuilder();
                this.result.hasInvitationMessage = false;
                this.result.invitationMessage_ = string.Empty;
                return this;
            }

            public Invitation.Builder ClearInviteeIdentity()
            {
                this.PrepareBuilder();
                this.result.hasInviteeIdentity = false;
                this.result.inviteeIdentity_ = null;
                return this;
            }

            public Invitation.Builder ClearInviteeName()
            {
                this.PrepareBuilder();
                this.result.hasInviteeName = false;
                this.result.inviteeName_ = string.Empty;
                return this;
            }

            public Invitation.Builder ClearInviterIdentity()
            {
                this.PrepareBuilder();
                this.result.hasInviterIdentity = false;
                this.result.inviterIdentity_ = null;
                return this;
            }

            public Invitation.Builder ClearInviterName()
            {
                this.PrepareBuilder();
                this.result.hasInviterName = false;
                this.result.inviterName_ = string.Empty;
                return this;
            }

            public override Invitation.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new Invitation.Builder(this.result);
                }
                return new Invitation.Builder().MergeFrom(this.result);
            }

            public override Invitation.Builder MergeFrom(Invitation other)
            {
                if (other != Invitation.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasId)
                    {
                        this.Id = other.Id;
                    }
                    if (other.HasInviterIdentity)
                    {
                        this.MergeInviterIdentity(other.InviterIdentity);
                    }
                    if (other.HasInviteeIdentity)
                    {
                        this.MergeInviteeIdentity(other.InviteeIdentity);
                    }
                    if (other.HasInviterName)
                    {
                        this.InviterName = other.InviterName;
                    }
                    if (other.HasInviteeName)
                    {
                        this.InviteeName = other.InviteeName;
                    }
                    if (other.HasInvitationMessage)
                    {
                        this.InvitationMessage = other.InvitationMessage;
                    }
                    if (other.HasCreationTime)
                    {
                        this.CreationTime = other.CreationTime;
                    }
                    if (other.HasExpirationTime)
                    {
                        this.ExpirationTime = other.ExpirationTime;
                    }
                    base.MergeExtensionFields(other);
                }
                return this;
            }

            public override Invitation.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override Invitation.Builder MergeFrom(IMessageLite other)
            {
                if (other is Invitation)
                {
                    return this.MergeFrom((Invitation) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override Invitation.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(Invitation._invitationFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = Invitation._invitationFieldTags[index];
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

                        case 9:
                        {
                            this.result.hasId = input.ReadFixed64(ref this.result.id_);
                            continue;
                        }
                        case 0x12:
                        {
                            Identity.Builder builder = Identity.CreateBuilder();
                            if (this.result.hasInviterIdentity)
                            {
                                builder.MergeFrom(this.InviterIdentity);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.InviterIdentity = builder.BuildPartial();
                            continue;
                        }
                        case 0x1a:
                        {
                            Identity.Builder builder2 = Identity.CreateBuilder();
                            if (this.result.hasInviteeIdentity)
                            {
                                builder2.MergeFrom(this.InviteeIdentity);
                            }
                            input.ReadMessage(builder2, extensionRegistry);
                            this.InviteeIdentity = builder2.BuildPartial();
                            continue;
                        }
                        case 0x22:
                        {
                            this.result.hasInviterName = input.ReadString(ref this.result.inviterName_);
                            continue;
                        }
                        case 0x2a:
                        {
                            this.result.hasInviteeName = input.ReadString(ref this.result.inviteeName_);
                            continue;
                        }
                        case 50:
                        {
                            this.result.hasInvitationMessage = input.ReadString(ref this.result.invitationMessage_);
                            continue;
                        }
                        case 0x38:
                        {
                            this.result.hasCreationTime = input.ReadUInt64(ref this.result.creationTime_);
                            continue;
                        }
                        case 0x40:
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

            public Invitation.Builder MergeInviteeIdentity(Identity value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasInviteeIdentity && (this.result.inviteeIdentity_ != Identity.DefaultInstance))
                {
                    this.result.inviteeIdentity_ = Identity.CreateBuilder(this.result.inviteeIdentity_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.inviteeIdentity_ = value;
                }
                this.result.hasInviteeIdentity = true;
                return this;
            }

            public Invitation.Builder MergeInviterIdentity(Identity value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasInviterIdentity && (this.result.inviterIdentity_ != Identity.DefaultInstance))
                {
                    this.result.inviterIdentity_ = Identity.CreateBuilder(this.result.inviterIdentity_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.inviterIdentity_ = value;
                }
                this.result.hasInviterIdentity = true;
                return this;
            }

            private Invitation PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    Invitation result = this.result;
                    this.result = new Invitation();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public Invitation.Builder SetCreationTime(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasCreationTime = true;
                this.result.creationTime_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public Invitation.Builder SetExpirationTime(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasExpirationTime = true;
                this.result.expirationTime_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public Invitation.Builder SetId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasId = true;
                this.result.id_ = value;
                return this;
            }

            public Invitation.Builder SetInvitationMessage(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasInvitationMessage = true;
                this.result.invitationMessage_ = value;
                return this;
            }

            public Invitation.Builder SetInviteeIdentity(Identity value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasInviteeIdentity = true;
                this.result.inviteeIdentity_ = value;
                return this;
            }

            public Invitation.Builder SetInviteeIdentity(Identity.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasInviteeIdentity = true;
                this.result.inviteeIdentity_ = builderForValue.Build();
                return this;
            }

            public Invitation.Builder SetInviteeName(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasInviteeName = true;
                this.result.inviteeName_ = value;
                return this;
            }

            public Invitation.Builder SetInviterIdentity(Identity value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasInviterIdentity = true;
                this.result.inviterIdentity_ = value;
                return this;
            }

            public Invitation.Builder SetInviterIdentity(Identity.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasInviterIdentity = true;
                this.result.inviterIdentity_ = builderForValue.Build();
                return this;
            }

            public Invitation.Builder SetInviterName(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasInviterName = true;
                this.result.inviterName_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public ulong CreationTime
            {
                get
                {
                    return this.result.CreationTime;
                }
                set
                {
                    this.SetCreationTime(value);
                }
            }

            public override Invitation DefaultInstanceForType
            {
                get
                {
                    return Invitation.DefaultInstance;
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

            public bool HasCreationTime
            {
                get
                {
                    return this.result.hasCreationTime;
                }
            }

            public bool HasExpirationTime
            {
                get
                {
                    return this.result.hasExpirationTime;
                }
            }

            public bool HasId
            {
                get
                {
                    return this.result.hasId;
                }
            }

            public bool HasInvitationMessage
            {
                get
                {
                    return this.result.hasInvitationMessage;
                }
            }

            public bool HasInviteeIdentity
            {
                get
                {
                    return this.result.hasInviteeIdentity;
                }
            }

            public bool HasInviteeName
            {
                get
                {
                    return this.result.hasInviteeName;
                }
            }

            public bool HasInviterIdentity
            {
                get
                {
                    return this.result.hasInviterIdentity;
                }
            }

            public bool HasInviterName
            {
                get
                {
                    return this.result.hasInviterName;
                }
            }

            [CLSCompliant(false)]
            public ulong Id
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

            public Identity InviteeIdentity
            {
                get
                {
                    return this.result.InviteeIdentity;
                }
                set
                {
                    this.SetInviteeIdentity(value);
                }
            }

            public string InviteeName
            {
                get
                {
                    return this.result.InviteeName;
                }
                set
                {
                    this.SetInviteeName(value);
                }
            }

            public Identity InviterIdentity
            {
                get
                {
                    return this.result.InviterIdentity;
                }
                set
                {
                    this.SetInviterIdentity(value);
                }
            }

            public string InviterName
            {
                get
                {
                    return this.result.InviterName;
                }
                set
                {
                    this.SetInviterName(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override Invitation MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override Invitation.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

